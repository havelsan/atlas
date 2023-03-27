
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
    public partial class CheckSitesBeforeChangeToFixedAssetForm : TTForm
    {
    /// <summary>
    /// Sarf Edilebilen Malzeme Tanımları
    /// </summary>
        protected TTObjectClasses.ConsumableMaterialDefinition _ConsumableMaterialDefinition
        {
            get { return (TTObjectClasses.ConsumableMaterialDefinition)_ttObject; }
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
            changeButton = (ITTButton)AddControl(new Guid("95aa66ad-08f1-4b8e-9a0e-155d3a0ce4e9"));
            resultTextLabel = (ITTLabel)AddControl(new Guid("4ce1bc61-a2c5-4667-9618-8932f3c17375"));
            resultLabel = (ITTLabel)AddControl(new Guid("905ca171-7871-4d86-a6bf-b79a9d5cf139"));
            ttbutton1 = (ITTButton)AddControl(new Guid("5418fdc6-db03-43ae-8e17-917cb517c176"));
            controlGrid = (ITTGrid)AddControl(new Guid("ce6ddc9b-f9ee-412c-a986-681bb8f87729"));
            site = (ITTListBoxColumn)AddControl(new Guid("844918bf-662a-4185-985b-9ea9f39a9b58"));
            status = (ITTTextBoxColumn)AddControl(new Guid("e5aa3197-9493-40be-b919-2cd415453fca"));
            action = (ITTTextBoxColumn)AddControl(new Guid("c3506c6d-be94-4745-a255-e30711821526"));
            base.InitializeControls();
        }

        public CheckSitesBeforeChangeToFixedAssetForm() : base("CONSUMABLEMATERIALDEFINITION", "CheckSitesBeforeChangeToFixedAssetForm")
        {
        }

        protected CheckSitesBeforeChangeToFixedAssetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}