
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
    /// Fatura Bilgilerini Muhasebeye Gönderme
    /// </summary>
    public partial class SendingInvToAccountingForm : TTForm
    {
    /// <summary>
    /// Fatura Bilgilerini Muhasebeye Gönderme
    /// </summary>
        protected TTObjectClasses.SendingInvoiceToAccounting _SendingInvoiceToAccounting
        {
            get { return (TTObjectClasses.SendingInvoiceToAccounting)_ttObject; }
        }

        protected ITTButton CLEARALL;
        protected ITTButton SELECTALL;
        protected ITTTabControl TABInvoices;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GRIDInvoices;
        protected ITTTextBoxColumn PAYERNAME;
        protected ITTTextBoxColumn PATIENTID;
        protected ITTTextBoxColumn PROTOCOLNO;
        protected ITTTextBoxColumn PATIENTNAME;
        protected ITTDateTimePickerColumn INVOICEDATE;
        protected ITTTextBoxColumn INVOICENO;
        protected ITTTextBoxColumn INVOICEPRICE;
        protected ITTCheckBoxColumn SEND;
        protected ITTButton LIST;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ENDDATE;
        protected ITTDateTimePicker STARTDATE;
        override protected void InitializeControls()
        {
            CLEARALL = (ITTButton)AddControl(new Guid("bc9137e5-e94c-4eaf-85e9-fe038e210635"));
            SELECTALL = (ITTButton)AddControl(new Guid("cf628ce4-e43a-4ac0-b05e-9e5b714f3b1b"));
            TABInvoices = (ITTTabControl)AddControl(new Guid("8824db7f-ba09-409a-8288-db26589fe985"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("cbad9b62-fccf-4335-a196-6825dad5401e"));
            GRIDInvoices = (ITTGrid)AddControl(new Guid("a5dd8fea-881c-4837-a475-1b44c35463dc"));
            PAYERNAME = (ITTTextBoxColumn)AddControl(new Guid("87d8077c-6be0-44d8-89b2-10209bc41817"));
            PATIENTID = (ITTTextBoxColumn)AddControl(new Guid("c2000152-8af4-4376-82d4-942b67459777"));
            PROTOCOLNO = (ITTTextBoxColumn)AddControl(new Guid("3ef4ed8b-62e9-487f-a5f9-70c5d9dbbf06"));
            PATIENTNAME = (ITTTextBoxColumn)AddControl(new Guid("51479bd6-8043-4aff-b6a8-db3215671a68"));
            INVOICEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("bbd4d2f6-b981-4cf8-8596-cfefb9e545a4"));
            INVOICENO = (ITTTextBoxColumn)AddControl(new Guid("2d6d26cc-3746-4978-9fea-97e8b2920243"));
            INVOICEPRICE = (ITTTextBoxColumn)AddControl(new Guid("81763a32-034e-48a2-857a-66088b7b76eb"));
            SEND = (ITTCheckBoxColumn)AddControl(new Guid("da5d9249-3208-4984-a93f-f725776d799a"));
            LIST = (ITTButton)AddControl(new Guid("89abb745-e235-41d0-ad0d-0634663a2b2b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a4d06e8b-05ca-4769-8070-2d78347d9f51"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c1092322-adb3-4d1f-91a7-fd366cca718b"));
            ENDDATE = (ITTDateTimePicker)AddControl(new Guid("e3fd1f62-f44d-4055-aad9-6e5674ff0fa8"));
            STARTDATE = (ITTDateTimePicker)AddControl(new Guid("ccda5fa3-dbf3-4529-ad96-16f9a2ab15c4"));
            base.InitializeControls();
        }

        public SendingInvToAccountingForm() : base("SENDINGINVOICETOACCOUNTING", "SendingInvToAccountingForm")
        {
        }

        protected SendingInvToAccountingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}