
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
    /// Fizyoterapi İstek
    /// </summary>
    public partial class PhysiotherapyForm : EpisodeActionForm
    {
    /// <summary>
    /// F.T.R. İstek İşlemlerinin Gerçekleştirildiği  Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyRequest _PhysiotherapyRequest
        {
            get { return (TTObjectClasses.PhysiotherapyRequest)_ttObject; }
        }

        protected ITTButton ttButtonRaporSorgu;
        protected ITTLabel lblTaniGrubu;
        protected ITTTextBox TaniGrubu;
        protected ITTTextBox MedulaRaporBilgileri;
        protected ITTTextBox MedulaRaporTakipNo;
        protected ITTLabel lblRaporBilgileri;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelMedulaRaporTakipNo;
        protected ITTEnumComboBox cmbTedaviTuru;
        protected ITTCheckBox chkDisXXXXXXRaporu;
        protected ITTCheckBox chkInPatientBed;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel lblEpisodeDiagnosis;
        protected ITTDateTimePicker RequestDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage PhysiotherapyOrder;
        protected ITTGrid Physiotherapies;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn TreatmentDiagnosisUnit;
        protected ITTListBoxColumn FTRApplicationAreaDef;
        protected ITTTextBoxColumn ApplicationArea;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Duration;
        protected ITTTextBoxColumn TreatmentProperties;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox NoteToPhysiotherapist;
        protected ITTTabPage ClinicInfo;
        protected ITTTextBox ClinicFindings;
        protected ITTTabPage TabClinicInformation;
        protected ITTRichTextBoxControl ClinicInfoRTF;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelProcedureDoctor;
        protected ITTButton btnSelectTemplate;
        protected ITTButton btnCreateTemplate;
        protected ITTButton btnEditTemplate;
        protected ITTObjectListBox Bed;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelRoomGroup;
        protected ITTObjectListBox Room;
        protected ITTLabel labelRoom;
        protected ITTLabel labelBed;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTLabel labelPhysicalStateClinic;
        protected ITTObjectListBox SecondProcedureDoctor;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ThirdProcedureDoctor;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox PackageProcedure;
        override protected void InitializeControls()
        {
            ttButtonRaporSorgu = (ITTButton)AddControl(new Guid("0d8ba204-89f9-4444-83af-e55d3d0da4c5"));
            lblTaniGrubu = (ITTLabel)AddControl(new Guid("1ccc1cb7-1119-4200-b25c-53961b68122a"));
            TaniGrubu = (ITTTextBox)AddControl(new Guid("9b138922-ebfc-4c00-b39b-d438235ef94b"));
            MedulaRaporBilgileri = (ITTTextBox)AddControl(new Guid("84c7d208-8fcc-4a06-bb6f-5ca0b3fa419b"));
            MedulaRaporTakipNo = (ITTTextBox)AddControl(new Guid("811daef6-2333-4851-814a-cc4b4ca9a62c"));
            lblRaporBilgileri = (ITTLabel)AddControl(new Guid("9610d290-755a-407d-9320-4e8d8681ed13"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("29746b34-845e-4a72-aea6-4b5041407dd1"));
            labelMedulaRaporTakipNo = (ITTLabel)AddControl(new Guid("c83e48af-1568-4d3e-a46b-4b347980b145"));
            cmbTedaviTuru = (ITTEnumComboBox)AddControl(new Guid("be6c90eb-e5da-4e9c-95a8-85665f440d58"));
            chkDisXXXXXXRaporu = (ITTCheckBox)AddControl(new Guid("8444d282-f901-498f-a009-d5073b429dc5"));
            chkInPatientBed = (ITTCheckBox)AddControl(new Guid("2d068b3f-7fb0-439d-a3ae-12782dfb3659"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("e91f2cbf-0dfc-4cf5-8884-d7495188f1dc"));
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("33beb7a0-2b4b-4525-993c-fe14c155a3d7"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("fe79a83c-eed2-485f-8427-20119e628661"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("19dce3c9-f82c-4a74-a8b0-9c9d4393ef56"));
            PhysiotherapyOrder = (ITTTabPage)AddControl(new Guid("62b6ec07-30ee-4429-961c-7b7d82fcc277"));
            Physiotherapies = (ITTGrid)AddControl(new Guid("89be1169-3047-4965-8307-783d9f50d8d8"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("6f4e08c2-75b3-47e0-afb5-63facedff6f4"));
            TreatmentDiagnosisUnit = (ITTListBoxColumn)AddControl(new Guid("b44201f6-c8b9-4038-b7c7-2df902a5b5d1"));
            FTRApplicationAreaDef = (ITTListBoxColumn)AddControl(new Guid("517a53d0-9a42-4c70-80a6-345ce2c6f79f"));
            ApplicationArea = (ITTTextBoxColumn)AddControl(new Guid("5b3f4dbf-c6ec-4bee-b81d-2d4427b1eb09"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("e9b203c8-b3c1-4463-9e35-911a96c4b04f"));
            Duration = (ITTTextBoxColumn)AddControl(new Guid("7c91a16c-ee71-4fb2-a9f3-cdaa911e50ee"));
            TreatmentProperties = (ITTTextBoxColumn)AddControl(new Guid("5a4ad772-43b0-40ac-80f5-529da6f68167"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("816d3ec7-2461-41d9-afa1-c68133d1e23c"));
            NoteToPhysiotherapist = (ITTTextBox)AddControl(new Guid("6db9500a-2ab5-4130-b95c-1d8f85496562"));
            ClinicInfo = (ITTTabPage)AddControl(new Guid("cd5545af-17eb-41d1-86b4-2376c057e549"));
            ClinicFindings = (ITTTextBox)AddControl(new Guid("740c7c6d-1f9a-4703-a107-09133a48a3c9"));
            TabClinicInformation = (ITTTabPage)AddControl(new Guid("3e4429f4-5c06-4092-98dd-5e79a59a9fe5"));
            ClinicInfoRTF = (ITTRichTextBoxControl)AddControl(new Guid("d9d2ae1d-380b-4461-b0e5-93f20c156e2c"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("a6cc3d42-b734-4b2a-a598-931ed5ff9aa6"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("87d7ca2f-e892-428a-ab4a-ec51f587ba10"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("1f0f5bc9-fc43-42b9-b5d8-d891fc114132"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("ac60b269-1410-455c-92de-aea26f061ee8"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("5273dfdc-03dc-4660-818d-3a5d1f211135"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("a4e17d5a-21d1-4383-b2ed-6dc8427dbb7a"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("5b4ae1a9-fa08-4f0e-8063-cd966e32b476"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("55c6dd46-b1dd-4870-84d8-20b1a7227414"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("9a747a06-6479-40fe-b445-bcaee7bbdf89"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("ee78dee3-64e0-4bde-b206-c0a2ad3c306f"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("89b4b6f9-6dfe-4b52-9949-0d643ab552b2"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("a0a104e5-4fe4-4338-a5ab-6e558444c4f4"));
            btnSelectTemplate = (ITTButton)AddControl(new Guid("36d9fa3d-23f5-410e-91af-ce6a244d6100"));
            btnCreateTemplate = (ITTButton)AddControl(new Guid("8af201c6-a322-4a78-a541-a08182dbea28"));
            btnEditTemplate = (ITTButton)AddControl(new Guid("cbc8ab05-621c-42b1-a68e-1d8cb226ab6e"));
            Bed = (ITTObjectListBox)AddControl(new Guid("71728eca-770b-4220-b6eb-18c07bcb9d51"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("53dbb8ad-429d-4e53-a633-1195ba955b16"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("d7e64728-0a29-4e4b-b0cf-671b600c0937"));
            Room = (ITTObjectListBox)AddControl(new Guid("423c7361-2b2e-4f9d-b3df-5d255baa5665"));
            labelRoom = (ITTLabel)AddControl(new Guid("070370f5-1e8a-457a-8b4c-29ec6f997589"));
            labelBed = (ITTLabel)AddControl(new Guid("60f5f0a5-88c2-47a1-bab2-83656a298c90"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("6b69edf9-add5-4281-8f11-5326170a4551"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("5a4b3eae-ef06-4673-801d-03a2114235cc"));
            SecondProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("b21acb6f-49a5-4745-ab7f-1b7fa98ab02d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ac622f91-144a-4ed6-b25f-8366772fc35c"));
            ThirdProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("094a09e8-405d-4cf9-b88d-6a5f6994804d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("42a064ef-d183-4de3-baaf-524a3e036193"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("0b5d04d2-f8a5-46e3-8798-e7d824b9666d"));
            PackageProcedure = (ITTObjectListBox)AddControl(new Guid("25a26764-dbda-4344-af36-aa95488a6f61"));
            base.InitializeControls();
        }

        public PhysiotherapyForm() : base("PHYSIOTHERAPYREQUEST", "PhysiotherapyForm")
        {
        }

        protected PhysiotherapyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}