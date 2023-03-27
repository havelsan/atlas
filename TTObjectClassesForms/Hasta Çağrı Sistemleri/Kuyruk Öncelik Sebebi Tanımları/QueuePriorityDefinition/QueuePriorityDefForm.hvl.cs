
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
    public partial class QueuePriorityDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Kuyruk Öncelik Sebebi Tanımlar
    /// </summary>
        protected TTObjectClasses.QueuePriorityDefinition _QueuePriorityDefinition
        {
            get { return (TTObjectClasses.QueuePriorityDefinition)_ttObject; }
        }

        protected ITTLabel labelPriorityName;
        protected ITTTextBox PriorityName;
        override protected void InitializeControls()
        {
            labelPriorityName = (ITTLabel)AddControl(new Guid("08f6f464-10c3-45b3-ad8d-585a542e3e5a"));
            PriorityName = (ITTTextBox)AddControl(new Guid("b67d29f4-4d2a-4c40-ac3e-381c4323709b"));
            base.InitializeControls();
        }

        public QueuePriorityDefForm() : base("QUEUEPRIORITYDEFINITION", "QueuePriorityDefForm")
        {
        }

        protected QueuePriorityDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}