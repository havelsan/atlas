
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
    /// Mazleme Muvazene İstek
    /// </summary>
    public partial class MaterialStabilityRequestForm : CentralActionBaseForm
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
            labelDescription = (ITTLabel)AddControl(new Guid("140f85ee-7915-4445-a7fe-5c5dd6eabbc7"));
            Description = (ITTTextBox)AddControl(new Guid("30f46f2e-85ff-45c5-8dc3-cc97d52e6ee6"));
            Amount = (ITTTextBox)AddControl(new Guid("f039fcdf-2f22-4358-8375-b9184e5ae886"));
            labelAmount = (ITTLabel)AddControl(new Guid("ecebaa74-46bd-44a3-8a45-bb9ec83273ce"));
            labelReceiveAccountancy = (ITTLabel)AddControl(new Guid("2fb23402-02ae-4b9a-bbad-846d26ed4912"));
            ReceiveAccountancy = (ITTObjectListBox)AddControl(new Guid("e624f7c1-d6da-46b9-9756-4adb13e977b9"));
            labelSendingAccountancy = (ITTLabel)AddControl(new Guid("bb81506c-bea9-4471-a67b-0970106ec730"));
            SendingAccountancy = (ITTObjectListBox)AddControl(new Guid("cda0af25-ed7e-4ddc-aeb8-a9abda7b69d7"));
            labelMaterial = (ITTLabel)AddControl(new Guid("ef0fc54a-7130-48dc-bb6e-3bdcb1402781"));
            Material = (ITTObjectListBox)AddControl(new Guid("99895d5c-c5e9-4232-8d34-2d2d6e83a154"));
            base.InitializeControls();
        }

        public MaterialStabilityRequestForm() : base("MATERIALSTABILITYACTION", "MaterialStabilityRequestForm")
        {
        }

        protected MaterialStabilityRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}