
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
    /// Tedarik Şekli Tanımları
    /// </summary>
    public partial class PurchaseTypeDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.PurchaseTypeDefinition _PurchaseTypeDefinition
        {
            get { return (TTObjectClasses.PurchaseTypeDefinition)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Document;
        protected ITTCheckBoxColumn Mandatory;
        protected ITTCheckBox NeedsSufficiencyStep;
        protected ITTEnumComboBox PurchaseMainType;
        protected ITTTextBox PurchaseTypeName;
        protected ITTLabel labelPurchaseMainType;
        protected ITTLabel labelPurchaseTypeName;
        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckbox2;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("570a0dcb-db1f-4b73-8823-1be50eb79990"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("08f8e2b8-471d-4561-b90a-b447606cbffd"));
            Document = (ITTListBoxColumn)AddControl(new Guid("72011475-4524-43e0-83fd-2632a94444dc"));
            Mandatory = (ITTCheckBoxColumn)AddControl(new Guid("43045df5-f926-4efa-9a27-95459c5144d2"));
            NeedsSufficiencyStep = (ITTCheckBox)AddControl(new Guid("741b26d8-6652-4d71-bbd9-4097583d509f"));
            PurchaseMainType = (ITTEnumComboBox)AddControl(new Guid("207a4f99-c1a2-4d78-9231-291ed4e8d763"));
            PurchaseTypeName = (ITTTextBox)AddControl(new Guid("98df8746-b088-4723-b938-6d433adbbfe1"));
            labelPurchaseMainType = (ITTLabel)AddControl(new Guid("2fcf10e5-29f8-4e46-b28a-c26dd645e2c6"));
            labelPurchaseTypeName = (ITTLabel)AddControl(new Guid("f6e7aa97-7e56-4232-817d-e7ef7ac1521b"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("e4f049d6-5eb7-4fff-8d8f-9071fa8a4dc8"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("8716a016-53b0-4d4f-8f7b-e7eaba9d46be"));
            base.InitializeControls();
        }

        public PurchaseTypeDefinitionForm() : base("PURCHASETYPEDEFINITION", "PurchaseTypeDefinitionForm")
        {
        }

        protected PurchaseTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}