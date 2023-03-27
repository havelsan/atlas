
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
    public partial class PatientOwnDrugEntryForm : TTForm
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
        protected ITTTextBoxColumn AmountPatientOwnDrugEntryDetail;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            PatientOwnDrugEntryDetails = (ITTGrid)AddControl(new Guid("4dd35884-1ac0-4075-a632-1a7cfe6c4ad8"));
            MaterialPatientOwnDrugEntryDetail = (ITTListBoxColumn)AddControl(new Guid("d4a24b0c-c66d-40a9-b58e-418fae32048a"));
            AmountPatientOwnDrugEntryDetail = (ITTTextBoxColumn)AddControl(new Guid("1038300d-6ed2-4297-a12f-2293a6fbcdd2"));
            labelID = (ITTLabel)AddControl(new Guid("825dd260-2fdb-4556-8f2d-2e96e5310015"));
            ID = (ITTTextBox)AddControl(new Guid("e79ecbf6-7419-4bca-bce0-7bac7d0723ad"));
            labelActionDate = (ITTLabel)AddControl(new Guid("4cfd43e1-5684-4307-9913-2f8652dfda2e"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("4c81ea55-0f1f-46b2-a1fc-d507870ae9e0"));
            base.InitializeControls();
        }

        public PatientOwnDrugEntryForm() : base("PATIENTOWNDRUGENTRY", "PatientOwnDrugEntryForm")
        {
        }

        protected PatientOwnDrugEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}