
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
    /// BaseSectionRequirementForm
    /// </summary>
    public partial class BaseSectionRequirementForm : StockActionBaseForm
    {
    /// <summary>
    /// Kısım İhtiyaç Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.SectionRequirement _SectionRequirement
        {
            get { return (TTObjectClasses.SectionRequirement)_ttObject; }
        }

        protected ITTTextBox RequestNo;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTextBox Description;
        protected ITTTextBox StockActionID;
        protected ITTTextBox OrderName;
        protected ITTTextBox OrderAmount;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelRequestNo;
        protected ITTLabel labelOrderName;
        protected ITTLabel labelOrderAmount;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn MaterialName;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn Existing;
        protected ITTTextBoxColumn AcceptedAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTListDefComboBoxColumn StockLevelType;
        override protected void InitializeControls()
        {
            RequestNo = (ITTTextBox)AddControl(new Guid("8c1505d6-d43b-4f0b-850f-a2bd0787ec30"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("1397cc47-c0d4-4246-b574-6e4894bcf13f"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("d524eb37-7e30-4894-a7c8-e7b1608fb157"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("cd84083d-e09b-407f-b933-13358d4bb0af"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("0142b19e-d449-4602-bb15-8597f09b3e46"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("8c4991f6-9d90-477a-8e7c-0d2a16a328bb"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("b80aa6ef-824b-4116-9d97-36833a5d585b"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("e35c3c56-65d1-4b0a-b519-38c299deed5e"));
            Description = (ITTTextBox)AddControl(new Guid("da3d856d-bcbb-4d04-a0e5-e2501d3b9b14"));
            StockActionID = (ITTTextBox)AddControl(new Guid("3fd174f7-0cae-4aae-a0bb-2c511337bbbc"));
            OrderName = (ITTTextBox)AddControl(new Guid("a260de09-a3f4-4c4a-a407-4e2c8a5ec8ae"));
            OrderAmount = (ITTTextBox)AddControl(new Guid("165e1e2c-2cf1-4c5d-99de-a094b8553173"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("bfdd229b-c818-4bd3-b406-cbf66c6a81a9"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("006da6e0-8996-4143-a25e-989bb8d1a332"));
            labelStore = (ITTLabel)AddControl(new Guid("86852b87-5315-49ff-9235-a554a93696bd"));
            Store = (ITTObjectListBox)AddControl(new Guid("8fb9e77c-3996-4f8e-bcea-54701e7b17de"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("fdd783ab-9e76-423e-8466-dbdbd388f23a"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("23ae5fce-13f4-47ad-ae25-4fa388103b46"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("7e4b3985-7ddf-43d3-afb9-0cc2bb8bf9d2"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("2506a532-3b52-48f9-8484-ce31e1d55a5d"));
            labelOrderName = (ITTLabel)AddControl(new Guid("b8fe2e22-16c4-46b2-a572-3de413ff3f36"));
            labelOrderAmount = (ITTLabel)AddControl(new Guid("4a1669c5-7b26-4d3e-871a-e65ff5fc517f"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("b5ebb8e4-900b-4983-92b2-ee8e2d96b8b9"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("1f881916-bde7-4e6d-897c-ed4160978af1"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("7fed7ca4-06f7-4609-9184-51fc3f7d9e25"));
            MaterialName = (ITTListBoxColumn)AddControl(new Guid("6339cb01-62c2-4b67-99fb-29aea9bf952a"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("866f093e-147d-4c11-9299-11a990b0ba48"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("c46b2208-0cd0-487d-a1f6-e0d656e68125"));
            Existing = (ITTTextBoxColumn)AddControl(new Guid("3348ee81-1984-4a9c-90ea-9d43e584e30d"));
            AcceptedAmount = (ITTTextBoxColumn)AddControl(new Guid("6b5150f1-da05-40c8-9412-124b3d7df1aa"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("7ecec9a8-f5d8-4907-98dd-1ebc5fe94683"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("72d48795-44ca-4301-becc-cff2f0471425"));
            base.InitializeControls();
        }

        public BaseSectionRequirementForm() : base("SECTIONREQUIREMENT", "BaseSectionRequirementForm")
        {
        }

        protected BaseSectionRequirementForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}