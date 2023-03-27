
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
    /// Grup Teklifleri
    /// </summary>
    public partial class GroupProposalsForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalmada İhale Tipi "Grup Toplam" İse, İHale Grupları İçin Kullanılan Sınıftır. Her Grup İçin Bir Adet Instance Yaratılır
    /// </summary>
        protected TTObjectClasses.PurchaseProjectGroup _PurchaseProjectGroup
        {
            get { return (TTObjectClasses.PurchaseProjectGroup)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid PurchaseProjectDetailGroupItems;
        protected ITTTextBoxColumn OrderNo;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTListBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn Amount;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid GroupProposalsGrid;
        protected ITTListBoxColumn Supplier;
        protected ITTTextBoxColumn TotalProposalPrice;
        protected ITTEnumComboBoxColumn Status;
        protected ITTLabel labelGroupName;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("b344ab7a-7190-4af8-b8de-12bac733ada8"));
            PurchaseProjectDetailGroupItems = (ITTGrid)AddControl(new Guid("930092df-e99c-4902-bbf0-e9d0b8f35bb7"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("27bec38e-cdaf-406e-8821-ce81e2257767"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("f673b19e-ce18-4d03-9fc2-f3960436527f"));
            PurchaseItemUnitType = (ITTListBoxColumn)AddControl(new Guid("dfe7c1fb-2c79-45ff-bf3b-5932eec37154"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("1a674cfc-ab95-41ee-b451-f10fbd19a8af"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f85d1257-4068-450b-8bfa-e7a66afb23cf"));
            GroupProposalsGrid = (ITTGrid)AddControl(new Guid("f7d839d3-cd08-42f4-b994-ce6635082a34"));
            Supplier = (ITTListBoxColumn)AddControl(new Guid("344db44d-f2f6-44e3-befa-13b5e6ad3fdb"));
            TotalProposalPrice = (ITTTextBoxColumn)AddControl(new Guid("aeede961-0945-469c-936b-c8714685965c"));
            Status = (ITTEnumComboBoxColumn)AddControl(new Guid("6c59feb3-bf87-4624-8955-e030490d85fe"));
            labelGroupName = (ITTLabel)AddControl(new Guid("fa6d04bf-8861-4487-a7a5-da42043f4cf8"));
            base.InitializeControls();
        }

        public GroupProposalsForm() : base("PURCHASEPROJECTGROUP", "GroupProposalsForm")
        {
        }

        protected GroupProposalsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}