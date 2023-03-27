
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
    /// E2 Onay
    /// </summary>
    public partial class E2ApprovalForm : StockActionBaseForm
    {
    /// <summary>
    /// E2 Belgesi
    /// </summary>
        protected TTObjectClasses.E2 _E2
        {
            get { return (TTObjectClasses.E2)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ConsumableMaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn StockLevelType;
        protected ITTTextBox RegistrationNumber;
        protected ITTTextBox SequenceNumber;
        protected ITTTextBox ProcessNO;
        protected ITTTextBox Description;
        protected ITTLabel labelRegistrationNumber;
        protected ITTObjectListBox Store;
        protected ITTLabel labelSequenceNumber;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelEndDate;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelDescription;
        protected ITTDateTimePicker ProcessDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelProcessNO;
        protected ITTLabel labelProcessDate;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("834bcdd3-db5b-42a7-9a4f-802998be42a1"));
            ConsumableMaterialTabPage = (ITTTabPage)AddControl(new Guid("e396317b-2ec4-4340-9744-b4eb50ec11f4"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("aeacf4c6-38bf-49ba-beb9-29209b6b7b90"));
            Material = (ITTListBoxColumn)AddControl(new Guid("facc45bb-6cd4-4f7a-9568-5df1f48e72fd"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("72dd4915-f6bf-4200-8a12-c463bc1b1a9e"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("d005c239-4d10-496c-b853-d36e8d714ea5"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("222a8ba0-504b-4c49-9c58-7fc49cdb30c4"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("23a48d57-5323-4ff0-8661-2c1997c0bd39"));
            ProcessNO = (ITTTextBox)AddControl(new Guid("52e3cd90-993a-4e76-ac6e-4a181377ad80"));
            Description = (ITTTextBox)AddControl(new Guid("e2f2b118-e03b-4529-be59-f5084dbf4d1f"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("cab4398e-05cb-46dc-a9a0-6e3b84bb72e6"));
            Store = (ITTObjectListBox)AddControl(new Guid("318dbbe9-6388-4ec4-91c5-cb3f28af9d58"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("906c99b8-4a2d-40e3-a4b1-83f5fb03084e"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("81a42c91-e835-4651-a3db-9027a0ff3bce"));
            labelEndDate = (ITTLabel)AddControl(new Guid("5b0b9c90-ffaa-49b6-b3e1-6a785363647f"));
            labelStartDate = (ITTLabel)AddControl(new Guid("faa51585-0ba5-400b-bd58-4bcb0d534eb1"));
            labelDescription = (ITTLabel)AddControl(new Guid("11739395-c550-4396-a9f5-b33a805b7c32"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("0de2f58e-5ff0-4324-b207-d209162d8f32"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("d4564cd4-48a5-4b91-a6fa-1bc7bf937880"));
            labelProcessNO = (ITTLabel)AddControl(new Guid("07612d7d-34ba-488b-aacc-18ab74fad1fa"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("1d268288-748c-48d4-ae71-76144ca97690"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0b0202e1-e8c5-4bc2-a1df-754a348c9d71"));
            base.InitializeControls();
        }

        public E2ApprovalForm() : base("E2", "E2ApprovalForm")
        {
        }

        protected E2ApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}