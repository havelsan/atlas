
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
    public partial class MaterialStabilityCompletedForm : CentralActionBaseForm
    {
    /// <summary>
    /// Malzeme Muvazene İstek
    /// </summary>
        protected TTObjectClasses.MaterialStabilityAction _MaterialStabilityAction
        {
            get { return (TTObjectClasses.MaterialStabilityAction)_ttObject; }
        }

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
            labelDescription = (ITTLabel)AddControl(new Guid("5e309c62-d120-4fa0-a3ac-8f23ae15b767"));
            Description = (ITTTextBox)AddControl(new Guid("2eddb2e3-6d99-4961-9b59-862203477247"));
            Amount = (ITTTextBox)AddControl(new Guid("d7d1b6f0-179d-4780-907f-131dccd2d628"));
            labelAmount = (ITTLabel)AddControl(new Guid("27db8b15-115e-4b4f-b3f3-2e04b69b0a93"));
            labelReceiveAccountancy = (ITTLabel)AddControl(new Guid("bae8951e-3a38-44a9-90a3-008f68a63ee7"));
            ReceiveAccountancy = (ITTObjectListBox)AddControl(new Guid("fa6cd555-38eb-49c1-a750-ca149ae89c2b"));
            labelSendingAccountancy = (ITTLabel)AddControl(new Guid("f396bcd8-ddc7-438a-92b1-62e9f4fc8ebe"));
            SendingAccountancy = (ITTObjectListBox)AddControl(new Guid("b49325cb-e524-440d-b823-d000f11c11f2"));
            labelMaterial = (ITTLabel)AddControl(new Guid("597ed0b8-5ca0-4f86-9a4c-4fc2ff4b3171"));
            Material = (ITTObjectListBox)AddControl(new Guid("bd793531-e235-4f74-9b38-cd4b4ceaeea9"));
            base.InitializeControls();
        }

        public MaterialStabilityCompletedForm() : base("MATERIALSTABILITYACTION", "MaterialStabilityCompletedForm")
        {
        }

        protected MaterialStabilityCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}