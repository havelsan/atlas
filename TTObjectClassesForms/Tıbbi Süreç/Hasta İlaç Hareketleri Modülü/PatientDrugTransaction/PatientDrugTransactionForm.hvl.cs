
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
    /// Hasta İlaç Hareketleri
    /// </summary>
    public partial class PatientDrugTransactionForm : TTForm
    {
    /// <summary>
    /// Hasta İlaç Hareketleri
    /// </summary>
        protected TTObjectClasses.PatientDrugTransaction _PatientDrugTransaction
        {
            get { return (TTObjectClasses.PatientDrugTransaction)_ttObject; }
        }

        protected ITTObjectListBox Patient;
        protected ITTLabel ttlabel1;
        protected ITTGrid Episodes;
        protected ITTListBoxColumn Material;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Name;
        protected ITTLabel labelPatient;
        override protected void InitializeControls()
        {
            Patient = (ITTObjectListBox)AddControl(new Guid("5877ce6f-2e31-4f99-a5a7-618ef4a23b8c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cae4189f-7b7e-4aef-89bf-695fa791a816"));
            Episodes = (ITTGrid)AddControl(new Guid("852d60e4-86bc-4ae4-afa3-a54e02f34b4f"));
            Material = (ITTListBoxColumn)AddControl(new Guid("1cf9db97-7d79-4538-83e0-2ae879795d22"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("a3a954fa-c17d-4a4b-86b7-79d1cbc36416"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("105a663d-0e99-40da-8c50-318d11bc8cbb"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("07bece00-79ec-4ce3-a3c3-aafb6b6fcdb0"));
            labelPatient = (ITTLabel)AddControl(new Guid("fe18355f-8627-4ea2-8255-b05d861b8556"));
            base.InitializeControls();
        }

        public PatientDrugTransactionForm() : base("PATIENTDRUGTRANSACTION", "PatientDrugTransactionForm")
        {
        }

        protected PatientDrugTransactionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}