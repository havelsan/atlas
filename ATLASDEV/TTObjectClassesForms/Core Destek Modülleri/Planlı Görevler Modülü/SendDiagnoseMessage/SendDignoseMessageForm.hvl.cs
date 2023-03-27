
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
    public partial class SendDignoseMessageForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Hastaya belirlenmiş bir tanı konulduğunda belirlenmiş bir kullanıcıya sms atmak için oluşturuldu.
    /// </summary>
        protected TTObjectClasses.SendDiagnoseMessage _SendDiagnoseMessage
        {
            get { return (TTObjectClasses.SendDiagnoseMessage)_ttObject; }
        }

        public SendDignoseMessageForm() : base("SENDDIAGNOSEMESSAGE", "SendDignoseMessageForm")
        {
        }

        protected SendDignoseMessageForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}