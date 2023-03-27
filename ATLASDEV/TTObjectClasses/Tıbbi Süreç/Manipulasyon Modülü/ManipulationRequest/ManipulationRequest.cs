
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
    /// Tıbbi/Cerrahi Uygulama İstek Yapılan Nesnedir 
    /// </summary>
    public  partial class ManipulationRequest : EpisodeActionWithDiagnosis, IWorkListEpisodeAction, IAllocateSpeciality
    {
        public partial class GetManipulationRequestQuery_Class : TTReportNqlObject 
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

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
#region UndoTransition_Completed2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Completed2Cancelled
        }

        protected void PostTransition_Request2Completed()
        {
            // From State : Request   To State : Completed
#region PostTransition_Request2Completed
            SplitWithProcedureObjectOfManipulationProcedures();
#endregion PostTransition_Request2Completed
        }

        protected void PostTransition_Request2Cancelled()
        {
            // From State : Request   To State : Cancelled
#region PostTransition_Request2Cancelled
            Cancel();
#endregion PostTransition_Request2Cancelled
        }

        protected void UndoTransition_Request2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : Cancelled
#region UndoTransition_Request2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Request2Cancelled
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObj = (ITTObject)this;
//            if (theObj.IsNew)
//            {
//                this.ReportNo.GetNextValue();
//            }
        }
          
        public RaporIslemleri.raporGirisDVO GetTakipNoileRaporBilgisiKaydet(ManipulationRequest manReq)
        {
            RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();
            if (manReq.SubEpisode != null && manReq.SubEpisode.SGKSEP != null && !string.IsNullOrEmpty(manReq.SubEpisode.SGKSEP.MedulaTakipNo))
            {

                raporGirisDVO.ilacRapor = null;
                //TODO : MEDULA20140501
                raporGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                raporGirisDVO.isgoremezlikRapor = null;

                RaporIslemleri.tedaviRaporDVO _tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
                _tedaviRaporDVO.tedaviRaporTuru = 4;
                List<RaporIslemleri.tedaviIslemBilgisiDVO> _tedaviIslemBilgisiDVOList = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();

                foreach (ManipulationProcedure item in _ManipulationProcedures)
                {
                    RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();
                    _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
                    _tedaviIslemBilgisiDVO.eswlRaporBilgisi = null;
                    _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
                    _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
                    _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = null;
                    _tedaviIslemBilgisiDVO.hotRaporBilgisi = null;

                    RaporIslemleri.tupBebekRaporBilgisiDVO _tupBebekRaporBilgisiDVO = new RaporIslemleri.tupBebekRaporBilgisiDVO();
                    if (((SurgeryDefinition)item.ProcedureObject).InVitroFertilizationProcess.HasValue)
                    {
                       
                        ButKodu= item.ProcedureObject.Code;
                        _tupBebekRaporBilgisiDVO.butKodu = item.ProcedureObject.Code;
                       
                        if(TestTubeBabyType!=null)
                        {
                            _tupBebekRaporBilgisiDVO.tupBebekRaporTuru =Convert.ToInt32(TestTubeBabyType);
                        }
                        _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = _tupBebekRaporBilgisiDVO;
                        _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);
                    }
                    
                }

                if (_tedaviIslemBilgisiDVOList.Count > 0)
                    _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();

                RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();

                _raporDVO.aciklama = "";
                _raporDVO.baslangicTarihi = manReq.ReportStartDate !=null ? manReq.ReportStartDate.Value.ToString("dd.MM.yyyy"):DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.bitisTarihi = manReq.ReportEndDate !=null ? manReq.ReportEndDate.Value.ToString("dd.MM.yyyy") :DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.durum = "";
                _raporDVO.duzenlemeTuru = "2";
                _raporDVO.klinikTani = "";
                _raporDVO.protokolNo = manReq.Episode.HospitalProtocolNo.ToString();
                _raporDVO.protokolTarihi = manReq.SubEpisode.PatientAdmission.ActionDate != null ? manReq.SubEpisode.PatientAdmission.ActionDate.Value.ToString("dd.MM.yyyy") : "";

                List<RaporIslemleri.taniBilgisiDVO> _taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
                foreach (DiagnosisGrid diagnosis in manReq.Episode.Diagnosis)
                {
                    RaporIslemleri.taniBilgisiDVO _taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
                    _taniBilgisiDVO.taniKodu = diagnosis.DiagnoseCode;
                    _taniBilgisiDVOList.Add(_taniBilgisiDVO);

                }
                if (_taniBilgisiDVOList.Count > 0)
                    _raporDVO.tanilar = _taniBilgisiDVOList.ToArray();

                _raporDVO.turu = "1";
                _raporDVO.takipNo = manReq.SubEpisode.SGKSEP.MedulaTakipNo;


                List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
                RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
                _doktorBilgisiDVO.drAdi = manReq.ProcedureDoctor.Person.Name;
                _doktorBilgisiDVO.drBransKodu = manReq.ProcedureDoctor.GetSpeciality() != null ? manReq.ProcedureDoctor.GetSpeciality().Code : "";
                _doktorBilgisiDVO.drSoyadi = manReq.ProcedureDoctor.Person.Surname;
                _doktorBilgisiDVO.drTescilNo = manReq.ProcedureDoctor.DiplomaRegisterNo;
                _doktorBilgisiDVO.tipi = "2";
                _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
                _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();

                _raporDVO.hakSahibi = null;

                RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
                _raporBilgisiDVO.aVakaTKaza = 3;
                _raporBilgisiDVO.no = ReportNo;
                _raporBilgisiDVO.raporSiraNo = 0;
                _raporBilgisiDVO.raporTakipNo = "";
                _raporBilgisiDVO.raporTesisKodu = SystemParameter.GetSaglikTesisKodu();
                _raporBilgisiDVO.tarih =  manReq.ReportStartDate !=null ? manReq.ReportStartDate.Value.ToString("dd.MM.yyyy"):DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.raporBilgisi = _raporBilgisiDVO;
                _raporDVO.teshisler = null;

                _tedaviRaporDVO.raporDVO = _raporDVO;

                raporGirisDVO.tedaviRapor = _tedaviRaporDVO;


            } return raporGirisDVO;
        }
        
        public ManipulationRequest(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            ActionDate = DateTime.Now;
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = ManipulationRequest.States.Request;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }

        public ManipulationRequest(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable)
            : this(objectContext)
        {
            ActionDate = DateTime.Now;
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = ManipulationRequest.States.Request;
            ProcedureSpeciality = subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
            Episode = subactionProcedureFlowable.Episode;
        }

        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList;
            if (base.OldActionPropertyList() == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            else
                propertyList = base.OldActionPropertyList();
            //-------------------------------------

            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26670", "Önbilgi"), Common.ReturnObjectAsString(PreInformation)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M16886", "İşlem Tarihi"), Common.ReturnObjectAsString(ActionDate)));

            //---------------------------------------
            return propertyList;

        }

        protected override List<List<List<EpisodeAction.OldActionPropertyObject>>> OldActionChildRelationList()
        {
            List<List<List<EpisodeAction.OldActionPropertyObject>>> gridList;
            if (base.OldActionChildRelationList() == null)
                gridList = new List<List<List<EpisodeAction.OldActionPropertyObject>>>();
            else
                gridList = base.OldActionChildRelationList();

            List<List<EpisodeAction.OldActionPropertyObject>> gridFolderContentsRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();

            foreach (ManipulationProcedure subProc in ManipulationProcedures)
            {
                List<EpisodeAction.OldActionPropertyObject> gridFolderContentsRowColumnList = new List<EpisodeAction.OldActionPropertyObject>();
                if (subProc.ProcedureObject != null)
                    gridFolderContentsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22842", "Tarih/Saat"), Common.ReturnObjectAsString(subProc.ActionDate)));
                if (subProc.ProcedureObject != null)
                    gridFolderContentsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M27207", "Yapılan İşlem"), Common.ReturnObjectAsString(subProc.ProcedureObject.Name)));
                gridFolderContentsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M10469", "Açıklama"), Common.ReturnObjectAsString(subProc.Description)));
                gridFolderContentsRowList.Add(gridFolderContentsRowColumnList);
            }
            gridList.Add(gridFolderContentsRowList);
            return gridList;
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.ManipulationRequest;
            }
        }
        protected void SplitWithDepartmentsOfManipulationProcedures()
        {
            int count = 0;
            ArrayList manipulationProceduretmentArray = new ArrayList();
            //ManipulationProceduresa girilen her bir satırdaki ProcedureDepartmentlar bir ArrayListe doldurulur(bir departement yalnız bir kez eklenir)
            foreach (ManipulationProcedure mp in ManipulationProcedures)
            {
                if (manipulationProceduretmentArray.Contains(mp.ProcedureDepartment) == false)
                {
                    manipulationProceduretmentArray.Add(mp.ProcedureDepartment);
                }
            }
            count = manipulationProceduretmentArray.Count;
            // Eğer yalnızca bir tip ProcedureDepartment var ise yeni Maniplationrequest fire edilmesine gerek yok.


            if (count > 0)
            {
                count--;
                //Array liste doldurulan birimlerin her biri için bir Manipulasyon fire edilir.
                for (int k = 0; k <= count; k++)
                {
                    Manipulation manipulation = new Manipulation(this, (TTObjectClasses.ResSection)manipulationProceduretmentArray[k]);
                    foreach (ManipulationProcedure mp in ManipulationProcedures)
                    {
                        if (mp.ProcedureDepartment.ObjectID == ((TTObjectClasses.ResSection)manipulationProceduretmentArray[k]).ObjectID)
                        {
                            // ManipulationProcedure manipulationProcedure = new ManipulationProcedure((ManipulationProcedure)mp);

                            manipulation.ManipulationProcedures.Add(mp);
                            mp.EpisodeAction = manipulation;

                        }
                    }
                }
            }
        }

        protected void SplitWithProcedureObjectOfManipulationProcedures()
        {
            int count = 0;
            Dictionary<string, ManipulationProcedure> manipulationProcedureArray = new Dictionary<string, ManipulationProcedure>();
            //ManipulationProceduresa girilen her bir satırdaki ProcedureObjectlar bir ArrayListe doldurulur(bir ProcedureObject yalnız bir kez eklenir)
            foreach (ManipulationProcedure mp in ManipulationProcedures)
            {
                if (manipulationProcedureArray.ContainsKey(mp.ProcedureObject.ObjectID + "-" + mp.ProcedureDepartment.ObjectID) == false)
                {
                    manipulationProcedureArray.Add(mp.ProcedureObject.ObjectID + "-" + mp.ProcedureDepartment.ObjectID, mp);
                }
            }


            //Array liste doldurulan birimlerin her biri için bir Manipulasyon fire edilir.
            foreach (KeyValuePair<string, ManipulationProcedure> mpKeyPair in manipulationProcedureArray)
            {
                Manipulation manipulation = new Manipulation(this, (TTObjectClasses.ResSection)(mpKeyPair.Value.ProcedureDepartment));
            
                foreach (ManipulationProcedure mp in ManipulationProcedures)
                {
                    if (mp.ProcedureObject.ObjectID + "-" + mp.ProcedureDepartment.ObjectID == mpKeyPair.Key)
                    {
                        manipulation.ManipulationProcedures.Add(mp);
                        mp.EpisodeAction = manipulation;
                    }
                    

                }
                manipulation.CreateManipulationFormBaseObject();
            }

        
            

        }
        protected void SplitAllManipulationProcedures()
        {
            foreach (ManipulationProcedure mp in ManipulationProcedures)
            {
                Manipulation manipulation = new Manipulation(this, (TTObjectClasses.ResSection)mp.ProcedureDepartment);
                manipulation.ManipulationProcedures.Add(mp);
                mp.EpisodeAction = manipulation;
            }
        }
        public override SubActionProcedure SetSubactionProcedureOfEpisodeAction(ProcedureDefinition procedureDefinition, ResSection MasterResourceForSubactionProcedureFlowable)
        {
            Manipulation m = new Manipulation(this, MasterResourceForSubactionProcedureFlowable);
            ManipulationProcedure mp = m.SetSubactionProcedureOfEpisodeAction(procedureDefinition, MasterResourceForSubactionProcedureFlowable) as ManipulationProcedure;
            if (mp != null)
                mp.ProcedureDepartment = MasterResourceForSubactionProcedureFlowable;
            return mp;
        }
       
        public override void Cancel()
        {
            foreach ( ManipulationProcedure  mp in ManipulationProcedures)
            {
                if (mp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    throw new Exception(SystemMessage.GetMessage(2728));
                }
            }
            base.Cancel();
        }
        
        
         public override void CompleteMySubActionProcedures()
        {
           // Manipulation Procedureler İstek Yapıldığı anda (ManipulationRequest Objecsi tarafından)  otomatik olarak tamamlamamalı.O yüzden base method kullanılmıyor 
        }


        public override void SetMySubActionProceduresPerformedDate()
        {
            // Manipulation Procedureler İstek Yapıldığı anda (ManipulationRequest Objecsi tarafından) performeddateleri set edilmemeli .O yüzden base method kullanılmıyor 
        }

        public override bool SetMyProcedureDoctorToMySubactionProcedure()
        {
            return false;
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ManipulationRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ManipulationRequest.States.Completed && toState == ManipulationRequest.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == ManipulationRequest.States.Request && toState == ManipulationRequest.States.Completed)
                PostTransition_Request2Completed();
            else if (fromState == ManipulationRequest.States.Request && toState == ManipulationRequest.States.Cancelled)
                PostTransition_Request2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ManipulationRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ManipulationRequest.States.Completed && toState == ManipulationRequest.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == ManipulationRequest.States.Request && toState == ManipulationRequest.States.Cancelled)
                UndoTransition_Request2Cancelled(transDef);
        }

    }
}