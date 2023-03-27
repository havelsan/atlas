
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Kan Bankası Dışardan Kan Ürünü Girişi Ekranı
    /// </summary>
    public partial class BloodBankExternalBloodProductEntryForm : EpisodeActionForm
    {
    /// <summary>
    /// Dışarıdan Hastaya Kan Ürünü Girişi
    /// </summary>
        protected TTObjectClasses.BloodBankExternalBloodProductEntry _BloodBankExternalBloodProductEntry
        {
            get { return (TTObjectClasses.BloodBankExternalBloodProductEntry)_ttObject; }
        }

        protected ITTTextBox RequestDescription;
        protected ITTLabel labelRequestDescription;
        override protected void InitializeControls()
        {
            RequestDescription = (ITTTextBox)AddControl(new Guid("d0c1fc59-e6dc-4844-9995-478953ad3242"));
            labelRequestDescription = (ITTLabel)AddControl(new Guid("b1f70b74-3bf8-4fcf-b543-f8dbdedb13ff"));
            base.InitializeControls();
        }

        public BloodBankExternalBloodProductEntryForm() : base("BLOODBANKEXTERNALBLOODPRODUCTENTRY", "BloodBankExternalBloodProductEntryForm")
        {
        }

        protected BloodBankExternalBloodProductEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}