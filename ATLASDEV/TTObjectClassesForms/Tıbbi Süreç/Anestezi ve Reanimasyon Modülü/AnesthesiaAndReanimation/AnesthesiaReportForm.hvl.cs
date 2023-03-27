
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
    /// Anestezi ve Reanimasyon
    /// </summary>
    public partial class AnesthesiaReportForm : EpisodeActionForm
    {
    /// <summary>
    /// Anestezi ve Reanimasyon İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.AnesthesiaAndReanimation _AnesthesiaAndReanimation
        {
            get { return (TTObjectClasses.AnesthesiaAndReanimation)_ttObject; }
        }

        protected ITTLabel labelLaparoscopy;
        protected ITTEnumComboBox Laparoscopy;
        protected ITTLabel labelScarType;
        protected ITTEnumComboBox ScarType;
        protected ITTLabel labelASAScore;
        protected ITTEnumComboBox ASAScore;
        protected ITTLabel labelComplicationDescription;
        protected ITTTextBox ComplicationDescription;
        protected ITTCheckBox HasComplication;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox AnesteziTeknigi;
        protected ITTRichTextBoxControl AnesthesiaReport;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker PlannedAnesthsiaDate;
        protected ITTLabel LabelRequest;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelAnesthesiaStartDateTime;
        protected ITTDateTimePicker AnesthesiaStartDateTime;
        protected ITTLabel labelAnesthesiaEndDateTime;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage SurgeryInfo;
        protected ITTLabel ttlabeldrAnesteziTescilNo;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox MasterResource;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelRoom;
        protected ITTLabel ttlabel5;
        protected ITTGrid GridSurgeryProcedures;
        protected ITTDateTimePickerColumn CAActionDate;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTListBoxColumn AyniFarkliKesi;
        protected ITTEnumComboBoxColumn Position;
        protected ITTListBoxColumn EntryDepartment;
        protected ITTEnumComboBoxColumn Euroscore;
        protected ITTObjectListBox TTListBoxDrAnesteziTescilNo;
        protected ITTLabel labelSurgeryDesk;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTTabPage AnesthesiaTeam;
        protected ITTGrid GridAnesthesiaPersonnels;
        protected ITTListBoxColumn AnesthesiaPersonnel;
        protected ITTTextBoxColumn Role;
        protected ITTTabPage AnesthesiaProcedure;
        protected ITTGrid GridAnesthesiaProcedures;
        protected ITTDateTimePickerColumn ACActionDate;
        protected ITTListBoxColumn ACProcedureObject;
        protected ITTListBoxColumn ACProcedureDoctor;
        protected ITTTextBoxColumn ACNote;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridAnesthesiaExpends;
        protected ITTDateTimePickerColumn SMActionDate;
        protected ITTListBoxColumn SMStore;
        protected ITTListBoxColumn SMMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn SMAmount;
        protected ITTTextBoxColumn UBBCode;
        protected ITTDateTimePickerColumn malzemeSatinAlisTarihi;
        protected ITTTextBoxColumn kodsuzMalzemeFiyati;
        protected ITTTextBoxColumn kdv;
        protected ITTListBoxColumn malzemeTuru;
        protected ITTTextBoxColumn malzemeBrans;
        protected ITTListBoxColumn malzemeOzelDurum;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ReasonOfCancel;
        protected ITTTextBox EpisodeId;
        protected ITTDateTimePicker AnesthesiaEndDateTime;
        protected ITTLabel lableAnsteziReportNo;
        protected ITTDateTimePicker AnesthesiaReportDate;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelASAType;
        protected ITTEnumComboBox ASAType;
        protected ITTCheckBox IsTreatmentMaterialEmpty;
        protected ITTLabel lebalReasonOfCancel;
        override protected void InitializeControls()
        {
            labelLaparoscopy = (ITTLabel)AddControl(new Guid("1b87de6c-8b1f-488a-8940-17e0c5c1704a"));
            Laparoscopy = (ITTEnumComboBox)AddControl(new Guid("4bb8981d-0b40-4b10-a153-d2971b211e04"));
            labelScarType = (ITTLabel)AddControl(new Guid("4bbd2989-b25b-47fe-b376-316d90d438d3"));
            ScarType = (ITTEnumComboBox)AddControl(new Guid("5b892584-eb54-4f7c-bd1b-79f1c9850476"));
            labelASAScore = (ITTLabel)AddControl(new Guid("2fcdb7c9-a11a-433b-b8d1-3705ca5e2bfe"));
            ASAScore = (ITTEnumComboBox)AddControl(new Guid("bcbecc58-9ac8-4678-b311-91448342099b"));
            labelComplicationDescription = (ITTLabel)AddControl(new Guid("a34a9214-663e-409d-928c-7ccd96cca242"));
            ComplicationDescription = (ITTTextBox)AddControl(new Guid("60e68296-95a2-48b4-b720-d2b4f494c398"));
            HasComplication = (ITTCheckBox)AddControl(new Guid("c36a55ff-2971-47de-8eb5-204f061f4567"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f2417745-9d1f-419d-bb94-dc1875dae373"));
            AnesteziTeknigi = (ITTEnumComboBox)AddControl(new Guid("3065892d-6cad-4081-b022-12a7be95b28f"));
            AnesthesiaReport = (ITTRichTextBoxControl)AddControl(new Guid("b9200d28-d7e2-4b26-af32-c57cc6834e3c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("dacd943b-0cac-4ea7-8802-f92c76b2910f"));
            PlannedAnesthsiaDate = (ITTDateTimePicker)AddControl(new Guid("3c8d8233-a105-44d2-a64a-10da0f4e884b"));
            LabelRequest = (ITTLabel)AddControl(new Guid("11c8c18e-748b-4920-836e-e85ae92515cb"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("ac0f0ec0-5c5f-40bd-9140-5fded5da1cae"));
            labelAnesthesiaStartDateTime = (ITTLabel)AddControl(new Guid("bc2b2371-aa3c-43ff-af32-a48afd265829"));
            AnesthesiaStartDateTime = (ITTDateTimePicker)AddControl(new Guid("817b4dce-0b14-411e-8efd-549c0e6911b6"));
            labelAnesthesiaEndDateTime = (ITTLabel)AddControl(new Guid("819ba277-a142-4411-a0d9-5b732460f19f"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("aaaa4e20-6508-4a86-ae7e-6b57ca588782"));
            SurgeryInfo = (ITTTabPage)AddControl(new Guid("6993a1c0-37d8-4f95-8b89-9180d1631d48"));
            ttlabeldrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("a48364c7-2a40-40bc-9243-35b7fcd57142"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("9c678a56-8dc0-40c7-b30c-72a1ca9d919f"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("7dd7b58e-93ce-488a-8af2-30b457ee4f0e"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("f90ab377-b44f-4ef8-a238-8c126f05c5f9"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("95841637-8d7b-4409-92c1-df6cfe960386"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("18f1d787-19a8-4aae-b55a-c79494c89772"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("d8147f9e-ce17-4073-9bf4-e0853298871d"));
            labelRoom = (ITTLabel)AddControl(new Guid("97105bd7-cc9c-4eb8-80b1-a21e743be79a"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("278307a6-bbdc-41b7-bc92-afc9ab2f53e8"));
            GridSurgeryProcedures = (ITTGrid)AddControl(new Guid("c736fdb0-55f5-470c-b9f1-0337722f2c31"));
            CAActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("305d3b20-b3d3-4af3-98a0-3faad4dc171b"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("dcd1bcd7-f9bf-4e5a-a768-3d80fcca1831"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("a76436b9-6704-4c88-9cee-96812ca0b34b"));
            Position = (ITTEnumComboBoxColumn)AddControl(new Guid("4784b93f-20c2-49df-974b-09a2d5f11d13"));
            EntryDepartment = (ITTListBoxColumn)AddControl(new Guid("f5a2ee59-1888-440f-8382-7f9f5ac1a9f5"));
            Euroscore = (ITTEnumComboBoxColumn)AddControl(new Guid("394436d7-a482-4a6b-b4e3-f22eb7e557a5"));
            TTListBoxDrAnesteziTescilNo = (ITTObjectListBox)AddControl(new Guid("285889eb-8b8a-462f-aaf2-5c01304b97b2"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("ec974d6a-5e7f-4ce7-8b6e-f2e2c00ea59b"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("280db678-1121-49cf-a737-1bef74a05611"));
            AnesthesiaTeam = (ITTTabPage)AddControl(new Guid("f0c202e5-a8fa-4530-a5e2-d1ffd727f659"));
            GridAnesthesiaPersonnels = (ITTGrid)AddControl(new Guid("904839bb-8043-4377-adef-80b7d3500369"));
            AnesthesiaPersonnel = (ITTListBoxColumn)AddControl(new Guid("8ec561c7-881e-4960-8bd7-92e13b9a0b12"));
            Role = (ITTTextBoxColumn)AddControl(new Guid("ec4846c1-d6b8-4308-8c24-d106fe43a5ff"));
            AnesthesiaProcedure = (ITTTabPage)AddControl(new Guid("541d4b4a-8800-4828-a126-97d783e67e0d"));
            GridAnesthesiaProcedures = (ITTGrid)AddControl(new Guid("f4abdde7-3e0a-4f15-b30d-cb968dd8b263"));
            ACActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("f40d4527-e1b1-4d66-bb52-f6f9fd4a595b"));
            ACProcedureObject = (ITTListBoxColumn)AddControl(new Guid("97810bdc-43b6-41c3-89d2-134e2d8ef730"));
            ACProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("28a8395b-2a7c-40ea-a638-762d166501b2"));
            ACNote = (ITTTextBoxColumn)AddControl(new Guid("b586fe5d-4c4e-4e66-af3f-88b98ebb7237"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("90515a13-75bf-4717-8920-573fab157057"));
            GridAnesthesiaExpends = (ITTGrid)AddControl(new Guid("e9ec678c-4894-40f8-a7dd-d4f9f002a8bb"));
            SMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("9864d1fe-3e1e-4d31-9ed3-079eb7b71940"));
            SMStore = (ITTListBoxColumn)AddControl(new Guid("712b5835-1cb4-4f3d-b9fa-adf959150b4b"));
            SMMaterial = (ITTListBoxColumn)AddControl(new Guid("bdea11d9-56aa-45c7-9ac8-e04123b8e847"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("cf6568f6-7fa4-4795-ad94-b3b87b639dd4"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("0dd15d3b-5a28-4a9b-bfb3-ef78fa096463"));
            SMAmount = (ITTTextBoxColumn)AddControl(new Guid("9ad2b40e-1649-404e-884d-918d5fa03491"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("414ad4b7-0457-4d26-842b-e695d803bf10"));
            malzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("6a5e2c43-8614-432c-abd8-531af4b33a8e"));
            kodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("a1639aec-2c00-4fdb-ae77-a544a7ecb627"));
            kdv = (ITTTextBoxColumn)AddControl(new Guid("7216279e-bbdf-41f5-9d58-c7431ae59a8f"));
            malzemeTuru = (ITTListBoxColumn)AddControl(new Guid("861cb857-c51d-4e7a-8942-d1fa7e05e636"));
            malzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("b80d7823-d2ce-441f-aa07-4185af92e36c"));
            malzemeOzelDurum = (ITTListBoxColumn)AddControl(new Guid("7cfa9587-75c0-4db1-9311-de166550db03"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("c5c26a85-bf92-4a8d-8dea-85219acab75a"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("bc7cfe8e-f80a-42a8-a132-115568598ee1"));
            EpisodeId = (ITTTextBox)AddControl(new Guid("918cf1dc-e3db-49d6-bf04-74e79877d995"));
            AnesthesiaEndDateTime = (ITTDateTimePicker)AddControl(new Guid("7134c26d-2a90-402c-95f5-b35de9939276"));
            lableAnsteziReportNo = (ITTLabel)AddControl(new Guid("5f08e134-efb8-4c45-8d71-d3da78788b56"));
            AnesthesiaReportDate = (ITTDateTimePicker)AddControl(new Guid("898a7408-c305-418a-a850-4ab3fcdb3a3f"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("08a0a89b-1991-45c9-a5ee-98ad488878ca"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("91039f6d-040f-411d-9ccf-69da5eebe2e1"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("85aac7dd-9d58-4856-8391-e78b6d9ef097"));
            labelASAType = (ITTLabel)AddControl(new Guid("71e50e60-bc4a-4d8e-a10b-642b025177f7"));
            ASAType = (ITTEnumComboBox)AddControl(new Guid("ce76fa9a-2c94-4358-ab96-066b045a94b8"));
            IsTreatmentMaterialEmpty = (ITTCheckBox)AddControl(new Guid("fcba674f-10fd-4fc4-91c1-020c184afd71"));
            lebalReasonOfCancel = (ITTLabel)AddControl(new Guid("a834fc19-7037-4a9c-a1e6-e19bb0890f7d"));
            base.InitializeControls();
        }

        public AnesthesiaReportForm() : base("ANESTHESIAANDREANIMATION", "AnesthesiaReportForm")
        {
        }

        protected AnesthesiaReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}