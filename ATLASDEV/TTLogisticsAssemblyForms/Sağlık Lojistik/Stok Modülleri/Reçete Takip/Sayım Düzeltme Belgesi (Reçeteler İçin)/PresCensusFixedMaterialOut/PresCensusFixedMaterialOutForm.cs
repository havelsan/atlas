
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
    public partial class PresCensusFixedMaterialOutForm : BaseStockActionDetailOutForm
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
#region PresCensusFixedMaterialOutForm_ttbutton1_Click
   int start = 0;
            int end = 0;

            if (string.IsNullOrEmpty(basNo.Text) == false && string.IsNullOrEmpty(bitNo.Text) == false && string.IsNullOrEmpty(seriNo.Text)== false)
            {
                start = Convert.ToInt32(basNo.Text);
                end = Convert.ToInt32(bitNo.Text);
                if (start >= end)
                    throw new Exception("Başlangıç bitişten büyük olamaz.");
            }
            else
                throw new Exception("Başlangıç,Bitiş ve Seri Numaraları boş geçilemez.");

            IList stock = _PresCensusFixedMaterialOut.ObjectContext.QueryObjects("STOCK", "MATERIAL = " + ConnectionManager.GuidToString(_PresCensusFixedMaterialOut.Material.ObjectID) + "AND STORE = " + ConnectionManager.GuidToString(_PresCensusFixedMaterialOut.PresCensusFixed.Store.ObjectID));
            if (stock.Count > 0)
            {
                IList prescriptionPapers = _PresCensusFixedMaterialOut.ObjectContext.QueryObjects("PRESCRIPTIONPAPER", "STOCK =" + ConnectionManager.GuidToString(((Stock)stock[0]).ObjectID));
                foreach (PrescriptionPaper prescriptionPaper in prescriptionPapers)
                {
                    if(prescriptionPaper.CurrentStateDefID == PrescriptionPaper.States.Usable)
                    {
                        if (prescriptionPaper.SerialNo.Equals(seriNo.Text))
                        {
                            if (Convert.ToInt32(prescriptionPaper.VolumeNo) >= start && Convert.ToInt32(prescriptionPaper.VolumeNo) <= end)
                            {
                                PrescriptionPaperOutDetail prescriptionPaperOutDetail = new PrescriptionPaperOutDetail(_PresCensusFixedMaterialOut.ObjectContext);
                                prescriptionPaperOutDetail.PrescriptionPaper = prescriptionPaper;
                                prescriptionPaperOutDetail.StockActionDetailOut = _PresCensusFixedMaterialOut;
                            }
                        }
                    }
                }
            }
#endregion PresCensusFixedMaterialOutForm_ttbutton1_Click
        }

        protected override void PreScript()
        {
#region PresCensusFixedMaterialOutForm_PreScript
    base.PreScript();
            
            PrescriptionPaperPrescriptionPaperOutDetail.ListFilterExpression = "STOCK.STORE=" + ConnectionManager.GuidToString(this._PresCensusFixedMaterialOut.PresCensusFixed.Store.ObjectID);
#endregion PresCensusFixedMaterialOutForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PresCensusFixedMaterialOutForm_PostScript
    base.PostScript(transDef);
            
            if( Convert.ToInt32(_PresCensusFixedMaterialOut.Amount) != PrescriptionPaperOutDetails.Rows.Count )
                throw new Exception("Reçete miktarı eksik girilmiştir.");
#endregion PresCensusFixedMaterialOutForm_PostScript

            }
                }
}