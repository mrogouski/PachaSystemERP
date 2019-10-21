// <copyright file="CueText.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Controles
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class CueText : Component, IExtenderProvider
    {
        private const int ECM_FIRST = 0x1500;
        private const int EM_SETCUEBANNER = ECM_FIRST + 1;
        private readonly IntPtr TRUE = (IntPtr)1;
        private Hashtable _cueBannerTable = new Hashtable();

        public bool CanExtend(object extendee)
        {
            throw new NotImplementedException();
        }

        [DefaultValue("")]
        [DisplayName("CueText")]
        public string GetCueText(TextBox control)
        {
            if (control is TextBox)
            {
                string cueText = (string)_cueBannerTable[control];
                return cueText == null ? string.Empty : cueText;
            }

            return string.Empty;
        }

        public void SetCueText(TextBox control, string cueText)
        {
            if (control is TextBox)
            {
                _cueBannerTable[control] = cueText;
                SendMessage(control.Handle, EM_SETCUEBANNER, TRUE, Marshal.StringToBSTR(cueText));
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    }
}
