
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class ProjectRegistrationForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdListDemands.Click += new TTControlEventDelegate(cmdListDemands_Click);
            cmdUncheckAll.Click += new TTControlEventDelegate(cmdUncheckAll_Click);
            cmdCheckAll.Click += new TTControlEventDelegate(cmdCheckAll_Click);
            ItemDetailsGrid.CellContentClick += new TTGridCellEventDelegate(ItemDetailsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdListDemands.Click -= new TTControlEventDelegate(cmdListDemands_Click);
            cmdUncheckAll.Click -= new TTControlEventDelegate(cmdUncheckAll_Click);
            cmdCheckAll.Click -= new TTControlEventDelegate(cmdCheckAll_Click);
            ItemDetailsGrid.CellContentClick -= new TTGridCellEventDelegate(ItemDetailsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void cmdListDemands_Click()
        {
#region ProjectRegistrationForm_cmdListDemands_Click
   ArrayList ResourcesColl = new ArrayList();
            ArrayList ItemColl = new ArrayList();
            ArrayList PIClassColl = new ArrayList();

            if (ResourcesGrid.Rows.Count > 0) //Servis Filtresi
            {
                for (int i = 0; i < ResourcesGrid.Rows.Count; i++)
                {
                    Resource resource = (Resource)_PurchaseProject.ObjectContext.GetObject((Guid)ResourcesGrid.Rows[i].Cells["Resource"].Value, "RESOURCE");
                    ResourcesColl.Add(resource);
                }
            }

            if (ItemsGrid.Rows.Count > 0) //PI Filtresi
            {
                for (int i = 0; i < ItemsGrid.Rows.Count; i++)
                {
                    PurchaseItemDef purchaseItemDef = (PurchaseItemDef)_PurchaseProject.ObjectContext.GetObject((Guid)ItemsGrid.Rows[i].Cells["PurchaseItem2"].Value, "PURCHASEITEMDEF");
                    ItemColl.Add(purchaseItemDef);
                }
            }

            _PurchaseProject.GetAvailableProjectDetails(ResourcesColl, ItemColl, PIClassColl);
            ItemDetailsGrid.RefreshRows();
#endregion ProjectRegistrationForm_cmdListDemands_Click
        }

        private void cmdUncheckAll_Click()
        {
#region ProjectRegistrationForm_cmdUncheckAll_Click
   foreach (ITTGridRow row in ItemDetailsGrid.Rows)
            {
                row.Cells["INCLUDE"].Value = false;
            }
#endregion ProjectRegistrationForm_cmdUncheckAll_Click
        }

        private void cmdCheckAll_Click()
        {
#region ProjectRegistrationForm_cmdCheckAll_Click
   foreach (ITTGridRow row in ItemDetailsGrid.Rows)
            {
                row.Cells["INCLUDE"].Value = true;
            }
#endregion ProjectRegistrationForm_cmdCheckAll_Click
        }

        private void ItemDetailsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ProjectRegistrationForm_ItemDetailsGrid_CellContentClick
   if (ItemDetailsGrid.CurrentCell == null)
                return;

            PurchaseProject myProject = _PurchaseProject;
            switch (ItemDetailsGrid.CurrentCell.OwningColumn.Name)
            {
                case "Details":
                    ProjectRegistrationItemDetailsForm prid = new ProjectRegistrationItemDetailsForm();
                    prid.ShowEdit(this.FindForm(), myProject.PurchaseProjectDetails[ItemDetailsGrid.CurrentCell.RowIndex]);
                    break;

                //                case "Release":
                //                    PurchaseProjectDetail ppd = (PurchaseProjectDetail)ItemDetailsGrid.CurrentCell.OwningRow.TTObject;
                //                    ppd.DemandDetails.Clear();
                //                    ((ITTObject)ppd).Delete();
                //                    _PurchaseProject.SetOrderNOs();
                //                    break;

                default:
                    break;

            }
#endregion ProjectRegistrationForm_ItemDetailsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region ProjectRegistrationForm_PreScript
    Guid hospGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            if (hospGuid == null)
                throw new TTUtils.TTException("Sistem parametrelerinden 'HOSPITAL' parametresini doldurmadan işleme devam edilemez.");

            ResHospital hosp = (ResHospital)_PurchaseProject.ObjectContext.GetObject(hospGuid, "RESHOSPITAL");
            if (hosp == null)
                throw new TTUtils.TTException("Kaynak ağacında bulunduğunuz sahanın XXXXXX tanımlanmamıştır. İşleme devam edilemez.");

            if (hosp.MilitaryUnit == null)
                throw new TTUtils.TTException("Bulunduğunuz XXXXXXnin bağlı olduğu birlik tanımlanmamıştır. İşleme devam edilemez.");

            Accountancy.ListFilterExpression = "ACCOUNTANCYMILITARYUNIT = '" + hosp.MilitaryUnit.ObjectID.ToString() + "'";
#endregion ProjectRegistrationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ProjectRegistrationForm_PostScript
    base.PostScript(transDef);

            ArrayList deleteList = new ArrayList();

            bool haveDetail = false;
            foreach (ITTGridRow row in ItemDetailsGrid.Rows)
            {
                if (row.Cells[Include.Name].Value != null)
                {
                    if ((bool)row.Cells[Include.Name].Value == false)
                        deleteList.Add((PurchaseProjectDetail)row.TTObject);
                    else
                        haveDetail = true;
                }
                else
                    deleteList.Add((PurchaseProjectDetail)row.TTObject);
            }

            if (!haveDetail)
                throw new TTUtils.TTException(SystemMessage.GetMessage(31));

            foreach (PurchaseProjectDetail ppd in deleteList)
            {
                ppd.DemandDetails.ClearChildren();
                ((ITTObject)ppd).Delete();
            }

            _PurchaseProject.SetOrderNOs();
#endregion ProjectRegistrationForm_PostScript

            }
                }
}