
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
    /// Hastanın İlaçları İade
    /// </summary>
    public partial class PatientOwnDrugReturnForm : TTForm
    {
        protected TTObjectClasses.PatientOwnDrugReturn _PatientOwnDrugReturn
        {
            get { return (TTObjectClasses.PatientOwnDrugReturn)_ttObject; }
        }

        protected ITTGrid PatientOwnDrugReturnDetails;
        protected ITTListBoxColumn MaterialPatientOwnDrugReturnDetail;
        protected ITTTextBoxColumn AmountPatientOwnDrugReturnDetail;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            PatientOwnDrugReturnDetails = (ITTGrid)AddControl(new Guid("be393287-087e-45e7-8054-bef927bf566d"));
            MaterialPatientOwnDrugReturnDetail = (ITTListBoxColumn)AddControl(new Guid("0dd9b484-bc4f-496a-a060-17a868f45e49"));
            AmountPatientOwnDrugReturnDetail = (ITTTextBoxColumn)AddControl(new Guid("1d1ddf87-86e7-4d9e-8505-6d4069e9d66f"));
            labelID = (ITTLabel)AddControl(new Guid("524bd7c3-91df-4782-9cc5-b2b778ebaae2"));
            ID = (ITTTextBox)AddControl(new Guid("314639f2-34f5-440f-a1ca-4cfcafaeae91"));
            labelActionDate = (ITTLabel)AddControl(new Guid("334f85c8-c969-40e8-bfe5-ebaea4261b59"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("0bdca396-7f4e-44a4-b029-789c0901d641"));
            base.InitializeControls();
        }

        public PatientOwnDrugReturnForm() : base("PATIENTOWNDRUGRETURN", "PatientOwnDrugReturnForm")
        {
        }

        protected PatientOwnDrugReturnForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}