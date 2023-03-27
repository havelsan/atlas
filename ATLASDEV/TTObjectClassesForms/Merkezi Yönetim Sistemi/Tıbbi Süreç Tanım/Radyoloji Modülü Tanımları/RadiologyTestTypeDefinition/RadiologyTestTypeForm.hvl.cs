
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
    /// Radyoloji Tetkik Tür Tanım Formu
    /// </summary>
    public partial class RadiologyTestTypeForm : TTDefinitionForm
    {
    /// <summary>
    /// Radyoloji Tetkik Tür Tanımları
    /// </summary>
        protected TTObjectClasses.RadiologyTestTypeDefinition _RadiologyTestTypeDefinition
        {
            get { return (TTObjectClasses.RadiologyTestTypeDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Description;
        protected ITTTextBox EstimatedCompletionTime;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("83470898-879a-496b-bcc5-04ea5977a621"));
            Name = (ITTTextBox)AddControl(new Guid("55d8ed5e-c4b4-4f2f-8342-4bed2cac2a23"));
            Description = (ITTTextBox)AddControl(new Guid("b2c2e1e7-3344-470c-a635-9b266d209ff1"));
            EstimatedCompletionTime = (ITTTextBox)AddControl(new Guid("96ed0f7b-5416-4bf0-b07c-2d4ec6c9b844"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5575a531-bbc9-4bd9-ba30-149aea8edbca"));
            labelDescription = (ITTLabel)AddControl(new Guid("2e32e5ec-11ed-4ac1-b49b-b79186b8b1c9"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("88509c6c-a84e-429f-821a-05aad24f8235"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a8acb561-a8a3-4f20-be1a-bf4c6d93b58d"));
            base.InitializeControls();
        }

        public RadiologyTestTypeForm() : base("RADIOLOGYTESTTYPEDEFINITION", "RadiologyTestTypeForm")
        {
        }

        protected RadiologyTestTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}