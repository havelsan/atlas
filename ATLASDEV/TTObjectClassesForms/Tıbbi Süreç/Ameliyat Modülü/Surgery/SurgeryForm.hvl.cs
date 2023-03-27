
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
    /// Ameliyat
    /// </summary>
    public partial class SurgeryForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Surgery _Surgery
        {
            get { return (TTObjectClasses.Surgery)_ttObject; }
        }

        protected ITTLabel labelSurgeryRobson;
        protected ITTObjectListBox SurgeryRobson;
        protected ITTLabel labelSurgeryResult;
        protected ITTObjectListBox SurgeryResult;
        protected ITTLabel labelSurgeryStatus;
        protected ITTEnumComboBox SurgeryStatus;
        protected ITTLabel labelSurgeryShift;
        protected ITTEnumComboBox SurgeryShift;
        protected ITTLabel labelReasonOfReject;
        protected ITTRichTextBoxControl ReasonOfReject;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelComplicationDescription;
        protected ITTTextBox ComplicationDescription;
        protected ITTTextBox ProtocolNo;
        protected ITTCheckBox IsComplicationSurgery;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker PlannedSurgeryDate;
        protected ITTLabel labelSurgeryEndTime;
        protected ITTDateTimePicker SurgeryEndTime;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelSurgeryStartTime;
        protected ITTDateTimePicker SurgeryStartTime;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRoom;
        protected ITTLabel labelProtocolNo;
        protected ITTTabControl TabOperative;
        protected ITTTabPage SurgeryInfo;
        protected ITTRichTextBoxControl SurgeryReport;
        protected ITTDateTimePicker SurgeryReportDate;
        protected ITTLabel ttlabel3;
        protected ITTTabControl Ameliyat;
        protected ITTTabPage MainSurgeryProcedures;
        protected ITTTabPage SurgeryProcedures;
        protected ITTTabPage SurgeryTeam;
        protected ITTGrid GridSurgeryPersonnels;
        protected ITTListBoxColumn SurgeryPersonnel;
        protected ITTEnumComboBoxColumn CARole;
        protected ITTTabPage SurgeryExpend;
        protected ITTGrid GridSurgeryExpends;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTListBoxColumn CAStore;
        protected ITTListBoxColumn CAMaterial;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn DonorID;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTabPage DirectPurchase;
        protected ITTGrid DirectPurchaseGrids;
        protected ITTListBoxColumn MaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn AmountDirectPurchaseGrid;
        protected ITTTabPage PreOperativeInfo;
        protected ITTRichTextBoxControl DescriptionToPreOp;
        protected ITTRichTextBoxControl PreOpDescriptions;
        protected ITTTabPage AnesthesiaInfo;
        protected ITTLabel labelLaparoscopyAnesthesiaAndReanimation;
        protected ITTEnumComboBox LaparoscopyAnesthesiaAndReanimation;
        protected ITTCheckBox HasComplicationAnesthesiaAndReanimation;
        protected ITTLabel labelComplicationDescriptionAnesthesiaAndReanimation;
        protected ITTTextBox ComplicationDescriptionAnesthesiaAndReanimation;
        protected ITTLabel labelScarTypeAnesthesiaAndReanimation;
        protected ITTEnumComboBox ScarTypeAnesthesiaAndReanimation;
        protected ITTLabel labelASAScoreAnesthesiaAndReanimation;
        protected ITTEnumComboBox ASAScoreAnesthesiaAndReanimation;
        protected ITTLabel labelAnesthesiaReportDateAnesthesiaAndReanimation;
        protected ITTDateTimePicker AnesthesiaReportDateAnesthesiaAndReanimation;
        protected ITTLabel labelASATypeAnesthesiaAndReanimation;
        protected ITTEnumComboBox ASATypeAnesthesiaAndReanimation;
        protected ITTLabel labelAnesthesiaEndDateTime;
        protected ITTRichTextBoxControl AnestesiaReport;
        protected ITTDateTimePicker AnesthesiaEndDateTime;
        protected ITTLabel labelAnesthesiaStartDateTime;
        protected ITTDateTimePicker AnesthesiaStartDateTime;
        protected ITTLabel ttlabel5;
        protected ITTGrid GridAnesthesiaProcedures;
        protected ITTDateTimePickerColumn ACActionDate;
        protected ITTListBoxColumn ACProcedureObject;
        protected ITTListBoxColumn ACProcedureDoctor;
        protected ITTTextBoxColumn ACNote;
        protected ITTEnumComboBox AnesteziTeknigi;
        protected ITTGrid GridAnesthesiaPersonnels;
        protected ITTListBoxColumn AnesthesiaPersonnel;
        protected ITTTextBoxColumn Role;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox AnestesiaProcedureDoctor2;
        protected ITTLabel labelProcedureDoctor2;
        protected ITTObjectListBox AnestesiaProcedureDoctor;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelPlannedSurgeryDescription;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelSurgeryDesk;
        override protected void InitializeControls()
        {
            labelSurgeryRobson = (ITTLabel)AddControl(new Guid("9588046a-2180-4319-9043-cbebc0ace785"));
            SurgeryRobson = (ITTObjectListBox)AddControl(new Guid("3bc1c7c3-7fd7-4528-b53c-49dd015ff08c"));
            labelSurgeryResult = (ITTLabel)AddControl(new Guid("f1a58a98-b8dd-43ea-afe8-319a7803a644"));
            SurgeryResult = (ITTObjectListBox)AddControl(new Guid("f42851c9-ef4f-4402-a787-287946ecbbbf"));
            labelSurgeryStatus = (ITTLabel)AddControl(new Guid("0db3045a-7253-40fa-b799-f7347edbe31e"));
            SurgeryStatus = (ITTEnumComboBox)AddControl(new Guid("c27320a3-b538-4fc8-a9fa-7e4dff579fe1"));
            labelSurgeryShift = (ITTLabel)AddControl(new Guid("c33b7ba9-c699-4dc6-b9ff-3b9c00572682"));
            SurgeryShift = (ITTEnumComboBox)AddControl(new Guid("7636e151-e42b-4223-947d-1b60c8c6ef82"));
            labelReasonOfReject = (ITTLabel)AddControl(new Guid("41eadfdc-6690-4be5-8f90-b5df34344de0"));
            ReasonOfReject = (ITTRichTextBoxControl)AddControl(new Guid("4e1f58e6-6372-4af7-a3fa-d32df65d8942"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("7e82dbd0-be24-4c8a-a250-eed4081bf0ec"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("a66889b9-e889-49b9-855e-f7ae8eb67825"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("d6ef3d1b-94b1-4619-979a-3af2b478eb45"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("ea83363c-d622-472c-809b-805b8912208c"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("58e427d9-92bf-4a7b-b6e4-8c3e2dc12fbb"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("4dff25eb-2c92-4245-a608-1716e0861bbf"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("29d7782a-26bb-497c-9b6b-bd838f511003"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("cd045e16-f317-45ee-868f-8ae2b5e60fd9"));
            labelComplicationDescription = (ITTLabel)AddControl(new Guid("652f6350-b8df-44f0-9044-e79bf6751b6e"));
            ComplicationDescription = (ITTTextBox)AddControl(new Guid("2a45b3e7-48a0-499d-bfe6-393bb436cefd"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("1f55191c-e826-49ee-9f8e-2adf97790f05"));
            IsComplicationSurgery = (ITTCheckBox)AddControl(new Guid("2ef0105d-665d-4e91-9ed9-c858aafba223"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("32de8aaf-c2d0-4c08-9f55-4eacaa1f5838"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("77a8ece5-e8c8-4bf9-8906-eba76d5f291d"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("5cca2505-a4dc-401b-9402-bc190ecdf79a"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("0b261c8e-20d0-450a-8b02-dcbe4ddd1215"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("0d1356d0-1c0d-4f8b-9afa-1084fab6b755"));
            PlannedSurgeryDate = (ITTDateTimePicker)AddControl(new Guid("9ab4c759-e7ae-4130-8609-5caf064ccc4e"));
            labelSurgeryEndTime = (ITTLabel)AddControl(new Guid("7e81a5a4-7721-4e6d-a63f-25456fc0d1fb"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("b9d3b6bb-338c-4a21-a440-c1f605a77725"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("cc2a81e6-8e68-43fe-a9e7-21d3556ae625"));
            Emergency = (ITTCheckBox)AddControl(new Guid("91eeb166-a907-4ca7-935f-3a960e0b68d9"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("f46b7eab-e89f-4901-9dc4-3c417a706173"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("5e748444-9fda-4a8e-9ca7-869354f5f67f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fab2c416-895e-4adb-85d6-b3e81b7695fc"));
            labelRoom = (ITTLabel)AddControl(new Guid("675c0cc6-b0fb-4bc8-a2b5-e230e3f11edf"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("3477d0a7-44fa-48a1-bf3d-e2502f485054"));
            TabOperative = (ITTTabControl)AddControl(new Guid("850182b0-1611-458d-be55-eca98f8e9587"));
            SurgeryInfo = (ITTTabPage)AddControl(new Guid("dec19558-8e1f-4045-8632-31ed7b816fb5"));
            SurgeryReport = (ITTRichTextBoxControl)AddControl(new Guid("825e9dc7-d50b-4cf4-ad7b-448cb03b23d9"));
            SurgeryReportDate = (ITTDateTimePicker)AddControl(new Guid("5ffa4e40-3a9d-4b40-8209-022969184526"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a5d67200-6841-4b3a-b093-0242664c591b"));
            Ameliyat = (ITTTabControl)AddControl(new Guid("de34f945-4c1e-4ccc-9367-7bb4bd8d0d07"));
            MainSurgeryProcedures = (ITTTabPage)AddControl(new Guid("74626241-bcc6-47a0-9b4e-20ceee92a681"));
            SurgeryProcedures = (ITTTabPage)AddControl(new Guid("2d65dca3-cd62-457d-8cb3-6a1430b9d1c4"));
            SurgeryTeam = (ITTTabPage)AddControl(new Guid("7d7e5038-568d-4e20-a8f4-a853c549a74a"));
            GridSurgeryPersonnels = (ITTGrid)AddControl(new Guid("c5f23489-b701-4ca6-b534-185ae9d61347"));
            SurgeryPersonnel = (ITTListBoxColumn)AddControl(new Guid("50a7d33b-9638-488d-8948-0b88367ca658"));
            CARole = (ITTEnumComboBoxColumn)AddControl(new Guid("9e2e7c12-1abd-4b05-8044-cc46ca0a711e"));
            SurgeryExpend = (ITTTabPage)AddControl(new Guid("65cb94cc-7a2e-4f79-8966-9fca023b44ee"));
            GridSurgeryExpends = (ITTGrid)AddControl(new Guid("8c266a9b-be9e-4a68-8177-70d2e213f5ba"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("dd8bb630-3722-4c67-8dbb-3f1c4583aae2"));
            CAStore = (ITTListBoxColumn)AddControl(new Guid("2c910ea4-73c8-4a41-a5cc-9eb8b883d501"));
            CAMaterial = (ITTListBoxColumn)AddControl(new Guid("0d1028c3-ecba-4ddb-832d-0f64e924e822"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("8299b329-d837-4534-9e3c-78e66ea5b4e2"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("7534a848-aa7e-4ecb-a14c-2bdd5fbe5a75"));
            DonorID = (ITTTextBoxColumn)AddControl(new Guid("1529436e-9285-4b39-8ab7-89deb08acfaf"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("e9ca2210-f906-4408-b68d-c34e32fc8e4b"));
            DirectPurchase = (ITTTabPage)AddControl(new Guid("801ad841-afcb-468b-81b4-1f7840e519fb"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("32e04934-5429-41ef-b3a0-32a37a6a1d3c"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("8262d007-15ab-4461-b48e-0f04b929d57e"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("c2bfa27a-5fbe-40bf-bdb5-7dd784e70f6e"));
            PreOperativeInfo = (ITTTabPage)AddControl(new Guid("5edd8f6d-4fee-4703-ae4f-2de841d67a7c"));
            DescriptionToPreOp = (ITTRichTextBoxControl)AddControl(new Guid("7791b641-e4ad-4055-adf1-630e98e1ae20"));
            PreOpDescriptions = (ITTRichTextBoxControl)AddControl(new Guid("ffde675e-3fff-46d8-aa84-0b2d4a449319"));
            AnesthesiaInfo = (ITTTabPage)AddControl(new Guid("a9641ad1-5fb4-4cf5-a082-3c5f8c366ad1"));
            labelLaparoscopyAnesthesiaAndReanimation = (ITTLabel)AddControl(new Guid("5dd84eb8-62ac-4615-9b4e-3dd088ab5847"));
            LaparoscopyAnesthesiaAndReanimation = (ITTEnumComboBox)AddControl(new Guid("d15d38e5-f9d9-458a-9e62-488d7676e75b"));
            HasComplicationAnesthesiaAndReanimation = (ITTCheckBox)AddControl(new Guid("aa83aa1b-a0b0-45fd-a912-e749461f4c4f"));
            labelComplicationDescriptionAnesthesiaAndReanimation = (ITTLabel)AddControl(new Guid("05a083f6-d567-4128-a808-396f9cdbaf23"));
            ComplicationDescriptionAnesthesiaAndReanimation = (ITTTextBox)AddControl(new Guid("89f4d712-b4ca-4358-b8da-0fb5cd3f29c6"));
            labelScarTypeAnesthesiaAndReanimation = (ITTLabel)AddControl(new Guid("db1a7993-0405-4ecd-8a48-db6ae5ffc585"));
            ScarTypeAnesthesiaAndReanimation = (ITTEnumComboBox)AddControl(new Guid("dd00bc2b-ff7a-4fa9-81cc-21deec1450ad"));
            labelASAScoreAnesthesiaAndReanimation = (ITTLabel)AddControl(new Guid("6a864a30-7cf8-4846-88f6-90b4c5833dbf"));
            ASAScoreAnesthesiaAndReanimation = (ITTEnumComboBox)AddControl(new Guid("27fe7b97-1a9b-42ca-b83f-8e94e308e748"));
            labelAnesthesiaReportDateAnesthesiaAndReanimation = (ITTLabel)AddControl(new Guid("9d9c5821-ce96-4e7f-9624-782ec7251d26"));
            AnesthesiaReportDateAnesthesiaAndReanimation = (ITTDateTimePicker)AddControl(new Guid("0e5a39ec-6435-427a-8d09-c2314ea16dcc"));
            labelASATypeAnesthesiaAndReanimation = (ITTLabel)AddControl(new Guid("97c90786-f6e2-467c-bc46-f95e90af1148"));
            ASATypeAnesthesiaAndReanimation = (ITTEnumComboBox)AddControl(new Guid("d3ee5eda-79b5-4167-90b2-e57a64dbb7f4"));
            labelAnesthesiaEndDateTime = (ITTLabel)AddControl(new Guid("b13ebd7a-7074-47c2-98d8-7c546a31930f"));
            AnestesiaReport = (ITTRichTextBoxControl)AddControl(new Guid("048f14e9-db11-4037-9904-70071d318912"));
            AnesthesiaEndDateTime = (ITTDateTimePicker)AddControl(new Guid("5b421aaa-ed79-4316-b2ad-f336632159d1"));
            labelAnesthesiaStartDateTime = (ITTLabel)AddControl(new Guid("dc14acb2-3e3e-49e1-8df8-873648d0b954"));
            AnesthesiaStartDateTime = (ITTDateTimePicker)AddControl(new Guid("78ef0e3a-d997-411f-859c-fedcdf6186a7"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a3934b72-1550-41dd-b63b-5af5b2715e09"));
            GridAnesthesiaProcedures = (ITTGrid)AddControl(new Guid("2161a4ce-c6b4-4e02-a349-b86be4cbebc2"));
            ACActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("acc2c6f1-2c28-413f-aeb9-b0df4fcdce67"));
            ACProcedureObject = (ITTListBoxColumn)AddControl(new Guid("8779950a-0880-406a-82ba-5c9f4b881df8"));
            ACProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("a868f117-f815-4aea-b129-afa12fce535f"));
            ACNote = (ITTTextBoxColumn)AddControl(new Guid("76a089cf-1337-48b9-8f7a-f165eae183cb"));
            AnesteziTeknigi = (ITTEnumComboBox)AddControl(new Guid("2c50cdd7-c45a-4754-87e7-4be593d68b29"));
            GridAnesthesiaPersonnels = (ITTGrid)AddControl(new Guid("cc517b21-5075-417d-8067-af4fa57ec360"));
            AnesthesiaPersonnel = (ITTListBoxColumn)AddControl(new Guid("69bae4ed-d069-4c33-83a2-f8c5d5400422"));
            Role = (ITTTextBoxColumn)AddControl(new Guid("76c3ffb5-0bd9-449a-92be-f756f14c138f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ead34446-da90-4824-9ddf-54d393571d79"));
            AnestesiaProcedureDoctor2 = (ITTObjectListBox)AddControl(new Guid("4207ff70-63fc-441c-945b-c00d6acbd212"));
            labelProcedureDoctor2 = (ITTLabel)AddControl(new Guid("0823b399-1d9b-4118-831e-e4a1973e935d"));
            AnestesiaProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("11b6d189-0ea3-4a22-b623-fd44930b48fd"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("1c8ea649-5f11-48e8-b5a9-43503210cc5e"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("e8ee4bb0-4640-4121-b746-f54b576f1c1c"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("87768109-d891-4cf3-b8ea-6dca71ebac52"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("e17da889-996b-412a-976a-3eea2fcb14e7"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("7d998a3b-40b3-4100-934f-4868c43576f8"));
            base.InitializeControls();
        }

        public SurgeryForm() : base("SURGERY", "SurgeryForm")
        {
        }

        protected SurgeryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}