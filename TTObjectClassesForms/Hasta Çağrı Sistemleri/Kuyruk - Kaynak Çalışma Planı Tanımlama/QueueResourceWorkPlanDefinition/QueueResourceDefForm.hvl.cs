
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
    public partial class QueueResourceDefForm : TTDefinitionForm
    {
        protected TTObjectClasses.QueueResourceWorkPlanDefinition _QueueResourceWorkPlanDefinition
        {
            get { return (TTObjectClasses.QueueResourceWorkPlanDefinition)_ttObject; }
        }

        protected ITTCheckBox IsActiveInQueue;
        protected ITTLabel labelQueue;
        protected ITTObjectListBox Queue;
        protected ITTLabel labelResource;
        protected ITTObjectListBox Resource;
        protected ITTLabel labelWorkDate;
        protected ITTDateTimePicker WorkDate;
        override protected void InitializeControls()
        {
            IsActiveInQueue = (ITTCheckBox)AddControl(new Guid("52e65adc-8058-4168-9184-d1dbaaeb4791"));
            labelQueue = (ITTLabel)AddControl(new Guid("756d4b5c-fe16-4244-8c7d-fcc735cf7716"));
            Queue = (ITTObjectListBox)AddControl(new Guid("a23ca8c0-557e-4238-9554-cc297bf37500"));
            labelResource = (ITTLabel)AddControl(new Guid("91d49ce8-efa3-466b-b4fd-1eb1c90ce373"));
            Resource = (ITTObjectListBox)AddControl(new Guid("52d09fe9-3a33-4357-bafa-3f6b59eb54b4"));
            labelWorkDate = (ITTLabel)AddControl(new Guid("55a1b226-173b-43d7-93af-cf25e4f4fd22"));
            WorkDate = (ITTDateTimePicker)AddControl(new Guid("072889c3-cd85-4d19-b880-754ae0cfd3c7"));
            base.InitializeControls();
        }

        public QueueResourceDefForm() : base("QUEUERESOURCEWORKPLANDEFINITION", "QueueResourceDefForm")
        {
        }

        protected QueueResourceDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}