
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
    public partial class DentalQueue : TTForm
    {
    /// <summary>
    /// Diş İşlemi Randevusu
    /// </summary>
        protected TTObjectClasses.DentalQueue _DentalQueue
        {
            get { return (TTObjectClasses.DentalQueue)_ttObject; }
        }

        protected ITTDateTimePicker QueueDate;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox OrderNo;
        protected ITTTextBox Description;
        protected ITTObjectListBox TTListBoxProcedure;
        protected ITTObjectListBox TTListBoxPatient;
        protected ITTLabel labelOrderNo;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabelTooth;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            QueueDate = (ITTDateTimePicker)AddControl(new Guid("8334a0dc-5b0a-427e-86eb-a84397d04114"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("06630e3e-0bff-4212-a55c-7558fecd8ca8"));
            OrderNo = (ITTTextBox)AddControl(new Guid("5e8fc2dd-31d0-49fe-aef9-217f15b116d9"));
            Description = (ITTTextBox)AddControl(new Guid("2774c636-38c7-409e-be68-45a57bf5da71"));
            TTListBoxProcedure = (ITTObjectListBox)AddControl(new Guid("b1c8cd0a-896e-43d1-8bad-5dbc55bd5721"));
            TTListBoxPatient = (ITTObjectListBox)AddControl(new Guid("522e63ee-39a4-405a-bae0-a95c1c169887"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("c04cb6db-dcfe-4414-a465-7ca142ef8833"));
            labelDescription = (ITTLabel)AddControl(new Guid("b5b705f2-489f-4a2d-b278-62b7321e1c2c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("841ebfbd-8f11-4af8-83ef-19a946331fed"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5b210558-e636-4760-a678-36f4844de0f1"));
            ttlabelTooth = (ITTLabel)AddControl(new Guid("21d26356-13f6-4bf2-aaf0-d62664a152a9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("6931f16b-7da8-42c0-8986-2234aeb33259"));
            base.InitializeControls();
        }

        public DentalQueue() : base("DENTALQUEUE", "DentalQueue")
        {
        }

        protected DentalQueue(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}