
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
    /// Başbakanlık(F022)  Kabulü
    /// </summary>
    public partial class PA_PrimeMinistryForm : PatientAdmissionForm
    {
    /// <summary>
    /// Başbakanlık(F022)  Kabul
    /// </summary>
        protected TTObjectClasses.PA_PrimeMinistry _PA_PrimeMinistry
        {
            get { return (TTObjectClasses.PA_PrimeMinistry)_ttObject; }
        }

        protected ITTTextBox DocumentNumber;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelDocumentNumber;
        protected ITTLabel labelProtocol;
        protected ITTLabel labelCity;
        protected ITTLabel labelFoundation;
        protected ITTObjectListBox PayerCity;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelRetirementFundID;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTLabel labelRelationship;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTObjectListBox Relationship;
        protected ITTObjectListBox Protocol;
        protected ITTObjectListBox Payer;
        protected ITTTextBox tttextbox2;
        protected ITTLabel labelHealtSlipNumber;
        override protected void InitializeControls()
        {
            DocumentNumber = (ITTTextBox)AddControl(new Guid("e1b42318-1507-44ab-b2dc-27552f453985"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("81d61835-ee1c-4114-b299-d0910f8c2bfa"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("b73acb66-6340-4be7-b3ac-85b7947336e1"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("17314385-b825-4c31-8e08-13ab38c63bd1"));
            labelProtocol = (ITTLabel)AddControl(new Guid("b453e8f5-47b5-4693-8cf4-8c551fd38642"));
            labelCity = (ITTLabel)AddControl(new Guid("882f0aca-8e02-4f1a-a234-b5a94577ffb1"));
            labelFoundation = (ITTLabel)AddControl(new Guid("e4d3a0f1-ec62-424b-be65-d67d572a3ace"));
            PayerCity = (ITTObjectListBox)AddControl(new Guid("5c08141c-1d5a-4856-a981-370b1b9dc6b8"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("280832e8-7452-46b9-aba7-dd2ff6234093"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("cc206f4c-47cf-4baa-82c3-f0eb58f1115b"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("a042dcac-4a33-4c3b-b678-738d13c97be1"));
            labelRelationship = (ITTLabel)AddControl(new Guid("b448c1f6-26f7-4d69-8fed-0fd4c4c6544b"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("583d20d8-49c6-43ca-8213-f3db7423ecc2"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("2a74d211-48e4-4d16-bb88-78e24f0cdad8"));
            Protocol = (ITTObjectListBox)AddControl(new Guid("0ff57d24-5222-414d-96ac-28af4f558f37"));
            Payer = (ITTObjectListBox)AddControl(new Guid("b507e401-1fc0-4bc1-81f3-9bca5e8115ab"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("a332b9fb-00f5-48de-8be8-d5c978b88659"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("1927d319-613d-49f3-a646-c13ee27b960f"));
            base.InitializeControls();
        }

        public PA_PrimeMinistryForm() : base("PA_PRIMEMINISTRY", "PA_PrimeMinistryForm")
        {
        }

        protected PA_PrimeMinistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}