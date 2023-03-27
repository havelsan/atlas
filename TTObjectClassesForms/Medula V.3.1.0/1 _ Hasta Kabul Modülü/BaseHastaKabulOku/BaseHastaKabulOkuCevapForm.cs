
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
    /// Hasta Kabul Oku Cevap
    /// </summary>
    public partial class BaseHastaKabulOkuCevapForm : BaseMedulaActionForm
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
#region BaseHastaKabulOkuCevapForm_PreScript
    base.PreScript();


            if (string.IsNullOrEmpty(dogumTarihiCevap.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(dogumTarihiCevap.Text);
                ((ITTDateTimePicker)dogumTarihiCevapDateTimePicker).ControlValue = dateTime;
            }

            if (string.IsNullOrEmpty(yeniDoganDogumTarihi.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(yeniDoganDogumTarihi.Text);
                ((ITTDateTimePicker)yeniDoganDogumTarihiDatetimepicker).ControlValue = dateTime;
            }

            if (string.IsNullOrEmpty(takipTarihi.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(takipTarihi.Text);
                ((ITTDateTimePicker)takipTarihiDatetimepicker).ControlValue = dateTime;
            }

            if (string.IsNullOrEmpty(kayitTarihi.Text) == false)
            {
                DateTime dateTime = Convert.ToDateTime(kayitTarihi.Text);
                ((ITTDateTimePicker)kayitTarihiDatetimepicker).ControlValue = dateTime;
            }
#endregion BaseHastaKabulOkuCevapForm_PreScript

            }
                }
}