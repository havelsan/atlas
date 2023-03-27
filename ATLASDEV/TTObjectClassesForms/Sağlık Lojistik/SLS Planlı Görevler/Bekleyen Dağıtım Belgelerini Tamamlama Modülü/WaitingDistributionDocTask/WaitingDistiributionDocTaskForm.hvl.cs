
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
    /// Bekleyen Dağıtım Belgelerini Tamamlama
    /// </summary>
    public partial class WaitingDistiributionDocTaskForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Bekleyen Dağıtım Belgelerini Tamamlama
    /// </summary>
        protected TTObjectClasses.WaitingDistributionDocTask _WaitingDistributionDocTask
        {
            get { return (TTObjectClasses.WaitingDistributionDocTask)_ttObject; }
        }

        protected ITTTextBox ExpirationDay;
        protected ITTLabel labelExpirationMonth;
        override protected void InitializeControls()
        {
            ExpirationDay = (ITTTextBox)AddControl(new Guid("5440c85d-e8c7-49ce-9403-df390ef717ca"));
            labelExpirationMonth = (ITTLabel)AddControl(new Guid("95ed0d65-3aed-4b81-add3-ebdca5573090"));
            base.InitializeControls();
        }

        public WaitingDistiributionDocTaskForm() : base("WAITINGDISTRIBUTIONDOCTASK", "WaitingDistiributionDocTaskForm")
        {
        }

        protected WaitingDistiributionDocTaskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}