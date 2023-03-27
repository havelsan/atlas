
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
    public partial class ScheduledTaskHistoryForm : TTForm
    {
    /// <summary>
    /// Planlı Görev Geçmişi
    /// </summary>
        protected TTObjectClasses.ScheduledTaskHistory _ScheduledTaskHistory
        {
            get { return (TTObjectClasses.ScheduledTaskHistory)_ttObject; }
        }

        protected ITTLabel labelLogDate;
        protected ITTDateTimePicker LogDate;
        protected ITTLabel labelLog;
        protected ITTTextBox Log;
        override protected void InitializeControls()
        {
            labelLogDate = (ITTLabel)AddControl(new Guid("1002af6b-c625-41a8-ba8b-855dae5195ae"));
            LogDate = (ITTDateTimePicker)AddControl(new Guid("dc2d114e-ec17-4008-a691-fd41696c9993"));
            labelLog = (ITTLabel)AddControl(new Guid("2bf87fc2-592c-4cde-a697-0d3fd278fb3e"));
            Log = (ITTTextBox)AddControl(new Guid("d221484b-c081-41a3-9fd1-66b775a5a3a4"));
            base.InitializeControls();
        }

        public ScheduledTaskHistoryForm() : base("SCHEDULEDTASKHISTORY", "ScheduledTaskHistoryForm")
        {
        }

        protected ScheduledTaskHistoryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}