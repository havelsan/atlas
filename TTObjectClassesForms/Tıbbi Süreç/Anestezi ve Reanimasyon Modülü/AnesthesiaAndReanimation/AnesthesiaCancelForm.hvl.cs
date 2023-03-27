
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
    /// SİL
    /// </summary>
    public partial class AnesthesiaCancelForm : EpisodeActionForm
    {
    /// <summary>
    /// Anestezi ve Reanimasyon İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.AnesthesiaAndReanimation _AnesthesiaAndReanimation
        {
            get { return (TTObjectClasses.AnesthesiaAndReanimation)_ttObject; }
        }

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
        protected ITTTabPage AnesthesiaProcedure;
        protected ITTGrid GridAnesthesiaProcedures;
        protected ITTDateTimePickerColumn ACActionDate;
        protected ITTListBoxColumn ACProcedureObject;
        protected ITTListBoxColumn ACProcedureDoctor;
        protected ITTTextBoxColumn ACNote;
        protected ITTTabPage AnesthesiaTeam;
        protected ITTGrid GridAnesthesiaPersonnels;
        protected ITTListBoxColumn AnesthesiaPersonnel;
        protected ITTTextBoxColumn Role;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridAnesthesiaExpends;
        protected ITTDateTimePickerColumn SMActionDate;
        protected ITTListBoxColumn SMMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn SMAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTabPage SurgeryInfo;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox MasterResource;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelRoom;
        protected ITTLabel ttlabel5;
        protected ITTGrid GridMainSurgeryProcedures;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTRichTextBoxControlColumn DescriptionOfProcedureObject;
        protected ITTLabel labelPlannedSurgeryDescription;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTLabel labelSurgeryDesk;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker AnesthesiaEndDateTime;
        protected ITTLabel lableAnsteziReportNo;
        protected ITTDateTimePicker AnesthesiaReportDate;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("db559b29-a0ec-4868-86d7-e186c55f2802"));
            AnesteziTeknigi = (ITTEnumComboBox)AddControl(new Guid("74c3dd52-eda3-4785-b011-5bcf6852f3c3"));
            AnesthesiaReport = (ITTRichTextBoxControl)AddControl(new Guid("e650a664-82da-4894-99ab-930c7746b054"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("708e1fa8-e43b-4b03-b74b-64738caa3a68"));
            PlannedAnesthsiaDate = (ITTDateTimePicker)AddControl(new Guid("91c09099-e3f5-4fc3-b43a-11593c0768ae"));
            LabelRequest = (ITTLabel)AddControl(new Guid("042f9df1-66c2-4dcb-a246-42e096fdad5c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("72a899bc-5bc2-4a6a-9512-e52239f83484"));
            labelAnesthesiaStartDateTime = (ITTLabel)AddControl(new Guid("8ff27482-7dc7-48a3-8f63-aa47409e4f36"));
            AnesthesiaStartDateTime = (ITTDateTimePicker)AddControl(new Guid("5e2206c5-7993-4a18-99be-55e251b073aa"));
            labelAnesthesiaEndDateTime = (ITTLabel)AddControl(new Guid("3ff0fb02-1f92-415a-8d96-260f0adeefb0"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("4180c7da-6423-45df-9678-9d9c641a479d"));
            AnesthesiaProcedure = (ITTTabPage)AddControl(new Guid("01bcedde-3d22-4d17-8ed5-5fbe58512760"));
            GridAnesthesiaProcedures = (ITTGrid)AddControl(new Guid("dbc0d100-8b6c-44c9-99cf-551472c684d4"));
            ACActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("7f612a18-5e5e-486f-8b41-48684131ff4a"));
            ACProcedureObject = (ITTListBoxColumn)AddControl(new Guid("f65860c1-f63c-4234-adf7-7fc5c0231061"));
            ACProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("b42ee444-5d50-4e1f-88a4-bca561ae2e64"));
            ACNote = (ITTTextBoxColumn)AddControl(new Guid("7276406b-1373-440f-af67-2cd780221f28"));
            AnesthesiaTeam = (ITTTabPage)AddControl(new Guid("0e4da380-c611-4ace-b209-1af90f4dc31a"));
            GridAnesthesiaPersonnels = (ITTGrid)AddControl(new Guid("71fc0b97-849b-4e33-b166-6662014fd796"));
            AnesthesiaPersonnel = (ITTListBoxColumn)AddControl(new Guid("cb4ada94-e426-4036-91a7-cf8b9b183e0e"));
            Role = (ITTTextBoxColumn)AddControl(new Guid("1c230cfa-260b-4792-8591-6724928c9af1"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("0ee35952-5de2-40f6-9f53-709bdf50abfa"));
            GridAnesthesiaExpends = (ITTGrid)AddControl(new Guid("153cbfa5-c5e0-4907-9c12-5aa9be3dae7c"));
            SMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("5e6e02a7-340f-4728-ba20-95b73088770b"));
            SMMaterial = (ITTListBoxColumn)AddControl(new Guid("ca25192e-3ab6-429a-b672-70da3edeb4c8"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("77a19e3b-57e4-419b-bf5f-dd8b6caae680"));
            SMAmount = (ITTTextBoxColumn)AddControl(new Guid("601578da-28c3-41e2-bc8c-6fadd0138609"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("ffef999e-87df-4b4a-a7ec-995dedd60625"));
            SurgeryInfo = (ITTTabPage)AddControl(new Guid("4243c374-7f7f-4426-a425-b3e280b87c1a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("6d078fc9-a65b-4ea6-9bfa-910cc305171a"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("bfa74b43-20eb-4618-894f-7860b2079772"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("339ec356-b650-4fc6-9d3c-5e0479b118fd"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("d12ec842-6548-411a-b4d7-4136e105e47b"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("5e1f0f8b-9e87-4f81-aaeb-19e4a7524a2d"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("43cbb8a8-6af2-4d01-b1e6-1227a5e1f4dc"));
            labelRoom = (ITTLabel)AddControl(new Guid("03f1e315-d17f-4d4a-b125-2632ad2de113"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("e5e06425-d339-43ad-9baa-a02b5da511a7"));
            GridMainSurgeryProcedures = (ITTGrid)AddControl(new Guid("cd616b04-bd45-492e-a58e-bb6d67539dc8"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("6fb7a55d-c265-46dd-9bd5-b622f4bffb03"));
            DescriptionOfProcedureObject = (ITTRichTextBoxControlColumn)AddControl(new Guid("bc209f72-1200-4159-b713-ae9304a6fe2c"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("3322522f-befb-4453-a03f-79af32319a50"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("c6ecfb21-6c34-4a58-81c4-d446627f1a94"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("76b1de9d-8f99-4efa-a8af-da0addedd995"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("20416dde-3880-4308-8cce-bd950bf139d6"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("66b32edf-67a8-4c9c-87e9-7f6bd3b20afc"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("4d864b69-6360-4904-8688-f8ab4da38a33"));
            AnesthesiaEndDateTime = (ITTDateTimePicker)AddControl(new Guid("3de09eda-20f7-4e72-affa-34ee8ac43743"));
            lableAnsteziReportNo = (ITTLabel)AddControl(new Guid("df0f4697-3870-4e6a-a5d3-254fe99752ee"));
            AnesthesiaReportDate = (ITTDateTimePicker)AddControl(new Guid("9e1280a3-2bde-42d8-b4b4-65bcdb11f35f"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("c993978b-9ccd-48c3-84a4-2865d3374677"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3132ed99-bfde-4068-8e86-9179a3619006"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("ccd70ffa-99e7-4fc5-bcec-5fb02fc9f942"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("a7789ea2-ef82-470b-962e-c2d94c18acef"));
            base.InitializeControls();
        }

        public AnesthesiaCancelForm() : base("ANESTHESIAANDREANIMATION", "AnesthesiaCancelForm")
        {
        }

        protected AnesthesiaCancelForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}