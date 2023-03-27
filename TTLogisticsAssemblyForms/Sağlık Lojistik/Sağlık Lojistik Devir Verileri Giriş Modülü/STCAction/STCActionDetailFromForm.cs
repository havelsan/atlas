
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
    /// Sayım Tartı Cizelgesi Detayları
    /// </summary>
    public partial class STCActionDetailFrom : TTForm
    {
        override protected void BindControlEvents()
        {
            MCActions.RowLeave += new TTGridCellEventDelegate(MCActions_RowLeave);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MCActions.RowLeave -= new TTGridCellEventDelegate(MCActions_RowLeave);
            base.UnBindControlEvents();
        }

        private void MCActions_RowLeave(Int32 rowIndex, Int32 columnIndex)
        {
#region STCActionDetailFrom_MCActions_RowLeave
   double mAmount = 0;
            double rmAmount = (double)_STCAction.MuvakkatenVerilen ;
            foreach (MCAction muvakkatlar in _STCAction.MCActions)
            {
                mAmount = mAmount + (double)muvakkatlar.MuvakkatenVerilen;
            }
            rmAmount = rmAmount - mAmount ;
            //ITTGridRow mcActionRow = MCActions.Rows[MCActions.CurrentCell.RowIndex];
            //MCAction mCAction = ((MCAction)mcActionRow.TTObject);
            //double rest = Convert.ToDouble(this.RestConsigned.Text) - (double)mCAction.MuvakkatenVerilen;
            this.RestConsigned.Text = rmAmount.ToString();
            // yazalım .
#endregion STCActionDetailFrom_MCActions_RowLeave
        }

        protected override void PreScript()
        {
#region STCActionDetailFrom_PreScript
    base.PreScript();
            double mAmount = 0;
            double rMAmount = (double)this._STCAction.MuvakkatenVerilen ;
            foreach (MCAction muvakkatlar in _STCAction.MCActions)
            {
                mAmount = mAmount + (double)muvakkatlar.MuvakkatenVerilen;
            }
            rMAmount = rMAmount - mAmount ;
            this.RestConsigned.Text = rMAmount.ToString();
            if(this._STCAction.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
            {
                if (this._STCAction.DCActions.Count != this._STCAction.Toplam)
                {
                    if (this._STCAction.Material == null || this._STCAction.Toplam == 0)
                        throw new TTException("Detayları girmeden önce Miktar girmeniz Malzeme seçmeniz gerekmektedir.\r\nMiktar : " + this._STCAction.Toplam);
                    
                    for (int i = 0; i < this._STCAction.Toplam ; i++)
                    {
                        DCAction dcAction = new DCAction(this._STCAction.ObjectContext);
                        dcAction.STCAction = this._STCAction;
                        //dcAction.Store = this._STCAction.MainStoreDefinition;
                    }
                }
            }
#endregion STCActionDetailFrom_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region STCActionDetailFrom_PostScript
    base.PostScript(transDef);
            Dictionary<Guid, double> muvakkatlar = new Dictionary<Guid,double>();
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            
            // Muvakkat Kontrolunun yapılması 
            double mAmount = 0;
            double mainStoreAmount = 0;
            foreach (MCAction muvakkat in this._STCAction.MCActions)
            {
                mAmount = mAmount + (double)muvakkat.MuvakkatenVerilen;
                muvakkatlar.Add(muvakkat.Store.ObjectID , (double)muvakkat.MuvakkatenVerilen);
            }
            mainStoreAmount = (double)this._STCAction.Toplam -(double) this._STCAction.MuvakkatenVerilen ;
            muvakkatlar.Add(this._STCAction.MainStoreDefinition.ObjectID, mainStoreAmount);
            if (mAmount != this._STCAction.MuvakkatenVerilen)
            {
                throw new TTException("Sayım Tartı Çizelgesinde " + this._STCAction.Material.Name + " isimli malzeme için girilen Muvakkaten Verilen miktar ile Muvvakkat Detaylarının Toplamı aynı olmalıdır!\r\n Muvakkaten Verilen :" + this._STCAction.MuvakkatenVerilen.ToString() + "\r\n Muvakkat Detayları Toplamı :" + mAmount.ToString());
            }

            //Demirbaş detaylarının kontrolünün yapılması 
            if (this._STCAction.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
            {
                bool err = false;
                string errmsg = "Demirbaş Detaylarındaki Depo Bilgileri Hatalıdır.!!\r\n";
                foreach (KeyValuePair<Guid, double> dc in muvakkatlar)
                {
                    IList dcDetails = _STCAction.DCActions.Select("STORE =" + ConnectionManager.GuidToString(dc.Key));
                    if (dcDetails.Count != dc.Value)
                    {
                        err = true;
                        Store storeNameObj = (Store)readOnlyContext.GetObject(dc.Key, "STORE");
                        errmsg = errmsg + storeNameObj.Name + " deposunda olması gereken Demirbaş Sayısı : " + dc.Value.ToString() + " Demirbaş Detayında olan Detay Sayısı : " + dcDetails.Count.ToString() + "\r\n";
                    }
                }
                if (err)
                {
                    throw new TTException(errmsg);
                }
            }
#endregion STCActionDetailFrom_PostScript

            }
                }
}