namespace PachaSystemERP.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    public class DetalleProducto : INotifyPropertyChanged
    {
        private int _productoID;
        private string _codigo;
        private string _descripcion;
        private int _cantidad;
        private decimal _precioUnitario;
        private decimal _alicuotaIva;
        private decimal _alicuotaTributo;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ProductoID
        {
            get
            {
                return _productoID;
            }

            set
            {
                if (_productoID == value)
                {
                    return;
                }

                _productoID = value;
                NotifyPropertyChanged();
            }
        }

        public string Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                if (_codigo == value)
                {
                    return;
                }

                _codigo = value;
                NotifyPropertyChanged();
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                if (_descripcion == value)
                {
                    return;
                }

                _descripcion = value;
                NotifyPropertyChanged();
            }
        }

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }

            set
            {
                if (_cantidad == value)
                {
                    return;
                }

                _cantidad = value;
                NotifyPropertyChanged();
            }
        }

        public decimal PrecioUnitario
        {
            get
            {
                return _precioUnitario;
            }

            set
            {
                if (_precioUnitario == value)
                {
                    return;
                }

                _precioUnitario = value;
                NotifyPropertyChanged();
            }
        }

        public decimal AlicuotaIva
        {
            get
            {
                return _alicuotaIva;
            }

            set
            {
                if (_alicuotaIva == value)
                {
                    return;
                }

                _alicuotaIva = value;
                NotifyPropertyChanged();
            }
        }

        public decimal ImporteIva
        {
            get
            {
                if (_alicuotaIva > 0)
                {
                    return decimal.Round(_precioUnitario * (_alicuotaIva / 100), 2, MidpointRounding.ToEven);
                }
                else
                {
                    return 0;
                }
            }
        }

        public decimal AlicuotaTributo
        {
            get
            {
                return _alicuotaTributo;
            }

            set
            {
                if (_alicuotaTributo == value)
                {
                    return;
                }

                _alicuotaTributo = value;
                NotifyPropertyChanged();
            }
        }

        public decimal ImporteTributo
        {
            get
            {
                if (_alicuotaTributo > 0)
                {
                    return decimal.Round(_precioUnitario * (_alicuotaTributo / 100), 2, MidpointRounding.ToEven);
                }
                else
                {
                    return 0;
                }
            }
        }

        public decimal BaseImponible
        {
            get
            {
                return decimal.Round(_precioUnitario * _cantidad, 2, MidpointRounding.ToEven);
            }
        }

        public decimal Subtotal
        {
            get
            {
                return decimal.Round((_precioUnitario + ImporteIva + ImporteTributo) * _cantidad, 2, MidpointRounding.ToEven);
            }
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
