
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
    /// Yatan Hasta Reçetesi
    /// </summary>
    public partial class InpatientPresDetailForm : TTForm
    {
        protected TTObjectClasses.InpatientPresDetail _InpatientPresDetail
        {
            get { return (TTObjectClasses.InpatientPresDetail)_ttObject; }
        }

        protected ITTLabel labelPrescriptionPaperPrescription;
        protected ITTObjectListBox PrescriptionPaperPrescription;
        protected ITTLabel labelEReceteNoPrescription;
        protected ITTTextBox EReceteNoPrescription;
        protected ITTTextBox EReceteDescriptionPrescription;
        protected ITTLabel labelEReceteDescriptionPrescription;
        protected ITTGrid InpatientDrugOrdersInpatientDrugOrder;
        protected ITTListBoxColumn Drug;
        protected ITTEnumComboBoxColumn Frequency;
        protected ITTTextBoxColumn DoseAmount;
        protected ITTTextBoxColumn Day;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UsageNote;
        protected ITTEnumComboBoxColumn DescriptionType;
        protected ITTTextBoxColumn Description;
        override protected void InitializeControls()
        {
            labelPrescriptionPaperPrescription = (ITTLabel)AddControl(new Guid("ef6439b7-09d5-4d6a-b7dc-f0c9e1c045c4"));
            PrescriptionPaperPrescription = (ITTObjectListBox)AddControl(new Guid("ba71322d-f36a-4e78-a895-7fed797a32d5"));
            labelEReceteNoPrescription = (ITTLabel)AddControl(new Guid("24e02f1e-1c85-44d3-9e0e-d907ed49fd15"));
            EReceteNoPrescription = (ITTTextBox)AddControl(new Guid("2fdf943e-fbd8-4068-8360-5a9be2a7d8ab"));
            EReceteDescriptionPrescription = (ITTTextBox)AddControl(new Guid("fa1abfdf-e591-462e-ab83-a960d79c0849"));
            labelEReceteDescriptionPrescription = (ITTLabel)AddControl(new Guid("a8cf82c5-1eb8-43cd-afae-4e1a488c20f0"));
            InpatientDrugOrdersInpatientDrugOrder = (ITTGrid)AddControl(new Guid("1b67e4ab-7c28-49cf-b56e-dab8b3beaaf5"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("9d0372e0-c1bf-4197-8b25-7acd0614add1"));
            Frequency = (ITTEnumComboBoxColumn)AddControl(new Guid("56fcc6d3-cf02-4534-b025-6683540f17bc"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("19f8ee32-a66f-4cb6-8ec9-7fd053732ffc"));
            Day = (ITTTextBoxColumn)AddControl(new Guid("6c2260fe-167e-41c2-8e95-30c513fd9749"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("5512f861-031e-429b-829e-e81e0753e390"));
            UsageNote = (ITTTextBoxColumn)AddControl(new Guid("4669e1f4-a325-4a8b-abb9-041a3574803e"));
            DescriptionType = (ITTEnumComboBoxColumn)AddControl(new Guid("36164f53-5039-4927-a8c7-530323e23d86"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("7506423d-ef22-491a-a3b9-6d4597486206"));
            base.InitializeControls();
        }

        public InpatientPresDetailForm() : base("INPATIENTPRESDETAIL", "InpatientPresDetailForm")
        {
        }

        protected InpatientPresDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}