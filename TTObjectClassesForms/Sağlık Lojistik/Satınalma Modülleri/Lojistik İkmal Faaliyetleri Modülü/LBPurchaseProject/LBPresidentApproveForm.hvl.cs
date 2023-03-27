
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
    /// Kurmay Başkanı Onayı
    /// </summary>
    public partial class LBPresidentApproveForm : LBBaseForm
    {
    /// <summary>
    /// Lojistik İkmal Faliyetleri modülü temel sınıfıdır
    /// </summary>
        protected TTObjectClasses.LBPurchaseProject _LBPurchaseProject
        {
            get { return (TTObjectClasses.LBPurchaseProject)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTEnumComboBox IBFType;
        protected ITTMaskedTextBox IBFYear;
        protected ITTTextBox tttextbox1;
        protected ITTLabel IBFYearLabel;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTLabel IBFTypeLabel;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("c1785ce0-f61d-4555-b655-75129b65508f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c0b61e8f-103c-46a6-bd1c-ceaa5431e3bd"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("53f83a70-4c44-4cdd-91df-6f5fd68e0212"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("df6becb7-68d6-40c7-a7a1-882adac887af"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("40ea4e2a-ab8e-4fde-a361-afb030b03326"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("eab49648-5fcf-4ce8-a649-31a989358842"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("53054e15-7f29-4da7-904c-399d346e0618"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("d49d9338-7075-4a01-9860-e8cb85ae1683"));
            IBFTypeLabel = (ITTLabel)AddControl(new Guid("b6fab886-2056-4082-8241-2a0aa8fab4bf"));
            base.InitializeControls();
        }

        public LBPresidentApproveForm() : base("LBPURCHASEPROJECT", "LBPresidentApproveForm")
        {
        }

        protected LBPresidentApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}