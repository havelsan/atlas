
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
    /// Stok Ayırtma Temel Form
    /// </summary>
    public partial class BaseStockReservationForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region BaseStockReservationForm_Methods
        public Store SelectedStore = null;
        public Material SelectedMaterial = null;
        TTObjectContext _readOnlyObjectContext = new TTObjectContext(true);

        public Stock SelectedStock
        {
            get
            {
                Stock stock = null;
                
                Store store = this.Store.SelectedObject as Store;
                Material material = this.Material.SelectedObject as Material;
                IList stocks = TTObjectClasses.Stock.GetStoreMaterial(_readOnlyObjectContext, store.ObjectID, material.ObjectID);
                if (stocks.Count > 1)
                    throw new TTException("Birden fazla stok bulundu.\r\nİşlem yapılamaz.");
                if (stocks.Count == 0)
                    throw new TTException("Stok bulunamadı.\r\nİşlem yapılamaz.");
                stock = (Stock)stocks[0];
                
                return stock;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (SelectedStore == null || SelectedMaterial == null)
                throw new TTException("Depo ve Malzeme boş olamaz.");

            this.Store.SelectedObject = SelectedStore;
            this.Material.SelectedObject = SelectedMaterial;

            this.StoreStock.Text = SelectedStock.Inheld.ToString();
            this.ReservedAmount.Text = SelectedStock.ReservedAmount.ToString();
        }
        
#endregion BaseStockReservationForm_Methods
    }
}