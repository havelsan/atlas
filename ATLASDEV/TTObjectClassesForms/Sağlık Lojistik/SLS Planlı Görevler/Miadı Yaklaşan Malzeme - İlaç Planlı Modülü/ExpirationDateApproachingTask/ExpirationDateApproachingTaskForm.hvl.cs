
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
    /// Miadı Yaklaşan Malzeme / İlaçlar
    /// </summary>
    public partial class ExpirationDateApproachingTaskForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Miadı Yaklaşan Malzeme / İlaçlar
    /// </summary>
        protected TTObjectClasses.ExpirationDateApproachingTask _ExpirationDateApproachingTask
        {
            get { return (TTObjectClasses.ExpirationDateApproachingTask)_ttObject; }
        }

        protected ITTTextBox ExpirationMonth;
        protected ITTObjectListBox Store;
        protected ITTLabel labelStore;
        protected ITTLabel labelExpirationMonth;
        protected ITTLabel ttlabel4;
        protected ITTGrid ExpirationDateApproachingTaskUsers;
        protected ITTListBoxColumn User;
        protected ITTLabel labelExpirationDateApproachingTaskUsers;
        override protected void InitializeControls()
        {
            ExpirationMonth = (ITTTextBox)AddControl(new Guid("be066689-770b-405e-b4b8-2fb75d9c1d3e"));
            Store = (ITTObjectListBox)AddControl(new Guid("9402c87c-0ddf-445e-a960-f4e776268ec0"));
            labelStore = (ITTLabel)AddControl(new Guid("ca64f230-6086-40a7-b624-506e2f215209"));
            labelExpirationMonth = (ITTLabel)AddControl(new Guid("2837d490-5106-498a-a5e4-b8f430ff1c08"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f07ca719-5485-4461-9395-016865f24d15"));
            ExpirationDateApproachingTaskUsers = (ITTGrid)AddControl(new Guid("e3ace538-5cd2-4300-940a-3ac951adb0a2"));
            User = (ITTListBoxColumn)AddControl(new Guid("d65f5776-761b-48e8-b913-7b77987ba2a9"));
            labelExpirationDateApproachingTaskUsers = (ITTLabel)AddControl(new Guid("e2946875-cbef-4998-8b74-9025cbbd9f24"));
            base.InitializeControls();
        }

        public ExpirationDateApproachingTaskForm() : base("EXPIRATIONDATEAPPROACHINGTASK", "ExpirationDateApproachingTaskForm")
        {
        }

        protected ExpirationDateApproachingTaskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}