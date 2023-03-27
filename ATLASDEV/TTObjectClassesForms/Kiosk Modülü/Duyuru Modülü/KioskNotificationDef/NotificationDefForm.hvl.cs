
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
    public partial class NotificationDefForm : TTForm
    {
    /// <summary>
    /// Duyuru Modülü
    /// </summary>
        protected TTObjectClasses.KioskNotificationDef _KioskNotificationDef
        {
            get { return (TTObjectClasses.KioskNotificationDef)_ttObject; }
        }

        protected ITTLabel labelNotification;
        protected ITTTextBox Notification;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        override protected void InitializeControls()
        {
            labelNotification = (ITTLabel)AddControl(new Guid("1e86b510-7890-4cc3-9692-77f7e0f788c2"));
            Notification = (ITTTextBox)AddControl(new Guid("0583d60b-2ea6-4a83-b3b6-ac9c0e044e86"));
            labelEndDate = (ITTLabel)AddControl(new Guid("80975338-7999-467a-8fcb-6bf03f6f53cf"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("f952a3e7-bef7-4bca-8bb2-91342e1e89c1"));
            labelStartDate = (ITTLabel)AddControl(new Guid("2b704829-a3cd-4ec0-8430-20cc4d202480"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("958974e1-65bd-4bfb-ad95-fbda4ade4e04"));
            base.InitializeControls();
        }

        public NotificationDefForm() : base("KIOSKNOTIFICATIONDEF", "NotificationDefForm")
        {
        }

        protected NotificationDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}