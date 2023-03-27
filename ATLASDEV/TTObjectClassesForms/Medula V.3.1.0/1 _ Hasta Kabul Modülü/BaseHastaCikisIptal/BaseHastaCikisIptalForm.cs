
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
    /// BaseHastaCikisIptalForm
    /// </summary>
    public partial class BaseHastaCikisIptalForm : BaseMedulaActionForm
    {
        override protected void BindControlEvents()
        {
            hastaCikisTarihiDateTimePicker.ValueChanged += new TTControlEventDelegate(hastaCikisTarihiDateTimePicker_ValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            hastaCikisTarihiDateTimePicker.ValueChanged -= new TTControlEventDelegate(hastaCikisTarihiDateTimePicker_ValueChanged);
            base.UnBindControlEvents();
        }

        private void hastaCikisTarihiDateTimePicker_ValueChanged()
        {
#region BaseHastaCikisIptalForm_hastaCikisTarihiDateTimePicker_ValueChanged
   string hastaCikisTarihiDateTime = hastaCikisTarihiDateTimePicker.Text;
            if (string.IsNullOrEmpty(hastaCikisTarihiDateTime) == false && hastaCikisTarihiDateTime.Length >= 10)
                hastaCikisTarihi.Text = hastaCikisTarihiDateTime.Substring(0, 10);
#endregion BaseHastaCikisIptalForm_hastaCikisTarihiDateTimePicker_ValueChanged
        }

        protected override void PreScript()
        {
#region BaseHastaCikisIptalForm_PreScript
    base.PreScript();

            ITTObject iTTObject = (ITTObject)_BaseHastaCikisIptal;
            if (iTTObject.IsNew)
                _BaseHastaCikisIptal.hastaCikisIptalDVO.saglikTesisKodu = _BaseHastaCikisIptal.HealthFacilityID.Value;

            if (string.IsNullOrEmpty(hastaCikisTarihi.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(hastaCikisTarihi.Text);
                ((ITTDateTimePicker)hastaCikisTarihiDateTimePicker).ControlValue = dateTime;
            }
#endregion BaseHastaCikisIptalForm_PreScript

            }
                }
}