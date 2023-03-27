
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
    /// Malzeme Detayları
    /// </summary>
    public partial class ResSubStoreConsumptionDetailForm : BaseStockActionDetailOutForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region ResSubStoreConsumptionDetailForm_ttbutton1_Click
   int start = 0;
            int end = 0;

            if (string.IsNullOrEmpty(startNo.Text) == false && string.IsNullOrEmpty(endNo.Text) == false && string.IsNullOrEmpty(seriNo.Text)== false)
            {
                start = Convert.ToInt32(startNo.Text);
                end = Convert.ToInt32(endNo.Text);
                if (start >= end)
                    throw new Exception("Başlangıç bitişten büyük olamaz.");
            }
            else
                throw new Exception("Başlangıç,Bitiş ve Seri Numaraları boş geçilemez.");

            IList stock = _ResSubStoreConsumptionDetail.ObjectContext.QueryObjects("STOCK", "MATERIAL = " + ConnectionManager.GuidToString(_ResSubStoreConsumptionDetail.Material.ObjectID) + "AND STORE = " + ConnectionManager.GuidToString(_ResSubStoreConsumptionDetail.ResSubStoreConsumption.Store.ObjectID));
            if (stock.Count > 0)
            {
                IList prescriptionPapers = _ResSubStoreConsumptionDetail.ObjectContext.QueryObjects("PRESCRIPTIONPAPER", "STOCK =" + ConnectionManager.GuidToString(((Stock)stock[0]).ObjectID));
                foreach (PrescriptionPaper prescriptionPaper in prescriptionPapers)
                {
                    if(prescriptionPaper.CurrentStateDefID == PrescriptionPaper.States.Usable)
                    {
                        if (prescriptionPaper.SerialNo.Equals(seriNo.Text))
                        {
                            if (Convert.ToInt32(prescriptionPaper.VolumeNo) >= start && Convert.ToInt32(prescriptionPaper.VolumeNo) <= end)
                            {
                                PrescriptionPaperOutDetail prescriptionPaperOutDetail = new PrescriptionPaperOutDetail(_ResSubStoreConsumptionDetail.ObjectContext);
                                prescriptionPaperOutDetail.PrescriptionPaper = prescriptionPaper;
                                prescriptionPaperOutDetail.StockActionDetailOut = _ResSubStoreConsumptionDetail;
                            }
                        }
                    }
                }
            }
#endregion ResSubStoreConsumptionDetailForm_ttbutton1_Click
        }

        protected override void PreScript()
        {
#region ResSubStoreConsumptionDetailForm_PreScript
    base.PreScript();
            PrescriptionPaperPrescriptionPaperOutDetail.ListFilterExpression = "STOCK.STORE=" + ConnectionManager.GuidToString(this._ResSubStoreConsumptionDetail.ResSubStoreConsumption.Store.ObjectID);
#endregion ResSubStoreConsumptionDetailForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ResSubStoreConsumptionDetailForm_PostScript
    base.PostScript(transDef);
            if( Convert.ToInt32(_ResSubStoreConsumptionDetail.Amount) != PrescriptionPaperOutDetails.Rows.Count )
            {
                throw new Exception("Reçete miktarı eksik girilmiştir.");
            }
#endregion ResSubStoreConsumptionDetailForm_PostScript

            }
                }
}