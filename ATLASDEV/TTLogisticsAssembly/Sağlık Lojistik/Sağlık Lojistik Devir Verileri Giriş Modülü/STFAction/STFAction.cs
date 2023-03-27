
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
    /// Sayım Tartı Verilerinin Girilmesi 
    /// </summary>
    public  partial class STFAction : BaseAction, IWorkListBaseAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            

            foreach (STCAction stc in STCActions)
            {
                Dictionary<Guid, double> muvakkatlar = new Dictionary<Guid, double>();
                TTObjectContext readOnlyContext = new TTObjectContext(true);

                // Muvakkat Kontrolunun yapılması
                double mAmount = 0;
                double mainStoreAmount = 0;
                foreach (MCAction muvakkat in stc.MCActions)
                {
                    mAmount = mAmount + (double)muvakkat.MuvakkatenVerilen;
                    muvakkatlar.Add(muvakkat.Store.ObjectID, (double)muvakkat.MuvakkatenVerilen);
                }
                mainStoreAmount = (double)stc.Toplam - (double)stc.MuvakkatenVerilen;
                muvakkatlar.Add(stc.MainStoreDefinition.ObjectID, mainStoreAmount);
                if (mAmount != stc.MuvakkatenVerilen)
                {
                    throw new TTException("Sayım Tartı Çizelgesinde " + stc.Material.Name + " isimli malzeme için girilen Muvakkaten Verilen miktar ile Muvvakkat Detaylarının Toplamı aynı olmalıdır!\r\n Muvakkaten Verilen :" + stc.MuvakkatenVerilen.ToString() + TTUtils.CultureService.GetText("M25053", "\r\n Muvakkat Detayları Toplamı :")+ mAmount.ToString());
                }

                //Demirbaş detaylarının kontrolünün yapılması
                if (stc.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                {
                    bool err = false;
                    string errmsg = stc.Material.Name + " isimli Demirbaş Detaylarındaki Depo Bilgileri Hatalıdır.!!\r\n";
                    foreach (KeyValuePair<Guid, double> dc in muvakkatlar)
                    {
                        IList dcDetails = stc.DCActions.Select("STORE =" + ConnectionManager.GuidToString(dc.Key));
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

                // Aynı Malzeme ve Aynı Masada aynı Sıra numaralı varmı kontrolü.
                if (stc.Material != null)
                {
                    IList mdbTartilar = readOnlyContext.QueryObjects("STCACTION", "MATERIAL =" + ConnectionManager.GuidToString(stc.Material.ObjectID));
                    if (mdbTartilar.Count > 0)
                    {
                        throw new TTException(stc.Material.Name + " isimli malzeme daha önce girilmiştir.");
                    }

                    IList mlocalTartilar = ObjectContext.LocalQuery("STCACTION", "MATERIAL =" + ConnectionManager.GuidToString(stc.Material.ObjectID));
                    if (mdbTartilar.Count > 1)
                    {
                        throw new TTException(stc.Material.Name + " isimli malzeme daha önce girilmiştir.");
                    }
                }
                else
                {
                    throw new TTException(TTUtils.CultureService.GetText("M26403", "Malzeme seçmelisiniz!!"));
                }

                if (stc.SiraNu != null)
                {
                    IList sdbTartilar = readOnlyContext.QueryObjects("STCACTION", "SIRANU = " + stc.SiraNu + " AND RESCARDDRAWER =" + ConnectionManager.GuidToString(stc.ResCardDrawer.ObjectID));
                    if (sdbTartilar.Count > 0)
                    {
                        throw new TTException(stc.ResCardDrawer.Name + " masaya " + stc.SiraNu.ToString() + " sıra numarası girilmiştir.");
                    }
                    IList slocalTartilar = ObjectContext.LocalQuery("STCACTION", "SIRANU = " + stc.SiraNu + " AND RESCARDDRAWER =" + ConnectionManager.GuidToString(stc.ResCardDrawer.ObjectID));
                    if (slocalTartilar.Count > 1)
                    {
                        throw new TTException(stc.ResCardDrawer.Name + " masaya " + stc.SiraNu.ToString() + " sıra numarası girilmiştir.");
                    }
                }
                else
                {
                    throw new TTException( stc.Material.Name + " isimli malzeme için Sıra Numarası Girmelisiniz.!!");
                }
                //Sarf Malzeme ve İlaçlarda Hek Mevcudunun sıfır olması kontrolü
                if (stc.HEKMevcut != null)
                {
                    if (stc.Material is ConsumableMaterialDefinition || stc.Material is DrugDefinition)
                    {
                        if (stc.HEKMevcut > 0)
                        {
                            throw new TTException(stc.Material.Name + "isimli malzeme için Hek Mevcudu 0 dan büyük giremezsiniz!!");
                        }
                    }
                }
            }

#endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(STFAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == STFAction.States.New && toState == STFAction.States.Completed)
                PreTransition_New2Completed();
        }

    }
}