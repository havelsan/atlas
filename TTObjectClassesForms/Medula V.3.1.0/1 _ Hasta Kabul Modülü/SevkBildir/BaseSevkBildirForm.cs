
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
    /// BaseSevkBildirForm
    /// </summary>
    public partial class BaseSevkBildirForm : BaseMedulaActionForm
    {
        override protected void BindControlEvents()
        {
            sevkEdilisTarihiDateTimePicker.ValueChanged += new TTControlEventDelegate(sevkEdilisTarihiDateTimePicker_ValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            sevkEdilisTarihiDateTimePicker.ValueChanged -= new TTControlEventDelegate(sevkEdilisTarihiDateTimePicker_ValueChanged);
            base.UnBindControlEvents();
        }

        private void sevkEdilisTarihiDateTimePicker_ValueChanged()
        {
#region BaseSevkBildirForm_sevkEdilisTarihiDateTimePicker_ValueChanged
   string sevkEdilisTarihiDateTime = sevkEdilisTarihiDateTimePicker.Text;
            if (string.IsNullOrEmpty(sevkEdilisTarihiDateTime) == false && sevkEdilisTarihiDateTime.Length >= 10)
                sevkEdilisTarihi.Text = sevkEdilisTarihiDateTime.Substring(0, 10);
#endregion BaseSevkBildirForm_sevkEdilisTarihiDateTimePicker_ValueChanged
        }

        protected override void PreScript()
        {
#region BaseSevkBildirForm_PreScript
    base.PreScript();

            ITTObject iTTObject = (ITTObject)_SevkBildir;
            if (iTTObject.IsNew)
                _SevkBildir.sevkBildirGirisDVO.tesisKodu = _SevkBildir.HealthFacilityID.Value;

            if (string.IsNullOrEmpty(sevkEdilisTarihi.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(sevkEdilisTarihi.Text);
                ((ITTDateTimePicker)sevkEdilisTarihiDateTimePicker).ControlValue = dateTime;
            }
#endregion BaseSevkBildirForm_PreScript

            }
                }
}