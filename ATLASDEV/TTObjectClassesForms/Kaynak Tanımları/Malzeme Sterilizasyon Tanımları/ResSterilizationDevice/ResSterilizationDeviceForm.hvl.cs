
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
    public partial class ResSterilizationDeviceForm : TTDefinitionForm
    {
    /// <summary>
    /// Sterilizasyon Cihazları
    /// </summary>
        protected TTObjectClasses.ResSterilizationDevice _ResSterilizationDevice
        {
            get { return (TTObjectClasses.ResSterilizationDevice)_ttObject; }
        }

        protected ITTLabel labelResSterilizationUnit;
        protected ITTObjectListBox ResSterilizationUnit;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelResSterilizationUnit = (ITTLabel)AddControl(new Guid("bc0310ce-7565-4149-838f-e33b540ba84c"));
            ResSterilizationUnit = (ITTObjectListBox)AddControl(new Guid("425db52a-a8f5-4343-96b5-75d17c322fe8"));
            labelQref = (ITTLabel)AddControl(new Guid("b587dec1-07c5-42d8-a2cf-6ce36592e5cc"));
            Qref = (ITTTextBox)AddControl(new Guid("44511980-7989-4b1b-80d4-4297e2b1b4e2"));
            Name = (ITTTextBox)AddControl(new Guid("b1d6f8c2-f0f0-449f-9744-2250e5309119"));
            labelName = (ITTLabel)AddControl(new Guid("9e96c445-456b-4f6a-b1c1-1d02a1719145"));
            base.InitializeControls();
        }

        public ResSterilizationDeviceForm() : base("RESSTERILIZATIONDEVICE", "ResSterilizationDeviceForm")
        {
        }

        protected ResSterilizationDeviceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}