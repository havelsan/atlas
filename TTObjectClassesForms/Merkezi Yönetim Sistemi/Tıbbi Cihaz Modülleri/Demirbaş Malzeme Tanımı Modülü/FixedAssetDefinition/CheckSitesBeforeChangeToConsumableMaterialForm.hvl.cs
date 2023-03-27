
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
    public partial class CheckSitesBeforeChangeToConsumableMaterialForm : TTForm
    {
    /// <summary>
    /// Demirbaş Malzeme Bilgileri
    /// </summary>
        protected TTObjectClasses.FixedAssetDefinition _FixedAssetDefinition
        {
            get { return (TTObjectClasses.FixedAssetDefinition)_ttObject; }
        }

        protected ITTButton changeButton;
        protected ITTLabel resultTextLabel;
        protected ITTLabel resultLabel;
        protected ITTButton ttbutton1;
        protected ITTGrid controlGrid;
        protected ITTListBoxColumn site;
        protected ITTTextBoxColumn status;
        protected ITTTextBoxColumn action;
        override protected void InitializeControls()
        {
            changeButton = (ITTButton)AddControl(new Guid("cbbaa929-4912-4e95-89a6-f161efeb0fed"));
            resultTextLabel = (ITTLabel)AddControl(new Guid("4c099e64-ac7a-42e6-934d-9dd5966f2af3"));
            resultLabel = (ITTLabel)AddControl(new Guid("c1d95f60-ef35-4788-bfc1-4f7d4e077fbc"));
            ttbutton1 = (ITTButton)AddControl(new Guid("384ad664-50e0-4d48-843f-4e9772737b3d"));
            controlGrid = (ITTGrid)AddControl(new Guid("d2fde896-6a27-4d8c-a028-8e7d97da31e7"));
            site = (ITTListBoxColumn)AddControl(new Guid("7af302a5-c00a-4a4c-9561-c6492e35d626"));
            status = (ITTTextBoxColumn)AddControl(new Guid("98c8e4a5-d893-4da7-ae5c-4b6cf55dfd71"));
            action = (ITTTextBoxColumn)AddControl(new Guid("edb07346-e012-48a9-b5c9-5c55d1b4fd9d"));
            base.InitializeControls();
        }

        public CheckSitesBeforeChangeToConsumableMaterialForm() : base("FIXEDASSETDEFINITION", "CheckSitesBeforeChangeToConsumableMaterialForm")
        {
        }

        protected CheckSitesBeforeChangeToConsumableMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}