
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
    /// Stok Kart Tanımları
    /// </summary>
    public  partial class StockCard : TerminologyManagerDef
    {
        public partial class GetStockCardForGuideCard_Class : TTReportNqlObject 
        {
        }

        public partial class UndefinedStockCardForStore_Class : TTReportNqlObject 
        {
        }

        public partial class DoubleZeroCardQuery_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_StockCard_Class : TTReportNqlObject 
        {
        }

        public partial class GetStockCard_Class : TTReportNqlObject 
        {
        }

        public partial class GetStockCardInfoQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetStockCardPreReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_Stockcard_WithDate_Class : TTReportNqlObject 
        {
        }

        public partial class GetStockCardNSNObjectID_Class : TTReportNqlObject 
        {
        }

        public partial class GetStockCardStock_Class : TTReportNqlObject 
        {
        }

        public partial class GetOldOrderNoQuery_Class : TTReportNqlObject 
        {
        }

        
                    
        public string REN
        {
            get
            {
                try
                {
#region REN_GetScript                    
                    string ren = string.Empty;
                    if (RepairCheckbox.HasValue && RepairCheckbox.Value == true)
                        ren = TTUtils.CultureService.GetText("M27032", "Tamir Edilebilir");
                    if (ProductionCheckbox.HasValue && ProductionCheckbox.Value == true)
                        ren = TTUtils.CultureService.GetText("M26797", "Sarf Edilebilir");
                    return string.IsNullOrEmpty(ren) ? TTUtils.CultureService.GetText("M25270", "Belirlenmemiş"): ren;
#endregion REN_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "REN") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            
            BindingList<StockCard> cards = StockCard.GetStockCardByNATOStockNo(ObjectContext, NATOStockNO);
            
            Guid localSiteGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            
            if(cards.Count > 1 && localSiteGuid.ToString() == "c23c102e-250f-4f3b-b1c6-dc607fecc9e9")
                throw new TTUtils.TTException(SystemMessage.GetMessage(584));
            
            if(NATOStockNO.Substring(0,1) != "*")
            {
                if(NATOStockNO.Length != 13 && CreatedSite.ObjectID.ToString() == "c23c102e-250f-4f3b-b1c6-dc607fecc9e9")
                    throw new TTUtils.TTException(SystemMessage.GetMessage(585));
            }


            StockCardRepeatCheck();

            if (Status == null)
                Status = StockCardStatusEnum.NewCard;

            if (IsActive == null)
                IsActive = true;



#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            
            base.PostInsert();
            //SyncronizeWithPurchaseItem();

#endregion PostInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            StockCardRepeatCheck();
            if (DistributionType == null)
            {
                throw new TTException(TTUtils.CultureService.GetText("M26954", "Stok kartının dağıtım şekli boş olamaz."));
            }
#endregion PreUpdate
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();
            //SyncronizeWithPurchaseItem();

#endregion PostUpdate
        }

#region Methods
        public override string ToString()
        {
            return NATOStockNO + " " + Name;
        }
        
        
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew && CreatedSite == null)
                CreatedSite = SystemParameter.GetSite();
        }

        private void SyncronizeWithPurchaseItem()
        {
            ResHospital hospital = Common.GetCurrentHospital(ObjectContext);
            if(hospital.Site.ObjectID != Sites.SiteMerkezSagKom)
                return;
            
            PurchaseItemDef pItem = null;
            IBindingList pItems = PurchaseItemDef.GetPurchaseItemByStockCard(ObjectContext, ObjectID.ToString());
            if (pItems.Count == 0)
            {
                pItem = new PurchaseItemDef(ObjectContext);
                pItem.StockCard = this;
            }
            else if (pItems.Count == 1)
                pItem = (PurchaseItemDef)pItems[0];
            else
                return;
            
            pItem.IsActive = IsActive;
            pItem.ItemName = Name;
            if(pItem != null)
                TerminologyManagerDef.RunSendWithTerminologyManagerDef(pItem);
        }

        /// <summary>
        /// Benzer isimde stockcard'ların daha önceden girilmesi durumunu kontrol etmektedir.
        /// </summary>
        private void StockCardRepeatCheck()
        {
            // Bu kontrol burada yapılmamalı, burada yapıldığında Eski hospPOC dan veri atmak mümkün olmuyor.
            // Burada birebir aynı isimli kart kontrolü yapılmalı.
            // Bu kontrol form postta yapılarak kullanıcıya sadece uyarı verilmeli devam etmek isteyip istemediği sorulmalıdır.
            return;

            //            string message = "", word = "";
            //            int count = 0;
            //            string words = this.Name;
            //
            //            string[] split = words.Split(new Char[] {' '},StringSplitOptions.RemoveEmptyEntries);
            //
            //            foreach (string s in split)
            //            {
            //                if(count == split.GetUpperBound(0))
            //                {
            //                    word += "NAME LIKE " + "'%" + s + "%'" ;
            //                }
            //                else
            //                {
            //                    word += "NAME LIKE " + "'%" + s + "%'" + "AND ";
            //                    count++;
            //                }
            //            }
            //
            //            IList stockCardName = this.ObjectContext.QueryObjects("STOCKCARD",word);
            //            ITTObject ttObject = (ITTObject)this;
            //            if(ttObject.IsNew)
            //            {
            //                foreach (StockCard stockCard in stockCardName)
            //                {
            //
            //                    message = message +"\r\n" + stockCard.Name;
            //                }
            //                if (message != "")
            //                    throw new Exception(message + " Stok Kartları daha önceden girilmiştir.");
            //            }
        }



        public bool IsExist()
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            BindingList<StockCard> oldStockCards = StockCard.GetStockCardInfo(objectContext, ObjectID.ToString());

            if (oldStockCards != null && oldStockCards.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public AccountancyStockCard GetAccountancyStockCard( Accountancy accountancy)
        {
            AccountancyStockCard accountancyStockCard = null;
            foreach(AccountancyStockCard aStockCard in AccountancyStockCards)
            {
                if (aStockCard.Accountancy.ObjectID.Equals(accountancy.ObjectID))
                    accountancyStockCard = aStockCard;
            }
            return accountancyStockCard ;
        }

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.StockCardDefinitionInfo;
        }

        public override bool IsActiveLocal()
        {
            return false;
        }
        
        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if (localPropertyNamesList == null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("CardAmount");
            localPropertyNamesList.Add("CardOrderNO");
            localPropertyNamesList.Add("StockGuideCard");
            localPropertyNamesList.Add("Status");
            localPropertyNamesList.Add("Description");
            localPropertyNamesList.Add("CardDrawer");
            return localPropertyNamesList;
        }
        
#endregion Methods

    }
}