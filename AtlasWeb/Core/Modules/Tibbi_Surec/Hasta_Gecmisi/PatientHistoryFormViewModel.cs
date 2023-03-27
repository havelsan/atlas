using System;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using TTDefinitionManagement;
using System.Linq;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Core.Modules.Tibbi_Surec.Tetkik_Istem_Modulu;
using Core.Security;
using TTStorageManager.Security;

namespace Core.Controllers
{
    public partial class PatientHistoryServiceController : Controller
    {

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string GetTeleTIPUrl(string patientUniqueRefNo)
        {
            try
            {
                String userName = TTObjectClasses.SystemParameter.GetParameterValue("GAZILERFIZIKTEDAVITELETIPUSERNAME", "XXXXXX");
                String password = TTObjectClasses.SystemParameter.GetParameterValue("GAZILERFIZIKTEDAVITELETIPPASSWORD", "XXXXXX");
                var user = TTUser.CurrentUser;

                string UrlGuid = TeletipGuidServis.WebMethods.CreateGuidWithTcNoAndAccNoSync(Sites.SiteLocalHost, userName, null, user.UniqueRefNo.ToString(), patientUniqueRefNo, null, null);
                if (UrlGuid == "0001" || UrlGuid == "1")
                    throw new Exception(TTUtils.CultureService.GetText("M25719", "Girilen Tc No'ları formata uygun değildir. (Numerik 11 karakter)"));
                else if (UrlGuid == "0002" || UrlGuid == "2")
                    throw new Exception(TTUtils.CultureService.GetText("M25717", "Girilen kullanıcı CKYS'de tanımlı değildir."));
                else if (UrlGuid == "0003" || UrlGuid == "3")
                    throw new Exception(TTUtils.CultureService.GetText("M25720", "Girilen Tc No'sına ait bir hasta bulunmamaktadır."));
                else if (UrlGuid == "0004" || UrlGuid == "4")
                    throw new Exception(TTUtils.CultureService.GetText("M25716", "Girilen Acc No’sına ait bir tetkik bulunmamaktadır."));
                else if (UrlGuid == "0005" || UrlGuid == "5")
                    throw new Exception(TTUtils.CultureService.GetText("M26892", "Sistem hatası."));
                else if (UrlGuid == "0006" || UrlGuid == "6")
                    throw new Exception(TTUtils.CultureService.GetText("M25718", "Girilen RequestingUserTc kayıtlı bir doktor değildir."));

                return UrlGuid;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public PatientHistoryFormViewModel PatientHistoryForm(Guid? id)
        {
            var FormDefID = Guid.Parse("a1c90338-f14d-4bf6-b191-c9b63eef5898");
            var ObjectDefID = Guid.Parse("d7eb5879-8ccd-4576-b46b-1b2cea89f549");
            var viewModel = new PatientHistoryFormViewModel();
            string policlinicFormDefId = "66986b55-231c-4c64-ab24-742c241c67fb";
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel.PatientId = id;
                    /*Poliklinik/Ayaktan Hasta Geçmişi*/
                    BindingList<PhysicianApplication.GetOldInfoForPoliclinic_Class> policlinicList = PhysicianApplication.GetOldInfoForPoliclinic(id.Value);
                    viewModel.PoliclinicProcessTitle = new List<ProcessTitle>();
                    foreach (var item in policlinicList)
                    {
                        ProcessTitle processTitle = new ProcessTitle
                        {
                            ObjectID = item.ObjectID.ToString(),
                            ObjectDefName = item.Defname,
                            FormDefId = policlinicFormDefId,
                            RequestDate = item.RequestDate,
                            DoctorName = item.Doktor,
                            SpecialityName = item.Uzmanlik
                        };
                        viewModel.PoliclinicProcessTitle.Add(processTitle);
                    }

                    /*Klinik/Yatan Hasta Geçmişi*/
                    BindingList<InPatientPhysicianApplication.GetOldInfoForClinic_Class> clinicList = InPatientPhysicianApplication.GetOldInfoForClinic(id.Value);
                    viewModel.ClinicProcessTitle = new List<ProcessTitle>();
                    foreach (var item in clinicList)
                    {
                        ProcessTitle processTitle = new ProcessTitle
                        {
                            ObjectID = item.ObjectID.ToString(),
                            ObjectDefName = item.Defname,
                            FormDefId = policlinicFormDefId,
                            RequestDate = item.Requestdate,
                            DoctorName = item.Doktor,
                            SpecialityName = item.Uzmanlik
                        };
                        viewModel.ClinicProcessTitle.Add(processTitle);
                    }

                    /*Tanı Geçmişi Count*/
                    BindingList<DiagnosisGrid.GetOldInfoCountForDiagnosis_Class> diagnosisCount = DiagnosisGrid.GetOldInfoCountForDiagnosis(id.Value);
                    viewModel.DiagnosisCount = Convert.ToInt32(diagnosisCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*Radyoloji Geçmişi Count*/
                    BindingList<RadiologyTest.GetOldInfoCountRadiology_Class> radiologyCount = RadiologyTest.GetOldInfoCountRadiology(id.Value);
                    viewModel.RadiologyCount = Convert.ToInt32(radiologyCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*Laboratuar Geçmişi Count*/
                    BindingList<LaboratoryProcedure.GetOldInfoCountLaboratory_Class> laboratoryCount = LaboratoryProcedure.GetOldInfoCountLaboratory(id.Value);
                    viewModel.LaboratoryCount = Convert.ToInt32(radiologyCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*Patoloji Geçmişi Count*/
                    BindingList<Pathology.GetOldInfoCountPathology_Class> pathologyCount = Pathology.GetOldInfoCountPathology(id.Value);
                    viewModel.PathologyCount = Convert.ToInt32(pathologyCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*İlaç Geçmişi Count*/
                    BindingList<DrugOrder.GetOldInfoForDrugOrderCount_Class> drugCount = DrugOrder.GetOldInfoForDrugOrderCount(id.Value);
                    viewModel.DrugOrderCount = Convert.ToInt32(drugCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*Ameliyat Geçmişi*/
                    BindingList<EpisodeActionWithDiagnosis.GetOldInfoForSurgery_Class> surgery = EpisodeActionWithDiagnosis.GetOldInfoForSurgery(id.Value);
                    viewModel.SurgeryTitles = new List<ProcessTitleWithSubTitles>();
                    foreach (var item in surgery.Where(c => c.Defname == "SURGERY"))
                    {
                        var selectedSubSurgery = surgery.Where(c => c.Defname == "SUBSURGERY").Where(c => c.Surgeryobjectid == item.ObjectID);
                        List<ProcessTitle> subSurgeryList = new List<ProcessTitle>();
                        foreach (var subsurgery in selectedSubSurgery)
                        {
                            ProcessTitle subProcessTitle = new ProcessTitle { RequestDate = subsurgery.SurgeryStartTime, SpecialityName = subsurgery.Name };
                            subSurgeryList.Add(subProcessTitle);
                        }

                        ProcessTitleWithSubTitles surgeryTitle = new ProcessTitleWithSubTitles { ObjectID = item.ObjectID.ToString(), ObjectDefName = item.Defname, RequestDate = item.SurgeryStartTime, SpecialityName = item.Name, SubTitles = subSurgeryList };
                        viewModel.SurgeryTitles.Add(surgeryTitle);
                    }

                    /*Önemli Tıbbi Bilgiler*/
                    BindingList<Patient.GetOldInfoForImportantMedicalInfo_Class> importantMedicalInfo = Patient.GetOldInfoForImportantMedicalInfo(id.Value);
                    if (importantMedicalInfo.Count() > 0)
                    {
                        viewModel.ImportantMedicalInformation = new ProcessTitle
                        {
                            ObjectID = importantMedicalInfo.FirstOrDefault().ObjectID.ToString(),
                            ObjectDefName = importantMedicalInfo.FirstOrDefault().Defname
                        };
                    }

                    /*Aşı Geçmişi Count*/
                    BindingList<VaccineDetails.GetOldInfoCountForVaccine_Class> vaccineCount = VaccineDetails.GetOldInfoCountForVaccine(id.Value);
                    viewModel.VaccineCount = Convert.ToInt32(vaccineCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*Uzmanlık Modulleri*/
                    BindingList<SpecialityBasedObject.GetOldInfoForSpeciality_Class> speciality = SpecialityBasedObject.GetOldInfoForSpeciality(id.Value);
                    viewModel.SpecialityTitles = new List<ProcessTitleWithSubTitles>();
                    foreach (var item in speciality.GroupBy(c => c.Objectdef))
                    {
                        var selectedSpeciality = speciality.Where(x => x.Objectdef == item.Key);
                        List<ProcessTitle> subSpecialityList = new List<ProcessTitle>();
                        foreach (var subSpeciality in selectedSpeciality)
                        {
                            ProcessTitle subTitle = new ProcessTitle
                            {
                                DoctorName = subSpeciality.Doctor,
                                ObjectDefName = subSpeciality.Objectdef,
                                ObjectID = subSpeciality.ObjectID.ToString(),
                                RequestDate = subSpeciality.RequestDate,
                                SpecialityName = subSpeciality.DisplayText
                            };
                            subSpecialityList.Add(subTitle);
                        }

                        ProcessTitleWithSubTitles specialityTitle = new ProcessTitleWithSubTitles
                        {
                            SpecialityName = item.FirstOrDefault().DisplayText,
                            SubTitles = subSpecialityList
                        };
                        viewModel.SpecialityTitles.Add(specialityTitle);
                    }

                    /*Hizmet ve Tetkik Count*/
                    BindingList<SubActionProcedure.GetOldInfoCountForRequestedProcedures_Class> requestedProcedures = SubActionProcedure.GetOldInfoCountForRequestedProcedures(id.Value);
                    viewModel.RequestedProceduresCount = Convert.ToInt32(requestedProcedures.FirstOrDefault().Nqlcolumn.ToString());

                    /*Malzeme ve Sarf Count*/
                    BindingList<BaseTreatmentMaterial.GetOldInfoCountForTreatmentMaterial_Class> treatmentMaterials = BaseTreatmentMaterial.GetOldInfoCountForTreatmentMaterial(id.Value);
                    viewModel.TreatmentMaterialsCount = treatmentMaterials.Sum(x => Convert.ToInt32(x.Nqlcolumn));

                    /*Acil*/
                    BindingList<EmergencySpecialityObject.GetOldInfoForEmergencySpecialityForm_Class> emergencyList = EmergencySpecialityObject.GetOldInfoForEmergencySpecialityForm(id.Value);
                    viewModel.EmergencyObjectTitle = new List<ProcessTitle>();
                    foreach (var item in emergencyList)
                    {
                        ProcessTitle processTitle = new ProcessTitle
                        {
                            ObjectID = item.ObjectID.ToString(),
                            ObjectDefName = item.Defname,
                            DoctorName = item.Doctor,
                            RequestDate = item.RequestDate
                        };
                        viewModel.EmergencyObjectTitle.Add(processTitle);
                    }

                    /*Diyet Count*/
                    BindingList<DietOrderDetail.GetOldInfoCountForDietOrder_Class> dietOrders = DietOrderDetail.GetOldInfoCountForDietOrder(id.Value);
                    viewModel.DietOrdersCount = Convert.ToInt32(dietOrders.FirstOrDefault().Nqlcolumn.ToString());


                    /*Fizyoterapi Hasta Geçmişi*/
                    BindingList<PhysiotherapyRequest.GetOldInfoForPhysiotherapyRequest_Class> physiotherapyList = PhysiotherapyRequest.GetOldInfoForPhysiotherapyRequest(id.Value);
                    viewModel.PhysiotherapyRequestsTitles = new List<ProcessTitle>();
                    foreach (var item in physiotherapyList)
                    {
                        ProcessTitle processTitle = new ProcessTitle
                        {
                            ObjectID = item.ObjectID.ToString(),
                            ObjectDefName = item.Defname,
                            FormDefId = policlinicFormDefId,
                            RequestDate = item.PhysiotherapyRequestDate,
                            DoctorName = item.Doctor,
                            SpecialityName = item.Fromresource
                        };
                        viewModel.PhysiotherapyRequestsTitles.Add(processTitle);
                    }




                    /*Kabul Bazlı Poliklinik/Ayaktan Hasta Geçmişi    ***********************************************************************/
                    BindingList<SubEpisode.GetOldInfoForSubEpisode_Class> patienSubEpisodeList = SubEpisode.GetOldInfoForSubEpisode(id.Value);
                    viewModel.PatientHistoryBySubEpisode = new List<ProcessTitle>();
                    foreach (var item in patienSubEpisodeList)
                    {
                        ProcessTitle patienSubEpisodeTitle = new ProcessTitle { DoctorName = item.Doctorname, ObjectID = item.ObjectID.ToString(), RequestDate = item.OpeningDate, SpecialityName = item.Specialityname };
                        viewModel.PatientHistoryBySubEpisode.Add(patienSubEpisodeTitle);
                    }

                    /*Manipulasyon Geçmişi*/
                    BindingList<Manipulation.GetOldInfoForManipulation_Class> manipulationList = Manipulation.GetOldInfoForManipulation(id.Value);
                    viewModel.ManipulationProcessTitle = new List<ProcessTitle>();
                    foreach (var item in manipulationList)
                    {
                        ProcessTitle processTitle = new ProcessTitle
                        {
                            ObjectID = item.ObjectID.ToString(),
                            ObjectDefName = item.Defname,
                            RequestDate = item.RequestDate,
                            DoctorName = item.Doktor,
                            SpecialityName = item.Uzmanlik

                        };
                        viewModel.ManipulationProcessTitle.Add(processTitle);
                    }


                    Patient p = (Patient)objectContext.GetObject((Guid)viewModel.PatientId, "Patient");

                    //Yabanci uyruklu hasta ise PasaportNo gonderilecek
                    string TCKimlikNo;
                    if (p.UniqueRefNo != null)
                        TCKimlikNo = Convert.ToString(p.UniqueRefNo);
                    else if (p.PassportNo != null)
                        TCKimlikNo = p.PassportNo.ToString();
                    else
                        TCKimlikNo = "10000000000";

                    //viewModel.AllProceduresLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?tc=" + TCKimlikNo + "&usr=extreme";
                    if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "EXTREME")
                    {
                        viewModel.AllProceduresLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?tc=" + TCKimlikNo + "&usr=extreme";

                    }
                    else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "COMPANY1") == "COMPANY2")
                    {
                        viewModel.AllProceduresLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?patientid=" + TCKimlikNo + "&ietab=true";
                    }
                    else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "XXXXXX")
                    {
                        viewModel.AllProceduresLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?Patientid=" + TCKimlikNo + "&StudyReload=1";
                    }


                    viewModel.AllLabProceduresLink = ProcedureRequestServiceController.GetURLForAllEpisodeTestResultsForPatientHistory(TCKimlikNo);
                    viewModel.PatientUniqueRefNo = p.UniqueRefNo.ToString();

                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    //viewModel.patientObjectId = new Guid("f2820174-fe97-4814-91a2-8bbb0b575d96");
                    ///*Poliklinik/Ayaktan Hasta Geçmişi*/
                    //BindingList<PhysicianApplication.GetOldInfoForPoliclinic_Class> policlinicList = PhysicianApplication.GetOldInfoForPoliclinic(viewModel.patientObjectId);
                    //viewModel.PoliclinicProcessTitle = new List<ProcessTitle>();
                    //foreach (var item in policlinicList)
                    //{
                    //    ProcessTitle processTitle = new ProcessTitle
                    //    {
                    //        ObjectID = item.ObjectID.ToString(),
                    //        ObjectDefName = item.Defname,
                    //        FormDefId = policlinicFormDefId,
                    //        RequestDate = item.RequestDate,
                    //        DoctorName = item.Uzmanlik,
                    //        SpecialityName = item.Doktor
                    //    };
                    //    viewModel.PoliclinicProcessTitle.Add(processTitle);
                    //}
                    ///*Klinik/Yatan Hasta Geçmişi*/
                    //BindingList<InPatientPhysicianApplication.GetOldInfoForClinic_Class> clinicList = InPatientPhysicianApplication.GetOldInfoForClinic(viewModel.patientObjectId);
                    //viewModel.ClinicProcessTitle = new List<ProcessTitle>();
                    //foreach (var item in clinicList)
                    //{
                    //    ProcessTitle processTitle = new ProcessTitle
                    //    {
                    //        ObjectID = item.ObjectID.ToString(),
                    //        ObjectDefName = item.Defname,
                    //        FormDefId = policlinicFormDefId,
                    //        RequestDate = item.Requestdate,
                    //        DoctorName = item.Uzmanlik,
                    //        SpecialityName = item.Doktor
                    //    };
                    //    viewModel.ClinicProcessTitle.Add(processTitle);
                    //}
                }
            }

            return viewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public PatientHistoryFormViewModel PatientHistoryFormByEpisode(Guid? id)
        {
            var FormDefID = Guid.Parse("a1c90338-f14d-4bf6-b191-c9b63eef5898");
            var ObjectDefID = Guid.Parse("d7eb5879-8ccd-4576-b46b-1b2cea89f549");
            var viewModel = new PatientHistoryFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel.EpisodeId = id;


                    /*Kabul Bazlı Poliklinik/Ayaktan Hasta Geçmişi    ***********************************************************************/
                    BindingList<SubEpisode.GetOldInfoForSubEpisodeByEpisode_Class> patienSubEpisodeList = SubEpisode.GetOldInfoForSubEpisodeByEpisode(id.Value);
                    viewModel.PatientHistoryBySubEpisode = new List<ProcessTitle>();
                    foreach (var item in patienSubEpisodeList)
                    {
                        ProcessTitle patientSubEpisodeTitle = new ProcessTitle { DoctorName = item.Doctorname, ObjectID = item.ObjectID.ToString(), RequestDate = item.OpeningDate, SpecialityName = item.Specialityname };
                        viewModel.PatientHistoryBySubEpisode.Add(patientSubEpisodeTitle);
                    }

                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    //viewModel.patientObjectId = new Guid("f2820174-fe97-4814-91a2-8bbb0b575d96");
                    ///*Poliklinik/Ayaktan Hasta Geçmişi*/
                    //BindingList<PhysicianApplication.GetOldInfoForPoliclinic_Class> policlinicList = PhysicianApplication.GetOldInfoForPoliclinic(viewModel.patientObjectId);
                    //viewModel.PoliclinicProcessTitle = new List<ProcessTitle>();
                    //foreach (var item in policlinicList)
                    //{
                    //    ProcessTitle processTitle = new ProcessTitle
                    //    {
                    //        ObjectID = item.ObjectID.ToString(),
                    //        ObjectDefName = item.Defname,
                    //        FormDefId = policlinicFormDefId,
                    //        RequestDate = item.RequestDate,
                    //        DoctorName = item.Uzmanlik,
                    //        SpecialityName = item.Doktor
                    //    };
                    //    viewModel.PoliclinicProcessTitle.Add(processTitle);
                    //}
                    ///*Klinik/Yatan Hasta Geçmişi*/
                    //BindingList<InPatientPhysicianApplication.GetOldInfoForClinic_Class> clinicList = InPatientPhysicianApplication.GetOldInfoForClinic(viewModel.patientObjectId);
                    //viewModel.ClinicProcessTitle = new List<ProcessTitle>();
                    //foreach (var item in clinicList)
                    //{
                    //    ProcessTitle processTitle = new ProcessTitle
                    //    {
                    //        ObjectID = item.ObjectID.ToString(),
                    //        ObjectDefName = item.Defname,
                    //        FormDefId = policlinicFormDefId,
                    //        RequestDate = item.Requestdate,
                    //        DoctorName = item.Uzmanlik,
                    //        SpecialityName = item.Doktor
                    //    };
                    //    viewModel.ClinicProcessTitle.Add(processTitle);
                    //}
                }
            }

            return viewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public PatientHistoryFormViewModel PatientHistoryFormByProtocolNo(string protocolNo)
        {
            var FormDefID = Guid.Parse("a1c90338-f14d-4bf6-b191-c9b63eef5898");
            var ObjectDefID = Guid.Parse("d7eb5879-8ccd-4576-b46b-1b2cea89f549");
            var viewModel = new PatientHistoryFormViewModel();
            var roContext = new TTObjectContext(true);
            var _subEpisode = SubEpisode.GetByProtocolNo(roContext, protocolNo).FirstOrDefault();
            Guid id = _subEpisode.Episode.Patient.ObjectID;
            string _subEpisodeId = _subEpisode.ObjectID.ToString();
            string policlinicFormDefId = "66986b55-231c-4c64-ab24-742c241c67fb";
            if (id != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id, ObjectDefID);
                    viewModel.PatientId = id;
                    viewModel.SubEpisodeId = _subEpisode.ObjectID.ToString();
                    /*Poliklinik/Ayaktan Hasta Geçmişi*///And SubEpisode=''
                    BindingList<PhysicianApplication.GetOldInfoForPoliclinic_Class> policlinicList = PhysicianApplication.GetOldInfoForPoliclinic(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.PoliclinicProcessTitle = new List<ProcessTitle>();
                    foreach (var item in policlinicList)
                    {
                        ProcessTitle processTitle = new ProcessTitle
                        {
                            ObjectID = item.ObjectID.ToString(),
                            ObjectDefName = item.Defname,
                            FormDefId = policlinicFormDefId,
                            RequestDate = item.RequestDate,
                            DoctorName = item.Doktor,
                            SpecialityName = item.Uzmanlik
                        };
                        viewModel.PoliclinicProcessTitle.Add(processTitle);
                    }

                    /*Klinik/Yatan Hasta Geçmişi*/
                    BindingList<InPatientPhysicianApplication.GetOldInfoForClinic_Class> clinicList = InPatientPhysicianApplication.GetOldInfoForClinic(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.ClinicProcessTitle = new List<ProcessTitle>();
                    foreach (var item in clinicList)
                    {
                        ProcessTitle processTitle = new ProcessTitle
                        {
                            ObjectID = item.ObjectID.ToString(),
                            ObjectDefName = item.Defname,
                            FormDefId = policlinicFormDefId,
                            RequestDate = item.Requestdate,
                            DoctorName = item.Doktor,
                            SpecialityName = item.Uzmanlik
                        };
                        viewModel.ClinicProcessTitle.Add(processTitle);
                    }

                    /*Tanı Geçmişi Count*/
                    BindingList<DiagnosisGrid.GetOldInfoCountForDiagnosis_Class> diagnosisCount = DiagnosisGrid.GetOldInfoCountForDiagnosis(id, "And EpisodeAction.SubEpisode='" + _subEpisodeId + "'");
                    viewModel.DiagnosisCount = Convert.ToInt32(diagnosisCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*Radyoloji Geçmişi Count*/
                    BindingList<RadiologyTest.GetOldInfoCountRadiology_Class> radiologyCount = RadiologyTest.GetOldInfoCountRadiology(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.RadiologyCount = Convert.ToInt32(radiologyCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*Laboratuar Geçmişi Count*/
                    BindingList<LaboratoryProcedure.GetOldInfoCountLaboratory_Class> laboratoryCount = LaboratoryProcedure.GetOldInfoCountLaboratory(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.LaboratoryCount = Convert.ToInt32(radiologyCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*Patoloji Geçmişi Count*/
                    BindingList<Pathology.GetOldInfoCountPathology_Class> pathologyCount = Pathology.GetOldInfoCountPathology(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.PathologyCount = Convert.ToInt32(pathologyCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*İlaç Geçmişi Count*/
                    BindingList<DrugOrder.GetOldInfoForDrugOrderCount_Class> drugCount = DrugOrder.GetOldInfoForDrugOrderCount(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.DrugOrderCount = Convert.ToInt32(drugCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*Ameliyat Geçmişi*/
                    BindingList<EpisodeActionWithDiagnosis.GetOldInfoForSurgery_Class> surgery = EpisodeActionWithDiagnosis.GetOldInfoForSurgery(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.SurgeryTitles = new List<ProcessTitleWithSubTitles>();
                    foreach (var item in surgery.Where(c => c.Defname == "SURGERY"))
                    {
                        var selectedSubSurgery = surgery.Where(c => c.Defname == "SUBSURGERY").Where(c => c.Surgeryobjectid == item.ObjectID);
                        List<ProcessTitle> subSurgeryList = new List<ProcessTitle>();
                        foreach (var subsurgery in selectedSubSurgery)
                        {
                            ProcessTitle subProcessTitle = new ProcessTitle { RequestDate = subsurgery.SurgeryStartTime, SpecialityName = subsurgery.Name };
                            subSurgeryList.Add(subProcessTitle);
                        }

                        ProcessTitleWithSubTitles surgeryTitle = new ProcessTitleWithSubTitles { ObjectID = item.ObjectID.ToString(), ObjectDefName = item.Defname, RequestDate = item.SurgeryStartTime, SpecialityName = item.Name, SubTitles = subSurgeryList };
                        viewModel.SurgeryTitles.Add(surgeryTitle);
                    }

                    /*Önemli Tıbbi Bilgiler*/
                    BindingList<Patient.GetOldInfoForImportantMedicalInfo_Class> importantMedicalInfo = Patient.GetOldInfoForImportantMedicalInfo(id);
                    if (importantMedicalInfo.Count() > 0)
                    {
                        viewModel.ImportantMedicalInformation = new ProcessTitle
                        {
                            ObjectID = importantMedicalInfo.FirstOrDefault().ObjectID.ToString(),
                            ObjectDefName = importantMedicalInfo.FirstOrDefault().Defname
                        };
                    }

                    /*Aşı Geçmişi Count*/
                    BindingList<VaccineDetails.GetOldInfoCountForVaccine_Class> vaccineCount = VaccineDetails.GetOldInfoCountForVaccine(id, "And VaccineFollowUp.SubEpisode='" + _subEpisodeId + "'");
                    viewModel.VaccineCount = Convert.ToInt32(vaccineCount.FirstOrDefault().Nqlcolumn.ToString());

                    /*Uzmanlık Modulleri*/
                    BindingList<SpecialityBasedObject.GetOldInfoForSpeciality_Class> speciality = SpecialityBasedObject.GetOldInfoForSpeciality(id, "And PhysicianApplication.SubEpisode='" + _subEpisodeId + "'");
                    viewModel.SpecialityTitles = new List<ProcessTitleWithSubTitles>();
                    foreach (var item in speciality.GroupBy(c => c.Objectdef))
                    {
                        var selectedSpeciality = speciality.Where(x => x.Objectdef == item.Key);
                        List<ProcessTitle> subSpecialityList = new List<ProcessTitle>();
                        foreach (var subSpeciality in selectedSpeciality)
                        {
                            ProcessTitle subTitle = new ProcessTitle
                            {
                                DoctorName = subSpeciality.Doctor,
                                ObjectDefName = subSpeciality.Objectdef,
                                ObjectID = subSpeciality.ObjectID.ToString(),
                                RequestDate = subSpeciality.RequestDate,
                                SpecialityName = subSpeciality.DisplayText
                            };
                            subSpecialityList.Add(subTitle);
                        }

                        ProcessTitleWithSubTitles specialityTitle = new ProcessTitleWithSubTitles
                        {
                            SpecialityName = item.FirstOrDefault().DisplayText,
                            SubTitles = subSpecialityList
                        };
                        viewModel.SpecialityTitles.Add(specialityTitle);
                    }

                    /*Hizmet ve Tetkik Count*/
                    BindingList<SubActionProcedure.GetOldInfoCountForRequestedProcedures_Class> requestedProcedures = SubActionProcedure.GetOldInfoCountForRequestedProcedures(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.RequestedProceduresCount = Convert.ToInt32(requestedProcedures.FirstOrDefault().Nqlcolumn.ToString());

                    /*Malzeme ve Sarf Count*/
                    BindingList<BaseTreatmentMaterial.GetOldInfoCountForTreatmentMaterial_Class> treatmentMaterials = BaseTreatmentMaterial.GetOldInfoCountForTreatmentMaterial(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.TreatmentMaterialsCount = treatmentMaterials.Sum(x => Convert.ToInt32(x.Nqlcolumn));

                    /*Acil*/
                    BindingList<EmergencySpecialityObject.GetOldInfoForEmergencySpecialityForm_Class> emergencyList = EmergencySpecialityObject.GetOldInfoForEmergencySpecialityForm(id, "And PhysicianApplication.SubEpisode='" + _subEpisodeId + "'");
                    viewModel.EmergencyObjectTitle = new List<ProcessTitle>();
                    foreach (var item in emergencyList)
                    {
                        ProcessTitle processTitle = new ProcessTitle
                        {
                            ObjectID = item.ObjectID.ToString(),
                            ObjectDefName = item.Defname,
                            DoctorName = item.Doctor,
                            RequestDate = item.RequestDate
                        };
                        viewModel.EmergencyObjectTitle.Add(processTitle);
                    }

                    /*Diyet Count*/
                    BindingList<DietOrderDetail.GetOldInfoCountForDietOrder_Class> dietOrders = DietOrderDetail.GetOldInfoCountForDietOrder(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.DietOrdersCount = Convert.ToInt32(dietOrders.FirstOrDefault().Nqlcolumn.ToString());


                    /*Fizyoterapi Hasta Geçmişi*/
                    BindingList<PhysiotherapyRequest.GetOldInfoForPhysiotherapyRequest_Class> physiotherapyList = PhysiotherapyRequest.GetOldInfoForPhysiotherapyRequest(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.PhysiotherapyRequestsTitles = new List<ProcessTitle>();
                    foreach (var item in physiotherapyList)
                    {
                        ProcessTitle processTitle = new ProcessTitle
                        {
                            ObjectID = item.ObjectID.ToString(),
                            ObjectDefName = item.Defname,
                            FormDefId = policlinicFormDefId,
                            RequestDate = item.PhysiotherapyRequestDate,
                            DoctorName = item.Doctor,
                            SpecialityName = item.Fromresource
                        };
                        viewModel.PhysiotherapyRequestsTitles.Add(processTitle);
                    }




                    /*Kabul Bazlı Poliklinik/Ayaktan Hasta Geçmişi    ***********************************************************************/
                    BindingList<SubEpisode.GetOldInfoForSubEpisode_Class> patienSubEpisodeList = SubEpisode.GetOldInfoForSubEpisode(id, "And OBJECTID='" + _subEpisodeId + "'");
                    viewModel.PatientHistoryBySubEpisode = new List<ProcessTitle>();
                    foreach (var item in patienSubEpisodeList)
                    {
                        ProcessTitle patienSubEpisodeTitle = new ProcessTitle { DoctorName = item.Doctorname, ObjectID = item.ObjectID.ToString(), RequestDate = item.OpeningDate, SpecialityName = item.Specialityname };
                        viewModel.PatientHistoryBySubEpisode.Add(patienSubEpisodeTitle);
                    }

                    /*Manipulasyon Geçmişi*/
                    BindingList<Manipulation.GetOldInfoForManipulation_Class> manipulationList = Manipulation.GetOldInfoForManipulation(id, "And SubEpisode='" + _subEpisodeId + "'");
                    viewModel.ManipulationProcessTitle = new List<ProcessTitle>();
                    foreach (var item in manipulationList)
                    {
                        ProcessTitle processTitle = new ProcessTitle
                        {
                            ObjectID = item.ObjectID.ToString(),
                            ObjectDefName = item.Defname,
                            RequestDate = item.RequestDate,
                            DoctorName = item.Doktor,
                            SpecialityName = item.Uzmanlik

                        };
                        viewModel.ManipulationProcessTitle.Add(processTitle);
                    }


                    Patient p = (Patient)objectContext.GetObject((Guid)viewModel.PatientId, "Patient");

                    //Yabanci uyruklu hasta ise PasaportNo gonderilecek
                    string TCKimlikNo;
                    if (p.UniqueRefNo != null)
                        TCKimlikNo = Convert.ToString(p.UniqueRefNo);
                    else if (p.PassportNo != null)
                        TCKimlikNo = p.PassportNo.ToString();
                    else
                        TCKimlikNo = "10000000000";

                    //viewModel.AllProceduresLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?tc=" + TCKimlikNo + "&usr=extreme";
                    if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "EXTREME")
                    {
                        viewModel.AllProceduresLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?tc=" + TCKimlikNo + "&usr=extreme";

                    }
                    else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "COMPANY1") == "COMPANY2")
                    {
                        viewModel.AllProceduresLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?patientid=" + TCKimlikNo + "&ietab=true";
                    }
                    else if (TTObjectClasses.SystemParameter.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "XXXXXX")
                    {
                        viewModel.AllProceduresLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?Patientid=" + TCKimlikNo + "&StudyReload=1";
                    }


                    viewModel.AllLabProceduresLink = ProcedureRequestServiceController.GetURLForAllEpisodeTestResultsForPatientHistory(TCKimlikNo);
                    viewModel.PatientUniqueRefNo = p.UniqueRefNo.ToString();

                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    //viewModel.patientObjectId = new Guid("f2820174-fe97-4814-91a2-8bbb0b575d96");
                    ///*Poliklinik/Ayaktan Hasta Geçmişi*/
                    //BindingList<PhysicianApplication.GetOldInfoForPoliclinic_Class> policlinicList = PhysicianApplication.GetOldInfoForPoliclinic(viewModel.patientObjectId);
                    //viewModel.PoliclinicProcessTitle = new List<ProcessTitle>();
                    //foreach (var item in policlinicList)
                    //{
                    //    ProcessTitle processTitle = new ProcessTitle
                    //    {
                    //        ObjectID = item.ObjectID.ToString(),
                    //        ObjectDefName = item.Defname,
                    //        FormDefId = policlinicFormDefId,
                    //        RequestDate = item.RequestDate,
                    //        DoctorName = item.Uzmanlik,
                    //        SpecialityName = item.Doktor
                    //    };
                    //    viewModel.PoliclinicProcessTitle.Add(processTitle);
                    //}
                    ///*Klinik/Yatan Hasta Geçmişi*/
                    //BindingList<InPatientPhysicianApplication.GetOldInfoForClinic_Class> clinicList = InPatientPhysicianApplication.GetOldInfoForClinic(viewModel.patientObjectId);
                    //viewModel.ClinicProcessTitle = new List<ProcessTitle>();
                    //foreach (var item in clinicList)
                    //{
                    //    ProcessTitle processTitle = new ProcessTitle
                    //    {
                    //        ObjectID = item.ObjectID.ToString(),
                    //        ObjectDefName = item.Defname,
                    //        FormDefId = policlinicFormDefId,
                    //        RequestDate = item.Requestdate,
                    //        DoctorName = item.Uzmanlik,
                    //        SpecialityName = item.Doktor
                    //    };
                    //    viewModel.ClinicProcessTitle.Add(processTitle);
                    //}
                }
            }

            return viewModel;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public void PatientHistoryForm(PatientHistoryFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.Save();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public DynamicComponentInfoDVO GetDynamicComponentInfo([FromQuery] string ObjectId)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                TTObject obj = objectContext.GetObject(new Guid(ObjectId), typeof(EpisodeAction));
                var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
                var folderPath = string.Join("/", subFolders.Reverse());
                var moduleName = obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
                var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                dynamicComponentInfo.ComponentName = obj.CurrentStateDef.FormDef.CodeName;
                dynamicComponentInfo.ModuleName = moduleName;
                dynamicComponentInfo.ModulePath = modulePath;
                dynamicComponentInfo.objectID = ObjectId;
                objectContext.FullPartialllyLoadedObjects();
                return dynamicComponentInfo;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public DynamicComponentInfoDVO GetNewObjectDynamicComponentInfo([FromQuery] string ObjectDefName)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            var objectDefList = TTObjectDefManager.Instance.ObjectDefs;
            var objectDef = objectDefList.Values.Where(d => d.Name.ToUpperInvariant() == ObjectDefName).FirstOrDefault();
            if (objectDef == null)
                return dynamicComponentInfo;
            var subFolders = GetParentFolders(objectDef.ModuleDef);
            var folderPath = string.Join("/", subFolders.Reverse());
            var moduleName = objectDef.ModuleDef.Name.GetTsModuleName();
            var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
            string componentName = string.Empty;
            foreach (TTObjectStateDef state in objectDef.StateDefs)
            {
                if (state.IsEntry)
                {
                    componentName = state.FormDef.CodeName;
                    break;
                }
            }

            dynamicComponentInfo.ComponentName = componentName;
            dynamicComponentInfo.ModuleName = moduleName;
            dynamicComponentInfo.ModulePath = modulePath;
            dynamicComponentInfo.objectID = string.Empty;
            return dynamicComponentInfo;
        }

        internal static IEnumerable<string> GetParentFolders(TTModuleDef moduleDef)
        {
            yield return TTUtils.Globals.GetModuleName(moduleDef.Name);
            Guid? folderDefId = moduleDef.FolderDefID;
            while (folderDefId != null)
            {
                TTFolderDef folderDef = null;
                if (TTObjectDefManager.Instance.FolderDefs.ContainsKey(folderDefId))
                {
                    folderDef = TTObjectDefManager.Instance.FolderDefs[folderDefId];
                    yield return TTUtils.Globals.GetModuleName(folderDef.CodeName);
                    folderDefId = folderDef.ParentFolderDefID;
                }

                if (!folderDefId.HasValue)
                    yield break;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public List<DiagnoseData> GetDiagnosisGrid(Guid id, string subEpisodeId)
        {
            /*Tanı Geçmişi*/
            string where = "";
            if (!String.IsNullOrEmpty(subEpisodeId))
            {
                where = "And EpisodeAction.SubEpisode='" + subEpisodeId + "'";
            }
            BindingList<DiagnosisGrid.GetOldInfoForDiagnosis_Class> diagnoseList = DiagnosisGrid.GetOldInfoForDiagnosis(id, where);
            var viewModel = new PatientHistoryFormViewModel();
            viewModel.DiagnoseDataList = new List<DiagnoseData>();
            foreach (var item in diagnoseList)
            {
                DiagnoseData diagnose = new DiagnoseData
                {
                    DiagnoseCode = item.Code,
                    DiagnoseDate = item.DiagnoseDate.Value.ToString("yyyy/MM/dd HH:mm"),
                    DiagnoseName = item.Diagnosename, //EntryType = item.Entrytype.ToString(),
                    FreeDiagnosis = item.FreeDiagnosis,
                    IsMainDiagnose = item.IsMainDiagnose,
                    ObjectId = item.Diagnoseobjectid,
                    ResponsibleDoctor = item.Doctorname != null ? item.Doctorname : item.Username,
                    Speciality = item.Speciality
                };
                viewModel.DiagnoseDataList.Add(diagnose);
            }

            return viewModel.DiagnoseDataList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public List<RadiologyData> GetRadiologyGrid(Guid id, string subEpisodeId)
        {
            /*Radyoloji Geçmişi*/
            string where = "";
            if (!String.IsNullOrEmpty(subEpisodeId))
            {
                where = "And EpisodeAction.SubEpisode='" + subEpisodeId + "'";
            }
            BindingList<RadiologyTest.GetOldInfoForRadiology_Class> radiologyList = RadiologyTest.GetOldInfoForRadiology(id, where);
            var viewModel = new PatientHistoryFormViewModel();
            viewModel.RadiologyDataList = new List<RadiologyData>();
            foreach (var item in radiologyList)
            {
                RadiologyData radiology = new RadiologyData
                {
                    Doctor = item.Doctor,
                    FromResource = item.Requestedclinic,
                    ReportTxt = item.ReportTxt,
                    RequestDate = item.RequestDate.Value.ToString("yyyy/MM/dd HH:mm"),
                    RequestNumber = item.Requestno.ToString(),
                    TestCode = item.Testcode,
                    TestName = item.Testname,
                    AccesionNumber = item.AccessionNo?.ToString(),
                    ObjectId = item.ObjectID.ToString()
                };
                viewModel.RadiologyDataList.Add(radiology);
            }

            return viewModel.RadiologyDataList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public List<LaboratoryData> GetLaboratoryGrid(Guid id, string subEpisodeId)
        {
            /*Laboratuar Geçmişi*/
            string where = "";
            if (!String.IsNullOrEmpty(subEpisodeId))
            {
                where = "And EpisodeAction.SubEpisode='" + subEpisodeId + "'";
            }
            BindingList<LaboratoryProcedure.GetOldInfoForLaboratory_Class> laboratoryList = LaboratoryProcedure.GetOldInfoForLaboratory(id, where);
            var viewModel = new PatientHistoryFormViewModel();
            viewModel.LaboratoryDataList = new List<LaboratoryData>();
            foreach (var item in laboratoryList)
            {
                LaboratoryData laboratory = new LaboratoryData
                {
                    ApproveDate = item.ApproveDate != null ? item.ApproveDate.Value : (DateTime?)null,
                    RequestDate = item.RequestDate != null ? item.RequestDate.Value : (DateTime?)null,
                    ResultDate = item.ResultDate != null ? item.ResultDate.Value : (DateTime?)null,
                    Reference = item.Reference,
                    SampleDate = item.SampleDate != null ? item.SampleDate.Value : (DateTime?)null,
                    Unit = item.Unit,
                    Result = item.Result,
                    BarcodePrintDate = item.PricingDate != null ? item.PricingDate.Value : (DateTime?)null,
                    BarcodeID = item.BarcodeId != null ? item.BarcodeId.ToString() : "",
                    TestCode = item.SpecimenId != null ? item.SpecimenId.ToString() : "",
                    FromResourceName = item.Fromresource,
                    LaboratoryTestName = item.Name,
                    RequestedByUser = item.Requestedbyuser,
                    SpecimenID = "",
                    TestLoincCode = ""
                };
                viewModel.LaboratoryDataList.Add(laboratory);
            }

            return viewModel.LaboratoryDataList;
        }

        public List<LaboratoryData> GetLaboratoryWithPanelTestsGrid(Guid id, string subEpisodeId)
        {
            /*Laboratuar Geçmişi*/
            string where = "";
            if (!String.IsNullOrEmpty(subEpisodeId))
            {
                where = "And EpisodeAction.SubEpisode='" + subEpisodeId + "'";
            }
            TTObjectContext context = new TTObjectContext(true);
            List<LaboratoryProcedure> laboratoryList = LaboratoryProcedure.GetOldInfoForLaboratoryByPatient(context, id.ToString(), where).ToList();

            var viewModel = new PatientHistoryFormViewModel();
            viewModel.LaboratoryDataList = new List<LaboratoryData>();

            foreach (LaboratoryProcedure item in laboratoryList)
            {
                LaboratoryData laboratory = new LaboratoryData
                {
                    ObjectID = item.ObjectID,
                    ApproveDate = item.ApproveDate != null ? item.ApproveDate.Value : (DateTime?)null,
                    RequestDate = item.RequestDate != null ? item.RequestDate.Value : (DateTime?)null,
                    ResultDate = item.ResultDate != null ? item.ResultDate.Value : (DateTime?)null,
                    Reference = item.Reference,
                    SampleDate = item.SampleDate != null ? item.SampleDate.Value : (DateTime?)null,
                    Unit = item.Unit,
                    Result = item.Result,
                    BarcodePrintDate = item.PricingDate != null ? item.PricingDate.Value : (DateTime?)null,
                    BarcodeID = item.BarcodeId != null ? item.BarcodeId.ToString() : "",
                    TestCode = item.ProcedureObject.Code != null ? item.ProcedureObject.Code.ToString() : "",
                    FromResourceName = item.FromResource.Name,
                    LaboratoryTestName = item.ProcedureObject.Name,
                    RequestedByUser = item.RequestedByUser.Name,
                    SpecimenID = "",
                    TestLoincCode = "",
                    isPanelTest = ((LaboratoryTestDefinition)(item.ProcedureObject)).IsPanel == true ? true : false
                };

                viewModel.LaboratoryDataList.Add(laboratory);
            }

            return viewModel.LaboratoryDataList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public List<DrugOrder.GetOldInfoForDrugOrder_Class> GetDrugOrderGrid(Guid id, string subEpisodeId)
        {
            /*İlaç Geçmişi*/
            string where = "";
            if (!String.IsNullOrEmpty(subEpisodeId))
            {
                where = "And EpisodeAction.SubEpisode='" + subEpisodeId + "'";
            }
            List<DrugOrder.GetOldInfoForDrugOrder_Class> drugOrderList = DrugOrder.GetOldInfoForDrugOrder(id, where).ToList();
            return drugOrderList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public List<PathologyData> GetPathologyGrid(Guid id, string subEpisodeId)
        {
            /*Patoloji Geçmişi*/
            string where = "";
            if (!String.IsNullOrEmpty(subEpisodeId))
            {
                where = "And THIS.SubEpisode='" + subEpisodeId + "'";
            }
            BindingList<Pathology.GetOldInfoForPathology_Class> pathologyList = Pathology.GetOldInfoForPathology(id, where);
            var viewModel = new PatientHistoryFormViewModel();
            viewModel.PathologyDataList = new List<PathologyData>();
            foreach (var item in pathologyList)
            {
                PathologyData pathology = new PathologyData
                {
                    AdmissionNumber = item.ProtocolNo.ToString(),
                    Doctor = item.Doctor,
                    FromResource = item.Requestedclinic,
                    Macroscopy = item.Macroscopy != null ? Common.BinaryToString(Guid.Parse(item.Macroscopy.ToString())) : "",
                    Microscopy = item.Microscopy != null ? Common.BinaryToString(Guid.Parse(item.Microscopy.ToString())) : "",
                    Note = item.Note != null ? Common.BinaryToString(Guid.Parse(item.Note.ToString())) : "",
                    PathologicDiagnosis = item.PathologicDiagnosis != null ? Common.BinaryToString(Guid.Parse(item.PathologicDiagnosis.ToString())) : "",
                    RequestDate = item.RequestDate.Value.ToString("yyyy/MM/dd HH:mm"),
                    TestCode = item.Code,
                    TestName = item.Name,
                    IsApproved = item.CurrentStateDefID == Pathology.States.Approvement ? true : false,
                    IsReported = item.CurrentStateDefID == Pathology.States.Report ? true : false,
                    ObjectID = item.ObjectID.Value.ToString()

                };
                viewModel.PathologyDataList.Add(pathology);
            }

            return viewModel.PathologyDataList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public List<ProcessTitle> GetSubEpisodeItems(Guid id)
        {
            /*Vaka Akışı Listesi*/
            BindingList<EpisodeAction.GetOldInfoForEpisodeAction_Class> actionList = EpisodeAction.GetOldInfoForEpisodeAction(id);
            var viewModel = new PatientHistoryFormViewModel();
            viewModel.PatientActionList = new List<ProcessTitle>();
            foreach (var item in actionList)
            {
                ProcessTitle action = new ProcessTitle { ObjectDefName = item.Defname, ObjectID = item.ObjectID.ToString(), RequestDate = item.RequestDate, SpecialityName = item.DisplayText };
                viewModel.PatientActionList.Add(action);
            }

            return viewModel.PatientActionList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public ProcessTitle GetVaccineGrid(Guid id, string subEpisodeId)
        {
            /*Aşı Takvimi*/
            string where = "";
            if (!String.IsNullOrEmpty(subEpisodeId))
            {
                where = "And EpisodeAction.SubEpisode='" + subEpisodeId + "'";
            }
            BindingList<VaccineDetails.GetOldInfoForVaccine_Class> vaccineFollowUpList = VaccineDetails.GetOldInfoForVaccine(id, where);
            var viewModel = new PatientHistoryFormViewModel();
            viewModel.VaccineProcessTitle = new List<ProcessTitle>();
            foreach (var item in vaccineFollowUpList)
            {
                ProcessTitle vaccine = new ProcessTitle { ObjectDefName = item.Objectdef, ObjectID = item.ObjectID.ToString(), };
                viewModel.VaccineProcessTitle.Add(vaccine);
            }

            return viewModel.VaccineProcessTitle.FirstOrDefault();
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public List<RequestedProcedureData> GetRequestedProceduresGrid(Guid id, string subEpisodeId)
        {
            /*Hizmet ve Tetkik Geçmişi*/
            string where = "";
            if (!String.IsNullOrEmpty(subEpisodeId))
            {
                where = "And EpisodeAction.SubEpisode='" + subEpisodeId + "'";
            }
            BindingList<SubActionProcedure.GetOldInfoForRequestedProcedures_Class> procedureList = SubActionProcedure.GetOldInfoForRequestedProcedures(id, where);
            var viewModel = new PatientHistoryFormViewModel();
            viewModel.RequestedProceduresList = new List<RequestedProcedureData>();
            foreach (var item in procedureList)
            {
                RequestedProcedureData procedure = new RequestedProcedureData
                {
                    ActionStatus = item.DisplayText,
                    Amount = item.Amount.ToString(),
                    MasterResource = item.Masterresource,
                    ProcedureCode = item.Procedurecode,
                    ProcedureName = item.Procedurename,
                    RequestBy = item.Requestby,
                    RequestDate = item.Requestdate.Value.ToString("yyyy/MM/dd HH:mm"),
                };
                viewModel.RequestedProceduresList.Add(procedure);
            }

            return viewModel.RequestedProceduresList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public List<TreatmentMaterialData> GetTreatmentMaterialsGrid(Guid id, string subEpisodeId)
        {
            /*Malzeme ve Sarf Geçmişi*/
            string where = "";
            if (!String.IsNullOrEmpty(subEpisodeId))
            {
                where = "And EpisodeAction.SubEpisode='" + subEpisodeId + "'";
            }
            BindingList<BaseTreatmentMaterial.GetOldInfoForTreatmentMaterial_Class> materialList = BaseTreatmentMaterial.GetOldInfoForTreatmentMaterial(id, where);
            var viewModel = new PatientHistoryFormViewModel();
            viewModel.TreatmentMaterialsList = new List<TreatmentMaterialData>();
            foreach (var item in materialList)
            {
                TreatmentMaterialData material = new TreatmentMaterialData
                {
                    ActionDate = item.ActionDate.Value.ToString("yyyy/MM/dd HH:mm"),
                    Amount = item.Amount.ToString(),
                    Code = item.Code,
                    Name = item.Name
                };
                viewModel.TreatmentMaterialsList.Add(material);
            }

            return viewModel.TreatmentMaterialsList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public List<DietOrderData> GetDietOrdersGrid(Guid id, string subEpisodeId)
        {
            /*Diyet Geçmişi*/
            string where = "";
            if (!String.IsNullOrEmpty(subEpisodeId))
            {
                where = "And EpisodeAction.SubEpisode='" + subEpisodeId + "'";
            }
            BindingList<DietOrderDetail.GetOldInfoForDietOrder_Class> dietList = DietOrderDetail.GetOldInfoForDietOrder(id, where);
            var viewModel = new PatientHistoryFormViewModel();
            viewModel.DietOrdersList = new List<DietOrderData>();
            foreach (var item in dietList)
            {
                DietOrderData diet = new DietOrderData
                {
                    CurrentStateName = item.Currentstatename.ToString(),
                    DietDate = item.WorkListDate.Value.ToString("yyyy/MM/dd"),
                    DietName = item.Name,
                    MasterResource = item.Tedaviklinikadi,
                    OrderDescription = item.OrderDescription,
                    PhysicalStateClinic = item.Yattigiklinikadi,
                    RoomGroupName = item.Yatakadi,
                    RoomName = item.Odaadi,
                    WhichMeal = (item.Breakfast == true ? "Kahvaltı, " : "") +
                    (item.Lunch == true ? "Öğlen, " : "") +
                    (item.Dinner == true ? "Akşam, " : "") +
                    (item.NightBreakfast == true ? "Gece Kahvaltısı, " : "") +
                    (item.Snack1 == true ? "Ara 1, " : "") +
                    (item.Snack2 == true ? "Ara 2, " : "") +
                    (item.Snack3 == true ? "Ara 3, " : "")

                };
                viewModel.DietOrdersList.Add(diet);
            }

            return viewModel.DietOrdersList;
        }

        #region POPUP HISTORY

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public PatientHistoryFormViewModel PatientHistoryFormBySubEpisode(HistoryFilter historyFilter/*, Guid? id,string ActionType,DateTime? StartDate,DateTime? EndDate,bool UseFilter*/)
        {
            var FormDefID = Guid.Parse("a1c90338-f14d-4bf6-b191-c9b63eef5898");
            var ObjectDefID = Guid.Parse("d7eb5879-8ccd-4576-b46b-1b2cea89f549");
            var viewModel = new PatientHistoryFormViewModel();

            string whereClause = string.Empty;
            Guid _patientId = new Guid();

            if (historyFilter.subEpisode != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, historyFilter.subEpisode, ObjectDefID);

                    if (historyFilter.useFilter)
                    {
                        SubEpisode sp = (SubEpisode)objectContext.GetObject(historyFilter.subEpisode, "SubEpisode");
                        _patientId = sp.Episode.Patient.ObjectID;
                    }

                    #region ACTIONTYPE NQL
                    BindingList<OrthesisProsthesisProcedure.GetOldOrthesisProsthesisProcedure_Class> ortezSubEpisodeList = null;
                    BindingList<PhysiotherapyRequest.GetOldPopupInfoForPhysiotherapyRequest_Class> physioSubEpisodeList = null;
                    #endregion
                    viewModel.PopUpHistoryList = new List<PopupHistory>();

                    if (historyFilter.selectAll == true)
                    {
                        whereClause += PrepareWhereClause(historyFilter.subEpisode, _patientId, historyFilter.useFilter, historyFilter.actionType, null, null);
                    }
                    else
                    {
                        whereClause += PrepareWhereClause(historyFilter.subEpisode, _patientId, historyFilter.useFilter, historyFilter.actionType, historyFilter.startDate, historyFilter.endDate);
                    }

                    switch (historyFilter.actionType)
                    {
                        case "PHYSIOTHERAPYREQUEST":
                            physioSubEpisodeList = PhysiotherapyRequest.GetOldPopupInfoForPhysiotherapyRequest(whereClause);
                            viewModel.PopUpHistoryList.AddRange(PreparePhysioPopupHistoryList(physioSubEpisodeList));
                            break;
                        case "ORTHESISPROSTHESISREQUEST":
                            ortezSubEpisodeList = OrthesisProsthesisProcedure.GetOldOrthesisProsthesisProcedure(whereClause);
                            viewModel.PopUpHistoryList.AddRange(PrepareOrtezPopupHistoryList(ortezSubEpisodeList));
                            break;
                        default:
                            break;
                    }
                    /*İşlem Bazlı Hasta Geçmişi    ***********************************************************************/

                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {

                }
            }

            return viewModel;
        }

        public string PrepareWhereClause(Guid? id, Guid _patientId, bool UseFilter, string ActionType, DateTime? StartDate, DateTime? EndDate)
        {
            string whereClause = " WHERE ";

            switch (ActionType)
            {
                case "ORTHESISPROSTHESISREQUEST":
                    if (UseFilter)
                    {
                        whereClause += " This.ORTHESISPROSTHESISREQUEST.Episode.Patient ='" + _patientId + "'";
                        if (StartDate != null)
                            whereClause += " AND THIS.ORTHESISPROSTHESISREQUEST.RequestDate >= TODATE('" + Convert.ToDateTime(StartDate.Value.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";

                        if (EndDate != null)
                            whereClause += " AND THIS.ORTHESISPROSTHESISREQUEST.RequestDate <= TODATE('" + Convert.ToDateTime(EndDate.Value.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";

                        whereClause += "  ORDER BY THIS.ORTHESISPROSTHESISREQUEST.RequestDate desc";
                    }
                    else
                        whereClause += " This.ORTHESISPROSTHESISREQUEST.SUBEPISODE ='" + id + "' ORDER BY THIS.ORTHESISPROSTHESISREQUEST.RequestDate desc";
                    break;
                case "PHYSIOTHERAPYREQUEST":
                    if (UseFilter)
                    {
                        whereClause += " This.Episode.Patient ='" + _patientId + "'";
                        if (StartDate != null)
                            whereClause += " AND THIS.PhysiotherapyRequestDate >= TODATE('" + Convert.ToDateTime(StartDate.Value.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";

                        if (EndDate != null)
                            whereClause += " AND THIS.PhysiotherapyRequestDate <= TODATE('" + Convert.ToDateTime(EndDate.Value.ToShortDateString() + " 23:59:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";

                        whereClause += "  ORDER BY THIS.PhysiotherapyRequestDate desc";
                    }
                    else
                        whereClause += " This.SUBEPISODE ='" + id + "' ORDER BY THIS.PhysiotherapyRequestDate desc";
                    break;
                default:
                    whereClause += "";
                    break;
            }

            return whereClause;
        }

        public List<PopupHistory> PrepareOrtezPopupHistoryList(BindingList<OrthesisProsthesisProcedure.GetOldOrthesisProsthesisProcedure_Class> ortezSubEpisodeList)
        {
            List<PopupHistory> popUpHistoryList = new List<PopupHistory>();
            PopupHistory popUpHistory = null;
            foreach (var item in ortezSubEpisodeList)
            {
                popUpHistory = new PopupHistory();

                popUpHistory.ObjectID = item.Episodeactionid.ToString();
                popUpHistory.RequesterID = item.RequesterUsr.ToString();

                if (item.RequesterUsr != null)
                    popUpHistory.RequesterUsr = TTUser.GetUser(item.RequesterUsr.Value).FullName;

                popUpHistory.RequesterUnit = item.Requesterunit;
                popUpHistory.RequestDate = item.RequestDate.Value;
                popUpHistory.ObjectDefName = item.ObjectDefName;
                popUpHistory.CurrentState = item.Currentstate;

                popUpHistoryList.Add(popUpHistory);
            }

            return popUpHistoryList;
        }

        public List<PopupHistory> PreparePhysioPopupHistoryList(BindingList<PhysiotherapyRequest.GetOldPopupInfoForPhysiotherapyRequest_Class> ortezSubEpisodeList)
        {
            List<PopupHistory> popUpHistoryList = new List<PopupHistory>();
            PopupHistory popUpHistory = null;
            foreach (var item in ortezSubEpisodeList)
            {
                popUpHistory = new PopupHistory();

                popUpHistory.ObjectID = item.ObjectID.ToString();
                popUpHistory.RequesterID = "0";
                popUpHistory.RequesterUsr = item.Doctor;
                popUpHistory.RequesterUnit = item.Fromresource;
                popUpHistory.RequestDate = item.PhysiotherapyRequestDate.Value;
                popUpHistory.ObjectDefName = item.Defname;
                popUpHistory.CurrentState = item.DisplayText;

                popUpHistoryList.Add(popUpHistory);
            }

            return popUpHistoryList;
        }

        #endregion

        public string GetPatientInfo(string protocolNo)
        {
            var query = SubEpisode.GetPatientByProtocolNo(protocolNo);
            string patientId = query.FirstOrDefault().ObjectID.ToString();
            return patientId.ToString();
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Eski_Islemler)]
        public List<RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class> GetRadiologyTestDef()
        {
            return RadiologyTestDefinition.GetRadiologyTestDefinitionNQL(" WHERE ISACTIVE = 1").ToList();

        }
        
        public void SetPatientHistoryShown(Guid episodeactionId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(episodeactionId);
                if (episodeAction.SubEpisode != null)
                {
                    SubEpisode subEpisode = episodeAction.SubEpisode;
                    subEpisode.IsPatientHistoryShown = true;
                    objectContext.Save();
                }
            }
        }
    }
}

namespace Core.Models
{
    public class PatientHistoryFormViewModel
    {
        public ProcessTitle _PatientHistory
        {
            get;
            set;
        }
        public string PatientUniqueRefNo
        {
            get;
            set;
        }

        public Guid? PatientId
        {
            get;
            set;
        }

        public Guid? EpisodeId
        {
            get;
            set;
        }

        public Guid patientObjectId
        {
            get;
            set;
        }

        public string SubEpisodeId
        {
            get;
            set;
        }

        public List<ProcessTitle> PoliclinicProcessTitle
        {
            get;
            set;
        } //Poliklinik İşlemleri Başlıkları

        public List<ProcessTitle> ClinicProcessTitle
        {
            get;
            set;
        } //Klinik İşlemleri Başlıkları

        public int DiagnosisCount
        {
            get;
            set;
        }

        public List<DiagnoseData> DiagnoseDataList
        {
            get;
            set;
        } //Tanı Geçmişi

        public int RadiologyCount
        {
            get;
            set;
        }
        public int LaboratoryCount
        {
            get;
            set;
        }

        public List<LaboratoryData> LaboratoryDataList
        {
            get;
            set;
        } //Laboratuvar Geçmişi

        public int DrugOrderCount
        {
            get;
            set;
        }

        public List<RadiologyData> RadiologyDataList
        {
            get;
            set;
        } //Radyoloji Geçmişi

        public List<DrugOrder.GetOldInfoForDrugOrder_Class> DrugOrderDataList
        {
            get;
            set;
        } //Radyoloji Geçmişi

        public int PathologyCount
        {
            get;
            set;
        }

        public List<PathologyData> PathologyDataList
        {
            get;
            set;
        } //Patoloji Geçmişi

        public List<ProcessTitleWithSubTitles> SurgeryTitles
        {
            get;
            set;
        } //Surgery ve SubSurgery Başlıkları

        public ProcessTitle ImportantMedicalInformation
        {
            get;
            set;
        } //Önemli Tıbbi Bilgiler

        public List<ProcessTitle> PatientHistoryBySubEpisode
        {
            get;
            set;
        } //Kabul Bazlı Görünüm Listesi

        public List<ProcessTitle> PatientActionList
        {
            get;
            set;
        } //Vaka Akışı Listesi

        public int VaccineCount
        {
            get;
            set;
        }

        public List<ProcessTitle> VaccineProcessTitle
        {
            get;
            set;
        } //Aşı Takvimi

        public List<ProcessTitleWithSubTitles> SpecialityTitles
        {
            get;
            set;
        } //Uzmanlık modülleri ve alt başlıkları

        public List<ProcessTitle> ManipulationProcessTitle
        {
            get;
            set;
        } //Manipulasyon Başlıkları

        public int RequestedProceduresCount { get; set; }//Hizmet ve Tetkik Sayısı
        public List<RequestedProcedureData> RequestedProceduresList { get; set; }//Hizmet ve Tetkik

        public int TreatmentMaterialsCount { get; set; }//Malzeme ve sarf Sayısı
        public List<TreatmentMaterialData> TreatmentMaterialsList { get; set; }//Malzeme ve sarf

        public List<ProcessTitle> EmergencyObjectTitle { get; set; } //Acil


        public int DietOrdersCount { get; set; }//Diyet Sayısı
        public List<DietOrderData> DietOrdersList { get; set; }//Diyet

        public string AllProceduresLink
        {
            get;
            set;
        }
        public string AllLabProceduresLink { get; set; }


        public List<ProcessTitle> PhysiotherapyRequestsTitles
        {
            get;
            set;
        } //Fizyoterapi İşlemleri Başlıkları

        public bool CloseAllPanel { get; set; }//popup açılacak hasta geçmişi için diğer tüm panelleri kapatır

        public List<PopupHistory> PopUpHistoryList { get; set; }
        public HistoryFilter _historyFilter
        {
            get;
            set;
        }
    }

    public class ProcessTitle
    {
        public string ObjectID
        {
            get;
            set;
        }

        public string ObjectDefName
        {
            get;
            set;
        }

        public string FormDefId
        {
            get;
            set;
        }

        public DateTime? RequestDate
        {
            get;
            set;
        }

        public string SpecialityName
        {
            get;
            set;
        }

        public string DoctorName
        {
            get;
            set;
        }
    }

    public class ProcessTitleWithSubTitles
    {
        public string ObjectID
        {
            get;
            set;
        }

        public string ObjectDefName
        {
            get;
            set;
        }

        public string FormDefId
        {
            get;
            set;
        }

        public DateTime? RequestDate
        {
            get;
            set;
        }

        public string SpecialityName
        {
            get;
            set;
        }

        public string DoctorName
        {
            get;
            set;
        }

        public List<ProcessTitle> SubTitles
        {
            get;
            set;
        }
    }

    public class DiagnoseData
    {
        public Guid? ObjectId
        {
            get;
            set;
        }

        public string DiagnoseDate
        {
            get;
            set;
        }

        public string DiagnoseType
        {
            get;
            set;
        }

        public string DiagnoseCode
        {
            get;
            set;
        }

        public string DiagnoseName
        {
            get;
            set;
        }

        public string FreeDiagnosis
        {
            get;
            set;
        }

        public bool? IsMainDiagnose
        {
            get;
            set;
        }

        public string EntryType
        {
            get;
            set;
        }

        public string Speciality
        {
            get;
            set;
        }

        public string ResponsibleDoctor
        {
            get;
            set;
        }
    }

    public class RadiologyData
    {
        public string RequestNumber
        {
            get;
            set;
        } //İstek Numarası

        public string RequestDate
        {
            get;
            set;
        } //İstem Tarihi

        public string TestCode
        {
            get;
            set;
        } //Tetkik Kodu

        public string TestName
        {
            get;
            set;
        } //Tetkik Adı

        public string Doctor
        {
            get;
            set;
        } //İstem Doktoru

        public string FromResource
        {
            get;
            set;
        } //İstem Birimi
        //Rapor İçeriği
        public string ReportTxt
        {
            get;
            set;
        }
        //Accesion Number
        public string AccesionNumber
        {
            get;
            set;
        }
        //ObjectID
        public string ObjectId
        {
            get;
            set;
        }


    }

    public class PathologyData
    {
        public string AdmissionNumber
        {
            get;
            set;
        } //Kabul Numarası

        public string RequestDate
        {
            get;
            set;
        } //İstem Tarihi

        public string TestCode
        {
            get;
            set;
        } //Tetkik Kodu

        public string TestName
        {
            get;
            set;
        } //Tetkik Adı

        public string Doctor
        {
            get;
            set;
        } //İstem Doktoru

        public string FromResource
        {
            get;
            set;
        } //İstem Birimi

        public string Macroscopy
        {
            get;
            set;
        } //Raporlar

        public string Microscopy
        {
            get;
            set;
        }

        public string PathologicDiagnosis
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }
        public bool IsReported { get; set; }
        public bool IsApproved { get; set; }
        public string ObjectID { get; set; }

    }

    public class RequestedProcedureData
    {
        public string ProcedureCode { get; set; }//İşlem Kodu
        public string ProcedureName { get; set; }//İşlem Adı
        public string Amount { get; set; }//Adet
        public string UnitPrice { get; set; }//Tutar
        public string RequestBy { get; set; }//İstem Yapan
        public string RequestDate { get; set; }//İstem Tarihi
        public string MasterResource { get; set; }//İstenilen Birim
        public string ActionStatus { get; set; }//İşlem Durumu
        public string ProcedureResultLink { get; set; }//Sonuç
        public string ProcedureReportLink { get; set; }//Rapor

    }

    public class TreatmentMaterialData
    {
        public string ActionDate { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Amount { get; set; }
    }

    public class DietOrderData
    {
        public string DietName { get; set; }//Diyet Tipi
        public string DietDate { get; set; }//Diyet Tarihi
        public string WhichMeal { get; set; }//Hangi Öğün
        //public string DietName { get; set; }//Yatış Durumu
        public string MasterResource { get; set; }//Tedavi Gördüğü Klinik
        public string PhysicalStateClinic { get; set; }//Yattığı Klinik
        public string RoomName { get; set; }//Oda No
        public string RoomGroupName { get; set; }//Yatak No
        public string OrderDescription { get; set; }//Açıklama
        public string CurrentStateName { get; set; }//Onay Durumu
        public string DoctorName { get; set; }
        public string PeriodStartTime { get; set; }
        public string PeriodEndTime { get; set; }

    }

    public class LaboratoryData
    {
        public Guid ObjectID
        {
            get;
            set;
        }
        public string TestCode
        {
            get;
            set;
        }
        public string LaboratoryTestName
        {
            get;
            set;
        }
        public DateTime? RequestDate
        {
            get;
            set;
        }
        public string FromResourceName
        {
            get;
            set;
        }
        public string RequestedByUser
        {
            get;
            set;
        }
        public string BarcodeID
        {
            get;
            set;
        }
        public string SpecimenID
        {
            get;
            set;
        }
        public DateTime? ResultDate
        {
            get;
            set;
        }
        public string Result
        {
            get;
            set;
        }
        public string Unit
        {
            get;
            set;
        }
        public string Reference
        {
            get;
            set;
        }
        public DateTime? ApproveDate
        {
            get;
            set;
        }
        public DateTime? BarcodePrintDate
        {
            get;
            set;
        }
        public DateTime? SampleDate
        {
            get;
            set;
        }
        public string TestLoincCode
        {
            get;
            set;
        }

        public List<LaboratorySubProcedureData> LaboratorySubProcedureList
        {
            get;
            set;
        }

        public Boolean isPanelTest
        {
            get;
            set;
        }

    }

    public class LaboratorySubProcedureData
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public Guid MasterSubactionProcedureID
        {
            get;
            set;
        }

        public string TestCode
        {
            get;
            set;
        }

        public string LaboratoryTestName
        {
            get;
            set;
        }

        public DateTime ResultDate
        {
            get;
            set;
        }

        public string Result
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public string Reference
        {
            get;
            set;
        }

    }

    public class PopupHistory
    {
        public string ObjectID { get; set; }
        public string RequesterID { get; set; }
        public string RequesterUsr { get; set; }
        public string RequesterUnit { get; set; }
        public string ObjectDefName { get; set; }
        public string CurrentState { get; set; }
        public DateTime RequestDate { get; set; }
    }

    public class HistoryFilter
    {
        public DateTime startDate
        {
            get;
            set;
        }

        public DateTime endDate
        {
            get;
            set;
        }

        public string actionType
        {
            get;
            set;
        }

        public bool selectAll { get; set; }
        public bool useFilter { get; set; }

        public Guid subEpisode { get; set; }
    }
}