
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
    /// Bekleyen Tıbbi Cihaz İşleri
    /// </summary>
    public partial class WaitingCMRActionTaskForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Bekleyen Tıbbi Cihaz İşleri
    /// </summary>
        protected TTObjectClasses.WaitingCMRActionTask _WaitingCMRActionTask
        {
            get { return (TTObjectClasses.WaitingCMRActionTask)_ttObject; }
        }

        protected ITTTextBox ExpirationDay;
        protected ITTGrid ExpirationDateApproachingTaskUsers;
        protected ITTListBoxColumn User;
        protected ITTLabel labelExpirationDateApproachingTaskUsers;
        protected ITTLabel labelExpirationMonth;
        override protected void InitializeControls()
        {
            ExpirationDay = (ITTTextBox)AddControl(new Guid("377c9a33-9158-4f18-a35d-183afbf183e8"));
            ExpirationDateApproachingTaskUsers = (ITTGrid)AddControl(new Guid("7aff0d09-f710-4880-a1d3-2df3601176cb"));
            User = (ITTListBoxColumn)AddControl(new Guid("b20f2426-ea6c-452f-a325-4a3a1125b3b7"));
            labelExpirationDateApproachingTaskUsers = (ITTLabel)AddControl(new Guid("6136d904-c3ca-4c48-ab0a-679ac80fdf78"));
            labelExpirationMonth = (ITTLabel)AddControl(new Guid("09167c08-2a7b-4da1-be5c-3458d00a43bf"));
            base.InitializeControls();
        }

        public WaitingCMRActionTaskForm() : base("WAITINGCMRACTIONTASK", "WaitingCMRActionTaskForm")
        {
        }

        protected WaitingCMRActionTaskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}