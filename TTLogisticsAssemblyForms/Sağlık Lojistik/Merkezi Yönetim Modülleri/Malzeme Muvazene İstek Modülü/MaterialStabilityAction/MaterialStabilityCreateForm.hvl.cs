
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
    public partial class MaterialStabilityCreateForm : CentralActionBaseForm
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
            labelDescription = (ITTLabel)AddControl(new Guid("83274e1c-33a9-49e4-ba7c-ce65516d60da"));
            Description = (ITTTextBox)AddControl(new Guid("708bef78-5ab4-4575-ac3e-7ff6f103206c"));
            Amount = (ITTTextBox)AddControl(new Guid("e7209c79-31c0-419f-b457-9bfbba7e4455"));
            labelAmount = (ITTLabel)AddControl(new Guid("11bf0acc-3190-4566-beb6-87264a74c121"));
            labelReceiveAccountancy = (ITTLabel)AddControl(new Guid("ef467c60-8802-44db-ad61-935b7cbaa7c7"));
            ReceiveAccountancy = (ITTObjectListBox)AddControl(new Guid("d3c84fb5-eca7-4729-b9d1-c881e79a2b48"));
            labelSendingAccountancy = (ITTLabel)AddControl(new Guid("74c951df-10ee-4589-b57f-b6e22650b403"));
            SendingAccountancy = (ITTObjectListBox)AddControl(new Guid("a84a0d04-00df-459f-9c0d-5d1c04d19bb1"));
            labelMaterial = (ITTLabel)AddControl(new Guid("e820345a-6a2b-4b9b-b105-8b4fef688d50"));
            Material = (ITTObjectListBox)AddControl(new Guid("da3460fe-64e5-4f8c-9c3f-6c6f2259a670"));
            base.InitializeControls();
        }

        public MaterialStabilityCreateForm() : base("MATERIALSTABILITYACTION", "MaterialStabilityCreateForm")
        {
        }

        protected MaterialStabilityCreateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}