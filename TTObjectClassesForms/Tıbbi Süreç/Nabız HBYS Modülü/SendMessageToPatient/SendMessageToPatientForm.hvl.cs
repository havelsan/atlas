
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
    public partial class SendMessageToPatientForm : TTForm
    {
    /// <summary>
    /// HastaMesajGonder methodu için kullanılan object
    /// </summary>
        protected TTObjectClasses.SendMessageToPatient _SendMessageToPatient
        {
            get { return (TTObjectClasses.SendMessageToPatient)_ttObject; }
        }

        protected ITTLabel labelSKRSHastaMesajlari;
        protected ITTObjectListBox SKRSHastaMesajlari;
        protected ITTLabel labelMessageDate;
        protected ITTDateTimePicker MessageDate;
        protected ITTLabel labelMessageInfo;
        protected ITTTextBox MessageInfo;
        override protected void InitializeControls()
        {
            labelSKRSHastaMesajlari = (ITTLabel)AddControl(new Guid("bfcac2d4-1e52-4660-bcc1-f444a794638b"));
            SKRSHastaMesajlari = (ITTObjectListBox)AddControl(new Guid("45749935-160e-4c2c-b9cb-2439fe9e0f8c"));
            labelMessageDate = (ITTLabel)AddControl(new Guid("61fd48e5-6f37-4ef2-a6de-96ecacf4672d"));
            MessageDate = (ITTDateTimePicker)AddControl(new Guid("2cee2477-fbcb-4cc9-8535-1fe6d84a78df"));
            labelMessageInfo = (ITTLabel)AddControl(new Guid("f23ca106-3112-419f-93a0-aba06f10b106"));
            MessageInfo = (ITTTextBox)AddControl(new Guid("616f4ce1-9e6b-43f5-b06f-3383bdf4013a"));
            base.InitializeControls();
        }

        public SendMessageToPatientForm() : base("SENDMESSAGETOPATIENT", "SendMessageToPatientForm")
        {
        }

        protected SendMessageToPatientForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}