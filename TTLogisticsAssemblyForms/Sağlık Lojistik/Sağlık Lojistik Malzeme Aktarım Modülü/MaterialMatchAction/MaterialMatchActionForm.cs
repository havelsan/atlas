
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
    /// <summary>
    /// Malzeme Aktarım
    /// </summary>
    public partial class MaterialMatchActionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            MatchMaterial.SelectedObjectChanged += new TTControlEventDelegate(MatchMaterial_SelectedObjectChanged);
            WrongMaterial.SelectedObjectChanged += new TTControlEventDelegate(WrongMaterial_SelectedObjectChanged);
            StockCard.SelectedObjectChanged += new TTControlEventDelegate(StockCard_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MatchMaterial.SelectedObjectChanged -= new TTControlEventDelegate(MatchMaterial_SelectedObjectChanged);
            WrongMaterial.SelectedObjectChanged -= new TTControlEventDelegate(WrongMaterial_SelectedObjectChanged);
            StockCard.SelectedObjectChanged -= new TTControlEventDelegate(StockCard_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void MatchMaterial_SelectedObjectChanged()
        {
#region MaterialMatchActionForm_MatchMaterial_SelectedObjectChanged
   if(MatchMaterial.SelectedObject != null)
            {
                Material currentMaterial = (Material)MatchMaterial.SelectedObject ;

                IList stocks = currentMaterial.Stocks.Select(string.Empty);
                foreach (Stock stock in stocks)
                {
                    ITTGridRow newRow = MStocks.Rows.Add();
                    newRow.Cells[0].Value = stock.Store.Name;
                    newRow.Cells[1].Value = stock.Inheld;
                    newRow.Cells[2].Value = stock.Consigned;
                    newRow.Cells[3].Value = stock.TotalIn;
                    newRow.Cells[4].Value = stock.TotalOut;
                }
            }
#endregion MaterialMatchActionForm_MatchMaterial_SelectedObjectChanged
        }

        private void WrongMaterial_SelectedObjectChanged()
        {
#region MaterialMatchActionForm_WrongMaterial_SelectedObjectChanged
   if(WrongMaterial.SelectedObject != null)
            {
                Material currentMaterial = (Material)WrongMaterial.SelectedObject ;

                IList stocks = currentMaterial.Stocks.Select(string.Empty);
                foreach (Stock stock in stocks)
                {
                    ITTGridRow newRow = WStocks.Rows.Add();
                    newRow.Cells[0].Value = stock.Store.Name;
                    newRow.Cells[1].Value = stock.Inheld;
                    newRow.Cells[2].Value = stock.Consigned;
                    newRow.Cells[3].Value = stock.TotalIn;
                    newRow.Cells[4].Value = stock.TotalOut;
                }
            }
#endregion MaterialMatchActionForm_WrongMaterial_SelectedObjectChanged
        }

        private void StockCard_SelectedObjectChanged()
        {
#region MaterialMatchActionForm_StockCard_SelectedObjectChanged
   //WrongMaterial.ListFilterExpression = "STOCKCARD =" + ConnectionManager.GuidToString((Guid)StockCard.SelectedObjectID) ;
            //MatchMaterial.ListFilterExpression = "STOCKCARD =" + ConnectionManager.GuidToString((Guid)StockCard.SelectedObjectID);
            
            MultiSelectForm wSelectForm = new MultiSelectForm();
            foreach (Material wMaterial in _MaterialMatchAction.StockCard.Materials)
                wSelectForm.AddMSItem(wMaterial.Name, wMaterial.ObjectID.ToString(), wMaterial);

            string wkey = wSelectForm.GetMSItem(this, "Mevcudun Bulunduğu Malzemeyi Seçin", true);
            if (string.IsNullOrEmpty(wkey))
                throw new TTException(SystemMessage.GetMessageV2(369, "Malzeme seçmeden işleme devam edemezsiniz."));
            _MaterialMatchAction.WrongMaterial = wSelectForm.MSSelectedItemObject as Material;

            MultiSelectForm mSelectForm = new MultiSelectForm();
            foreach (Material material in _MaterialMatchAction.StockCard.Materials)
            {
                if (material.Equals(_MaterialMatchAction.WrongMaterial) == false)
                    mSelectForm.AddMSItem(material.Name, material.ObjectID.ToString(), material);
            }
           
            string mkey = mSelectForm.GetMSItem(this, "Mevcudun Bulunması Gereken Malzemeyi Seçin", true);
            if (string.IsNullOrEmpty(mkey))
                throw new TTException(SystemMessage.GetMessageV2(369, "Malzeme seçmeden işleme devam edemezsiniz."));
            _MaterialMatchAction.MatchMaterial = mSelectForm.MSSelectedItemObject as Material;
#endregion MaterialMatchActionForm_StockCard_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region MaterialMatchActionForm_PreScript
    base.PreScript();
#endregion MaterialMatchActionForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region MaterialMatchActionForm_ClientSidePreScript
    base.ClientSidePreScript();
              MainStoreDefinition mainStore = CommonForm.SelectResourceDependentMainStoreDefinition(this);
            if (mainStore == null)
                throw new Exception("Kaynaklarınızın arasında Ana Deposu olan bir kaynak olmadığından işleme devam edemezsiniz.");
            _MaterialMatchAction.MainStoreDefinition = mainStore;
#endregion MaterialMatchActionForm_ClientSidePreScript

        }
    }
}