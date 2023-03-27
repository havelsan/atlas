
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
    public partial class SendSMSWorkHealthSecWarnForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// İş Sağlığı ve Güvenliği Muayenelerinin hatırlatma smslerinin gönderileceği planlı görev
    /// </summary>
        protected TTObjectClasses.SendSMSWorkHealthSecWarn _SendSMSWorkHealthSecWarn
        {
            get { return (TTObjectClasses.SendSMSWorkHealthSecWarn)_ttObject; }
        }

        public SendSMSWorkHealthSecWarnForm() : base("SENDSMSWORKHEALTHSECWARN", "SendSMSWorkHealthSecWarnForm")
        {
        }

        protected SendSMSWorkHealthSecWarnForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}