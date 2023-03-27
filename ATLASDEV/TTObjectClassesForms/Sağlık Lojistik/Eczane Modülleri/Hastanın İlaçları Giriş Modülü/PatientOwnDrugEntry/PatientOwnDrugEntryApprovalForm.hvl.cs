
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
    /// Hastanın İlaçları Giriş
    /// </summary>
    public partial class PatientOwnDrugEntryApprovalForm : TTForm
    {
    /// <summary>
    /// Hastanın İlaçları Giriş
    /// </summary>
        protected TTObjectClasses.PatientOwnDrugEntry _PatientOwnDrugEntry
        {
            get { return (TTObjectClasses.PatientOwnDrugEntry)_ttObject; }
        }

        protected ITTGrid PatientOwnDrugEntryDetails;
        protected ITTListBoxColumn MaterialPatientOwnDrugEntryDetail;
        protected ITTTextBoxColumn SendAmountPatientOwnDrugEntryDetail;
        protected ITTTextBoxColumn AmountPatientOwnDrugEntryDetail;
        protected ITTTextBoxColumn BarcodeAmountPatientOwnDrugEntryDetail;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            PatientOwnDrugEntryDetails = (ITTGrid)AddControl(new Guid("2f500744-62eb-49fe-ba40-a33dc2dc03ea"));
            MaterialPatientOwnDrugEntryDetail = (ITTListBoxColumn)AddControl(new Guid("ae26438c-6c69-41ab-a2ed-8c8ce80154d2"));
            SendAmountPatientOwnDrugEntryDetail = (ITTTextBoxColumn)AddControl(new Guid("272976d3-1fb3-45d6-a10a-d0d854759c27"));
            AmountPatientOwnDrugEntryDetail = (ITTTextBoxColumn)AddControl(new Guid("896839bd-8e3e-431e-ac20-01e8f33d7614"));
            BarcodeAmountPatientOwnDrugEntryDetail = (ITTTextBoxColumn)AddControl(new Guid("320335af-32cf-43a0-b34a-471ac5c1ea97"));
            labelID = (ITTLabel)AddControl(new Guid("5b111914-9767-470c-ade6-61184cbaef39"));
            ID = (ITTTextBox)AddControl(new Guid("5a7568a9-c576-4ceb-9933-b4ca172386c5"));
            labelActionDate = (ITTLabel)AddControl(new Guid("894856b3-71c5-493f-8ba3-3a14e58d9d41"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("57292bd8-41bc-4f26-8178-5cccb8719542"));
            base.InitializeControls();
        }

        public PatientOwnDrugEntryApprovalForm() : base("PATIENTOWNDRUGENTRY", "PatientOwnDrugEntryApprovalForm")
        {
        }

        protected PatientOwnDrugEntryApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}