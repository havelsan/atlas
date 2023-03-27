
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
    /// Fizyoterapi �stek ��lemlerinin Ger�ekle�tirildi�i  Nesnedir
    /// </summary>
    public partial class PhysiotherapyRequest : EpisodeActionWithDiagnosis, IReasonOfReject, IAllocateSpeciality
    {
        public partial class GetPhysiotheraphyHealthReport_Class : TTReportNqlObject
        {
        }

        public partial class GetPhysiotherapyReport_Class : TTReportNqlObject
        {
        }

        #region IAllocateSpeciality Members
        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        public EpisodeAction GetMyEpisodeAction()
        {
            return MyEpisodeAction;
        }

        public void SetMyEpisodeAction(EpisodeAction value)
        {
            MyEpisodeAction = value;
        }

        public SubActionProcedure GetMySubActionProcedure()
        {
            return MySubActionProcedure;
        }

        public void SetMySubActionProcedure(SubActionProcedure value)
        {
            MySubActionProcedure = value;
        }

        public SpecialityDefinition GetProcedureSpeciality()
        {
            return ProcedureSpeciality;
        }

        public void SetProcedureSpeciality(SpecialityDefinition value)
        {
            ProcedureSpeciality = value;
        }

        #endregion

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "INPATIENTBED":
                    {
                        ResBed value = (ResBed)newValue;
                        #region INPATIENTBED_SetParentScript
                        if (value != null)
                        {
                            if (value.Room != null && value.Room.RoomGroup != null)
                                SecondaryMasterResource = value.Room.RoomGroup.Ward;
                        }
                        #endregion INPATIENTBED_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PreTransition_Request2Completed()
        {
            // From State : Request   To State : Completed
            #region PreTransition_Request2Completed


            if (ProcedureDoctor == null)
                throw new Exception(SystemMessage.GetMessage(633));

            if (PhysiotherapyOrders.Count == 0)
                throw new Exception(SystemMessage.GetMessage(1154));
            else
            {
                foreach (PhysiotherapyOrder physiotherapyOrder in PhysiotherapyOrders)
                {
                    if (physiotherapyOrder.Amount >= 30)
                    {
                        if (SecondProcedureDoctor == null)
                            throw new Exception(SystemMessage.GetMessage(1155));
                        if (ThirdProcedureDoctor == null)
                            throw new Exception(SystemMessage.GetMessage(1156));
                    }
                }
            }

            //if(this.SubEpisode.IsSGK && this.PackageProcedure == null)
            //    throw new Exception("SGK'l� hastalar i�in Paket Hizmet alan� bo� ge�ilemez.");

            #endregion PreTransition_Request2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }
        protected void PostTransition_Completed2Planned()
        {
            // From State : Completed   To State : Planned
            #region PostTransition_Completed2Planned

            //this.Cancel();
            #endregion PostTransition_Completed2Planned
        }

        protected void PostTransition_RequestAcception2Planned()//planlamadan uygulama ad�m�na ge�i�te seans objeleri olu�turuluyor
        {
            // From State : RequestAcception   To State : Planned
            #region PostTransition_RequestAcception2Planned

            var reportList = PhysiotherapyOrders.Where(c => c.CurrentStateDefID != PhysiotherapyOrder.States.Cancelled && c.PackageProcedure != null).GroupBy(x => x.PackageProcedure);
            if (SubEpisode.StarterEpisodeAction.SubEpisode.PatientStatus.Value == SubEpisodeStatusEnum.Outpatient && reportList.Count() > 1)
            {
                throw new Exception("Ayaktan hasta i�in birden fazla paket hizmeti i�in planlama yap�lamaz !");
            }
            else if (SubEpisode.StarterEpisodeAction.SubEpisode.PatientStatus.Value != SubEpisodeStatusEnum.Outpatient && reportList.Count() > 2)
            {
                throw new Exception("Yatan hasta i�in ikiden fazla paket hizmeti i�in planlama yap�lamaz !");
            }

            var PhysiotherapyOrderDetailList = PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled);
            List<PhysiotherapySessionInfo> sessionList = PhysiotherapySessions.ToList();
            if (sessionList.Count() > 0)
            {
                foreach (var item in sessionList)
                {
                    //var olan sessionlar silinecek!
                    PhysiotherapySessionInfo sessionItem = PhysiotherapySessions.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault();
                    ((ITTObject)sessionItem).Delete();
                }
            }
            foreach (var groupedItem in PhysiotherapyOrderDetailList.GroupBy(c => c.PlannedDate.Value.Date))
            {
                PhysiotherapySessionInfo _sessionInfo = new PhysiotherapySessionInfo(ObjectContext);
                _sessionInfo.PlannedDate = groupedItem.FirstOrDefault().PlannedDate;
                _sessionInfo.PhysiotherapyRequest = this;
                foreach (var orderDetail in groupedItem)
                {
                    orderDetail.PhysiotherapySession = _sessionInfo;
                }
            }

            #endregion PostTransition_RequestAcception2Planned
        }

        #region Methods

        public override void SetMySubActionProceduresPerformedDate()
        {
            // EpisodeAction ba�ar�l� tamamlan�rken alt�ndaki SubactionProcedurelerinden PerformedDate'i bo� olanlar�n ser edilmesini engellemek i�in bo� overrride yap�ld�.
        }
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.PhysiotherapyRequest;
            }
        }

        public override void Cancel()
        {

            foreach (PhysiotherapyOrder physiotherapyOrder in PhysiotherapyOrders)
            {
                if (physiotherapyOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled && physiotherapyOrder.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                {
                    throw new Exception(SystemMessage.GetMessage(1157));
                }
            }
            base.Cancel();
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            //            ITTObject theObj = (ITTObject)this;
            //            if (theObj.IsNew)
            //            {
            //                this.ReportNo.GetNextValue();
            //            }
        }

        public PhysiotherapyRequest(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            EpisodeAction _episodeAction = objectContext.GetObject<EpisodeAction>(episodeAction.ObjectID);

            ActionDate = Common.RecTime();
            //this.MasterResource = _episodeAction.MasterResource;// i�lem kaynek e�le�tirmeden set edilsin diye kapat�ld�
            FromResource = _episodeAction.MasterResource;
            CurrentStateDefID = PhysiotherapyRequest.States.RequestAcception;
            MasterAction = _episodeAction;
            Episode = _episodeAction.Episode;
            if (episodeAction.SubEpisode.StarterEpisodeAction != null && episodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor != null)
                ProcedureDoctor = episodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor;
            else if (episodeAction.ProcedureDoctor != null)
                ProcedureDoctor = episodeAction.ProcedureDoctor;
        }

        public override List<int> AllowedMedulaTedaviTipi()
        {
            List<int> typeList = new List<int>();
            typeList.Add(2);//Fiziksel Tedavi ve Rehabilitasyon
            return typeList;
        }

        public RaporIslemleri.raporGirisDVO GetTakipNoileRaporBilgisiKaydet(PhysiotherapyRequest phyReq)
        {
            RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();

            if (phyReq.SubEpisode != null && phyReq.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(phyReq.SubEpisode.SGKSEP.MedulaTakipNo))
            {

                raporGirisDVO.ilacRapor = null;
                //TODO : MEDULA20140501
                raporGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                raporGirisDVO.isgoremezlikRapor = null;

                RaporIslemleri.tedaviRaporDVO _tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
                if (phyReq.SubEpisode.SGKSEP != null)
                {
                    if (phyReq.SubEpisode.SGKSEP.MedulaProvizyonTipi != null)
                    {
                        if (phyReq.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu == "T")
                        {
                            _tedaviRaporDVO.tedaviRaporTuru = 7;
                        }
                        else
                        {
                            _tedaviRaporDVO.tedaviRaporTuru = 5;
                        }
                    }
                }
                List<RaporIslemleri.tedaviIslemBilgisiDVO> _tedaviIslemBilgisiDVOList = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();

                foreach (PhysiotherapyOrder item in _PhysiotherapyOrders)
                {
                    RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();
                    if (((PhysiotherapyDefinition)item.ProcedureObject).ESWTTransaction.HasValue)
                    {
                        _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.eswlRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.hotRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = null;


                        RaporIslemleri.eswtRaporBilgisiDVO _eSWTRaporBilgisiDVO = new RaporIslemleri.eswtRaporBilgisiDVO();
                        _eSWTRaporBilgisiDVO.butKodu = item.ProcedureObject != null ? item.ProcedureObject.Code : "";
                        _eSWTRaporBilgisiDVO.eswtVucutBolgesiKodu = item.FTRApplicationAreaDef != null ? item.FTRApplicationAreaDef.ftrVucutBolgesiKodu.Value : 0;

                        _eSWTRaporBilgisiDVO.seansGun = item.SeansGunSayisi != null ? item.SeansGunSayisi.Value : 0;
                        _eSWTRaporBilgisiDVO.seansSayi = item.Amount != null ? Convert.ToInt32(item.Amount.Value) : 0;

                        _tedaviIslemBilgisiDVO.eswtRaporBilgisi = _eSWTRaporBilgisiDVO;

                        _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);
                    }
                    else
                    {
                        _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.eswlRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.hotRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = null;


                        RaporIslemleri.ftrRaporBilgisiDVO _fTRRaporBilgisiDVO = new RaporIslemleri.ftrRaporBilgisiDVO();
                        _fTRRaporBilgisiDVO.butKodu = item.ProcedureObject != null ? item.ProcedureObject.Code : "";
                        _fTRRaporBilgisiDVO.ftrVucutBolgesiKodu = item.FTRApplicationAreaDef != null ? item.FTRApplicationAreaDef.ftrVucutBolgesiKodu.Value : 0;
                        _fTRRaporBilgisiDVO.robotikRehabilitasyon = "";
                        _fTRRaporBilgisiDVO.seansGun = item.Duration != null ? Convert.ToInt32(item.Duration.Value) : 0;
                        _fTRRaporBilgisiDVO.seansSayi = item.Amount != null ? Convert.ToInt32(item.Amount.Value) : 0;
                        if (phyReq.Episode.PatientStatus.HasValue)
                        {
                            if (phyReq.Episode.PatientStatus == PatientStatusEnum.Inpatient || phyReq.Episode.PatientStatus == PatientStatusEnum.PreDischarge)
                                _fTRRaporBilgisiDVO.tedaviTuru = "Y";
                            if (phyReq.Episode.PatientStatus == PatientStatusEnum.Outpatient)
                                _fTRRaporBilgisiDVO.tedaviTuru = "A";

                        }
                        else
                        {
                            _fTRRaporBilgisiDVO.tedaviTuru = "A";
                        }
                        _tedaviIslemBilgisiDVO.ftrRaporBilgisi = _fTRRaporBilgisiDVO;

                        _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);
                    }

                }
                if (_tedaviIslemBilgisiDVOList.Count > 0)
                    _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();



                RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();

                _raporDVO.aciklama = "";
                _raporDVO.baslangicTarihi = phyReq.ReportStartDate != null ? phyReq.ReportStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.bitisTarihi = phyReq.ReportEndDate != null ? phyReq.ReportEndDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.durum = "";
                _raporDVO.duzenlemeTuru = "2";
                _raporDVO.klinikTani = "";
                _raporDVO.protokolNo = phyReq.Episode.HospitalProtocolNo.ToString();
                _raporDVO.protokolTarihi = phyReq.SubEpisode.PatientAdmission.ActionDate != null ? phyReq.SubEpisode.PatientAdmission.ActionDate.Value.ToString("dd.MM.yyyy") : "";

                List<RaporIslemleri.taniBilgisiDVO> _taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
                foreach (DiagnosisGrid diagnosis in phyReq.Episode.Diagnosis)
                {
                    RaporIslemleri.taniBilgisiDVO _taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
                    _taniBilgisiDVO.taniKodu = diagnosis.DiagnoseCode;
                    _taniBilgisiDVOList.Add(_taniBilgisiDVO);

                }
                if (_taniBilgisiDVOList.Count > 0)
                    _raporDVO.tanilar = _taniBilgisiDVOList.ToArray();

                _raporDVO.turu = "1";
                _raporDVO.takipNo = phyReq.SubEpisode.SGKSEP.MedulaTakipNo;

                List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
                RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
                _doktorBilgisiDVO.drAdi = phyReq.ProcedureDoctor.Person.Name;
                _doktorBilgisiDVO.drBransKodu = phyReq.ProcedureDoctor.GetSpeciality() != null ? phyReq.ProcedureDoctor.GetSpeciality().Code : "";
                _doktorBilgisiDVO.drSoyadi = phyReq.ProcedureDoctor.Person.Surname;
                _doktorBilgisiDVO.drTescilNo = phyReq.ProcedureDoctor.DiplomaRegisterNo;
                _doktorBilgisiDVO.tipi = "2";
                _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
                _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();

                _raporDVO.hakSahibi = null;

                RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
                _raporBilgisiDVO.aVakaTKaza = 3;
                //  _raporBilgisiDVO.no = this.ReportNo.Value.ToString();
                _raporBilgisiDVO.raporSiraNo = 0;
                _raporBilgisiDVO.raporTakipNo = "";
                _raporBilgisiDVO.raporTesisKodu = SystemParameter.GetSaglikTesisKodu();
                _raporBilgisiDVO.tarih = phyReq.ReportStartDate != null ? phyReq.ReportStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.raporBilgisi = _raporBilgisiDVO;
                _raporDVO.teshisler = null;

                _tedaviRaporDVO.raporDVO = _raporDVO;

                raporGirisDVO.tedaviRapor = _tedaviRaporDVO;
            }
            return raporGirisDVO;
        }

        public static int GetTotalRoboticOrdersCount(Guid patientID)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            Guid roboticID = new Guid("8f2c7584-cb37-446f-a731-52383e063e93");

            BindingList<PhysiotherapyOrderDetail> list = PhysiotherapyOrderDetail.GetPhyOrderDetsForPatientByOrderObject(objectContext, roboticID.ToString(), patientID.ToString());
            int totalAmount = 0;
            foreach (PhysiotherapyOrderDetail pOrderDetail in list)
            {
                if (((DateTime)((PhysiotherapyOrder)pOrderDetail.OrderObject).ActionDate).AddYears(1) > Common.RecTime())
                    totalAmount = totalAmount + Convert.ToInt32(pOrderDetail.Amount);
            }
            return totalAmount;
        }

        #region SubEpisode Metodlar�

        public override DateTime SubEpisodeOpeningDate()
        {
            if (PhysiotherapyRequestDate.HasValue)
                return PhysiotherapyRequestDate.Value;

            return Common.RecTime();
        }

        //public override DateTime SubEpisodeOpeningDate()
        //{
        //    DateTime subEpisodeDate;
        //    //SubEpisode Tarihi en erken tarihli order'�n tarihi set ediliyor
        //    subEpisodeDate = (this.PhysiotherapyOrders.Where(c => c.CurrentStateDefID != PhysiotherapyOrder.States.Cancelled && c.PhysiotherapyStartDate != null).Count() > 0) ? ((DateTime)this.PhysiotherapyOrders.Where(c => c.CurrentStateDefID != PhysiotherapyOrder.States.Cancelled && c.PhysiotherapyStartDate != null).OrderBy(c => c.PhysiotherapyStartDate).FirstOrDefault().PhysiotherapyStartDate) : base.SubEpisodeOpeningDate();

        //    //SubEpisode saati; tamamlanm�� en erken tarihli orderDetailvar ise onun saati yok ise order saati set ediliyor.
        //    var details = this.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Completed).OrderBy(x => x.PhysiotherapyOrder.PhysiotherapyStartDate);
        //    if (details.Count() > 0 && details.FirstOrDefault().StartDate != null)
        //    {
        //        subEpisodeDate = subEpisodeDate.Date + details.FirstOrDefault().StartDate.Value.TimeOfDay;
        //    }


        //    return subEpisodeDate;
        //}

        //public override SubEpisode SubEpisodeCreatedByMe // ICreateSubEpisode  interfacei i�in  kullan�l�r
        //{
        //    get
        //    {
        //        return Episode.SubEpisodes.Where(x => x.StarterEpisodeAction.ObjectID == ObjectID).FirstOrDefault();
        //    }
        //    set { }
        //}

        //public ISubEpisodeStarter SubEpisodeStarter
        //{
        //    get
        //    {
        //        return (ISubEpisodeStarter)this;
        //    }

        //    set
        //    {
        //    }
        //}

        public override List<EpisodeAction> GetLinkedEpisodeActionsForSubEpisode()
        {
            List<EpisodeAction> eaList = base.GetLinkedEpisodeActionsForSubEpisode();

                foreach (PhysiotherapyOrder pOrder in PhysiotherapyOrders)
                {
                    eaList.Add((EpisodeAction)pOrder);
                }

            return eaList;
        }

        //public override ResSection SubEpisodeResSection
        //{
        //    get
        //    {
        //        return (ResSection)GetResourceOfSepeciality();
        //    }
        //    set { }
        //}

        //public override SubEpisodeStatusEnum SubEpisodePatientStatus
        //{
        //    get
        //    {
        //        if (Episode.PatientStatus != PatientStatusEnum.Outpatient)
        //            return SubEpisodeStatusEnum.Inpatient;

        //        return SubEpisodeStatusEnum.Outpatient;
        //    }
        //    set { }
        //}

        public override SpecialityDefinition GetSubEpisodeSpeciality()
        {
            // Spor hekimli�i yada hidroklimatoloji den FTR ye kay�t a��l�yorsa bran� � FTR yapma, ilk takip ne ise �yle kals�n. 
            // Bu kontrol ArrangeMeOrCreateNewSubEpisode metodundan buraya ta��nd�, A�a��daki 2 bran�la ilgili kontrol ileride gerekirse a��lacak (MDZ)
            //if (Episode.MainSpeciality != null && (Episode.MainSpeciality.Code.Equals("4000") || Episode.MainSpeciality.Code.Equals("600")))
            //    return Episode.MainSpeciality;

            //return base.SubEpisodeSpeciality;

            return SpecialityDefinition.GetBrans("1800"); // Fiziksel T�p Ve Rehabilitasyon bran��. Ge�ici olarak sabit al�nd�, birimin bran� tan�m�ndan al�nmal�.
        }

        public override bool IsNewSubEpisodeNeeded()
        {
            if (GetSubEpisodeCreatedByMe() != null) // Zaten altvaka olu�turmu�sa tekrar olu�turmas�n
                return false;

            // Ba�lat�ld��� birimin tedavi tipi, subepisode daki son takibin tedavi tipinden farkl� ise yeni subepisode olu�turulacak
            // Normal -> FTR, Normal -> ESWT gibi
            SubEpisodeProtocol lastSEP = SubEpisode.LastActiveSubEpisodeProtocol;
            if (lastSEP != null)
            {
                if (lastSEP.MedulaTedaviTipi.tedaviTipiKodu != GetMyTedaviTipi().tedaviTipiKodu)
                    return true;
            }

            // 1800 = FTR , 600 = T�bbi Ekoloji ve Hidroklimatoloji, 4000 = Spor Hekimli�i
            //if (!Episode.IsSGKSubEpisodeProtocolExists(new String[] { "1800", "4000", "600" }, new String[] { "G", "Y" }, "2"))
            //    return true;

            // �nceden bu metod ile de kontrol yap�l�yordu PhysiotherapyOrder.PostUpdate metodunda, �imdilik kapatt�m ileride gerek olursa a��lmas� laz�m (MDZ)
            // Episode.Patient.SuitableToCreateNewDailySubEpisode(SubEpisodeSpeciality);  

            return false;
        }

        // SEP in de�i�tirilmesi gereken propertyleri varsa bu metodda set edilmeli
        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            sep.MedulaTedaviTipi = GetMyTedaviTipi();
            sep.ParentSEP = SubEpisode.LastActiveSubEpisodeProtocol;
            sep.MedulaProvizyonTarihi = sep.SubEpisode.OpeningDate; // SubEpisode.Openingdate planlanan ilk uygulama tarihi ile set edildi�i i�in, provizyon tarihi de bu tarih olarak set edilir
        }
        #endregion

        public TedaviTipi GetMyTedaviTipi()
        {
            TedaviTipi tedaviTipi = TedaviTipi.GetTedaviTipi("2");

            // ESWT i�lemi de FTR den yap�laca�� i�in, ESWT oldu�una se�ilen paketin kodundan bak�ld� �imdilik. �leride daha iyi bir y�akmak gerekir. (Mustafa)
            if (PhysiotherapyOrders.Count() > 0 && PhysiotherapyOrders[0].PackageProcedure != null && PhysiotherapyOrders[0].PackageProcedure.Code.Equals("P610820"))
                tedaviTipi = TedaviTipi.GetTedaviTipi("16");

            //ResSection resSection = SubEpisodeResSection;
            //if (resSection != null && resSection.TedaviTipi != null)
            //    tedaviTipi = resSection.TedaviTipi;

            return tedaviTipi;
        }

        public void CompleteRequestByDate(DateTime dateTime)//Belirtilen tarihten sonraki uygulanmam�� detailler abort durumuna �ekiliyor ve yeni durumunda i�lem kalmam��sa order ve request tamaman�yor.
        {
            var uncompleteDetails = PhysiotherapyOrderDetails.Where(x => x.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution && x.PlannedDate.Value.Date > dateTime.Date);//belirlenen tarihten sonra uygulama ad�m�nda olan detailller
            foreach (var orderDetail in uncompleteDetails)
            {
                orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Aborted;
                orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Aborted;
                orderDetail.IsChangedAutomatically = true;
            }
            foreach (var order in PhysiotherapyOrders)
            {
                CompletePhysiotherapyOrder(order);
            }
            CompletePhysiotherapyRequest();
        }
        public void CompleteRequest()//T�m uygulanmam�� detailler abort durumuna �ekiliyor ve yeni durumunda i�lem kalmam��sa order ve request tamaman�yor.
        {
            var uncompleteDetails = PhysiotherapyOrderDetails.Where(x => x.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution);//uygulama ad�m�nda olan detailller
            foreach (var orderDetail in uncompleteDetails)
            {
                orderDetail.CurrentStateDefID = PhysiotherapyOrderDetail.States.Aborted;
                orderDetail.PhysiotherapyState = PhysiotherapyStateEnum.Aborted;
                orderDetail.IsChangedAutomatically = true;
            }
            foreach (var order in PhysiotherapyOrders)
            {
                CompletePhysiotherapyOrder(order);
            }
            CompletePhysiotherapyRequest();
        }
        private void CompletePhysiotherapyOrder(PhysiotherapyOrder order)//Order Detaillerin Hepsi Tamamland� �se Order da tamamlanmal�
        {
            //Order Detaillerin Hepsi Tamamland� �se Order da tamamlanmal�
            if (order.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution).Count() == 0)
            {
                order.CurrentStateDefID = PhysiotherapyOrder.States.Completed;
            }
        }
        private void CompletePhysiotherapyRequest()//Order'lar�n Hepsi Tamamland� ise T�m Seans/Tedavi Tamamlans�n
        {
            //Order'lar�n Hepsi Tamamland� ise T�m Seans/Tedavi Tamamlans�n
            if (PhysiotherapyOrders.Where(c => c.CurrentStateDefID == PhysiotherapyOrder.States.RequestAcception).Count() == 0)
            {
                CurrentStateDefID = PhysiotherapyRequest.States.Completed;
            }
        }
        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PhysiotherapyRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == States.Request && toState == States.Completed)
            //    PreTransition_Request2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PhysiotherapyRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PhysiotherapyRequest.States.Completed && toState == PhysiotherapyRequest.States.Cancelled && SubEpisode.IsInvoicedCompletely == true)
            {
                if (Episode.PatientStatus == PatientStatusEnum.Discharge)
                {
                    throw new Exception("Taburcu edilmi�/Faturas� kesilmi� hastan�n seans sonland�rmas�n� geri alamazs�n�z!");
                }
                PostTransition_Completed2Cancelled();
            }


            if (fromState == PhysiotherapyRequest.States.Completed && toState == PhysiotherapyRequest.States.Planned && SubEpisode.IsInvoicedCompletely == true)
            {
                if (Episode.PatientStatus == PatientStatusEnum.Discharge)
                {
                    throw new Exception("Taburcu edilmi�/Faturas� kesilmi� hastan�n seans sonland�rmas�n� geri alamazs�n�z!");
                }
                PostTransition_Completed2Planned();
            }

            if (fromState == PhysiotherapyRequest.States.RequestAcception && toState == PhysiotherapyRequest.States.Planned)
            {
                PostTransition_RequestAcception2Planned();//planlamadan uygulama ad�m�na ge�i�te seans objeleri olu�turuluyor
            }

        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PhysiotherapyOrderDetail).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if ((fromState == PhysiotherapyRequest.States.Completed && toState == PhysiotherapyRequest.States.Cancelled) && (Episode.PatientStatus == PatientStatusEnum.Discharge || Episode.PatientStatus == PatientStatusEnum.PreDischarge))
                throw new Exception("Taburcu edilmi�/Faturas� kesilmi� hastan�n seans sonland�rmas�n� geri alamazs�n�z!");

            if ((fromState == PhysiotherapyRequest.States.Completed && toState == PhysiotherapyRequest.States.Planned) && (Episode.PatientStatus == PatientStatusEnum.Discharge || Episode.PatientStatus == PatientStatusEnum.PreDischarge))
                throw new Exception("Taburcu edilmi�/Faturas� kesilmi� hastan�n seans sonland�rmas�n� geri alamazs�n�z!");

        }

    }
}