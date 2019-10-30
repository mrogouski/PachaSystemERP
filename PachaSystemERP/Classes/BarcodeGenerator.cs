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
        private float _moduleWidth = 0.191f;
        private int _moduleHeight = 32;
        private float _wideToNarrowRatio = 2.5f;
        private int _moduleQuantity;

        public BarcodeGenerator(int width, int height)
        {
            _moduleWidth = width;
            _moduleHeight = height;
        }

        public float Width { get => _moduleWidth; set => value = _moduleWidth; }

        public float Height { get => _moduleHeight; set => value = _moduleHeight; }

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

                }
            }
        }

        public Bitmap GenerateBarcodeAFIP(string code)
        {
            //var controlDigit = GetControlDigitAFIP(code);

            var encodedCode = EncodeString(code);

            return CreateBinaryImage(encodedCode);
        }

        private List<string> EncodeString(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }

            List<string> pairs = new List<string>();
            List<string> encodedPairs = new List<string>();
            string left = null;
            string right = null;

            for (int index = 0; index < code.Length;)
            {
                pairs.Add(code.Substring(index, 2));
                index += 2;

                foreach (string pair in pairs)
                {
                    switch (int.Parse(pair.Substring(0, 1)))
                    {
                        case 0:
                            left = "00110";
                            break;
                        case 1:
                            left = "10001";
                            break;
                        case '2':
                            left = "01001";
                            break;
                        case 3:
                            left = "11000";
                            break;
                        case 4:
                            left = "00101";
                            break;
                        case 5:
                            left = "10100";
                            break;
                        case 6:
                            left = "01100";
                            break;
                        case 7:
                            left = "00011";
                            break;
                        case 8:
                            left = "10010";
                            break;
                        case 9:
                            left = "01010";
                            break;
                    }

                    switch (int.Parse(pair.Substring(1, 1)))
                    {
                        case 0:
                            right = "00110";
                            break;
                        case 1:
                            right = "10001";
                            break;
                        case '2':
                            right = "01001";
                            break;
                        case 3:
                            right = "11000";
                            break;
                        case 4:
                            right = "00101";
                            break;
                        case 5:
                            right = "10100";
                            break;
                        case 6:
                            right = "01100";
                            break;
                        case 7:
                            right = "00011";
                            break;
                        case 8:
                            right = "10010";
                            break;
                        case 9:
                            right = "01010";
                            break;
                    }

                    encodedPairs.Add(left + right);
                }
            }

            return encodedPairs;
        }

        private Bitmap CreateBinaryImage(List<string> code)
        {
            int xAxis = 0;
            int yAxis = 0;
            string startPattern = "0000";
            string stopPattern = "100";

            //Create de bitmap with the specified width and height
            Bitmap bitmap = new Bitmap(_moduleWidth * _moduleQuantity, _moduleHeight);
            Graphics graphics = Graphics.FromImage(bitmap);

            // Set the PageUnit to Millimeter because all of our measurements are in millimeter.
            graphics.PageUnit = GraphicsUnit.Millimeter;

            // Set the PageScale to 1, so a millimeter will represent a true millimeter.
            graphics.PageScale = 1;

            foreach (var pair in code)
            {
                var leftPair = pair.Substring(0, 5);
                var rightPair = pair.Substring(5, 5);

                for (int index = 0; index < 5; index++)
                {
                    switch (leftPair.Substring(index, 1))
                    {
                        case "0":
                            graphics.FillRectangle(Brushes.Black, xAxis, yAxis, _moduleWidth / _moduleWidth, _moduleHeight);
                            break;
                        case "1":
                            graphics.FillRectangle(Brushes.Black, xAxis, yAxis, (_moduleWidth / _moduleWidth) * _wideToNarrowRatio, _moduleHeight * _wideToNarrowRatio);
                            break;
                    }

                    switch (rightPair.Substring(index, 1))
                    {
                        case "0":
                            graphics.FillRectangle(Brushes.White, xAxis, yAxis, _moduleWidth, _moduleHeight);
                            break;
                        case "1":
                            graphics.FillRectangle(Brushes.White, xAxis, yAxis, _moduleWidth * _wideToNarrowRatio, _moduleHeight * _wideToNarrowRatio);
                            break;
                    }
                }
            }

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
