//$8B0BDD69
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public partial class HealthCommitteeServiceController : Controller
    {
        [HttpGet]
        public HCNewFormViewModel HCNewForm(Guid? id)
        {
            var FormDefID = Guid.Parse("6df12f7a-b11d-4273-81ca-d3d3c7f02019");
            var ObjectDefID = Guid.Parse("00787ad8-30b5-44a8-bb40-d1cd0414fb0a");
            var viewModel = new HCNewFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._HealthCommittee = objectContext.GetObject(id.Value, ObjectDefID) as HealthCommittee;
                    var e = viewModel._HealthCommittee.Episode; //Contexe episodeu yüklemediği için yazıldı silmeyin
                    viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
                    viewModel.HospitalsUnitsGridList = viewModel._HealthCommittee.HospitalsUnits.OfType<BaseHealthCommittee_HospitalsUnitsGrid>().ToArray();

                    System.Collections.ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(viewModel._HealthCommittee);
                    string _tempDecision = string.Empty;

                    #region MUAYENENİN DURUMU
                    viewModel.LinkedActions = new List<EpisodeAction>();
                    viewModel.HCExaminationComponents = new List<HCExaminationComponent>();
                    foreach (EpisodeAction eaction in arrList)
                    {
                        if (eaction is PatientExamination && ((PatientExamination)eaction).PatientExaminationType == PatientExaminationEnum.HealthCommittee && !eaction.IsCancelled && eaction.CurrentStateDefID != PatientExamination.States.PatientNoShown)
                        {
                            //eaction.CurrentStateDef
                            viewModel.LinkedActions.Add(eaction);
                            viewModel.HCExaminationComponents.Add(((PatientExamination)eaction).HCExaminationComponent);
                        }
                    }

                    //Services.LookupService service = new Services.LookupService();
                    //var result = service.EnumList(enumName).ToArray();
                    #endregion

                    if (viewModel._HealthCommittee.ExternalDoctors == null || viewModel._HealthCommittee.ExternalDoctors.Count == 0)
                        GetLastInsertedExtDoctorList(viewModel, objectContext);
                    else
                        viewModel.ExternalDoctorsGridList = viewModel._HealthCommittee.ExternalDoctors.OfType<BaseHealthCommittee_ExtDoctorGrid>().ToArray();

                    if (viewModel._HealthCommittee.Members == null || viewModel._HealthCommittee.Members.Count == 0)
                        GetHCMemberDefinition(viewModel, objectContext);

                    if (viewModel._HealthCommittee.HCRequestReason != null && viewModel._HealthCommittee.HCRequestReason.ReasonForExamination != null && viewModel._HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition != null)
                    {
                        viewModel.IsDisabled = viewModel._HealthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true ? true : false;
                    }

                    viewModel.MembersGridList = viewModel._HealthCommittee.Members.OfType<MemberOfHealthCommiittee>().ToArray();
                    viewModel.HCRequestReasons = objectContext.LocalQuery<HCRequestReason>().ToArray();
                    viewModel.ReasonForExaminationDefinitions = objectContext.LocalQuery<ReasonForExaminationDefinition>().ToArray();
                    viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                    viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
                    viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
                    viewModel.HospitalsUnitsGridListPre = viewModel._HealthCommittee.HospitalsUnits.OfType<BaseHealthCommittee_HospitalsUnitsGrid>().ToArray();
                    viewModel.IsUnCompletedExaminationExists = HealthCommittee.UnCompletedExaminationExists(viewModel._HealthCommittee);
                    //viewModel.SpecialityDefinitionsList = SpecialityDefinition.GetAllSpecialityDefinition(objectContext, " WHERE  ISACTIVE = 1").OrderBy(x => x.Name).ToArray();
                    viewModel.SpecialityDefinitionsList = SpecialityDefinition.GetSpecialityDefByLastUpdateDate(objectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).OrderBy(x => x.Name).ToArray();
                    viewModel.DoctorandTechnicianList = ResUser.GetDoctorandTechnicianList(objectContext, "").ToArray();

                    if (viewModel._HealthCommittee.ClinicWeight == null)
                        viewModel._HealthCommittee.ClinicWeight = viewModel._HealthCommittee.Episode.Patient.Weight != null ? (int)viewModel._HealthCommittee.Episode.Patient.Weight : 0;
                    if (viewModel._HealthCommittee.ClinicHeight == null)
                        viewModel._HealthCommittee.ClinicHeight = viewModel._HealthCommittee.Episode.Patient.Heigth != null ? (int)viewModel._HealthCommittee.Episode.Patient.Heigth : 0;

                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._HealthCommittee = new HealthCommittee(objectContext);
                    //Silinecek
                    /* 
                    SubEpisode se = new SubEpisode(objectContext);
                    viewModel.SubEpisode = objectContext.LocalQuery<SubEpisode>().ToArray();
                    
                    //se.PatientAdmission = (PatientAdmission)viewModel._HealthCommittee.MasterAction;
                    //se.EpisodeActions.Add(viewModel._HealthCommittee);

                    SubEpisodeProtocol.SEPProperty SEPProperty = new SubEpisodeProtocol.SEPProperty();
                    se.AddSubEpisodeProtocol(SEPProperty);
                    viewModel.SubEpisodeList.Add(se);
                    viewModel.SubEpisode = viewModel.SubEpisodeList.ToArray();
                    if (viewModel.SubEpisode.Length > 0)
                    {
                        viewModel.SubEpisodeProtocolList = viewModel.SubEpisode[0].SubEpisodeProtocols.ToList();
                    }

                    SubEpisodeProtocol sep;
                    sep = SubEpisode.GetActiveSubEpisodeProtocol(se);
                    //if (sep == null)
                    //    throw new TTException("Altvakada açık anlaşma bulunamadığı için Ücreti Ödeyecek belirlenemiyor.");
                    if (sep.Protocol != null && sep.Protocol.Type == ProtocolTypeEnum.Paid)
                        viewModel._HealthCommittee.WhoPays = WhoPaysEnum.PatientPays;
                    else viewModel._HealthCommittee.WhoPays = WhoPaysEnum.PayerPays;
                    */
                    var entryStateID = Guid.Parse("c2b49309-ec10-4dae-96ef-45bd4eba3cdd");
                    viewModel._HealthCommittee.CurrentStateDefID = entryStateID;
                    viewModel.HospitalsUnitsGridList = new TTObjectClasses.BaseHealthCommittee_HospitalsUnitsGrid[] { };
                    viewModel.ExternalDoctorsGridList = new BaseHealthCommittee_ExtDoctorGrid[] { };
                    viewModel.MembersGridList = new TTObjectClasses.MemberOfHealthCommiittee[] { };
                    viewModel._HealthCommittee.SetProcedureDoctorAsCurrentResource();
                    //viewModel.SpecialityDefinitionsList = SpecialityDefinition.GetAllSpecialityDefinition(objectContext, "WHERE  ISACTIVE = 1").OrderBy(x => x.Name).ToArray();
                    viewModel.SpecialityDefinitionsList = SpecialityDefinition.GetSpecialityDefByLastUpdateDate(objectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).OrderBy(x => x.Name).ToArray();
                    //viewModel._HealthCommittee.ClinicWeight = viewModel._HealthCommittee.PatientAdmission.Episode.Patient.Weight != null ? (int)viewModel._HealthCommittee.PatientAdmission.Episode.Patient.Weight : 0;
                    //viewModel._HealthCommittee.ClinicHeight = viewModel._HealthCommittee.PatientAdmission.Episode.Patient.Heigth != null ? (int)viewModel._HealthCommittee.PatientAdmission.Episode.Patient.Heigth : 0;
                }

            }


            return viewModel;
        }

        private void GetLastInsertedExtDoctorList(HCNewFormViewModel viewModel, TTObjectContext objectContext)
        {
            BindingList<BaseHealthCommittee_ExtDoctorGrid.GetLastUpdatedHCID_Class> _tempData = BaseHealthCommittee_ExtDoctorGrid.GetLastUpdatedHCID(objectContext);

            Guid hcID = (_tempData != null && _tempData.Count > 0 && _tempData[0] != null && _tempData[0].BaseHealthCommittee != null) ? _tempData[0].BaseHealthCommittee.Value : new Guid();

            viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
            List<BaseHealthCommittee_ExtDoctorGrid> tempList = new List<BaseHealthCommittee_ExtDoctorGrid>();

            tempList = BaseHealthCommittee_ExtDoctorGrid.GetLastUpdatedExtDoctorList(objectContext, hcID).ToList();
            //viewModel.ExternalDoctorsGridList = (BaseHealthCommittee_ExtDoctorGrid[])tempList.ToArray().Clone();
            List<BaseHealthCommittee_ExtDoctorGrid> hede = new List<BaseHealthCommittee_ExtDoctorGrid>();
            foreach (BaseHealthCommittee_ExtDoctorGrid item in tempList)
            {
                BaseHealthCommittee_ExtDoctorGrid asas = (BaseHealthCommittee_ExtDoctorGrid)item.Clone();


                hede.Add(asas);
                viewModel._HealthCommittee.ExternalDoctors.Add(asas);
                viewModel.SpecialityDefinitions.ToList().Add(asas.Speciality);
            }
            viewModel.ExternalDoctorsGridList = hede.ToArray();
        }

        private void GetHCMemberDefinition(HCNewFormViewModel viewModel, TTObjectContext objectContext)
        {

            if (viewModel._HealthCommittee != null && viewModel._HealthCommittee.HCRequestReason != null && viewModel._HealthCommittee.HCRequestReason.ReasonForExamination != null
                && viewModel._HealthCommittee.HCRequestReason.ReasonForExamination.MemberOfHealthCommittee != null && viewModel._HealthCommittee.HCRequestReason.ReasonForExamination.MemberOfHealthCommittee.Members != null)
            {
                foreach (var member in viewModel._HealthCommittee.HCRequestReason.ReasonForExamination.MemberOfHealthCommittee.Members)
                {
                    MemberOfHealthCommiittee mohc = new MemberOfHealthCommiittee(objectContext);
                    mohc.MemberDoctor = member.Doctor;
                    mohc.Speciality = member.Unit != null ? member.Unit.Brans : null;
                    var zz = viewModel._HealthCommittee.Members.Where(x => x.MemberDoctor.ObjectID == member.Doctor.ObjectID).ToList();
                    int aa = zz != null ? zz.Count() : 0;
                    if (zz == null || aa == 0)
                        viewModel._HealthCommittee.Members.Add(mohc);
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SpecialityDefinition GetDoctorBrans(string ResUserID)
        {
            TTObjectContext objectContext = new TTObjectContext(true);

            ResUser ru = (ResUser)objectContext.GetObject(new Guid(ResUserID), "ResUser");

            if (ru.ResourceSpecialities.Count > 0)
                return ru.ResourceSpecialities[0].Speciality;

            return null;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool IsResourceExists(Guid HCObjectID)
        {
            bool resourceExists = false;
            using (TTObjectContext context = new TTObjectContext(false))
            {
                HealthCommittee healthCommittee = context.GetObject(HCObjectID, typeof(HealthCommittee)) as HealthCommittee;
                if (!Common.CurrentUser.IsPowerUser && !Common.CurrentUser.IsSuperUser)
                {
                    if (Common.CurrentDoctor != null && healthCommittee.HCRequestReason != null && healthCommittee.HCRequestReason.ReasonForExamination != null)
                    {
                        if (healthCommittee.HCRequestReason.ReasonForExamination.HospitalsUnits != null && healthCommittee.HCRequestReason.ReasonForExamination.HospitalsUnits.Count == 0)
                        {
                            foreach (BaseHealthCommittee_HospitalsUnitsGrid unitsGrid in healthCommittee.HospitalsUnits)
                            {
                                if (unitsGrid.Unit != null)
                                {
                                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                                    {
                                        if (userResource.Resource != null && unitsGrid.Unit.ObjectID == userResource.Resource.ObjectID)
                                        {
                                            resourceExists = true;
                                            break;
                                        }
                                    }

                                    if (resourceExists)
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            return resourceExists;
        }

        void AddToContext(TTObjectContext objectContext, TTObject[] arrTTObject)
        {
            if (arrTTObject != null)
            {
                foreach (var item in arrTTObject)
                {
                    objectContext.AddObject(item);
                }
            }
        }

        [HttpPost]
        public void HCNewForm(HCNewFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var healthCommittee = (HealthCommittee)objectContext.AddObject(viewModel._HealthCommittee);

                if (healthCommittee.ClinicHeight < 0)
                    throw new Exception("Boy bilgisi negatif olamaz");

                if (healthCommittee.ClinicWeight < 0)
                    throw new Exception("Kilo bilgisi negatif olamaz");

                //   healthCommittee.CurrentStateDefID = HealthCommittee.States.New;
                healthCommittee.ActionDate = Common.RecTime();
                // healthCommittee.MasterAction = patientAdmission;
                //  healthCommittee.FromResource = viewModel.Policlinic;
                AddToContext(objectContext, viewModel.HCRequestReasons);
                AddToContext(objectContext, viewModel.Episodes);
                //   healthCommittee.HCRequestReason = viewModel._HealthCommittee.HCRequestReason;
                //PA'nın firedEpisodeAction'ı Episode dan önce set edilmeli. Buradaki sıra önemli
                // patientAdmission.FiredEpisodeActions.Add(this);
                // healthCommittee.Episode = viewModel._HealthCommittee.Episode;
                healthCommittee.WhoPays = viewModel._HealthCommittee.WhoPays;
                if (viewModel.HospitalsUnitsGridListPre != null)
                {
                    List<BaseHealthCommittee_HospitalsUnitsGrid> hospitalsUnitsPreImportedList = new List<BaseHealthCommittee_HospitalsUnitsGrid>();
                    
                    foreach (var item in viewModel.HospitalsUnitsGridListPre)
                    {
                        var hospitalsUnitsPreImported = (BaseHealthCommittee_HospitalsUnitsGrid)objectContext.AddObject(item);
                        hospitalsUnitsPreImported.BaseHealthCommittee = healthCommittee;
                        hospitalsUnitsPreImportedList.Add(hospitalsUnitsPreImported);
                    }

                    foreach (var item in viewModel.HospitalsUnitsGridList)
                    {
                        var hospitalsUnitsImported = (BaseHealthCommittee_HospitalsUnitsGrid)objectContext.AddObject(item);
                        if (((ITTObject)hospitalsUnitsImported).IsDeleted)
                            continue;
                        hospitalsUnitsImported.BaseHealthCommittee = healthCommittee;
                        if (!hospitalsUnitsPreImportedList.Contains(hospitalsUnitsImported))
                        {
                            EpisodeAction.ForkHealthCommitteeExamination((HospitalsUnitsGrid)hospitalsUnitsImported, healthCommittee);
                        }
                    }
                }

                if (viewModel.ExternalDoctorsGridList != null)
                {
                    foreach (var item in viewModel.ExternalDoctorsGridList)
                    {
                        var externalDoctorsImported = (BaseHealthCommittee_ExtDoctorGrid)objectContext.AddObject(item);
                        if (((ITTObject)externalDoctorsImported).IsDeleted)
                            continue;
                        externalDoctorsImported.BaseHealthCommittee = healthCommittee;
                    }
                }

                if (viewModel.MembersGridList != null)
                {
                    foreach (var item in viewModel.MembersGridList)
                    {
                        var hcMember = (MemberOfHealthCommiittee)objectContext.AddObject(item);
                        if (((ITTObject)hcMember).IsDeleted)
                            continue;
                        hcMember.HealthCommittee = healthCommittee;
                    }
                }

                //if (viewModel.ExternalDoctorsGridList != null)
                //{
                //    foreach (var item in viewModel.ExternalDoctorsGridList)
                //    {
                //        var externalDoctorsImported = (BaseHealthCommittee_ExtDoctorGrid)objectContext.GetLoadedObject(item.ObjectID);
                //        if (((ITTObject)externalDoctorsImported).IsDeleted)
                //            continue;
                //        externalDoctorsImported.BaseHealthCommittee = healthCommittee;
                //    }
                //}

                if (healthCommittee.TransDef != null && healthCommittee.TransDef.ToStateDefID == HealthCommittee.States.CommitteeAcceptance)
                {
                    if (viewModel.IsUnCompletedExaminationExists)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(501));
                    else
                    {
                        healthCommittee.CurrentStateDefID = HealthCommittee.States.CommitteeAcceptance;
                        objectContext.Update();
                    }

                    if (healthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)//E-sağlık kurulu
                    {
                        EDisabledReport eDisabledReport = null;
                        foreach (EpisodeAction episodeAction in healthCommittee.LinkedActions)
                        {
                            if (episodeAction is PatientExamination)
                            {
                                if (((PatientExamination)episodeAction).HCExaminationComponent != null)
                                {
                                    //eDisabledReport = ((PatientExamination)episodeAction).HCExaminationComponent.EDisabledReport;
                                    eDisabledReport = objectContext.GetObject<EDisabledReport>(((PatientExamination)episodeAction).HCExaminationComponent.EDisabledReport.ObjectID);
                                    break;
                                }
                            }
                        }
                        bool reportSave = true;
                        if(eDisabledReport.IsCozgerReport != true)
                            reportSave = EDisabledReportServiceController.SendToCouncil(eDisabledReport, objectContext);
                        else
                            reportSave = EDisabledReportServiceController.SendCozgerToCouncil(eDisabledReport, objectContext);
                        if (reportSave == false)
                            throw new TTUtils.TTException("E-Rapor servisinde Kurula alınırken bir hata oluştu!");
                    }
                    else
                    {
                        EStatusNotRepCommitteeObj eStatusNotRepCommitteeObj = null;
                        foreach (EpisodeAction episodeAction in healthCommittee.LinkedActions)
                        {
                            if (episodeAction is PatientExamination)
                            {
                                if (((PatientExamination)episodeAction).HCExaminationComponent != null)
                                {
                                    //eDisabledReport = ((PatientExamination)episodeAction).HCExaminationComponent.EDisabledReport;
                                    if (((PatientExamination)episodeAction).HCExaminationComponent.EStatusNotRepCommitteeObj != null)
                                    {
                                        eStatusNotRepCommitteeObj = objectContext.GetObject<EStatusNotRepCommitteeObj>(((PatientExamination)episodeAction).HCExaminationComponent.EStatusNotRepCommitteeObj.ObjectID);
                                        break;
                                    }

                                }
                            }
                        }
                        string entegrasyonAktif = TTObjectClasses.SystemParameter.GetParameterValue("EDURUMBILDIRIRKURULENTAKTIF", "FALSE");
                        if (entegrasyonAktif == "TRUE" && eStatusNotRepCommitteeObj != null && eStatusNotRepCommitteeObj.PatientApplicationID != null && healthCommittee.HCRequestReason.ReasonForExamination.IntegratedReporting == true)
                        {
                            bool isSent = EDurumBildirirKurulServiceController.SendPatientToEDurumBildirirCouncil(healthCommittee.Episode.Patient.UniqueRefNo.ToString(),eStatusNotRepCommitteeObj, objectContext);
                            if (isSent == false)
                                throw new TTUtils.TTException("E-Rapor servisinde Kayıt Silinirken bir hata oluştu!");
                        }
                        else
                        {
                            objectContext.Save();
                        }
                    }

                }
                else if (healthCommittee.TransDef != null && healthCommittee.TransDef.ToStateDefID == HealthCommittee.States.Cancelled)
                {
                    if (healthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled != true)//E-sağlık kurulu
                    {
                        EStatusNotRepCommitteeObj eStatusNotRepCommitteeObj = null;
                        foreach (EpisodeAction episodeAction in healthCommittee.LinkedActions)
                        {
                            if (episodeAction is PatientExamination)
                            {
                                if (((PatientExamination)episodeAction).HCExaminationComponent != null)
                                {
                                    //eDisabledReport = ((PatientExamination)episodeAction).HCExaminationComponent.EDisabledReport;
                                    if (((PatientExamination)episodeAction).HCExaminationComponent.EStatusNotRepCommitteeObj != null)
                                    {
                                        eStatusNotRepCommitteeObj = objectContext.GetObject<EStatusNotRepCommitteeObj>(((PatientExamination)episodeAction).HCExaminationComponent.EStatusNotRepCommitteeObj.ObjectID);
                                        break;
                                    }

                                }
                            }
                        }
                        string entegrasyonAktif = TTObjectClasses.SystemParameter.GetParameterValue("EDURUMBILDIRIRKURULENTAKTIF", "FALSE");
                        if (entegrasyonAktif == "TRUE" && eStatusNotRepCommitteeObj != null && eStatusNotRepCommitteeObj.PatientApplicationID != null && healthCommittee.HCRequestReason.ReasonForExamination.IntegratedReporting == true)
                        {
                            bool isDeleted = EDurumBildirirKurulServiceController.DeleteEDurumBildirirKurulApplication(eStatusNotRepCommitteeObj, objectContext);
                            if (isDeleted == false)
                                throw new TTUtils.TTException("E-Rapor servisinde Kayıt Silinirken bir hata oluştu!");
                        }
                        else
                        {
                            objectContext.Save();
                        }
                    }
                    else
                    {
                        objectContext.Save();
                    }
                }
                else
                {
                    //ArrangeHCMemeber(objectContext, viewModel);
                    objectContext.Save();
                }
                if (healthCommittee.CurrentStateDefID == HealthCommittee.States.CommitteeAcceptance)
                {
                    if (healthCommittee.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true && healthCommittee.IntendedUseOfDisabledReport == null)
                    {
                        IntendedUseOfDisabledReport intendedUseOfDisabledReport = new IntendedUseOfDisabledReport(objectContext);
                        healthCommittee.IntendedUseOfDisabledReport = intendedUseOfDisabledReport;
                        string HCReportIntendedUseEvaluation = TTObjectClasses.SystemParameter.GetParameterValue("HCREPORTINTENDEDUSEEVALUATION", null);
                        if (HCReportIntendedUseEvaluation == TTUtils.CultureService.GetText("M25395", "Değerlendirilmedi"))
                        {
                            healthCommittee.IntendedUseOfDisabledReport.EducationEvaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                            healthCommittee.IntendedUseOfDisabledReport.EmploymentEvaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                            healthCommittee.IntendedUseOfDisabledReport.SocialAidEvaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                            healthCommittee.IntendedUseOfDisabledReport.OrtesisProsthesEquEvaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                            healthCommittee.IntendedUseOfDisabledReport.DisabledChaiEvaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                            healthCommittee.IntendedUseOfDisabledReport.DisabledIdentityCardEvalution = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                            healthCommittee.IntendedUseOfDisabledReport.LawNo2022Evaluation = EvetHayirDegerlendirilmediEnum.Degerlendirilmedi;
                        }
                        else if (HCReportIntendedUseEvaluation == TTUtils.CultureService.GetText("M15570", "Hayır"))
                        {
                            healthCommittee.IntendedUseOfDisabledReport.EducationEvaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                            healthCommittee.IntendedUseOfDisabledReport.EmploymentEvaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                            healthCommittee.IntendedUseOfDisabledReport.SocialAidEvaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                            healthCommittee.IntendedUseOfDisabledReport.OrtesisProsthesEquEvaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                            healthCommittee.IntendedUseOfDisabledReport.DisabledChaiEvaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                            healthCommittee.IntendedUseOfDisabledReport.DisabledIdentityCardEvalution = EvetHayirDegerlendirilmediEnum.Hayir;
                            healthCommittee.IntendedUseOfDisabledReport.LawNo2022Evaluation = EvetHayirDegerlendirilmediEnum.Hayir;
                        }
                    }

                    healthCommittee.CurrentStateDefID = HealthCommittee.States.Report;
                    //ArrangeHCMemeber(objectContext, viewModel);
                    objectContext.Save();
                }

            }
        }

        public void ArrangeHCMemeber(TTObjectContext objContext, HCNewFormViewModel viewModel)
        {
            if (viewModel.MembersGridList != null)
            {
                //viewModel._HealthCommittee.HCRequestReason.ReasonForExamination.MemberOfHealthCommittee=new MemberOfHealthCommitteeDefinition
                HealthCommittee hc = objContext.GetLoadedObject(viewModel._HealthCommittee.ObjectID) as HealthCommittee;
                //MemberOfHealthCommitteeDefinition hcRequestReason = objContext.GetObject(hc.HCRequestReason.ReasonForExamination.MemberOfHealthCommittee.ObjectID, typeof(MemberOfHealthCommitteeDefinition)) as MemberOfHealthCommitteeDefinition;

                while (hc.HCRequestReason.ReasonForExamination.MemberOfHealthCommittee.Members.Count > 0)
                {
                    hc.HCRequestReason.ReasonForExamination.MemberOfHealthCommittee.Members.RemoveAt(0);
                }

                //foreach (var item in viewModel.MembersGridList)
                //{
                //    HealthCommitteMemberGrid hcm = new HealthCommitteMemberGrid();
                //    hcm.Doctor = item.MemberDoctor;
                //    hcm.Unit = "4343ba13-18e6-40b4-b374-d2d502b57a92";
                //    hcm.Unit.Brans = item.Speciality;

                //    var hcMember = (HealthCommitteMemberGrid)objContext.AddObject(item);
                //    if (((ITTObject)hcMember).IsDeleted)
                //        continue;
                //    hcRequestReason.Members.Add(hcMember);
                //}
            }
            //objContext.Save();
            if (viewModel._HealthCommittee.HCRequestReason.ReasonForExamination.MemberOfHealthCommittee.Members != null)
            {

            }
        }

        [HttpGet]
        public HCRequestReasonDetail GetHCRequestReasonDetails(Guid requestReasonObjectID)
        {
            //
            ReasonForExaminationDefinition reasonForExamination = new ReasonForExaminationDefinition();
            HCRequestReasonDetail requestReasonDetail = new HCRequestReasonDetail();
            requestReasonDetail.HospitalsUnits = new List<HCHospitalUnit>();
            using (TTObjectContext context = new TTObjectContext(false))
            {
                HCRequestReason hcRequestReason = context.GetObject(requestReasonObjectID, typeof(HCRequestReason)) as HCRequestReason;
                if (hcRequestReason.ReasonForExamination != null)
                {
                    requestReasonDetail.ReasonForExaminationDefinition = hcRequestReason.ReasonForExamination;
                    foreach (HospitalsUnitsDefinitionGrid hospitalUnit in hcRequestReason.ReasonForExamination.HospitalsUnits)
                    {
                        HCHospitalUnit hcHospitalUnit = new HCHospitalUnit();
                        hcHospitalUnit.HospitalsUnit = hospitalUnit;
                        hcHospitalUnit.Policlinic = hospitalUnit.Policklinic;
                        hcHospitalUnit.ProcedureDoctor = hospitalUnit.ProcedureDoctor;
                        // hcHospitalUnit.AdmissionQueueNumber =  zaten burda yeni eklendiği için sıra numarası olmaz
                        requestReasonDetail.HospitalsUnits.Add(hcHospitalUnit);
                    }
                }
            }

            return requestReasonDetail;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<HCCommissionList> GetHcCommissionList()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<HCCommissionList> commissionList = new List<HCCommissionList>();

               BindingList<MemberOfHealthCommitteeDefinition.GetMemberOfHealthCommitteeDefinition_Class> getMemberOfHealth = MemberOfHealthCommitteeDefinition.GetMemberOfHealthCommitteeDefinition("");

                foreach (var item in getMemberOfHealth)
                {
                    HCCommissionList commission = new HCCommissionList();

                    commission.ObjectID = item.ObjectID.Value;
                    commission.Name = item.CommitteeName + " - " + item.GroupNo;
                    commissionList.Add(commission);

                }
                return commissionList;
            }
        }
    }
}

namespace Core.Models
{
    public class HCNewFormViewModel
    {
        public TTObjectClasses.HealthCommittee _HealthCommittee
        {
            get;
            set;
        }

        public TTObjectClasses.BaseHealthCommittee_HospitalsUnitsGrid[] HospitalsUnitsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.BaseHealthCommittee_HospitalsUnitsGrid[] HospitalsUnitsGridListPre
        {
            get;
            set;
        }

        public TTObjectClasses.BaseHealthCommittee_ExtDoctorGrid[] ExternalDoctorsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.MemberOfHealthCommiittee[] MembersGridList
        {
            get;
            set;
        }

        public List<TTObjectClasses.EpisodeAction> LinkedActions
        {
            get;
            set;
        }

        public TTObjectClasses.HCRequestReason[] HCRequestReasons
        {
            get;
            set;
        }

        public TTObjectClasses.ReasonForExaminationDefinition[] ReasonForExaminationDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }

        public HCRequestReasonDetail HCRequestReasonDetail;
        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.SubEpisode[] SubEpisode
        {
            get;
            set;
        }

        public List<SubEpisode> SubEpisodeList = new List<SubEpisode>();
        public List<SubEpisodeProtocol> SubEpisodeProtocolList = new List<SubEpisodeProtocol>();
        public bool IsUnCompletedExaminationExists
        {
            get;
            set;
        }

        public SpecialityDefinition[] SpecialityDefinitionsList
        {
            get;
            set;
        }

        public ResUser.GetDoctorandTechnicianList_Class[] DoctorandTechnicianList
        {
            get;
            set;
        }
        public List<HCExaminationComponent> HCExaminationComponents { get; set; }


        public bool IsDisabled { get; set; }
    }

    public class HCCommissionList {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
    }
}