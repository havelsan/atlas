
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
    public partial class QueuePriorityTemplateDefForm : TTDefinitionForm
    {
        protected TTObjectClasses.QueuePriorityTemplateDef _QueuePriorityTemplateDef
        {
            get { return (TTObjectClasses.QueuePriorityTemplateDef)_ttObject; }
        }

        protected ITTButton cmdPriorityDefs;
        protected ITTGrid QueueTemplatePriorityGridObjects;
        protected ITTTextBoxColumn OrderNoQueueTempPriorityGridObject;
        protected ITTListBoxColumn QueuePriorityDefinitionQueueTempPriorityGridObject;
        protected ITTEnumComboBoxColumn QueuePrioritySystem;
        protected ITTCheckBoxColumn OrderByRank;
        protected ITTLabel labelTemplateName;
        protected ITTTextBox TemplateName;
        override protected void InitializeControls()
        {
            cmdPriorityDefs = (ITTButton)AddControl(new Guid("60146391-2102-43d5-9cea-879e0c4860db"));
            QueueTemplatePriorityGridObjects = (ITTGrid)AddControl(new Guid("3025187d-9c5a-431b-80ec-31442340636a"));
            OrderNoQueueTempPriorityGridObject = (ITTTextBoxColumn)AddControl(new Guid("6dd43b81-5a4f-4822-8371-746c0ada30e5"));
            QueuePriorityDefinitionQueueTempPriorityGridObject = (ITTListBoxColumn)AddControl(new Guid("6c575529-e320-459b-b6f6-c99c391391d4"));
            QueuePrioritySystem = (ITTEnumComboBoxColumn)AddControl(new Guid("52e88511-856a-49cb-9faf-88a182f8b95f"));
            OrderByRank = (ITTCheckBoxColumn)AddControl(new Guid("6d773edc-fee6-4d39-8714-e51115bc6d79"));
            labelTemplateName = (ITTLabel)AddControl(new Guid("deb58bbd-d1d1-4f8e-a974-3b9314d81fef"));
            TemplateName = (ITTTextBox)AddControl(new Guid("cbe6e283-6257-459e-ae46-9b955b775afd"));
            base.InitializeControls();
        }

        public QueuePriorityTemplateDefForm() : base("QUEUEPRIORITYTEMPLATEDEF", "QueuePriorityTemplateDefForm")
        {
        }

        protected QueuePriorityTemplateDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}