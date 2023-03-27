
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
    /// Sağlık Kurulu
    /// </summary>
    public partial class HCNewForm : EpisodeActionForm
    {
    /// <summary>
    /// Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommittee _HealthCommittee
        {
            get { return (TTObjectClasses.HealthCommittee)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage labelReturnDescription;
        protected ITTGrid Members;
        protected ITTListBoxColumn MemberDoctorMemberOfHealthCommiittee;
        protected ITTListBoxColumn SpecialityMemberOfHealthCommiittee;
        protected ITTTextBoxColumn DoctorTescilNumber;
        protected ITTTextBoxColumn DoctorSpecialityRegNo;
        protected ITTGrid ExternalDoctors;
        protected ITTTextBoxColumn ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid;
        protected ITTListBoxColumn SpecialityBaseHealthCommittee_ExtDoctorGrid;
        protected ITTTextBoxColumn ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid;
        protected ITTTextBoxColumn ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid;
        protected ITTLabel ExternalDoctorInfo;
        protected ITTLabel labelNumberOfDocumnets;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelReasonForExaminationHCRequestReason;
        protected ITTObjectListBox ReasonForExaminationHCRequestReason;
        protected ITTLabel labelHCRequestReason;
        protected ITTObjectListBox HCRequestReason;
        protected ITTLabel ttlabel1;
        protected ITTGrid HospitalsUnits;
        protected ITTListBoxColumn DoctorBaseHealthCommittee_HospitalsUnitsGrid;
        protected ITTListBoxColumn UnitBaseHealthCommittee_HospitalsUnitsGrid;
        protected ITTListBoxColumn SpecialityBaseHealthCommittee_HospitalsUnitsGrid;
        protected ITTTextBoxColumn ExaminationStateInfo;
        protected ITTTextBoxColumn DisableRatioInfo;
        protected ITTEnumComboBox WhoPays;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel2;
        protected ITTGrid ReturnDescriptionGrid;
        protected ITTTextBoxColumn EntryDate;
        protected ITTTextBoxColumn ReturnDescription;
        protected ITTTextBoxColumn OwnerUser;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel14;
        protected ITTTextBox Height;
        protected ITTLabel ttlabel8;
        protected ITTTextBox Weight;
        protected ITTLabel ttlabel7;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelMasterResource;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelDocumentDate;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelNumberOfProcedure;
        protected ITTTextBox NumberOfProcedure;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("d5e477ac-3dca-4e9b-84a9-28ec996a2656"));
            labelReturnDescription = (ITTTabPage)AddControl(new Guid("3b6caef5-f96b-4156-94a9-56d2d431766e"));
            Members = (ITTGrid)AddControl(new Guid("7458647f-b1ce-46d0-ac43-7a4304294999"));
            MemberDoctorMemberOfHealthCommiittee = (ITTListBoxColumn)AddControl(new Guid("eca22d4c-dcdd-48e2-a48b-6def9d269e68"));
            SpecialityMemberOfHealthCommiittee = (ITTListBoxColumn)AddControl(new Guid("f8faa327-9fcf-4500-a1ca-119aafe1132c"));
            DoctorTescilNumber = (ITTTextBoxColumn)AddControl(new Guid("061cdabe-2a5a-4ce9-b8b2-a544427748c2"));
            DoctorSpecialityRegNo = (ITTTextBoxColumn)AddControl(new Guid("89545ab0-987f-4731-841b-2c63b3b4dab3"));
            ExternalDoctors = (ITTGrid)AddControl(new Guid("51c14ffe-81dd-432f-8424-2527ad99acf1"));
            ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid = (ITTTextBoxColumn)AddControl(new Guid("8245e5d6-d430-4cb5-957d-3a4fde0c7b04"));
            SpecialityBaseHealthCommittee_ExtDoctorGrid = (ITTListBoxColumn)AddControl(new Guid("e2631b3e-be76-466c-9e6a-54b594fc273f"));
            ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid = (ITTTextBoxColumn)AddControl(new Guid("4828f139-3aa3-4963-8027-a2d60af78e21"));
            ExternalDoctorSpecialityRegNoBaseHealthCommittee_ExtDoctorGrid = (ITTTextBoxColumn)AddControl(new Guid("c71a7d13-1584-4f0d-9ed3-d8e1ee8fd990"));
            ExternalDoctorInfo = (ITTLabel)AddControl(new Guid("f478389c-fea2-41b2-b871-b8ae177a6a88"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("94327252-b2fc-4778-b19d-925897f6b824"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("aa308f46-0e02-4779-a3ba-e11046d8618d"));
            labelReasonForExaminationHCRequestReason = (ITTLabel)AddControl(new Guid("f0da021b-d5a6-4bf4-a130-898fe2b8d183"));
            ReasonForExaminationHCRequestReason = (ITTObjectListBox)AddControl(new Guid("4946a597-833b-4dc2-b768-6d6f45563b93"));
            labelHCRequestReason = (ITTLabel)AddControl(new Guid("7ebe8312-d14f-4f1a-9b4c-eb0623e4df38"));
            HCRequestReason = (ITTObjectListBox)AddControl(new Guid("f7d49ca6-640b-4ca4-965a-24e707c5617c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("52215900-d55d-4d53-9b7b-86d5faf434b4"));
            HospitalsUnits = (ITTGrid)AddControl(new Guid("188b651f-079d-4c5e-a555-d6923cf917b8"));
            DoctorBaseHealthCommittee_HospitalsUnitsGrid = (ITTListBoxColumn)AddControl(new Guid("0fa2e3b0-d916-469f-a144-de5f23eddd6e"));
            UnitBaseHealthCommittee_HospitalsUnitsGrid = (ITTListBoxColumn)AddControl(new Guid("a7f28df5-948f-4c25-a83c-1d78bb25e111"));
            SpecialityBaseHealthCommittee_HospitalsUnitsGrid = (ITTListBoxColumn)AddControl(new Guid("7021b979-ab00-4138-bcb6-ffe2052b57b5"));
            ExaminationStateInfo = (ITTTextBoxColumn)AddControl(new Guid("20d263bc-eca5-4be6-a4b0-145b287df79f"));
            DisableRatioInfo = (ITTTextBoxColumn)AddControl(new Guid("36b21d28-7ead-4dab-8bc8-8b3d5ff3f6f5"));
            WhoPays = (ITTEnumComboBox)AddControl(new Guid("52befab4-8105-4078-9cc8-2d91db6a597c"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("739f76d3-9513-4823-a492-b3cac79c2622"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("94d8b75d-8671-47c1-8254-3412e50c4002"));
            ReturnDescriptionGrid = (ITTGrid)AddControl(new Guid("068990f8-0e4b-4e7d-a29e-b964109d1e01"));
            EntryDate = (ITTTextBoxColumn)AddControl(new Guid("a67bd7a9-7b01-4e60-9146-4c8987cbe2c8"));
            ReturnDescription = (ITTTextBoxColumn)AddControl(new Guid("69d18418-2852-49eb-822e-7fdc88d49634"));
            OwnerUser = (ITTTextBoxColumn)AddControl(new Guid("d8f9957b-3ba4-40d4-99ed-d0fbc8dcc6d2"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("d18497ec-594c-4305-aeab-a80dcc44d810"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("f2e512eb-9c23-41bb-9ed6-82b0e905a7dc"));
            Height = (ITTTextBox)AddControl(new Guid("0a171b86-b95c-47e4-a823-aab6f553fbdd"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("dccf0c2d-8ede-4b84-bc2b-28ac7df67b7c"));
            Weight = (ITTTextBox)AddControl(new Guid("e5efd3ba-5122-4efe-a1ef-3e919e8aaaa8"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("b55aa4a8-56b9-4922-83ca-2f7fc9c32883"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("252ff698-212c-492b-88ea-b8f1a57d0c8d"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("e09b7ed4-7b23-4aa5-a675-6fcf8005fcc1"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("dde0e3d8-83e7-4b67-839e-1b35b5de735e"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("2f9d296b-910d-4632-a841-b3a6eb905e98"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("1b7bcaa6-0989-4d59-ad4c-38d84546dce4"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("0a7ea591-6711-4d5c-b92a-fbfb0cdb5d70"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("f538ff97-4877-4e2f-8eb9-064171660a97"));
            NumberOfProcedure = (ITTTextBox)AddControl(new Guid("e4ab00e4-e680-430e-8e76-38c1435ff1f7"));
            base.InitializeControls();
        }

        public HCNewForm() : base("HEALTHCOMMITTEE", "HCNewForm")
        {
        }

        protected HCNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}