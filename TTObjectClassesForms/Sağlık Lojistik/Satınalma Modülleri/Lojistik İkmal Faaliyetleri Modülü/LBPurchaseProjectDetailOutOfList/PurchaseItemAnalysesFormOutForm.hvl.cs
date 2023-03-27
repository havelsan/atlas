
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
    /// İnceleme
    /// </summary>
    public partial class PurchaseItemAnalysesFormOut : TTForm
    {
    /// <summary>
    /// Lojistik ikmal faaliyetlerinde kullanılan temel detay sınıfıdır(İBF listesi harici)
    /// </summary>
        protected TTObjectClasses.LBPurchaseProjectDetailOutOfList _LBPurchaseProjectDetailOutOfList
        {
            get { return (TTObjectClasses.LBPurchaseProjectDetailOutOfList)_ttObject; }
        }

        protected ITTLabel RestAmount;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel4;
        protected ITTTextBox txtCancelledAmount;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTTextBox txtApprovedAmount;
        protected ITTTextBox txtDemandedAmount;
        protected ITTLabel ttlabel1;
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
        override protected void InitializeControls()
        {
            RestAmount = (ITTLabel)AddControl(new Guid("4f20e9e3-e736-43ad-b3ca-4da00da5d981"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("2bb9feda-e68d-46e2-9d6c-17b5683212ac"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("75d98309-d10a-40a0-a2b5-52b76178a93b"));
            txtCancelledAmount = (ITTTextBox)AddControl(new Guid("2a7dd26d-ca27-44fa-b38c-fd0ff1e89dfd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ec57fae7-3248-425b-8de8-8b0d16c9ca0f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5f7bd74e-fccf-4614-be23-fe1e42d337d7"));
            txtApprovedAmount = (ITTTextBox)AddControl(new Guid("9f2b4ac4-e8ad-42a5-975a-4b7f193f8e0a"));
            txtDemandedAmount = (ITTTextBox)AddControl(new Guid("4f9ce19d-14b7-423d-b607-6d43fb1f4d95"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1acca260-a44c-4f9e-90c1-21940bdb47bb"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("5f37545c-e1ea-4b76-9559-e56b3619de44"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("9c30f0ac-af85-4f6a-9f39-7414117b7f5f"));
            ttgroupbox4 = (ITTGroupBox)AddControl(new Guid("dc3e981f-626d-4ada-9d3a-3c9a8de057c7"));
            ttgrid3 = (ITTGrid)AddControl(new Guid("dddf8cb7-0bd6-4843-a71e-d1a911342094"));
            FromAccountancy = (ITTListBoxColumn)AddControl(new Guid("24a67ac7-ad63-42a2-9842-1826f3b76d89"));
            ToAccountancy = (ITTListBoxColumn)AddControl(new Guid("2205665b-f06d-4bfe-bb2a-47c4f0385870"));
            TransferAmount = (ITTTextBoxColumn)AddControl(new Guid("3da3ee57-9a36-43fd-955e-f0f687554603"));
            cmdDelete = (ITTButtonColumn)AddControl(new Guid("8f10337a-c7fa-4af8-ada6-30ef20ed7c20"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("168f2304-1fcd-4be7-a946-48f5212b1dc5"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("fa254734-0612-4a29-81fe-78a95eed579d"));
            Accountancy1 = (ITTListBoxColumn)AddControl(new Guid("05ed9dfd-c025-4e63-9e4e-06af79241272"));
            ReqAmount1 = (ITTTextBoxColumn)AddControl(new Guid("497d63c8-4ba0-4b44-87ab-e8114732c99a"));
            AppAmount1 = (ITTTextBoxColumn)AddControl(new Guid("d72cb5cd-aa6e-4bd1-9677-f6650b3772d8"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("d03b2afc-046d-4057-bc31-21fdfaf6c6ad"));
            ApproveDetailsGrid = (ITTGrid)AddControl(new Guid("9cbf5e94-26a1-44ed-9a53-dc29f44b1d1c"));
            ApproveType = (ITTEnumComboBoxColumn)AddControl(new Guid("0c83e68e-a1b3-4b9d-856e-c1914df179e7"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("fcda5965-54cb-4752-9cde-bf15ce0452c8"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("c63a8757-d78a-4163-a7c7-8088c591ba6f"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("91a66b94-a8e5-4cce-8ede-1849ed3f53c7"));
            ttgroupbox5 = (ITTGroupBox)AddControl(new Guid("b3a3c86d-5560-4f51-aefb-2c667a1c371a"));
            cmdList3 = (ITTButton)AddControl(new Guid("edfeff1a-8cc9-4be3-8529-4f24a98c9707"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("52c0b556-feb5-41d3-8a7d-886c0b1a89a2"));
            Accountancy = (ITTListBoxColumn)AddControl(new Guid("82b283a2-29e7-4ca6-8877-d4839e6afff1"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("69b7546a-1067-42dd-b4dd-8b3136227f5e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("04309daa-618e-43bc-8354-0bfd71d96a2f"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("c3d4ea86-37a1-40f1-8017-2922de38c4a3"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("8c9a921c-97df-4374-ab6f-eb55820e8f38"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("bf7248f5-a2c3-4f3b-b5ca-ae29839b556a"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("74a05ce8-55fb-4719-bd2d-bb5c54ca477e"));
            cmdList2 = (ITTButton)AddControl(new Guid("36a66de6-b0c8-4bcc-ba4e-1c82682e7567"));
            cmdList1 = (ITTButton)AddControl(new Guid("dbb11796-21f3-4780-a970-181fe4fb81f9"));
            ttmaskedtextbox1 = (ITTMaskedTextBox)AddControl(new Guid("28e2b27b-6ec5-4e1a-ad77-b4e6cf98c7a9"));
            lblMinimumSurplusAmount = (ITTLabel)AddControl(new Guid("f3dad667-3ca7-48ab-a774-6cc20887de2f"));
            StocksGrid = (ITTGrid)AddControl(new Guid("e121e20d-83bb-4128-a55e-884c3cf40769"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("cc2da805-07b8-4514-852e-e40eb9039349"));
            Amount1 = (ITTTextBoxColumn)AddControl(new Guid("59385935-36cf-4465-8baf-3d34695ae2bb"));
            SurPlusAmount = (ITTTextBoxColumn)AddControl(new Guid("64e42be0-f517-4baa-9962-37c3cef021be"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("27725e10-707f-44e1-a2d3-854233c981e7"));
            ttmaskedtextbox2 = (ITTMaskedTextBox)AddControl(new Guid("07f4ebe2-ab29-4003-86c6-74f1a618104b"));
            ttmaskedtextbox3 = (ITTMaskedTextBox)AddControl(new Guid("e40e2402-356f-4d15-b489-ff08ee97369c"));
            ttmaskedtextbox4 = (ITTMaskedTextBox)AddControl(new Guid("db9114e9-5fb6-4fa3-8db5-06e00a3ec51d"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("a3a0e8a0-44b8-4155-b464-bb3f7a7559db"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("b0459213-d907-4958-909e-8d7c2dd74301"));
            base.InitializeControls();
        }

        public PurchaseItemAnalysesFormOut() : base("LBPURCHASEPROJECTDETAILOUTOFLIST", "PurchaseItemAnalysesFormOut")
        {
        }

        protected PurchaseItemAnalysesFormOut(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}