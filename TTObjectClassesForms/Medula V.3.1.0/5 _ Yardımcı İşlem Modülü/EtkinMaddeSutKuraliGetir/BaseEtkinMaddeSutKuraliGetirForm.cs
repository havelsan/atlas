
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
    public partial class BaseEtkinMaddeSutKuraliGetirForm : BaseMedulaDefinitionActionForm
    {
        override protected void BindControlEvents()
        {
            raporTarihiDateTimePicker.ValueChanged += new TTControlEventDelegate(raporTarihiDateTimePicker_ValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            raporTarihiDateTimePicker.ValueChanged -= new TTControlEventDelegate(raporTarihiDateTimePicker_ValueChanged);
            base.UnBindControlEvents();
        }

        private void raporTarihiDateTimePicker_ValueChanged()
        {
#region BaseEtkinMaddeSutKuraliGetirForm_raporTarihiDateTimePicker_ValueChanged
   string raporTarihiDateTime = ((DateTime)((ITTDateTimePicker)raporTarihiDateTimePicker).ControlValue).ToString("dd.MM.yyyy");
            if (string.IsNullOrEmpty(raporTarihiDateTime) == false && raporTarihiDateTime.Length >= 10)
                raporTarihiEtkinMaddeSUTGirisDVO.Text = raporTarihiDateTime.Substring(0, 10);
#endregion BaseEtkinMaddeSutKuraliGetirForm_raporTarihiDateTimePicker_ValueChanged
        }

        protected override void PreScript()
        {
#region BaseEtkinMaddeSutKuraliGetirForm_PreScript
    base.PreScript();
            _EtkinMaddeSutKuraliGetir.etkinMaddeSUTGirisDVO.saglikTesisiKodu = _EtkinMaddeSutKuraliGetir.HealthFacilityID.Value;


            if (string.IsNullOrEmpty(raporTarihiEtkinMaddeSUTGirisDVO.Text))
            {
                ((ITTDateTimePicker)raporTarihiDateTimePicker).ControlValue = TTObjectDefManager.ServerTime;
            }
            else
            {
                DateTime dateTime = Convert.ToDateTime(raporTarihiEtkinMaddeSUTGirisDVO.Text);
                ((ITTDateTimePicker)raporTarihiDateTimePicker).ControlValue = dateTime;
            }
#endregion BaseEtkinMaddeSutKuraliGetirForm_PreScript

            }
                }
}