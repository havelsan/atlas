
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
    /// Yedek Subay Adayı XXXXXX Ögrenci
    /// </summary>
    public partial class PA_ReserveOfficerCadetCandidateForm : PatientAdmissionForm
    {
    /// <summary>
    /// Yedek Subay Adayı XXXXXX Ögrenci
    /// </summary>
        protected TTObjectClasses.PA_ReserveOfficerCadetCandidate _PA_ReserveOfficerCadetCandidate
        {
            get { return (TTObjectClasses.PA_ReserveOfficerCadetCandidate)_ttObject; }
        }

        protected ITTObjectListBox assasmntDeptlst;
        protected ITTObjectListBox salaryPayLst;
        protected ITTLabel ttlabel833;
        protected ITTLabel ttlabel133;
        protected ITTObjectListBox Rank;
        protected ITTTextBox DocumentNumber;
        protected ITTDateTimePicker DocumentDate;
        protected ITTObjectListBox SenderChair;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelSenderChair;
        protected ITTTextBox HealtSlipNumber;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel labelDocumentNumber;
        protected ITTLabel lableMilitaryUnit;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelRetirementFundID;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTLabel labelRank;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel labelMilitaryClass;
        protected ITTLabel labelForcesCommand;
        override protected void InitializeControls()
        {
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("152335d5-6329-4ced-bea1-519d741689d0"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("08deb9b2-5cb1-4872-a5e8-869dc12d9ea3"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("c31574cd-8219-4dff-b58f-204444280036"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("1fb15110-9c84-498c-9f01-28ecfe95a7b8"));
            Rank = (ITTObjectListBox)AddControl(new Guid("9449c355-daf4-49ce-bfc7-02a94803af56"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("64030634-85ea-410c-a005-a8837bbb28eb"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("50d329e1-decc-4749-87db-360ddb3e9413"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("8a856f84-dbde-4bc6-bf6b-16567a3458fc"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("37dd23aa-99b0-463c-a90c-6c74d5719a6e"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("ddbbbb5e-e8c4-4cc7-b159-617df27554c6"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("149d56a0-2323-4fdc-aee1-39cfc684aa10"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("68746fb8-776c-4d62-a94d-4fb09dc22e38"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("99acd005-80d8-4fd1-8bd3-7d8e030b09ad"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("ad3991e5-db0e-425b-9247-89fade879e31"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("a4da4c94-f27c-4de7-940c-b809c9c51185"));
            lableMilitaryUnit = (ITTLabel)AddControl(new Guid("05ff8d8e-7d72-4ed6-8933-b25be3831707"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("e7005168-8116-4f1d-b8f9-1d7033785f73"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("2348196d-9616-48c2-b892-ee4fe19484fb"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("52465ad5-df2e-4840-a913-3761a573cf1f"));
            labelRank = (ITTLabel)AddControl(new Guid("8a6bbc20-101c-47eb-bde9-b51056c6ede0"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("1af9ce69-5a3a-4ba1-b469-967dfc34735f"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("ce2fc765-01d4-4bce-ba24-72132cdb1b49"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("a99f182d-2e88-41a1-82b2-eed66b86ce96"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("9ceac5db-0327-456c-8bfd-b37305c718f8"));
            base.InitializeControls();
        }

        public PA_ReserveOfficerCadetCandidateForm() : base("PA_RESERVEOFFICERCADETCANDIDATE", "PA_ReserveOfficerCadetCandidateForm")
        {
        }

        protected PA_ReserveOfficerCadetCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}