
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
    public partial class SurgeryPreOpForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Surgery _Surgery
        {
            get { return (TTObjectClasses.Surgery)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTTabControl tabApplication;
        protected ITTTabPage PreOpApplications;
        protected ITTGrid GridPreOpApplications;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTTabPage TratmentMaterialTab;
        protected ITTGrid GridSurgeryExpends;
        protected ITTDateTimePickerColumn CMActionDate;
        protected ITTListBoxColumn CAMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn CAAmount;
        protected ITTTextBoxColumn DistriButtionType;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTTextBox EpisodeId;
        protected ITTRichTextBoxControl PreOpDescriptions;
        protected ITTRichTextBoxControl DescriptionToPreOp;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker PlannedSurgeryDate;
        protected ITTLabel labelProtocolNo;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox MasterResource;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelRoom;
        protected ITTCheckBox ApprovalFormGiven;
        protected ITTGrid GridMainSurgeryProcedures;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTLabel labelPlannedSurgeryDescription;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelSurgeryDesk;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("6300870d-e681-498d-b2fa-c142e50ee270"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("6a27a12c-3a22-44d3-a619-c8c658a67800"));
            tabApplication = (ITTTabControl)AddControl(new Guid("9a305e73-be06-425c-a257-4b528a9fa972"));
            PreOpApplications = (ITTTabPage)AddControl(new Guid("f25ceeb8-2007-4945-afaa-dcae08e4cabf"));
            GridPreOpApplications = (ITTGrid)AddControl(new Guid("fed3e749-3df2-41cf-a1b2-bf944f5d6242"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("2b190f1d-99cc-4c8a-b959-70361c162e6a"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("37add139-45b7-407d-a0ab-04dd71973b03"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("75f03991-1224-4810-9d5e-484d96d72df7"));
            TratmentMaterialTab = (ITTTabPage)AddControl(new Guid("e2be85c9-f204-4bf2-890b-2ae8f104931d"));
            GridSurgeryExpends = (ITTGrid)AddControl(new Guid("80f11c7a-5052-4d72-89f4-a5ca326f65fe"));
            CMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("8c511cb0-64d0-4464-9ea7-f4f704899b64"));
            CAMaterial = (ITTListBoxColumn)AddControl(new Guid("3464fa68-6495-47d1-b658-e7f5546e32dd"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("b69afb88-fc1d-45fd-ba58-c64ec628388b"));
            CAAmount = (ITTTextBoxColumn)AddControl(new Guid("4009ee52-7e93-4baa-9a63-ab5f8a4cb54f"));
            DistriButtionType = (ITTTextBoxColumn)AddControl(new Guid("70122aaa-371a-48b1-a8e1-21dc46ef9987"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("462d909c-016c-494a-a1db-57e954e4d1ae"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("574a994b-367b-496a-92e5-8b77f1f7909e"));
            EpisodeId = (ITTTextBox)AddControl(new Guid("01e3179d-7567-4d17-a15b-a64ac2ebdc4f"));
            PreOpDescriptions = (ITTRichTextBoxControl)AddControl(new Guid("9921a9a9-540e-41a6-9463-f9dca0561b9f"));
            DescriptionToPreOp = (ITTRichTextBoxControl)AddControl(new Guid("9065344f-2228-4b5e-b156-24640f6e5ea7"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("ff0ac91b-e37a-4053-84cb-6d49cd078618"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("c8f5f2b5-83cf-4306-a68b-543dcff8f3de"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("31906e27-3b2a-4e1d-afda-8e3ddc6572de"));
            PlannedSurgeryDate = (ITTDateTimePicker)AddControl(new Guid("218ec455-4729-4c52-806b-50c2d584148f"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("25f509f3-a44f-43ac-b07f-96d92294299a"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("e3e47b80-4331-4257-a51f-48d601353598"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1ad73fc4-229a-4dab-b903-6a365cf16f9b"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("bc04d725-b89d-4f48-9697-4803b55101aa"));
            Emergency = (ITTCheckBox)AddControl(new Guid("969b5d0d-f5ed-4460-a0f6-78854128445d"));
            labelRoom = (ITTLabel)AddControl(new Guid("10711b86-1147-4b91-a496-ebab3f76f63b"));
            ApprovalFormGiven = (ITTCheckBox)AddControl(new Guid("1a222d4d-65de-4d1a-99d0-37263496fc7e"));
            GridMainSurgeryProcedures = (ITTGrid)AddControl(new Guid("684d93a2-7ca0-43cf-9e25-5d6fe6b9f474"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("c9aaac11-bc9e-45c3-a503-df2976a7524f"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("b21bb128-f3f5-4c6f-957c-b6a8db1a3866"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("2b19e597-bc0c-48bf-a5f7-9244d7d0059e"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("e1a86ff6-4032-4bbd-8349-b68c172008fb"));
            base.InitializeControls();
        }

        public SurgeryPreOpForm() : base("SURGERY", "SurgeryPreOpForm")
        {
        }

        protected SurgeryPreOpForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}