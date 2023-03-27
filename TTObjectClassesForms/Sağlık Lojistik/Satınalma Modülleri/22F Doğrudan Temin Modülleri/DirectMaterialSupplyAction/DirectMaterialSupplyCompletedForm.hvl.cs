
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
    /// Doğrudan Malzeme Tedarik 22F
    /// </summary>
    public partial class DirectMaterialSupplyCompletedForm : BaseDirectMaterialSupplyForm
    {
    /// <summary>
    /// Doğrudan Malzeme Tedarik 22f
    /// </summary>
        protected TTObjectClasses.DirectMaterialSupplyAction _DirectMaterialSupplyAction
        {
            get { return (TTObjectClasses.DirectMaterialSupplyAction)_ttObject; }
        }

        protected ITTButton SendToXXXXXX;
        protected ITTTextBox XXXXXXMesaj;
        protected ITTTextBox XXXXXXKayitId;
        protected ITTLabel labelXXXXXXMesaj;
        protected ITTLabel labelXXXXXXKayitId;
        override protected void InitializeControls()
        {
            SendToXXXXXX = (ITTButton)AddControl(new Guid("09a6907d-09a0-43fa-850b-c8f9ffb0fa8b"));
            XXXXXXMesaj = (ITTTextBox)AddControl(new Guid("afb0d694-33a8-4180-8a34-82bf006bf696"));
            XXXXXXKayitId = (ITTTextBox)AddControl(new Guid("2a09421e-ca13-4098-968a-f0691dfab85e"));
            labelXXXXXXMesaj = (ITTLabel)AddControl(new Guid("d6a2e949-fc0c-4373-86aa-2d161989a7f8"));
            labelXXXXXXKayitId = (ITTLabel)AddControl(new Guid("c7b719f3-8c0b-4671-b578-23858b56a725"));
            base.InitializeControls();
        }

        public DirectMaterialSupplyCompletedForm() : base("DIRECTMATERIALSUPPLYACTION", "DirectMaterialSupplyCompletedForm")
        {
        }

        protected DirectMaterialSupplyCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}