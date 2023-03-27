
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
    public partial class Send502Form : ScheduledTaskBaseForm
    {
    /// <summary>
    /// NABIZ - Yoğun Bakım İzlem Veri Seti
    /// </summary>
        protected TTObjectClasses.ENABIZSend502 _ENABIZSend502
        {
            get { return (TTObjectClasses.ENABIZSend502)_ttObject; }
        }

        public Send502Form() : base("ENABIZSEND502", "Send502Form")
        {
        }

        protected Send502Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}