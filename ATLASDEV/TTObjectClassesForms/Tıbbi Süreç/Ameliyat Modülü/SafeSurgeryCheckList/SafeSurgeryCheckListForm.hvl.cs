
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
    /// Güvenli Cerrahi Kontrol Listesi Formu
    /// </summary>
    public partial class SafeSurgeryCheckListForm : TTForm
    {
    /// <summary>
    /// Güvenli Cerrahi Kontrol Listesi
    /// </summary>
        protected TTObjectClasses.SafeSurgeryCheckList _SafeSurgeryCheckList
        {
            get { return (TTObjectClasses.SafeSurgeryCheckList)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage BeforeLeavingClinic;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelClinicalNurse;
        protected ITTObjectListBox ClinicalNurse;
        protected ITTLabel labelPatientClothesDescription;
        protected ITTTextBox PatientClothesDescription;
        protected ITTCheckBox LabAndRadioTestsAvailable;
        protected ITTCheckBox MaterialPreparationChecked;
        protected ITTLabel labelOtherSpecialActionDescription;
        protected ITTTextBox OtherSpecialActionDescription;
        protected ITTCheckBox OtherSpecialActionRequired;
        protected ITTCheckBox TreatmentProtocolRequired;
        protected ITTCheckBox CatheterizationRequired;
        protected ITTCheckBox VaricoseBandageRequired;
        protected ITTCheckBox LavmanRequired;
        protected ITTCheckBox IsPatientClothesReady;
        protected ITTLabel labelMakeupProstValItemDescription;
        protected ITTTextBox MakeupProstValItemDescription;
        protected ITTCheckBox MakeupProsthesisValuableItem;
        protected ITTLabel labelSurgeryAreaShavedDescription;
        protected ITTTextBox SurgeryAreaShavedDescription;
        protected ITTCheckBox SurgeryAreaShaved;
        protected ITTLabel labelPatientHungerDescription;
        protected ITTTextBox PatientHungerDescription;
        protected ITTCheckBox IsPatientHungry;
        protected ITTCheckBox PatientConsentChecked;
        protected ITTCheckBox PatientSurgeryAreaVerified;
        protected ITTCheckBox PatientSurgeryVerified;
        protected ITTCheckBox PatientIDInfoVerified;
        protected ITTTabPage BeforeAnesthesia;
        protected ITTLabel labelAnesthesiologist;
        protected ITTObjectListBox Anesthesiologist;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel17;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelPatientAllergyDescription;
        protected ITTTextBox PatientAllergyDescription;
        protected ITTCheckBox HasBloodLossRisk;
        protected ITTCheckBox HasImagingDevice;
        protected ITTCheckBox PatientHasAnAllergy;
        protected ITTCheckBox PulseOximeterWorksOut;
        protected ITTCheckBox AnesthesiaChecklistCompleted;
        protected ITTCheckBox HasSignInSurgeryArea;
        protected ITTCheckBox ConsentVerifiedByPatient;
        protected ITTCheckBox SugeryAreaVerifiedByPatient;
        protected ITTCheckBox SurgeryVerifiedByPatient;
        protected ITTCheckBox PatientIDVerifiedByPatient;
        protected ITTLabel ttlabel1;
        protected ITTTabPage BeforeSurgicalIncision;
        protected ITTLabel ttlabel26;
        protected ITTLabel ttlabel25;
        protected ITTLabel ttlabel24;
        protected ITTLabel ttlabel23;
        protected ITTLabel ttlabel22;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel21;
        protected ITTLabel ttlabel20;
        protected ITTLabel ttlabel19;
        protected ITTLabel labelSurgeryDoctor;
        protected ITTObjectListBox SurgeryDoctor;
        protected ITTCheckBox TeamMemberInformedVerbally;
        protected ITTCheckBox NecessaryDeepVeinThrombosis;
        protected ITTCheckBox HasAnticoagulantUsage;
        protected ITTCheckBox NecessaryBloodSugarControl;
        protected ITTCheckBox SuitableMaterialSterilization;
        protected ITTCheckBox ReadyUsedMaterials;
        protected ITTCheckBox AppliedProphylacticAntibiotic;
        protected ITTCheckBox ReviewedPatientPosition;
        protected ITTCheckBox ReviewedPossibAnesthesiaRisk;
        protected ITTCheckBox ReviewedUnexpectedEvents;
        protected ITTCheckBox ReviewedExpectedBloodLoss;
        protected ITTCheckBox ReviewedEstimatedSurgeryTime;
        protected ITTCheckBox TeamMembersIntroThemselves;
        protected ITTTabPage BeforeLeavingSurgery;
        protected ITTLabel ttlabel34;
        protected ITTLabel ttlabel33;
        protected ITTLabel ttlabel32;
        protected ITTLabel ttlabel31;
        protected ITTLabel ttlabel30;
        protected ITTLabel labelOperatingRoomNurse;
        protected ITTObjectListBox OperatingRoomNurse;
        protected ITTCheckBox ConfirmedAfterSurgeryClinic;
        protected ITTLabel labelSurgeonSuggestions;
        protected ITTTextBox SurgeonSuggestions;
        protected ITTLabel labelAnesthetistSuggestions;
        protected ITTTextBox AnesthetistSuggestions;
        protected ITTCheckBox SampleRegionOnSampleLabel;
        protected ITTCheckBox PatientNameOnSampleLabel;
        protected ITTCheckBox ToolSpongeNeedleCountsDone;
        protected ITTCheckBox ConfirmedSurgeryAreaVerbally;
        protected ITTCheckBox ConfirmedSurgeryVerbally;
        protected ITTCheckBox ConfirmedPatientVerbally;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("aa8812a2-9cf5-4bfe-ab5a-2a91ed9d669a"));
            BeforeLeavingClinic = (ITTTabPage)AddControl(new Guid("77a63e21-1d2e-4470-a9eb-12c83ebccfc1"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("8e8d41ef-2b67-498e-8355-02f2cbf4e472"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("c78a341d-f203-4700-bfdc-80c86cafb07f"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("5944e94a-c976-49f1-b04c-ad68c3b47ee4"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("52cfea8e-fac7-4342-97c0-d3ed1b97b9b2"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("fd1bc6f0-b971-472a-be21-2f3aeebe3e64"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("fe0bd042-5758-4852-9b53-881ad13f8316"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("3a87ffe2-f189-4d47-a527-d0d3d825403f"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("afe2491d-3669-4cc7-b74b-ff03173bd9c1"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("885e48da-2456-4b74-87cf-431570300539"));
            labelClinicalNurse = (ITTLabel)AddControl(new Guid("d5f98bdf-3421-47c3-876a-386b3d34cdd7"));
            ClinicalNurse = (ITTObjectListBox)AddControl(new Guid("7fae6fc1-0541-48a2-9237-a963d4afb682"));
            labelPatientClothesDescription = (ITTLabel)AddControl(new Guid("783e909b-ed90-4cf3-ae6d-d94334cbc360"));
            PatientClothesDescription = (ITTTextBox)AddControl(new Guid("21c012f9-b1fb-404d-990e-38be4d21272a"));
            LabAndRadioTestsAvailable = (ITTCheckBox)AddControl(new Guid("1735aa10-bc73-4980-aba6-df89e42d3db0"));
            MaterialPreparationChecked = (ITTCheckBox)AddControl(new Guid("e139985c-d172-42aa-bf15-fcfa6c3848b9"));
            labelOtherSpecialActionDescription = (ITTLabel)AddControl(new Guid("802de16c-8f99-44aa-85d3-74e3eee66be7"));
            OtherSpecialActionDescription = (ITTTextBox)AddControl(new Guid("56175d48-ce92-4070-b8d7-f8017db95424"));
            OtherSpecialActionRequired = (ITTCheckBox)AddControl(new Guid("cf61a861-de00-494c-804c-ef5516ec461b"));
            TreatmentProtocolRequired = (ITTCheckBox)AddControl(new Guid("f5a68e43-0b79-4f76-a881-bb1bd4c68269"));
            CatheterizationRequired = (ITTCheckBox)AddControl(new Guid("4058e144-05f9-4638-aa26-5600404107ca"));
            VaricoseBandageRequired = (ITTCheckBox)AddControl(new Guid("913b5cb7-000d-4612-8459-d77f73704eb5"));
            LavmanRequired = (ITTCheckBox)AddControl(new Guid("8fe6f29e-94ea-4914-944b-8c0fa5b1a104"));
            IsPatientClothesReady = (ITTCheckBox)AddControl(new Guid("84c35bf6-6601-4260-8c81-5d7c9cca383d"));
            labelMakeupProstValItemDescription = (ITTLabel)AddControl(new Guid("2f8887a7-ee3c-4e70-a5c7-377fb69d8f6c"));
            MakeupProstValItemDescription = (ITTTextBox)AddControl(new Guid("1dbc4849-d67e-4d44-bf61-a7a61f1d8679"));
            MakeupProsthesisValuableItem = (ITTCheckBox)AddControl(new Guid("442cf54f-86db-4b66-863a-52751253d005"));
            labelSurgeryAreaShavedDescription = (ITTLabel)AddControl(new Guid("a6909d7a-d95e-4797-a8f0-a435f53349f7"));
            SurgeryAreaShavedDescription = (ITTTextBox)AddControl(new Guid("a8b8e9fd-2d10-426d-9aec-da8ea9280578"));
            SurgeryAreaShaved = (ITTCheckBox)AddControl(new Guid("e36475c0-4713-4910-a3b3-952ecc82e7d1"));
            labelPatientHungerDescription = (ITTLabel)AddControl(new Guid("acfdc887-0741-4424-b98f-bf5233ee97b2"));
            PatientHungerDescription = (ITTTextBox)AddControl(new Guid("fa2d801a-8997-49f8-bb86-3b460b431495"));
            IsPatientHungry = (ITTCheckBox)AddControl(new Guid("e80d64a2-e956-433d-a2ce-24db2153de37"));
            PatientConsentChecked = (ITTCheckBox)AddControl(new Guid("53ef7017-f73c-4ba5-8dc3-ad94a4c8cf74"));
            PatientSurgeryAreaVerified = (ITTCheckBox)AddControl(new Guid("e2e538ac-5937-4d52-9d75-1ff082608cd9"));
            PatientSurgeryVerified = (ITTCheckBox)AddControl(new Guid("d59e239f-84ad-48f0-a190-048db356d6c8"));
            PatientIDInfoVerified = (ITTCheckBox)AddControl(new Guid("010306d9-ac38-4ac9-b577-6cdb486edb33"));
            BeforeAnesthesia = (ITTTabPage)AddControl(new Guid("b7f9d585-f91a-41e9-9a38-b2fc62e764d8"));
            labelAnesthesiologist = (ITTLabel)AddControl(new Guid("955c0baa-5e81-418a-94ca-699d2959e3da"));
            Anesthesiologist = (ITTObjectListBox)AddControl(new Guid("ccc147e4-221d-4edf-a116-69b6d41e98d7"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("c692ed81-dbfe-4a64-a030-05655adb67a3"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("24ef1f80-93de-4903-b290-3eb588853c99"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("b121c226-d7f8-46b3-a353-c2e3819557f4"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("b06f5d8a-252d-4ce3-a667-82bf9dc0799a"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("f9ea3d1a-8b9d-4177-aa7a-3bba16fdf4da"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4f96ab3a-f5bb-47e7-8ffb-6a6b9b4efb49"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e3c49c4a-2608-4771-961e-5d9f28184d9b"));
            labelPatientAllergyDescription = (ITTLabel)AddControl(new Guid("76f00f64-e327-4ad4-9a08-69d59bb38238"));
            PatientAllergyDescription = (ITTTextBox)AddControl(new Guid("cdfec1af-0ab3-45a5-b7cd-471039b66e93"));
            HasBloodLossRisk = (ITTCheckBox)AddControl(new Guid("d40243e4-b2eb-4ec8-aa58-365447696327"));
            HasImagingDevice = (ITTCheckBox)AddControl(new Guid("6a7930bf-1b71-4316-b5c0-e6380ca6f02e"));
            PatientHasAnAllergy = (ITTCheckBox)AddControl(new Guid("cf734745-87fa-43f3-be45-ea2a7ebd423d"));
            PulseOximeterWorksOut = (ITTCheckBox)AddControl(new Guid("046a4d43-ab80-471a-b261-6d40eee03f16"));
            AnesthesiaChecklistCompleted = (ITTCheckBox)AddControl(new Guid("86a03759-5267-4a8f-b288-4b838e41697e"));
            HasSignInSurgeryArea = (ITTCheckBox)AddControl(new Guid("52eea624-d222-4118-952e-ee449b541b8f"));
            ConsentVerifiedByPatient = (ITTCheckBox)AddControl(new Guid("e12919b3-2a38-4933-8d7d-746e144be573"));
            SugeryAreaVerifiedByPatient = (ITTCheckBox)AddControl(new Guid("cb3a8660-5a4a-4d45-8885-016b6c5529db"));
            SurgeryVerifiedByPatient = (ITTCheckBox)AddControl(new Guid("04fe7cad-534d-42d1-b6c7-efcff86105ba"));
            PatientIDVerifiedByPatient = (ITTCheckBox)AddControl(new Guid("edfd628c-6194-4e83-98f4-1491395193a9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7846a7e0-bd0e-4445-926b-9379a7dbaee0"));
            BeforeSurgicalIncision = (ITTTabPage)AddControl(new Guid("8ed38e3b-e1c3-4910-8ece-031540e11759"));
            ttlabel26 = (ITTLabel)AddControl(new Guid("7f669efb-461c-43ee-93ee-205e25cef73e"));
            ttlabel25 = (ITTLabel)AddControl(new Guid("6835059a-e37a-4a34-8606-13b88d0ecb04"));
            ttlabel24 = (ITTLabel)AddControl(new Guid("8ccdd9eb-c14f-46e3-92be-1b9c51dc3448"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("b8258416-3779-4f88-93ee-b177e23e00db"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("5b53f961-587a-474f-8ddc-96fae89bf16b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("02fcedbc-35d6-43cf-8840-228530e77863"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("c4f73112-5a99-472c-959c-1f22a05b2beb"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("ca9546ed-5f20-44d9-a3db-a5ddf281b323"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("f41da9e3-a2a1-48b2-84e6-1bdd3868938a"));
            labelSurgeryDoctor = (ITTLabel)AddControl(new Guid("cb86f491-9146-4261-945f-7a0ae4b75938"));
            SurgeryDoctor = (ITTObjectListBox)AddControl(new Guid("287ce14e-782e-4cd2-bd2e-2a730dc3404d"));
            TeamMemberInformedVerbally = (ITTCheckBox)AddControl(new Guid("c6ffac84-56db-4840-8ab1-d5c5ad464b96"));
            NecessaryDeepVeinThrombosis = (ITTCheckBox)AddControl(new Guid("bfade647-1204-439b-9fef-9669288ff077"));
            HasAnticoagulantUsage = (ITTCheckBox)AddControl(new Guid("56ebe0ba-d2e4-44c6-95e3-c160fee06485"));
            NecessaryBloodSugarControl = (ITTCheckBox)AddControl(new Guid("9f16aae4-07d1-459b-9937-4db03c4c6d30"));
            SuitableMaterialSterilization = (ITTCheckBox)AddControl(new Guid("781a1003-f814-4aab-b1bb-c5b08ce78f35"));
            ReadyUsedMaterials = (ITTCheckBox)AddControl(new Guid("28e4d07f-d465-44c6-b4f5-89a791f75cd2"));
            AppliedProphylacticAntibiotic = (ITTCheckBox)AddControl(new Guid("2a741feb-cf48-41b2-bc25-e9778a78e0a1"));
            ReviewedPatientPosition = (ITTCheckBox)AddControl(new Guid("258fef3d-b1f1-4d5a-9d40-fb974af79f3c"));
            ReviewedPossibAnesthesiaRisk = (ITTCheckBox)AddControl(new Guid("187b0a8a-f810-469d-85a1-4658d6c238b2"));
            ReviewedUnexpectedEvents = (ITTCheckBox)AddControl(new Guid("cd52f92e-7884-4874-b45e-cb4c7ef25f11"));
            ReviewedExpectedBloodLoss = (ITTCheckBox)AddControl(new Guid("0c898a68-e2ee-41ce-ad8a-7fab783eba3d"));
            ReviewedEstimatedSurgeryTime = (ITTCheckBox)AddControl(new Guid("cd750142-1841-4f3b-b96b-5bf4cec16c2a"));
            TeamMembersIntroThemselves = (ITTCheckBox)AddControl(new Guid("5c39ec3c-237a-443a-b73d-5343edddeec2"));
            BeforeLeavingSurgery = (ITTTabPage)AddControl(new Guid("d349a3c1-89a3-40f0-a85d-49176ecd46ae"));
            ttlabel34 = (ITTLabel)AddControl(new Guid("3d5c6dc6-b431-4183-98bd-52448670c2d8"));
            ttlabel33 = (ITTLabel)AddControl(new Guid("127671ff-7438-4986-8655-75efaca5b75d"));
            ttlabel32 = (ITTLabel)AddControl(new Guid("a20572dc-2123-4069-b74c-d9fdfe19ccf4"));
            ttlabel31 = (ITTLabel)AddControl(new Guid("29fa985e-389b-4674-b60a-d9c2c7f843d3"));
            ttlabel30 = (ITTLabel)AddControl(new Guid("0e4d8795-6eb3-433c-abd9-4527cdc5f8f5"));
            labelOperatingRoomNurse = (ITTLabel)AddControl(new Guid("ae3e5ed4-793d-4826-a2e0-9339179cd3c8"));
            OperatingRoomNurse = (ITTObjectListBox)AddControl(new Guid("0e1d695a-1c85-4bcb-8652-c0c6e99764ed"));
            ConfirmedAfterSurgeryClinic = (ITTCheckBox)AddControl(new Guid("7531cfb4-cd1e-4b0b-a655-cfb633a39130"));
            labelSurgeonSuggestions = (ITTLabel)AddControl(new Guid("8eb50d2a-06b8-4d44-ae95-3fd13f42c53b"));
            SurgeonSuggestions = (ITTTextBox)AddControl(new Guid("d72d7566-782f-4f2e-89fa-59f553ae3827"));
            labelAnesthetistSuggestions = (ITTLabel)AddControl(new Guid("2a9f9028-acb6-41b7-bd05-448ede63c121"));
            AnesthetistSuggestions = (ITTTextBox)AddControl(new Guid("c4a16134-a20f-4093-bb67-460d98fe0a71"));
            SampleRegionOnSampleLabel = (ITTCheckBox)AddControl(new Guid("8f8b7778-c423-4ad8-a3c3-dd8ad194bb6c"));
            PatientNameOnSampleLabel = (ITTCheckBox)AddControl(new Guid("dc0d70b0-e0e7-42fe-8b6f-2e9d753eec3d"));
            ToolSpongeNeedleCountsDone = (ITTCheckBox)AddControl(new Guid("9c5df6cc-8fa1-4fa2-b5e2-3fbc5eed8851"));
            ConfirmedSurgeryAreaVerbally = (ITTCheckBox)AddControl(new Guid("da62b1f8-34a1-4175-ab0f-6a0ef8dd9421"));
            ConfirmedSurgeryVerbally = (ITTCheckBox)AddControl(new Guid("c37ac282-7300-4edf-bc70-0e9df37cf405"));
            ConfirmedPatientVerbally = (ITTCheckBox)AddControl(new Guid("cdade1b5-a8bb-4a93-835e-f28998f9ccb2"));
            base.InitializeControls();
        }

        public SafeSurgeryCheckListForm() : base("SAFESURGERYCHECKLIST", "SafeSurgeryCheckListForm")
        {
        }

        protected SafeSurgeryCheckListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}