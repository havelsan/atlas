
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
    /// Morg İşlemleri
    /// </summary>
    public partial class MorgueProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Morg İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Morgue _Morgue
        {
            get { return (TTObjectClasses.Morgue)_ttObject; }
        }

        protected ITTLabel labelSKRSTombTown;
        protected ITTObjectListBox SKRSTombTown;
        protected ITTLabel labelSKRSTombCity;
        protected ITTObjectListBox SKRSTombCity;
        protected ITTPanel ttpanel1;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTTextBox CitizenshipNoOfAdmittedFrom;
        protected ITTTextBox AddressOfAdmittedFrom;
        protected ITTLabel ttlabel1;
        protected ITTTextBox PhoneNumberOfAdmittedFrom;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel7;
        protected ITTTextBox DeathBodyAdmittedFrom;
        protected ITTTextBox DeathBodyAdmittedTo;
        protected ITTTextBox MorgueCupboardNo;
        protected ITTTextBox MaterialsAdmittedTo;
        protected ITTTextBox ExternalSenderDoctorMorgueUnR;
        protected ITTTextBox ExternalSenderDoctorToMorgue;
        protected ITTTextBox ExternalDoctorFixedUniqueNo;
        protected ITTTextBox ExternalDoctorFixed;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox DeathReportNo;
        protected ITTTextBox FoundationToFixDeath;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelMaterialsAdmittedFrom;
        protected ITTLabel labelMaterialsAdmittedTo;
        protected ITTObjectListBox Cupboard;
        protected ITTLabel labelMorgueCupboardNo;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelQuarantineCupboardNo;
        protected ITTObjectListBox MaterialsAdmittedFrom;
        protected ITTLabel labelDateTimeOfDeath;
        protected ITTLabel labelDeathReason;
        protected ITTGrid DeathReasonDiagnosis;
        protected ITTListBoxColumn SKRSICDDeathReasonDiagnosis;
        protected ITTListBoxColumn SKRSOlumNedeniTuruDeathReasonDiagnosis;
        protected ITTLabel labelDateOfDeathReport;
        protected ITTDateTimePicker DateOfDeathReport;
        protected ITTLabel labelNote;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTLabel labelSKRSInjuryPlace;
        protected ITTObjectListBox SKRSInjuryPlace;
        protected ITTLabel labelInjuryDate;
        protected ITTDateTimePicker InjuryDate;
        protected ITTLabel labelSKRSDeathReason;
        protected ITTObjectListBox SKRSDeathReason;
        protected ITTLabel labelSKRSDeathPlace;
        protected ITTObjectListBox SKRSDeathPlace;
        protected ITTLabel labelDeathReasonEvaluation;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTLabel labelDiedClinic;
        protected ITTObjectListBox DiedClinic;
        protected ITTLabel labelNurse;
        protected ITTObjectListBox Nurse;
        protected ITTLabel labelExternalSenderDoctorMorgueUnR;
        protected ITTLabel labelExternalSenderDoctorToMorgue;
        protected ITTLabel labelSenderDoctor;
        protected ITTObjectListBox ttobjectlistbox7;
        protected ITTLabel labelExternalDoctorFixedUniqueNo;
        protected ITTLabel labelExternalDoctorFixed;
        protected ITTLabel labelDoctorFixed;
        protected ITTObjectListBox ttobjectlistbox8;
        protected ITTLabel labelMernisDeathReasons;
        protected ITTObjectListBox MernisDeathReasons;
        protected ITTGrid MorgueDeathType;
        protected ITTListBoxColumn SKRSOlumSekliMorgueDeathType;
        protected ITTListBoxColumn MorgueMorgueDeathType;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel29;
        protected ITTCheckBox InjuryExisting;
        protected ITTLabel ttlabel17;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel10;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage Materials;
        protected ITTGrid MaterialsGrid;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTListBoxColumn ExMaterials;
        protected ITTTextBoxColumn ExAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn ExNotes;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn TreatmentMaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn OzelDurum;
        protected ITTTextBoxColumn Notes;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTextBoxColumn KodsuzMalzemeFiyatı;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn SatinAlisTarihi;
        override protected void InitializeControls()
        {
            labelSKRSTombTown = (ITTLabel)AddControl(new Guid("94207236-75b5-43a1-ba85-f44235f6ccba"));
            SKRSTombTown = (ITTObjectListBox)AddControl(new Guid("56b99a36-d24e-4347-9b1f-040fd36d9764"));
            labelSKRSTombCity = (ITTLabel)AddControl(new Guid("7027a77b-1b7b-4ff9-8f3d-8b489d3529b3"));
            SKRSTombCity = (ITTObjectListBox)AddControl(new Guid("0140b534-42a6-49ff-88f4-a3c72fa2fd4e"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("438c9d1d-a74a-49c3-b80e-06b785d78309"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bb39c7ce-c99d-4f6f-98bd-f7a2d34df697"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("cdb9e42a-b603-4cae-b13f-af0687629dfd"));
            CitizenshipNoOfAdmittedFrom = (ITTTextBox)AddControl(new Guid("b674ac1f-0204-4c4f-aab2-8f82f55d610d"));
            AddressOfAdmittedFrom = (ITTTextBox)AddControl(new Guid("fb106cd3-740a-405e-a879-6d8259bb09a8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a571bf9d-e0d1-475b-b599-ecd16077c0f3"));
            PhoneNumberOfAdmittedFrom = (ITTTextBox)AddControl(new Guid("388f1fbd-ee46-4ad8-90f3-e6d06c3c88b9"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("83d63e0b-77d7-4fe2-8bbd-dbba4076c941"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("532d9917-7044-4f11-8515-1c79608de48a"));
            DeathBodyAdmittedFrom = (ITTTextBox)AddControl(new Guid("ea896147-c935-4c21-89cb-8621179e8690"));
            DeathBodyAdmittedTo = (ITTTextBox)AddControl(new Guid("062ae931-c0bd-4218-ba2d-45a38302f3b6"));
            MorgueCupboardNo = (ITTTextBox)AddControl(new Guid("4d6c5355-3c2a-4ea3-af70-844c9bc50e73"));
            MaterialsAdmittedTo = (ITTTextBox)AddControl(new Guid("928da148-0f3d-4303-a11c-45deaa6fa5e3"));
            ExternalSenderDoctorMorgueUnR = (ITTTextBox)AddControl(new Guid("995c9afb-8e24-4222-b549-c3f5e5b9e328"));
            ExternalSenderDoctorToMorgue = (ITTTextBox)AddControl(new Guid("7ea3c5c4-8893-4109-9009-038d15167d83"));
            ExternalDoctorFixedUniqueNo = (ITTTextBox)AddControl(new Guid("e608d710-79e6-4e84-b5ac-73572aabebc6"));
            ExternalDoctorFixed = (ITTTextBox)AddControl(new Guid("87d9cf19-350f-4fa8-9380-cc51c7a61625"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("bca7d526-e9d1-4aa7-87b3-46f472bd1d93"));
            DeathReportNo = (ITTTextBox)AddControl(new Guid("1744164f-fe0f-4939-b535-b6a0b97f2d42"));
            FoundationToFixDeath = (ITTTextBox)AddControl(new Guid("caad00fd-829c-405f-bae7-1948748d1f3b"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("82ce3f53-7f1e-42bc-910e-a84b6f4290ac"));
            labelMaterialsAdmittedFrom = (ITTLabel)AddControl(new Guid("98f8af42-f2fc-4dc6-9053-7ab1a7ef2763"));
            labelMaterialsAdmittedTo = (ITTLabel)AddControl(new Guid("5f45223c-389d-423a-b926-ae2b33abb80f"));
            Cupboard = (ITTObjectListBox)AddControl(new Guid("e5db8e88-ecf3-427e-983d-838621af895f"));
            labelMorgueCupboardNo = (ITTLabel)AddControl(new Guid("ec47d341-c0d2-476d-a55c-73e39f6385c6"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("d9e5499b-d4e8-4907-b447-bb1daad940c4"));
            labelQuarantineCupboardNo = (ITTLabel)AddControl(new Guid("f886efb7-630d-4954-be16-042f4878c66d"));
            MaterialsAdmittedFrom = (ITTObjectListBox)AddControl(new Guid("4b95a241-2868-45d1-b550-66c180345711"));
            labelDateTimeOfDeath = (ITTLabel)AddControl(new Guid("aaf3643a-4520-412c-abdd-2002e54f730f"));
            labelDeathReason = (ITTLabel)AddControl(new Guid("e53e4ad6-2349-4002-9a80-1f94f2b8e5a5"));
            DeathReasonDiagnosis = (ITTGrid)AddControl(new Guid("eb415897-4efe-46d2-85c0-0d9bf1dd7071"));
            SKRSICDDeathReasonDiagnosis = (ITTListBoxColumn)AddControl(new Guid("1066c5e0-9e95-40bb-a80a-237b3d351f2b"));
            SKRSOlumNedeniTuruDeathReasonDiagnosis = (ITTListBoxColumn)AddControl(new Guid("2db39235-8098-4983-a7e3-ebb85f7e5674"));
            labelDateOfDeathReport = (ITTLabel)AddControl(new Guid("ee76498c-9c17-4d4b-9e8e-bfb9bacb6543"));
            DateOfDeathReport = (ITTDateTimePicker)AddControl(new Guid("7ab02b92-6fda-432c-8a15-b1aac350314d"));
            labelNote = (ITTLabel)AddControl(new Guid("c99d41fa-7651-4727-a63a-b44cb2d4ccd2"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("cb8cc9e9-2867-47f2-9bae-58289eb6530b"));
            labelSKRSInjuryPlace = (ITTLabel)AddControl(new Guid("832f2977-033a-4668-be82-7769847dd570"));
            SKRSInjuryPlace = (ITTObjectListBox)AddControl(new Guid("45c68e6e-3a6f-4282-a12e-8e727701e3df"));
            labelInjuryDate = (ITTLabel)AddControl(new Guid("46eb1226-532e-4201-aa86-4140c0709e6b"));
            InjuryDate = (ITTDateTimePicker)AddControl(new Guid("af8d4bec-f69d-4e75-90fd-233ab642fb27"));
            labelSKRSDeathReason = (ITTLabel)AddControl(new Guid("e693d495-2b46-497d-b239-26359793840c"));
            SKRSDeathReason = (ITTObjectListBox)AddControl(new Guid("8f446ac7-4d5a-4a08-87a6-35b356b79091"));
            labelSKRSDeathPlace = (ITTLabel)AddControl(new Guid("89ec50b6-d52e-4ef5-8df3-90422d457ec5"));
            SKRSDeathPlace = (ITTObjectListBox)AddControl(new Guid("93ea1035-a16d-4687-9543-9bdc92d8eeb1"));
            labelDeathReasonEvaluation = (ITTLabel)AddControl(new Guid("83436842-f650-453c-967f-50d7a283cb41"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("17d8353b-2f1b-451f-96a8-932e5e62acd5"));
            labelDiedClinic = (ITTLabel)AddControl(new Guid("0b30114f-78b6-4919-9ef6-b7005d85379e"));
            DiedClinic = (ITTObjectListBox)AddControl(new Guid("28e3f02c-805b-449a-96d7-d8e0069e9cdd"));
            labelNurse = (ITTLabel)AddControl(new Guid("ce20bb5f-b470-4762-b294-ffd33f21f66c"));
            Nurse = (ITTObjectListBox)AddControl(new Guid("0d4aa8a0-189a-4d52-8c38-5930eccfa8a8"));
            labelExternalSenderDoctorMorgueUnR = (ITTLabel)AddControl(new Guid("a26512db-b01e-498d-8ddc-8f972bd1985a"));
            labelExternalSenderDoctorToMorgue = (ITTLabel)AddControl(new Guid("74fb772a-980d-4530-bed2-2434d39f5e0c"));
            labelSenderDoctor = (ITTLabel)AddControl(new Guid("638ea3c5-a86e-43a3-9985-e5db303b0172"));
            ttobjectlistbox7 = (ITTObjectListBox)AddControl(new Guid("020dd1fc-5ffe-4e06-b339-4cc686be0198"));
            labelExternalDoctorFixedUniqueNo = (ITTLabel)AddControl(new Guid("bd0db0da-1b06-49a8-b5c0-92f580497860"));
            labelExternalDoctorFixed = (ITTLabel)AddControl(new Guid("7e2ea161-85ab-41af-9b10-3befe6639dec"));
            labelDoctorFixed = (ITTLabel)AddControl(new Guid("42a6165a-6d4f-4be6-bd2d-1ae081fe2321"));
            ttobjectlistbox8 = (ITTObjectListBox)AddControl(new Guid("875c4909-4aa2-4c66-9049-279ca0425887"));
            labelMernisDeathReasons = (ITTLabel)AddControl(new Guid("009f421b-a3ea-4d50-89a6-060f5d0dc6b4"));
            MernisDeathReasons = (ITTObjectListBox)AddControl(new Guid("4dfcdc3d-c5e2-49f5-92f7-79bd60b83d23"));
            MorgueDeathType = (ITTGrid)AddControl(new Guid("49ad4fef-2819-4f68-a85a-e2b994dbd9d6"));
            SKRSOlumSekliMorgueDeathType = (ITTListBoxColumn)AddControl(new Guid("f20fb520-5049-415b-bf94-705700e78471"));
            MorgueMorgueDeathType = (ITTListBoxColumn)AddControl(new Guid("2008166f-1c72-4422-bb6a-ace18cba14cf"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("47594259-b8b3-4765-baf9-7c74b14d1ecb"));
            ttlabel29 = (ITTLabel)AddControl(new Guid("23ad8a1b-d84e-4eef-8306-dfe75ca78cdf"));
            InjuryExisting = (ITTCheckBox)AddControl(new Guid("7d1827f8-98b8-43d8-80a1-e050c6af20cb"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("7ecb49f6-d78b-4fbf-8dd7-e20ee40d39c5"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("ebbd5c3c-940f-4eb9-9dc4-6f1c19eea667"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ef65997f-4d2f-4964-aac8-acfc3839835c"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("afaf679c-272e-4c5a-bdaa-e96322154b04"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("4028ab9a-c8a5-41aa-b93e-898ff0352e78"));
            Materials = (ITTTabPage)AddControl(new Guid("e0dee052-54aa-40b0-bc14-6220bc000673"));
            MaterialsGrid = (ITTGrid)AddControl(new Guid("07a882d6-3659-4037-b7ce-90b911c3f07a"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("6d6ca461-641b-452e-829a-c0f08fa1fd5b"));
            ExMaterials = (ITTListBoxColumn)AddControl(new Guid("bb5b0e5d-823c-4228-bc71-18c0ea663fb5"));
            ExAmount = (ITTTextBoxColumn)AddControl(new Guid("a0c7c596-96a5-4a08-a0ac-3399ee259fff"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("c869db92-7a16-4515-9f59-f417244a19af"));
            ExNotes = (ITTTextBoxColumn)AddControl(new Guid("45fba1bf-9cef-455a-93fd-04efcb24d727"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("78157625-7582-4afc-b620-50f1040b6e33"));
            TreatmentMaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("d26471ea-fe53-4c1e-a8d8-37f715921834"));
            Material = (ITTListBoxColumn)AddControl(new Guid("f7b899f5-2da8-4076-b422-3719945627a5"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("50afb0f6-8a88-4faf-b120-f6665046080c"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("dc272b3e-54db-44ba-8988-7bd2f59bfe7b"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("662c6676-6fff-46d6-a0f1-d3f87e04bbd7"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("cb9b32de-6b6d-407d-8af8-4152fb6c388b"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("2e0cb54e-21c5-4101-965f-341f434d1a73"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("98bf1ec9-5411-4b42-a840-16a147eb4794"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("2e3c0724-656c-43ed-82cb-6ac814533467"));
            KodsuzMalzemeFiyatı = (ITTTextBoxColumn)AddControl(new Guid("b1f6c075-849e-4878-9d18-3e56f43c3192"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("74cc86c3-7a08-4e10-b2ef-4a958c910dcf"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("95924e5e-ce2c-4f92-89e7-51e5440b479e"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("0852d02c-d04a-47fe-b815-cbdbd7f71716"));
            SatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("1dd4ccb6-c0d7-4eaa-a8a7-9eca09c17533"));
            base.InitializeControls();
        }

        public MorgueProcedureForm() : base("MORGUE", "MorgueProcedureForm")
        {
        }

        protected MorgueProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}