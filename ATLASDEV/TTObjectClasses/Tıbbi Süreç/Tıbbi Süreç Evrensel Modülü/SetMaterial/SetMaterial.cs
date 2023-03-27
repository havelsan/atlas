
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
    public  partial class SetMaterial : BaseTreatmentMaterial
    {
#region Methods
        override public object GetDVO(AccountTransaction AccTrx)
        {
            HizmetKayitIslemleri.malzemeBilgisiDVO malzemeBilgisiDVO = new HizmetKayitIslemleri.malzemeBilgisiDVO();

            malzemeBilgisiDVO.adet = AccTrx.Amount;
            //malzemeBilgisiDVO.adetSpecified = true;
            //malzemeBilgisiDVO.barkod = !string.IsNullOrEmpty(AccTrx.Barcode) ? AccTrx.Barcode : Material.Barcode; // Set Malzemeler için barkod zorunlu değil bu yüzden kapatıldı
            malzemeBilgisiDVO.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
            malzemeBilgisiDVO.islemTarihi = AccTrx.MedulaTransactionDate;

            if (Material.MaterialVatRates != null && Material.MaterialVatRates.Count > 0)
            {
                if (Material.MaterialVatRates[0].VatRate != null)
                {
                    malzemeBilgisiDVO.kdv = Convert.ToInt32(Material.MaterialVatRates[0].VatRate.Value);
                    //malzemeBilgisiDVO.kdvSpecified = true;
                }
            }

            malzemeBilgisiDVO.malzemeTuru = "1"; // Set Malzemeler SUT Kodlu
            malzemeBilgisiDVO.malzemeKodu = AccTrx.MedulaMaterialCode;
            malzemeBilgisiDVO.kodsuzMalzemeFiyati = Convert.ToDouble(AccTrx.UnitPrice * AccTrx.Amount);
            //malzemeBilgisiDVO.kodsuzMalzemeFiyatiSpecified = true;
            malzemeBilgisiDVO.bransKodu = GetMedulaBransKodu();
            malzemeBilgisiDVO.drTescilNo = GetMedulaDrTescilNo(malzemeBilgisiDVO.bransKodu);

            // Set Malzemeler için Brans zorunlu değil bu yüzden kapatıldı
            //malzemeBilgisiDVO.malzemeBrans = this.Material.Brans != null ? this.Material.Brans.bransKodu : null;

            // Set Malzemeler için Satınalma Tarihi ve Firma Tanımlayıcı No zorunlu değil bu yüzden kapatıldı
            // Satınalma Tarihi ve Firma Tanımlayıcı No bilgilerine set içindeki malzemelerden ulaşılacak
            /*
             *  if (AccTrx.PurchaseDate.HasValue) // Burası değişti kod açılacak olursa buraya dikkat edilecek.
                    malzemeBilgisiDVO.malzemeSatinAlisTarihi = AccTrx.PurchaseDate.Value.ToShortDateString();

            foreach(BaseTreatmentMaterial subMaterial in this.SubMaterials)
            {
                if(string.IsNullOrEmpty(malzemeBilgisiDVO.malzemeSatinAlisTarihi))
                {
                    if (subMaterial.StockActionDetail != null && subMaterial.StockActionDetail.StockTransactions.Select("INOUT=2").Count > 0)
                    {
                        DateTime? satinAlisTarihi = subMaterial.StockActionDetail.StockTransactions.Select("INOUT=2")[0].GetPurchaseDate();
                        if (satinAlisTarihi != null)
                            malzemeBilgisiDVO.malzemeSatinAlisTarihi = satinAlisTarihi.Value.ToShortDateString();
                    }
                }
                
                if(string.IsNullOrEmpty(malzemeBilgisiDVO.firmaTanimlayiciNo))
                {
                    if (subMaterial.Material.Producer != null)
                        malzemeBilgisiDVO.firmaTanimlayiciNo = subMaterial.Material.Producer.Code != null ? subMaterial.Material.Producer.Code.ToString() : null;
                        //Burası kullanılıyor olacak// string.IsNullOrEmpty(AccTrx.ProducerCode) ? (this.Material.Producer != null && this.Material.Producer.Code.HasValue ? this.Material.Producer.Code.ToString() : null) : AccTrx.ProducerCode;
                }
            }
             */
            
            malzemeBilgisiDVO.paketHaric = AccTrx.MedulaPackageInOut;
            malzemeBilgisiDVO.katkiPayi = MedulaPatientShareExists(AccTrx);
            malzemeBilgisiDVO.donorId = DonorID;
            
            if (OzelDurum != null && OzelDurum.ozelDurumKodu != null)
                malzemeBilgisiDVO.ozelDurum = OzelDurum.ozelDurumKodu;

            if (CokluOzelDurum != null && CokluOzelDurum.Count > 0)
            {
                List<String> listCokluOzelDurum = new List<String>();
                foreach (CokluOzelDurum od in CokluOzelDurum)
                    listCokluOzelDurum.Add(od.OzelDurum.ozelDurumKodu);

                malzemeBilgisiDVO.cokluOzelDurum = listCokluOzelDurum.ToArray();
            }

            return malzemeBilgisiDVO;
        }
        
#endregion Methods

    }
}