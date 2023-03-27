
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
    public partial class DirectMaterialSupplyRequestForm : BaseDirectMaterialSupplyForm
    {
    /// <summary>
    /// Doğrudan Malzeme Tedarik 22f
    /// </summary>
        protected TTObjectClasses.DirectMaterialSupplyAction _DirectMaterialSupplyAction
        {
            get { return (TTObjectClasses.DirectMaterialSupplyAction)_ttObject; }
        }

        protected ITTTextBox XXXXXXKayitId;
        protected ITTTextBox XXXXXXMesaj;
        protected ITTLabel labelXXXXXXMesaj;
        protected ITTLabel labelXXXXXXKayitId;
        override protected void InitializeControls()
        {
            XXXXXXKayitId = (ITTTextBox)AddControl(new Guid("fe808475-be40-48ab-b548-8df9805b2492"));
            XXXXXXMesaj = (ITTTextBox)AddControl(new Guid("eed84956-7a18-4d72-bcf0-b667ec23a287"));
            labelXXXXXXMesaj = (ITTLabel)AddControl(new Guid("c9bb0746-e458-484c-8748-514b8ed8ac66"));
            labelXXXXXXKayitId = (ITTLabel)AddControl(new Guid("9018a42f-e0ce-4646-a1b1-e5131402b7ee"));
            base.InitializeControls();
        }

        public DirectMaterialSupplyRequestForm() : base("DIRECTMATERIALSUPPLYACTION", "DirectMaterialSupplyRequestForm")
        {
        }

        protected DirectMaterialSupplyRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}