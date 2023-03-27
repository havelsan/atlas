
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
    /// Geriye Dönük Yatış Kabul Cevap
    /// </summary>
    public partial class GeriyeDonukYatisKabulCevapForm : BaseHastaKabulCevapForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region GeriyeDonukYatisKabulCevapForm_PreScript
    base.PreScript();

            if (string.IsNullOrEmpty(yatisBitisTarihi.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(yatisBitisTarihi.Text);
                ((ITTDateTimePicker)yatisBitisTarihiDatetimepicker).ControlValue = dateTime;
            }
#endregion GeriyeDonukYatisKabulCevapForm_PreScript

            }
                }
}