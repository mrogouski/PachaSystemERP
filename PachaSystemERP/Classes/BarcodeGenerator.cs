using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PachaSystemERP.Classes
{
    public class BarcodeGenerator : IDisposable
    {
        private float _moduleWidth;
        private float _moduleHeight;
        private float _wideToNarrowRatio;

        public float ModuleWidth
        {
            get
            {
                return _moduleWidth;
            }
            set
            {
                if (_moduleWidth < 1.520 && _moduleWidth > 0.1)
                {
                    throw new ArgumentOutOfRangeException(nameof(ModuleWidth));
                }

                _moduleWidth = value;
            }
        }

        public float ModuleHeight
        {
            get
            {
                return _moduleHeight;
            }
            set
            {
                _moduleHeight = value;
            }
        }

        public float WideToNarrowRatio
        {
            get
            {
                return _wideToNarrowRatio;
            }
            set
            {
                if (value < 2.25 || value > 3)
                {
                    throw new ArgumentOutOfRangeException(nameof(WideToNarrowRatio));
                }

                _wideToNarrowRatio = value;
            }
        }

        public Bitmap GenerateBarcodeAFIP(string code)
        {
            var controlDigit = GetControlDigitAFIP(code);

            var encodedCode = EncodeString(code + controlDigit);

            return CreateBinaryImage(encodedCode);
        }

        private List<string> EncodeString(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }

            List<string> encodedPairs = new List<string>();
            string left = null;
            string right = null;

            for (int index = 0; index < code.Count();)
            {
                var pair = code.Substring(index, 2);
                index += 2;

                switch (pair.Substring(0, 1))
                {
                    case "0":
                        left = "00110";
                        break;
                    case "1":
                        left = "10001";
                        break;
                    case "2":
                        left = "01001";
                        break;
                    case "3":
                        left = "11000";
                        break;
                    case "4":
                        left = "00101";
                        break;
                    case "5":
                        left = "10100";
                        break;
                    case "6":
                        left = "01100";
                        break;
                    case "7":
                        left = "00011";
                        break;
                    case "8":
                        left = "10010";
                        break;
                    case "9":
                        left = "01010";
                        break;
                }

                switch (pair.Substring(1, 1))
                {
                    case "0":
                        right = "00110";
                        break;
                    case "1":
                        right = "10001";
                        break;
                    case "2":
                        right = "01001";
                        break;
                    case "3":
                        right = "11000";
                        break;
                    case "4":
                        right = "00101";
                        break;
                    case "5":
                        right = "10100";
                        break;
                    case "6":
                        right = "01100";
                        break;
                    case "7":
                        right = "00011";
                        break;
                    case "8":
                        right = "10010";
                        break;
                    case "9":
                        right = "01010";
                        break;
                }

                encodedPairs.Add(left + right);
            }

            return encodedPairs;
        }

        private Bitmap CreateBinaryImage(List<string> code)
        {
            float xAxis = 0;
            float yAxis = 0;

            //Create de bitmap with the specified width and height
            Bitmap bitmap = new Bitmap(776, 426);
            Graphics graphics = Graphics.FromImage(bitmap);

            // Set the PageUnit to Millimeter because all of our measurements are in millimeter.
            graphics.PageUnit = GraphicsUnit.Millimeter;

            // Set the PageScale to 1, so a millimeter will represent a true millimeter.
            graphics.PageScale = 1;

            //Drawing the starting quiet zone
            graphics.FillRectangle(Brushes.White, xAxis, yAxis, 10 * (_moduleWidth * _wideToNarrowRatio), _moduleHeight);
            xAxis += 10 * (_moduleWidth * _wideToNarrowRatio);

            //Drawing the start pattern
            graphics.FillRectangle(Brushes.Black, xAxis, yAxis, _moduleWidth, _moduleHeight);
            xAxis += _moduleWidth;

            graphics.FillRectangle(Brushes.White, xAxis, yAxis, _moduleWidth, _moduleHeight);
            xAxis += _moduleWidth;

            graphics.FillRectangle(Brushes.Black, xAxis, yAxis, _moduleWidth, _moduleHeight);
            xAxis += _moduleWidth;

            graphics.FillRectangle(Brushes.White, xAxis, yAxis, _moduleWidth, _moduleHeight);
            xAxis += _moduleWidth;

            //Drawing the barcode
            foreach (var pair in code)
            {
                var leftPair = pair.Substring(0, 5);
                var rightPair = pair.Substring(5, 5);

                for (int index = 0; index < 5; index++)
                {
                    switch (leftPair.Substring(index, 1))
                    {
                        case "0":
                            graphics.FillRectangle(Brushes.Black, xAxis, yAxis, _moduleWidth, _moduleHeight);
                            xAxis += _moduleWidth;
                            break;
                        case "1":
                            graphics.FillRectangle(Brushes.Black, xAxis, yAxis, _moduleWidth * _wideToNarrowRatio, _moduleHeight);
                            xAxis += (_moduleWidth * _wideToNarrowRatio);
                            break;
                    }

                    switch (rightPair.Substring(index, 1))
                    {
                        case "0":
                            graphics.FillRectangle(Brushes.White, xAxis, yAxis, _moduleWidth, _moduleHeight);
                            xAxis += _moduleWidth;
                            break;
                        case "1":
                            graphics.FillRectangle(Brushes.White, xAxis, yAxis, _moduleWidth * _wideToNarrowRatio, _moduleHeight);
                            xAxis += (_moduleWidth * _wideToNarrowRatio);
                            break;
                    }
                }
            }

            //Drawing the stop pattern
            graphics.FillRectangle(Brushes.Black, xAxis, yAxis, (_moduleWidth * _wideToNarrowRatio), _moduleHeight);
            xAxis += (_moduleWidth * _wideToNarrowRatio);

            graphics.FillRectangle(Brushes.White, xAxis, yAxis, _moduleWidth, _moduleHeight);
            xAxis += _moduleWidth;

            graphics.FillRectangle(Brushes.Black, xAxis, yAxis, _moduleWidth, _moduleHeight);
            xAxis += _moduleWidth;

            //Drawing the ending quiet zone
            graphics.FillRectangle(Brushes.White, xAxis, yAxis, 10 * (_moduleWidth * _wideToNarrowRatio), _moduleHeight);

            return bitmap;
        }

        private int GetControlDigit(string code)
        {
            int odd = 0;
            int even = 0;

            if (code.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(code));
            }

            var reverseCode = code.Reverse();
            for (int i = 0; i < reverseCode.Count(); i++)
            {
                var number = (int)char.GetNumericValue(reverseCode.ElementAt(i));
                if (i % 2 != 0)
                {
                    even += number;
                }
                else
                {
                    odd += number;
                }
            }

            var sum = (odd * 3) + even;

            var controlDigit = (10 - (sum % 10)) % 10;
            return controlDigit;
        }

        /// <summary>
        /// Get the control digit for the especified barcode number, this is a special method for generating an AFIP barcode billing
        /// </summary>
        /// <param name="code">The number used to generate de control digit</param>
        /// <returns>The control digit for checksum</returns>
        /// <exception cref="ArgumentNullException">Throws an exception if the especified code number is null or hasn't a even length</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws an exception if the especified code number isn't a 41 digit number</exception>
        private int GetControlDigitAFIP(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }
            else if (code.Count() != 41)
            {
                throw new ArgumentOutOfRangeException(nameof(code));
            }

            int odd = 0;
            int even = 0;

            for (int position = 0; position < code.Count(); position++)
            {
                var number = (int)char.GetNumericValue(code.ElementAt(position));
                if (position % 2 == 0)
                {
                    even += number;
                }
                else
                {
                    odd += number;
                }
            }

            var sum = odd + (even * 3);

            var controlDigit = (10 - (sum % 10)) % 10;
            return controlDigit;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BarcodeGenerator() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
