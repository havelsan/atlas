
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
    /// İstek Detayları
    /// </summary>
    public partial class ProjectRegistrationItemDetailsForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfına Bağlı Her Detayın/Kalemin Bağlı Olduğu Sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseProjectDetail _PurchaseProjectDetail
        {
            get { return (TTObjectClasses.PurchaseProjectDetail)_ttObject; }
        }

        protected ITTGrid DetailsGrid;
        protected ITTListBoxColumn DemaderUnit;
        protected ITTTextBoxColumn Amount;
        protected ITTRichTextBoxControlColumn SpToRef;
        protected ITTListBoxColumn Patient;
        protected ITTTextBoxColumn TechnicalSpecificationNo;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            DetailsGrid = (ITTGrid)AddControl(new Guid("111c017f-3060-4078-b619-423751b8621d"));
            DemaderUnit = (ITTListBoxColumn)AddControl(new Guid("a31d1cfc-e52d-4790-a0af-5ed1f04b2b2d"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("5ee84497-d467-4b54-9a48-d39142ef9344"));
            SpToRef = (ITTRichTextBoxControlColumn)AddControl(new Guid("dbee78c1-893d-4527-8757-a36beb7d932f"));
            Patient = (ITTListBoxColumn)AddControl(new Guid("1e7150de-e5cc-4987-aea2-fa01e7b9bfae"));
            TechnicalSpecificationNo = (ITTTextBoxColumn)AddControl(new Guid("21d33854-85b9-4b86-97c0-f22997ae1a0f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("1901a780-0db2-4c8d-af62-5ecd920e1c0d"));
            base.InitializeControls();
        }

        public ProjectRegistrationItemDetailsForm() : base("PURCHASEPROJECTDETAIL", "ProjectRegistrationItemDetailsForm")
        {
        }

        protected ProjectRegistrationItemDetailsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}