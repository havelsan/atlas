
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
    /// MKYS İhtiyaç Fazlası Sorgulama Formu
    /// </summary>
    public partial class MKYSExcessForm : TTForm
    {
        override protected void BindControlEvents()
        {
            this.btnHospitalExcessQuery.Click += new TTControlEventDelegate(btnHospitalExcessQuery_Click);
            this.btnExcessQuery.Click += new TTControlEventDelegate(btnExcessQuery_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            this.btnHospitalExcessQuery.Click -= new TTControlEventDelegate(btnHospitalExcessQuery_Click);
            this.btnExcessQuery.Click -= new TTControlEventDelegate(btnExcessQuery_Click);
            base.UnBindControlEvents();
        }

        private void btnHospitalExcessQuery_Click()
        {
            var existingStocks = this._SupplyRequestPoolDetail.ObjectContext.QueryObjects("STOCK", "MATERIAL='" + this._SupplyRequestPoolDetail.Material.ObjectID + "'" +" AND INHELD >="+ this._SupplyRequestPoolDetail.Amount);

            if (existingStocks.Count > 0)
            {
                foreach (Stock item in existingStocks)
                {
                    ITTGridRow addedRow = this.ihtiyacFazlasiItemsGrid.Rows.Add();

                    addedRow.Cells[malzemeKodu.Name].Value = String.IsNullOrEmpty(this._SupplyRequestPoolDetail.Material.StockCard.NATOStockNO) ? string.Empty : this._SupplyRequestPoolDetail.Material.StockCard.NATOStockNO;
                    addedRow.Cells[malzemeAdi.Name].Value = String.IsNullOrEmpty(this._SupplyRequestPoolDetail.Material.Name) ? string.Empty : this._SupplyRequestPoolDetail.Material.Name;

                    addedRow.Cells[adeti.Name].Value = item.Inheld.Value.ToString();

                    addedRow.Cells[birimAdi.Name].Value = String.IsNullOrEmpty(item.Store.Name) ? string.Empty : item.Store.Name;

                }
            }
        }

        private void btnExcessQuery_Click()
        {
            MkysServis.ihtiyacFazlasiKriterItem kriter = new MkysServis.ihtiyacFazlasiKriterItem();

            if (CityListBox.SelectedObject != null)
            {
                City city = (City)CityListBox.SelectedObject;
                kriter.ilAdi = city.Name;
            }

            if (!String.IsNullOrEmpty(birimTextBox.Text))
            {
                kriter.birimAdi = birimTextBox.Text;
            }

            kriter.malzemeAdi = NamePurchaseGroup.Text;
            kriter.malzemeKodu = CodePurchaseGroup.Text;

            MkysServis.ihtiyacFazlasiItem[] items = MkysServis.WebMethods.ihtiyacFazlasiGetDataSync(Sites.SiteLocalHost, kriter);


            foreach (MkysServis.ihtiyacFazlasiItem sinif in items)
            {
                ITTGridRow addedRow = this.ihtiyacFazlasiItemsGrid.Rows.Add();

                addedRow.Cells[siraNo.Name].Value = sinif.siraNo == null ? string.Empty : sinif.siraNo.ToString();
                addedRow.Cells[malzemeKodu.Name].Value = String.IsNullOrEmpty(sinif.malzemeKodu) ? string.Empty : sinif.malzemeKodu;
                addedRow.Cells[malzemeAdi.Name].Value = String.IsNullOrEmpty(sinif.malzemeAdi) ? string.Empty : sinif.malzemeAdi;
                addedRow.Cells[malzemeDigerAciklama.Name].Value = String.IsNullOrEmpty(sinif.malzemeDigerAciklama) ? string.Empty : sinif.malzemeDigerAciklama;
                addedRow.Cells[adeti.Name].Value = sinif.adeti.ToString();
                addedRow.Cells[vergiliBirimFiyat.Name].Value = sinif.vergiliBirimFiyat.ToString();
                addedRow.Cells[tarih.Name].Value = sinif.tarih;
                addedRow.Cells[ilAdi.Name].Value = String.IsNullOrEmpty(sinif.ilAdi) ? string.Empty : sinif.ilAdi;
                addedRow.Cells[ilKodu.Name].Value = String.IsNullOrEmpty(sinif.ilKodu) ? string.Empty : sinif.ilKodu;
                addedRow.Cells[birimAdi.Name].Value = String.IsNullOrEmpty(sinif.birimAdi) ? string.Empty : sinif.birimAdi;

            }

        }
    }
}