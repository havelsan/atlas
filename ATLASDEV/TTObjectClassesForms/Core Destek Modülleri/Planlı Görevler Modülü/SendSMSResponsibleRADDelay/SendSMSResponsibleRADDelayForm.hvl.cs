
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
    /// Radyoloji Gecikmeleri için Sorumlu Doktora SMS Gönderme İşlemi
    /// </summary>
    public partial class SendSMSResponsibleRADDelayForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Radyoloji Gecikmeleri için Sorumlu Doktora SMS Gönderme İşlemi
    /// </summary>
        protected TTObjectClasses.SendSMSResponsibleRADDelay _SendSMSResponsibleRADDelay
        {
            get { return (TTObjectClasses.SendSMSResponsibleRADDelay)_ttObject; }
        }

        public SendSMSResponsibleRADDelayForm() : base("SENDSMSRESPONSIBLERADDELAY", "SendSMSResponsibleRADDelayForm")
        {
        }

        protected SendSMSResponsibleRADDelayForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}