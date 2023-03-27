
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
    /// Diğer Tahsilat İşlemleri
    /// </summary>
    public partial class MainCashOfficeOperationForm : TTForm
    {
    /// <summary>
    /// Vezne Tahsilat İşlemi
    /// </summary>
        protected TTObjectClasses.MainCashOfficeOperation _MainCashOfficeOperation
        {
            get { return (TTObjectClasses.MainCashOfficeOperation)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel15;
        protected ITTTextBox tttextbox8;
        protected ITTLabel ttlabel12;
        protected ITTTextBox tttextbox7;
        protected ITTLabel ttlabel5;
        protected ITTTextBox tttextbox6;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox BANKDECOUNTNO;
        protected ITTTextBox RECEIPTNO;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox Description;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox RECEIPTSPECIALNO;
        protected ITTTextBox TOTALPRICE;
        protected ITTLabel ttlabel17;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel14;
        protected ITTEnumComboBox cbxPaymentType;
        protected ITTGrid CashierLogsGrid;
        protected ITTTextBoxColumn LOGID;
        protected ITTDateTimePickerColumn OPENINGDATE;
        protected ITTDateTimePickerColumn CLOSINGDATE;
        protected ITTTextBoxColumn CASHOFFICE;
        protected ITTTextBoxColumn RESUSER;
        protected ITTTextBoxColumn SUBMITTEDTOTAL;
        protected ITTCheckBoxColumn SUBMIT;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox MONEYRECEIVEDTYPE;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelCashOfficeName;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTObjectListBox BANKACCOUNT;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel19;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTDateTimePicker BANKDECOUNTDATE;
        protected ITTLabel lblBankDecountDate;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("15295dcb-f42e-45a2-846e-7d4574e858f3"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("6eaf9d66-ba66-4e2a-951f-a13c1e8a8b2a"));
            tttextbox8 = (ITTTextBox)AddControl(new Guid("4493cfeb-0683-4880-af61-c7de63fa1ad4"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("0dbef723-c0ea-40ce-990b-d025b95a71ff"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("807430be-f66d-487a-853e-6590f3591e20"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("12736318-5050-4b72-988a-53ab9f280a52"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("4f418dae-1e76-4446-a630-42f57c6055a5"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("7742a24f-b89f-42d1-a50d-70c8624a8027"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("1c2ec8fb-c502-4ed7-a122-e5f4e3f77233"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("24aa361f-f00a-44f5-9167-3474a631d3c5"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("2849a894-71f0-4f85-a66d-0e7b33a9cc91"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("16bae3a4-f3b6-4f12-bb68-fdbb96753de6"));
            BANKDECOUNTNO = (ITTTextBox)AddControl(new Guid("373d2982-961f-4526-b559-e4c77568fe5a"));
            RECEIPTNO = (ITTTextBox)AddControl(new Guid("15e9cb25-188e-4afe-883a-2385f157ce03"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("12d7cbe2-277d-486e-81a2-3c9b730dc323"));
            Description = (ITTTextBox)AddControl(new Guid("36eb4d6b-c4de-4391-9b23-4202eec2856f"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("e810769d-bde4-4abf-b3ac-a6292d726450"));
            RECEIPTSPECIALNO = (ITTTextBox)AddControl(new Guid("01bb00d9-9f5c-4cff-90a4-f51ebd610a5e"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("c9299c74-3003-44d7-86eb-f7617445e027"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("9350ac57-7118-4be5-ad58-80262c0d2e0b"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("24892a77-8f1b-474a-9b83-e65513eabd8e"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("c3a405d4-4419-48e8-b8b9-d911974376e8"));
            cbxPaymentType = (ITTEnumComboBox)AddControl(new Guid("bf460710-6f0a-4227-acf9-bb84ec7c7c71"));
            CashierLogsGrid = (ITTGrid)AddControl(new Guid("67ff3fbf-4ea1-4b0a-b4a7-e704cf005575"));
            LOGID = (ITTTextBoxColumn)AddControl(new Guid("14322878-907a-4f56-8b1b-7a59acd769d4"));
            OPENINGDATE = (ITTDateTimePickerColumn)AddControl(new Guid("2ba134b3-787a-45ce-a8c8-5bd692b0ea2d"));
            CLOSINGDATE = (ITTDateTimePickerColumn)AddControl(new Guid("150d2250-a7e3-4a48-8fd1-789a46d02a8f"));
            CASHOFFICE = (ITTTextBoxColumn)AddControl(new Guid("a2a83853-78b7-43c6-a369-779c70cddaf7"));
            RESUSER = (ITTTextBoxColumn)AddControl(new Guid("42a9b96e-dde7-43f6-8419-e21769109e58"));
            SUBMITTEDTOTAL = (ITTTextBoxColumn)AddControl(new Guid("f799104e-3826-4832-95c7-00f1f3bdff58"));
            SUBMIT = (ITTCheckBoxColumn)AddControl(new Guid("c74fa303-fbcc-4d3f-9ed9-290a54ee3780"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("829ba451-006c-4fdd-b985-03be3d570d65"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e86f3c2f-d2e0-4cea-812f-41e84ae13060"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("fb7c008a-195a-486f-961f-454fa606f495"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("cf1ee877-e5fb-4923-aa10-4708e7c8834b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("00494dcf-edbc-4b50-9f84-5a30c7e9b2b8"));
            MONEYRECEIVEDTYPE = (ITTObjectListBox)AddControl(new Guid("e5c05c0a-5c05-41db-81e2-6c8d117186f6"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9af74b00-f9c3-4c5c-a30c-ac335fb83ef4"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("805a024e-5407-4c2c-813c-ac6d839f66df"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("c6c9132d-5429-474c-8654-c28cda57c068"));
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("337ac3a9-41db-4cba-999a-df165cfba0c7"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("a640eac3-aaf7-42dd-a856-f72b7f4f4318"));
            BANKACCOUNT = (ITTObjectListBox)AddControl(new Guid("8b356de2-9f4c-4603-912b-e8e2327e1f63"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("a3cf12d6-ec9f-468d-8104-357589615e41"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("92f64ec1-73ca-48ba-8947-21373e0ef4bf"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("409dfd47-58f9-4ff0-90bc-3fd291fa6b40"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("e1d13324-4407-4122-88fd-b722b77b8d87"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("f6417ae8-0581-4781-aac5-4c491d97f05b"));
            BANKDECOUNTDATE = (ITTDateTimePicker)AddControl(new Guid("d8b6d766-f693-4e3b-8282-a547f99b69ff"));
            lblBankDecountDate = (ITTLabel)AddControl(new Guid("89c97e39-47c8-4508-99b6-c6a5672c3fc9"));
            base.InitializeControls();
        }

        public MainCashOfficeOperationForm() : base("MAINCASHOFFICEOPERATION", "MainCashOfficeOperationForm")
        {
        }

        protected MainCashOfficeOperationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}