namespace PachaSystemERP.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using PachaSystemERP.Enums;

    public class GeneradorComprobante : INotifyPropertyChanged
    {
        private FacturaElectronica _facturaElectronica;
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;
        private Comprobante _comprobante;
        private List<DetalleProducto> _detalleProducto;
        private int _cantidadTotal;
        private decimal _importeTotal;
        private string _numeroComprobante;

        public GeneradorComprobante(TipoComprobante tipoComprobante)
        {
            if (tipoComprobante == null)
            {
                throw new ArgumentNullException(nameof(tipoComprobante));
            }

            _facturaElectronica = new FacturaElectronica();
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _comprobante = new Comprobante();
            _numeroComprobante = _facturaElectronica.SincronizarNumeroComprobante(tipoComprobante);
            _comprobante.PuntoVenta = Configuracion.PuntoVenta;
            _comprobante.TipoComprobanteID = tipoComprobante.ID;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<DetalleProducto> DetalleFacturacion
        {
            get
            {
                if (_detalleProducto == null)
                {
                    _detalleProducto = new List<DetalleProducto>();
                }

                return _detalleProducto;
            }

            set
            {
                _detalleProducto = value;
            }
        }

        public int CantidadTotal
        {
            get
            {
                return _cantidadTotal;
            }

            private set
            {
                if (_cantidadTotal == value)
                {
                    return;
                }

                _cantidadTotal = value;
                NotifyPropertyChanged();
            }
        }

        public decimal ImporteTotal
        {
            get
            {
                return _importeTotal;
            }

            private set
            {
                if (_importeTotal == value)
                {
                    return;
                }

                _importeTotal = value;
                NotifyPropertyChanged();
            }
        }

        public string NumeroComprobante
        {
            get
            {
                return _numeroComprobante;
            }
        }

        public void AgregarProducto(string codigoProducto, int cantidad)
        {
            var query = _unitOfWork.Producto.Obtener(x => x.Codigo == codigoProducto);
            DetalleProducto detalle = new DetalleProducto();
            detalle.ProductoID = query.ID;
            detalle.Codigo = query.Codigo;
            detalle.Descripcion = query.Descripcion;
            detalle.Cantidad = cantidad;
            detalle.PrecioUnitario = query.PrecioUnitario;
            detalle.AlicuotaIva = query.TipoCondicionIva.Alicuota;

            _detalleProducto.Add(detalle);
            CantidadTotal = _detalleProducto.Sum(x => x.Cantidad);
            ImporteTotal = _detalleProducto.Sum(x => x.Subtotal);
        }

        public void AgregarCliente(string razonSocial, int tipoDocumentoID, string numeroDocumento, int tipoResponsableID, string domicilio)
        {
            Cliente cliente = new Cliente();
            cliente.RazonSocial = razonSocial;
            cliente.TipoDocumentoID = tipoDocumentoID;
            cliente.NumeroDocumento = numeroDocumento;
            cliente.TipoResponsableID = tipoResponsableID;
            cliente.Domicilio = domicilio;
            _comprobante.Cliente = cliente;
        }

        public Comprobante GenerarComprobante(TipoConcepto tipoConcepto)
        {
            if (_detalleProducto.Count == 0)
            {
                throw new ArgumentException("No se pudo generar el comprobante porque no se cargo ningún producto");
            }
            else
            {
                _comprobante.TipoConceptoID = tipoConcepto.ID;
                _comprobante.FechaComprobante = DateTime.Now;
                _comprobante.TipoMoneda = _unitOfWork.TipoMoneda.Obtener(x => x.ID == 2);
                _comprobante.CotizacionMoneda = 1;
                _comprobante.ImporteNeto = _detalleProducto.Sum(x => x.BaseImponible);
                _comprobante.ImporteNetoNoGravado = 0;
                _comprobante.ImporteExento = 0;
                _comprobante.ImporteTotalIva = _detalleProducto.Sum(x => x.ImporteIva);
                _comprobante.ImporteTotalTributo = _detalleProducto.Sum(x => x.ImporteTributo);
                _comprobante.ImporteTotal = _comprobante.ImporteNeto + _comprobante.ImporteNetoNoGravado + _comprobante.ImporteExento + _comprobante.ImporteTotalIva + _comprobante.ImporteTotalTributo;

                foreach (var item in _detalleProducto)
                {
                    DetalleComprobante detalle = new DetalleComprobante();
                    detalle.ComprobanteID = _comprobante.ID;
                    detalle.Producto = _unitOfWork.Producto.Obtener(x => x.ID == item.ProductoID);
                    detalle.Cantidad = item.Cantidad;
                    detalle.ImporteIva = item.ImporteIva;
                    detalle.BaseImponible = item.BaseImponible;
                    detalle.Subtotal = item.Subtotal;

                    _comprobante.DetalleComprobante.Add(detalle);
                }

                if (_comprobante.Cliente == null)
                {
                    Cliente cliente = new Cliente();
                    cliente = _unitOfWork.Cliente.Obtener(x => x.RazonSocial == "CONSUMIDOR FINAL");
                    _comprobante.Cliente = cliente;
                }

                var response = _facturaElectronica.GenerarComprobante(_comprobante);

                if (response.CabeceraResponse.Resultado == "A")
                {
                    _comprobante.CAE = response.DetalleResponse.Select(x => x.CAE).First();
                    _comprobante.FechaVencimientoCAE = DateTime.ParseExact(response.DetalleResponse.Select(x => x.FechaVencimientoCAE).First(), "yyyyMMdd", CultureInfo.CurrentCulture);
                }
            }

            _unitOfWork.Comprobante.Agregar(_comprobante);
            _unitOfWork.Guardar();

            return _comprobante;
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
