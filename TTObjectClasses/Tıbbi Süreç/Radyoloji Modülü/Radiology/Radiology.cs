
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
    /// Radyoloji
    /// </summary>
    public  partial class Radiology : EpisodeActionWithDiagnosis, IAllocateSpeciality, IEpisodeAction
    {
        public partial class RadiologyRequestPatientInfoReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class VEM_RADYOLOJI_ORNEK_Class : TTReportNqlObject 
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
                case "TOOTHNUMBER":
                    {
                        ToothNumberEnum? value = (ToothNumberEnum?)(int?)newValue;
#region TOOTHNUMBER_SetScript
                        if (value.HasValue)
            {
                DentalPosition = Common.SetDentalPosition((int)value);
            }
#endregion TOOTHNUMBER_SetScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            
            if(EpisodeAction.IsFiredByPatientAdmission(this) == true && PreDiagnosis == null)
            {
                PreDiagnosis = SubEpisode.PatientAdmission.AdmissionType + " kabulü sebebiyle";
            }
#endregion PreInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            
            //  Guid NextState = new Guid("e7a2252f-a1a8-47fd-9a10-3b99d75de71c");
            //  if(CurrentStateDefID == NextState ) CheckRejectReason();
            
            // split kontrolü burda olmalı.. şimdilik formpostlarda
            

#endregion PostUpdate
        }

        protected void PostTransition_Procedure2Reject()
        {
            // From State : Procedure   To State : Reject
            #region PostTransition_Procedure2Reject

            Cancel();

            #endregion PostTransition_Procedure2Reject
        }


        protected void PostTransition_Request2Reject()
        {
            // From State : Procedure   To State : Reject
            #region PostTransition_Request2Reject

            Cancel();

            #endregion PostTransition_Request2Reject
        }

        public override void Cancel()
        {

            //bool hasStudyingTest = false;
            //foreach (RadiologyTest radTest in this.RadiologyTests)
            //{
            //    if (!(radTest.CurrentStateDefID == RadiologyTest.States.Cancelled || radTest.CurrentStateDefID == RadiologyTest.States.Reject))
            //    {
            //        hasStudyingTest = true;
            //        break;
            //    }
            //}
            //if (hasStudyingTest)
            //    throw new Exception(SystemMessage.GetMessage(915));
            //else
                base.Cancel();
        }



        protected void PostTransition_Procedure2Completed()
        {
            // From State : Procedure   To State : Completed
#region PostTransition_Procedure2Completed
            /*
            if(this.SourceObjectID != null) //XXXXXXler Arsı Sevkden yaratıldı ise
            {
                if(this.Episode.CreaterSite != null)
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    try
                    {
                        TTMessage message = Radiology.RemoteMethods.ReturnRadiologyToSourceHospital(this.Episode.CreaterSite.ObjectID, this);
                        objectContext.Save();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        objectContext.Dispose();
                    }
                }
            }
             */

            //RunReturnRadiologyFromOtherHospital();
#endregion PostTransition_Procedure2Completed
        }

#region Methods
        public Radiology(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            //this.MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = Radiology.States.Request;
            ProcedureSpeciality=episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }
        
        public Radiology(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = Radiology.States.Request;
            ProcedureSpeciality=subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
            Episode = subactionProcedureFlowable.Episode;
        }
        
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.Radiology;
            }
        }

        
       
        override protected void OnConstruct() {
            
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                
            }
            
        }
        
        public void CheckRejectReason()
        {
            if(RejectReason == null) throw new TTException(SystemMessage.GetMessage(916));
        }
        
        
        public string TimeLimitControl( RadiologyTestDefinition Testn )
        {
            //şimdilik aynı episodedaki kontrol..
            foreach (  EpisodeAction ea in    Episode.EpisodeActions)
            {
                if ( ea.ObjectDef.Name.ToUpperInvariant() == "RADIOLOGY" )
                {
                    foreach (  RadiologyTest rtest  in  ((Radiology)ea).RadiologyTests   )
                    {
                        if ( rtest.ProcedureObject == Testn  )
                        {
                            if( rtest.RequestDate !=null )
                            {
                                TimeSpan ts = Common.RecTime().Subtract(rtest.RequestDate.Value);
                                
                                if ( ts.Days > Testn.TimeLimit )
                                {
                                    return Testn.Name.ToString() + "  testi " +
                                        rtest.RequestDate .ToString() + " tarihinde istenmiştir." ;
                                }
                            }
                        }
                    }
                }
            }
            return "";
        }
        
        
        public string SexControl( RadiologyTestDefinition Testn )
        {
            if (Testn.SexControl != null && Testn.SexControl != SexEnum.Unidentified  )
            {
                //if (Testn.SexControl != this.Episode.Patient.Sex)
                //{
                //    if (Testn.SexControl == SexEnum.Male )
                        
                //        return "Bu test sadece erkek hastalar için istenebilir.";
                //    else
                        
                //        return "Bu test sadece kadın hastalar için istenebilir.";
                //}
            }
            return "";
        }

        public void RestrictedTestControl()
        {
            foreach (RadiologyTest test in RadiologyTests)
            {
                RadiologyTestDefinition testdef = (RadiologyTestDefinition) test.ProcedureObject;
                foreach(RadiologyGridRestrictedTestDefinition temp in testdef.Restricteds)
                {
                    foreach (RadiologyTest testx in RadiologyTests)
                    {
                        if (temp.Test == ((RadiologyTestDefinition) testx.ProcedureObject) )
                        {
                            throw new TTException(SystemMessage.GetMessageV3(120, new string[] { testdef.Name.ToString(), temp.Test.Name.ToString()}));
                        }
                    }
                }
            }
        }
        
        /*
        public IList GetRadiologyTabs(){
            
            IList RadTabs = RadiologyTabDefinition.GetRadTabs(ObjectContext);
            return  RadTabs;
        }
         */
        public ArrayList GetTestDescription(RadiologyTestDefinition Testn)
        {
            ArrayList aList= new ArrayList();
            if( Testn.RadiologyTestDescriptions.Count > 0 )
            {
                foreach (RadiologyGridTestDescriptionDefinition RadGridTestDef in Testn.RadiologyTestDescriptions)
                {
                    aList.Add(RadGridTestDef.TestDescription?.Description?.ToString());
                }
            }
            return aList;
        }
        
        public IList GetTestFromRadiologyLocation(RadiologyTabDefinition Tab)
        {
            IList RadLocations =  RadiologyLocation.GetByTab(ObjectContext,Tab.ObjectID.ToString());
            return RadLocations;
        }
        
        
        //şimdilik silme yok..
        public void SendToRequestAccept()
        {
            foreach( RadiologyTest Testn in RadiologyTests)
            {
                Testn.CurrentStateDefID = RadiologyTest.States.RequestAcception;
            }
        }

        public  Radiology(TTObjectContext objectContext,Radiology Rad,ResRadiologyDepartment Dep,bool SendOtherState):this(objectContext)
        {
            //Idler falan değişecek
            
            Episode = Rad.Episode;
            FromResource = Rad.FromResource;
            ActionDate = Common.RecTime().Date;
            RequestDoctor = Rad.RequestDoctor;
            Description = Rad.Description;
            PreDiagnosis = Rad.PreDiagnosis;
            MasterResource = Dep;
            if((bool)SendOtherState)
            {
                CurrentStateDefID = Radiology.States.Procedure;
                CurrentStateDefID = Rad.TransDef.ToStateDefID;
            }
            else
            {
                CurrentStateDef = Rad.TransDef.FromStateDef;
                CurrentStateDefID = Rad.TransDef.FromStateDefID;
            }
        }

        //En az bir SEÇ alanının seçilmesi zorunluluğu
        public bool RequestAcceptTestCheckControl()
        {
            Guid NextState = new Guid("46fae9ee-bff0-454f-bed2-d498508d17bc");
            if(CurrentStateDefID != NextState )
            {
                bool send = false;
                foreach( RadiologyTest Testn in RadiologyTests)
                {
                    if ( Testn.Check == true )
                    {
                        send = true;
                        break;
                    }
                }
                if (!send) {throw new TTException(SystemMessage.GetMessage(917)); }
                else { return true;}
            }
            else {return false; }
        }

        public void AddRemoveRadiologyTest(RadiologyTestDefinition Testn,bool IsAdding)
        {
            if(IsAdding)
            {
                RadiologyTest item = new RadiologyTest(ObjectContext);
                item.CurrentStateDefID = RadiologyTest.States.New;
                item.ProcedureObject = (RadiologyTestDefinition) Testn;

                //  ilkini set et
                foreach(RadiologyGridDepartmentDefinition RadDep in Testn.Departments )
                {
                    item.Department =  RadDep.Department;
                    //şimdilik
                    item.MasterResource =  RadDep.Department;
                    item.FromResource =  RadDep.Department;
                    break;
                }
                item.TestDate = Common.RecTime();
                item.RequestDate = Common.RecTime();
                
                ObjectContext.Update();
                RadiologyTests.Add(item);
            }
            else
            {
                foreach (RadiologyTest test in RadiologyTests)
                {
                    if( test.ProcedureObject == Testn)
                    {
                        RadiologyTests.Remove(test);
                        break;
                    }
                }
            }
        }

 
        
       
        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList= base.OldActionPropertyList();
            if(propertyList ==null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            if(ProcedureDoctor!=null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26233", "İşlemi Yapan Hekim"),Common.ReturnObjectAsString(ProcedureDoctor.Name)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M10483", "Açıklamalar"),Common.ReturnObjectAsString(Description)));
            return propertyList;
        }
        
        public override EpisodeAction PrepareEpisodeActionForRemoteMethod(bool withNewObjectID)
        {
            Radiology radiology = (Radiology)base.PrepareEpisodeActionForRemoteMethod(withNewObjectID);
            
            if(withNewObjectID)
            {
           
                radiology.RequestDoctor = null;
            }
            return radiology;
        }
        
        //public void RunReturnRadiologyFromOtherHospital()
        //{
        //    if(this.SourceObjectID != null && this.Episode.CreaterSite != null)
        //    {
        //        Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
        //        if(this.Episode.CreaterSite.ObjectID != siteIDGuid)
        //        {
        //            Guid savePoint = this.ObjectContext.BeginSavePoint();
        //            //String messageString="";
        //            try
        //            {
        //                List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
        //                foreach (DiagnosisGrid dg in this.Diagnosis)// Geriye gönderilirken yalnız Consultasyonda konulan tanılar geriye gönderiliyor.
        //                {
        //                    if(dg.ResponsibleUser!=null)
        //                        diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
        //                }

        //                //
        //                List<RadiologyTest> radiologyTestList = new List<RadiologyTest>();
        //                List<Guid> procedureObjectList = new List<Guid>();
        //                if(this.RadiologyTests.Count > 0)
        //                {
        //                    foreach(RadiologyTest test in this.RadiologyTests)
        //                    {
        //                        radiologyTestList.Add(test);
        //                        procedureObjectList.Add(test.ProcedureObject.ObjectID);
        //                    }
        //                }
        //                //
                        
                        
        //                //Radiology.RemoteMethods.ReturnRadiologyToSourceHospital(this.Episode.CreaterSite.ObjectID,(Radiology)this.PrepareEpisodeActionForRemoteMethod(true), this.RadiologyTests[0],diagnosisList);
        //                //Radiology.RemoteMethods.ReturnRadiologyTestsToSource(this.Episode.CreaterSite.ObjectID, (Radiology)this.PrepareEpisodeActionForRemoteMethod(true), radiologyTestList, diagnosisList,procedureObjectList);
                        
                        
        //                //ConsultationFromOtherHospital consultationFromOtherHospital = (ConsultationFromOtherHospital)objectContext.GetObject(this.ObjectID,"ConsultationFromOtherHospital");
        //                //consultationFromOtherHospital.MessageID = message.MessageID.ToString();
        //                //messageString = message.MessageID.ToString();
        //            }
        //            catch(Exception ex)
        //            {
        //                throw;
        //            }
        //            finally
        //            {
        //                this.ObjectContext.RollbackSavePoint(savePoint);
        //                //this.MessageID = messageString;
        //                //this.ObjectContext.Save();
        //            }
        //        }
        //    }
        //}

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
          

        }

        public override string OldActionSubactionProcedureFlowablesHtml()
        {
            string s = "";

            foreach (SubactionProcedureFlowable sf in SubactionProcedureFlowables)
            {
                if(sf is RadiologyTest)
                {
                    s = s + "<br>";
                    s = s + sf.OldActionReportHtml();
                }
                
            }
            return s;
        }
        
          override public Guid ProcedureRequestStartedStateDefID()
        {
            return (Guid)Radiology.States.Procedure;
        }
        
          
         override public void DoMyActionControlsForProcedureRequest()
        {

            if (!((ITTObject)this).IsReadOnly )
            {
                if (RequestDoctor == null)
                {
                    int[] doctorType = new int[3] { 0, 2, 17 };

                    if (Common.CurrentResource.TakesPerformanceScore == true && doctorType.Contains((int)Common.CurrentResource.UserType))
                    {

                        RequestDoctor = Common.CurrentResource;
                    }
                    else
                    {
                        if (this.MasterAction is PatientExamination)
                        {
                            if (((PatientExamination)this.MasterAction).ProcedureDoctor != null)
                                RequestDoctor = ((PatientExamination)this.MasterAction).ProcedureDoctor;
                        }
                        else if (this.MasterAction is InPatientPhysicianApplication)
                        {
                            if (((InPatientPhysicianApplication)this.MasterAction).ProcedureDoctor != null)
                                RequestDoctor = ((InPatientPhysicianApplication)this.MasterAction).ProcedureDoctor;
                        }
                        else
                            RequestDoctor = Common.CurrentResource;

                    }
                }
            }

            //Demo icin gecici olarak kapatıldı.
            //if (String.IsNullOrEmpty(this.PreDiagnosis))
            //{
            //    throw new Exception("Kısa Anamnez ve Klinik Bulgular alanı boş geçilemez!");
            //}

            if (PatientAdmission != null && PatientAdmission.AdmissionAppointment != null)
            {
                foreach (Appointment app in (PatientAdmission.AdmissionAppointment.Appointments))
                {
                    if (app.CurrentStateDefID == Appointment.States.New || app.CurrentStateDefID == Appointment.States.NotApproved)
                    {
                        app.SubActionProcedure = RadiologyTests[0];
                        break;
                    }
                }
            }

            //Tekrarlayan tetkik isteklerin kontrolü burada gerçekleşir...
            foreach (EpisodeAction episodeAction in Episode.EpisodeActions)
            {
                    if (episodeAction is Radiology)
                    {
                        if (episodeAction.ObjectID != ObjectID)
                        {
                            if (SubactionProcedures.Count > 0)
                            {
                                foreach (SubActionProcedure radRequestInfo in SubactionProcedures)
                                {

                                    foreach (RadiologyTest radProc in ((Radiology)episodeAction).RadiologyTests)
                                    {
                                        if (radRequestInfo.ProcedureObject.ObjectID == radProc.ProcedureObject.ObjectID)
                                        {
                                            //Basarili ya da Basarisiz tamamlanmis stepler disindaki herhangi bir stepte ayni istem varsa exception verecek.
                                            if (radProc.CurrentStateDefID  != RadiologyTest.States.Completed && radProc.CurrentStateDefID != RadiologyTest.States.Reported && radProc.CurrentStateDefID != RadiologyTest.States.Cancelled )
                                            {
                                                string errorMsg = "Hastanın vakasında daha önceden istenmiş " + radProc.ProcedureObject.Code.ToString() + " " + radProc.ProcedureObject.Name.ToString() + " tetkik isteği mevcuttur!" + "\n  Radyoloji İşlem Numarası: " + radProc.EpisodeAction.ID.Value.ToString() + "\n" + TTUtils.CultureService.GetText("M27100", "Tetkik istekten vazgeçildi.");
                                                //throw new TTUtils.TTException(errorMsg);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Radiology).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Radiology.States.Procedure && toState == Radiology.States.Reject)
                PostTransition_Procedure2Reject();
            else if (fromState == Radiology.States.Procedure && toState == Radiology.States.Completed)
                PostTransition_Procedure2Completed();
            else if (fromState == Radiology.States.Request && toState == Radiology.States.Reject)
                PostTransition_Request2Reject();
        }

    }
}