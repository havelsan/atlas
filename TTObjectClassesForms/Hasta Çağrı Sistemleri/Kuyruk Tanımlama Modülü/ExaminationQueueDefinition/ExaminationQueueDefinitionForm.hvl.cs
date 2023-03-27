
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
    public partial class ExaminationQueueDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Randevu Kuyruğu Tanımlama
    /// </summary>
        protected TTObjectClasses.ExaminationQueueDefinition _ExaminationQueueDefinition
        {
            get { return (TTObjectClasses.ExaminationQueueDefinition)_ttObject; }
        }

        protected ITTLabel labelRecallCount;
        protected ITTTextBox RecallCount;
        protected ITTTextBox DivertTime;
        protected ITTTextBox Name;
        protected ITTTextBox DisplayPeriod;
        protected ITTCheckBox IsEmergencyQueue;
        protected ITTGrid ExQueueDefPriorityGridObjects;
        protected ITTTextBoxColumn OrderNo;
        protected ITTListBoxColumn QueuePriorityDefinitionExaminationQueueDefPriorityGridObj;
        protected ITTEnumComboBoxColumn PrioritySystem;
        protected ITTCheckBoxColumn OrderByRank;
        protected ITTLabel labelQueuePriorityTemplateDef;
        protected ITTObjectListBox QueuePriorityTemplateDef;
        protected ITTCheckBox NotAllowToSelectDoctor;
        protected ITTCheckBox IgnorePriority;
        protected ITTCheckBox IsActiveQueue;
        protected ITTLabel labelResSection;
        protected ITTObjectListBox ResPoliclinic;
        protected ITTLabel labelDivertTime;
        protected ITTLabel labelName;
        protected ITTLabel labelDisplayPeriod;
        override protected void InitializeControls()
        {
            labelRecallCount = (ITTLabel)AddControl(new Guid("286ec1b0-f313-4bfe-8689-0090e701d2c0"));
            RecallCount = (ITTTextBox)AddControl(new Guid("a61dd4ed-1e87-49f0-a6dd-cb3b8ca38697"));
            DivertTime = (ITTTextBox)AddControl(new Guid("4d9000cd-bcb6-47cd-88c6-4984c1728535"));
            Name = (ITTTextBox)AddControl(new Guid("92b699fd-549f-4e6c-baa2-6747d96442f0"));
            DisplayPeriod = (ITTTextBox)AddControl(new Guid("aa1674e3-41e6-4482-b3d3-de2577a7b09c"));
            IsEmergencyQueue = (ITTCheckBox)AddControl(new Guid("7b76e9ca-4177-4d90-a4e2-a81ba7a146e1"));
            ExQueueDefPriorityGridObjects = (ITTGrid)AddControl(new Guid("3408fe92-9c28-408f-9a18-93f7c4208f1e"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("f48156c2-be36-4485-b13c-fb5357974bf1"));
            QueuePriorityDefinitionExaminationQueueDefPriorityGridObj = (ITTListBoxColumn)AddControl(new Guid("2fbc1ca1-56ad-4288-b878-7dd2a34f2fb3"));
            PrioritySystem = (ITTEnumComboBoxColumn)AddControl(new Guid("b0f0603e-8cfa-4a0d-8003-94b0aae542aa"));
            OrderByRank = (ITTCheckBoxColumn)AddControl(new Guid("1db37b4c-cb94-482c-820d-ed7507f08843"));
            labelQueuePriorityTemplateDef = (ITTLabel)AddControl(new Guid("249ea0bd-c001-4efa-8fb3-bc31c0be12ab"));
            QueuePriorityTemplateDef = (ITTObjectListBox)AddControl(new Guid("74afe90d-055f-43e7-a815-b508cc0d4d87"));
            NotAllowToSelectDoctor = (ITTCheckBox)AddControl(new Guid("0ce9b672-3912-49e3-9797-d094b1843398"));
            IgnorePriority = (ITTCheckBox)AddControl(new Guid("3a45b385-1e44-4122-af71-0be1f14da3de"));
            IsActiveQueue = (ITTCheckBox)AddControl(new Guid("822209d8-f7f1-4287-931c-a052ba9e4853"));
            labelResSection = (ITTLabel)AddControl(new Guid("47996da4-26ff-46f8-bdd9-f7ccfae429f4"));
            ResPoliclinic = (ITTObjectListBox)AddControl(new Guid("2506e421-2e67-47d8-84f2-8b9168a756dc"));
            labelDivertTime = (ITTLabel)AddControl(new Guid("7cb4692c-512c-41c7-acd5-c370b9cf47ea"));
            labelName = (ITTLabel)AddControl(new Guid("8e4a7e8c-cb31-4012-b36b-1a5be0b1e83a"));
            labelDisplayPeriod = (ITTLabel)AddControl(new Guid("d2561476-31eb-4abb-ad7e-c6cca8f46dca"));
            base.InitializeControls();
        }

        public ExaminationQueueDefinitionForm() : base("EXAMINATIONQUEUEDEFINITION", "ExaminationQueueDefinitionForm")
        {
        }

        protected ExaminationQueueDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}