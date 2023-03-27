
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
    public partial class InvoiceCollection : AccountAction
    {
        public partial class GetInvoiceCollectionBySqlInjection_Class : TTReportNqlObject
        {
        }


        public InvoiceCollectionDetail AddInvoiceCollectionDetail(SubEpisodeProtocol sep)
        {
            //TODO: AAE Kapasite kontrolü daha hassas a çevrilebilir. 

            string ttKodu = "A";
            if (sep.SubEpisode.Episode.PatientStatus != PatientStatusEnum.Outpatient)
                ttKodu = "Y";

            if (CurrentStateDefID != InvoiceCollection.States.Open)
                throw new TTException(TTUtils.CultureService.GetText("M25577", "Eklemeye çalıştığınız icmal açık durumda değildir."));
            if (!(CreateUser.ObjectID == Common.CurrentResource.ObjectID || (IsGeneral.HasValue && IsGeneral.Value == true)))
                throw new TTException("Eklemeye çalıştığınız icmal genel icmal değil veya size ait bir icmal değil.");
            if (Payer.ObjectID != sep.Payer.ObjectID)
                throw new TTException("Eklemeye çalıştığınız icmalin kurumu uyumsuzdur.");
            if (!(TedaviTuru == null || (TedaviTuru != null && TedaviTuru.tedaviTuruKodu == ttKodu)))
                throw new TTException("Eklemeye çalıştığınız icmalin tedavi türü uyumsuzdur.");
            if (Capacity != null && InvoiceCollectionDetails.Count(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled) >= Capacity)
                throw new TTException("Eklemeye çalıştığınız icmalin kapasitesi dolmuştur.");

            sep.CreateInvoiceCollectionDetail(this, InvoiceCollectionDetail.States.New);
            InvoiceCollectionDetail icd = sep.InvoiceCollectionDetail;

            foreach (var sepInner in sep.SEPMaster.SubEpisodeProtocols.Where(x => x.CurrentStateDefID == SubEpisodeProtocol.States.Open && sep.Payer.ObjectID == x.Payer.ObjectID  && (x.InvoiceStatus == MedulaSubEpisodeStatusEnum.ProvisionNoNotExists || x.InvoiceStatus == MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted)))
            {
                if (sepInner.InvoiceCollectionDetail == null)
                {
                    sepInner.InvoiceCollectionDetail = icd;
                    sepInner.InvoiceStatus = MedulaSubEpisodeStatusEnum.InsideInvoiceCollection;
                }
                else if (sepInner.ObjectID == sep.ObjectID)
                    sepInner.InvoiceStatus = MedulaSubEpisodeStatusEnum.InsideInvoiceCollection;
                else if (sepInner.ObjectID != sep.ObjectID)
                    throw new TTException("İcmale eklenmeye çalışılan kayıtlarda daha önce icmalde olan bulundu. Lütfen kontrol ediniz.");

                InvoiceLog.AddInfo("İcmale eklendi. İcmal Adı: " + icd.InvoiceCollection.Name, sepInner.ObjectID, InvoiceOperationTypeEnum.IcmaleEkle, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectContext);
            }

            return icd;
        }

        public bool RemoveInvoiceCollectionDetail(InvoiceCollectionDetail icd, CancelledInvoiceTypeEnum cancelType)
        {
            icd.CurrentStateDefID = InvoiceCollectionDetail.States.Cancelled;
            DateTime nw = DateTime.Now;
            List<SubEpisodeProtocol> list = icd.SubEpisodeProtocols.ToList();
            foreach (var sepInner in list)
            {
                InvoiceLog.AddInfo("İcmalden çıkarıldı. İcmal Adı: " + icd.InvoiceCollection.Name, sepInner.ObjectID, InvoiceOperationTypeEnum.IcmaldenCikar, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, ObjectContext);
                if (sepInner.InvoiceStatus == MedulaSubEpisodeStatusEnum.InsideInvoiceCollection || sepInner.InvoiceStatus == MedulaSubEpisodeStatusEnum.ProvisionNoNotExists || sepInner.InvoiceStatus == MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted)
                {//icmal içerisindeki bir sep İcmal İçerisinde statüsü dışında bir statüde olabilir mi?
                    sepInner.InvoiceCollectionDetail = null;
                    if (string.IsNullOrEmpty(sepInner.MedulaTakipNo))
                        sepInner.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
                    else
                        sepInner.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;

                    CancelledInvoice ci = new CancelledInvoice(ObjectContext);
                    ci.SEP = sepInner;
                    ci.ICD = icd;
                    ci.Date = nw;
                    ci.Type = cancelType;
                    ci.User = Common.CurrentResource;
                }
                else
                    throw new TTException("İcmalden çıkarılmaya çalışılan kayıtların durumu 'İcmal İçerisinde' olmalıdır.");
            }

            return true;
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InvoiceCollection).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if ((fromState == InvoiceCollection.States.Closed || fromState == InvoiceCollection.States.Delivered) && toState == InvoiceCollection.States.Send) //toSend
                PostTransition_2Send();
            else if ((fromState == InvoiceCollection.States.Open || fromState == InvoiceCollection.States.Locked) && toState == InvoiceCollection.States.Closed) //ToClose
                PostTransition_2Closed();
            else if ((fromState == InvoiceCollection.States.Delivered || fromState == InvoiceCollection.States.Paid) && toState == InvoiceCollection.States.PartialPaid) //toPartialPaid
                PostTransition_2PartialPaid();
            else if ((fromState == InvoiceCollection.States.Delivered || fromState == InvoiceCollection.States.PartialPaid) && toState == InvoiceCollection.States.Paid) //toPaid
                PostTransition_2Paid();
            else if (toState == InvoiceCollection.States.Delivered) //toDelivered
            {
                if (fromState == InvoiceCollection.States.Closed || fromState == InvoiceCollection.States.Send)
                    PostTransition_Send2Delivered();
                else if (fromState == InvoiceCollection.States.PartialPaid || fromState == InvoiceCollection.States.Paid)
                    PostTransition_Paid2Delivered();
            }
            else if (fromState == InvoiceCollection.States.Closed && toState == InvoiceCollection.States.Open) //toOpen
            {
                foreach (InvoiceCollectionDocument invCollectionDoc in AccountDocuments)
                {
                    if (invCollectionDoc.CurrentStateDefID == InvoiceCollectionDocument.States.Invoiced)
                    {
                        invCollectionDoc.CurrentStateDefID = InvoiceCollectionDocument.States.Cancelled;
                        invCollectionDoc.CancelDate = Common.RecTime();
                    }
                }
            }
            else if ((fromState == InvoiceCollection.States.Locked || fromState == InvoiceCollection.States.Open) && toState == InvoiceCollection.States.Cancelled) //toCancel
            {
                foreach (InvoiceCollectionDetail invCollectionDet in InvoiceCollectionDetails.Where(x => x.CurrentStateDefID == InvoiceCollectionDetail.States.New || x.CurrentStateDefID == InvoiceCollectionDetail.States.Invoiced))
                {
                    if (invCollectionDet.PayerInvoiceDocument != null)
                        invCollectionDet.PayerInvoiceDocument.Cancel();

                    invCollectionDet.InvoiceCollection.RemoveInvoiceCollectionDetail(invCollectionDet, CancelledInvoiceTypeEnum.OutOfInvoiceCollection);
                }

                foreach (InvoiceCollectionDocument invCollectionDoc in AccountDocuments)
                {
                    invCollectionDoc.CurrentStateDefID = TTObjectClasses.InvoiceCollectionDocument.States.Cancelled;
                }
            }
        }
        public void PostTransition_2Closed()
        {
            if (InvoiceTerm == null)
                throw new TTException("Dönemi belli olmayan icmal kapatılamaz!");

            if (IsAutoGenerated != true)
            {
                if (InvoiceCollectionDetails.Where(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled).Count() == 0)
                    throw new TTException(TTUtils.CultureService.GetText("M26001", "İcmal içerisinde detay bulunmadığı için kapatılamaz!"));

                TotalPrice = 0;
                int counter = 1;
                InvoiceCollectionDocument invCollectionDoc = null;
                foreach (InvoiceCollectionDetail icd in InvoiceCollectionDetails.OrderBy(x => x.Episode.OpeningDate))
                {
                    if (icd.CurrentStateDefID == InvoiceCollectionDetail.States.New || icd.CurrentStateDefID == InvoiceCollectionDetail.States.Invoiced)
                    {
                        if (icd.PayerInvoiceDocument == null)
                            icd.CreatePayerInvoice(Date.Value, "İcmal kapatılırken otomatik faturalama.");

                        TotalPrice += icd.PayerInvoiceDocument.TotalPrice;

                        //Toplu faturalama ise sıra numarası ver.
                        if (Type == InvoiceCollectionTypeEnum.CollectedInvoice)
                        {
                            icd.PayerInvoiceDocument.OrderNo = counter;

                            if (counter == 1)
                            {
                                invCollectionDoc = new InvoiceCollectionDocument(ObjectContext);
                                invCollectionDoc.AccountAction = this;
                                invCollectionDoc.DocumentNo = icd.PayerInvoiceDocument.DocumentNo;
                                invCollectionDoc.DocumentDate = Date.Value;
                                invCollectionDoc.CreateDate = DateTime.Now;
                                invCollectionDoc.Payer = Payer;
                                invCollectionDoc.Description = Description;
                                invCollectionDoc.ResUser = Common.CurrentResource;
                                invCollectionDoc.CurrentStateDefID = TTObjectClasses.InvoiceCollectionDocument.States.Invoiced;
                                InvoiceCollectionDocument = invCollectionDoc;
                                //DocumentID = 0;  Gerekirse eklenecek
                            }

                            //icd.PayerInvoiceDocument.DocumentNo = icd.PayerInvoiceDocument.DocumentNo + "-" + icd.PayerInvoiceDocument.OrderNo.ToString();

                            foreach (PayerInvoiceDocumentGroup pidg in icd.PayerInvoiceDocument.PayerInvoiceDocumentGroups)
                            {
                                InvoiceCollectionDocumentGroup tempIcdg = invCollectionDoc.InvoiceCollectionDocumentGroups.Where(x => x.GroupCode == pidg.GroupCode && x.GroupDescription == pidg.GroupDescription).FirstOrDefault();

                                if (tempIcdg == null)
                                {
                                    tempIcdg = new InvoiceCollectionDocumentGroup(ObjectContext);
                                    tempIcdg.GroupCode = pidg.GroupCode;
                                    tempIcdg.GroupDescription = pidg.GroupDescription;
                                    tempIcdg.AccountDocument = invCollectionDoc;
                                }

                                foreach (PayerInvoiceDocumentDetail pidd in pidg.PayerInvoiceDocumentDetails)
                                {
                                    InvoiceCollectionDocumentDetail tempIcdd = tempIcdg.InvoiceCollectionDocumentDetails.Where(x => x.ExternalCode == pidd.ExternalCode && x.Description == pidd.Description && x.UnitPrice == pidd.UnitPrice).FirstOrDefault();

                                    if (tempIcdd == null)
                                    {
                                        tempIcdd = new InvoiceCollectionDocumentDetail(ObjectContext);
                                        tempIcdd.ExternalCode = pidd.ExternalCode;
                                        tempIcdd.Description = pidd.Description;
                                        tempIcdd.Amount = pidd.Amount;
                                        tempIcdd.UnitPrice = pidd.UnitPrice;
                                        tempIcdd.TotalDiscountPrice = pidd.TotalDiscountPrice;
                                        tempIcdd.TotalDiscountedPrice = pidd.TotalDiscountedPrice;
                                    }
                                    else
                                    {
                                        tempIcdd.Amount += pidd.Amount;
                                        tempIcdd.TotalDiscountPrice += pidd.TotalDiscountPrice;
                                        tempIcdd.TotalDiscountedPrice += pidd.TotalDiscountedPrice;
                                    }
                                    tempIcdd.AccountDocumentGroup = tempIcdg;
                                }
                            }

                            if (icd.PayerInvoiceDocument.MaterialTotal.HasValue)
                            {
                                if (!invCollectionDoc.MaterialTotal.HasValue)
                                    invCollectionDoc.MaterialTotal = 0;

                                invCollectionDoc.MaterialTotal += icd.PayerInvoiceDocument.MaterialTotal.Value;
                            }

                            if (icd.PayerInvoiceDocument.DrugTotal.HasValue)
                            {
                                if (!invCollectionDoc.DrugTotal.HasValue)
                                    invCollectionDoc.DrugTotal = 0;

                                invCollectionDoc.DrugTotal += icd.PayerInvoiceDocument.DrugTotal.Value;
                            }
                        }
                        counter++;
                    }
                }

                if (InvoiceCollectionDetails.Where(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled && x.CurrentStateDefID != InvoiceCollectionDetail.States.Invoiced).Count() > 0)
                    throw new TTException("İcmali 'Kapalı' durumuna alabilmek için tüm detayları 'Faturalandı' durumunda olmalıdır.");

                if (invCollectionDoc != null)
                    invCollectionDoc.TotalPrice = TotalPrice;
            }
        }

        protected void PostTransition_2Send()
        {
            if (string.IsNullOrEmpty(SendingNo))
                throw new TTException(TTUtils.CultureService.GetText("M26701", "Postaya Gönderim durumuna alabilmek için 'Posta Gönderim Numarası' zorunludur."));

            if (!SendingDate.HasValue)
                throw new TTException(TTUtils.CultureService.GetText("M26702", "Postaya Gönderim durumuna alabilmek için 'Posta Gönderim Tarihi' zorunludur."));
        }

        protected void PostTransition_Send2Delivered()
        {
            if (!DeliveredDate.HasValue)
                throw new TTException(TTUtils.CultureService.GetText("M26015", "İcmali Kuruma Teslim durumuna alabilmek için 'Kuruma Teslim Tarihi' zorunludur."));
        }

        protected void PostTransition_Paid2Delivered()
        {
            if (InvoiceCollectionDetails.Where(x => x.CurrentStateDefID == InvoiceCollectionDetail.States.PartialPaid || x.CurrentStateDefID == InvoiceCollectionDetail.States.Paid).Count() > 0)
                throw new TTException(TTUtils.CultureService.GetText("M26018", "İçerisinde 'Kısmen Ödendi' veya 'Ödendi' durumunda detay bulunan icmal 'Kuruma Teslim' durumuna alınamaz."));
        }

        protected void PostTransition_2PartialPaid()
        {
            int detailCount = InvoicedDetailCount();

            if (detailCount == InvoiceCollectionDetails.Where(x => x.CurrentStateDefID == InvoiceCollectionDetail.States.Paid).Count())
                throw new TTException(TTUtils.CultureService.GetText("M27126", "Tüm detayları 'Ödendi' durumunda olan icmal 'Kısmen Ödendi' durumuna alınamaz."));

            if (detailCount == InvoiceCollectionDetails.Where(x => x.CurrentStateDefID == InvoiceCollectionDetail.States.Invoiced).Count())
                throw new TTException(TTUtils.CultureService.GetText("M27125", "Tüm detayları 'Faturalandı' durumunda olan icmal 'Kısmen Ödendi' durumuna alınamaz."));
        }

        protected void PostTransition_2Paid()
        {
            if (InvoiceCollectionDetails.Where(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled && x.CurrentStateDefID != InvoiceCollectionDetail.States.Paid).Count() > 0)
                throw new TTException(TTUtils.CultureService.GetText("M26016", "İcmali Ödendi durumuna alabilmek için tüm detayları Ödendi durumunda olmalıdır."));
        }

        public void PrepareNewInvoiceCollection()
        {
            Date = Common.RecTime();
            IsGeneral = false;
            IsAutoGenerated = false;
            CreateUser = Common.CurrentResource;
        }
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
                No.GetNextValue();
        }

        public int DetailCount()
        {
            return InvoiceCollectionDetails.Where(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled).Count();
        }

        public int InvoicedDetailCount()
        {
            return InvoiceCollectionDetails.Where(x => x.CurrentStateDefID == InvoiceCollectionDetail.States.Invoiced ||
                                                       x.CurrentStateDefID == InvoiceCollectionDetail.States.PartialPaid ||
                                                       x.CurrentStateDefID == InvoiceCollectionDetail.States.Paid).Count();
        }

        protected override void PreInsert()
        {
            base.PreInsert();

            if (InvoiceTerm != null && InvoiceTerm.CurrentStateDefID != InvoiceTerm.States.Open)
                throw new TTException(TTUtils.CultureService.GetText("M26813", "Seçilen Dönemin 'Açık' durumda olması gerekmektedir."));

            if (IsAutoGenerated != true && TedaviTuru != null && TedaviTuru.tedaviTuruKodu == "G")
                throw new TTException(TTUtils.CultureService.GetText("M27083", "Tedavi Türü 'Günübirlik' olan icmal oluşturulamaz."));

            CreateUser = Common.CurrentResource;
            CreateDate = Common.RecTime();
            LastStateUser = Common.CurrentResource;
            LastStateDate = Common.RecTime();
        }

        protected override void PreUpdate()
        {
            base.PreUpdate();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                InvoiceCollection oldIncvoiceCollection = objectContext.GetObject<InvoiceCollection>(ObjectID);
                if (Payer == null)
                    throw new TTException("Lütfen Kurum Bilgisi seçiniz.");
                if (oldIncvoiceCollection.Payer.ObjectID != Payer.ObjectID)
                {
                    if (DetailCount() > 0)
                        throw new TTException(TTUtils.CultureService.GetText("M25425", "Detayları olan icmalin Kurumu güncellenemez."));
                }
                if (oldIncvoiceCollection.TedaviTuru != null && TedaviTuru != null && oldIncvoiceCollection.TedaviTuru.ObjectID != TedaviTuru.ObjectID)
                {
                    if (DetailCount() > 0)
                        throw new TTException(TTUtils.CultureService.GetText("M25426", "Detayları olan icmalin Tedavi Türü güncellenemez."));
                }
                if (Capacity.HasValue && oldIncvoiceCollection.Capacity != Capacity)
                {
                    if (DetailCount() > Capacity)
                        throw new TTException("Kapasite güncellenemiyor! Girilen kapasite icmal içerisinde bulunan detay sayısından fazladır.");
                }
                if ((oldIncvoiceCollection.InvoiceTerm == null && InvoiceTerm != null) ||
                   (oldIncvoiceCollection.InvoiceTerm != null && InvoiceTerm == null) ||
                   (oldIncvoiceCollection.InvoiceTerm != null && InvoiceTerm != null && oldIncvoiceCollection.InvoiceTerm.ObjectID != InvoiceTerm.ObjectID))
                {
                    if (InvoicedDetailCount() > 0)
                        throw new TTException(TTUtils.CultureService.GetText("M25667", "Faturalanmış detayı olan icmalin Dönemi güncellenemez!"));
                }
                if (oldIncvoiceCollection.Type != Type)
                {
                    if (InvoicedDetailCount() > 0)
                        throw new TTException(TTUtils.CultureService.GetText("M25668", "Faturalanmış detayı olan icmalin Tipi güncellenemez!"));
                }
                if (InvoiceTerm != null && InvoiceTerm.CurrentStateDefID != InvoiceTerm.States.Open && InvoiceTerm.CurrentStateDefID != InvoiceTerm.States.Locked)
                {
                    //Fatura tahsilat işleminden gelen durum kontrolü
                    if (!(InvoiceTerm.CurrentStateDefID == InvoiceTerm.States.Closed &&
                         (CurrentStateDefID == InvoiceCollection.States.PartialPaid ||
                            CurrentStateDefID == InvoiceCollection.States.Paid ||
                                (CurrentStateDefID == InvoiceCollection.States.Delivered &&
                                                                (oldIncvoiceCollection.CurrentStateDefID == InvoiceCollection.States.PartialPaid
                                                                || oldIncvoiceCollection.CurrentStateDefID == InvoiceCollection.States.Paid
                                                                )
                           )
                         )
                        )
                       )
                        throw new TTException("İcmal üzerinde güncelleme yapabilmek için seçilen Dönemin 'Açık' veya 'Kilitli' olması gerekmektedir.");
                }
                if (IsAutoGenerated == true && (CurrentStateDefID == InvoiceCollection.States.Locked || CurrentStateDefID == InvoiceCollection.States.Cancelled))
                    throw new TTException(TTUtils.CultureService.GetText("M26643", "Otomatik oluşturulan icmal 'Kilitli' veya 'İptal' adımına geçemez."));
            }

            LastStateUser = Common.CurrentResource;
            LastStateDate = Common.RecTime();
        }

        public void SetStateAfterInvoicePayment()
        {
            if (CurrentStateDefID != InvoiceCollection.States.Delivered && CurrentStateDefID != InvoiceCollection.States.PartialPaid && CurrentStateDefID != InvoiceCollection.States.Paid)
                throw new TTException("Fatura tahsilat işlemi için İcmal 'Kuruma Teslim' , 'Kısmen Ödendi' veya 'Ödendi' durumlarından birinde olmalıdır. İcmal Durumu : " + CurrentStateDef.DisplayText);

            int detailCount = InvoicedDetailCount();

            if (detailCount == InvoiceCollectionDetails.Where(x => x.CurrentStateDefID == InvoiceCollectionDetail.States.Paid).Count()) // Tüm detaylar "Paid" durumunda ise İcmal "Paid" durumuna alınır
                CurrentStateDefID = InvoiceCollection.States.Paid;
            else if (detailCount == InvoiceCollectionDetails.Where(x => x.CurrentStateDefID == InvoiceCollectionDetail.States.Invoiced).Count()) // Tüm detaylar "Invoiced" durumunda ise İcmal "Delivered" durumuna alınır
                CurrentStateDefID = InvoiceCollection.States.Delivered;
            else
                CurrentStateDefID = InvoiceCollection.States.PartialPaid; // Diğer durumda İcmal "PartialPaid" durumuna alınır
        }
    }
}