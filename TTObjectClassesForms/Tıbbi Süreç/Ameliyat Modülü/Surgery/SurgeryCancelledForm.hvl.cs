
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
    public partial class SurgeryCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Surgery _Surgery
        {
            get { return (TTObjectClasses.Surgery)_ttObject; }
        }

        protected ITTTabControl Ameliyat;
        protected ITTTabPage CancelledInfo;
        protected ITTTextBox tttextbox1;
        protected ITTTabPage ReturnToDoctorReasonTab;
        protected ITTTextBox ReturnToDoctorReason;
        protected ITTTabPage SurgeryProcedures;
        protected ITTGrid GridSurgeryProcedures;
        protected ITTDateTimePickerColumn CAActionDate;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTEnumComboBoxColumn IncisionType;
        protected ITTEnumComboBoxColumn Position;
        protected ITTRichTextBoxControlColumn Description;
        protected ITTListBoxColumn EntryDepartment;
        protected ITTListBoxColumn ProceduerDoctor1;
        protected ITTTabPage AllSurgeryReports;
        protected ITTRichTextBoxControl TTRichTextBoxUserControl;
        protected ITTGrid GridSurgeryReports;
        protected ITTListBoxColumn Department;
        protected ITTListBoxColumn SubSurgeryProcedureDoctor;
        protected ITTRichTextBoxControlColumn SubSurgeryReports;
        protected ITTTabPage AnesthesiaInfo;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTGrid GridAnesthesiaProcedures;
        protected ITTDateTimePickerColumn ACActionDate;
        protected ITTListBoxColumn ACProcedureObject;
        protected ITTListBoxColumn ACProcedureDoctor;
        protected ITTTextBoxColumn ACNote;
        protected ITTLabel labelAnesthesiaStartDateTime;
        protected ITTDateTimePicker AnesthesiaEndDateTime;
        protected ITTLabel labelAnesthesiaEndDateTime;
        protected ITTDateTimePicker AnesthesiaStartDateTime;
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox AnesteziTeknigi;
        protected ITTTabPage SurgeryTeam;
        protected ITTGrid GridSurgeryPersonnels;
        protected ITTListBoxColumn SurgeryPersonnel;
        protected ITTEnumComboBoxColumn CARole;
        protected ITTTabPage SurgeryDirectPurchaseGrids;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn DPADetailFirmPriceOfferSurgeryDirectPurchaseGrid;
        protected ITTTextBoxColumn txtBarcode;
        protected ITTTextBoxColumn txtMiktar;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker SurgeryEndTime;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelSurgeryStartTime;
        protected ITTDateTimePicker SurgeryStartTime;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRoom;
        protected ITTLabel labelProtocolNo;
        protected ITTObjectListBox MasterResource;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelSurgeryDesk;
        override protected void InitializeControls()
        {
            Ameliyat = (ITTTabControl)AddControl(new Guid("1109ce88-72b7-4984-a6a8-43a388a0890c"));
            CancelledInfo = (ITTTabPage)AddControl(new Guid("d68874b3-7d22-4f53-a30f-7351571a6205"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("d0da231d-2d93-4af5-ad12-c2ab7b5867e6"));
            ReturnToDoctorReasonTab = (ITTTabPage)AddControl(new Guid("adf8e3cf-7196-4f0f-b5a8-fb0d36da90ba"));
            ReturnToDoctorReason = (ITTTextBox)AddControl(new Guid("a769c722-be4b-4104-bab9-48f280c4e19e"));
            SurgeryProcedures = (ITTTabPage)AddControl(new Guid("0024fb48-93ff-4bb1-be76-f2fc5d032d2d"));
            GridSurgeryProcedures = (ITTGrid)AddControl(new Guid("6cf13fc7-5d41-4b38-8a04-52702f124541"));
            CAActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("a1dc6113-953e-4e0e-be2c-7ea5bb5dfbcd"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e45b008b-760a-4676-bb64-15455a70879b"));
            IncisionType = (ITTEnumComboBoxColumn)AddControl(new Guid("e23afa71-b2d2-411a-8143-eb37b6f3e1ae"));
            Position = (ITTEnumComboBoxColumn)AddControl(new Guid("caef35a1-08ed-4b38-aff6-1d3d44f2c264"));
            Description = (ITTRichTextBoxControlColumn)AddControl(new Guid("8ee2aaad-98e8-4c8e-858e-74257c4dc7bd"));
            EntryDepartment = (ITTListBoxColumn)AddControl(new Guid("10c06d77-7b8e-4366-aa7e-659691d4c71b"));
            ProceduerDoctor1 = (ITTListBoxColumn)AddControl(new Guid("acdb7518-aff8-4318-ba26-0e09777880dd"));
            AllSurgeryReports = (ITTTabPage)AddControl(new Guid("63276aa0-b1ae-40fa-b603-b4effbada581"));
            TTRichTextBoxUserControl = (ITTRichTextBoxControl)AddControl(new Guid("30c9dc93-0fd1-492e-ba07-2eae62cbd612"));
            GridSurgeryReports = (ITTGrid)AddControl(new Guid("c6892c96-754e-402f-9dc3-0bd1b475b1e6"));
            Department = (ITTListBoxColumn)AddControl(new Guid("d02c29d0-b543-40ea-a7de-125436777f17"));
            SubSurgeryProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("de669c69-1105-4264-ba2f-cdee09e2a9e9"));
            SubSurgeryReports = (ITTRichTextBoxControlColumn)AddControl(new Guid("e2be2c8f-f3c3-412f-a81a-f2a989296230"));
            AnesthesiaInfo = (ITTTabPage)AddControl(new Guid("a069d2fd-d641-4035-90ff-cefd87ac1e5e"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("5d6db4cf-77fd-4a1b-b1ca-5828bf97117d"));
            GridAnesthesiaProcedures = (ITTGrid)AddControl(new Guid("421bad5e-3e5a-4b0b-bd89-ea9179b45eb0"));
            ACActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("e503b2c4-0396-47bd-9680-1ee1165f7ad2"));
            ACProcedureObject = (ITTListBoxColumn)AddControl(new Guid("fc2dd042-b009-4fbc-8ebb-08378809c69d"));
            ACProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("f988f161-8683-4278-9f81-5dcac435289f"));
            ACNote = (ITTTextBoxColumn)AddControl(new Guid("b68c54bd-0b77-49f1-b5ce-39de00f22efa"));
            labelAnesthesiaStartDateTime = (ITTLabel)AddControl(new Guid("57b0bc2a-ca79-4b74-ad2f-e39743b3404b"));
            AnesthesiaEndDateTime = (ITTDateTimePicker)AddControl(new Guid("80ae5753-dd99-4139-b9bb-9fbb1ffdd631"));
            labelAnesthesiaEndDateTime = (ITTLabel)AddControl(new Guid("9e221890-ea20-4d61-a20b-9bff8bf01d63"));
            AnesthesiaStartDateTime = (ITTDateTimePicker)AddControl(new Guid("320421f4-19c6-4dc3-94d1-47f14d860747"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5c937d5e-1b52-4c55-aac8-e9c2f71104d8"));
            AnesteziTeknigi = (ITTEnumComboBox)AddControl(new Guid("a77f5851-4621-46c1-8464-49face2a35c3"));
            SurgeryTeam = (ITTTabPage)AddControl(new Guid("b2c5392d-d58d-42ba-8d5a-6c2399a0e52c"));
            GridSurgeryPersonnels = (ITTGrid)AddControl(new Guid("7a9533f8-b1f1-4985-b679-7fe2b59a2261"));
            SurgeryPersonnel = (ITTListBoxColumn)AddControl(new Guid("0cc067b3-92b1-4e87-b154-be4ff19d0e94"));
            CARole = (ITTEnumComboBoxColumn)AddControl(new Guid("a194428c-96d9-4187-bab5-7d051fff350f"));
            SurgeryDirectPurchaseGrids = (ITTTabPage)AddControl(new Guid("af79ac81-2caa-44af-9aab-14279cc6d6a8"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("83cd7a02-9074-4cd9-b28a-f71f527d40d1"));
            DPADetailFirmPriceOfferSurgeryDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("dcfac2ac-def7-41c0-8c12-201d011bbe1c"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("a692df44-26ba-41a4-a580-5b2f1f5f62b8"));
            txtMiktar = (ITTTextBoxColumn)AddControl(new Guid("e4127e6f-2db2-4317-bf22-3e51addcbf30"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("f09d1da8-470e-4e57-91de-a6897a3fe4e4"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("fbb971cb-d801-49f9-a972-f79a56362c26"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("da7d973e-2cba-4da4-b517-467b89ee13b8"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("88f048c7-5dbd-496e-9752-59fa06faec06"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("6cd06abd-485d-40c9-a610-5044732cb0ed"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("5e31b405-b392-4b88-ad42-924430f7918f"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("76f5d0db-409c-4e7b-8258-d6ad540c44f9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("00b82c71-3d98-49d0-b63e-e8bc755e4905"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("e13afa62-9f93-4ac4-9c97-3190a44b7533"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("02a0802f-ecc2-4e31-ae38-dd9e5fd331b0"));
            Emergency = (ITTCheckBox)AddControl(new Guid("8a1ac911-a354-4531-ab87-1c58780d217d"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("0fddcb77-e31b-4e5d-ab9a-b970d2d62b9f"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("ea06921c-e828-4b7d-9edd-97b29e1c2250"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("138aa3f6-0176-4f49-a10e-13dc24b408d0"));
            labelRoom = (ITTLabel)AddControl(new Guid("19e0b2b9-eac6-4066-b087-36bcb5b25066"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("ad16e22a-c41b-4104-b068-c4e6c679e992"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("4243f350-381b-4ee3-9dc8-e31b467f8c49"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("eff172ed-9f16-4728-a1f7-ddcbe2f5c322"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("2ac7c8fb-11ed-4785-8de5-44fc1316dd1e"));
            base.InitializeControls();
        }

        public SurgeryCancelledForm() : base("SURGERY", "SurgeryCancelledForm")
        {
        }

        protected SurgeryCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}