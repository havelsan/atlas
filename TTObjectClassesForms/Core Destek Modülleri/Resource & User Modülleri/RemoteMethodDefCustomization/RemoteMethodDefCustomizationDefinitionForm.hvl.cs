
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
    public partial class RemoteMethodDefCustomizationDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.RemoteMethodDefCustomization _RemoteMethodDefCustomization
        {
            get { return (TTObjectClasses.RemoteMethodDefCustomization)_ttObject; }
        }

        protected ITTLabel labelKeepDays;
        protected ITTTextBox KeepDays;
        protected ITTTextBox RemoteMethodDefName;
        protected ITTTextBox RemoteMethodDefID;
        protected ITTLabel labelSendingStartTime;
        protected ITTDateTimePicker SendingStartTime;
        protected ITTLabel labelSendingEndTime;
        protected ITTDateTimePicker SendingEndTime;
        protected ITTCheckBox IsKeepCompleted;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRemoteMethodDefName;
        protected ITTLabel labelRemoteMethodDefID;
        protected ITTGrid MessageQueueIterations;
        protected ITTEnumComboBoxColumn MessageQueueStatusRemoteMethodDefIteration;
        protected ITTTextBoxColumn IterationCountRemoteMethodDefIteration;
        protected ITTTextBoxColumn NextTrialRemoteMethodDefIteration;
        protected ITTCheckBoxColumn IsActiveRemoteMethodDefIteration;
        protected ITTCheckBox IsSendingStartStop;
        protected ITTCheckBox IsActive;
        protected ITTButton SelectRemoteMethodDefButton;
        override protected void InitializeControls()
        {
            labelKeepDays = (ITTLabel)AddControl(new Guid("52f3d4f5-4cf7-46dd-9656-000855e229b5"));
            KeepDays = (ITTTextBox)AddControl(new Guid("ce66933c-7c71-4bf4-9a4e-8f1fcf51a7a7"));
            RemoteMethodDefName = (ITTTextBox)AddControl(new Guid("813b98ce-4434-49c6-bc92-1899bad9892a"));
            RemoteMethodDefID = (ITTTextBox)AddControl(new Guid("ff0bede2-b758-4e6f-8c8d-13b2626007ce"));
            labelSendingStartTime = (ITTLabel)AddControl(new Guid("2e1b1254-7226-46fa-80ad-ae0860aecc9d"));
            SendingStartTime = (ITTDateTimePicker)AddControl(new Guid("5f3d7b7d-3808-4177-a477-4deb1c9a05d1"));
            labelSendingEndTime = (ITTLabel)AddControl(new Guid("e9fb08c6-3dee-4ebf-8242-88b9a9122ad8"));
            SendingEndTime = (ITTDateTimePicker)AddControl(new Guid("4a82f404-5c8c-4ed0-8ce4-c9fbb408298d"));
            IsKeepCompleted = (ITTCheckBox)AddControl(new Guid("91724866-8439-4072-b9ba-d103bd7e1b35"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e45c10f2-e32f-44eb-99ee-29de3f10de3e"));
            labelRemoteMethodDefName = (ITTLabel)AddControl(new Guid("bd096004-a10d-4d07-b38c-3f6aa4a630a2"));
            labelRemoteMethodDefID = (ITTLabel)AddControl(new Guid("eae471f0-2027-4291-912b-79246e59ae2f"));
            MessageQueueIterations = (ITTGrid)AddControl(new Guid("7d34cedf-6231-41d0-9413-897b87dd8bfb"));
            MessageQueueStatusRemoteMethodDefIteration = (ITTEnumComboBoxColumn)AddControl(new Guid("60331410-87d7-4454-91ca-4c7bb5ec306b"));
            IterationCountRemoteMethodDefIteration = (ITTTextBoxColumn)AddControl(new Guid("bc3b2d8c-4bea-4539-9a6e-4fba55eef3ce"));
            NextTrialRemoteMethodDefIteration = (ITTTextBoxColumn)AddControl(new Guid("e58148e8-919c-482c-b049-5b9f95cbd4d6"));
            IsActiveRemoteMethodDefIteration = (ITTCheckBoxColumn)AddControl(new Guid("e2613d0c-98f6-4b07-94b7-8b075bc9240c"));
            IsSendingStartStop = (ITTCheckBox)AddControl(new Guid("70d96079-1188-4533-b538-3caa3761ca83"));
            IsActive = (ITTCheckBox)AddControl(new Guid("c39a7aa3-c72b-4ddc-a580-b6c2efb7fda2"));
            SelectRemoteMethodDefButton = (ITTButton)AddControl(new Guid("42d8e5f8-6bfa-4fcc-9c6d-6338e8750d07"));
            base.InitializeControls();
        }

        public RemoteMethodDefCustomizationDefinitionForm() : base("REMOTEMETHODDEFCUSTOMIZATION", "RemoteMethodDefCustomizationDefinitionForm")
        {
        }

        protected RemoteMethodDefCustomizationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}