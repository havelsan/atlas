
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
    /// Bağlı Birlik Malzeme Mevcut Sorgualama Formu
    /// </summary>
    public partial class SubUnitMatInheldForm : TTForm
    {
    /// <summary>
    /// Bağlı Birlik Malzeme Mevcudu
    /// </summary>
        protected TTObjectClasses.SubUnitMaterialInheld _SubUnitMaterialInheld
        {
            get { return (TTObjectClasses.SubUnitMaterialInheld)_ttObject; }
        }

        protected ITTButton getSubInheld;
        protected ITTButton getInheld;
        protected ITTGrid SubUnitMatGrid;
        protected ITTListBoxColumn MaterialSubUnitMatGridClass;
        protected ITTTextBoxColumn StoreInheldSubUnitMatGridClass;
        protected ITTTextBoxColumn SubUniteMatInheldSubUnitMatGridClass;
        protected ITTTextBoxColumn DifferenceInheldSubUnitMatGridClass;
        override protected void InitializeControls()
        {
            getSubInheld = (ITTButton)AddControl(new Guid("41546be2-c126-483e-9373-d43b0749bb7a"));
            getInheld = (ITTButton)AddControl(new Guid("e7b083fc-6d23-41d0-b345-f00081472d88"));
            SubUnitMatGrid = (ITTGrid)AddControl(new Guid("93de1de6-ea1e-4785-bb05-d5f99b9316b1"));
            MaterialSubUnitMatGridClass = (ITTListBoxColumn)AddControl(new Guid("4f480406-caf0-4092-8fc9-f55ef515fcb7"));
            StoreInheldSubUnitMatGridClass = (ITTTextBoxColumn)AddControl(new Guid("12af6a41-6503-4cba-a093-9cbfba5000f8"));
            SubUniteMatInheldSubUnitMatGridClass = (ITTTextBoxColumn)AddControl(new Guid("48483cb8-4c6a-46f2-ac0f-dfdd62146927"));
            DifferenceInheldSubUnitMatGridClass = (ITTTextBoxColumn)AddControl(new Guid("fe7a12f8-9667-4cc1-abbb-edaefe4f0d4e"));
            base.InitializeControls();
        }

        public SubUnitMatInheldForm() : base("SUBUNITMATERIALINHELD", "SubUnitMatInheldForm")
        {
        }

        protected SubUnitMatInheldForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}