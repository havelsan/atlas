
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
    public partial class PatientOwnDrugReturnCompForm : TTForm
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
            PatientOwnDrugReturnDetails = (ITTGrid)AddControl(new Guid("65abb84d-a821-4a2f-9bf2-5b2e454fde07"));
            MaterialPatientOwnDrugReturnDetail = (ITTListBoxColumn)AddControl(new Guid("0a2320b9-3628-42df-9cb4-bcdd601c85bb"));
            AmountPatientOwnDrugReturnDetail = (ITTTextBoxColumn)AddControl(new Guid("a9d38c8a-53c1-4dd8-a24f-10dd071e3913"));
            labelID = (ITTLabel)AddControl(new Guid("3f72d8d9-2693-41ef-a60c-aaaf656ac36d"));
            ID = (ITTTextBox)AddControl(new Guid("69a761f6-e7ce-4357-bde6-b7ccaaeee536"));
            labelActionDate = (ITTLabel)AddControl(new Guid("ab84c21c-b9eb-465c-8829-b4608ff669bb"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("137e11f9-7afe-489c-aa4c-de2eac8be53a"));
            base.InitializeControls();
        }

        public PatientOwnDrugReturnCompForm() : base("PATIENTOWNDRUGRETURN", "PatientOwnDrugReturnCompForm")
        {
        }

        protected PatientOwnDrugReturnCompForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}