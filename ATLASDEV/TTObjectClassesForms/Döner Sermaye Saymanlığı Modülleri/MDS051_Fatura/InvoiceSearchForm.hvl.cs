
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
    public partial class InvoiceSearchForm : TTUnboundForm
    {
        protected ITTPanel ttpanel2;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn EpisodeNo;
        protected ITTTextBoxColumn NameSurname;
        protected ITTTextBoxColumn TC;
        protected ITTTextBoxColumn ProvisionDate;
        protected ITTTextBoxColumn HospDate;
        protected ITTTextBoxColumn HospLeaveDate;
        protected ITTTextBoxColumn ApplicationNo;
        protected ITTTextBoxColumn ProvisionNo;
        protected ITTTextBoxColumn InvoiceNo;
        protected ITTTextBoxColumn InvoiceTotalPrice;
        protected ITTTextBoxColumn InvoiceReadPrice;
        protected ITTTextBoxColumn AtlasTotalInvoicePrice;
        protected ITTTextBoxColumn DifPrice;
        protected ITTTextBoxColumn Ressectiion;
        protected ITTTextBoxColumn Doctor;
        protected ITTTextBoxColumn InvoiceCollectionNo;
        protected ITTTextBoxColumn TedaviTuru;
        protected ITTPanel ttpanel1;
        protected ITTListDefComboBox cbTedaviTipi;
        protected ITTButton btnSearch;
        protected ITTListDefComboBox cbResbuilding;
        protected ITTListDefComboBox cbPayerType;
        protected ITTLabel ttlabel37;
        protected ITTComboBox ttcombobox1;
        protected ITTLabel ttlabel36;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel35;
        protected ITTEnumComboBox cbSepState;
        protected ITTLabel ttlabel34;
        protected ITTDateTimePicker SubepisodeOpeninglasstDate;
        protected ITTLabel ttlabel33;
        protected ITTDateTimePicker SubepisodeOpeningFirstDate;
        protected ITTLabel ttlabel32;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tbTcNo;
        protected ITTDateTimePicker dtpHospLaststDate;
        protected ITTTextBox tbPatientSurname;
        protected ITTDateTimePicker dtpHospFirstDate;
        protected ITTTextBox tbPatientName;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tbHospitalizationNo;
        protected ITTDateTimePicker dtpHospLastDate;
        protected ITTTextBox tbProthocolNo;
        protected ITTDateTimePicker dtpHospLeaveFirstDate;
        protected ITTTextBox tbProvisionNo;
        protected ITTLabel lblLeaveDate;
        protected ITTLabel ttlabel31;
        protected ITTListDefComboBox cbInvoiceTerm;
        protected ITTEnumComboBox ttenumcombobox18;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel30;
        protected ITTLabel lblTedaviTipi;
        protected ITTEnumComboBox ttenumcombobox17;
        protected ITTLabel ttlabel29;
        protected ITTListDefComboBox cbTedaviTuru;
        protected ITTEnumComboBox ttenumcombobox16;
        protected ITTLabel lblTedaviTuru;
        protected ITTLabel ttlabel28;
        protected ITTListDefComboBox cbTakipTipi;
        protected ITTEnumComboBox ttenumcombobox15;
        protected ITTLabel lblTakipTipi;
        protected ITTLabel ttlabel27;
        protected ITTListDefComboBox cbProvizyonTipi;
        protected ITTEnumComboBox ttenumcombobox14;
        protected ITTLabel lblProvizyonTipi;
        protected ITTLabel ttlabel25;
        protected ITTObjectListBox lbPayer;
        protected ITTEnumComboBox ttenumcombobox13;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel26;
        protected ITTObjectListBox lbBranch;
        protected ITTObjectListBox lbDoctor;
        protected ITTLabel ttlabel11;
        protected ITTEnumComboBox ttenumcombobox5;
        protected ITTObjectListBox lbRessource;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox lbDiagnosis;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel24;
        protected ITTLabel ttlabel13;
        protected ITTEnumComboBox ttenumcombobox12;
        protected ITTEnumComboBox cbInvoiceBlockState;
        protected ITTEnumComboBox cbMaterialGroupDefinition;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel23;
        protected ITTObjectListBox lbMaterialGroupDefinition;
        protected ITTEnumComboBox ttenumcombobox6;
        protected ITTEnumComboBox cbMaterialDefinition;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel22;
        protected ITTEnumComboBox ttenumcombobox7;
        protected ITTObjectListBox lbMaterialDefinition;
        protected ITTLabel ttlabel19;
        protected ITTEnumComboBox cbProcedureDefinition2;
        protected ITTObjectListBox lbProcedureDefinition1;
        protected ITTLabel ttlabel21;
        protected ITTLabel ttlabel20;
        protected ITTObjectListBox lbProcedureDefinition2;
        protected ITTEnumComboBox cbProcedureDefinition1;
        protected ITTLabel ttlabel17;
        override protected void InitializeControls()
        {
            ttpanel2 = (ITTPanel)AddControl(new Guid("38bc3b7f-72b3-4aa6-ba8a-b7e0e7322e46"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("4e2e7cb6-9aef-4524-8435-9b0d50132cdb"));
            EpisodeNo = (ITTTextBoxColumn)AddControl(new Guid("64ab0339-ff05-4337-9167-dc1a7c8d425b"));
            NameSurname = (ITTTextBoxColumn)AddControl(new Guid("b8ac7d67-49df-4337-b6fb-5a37078d2725"));
            TC = (ITTTextBoxColumn)AddControl(new Guid("3ed3a92e-a1f4-4ce5-a0ea-fccf2bf5fe9f"));
            ProvisionDate = (ITTTextBoxColumn)AddControl(new Guid("e857eb12-55e8-4645-bd5c-949b570b7cb4"));
            HospDate = (ITTTextBoxColumn)AddControl(new Guid("98a96aaa-39b5-4429-bc97-4c965896d65c"));
            HospLeaveDate = (ITTTextBoxColumn)AddControl(new Guid("6437b036-02b8-4551-98f5-b5af7fcb4c01"));
            ApplicationNo = (ITTTextBoxColumn)AddControl(new Guid("8266a882-2deb-413a-9715-25d619256fc2"));
            ProvisionNo = (ITTTextBoxColumn)AddControl(new Guid("382eed1b-d81a-4e46-982c-cb13c349f271"));
            InvoiceNo = (ITTTextBoxColumn)AddControl(new Guid("03ab8498-e9b8-4313-af56-17908552cb28"));
            InvoiceTotalPrice = (ITTTextBoxColumn)AddControl(new Guid("cf3500e6-e5d7-4ece-a823-bfd5ba793396"));
            InvoiceReadPrice = (ITTTextBoxColumn)AddControl(new Guid("3f456175-b67c-40c0-adc1-8bf4644b8f1c"));
            AtlasTotalInvoicePrice = (ITTTextBoxColumn)AddControl(new Guid("9c338e7d-bb0e-4088-bebb-465bdc6866a5"));
            DifPrice = (ITTTextBoxColumn)AddControl(new Guid("a67ea440-b328-4cfd-bd4f-356f452c1c07"));
            Ressectiion = (ITTTextBoxColumn)AddControl(new Guid("463f08a2-c785-4697-a987-eebd26e8168a"));
            Doctor = (ITTTextBoxColumn)AddControl(new Guid("3e02e016-029a-4a4d-8f12-4eca29132cbc"));
            InvoiceCollectionNo = (ITTTextBoxColumn)AddControl(new Guid("fc556050-be94-490d-8fc6-56c171310a25"));
            TedaviTuru = (ITTTextBoxColumn)AddControl(new Guid("2c672c1d-d48a-40bd-9d10-e9af5c93c984"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("bdcd9def-3d66-4a21-a8fb-ab412f830160"));
            cbTedaviTipi = (ITTListDefComboBox)AddControl(new Guid("17e2d262-4acb-4cbe-bb6f-c659d2fada78"));
            btnSearch = (ITTButton)AddControl(new Guid("055de8e7-c6f8-471d-b938-811cd173aa5d"));
            cbResbuilding = (ITTListDefComboBox)AddControl(new Guid("9580c105-347d-4d62-b39f-33de042f7352"));
            cbPayerType = (ITTListDefComboBox)AddControl(new Guid("1092b1cf-a37e-405e-b323-6582d0ff7e50"));
            ttlabel37 = (ITTLabel)AddControl(new Guid("9f42c9ce-3c7b-4c73-b2ec-1fd6c7248172"));
            ttcombobox1 = (ITTComboBox)AddControl(new Guid("a82dc626-918e-4d61-bd29-62850762121c"));
            ttlabel36 = (ITTLabel)AddControl(new Guid("5e4c1d1f-93af-4ca2-95ca-863400d43f49"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("ef3b042d-c77c-4e80-a240-23e3e3057042"));
            ttlabel35 = (ITTLabel)AddControl(new Guid("32c5675a-34fe-43ff-97a3-f815e409e836"));
            cbSepState = (ITTEnumComboBox)AddControl(new Guid("53af881d-9126-4099-bbbe-ec6c1aa7753d"));
            ttlabel34 = (ITTLabel)AddControl(new Guid("30666992-6c18-448e-a3f9-12b1d7a16430"));
            SubepisodeOpeninglasstDate = (ITTDateTimePicker)AddControl(new Guid("2ccbe6bc-2a03-4a16-b9b9-31de5455584a"));
            ttlabel33 = (ITTLabel)AddControl(new Guid("928b9cfa-52ca-4a21-8dd2-b3ddfa422aee"));
            SubepisodeOpeningFirstDate = (ITTDateTimePicker)AddControl(new Guid("f1bee9fd-a7c9-4f79-ad96-df30484cda1b"));
            ttlabel32 = (ITTLabel)AddControl(new Guid("579a4d9e-ef53-41d5-ba79-f1810362acb4"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("4eb8b56e-24aa-4737-818b-f87a8ac17636"));
            tbTcNo = (ITTTextBox)AddControl(new Guid("7afdcf76-1728-4195-8b2e-dbedce0e5bd7"));
            dtpHospLaststDate = (ITTDateTimePicker)AddControl(new Guid("9081d446-cb75-4a30-ac24-a71789632bd1"));
            tbPatientSurname = (ITTTextBox)AddControl(new Guid("d7480806-98d8-4dc0-b374-b53485fadcfa"));
            dtpHospFirstDate = (ITTDateTimePicker)AddControl(new Guid("27b69c47-da95-4655-8698-f3cbd16b1216"));
            tbPatientName = (ITTTextBox)AddControl(new Guid("b9ac112a-612c-4c9a-b05e-b51c45cd9d95"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3a2bfc5c-380e-4c0f-905e-040d155968c9"));
            tbHospitalizationNo = (ITTTextBox)AddControl(new Guid("77dc339c-20f7-4331-b690-f77b07e9dbf3"));
            dtpHospLastDate = (ITTDateTimePicker)AddControl(new Guid("4dd1fdb9-cf23-4c48-bc7d-8a7c7cb99180"));
            tbProthocolNo = (ITTTextBox)AddControl(new Guid("66a73c7b-b335-4265-8f15-e073e3a06437"));
            dtpHospLeaveFirstDate = (ITTDateTimePicker)AddControl(new Guid("654a8c6c-ff6b-4925-9b1b-9b611f1d8d5f"));
            tbProvisionNo = (ITTTextBox)AddControl(new Guid("ff34e4d0-352c-4288-a9dd-0ebac6db5fcb"));
            lblLeaveDate = (ITTLabel)AddControl(new Guid("18c0f6ee-e5fb-4e95-bf6f-479093de203e"));
            ttlabel31 = (ITTLabel)AddControl(new Guid("3efead13-0ad1-4a08-9208-c69ad7b81e86"));
            cbInvoiceTerm = (ITTListDefComboBox)AddControl(new Guid("f039ba15-9410-4699-a324-5336dfffe2b0"));
            ttenumcombobox18 = (ITTEnumComboBox)AddControl(new Guid("e3318f0f-eda9-4566-82d8-3f9317d4d58f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1f7f5dbf-7c10-4d42-ac6e-66ec9f2a7f8b"));
            ttlabel30 = (ITTLabel)AddControl(new Guid("9ef22dac-102e-466c-94fd-98ecdf6ee476"));
            lblTedaviTipi = (ITTLabel)AddControl(new Guid("8780a547-b3e8-4409-b112-84c327bafc1a"));
            ttenumcombobox17 = (ITTEnumComboBox)AddControl(new Guid("1d7c84f2-3d45-4810-af10-3c97df8600ff"));
            ttlabel29 = (ITTLabel)AddControl(new Guid("297ca27f-8680-40e6-afac-26a87903443f"));
            cbTedaviTuru = (ITTListDefComboBox)AddControl(new Guid("626f601b-7350-4b50-b409-c08ace1d564c"));
            ttenumcombobox16 = (ITTEnumComboBox)AddControl(new Guid("1abe3793-9281-46a3-a9c2-d401bd774dda"));
            lblTedaviTuru = (ITTLabel)AddControl(new Guid("9314fceb-f14b-45f8-83e0-38c8c0a5ea52"));
            ttlabel28 = (ITTLabel)AddControl(new Guid("d71e7805-d0cb-4a99-9ca3-7ef614e4781d"));
            cbTakipTipi = (ITTListDefComboBox)AddControl(new Guid("5433888c-5015-4427-b06e-2455419071c2"));
            ttenumcombobox15 = (ITTEnumComboBox)AddControl(new Guid("de5dc6ff-ab4b-42a5-8221-91b2c77215d6"));
            lblTakipTipi = (ITTLabel)AddControl(new Guid("528b8afd-e188-4896-9763-de33269c8caa"));
            ttlabel27 = (ITTLabel)AddControl(new Guid("5cf7750f-916f-4f36-ac52-7a3ebd2c477e"));
            cbProvizyonTipi = (ITTListDefComboBox)AddControl(new Guid("753f01de-843a-4d14-9793-86dd198e8ed7"));
            ttenumcombobox14 = (ITTEnumComboBox)AddControl(new Guid("c3fc2c32-fbca-42bf-9104-02b6673587c3"));
            lblProvizyonTipi = (ITTLabel)AddControl(new Guid("e4443c0d-849f-4154-80fc-a75f9e8dbe41"));
            ttlabel25 = (ITTLabel)AddControl(new Guid("b29f6ee1-e52d-44e6-8dbd-386636951f99"));
            lbPayer = (ITTObjectListBox)AddControl(new Guid("8e233bff-2de9-4b4d-a1ee-315f3c7b787d"));
            ttenumcombobox13 = (ITTEnumComboBox)AddControl(new Guid("3271d1d3-cbd2-40be-b1be-a821e5c350d4"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("e451a350-4e94-4981-82e3-558777fdbea9"));
            ttlabel26 = (ITTLabel)AddControl(new Guid("2e069340-9e4e-429d-86d6-d7f395fac6e6"));
            lbBranch = (ITTObjectListBox)AddControl(new Guid("f64c1293-461a-4623-9479-25fcda67bf05"));
            lbDoctor = (ITTObjectListBox)AddControl(new Guid("5731ad73-6a28-4915-b817-c56bbc1991b3"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("23e5e11f-d9ce-482b-92a5-f823bbce64c0"));
            ttenumcombobox5 = (ITTEnumComboBox)AddControl(new Guid("64a22be2-8595-47d7-8555-1cdf39c93657"));
            lbRessource = (ITTObjectListBox)AddControl(new Guid("52d7adf5-cfb8-4875-9902-d92b500d71d2"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("7a34b88b-2223-44f2-a0ee-034abc68d225"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("a0493c7f-8f6c-4c57-b45f-622c31b80dab"));
            lbDiagnosis = (ITTObjectListBox)AddControl(new Guid("7365270e-2b62-43f2-9cdb-ac4a649872b5"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("32bb665f-5b6c-4dfc-b57c-556f420bad2c"));
            ttlabel24 = (ITTLabel)AddControl(new Guid("6cfae283-6f89-4eac-9825-6ade4bb1894c"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("ce69c69c-d93d-4d06-a2e8-7422ebbfaf5b"));
            ttenumcombobox12 = (ITTEnumComboBox)AddControl(new Guid("2cf4b01c-585b-494a-a715-d1a5f06f10b1"));
            cbInvoiceBlockState = (ITTEnumComboBox)AddControl(new Guid("3c037811-873c-4bc2-ab56-d6d324f1a288"));
            cbMaterialGroupDefinition = (ITTEnumComboBox)AddControl(new Guid("0d5c3e53-825d-4ecd-8d75-168f9bedd30b"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("d0bbff2b-501f-4166-a282-bc36613a6c4a"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("609df7f9-797c-4822-8617-9e6ac8bffe9d"));
            lbMaterialGroupDefinition = (ITTObjectListBox)AddControl(new Guid("703083db-a83d-4fd1-971f-fa9f4d8825d8"));
            ttenumcombobox6 = (ITTEnumComboBox)AddControl(new Guid("89c29f13-baf3-42d3-bd56-1f2259254d15"));
            cbMaterialDefinition = (ITTEnumComboBox)AddControl(new Guid("db4c67d3-3a8b-403b-b2c8-5c09f1a1326a"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("4b95d774-fee4-4a38-b80c-4588e8a00355"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("99fc10f7-3160-4feb-a03f-44ba767f4d2b"));
            ttenumcombobox7 = (ITTEnumComboBox)AddControl(new Guid("b4bb7ab9-9404-43bd-b9e4-b232cb8dbed2"));
            lbMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("b7bcf1d3-84bd-46e6-bec4-3698468d3e6c"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("0476e3c9-adfc-47a7-bb19-d25df4ed1d00"));
            cbProcedureDefinition2 = (ITTEnumComboBox)AddControl(new Guid("62485c38-f8e0-4d07-903d-babecbaa9b2d"));
            lbProcedureDefinition1 = (ITTObjectListBox)AddControl(new Guid("e8275e8c-cc55-4617-852b-38fddea94c31"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("cc936467-e15f-4650-951e-900af6f2743f"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("dfdbc618-ce09-4e4a-aeab-74a27ae81c9f"));
            lbProcedureDefinition2 = (ITTObjectListBox)AddControl(new Guid("c1d47a0c-6411-435d-90a8-3c34db1cec37"));
            cbProcedureDefinition1 = (ITTEnumComboBox)AddControl(new Guid("d8587458-24cf-44b2-a07e-d48f0426f314"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("d9741e77-8736-4ada-8d33-792c9ec31029"));
            base.InitializeControls();
        }

        public InvoiceSearchForm() : base("InvoiceSearchForm")
        {
        }

        protected InvoiceSearchForm(string formDefName) : base(formDefName)
        {
        }
    }
}