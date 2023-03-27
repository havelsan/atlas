
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
    /// Geriye Dönük Yatış Kabul
    /// </summary>
    public partial class GeriyeDonukYatisKabulForm : BaseHastaKabulForm
    {
        override protected void BindControlEvents()
        {
            yatisBitisTarihiDatetimepicker.ValueChanged += new TTControlEventDelegate(yatisBitisTarihiDatetimepicker_ValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            yatisBitisTarihiDatetimepicker.ValueChanged -= new TTControlEventDelegate(yatisBitisTarihiDatetimepicker_ValueChanged);
            base.UnBindControlEvents();
        }

        private void yatisBitisTarihiDatetimepicker_ValueChanged()
        {
#region GeriyeDonukYatisKabulForm_yatisBitisTarihiDatetimepicker_ValueChanged
   string yatisBitisTarihiDateTime = yatisBitisTarihiDatetimepicker.Text;
            if (string.IsNullOrEmpty(yatisBitisTarihiDateTime) == false && yatisBitisTarihiDateTime.Length >= 10)
                yatisBitisTarihi.Text = yatisBitisTarihiDateTime.Substring(0, 10);
#endregion GeriyeDonukYatisKabulForm_yatisBitisTarihiDatetimepicker_ValueChanged
        }

        protected override void PreScript()
        {
#region GeriyeDonukYatisKabulForm_PreScript
    base.PreScript();

            if (string.IsNullOrEmpty(yatisBitisTarihi.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(yatisBitisTarihi.Text);
                ((ITTDateTimePicker)yatisBitisTarihiDatetimepicker).ControlValue = dateTime;
            }
#endregion GeriyeDonukYatisKabulForm_PreScript

            }
                }
}