
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
    /// Stok Kontrolü
    /// </summary>
    public partial class StockControlForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            storelistbox.SelectedObjectChanged += new TTControlEventDelegate(storelistbox_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            storelistbox.SelectedObjectChanged -= new TTControlEventDelegate(storelistbox_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void storelistbox_SelectedObjectChanged()
        {
#region StockControlForm_storelistbox_SelectedObjectChanged
   TTObjectContext context = new TTObjectContext(true);
            Guid storeGuid = new Guid(storelistbox.SelectedValue.ToString());
            
            IList stockList = context.QueryObjects("Stock"," STORE= " + ConnectionManager.GuidToString(storeGuid));
            ((TTGrid)this.Inheldgrid).VirtualMode = false;
            ((TTGrid)this.Inheldgrid).Rows.Clear();
            
            if(stockList.Count == 0)
                throw new TTUtils.TTException("Seçtiğiniz depoda hiç malzeme bulunmamaktadır.");
            else
            {
                foreach (Stock stock in stockList)
                {
                    if (stock.Inheld > 0)
                        ((TTGrid)this.Inheldgrid).Rows.Add(new object[] {stock.Material.Name.ToString(),stock.Inheld.ToString()});
                }
            }
#endregion StockControlForm_storelistbox_SelectedObjectChanged
        }

#region StockControlForm_Methods
        //
        
#endregion StockControlForm_Methods
    }
}