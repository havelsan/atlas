
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
    /// Otomatik Tüketim Üretim Elde Edilenler Belgesi Oluşturma
    /// </summary>
    public partial class AutoConsumptionDocTaskForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Otomatik Tüketim Üretim Elde Edilenler Belgesi Oluşturma
    /// </summary>
        protected TTObjectClasses.AutoConsumptionDocTask _AutoConsumptionDocTask
        {
            get { return (TTObjectClasses.AutoConsumptionDocTask)_ttObject; }
        }

        public AutoConsumptionDocTaskForm() : base("AUTOCONSUMPTIONDOCTASK", "AutoConsumptionDocTaskForm")
        {
        }

        protected AutoConsumptionDocTaskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}