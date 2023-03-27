
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
    /// Medula Takip 
    /// </summary>
    public partial class MedulaProvision : TTObject
    {
        public partial class GetMedulaProvisionsByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaProvisionByObjectID_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaProvisions_Class : TTReportNqlObject
        {
        }

        public partial class GetByDateInterval_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaProvisionsByPatientInfo_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaProvisionByProvisionNoQuery_Class : TTReportNqlObject
        {
        }

        public partial class MedulaProvisionDetailReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaProvisionsByApplicationNoAndEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaProvisionsByDischargeDate_Class : TTReportNqlObject
        {
        }

        public partial class GetMedulaProvisionByProvisionType_Class : TTReportNqlObject
        {
        }

        public partial class VEM_MEDULA_TAKIP_Class : TTReportNqlObject
        {
        }

        

        /// <summary>
        /// FaturaKayıt HizmetDetayDVO daki protokolNo
        /// </summary>
        //public string InvoiceProtocolNo
        //{
        //    get
        //    {
        //        try
        //        {
        //            #region InvoiceProtocolNo_GetScript                    
        //            string protocolNo = string.Empty;
        //            /*
        //            if(this.Episode != null)
        //            {
        //                protocolNo = Common.RecTime().Year.ToString() + "_";
        //                protocolNo += this.Episode.HospitalProtocolNo.Value.ToString() + "_";
        //                protocolNo += this.OrderNo.Value.ToString();
        //            }
        //            */
        //            return protocolNo;
        //            #endregion InvoiceProtocolNo_GetScript
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "InvoiceProtocolNo") + " : " + ex.Message, ex);
        //        }
        //    }
        //}

        /// <summary>
        /// Takibin toplam tutarı
        /// </summary>
        //public double? TotalPrice
        //{
        //    get
        //    {
        //        try
        //        {
        //            #region TotalPrice_GetScript                    
        //            if (this.SubEpisode != null)
        //            {
        //                BindingList<AccountTransaction.GetPayerTotalPriceBySubEpisode_Class> totalPriceList = AccountTransaction.GetPayerTotalPriceBySubEpisode(this.ObjectContext, this.SubEpisode.ObjectID);
        //                if (totalPriceList[0].Totalprice != null)
        //                    return Convert.ToDouble(totalPriceList[0].Totalprice);
        //                else
        //                    return 0;
        //            }

        //            return null;
        //            #endregion TotalPrice_GetScript
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "TotalPrice") + " : " + ex.Message, ex);
        //        }
        //    }
        //}

        /// <summary>
        /// Takibin hizmet kaydı yapılmış tutarı
        /// </summary>
        //public double? EntryPrice
        //{
        //    get
        //    {
        //        try
        //        {
        //            #region EntryPrice_GetScript                    
        //            if (this.SubEpisode != null)
        //            {
        //                BindingList<AccountTransaction.GetMedulaEntryPriceBySEP_Class> entryPriceList = AccountTransaction.GetMedulaEntryPriceBySEP(this.ObjectContext, this.SubEpisode.ObjectID);
        //                if (entryPriceList[0].Totalprice != null)
        //                    return Convert.ToDouble(entryPriceList[0].Totalprice);
        //                else
        //                    return 0;
        //            }

        //            return null;
        //            #endregion EntryPrice_GetScript
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "EntryPrice") + " : " + ex.Message, ex);
        //        }
        //    }
        //}

        //public string ProvizyonTipiDesc
        //{
        //    get
        //    {
        //        try
        //        {
        //            #region ProvizyonTipiDesc_GetScript                    
        //            if (this.ProvizyonTipi != null)
        //                return this.ProvizyonTipi.ToString();

        //            return string.Empty;
        //            #endregion ProvizyonTipiDesc_GetScript
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ProvizyonTipiDesc") + " : " + ex.Message, ex);
        //        }
        //    }
        //}

        public string TedaviTuruDesc
        {
            get
            {
                try
                {
                    #region TedaviTuruDesc_GetScript                    
                    if (TedaviTuru != null)
                        return TedaviTuru.ToString();

                    return string.Empty;
                    #endregion TedaviTuruDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "TedaviTuruDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string BransDesc
        {
            get
            {
                try
                {
                    #region BransDesc_GetScript                    
                    if (Brans != null)
                        return Brans.ToString();

                    return string.Empty;
                    #endregion BransDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "BransDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string TedaviTipiDesc
        {
            get
            {
                try
                {
                    #region TedaviTipiDesc_GetScript                    
                    if (TedaviTipi != null)
                        return TedaviTipi.ToString();

                    return string.Empty;
                    #endregion TedaviTipiDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "TedaviTipiDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string TakipTipiDesc
        {
            get
            {
                try
                {
                    #region TakipTipiDesc_GetScript                    
                    if (TakipTipi != null)
                        return TakipTipi.ToString();

                    return string.Empty;
                    #endregion TakipTipiDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "TakipTipiDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string SigortaliTuruDesc
        {
            get
            {
                try
                {
                    #region SigortaliTuruDesc_GetScript                    
                    if (SigortaliTuru != null)
                        return SigortaliTuru.ToString();

                    return string.Empty;
                    #endregion SigortaliTuruDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "SigortaliTuruDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string DevredilenKurumDesc
        {
            get
            {
                try
                {
                    #region DevredilenKurumDesc_GetScript                    
                    if (DevredilenKurum != null)
                        return DevredilenKurum.ToString();

                    return string.Empty;
                    #endregion DevredilenKurumDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DevredilenKurumDesc") + " : " + ex.Message, ex);
                }
            }
        }
        
        /*
        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();
            this.UpDateLast = Common.RecTime();
            //ControlDailyBedProcedure();

            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate

            base.PreUpdate();

            // Faturalandı durumunda ise 
            if (this.Status == MedulaSubEpisodeStatusEnum.Invoiced)
            {
                if (this.MedulaInvoice == null) // Medula Faturası boş ise hata verelim
                    throw new TTUtils.TTException("'Fatura Kaydedildi' durumundaki Medula Takibi'nin Medula Fatura'sı dolu olmalıdır!");
                else if (this.MedulaInvoice != null && string.IsNullOrEmpty(this.MedulaInvoice.InvoiceDeliveryNo)) // Fatura Teslim Numarası boş ise hata verelim
                    throw new TTUtils.TTException("'Fatura Kaydedildi' durumundaki Medula Takibi'nin Medula Fatura'sının 'Fatura Teslim Numarası' dolu olmalıdır!");
            }

            #endregion PreUpdate
        }
        */
        
            
        //protected override void PostUpdate()
        //{
        //    #region PostUpdate

        //    base.PostUpdate();

        //    this.UpDateLast = Common.RecTime();
        //    // Yeni durumunda (aktif) ise
        //    if (this.CurrentStateDefID == MedulaProvision.States.New)
        //    {
        //        // MedulaProvision ın update ten önceki orjinal hali alınır
        //        TTObjectContext objContext = new TTObjectContext(true);
        //        MedulaProvision originalMP = (MedulaProvision)objContext.GetObject(this.ObjectID, TTObjectDefManager.Instance.ObjectDefs[typeof(MedulaProvision).Name], false);
        //        if (originalMP != null)
        //        {
        //            // Faturalandı dan başka bir duruma alınıyorsa ve Fatura Teslim Numarası boş değilse hata verelim
        //            if (originalMP.Status == MedulaSubEpisodeStatusEnum.Invoiced && this.Status != MedulaSubEpisodeStatusEnum.Invoiced)
        //            {
        //                if (this.MedulaInvoice != null && !string.IsNullOrEmpty(this.MedulaInvoice.InvoiceDeliveryNo))
        //                {
        //                    if (this.MedulaInvoice.InvoiceDeliveryNo != "0") // Bazen 0 oluyor Fatura Teslim Numarası, geçerli bir numara değil
        //                        throw new TTUtils.TTException("Medula Takibini Fatura Kaydedildi'den başka bir duruma alabilmek için 'Fatura Teslim Numarası' boş olmalıdır!");
        //                }
        //            }

        //            if (this.Status == MedulaSubEpisodeStatusEnum.InvoiceEntryWaiting || this.Status == MedulaSubEpisodeStatusEnum.Invoiced)
        //            {
        //                // InvoiceEntryWaiting veya Invoiced durumuna geçilmiş ise vakanın anlaşmalarını kapatmak lazım ki yeni hizmet/malzeme girilemesin
        //                //if (originalMP.Status != MedulaSubEpisodeStatusEnum.InvoiceEntryWaiting && originalMP.Status != MedulaSubEpisodeStatusEnum.Invoiced)
        //                //    this.Episode.CloseEpisodeProtocols();

        //                // Takip Faturalandı durumuna geçince Fatura Bilgisi Kayıt tipinde e-nabız objesi oluşturulur
        //                if (this.Status == MedulaSubEpisodeStatusEnum.Invoiced && originalMP.Status != MedulaSubEpisodeStatusEnum.Invoiced && this.SubEpisode != null)
        //                    new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "104", Common.RecTime());
        //            }
        //            else
        //            {
        //                // Önceki durumu InvoiceEntryWaiting veya Invoiced ama şu anki durumu farklı ise son anlaşma açılır ki hizmet girilebilsin
        //                if (originalMP.Status == MedulaSubEpisodeStatusEnum.InvoiceEntryWaiting || originalMP.Status == MedulaSubEpisodeStatusEnum.Invoiced)
        //                {
        //                    /*
        //                    EpisodeProtocol lastEP = this.Episode.MyLastEpisodeProtocol();
        //                    if(lastEP != null && lastEP.CurrentStateDefID != EpisodeProtocol.States.OPEN)
        //                        lastEP.CurrentStateDefID = EpisodeProtocol.States.OPEN;
        //                    */
        //                }
        //            }

        //            //CheckToCancelPatientShareAccTrxsOfEpisode(originalMP);
        //        }
        //        //ControlDailyBedProcedure();
        //    }
        //    else if (this.CurrentStateDefID == MedulaProvision.States.Cancelled)
        //    {
        //        if (this.ProvisionNo != null)
        //            throw new TTUtils.TTException("Medula Takibini İptal adımına alabilmek için 'Takip No' boş olmalıdır!");
        //        if (this.Status != MedulaSubEpisodeStatusEnum.ProvisionNoNotExists)
        //            throw new TTUtils.TTException("Medula Takibini İptal adımına alabilmek için durumu 'Takip No Alınmamış' olmalıdır!");
        //    }


        //    #endregion PostUpdate
        //}
        

        #region Methods
            /*
        public void CheckForRelatedProvisionInvoiceStatus()
        {
            if (this.RelatedProvisionNo == null || string.IsNullOrEmpty(this.RelatedProvisionNo))
                return;

            MedulaProvision mp = GetMedulaProvisionByProvisionNo(this.RelatedProvisionNo);

            if (mp.MedulaInvoice != null && mp.MedulaInvoice.Status != null && mp.MedulaInvoice.Status == MedulaInvoiceStatusEnum.Invoiced)
                throw new TTUtils.TTException("Bu takibe bağlı olan takip faturalandırılmıştır. Faturalandırılmış takibe bağlı takip alınamaz.");
        }
        */

        public int? GetAndSetNextOrderNo()
        {
            /*
            if (this.Episode == null)
                throw new TTUtils.TTException("Medula Takip nesnesinin sıra numarasının set edilebilmesi için vakası belirlenmiş olmalıdır.");
            int orderNo = this.Episode.MedulaProvisions.Count;
            this.OrderNo = orderNo;
            */
            return OrderNo;
        }

        // Hizmet Kaydı yapıldıktan sonra MedulaProvision ın durumunu set eder ve döndürür
        public MedulaSubEpisodeStatusEnum GetAndSetMyStatusAfterProcedureEntry()
        {
            /*
            if(this.SubEpisode != null)
            {
                // Hata alınmış var ise
                List<Guid> stateList = new List<Guid>();
                stateList.Add(AccountTransaction.States.MedulaEntryUnsuccessful);
                
                BindingList<AccountTransaction.GetMedulaTransactionsBySubEpisodeAndState_Class> accTrxs = AccountTransaction.GetMedulaTransactionsBySubEpisodeAndState(this.SubEpisode.ObjectID, stateList.ToArray());
                if(accTrxs.Count > 0)
                {
                    this.Status = MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;
                    return (MedulaSubEpisodeStatusEnum)this.Status;
                }
                

                List<int> statuslist = new List<int>();
                statuslist.Add(3); // MedulaDiagnosisStatusEnum.EntryUnsuccessful
                BindingList<DiagnosisGrid.GetMedulaDiagnosisBySubEpisodeAndStatus_Class> diagnosisList = DiagnosisGrid.GetMedulaDiagnosisBySubEpisodeAndStatus(this.SubEpisode.ObjectID,  statuslist.ToArray());
                if (diagnosisList.Count > 0)
                {
                    this.Status = MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;
                    return (MedulaSubEpisodeStatusEnum)this.Status;
                }

                // Hizmet Kaydı yapılmamış var ise
                stateList.Clear();
                accTrxs.Clear();
                stateList.Add(AccountTransaction.States.New);
                stateList.Add(AccountTransaction.States.ToBeNew);
                stateList.Add(AccountTransaction.States.MedulaSentServer);
                accTrxs = AccountTransaction.GetMedulaTransactionsBySubEpisodeAndState(this.SubEpisode.ObjectID, stateList.ToArray());
                if (accTrxs.Count > 0)
                {
                    this.Status = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                    return (MedulaSubEpisodeStatusEnum)this.Status;
                }
                
               
                statuslist.Clear();
                diagnosisList.Clear();
                statuslist.Add(0); // MedulaDiagnosisStatusEnum.New
                statuslist.Add(1); // MedulaDiagnosisStatusEnum.SentServer
                diagnosisList = DiagnosisGrid.GetMedulaDiagnosisBySubEpisodeAndStatus(this.SubEpisode.ObjectID, statuslist.ToArray());
                if (diagnosisList.Count > 0)
                {
                    this.Status = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                    return (MedulaSubEpisodeStatusEnum)this.Status;
                }

                // İkisi de yoksa hepsi başarılı hizmet kaydı yapılmış demektir
                this.Status = MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted;
            }
            */
            return (MedulaSubEpisodeStatusEnum)Status;
        }

        // Fatura Kaydı yapılmadan önce MedulaProvision ın durumunu kontrol eder ve döndürür, gerçekten tüm hizmet kayıtları yapılmış mı diye
        public MedulaSubEpisodeStatusEnum GetMyStatusBeforeInvoiceEntry()
        {
            /*
            if(this.Status != MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted)
                return (MedulaSubEpisodeStatusEnum)this.Status;
            else // status ProcedureEntryCompleted ise, bir de acctrx ve tanılardan kontrol edilir, gerçekten hepsi kaydedilmiş mi diye
            {
                if(this.SubEpisode != null)
                {
                    // Hata alınmış var ise
                    List<Guid> stateList = new List<Guid>();
                    stateList.Add(AccountTransaction.States.MedulaEntryUnsuccessful);
                    
                    BindingList<AccountTransaction.GetMedulaTransactionsBySubEpisodeAndState_Class> accTrxs = AccountTransaction.GetMedulaTransactionsBySubEpisodeAndState(this.SubEpisode.ObjectID, stateList.ToArray());
                    if(accTrxs.Count > 0)
                        return MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;
                    

                    List<int> statuslist = new List<int>();
                    statuslist.Add(3); // MedulaDiagnosisStatusEnum.EntryUnsuccessful
                    BindingList<DiagnosisGrid.GetMedulaDiagnosisBySubEpisodeAndStatus_Class> diagnosisList = DiagnosisGrid.GetMedulaDiagnosisBySubEpisodeAndStatus(this.SubEpisode.ObjectID,  statuslist.ToArray());
                    if (diagnosisList.Count > 0)
                        return MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;

                    // Hizmet Kaydı yapılmamış var ise
                    
                    stateList.Clear();
                    accTrxs.Clear();
                    stateList.Add(AccountTransaction.States.New);
                    stateList.Add(AccountTransaction.States.ToBeNew);
                    stateList.Add(AccountTransaction.States.MedulaSentServer);
                    accTrxs = AccountTransaction.GetMedulaTransactionsBySubEpisodeAndState(this.SubEpisode.ObjectID, stateList.ToArray());
                    if (accTrxs.Count > 0)
                        return MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                        

                    statuslist.Clear();
                    diagnosisList.Clear();
                    statuslist.Add(0); // MedulaDiagnosisStatusEnum.New
                    statuslist.Add(1); // MedulaDiagnosisStatusEnum.SentServer
                    diagnosisList = DiagnosisGrid.GetMedulaDiagnosisBySubEpisodeAndStatus(this.SubEpisode.ObjectID, statuslist.ToArray());
                    if (diagnosisList.Count > 0)
                        return MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                }
            }
            */
            return (MedulaSubEpisodeStatusEnum)Status;
        }

        public static MedulaProvision GetFirstMedulaProvisionByApplicationNo(string ApplicationNo)
        {
            TTObjectContext context = new TTObjectContext(false);
            BindingList<MedulaProvision> medulaProvisions = MedulaProvision.GetMedulaProvisionsByApplicationNo(context, ApplicationNo);
            foreach (MedulaProvision mp in medulaProvisions)
            {
                if (string.IsNullOrEmpty(mp.RelatedProvisionNo))
                    return mp;
            }

            // Aynı Tesis nolu XXXXXXlerden birinde(Ör Rehab) hasta kabul yapıldıktan sonra aynı gün  diğer XXXXXXye(XXXXXX) de kabul yapılırsa, Bu kabul(XXXXXXdaki) takibi ilk yapılan XXXXXXdekine(Rehabdakine)  bağlı olarak oluşturulur
            // dolayısı ile ikinci kabul yapılan XXXXXXdeki ilk takibin bile  bağlı provizyon nosu dolu olur.Bu durumda RelatePrivisyonun boş olmasına değil doluysa bile ilkine ulaşılmalı.
            foreach (MedulaProvision mp in medulaProvisions)
            {
                if (GetMedulaProvisionByProvisionNo(mp.RelatedProvisionNo) == null)
                    return mp;
            }

            return null;
        }

        public static MedulaProvision GetMedulaProvisionByProvisionNo(string ProvisionNo)
        {
            TTObjectContext context = new TTObjectContext(false);
            IBindingList medulaProvisionList = context.QueryObjects(typeof(MedulaProvision).Name, "PROVISIONNO = '" + ProvisionNo + "'");
            if (medulaProvisionList.Count > 0)
                return (MedulaProvision)medulaProvisionList[0];

            return null;
        }
        /*
        public string Triaj
        {
            get
            {
                bool needTriajCode = false;
                if (this.ProvizyonTipi != null)
                {
                    // A = Acil , V = Adli Vaka , T = Trafik Kazası , I = İş Kazası , E = 3713/21
                    if (this.ProvizyonTipi.provizyonTipiKodu.Trim().Equals("A"))
                        needTriajCode = true;
                    else if (this.ProvizyonTipi.provizyonTipiKodu.Trim().Equals("V") || this.ProvizyonTipi.provizyonTipiKodu.Trim().Equals("T") || this.ProvizyonTipi.provizyonTipiKodu.Trim().Equals("I") || this.ProvizyonTipi.provizyonTipiKodu.Trim().Equals("E"))
                    {
                        if (this.Brans != null && this.Brans.Code.Trim().Equals("4400")) // 4400 = Acil Tıp
                            needTriajCode = true;
                    }
                }

                if (needTriajCode)
                {
                    foreach (EmergencyIntervention ei in this.Episode.EmergencyInterventions)
                    {
                        if (ei.CurrentStateDefID != EmergencyIntervention.States.Cancelled && ei.TriajCode != null)
                        {
                            if (ei.TriajCode == TriajCode.Red)
                                return "K";
                            else if (ei.TriajCode == TriajCode.Yellow)
                                return "S";
                            else if (ei.TriajCode == TriajCode.Green)
                                return "Y";
                        }
                    }
                    foreach (DentalExamination de in this.Episode.DentalExaminations)
                    {
                        if (de.CurrentStateDefID != DentalExamination.States.Cancelled && de.TriajCode != null)
                        {
                            if (de.TriajCode == TriajCode.Red)
                                return "K";
                            else if (de.TriajCode == TriajCode.Yellow)
                                return "S";
                            else if (de.TriajCode == TriajCode.Green)
                                return "Y";
                        }
                    }
                    return "Y"; // Triaj bilgisine ulaşılamazsa Y döndürülür
                }
                return null;
            }
        }
        */
        /* Artık kullanılmıyor )
        public void ControlDailyBedProcedure()
        {
            if (this.TedaviTuru != null && this.TedaviTuru.tedaviTuruKodu != null && this.ApplicationNo != null && this.TedaviTuru.tedaviTuruKodu.Equals("G"))
            {
                BindingList<MedulaProvision> mProvisions = MedulaProvision.GetMedulaProvisionsByApplicationNo(this.ObjectContext, this.ApplicationNo);
                if (mProvisions.Count != 0)
                {
                    List<Guid> list = new List<Guid>();
                    BindingList<AccountTransaction> aTransactions = new BindingList<AccountTransaction>();
                    foreach (MedulaProvision mProvision in mProvisions)
                    {
                        if (string.IsNullOrEmpty(mProvision.ProvisionNo) == false && mProvision.CurrentStateDefID != MedulaProvision.States.Cancelled && mProvision.SubEpisode != null && mProvision.TedaviTuru != null && mProvision.TedaviTuru.tedaviTuruKodu != null && mProvision.TedaviTuru.tedaviTuruKodu.Equals("A"))
                            list.Add(mProvision.SubEpisode.ObjectID);
                    }
                    
                    List<Guid> accTrxStatelist = new List<Guid>();
                    accTrxStatelist.Add(AccountTransaction.States.New);
                    accTrxStatelist.Add(AccountTransaction.States.ToBeNew);
                    accTrxStatelist.Add(AccountTransaction.States.MedulaDontSend);
                    accTrxStatelist.Add(AccountTransaction.States.MedulaEntryUnsuccessful);
                    
                    if(list.Count != 0)
                        aTransactions = AccountTransaction.GetTrxBySubEpisodeProcedureAndState(this.ObjectContext, list.ToArray(), ProcedureDefinition.DailyBedProcedureObjectId, accTrxStatelist.ToArray());
                    if(aTransactions.Count != 0)
                    {
                        foreach(AccountTransaction at in aTransactions)
                        {
                            at.SubEpisode = this.SubEpisode;
                            at.SubActionProcedure.SubEpisode = this.SubEpisode;
                        }
                    }
                }
            }
        }
         */

        /*
        public static string RunSendMedulaProvision(Guid targetSite, List<Guid> medulaProvisionObjectIDs)
        {
            Common.RemotingResultClass remotingResultClass = new Common.RemotingResultClass();
            remotingResultClass.resultMessage = "Gönderilebilecek takip bulunamadı!";
            
            if(medulaProvisionObjectIDs.Count > 0)
            {
                List<MedulaProvision> mpList = new List<MedulaProvision>();
                List<SubEpisode> seList = new List<SubEpisode>();
                TTObjectContext objectContext = new TTObjectContext(false);
                
                foreach(Guid mpObjectID in medulaProvisionObjectIDs)
                {
                    MedulaProvision orjMP = (MedulaProvision)objectContext.GetObject(mpObjectID, typeof(MedulaProvision));
                    if(orjMP != null && orjMP.SubEpisode != null)
                    {
                        SubEpisode newSE = orjMP.SubEpisode.PrepareSubEpisodeForRemoteMethod(true);
                        MedulaProvision newMP = orjMP.PrepareMedulaProvisionForRemoteMethod(true);
                        newMP.SourceMPObjectID = orjMP.ObjectID;
                        newMP.SubEpisode = newSE;
                        mpList.Add(newMP);
                        seList.Add(newSE);
                    }
                }
                
                if(mpList.Count > 0 && seList.Count > 0)
                {
                    remotingResultClass = MedulaProvision.RemoteMethods.SendMedulaProvision(targetSite, mpList, seList);
                    if(remotingResultClass.resultCode == "0")
                    {
                        TTObjectContext newObjectContext = new TTObjectContext(false);
                        foreach(Guid mpObjectID in medulaProvisionObjectIDs)
                        {
                            MedulaProvision medulaProvision = (MedulaProvision)newObjectContext.GetObject(mpObjectID, typeof(MedulaProvision));
                            medulaProvision.Status = MedulaSubEpisodeStatusEnum.SentOtherHospitalToInvoice;
                            
                            // TargetMPObjectID ler doldurulur
                            foreach(MedulaProvision newMP in mpList)
                            {
                                if (newMP.SourceMPObjectID == medulaProvision.ObjectID)
                                {
                                    medulaProvision.TargetMPObjectID = newMP.ObjectID;
                                    break;
                                }
                            }
                        }
                        newObjectContext.Save();
                        newObjectContext.Dispose();
                    }
                }
                objectContext.Dispose();
            }
            return remotingResultClass.resultMessage;
        }
        */

        /*
        public MedulaProvision PrepareMedulaProvisionForRemoteMethod(bool withNewObjectID)
        {
            if (withNewObjectID)
            {
                MedulaProvision sendingMedulaProvision = (MedulaProvision)this.Clone();
                //sendingMedulaProvision.Episode = null;
                sendingMedulaProvision.MedulaInvoice = null;
                //sendingMedulaProvision.SubEpisode = null;
                return sendingMedulaProvision;
            }
            else
                return this;
        }
        */

        // Takip altındaki Gündüz Yatak hizmetlerini ayarlar (Yoksa oluşturur, birden çok varsa fazla olanları iptal eder)
        //public void ArrangeDailyBedProcedure()
        //{
        //    // Fatura Kayıt bekleyen veya Faturalandı durumundaki takip için birşey yapılmamalı
        //    if (this.Status != MedulaSubEpisodeStatusEnum.InvoiceEntryWaiting && this.Status != MedulaSubEpisodeStatusEnum.Invoiced)
        //    {
        //        if (this.SubEpisode != null && this.TedaviTuru != null && this.TedaviTuru.tedaviTuruKodu != null)
        //        {
        //            if (this.TedaviTuru.tedaviTuruKodu.Equals("A") || this.TedaviTuru.tedaviTuruKodu.Equals("G"))
        //            {
        //                Guid dailyBedProcedureGuid = ProcedureDefinition.DailyBedProcedureObjectId;

        //                List<Guid> subEpisodelist = new List<Guid>();
        //                subEpisodelist.Add(this.SubEpisode.ObjectID);

        //                List<Guid> accTrxStatelist = new List<Guid>();
        //                accTrxStatelist.Add(AccountTransaction.States.New);
        //                accTrxStatelist.Add(AccountTransaction.States.ToBeNew);
        //                accTrxStatelist.Add(AccountTransaction.States.MedulaDontSend);
        //                accTrxStatelist.Add(AccountTransaction.States.MedulaEntrySuccessful);
        //                accTrxStatelist.Add(AccountTransaction.States.MedulaEntryUnsuccessful);

        //                BindingList<AccountTransaction> aTransactions = AccountTransaction.GetTrxBySEPProcedureAndState(this.ObjectContext, subEpisodelist.ToArray(), dailyBedProcedureGuid, accTrxStatelist.ToArray());

        //                // Ayaktan takip içinde Gündüz Yatak hizmeti varsa iptal edilir
        //                if (this.TedaviTuru.tedaviTuruKodu.Equals("A"))
        //                {
        //                    foreach (AccountTransaction accTrx in aTransactions)
        //                    {
        //                        if (accTrx.CurrentStateDefID == AccountTransaction.States.New ||
        //                           accTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew ||
        //                           accTrx.CurrentStateDefID == AccountTransaction.States.MedulaDontSend ||
        //                           accTrx.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful)
        //                            accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
        //                    }
        //                }
        //                else if (this.TedaviTuru.tedaviTuruKodu.Equals("G"))
        //                {
        //                    if (aTransactions.Count == 0) // Gündüz Yatak hizmeti yoksa
        //                    {
        //                        // İptal durumunda Gündüz Yatak hizmeti varsa Yeni durumuna alınacak
        //                        List<Guid> accTrxCancelStatelist = new List<Guid>();
        //                        accTrxCancelStatelist.Add(AccountTransaction.States.Cancelled);
        //                        BindingList<AccountTransaction> cancelledTransactions = AccountTransaction.GetTrxBySEPProcedureAndState(this.ObjectContext, subEpisodelist.ToArray(), dailyBedProcedureGuid, accTrxCancelStatelist.ToArray());
        //                        if (cancelledTransactions.Count > 0)
        //                        {
        //                            foreach (AccountTransaction accTrx in cancelledTransactions)
        //                            {
        //                                accTrx.CurrentStateDefID = AccountTransaction.States.New;
        //                                this.ObjectContext.Save();
        //                                //accTrx.SetTransactionDateForDailyMedulaProvision(this);
        //                                break;
        //                            }
        //                        }
        //                        else // İptal durumunda Gündüz Yatak hizmeti yoksa yeni bir tane oluşturulacak
        //                        {
        //                            EpisodeAction episodeAction = null;
        //                            // Altvakanın iptal durumunda olmayan EpisodeAction larından biri seçilir
        //                            foreach (EpisodeAction ea in this.SubEpisode.EpisodeActions)
        //                            {
        //                                if (ea.CurrentStateDef != null && ea.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //                                {
        //                                    episodeAction = ea;
        //                                    break;
        //                                }
        //                            }

        //                            // Bulunamazsa SubEpisode içindeki AccountTransaction lardan birinin EpisodeAction ı alınır
        //                            if (episodeAction == null)
        //                            {
        //                                /*
        //                                foreach(AccountTransaction accTrx in this.SubEpisode.AccountTransactions)
        //                                {
        //                                    if(accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER && accTrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
        //                                    {
        //                                        if(accTrx.SubActionProcedure != null && accTrx.SubActionProcedure.EpisodeAction != null)
        //                                        {
        //                                            if(accTrx.SubActionProcedure.EpisodeAction.CurrentStateDef != null && accTrx.SubActionProcedure.EpisodeAction.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //                                            {
        //                                                episodeAction = accTrx.SubActionProcedure.EpisodeAction;
        //                                                break;
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                                */
        //                            }

        //                            if (episodeAction != null)
        //                            {
        //                                ProcedureDefinition dailyBedProcedure = (ProcedureDefinition)this.ObjectContext.GetObject(dailyBedProcedureGuid, typeof(ProcedureDefinition));

        //                                JointPricingProcedure jointProcedure = new JointPricingProcedure(this.ObjectContext);
        //                                jointProcedure.ProcedureObject = dailyBedProcedure;
        //                                jointProcedure.Amount = 1;
        //                                jointProcedure.CurrentStateDefID = JointPricingProcedure.States.Completed;
        //                                if (this.ProvisionDate.HasValue)
        //                                    jointProcedure.PricingDate = this.ProvisionDate.Value;
        //                                episodeAction.SubactionProcedures.Add(jointProcedure);
        //                                jointProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
        //                                jointProcedure.SubEpisode = this.SubEpisode;
        //                            }
        //                        }
        //                    }
        //                    else if (aTransactions.Count > 1) // Birden çok Gündüz Yatak hizmeti varsa sadece bir tanesi kalacak, diğerleri iptal edilecek
        //                    {
        //                        bool cancelExtraDailyBedProcedures = true;
        //                        // "3200 : Radyasyon Onkolojisi" branşı hariç, bu branşta aynı takip içinde farklı tarihlerde birden çok Gündüz Yatak
        //                        // hizmeti olabiliyor
        //                        if (this.Brans != null && this.Brans.Code != null && this.Brans.Code.Equals("3200"))
        //                            cancelExtraDailyBedProcedures = false;

        //                        if (cancelExtraDailyBedProcedures)
        //                        {
        //                            bool medulaEntrySuccessfulExists = false;
        //                            foreach (AccountTransaction accTrx in aTransactions)
        //                            {
        //                                if (accTrx.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful)
        //                                {
        //                                    medulaEntrySuccessfulExists = true;
        //                                    break;
        //                                }
        //                            }

        //                            // Hizmet kaydı yapılmış bir Gündüz Yatak hizmeti varsa diğerlerinin hepsi iptal edilecek,
        //                            // yoksa bir tane Gündüz Yatak hizmeti bırakılacak ve diğerleri iptal edilecek
        //                            bool oneDailyBedProcedureLeft = false;
        //                            foreach (AccountTransaction accTrx in aTransactions)
        //                            {
        //                                if (accTrx.CurrentStateDefID == AccountTransaction.States.New ||
        //                                    accTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew ||
        //                                    accTrx.CurrentStateDefID == AccountTransaction.States.MedulaDontSend ||
        //                                    accTrx.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful)
        //                                {
        //                                    if (medulaEntrySuccessfulExists)
        //                                        accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
        //                                    else
        //                                    {
        //                                        if (!oneDailyBedProcedureLeft)
        //                                        {
        //                                            if (accTrx.CurrentStateDefID != AccountTransaction.States.New)
        //                                                accTrx.CurrentStateDefID = AccountTransaction.States.New;
        //                                            oneDailyBedProcedureLeft = true;
        //                                        }
        //                                        else
        //                                            accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        /*
        public string GetMyDischargeCode()
        {   
            string dischargeCode = "";
            int processNo = 0;
            TreatmentDischarge tretDisc = null;
            try
            {
                if (this.Episode.PatientStatus == PatientStatusEnum.Outpatient) // Ayaktan durumundaki vakalar için
                {
                    if (this.Episode.TreatmentDischarges.Count > 0) // Muayene tedavi sonuç işlemi yoksa 2 gönder
                    {
                        foreach (TreatmentDischarge treatmentDischarge in this.Episode.TreatmentDischarges)
                        {
                            if ((treatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.OkWithApprove || treatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.OkWithoutApprove) && Convert.ToInt32(treatmentDischarge.ID.ToString()) > processNo)
                            {
                                processNo = Convert.ToInt32(treatmentDischarge.ID.ToString());
                                tretDisc = treatmentDischarge;
                            }
                        }
                        if (tretDisc != null && tretDisc.DischargeType != null) // Tamamlandı(Onaylı/Onaysız) adımında MTS yoksa veya varsa ve Taburcu Kodu girilmemişse 2 gönder, varsa ve girilmişse Medula Taburcu tipinde eşleştirme ye bak
                        {
                            IBindingList dischargeTypes = this.ObjectContext.QueryObjects(typeof(MedulaDischargeTypeDefinition).Name, "XXXXXXDISCHARGETYPE = " + Convert.ToInt16(tretDisc.DischargeType.Value) + "");
                            if (dischargeTypes.Count > 0)  // Medula Taburcu tipinde eşleştirme varsa ordaki medula taburcu kodunu gönder, yoksa 2 Haliyle taburcu gönder
                            {
                                if (((MedulaDischargeTypeDefinition)dischargeTypes[0]).MedulaDischargeCode != null)
                                    dischargeCode = ((MedulaDischargeTypeDefinition)dischargeTypes[0]).MedulaDischargeCode.taburcuKodu;
                                if (dischargeCode.Equals("3"))  // Ayaktan takipte Tedaviden Vazgeçme(3) taburcu kodu için fatura kaydı yapılamamaktadır. Bundan dolayı Haliyle Taburcu(2) gönderdik
                                    dischargeCode = "2";
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(dischargeCode))
                        dischargeCode = "2";
                }
                else // yatan veya taburcu durumundaki vakalar için
                {
                    if (!this.TedaviTuru.tedaviTuruKodu.Equals("Y")) // eğer takibin tedavi türü ayaktan ya da günübirlikse 2 gönder
                    {
                        dischargeCode = "2";
                    }
                    else // takibin tedavi turu yatansa
                    {
                        if (this.InPatientTreatmentClinicApplication.Count > 0 && this.InPatientTreatmentClinicApplication[0].InPatientPhysicianApplication.Count > 0 && this.InPatientTreatmentClinicApplication[0].InPatientPhysicianApplication[0].TreatmentDischarges.Count > 0)
                        {
                            TreatmentDischarge tDischarge = null;
                            if (this.InPatientTreatmentClinicApplication[0].InPatientPhysicianApplication[0].TreatmentDischarge != null)
                                tDischarge = this.InPatientTreatmentClinicApplication[0].InPatientPhysicianApplication[0].TreatmentDischarge;
                            if ((tDischarge.CurrentStateDefID == TreatmentDischarge.States.OkWithApprove || tDischarge.CurrentStateDefID == TreatmentDischarge.States.OkWithoutApprove) && tDischarge.DischargeType != null) // Tamamlandı(Onaylı/Onaysız) adımında MTS yoksa veya varsa ve Taburcu Kodu girilmemişse 2 gönder, varsa ve girilmişse Medula Taburcu tipinde eşleştirme ye bak
                            {
                                IBindingList dischargeTypes = this.ObjectContext.QueryObjects(typeof(MedulaDischargeTypeDefinition).Name, "XXXXXXDISCHARGETYPE = " + Convert.ToInt16(tDischarge.DischargeType.Value) + "");
                                if (dischargeTypes.Count > 0)  // Medula Taburcu tipinde eşleştirme varsa ordaki medula taburcu kodunu gönder, yoksa 2 Haliyle taburcu gönder
                                {
                                    if (((MedulaDischargeTypeDefinition)dischargeTypes[0]).MedulaDischargeCode != null)
                                        dischargeCode = ((MedulaDischargeTypeDefinition)dischargeTypes[0]).MedulaDischargeCode.taburcuKodu;
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(dischargeCode))
                            dischargeCode = "2";
                    }
                }
                return dischargeCode;
            }
            catch (Exception e)
            {
                return "2"; // haliyle taburcu
            }
        }
        */

        //public void AddDailyBedProcedure()
        //{
        //    if (this.Status != MedulaSubEpisodeStatusEnum.InvoiceEntryWaiting && this.Status != MedulaSubEpisodeStatusEnum.Invoiced)
        //    {
        //        if (this.SubEpisode != null && this.TedaviTuru != null && this.TedaviTuru.tedaviTuruKodu != null && this.TedaviTuru.tedaviTuruKodu.Equals("G") &&
        //           this.Brans != null && this.Brans.Code != null && this.Brans.Code.Equals("3200")) // Günübirlik tedavi türünde Radyasyon Onkolojisi branşlı takipler için
        //        {
        //            Guid dailyBedProcedureGuid = ProcedureDefinition.DailyBedProcedureObjectId;
        //            EpisodeAction episodeAction = null;
        //            // SubEpisode lardan durumu iptal olmayan bir EpisodeAction seçilir
        //            foreach (EpisodeAction ea in this.SubEpisode.EpisodeActions)
        //            {
        //                if (ea.CurrentStateDef != null && this.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //                {
        //                    episodeAction = ea;
        //                    break;
        //                }
        //            }

        //            //Bulunmazsa Subepisodelardaki iptal durumu dışındaki bir Acc Trx in EpisodeAction u alınır.

        //            if (episodeAction == null)
        //            {
        //                /*
        //                foreach(AccountTransaction accTrx in this.SubEpisode.AccountTransactions)
        //                {
        //                    if(accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER && accTrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
        //                    {
        //                        if(accTrx.SubActionProcedure != null && accTrx.SubActionProcedure.EpisodeAction != null && accTrx.SubActionProcedure.EpisodeAction.CurrentStateDef != null &&
        //                           accTrx.SubActionProcedure.EpisodeAction.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //                        {
        //                            episodeAction = accTrx.SubActionProcedure.EpisodeAction;
        //                            break;
        //                        }
        //                    }
        //                }
        //                */
        //            }

        //            if (episodeAction != null)
        //            {
        //                ProcedureDefinition dailyBedProcedure = (ProcedureDefinition)this.ObjectContext.GetObject(dailyBedProcedureGuid, typeof(ProcedureDefinition));
        //                JointPricingProcedure jointProcedure = new JointPricingProcedure(this.ObjectContext);
        //                jointProcedure.ProcedureObject = dailyBedProcedure;
        //                jointProcedure.Amount = 1;
        //                jointProcedure.CurrentStateDefID = JointPricingProcedure.States.Completed;
        //                if (this.ProvisionDate.HasValue)
        //                    jointProcedure.PricingDate = this.ProvisionDate.Value;
        //                episodeAction.SubactionProcedures.Add(jointProcedure);
        //                jointProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
        //                jointProcedure.SubEpisode = this.SubEpisode;
        //            }
        //        }
        //    }
        //}

        // Provizyon Tipi "E : 3713/21" olan takipler için hasta payı oluşmaması gerekiyor
        /*
        public bool CheckToCancelPatientShareAccTrxs()
        {
            if (!string.IsNullOrEmpty(ProvisionNo))
            {
                if (ProvizyonTipi != null && ProvizyonTipi.provizyonTipiKodu.Equals("E"))
                    return true;
            }
            return false;
        }
        */

        // Provizyon Tipi sonradan "E : 3713/21" olarak güncellenirse vakadaki hasta paylarının iptal edilmesi gerekiyor
        /*
        public void CheckToCancelPatientShareAccTrxsOfEpisode(MedulaProvision originalMedulaProvision)
        {
            if (CheckToCancelPatientShareAccTrxs())
            {
                if (originalMedulaProvision.ProvizyonTipi == null || (originalMedulaProvision.ProvizyonTipi != null && !originalMedulaProvision.ProvizyonTipi.provizyonTipiKodu.Equals("E")))
                    this.Episode.CancelPatientShareAccTrxs();
            }
        }
        */

        #endregion Methods

    }
}