
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
    /// Ortez Protez
    /// </summary>
    public partial class OrthesisProsthesisDoctorApprovalForm : EpisodeActionForm
    {
    /// <summary>
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest
        {
            get { return (TTObjectClasses.OrthesisProsthesisRequest)_ttObject; }
        }

        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelTechnicianNote;
        protected ITTRichTextBoxControl TotalDescription;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage OrthesisProthesis;
        protected ITTGrid OrthesisProsthesisProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTEnumComboBoxColumn SideO;
        protected ITTTextBoxColumn Amount;
        protected ITTTabPage tttabpageDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn MMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBox ChiefTechnicianNote;
        protected ITTTextBox TechnicianNote;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelChiefTechnicianNote;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelProcedureDoctor;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("b40ef72b-5b23-4b19-8b81-4ccc6889633f"));
            labelTechnicianNote = (ITTLabel)AddControl(new Guid("e9909ba1-8c7d-4f9c-80cc-17c6a6e69752"));
            TotalDescription = (ITTRichTextBoxControl)AddControl(new Guid("bb8d5fae-3e3d-41a8-97be-4223d83af533"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("2f90256a-e50c-4856-b3f2-6fdfc53e1ee8"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("620e4faf-2c0e-4fcd-ab2e-58db06768589"));
            OrthesisProthesis = (ITTTabPage)AddControl(new Guid("313f887a-5302-4d04-92ab-3dd2c999d8a2"));
            OrthesisProsthesisProcedures = (ITTGrid)AddControl(new Guid("b40e5248-51cc-4601-9035-f7b98f190655"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e1eee3f4-59c4-45a4-8b67-b441a5cf69e9"));
            SideO = (ITTEnumComboBoxColumn)AddControl(new Guid("cf50e5ff-7cf2-4f4f-aad2-3f3721df6fe3"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("c3aa1eb3-42db-4152-af8d-c25e9d53d262"));
            tttabpageDiagnosis = (ITTTabPage)AddControl(new Guid("4e33e4ab-c57a-4bd2-abb9-11b881dcf4e9"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("2093f96b-eb94-40f2-9739-e6afe93e2d80"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("4918ae34-15bd-4e94-a689-23a9b21cf71e"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("aeb01c88-e452-4e4f-a956-21e294efd3ca"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("246b5e5a-f9ef-4293-8113-b60f15a35c57"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("bce8448b-7dc6-4b56-aa76-bfe846319bdf"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("88dcf91c-29f8-402e-91fd-86c04ba0ef19"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("d114ec16-4f85-4427-9df3-4af476b28302"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("bf9d8adb-f2f1-4529-a3aa-10ffd9e6d596"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("6c2705c5-7320-49fa-ba20-95a9f3ab66a2"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("fe0eabf0-f43a-4aa9-b224-6f22887808d1"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b6f1a994-dab8-4466-8bc3-e4ffde1e8c81"));
            MMaterial = (ITTListBoxColumn)AddControl(new Guid("5e60ef05-ea8f-432f-82ec-6b39fb3cc8b7"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("e0c2b6e5-41fa-4e13-863b-f48f38579e40"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("7a6578d2-e5a1-49a8-869c-10044690921f"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("42c0d121-1208-4d07-8416-796b637c5f08"));
            ChiefTechnicianNote = (ITTTextBox)AddControl(new Guid("c1c0d57c-747e-4294-8767-64e4e1df89be"));
            TechnicianNote = (ITTTextBox)AddControl(new Guid("007b6135-78ba-45a7-961f-a4101e6069c5"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("c89477a6-b861-4d13-9e44-94fbc3e11991"));
            labelChiefTechnicianNote = (ITTLabel)AddControl(new Guid("068f2871-078e-4682-9276-9a85e4ece008"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("4ebd4370-c705-48f6-aa44-d0ce43f2ec9a"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("ac6243d6-5e15-4e10-94aa-fa5d65a831a5"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("0b314011-383a-4b4c-b3cb-d503dceebd6c"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("82bda035-9d1d-4d1a-b771-9850ffb0efa3"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("10988cb2-7036-4685-aeef-f1134b55c8fb"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("9e732e4d-26b6-4351-a7dc-0ed0dc3a7a81"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("b852dc89-7185-4a5c-bfd0-f6cb0ecb92c9"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("8e460112-66d2-4f37-8a07-135b681132b6"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fd5ae3ae-3b90-40ce-a6e9-fe041a6a9c2c"));
            base.InitializeControls();
        }

        public OrthesisProsthesisDoctorApprovalForm() : base("ORTHESISPROSTHESISREQUEST", "OrthesisProsthesisDoctorApprovalForm")
        {
        }

        protected OrthesisProsthesisDoctorApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}