
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
    public partial class DemandLogDepApprovalForm : TTForm
    {
    /// <summary>
    /// Malzeme/Hizmet İstek modülü için ana sınıftır
    /// </summary>
        protected TTObjectClasses.Demand _Demand
        {
            get { return (TTObjectClasses.Demand)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ItemsGrid;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn ApprovedAmount;
        protected ITTTextBoxColumn StoreStocks;
        protected ITTTextBoxColumn AccountancyAmount;
        protected ITTTextBoxColumn TransferAmount;
        protected ITTTextBoxColumn Description2;
        protected ITTRichTextBoxControlColumn SpRefToAdMatters;
        protected ITTRichTextBoxControlColumn FeasibilityEtude;
        protected ITTListBoxColumn Patient;
        protected ITTTextBoxColumn TechnicalSpecificationNo;
        protected ITTTabPage tttabpage2;
        protected ITTGrid TransfersGrid;
        protected ITTListBoxColumn ReturnStore;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTButtonColumn cmdCancel;
        protected ITTGroupBox ttgroupbox2;
        protected ITTButton cmdApproveAll;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelID;
        protected ITTTextBox Description;
        protected ITTLabel labelDemandType;
        protected ITTDateTimePicker ActionDate;
        protected ITTEnumComboBox DemandType;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d9786ab3-efe8-4a59-8516-c525070cb49a"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("3275db6e-0fb1-4fa6-b181-c55eaf9eee45"));
            ItemsGrid = (ITTGrid)AddControl(new Guid("1019892b-d11e-442b-a3e1-11d6d55ebe4e"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("67561fd5-5c98-4431-a1e9-7296fe5afc88"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("bdba9a29-c843-40d9-9714-29b9bdef227a"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("6322c0b8-98c8-4349-88e7-ec1546725c4a"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("d8ca3561-a528-40e4-a43a-5b93bac30fd8"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("87e900f0-406a-4827-8b57-de3f652b4ce0"));
            ApprovedAmount = (ITTTextBoxColumn)AddControl(new Guid("7bf9125c-d726-4ef9-9b9e-d1a15019df41"));
            StoreStocks = (ITTTextBoxColumn)AddControl(new Guid("ab04881a-b22d-4e7d-8883-56a81d89e8f0"));
            AccountancyAmount = (ITTTextBoxColumn)AddControl(new Guid("7ca521f3-aee3-49ab-bf7e-440abde0e1fd"));
            TransferAmount = (ITTTextBoxColumn)AddControl(new Guid("9ca0e4a7-03de-4b14-a379-2b35ab2d7c61"));
            Description2 = (ITTTextBoxColumn)AddControl(new Guid("7a34fa5b-4065-43a0-b6d7-27a0f77b13ae"));
            SpRefToAdMatters = (ITTRichTextBoxControlColumn)AddControl(new Guid("8d3fe7bb-b2f2-4e61-bae0-0d99fedb7707"));
            FeasibilityEtude = (ITTRichTextBoxControlColumn)AddControl(new Guid("2f43e0ed-e204-467f-87e8-e2d9827561d7"));
            Patient = (ITTListBoxColumn)AddControl(new Guid("1e48b55e-1c6c-4466-bf11-74b9d968bfdc"));
            TechnicalSpecificationNo = (ITTTextBoxColumn)AddControl(new Guid("54e6e80c-0680-4364-9f2c-f65e73f13a86"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("28615a08-9989-45b2-91c6-848d9fdc03a2"));
            TransfersGrid = (ITTGrid)AddControl(new Guid("83a14aec-2c92-41fc-bdb2-7afc3c9dd585"));
            ReturnStore = (ITTListBoxColumn)AddControl(new Guid("278ca446-f653-41f1-b2e1-d92cc8f422ac"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("e2bff0ea-706b-4bd7-87e8-32bdf9d3defd"));
            Material = (ITTListBoxColumn)AddControl(new Guid("2c5f3bdb-cf74-495b-b671-166034a65545"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("f830d89d-8b5a-4237-920a-d96725affc4d"));
            cmdCancel = (ITTButtonColumn)AddControl(new Guid("f4a4be8e-0568-48fa-afe4-69c48e69a743"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("4bbc0692-b1b9-42ee-a8c2-8b721a7cb527"));
            cmdApproveAll = (ITTButton)AddControl(new Guid("1b3be4e1-ec7d-4b0f-8bb2-2bb15e4d2eb6"));
            labelDescription = (ITTLabel)AddControl(new Guid("20a51184-237d-4018-aa2c-b32079168941"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0e0c5c0a-daf3-4fc6-8925-99bf396f55cc"));
            labelActionDate = (ITTLabel)AddControl(new Guid("39223285-3262-4dcf-b1ef-134d92f5902a"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("e4a44e41-2362-4719-948c-1f88de58945e"));
            RequestNO = (ITTTextBox)AddControl(new Guid("35543056-cc48-4692-9b75-7092d9551118"));
            labelID = (ITTLabel)AddControl(new Guid("78e72f43-3d75-4f96-90e6-c3c31caf3030"));
            Description = (ITTTextBox)AddControl(new Guid("61571c6d-b925-404f-89cc-d4449cd2cfab"));
            labelDemandType = (ITTLabel)AddControl(new Guid("9262db65-3c3f-4056-a508-f10271babbd5"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("80d49e8a-5e47-47b9-95ca-8abe57bfe7ab"));
            DemandType = (ITTEnumComboBox)AddControl(new Guid("98276d7d-8983-40f5-a2a2-4345d23494aa"));
            base.InitializeControls();
        }

        public DemandLogDepApprovalForm() : base("DEMAND", "DemandLogDepApprovalForm")
        {
        }

        protected DemandLogDepApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}