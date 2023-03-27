
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
    /// Makbuz İade İşlemi
    /// </summary>
    public partial class ReceiptBackForm : TTForm
    {
    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade işlemi
    /// </summary>
        protected TTObjectClasses.ReceiptBack _ReceiptBack
        {
            get { return (TTObjectClasses.ReceiptBack)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox lstBoxReceipts;
        protected ITTDateTimePicker DATEOFRETURN;
        protected ITTLabel labelOfficerName;
        protected ITTTextBox RECEIPTTOTALPRICE;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelCashierLogId;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GRIDReceiptBackDetails;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTTextBoxColumn EXTERNALCODE;
        protected ITTTextBoxColumn Description;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UNITPRICE;
        protected ITTTextBoxColumn TOTALPRICE;
        protected ITTTextBoxColumn PAYMENTPRICE;
        protected ITTTextBoxColumn STATE;
        protected ITTCheckBoxColumn RETURN;
        protected ITTTextBoxColumn TOTALDISCOUNTEDPRICE;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox RETURNTOTALPRICE;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox REASONOFRETURN;
        protected ITTTextBox RECEIPTNO;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel8;
        protected ITTButton BTNLISTDETAIL;
        protected ITTLabel labelCashOfficeName;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("94be88aa-9fd9-4ad7-95f2-5eaf650ed761"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5a0ee4b8-e3f0-4d48-99b4-931d38674ca0"));
            lstBoxReceipts = (ITTObjectListBox)AddControl(new Guid("b9d40a97-0643-4b0c-aaf6-0a43ca9558e9"));
            DATEOFRETURN = (ITTDateTimePicker)AddControl(new Guid("27459991-9bee-4a7c-ad9f-0a9f02bff4ca"));
            labelOfficerName = (ITTLabel)AddControl(new Guid("be05c0bd-faeb-4dd2-8a03-12088530c176"));
            RECEIPTTOTALPRICE = (ITTTextBox)AddControl(new Guid("5273b209-6632-4c10-9b5d-1cdb4485cfe8"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c6a4a3a8-3342-4ce6-98e4-28f1eefe4382"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("13c21ed0-c5ab-472d-9176-291497b05cca"));
            labelCashierLogId = (ITTLabel)AddControl(new Guid("7be3fb68-66de-485c-b722-2e6373566686"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6d1964f5-1048-47df-b27b-451160fca8ec"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("623cbecb-c7a5-46d3-92b8-86ce65ceeb9b"));
            GRIDReceiptBackDetails = (ITTGrid)AddControl(new Guid("d432a7e1-30cf-4fa4-92b2-7da07f5d1bdf"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("c6c4b1c5-982f-4166-a330-a4502919b841"));
            EXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("4f84b80e-7105-422d-84ec-de93debd8cb3"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("21d20881-0d28-4e69-81fa-e1a23b22a1f0"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("158f6e1b-03a0-4288-8f57-bebf472f4ca6"));
            UNITPRICE = (ITTTextBoxColumn)AddControl(new Guid("b77d87c6-a544-47a9-a059-a1d07a2d2a41"));
            TOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("47c67681-c843-40ea-a4a6-9ded3284b0fc"));
            PAYMENTPRICE = (ITTTextBoxColumn)AddControl(new Guid("fcb0b64e-cb31-4e36-ad93-b64b5a81c3e7"));
            STATE = (ITTTextBoxColumn)AddControl(new Guid("4fa630e5-0891-4956-90a9-d5f42a6ef517"));
            RETURN = (ITTCheckBoxColumn)AddControl(new Guid("391cc19a-22fa-4a8c-af0b-7c7b314fb6f5"));
            TOTALDISCOUNTEDPRICE = (ITTTextBoxColumn)AddControl(new Guid("7fe93dca-9eaf-44d4-8099-ca809b7b5ddf"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("3608f2fb-e981-4f4f-97a7-4f97faf2315e"));
            RETURNTOTALPRICE = (ITTTextBox)AddControl(new Guid("1b4935f8-1725-48ae-8157-77660df85d06"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("d805cfa9-db0e-4ecd-b838-9f97db2aa261"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("6af34b4a-de88-44b0-9a73-b180a042a1cd"));
            REASONOFRETURN = (ITTTextBox)AddControl(new Guid("0f5def54-cb45-4267-ac28-bd2b173f4125"));
            RECEIPTNO = (ITTTextBox)AddControl(new Guid("6944b239-fa0f-412e-8773-c49b853c4d02"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ad012974-ae15-4178-a26a-461e4bbc76eb"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("764476e6-a73f-4e89-a284-5e6ae80cb792"));
            BTNLISTDETAIL = (ITTButton)AddControl(new Guid("8596b93a-b030-4832-99be-da78f49a245a"));
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("61cc6c8e-d922-40ff-a796-eff35f0e0063"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1a7a566a-2485-4441-b052-f0264be91343"));
            base.InitializeControls();
        }

        public ReceiptBackForm() : base("RECEIPTBACK", "ReceiptBackForm")
        {
        }

        protected ReceiptBackForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}