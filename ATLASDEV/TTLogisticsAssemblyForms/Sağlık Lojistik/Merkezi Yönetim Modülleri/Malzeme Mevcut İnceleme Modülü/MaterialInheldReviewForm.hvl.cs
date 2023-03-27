
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
    /// Malzeme Mevcut İnceleme
    /// </summary>
    public partial class MaterialInheldReviewForm : TTUnboundForm
    {
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage4;
        protected ITTTextBox txtTotalOut;
        protected ITTLabel ttlabel11;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox txtCensusTotalInheld;
        protected ITTLabel ttlabel16;
        protected ITTTextBox txtCensusTotalOut;
        protected ITTLabel ttlabel15;
        protected ITTTextBox txtCensusTotalIn;
        protected ITTLabel ttlabel14;
        protected ITTTextBox txtCensusYearCensus;
        protected ITTLabel ttlabel13;
        protected ITTLabel lblTerm;
        protected ITTTextBox txtTotalIn;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel8;
        protected ITTTextBox txtReservationAmount;
        protected ITTTextBox txtMinLevel;
        protected ITTLabel ttlabel7;
        protected ITTTextBox txtMaxLevel;
        protected ITTTextBox txtConsigned;
        protected ITTLabel ttlabel6;
        protected ITTTextBox txtInheld;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTGrid OutableGrid;
        protected ITTTextBoxColumn LotNo;
        protected ITTDateTimePickerColumn ExpirationDate;
        protected ITTTextBoxColumn Amount;
        protected ITTTabPage tttabpage1;
        protected ITTButton cmdCreateStability;
        protected ITTTextBox txtDescription;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox AccountancyListBox;
        protected ITTGrid StabilityGrid;
        protected ITTListBoxColumn SendingAccountancy;
        protected ITTListBoxColumn ReceivAccountancy;
        protected ITTTextBoxColumn StabilityAmount;
        protected ITTListBoxColumn Site;
        protected ITTTextBoxColumn MainStoreID;
        protected ITTButton cmdAddStability;
        protected ITTTabPage tttabpage2;
        protected ITTLabel ttlabel17;
        protected ITTDateTimePicker endDate;
        protected ITTLabel ttlabel12;
        protected ITTDateTimePicker startDate;
        protected ITTButton cmdListMaterialStability;
        protected ITTListView MaterialStabilitListview;
        protected ITTTabPage tttabpage3;
        protected ITTButton ttbuttonLotNuGetir;
        protected ITTTextBox ttLotNuTextBox;
        protected ITTLabel lblLotNu;
        protected ITTListView MaterialLotListView;
        protected ITTButton cmdGetInheld;
        protected ITTListView SiteListview;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox MaterialListBox;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d788df3c-01ce-4e1c-ad58-c4a9729067f8"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("1b2cddc1-fdf0-4072-b1b7-9d3b102320a5"));
            txtTotalOut = (ITTTextBox)AddControl(new Guid("bdd8a1b4-0e9b-43bb-86ad-f29f58760a92"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("92ca7bdb-d80d-4f5a-95a1-01cd611040e7"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("69066c22-3112-457d-9665-dc962695eeed"));
            txtCensusTotalInheld = (ITTTextBox)AddControl(new Guid("4ed5b3e5-8249-4ed7-8d37-21875807454f"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("c4664ab9-5045-49e3-a6bd-efcb31242584"));
            txtCensusTotalOut = (ITTTextBox)AddControl(new Guid("1eb6c0ae-b99d-4d0f-a68d-1f7cba96ebc7"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("3a09d105-3dfa-4fe2-b09b-1f1fbc4477b0"));
            txtCensusTotalIn = (ITTTextBox)AddControl(new Guid("f578fc0e-ab9f-4848-bd7b-7464a0531270"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("2b3d58b2-3693-4df8-95ad-b789ddd583da"));
            txtCensusYearCensus = (ITTTextBox)AddControl(new Guid("7d002854-d8f3-45eb-8981-3b0282568886"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("364e1ccc-133f-4068-864c-6f2fa44ad599"));
            lblTerm = (ITTLabel)AddControl(new Guid("785d59af-8600-44f5-8383-07d70dc77732"));
            txtTotalIn = (ITTTextBox)AddControl(new Guid("6096df05-7926-4f05-a831-a85f71ce56d8"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("07b41726-afa1-413d-a108-c008cb3ef659"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("24f20872-8ed7-43ba-b486-e370141561ba"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("5db62039-d8e2-43f6-bc09-34f151a7c4fc"));
            txtReservationAmount = (ITTTextBox)AddControl(new Guid("0ae71eb5-daf9-43d6-8d7e-cbe5cd8cb22a"));
            txtMinLevel = (ITTTextBox)AddControl(new Guid("c54930b5-b64e-4980-9c2e-5cc978cb6eaa"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("835dfff9-2074-4092-b62a-63f6eb94fb13"));
            txtMaxLevel = (ITTTextBox)AddControl(new Guid("dfe50d63-7661-4049-8639-36870837e740"));
            txtConsigned = (ITTTextBox)AddControl(new Guid("1195a1ed-b7f8-4869-8660-e41c0bdbec79"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("09241bc8-bbfd-47f7-aa00-bdf8aab41a0f"));
            txtInheld = (ITTTextBox)AddControl(new Guid("d0757c5f-b3c8-4590-aa4f-a2680a6d5566"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b6d63d94-282c-4801-9cf5-458232eb6d1c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4f8084e5-7c7a-4ac1-bf70-f13f1fbb136d"));
            OutableGrid = (ITTGrid)AddControl(new Guid("c053cfb1-f330-41d7-8cb1-34c2269a1660"));
            LotNo = (ITTTextBoxColumn)AddControl(new Guid("f1453da0-b120-44cf-a046-8e78bd3af056"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("e7e0acb8-ba63-471f-9c7a-ec3e9f1d0a42"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("2196e862-d5b4-4b22-a67f-57c460476c51"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("cba74637-d52e-4634-969d-913c3c822d2a"));
            cmdCreateStability = (ITTButton)AddControl(new Guid("6325be68-bce4-49fd-b900-0f0b9325a166"));
            txtDescription = (ITTTextBox)AddControl(new Guid("017a5d87-0eec-41d1-81cb-2ca4e9850789"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3658c261-46ed-4d2b-854e-ca5045c8017f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("aae1d12b-e694-4ac9-8f4f-b485ff7dff30"));
            AccountancyListBox = (ITTObjectListBox)AddControl(new Guid("a5910a0d-6e2c-42f7-9db4-9412f11c7a13"));
            StabilityGrid = (ITTGrid)AddControl(new Guid("025ffe49-1eb8-4fae-ac56-89514f07fcd8"));
            SendingAccountancy = (ITTListBoxColumn)AddControl(new Guid("f5eec1ec-648e-4375-ade4-03fabeee9ff4"));
            ReceivAccountancy = (ITTListBoxColumn)AddControl(new Guid("805a0dbd-5bbb-4b0e-9780-656fcff0e0a7"));
            StabilityAmount = (ITTTextBoxColumn)AddControl(new Guid("f406d04b-d7d7-4014-933a-3a6564acfda9"));
            Site = (ITTListBoxColumn)AddControl(new Guid("551dd314-b66f-48bf-85a2-6026ee561b66"));
            MainStoreID = (ITTTextBoxColumn)AddControl(new Guid("6e373e34-69b3-408b-bf25-29179d2007be"));
            cmdAddStability = (ITTButton)AddControl(new Guid("0559c4e4-deec-452d-8953-74c58b592cad"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("641f0656-038c-4dd3-9546-28d17b869187"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("cff938cc-be96-4b25-809a-fbd224a39e7d"));
            endDate = (ITTDateTimePicker)AddControl(new Guid("342a1362-7434-411e-ad9f-3674c470d691"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("d088fabf-c961-4c7a-becb-7ece0792b4a2"));
            startDate = (ITTDateTimePicker)AddControl(new Guid("23613a51-e90a-4f04-afee-df2ee6b9e4ee"));
            cmdListMaterialStability = (ITTButton)AddControl(new Guid("123c6b70-9707-44a8-ab5b-77fed699f163"));
            MaterialStabilitListview = (ITTListView)AddControl(new Guid("4371262b-f8aa-4914-ab61-610e605212e8"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("fc225c03-98df-4f37-b4a0-29fffee276a7"));
            ttbuttonLotNuGetir = (ITTButton)AddControl(new Guid("b99ea160-1a48-4d85-b9e0-c80e7324611d"));
            ttLotNuTextBox = (ITTTextBox)AddControl(new Guid("2f67b32f-2516-4435-a65c-ee9ec59bd795"));
            lblLotNu = (ITTLabel)AddControl(new Guid("1fa89273-862d-4bb7-bbb1-d740fbe865cc"));
            MaterialLotListView = (ITTListView)AddControl(new Guid("9ec77918-019a-47fa-8f1b-b9da91bbd65d"));
            cmdGetInheld = (ITTButton)AddControl(new Guid("8c06c90e-f558-4b38-a17e-878824acfb63"));
            SiteListview = (ITTListView)AddControl(new Guid("4b9a97ce-5a17-47e1-bac9-062f5352304f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("964b0b53-05b6-4e96-8847-32ee2ad11baa"));
            MaterialListBox = (ITTObjectListBox)AddControl(new Guid("66fa0a6c-6262-4bbf-b5de-684f5c27a4f1"));
            base.InitializeControls();
        }

        public MaterialInheldReviewForm() : base("MaterialInheldReviewForm")
        {
        }

        protected MaterialInheldReviewForm(string formDefName) : base(formDefName)
        {
        }
    }
}