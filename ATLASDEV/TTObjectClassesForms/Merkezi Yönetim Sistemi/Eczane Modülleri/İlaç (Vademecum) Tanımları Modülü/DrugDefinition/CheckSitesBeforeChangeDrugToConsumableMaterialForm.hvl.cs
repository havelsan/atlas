
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
    public partial class CheckSitesBeforeChangeDrugToConsumableMaterialForm : TTForm
    {
    /// <summary>
    /// İlaç Tanımı
    /// </summary>
        protected TTObjectClasses.DrugDefinition _DrugDefinition
        {
            get { return (TTObjectClasses.DrugDefinition)_ttObject; }
        }

        protected ITTGrid controlGrid;
        protected ITTListBoxColumn site;
        protected ITTTextBoxColumn status;
        protected ITTTextBoxColumn action;
        protected ITTButton changeButton;
        protected ITTLabel resultTextLabel;
        protected ITTLabel resultLabel;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            controlGrid = (ITTGrid)AddControl(new Guid("fbd8aceb-5919-403d-ae65-6ecd95e69e5a"));
            site = (ITTListBoxColumn)AddControl(new Guid("3d3b503c-f3bd-42cb-9d55-264ced21b423"));
            status = (ITTTextBoxColumn)AddControl(new Guid("1f7b7f55-95a5-4ce3-bc16-9af0026b8fc0"));
            action = (ITTTextBoxColumn)AddControl(new Guid("cc341574-1020-45e3-983c-68657b860f6e"));
            changeButton = (ITTButton)AddControl(new Guid("d5454fa5-726f-4243-8b72-97dfb396b0bc"));
            resultTextLabel = (ITTLabel)AddControl(new Guid("526401d3-6dc7-44dc-bb5c-e1d12fd929d8"));
            resultLabel = (ITTLabel)AddControl(new Guid("fff0327d-71ca-47f1-bc11-fdfb1920dc33"));
            ttbutton1 = (ITTButton)AddControl(new Guid("b90edcbd-143b-4140-83d1-53da663c19b1"));
            base.InitializeControls();
        }

        public CheckSitesBeforeChangeDrugToConsumableMaterialForm() : base("DRUGDEFINITION", "CheckSitesBeforeChangeDrugToConsumableMaterialForm")
        {
        }

        protected CheckSitesBeforeChangeDrugToConsumableMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}