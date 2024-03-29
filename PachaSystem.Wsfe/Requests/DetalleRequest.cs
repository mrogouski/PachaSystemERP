﻿// <copyright file="DetalleRequest.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Requests
{
    using PachaSystem.Wsfe.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "FEDetRequest", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class DetalleRequest
    {
        private int _concepto;
        private int _tipoDeDocumento;
        private long _numeroDeDocumento;
        private long _numeroDeComprobanteInicial;
        private long _numeroDeComprobanteFinal;
        private string _fechaDeComprobante;
        private double _importeTotal;
        private double _importeNetoNoGravado;
        private double _importeNetoGravado;
        private double _importeExento;
        private double _importeIva;
        private double _importeTributo;
        private string _fechaDeInicioDeServicio;
        private string _fechaDeFinalizacionDeServicio;
        private string _fechaDeVencimientoDePago;
        private string _idMoneda;
        private double _cotizacionMoneda;
        private List<ComprobanteAsociado> _comprobantesAsociados;
        private List<Tributo> _tributo;
        private List<AlicuotaIva> _iva;
        private List<Opcional> _opcionales;
        private List<Comprador> _compradores;

        [DataMember(IsRequired = true, Name = "Concepto", Order = 0)]
        public int Concepto
        {
            get
            {
                return _concepto;
            }

            set
            {
                _concepto = value;
            }
        }

        [DataMember(Name = "DocTipo", Order = 1)]
        public int TipoDeDocumento
        {
            get
            {
                return _tipoDeDocumento;
            }

            set
            {
                _tipoDeDocumento = value;
            }
        }

        [DataMember(Name = "DocNro", Order = 2)]
        public long NumeroDeDocumento
        {
            get
            {
                return _numeroDeDocumento;
            }

            set
            {
                _numeroDeDocumento = value;
            }
        }

        [DataMember(Name = "CbteDesde", Order = 3)]
        public long ComprobanteDesde
        {
            get
            {
                return _numeroDeComprobanteInicial;
            }

            set
            {
                _numeroDeComprobanteInicial = value;
            }
        }

        [DataMember(Name = "CbteHasta", Order = 4)]
        public long ComprobanteHasta
        {
            get
            {
                return _numeroDeComprobanteFinal;
            }

            set
            {
                _numeroDeComprobanteFinal = value;
            }
        }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "CbteFch", Order = 5)]
        public string FechaDeComprobante
        {
            get
            {
                return _fechaDeComprobante;
            }

            set
            {
                _fechaDeComprobante = value;
            }
        }

        [DataMember(Name = "ImpTotal", Order = 6)]
        public double ImporteTotal
        {
            get
            {
                return _importeTotal;
            }

            set
            {
                _importeTotal = value;
            }
        }

        [DataMember(Name = "ImpTotConc", Order = 7)]
        public double ImporteNetoNoGravado
        {
            get
            {
                return _importeNetoNoGravado;
            }

            set
            {
                _importeNetoNoGravado = value;
            }
        }

        [DataMember(Name = "ImpNeto", Order = 8)]
        public double ImporteNeto
        {
            get
            {
                return _importeNetoGravado;
            }

            set
            {
                _importeNetoGravado = value;
            }
        }

        [DataMember(Name = "ImpOpEx", Order = 9)]
        public double ImporteExento
        {
            get
            {
                return _importeExento;
            }

            set
            {
                _importeExento = value;
            }
        }

        [DataMember(Name = "ImpTrib", Order = 10)]
        public double ImporteTributo
        {
            get
            {
                return _importeTributo;
            }

            set
            {
                _importeTributo = value;
            }
        }

        [DataMember(Name = "ImpIVA", Order = 11)]
        public double ImporteIVA
        {
            get
            {
                return _importeIva;
            }

            set
            {
                _importeIva = value;
            }
        }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "FchServDesde", Order = 12)]
        public string FechaServicioDesde
        {
            get
            {
                return _fechaDeInicioDeServicio;
            }

            set
            {
                _fechaDeInicioDeServicio = value;
            }
        }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "FchServHasta", Order = 13)]
        public string FechaServicioHasta
        {
            get
            {
                return _fechaDeFinalizacionDeServicio;
            }

            set
            {
                _fechaDeFinalizacionDeServicio = value;
            }
        }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "FchVtoPago", Order = 14)]
        public string FechaVencimientoDePago
        {
            get
            {
                return _fechaDeVencimientoDePago;
            }

            set
            {
                _fechaDeVencimientoDePago = value;
            }
        }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Name = "MonId", Order = 15)]
        public string CodigoMoneda
        {
            get
            {
                return _idMoneda;
            }

            set
            {
                _idMoneda = value;
            }
        }

        [DataMember(Name = "MonCotiz", Order = 16)]
        public double MonedaCotizacion
        {
            get
            {
                return _cotizacionMoneda;
            }

            set
            {
                _cotizacionMoneda = value;
            }
        }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "CbtesAsoc", Order = 17)]
        public List<ComprobanteAsociado> ComprobantesAsociados
        {
            get
            {
                return _comprobantesAsociados;
            }

            set
            {
                _comprobantesAsociados = value;
            }
        }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "Tributos", Order = 18)]
        public List<Tributo> Tributos
        {
            get
            {
                return _tributo;
            }

            set
            {
                _tributo = value;
            }
        }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "Iva", Order = 19)]
        public List<AlicuotaIva> AlicuotaIVA
        {
            get
            {
                return _iva;
            }

            set
            {
                _iva = value;
            }
        }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "Opcionales", Order = 20)]
        public List<Opcional> Opcionales
        {
            get
            {
                return _opcionales;
            }

            set
            {
                _opcionales = value;
            }
        }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "Compradores", Order = 21)]
        public List<Comprador> Compradores
        {
            get
            {
                return _compradores;
            }

            set
            {
                _compradores = value;
            }
        }

        public void AgregarIva(int ivaId, decimal baseImponible, decimal importe)
        {
            if (_iva == null)
            {
                _iva = new List<AlicuotaIva>();
            }

            var currentIva = _iva.Find(x => x.ID == ivaId);

            if (currentIva != null)
            {
                currentIva.BaseImponible += decimal.ToDouble(baseImponible);
                currentIva.Importe += decimal.ToDouble(importe);
            }
            else
            {
                var iva = new AlicuotaIva();
                iva.ID = ivaId;
                iva.BaseImponible = decimal.ToDouble(baseImponible);
                iva.Importe = decimal.ToDouble(importe);
                _iva.Add(iva);
            }
        }

        public void AgregarTributo(short tributoID, string descripcion, decimal baseImponible, decimal alicuota, decimal importe)
        {
            if (_tributo == null)
            {
                _tributo = new List<Tributo>();
            }

            var tributo = new Tributo();
            tributo.ID = tributoID;
            tributo.Descripcion = descripcion;
            tributo.BaseImponible = decimal.ToDouble(baseImponible);
            tributo.Alicuota = decimal.ToDouble(alicuota);
            tributo.Importe = decimal.ToDouble(importe);
            _tributo.Add(tributo);
        }
    }
}