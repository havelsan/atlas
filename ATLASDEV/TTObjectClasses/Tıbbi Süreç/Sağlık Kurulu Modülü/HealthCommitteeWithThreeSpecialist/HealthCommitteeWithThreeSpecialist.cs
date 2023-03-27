
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
    /// Üç Uzman Tabip İmzalı Rapor  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class HealthCommitteeWithThreeSpecialist : BaseHealthCommittee, IWorkListEpisodeAction, IOAHealthCommittee
    {
        public partial class GetHCWithThreeSpecialist_Class : TTReportNqlObject 
        {
        }

        public partial class GetAllHCWithThreeSpecialist_Class : TTReportNqlObject 
        {
        }

        public partial class GetHCWTSByDateAndUniqueRefNo_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetCancelledHCWithThreeSpecialist_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetHCWithThreeSpecialistByDate_Class : TTReportNqlObject 
        {
        }

        public partial class GetHCWithThreeSpecialistsByDate_Class : TTReportNqlObject 
        {
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            
            base.PostUpdate();

#endregion PostUpdate
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            
            Cancel();


#endregion PostTransition_Completed2Cancelled
        }

        protected void PreTransition_Request2New()
        {
            // From State : Request   To State : New
#region PreTransition_Request2New
            HealthCommitteeProcedure pProcedure = new HealthCommitteeProcedure(this, ProcedureDefinition.HCReportProcedureObjectId.ToString());
#endregion PreTransition_Request2New
        }

        protected void PostTransition_FirstAdditionalUnit2Report()
        {
            // From State : FirstAdditionalUnit   To State : Report
#region PostTransition_FirstAdditionalUnit2Report
            ChangeMasterResource(Department);
#endregion PostTransition_FirstAdditionalUnit2Report
        }

        protected void UndoTransition_FirstAdditionalUnit2Report(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FirstAdditionalUnit   To State : Report
#region UndoTransition_FirstAdditionalUnit2Report
            ChangeMasterResource(FirstAdditionalUnit);
#endregion UndoTransition_FirstAdditionalUnit2Report
        }

        protected void PostTransition_FirstAdditionalUnit2New()
        {
            // From State : FirstAdditionalUnit   To State : New
#region PostTransition_FirstAdditionalUnit2New
            
            ChangeMasterResource(Department);
#endregion PostTransition_FirstAdditionalUnit2New
        }

        protected void UndoTransition_FirstAdditionalUnit2New(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FirstAdditionalUnit   To State : New
#region UndoTransition_FirstAdditionalUnit2New
            
            ChangeMasterResource(FirstAdditionalUnit);
#endregion UndoTransition_FirstAdditionalUnit2New
        }

        protected void PostTransition_FirstAdditionalUnit2SecondAdditionalUnit()
        {
            // From State : FirstAdditionalUnit   To State : SecondAdditionalUnit
#region PostTransition_FirstAdditionalUnit2SecondAdditionalUnit
            


            //2. ek birim doktoru authorizedUser olarak ekleniyor
            AuthorizedUser pAUser = new AuthorizedUser(ObjectContext);
            pAUser.Action = this;
            pAUser.User = AdditionalSpecialist2;
            AuthorizedUsers.Add(pAUser);

            ChangeMasterResource(SecondAdditionalUnit);

#endregion PostTransition_FirstAdditionalUnit2SecondAdditionalUnit
        }

        protected void UndoTransition_FirstAdditionalUnit2SecondAdditionalUnit(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FirstAdditionalUnit   To State : SecondAdditionalUnit
#region UndoTransition_FirstAdditionalUnit2SecondAdditionalUnit
            
            ChangeMasterResource(FirstAdditionalUnit);
#endregion UndoTransition_FirstAdditionalUnit2SecondAdditionalUnit
        }

        protected void PostTransition_ThirdSpecialistApproval2FirstAdditionalUnit()
        {
            // From State : ThirdSpecialistApproval   To State : FirstAdditionalUnit
#region PostTransition_ThirdSpecialistApproval2FirstAdditionalUnit
            
            //1. ek birim doktoru authorizedUser olarak ekleniyor
            AuthorizedUser pAUser = new AuthorizedUser(ObjectContext);
            pAUser.Action = this;
            pAUser.User = AdditionalSpecialist1;
            AuthorizedUsers.Add(pAUser);

            ChangeMasterResource(FirstAdditionalUnit);

#endregion PostTransition_ThirdSpecialistApproval2FirstAdditionalUnit
        }

        protected void UndoTransition_ThirdSpecialistApproval2FirstAdditionalUnit(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ThirdSpecialistApproval   To State : FirstAdditionalUnit
#region UndoTransition_ThirdSpecialistApproval2FirstAdditionalUnit
            


            CheckUnCompletedExamination();
            foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid pGrid in Specialists)
            {
                //3.uzman doktor authorizedUser olarak ekleniyor
                AuthorizedUser pAUser = new AuthorizedUser(ObjectContext);
                pAUser.Action = this;
                pAUser.User = pGrid.Specialist3;
                AuthorizedUsers.Add(pAUser);

                ChangeMasterResource(pGrid.ResSectionOfSpecialist3);
                break;//ilk satır yeterli, bu yapı değişmeli grid olmamalı aslında...YY
            }

#endregion UndoTransition_ThirdSpecialistApproval2FirstAdditionalUnit
        }

        protected void PostTransition_ThirdSpecialistApproval2Report()
        {
            // From State : ThirdSpecialistApproval   To State : Report
#region PostTransition_ThirdSpecialistApproval2Report
            

            ChangeMasterResource(Department);
            /*
            string sBirthID = SystemParameter.GetParameterValue("UNITOFBIRTH_OBJECTID", "");
            Guid birthID = new Guid(sBirthID);
            if(this.MasterResource.ObjectID == birthID)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", this.ObjectID.ToString());
                parameters.Add("TTOBJECTID",objectID);
                int copy= 1;
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCWThreeSpecialistReportForBirth),true, copy, parameters);
            }
            else
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", this.ObjectID.ToString());
                parameters.Add("TTOBJECTID",objectID);
                int copy= 1;
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HealthCommitteeWithThreeSpecialistReport),true, copy, parameters);
            }
            */


#endregion PostTransition_ThirdSpecialistApproval2Report
        }

        protected void UndoTransition_ThirdSpecialistApproval2Report(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ThirdSpecialistApproval   To State : Report
#region UndoTransition_ThirdSpecialistApproval2Report
            


            CheckUnCompletedExamination();
            foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid pGrid in Specialists)
            {
                //3.uzman doktor authorizedUser olarak ekleniyor
                AuthorizedUser pAUser = new AuthorizedUser(ObjectContext);
                pAUser.Action = this;
                pAUser.User = pGrid.Specialist3;
                AuthorizedUsers.Add(pAUser);

                ChangeMasterResource(pGrid.ResSectionOfSpecialist3);
                break;//ilk satır yeterli, bu yapı değişmeli grid olmamalı aslında...YY
            }

#endregion UndoTransition_ThirdSpecialistApproval2Report
        }

        protected void PostTransition_ThirdSpecialistApproval2SecondAdditionalUnit()
        {
            // From State : ThirdSpecialistApproval   To State : SecondAdditionalUnit
#region PostTransition_ThirdSpecialistApproval2SecondAdditionalUnit
            


            //2. ek birim doktoru authorizedUser olarak ekleniyor
            AuthorizedUser pAUser = new AuthorizedUser(ObjectContext);
            pAUser.Action = this;
            pAUser.User = AdditionalSpecialist2;
            AuthorizedUsers.Add(pAUser);

            ChangeMasterResource(SecondAdditionalUnit);

#endregion PostTransition_ThirdSpecialistApproval2SecondAdditionalUnit
        }

        protected void UndoTransition_ThirdSpecialistApproval2SecondAdditionalUnit(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ThirdSpecialistApproval   To State : SecondAdditionalUnit
#region UndoTransition_ThirdSpecialistApproval2SecondAdditionalUnit
            


            CheckUnCompletedExamination();
            foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid pGrid in Specialists)
            {
                //3.uzman doktor authorizedUser olarak ekleniyor
                AuthorizedUser pAUser = new AuthorizedUser(ObjectContext);
                pAUser.Action = this;
                pAUser.User = pGrid.Specialist3;
                AuthorizedUsers.Add(pAUser);

                ChangeMasterResource(pGrid.ResSectionOfSpecialist3);
                break;//ilk satır yeterli, bu yapı değişmeli grid olmamalı aslında...YY
            }

#endregion UndoTransition_ThirdSpecialistApproval2SecondAdditionalUnit
        }

        protected void PostTransition_ThirdSpecialistApproval2New()
        {
            // From State : ThirdSpecialistApproval   To State : New
#region PostTransition_ThirdSpecialistApproval2New
            ChangeMasterResource(Department);
#endregion PostTransition_ThirdSpecialistApproval2New
        }

        protected void UndoTransition_ThirdSpecialistApproval2New(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ThirdSpecialistApproval   To State : New
#region UndoTransition_ThirdSpecialistApproval2New
            


            foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid pGrid in Specialists)
            {
                //3.uzman doktor authorizedUser olarak ekleniyor
                AuthorizedUser pAUser = new AuthorizedUser(ObjectContext);
                pAUser.Action = this;
                pAUser.User = pGrid.Specialist3;
                AuthorizedUsers.Add(pAUser);

                ChangeMasterResource(pGrid.ResSectionOfSpecialist3);
                break;//ilk satır yeterli, bu yapı değişmeli grid olmamalı aslında...YY
            }

#endregion UndoTransition_ThirdSpecialistApproval2New
        }

        protected void PostTransition_New2SecondSpecialistApproval()
        {
            // From State : New   To State : SecondSpecialistApproval
#region PostTransition_New2SecondSpecialistApproval
            
            foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid pGrid in Specialists)
            {
                //2. uzman tabip authorizeduser olarak ekleniyor.
                AuthorizedUser pAUser1 = new AuthorizedUser(ObjectContext);
                pAUser1.Action = this;
                pAUser1.User = pGrid.Specialist2;
                AuthorizedUsers.Add(pAUser1);

                ChangeMasterResource(pGrid.ResSectionOfSpecialist2);
                break;//ilk satır yeterli, bu yapı değişmeli grid olmamalı aslında...YY
            }
            
            ControlRequiredPropertiesByReportType();

#endregion PostTransition_New2SecondSpecialistApproval
        }

        protected void UndoTransition_New2SecondSpecialistApproval(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : SecondSpecialistApproval
#region UndoTransition_New2SecondSpecialistApproval
            

            CheckUnCompletedExamination();
            ChangeMasterResource(Department);

#endregion UndoTransition_New2SecondSpecialistApproval
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
#region PostTransition_New2Cancelled
            Cancel();
#endregion PostTransition_New2Cancelled
        }

        protected void PostTransition_New2Report()
        {
            // From State : New   To State : Report
#region PostTransition_New2Report
            
            ControlRequiredPropertiesByReportType();

#endregion PostTransition_New2Report
        }

        protected void PostTransition_SecondSpecialistApproval2ThirdSpecialistApproval()
        {
            // From State : SecondSpecialistApproval   To State : ThirdSpecialistApproval
#region PostTransition_SecondSpecialistApproval2ThirdSpecialistApproval
            
            foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid pGrid in Specialists)
            {
                //3. uzman tabip authorizeduser olarak ekleniyor.
                
                AuthorizedUser pAUser2 = new AuthorizedUser(ObjectContext);
                pAUser2.Action = this;
                pAUser2.User = pGrid.Specialist3;
                AuthorizedUsers.Add(pAUser2);
                
                ChangeMasterResource(pGrid.ResSectionOfSpecialist3);
                break;//ilk satır yeterli, bu yapı değişmeli grid olmamalı aslında...YY
            }

            /* Eskiden raporlar burada dökülüyordu, artık 3. Uzman Tabip Onay state inden
             * Rapor Onayı (Başhekim Onayı butonuna basılınca) state ine geçerken dökülecek.
            string sBirthID = SystemParameter.GetParameterValue("UNITOFBIRTH_OBJECTID", "");
            Guid birthID = new Guid(sBirthID);
            if(this.MasterResource.ObjectID == birthID)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", this.ObjectID.ToString());
                parameters.Add("TTOBJECTID",objectID);
                int copy= 1;
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCWThreeSpecialistReportForBirth),true, copy, parameters);
            }
            else
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", this.ObjectID.ToString());
                parameters.Add("TTOBJECTID",objectID);
                int copy= 1;
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HealthCommitteeWithThreeSpecialistReport),true, copy, parameters);
            }
             */

#endregion PostTransition_SecondSpecialistApproval2ThirdSpecialistApproval
        }

        protected void UndoTransition_SecondSpecialistApproval2ThirdSpecialistApproval(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SecondSpecialistApproval   To State : ThirdSpecialistApproval
#region UndoTransition_SecondSpecialistApproval2ThirdSpecialistApproval
            


            CheckUnCompletedExamination();
            foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid pGrid in Specialists)
            {
                //2. uzman doktor authorizedUser olarak ekleniyor
                AuthorizedUser pAUser = new AuthorizedUser(ObjectContext);
                pAUser.Action = this;
                pAUser.User = pGrid.Specialist2;
                AuthorizedUsers.Add(pAUser);

                ChangeMasterResource(pGrid.ResSectionOfSpecialist2);
                break;//ilk satır yeterli, bu yapı değişmeli grid olmamalı aslında...YY
            }

#endregion UndoTransition_SecondSpecialistApproval2ThirdSpecialistApproval
        }

        protected void PostTransition_SecondSpecialistApproval2New()
        {
            // From State : SecondSpecialistApproval   To State : New
#region PostTransition_SecondSpecialistApproval2New
            
            ChangeMasterResource(Department);
#endregion PostTransition_SecondSpecialistApproval2New
        }

        protected void UndoTransition_SecondSpecialistApproval2New(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SecondSpecialistApproval   To State : New
#region UndoTransition_SecondSpecialistApproval2New
            


            foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid pGrid in Specialists)
            {
                //2. uzman doktor authorizedUser olarak ekleniyor
                AuthorizedUser pAUser = new AuthorizedUser(ObjectContext);
                pAUser.Action = this;
                pAUser.User = pGrid.Specialist2;
                AuthorizedUsers.Add(pAUser);

                ChangeMasterResource(pGrid.ResSectionOfSpecialist2);
                break;
            }

#endregion UndoTransition_SecondSpecialistApproval2New
        }

        protected void PostTransition_SecondAdditionalUnit2New()
        {
            // From State : SecondAdditionalUnit   To State : New
#region PostTransition_SecondAdditionalUnit2New
            
            ChangeMasterResource(Department);
#endregion PostTransition_SecondAdditionalUnit2New
        }

        protected void UndoTransition_SecondAdditionalUnit2New(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SecondAdditionalUnit   To State : New
#region UndoTransition_SecondAdditionalUnit2New
            
            ChangeMasterResource(SecondAdditionalUnit);
#endregion UndoTransition_SecondAdditionalUnit2New
        }

        protected void PostTransition_SecondAdditionalUnit2Report()
        {
            // From State : SecondAdditionalUnit   To State : Report
#region PostTransition_SecondAdditionalUnit2Report
            
            ChangeMasterResource(Department);
#endregion PostTransition_SecondAdditionalUnit2Report
        }

        protected void UndoTransition_SecondAdditionalUnit2Report(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SecondAdditionalUnit   To State : Report
#region UndoTransition_SecondAdditionalUnit2Report
            

            CheckUnCompletedExamination();
            ChangeMasterResource(SecondAdditionalUnit);

#endregion UndoTransition_SecondAdditionalUnit2Report
        }

        protected void PreTransition_Report2Completed()
        {
            // From State : Report   To State : Completed
#region PreTransition_Report2Completed
            
            OlapDate = DateTime.Now;

#endregion PreTransition_Report2Completed
        }

        protected void UndoTransition_Report2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Report   To State : Completed
#region UndoTransition_Report2Completed
            
            
            CheckUnCompletedExamination();
            

#endregion UndoTransition_Report2Completed
        }

#region Methods
        public HealthCommitteeWithThreeSpecialist(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = HealthCommitteeWithThreeSpecialist.States.Request;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
            {
                ClinicReportNo.GetNextValue(Common.RecTime().Date.Year);
            }
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.HealthCommitteeWithThreeSpecialist;
            }
        }

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //Eğer hastanın episode'unda Heyet Kabul adımında SK varsa, yeni 3 İmza işleminin başlatılması engellenir..
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            foreach (EpisodeAction episodeaction in subEpisode.Episode.EpisodeActions)
            {
                if (episodeaction is HealthCommittee)
                {
                    if (episodeaction.CurrentStateDefID == HealthCommittee.States.CommitteeAcceptance)
                    {
                        throw new TTException(SystemMessage.GetMessage(1137));
                    }
                }
            }
            //Sevk Eri,Yedek Subay Aday Adayı,Yoklama Eri

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            // Hasta kabul sebebi SAĞLIK KURULU MUAYENESİ, PERİYODİK MUAYENE, GEÇİCİ SAĞLIK KURULU MUAYENESİ?nden biri ise, ve  hastanın grubu HEMŞİRE ADAYI, ÖĞRENCİ ADAYI, SUBAY ADAYI, SİVİL MEMUR ADAYI, UZMAN ERBAŞ ADAYI, YEDEK SUBAY ADAYI, İŞÇİ ADAYI ise,  Sağlık Kurulu Sebepleri aşağıdaki gibi set edilir:
            // HEMŞİRE ADAYI -> XXXXXXİ HEMŞİRE OLMAK İÇİN
            // ÖĞRENCİ ADAYI -> XXXXXXİ ÖĞRENCİ OLMAK İÇİN
            // SUBAY ADAYI -> SUBAY OLMAK İÇİN
            // SİVİL MEMUR ADAYI -> SİVİL MEMUR OLMAK İÇİN
            // UZMAN ERBAŞ ADAYI ->UZMAN ERBAŞ OLMAK İÇİN
            // YEDEK SUBAY ADAYI ->YEDEK SUBAY OLMAK İÇİN
            // İŞÇİ ADAYI-> İŞÇİ OLMAK İÇİN
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            /* switch(episode.ReasonForAdmission.Type)
            {
                case AdmissionTypeEnum.HealthCommitteeExamination:
                case AdmissionTypeEnum.PeriodicExamination:
                case AdmissionTypeEnum.TemporaryHealthCommitteExamination:
                    switch(episode.PatientGroup){
                        case PatientGroupEnum.CadetCandidate:
                            episode.ReasonForExamination.ReasonForExaminationType = ReasonForExaminationTypeEnum.Cadet;
                            break;
                        case PatientGroupEnum.MilitaryCivilOfficialCandidate:
                            episode.ReasonForExamination.ReasonForExaminationType = ReasonForExaminationTypeEnum.MilitaryCivilOfficial;
                            break;
                        case PatientGroupEnum.ExpertNonComCandidate:
                            episode.ReasonForExamination.ReasonForExaminationType = ReasonForExaminationTypeEnum.ExpertNonCom;
                            break;
                        case PatientGroupEnum.MilitaryWorkerCandidate:
                            episode.ReasonForExamination.ReasonForExaminationType = ReasonForExaminationTypeEnum.MilitaryWorker;
                            break;
                            //                        case PatientGroupEnum.MilitaryNurseCandidate:
                            //                            episode.ReasonForExamination.ReasonForExaminationType = ReasonForExaminationTypeEnum.MilitaryNurseCandidate;
                            //                            break;
                    }
                    break;
            }*/

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //Kabul sebebi Periyodik Muayene olan SOZLESMELI ASTSUBAY, SOZLESMELI SUBAY, ASTSUBAY,SUBAY,KURMAY
            //SUBAY,SİVİL MEMUR,UZMAN ERBAŞ için ise Sağlık Kurulu Sebebi olarak  PERİYODİK MUAYENE İÇİN ibaresi set edilir.
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            /*if(episode.ReasonForAdmission.Type== AdmissionTypeEnum.PeriodicExamination)
            {
                switch(episode.PatientGroup)
                {
                        // YAPILACAK: case SOZLESMELI SUBAYE
                        // YAPILACAK: case SOZLESMELI ASTSUBAY
                        // YAPILACAK: case KURMAY SUBAY
                    case PatientGroupEnum.MilitaryCivilOfficial:
                    case PatientGroupEnum.ExpertNonCom:
                    case PatientGroupEnum.NoncommissionedOfficer:
                    case PatientGroupEnum.Officer:
                        episode.ReasonForExamination.ReasonForExaminationType= ReasonForExaminationTypeEnum.PeriodicExamination;
                        break;
                }
            }*/

            //         if(episode.PatientAdmission.Payer.Type.PayerType == PayerTypeEnum.Paid)
            //                this.CurrentStateDefID = HealthCommitteeWithThreeSpecialist.States.Request;
            //            else
            //                this.CurrentStateDefID = HealthCommitteeWithThreeSpecialist.States.New;
        }


      
        /// <summary>
        /// Ortez protezden fire edildiğinde ortez protezin HospitalsUnits ve ReasonForExamination değerlerini aktarmaya yaratan constructor
        /// </summary>
        /// <param name="objectContext"></param>
        /// <param name="reasonForExaminationDefinition"></param>
        /// <param name="hospitalsUnitsList"></param>
        public HealthCommitteeWithThreeSpecialist(OrthesisProsthesisProcedure orthesisProsthesisProcedure)
            : this(orthesisProsthesisProcedure.ObjectContext)
        {
            ActionDate = Common.RecTime();
            MasterAction = orthesisProsthesisProcedure.OrthesisProsthesisRequest;
            MasterResource = orthesisProsthesisProcedure.OrthesisProsthesisRequest.FromResource;
            FromResource = orthesisProsthesisProcedure.OrthesisProsthesisRequest.FromResource;
            ReasonForExamination = ((OrthesisProsthesisRequest)orthesisProsthesisProcedure.OrthesisProsthesisRequest).ReasonForExamination;
            Episode = orthesisProsthesisProcedure.EpisodeAction.Episode;
            foreach (OrthesisProsthesisHospitalsUnitsGrid orthesisProsthesisHospitalsUnitsGrid in ((OrthesisProsthesisRequest)orthesisProsthesisProcedure.OrthesisProsthesisRequest).HospitalsUnits)
            {
                BaseHealthCommittee_HospitalsUnitsGrid hospitalsUnitsGrid = new BaseHealthCommittee_HospitalsUnitsGrid(ObjectContext);
               // hospitalsUnitsGrid.Hospital = orthesisProsthesisHospitalsUnitsGrid.Hospital;
                hospitalsUnitsGrid.Unit = orthesisProsthesisHospitalsUnitsGrid.Unit;
                HospitalsUnits.Add(hospitalsUnitsGrid);
            }
            CurrentStateDefID = HealthCommitteeWithThreeSpecialist.States.Request;
            Update();
            CurrentStateDefID = HealthCommitteeWithThreeSpecialist.States.New;

        }
        /// <summary>
        /// HospitalsUnits içindeki her bir satırın SK Muayenesi olarak fork edilmesini sağlar.
        /// </summary>
        protected void CheckHospitalsUnitsGridForFork()
        {
            foreach (BaseHealthCommittee_HospitalsUnitsGrid hospitalUnit in _HospitalsUnits)
            {
                Guid hospID = new Guid(SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
                //if (!hospitalUnit.Hospital.ObjectID.Equals(hospID))
                //{
                //    this.ForkHealthCommitteeExaminationFromOtherHospitals((HospitalsUnitsGrid)hospitalUnit);
                //}
                //else
                //{
                    ForkExaminationApproval((HospitalsUnitsGrid)hospitalUnit);
                //}
            }
        }

        public override void Cancel()
        {
            base.Cancel();
            CheckUnCompletedExamination();
        }

        private void CheckUnCompletedExamination()
        {
            bool bFound = false;
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this);
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is HealthCommitteeExamination && !eaction.IsCancelled)
                {
                    HealthCommitteeExamination exam = (HealthCommitteeExamination)eaction;
                    if (!exam.CurrentStateDefID.Equals(HealthCommitteeExamination.States.Completed))
                    {
                        bFound = true;
                        break;
                    }
                }

                if (eaction is HealthCommitteeExaminationFromOtherDepartments && !eaction.IsCancelled)
                {
                    HealthCommitteeExaminationFromOtherDepartments exam = (HealthCommitteeExaminationFromOtherDepartments)eaction;
                    if (!exam.CurrentStateDefID.Equals(HealthCommitteeExaminationFromOtherDepartments.States.Acceptance))
                    {
                        bFound = true;
                        break;
                    }
                }
            }

            if (bFound)
                throw new Exception(SystemMessage.GetMessage(501));
        }

        public void ChangeMasterResource(ResSection mResource)
        {
            if (mResource != null)
                MasterResource = mResource;
        }
        
        // Rapor türüne göre zorunlu alan kontrolleri
        public void ControlRequiredPropertiesByReportType()
        {
            if (ExaminationReason.ReportType.HasValue)
            {
                if (ExaminationReason.ReportType.Value == HCThreeSpecialistReportTypeEnum.Material)
                {
                    if (!ReportStartDate.HasValue)
                        throw new TTException(TTUtils.CultureService.GetText("M27102", "Tıbbi Malzeme Raporu için 'Rapor Başlangıç Tarihi' bilgisi boş olamaz."));
                    if (!ReportEndDate.HasValue)
                        throw new TTException(TTUtils.CultureService.GetText("M27103", "Tıbbi Malzeme Raporu için 'Rapor Bitiş Tarihi' bilgisi boş olamaz."));
                }
                else if (ExaminationReason.ReportType.Value == HCThreeSpecialistReportTypeEnum.Rest)
                {
                    if (!ReportStartDate.HasValue)
                        throw new TTException(TTUtils.CultureService.GetText("M26165", "İstirahat Raporu için 'Rapor Başlangıç Tarihi' bilgisi boş olamaz."));
                    if (!ReportEndDate.HasValue)
                        throw new TTException(TTUtils.CultureService.GetText("M26166", "İstirahat Raporu için 'Rapor Bitiş Tarihi' bilgisi boş olamaz."));
                    if (!DecisionDate.HasValue)
                        throw new TTException(TTUtils.CultureService.GetText("M26164", "İstirahat Raporu için 'Karar Tarihi' bilgisi boş olamaz."));
                    if (!RestReportDecision.HasValue)
                        throw new TTException(TTUtils.CultureService.GetText("M26163", "İstirahat Raporu için 'Karar' bilgisi boş olamaz."));
                }
                else if (ExaminationReason.ReportType.Value == HCThreeSpecialistReportTypeEnum.SituationInformOneDoctor)
                {
                    if (!SituationInformODReportType.HasValue)
                        throw new TTException(TTUtils.CultureService.GetText("M25554", "Durum Bildirir Tek Hekim Raporu için 'Verilme Nedeni' bilgisi boş olamaz."));
                    if (!SituationInformODDecision.HasValue)
                        throw new TTException(TTUtils.CultureService.GetText("M25553", "Durum Bildirir Tek Hekim Raporu için 'Karar' bilgisi boş olamaz."));
                    if (string.IsNullOrEmpty(NoObstacleDescription) && SituationInformODDecision.Value == HCTSituationInformODDecisionEnum.NoObstacle)
                        throw new TTException(TTUtils.CultureService.GetText("M25552", "Durum Bildirir Tek Hekim Raporu için 'Engeli Olmayan Durum' bilgisi boş olamaz."));
                }
            }
        }
        public static int IsCurrentUserOneOfSpecialists(HealthCommitteeWithThreeSpecialist healthCommitteeWithThreeSpecialist)
        {
            List<ResUser> specialists = new List<ResUser>();
            if (healthCommitteeWithThreeSpecialist.AdditionalSpecialist1 != null )
                specialists.Add(healthCommitteeWithThreeSpecialist.AdditionalSpecialist1);
            if (healthCommitteeWithThreeSpecialist.AdditionalSpecialist2 != null )
                specialists.Add(healthCommitteeWithThreeSpecialist.AdditionalSpecialist2);
            specialists.Add(((HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid)healthCommitteeWithThreeSpecialist.Specialists[0]).Specialist1);
            specialists.Add(((HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid)healthCommitteeWithThreeSpecialist.Specialists[0]).Specialist2);
            specialists.Add(((HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid)healthCommitteeWithThreeSpecialist.Specialists[0]).Specialist3);
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            
            foreach(ResUser specialist in specialists)
            {
                if(currentUser.ObjectID == specialist.ObjectID)
                    return 1;
            }
            return 0;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeWithThreeSpecialist).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeWithThreeSpecialist.States.Request && toState == HealthCommitteeWithThreeSpecialist.States.New)
                PreTransition_Request2New();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.Report && toState == HealthCommitteeWithThreeSpecialist.States.Completed)
                PreTransition_Report2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeWithThreeSpecialist).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeWithThreeSpecialist.States.Completed && toState == HealthCommitteeWithThreeSpecialist.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit && toState == HealthCommitteeWithThreeSpecialist.States.Report)
                PostTransition_FirstAdditionalUnit2Report();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit && toState == HealthCommitteeWithThreeSpecialist.States.New)
                PostTransition_FirstAdditionalUnit2New();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit && toState == HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit)
                PostTransition_FirstAdditionalUnit2SecondAdditionalUnit();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit)
                PostTransition_ThirdSpecialistApproval2FirstAdditionalUnit();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.Report)
                PostTransition_ThirdSpecialistApproval2Report();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit)
                PostTransition_ThirdSpecialistApproval2SecondAdditionalUnit();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.New)
                PostTransition_ThirdSpecialistApproval2New();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.New && toState == HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval)
                PostTransition_New2SecondSpecialistApproval();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.New && toState == HealthCommitteeWithThreeSpecialist.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.New && toState == HealthCommitteeWithThreeSpecialist.States.Report)
                PostTransition_New2Report();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval)
                PostTransition_SecondSpecialistApproval2ThirdSpecialistApproval();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.New)
                PostTransition_SecondSpecialistApproval2New();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit && toState == HealthCommitteeWithThreeSpecialist.States.New)
                PostTransition_SecondAdditionalUnit2New();
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit && toState == HealthCommitteeWithThreeSpecialist.States.Report)
                PostTransition_SecondAdditionalUnit2Report();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeWithThreeSpecialist).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit && toState == HealthCommitteeWithThreeSpecialist.States.Report)
                UndoTransition_FirstAdditionalUnit2Report(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit && toState == HealthCommitteeWithThreeSpecialist.States.New)
                UndoTransition_FirstAdditionalUnit2New(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit && toState == HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit)
                UndoTransition_FirstAdditionalUnit2SecondAdditionalUnit(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit)
                UndoTransition_ThirdSpecialistApproval2FirstAdditionalUnit(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.Report)
                UndoTransition_ThirdSpecialistApproval2Report(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit)
                UndoTransition_ThirdSpecialistApproval2SecondAdditionalUnit(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.New)
                UndoTransition_ThirdSpecialistApproval2New(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.New && toState == HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval)
                UndoTransition_New2SecondSpecialistApproval(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval)
                UndoTransition_SecondSpecialistApproval2ThirdSpecialistApproval(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval && toState == HealthCommitteeWithThreeSpecialist.States.New)
                UndoTransition_SecondSpecialistApproval2New(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit && toState == HealthCommitteeWithThreeSpecialist.States.New)
                UndoTransition_SecondAdditionalUnit2New(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit && toState == HealthCommitteeWithThreeSpecialist.States.Report)
                UndoTransition_SecondAdditionalUnit2Report(transDef);
            else if (fromState == HealthCommitteeWithThreeSpecialist.States.Report && toState == HealthCommitteeWithThreeSpecialist.States.Completed)
                UndoTransition_Report2Completed(transDef);
        }

    }
}