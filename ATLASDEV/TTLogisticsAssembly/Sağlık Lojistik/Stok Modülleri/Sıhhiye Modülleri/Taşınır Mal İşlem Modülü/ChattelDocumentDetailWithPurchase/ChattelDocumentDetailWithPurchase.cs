
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
    public  partial class ChattelDocumentDetailWithPurchase : StockActionDetailIn
    {
#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew)
                StockLevelType = StockLevelType.NewStockLevel;
        }


        public Currency? GetUnitPriceWithInVat()
        {
            return UnitPriceWithInVat;
        }

        public void SetUnitPriceWithInVat(Currency? value)
        {
            UnitPriceWithInVat = value;
        }

        public BigCurrency? GetUnitPriceWithOutVat()
        {
            return UnitPriceWithOutVat;
        }

        public void GetUnitPriceWithOutVat(BigCurrency? value)
        {
            UnitPriceWithOutVat = value;
        }

        public void CalculatePricesWithKdv()
        {
            if(UnitPriceWithOutVat != null)
            {
                UnitPrice = UnitPriceWithOutVat;
                if(Amount != null && VatRate != null)
                {
                    BigCurrency kdvsizBirimFiyat = (BigCurrency)UnitPriceWithOutVat;
                    Currency miktar = (Currency)Amount;
                    long kdv = (long)VatRate;
                    double KdvOrani = Convert.ToDouble(kdv) / 100.0 ;
                    BigCurrency indirimOrani = 0;
                    
                    
                    BigCurrency birimFiyatKDVli = (BigCurrency)(kdvsizBirimFiyat + ((BigCurrency)kdvsizBirimFiyat * (BigCurrency)CurrencyType.ConvertFrom(KdvOrani)));
                    UnitPriceWithInVat = birimFiyatKDVli;
                    NotDiscountedUnitPrice = birimFiyatKDVli;
                    
                    if(DiscountRate != null)
                    {
                        indirimOrani  = (BigCurrency)DiscountRate;
                    }
                    BigCurrency indirimliBirimFiyat = (BigCurrency)(birimFiyatKDVli - (birimFiyatKDVli * indirimOrani / 100));
                    UnitPrice = indirimliBirimFiyat;
                    
                    BigCurrency indirimTutari = (birimFiyatKDVli - indirimliBirimFiyat) * (BigCurrency)miktar;
                    DiscountAmount = indirimTutari;
                    
                    BigCurrency toplamTutar = indirimliBirimFiyat  * (BigCurrency)miktar;
                    Price = toplamTutar;
                }
            }
        }
        
#endregion Methods

    }
}