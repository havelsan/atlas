
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
    /// Senet Formu
    /// </summary>
    public partial class BondForm : TTForm
    {
    /// <summary>
    /// Senet İşlemleri
    /// </summary>
        protected TTObjectClasses.Bond _Bond
        {
            get { return (TTObjectClasses.Bond)_ttObject; }
        }

        protected ITTTabControl BondTabs;
        protected ITTTabPage BondPayerTab;
        protected ITTLabel lblPayerPhone;
        protected ITTTextBox tttextbox11;
        protected ITTLabel lblPayerDescription;
        protected ITTTextBox tttextbox8;
        protected ITTLabel lblPayerAddress;
        protected ITTTextBox txtPayerAddress;
        protected ITTLabel lblPayerHomeTown;
        protected ITTObjectListBox TTListBoxPayerHomeTown;
        protected ITTLabel lblPayerHomeCity;
        protected ITTObjectListBox TTListBoxPayerHomeCity;
        protected ITTLabel lblPayerTownOfRegistry;
        protected ITTObjectListBox TTListBoxPayerTownOfRegistry;
        protected ITTLabel lblPayerCityOfResgistry;
        protected ITTObjectListBox TTListBoxPayerCityOfRegistry;
        protected ITTLabel lblPayerBirthDate;
        protected ITTDateTimePicker dtPickerPayerBirthDate;
        protected ITTLabel lblPayerCityOfBirth;
        protected ITTObjectListBox TTListBoxCityOfBirth;
        protected ITTLabel lblPayerMotherName;
        protected ITTTextBox txtPayerMotherName;
        protected ITTLabel lblPayerFatherName;
        protected ITTTextBox txtPayerFatherName;
        protected ITTLabel lblPayerSurname;
        protected ITTTextBox txtPayerSurname;
        protected ITTLabel lblPayerIdentificationCardNo;
        protected ITTLabel lblPayerUniqueRefNo;
        protected ITTTextBox txtPayerIdentificationCardNo;
        protected ITTTextBox txtPayerUniqueRefNo;
        protected ITTLabel lblPayerName;
        protected ITTTextBox txtBondPayerName;
        protected ITTTabPage TTListBox;
        protected ITTLabel lblFirstGuarantorPhone;
        protected ITTTextBox txtFirstGuarantorPhone;
        protected ITTTextBox txtFirstGuarantorDescription;
        protected ITTLabel lblFirstGuarantorDescription;
        protected ITTTextBox txtFirstGuarantorName;
        protected ITTLabel lblFirstGuarantorName;
        protected ITTLabel lblFirstGuarantorAddress;
        protected ITTTextBox txtFirstGuarantorUniqueRefNo;
        protected ITTTextBox txtFirstGuarantorAddress;
        protected ITTTextBox txtFirstGuarantorIdentificationCardNo;
        protected ITTLabel lblFirstGuarantorHomeTown;
        protected ITTLabel lblFirstGuarantorUniqueRefNo;
        protected ITTObjectListBox txtFirstGuarantorHomeTown;
        protected ITTLabel lblFirstGuarantorIdentificationCardNo;
        protected ITTLabel lblFirstGuarantorHomeCity;
        protected ITTTextBox txtFirstGuarantorSurname;
        protected ITTObjectListBox TTListBoxFirstGuarantorHomeCity;
        protected ITTLabel lblFirstGuarantorSurname;
        protected ITTTextBox txtFirstGuarantorFatherName;
        protected ITTLabel lblFirstGuarantorFatherName;
        protected ITTTextBox txtFirstGuarantorMotherName;
        protected ITTLabel lblFirstGuarantorMotherName;
        protected ITTLabel lblFirstGuarantorBirthDate;
        protected ITTObjectListBox TTListBoxFirstGuarantorCityOfBirth;
        protected ITTDateTimePicker TTListBoxFirstGuarantorBirthDate;
        protected ITTLabel lblFirstGuarantorCityOfBirth;
        protected ITTTabPage BondDetail;
        protected ITTGrid GrdBondDetails;
        protected ITTDateTimePickerColumn BDDATE;
        protected ITTTextBoxColumn BDPRICE;
        protected ITTDateTimePickerColumn BDPAYMENTDATE;
        protected ITTTextBoxColumn BDDESCRIPTION;
        protected ITTCheckBoxColumn BDBUTTONPAID;
        protected ITTTabPage BondProceduresTab;
        protected ITTGrid GrdBondProcedure;
        protected ITTTextBoxColumn BPACTIONDATE;
        protected ITTTextBoxColumn BPEXTERNALCODE;
        protected ITTTextBoxColumn BPAMOUNT;
        protected ITTTextBoxColumn BPREMAININGPRICE;
        protected ITTTextBoxColumn BPTOTALPRICE;
        protected ITTTextBoxColumn BPUNITPRICE;
        protected ITTTextBoxColumn BPDESCRIPTION;
        protected ITTGroupBox grpBoxBondInfo;
        protected ITTLabel lblRestructuredBond;
        protected ITTTextBox txtRestructuredBond;
        protected ITTLabel lblAdavnceTaken;
        protected ITTTextBox txtAdvanceTaken;
        protected ITTButton btnCalcBondDetail;
        protected ITTLabel lblBondPrice;
        protected ITTTextBox txtBondPrice;
        protected ITTLabel lblBondDescription;
        protected ITTLabel lblSecondNotificationDate;
        protected ITTLabel lblFirstNotificationDate;
        protected ITTLabel lblBondDate;
        protected ITTLabel lblBondNo;
        protected ITTTextBox txtBondDescription;
        protected ITTDateTimePicker dtPickerBondDate;
        protected ITTTextBox txtBondNo;
        protected ITTDateTimePicker dtPickerSecondNotificationDate;
        protected ITTDateTimePicker dtPickerFirstNoficationDate;
        override protected void InitializeControls()
        {
            BondTabs = (ITTTabControl)AddControl(new Guid("e064c8e8-1711-4d85-9fa1-8e2d778c564b"));
            BondPayerTab = (ITTTabPage)AddControl(new Guid("1b6f7784-e9ed-4ac6-91d7-69fd4b251500"));
            lblPayerPhone = (ITTLabel)AddControl(new Guid("dd9e208a-6d4b-4fb7-9d29-0af782760205"));
            tttextbox11 = (ITTTextBox)AddControl(new Guid("e4cdeddb-18bb-4bb4-afba-3576b80601aa"));
            lblPayerDescription = (ITTLabel)AddControl(new Guid("b13c999c-ee13-4eb1-8405-661e77f807d8"));
            tttextbox8 = (ITTTextBox)AddControl(new Guid("3c6a210c-0138-40f4-b4b3-1ff4ebd014d9"));
            lblPayerAddress = (ITTLabel)AddControl(new Guid("1f3cb280-94bc-4028-a2ea-b4d985107f9d"));
            txtPayerAddress = (ITTTextBox)AddControl(new Guid("8e4d2e58-e2e3-427e-898b-ba2e0fae977b"));
            lblPayerHomeTown = (ITTLabel)AddControl(new Guid("64f9614e-7dc0-4fe4-8d66-db1d9f6e78dd"));
            TTListBoxPayerHomeTown = (ITTObjectListBox)AddControl(new Guid("1c786fed-86a7-4c76-a62a-e436071a1c65"));
            lblPayerHomeCity = (ITTLabel)AddControl(new Guid("68006b7a-657e-4caf-bce1-4512607e10d3"));
            TTListBoxPayerHomeCity = (ITTObjectListBox)AddControl(new Guid("2c54cb39-8ada-45fd-bd8a-03f694bbbb61"));
            lblPayerTownOfRegistry = (ITTLabel)AddControl(new Guid("aeb51078-5083-44a1-9d54-34b6c7f30030"));
            TTListBoxPayerTownOfRegistry = (ITTObjectListBox)AddControl(new Guid("538ca1a3-0cbc-4ee5-a5de-53e4b8357e8a"));
            lblPayerCityOfResgistry = (ITTLabel)AddControl(new Guid("22a80eba-d29f-4cb3-ab42-1dc5ec149db7"));
            TTListBoxPayerCityOfRegistry = (ITTObjectListBox)AddControl(new Guid("a38ea06a-9d39-4756-90d0-138e7e147d6b"));
            lblPayerBirthDate = (ITTLabel)AddControl(new Guid("909611b7-ee2e-44b7-9522-064f6a82785d"));
            dtPickerPayerBirthDate = (ITTDateTimePicker)AddControl(new Guid("483d3ef0-abfc-49ba-9c4b-a2a49998a8e3"));
            lblPayerCityOfBirth = (ITTLabel)AddControl(new Guid("0dc66e60-0efa-4877-9de9-b423af5a3948"));
            TTListBoxCityOfBirth = (ITTObjectListBox)AddControl(new Guid("32ce0bb0-cbfb-4054-a53c-d7b08f9f0280"));
            lblPayerMotherName = (ITTLabel)AddControl(new Guid("352381c4-a8dd-4194-902e-db80f4dc0916"));
            txtPayerMotherName = (ITTTextBox)AddControl(new Guid("b81f1526-6d9a-4860-a76b-92ecf211c583"));
            lblPayerFatherName = (ITTLabel)AddControl(new Guid("61d30996-a19c-4ad9-90a1-c7305cd53a81"));
            txtPayerFatherName = (ITTTextBox)AddControl(new Guid("842cf910-a5b7-4bed-8cc3-d01181da87fc"));
            lblPayerSurname = (ITTLabel)AddControl(new Guid("d2efb6bf-fbe2-44ae-8a50-6d5cdffb38df"));
            txtPayerSurname = (ITTTextBox)AddControl(new Guid("e18c1acf-badb-455d-aabe-4b10f7663477"));
            lblPayerIdentificationCardNo = (ITTLabel)AddControl(new Guid("c6e34291-819b-4cfb-b299-7affba7f23f8"));
            lblPayerUniqueRefNo = (ITTLabel)AddControl(new Guid("d145d943-5b6c-42fe-ba48-eb40d91c4ac8"));
            txtPayerIdentificationCardNo = (ITTTextBox)AddControl(new Guid("54594fde-dc6f-4a5a-a8dd-249d8f482284"));
            txtPayerUniqueRefNo = (ITTTextBox)AddControl(new Guid("f560c1db-e1ba-4ab8-8970-caa19a02e437"));
            lblPayerName = (ITTLabel)AddControl(new Guid("d6d5425c-8b70-47ad-b242-227126378a76"));
            txtBondPayerName = (ITTTextBox)AddControl(new Guid("feb90d31-8801-4c0c-b30d-750c6808e00b"));
            TTListBox = (ITTTabPage)AddControl(new Guid("028d4034-112b-4dac-8ebd-27e03a878d4d"));
            lblFirstGuarantorPhone = (ITTLabel)AddControl(new Guid("e2b8468c-9d50-4943-9c35-b0e0708c9654"));
            txtFirstGuarantorPhone = (ITTTextBox)AddControl(new Guid("9afebc3b-fae0-4bb5-8208-90508e737027"));
            txtFirstGuarantorDescription = (ITTTextBox)AddControl(new Guid("81dec7f2-4351-4ec2-bf4a-0d1838402ccb"));
            lblFirstGuarantorDescription = (ITTLabel)AddControl(new Guid("07d7c04d-9928-4535-8f27-aa7ef82663ec"));
            txtFirstGuarantorName = (ITTTextBox)AddControl(new Guid("7fafb3ca-4257-4a5a-bb7b-ff93aeaca7de"));
            lblFirstGuarantorName = (ITTLabel)AddControl(new Guid("03d7e60f-1c96-4a92-87b8-3c92ca57e6ea"));
            lblFirstGuarantorAddress = (ITTLabel)AddControl(new Guid("9c1bdfb0-8b79-4f30-9463-9aa697f77462"));
            txtFirstGuarantorUniqueRefNo = (ITTTextBox)AddControl(new Guid("e5512d14-b6e9-4bd3-a662-70f3fee98f36"));
            txtFirstGuarantorAddress = (ITTTextBox)AddControl(new Guid("6f2dd6cd-948d-42c5-af2f-e6f7a6598f2e"));
            txtFirstGuarantorIdentificationCardNo = (ITTTextBox)AddControl(new Guid("515ac776-fae9-4f52-b074-867181b6045e"));
            lblFirstGuarantorHomeTown = (ITTLabel)AddControl(new Guid("d6a77ce8-c009-419f-8ae6-197c8244db5f"));
            lblFirstGuarantorUniqueRefNo = (ITTLabel)AddControl(new Guid("5be9e2a0-2d67-40b8-b959-5adace024fab"));
            txtFirstGuarantorHomeTown = (ITTObjectListBox)AddControl(new Guid("28ac6798-378e-47a0-b2e1-7af80ff54cbe"));
            lblFirstGuarantorIdentificationCardNo = (ITTLabel)AddControl(new Guid("14917f68-aa17-4316-adaf-4f38a3d71c24"));
            lblFirstGuarantorHomeCity = (ITTLabel)AddControl(new Guid("2f169fa3-716a-464e-8744-bbe16eff78ed"));
            txtFirstGuarantorSurname = (ITTTextBox)AddControl(new Guid("d11cea6a-4b9e-4c06-8c83-350ad2bd5fba"));
            TTListBoxFirstGuarantorHomeCity = (ITTObjectListBox)AddControl(new Guid("34aa7b1e-75c4-40c3-bbc9-f94cd59c86ab"));
            lblFirstGuarantorSurname = (ITTLabel)AddControl(new Guid("731776f8-0fa8-459e-8deb-4406e71417e3"));
            txtFirstGuarantorFatherName = (ITTTextBox)AddControl(new Guid("a77588c5-ac6f-474f-a83d-8e9d9199dc19"));
            lblFirstGuarantorFatherName = (ITTLabel)AddControl(new Guid("46c314f4-5493-422e-9ca8-93e7a30bd53a"));
            txtFirstGuarantorMotherName = (ITTTextBox)AddControl(new Guid("a856ee18-e8a7-4d37-9a63-328727d7b9c9"));
            lblFirstGuarantorMotherName = (ITTLabel)AddControl(new Guid("d738612f-2250-4f5e-8e23-8ac1f2b8df21"));
            lblFirstGuarantorBirthDate = (ITTLabel)AddControl(new Guid("400efc45-2eaa-4b49-869e-8ba3ae165ed8"));
            TTListBoxFirstGuarantorCityOfBirth = (ITTObjectListBox)AddControl(new Guid("105a7dce-9aeb-464b-b054-93545deaca86"));
            TTListBoxFirstGuarantorBirthDate = (ITTDateTimePicker)AddControl(new Guid("391e519b-e8cd-45cd-a3aa-31f37273c60f"));
            lblFirstGuarantorCityOfBirth = (ITTLabel)AddControl(new Guid("012b7bc5-7431-4eb0-b1db-f3cbc8e6fd87"));
            BondDetail = (ITTTabPage)AddControl(new Guid("039dab3c-bd63-436c-9975-0bee0105228d"));
            GrdBondDetails = (ITTGrid)AddControl(new Guid("b197f019-b361-427d-b081-1a990cec8eca"));
            BDDATE = (ITTDateTimePickerColumn)AddControl(new Guid("f2c3ea87-925e-432f-8584-927baa93fafa"));
            BDPRICE = (ITTTextBoxColumn)AddControl(new Guid("e6328d0a-af28-48c9-ba54-059f6ed006dd"));
            BDPAYMENTDATE = (ITTDateTimePickerColumn)AddControl(new Guid("2bfe6381-995e-4b2a-9ffb-16587f8506a8"));
            BDDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("f085c619-356d-4524-9d1f-c438d24130a7"));
            BDBUTTONPAID = (ITTCheckBoxColumn)AddControl(new Guid("05f21524-1403-41c2-b042-a4f9bf0a8742"));
            BondProceduresTab = (ITTTabPage)AddControl(new Guid("d31103e4-98f1-4c79-8b2f-5307c7c16bf6"));
            GrdBondProcedure = (ITTGrid)AddControl(new Guid("45059406-3b7e-46e2-953d-2d0f55993890"));
            BPACTIONDATE = (ITTTextBoxColumn)AddControl(new Guid("1592c9a3-e2ae-4942-8431-880c515aac1e"));
            BPEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("279fcd7b-c72a-41f6-ad17-54397561f5ac"));
            BPAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("49a0f792-e9f8-44a3-87ca-ac9e38eccc7f"));
            BPREMAININGPRICE = (ITTTextBoxColumn)AddControl(new Guid("34057ded-545a-4182-b52b-5c1d9981f495"));
            BPTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("88b4bb96-e7d4-43ae-bdb0-39c6eceebfec"));
            BPUNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("550341a0-bcf8-4664-9cdf-2acf54c94874"));
            BPDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("d492ef0a-4dd5-42c8-864d-bc63b94ef74a"));
            grpBoxBondInfo = (ITTGroupBox)AddControl(new Guid("e4fd72b7-dead-4c98-9ce0-14d0543a1919"));
            lblRestructuredBond = (ITTLabel)AddControl(new Guid("08d30b0c-72a3-4849-bdcf-819d4c6b05f2"));
            txtRestructuredBond = (ITTTextBox)AddControl(new Guid("f7872f0c-728a-4926-8b70-95b25625596d"));
            lblAdavnceTaken = (ITTLabel)AddControl(new Guid("c9ab209d-d531-4398-b352-b03d4c0dac48"));
            txtAdvanceTaken = (ITTTextBox)AddControl(new Guid("aa248454-9659-4e51-b723-bccb3b160796"));
            btnCalcBondDetail = (ITTButton)AddControl(new Guid("04d1c810-29bc-44b5-bce2-18afbdb0e2e2"));
            lblBondPrice = (ITTLabel)AddControl(new Guid("54a1807c-c673-4ec5-84f8-5049ebc00d9b"));
            txtBondPrice = (ITTTextBox)AddControl(new Guid("906625f3-f6bf-4ad0-8e97-b6649f90ff2a"));
            lblBondDescription = (ITTLabel)AddControl(new Guid("91535855-fee6-4339-8bf2-de378a1582c2"));
            lblSecondNotificationDate = (ITTLabel)AddControl(new Guid("3e43d1de-56f4-4562-bf0c-259751e2fb53"));
            lblFirstNotificationDate = (ITTLabel)AddControl(new Guid("d3c94cf6-e381-42e8-8fcb-c24f4a1fee40"));
            lblBondDate = (ITTLabel)AddControl(new Guid("5d333d73-1afa-4237-965e-10c944c6863a"));
            lblBondNo = (ITTLabel)AddControl(new Guid("555dd777-6b71-4533-a1db-5cd845d0193c"));
            txtBondDescription = (ITTTextBox)AddControl(new Guid("7216bbd2-6ba9-4122-a4c1-c2b64eca2c10"));
            dtPickerBondDate = (ITTDateTimePicker)AddControl(new Guid("53ce77e8-9f22-4d08-ba00-500d271be1c9"));
            txtBondNo = (ITTTextBox)AddControl(new Guid("c00873ab-e09e-45c8-bb9d-e6861c34f93a"));
            dtPickerSecondNotificationDate = (ITTDateTimePicker)AddControl(new Guid("ecde7460-5492-4313-98de-f3d2176bc113"));
            dtPickerFirstNoficationDate = (ITTDateTimePicker)AddControl(new Guid("966d20ca-1b7c-44e0-8fa5-13a0c02def3b"));
            base.InitializeControls();
        }

        public BondForm() : base("BOND", "BondForm")
        {
        }

        protected BondForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}