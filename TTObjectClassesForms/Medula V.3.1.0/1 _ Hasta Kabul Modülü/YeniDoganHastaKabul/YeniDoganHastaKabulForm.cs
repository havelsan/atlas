
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
    /// Yeni Doğan Hasta Kabul
    /// </summary>
    public partial class YeniDoganHastaKabulForm : BaseHastaKabulForm
    {
        override protected void BindControlEvents()
        {
            bebeginDogumTarihiDatetimepicker.ValueChanged += new TTControlEventDelegate(bebeginDogumTarihiDatetimepicker_ValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            bebeginDogumTarihiDatetimepicker.ValueChanged -= new TTControlEventDelegate(bebeginDogumTarihiDatetimepicker_ValueChanged);
            base.UnBindControlEvents();
        }

        private void bebeginDogumTarihiDatetimepicker_ValueChanged()
        {
#region YeniDoganHastaKabulForm_bebeginDogumTarihiDatetimepicker_ValueChanged
   string bebeginDogumTarihiDateTime = bebeginDogumTarihiDatetimepicker.Text;
            if (string.IsNullOrEmpty(bebeginDogumTarihiDateTime) == false && bebeginDogumTarihiDateTime.Length >= 10)
                bebeginDogumTarihi.Text = bebeginDogumTarihiDateTime.Substring(0, 10);
#endregion YeniDoganHastaKabulForm_bebeginDogumTarihiDatetimepicker_ValueChanged
        }

        protected override void PreScript()
        {
#region YeniDoganHastaKabulForm_PreScript
    base.PreScript();

            if (string.IsNullOrEmpty(bebeginDogumTarihi.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(bebeginDogumTarihi.Text);
                ((ITTDateTimePicker)bebeginDogumTarihiDatetimepicker).ControlValue = dateTime;
            }
#endregion YeniDoganHastaKabulForm_PreScript

            }
                }
}