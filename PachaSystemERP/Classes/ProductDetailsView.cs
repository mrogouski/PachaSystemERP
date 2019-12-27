namespace PachaSystemERP.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductDetailsView : INotifyPropertyChanged
    {
        private int _productID;
        private string _code;
        private string _name;
        private int _quantity;
        private decimal _unitPrice;
        private decimal _vatAliquot;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ProductID
        {
            get
            {
                return _productID;
            }

            set
            {
                if (_productID == value)
                {
                    return;
                }

                _productID = value;
                NotifyPropertyChanged();
            }
        }

        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                if (_code == value)
                {
                    return;
                }

                _code = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;
                NotifyPropertyChanged();
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                if (_quantity == value)
                {
                    return;
                }

                _quantity = value;
                NotifyPropertyChanged();
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return _unitPrice;
            }

            set
            {
                if (_unitPrice == value)
                {
                    return;
                }

                _unitPrice = value;
                NotifyPropertyChanged();
            }
        }

        public decimal VatAliquot
        {
            get
            {
                return _vatAliquot;
            }

            set
            {
                if (_vatAliquot == value)
                {
                    return;
                }

                _vatAliquot = value;
                NotifyPropertyChanged();
            }
        }

        public decimal VatAmount
        {
            get
            {
                if (_vatAliquot > 0)
                {
                    return decimal.Round(TaxBase * (_vatAliquot / 100), 2, MidpointRounding.ToEven);
                }
                else
                {
                    return 0;
                }
            }
        }

        public decimal TaxBase
        {
            get
            {
                return decimal.Round(_unitPrice * _quantity, 2, MidpointRounding.ToEven);
            }
        }

        public decimal Subtotal
        {
            get
            {
                return decimal.Round((TaxBase + VatAmount), 2, MidpointRounding.ToEven);
            }
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
