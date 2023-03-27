
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
    /// Diyaliz İstek  İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
    public partial class DialysisRequest : EpisodeActionWithDiagnosis, IReasonOfReject, IWorkListEpisodeAction, IAllocateSpeciality, ICreateSubEpisode, IDiagnosisOzelDurum
    {
        public partial class GetDialysisRequestQuery_Class : TTReportNqlObject
        {
        }

        #region IDiagnosisOzelDurum Members
        public OzelDurum GetOzelDurum()
        {
            return OzelDurum;
        }

        public void SetOzelDurum(OzelDurum value)
        {
            OzelDurum = value;
        }

        public DiagnosisGrid.ChildDiagnosisGridCollection GetDiagnosis()
        {
            return Diagnosis;
        }
        #endregion

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


            if (DialysisOrders.Count == 0)
            {
                throw new Exception(SystemMessage.GetMessage(951));
            }

            if (ProcedureDoctor == null)
                throw new Exception(SystemMessage.GetMessage(633));






            #endregion PreTransition_Request2Completed
        }

        protected void PostTransition_Request2Completed()
        {
            // From State : Request   To State : Completed
            #region PostTransition_Request2Completed


            if (PackageProcedure == null && SubEpisode.IsSGK)
                throw new Exception(TTUtils.CultureService.GetText("M26873", "SGK'lı hastalar için Paket Hizmet alanı boş geçilemez."));

            #endregion PostTransition_Request2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        #region Methods


        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.DialysisRequest;
            }
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObj = (ITTObject)this;
            //if (theObj.IsNew)
            //{
            //    this.ReportNo.GetNextValue();
            //}
        }

        public override List<int> AllowedMedulaTedaviTipi()
        {
            List<int> typeList = new List<int>();
            typeList.Add(1); //'Diyaliz' Tedavi Türünde
            return typeList;
        }
        public override void Cancel()
        {

            foreach (DialysisOrder dialysisOrder in DialysisOrders)
            {
                if (dialysisOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled && dialysisOrder.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                {
                    throw new Exception(SystemMessage.GetMessage(952));
                }
            }
            base.Cancel();
        }

        public override SubEpisodeStatusEnum GetSubEpisodePatientStatus()
        {
                return SubEpisodeStatusEnum.Daily;
        }

        public RaporIslemleri.raporGirisDVO GetTakipNoileRaporBilgisiKaydet(DialysisRequest dailReq)
        {
            RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();

            if (dailReq.SubEpisode != null && dailReq.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(dailReq.SubEpisode.SGKSEP.MedulaTakipNo))
            {
                raporGirisDVO.ilacRapor = null;
                //TODO : MEDULA20140501
                raporGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                raporGirisDVO.isgoremezlikRapor = null;

                RaporIslemleri.tedaviRaporDVO _tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
                List<RaporIslemleri.tedaviIslemBilgisiDVO> _tedaviIslemBilgisiDVOList = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();


                if (HomeDialysis.HasValue)
                {
                    if (HomeDialysis.Value)
                    {
                        _tedaviRaporDVO.tedaviRaporTuru = 8;
                        foreach (DialysisOrder item in _DialysisOrders)
                        {
                            RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();
                            _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
                            _tedaviIslemBilgisiDVO.eswlRaporBilgisi = null;
                            _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
                            _tedaviIslemBilgisiDVO.hotRaporBilgisi = null;
                            _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = null;
                            _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = null;

                            RaporIslemleri.evHemodiyaliziRaporBilgisiDVO _evHemodiyaliziRaporBilgisiDVO = new RaporIslemleri.evHemodiyaliziRaporBilgisiDVO();
                            _evHemodiyaliziRaporBilgisiDVO.butKodu = item.ProcedureObject != null ? item.ProcedureObject.Code : "";
                            _evHemodiyaliziRaporBilgisiDVO.seansGun = item.Duration != null ? Convert.ToInt32(item.Duration.Value) : 0;
                            _evHemodiyaliziRaporBilgisiDVO.seansSayi = item.Amount != null ? Convert.ToInt32(item.Amount.Value) : 0;

                            _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = _evHemodiyaliziRaporBilgisiDVO;

                            _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);
                        }
                        if (_tedaviIslemBilgisiDVOList.Count > 0)
                            _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();
                    }
                    else
                    {
                        _tedaviRaporDVO.tedaviRaporTuru = 1;
                        foreach (DialysisOrder item in _DialysisOrders)
                        {
                            RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();
                            _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
                            _tedaviIslemBilgisiDVO.eswlRaporBilgisi = null;
                            _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
                            _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
                            _tedaviIslemBilgisiDVO.hotRaporBilgisi = null;
                            _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = null;

                            RaporIslemleri.diyalizRaporBilgisiDVO _diyalizRaporBilgisiDVO = new RaporIslemleri.diyalizRaporBilgisiDVO();
                            _diyalizRaporBilgisiDVO.butKodu = item.ProcedureObject != null ? item.ProcedureObject.Code : "";
                            _diyalizRaporBilgisiDVO.seansGun = item.Duration != null ? Convert.ToInt32(item.Duration.Value) : 0;
                            _diyalizRaporBilgisiDVO.seansSayi = item.Amount != null ? Convert.ToInt32(item.Amount.Value) : 0;
                            _diyalizRaporBilgisiDVO.refakatVarMi = "H";
                            _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = _diyalizRaporBilgisiDVO;

                            _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);
                        }
                        if (_tedaviIslemBilgisiDVOList.Count > 0)
                            _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();
                    }
                }
                else
                {
                    _tedaviRaporDVO.tedaviRaporTuru = 1;
                    foreach (DialysisOrder item in _DialysisOrders)
                    {
                        RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();
                        _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.eswlRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.hotRaporBilgisi = null;
                        _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = null;

                        RaporIslemleri.diyalizRaporBilgisiDVO _diyalizRaporBilgisiDVO = new RaporIslemleri.diyalizRaporBilgisiDVO();
                        _diyalizRaporBilgisiDVO.butKodu = item.ProcedureObject != null ? item.ProcedureObject.Code : "";
                        _diyalizRaporBilgisiDVO.seansGun = item.Duration != null ? Convert.ToInt32(item.Duration.Value) : 0;
                        _diyalizRaporBilgisiDVO.seansSayi = item.Amount != null ? Convert.ToInt32(item.Amount.Value) : 0;
                        _diyalizRaporBilgisiDVO.refakatVarMi = "H";
                        _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = _diyalizRaporBilgisiDVO;

                        _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);
                    }
                    if (_tedaviIslemBilgisiDVOList.Count > 0)
                        _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();

                }





                RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();

                _raporDVO.aciklama = "";
                _raporDVO.baslangicTarihi = dailReq.ReportStartDate != null ? dailReq.ReportStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.bitisTarihi = dailReq.ReportEndDate != null ? dailReq.ReportEndDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.durum = "";
                _raporDVO.duzenlemeTuru = "2";
                _raporDVO.klinikTani = "";
                _raporDVO.protokolNo = dailReq.Episode.HospitalProtocolNo.ToString();
                _raporDVO.protokolTarihi = dailReq.SubEpisode.PatientAdmission.ActionDate != null ? dailReq.SubEpisode.PatientAdmission.ActionDate.Value.ToString("dd.MM.yyyy") : "";

                List<RaporIslemleri.taniBilgisiDVO> _taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
                foreach (DiagnosisGrid diagnosis in dailReq.Episode.Diagnosis)
                {
                    RaporIslemleri.taniBilgisiDVO _taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
                    _taniBilgisiDVO.taniKodu = diagnosis.DiagnoseCode;
                    _taniBilgisiDVOList.Add(_taniBilgisiDVO);

                }
                if (_taniBilgisiDVOList.Count > 0)
                    _raporDVO.tanilar = _taniBilgisiDVOList.ToArray();

                _raporDVO.turu = "1";
                _raporDVO.takipNo = dailReq.SubEpisode.SGKSEP.MedulaTakipNo;


                List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
                RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
                _doktorBilgisiDVO.drAdi = dailReq.ProcedureDoctor.Person.Name;
                _doktorBilgisiDVO.drBransKodu = dailReq.ProcedureDoctor.GetSpeciality() != null ? dailReq.ProcedureDoctor.GetSpeciality().Code : "";
                _doktorBilgisiDVO.drSoyadi = dailReq.ProcedureDoctor.Person.Surname;
                _doktorBilgisiDVO.drTescilNo = dailReq.ProcedureDoctor.DiplomaRegisterNo;
                _doktorBilgisiDVO.tipi = "2";
                _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
                _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();

                _raporDVO.hakSahibi = null;

                RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
                _raporBilgisiDVO.aVakaTKaza = 3;
                // _raporBilgisiDVO.no = this.ReportNo.Value.ToString();
                _raporBilgisiDVO.raporSiraNo = 0;
                _raporBilgisiDVO.raporTakipNo = "";
                _raporBilgisiDVO.raporTesisKodu = SystemParameter.GetSaglikTesisKodu();
                _raporBilgisiDVO.tarih = dailReq.ReportStartDate != null ? dailReq.ReportStartDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.raporBilgisi = _raporBilgisiDVO;
                _raporDVO.teshisler = null;

                _tedaviRaporDVO.raporDVO = _raporDVO;

                raporGirisDVO.tedaviRapor = _tedaviRaporDVO;

            }
            return raporGirisDVO;
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DialysisRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DialysisRequest.States.Request && toState == DialysisRequest.States.Completed)
                PreTransition_Request2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DialysisRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DialysisRequest.States.Request && toState == DialysisRequest.States.Completed)
                PostTransition_Request2Completed();
            else if (fromState == DialysisRequest.States.Completed && toState == DialysisRequest.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

    }
}