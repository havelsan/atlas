
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
    public partial class ENabizDataUpdateTaskForm : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENabizDataUpdateTask _ENabizDataUpdateTask
        {
            get { return (TTObjectClasses.ENabizDataUpdateTask)_ttObject; }
        }

        protected ITTLabel labelStartedDay;
        protected ITTTextBox StartedDay;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            labelStartedDay = (ITTLabel)AddControl(new Guid("91b6ae1a-ae00-4c6c-81de-f59840631c41"));
            StartedDay = (ITTTextBox)AddControl(new Guid("4b0939bb-a868-40f2-9ade-742cc6699007"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b28284ff-b808-42db-9978-fb101d9d525a"));
            base.InitializeControls();
        }

        public ENabizDataUpdateTaskForm() : base("ENABIZDATAUPDATETASK", "ENabizDataUpdateTaskForm")
        {
        }

        protected ENabizDataUpdateTaskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}