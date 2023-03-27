
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
    /// Mesaj Gönderme
    /// </summary>
    public partial class UserMessageSendingForm : TTUnboundForm
    {
        protected ITTPanel ttpanel1;
        protected ITTButton ttbutton3;
        protected ITTDateTimePicker ExpireDate;
        protected ITTLabel labelExpireDate;
        protected ITTCheckBox IsSplashMessage;
        protected ITTCheckBox MessageFeedback;
        protected ITTButton ttbutton1;
        protected ITTLabel labelMessageDate;
        protected ITTButton ttbutton2;
        protected ITTButton ttbuttonSelect;
        protected ITTDateTimePicker MessageDate;
        protected ITTCheckBox IsSystemMessage;
        protected ITTTextBox ToUsersBox;
        protected ITTRichTextBoxControl MessageBody;
        protected ITTTextBox Subject;
        protected ITTLabel labelSubject;
        protected ITTPanel pnlSendingButtons;
        protected ITTButton btnSend;
        protected ITTButton btnOK;
        protected ITTButton btnCancel;
        override protected void InitializeControls()
        {
            ttpanel1 = (ITTPanel)AddControl(new Guid("cf1ccbcf-f13f-421a-8fb1-6f3b4414d768"));
            ttbutton3 = (ITTButton)AddControl(new Guid("2b0dddd1-ccae-4ebe-a7e0-e1eb2e218a37"));
            ExpireDate = (ITTDateTimePicker)AddControl(new Guid("9a6e7852-1909-46d2-9809-a19d9d597ec8"));
            labelExpireDate = (ITTLabel)AddControl(new Guid("de54360c-4a3f-4748-919d-07caaf4f67b1"));
            IsSplashMessage = (ITTCheckBox)AddControl(new Guid("6bdaa197-83e0-47f7-9357-f9e3fc8f5695"));
            MessageFeedback = (ITTCheckBox)AddControl(new Guid("d173e493-8128-4aaa-9151-0caaf891670d"));
            ttbutton1 = (ITTButton)AddControl(new Guid("0819e355-fbf5-4bb6-b78f-99672b09f5c1"));
            labelMessageDate = (ITTLabel)AddControl(new Guid("0d4d5ff1-9c85-4cf4-9229-ed64ac723279"));
            ttbutton2 = (ITTButton)AddControl(new Guid("34fa28fb-7256-449e-8bfb-d596daf3f1df"));
            ttbuttonSelect = (ITTButton)AddControl(new Guid("3033e385-5362-4bfc-9873-be2e29c56150"));
            MessageDate = (ITTDateTimePicker)AddControl(new Guid("97be7635-8b14-41c4-8fa5-4f469f41c2d4"));
            IsSystemMessage = (ITTCheckBox)AddControl(new Guid("2d5193f0-1c54-43d1-ab21-6add0cda0a1f"));
            ToUsersBox = (ITTTextBox)AddControl(new Guid("625c1a64-7b7d-4a90-a724-e14719aae1bd"));
            MessageBody = (ITTRichTextBoxControl)AddControl(new Guid("06994e30-bcb7-449d-ad11-744122fe0c72"));
            Subject = (ITTTextBox)AddControl(new Guid("730f40e9-5ee4-4978-b4ee-6747f149da90"));
            labelSubject = (ITTLabel)AddControl(new Guid("046f214c-fd31-4aee-b902-8c10de2e1078"));
            pnlSendingButtons = (ITTPanel)AddControl(new Guid("c1b0fc5f-c2ae-4c1f-8474-1acc52d01697"));
            btnSend = (ITTButton)AddControl(new Guid("7e6b3ec1-5707-4c79-84b2-bea0e5667d6f"));
            btnOK = (ITTButton)AddControl(new Guid("1692ef4b-6bbd-4973-9496-c3f4c2e367ef"));
            btnCancel = (ITTButton)AddControl(new Guid("11295a2f-aff4-4e7e-b4e9-6a13234c6616"));
            base.InitializeControls();
        }

        public UserMessageSendingForm() : base("UserMessageSendingForm")
        {
        }

        protected UserMessageSendingForm(string formDefName) : base(formDefName)
        {
        }
    }
}