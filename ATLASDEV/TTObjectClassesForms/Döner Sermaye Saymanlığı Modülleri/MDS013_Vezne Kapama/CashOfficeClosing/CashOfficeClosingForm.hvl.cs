
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
    /// Muhasebe Yetkilisi Mutemetliği / Vezne / Fatura Servisi Kapama
    /// </summary>
    public partial class CashOfficeClosingForm : TTForm
    {
    /// <summary>
    /// Muh.Yet. Mutemetliği/Vezne/Fatura Servisi Kapama
    /// </summary>
        protected TTObjectClasses.CashOfficeClosing _CashOfficeClosing
        {
            get { return (TTObjectClasses.CashOfficeClosing)_ttObject; }
        }

        protected ITTTextBox OTHERPRICEBACKTOTAL;
        protected ITTTextBox TREATMENTPRICEBACKTOTAL;
        protected ITTTextBox CASHOFFICECREDITCARDANNUAL;
        protected ITTTextBox CASHOFFICECASHANNUAL;
        protected ITTTextBox LOGID;
        protected ITTTextBox CASHOFFICE;
        protected ITTTextBox CASHOFFICECODE;
        protected ITTTextBox CASHOFFICEBALANCE;
        protected ITTTextBox SUBMITTEDTOTAL;
        protected ITTTextBox REMAININGTOTAL;
        protected ITTLabel TREATMENTPRICEBACKTOTALLABEL;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel13;
        protected ITTGroupBox ttgroupbox1;
        protected ITTButton PREVIEWREPORT;
        protected ITTTextBox CASHREVENUETOTAL;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel10;
        protected ITTTextBox CREDITCARDREVENUETOTAL;
        protected ITTLabel ttlabel8;
        protected ITTTextBox GENERALREVENUETOTAL;
        protected ITTLabel AdLabel;
        protected ITTDateTimePicker OPENINGDATE;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker CLOSINGDATE;
        protected ITTLabel ttlabel5;
        protected ITTLabel KodLabel;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel1;
        protected ITTGroupBox BANKDELIVERY;
        protected ITTTextBox RECEIPTNO;
        protected ITTLabel ttlabel15;
        protected ITTTextBox SPECIALNO;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox BANKACCOUNT;
        override protected void InitializeControls()
        {
            OTHERPRICEBACKTOTAL = (ITTTextBox)AddControl(new Guid("88d4624b-c64e-44ac-af86-328643fe90b2"));
            TREATMENTPRICEBACKTOTAL = (ITTTextBox)AddControl(new Guid("604feff2-c22f-485e-8415-2a5085121bd7"));
            CASHOFFICECREDITCARDANNUAL = (ITTTextBox)AddControl(new Guid("360b3419-11e9-4f2a-be24-fa0b743f41ae"));
            CASHOFFICECASHANNUAL = (ITTTextBox)AddControl(new Guid("fb8cb1bd-56ff-4c5e-bdb2-7117d941569f"));
            LOGID = (ITTTextBox)AddControl(new Guid("4dbbfaf4-a79d-4315-ac88-a07ac53c31f1"));
            CASHOFFICE = (ITTTextBox)AddControl(new Guid("87e34efb-4db4-4975-a73f-db2fbe3465f6"));
            CASHOFFICECODE = (ITTTextBox)AddControl(new Guid("427bb232-ef9f-4c5e-adef-fb404d9f36f2"));
            CASHOFFICEBALANCE = (ITTTextBox)AddControl(new Guid("c7b83277-eafd-4e28-bb70-c8ab2d018590"));
            SUBMITTEDTOTAL = (ITTTextBox)AddControl(new Guid("6c89453a-722c-4866-a500-e9cd45b23a9c"));
            REMAININGTOTAL = (ITTTextBox)AddControl(new Guid("c3434df4-7f4c-4518-85e6-48bb120c84c1"));
            TREATMENTPRICEBACKTOTALLABEL = (ITTLabel)AddControl(new Guid("73931308-5d28-4e64-893d-f66c2b5e9cab"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("2ff30aa9-57b1-40c7-a278-2d84c7b97320"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("10509a24-b03a-4cdb-abb6-17efa9b350b2"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("9ed90f6a-f2d5-430f-a533-6f204d158b59"));
            PREVIEWREPORT = (ITTButton)AddControl(new Guid("933fbc0e-1693-4504-935f-1ef532cc49d5"));
            CASHREVENUETOTAL = (ITTTextBox)AddControl(new Guid("211ecc3f-3466-4a07-bee6-1d3f8f53e7ba"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("c800bb89-7fc0-4936-9f48-355f59581412"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("c5d550cb-0e0c-407e-9fa6-a3659552c413"));
            CREDITCARDREVENUETOTAL = (ITTTextBox)AddControl(new Guid("e61f3e6d-381b-48b1-9297-3edb86cd7926"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("c9d04f0e-bd6f-4ebf-9315-bd3dd680fd2a"));
            GENERALREVENUETOTAL = (ITTTextBox)AddControl(new Guid("d924ca11-4bf4-4042-a6aa-19ff8b250882"));
            AdLabel = (ITTLabel)AddControl(new Guid("bdfd52a7-6aed-4107-8ae5-4b1cf561c6af"));
            OPENINGDATE = (ITTDateTimePicker)AddControl(new Guid("5ea3b9dd-13ae-429d-8162-705691b39e66"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6ab7a9b4-5a9f-4ee1-a5e6-77fe2e6f925f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f53cbfe9-3247-4695-9f0f-ad77498a14c5"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ea653c69-a804-4752-8c21-b1f3b5d6341c"));
            CLOSINGDATE = (ITTDateTimePicker)AddControl(new Guid("5d6fcc59-c539-4e70-8c0c-d50b8ba8c2bd"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b1e0a3f5-9601-48c9-9400-fa1d9937b6e6"));
            KodLabel = (ITTLabel)AddControl(new Guid("4d774af0-c6e3-43ba-9916-74721994eeb8"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("4cc55616-c758-4b2a-ac96-924d9bbcad3e"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("e1553674-95dc-42f5-a22f-034ebc3cc875"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("bc5acc98-ecfe-473e-951c-50edfff58b04"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a97e328d-9a2f-4822-ab40-f9957fedab61"));
            BANKDELIVERY = (ITTGroupBox)AddControl(new Guid("c63ba6ff-0e15-4652-8d2b-d3b7e1a4051e"));
            RECEIPTNO = (ITTTextBox)AddControl(new Guid("1b441feb-e975-4f70-a293-87f362749351"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("e306b218-7e82-4987-b5f4-3967e28a0b9a"));
            SPECIALNO = (ITTTextBox)AddControl(new Guid("20663e13-9767-42d9-8cfe-e946fdf732d0"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("9e42af5b-2bc3-42d7-8015-d11911a08976"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d2e62199-4025-44ed-9216-9ff16355a747"));
            BANKACCOUNT = (ITTObjectListBox)AddControl(new Guid("b3fb9068-d202-4991-9628-3e67f1fc4b7d"));
            base.InitializeControls();
        }

        public CashOfficeClosingForm() : base("CASHOFFICECLOSING", "CashOfficeClosingForm")
        {
        }

        protected CashOfficeClosingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}