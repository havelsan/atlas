
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
    /// Malzeme Muvazene İstek
    /// </summary>
    public partial class MaterialStabilitySiteForm : CentralActionBaseForm
    {
    /// <summary>
    /// Malzeme Muvazene İstek
    /// </summary>
        protected TTObjectClasses.MaterialStabilityAction _MaterialStabilityAction
        {
            get { return (TTObjectClasses.MaterialStabilityAction)_ttObject; }
        }

        protected ITTButton cmdOutputDocument;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Amount;
        protected ITTLabel labelAmount;
        protected ITTLabel labelReceiveAccountancy;
        protected ITTObjectListBox ReceiveAccountancy;
        protected ITTLabel labelSendingAccountancy;
        protected ITTObjectListBox SendingAccountancy;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        override protected void InitializeControls()
        {
            cmdOutputDocument = (ITTButton)AddControl(new Guid("85e0703a-2cd5-4649-8abb-ec47d7ba4839"));
            labelDescription = (ITTLabel)AddControl(new Guid("43899846-860b-48bc-8ff4-1268a7494d50"));
            Description = (ITTTextBox)AddControl(new Guid("e278b126-b498-4814-b88f-9e88e197938f"));
            Amount = (ITTTextBox)AddControl(new Guid("0d1cbef2-ba9d-4058-a477-b92dc257b3a8"));
            labelAmount = (ITTLabel)AddControl(new Guid("9aa7522b-6435-41dc-853a-72d8921f2621"));
            labelReceiveAccountancy = (ITTLabel)AddControl(new Guid("05fa78bf-6c03-470c-82fa-d8082dad4cb2"));
            ReceiveAccountancy = (ITTObjectListBox)AddControl(new Guid("27fd47e0-c769-4b8e-97eb-c58f93bb6d52"));
            labelSendingAccountancy = (ITTLabel)AddControl(new Guid("0d95f97a-8ad0-4cf1-8dcd-ba64aa0c964f"));
            SendingAccountancy = (ITTObjectListBox)AddControl(new Guid("e2d8180f-7eb1-45a5-a428-1db0b853b1d8"));
            labelMaterial = (ITTLabel)AddControl(new Guid("ff3e74ef-e3d4-475e-8321-dded9e0e736a"));
            Material = (ITTObjectListBox)AddControl(new Guid("e6487991-68da-4881-8e6f-c748283cd568"));
            base.InitializeControls();
        }

        public MaterialStabilitySiteForm() : base("MATERIALSTABILITYACTION", "MaterialStabilitySiteForm")
        {
        }

        protected MaterialStabilitySiteForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}