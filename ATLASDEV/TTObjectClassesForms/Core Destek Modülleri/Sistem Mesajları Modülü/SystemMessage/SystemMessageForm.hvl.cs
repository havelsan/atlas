
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
    /// Sistem Mesajları Tanımı
    /// </summary>
    public partial class SystemMessageForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Sistem Mesajları Tanımı
    /// </summary>
        protected TTObjectClasses.SystemMessage _SystemMessage
        {
            get { return (TTObjectClasses.SystemMessage)_ttObject; }
        }

        protected ITTLabel labelMessage;
        protected ITTTextBox Message;
        protected ITTLabel labelMessageType;
        protected ITTEnumComboBox MessageType;
        protected ITTLabel labelMessageCode;
        protected ITTTextBox MessageCode;
        override protected void InitializeControls()
        {
            labelMessage = (ITTLabel)AddControl(new Guid("80e08fc2-4bb6-40b1-b8bf-5f46b082e5be"));
            Message = (ITTTextBox)AddControl(new Guid("6a7e6155-ca9e-4a78-9dce-ff11dd73d2d3"));
            labelMessageType = (ITTLabel)AddControl(new Guid("0c97aab0-1a1b-46fe-8331-7816e78fa413"));
            MessageType = (ITTEnumComboBox)AddControl(new Guid("70a892e5-aeca-404a-9614-87d73cd035c8"));
            labelMessageCode = (ITTLabel)AddControl(new Guid("833c703d-7e5d-4645-8f53-e6153fc43925"));
            MessageCode = (ITTTextBox)AddControl(new Guid("ba8ad380-db78-4024-a82c-cbcbf3f26f1d"));
            base.InitializeControls();
        }

        public SystemMessageForm() : base("SYSTEMMESSAGE", "SystemMessageForm")
        {
        }

        protected SystemMessageForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}