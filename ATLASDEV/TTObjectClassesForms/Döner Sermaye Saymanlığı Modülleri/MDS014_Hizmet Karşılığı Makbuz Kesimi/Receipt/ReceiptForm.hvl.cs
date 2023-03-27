
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
    /// Hastadan Tahsilat
    /// </summary>
    public partial class ReceiptForm : TTForm
    {
    /// <summary>
    /// Hastadan Tahsilat İşlemi
    /// </summary>
        protected TTObjectClasses.Receipt _Receipt
        {
            get { return (TTObjectClasses.Receipt)_ttObject; }
        }

        protected ITTTextBox PATIENTNAME;
        protected ITTTextBox TOTALDISCOUNTENTRY;
        protected ITTTextBox GENERALTOTALPRICE;
        protected ITTTextBox TOTALDISCOUNTPRICE;
        protected ITTTextBox CREDITCARDDOCUMENTNO;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox txtTotalPrice;
        protected ITTTextBox RECEIPTSPECIALNO;
        protected ITTTextBox PAYEENAME;
        protected ITTTextBox CREDITCARDSPECIALNO;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox RECEIPTNO;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTEnumComboBox cbxPaymentType;
        protected ITTLabel ttlabel14;
        protected ITTCheckBox UNDETAILEDREPORT;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel2;
        protected ITTButton BUTTONDISCOUNT;
        protected ITTObjectListBox DISCOUNTTYPE;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelCashOfficeName;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelTotalPrice;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel9;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GRIDReceiptProcedures;
        protected ITTDateTimePickerColumn PACTIONDATE;
        protected ITTTextBoxColumn PEXTERNALCODE;
        protected ITTTextBoxColumn PDESCRIPTION;
        protected ITTTextBoxColumn PREVENUETYPE;
        protected ITTTextBoxColumn PAMOUNT;
        protected ITTTextBoxColumn PUNITPRICE;
        protected ITTTextBoxColumn PTOTALPRICE;
        protected ITTTextBoxColumn PREMAININGPRICE;
        protected ITTTextBoxColumn PPAYMENTPRICE;
        protected ITTCheckBoxColumn PPAID;
        protected ITTTextBoxColumn PTOTALDISCOUNTEDPRICE;
        protected ITTTextBoxColumn PTOTALDISCOUNTPRICE;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GRIDReceiptMaterials;
        protected ITTDateTimePickerColumn MACTIONDATE;
        protected ITTTextBoxColumn MEXTERNALCODE;
        protected ITTTextBoxColumn MDESCRIPTION;
        protected ITTTextBoxColumn MAMOUNT;
        protected ITTTextBoxColumn MUNITPRICE;
        protected ITTTextBoxColumn MTOTALPRICE;
        protected ITTTextBoxColumn MREMAININGPRICE;
        protected ITTTextBoxColumn MPAYMENTPRICE;
        protected ITTCheckBoxColumn MPAID;
        protected ITTTextBoxColumn MTOTALDISCOUNTEDPRICE;
        protected ITTTextBoxColumn MTOTALDISCOUNTPRICE;
        protected ITTTextBox txtTotalPayment;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel13;
        override protected void InitializeControls()
        {
            PATIENTNAME = (ITTTextBox)AddControl(new Guid("ea76e383-bfb3-4116-8869-12c92e9e99a0"));
            TOTALDISCOUNTENTRY = (ITTTextBox)AddControl(new Guid("83b3683c-fafa-4518-b207-4aa244fa6cce"));
            GENERALTOTALPRICE = (ITTTextBox)AddControl(new Guid("ac38ed5c-d655-447f-afdc-52c028a9c8e0"));
            TOTALDISCOUNTPRICE = (ITTTextBox)AddControl(new Guid("2bfba050-469c-431c-8a53-a5e80d2f2a24"));
            CREDITCARDDOCUMENTNO = (ITTTextBox)AddControl(new Guid("40bdb299-c5b0-4896-a95d-0e0bb052401d"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("ffc54060-ddbc-4d2a-909f-168d28083f87"));
            txtTotalPrice = (ITTTextBox)AddControl(new Guid("756a053b-3c65-4bad-9367-2fe3eddcd186"));
            RECEIPTSPECIALNO = (ITTTextBox)AddControl(new Guid("f5e5be56-6aa3-47d0-bc65-47fc57590605"));
            PAYEENAME = (ITTTextBox)AddControl(new Guid("443b930b-ff12-4e5a-b492-4cbb13faeab4"));
            CREDITCARDSPECIALNO = (ITTTextBox)AddControl(new Guid("fe83b457-8d04-44a5-acee-8283e4321af5"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("f30e65da-1487-4c96-b77d-86c4d7e4fe17"));
            RECEIPTNO = (ITTTextBox)AddControl(new Guid("6ecf91c7-b7bf-45c9-b6cf-af551f6e8967"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("1a1985fe-ca74-42b1-a678-c927339b2e59"));
            cbxPaymentType = (ITTEnumComboBox)AddControl(new Guid("895240ac-a73c-4802-a3a8-e5d737b55359"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("e07a01a8-36d7-465d-8320-926f9d080f1d"));
            UNDETAILEDREPORT = (ITTCheckBox)AddControl(new Guid("3c16cb7f-f04c-4c9b-9530-1182e51bd56c"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("e367c30e-762c-4c34-920a-fcbb192a4d64"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("fb673e5a-7e82-4fcc-bf02-dbc098262a7d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("16ca3de2-07bb-438a-8be9-382f15847ad1"));
            BUTTONDISCOUNT = (ITTButton)AddControl(new Guid("9f07a7fb-fdaf-4162-8875-63346148ec8f"));
            DISCOUNTTYPE = (ITTObjectListBox)AddControl(new Guid("0a131862-4c21-4bfb-884b-956e07d18845"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fbc9984b-3187-487c-b64a-acb822fa7b53"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("e8b26cde-6386-4b93-9b1e-10ce59c3a3e0"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("8743c7fe-e1a3-47af-9b89-2635ef1b31f5"));
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("d22c3c60-daa7-4046-8a6e-481d6df44995"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("097f54aa-78bb-4904-90b8-499017d6495f"));
            labelTotalPrice = (ITTLabel)AddControl(new Guid("8d4e0e72-feb0-4f3a-8f03-6c5e21ad5c39"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("7bb5fb3e-5521-4539-9e9a-9f4ec416c255"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9753aef3-44b4-4eb7-83ba-a1299a43739c"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("481232be-8c6d-481f-9299-d772ffef5cdd"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("d3c9173d-b9b6-4cba-b892-d9326334cb80"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("b45f7275-4968-4892-b91a-da5212ae10ba"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("abea3bc3-253b-4786-a060-ddb395aa3ba3"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4e5da079-ff25-49e5-963f-e35eeabc0667"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("594c4540-d2e3-4a03-b048-029d6acbe76e"));
            GRIDReceiptProcedures = (ITTGrid)AddControl(new Guid("f4acec72-cff8-4735-a61b-2700345ae733"));
            PACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("d617329d-cfdd-4c9c-82e3-4dcf9664c285"));
            PEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("b10ceb40-b9d1-4fd2-86ee-0ae58e1fd99a"));
            PDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("4eaf68e5-8e38-43d2-a65f-a14d0ff25970"));
            PREVENUETYPE = (ITTTextBoxColumn)AddControl(new Guid("8f1fe8e3-9723-48f1-a041-efa51e05149f"));
            PAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("ccddf603-3479-4b8e-b094-9a5bd2980196"));
            PUNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("8aed83e5-2a43-4f9c-b83a-a2eda856ded1"));
            PTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("bcd654f9-13c9-45a6-ad40-aff5e3434131"));
            PREMAININGPRICE = (ITTTextBoxColumn)AddControl(new Guid("4cbb9b74-29a5-43b5-951f-a983cae5fc75"));
            PPAYMENTPRICE = (ITTTextBoxColumn)AddControl(new Guid("d121bc8a-ecb8-4dd5-a988-0d9d17059338"));
            PPAID = (ITTCheckBoxColumn)AddControl(new Guid("bd64fa59-2f47-4bd9-b2c3-5ea10d6da597"));
            PTOTALDISCOUNTEDPRICE = (ITTTextBoxColumn)AddControl(new Guid("ed771c77-fa45-4a4c-bec8-141b7af7580c"));
            PTOTALDISCOUNTPRICE = (ITTTextBoxColumn)AddControl(new Guid("b125a8f1-a358-49e1-aff9-4664875bf390"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("807e0c17-083a-42be-bc19-55ff25ce22cf"));
            GRIDReceiptMaterials = (ITTGrid)AddControl(new Guid("38e8f50a-9f7a-4934-9aea-66f47b17a9db"));
            MACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("00e89a66-6712-4854-a84d-e0bb46b92edf"));
            MEXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("932c20b3-b5cc-4096-a7a6-7beec37a5618"));
            MDESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("f8464810-eedd-4816-8b5d-f6dfbb9df278"));
            MAMOUNT = (ITTTextBoxColumn)AddControl(new Guid("f8c76d80-a897-46f9-a0a7-6458655849b3"));
            MUNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("a52cc415-ab6c-4022-88b5-4d0dc47bbb86"));
            MTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("ae279165-6986-4b3a-b3b3-88a95819d131"));
            MREMAININGPRICE = (ITTTextBoxColumn)AddControl(new Guid("9d0a8d38-5232-48bf-8184-dff0a6c11a56"));
            MPAYMENTPRICE = (ITTTextBoxColumn)AddControl(new Guid("ee82e93d-51a1-49f2-85fc-8fc3817b5627"));
            MPAID = (ITTCheckBoxColumn)AddControl(new Guid("33c457c7-4533-4b4e-92e5-1c47acd032c8"));
            MTOTALDISCOUNTEDPRICE = (ITTTextBoxColumn)AddControl(new Guid("75ba0fd5-06de-4da1-8a56-a489a3c78c4d"));
            MTOTALDISCOUNTPRICE = (ITTTextBoxColumn)AddControl(new Guid("48899e42-db10-49bf-84e0-4132887bb430"));
            txtTotalPayment = (ITTTextBox)AddControl(new Guid("67c819ca-ea58-4aec-9cf9-abbb49ac22e7"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("840ff1a7-a670-4c7f-bdcb-028bcfe97d19"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("83c2707e-345d-43c9-90dd-88915192572e"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("8577c6ee-ae6b-464a-812a-245d487e81de"));
            base.InitializeControls();
        }

        public ReceiptForm() : base("RECEIPT", "ReceiptForm")
        {
        }

        protected ReceiptForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}