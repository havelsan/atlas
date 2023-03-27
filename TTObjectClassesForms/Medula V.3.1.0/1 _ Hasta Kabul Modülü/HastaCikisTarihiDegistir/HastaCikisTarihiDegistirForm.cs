
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Hasta Çıkış Tarihi Değiştir
    /// </summary>
    public partial class HastaCikisTarihiDegistirForm : BaseHastaCikisIptalForm
    {
        override protected void BindControlEvents()
        {
            yeniHastaCikisTarihiDateTimePicker.ValueChanged += new TTControlEventDelegate(yeniHastaCikisTarihiDateTimePicker_ValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            yeniHastaCikisTarihiDateTimePicker.ValueChanged -= new TTControlEventDelegate(yeniHastaCikisTarihiDateTimePicker_ValueChanged);
            base.UnBindControlEvents();
        }

        private void yeniHastaCikisTarihiDateTimePicker_ValueChanged()
        {
#region HastaCikisTarihiDegistirForm_yeniHastaCikisTarihiDateTimePicker_ValueChanged
   string yeniHastaCikisTarihiDateTime = yeniHastaCikisTarihiDateTimePicker.Text;
            if (string.IsNullOrEmpty(yeniHastaCikisTarihiDateTime) == false && yeniHastaCikisTarihiDateTime.Length >= 10)
                yeniHastaCikisTarihi.Text = yeniHastaCikisTarihiDateTime.Substring(0, 10);
#endregion HastaCikisTarihiDegistirForm_yeniHastaCikisTarihiDateTimePicker_ValueChanged
        }

        protected override void PreScript()
        {
#region HastaCikisTarihiDegistirForm_PreScript
    base.PreScript();

            if (string.IsNullOrEmpty(yeniHastaCikisTarihi.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(yeniHastaCikisTarihi.Text);
                ((ITTDateTimePicker)yeniHastaCikisTarihiDateTimePicker).ControlValue = dateTime;
            }
#endregion HastaCikisTarihiDegistirForm_PreScript

            }
                }
}