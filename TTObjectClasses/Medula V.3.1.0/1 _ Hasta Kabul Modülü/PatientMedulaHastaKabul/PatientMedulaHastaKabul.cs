
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
    public  partial class PatientMedulaHastaKabul : TTObject
    {
#region Methods
        public string ShowSummary()
        {
            string retValue = string.Empty;

            if (BaseHastaKabul != null && BaseHastaKabul.provizyonGirisDVO != null && BaseHastaKabul.provizyonGirisDVO.provizyonCevapDVO != null && BaseHastaKabul.provizyonGirisDVO.provizyonCevapDVO.hastaBilgileri != null)
            {
                retValue += "Provizyon Tarihi : " + BaseHastaKabul.provizyonGirisDVO.provizyonTarihi + "\r\n";
                retValue += "Takip Numarası : " + BaseHastaKabul.provizyonGirisDVO.provizyonCevapDVO.takipNo + "\r\n";
                retValue += "Hasta Başvuru Numarası : " + BaseHastaKabul.provizyonGirisDVO.provizyonCevapDVO.hastaBasvuruNo + "\r\n";
                retValue += "Sigortalı Türü : " + SigortaliTuru.GetSigortaliTuru(BaseHastaKabul.provizyonGirisDVO.provizyonCevapDVO.hastaBilgileri.sigortaliTuru).ToString() + "\r\n";
                retValue += "Branş : " + SpecialityDefinition.GetBrans(BaseHastaKabul.provizyonGirisDVO.bransKodu).ToString() + "\r\n";
                retValue += "Hastanın Devredilen Kurumu : " + DevredilenKurum.GetDevredilenKurum(BaseHastaKabul.provizyonGirisDVO.devredilenKurum).ToString() + "\r\n";
                retValue += "Provizyon Tipi : " + ProvizyonTipi.GetProvizyonTipi(BaseHastaKabul.provizyonGirisDVO.provizyonTipi).ToString() + "\r\n";
                retValue += "Takip Tipi : " + TakipTipi.GetTakipTipi(BaseHastaKabul.provizyonGirisDVO.takipTipi).ToString() + "\r\n";
                retValue += "Tedavi Türü : " + TedaviTuru.GetTedaviTuru(BaseHastaKabul.provizyonGirisDVO.tedaviTuru).ToString() + "\r\n";
                retValue += "Tedavi Tipi : " + TedaviTipi.GetTedaviTipi(BaseHastaKabul.provizyonGirisDVO.tedaviTipi).ToString() + "\r\n";
            }

            return retValue;
        }
        
        // Medulaya fatura kaydı yapılabilir durumda ise True, değilse False döndürür
        public bool IsReadyForInvoice()
        {
            /*
            foreach (DiagnosisGrid diagnosis in this.DiagnosisGrids)
            {
                if (!diagnosis.CanBeInvoicedToMedula())  // Medulaya kaydı başarıyla yapılmamış tanılar
                    return false;
            }
             
            foreach (SubActionProcedure sp in this.SubActionProcedures)
            {
                foreach(AccountTransaction AccTrx in sp.AccountTransactions)
                {
                    if (AccTrx.IsMedulaAccountTransaction() && AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && !AccTrx.CanBeInvoicedToMedula())
                        return false;
                }
            }
            
            foreach (SubActionMaterial sm in this.SubActionMaterials)
            {
                foreach(AccountTransaction AccTrx in sm.AccountTransactions)
                {
                    if (AccTrx.IsMedulaAccountTransaction() && AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && !AccTrx.CanBeInvoicedToMedula())
                        return false;
                }
            }
            */
            return true;
        }
        
        // Medulaya kaydedilebilir durumda hizmet, malzeme veya tanı varsa True, yoksa False döndürür
        public bool RegisterableItemExists()
        {
            /*
            foreach (DiagnosisGrid diagnosis in this.DiagnosisGrids)
            {
                if (diagnosis.CanBeRegisteredToMedula())  // Medulaya kaydı başarıyla yapılmamış tanılar
                    return true;
            }
             
            foreach (SubActionProcedure sp in this.SubActionProcedures)
            {
                foreach(AccountTransaction AccTrx in sp.AccountTransactions)
                {
                    if (AccTrx.CanBeRegisteredToMedula())
                        return true;
                }
            }
            
            foreach (SubActionMaterial sm in this.SubActionMaterials)
            {
                foreach(AccountTransaction AccTrx in sm.AccountTransactions)
                {
                    if (AccTrx.CanBeRegisteredToMedula())
                        return true;
                }
            }
            */
            return false;
        }
        
        public virtual List<AccountTransaction> RegisterableAccountTransactions
        {
            get
            {
                List<AccountTransaction> myAccTrxs = new List<AccountTransaction>();
                /*
                foreach (SubActionProcedure sp in this.SubActionProcedures)
                {
                    foreach(AccountTransaction AccTrx in sp.AccountTransactions)
                    {
                        if (AccTrx.CanBeRegisteredToMedula())
                            myAccTrxs.Add(AccTrx);
                    }
                }
                
                foreach (SubActionMaterial sm in this.SubActionMaterials)
                {
                    foreach(AccountTransaction AccTrx in sm.AccountTransactions)
                    {
                        if (AccTrx.CanBeRegisteredToMedula())
                            myAccTrxs.Add(AccTrx);
                    }
                }
                */
                return myAccTrxs;
            }
        }
        
        public virtual List<DiagnosisGrid> RegisterableDiagnosises
        {
            get
            {
                List<DiagnosisGrid> myDiagnosises = new List<DiagnosisGrid>();
                /*
                foreach (DiagnosisGrid diagnosis in this.DiagnosisGrids)
                {
                    if (diagnosis.CanBeRegisteredToMedula())
                        myDiagnosises.Add(diagnosis);
                }
                */
                return myDiagnosises;
            }
        }
        
        public void CreateFullHizmetKayitGirisDVO(HizmetKayit hKayit)
        {
            CreateHizmetKayitGirisDVO(ObjectContext, hKayit, RegisterableAccountTransactions, RegisterableDiagnosises);
        }
        
        public void CreateHizmetKayitGirisDVO(TTObjectContext context, HizmetKayit hizmetKayit, List<AccountTransaction> AccountTransactions, List<DiagnosisGrid> DiagnosisGrids)
        {
            hizmetKayit.hizmetKayitGirisDVO.saglikTesisKodu = hizmetKayit.HealthFacilityID;
            hizmetKayit.hizmetKayitGirisDVO.hastaBasvuruNo = BaseHastaKabul.provizyonGirisDVO.provizyonCevapDVO.hastaBasvuruNo;
            hizmetKayit.hizmetKayitGirisDVO.takipNo = BaseHastaKabul.provizyonGirisDVO.provizyonCevapDVO.takipNo;
            
            // Tanılar ekleniyor
            /*
            foreach (DiagnosisGrid diagnosisGrid in DiagnosisGrids)
            {
                if (diagnosisGrid.CanBeRegisteredToMedula())
                {
                    TaniBilgisiDVO tani = new TaniBilgisiDVO(context);
                    
                    tani.hizmetSunucuRefNo = diagnosisGrid.MedulaReferenceNumber;
                    tani.taniKodu = diagnosisGrid.DiagnoseCode;
                    tani.taniTipi = diagnosisGrid.MedulaDiagnoseType;
                    tani.birincilTani = diagnosisGrid.MedulaIsPrimaryDiagnose;
                    
                    hizmetKayit.hizmetKayitGirisDVO.tanilar.Add(tani);
                    diagnosisGrid.MedulaRegistration = hizmetKayit;
                }
            }
            
            // Hizmet, ilaç ve malzemeler ekleniyor
            foreach (AccountTransaction AccTrx in AccountTransactions)
            {
                if(AccTrx.IsMedulaAccountTransaction() && AccTrx.CanBeRegisteredToMedula())
                {
                    if (AccTrx.SubActionProcedure != null)  // hizmetler
                    {
                        if (AccTrx.PricingDetail != null)
                        {
                            if (AccTrx.PricingDetail.MedulaSUTGroup == MedulaSUTGroupEnum.muayeneBilgisi)
                            {
                                MuayeneBilgisiDVO muayene = new MuayeneBilgisiDVO(context);

                                muayene.bransKodu = AccTrx.SubActionProcedure.DoctorSpecialityCode.ToString();
                                muayene.drTescilNo = AccTrx.SubActionProcedure.DoctorDiplomaRegisterNo;
                                muayene.sutKodu = AccTrx.MedulaProcedureCode;
                                muayene.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
                                muayene.muayeneTarihi = AccTrx.MedulaTransactionDate;
                                
                                hizmetKayit.hizmetKayitGirisDVO.muayeneBilgisi = muayene;
                            }
                            else if (AccTrx.PricingDetail.MedulaSUTGroup == MedulaSUTGroupEnum.konsultasyonBilgileri)
                            {
                                KonsultasyonBilgisiDVO konsultasyon = new KonsultasyonBilgisiDVO(context);

                                konsultasyon.bransKodu = AccTrx.SubActionProcedure.DoctorSpecialityCode.ToString();
                                konsultasyon.drTescilNo = AccTrx.SubActionProcedure.DoctorDiplomaRegisterNo;
                                konsultasyon.sutKodu = AccTrx.MedulaProcedureCode;
                                konsultasyon.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
                                konsultasyon.islemTarihi = AccTrx.MedulaTransactionDate;
                                
                                hizmetKayit.hizmetKayitGirisDVO.konsultasyonBilgileri.Add(konsultasyon);
                            }
                            else if (AccTrx.PricingDetail.MedulaSUTGroup == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
                            {
                                AmeliyatveGirisimBilgisiDVO ameliyat = new AmeliyatveGirisimBilgisiDVO(context);
                                
                                ameliyat.adet = (int)AccTrx.Amount;
                                ameliyat.bransKodu = AccTrx.SubActionProcedure.DoctorSpecialityCode.ToString();
                                ameliyat.drTescilNo = AccTrx.SubActionProcedure.DoctorDiplomaRegisterNo;
                                ameliyat.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
                                ameliyat.islemTarihi = AccTrx.MedulaTransactionDate;
                                ameliyat.sutKodu = AccTrx.MedulaProcedureCode;
                                
                                if (AccTrx.SubActionProcedure is BaseSurgeryProcedure)
                                {
                                    ameliyat.ayniFarkliKesi = ((SurgeryProcedure)AccTrx.SubActionProcedure).MedulaKesi;
                                    ameliyat.sagSol = ((SurgeryProcedure)AccTrx.SubActionProcedure).MedulaSagSol;
                                    if(((BaseSurgeryProcedure)AccTrx.SubActionProcedure).DescriptionOfProcedureObject!=null)
                                        ameliyat.aciklama =  Common.GetTextOfRTFString(((BaseSurgeryProcedure)AccTrx.SubActionProcedure).DescriptionOfProcedureObject.ToString());
                                    ameliyat.euroscore = ((SurgeryProcedure)AccTrx.SubActionProcedure).MedulaEuroScore;
                                }
                                else if (AccTrx.SubActionProcedure is SubActionPackageProcedure)
                                {
                                    if (AccTrx.SubActionProcedure is SurgeryPackageProcedure)
                                    {
                                        ameliyat.ayniFarkliKesi = ((SurgeryPackageProcedure)AccTrx.SubActionProcedure).SurgeryProcedure.MedulaKesi;
                                        ameliyat.sagSol = ((SurgeryPackageProcedure)AccTrx.SubActionProcedure).SurgeryProcedure.MedulaSagSol;
                                        if(((BaseSurgeryProcedure)((SurgeryPackageProcedure)AccTrx.SubActionProcedure).SurgeryProcedure).DescriptionOfProcedureObject!=null)
                                            ameliyat.aciklama = Common.GetTextOfRTFString(((BaseSurgeryProcedure)((SurgeryPackageProcedure)AccTrx.SubActionProcedure).SurgeryProcedure).DescriptionOfProcedureObject.ToString());
                                        ameliyat.euroscore = ((SurgeryPackageProcedure)AccTrx.SubActionProcedure).SurgeryProcedure.MedulaEuroScore;
                                    }
                                    else
                                        ameliyat.euroscore = "0";
                                }
                                else
                                    ameliyat.euroscore = "0";
                                
                                
                                hizmetKayit.hizmetKayitGirisDVO.ameliyatveGirisimBilgileri.Add(ameliyat);
                            }
                            else if (AccTrx.PricingDetail.MedulaSUTGroup == MedulaSUTGroupEnum.digerIslemBilgileri)
                            {
                                DigerIslemBilgisiDVO diger = new DigerIslemBilgisiDVO(context);
                                
                                diger.adet = (int)AccTrx.Amount;
                                diger.bransKodu = AccTrx.SubActionProcedure.DoctorSpecialityCode.ToString();
                                diger.sutKodu = AccTrx.MedulaProcedureCode;
                                diger.drTescilNo = AccTrx.SubActionProcedure.DoctorDiplomaRegisterNo;
                                diger.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
                                diger.islemTarihi = AccTrx.MedulaTransactionDate;
                                diger.raporTakipNo = "";
                                
                                hizmetKayit.hizmetKayitGirisDVO.digerIslemBilgileri.Add(diger);
                            }
                            else if (AccTrx.PricingDetail.MedulaSUTGroup == MedulaSUTGroupEnum.disBilgileri)
                            {
                                DisBilgisiDVO dis = new DisBilgisiDVO(context);

                                dis.drTescilNo = AccTrx.SubActionProcedure.DoctorDiplomaRegisterNo;
                                dis.adet = (int)AccTrx.Amount;
                                dis.bransKodu = AccTrx.SubActionProcedure.DoctorSpecialityCode.ToString();
                                dis.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
                                dis.islemTarihi = AccTrx.MedulaTransactionDate;
                                dis.sutKodu = AccTrx.MedulaProcedureCode;
                                
                                if (AccTrx.SubActionProcedure is DentalProcedure)
                                {
                                    dis.anomali = ((DentalProcedure)AccTrx.SubActionProcedure).anomali;
                                    dis.sagAltCene = ((DentalProcedure)AccTrx.SubActionProcedure).sagAltCene;
                                    dis.sagSutAltCene = ((DentalProcedure)AccTrx.SubActionProcedure).sagSutAltCene;
                                    dis.sagUstCene = ((DentalProcedure)AccTrx.SubActionProcedure).sagUstCene;
                                    dis.sagSutUstCene = ((DentalProcedure)AccTrx.SubActionProcedure).sagSutUstCene;
                                    dis.solAltCene = ((DentalProcedure)AccTrx.SubActionProcedure).solAltCene;
                                    dis.solSutAltCene = ((DentalProcedure)AccTrx.SubActionProcedure).solSutAltCene;
                                    dis.solUstCene = ((DentalProcedure)AccTrx.SubActionProcedure).solUstCene;
                                    dis.solSutUstCene = ((DentalProcedure)AccTrx.SubActionProcedure).solSutUstCene;
                                }
                                
                                hizmetKayit.hizmetKayitGirisDVO.disBilgileri.Add(dis);
                            }
                            else if (AccTrx.PricingDetail.MedulaSUTGroup == MedulaSUTGroupEnum.hastaYatisBilgileri)
                            {
                                HastaYatisBilgisiDVO yatis = new HastaYatisBilgisiDVO(context);

                                yatis.bransKodu = AccTrx.SubActionProcedure.DoctorSpecialityCode.ToString();
                                yatis.drTescilNo = AccTrx.SubActionProcedure.DoctorDiplomaRegisterNo;
                                yatis.sutKodu = AccTrx.MedulaProcedureCode;
                                yatis.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
                                
                                if (AccTrx.SubActionProcedure is BaseBedProcedure)
                                {
                                    yatis.refakatciGunSayisi = ((BaseBedProcedure)AccTrx.SubActionProcedure).refakatciGunSayisi;
                                    yatis.yatisBaslangicTarihi = ((BaseBedProcedure)AccTrx.SubActionProcedure).yatisBaslangicTarihi;
                                    yatis.yatisBitisTarihi = ((BaseBedProcedure)AccTrx.SubActionProcedure).yatisBitisTarihi;
                                }
                                
                                hizmetKayit.hizmetKayitGirisDVO.hastaYatisBilgileri.Add(yatis);
                            }
                            else if (AccTrx.PricingDetail.MedulaSUTGroup == MedulaSUTGroupEnum.tahlilBilgileri)
                            {
                                TahlilBilgisiDVO tahlil = new TahlilBilgisiDVO(context);

                                tahlil.bransKodu = AccTrx.SubActionProcedure.DoctorSpecialityCode.ToString();
                                tahlil.drTescilNo = AccTrx.SubActionProcedure.DoctorDiplomaRegisterNo;
                                tahlil.sutKodu = AccTrx.MedulaProcedureCode;
                                tahlil.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
                                tahlil.islemTarihi = AccTrx.MedulaTransactionDate;
                                tahlil.adet = (int)AccTrx.Amount;
                                
                                hizmetKayit.hizmetKayitGirisDVO.tahlilBilgileri.Add(tahlil);
                            }
                            else if (AccTrx.PricingDetail.MedulaSUTGroup == MedulaSUTGroupEnum.tetkikveRadyolojiBilgileri)
                            {
                                TetkikveRadyolojiBilgisiDVO radyoloji = new TetkikveRadyolojiBilgisiDVO(context);

                                radyoloji.bransKodu = AccTrx.SubActionProcedure.DoctorSpecialityCode.ToString();
                                radyoloji.drTescilNo = AccTrx.SubActionProcedure.DoctorDiplomaRegisterNo;
                                radyoloji.sutKodu = AccTrx.MedulaProcedureCode;
                                radyoloji.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
                                radyoloji.adet = (int)AccTrx.Amount;
                                radyoloji.islemTarihi = AccTrx.MedulaTransactionDate;
                                
                                hizmetKayit.hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri.Add(radyoloji);
                            }
                            else
                                throw new TTException(SystemMessage.GetMessage(1202, new string[] { AccTrx.TransactionDate.ToString(), AccTrx.MedulaProcedureCode.ToString(), AccTrx.Description.ToString()}));
                        }
                        else
                            throw new TTException(SystemMessage.GetMessage(1203, new string[] { AccTrx.TransactionDate.ToString(), AccTrx.Description.ToString()}));
                    }
                    else if (AccTrx.SubActionMaterial != null) // ilaç ve malzemeler
                    {
                        if (AccTrx.SubActionMaterial.Material is DrugDefinition) //İLAÇ (1=Barkodlu,2=Majistral,3=Radyofarmasötik Ajan)
                        {
                            IlacBilgisiDVO ilac = new IlacBilgisiDVO(context);
                            
                            ilac.adet = AccTrx.Amount;
                            ilac.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
                            ilac.ilacTuru = ((DrugDefinition)AccTrx.SubActionMaterial.Material).IlacTuru;
                            ilac.islemTarihi = AccTrx.MedulaTransactionDate;
                            ilac.paketHaric = AccTrx.MedulaPackageInOut;
                            
                            if (ilac.ilacTuru == "2" || ilac.ilacTuru == "3") // Majistral ve Radyofarmasötik Ajan için fiyat istiyor
                                ilac.tutar = AccTrx.UnitPrice;
                            
                            if (ilac.ilacTuru == "2")     // Majistral için açıklamada ilaç içeriğini istiyor
                                ilac.aciklama = AccTrx.SubActionMaterial.MedulaMagistralPreparationDescription;
                            else
                            {
                                ilac.barkod = AccTrx.SubActionMaterial.Material.Barcode;
                                ilac.aciklama = AccTrx.SubActionMaterial.Material.Description;
                            }
                            
                            hizmetKayit.hizmetKayitGirisDVO.ilacBilgileri.Add(ilac);
                        }
                        else // MALZEME (1=BUT Kodlu, 2=Emekli Sandığı Protokol Kodlu, 3=Kodsuz malzeme)
                        {
                            MalzemeBilgisiDVO malzeme = new MalzemeBilgisiDVO(context);
                            
                            malzeme.malzemeTuru = "3";      // TODOMedula: Malzeme türlerine karar verilecek
                            malzeme.adet = AccTrx.Amount;
                            malzeme.kodsuzMalzemeFiyati = AccTrx.Amount * AccTrx.UnitPrice;
                            malzeme.barkod = AccTrx.SubActionMaterial.Material.Barcode;
                            malzeme.hizmetSunucuRefNo = AccTrx.MedulaReferenceNumber;
                            malzeme.islemTarihi = AccTrx.MedulaTransactionDate;
                            malzeme.paketHaric = AccTrx.MedulaPackageInOut;
                            malzeme.katkiPayi = AccTrx.SubActionMaterial.MedulaPatientShareExists;
                            
                            if (malzeme.malzemeTuru == "3")
                                malzeme.kodsuzMalzemeAdi = AccTrx.SubActionMaterial.Material.Name;
                            
                            if (malzeme.malzemeTuru == "1" || malzeme.malzemeTuru == "2")
                                malzeme.malzemeKodu = AccTrx.MedulaMaterialCode;
                            
                            hizmetKayit.hizmetKayitGirisDVO.malzemeBilgileri.Add(malzeme);
                        }
                    }
                    AccTrx.MedulaRegistration = hizmetKayit;
                }
            }
            */
        }
        
#endregion Methods

    }
}