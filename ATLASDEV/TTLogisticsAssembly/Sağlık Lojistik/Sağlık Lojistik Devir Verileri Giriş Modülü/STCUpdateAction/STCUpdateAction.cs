
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


namespace TTObjectClasses
{
    /// <summary>
    /// Sayım Tartı Çizelgesinin Güncellenmesi
    /// </summary>
    public  partial class STCUpdateAction : BaseAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            
            
            
            
            Dictionary<Guid, double> muvakkatlar = new Dictionary<Guid, double>();
            TTObjectContext readOnlyContext = new TTObjectContext(true);

            // Muvakkat Kontrolunun yapılması
            double mAmount = 0;
            double mainStoreAmount = 0;
            foreach (MCAction muvakkat in STCAction.MCActions)
            {
                mAmount = mAmount + (double)muvakkat.MuvakkatenVerilen;
                muvakkatlar.Add(muvakkat.Store.ObjectID, (double)muvakkat.MuvakkatenVerilen);
            }
            mainStoreAmount = (double)STCAction.Toplam - (double)STCAction.MuvakkatenVerilen;
            muvakkatlar.Add(STCAction.MainStoreDefinition.ObjectID, mainStoreAmount);
            if (mAmount != STCAction.MuvakkatenVerilen)
            {
                throw new TTException("Sayım Tartı Çizelgesinde " + STCAction.Material.Name + " isimli malzeme için girilen Muvakkaten Verilen miktar ile Muvvakkat Detaylarının Toplamı aynı olmalıdır!\r\n Muvakkaten Verilen :" + STCAction.MuvakkatenVerilen.ToString() + TTUtils.CultureService.GetText("M25053", "\r\n Muvakkat Detayları Toplamı :")+ mAmount.ToString());
            }

            //Demirbaş detaylarının kontrolünün yapılması
            if (STCAction.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
            {
                if (STCAction.DCActions.Count == STCAction.Toplam)
                {
                    bool err = false;
                    string errmsg = STCAction.Material.Name + " isimli Demirbaş Detaylarındaki Depo Bilgileri Hatalıdır.!!\r\n";
                    foreach (KeyValuePair<Guid, double> dc in muvakkatlar)
                    {
                        IList dcDetails = STCAction.DCActions.Select("STORE =" + ConnectionManager.GuidToString(dc.Key));
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
                else
                {
                    throw new TTException(STCAction.Material.Name + " isimli Malzemenin Demirbaş Detayları Eksiktir.\r\n Olması Gereken Detay :" + STCAction.Toplam.ToString() + TTUtils.CultureService.GetText("M25054", "\r\n Olan Detay :")+ STCAction.DCActions.Count.ToString());
                }
            }
            else
            {
                if (STCAction.DCActions.Count > 0)
                {
                    STCAction.DCActions.DeleteChildren();
                }
            }

            // Aynı Malzeme ve Aynı Masada aynı Sıra numaralı varmı kontrolü.
            if (STCAction.Material != null)
            {
                IList mdbTartilar = readOnlyContext.QueryObjects("STCACTION", "MATERIAL =" + ConnectionManager.GuidToString(STCAction.Material.ObjectID));
                if (mdbTartilar.Count > 1)
                {
                    throw new TTException(STCAction.Material.Name + " isimli malzeme daha önce girilmiştir.");
                }
            }
            else
            {
                throw new TTException(TTUtils.CultureService.GetText("M26403", "Malzeme seçmelisiniz!!"));
            }

            if (STCAction.SiraNu != null)
            {
                IList sdbTartilar = readOnlyContext.QueryObjects("STCACTION", "SIRANU = " + STCAction.SiraNu + " AND RESCARDDRAWER =" + ConnectionManager.GuidToString(STCAction.ResCardDrawer.ObjectID));
                if (sdbTartilar.Count > 1)
                {
                    throw new TTException(STCAction.ResCardDrawer.Name + " masaya " + STCAction.SiraNu.ToString() + " sıra numarası girilmiştir.");
                }
            }
            else
            {
                throw new TTException(STCAction.Material.Name + " isimli malzeme için Sıra Numarası Girmelisiniz.!!");
            }
            //Sarf Malzeme ve İlaçlarda Hek Mevcudunun sıfır olması kontrolü
            if (STCAction.HEKMevcut != null)
            {
                if (STCAction.Material is ConsumableMaterialDefinition || STCAction.Material is DrugDefinition)
                {
                    if (STCAction.HEKMevcut > 0)
                    {
                        throw new TTException(STCAction.Material.Name + "isimli malzeme için Hek Mevcudu 0 dan büyük giremezsiniz!!");
                    }
                }
            }

#endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(STCUpdateAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == STCUpdateAction.States.New && toState == STCUpdateAction.States.Completed)
                PreTransition_New2Completed();
        }

    }
}