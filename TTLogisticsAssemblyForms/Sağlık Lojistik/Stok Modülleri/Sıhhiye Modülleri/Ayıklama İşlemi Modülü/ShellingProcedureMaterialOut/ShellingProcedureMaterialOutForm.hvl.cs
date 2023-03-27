
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
    /// İmha Edilenler
    /// </summary>
    public partial class ShellingProcedureMaterialOutForm : BaseStockActionDetailOutForm
    {
    /// <summary>
    /// Ayıklama işleminde artan malzeme detaylarını tutan sınıftır
    /// </summary>
        protected TTObjectClasses.ShellingProcedureMaterialOut _ShellingProcedureMaterialOut
        {
            get { return (TTObjectClasses.ShellingProcedureMaterialOut)_ttObject; }
        }

        protected ITTListBoxColumn FromAccountancy;
        protected ITTTabPage InMaterialTabpage;
        protected ITTGrid InMaterials;
        protected ITTListBoxColumn InMaterial;
        protected ITTListBoxColumn InDistributionType;
        protected ITTTextBoxColumn InAmount;
        protected ITTTextBoxColumn InUnitPrice;
        protected ITTListDefComboBoxColumn InStockLevelType;
        protected ITTEnumComboBoxColumn HEKResult;
        override protected void InitializeControls()
        {
            FromAccountancy = (ITTListBoxColumn)AddControl(new Guid("ff730d77-8de6-4e7d-9029-e0ac290969b0"));
            InMaterialTabpage = (ITTTabPage)AddControl(new Guid("d023c298-d900-4cd4-af32-844961730e17"));
            InMaterials = (ITTGrid)AddControl(new Guid("9a960fda-d634-4e1a-80ee-b3b0d099b529"));
            InMaterial = (ITTListBoxColumn)AddControl(new Guid("f0f04e94-441a-4d74-99a6-0391892809a8"));
            InDistributionType = (ITTListBoxColumn)AddControl(new Guid("00d6e053-a399-4015-827b-b24159107c0b"));
            InAmount = (ITTTextBoxColumn)AddControl(new Guid("a8d07fc6-ac02-4d5e-8112-ffb63487816a"));
            InUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("b28c043a-7853-4191-9f16-870e922529cb"));
            InStockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("3705d76d-1f32-48bd-98a2-200625b9b6aa"));
            HEKResult = (ITTEnumComboBoxColumn)AddControl(new Guid("5797d4fe-1230-40cd-834c-888c74a55891"));
            base.InitializeControls();
        }

        public ShellingProcedureMaterialOutForm() : base("SHELLINGPROCEDUREMATERIALOUT", "ShellingProcedureMaterialOutForm")
        {
        }

        protected ShellingProcedureMaterialOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}