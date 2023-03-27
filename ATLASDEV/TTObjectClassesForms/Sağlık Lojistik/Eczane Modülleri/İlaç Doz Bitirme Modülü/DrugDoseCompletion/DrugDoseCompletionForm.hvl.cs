
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
    /// İlaç Doz Bitirme
    /// </summary>
    public partial class DrugDoseCompletionForm : TTForm
    {
    /// <summary>
    /// İlaç Doz Bitirme
    /// </summary>
        protected TTObjectClasses.DrugDoseCompletion _DrugDoseCompletion
        {
            get { return (TTObjectClasses.DrugDoseCompletion)_ttObject; }
        }

        protected ITTLabel labelPatientIDandFullNamePatient;
        protected ITTTextBox PatientIDandFullNamePatient;
        protected ITTTextBox ID;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTGrid DrugDoseCompletionDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTCheckBoxColumn Completed;
        override protected void InitializeControls()
        {
            labelPatientIDandFullNamePatient = (ITTLabel)AddControl(new Guid("779c4ed8-d1ee-4092-894d-523d8444d916"));
            PatientIDandFullNamePatient = (ITTTextBox)AddControl(new Guid("d8ac1de7-c756-4ce5-a032-1bb181c41d44"));
            ID = (ITTTextBox)AddControl(new Guid("1259083d-5808-474b-88b0-6db8b94406f8"));
            labelID = (ITTLabel)AddControl(new Guid("fda10829-b145-4162-a9ab-c20c4946621d"));
            labelActionDate = (ITTLabel)AddControl(new Guid("d235c140-8d02-47c9-a20f-f8065d9bbe46"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("8199f140-64b7-46ca-bfb1-11b8a969f7cd"));
            DrugDoseCompletionDetails = (ITTGrid)AddControl(new Guid("954871fb-334c-4aff-87d8-57a9f0bd4401"));
            Material = (ITTListBoxColumn)AddControl(new Guid("81006d59-2c7c-4d4d-b4ef-7b15805aec4d"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("09c4b885-abb9-4fdd-bc8d-d97836aac35f"));
            Completed = (ITTCheckBoxColumn)AddControl(new Guid("a2d286a3-7f1f-4da2-848e-6f56e4ece218"));
            base.InitializeControls();
        }

        public DrugDoseCompletionForm() : base("DRUGDOSECOMPLETION", "DrugDoseCompletionForm")
        {
        }

        protected DrugDoseCompletionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}