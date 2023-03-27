
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
    /// Taş Kırma
    /// </summary>
    public  partial class StoneBreakUpRequest : EpisodeActionWithDiagnosis, IAppointmentDef, IWorkListEpisodeAction
    {
        public partial class StoneBreakUpReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetStoneBreakUpQuery_Class : TTReportNqlObject 
        {
        }

        protected void UndoTransition_Appointment2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Appointment   To State : Procedure
#region UndoTransition_Appointment2Procedure
            NoBackStateBack();
#endregion UndoTransition_Appointment2Procedure
        }

        protected void PostTransition_Appointment2Cancelled()
        {
            // From State : Appointment   To State : Cancelled
#region PostTransition_Appointment2Cancelled
            Cancel();
#endregion PostTransition_Appointment2Cancelled
        }

        protected void UndoTransition_Appointment2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Appointment   To State : Cancelled
#region UndoTransition_Appointment2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Appointment2Cancelled
        }

        protected void PostTransition_ResultedUnsuccessfully2Cancelled()
        {
            // From State : ResultedUnsuccessfully   To State : Cancelled
#region PostTransition_ResultedUnsuccessfully2Cancelled
            Cancel();
#endregion PostTransition_ResultedUnsuccessfully2Cancelled
        }

        protected void UndoTransition_ResultedUnsuccessfully2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ResultedUnsuccessfully   To State : Cancelled
#region UndoTransition_ResultedUnsuccessfully2Cancelled
            NoBackStateBack();
#endregion UndoTransition_ResultedUnsuccessfully2Cancelled
        }

        protected void PostTransition_ResultedSuccessfully2Cancelled()
        {
            // From State : ResultedSuccessfully   To State : Cancelled
#region PostTransition_ResultedSuccessfully2Cancelled
            Cancel();
#endregion PostTransition_ResultedSuccessfully2Cancelled
        }

        protected void UndoTransition_ResultedSuccessfully2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ResultedSuccessfully   To State : Cancelled
#region UndoTransition_ResultedSuccessfully2Cancelled
            NoBackStateBack();
#endregion UndoTransition_ResultedSuccessfully2Cancelled
        }

        protected void UndoTransition_RequestAcception2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Appointment
#region UndoTransition_RequestAcception2Appointment
            NoBackStateBack();
#endregion UndoTransition_RequestAcception2Appointment
        }

        protected void PostTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
#region PostTransition_RequestAcception2Cancelled
            Cancel();
#endregion PostTransition_RequestAcception2Cancelled
        }

        protected void UndoTransition_RequestAcception2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Cancelled
#region UndoTransition_RequestAcception2Cancelled
            NoBackStateBack();
#endregion UndoTransition_RequestAcception2Cancelled
        }

        protected void PreTransition_RequestAcception2Procedure()
        {
            // From State : RequestAcception   To State : Procedure
            #region PreTransition_RequestAcception2Procedure

            //            
            //            
            //            
            //            if(!string.IsNullOrEmpty(this.MedulaRaporTakipNo))
            //            {
            //                TTObjectContext context = new TTObjectContext(false);
            //                MedulaReportResult medulaReportResult = new MedulaReportResult(context);
            //                medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
            //                medulaReportResult.ReportNumber =  "";
            //                medulaReportResult.ReportRowNumber = 0;
            //                medulaReportResult.ReportChasingNo = this.MedulaRaporTakipNo;
            //                medulaReportResult.SendReportDate = DateTime.Now;
            //                medulaReportResult.ResultCode="0";
            //                medulaReportResult.ResultExplanation = "Rapor Takip Numarası Dış XXXXXX Tarafından Verilmiştir!!!";
            //                 medulaReportResult.StoneBreakUpRequest = this;
            //                context.Save();
            //            }
            //            else
            //            {
            //                if(this.Episode != null && this.Episode.SubEpisodes[0] !=null && this.Episode.SubEpisodes[0].SGKSEP!=null && this.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo!=null)
            //                {
            //                    
            //                    try
            //                    {
            //                        RaporIslemleri.raporCevapDVO response = RaporIslemleri.WebMethods.takipNoileRaporBilgisiKaydetSync(Sites.SiteLocalHost, GetTakipNoileRaporBilgisiKaydet(this));
            //                        if (response != null)
            //                        {
            //                            if (response.sonucKodu != null)
            //                            {
            //                                if (response.sonucKodu.Equals(0))
            //                                {
            //                                    TTObjectContext context = new TTObjectContext(false);
            //                                    MedulaReportResult medulaReportResult = new MedulaReportResult(context);
            //                                    medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
            //                                    medulaReportResult.ReportNumber=this.ReportNo.ToString();
            //                                    medulaReportResult.ReportRowNumber=response.tedaviRapor.raporDVO.raporBilgisi.raporSiraNo;
            //                                    medulaReportResult.ReportChasingNo= response.raporTakipNo!=null?response.raporTakipNo.ToString():"";
            //                                    medulaReportResult.SendReportDate= Convert.ToDateTime(response.tedaviRapor.raporDVO.raporBilgisi.tarih);
            //                                    medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                                    medulaReportResult.StoneBreakUpRequest = this;
            //                                    context.Save();
            //                                }
            //                                else
            //                                {
            //                                    TTObjectContext context = new TTObjectContext(false);
            //                                    MedulaReportResult medulaReportResult = new MedulaReportResult(context);
            //                                    medulaReportResult.CurrentStateDefID = MedulaReportResult.States.New;
            //                                    medulaReportResult.ResultCode = response.sonucKodu.ToString();
            //                                    medulaReportResult.ResultExplanation = response.sonucAciklamasi;
            //                                    medulaReportResult.ReportNumber="0";
            //                                    medulaReportResult.StoneBreakUpRequest = this ;
            //                                    medulaReportResult.SendReportDate= DateTime.Now;
            //                                    context.Save();
            //                                }
            //                            }
            //                            else
            //                            {
            //                                if (!string.IsNullOrEmpty(response.sonucAciklamasi))
            //                                {
            //                                    throw new TTException("Rapor Servisinden Gelen Sonuç Mesajı : " + response.sonucAciklamasi);
            //                                }
            //
            //                            }
            //                        }
            //                    }
            //                    catch (Exception)
            //                    {
            //
            //                        throw;
            //                    }
            //                }
            //            }

            #endregion PreTransition_RequestAcception2Procedure
        }

        protected void UndoTransition_RequestAcception2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Procedure
#region UndoTransition_RequestAcception2Procedure
            NoBackIfHasProcedureAfterProcedureDate();
#endregion UndoTransition_RequestAcception2Procedure
        }

        protected void PostTransition_Procedure2Cancelled()
        {
            // From State : Procedure   To State : Cancelled
#region PostTransition_Procedure2Cancelled
            Cancel();
#endregion PostTransition_Procedure2Cancelled
        }

        protected void UndoTransition_Procedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : Cancelled
#region UndoTransition_Procedure2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Procedure2Cancelled
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

        protected void PostTransition_Request2RequestAcception()
        {
            // From State : Request   To State : RequestAcception
#region PostTransition_Request2RequestAcception
            
            NotAllowMoreThanOneProcedure();
#endregion PostTransition_Request2RequestAcception
        }

        protected void PreTransition_ResultEntry2ResultedUnsuccessfully()
        {
            // From State : ResultEntry   To State : ResultedUnsuccessfully
#region PreTransition_ResultEntry2ResultedUnsuccessfully
            
            
            //if (this.ReportNo.Value==null)
            //    this.ReportNo.GetNextValue(Common.RecTime().Year);
#endregion PreTransition_ResultEntry2ResultedUnsuccessfully
        }

        protected void PreTransition_ResultEntry2ResultedSuccessfully()
        {
            // From State : ResultEntry   To State : ResultedSuccessfully
#region PreTransition_ResultEntry2ResultedSuccessfully
            
            
            //if (this.ReportNo.Value==null)
            //    this.ReportNo.GetNextValue(Common.RecTime().Year);
#endregion PreTransition_ResultEntry2ResultedSuccessfully
        }

        protected void PostTransition_ResultEntry2ResultedSuccessfully()
        {
            // From State : ResultEntry   To State : ResultedSuccessfully
#region PostTransition_ResultEntry2ResultedSuccessfully
            SetMySubActionProceduresPerformedDate();
    

#endregion PostTransition_ResultEntry2ResultedSuccessfully
        }

        protected void PostTransition_ResultEntry2Cancelled()
        {
            // From State : ResultEntry   To State : Cancelled
#region PostTransition_ResultEntry2Cancelled
            Cancel();
#endregion PostTransition_ResultEntry2Cancelled
        }

        protected void UndoTransition_ResultEntry2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ResultEntry   To State : Cancelled
#region UndoTransition_ResultEntry2Cancelled
            NoBackStateBack();
#endregion UndoTransition_ResultEntry2Cancelled
        }

#region Methods
        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> retval = new List<AppointmentCarrier>();

                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.StoneBreakUpRequest);
                if (appDefList.Count > 0)
                {
                    appDef = (AppointmentDefinition)appDefList[0];
                    foreach (AppointmentCarrier appCarrier in appDef.AppointmentCarriers)
                    {
                        retval.Add(appCarrier);
                    }
                }

                if (retval.Count == 0)
                {
                    AppointmentCarrier carrier = new AppointmentCarrier(context);
                    carrier.MasterResource = "ResClinic";
                    carrier.SubResource = "ResEquipment";
                    carrier.RelationParentName = "Clinic";
                    carrier.AppointmentDefinition = appDef;
                    retval.Add(carrier);
                }
                ClearAppointmentCarrierDynamicFields(retval);
                foreach (AppointmentCarrier appointmentCarrier in retval)
                {
                    appointmentCarrier.MasterResourceFilter = " OBJECTID = '" + MasterResource.ObjectID.ToString() + "'";
                }
                return retval;
            }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion

        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.StoneBreakUpRequest;
            }
        }


        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);
            //            if (((ITTObject)this).IsNew == true)
            //            {
            //                bool bFound = false;
            //                foreach(HealthCommitteeWithThreeSpecialist threeSpecialistAction in episode.HealthCommitteeWithThreeSpecialists)
            //                {
            //                    if(threeSpecialistAction.CurrentStateDef.Status != StateStatusEnum.Cancelled)
            //                    {
            //                        bFound = true;
            //                        break;
            //                    }
            //                }
            //                if(!bFound)
            //                    throw new Exception ("Bu vakada tamamlanmış 3 İmzalı Sağlık Kurulu raporu yoktur.Taşkırma isteği yapılamaz..." );
            //            }
        }

        protected void NotAllowMoreThanOneProcedure()
        {
            if(StoneBreakUpProcedures.Count > 1)
                throw new Exception(SystemMessage.GetMessage(970));
        }
        
        
        
        public void Cancel()
        {
            foreach(StoneBreakUpProcedure stoneBreakUpProcedure in StoneBreakUpProcedures)
            {
                if(stoneBreakUpProcedure.ProcedureDate!=null)
                {
                    if (stoneBreakUpProcedure.HasProcedureAfterProcedureDate())
                    {
                        throw new Exception(SystemMessage.GetMessage(971));
                    }
                }
            }
            base.Cancel();
        }

        public void NoBackIfHasProcedureAfterProcedureDate(){
            foreach(StoneBreakUpProcedure stoneBreakUpProcedure in StoneBreakUpProcedures)
            {
                if(stoneBreakUpProcedure.ProcedureDate!=null)
                {
                    if (stoneBreakUpProcedure.HasProcedureAfterProcedureDate())
                    {
                        throw new Exception(SystemMessage.GetMessage(972));
                    }
                    else{
                        stoneBreakUpProcedure.ProcedureDate=null;
                    }
                    
                }
            }
        }
        
        
       
        
        public override List<int> AllowedMedulaTedaviTipi()
        {
            List<int> typeList=new List<int>();
            typeList.Add(8);//ESWL
            return typeList;
        }
        
        
        //        protected override List<OldActionPropertyObject> OldActionPropertyList()
        //        {
        //            List<OldActionPropertyObject> propertyList = base.OldActionPropertyList();
        //            if(propertyList ==null)
        //                propertyList = new List<OldActionPropertyObject>();
//
        //            propertyList.Add(new OldActionPropertyObject("Protokol No",Common.ReturnObjectAsString(this.ProtocolNo)));
        //            propertyList.Add(new OldActionPropertyObject("Prosedür Tarihi",Common.ReturnObjectAsString(ProcessDate)));
        //            propertyList.Add(new OldActionPropertyObject("Rapor No",Common.ReturnObjectAsString(ReportNo)));
        //            propertyList.Add(new OldActionPropertyObject("Rapor Tarihi",Common.ReturnObjectAsString(ReportDate)));
        //            propertyList.Add(new OldActionPropertyObject("Rapor ",Common.ReturnObjectAsString(Report)));
        //            if(ProcedureDoctor!=null)
        //                propertyList.Add(new OldActionPropertyObject("İşlemi Yapan Hekim",Common.ReturnObjectAsString(ProcedureDoctor.Name)));
        //            propertyList.Add(new OldActionPropertyObject("Anamnez ve Bulgular ",Common.ReturnObjectAsString(Symptom)));
        //            propertyList.Add(new OldActionPropertyObject("Açıklamalar",Common.ReturnObjectAsString(Note)));
        //            return propertyList;
        //        }
        
        
        //        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        //        {
        //            List<List<List<OldActionPropertyObject>>> gridList;
        //            if(base.OldActionChildRelationList()==null)
        //                gridList=new List<List<List<OldActionPropertyObject>>>();
        //            else
        //                gridList=base.OldActionChildRelationList();
        //            // Taşkırma İşlemleri
        //            List<List<OldActionPropertyObject>> gridProceduresRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(StoneBreakUpProcedure Procedure in StoneBreakUpProcedures)
        //            {
        //                List<OldActionPropertyObject> gridProceduresRowColumnList=new List<OldActionPropertyObject>();
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(Procedure.ActionDate)));
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Taş Kırma İşlemi",Common.ReturnObjectAsString(Procedure.ProcedureObject.Name)));
        //                if(Procedure.PartOfStone!=null)
        //                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("Lokasyon",Common.ReturnObjectAsString(Procedure.PartOfStone.PartOfStone)));
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Taş Boyutu(mm)",Common.ReturnObjectAsString(Procedure.StoneDimension)));
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Kaçıncı Seans",Common.ReturnObjectAsString(Procedure.NumberOfProcedure)));
        //                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Taraf",Common.ReturnObjectAsString(Procedure.ZoneOfStone)));
//
        //                gridProceduresRowList.Add(gridProceduresRowColumnList);
        //            }
        //            gridList.Add(gridProceduresRowList);
//
        //            gridList.Add(this.OldActionSecDiagnosisList());
//
        //            return gridList;
        //        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObj = (ITTObject)this;
            if(theObj.IsNew)
            {
                //  this.ReportNo.GetNextValue();
            }
        }

        public RaporIslemleri.raporGirisDVO GetTakipNoileRaporBilgisiKaydet(StoneBreakUpRequest sbuReq)
        {
            RaporIslemleri.raporGirisDVO raporGirisDVO = new RaporIslemleri.raporGirisDVO();
            if(Episode != null && Episode.SubEpisodes[0] !=null && Episode.SubEpisodes[0].SGKSEP!=null && Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo != null)
            {
                
                raporGirisDVO.ilacRapor = null;
                //TODO : MEDULA20140501
                raporGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                raporGirisDVO.isgoremezlikRapor = null;

                RaporIslemleri.tedaviRaporDVO _tedaviRaporDVO = new RaporIslemleri.tedaviRaporDVO();
                _tedaviRaporDVO.tedaviRaporTuru=6;
                List<RaporIslemleri.tedaviIslemBilgisiDVO> _tedaviIslemBilgisiDVOList = new List<RaporIslemleri.tedaviIslemBilgisiDVO>();
                foreach (StoneBreakUpProcedure item in _StoneBreakUpProcedures)
                {
                    RaporIslemleri.tedaviIslemBilgisiDVO _tedaviIslemBilgisiDVO = new RaporIslemleri.tedaviIslemBilgisiDVO();

                    RaporIslemleri.eswlRaporBilgisiDVO _eSWLRaporBilgisiDVO = new RaporIslemleri.eswlRaporBilgisiDVO();
                    
                    if(item.ZoneOfStone!=null)
                    {
                        switch ((int)item.ZoneOfStone.Value)
                        {
                            case 3:
                            case 4:
                            case 5:
                                case 8: _eSWLRaporBilgisiDVO.bobrekBilgisi = 1;
                                break;
                            case 2:
                            case 6:
                            case 7:
                                case 9: _eSWLRaporBilgisiDVO.bobrekBilgisi = 2;
                                break;
                            default:
                                break;
                        }
                    }
                    _eSWLRaporBilgisiDVO.butKodu = item.ProcedureObject.Code;
                    _eSWLRaporBilgisiDVO.eswlRaporuSeansSayisi = item.NumberOfProcedure!=null ?item.NumberOfProcedure.Value:0;//Rapora Ait Seans Sayısı
                    _eSWLRaporBilgisiDVO.eswlRaporuTasSayisi=item.NumberOfStone!=null ?item.NumberOfStone.Value:0;//Rapora ait Ta? Sayısı
                    
                    List<RaporIslemleri.eswlTasBilgisiDVO> _eSWLTasBilgisiDVOList = new List<RaporIslemleri.eswlTasBilgisiDVO>();
                    RaporIslemleri.eswlTasBilgisiDVO _eSWLTasBilgisiDVO = new RaporIslemleri.eswlTasBilgisiDVO();
                    _eSWLTasBilgisiDVO.tasBoyutu = item.StoneDimension;
                    if(item.PartOfStone.PartOfStone.Contains("brek"))
                    {
                        _eSWLTasBilgisiDVO.tasLokalizasyonKodu =4;
                    }
                    if(item.PartOfStone.PartOfStone.Contains("esane"))
                    {
                        _eSWLTasBilgisiDVO.tasLokalizasyonKodu =2;
                    }
                    
                    _eSWLTasBilgisiDVOList.Add(_eSWLTasBilgisiDVO);
                    
                    _eSWLRaporBilgisiDVO.eswlRaporuTasBilgileri = _eSWLTasBilgisiDVOList.ToArray() ;
                    _tedaviIslemBilgisiDVO.eswlRaporBilgisi = _eSWLRaporBilgisiDVO;

                    
                    _tedaviIslemBilgisiDVO.diyalizRaporBilgisi = null;
                    _tedaviIslemBilgisiDVO.eswtRaporBilgisi = null;
                    _tedaviIslemBilgisiDVO.evHemodiyaliziRaporBilgisi = null;
                    _tedaviIslemBilgisiDVO.hotRaporBilgisi = null;
                    _tedaviIslemBilgisiDVO.tupBebekRaporBilgisi = null;
                    _tedaviIslemBilgisiDVO.ftrRaporBilgisi = null;
                    
                    _tedaviIslemBilgisiDVOList.Add(_tedaviIslemBilgisiDVO);
                }

                _tedaviRaporDVO.islemler = _tedaviIslemBilgisiDVOList.ToArray();

                
                
                RaporIslemleri.raporDVO _raporDVO = new RaporIslemleri.raporDVO();

                _raporDVO.aciklama = "";
                _raporDVO.baslangicTarihi = sbuReq.ReportStartDate!=null? sbuReq.ReportStartDate.Value.ToString("dd.MM.yyyy"):DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.bitisTarihi = sbuReq.ReportEndDate!=null?sbuReq.ReportEndDate.Value.ToString("dd.MM.yyyy"):DateTime.Now.ToString("dd.MM.yyyy");
                _raporDVO.durum = "";
                _raporDVO.duzenlemeTuru = "2";
                _raporDVO.klinikTani="";
                _raporDVO.protokolNo = sbuReq.Episode.HospitalProtocolNo.ToString();
                _raporDVO.protokolTarihi = sbuReq.SubEpisode.PatientAdmission.ActionDate != null ? sbuReq.SubEpisode.PatientAdmission.ActionDate.Value.ToString("dd.MM.yyyy") : "";
                
                List<RaporIslemleri.taniBilgisiDVO> _taniBilgisiDVOList = new List<RaporIslemleri.taniBilgisiDVO>();
                foreach (DiagnosisGrid diagnosis in sbuReq.Episode.Diagnosis)
                {
                    RaporIslemleri.taniBilgisiDVO _taniBilgisiDVO = new RaporIslemleri.taniBilgisiDVO();
                    _taniBilgisiDVO.taniKodu = diagnosis.DiagnoseCode;
                    _taniBilgisiDVOList.Add(_taniBilgisiDVO);

                }
                if(_taniBilgisiDVOList.Count>0)
                    _raporDVO.tanilar = _taniBilgisiDVOList.ToArray();
                
                _raporDVO.turu = "1";
                _raporDVO.takipNo = sbuReq.Episode.SubEpisodes[0].SGKSEP.MedulaTakipNo;

                
                List<RaporIslemleri.doktorBilgisiDVO> _doktorBilgisiDVOList = new List<RaporIslemleri.doktorBilgisiDVO>();
                RaporIslemleri.doktorBilgisiDVO _doktorBilgisiDVO = new RaporIslemleri.doktorBilgisiDVO();
                if(sbuReq.ProcedureDoctor==null || sbuReq.ProcedureDoctor.Person==null)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M25519", "Doktor Bilgisi Boş Olamaz"));
                }
                _doktorBilgisiDVO.drAdi = sbuReq.ProcedureDoctor.Person.Name;
                _doktorBilgisiDVO.drBransKodu = sbuReq.ProcedureDoctor.GetSpeciality() != null ? sbuReq.ProcedureDoctor.GetSpeciality().Code : "";
                _doktorBilgisiDVO.drSoyadi = sbuReq.ProcedureDoctor.Person.Surname;
                _doktorBilgisiDVO.drTescilNo = sbuReq.ProcedureDoctor.DiplomaRegisterNo;
                _doktorBilgisiDVO.tipi = "2";
                _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);
                _raporDVO.doktorlar = _doktorBilgisiDVOList.ToArray();
                
                _raporDVO.hakSahibi = null;
                
                RaporIslemleri.raporBilgisiDVO _raporBilgisiDVO = new RaporIslemleri.raporBilgisiDVO();
                _raporBilgisiDVO.aVakaTKaza = 3;
                //_raporBilgisiDVO.no =  this.ReportNo.Value.ToString();
                _raporBilgisiDVO.raporSiraNo = 0;
                _raporBilgisiDVO.raporTakipNo = "";
                _raporBilgisiDVO.raporTesisKodu = SystemParameter.GetSaglikTesisKodu();
                _raporBilgisiDVO.tarih = sbuReq.ReportStartDate!=null? sbuReq.ReportStartDate.Value.ToString("dd.MM.yyyy"):DateTime.Now.ToString("dd.MM.yyyy");
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
            if (transDef.ObjectDef.CodeName != typeof(StoneBreakUpRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StoneBreakUpRequest.States.RequestAcception && toState == StoneBreakUpRequest.States.Procedure)
                PreTransition_RequestAcception2Procedure();
            else if (fromState == StoneBreakUpRequest.States.ResultEntry && toState == StoneBreakUpRequest.States.ResultedUnsuccessfully)
                PreTransition_ResultEntry2ResultedUnsuccessfully();
            else if (fromState == StoneBreakUpRequest.States.ResultEntry && toState == StoneBreakUpRequest.States.ResultedSuccessfully)
                PreTransition_ResultEntry2ResultedSuccessfully();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StoneBreakUpRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StoneBreakUpRequest.States.Appointment && toState == StoneBreakUpRequest.States.Cancelled)
                PostTransition_Appointment2Cancelled();
            else if (fromState == StoneBreakUpRequest.States.ResultedUnsuccessfully && toState == StoneBreakUpRequest.States.Cancelled)
                PostTransition_ResultedUnsuccessfully2Cancelled();
            else if (fromState == StoneBreakUpRequest.States.ResultedSuccessfully && toState == StoneBreakUpRequest.States.Cancelled)
                PostTransition_ResultedSuccessfully2Cancelled();
            else if (fromState == StoneBreakUpRequest.States.RequestAcception && toState == StoneBreakUpRequest.States.Cancelled)
                PostTransition_RequestAcception2Cancelled();
            else if (fromState == StoneBreakUpRequest.States.Procedure && toState == StoneBreakUpRequest.States.Cancelled)
                PostTransition_Procedure2Cancelled();
            else if (fromState == StoneBreakUpRequest.States.Request && toState == StoneBreakUpRequest.States.Cancelled)
                PostTransition_Request2Cancelled();
            else if (fromState == StoneBreakUpRequest.States.Request && toState == StoneBreakUpRequest.States.RequestAcception)
                PostTransition_Request2RequestAcception();
            else if (fromState == StoneBreakUpRequest.States.ResultEntry && toState == StoneBreakUpRequest.States.ResultedSuccessfully)
                PostTransition_ResultEntry2ResultedSuccessfully();
            else if (fromState == StoneBreakUpRequest.States.ResultEntry && toState == StoneBreakUpRequest.States.Cancelled)
                PostTransition_ResultEntry2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StoneBreakUpRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StoneBreakUpRequest.States.Appointment && toState == StoneBreakUpRequest.States.Procedure)
                UndoTransition_Appointment2Procedure(transDef);
            else if (fromState == StoneBreakUpRequest.States.Appointment && toState == StoneBreakUpRequest.States.Cancelled)
                UndoTransition_Appointment2Cancelled(transDef);
            else if (fromState == StoneBreakUpRequest.States.ResultedUnsuccessfully && toState == StoneBreakUpRequest.States.Cancelled)
                UndoTransition_ResultedUnsuccessfully2Cancelled(transDef);
            else if (fromState == StoneBreakUpRequest.States.ResultedSuccessfully && toState == StoneBreakUpRequest.States.Cancelled)
                UndoTransition_ResultedSuccessfully2Cancelled(transDef);
            else if (fromState == StoneBreakUpRequest.States.RequestAcception && toState == StoneBreakUpRequest.States.Appointment)
                UndoTransition_RequestAcception2Appointment(transDef);
            else if (fromState == StoneBreakUpRequest.States.RequestAcception && toState == StoneBreakUpRequest.States.Cancelled)
                UndoTransition_RequestAcception2Cancelled(transDef);
            else if (fromState == StoneBreakUpRequest.States.RequestAcception && toState == StoneBreakUpRequest.States.Procedure)
                UndoTransition_RequestAcception2Procedure(transDef);
            else if (fromState == StoneBreakUpRequest.States.Procedure && toState == StoneBreakUpRequest.States.Cancelled)
                UndoTransition_Procedure2Cancelled(transDef);
            else if (fromState == StoneBreakUpRequest.States.Request && toState == StoneBreakUpRequest.States.Cancelled)
                UndoTransition_Request2Cancelled(transDef);
            else if (fromState == StoneBreakUpRequest.States.ResultEntry && toState == StoneBreakUpRequest.States.Cancelled)
                UndoTransition_ResultEntry2Cancelled(transDef);
        }

    }
}