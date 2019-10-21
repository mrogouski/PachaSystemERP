namespace PachaSystemERP.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    public class DetalleServicio : INotifyPropertyChanged
    {
        private int _productoID;
        private string _codigo;
        private string _descripcion;
        private int _cantidad;
        private double _precioUnitario;
        private double _alicuotaIva;
        private double _importeIva;
        private double _alicuotaTributo;
        private double _importeTributo;
        private double _subtotal;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ProductoID { get => _productoID; set => _productoID = value; }

        public string Codigo { get => _codigo; set => _codigo = value; }

        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public double AlicuotaIva
        {
            get
            {
                return _alicuotaIva;
            }

            set
            {
                NotifyPropertyChanged();
                _alicuotaIva = value;
            }
        }

        public double ImporteIva
        {
            get
            {
                if (_alicuotaIva > 0)
                {
                    return _precioUnitario * (_alicuotaIva / 100);
                }
                else
                {
                    return 0;
                }
            }
        }

        public double AlicuotaTributo
        {
            get
            {
                return _alicuotaTributo;
            }

            set
            {
                if (AlicuotaTributo == value)
                {
                    NotifyPropertyChanged();
                    _alicuotaTributo = value;
                }
            }
        }

        public double ImporteTributo
        {
            get
            {
                if (_alicuotaTributo > 0)
                {
                    return _precioUnitario * (_alicuotaTributo / 100);
                }
                else
                {
                    return 0;
                }
            }
        }

        public double ImporteNeto
        {
            get
            {
                return _precioUnitario * _cantidad;
            }
        }

        public double Subtotal
        {
            get
            {
                return (_precioUnitario + ImporteIva + ImporteTributo) * _cantidad;
            }
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
