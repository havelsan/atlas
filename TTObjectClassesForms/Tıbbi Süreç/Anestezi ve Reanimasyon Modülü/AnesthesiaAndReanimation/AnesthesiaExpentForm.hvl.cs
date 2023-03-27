
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
    public partial class AnesthesiaExpentForm : EpisodeActionForm
    {
    /// <summary>
    /// Anestezi ve Reanimasyon İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.AnesthesiaAndReanimation _AnesthesiaAndReanimation
        {
            get { return (TTObjectClasses.AnesthesiaAndReanimation)_ttObject; }
        }

        protected ITTLabel labelAnesthesiaTechnique;
        protected ITTEnumComboBox AnesthesiaTechnique;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker PlannedAnesthsiaDate;
        protected ITTLabel LabelRequest;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelAnesthesiaStartDateTime;
        protected ITTDateTimePicker AnesthesiaStartDateTime;
        protected ITTLabel labelAnesthesiaEndDateTime;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridAnesthesiaExpends;
        protected ITTDateTimePickerColumn SMActionDate;
        protected ITTListBoxColumn SMStore;
        protected ITTListBoxColumn SMMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn SMAmount;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTabPage AnesthesiaTeam;
        protected ITTGrid GridAnesthesiaPersonnels;
        protected ITTListBoxColumn AnesthesiaPersonnel;
        protected ITTTextBoxColumn Role;
        protected ITTTabPage SurgeryInfo;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelRoom;
        protected ITTDateTimePicker SurgeryStartTime;
        protected ITTLabel labelSurgeryStartTime;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTDateTimePicker SurgeryEndTime;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelPlannedSurgeryDescription;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTGrid GridMainSurgeryProcedures;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTRichTextBoxControlColumn DescriptionOfProcedureObject;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelSurgeryDesk;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox EpisodeId;
        protected ITTDateTimePicker AnesthesiaEndDateTime;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            labelAnesthesiaTechnique = (ITTLabel)AddControl(new Guid("37182870-d27a-47dd-b19f-fe8dc252e8f2"));
            AnesthesiaTechnique = (ITTEnumComboBox)AddControl(new Guid("b04e550a-45cf-4ac3-bb6d-2b38961c944e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("07aefbcd-57ab-4b6d-8d8b-d6715f173752"));
            PlannedAnesthsiaDate = (ITTDateTimePicker)AddControl(new Guid("469326ac-67c1-4503-ad73-12bb39bae756"));
            LabelRequest = (ITTLabel)AddControl(new Guid("3fae303f-0cf8-4ff6-9050-4232b7380f21"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("6a76ebe8-678e-40ef-91fc-5517e55720f6"));
            labelAnesthesiaStartDateTime = (ITTLabel)AddControl(new Guid("7fc945b3-8fea-4f71-acda-01efc43ad5ca"));
            AnesthesiaStartDateTime = (ITTDateTimePicker)AddControl(new Guid("25532670-d2bd-4a43-9999-cfefa1df1db5"));
            labelAnesthesiaEndDateTime = (ITTLabel)AddControl(new Guid("e671e0c2-540e-472b-9d6b-6c240a6dc207"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("d7985f31-8283-43cc-b952-6be17a9b312e"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("3a702d1b-1c5d-45e3-95db-5f6aabfcd230"));
            GridAnesthesiaExpends = (ITTGrid)AddControl(new Guid("572ef313-446c-489e-a5ff-f26c07c3b359"));
            SMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("57bb30ff-da04-46a5-ad5c-2db7e5a7bcfb"));
            SMStore = (ITTListBoxColumn)AddControl(new Guid("dece0cf0-71d9-46e3-bcfe-4c63caa8d6f0"));
            SMMaterial = (ITTListBoxColumn)AddControl(new Guid("13a2608a-3121-4409-a100-b81495d59421"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("fb204709-e9e4-4108-80e0-e377333c421c"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("f57a7b5c-6f53-4df5-9020-c31e4b42a451"));
            SMAmount = (ITTTextBoxColumn)AddControl(new Guid("6e627c23-240b-474e-94f5-c52b843b7acf"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("d7cdcf21-6d65-456a-87a2-febf01a5c2f2"));
            AnesthesiaTeam = (ITTTabPage)AddControl(new Guid("59772cba-5bf5-4335-b5ca-8eb649ee63ec"));
            GridAnesthesiaPersonnels = (ITTGrid)AddControl(new Guid("2c5585eb-a94e-4ff3-bc62-e916ab02f7f4"));
            AnesthesiaPersonnel = (ITTListBoxColumn)AddControl(new Guid("c903bef5-0361-4988-a132-34a919842463"));
            Role = (ITTTextBoxColumn)AddControl(new Guid("796ff310-dfe0-4eca-9649-9848a828ae14"));
            SurgeryInfo = (ITTTabPage)AddControl(new Guid("4de7c3bd-7ac0-4737-a465-4834ba3d66ad"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2742d4b9-b9e9-49b4-b39a-6f1ab2259f3b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("31aa1162-f097-467e-be84-5390a98e5eca"));
            labelRoom = (ITTLabel)AddControl(new Guid("2dadfebc-6af0-4af0-b590-187e249a8937"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("fbd7f72b-5968-4e8f-a60c-9a70ae92212f"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("ccf11d59-4b0f-449f-b9c6-1eb31da3f7eb"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("eca6f812-3f41-4186-b973-5483bb533cf2"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("d5f2494a-a30e-41bc-9df4-0f05cd14700a"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("b465fc25-53de-4e67-922c-87a78826e174"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("23d7b880-6536-467a-8dfe-64e32ddb7a18"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("5c7d5e8d-9463-431b-9981-9415ab890593"));
            GridMainSurgeryProcedures = (ITTGrid)AddControl(new Guid("9b0b4a27-4c35-4f9f-b98d-40a5c240a3a6"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("122705cb-e260-477c-9c7a-9c19ef86d37b"));
            DescriptionOfProcedureObject = (ITTRichTextBoxControlColumn)AddControl(new Guid("af7744b1-a3e3-48b3-8809-7e8754583f7f"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("da0aaf8a-68a1-40cc-9123-79f053e496d5"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("ec66df8d-94e6-4a43-b065-52e7fe34e3f8"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("d1375da7-a35e-4854-984e-8d137f38c9a9"));
            EpisodeId = (ITTTextBox)AddControl(new Guid("0e16de9b-29a4-4fc6-b691-b3377687ba3f"));
            AnesthesiaEndDateTime = (ITTDateTimePicker)AddControl(new Guid("df6bda57-b9d0-4efb-8e06-5b7559d5dd3b"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("14b20af7-edef-452e-b360-dae24b71d1e1"));
            base.InitializeControls();
        }

        public AnesthesiaExpentForm() : base("ANESTHESIAANDREANIMATION", "AnesthesiaExpentForm")
        {
        }

        protected AnesthesiaExpentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}