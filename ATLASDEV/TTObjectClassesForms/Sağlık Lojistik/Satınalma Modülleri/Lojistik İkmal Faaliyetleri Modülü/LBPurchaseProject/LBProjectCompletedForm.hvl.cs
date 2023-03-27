
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
    /// Tamamlanmış Proje
    /// </summary>
    public partial class LBProjectCompletedForm : LBBaseForm
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
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("13260997-86d9-4e6b-b6b2-7ec1c1976415"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ed66342a-8985-4ebc-83b7-c9461aba49fd"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("da9761ff-c5b5-4d8a-9135-0495f1eb26b1"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("148b95e2-4c02-4e1f-a0b3-de05982da917"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("20a4402c-a1ac-4782-8c01-d737a241d14a"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("d1437ec5-576d-46a3-bba7-2deadb03e8b9"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("7f53cd25-d875-4615-9809-21c6be8612b2"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("d05027b5-5b24-4b03-a878-6c8dcfd8fce7"));
            IBFTypeLabel = (ITTLabel)AddControl(new Guid("5a457ced-a081-4eae-8f46-cd1c96fadb03"));
            base.InitializeControls();
        }

        public LBProjectCompletedForm() : base("LBPURCHASEPROJECT", "LBProjectCompletedForm")
        {
        }

        protected LBProjectCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}