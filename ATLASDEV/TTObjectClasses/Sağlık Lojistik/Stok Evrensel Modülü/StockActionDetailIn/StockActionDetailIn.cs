
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
    /// Stok hareketlerinde giriş detaylarını barındıran sınıftır. Stok modüllerindeki giriş tipindeki detay sınıfları bu sınıftan türer
    /// </summary>
    public  abstract  partial class StockActionDetailIn : StockActionDetail, IStockActionDetailIn
    {

        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion

        /// <summary>
        /// Toplam Tutar
        /// </summary>
        public BigCurrency? Price
        {
            get
            {
                try
                {
                    #region Price_GetScript                    
                    BigCurrency price = 0;
                    if (this is IChattelDocumentDetailWithPurchase)
                    {
                        BigCurrency priceWithKDV = 0;
                        priceWithKDV = (BigCurrency)((((IChattelDocumentDetailWithPurchase)this).GetUnitPriceWithOutVat() * (double)VatRate / 100) + ((IChattelDocumentDetailWithPurchase)this).GetUnitPriceWithOutVat()) * (double)Amount;
                        price = priceWithKDV - ((BigCurrency)DiscountAmount);
                    }
                    else
                    {
                        if (Amount.HasValue && UnitPrice.HasValue)
                            if (Amount.Value > 0 && UnitPrice.Value > 0)
                                price = (double)Amount.Value * (double)UnitPrice.Value;
                    }
                    return price;
#endregion Price_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "Price") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region Price_SetScript                    
                    //to fire property set event.
            return;
#endregion Price_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "Price") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "UNITPRICE":
                    {
                        BigCurrency? value = (BigCurrency?)newValue;
#region UNITPRICE_SetScript
                        Price = null;
#endregion UNITPRICE_SetScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

#region Methods
        public void CalculatePrices()
        {
            if(NotDiscountedUnitPrice != null)
            {
                UnitPrice = NotDiscountedUnitPrice;
                if(Amount != null && DiscountRate != null)
                {
                    BigCurrency indirimsizFiyat = (BigCurrency)NotDiscountedUnitPrice;
                    Currency miktar = (Currency)Amount;
                    BigCurrency indirimOrani = (BigCurrency)DiscountRate;

                    BigCurrency indirimliBirimFiyat = (BigCurrency)(indirimsizFiyat - (indirimsizFiyat * indirimOrani / 100));
                    UnitPrice = indirimliBirimFiyat;

                    BigCurrency indirimsizToplamFiyat = indirimsizFiyat * (BigCurrency)miktar;
                    TotalPriceNotDiscount = indirimsizToplamFiyat;

                    BigCurrency indirimliToplamFiyat = indirimliBirimFiyat * (BigCurrency)miktar;
                    Price = indirimliToplamFiyat;

                    BigCurrency toplamIndirim = indirimsizToplamFiyat - indirimliToplamFiyat;
                    TotalDiscountAmount = toplamIndirim;
                }
            }
        }

        #region barkodUpdate
        public static string SendBarkodUpdateMessageToMKYS(string mkysPwd,int MKYS_StokHareketID, string newBarcode)
        {
            string SonucMesaj = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                SonucMesaj = barkodUpdate(mkysPwd, MKYS_StokHareketID, newBarcode);
                if (String.IsNullOrEmpty(SonucMesaj))
                    SonucMesaj = TTUtils.CultureService.GetText("M26531", "MKYS barkod güncelleme işlemi başarısız!");
                return SonucMesaj;
            }
        }
        public static string barkodUpdate(string mkysPwd, int MKYS_StokHareketID, string newBarcode)
        {
            string SonucMesaj = string.Empty;
            try
            {
                MkysServis.mkysSonuc sonuc = MkysServis.WebMethods.barkodUpdateSync(Sites.SiteLocalHost, MKYS_StokHareketID, newBarcode);
                if (!sonuc.basariDurumu)
                {
                    throw new Exception("Barkod güncelleme başarısız!" + sonuc.mesaj);
                }
                else
                {
                    SonucMesaj += MKYS_StokHareketID.ToString() + " stok hareket id li işlemin barkodu güncellenmiştir." + sonuc.mesaj;
                }
                return SonucMesaj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion barkodUpdate

        #region IStockActionDetailIn Members
        public BigCurrency? GetNotDiscountedUnitPrice()
        {
            return NotDiscountedUnitPrice;
        }
        public void SetNotDiscountedUnitPrice(BigCurrency? value)
        {
            NotDiscountedUnitPrice = value;
        }

        public int? GetRetrievalYear()
        {
            return RetrievalYear;
        }
        public void SetRetrievalYear(int? value)
        {
            RetrievalYear = value;
        }

        public BigCurrency? GetDiscountAmount()
        {
            return DiscountAmount;
        }
        public void SetDiscountAmount(BigCurrency? value)
        {
            DiscountAmount = value;
        }

        public BigCurrency? GetDiscountRate()
        {
            return DiscountRate;
        }
        public void SetDiscountRate(BigCurrency? value)
        {
            DiscountRate = value;
        }

        public BigCurrency? GetUnitPrice()
        {
            return UnitPrice;
        }
        public void SetUnitPrice(BigCurrency? value)
        {
            UnitPrice = value;
        }

        public DateTime? GetExpirationDate()
        {
            return ExpirationDate;
        }
        public void SetExpirationDate(DateTime? value)
        {
            ExpirationDate = value;
        }

        public long? GetVatRate()
        {
            return VatRate;
        }
        public void SetVatRate(long? value)
        {
            VatRate = value;
        }
        #endregion
        #endregion Methods

    }
}