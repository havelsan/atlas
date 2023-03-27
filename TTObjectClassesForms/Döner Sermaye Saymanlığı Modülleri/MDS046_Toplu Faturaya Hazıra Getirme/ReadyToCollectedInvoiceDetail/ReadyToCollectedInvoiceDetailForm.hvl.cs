
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
    public partial class ReadyToCollectedInvoiceDetailForm : TTForm
    {
        protected TTObjectClasses.ReadyToCollectedInvoiceDetail _ReadyToCollectedInvoiceDetail
        {
            get { return (TTObjectClasses.ReadyToCollectedInvoiceDetail)_ttObject; }
        }

        protected ITTGroupBox PayerInvoiceInfo;
        protected ITTTextBox TotalPriceEpisodeAccountAction;
        protected ITTLabel labelIDBaseAction;
        protected ITTLabel labelTotalPriceEpisodeAccountAction;
        protected ITTTextBox IDBaseAction;
        protected ITTDateTimePicker ActionDateBaseAction;
        protected ITTObjectListBox PROTOCOLNAME;
        protected ITTLabel labelActionDateBaseAction;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox PAYERNAME;
        protected ITTLabel ttlabel20;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox PISUBEPISODE;
        protected ITTTextBox TotalPrice;
        protected ITTTextBox ErrorMessage;
        protected ITTLabel labelTotalPrice;
        protected ITTLabel labelErrorMessage;
        protected ITTObjectListBox SUBEPISODE;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            PayerInvoiceInfo = (ITTGroupBox)AddControl(new Guid("ecbd1948-d108-4ced-bd06-570093804698"));
            TotalPriceEpisodeAccountAction = (ITTTextBox)AddControl(new Guid("06d2911b-a2a7-4143-9f20-c3b34ffdf348"));
            labelIDBaseAction = (ITTLabel)AddControl(new Guid("22c20445-83bf-406e-864c-f65fc3cc833f"));
            labelTotalPriceEpisodeAccountAction = (ITTLabel)AddControl(new Guid("16aaa393-1bc0-4106-ac9c-0494db7afbbf"));
            IDBaseAction = (ITTTextBox)AddControl(new Guid("c35e160b-64c2-477a-907a-e288d6ba83fc"));
            ActionDateBaseAction = (ITTDateTimePicker)AddControl(new Guid("be24103e-784c-4de9-a2c8-f4294c7ed517"));
            PROTOCOLNAME = (ITTObjectListBox)AddControl(new Guid("c11b68fe-3790-45b0-9716-0b742546e41c"));
            labelActionDateBaseAction = (ITTLabel)AddControl(new Guid("412ef5da-5177-4028-9da1-8e92ef797b80"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d680c37f-5c49-493e-925e-338a563244d6"));
            PAYERNAME = (ITTObjectListBox)AddControl(new Guid("9b23c682-5245-428e-b8fa-0d2208b3b7ba"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("2a53473e-12a7-4fdc-b9d2-cdf138b0808d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3d29e433-4f7d-4915-be58-62aa3d1f6626"));
            PISUBEPISODE = (ITTObjectListBox)AddControl(new Guid("b12a4483-f4bd-4999-a393-1725469ca862"));
            TotalPrice = (ITTTextBox)AddControl(new Guid("f51724bb-792c-44fb-baff-b5c7805ac39e"));
            ErrorMessage = (ITTTextBox)AddControl(new Guid("8bba3e9d-e34b-4265-bc85-53a4ac7add93"));
            labelTotalPrice = (ITTLabel)AddControl(new Guid("25825a41-7594-430e-a243-b3040c7da877"));
            labelErrorMessage = (ITTLabel)AddControl(new Guid("de596fc2-986b-4814-8313-0f12325fdb4d"));
            SUBEPISODE = (ITTObjectListBox)AddControl(new Guid("193232ef-5acf-495a-98d7-e898918df92c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3a147894-578e-493a-8e0b-22cf90c5cdc5"));
            base.InitializeControls();
        }

        public ReadyToCollectedInvoiceDetailForm() : base("READYTOCOLLECTEDINVOICEDETAIL", "ReadyToCollectedInvoiceDetailForm")
        {
        }

        protected ReadyToCollectedInvoiceDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}