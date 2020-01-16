namespace PachaSystemERP.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    public class ItemDetailsView : INotifyPropertyChanged
    {
        private int _ID;
        private string _code;
        private string _name;
        private int _quantity;
        private decimal _unitPrice;
        private decimal _vatAliquot;
        private decimal _vatAmount;
        private decimal _taxBase;
        private decimal _subtotal;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ItemID
        {
            get
            {
                return _ID;
            }

            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    NotifyPropertyChanged();
                }
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
                if (_code != value)
                {
                    _code = value;
                    NotifyPropertyChanged();
                }
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
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
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
                if (_quantity != value)
                {
                    _quantity = value;
                    NotifyPropertyChanged();
                }
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
                if (_unitPrice != value)
                {
                    _unitPrice = value;
                    NotifyPropertyChanged();
                }
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
                if (_vatAliquot != value)
                {
                    _vatAliquot = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal VatAmount
        {
            get
            {
                return _vatAmount;
            }

            set
            {
                if (_vatAmount != value)
                {
                    _vatAmount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal TaxBase
        {
            get
            {
                return _taxBase;
            }

            set
            {
                if (_taxBase != value)
                {
                    _taxBase = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal Subtotal
        {
            get
            {
                return _subtotal;
            }

            set
            {
                if (_subtotal != value)
                {
                    _subtotal = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
