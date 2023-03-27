
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
    /// Lojistik İnceleme
    /// </summary>
    public partial class PurchaseItemAnalysesFormIn : TTForm
    {
    /// <summary>
    /// Lojistik ikmal faaliyetlerinde kullanılan temel detay sınıfıdır(İBF listesi dahili)
    /// </summary>
        protected TTObjectClasses.LBPurchaseProjectDetailInList _LBPurchaseProjectDetailInList
        {
            get { return (TTObjectClasses.LBPurchaseProjectDetailInList)_ttObject; }
        }

        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage3;
        protected ITTGroupBox ttgroupbox4;
        protected ITTGrid ttgrid3;
        protected ITTListBoxColumn FromAccountancy;
        protected ITTListBoxColumn ToAccountancy;
        protected ITTTextBoxColumn TransferAmount;
        protected ITTButtonColumn cmdDelete;
        protected ITTGroupBox ttgroupbox3;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Accountancy1;
        protected ITTTextBoxColumn ReqAmount1;
        protected ITTTextBoxColumn AppAmount1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid ApproveDetailsGrid;
        protected ITTEnumComboBoxColumn ApproveType;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage tttabpage4;
        protected ITTGroupBox ttgroupbox5;
        protected ITTButton cmdList3;
        protected ITTGrid ttgrid2;
        protected ITTListBoxColumn Accountancy;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel6;
        protected ITTGroupBox ttgroupbox1;
        protected ITTButton cmdList2;
        protected ITTButton cmdList1;
        protected ITTMaskedTextBox ttmaskedtextbox1;
        protected ITTLabel lblMinimumSurplusAmount;
        protected ITTGrid StocksGrid;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn Amount1;
        protected ITTTextBoxColumn SurPlusAmount;
        protected ITTLabel ttlabel9;
        protected ITTMaskedTextBox ttmaskedtextbox2;
        protected ITTMaskedTextBox ttmaskedtextbox3;
        protected ITTMaskedTextBox ttmaskedtextbox4;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel8;
        protected ITTTextBox txtDemandedAmount;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel4;
        protected ITTTextBox txtCancelledAmount;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTTextBox txtApprovedAmount;
        protected ITTLabel RestAmount;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("38167002-2f0e-4f96-9510-10a2646f1d7f"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("c4f78017-289c-4928-a7c3-851faacbb555"));
            ttgroupbox4 = (ITTGroupBox)AddControl(new Guid("c18ad81e-33c0-4cff-a9a0-fe0b129190af"));
            ttgrid3 = (ITTGrid)AddControl(new Guid("10509651-6a93-403d-b0a5-4c03f32356b4"));
            FromAccountancy = (ITTListBoxColumn)AddControl(new Guid("a52da07c-f1f0-4ced-82c5-a3179fd582c8"));
            ToAccountancy = (ITTListBoxColumn)AddControl(new Guid("72ff566f-fc85-4fc3-8d93-4d9a59f34435"));
            TransferAmount = (ITTTextBoxColumn)AddControl(new Guid("9b809431-bbde-47f5-9301-6d0c899b451a"));
            cmdDelete = (ITTButtonColumn)AddControl(new Guid("74363a26-3727-4308-8ab1-1199dbddaf12"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("a58af8ce-ab83-4a3e-a6f1-ba19c32b130c"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("6576bb3c-6be7-45a0-8194-0217d203ef65"));
            Accountancy1 = (ITTListBoxColumn)AddControl(new Guid("495c15bb-0b26-4643-ae0e-0507b4fc33db"));
            ReqAmount1 = (ITTTextBoxColumn)AddControl(new Guid("5a1b2ab8-fd20-434a-985b-adf6d8638572"));
            AppAmount1 = (ITTTextBoxColumn)AddControl(new Guid("aaab3273-8975-4ba7-a077-af70a10835b0"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("b0bd3341-0efd-431e-9827-6705e5c249e8"));
            ApproveDetailsGrid = (ITTGrid)AddControl(new Guid("81ece5e7-ebc0-4322-8342-a470f37f1b94"));
            ApproveType = (ITTEnumComboBoxColumn)AddControl(new Guid("bcd6c66f-21c7-4eb0-a0d4-1158790593c9"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("b9b0b3f8-de8a-4bb1-9bc6-640dfc3ab71f"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("dea838ce-f9a8-4ed0-817e-7e59fbaf0a94"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("66799183-2a2a-4cee-bf6e-4c53718a76c0"));
            ttgroupbox5 = (ITTGroupBox)AddControl(new Guid("8f08d4b5-cc3a-417a-aa0f-4af767949c35"));
            cmdList3 = (ITTButton)AddControl(new Guid("58f4c0a3-d339-4324-9c8f-cf7e65981584"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("76447cd0-19d5-48e4-9ff8-85fa9ee7e8ac"));
            Accountancy = (ITTListBoxColumn)AddControl(new Guid("1381a89f-988c-4bab-8e49-e0778f1b95d9"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("a3bf54cc-7bb8-465b-ab9c-932d07a491a1"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("e495f2dd-3202-4133-955f-e37bba4ea1da"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("a9695d0b-4403-4527-8b32-38f9c3370a0b"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("89d41dcf-05ea-4b4e-8e6b-03bff4e7696c"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("f6f4dfde-b26b-4f7d-8488-504937aea45f"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("6acf7df8-247d-49c8-aecb-c86a56c3b34e"));
            cmdList2 = (ITTButton)AddControl(new Guid("6bbbef95-c8f5-46dc-aafd-45528ac057e2"));
            cmdList1 = (ITTButton)AddControl(new Guid("80aca979-5703-401d-af85-dd78d41b6529"));
            ttmaskedtextbox1 = (ITTMaskedTextBox)AddControl(new Guid("98ca238e-6049-4ed9-9aba-cd05bbae95c5"));
            lblMinimumSurplusAmount = (ITTLabel)AddControl(new Guid("422ed39f-5a13-46ba-b426-afbcbb39b29a"));
            StocksGrid = (ITTGrid)AddControl(new Guid("700f6b41-9490-4e78-8515-10ca6405fbd7"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("652fa53a-b93d-4115-820f-28241c6551e8"));
            Amount1 = (ITTTextBoxColumn)AddControl(new Guid("cced1aa4-7ee4-44f7-bbb3-2c8c36f5649d"));
            SurPlusAmount = (ITTTextBoxColumn)AddControl(new Guid("2b04b00e-f1cf-4e82-9f7a-17af90bea91c"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("4d761953-5f7c-4caa-89db-f824f541fe17"));
            ttmaskedtextbox2 = (ITTMaskedTextBox)AddControl(new Guid("a872b533-56ca-4f3b-8870-18b332dcd05e"));
            ttmaskedtextbox3 = (ITTMaskedTextBox)AddControl(new Guid("b11586bc-3985-4a4d-af4c-5ccb62c784e2"));
            ttmaskedtextbox4 = (ITTMaskedTextBox)AddControl(new Guid("a0cae08e-9353-4d7d-bc8c-89859f9bc934"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("2ab75287-5205-46b1-a808-d79d34ac5695"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("e02f222c-943b-4073-abfb-209701ed5a0b"));
            txtDemandedAmount = (ITTTextBox)AddControl(new Guid("ff1711c3-89e9-427c-ab29-0ae2aeaa56f1"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("7a59e193-abb0-45c7-b97e-848570b754d6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d12bc275-d88f-4eb1-aad1-8c95b435e7b8"));
            txtCancelledAmount = (ITTTextBox)AddControl(new Guid("6d2805c1-e9c4-4b34-87ef-52510d7bb78b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3bfec449-404a-4d6b-aa87-3bfa065dfba0"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7116e9c0-942f-4205-b987-a478deb342cb"));
            txtApprovedAmount = (ITTTextBox)AddControl(new Guid("09a5cdd7-da6b-407d-93ae-87d00f855198"));
            RestAmount = (ITTLabel)AddControl(new Guid("05cc0dd6-cdc1-4497-9ee9-5acf9f84e9c5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("50af71c3-6b18-43df-9d33-040f416d97c8"));
            base.InitializeControls();
        }

        public PurchaseItemAnalysesFormIn() : base("LBPURCHASEPROJECTDETAILINLIST", "PurchaseItemAnalysesFormIn")
        {
        }

        protected PurchaseItemAnalysesFormIn(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}