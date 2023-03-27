
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
    /// Tıbbi Kayıt Emanet Eşya Tanımı
    /// </summary>
    public partial class QuarantineMaterialDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Tıbbi Kayıt Emanet Eşya Tanımları
    /// </summary>
        protected TTObjectClasses.QuarantineMaterialDefinition _QuarantineMaterialDefinition
        {
            get { return (TTObjectClasses.QuarantineMaterialDefinition)_ttObject; }
        }

        protected ITTLabel labelMaterialType;
        protected ITTEnumComboBox MaterialType;
        protected ITTLabel labelMaterial;
        protected ITTTextBox Material;
        override protected void InitializeControls()
        {
            labelMaterialType = (ITTLabel)AddControl(new Guid("5411c6cf-dead-42ae-b14f-1cf2e29ad1bc"));
            MaterialType = (ITTEnumComboBox)AddControl(new Guid("db6f769c-5921-49a2-9550-32772b33a12b"));
            labelMaterial = (ITTLabel)AddControl(new Guid("47832a31-1d9e-4256-b6af-613ec3ee209c"));
            Material = (ITTTextBox)AddControl(new Guid("fe3443e4-1b28-4f80-bd74-2521c0c8e87c"));
            base.InitializeControls();
        }

        public QuarantineMaterialDefinitionForm() : base("QUARANTINEMATERIALDEFINITION", "QuarantineMaterialDefinitionForm")
        {
        }

        protected QuarantineMaterialDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}