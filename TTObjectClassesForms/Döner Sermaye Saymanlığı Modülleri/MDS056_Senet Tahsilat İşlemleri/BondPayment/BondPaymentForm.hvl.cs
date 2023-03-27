
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
    public partial class BondPaymentForm : TTForm
    {
    /// <summary>
    /// Senet Tahsilat
    /// </summary>
        protected TTObjectClasses.BondPayment _BondPayment
        {
            get { return (TTObjectClasses.BondPayment)_ttObject; }
        }

        protected ITTEnumComboBox cbxPaymentType;
        protected ITTLabel lblPaymentPrice;
        protected ITTTextBox txtPaymentPrice;
        protected ITTTextBox txtTotalPrice;
        protected ITTTextBox txtDescription;
        protected ITTTextBox txtPayeeName;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox txtDocumentNo;
        protected ITTTextBox txtCashierName;
        protected ITTTextBox txtBankDecountNo;
        protected ITTLabel lblTotalPrice;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn GRDBONDNO;
        protected ITTDateTimePickerColumn GRDBONDDETAILDATE;
        protected ITTTextBoxColumn GRDPRICE;
        protected ITTCheckBoxColumn GRDPAID;
        protected ITTLabel lblDescription;
        protected ITTLabel lblBankDecountDate;
        protected ITTDateTimePicker dtPickerBankDecountDate;
        protected ITTLabel lblBankDeceountNo;
        protected ITTLabel lblBankAccount;
        protected ITTObjectListBox lstBoxBankAccount;
        protected ITTLabel lblPaymentType;
        protected ITTLabel lblPayeeName;
        protected ITTLabel lblDocumentNo;
        protected ITTLabel lblProcessDate;
        protected ITTLabel lblCashierName;
        protected ITTLabel lblCashOfficeName;
        protected ITTDateTimePicker dtPickerDocumentDate;
        override protected void InitializeControls()
        {
            cbxPaymentType = (ITTEnumComboBox)AddControl(new Guid("5517348e-dbd0-429c-89ad-d3d607b6c327"));
            lblPaymentPrice = (ITTLabel)AddControl(new Guid("9f53a796-6e7c-4b70-ad0f-82ba2e15e6e6"));
            txtPaymentPrice = (ITTTextBox)AddControl(new Guid("e4e6ade1-7a5c-4a36-8472-8750ff11c0a7"));
            txtTotalPrice = (ITTTextBox)AddControl(new Guid("8ab38255-ede3-451c-af9a-2567593aea19"));
            txtDescription = (ITTTextBox)AddControl(new Guid("403a439f-b9f8-473d-af97-2d46f1f0c778"));
            txtPayeeName = (ITTTextBox)AddControl(new Guid("0ed6e5c6-dd11-43b4-809b-4774d5314b0f"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("84566a4d-b451-41f0-aad6-7b90460c0307"));
            txtDocumentNo = (ITTTextBox)AddControl(new Guid("0c1ab1d8-f851-4fa6-8550-140f043796e4"));
            txtCashierName = (ITTTextBox)AddControl(new Guid("067d0322-dd92-4953-b849-5bf061db5fd4"));
            txtBankDecountNo = (ITTTextBox)AddControl(new Guid("c7a93d2f-40d5-4e4f-a7d4-979cdb5429ce"));
            lblTotalPrice = (ITTLabel)AddControl(new Guid("48b45256-8953-47de-814e-2c48d464a138"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("1831fede-1f82-4844-ba62-8653fea9f734"));
            GRDBONDNO = (ITTTextBoxColumn)AddControl(new Guid("bb7be832-75a6-44ee-8239-db12c53e067a"));
            GRDBONDDETAILDATE = (ITTDateTimePickerColumn)AddControl(new Guid("a3060511-e4dd-42cb-8718-0cf643d221f1"));
            GRDPRICE = (ITTTextBoxColumn)AddControl(new Guid("aeed5c78-0fa5-434b-8505-36b3bab0b6a6"));
            GRDPAID = (ITTCheckBoxColumn)AddControl(new Guid("0b388a72-b781-4a87-acf1-2a2d1da0ea52"));
            lblDescription = (ITTLabel)AddControl(new Guid("6e061a3f-b49c-4e5d-b88e-804baa5ff77c"));
            lblBankDecountDate = (ITTLabel)AddControl(new Guid("324cbad9-6017-45f2-8b52-5a742c7b72c1"));
            dtPickerBankDecountDate = (ITTDateTimePicker)AddControl(new Guid("a5836860-a7b6-498d-92c3-d1176a1523c0"));
            lblBankDeceountNo = (ITTLabel)AddControl(new Guid("5e05d2d6-483d-434a-b4e6-5502082ac453"));
            lblBankAccount = (ITTLabel)AddControl(new Guid("e6c03e65-fa8c-4f9b-a0ee-6acbb6ee84de"));
            lstBoxBankAccount = (ITTObjectListBox)AddControl(new Guid("23db85bd-ddf0-4ba8-b1f0-9069c1ed86b0"));
            lblPaymentType = (ITTLabel)AddControl(new Guid("65f4186c-6d33-4e9a-b102-f85c897fdf3b"));
            lblPayeeName = (ITTLabel)AddControl(new Guid("85d5d04d-c074-435f-9f32-f60605957941"));
            lblDocumentNo = (ITTLabel)AddControl(new Guid("1ff8ee76-577f-4aeb-a73f-6e0802e33ea5"));
            lblProcessDate = (ITTLabel)AddControl(new Guid("77c240c8-0923-4adb-841c-176362a0056e"));
            lblCashierName = (ITTLabel)AddControl(new Guid("957554aa-c88d-405a-9f54-68f3c2db3221"));
            lblCashOfficeName = (ITTLabel)AddControl(new Guid("dab6b92c-d338-405c-8652-c9cf0046dbaf"));
            dtPickerDocumentDate = (ITTDateTimePicker)AddControl(new Guid("5e4cbaba-66fd-44c5-a1a9-80543921ac59"));
            base.InitializeControls();
        }

        public BondPaymentForm() : base("BONDPAYMENT", "BondPaymentForm")
        {
        }

        protected BondPaymentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}