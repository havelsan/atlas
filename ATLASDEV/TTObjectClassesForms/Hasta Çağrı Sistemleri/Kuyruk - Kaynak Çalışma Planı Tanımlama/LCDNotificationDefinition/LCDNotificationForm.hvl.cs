
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
    public partial class LCDNotificationForm : TTDefinitionForm
    {
    /// <summary>
    /// LCD Bilgilendirme Tanımları
    /// </summary>
        protected TTObjectClasses.LCDNotificationDefinition _LCDNotificationDefinition
        {
            get { return (TTObjectClasses.LCDNotificationDefinition)_ttObject; }
        }

        protected ITTCheckBox IsActive;
        protected ITTLabel labelNotification;
        protected ITTTextBox Notification;
        override protected void InitializeControls()
        {
            IsActive = (ITTCheckBox)AddControl(new Guid("a8be4ce8-a8f7-419b-9c29-3f095f6580b9"));
            labelNotification = (ITTLabel)AddControl(new Guid("5e8e4c80-3ea2-4d6d-9a34-40108c894041"));
            Notification = (ITTTextBox)AddControl(new Guid("2dffa485-3303-4af7-9f19-3bc0ff836131"));
            base.InitializeControls();
        }

        public LCDNotificationForm() : base("LCDNOTIFICATIONDEFINITION", "LCDNotificationForm")
        {
        }

        protected LCDNotificationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}