
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
    /// Kurum Tanımı
    /// </summary>
    public partial class PayerForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kurum Tanımlama
    /// </summary>
        protected TTObjectClasses.PayerDefinition _PayerDefinition
        {
            get { return (TTObjectClasses.PayerDefinition)_ttObject; }
        }

        protected ITTCheckBox SelectInPatientAdmission;
        protected ITTEnumComboBox MIFType;
        protected ITTLabel lblMIFType;
        protected ITTCheckBox HealthTourism;
        protected ITTCheckBox OnlineInvoice;
        protected ITTLabel labelMedulaDevredilenKurum;
        protected ITTObjectListBox MedulaDevredilenKurum;
        protected ITTObjectListBox RevenueSubAccountCode;
        protected ITTTextBox PaymentDayLimit;
        protected ITTTextBox FAXNUMBER;
        protected ITTTextBox TAXNUMBER;
        protected ITTTextBox LIMITOFINVOICESUMMARYLIST;
        protected ITTTextBox TAXOFFICE;
        protected ITTTextBox DAYOFSENT;
        protected ITTTextBox ID;
        protected ITTTextBox ZIPCODE;
        protected ITTTextBox ADDRESS;
        protected ITTTextBox NAME;
        protected ITTTextBox CODE;
        protected ITTTextBox PHONENUMBER;
        protected ITTLabel lblPaymentDayLimit;
        protected ITTGrid grdProtocols;
        protected ITTListBoxColumn Protocol;
        protected ITTDateTimePickerColumn ProtocolStartDate;
        protected ITTDateTimePickerColumn ProtocolEndDate;
        protected ITTLabel lblProtocols;
        protected ITTObjectListBox CITY;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox Active;
        protected ITTObjectListBox PAYERTYPE;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel TTLabel15;
        protected ITTLabel TTLabel14;
        protected ITTLabel TTLabel13;
        protected ITTObjectListBox PARENTPAYER;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel17;
        protected ITTCheckBox GetPatientParticipation;
        protected ITTCheckBox CancelPatientShareAccTrx;
        override protected void InitializeControls()
        {
            SelectInPatientAdmission = (ITTCheckBox)AddControl(new Guid("629be5fa-9441-48e4-a7c0-f5c57ca57130"));
            MIFType = (ITTEnumComboBox)AddControl(new Guid("2e08d86c-f781-4967-aec5-716b87d2da28"));
            lblMIFType = (ITTLabel)AddControl(new Guid("5c9b4768-8f0f-4021-ac49-450661fa0aec"));
            HealthTourism = (ITTCheckBox)AddControl(new Guid("646e14b6-d78a-447f-b106-609e37c141d8"));
            OnlineInvoice = (ITTCheckBox)AddControl(new Guid("faf6bbde-4545-40c3-a480-977338900be8"));
            labelMedulaDevredilenKurum = (ITTLabel)AddControl(new Guid("cd4712b0-a39d-4049-91b0-34d63e98bb11"));
            MedulaDevredilenKurum = (ITTObjectListBox)AddControl(new Guid("47a795c3-8f0d-4aca-83cd-3ecba6a4b08f"));
            RevenueSubAccountCode = (ITTObjectListBox)AddControl(new Guid("6576de81-e917-4576-8370-4fede3a95b55"));
            PaymentDayLimit = (ITTTextBox)AddControl(new Guid("938e7ea0-50a1-4866-9975-82b4f2c7bc85"));
            FAXNUMBER = (ITTTextBox)AddControl(new Guid("4ef64561-7fe0-4ada-9154-43ec26ac875e"));
            TAXNUMBER = (ITTTextBox)AddControl(new Guid("ad0a3441-ba00-41c6-ad52-7f57b59d4d92"));
            LIMITOFINVOICESUMMARYLIST = (ITTTextBox)AddControl(new Guid("7b88695d-3701-424a-bef3-88e9f739b20b"));
            TAXOFFICE = (ITTTextBox)AddControl(new Guid("1d4eccd1-988d-4627-9c84-8a0b14f55abe"));
            DAYOFSENT = (ITTTextBox)AddControl(new Guid("aedecfcf-caac-418b-bb4b-a75aeb37d5de"));
            ID = (ITTTextBox)AddControl(new Guid("935c7882-5008-4ba9-a03d-ae33b15e56db"));
            ZIPCODE = (ITTTextBox)AddControl(new Guid("61fa009a-7543-41e3-8627-d140c8d3d4cf"));
            ADDRESS = (ITTTextBox)AddControl(new Guid("d074f650-45db-439b-aa90-ddf98e0f19b1"));
            NAME = (ITTTextBox)AddControl(new Guid("a58f5b4a-5c71-4936-be1d-f14700da9395"));
            CODE = (ITTTextBox)AddControl(new Guid("0b30cef1-02d8-495d-bc84-f2522d8580fe"));
            PHONENUMBER = (ITTTextBox)AddControl(new Guid("015f725d-629c-44b9-8628-feab80dbe661"));
            lblPaymentDayLimit = (ITTLabel)AddControl(new Guid("309c1f8a-846f-4d9c-b86b-03f81f95c603"));
            grdProtocols = (ITTGrid)AddControl(new Guid("b0d03859-594d-4a14-bf14-398a6e53b4a4"));
            Protocol = (ITTListBoxColumn)AddControl(new Guid("c92a8b26-6563-415b-8a18-069e5010a5a1"));
            ProtocolStartDate = (ITTDateTimePickerColumn)AddControl(new Guid("c82a5063-4a5d-4c0a-9636-fea3c75826da"));
            ProtocolEndDate = (ITTDateTimePickerColumn)AddControl(new Guid("69a1f6d9-25c1-488b-9b4a-ac477765fdbb"));
            lblProtocols = (ITTLabel)AddControl(new Guid("486330c9-78ee-4580-8f01-91e0e0bfc414"));
            CITY = (ITTObjectListBox)AddControl(new Guid("12c426bb-8940-4f1b-8b98-0f0339089a9f"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("623770a1-89d6-4a85-85a9-1db4688722cb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7a23ab82-34de-453b-81ee-2090cbdd15a4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b561da2a-602b-48a7-9bd1-4d302ab61dba"));
            Active = (ITTCheckBox)AddControl(new Guid("2aea8397-8d82-4cfa-909f-5bcb6fe9140d"));
            PAYERTYPE = (ITTObjectListBox)AddControl(new Guid("81fa8d00-2b8c-4139-9cfe-6202edad94ce"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("cc073389-a93f-4c90-9256-64461318d438"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("8010a05d-5fe6-4b91-8c4a-65ed7b070b23"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("948db566-c900-4be8-aed3-6ae223b82418"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("c440bcd7-cdc8-4970-b57c-6e03166f40c2"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("5196b61b-be1b-4f80-bd95-74304a4e1b4c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c046973d-8002-4f83-8f38-7602b8f261a6"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("50c8a93a-db43-43ad-a523-830db0e32066"));
            TTLabel15 = (ITTLabel)AddControl(new Guid("49e71999-796a-4ef2-a36c-862caf4650c5"));
            TTLabel14 = (ITTLabel)AddControl(new Guid("f3991ab0-596f-4cf1-b680-880b6562c173"));
            TTLabel13 = (ITTLabel)AddControl(new Guid("54b31797-71af-4648-828f-8f086dc5674a"));
            PARENTPAYER = (ITTObjectListBox)AddControl(new Guid("22e183ba-d2d4-4c78-b9cb-8f8b367ea460"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("babe7bd4-6d75-41e6-afd5-ce5291d623c5"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("d413e317-3681-472b-9570-cf713505d31f"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("5e07ae07-2a0a-4857-a68a-0d55f101f460"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("94623697-2be8-4779-ad5c-42080c7a7351"));
            GetPatientParticipation = (ITTCheckBox)AddControl(new Guid("a937a08f-8693-48d4-aef0-352dd9dfaeb9"));
            CancelPatientShareAccTrx = (ITTCheckBox)AddControl(new Guid("093304dd-1158-417a-bfaa-7af08e33d4e9"));
            base.InitializeControls();
        }

        public PayerForm() : base("PAYERDEFINITION", "PayerForm")
        {
        }

        protected PayerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}