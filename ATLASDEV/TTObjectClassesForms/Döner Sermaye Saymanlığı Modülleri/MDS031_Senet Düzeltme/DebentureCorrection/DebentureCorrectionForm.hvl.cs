
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
    /// Senet Düzeltme Formu
    /// </summary>
    public partial class DebentureCorrectionForm : TTForm
    {
    /// <summary>
    /// Senet Düzeltme İşlemi
    /// </summary>
        protected TTObjectClasses.DebentureCorrection _DebentureCorrection
        {
            get { return (TTObjectClasses.DebentureCorrection)_ttObject; }
        }

        protected ITTTextBox DEBENTUREDOCUMENTOBJECTID;
        protected ITTTextBox CASHIERNAME;
        protected ITTLabel ttlabel3;
        protected ITTTextBox NEWCREATEDTOTALPRICE;
        protected ITTTextBox CANCELLEDTOTALPRICE;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTabControl NewDebentureInfo;
        protected ITTTabPage TabCreatable;
        protected ITTGrid GRIDNEWDEBENTURES;
        protected ITTTextBoxColumn NDEBENTURENO;
        protected ITTDateTimePickerColumn NDUEDATE;
        protected ITTTextBoxColumn NDEBENTUREPRICE;
        protected ITTButtonColumn ENTERGUARANTORINFO;
        protected ITTCheckBoxColumn CREATENEWGUARANTOR;
        protected ITTTabControl OldDebentureInfo;
        protected ITTTabPage TabCancellable;
        protected ITTGrid GRIDCANCELLABLEDEBENTURES;
        protected ITTTextBoxColumn DEBENTURENO;
        protected ITTDateTimePickerColumn DUEDATE;
        protected ITTTextBoxColumn DEBENTUREPRICE;
        protected ITTTextBoxColumn STATUS;
        protected ITTButtonColumn CANCEL;
        protected ITTCheckBoxColumn CANCELLED;
        protected ITTButtonColumn GUARANTORINFO;
        protected ITTTextBoxColumn DEBENTUREOBJECTID;
        protected ITTTextBoxColumn RECEIPTDOCUMENTOBJECTID;
        protected ITTTextBoxColumn ADVANCEDOCUMENTOBJECTID;
        override protected void InitializeControls()
        {
            DEBENTUREDOCUMENTOBJECTID = (ITTTextBox)AddControl(new Guid("d75553ca-1a8b-45f8-8304-d5665f638625"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("55481cc9-87ce-4e21-a2ec-cee799408dfc"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("deefefba-c869-4830-84a9-5471f615f59a"));
            NEWCREATEDTOTALPRICE = (ITTTextBox)AddControl(new Guid("5d42b8cf-a343-4342-b284-cd8c5f18ed0b"));
            CANCELLEDTOTALPRICE = (ITTTextBox)AddControl(new Guid("f93f52df-c571-4deb-b891-82e1d636a96e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("86e6e3b1-8630-43b3-a226-70bdb1dc3739"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("22b2a8e8-cd65-4caf-be8f-84b1d37c1049"));
            NewDebentureInfo = (ITTTabControl)AddControl(new Guid("f2a52a8a-3d99-4f33-a9d6-6624eb49d023"));
            TabCreatable = (ITTTabPage)AddControl(new Guid("e54de26f-db88-424c-8351-90ac1987ff7b"));
            GRIDNEWDEBENTURES = (ITTGrid)AddControl(new Guid("e0188598-bb59-4176-b9f7-7e4a303b07a3"));
            NDEBENTURENO = (ITTTextBoxColumn)AddControl(new Guid("853e6583-f10c-4435-9d73-ae5be1225063"));
            NDUEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("bffd8f76-4a86-4338-9a6f-2b6a4fb3783c"));
            NDEBENTUREPRICE = (ITTTextBoxColumn)AddControl(new Guid("ace2f1d6-56b6-48b3-8dba-a287c952dcf6"));
            ENTERGUARANTORINFO = (ITTButtonColumn)AddControl(new Guid("8c128f14-e4fd-4060-b77a-9cbcbb2ca5ce"));
            CREATENEWGUARANTOR = (ITTCheckBoxColumn)AddControl(new Guid("7fdc79c7-672d-4461-bba5-b2bb6a4f0db3"));
            OldDebentureInfo = (ITTTabControl)AddControl(new Guid("804042ec-da70-454b-9388-579f7c541bab"));
            TabCancellable = (ITTTabPage)AddControl(new Guid("8cd179f2-61b3-48cb-a197-8a3c43b97040"));
            GRIDCANCELLABLEDEBENTURES = (ITTGrid)AddControl(new Guid("363df8bd-6a06-4995-b30c-eca1ccb4f805"));
            DEBENTURENO = (ITTTextBoxColumn)AddControl(new Guid("59367038-dd5a-4d1c-86b9-d90c57afa8f0"));
            DUEDATE = (ITTDateTimePickerColumn)AddControl(new Guid("d95a3f38-1598-4725-9b40-1b0294f4a19a"));
            DEBENTUREPRICE = (ITTTextBoxColumn)AddControl(new Guid("754332c4-d0c7-4be2-86f1-23b94f751148"));
            STATUS = (ITTTextBoxColumn)AddControl(new Guid("47ae5e64-f831-4624-a787-f12e74a03d9b"));
            CANCEL = (ITTButtonColumn)AddControl(new Guid("2dc11cae-302d-46e1-bf53-a6ae8a2ebda9"));
            CANCELLED = (ITTCheckBoxColumn)AddControl(new Guid("51f413eb-d812-45ac-aad4-b1b38f6faeb7"));
            GUARANTORINFO = (ITTButtonColumn)AddControl(new Guid("4ad068e3-e284-4eaa-a531-31ab846c6aef"));
            DEBENTUREOBJECTID = (ITTTextBoxColumn)AddControl(new Guid("4daa74de-ea4a-4e60-90bd-fa32724cdc1d"));
            RECEIPTDOCUMENTOBJECTID = (ITTTextBoxColumn)AddControl(new Guid("b83f04cb-d235-4ef2-bbea-dcf8e79dc881"));
            ADVANCEDOCUMENTOBJECTID = (ITTTextBoxColumn)AddControl(new Guid("faa46a4d-13d1-4533-a798-794961a46081"));
            base.InitializeControls();
        }

        public DebentureCorrectionForm() : base("DEBENTURECORRECTION", "DebentureCorrectionForm")
        {
        }

        protected DebentureCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}