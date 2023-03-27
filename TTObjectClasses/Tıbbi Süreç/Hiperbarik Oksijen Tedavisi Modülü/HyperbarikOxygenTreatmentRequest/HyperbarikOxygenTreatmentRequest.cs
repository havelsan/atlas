
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
    /// Hiperbarik Oksijen Tedavisi İstek
    /// </summary>
    public  partial class HyperbarikOxygenTreatmentRequest : EpisodeActionWithDiagnosis, IReasonOfReject, IWorkListEpisodeAction, IAllocateSpeciality, ICreateSubEpisode, IDiagnosisOzelDurum
    {
        public partial class HOTReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class HyperReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetHOTRequestQuery_Class : TTReportNqlObject 
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

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
#endregion PostUpdate
        }

        protected void PreTransition_Request2Completed()
        {
            // From State : Request   To State : Completed
#region PreTransition_Request2Completed
            


            if (HyperbaricOxygenTreatmentOrders.Count == 0)
            {
                throw new Exception(SystemMessage.GetMessage(632));
            }

            if (ProcedureDoctor == null)
                throw new Exception(SystemMessage.GetMessage(633));

           


#endregion PreTransition_Request2Completed
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
                return ActionTypeEnum.HyperbarikOxygenTreatmentRequest;
            }
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObj = (ITTObject)this;
//            if (theObj.IsNew)
//            {
//                this.ReportNo.GetNextValue();
//            }
        }
        
        public override List<int> AllowedMedulaTedaviTipi()
        {
            List<int> typeList = new List<int>();
            typeList.Add(7); //'Hiperbarik Oksijen Tedavisi' Tedavi Türünde
            return typeList;
        }

        public override void Cancel()
        {

            foreach (HyperbaricOxygenTreatmentOrder hyperbaricOrder in HyperbaricOxygenTreatmentOrders)
            {
                if (hyperbaricOrder.CurrentStateDef.Status != StateStatusEnum.Cancelled && hyperbaricOrder.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                {
                    throw new Exception(SystemMessage.GetMessage(634));
                }
            }
            base.Cancel();
        }

        public override SubEpisodeStatusEnum GetSubEpisodePatientStatus()
        {
                return SubEpisodeStatusEnum.Daily;
        }


        //public RaporIslemleri.raporGirisDVO GetTakipNoileRaporBilgisiKaydet(HyperbarikOxygenTreatmentRequest hotReq)
        //{
        //    RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();
        //    if ( hotReq.SubEpisode!=null && hotReq.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(hotReq.SubEpisode.SGKSEP.MedulaTakipNo))
        //    {

        //        raporGirisDVO.ilacRapor = null;
        //TODO : MEDULA20140501
        //        raporGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
        //        raporGirisDVO.isgoremezlikRapor = null;

        //        RaporIslemleri.tedaviRaporDVO _tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
        //        _tedaviRaporDVO.tedaviRaporTuru = 2;
        //        List<RaporIslemleri.tedaviIslemBilgisiDVO> _tedaviIslemBilgisiDVOList = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();

        //        foreach (HyperbaricOxygenTreatmentOrder item in _HyperbaricOxygenTreatmentOrders)
        //        {
        //            RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();
        //            _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
        //            _tedaviIslemBilgisiDVO.eswlRaporBilgisi = null;
        //            _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
        //            _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
        //            _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = null;
        //            _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = null;

        //            RaporIslemleri.HOTRaporBilgisiDVO _hOTRaporBilgisiDVO = new RaporIslemleri.HOTRaporBilgisiDVO();
        //            _hOTRaporBilgisiDVO.tedaviSuresi = item.Duration != null ? Convert.ToInt32(item.Duration.Value) : 0;
        //            _hOTRaporBilgisiDVO.seansGun = item.TreatmentPeriod!= null ? Convert.ToInt32(item.TreatmentPeriod.Value) : 0;
        //            _hOTRaporBilgisiDVO.seansSayi = item.Amount != null ? Convert.ToInt32(item.Amount.Value) : 0;
        //            _tedaviIslemBilgisiDVO.hotRaporBilgisi = _hOTRaporBilgisiDVO;
        //            _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);
        //        }

        //        if (_tedaviIslemBilgisiDVOList.Count > 0)
        //            _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();

        //        RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();

        //        _raporDVO.aciklama = "";
        //        _raporDVO.baslangicTarihi = hotReq.ReportStartDate !=null ? hotReq.ReportStartDate.Value.ToString("dd.MM.yyyy"):DateTime.Now.ToString("dd.MM.yyyy");
        //        _raporDVO.bitisTarihi = hotReq.ReportEndDate !=null ? hotReq.ReportEndDate.Value.ToString("dd.MM.yyyy") :DateTime.Now.ToString("dd.MM.yyyy");
        //        _raporDVO.durum = "";
        //        _raporDVO.duzenlemeTuru = "1";
        //        _raporDVO.klinikTani = "";
        //        _raporDVO.protokolNo = hotReq.Episode.HospitalProtocolNo.ToString();
        //        _raporDVO.protokolTarihi = hotReq.SubEpisode.PatientAdmission.ActionDate != null ? hotReq.SubEpisode.PatientAdmission.ActionDate.Value.ToString("dd.MM.yyyy") : "";

        //        List<RaporIslemleri.taniBilgisiDVO> _taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
        //        foreach (DiagnosisGrid diagnosis in hotReq.Episode.Diagnosis)
        //        {
        //            RaporIslemleri.taniBilgisiDVO _taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
        //            _taniBilgisiDVO.taniKodu = diagnosis.DiagnoseCode;
        //            _taniBilgisiDVOList.Add(_taniBilgisiDVO);

        //        }
        //        if (_taniBilgisiDVOList.Count > 0)
        //            _raporDVO.tanilar = _taniBilgisiDVOList.ToArray();

        //        _raporDVO.turu = "1";
        //        _raporDVO.takipNo = hotReq.SubEpisode.SGKSEP.MedulaTakipNo;


        //        List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
        //        RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
        //        _doktorBilgisiDVO.drAdi = hotReq.ProcedureDoctor.Person.Name;
        //        _doktorBilgisiDVO.drBransKodu = hotReq.ProcedureDoctor.GetSpeciality() != null ? hotReq.ProcedureDoctor.GetSpeciality().Code : "";
        //        _doktorBilgisiDVO.drSoyadi = hotReq.ProcedureDoctor.Person.Surname;
        //        _doktorBilgisiDVO.drTescilNo = hotReq.ProcedureDoctor.DiplomaRegisterNo;
        //        _doktorBilgisiDVO.tipi = "2";
        //        _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
        //        _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();

        //        _raporDVO.hakSahibi = null;

        //        RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
        //        _raporBilgisiDVO.AVakaTKaza = 3;
        //        //_raporBilgisiDVO.no = this.ReportNo.Value.ToString();
        //        _raporBilgisiDVO.raporSiraNo = 0;
        //        _raporBilgisiDVO.raporTakipNo = "";
        //        _raporBilgisiDVO.raporTesisKodu = SystemParameter.GetSaglikTesisKodu();
        //        _raporBilgisiDVO.tarih =  hotReq.ReportStartDate !=null ? hotReq.ReportStartDate.Value.ToString("dd.MM.yyyy"):DateTime.Now.ToString("dd.MM.yyyy");
        //        _raporDVO.raporBilgisi = _raporBilgisiDVO;
        //        _raporDVO.teshisler = null;

        //        _tedaviRaporDVO.raporDVO = _raporDVO;

        //        raporGirisDVO.tedaviRapor = _tedaviRaporDVO;


        //    } return raporGirisDVO;
        //}

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HyperbarikOxygenTreatmentRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HyperbarikOxygenTreatmentRequest.States.Request && toState == HyperbarikOxygenTreatmentRequest.States.Completed)
                PreTransition_Request2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HyperbarikOxygenTreatmentRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HyperbarikOxygenTreatmentRequest.States.Completed && toState == HyperbarikOxygenTreatmentRequest.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

    }
}