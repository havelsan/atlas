
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
    public partial class PresChaDocOutputDetWithAccountancyForm : BaseStockActionDetailOutForm
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
#region PresChaDocOutputDetWithAccountancyForm_ttbutton1_Click
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

            IList stock = _PresChaDocOutputDetWithAccountancy.ObjectContext.QueryObjects("STOCK", "MATERIAL = " + ConnectionManager.GuidToString(_PresChaDocOutputDetWithAccountancy.Material.ObjectID) + "AND STORE = " + ConnectionManager.GuidToString(_PresChaDocOutputDetWithAccountancy.PresChaDocOutputWithAccountancy.Store.ObjectID));
            if (stock.Count > 0)
            {
                IList prescriptionPapers = _PresChaDocOutputDetWithAccountancy.ObjectContext.QueryObjects("PRESCRIPTIONPAPER", "STOCK =" + ConnectionManager.GuidToString(((Stock)stock[0]).ObjectID));
                foreach (PrescriptionPaper prescriptionPaper in prescriptionPapers)
                {
                    if(prescriptionPaper.CurrentStateDefID == PrescriptionPaper.States.Usable)
                    {
                        if (prescriptionPaper.SerialNo.Equals(seriNo.Text))
                        {
                            if (Convert.ToInt32(prescriptionPaper.VolumeNo) >= start && Convert.ToInt32(prescriptionPaper.VolumeNo) <= end)
                            {
                                PrescriptionPaperOutDetail prescriptionPaperOutDetail = new PrescriptionPaperOutDetail(_PresChaDocOutputDetWithAccountancy.ObjectContext);
                                prescriptionPaperOutDetail.PrescriptionPaper = prescriptionPaper;
                                prescriptionPaperOutDetail.StockActionDetailOut = _PresChaDocOutputDetWithAccountancy;
                            }
                        }
                    }
                }
            }
#endregion PresChaDocOutputDetWithAccountancyForm_ttbutton1_Click
        }

        protected override void PreScript()
        {
#region PresChaDocOutputDetWithAccountancyForm_PreScript
    base.PreScript();

    PrescriptionPaperPrescriptionPaperOutDetail.ListFilterExpression = "STOCK.STORE=" + ConnectionManager.GuidToString(this._PresChaDocOutputDetWithAccountancy.PresChaDocOutputWithAccountancy.Store.ObjectID);
#endregion PresChaDocOutputDetWithAccountancyForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PresChaDocOutputDetWithAccountancyForm_PostScript
    base.PostScript(transDef);
           
                if( Convert.ToInt32(_PresChaDocOutputDetWithAccountancy.Amount) != PrescriptionPaperOutDetails.Rows.Count )
            {
            throw new Exception("Reçete miktarı eksik girilmiştir.");
            }
#endregion PresChaDocOutputDetWithAccountancyForm_PostScript

            }
                }
}