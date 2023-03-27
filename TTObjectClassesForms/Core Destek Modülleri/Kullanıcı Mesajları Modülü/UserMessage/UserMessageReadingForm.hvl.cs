
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
    /// Mesaj İçerik
    /// </summary>
    public partial class UserMessageReadingForm : TTForm
    {
    /// <summary>
    /// Kullanıcı Mesajları
    /// </summary>
        protected TTObjectClasses.UserMessage _UserMessage
        {
            get { return (TTObjectClasses.UserMessage)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTTextBox Subject;
        protected ITTButton cmdSwitchToAction;
        protected ITTButton cmdSwitchToFolder;
        protected ITTButton ViewReportButton;
        protected ITTObjectListBox SenderUser;
        protected ITTRichTextBoxControl MessageBody;
        protected ITTLabel labelSubject;
        protected ITTLabel labelMessageDate;
        protected ITTDateTimePicker MessageDate;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox IsSystemMessage;
        protected ITTObjectListBox ToUser;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("61f07167-a81e-4c9d-80b3-dccabcc60872"));
            Subject = (ITTTextBox)AddControl(new Guid("21ea8ea6-655d-4f2c-afeb-1b697171d96e"));
            cmdSwitchToAction = (ITTButton)AddControl(new Guid("0047c823-6886-4ec0-97de-a8561d2877c3"));
            cmdSwitchToFolder = (ITTButton)AddControl(new Guid("6d749272-a648-48b9-af26-07a9949953de"));
            ViewReportButton = (ITTButton)AddControl(new Guid("58a1b91d-7cbc-458d-b101-dc42577c5478"));
            SenderUser = (ITTObjectListBox)AddControl(new Guid("d7a89159-d0c8-480c-886d-ffadc6fac2eb"));
            MessageBody = (ITTRichTextBoxControl)AddControl(new Guid("105391be-431f-457a-a08a-bf23c4fa7326"));
            labelSubject = (ITTLabel)AddControl(new Guid("08caf6de-605e-4597-9ec8-394d3dd95a08"));
            labelMessageDate = (ITTLabel)AddControl(new Guid("0948e37d-3d64-4b18-bb7e-9582aaf01b69"));
            MessageDate = (ITTDateTimePicker)AddControl(new Guid("33e44cc2-e12b-4414-9620-6bc0df1327cf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6c712cd0-9cb6-4d7b-a974-57044fbd6821"));
            IsSystemMessage = (ITTCheckBox)AddControl(new Guid("81ea6d9d-ec06-4f70-8ed7-0b6b31ad4418"));
            ToUser = (ITTObjectListBox)AddControl(new Guid("4357d0c4-ac32-4c16-90ea-b980b0640374"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("aa155c5c-5a81-4c30-bc84-4f2a0f670d0a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0d853732-c26b-4c6c-8cb6-d9b03084b89c"));
            base.InitializeControls();
        }

        public UserMessageReadingForm() : base("USERMESSAGE", "UserMessageReadingForm")
        {
        }

        protected UserMessageReadingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}