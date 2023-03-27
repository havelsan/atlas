
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
    /// PTS İşlemi Tamamlama
    /// </summary>
    public partial class PTSActionCompletedTaskForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// PTS Giriş İşlemi Tamamlama
    /// </summary>
        protected TTObjectClasses.PTSActionCompletedTask _PTSActionCompletedTask
        {
            get { return (TTObjectClasses.PTSActionCompletedTask)_ttObject; }
        }

        protected ITTTextBox ExpirationDay;
        protected ITTLabel labelExpirationDay;
        override protected void InitializeControls()
        {
            ExpirationDay = (ITTTextBox)AddControl(new Guid("fb1ec003-832e-48cc-9284-43c34ad1cd92"));
            labelExpirationDay = (ITTLabel)AddControl(new Guid("483238da-dd30-4ab9-b98e-5c5691d85b72"));
            base.InitializeControls();
        }

        public PTSActionCompletedTaskForm() : base("PTSACTIONCOMPLETEDTASK", "PTSActionCompletedTaskForm")
        {
        }

        protected PTSActionCompletedTaskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}