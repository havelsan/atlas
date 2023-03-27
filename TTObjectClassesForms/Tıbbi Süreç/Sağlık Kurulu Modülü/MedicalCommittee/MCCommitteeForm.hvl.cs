
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
    /// Tıbbi Kurullar
    /// </summary>
    public partial class MCCommitteeForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Kurul İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.MedicalCommittee _MedicalCommittee
        {
            get { return (TTObjectClasses.MedicalCommittee)_ttObject; }
        }

        protected ITTRichTextBoxControl TreatmentPlan;
        protected ITTRichTextBoxControl Subject;
        protected ITTLabel ttlabel2;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox MedicalCommitteType;
        protected ITTLabel labelDepartment;
        protected ITTLabel labelMedicalCommitteType;
        protected ITTObjectListBox Department;
        protected ITTTabControl tttabcontrolDiagnosis;
        protected ITTTabPage tttabpageEpisodeDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage tttabpagePreDiagnosis;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        protected ITTGrid MemberOfMedicalCommittee;
        protected ITTListBoxColumn Doctor;
        protected ITTListBoxColumn Speciality;
        protected ITTCheckBoxColumn NotAttend;
        protected ITTTextBoxColumn Description;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker ttdatetimepicker2;
        override protected void InitializeControls()
        {
            TreatmentPlan = (ITTRichTextBoxControl)AddControl(new Guid("2014c5a0-5122-4e16-88fc-b563e7602d82"));
            Subject = (ITTRichTextBoxControl)AddControl(new Guid("b0f5fb2f-9aec-4090-8aa6-fe8f6bfbe270"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ec99ecd5-010e-449b-ae64-828039f600b6"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("2cf281c5-8fb3-4aed-b92d-cae4cebd929c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("069727dd-7b37-4a4c-b57c-0851f9f6f5ee"));
            MedicalCommitteType = (ITTObjectListBox)AddControl(new Guid("aab21376-1167-4325-8318-119c641931bc"));
            labelDepartment = (ITTLabel)AddControl(new Guid("b5034237-c010-4c54-b9c1-4aa5493796a4"));
            labelMedicalCommitteType = (ITTLabel)AddControl(new Guid("b2d9edd6-27d7-4c92-b26e-ad18102325e0"));
            Department = (ITTObjectListBox)AddControl(new Guid("8717a674-d47c-408d-8ae1-fabc97d9c77a"));
            tttabcontrolDiagnosis = (ITTTabControl)AddControl(new Guid("f4f6f360-758e-4b0a-beb1-d076a1b69c5a"));
            tttabpageEpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("78e54db2-f686-4fa2-b9eb-112d1aa90a4a"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("a1c7a43d-f721-40fa-9653-77d2a3574bc5"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b581adf8-cb84-4636-b32b-333ec0b3d99e"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("d76a70ff-0d99-48c1-b600-0f7a6f2a3268"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("963acb92-d5dd-4555-9233-3532cf72a26d"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("833777f8-9e81-42ff-abe3-bef16b581c94"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("21fb058d-2985-437c-82f7-e36e8d064cf9"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("8732037e-6f45-4fc6-81de-beb7895bc3de"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("a06a56d4-a5b2-46ab-858c-a3d56009fc73"));
            tttabpagePreDiagnosis = (ITTTabPage)AddControl(new Guid("d677e641-67e3-4149-8d53-43ad4de6c085"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("520649c6-78fb-4578-98a3-98e80aebc885"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("dac88390-76b3-4914-a5be-4ee876e0ac70"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("a1dcf3ec-c79f-48ca-befe-71bcedf3ab74"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("327f0d4e-29dc-4b28-84b7-8777f6d289c5"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("53cb3834-378b-4755-bc22-90c4776e24a8"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("7fea47c0-5332-4611-986e-4b534766ca65"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("1a5499fc-8269-47e1-9c64-9d89dd5e02a0"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4f232c83-9772-447f-9ecb-999d22231436"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("876ebd69-f220-42af-8f77-ae23214b6260"));
            MemberOfMedicalCommittee = (ITTGrid)AddControl(new Guid("fc6c33c7-ed72-4f2d-afe2-e033af1b9a91"));
            Doctor = (ITTListBoxColumn)AddControl(new Guid("fd582fbb-888d-452c-bdec-e46bf240e6ae"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("a3076598-7ee8-419e-8598-db8ddd00108e"));
            NotAttend = (ITTCheckBoxColumn)AddControl(new Guid("9f0c7949-5050-4064-ae50-002292ea77ba"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("2293c585-3aae-44df-849a-14ff364493d8"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ae73e789-0586-4b7b-a8ba-d9c9b3bc4c79"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("793c78c4-033a-42f2-82bb-b3fe2b1891a7"));
            base.InitializeControls();
        }

        public MCCommitteeForm() : base("MEDICALCOMMITTEE", "MCCommitteeForm")
        {
        }

        protected MCCommitteeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}