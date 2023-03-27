//$9D1C07C7
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Infrastructure.Helpers;
using System.Collections.Generic;
using static TTObjectClasses.UserResource;
using Microsoft.AspNetCore.Mvc;
using TTStorageManager.Security;
using Core.Security;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Net;
using Newtonsoft.Json;
using static TTObjectClasses.SubEpisodeProtocol;
using TTDefinitionManagement;

namespace Core.Controllers
{
    public partial class PatientAdmissionServiceController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public PatientAdmissionFormViewModel PatientAdmissionFormPreLoad(Guid? id, bool? loadAdmissions = false)
        {
            var formDefID = Guid.Parse("ae86a7f9-497c-4945-8198-108dc56abbb0");
            var objectDefID = Guid.Parse("417114a6-5caa-4613-ab25-7ef4b28f5f82");
            var viewModel = new PatientAdmissionFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._PatientAdmission = objectContext.GetObject(id.Value, objectDefID) as PatientAdmission;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientAdmission, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientAdmission, formDefID);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    var episode = viewModel._PatientAdmission.Episode;
                    var se = viewModel._PatientAdmission.FirstSubEpisode;
                    if (se == null)
                    {
                        se = new SubEpisode(objectContext);
                        se.Episode = episode;
                    }

                    viewModel.SubEpisode = objectContext.LocalQuery<SubEpisode>().ToArray();
                    var sep = se.FirstSubEpisodeProtocol;
                    if (sep == null)
                        sep = se.AddSubEpisodeProtocol();

                    viewModel.SubEpisodeProtocol = sep;

                    var mst = sep.MedulaSigortaliTuru;

                    if (viewModel._PatientAdmission.MedulaSigortaliTuru == null)
                        viewModel._PatientAdmission.MedulaSigortaliTuru = mst;

                    var mih = sep.MedulaIstisnaiHal;
                    var eDisRep = viewModel._PatientAdmission.EDisabledReport;
                    var eStatusNotRepCom = viewModel._PatientAdmission.EStatusNotRepCommitteeObj;
                    if (viewModel._PatientAdmission.MedulaIstisnaiHal == null)
                        viewModel._PatientAdmission.MedulaIstisnaiHal = mih;

                    if (viewModel._PatientAdmission.PA_Address == null)
                        viewModel._PatientAdmission.PA_Address = new PatientIdentityAndAddress(objectContext);

                    LocalQueryToView(viewModel, objectContext);

                    if (loadAdmissions.HasValue && loadAdmissions.Value)
                        FillPatientAdmissionHistory(objectContext, viewModel);

                    SetDefaultProvisionType(viewModel);
                    SetPayerAndSigortaliTuru(objectContext, viewModel);
                    SetPoliclinicAndProcedureDoctor(viewModel);
                    viewModel.SEProtocolNo = viewModel._PatientAdmission.FirstSubEpisode?.ProtocolNo;

                    foreach (EpisodeAction ea in viewModel._PatientAdmission.FirstSubEpisode?.EpisodeActions)
                    {
                        if (ea.SubEpisode.ProtocolNo == viewModel.SEProtocolNo)
                            viewModel.episodeAction = ea;
                    }
                    viewModel.subEpisode = viewModel._PatientAdmission.FirstSubEpisode;

                    #region parameters&perms
                    viewModel.HasBuilding = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HASBUILDING", "FALSE"));
                    viewModel.GetTotalSepCount = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETTOTALSEPCOUNT", "FALSE"));
                    viewModel.HasTriageArea = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HASTRIAGEAREA", "FALSE"));
                    viewModel.RehabilitationApplication = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("REHABILITATIONAPPLICATION", "FALSE"));
                    viewModel.DispatchTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("DISPATCHTABACTIVE", "FALSE"));
                    viewModel.HealthCommissionTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HEALTHCOMMISSIONTABACTIVE", "FALSE"));
                    viewModel.MainTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("MAINTABACTIVE", "TRUE"));

                    string paidPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("PAIDPAYERDEFINITION", "4d7b28c8-4f48-4452-afe2-98a30c376b80");
                    viewModel.PaidPayerDefinition = objectContext.GetObject<PayerDefinition>(new Guid(paidPayerObjectID), false);

                    string healthTourismPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("HEALTHTOURISMPAYERDEFINITION", "adbc5921-3a3a-4a20-beed-471be8c45f23");
                    viewModel.HealthTourismPayerDefinition = objectContext.GetObject<PayerDefinition>(new Guid(healthTourismPayerObjectID), false);

                    viewModel.CheckMernisRole = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Mernis_Sorgulama);
                    viewModel.GizliHastaKabulRole = TTUser.CurrentUser.HasRole(Common.GizliHastaKabulRoleID);
                    viewModel.ModifyPatientInfoRole = TTUser.CurrentUser.HasRole(Common.ModifyPatientInfoRoleID);
                    viewModel.IsSuperUser = Common.CurrentUser.IsSuperUser;
                    viewModel.activeTab = (viewModel._PatientAdmission.AdmissionStatus == null) ? 1 : SetActiveTab(viewModel._PatientAdmission);
                    viewModel.hasDoctorKotaRole = TTUser.CurrentUser.HasRole(TTRoleNames.Doktor_Kota_Tanimlama) ? true : false;
                    viewModel.hasGiveAppointmentRole = TTUser.CurrentUser.HasRole(TTRoleNames.Randevu_Verme) ? true : false;
                    viewModel.HCControlDayLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("HCCONTROLDAYLIMIT", "40"));
                    viewModel.ControlPreviousHcExam = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("CONTROLPREVIOUSHCEXAM", "TRUE"));
                    viewModel.openKPSLoginInfo = openKPSLoginInfo();
                    viewModel.CheckMernisRole = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Mernis_Sorgulama);
                    viewModel.canGetEpicrisisReport = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Kayit_Kabul_Epikriz_Raporu);
                    viewModel.getRelatedResourceParam = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETRELATEDRESOURCEPARAM", "TRUE"));
                    viewModel.getLastSelectedDoctorandPoliclinic = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETLASTSELECTEDDOCTORANDPOLICLINIC", "TRUE"));
                    viewModel.HospitalName = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "TRUE"));
                    viewModel.VerifiedKpsWithoutApprove = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("VERIFIEDKPSWITHOUTAPPROVE", "TRUE"));
                    viewModel.PrintMedulaCodeReport = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("PRINTMEDULACODEREPORT", "TRUE"));
                    viewModel.NewPatientBarcode = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("NEWPATIENTBARCODE", "FALSE"));
                    viewModel.AcilDoktorSecimiZorla = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("ACILDOKTORSECIMIZORLA", "FALSE"));
                    viewModel.KurumSevkTalepNoZorla = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("KURUMSEVKTALEPNOZORLA", "FALSE"));
                    
                    #endregion

                    LoadPatientPrivacyTempInfo(viewModel);
                    LoadRisLisInfo(viewModel);

                    viewModel.ResourcesToBeReferredPoliclinic = GetAllActivePoliclinic();

                    List<string> result = new List<string>();

                    if (viewModel.getRelatedResourceParam && !viewModel.IsSuperUser)
                    {
                        GetRelatedResourceParam(viewModel);
                        result = viewModel.relatedPoliclinicList.Replace("'", "").Split(',').ToList();
                        viewModel.PoliclinicListForFilter = viewModel.ResourcesToBeReferredPoliclinic.Where(x => result.Contains(x.ObjectID.ToString())).ToList();
                    }
                    else
                    {
                        viewModel.PoliclinicListForFilter = viewModel.ResourcesToBeReferredPoliclinic.ToList();
                    }

                    //TODO bg
                    viewModel.returnMessage = PatientAdmission.PatientHasDebt(viewModel._PatientAdmission);

                    if (viewModel._PatientAdmission.ImportantPAInfo != null)
                        viewModel.returnMessage += viewModel._PatientAdmission.ImportantPAInfo.ToString();

                    viewModel.KurumSevkTalepNo = viewModel._PatientAdmission.KurumSevkTalepNo;

                    if (viewModel._PatientAdmission.FiredEpisodeActions.Count > 0)
                    {
                        foreach (var firedAction in viewModel._PatientAdmission.FiredEpisodeActions)
                        {
                            if (firedAction is PatientExamination || firedAction is DispatchExamination)
                            {
                                viewModel.StarterEpisodeAction = firedAction.ObjectID;
                            }
                        }
                    }

                    if (viewModel._PatientAdmission.Episode != null && viewModel._PatientAdmission.Episode.Patient != null && viewModel._PatientAdmission.Episode.Patient.Photo != null)
                    {
                        if (viewModel._PatientAdmission.Episode.Patient.Photo is string)
                        {
                            viewModel.PhotoString = viewModel._PatientAdmission.Episode.Patient.Photo.ToString();
                        }
                        else
                            viewModel.PhotoString = Convert.ToBase64String((byte[])viewModel._PatientAdmission.Episode.Patient.Photo);
                    }

                    if (viewModel._PatientAdmission.Episode != null && viewModel._PatientAdmission.Episode.Patient != null && viewModel._PatientAdmission.Episode.Patient.MedicalInformation != null)
                    {
                        viewModel.IsPandemicPatient = viewModel._PatientAdmission.Episode.Patient.MedicalInformation.Pandemic.HasValue ? viewModel._PatientAdmission.Episode.Patient.MedicalInformation.Pandemic.Value : false;
                    }



                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        private void GetRelatedResourceParam(PatientAdmissionFormViewModel viewModel)
        {
            viewModel.relatedBransList = "'1'";
            viewModel.relatedPoliclinicList = "'1'";
            viewModel.relatedPoliclinicDoctorList = "'1'";

            foreach (var useResource in Common.CurrentResource.UserResources)
            {
                //if (useResource.Resource is ResDepartment)
                //    viewModel.relatedBransList += "'" + useResource.Resource.ObjectID + "'";
                if (useResource.Resource is ResPoliclinic && useResource.Resource.IsActive.HasValue && useResource.Resource.IsActive.Value)
                {
                    viewModel.relatedPoliclinicList += ",'" + useResource.Resource.ObjectID + "'";

                    using (var objectContext = new TTObjectContext(true))
                    {
                        //ResPoliclinic resPoliclinic = objectContext.GetObject<ResPoliclinic>(useResource.Resource.ObjectID);
                        //ResDepartment resDepartment = resPoliclinic.Department;
                        if (((ResPoliclinic)useResource.Resource).Department != null)
                            viewModel.relatedBransList += ",'" + ((ResPoliclinic)useResource.Resource).Department.ObjectID + "'";

                        string _doctorfilter = " AND this.ISACTIVE = 1 AND USERRESOURCES.RESOURCE ='" + useResource.Resource.ObjectID + "'";

                        List<ResUser.SpecialistDoctorListNQL_Class> DoctorListFromQuery = ResUser.SpecialistDoctorListNQL(_doctorfilter).ToList();
                        List<FilterDoctorModel> DoctorList = new List<FilterDoctorModel>();

                        foreach (ResUser.SpecialistDoctorListNQL_Class doctor in DoctorListFromQuery)
                        {
                            viewModel.relatedPoliclinicDoctorList += ",'" + doctor.ObjectID + "'";
                        }

                    }


                }
            }

            if (!((ITTObject)viewModel._PatientAdmission).IsNew)
            {
                if ((viewModel._PatientAdmission.Episode.Patient.Death.HasValue && viewModel._PatientAdmission.Episode.Patient.Death.Value == false)//değer var ve false ise
                    || viewModel._PatientAdmission.Episode.Patient.Death.HasValue == false)//değer yok ise
                {
                    viewModel.relatedPoliclinicList += ",'" + viewModel._PatientAdmission.Policlinic.ObjectID + "'";
                    viewModel.relatedBransList += ",'" + viewModel._PatientAdmission.Department.ObjectID + "'";
                    viewModel.relatedPoliclinicDoctorList += ",'" + viewModel._PatientAdmission.ProcedureDoctor.ObjectID + "'";
                }
            }

        }

        //private RelatedResourceList GetRelatedResourceParam2()
        //{
        //    RelatedResourceList _list = new RelatedResourceList();
        //    _list.relatedBransList = "'1'";
        //    _list.relatedPoliclinicList = "'1'";

        //    foreach (var useResource in Common.CurrentResource.UserResources)
        //    {
        //        //if (useResource.Resource is ResDepartment)
        //        //    _list.relatedBransList += ",'" + useResource.Resource.ObjectID + "'";
        //        if (useResource.Resource is ResPoliclinic)
        //        {
        //            _list.relatedPoliclinicList += ",'" + useResource.Resource.ObjectID + "'";
        //            for (int i = 0; i < useResource.Resource.ResourceSpecialities.Count; i++)
        //            {
        //                _list.relatedBransList += ",'" + ((ResPoliclinic)useResource.Resource).Department + "'";
        //            }

        //        }
        //    }
        //    return _list;

        //}

        /// <summary>
        /// yeni kps servisi için kullanıcıya ait kps login ekranı açılacak mı açılmayacak mı
        /// </summary>
        /// <returns></returns>
        private bool openKPSLoginInfo()
        {
            bool hasRole = TTUser.CurrentUser.HasRole(TTRoleNames.KPS_Kullanici_Sifre_Degistirme) ? true : false;

            if (TTObjectClasses.SystemParameter.GetParameterValue("ISKPSACTIVE", "TRUE") == "TRUE")
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("KIMLIKNOILEADRESSORGUPARAM", "FALSE") == "FALSE")//yeni servis
                    if (hasRole && (string.IsNullOrEmpty(Common.CurrentResource.KPSPassword) || string.IsNullOrEmpty(Common.CurrentResource.KPSUserName)))
                        return true;
            }

            return false;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public PatientAdmissionFormViewModel PatientAdmissionEmptyForm()
        {
            var FormDefID = Guid.Parse("ae86a7f9-497c-4945-8198-108dc56abbb0");
            var ObjectDefID = Guid.Parse("417114a6-5caa-4613-ab25-7ef4b28f5f82");
            var viewModel = new PatientAdmissionFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PatientAdmission = new PatientAdmission(objectContext);
                SubEpisode se = new SubEpisode(objectContext);
                viewModel.SubEpisode = objectContext.LocalQuery<SubEpisode>().ToArray();
                se.PatientAdmission = viewModel._PatientAdmission;
                se.AddSubEpisodeProtocol();

                var sep = se.FirstSubEpisodeProtocol;
                if (sep == null)
                    sep = se.AddSubEpisodeProtocol();

                viewModel.SubEpisodeProtocol = sep;

                viewModel._PatientAdmission.Episode = new Episode(objectContext);
                viewModel._PatientAdmission.Episode.Patient = new Patient(objectContext);

                SetDefaultProvisionType(viewModel);
                viewModel._PatientAdmission.AdmissionType = viewModel.NormalProvisionType;

                viewModel._PatientAdmission.Episode.Patient.Nationality = Patient.SetDefaultNationality().FirstOrDefault();
                viewModel._PatientAdmission.Building = (ResBuilding)ResBuilding.GetMainBuilding(objectContext).FirstOrDefault();
                viewModel._PatientAdmission.PA_Address = new PatientIdentityAndAddress(objectContext);

                if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("SETDEFAULTPAYERDEFINITION", "FALSE")) == true)
                    SetDefaultPayerAndSigortaliTuru(objectContext, viewModel);

                #region parameters&perms
                viewModel.HasBuilding = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HASBUILDING", "FALSE"));
                viewModel.GetTotalSepCount = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETTOTALSEPCOUNT", "FALSE"));
                viewModel.HasTriageArea = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HASTRIAGEAREA", "FALSE"));
                viewModel.RehabilitationApplication = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("REHABILITATIONAPPLICATION", "FALSE"));
                viewModel.DispatchTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("DISPATCHTABACTIVE", "FALSE"));
                viewModel.HealthCommissionTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HEALTHCOMMISSIONTABACTIVE", "FALSE"));
                viewModel.MainTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("MAINTABACTIVE", "TRUE"));
                viewModel.CheckMernisRole = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Mernis_Sorgulama);
                viewModel.GizliHastaKabulRole = TTUser.CurrentUser.HasRole(Common.GizliHastaKabulRoleID);
                viewModel.ModifyPatientInfoRole = TTUser.CurrentUser.HasRole(Common.ModifyPatientInfoRoleID);
                viewModel.IsSuperUser = Common.CurrentUser.IsSuperUser;
                viewModel.activeTab = (viewModel._PatientAdmission.AdmissionStatus == null) ? 1 : SetActiveTab(viewModel._PatientAdmission);
                viewModel.hasDoctorKotaRole = TTUser.CurrentUser.HasRole(TTRoleNames.Doktor_Kota_Tanimlama) ? true : false;
                viewModel.hasGiveAppointmentRole = TTUser.CurrentUser.HasRole(TTRoleNames.Randevu_Verme) ? true : false;
                viewModel.HCControlDayLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("HCCONTROLDAYLIMIT", "40"));
                viewModel.ControlPreviousHcExam = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("CONTROLPREVIOUSHCEXAM", "TRUE"));
                viewModel.openKPSLoginInfo = openKPSLoginInfo();
                viewModel.canGetEpicrisisReport = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Kayit_Kabul_Epikriz_Raporu);
                viewModel.getRelatedResourceParam = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETRELATEDRESOURCEPARAM", "TRUE"));
                viewModel.getLastSelectedDoctorandPoliclinic = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETLASTSELECTEDDOCTORANDPOLICLINIC", "TRUE"));
                viewModel.HospitalName = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "TRUE"));
                viewModel.VerifiedKpsWithoutApprove = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("VERIFIEDKPSWITHOUTAPPROVE", "TRUE"));
                viewModel.PrintMedulaCodeReport = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("PRINTMEDULACODEREPORT", "TRUE"));
                viewModel.AcilDoktorSecimiZorla = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("ACILDOKTORSECIMIZORLA", "FALSE"));
                viewModel.KurumSevkTalepNoZorla = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("KURUMSEVKTALEPNOZORLA", "FALSE"));

                string paidPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("PAIDPAYERDEFINITION", "4d7b28c8-4f48-4452-afe2-98a30c376b80");
                viewModel.PaidPayerDefinition = objectContext.GetObject<PayerDefinition>(new Guid(paidPayerObjectID), false);

                string healthTourismPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("HEALTHTOURISMPAYERDEFINITION", "adbc5921-3a3a-4a20-beed-471be8c45f23");
                viewModel.HealthTourismPayerDefinition = objectContext.GetObject<PayerDefinition>(new Guid(healthTourismPayerObjectID), false);
                #endregion

                viewModel.ResourcesToBeReferredPoliclinic = GetAllActivePoliclinic();

                List<string> result = new List<string>();

                if (viewModel.getRelatedResourceParam && !viewModel.IsSuperUser)
                {
                    GetRelatedResourceParam(viewModel);
                    result = viewModel.relatedPoliclinicList.Replace("'", "").Split(',').ToList();
                    viewModel.PoliclinicListForFilter = viewModel.ResourcesToBeReferredPoliclinic.Where(x => result.Contains(x.ObjectID.ToString())).ToList();
                }
                else
                {
                    viewModel.PoliclinicListForFilter = viewModel.ResourcesToBeReferredPoliclinic.ToList();
                }

                //viewModel.ProcedureDoctorToBeReferred = ResUser.GetSpecialistDoctorWithAllInf(objectContext, " AND  ISACTIVE = 1").ToArray();

                LocalQueryToView(viewModel, objectContext);
            }

            return viewModel;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public PatientAdmissionFormViewModel PatientAdmissionFormLoad(Patient id)
        {
            PatientAdmissionFormViewModel viewModel = null;
            Patient p = id;
            Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();
            if (p != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel = PatientAdmissionFormLoadInternal(p, objectContext);
                }
            }

            return viewModel;
        }


        internal PatientAdmissionFormViewModel PatientAdmissionFormLoadInternal(Patient p, TTObjectContext objectContext)
        {
            var viewModel = new PatientAdmissionFormViewModel();

            this.PatientAdmissionFormViewModel(viewModel, p, objectContext);

            return viewModel;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]

        public Patient PatientAdmissionFormLoadFromKPSButton(Patient id)
        {
            var viewModel = new PatientAdmissionFormViewModel();
            if (id != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    //viewModel.fromVerifiedKPSBtn = true;
                    ////p.IsTrusted = false;
                    //viewModel = this.PatientAdmissionFormViewModel(viewModel, p, objectContext);
                    Patient p = objectContext.GetObject(id.ObjectID, typeof(Patient)) as Patient;
                    objectContext.FullPartialllyLoadedObjects();
                    try
                    {
                        viewModel.MernisPatientModel = Patient.GetPatientandAdresInfoFromKPS(p, true, objectContext);//gelen veriyi patient içine set etmesi için truew gönderildi
                        p.ObjectContext.Save();

                        return p;
                    }
                    catch (Exception ex)
                    {
                        TTUtils.Logger.WriteException("Error in KPSServis", ex);
                        if (ex.InnerException != null)
                            TTUtils.InfoMessageService.Instance.ShowMessage(ex.InnerException.Message.ToString());
                        else
                            TTUtils.InfoMessageService.Instance.ShowMessage("Mernis bilgileri alınırken bir hata ile karşılaşıldı");

                        return null;
                    }

                }
            }
            return null;

        }

        public class LISPARAM
        {
            public string UniqueRefNo { get; set; }
            public List<SubEpisode> SubEpisodes = new List<SubEpisode>();
        }

        [HttpPost]
        public List<string> GetReportForPacs(LISPARAM param)
        {
            List<string> result = new List<string>();
            BindingList<RadiologyTest.GetRadiologyTestBySubEpisode_Class> radtest = RadiologyTest.GetRadiologyTestBySubEpisode(param.SubEpisodes[0].ObjectID.ToString());

            if (radtest.Count > 0)
            {
                foreach (var item in radtest)
                {
                    result.Add(item.ObjectID.ToString());
                }
                return result;
            }

            return null;
        }

        [HttpPost]
        public string GetReportURLFromLIS(LISPARAM param)
        {
            string urlParams = "";
            string checkSum = "";
            BindingList<LaboratoryProcedure.GetLaboratoryResultsBySubepisodeId_Class> spcids = LaboratoryProcedure.GetLaboratoryResultsBySubepisodeId(param.SubEpisodes[0].ObjectID.ToString());
            if (spcids.Count > 0)
            {
                string SpecimenId = spcids[0].Tetkik_ornek_numarasi.ToString();
                string urlLink = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATIONURL", ""); //"http://X.X.X.X/alissonuc/Rapor_Sonuc.aspx?";
                if (SpecimenId != null)
                {
                    urlParams = urlParams + "OID=" + WebUtility.UrlEncode(EncodeTo64UTF8(SpecimenId.ToString()));
                    if (param.UniqueRefNo.ToString() != null)
                    {
                        urlParams = urlParams + "&TCKN=" + WebUtility.UrlEncode(EncodeTo64UTF8(param.UniqueRefNo.ToString()));
                    }
                }

                checkSum = CheckSumUrl(DateTime.Now, SpecimenId.ToString());
                urlLink = urlLink + urlParams + "&CHK=" + checkSum;
                return urlLink;
            }
            else
            {
                return null;
            }
        }

        public static string CheckSumUrl(DateTime tarih, string str)
        {
            if (string.IsNullOrEmpty(str) || tarih == null || tarih == DateTime.MinValue)
                return string.Empty;
            str = tarih.ToString("yyyyMMddHHmm") + FillLeftStr(str, "0", 25);
            string res = string.Empty;
            for (int i = 0; i < str.Length - 1; i++)
                if (str[i] % 3 == 0)
                    res += Convert.ToChar((((str[i] + str[(i + 1)]) % 80) + 80));
                else
                    res += Convert.ToChar((((str[i] + str[(i + 1)]) % 50) + 50));
            return WebUtility.UrlEncode(EncodeTo64UTF8(res));
        }

        public static string EncodeTo64UTF8(string toEncode)
        {
            string returnValue = "";
            if (!string.IsNullOrWhiteSpace(toEncode))
            {
                try
                {
                    byte[] toEncodeAsBytes = System.Text.UTF8Encoding.UTF8.GetBytes(toEncode);
                    returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
                }
                catch
                {
                    returnValue = toEncode;
                }
            }

            return returnValue;
        }


        public static string FillLeftStr(string str, string fillStr, int size)
        {
            string result = str;
            if (!string.IsNullOrEmpty(str))
                if (str.Length < size)
                {
                    int toRepeat = size - str.Length;
                    for (int i = 1; i <= toRepeat; i++)
                        str = fillStr + str;
                }

            return str;
        }



        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public PatientAdmissionFormViewModel PatientAdmissionFormAppointmentLoad(Guid id, long uniqueRefNo, Guid? appointmentID = null)
        {
            var viewModel = new PatientAdmissionFormViewModel();
            Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();
            using (var objectContext = new TTObjectContext(false))
            {
                Patient p = objectContext.GetObject<Patient>(id, false);

                if (p == null)
                    p = Patient.GetPatientsByUniqueRefNo(objectContext, uniqueRefNo).SingleOrDefault();

                if (p == null && appointmentID != null)
                {
                    BindingList<Appointment.GetPatientAppointmentByID_Class> appList = Appointment.GetPatientAppointmentByID(objectContext, (Guid)appointmentID);
                    if (appList.Count > 0)
                    {
                        if (appList[0].Patient == null)
                        {
                            Patient patient = new Patient(objectContext);
                            p = patient;
                            p.UniqueRefNo = uniqueRefNo;
                        }
                        else
                        {
                            p = objectContext.GetObject<Patient>(appList[0].Patient.Value);
                        }
                    }
                    else
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26723", "Randevu bilgilerini kontrol ediniz."));
                }

                if (p != null)
                {
                    viewModel = this.PatientAdmissionFormViewModel(viewModel, p, objectContext);
                    viewModel._PatientAdmission = PatientAdmission.LoadAppointmentInfo(viewModel._PatientAdmission, objectContext, appointmentID);

                    if (viewModel._PatientAdmission.Episode != null && viewModel._PatientAdmission.Episode.Patient != null && viewModel._PatientAdmission.Episode.Patient.MedicalInformation != null)
                    {
                        viewModel.IsPandemicPatient = viewModel._PatientAdmission.Episode.Patient.MedicalInformation.Pandemic.HasValue ? viewModel._PatientAdmission.Episode.Patient.MedicalInformation.Pandemic.Value : false;
                    }

                    viewModel.tempPoliclinic = viewModel._PatientAdmission.Policlinic;
                    viewModel.tempProcedureDoctor = viewModel._PatientAdmission.ProcedureDoctor;
                    LocalQueryToView(viewModel, objectContext);
                    var se = viewModel._PatientAdmission.FirstSubEpisode;
                    var sep = se.FirstSubEpisodeProtocol;
                    if (sep == null)
                        sep = se.AddSubEpisodeProtocol();

                    viewModel.SubEpisodeProtocol = sep;

                    objectContext.FullPartialllyLoadedObjects();
                }

                #region parameters&perms
                viewModel.HasBuilding = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HASBUILDING", "FALSE"));
                viewModel.GetTotalSepCount = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETTOTALSEPCOUNT", "FALSE"));
                viewModel.HasTriageArea = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HASTRIAGEAREA", "FALSE"));
                viewModel.RehabilitationApplication = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("REHABILITATIONAPPLICATION", "FALSE"));
                viewModel.DispatchTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("DISPATCHTABACTIVE", "FALSE"));
                viewModel.HealthCommissionTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HEALTHCOMMISSIONTABACTIVE", "FALSE"));
                viewModel.MainTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("MAINTABACTIVE", "TRUE"));
                viewModel.CheckMernisRole = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Mernis_Sorgulama);
                viewModel.GizliHastaKabulRole = TTUser.CurrentUser.HasRole(Common.GizliHastaKabulRoleID);
                viewModel.ModifyPatientInfoRole = TTUser.CurrentUser.HasRole(Common.ModifyPatientInfoRoleID);
                viewModel.IsSuperUser = Common.CurrentUser.IsSuperUser;
                viewModel.activeTab = (viewModel._PatientAdmission.AdmissionStatus == null) ? 1 : SetActiveTab(viewModel._PatientAdmission);
                viewModel.hasDoctorKotaRole = TTUser.CurrentUser.HasRole(TTRoleNames.Doktor_Kota_Tanimlama) ? true : false;
                viewModel.hasGiveAppointmentRole = TTUser.CurrentUser.HasRole(TTRoleNames.Randevu_Verme) ? true : false;
                viewModel.HCControlDayLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("HCCONTROLDAYLIMIT", "40"));
                viewModel.ControlPreviousHcExam = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("CONTROLPREVIOUSHCEXAM", "TRUE"));
                viewModel.openKPSLoginInfo = openKPSLoginInfo();
                viewModel.canGetEpicrisisReport = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Kayit_Kabul_Epikriz_Raporu);
                viewModel.getRelatedResourceParam = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETRELATEDRESOURCEPARAM", "TRUE"));
                viewModel.getLastSelectedDoctorandPoliclinic = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETLASTSELECTEDDOCTORANDPOLICLINIC", "TRUE"));
                viewModel.HospitalName = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "TRUE"));
                viewModel.VerifiedKpsWithoutApprove = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("VERIFIEDKPSWITHOUTAPPROVE", "TRUE"));
                viewModel.PrintMedulaCodeReport = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("PRINTMEDULACODEREPORT", "TRUE"));
                viewModel.AcilDoktorSecimiZorla = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("ACILDOKTORSECIMIZORLA", "FALSE"));
                viewModel.KurumSevkTalepNoZorla = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("KURUMSEVKTALEPNOZORLA", "FALSE"));

                string paidPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("PAIDPAYERDEFINITION", "4d7b28c8-4f48-4452-afe2-98a30c376b80");
                viewModel.PaidPayerDefinition = objectContext.GetObject<PayerDefinition>(new Guid(paidPayerObjectID), false);

                string healthTourismPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("HEALTHTOURISMPAYERDEFINITION", "adbc5921-3a3a-4a20-beed-471be8c45f23");
                viewModel.HealthTourismPayerDefinition = objectContext.GetObject<PayerDefinition>(new Guid(healthTourismPayerObjectID), false);
                #endregion

                viewModel.ResourcesToBeReferredPoliclinic = GetAllActivePoliclinic();

                List<string> result = new List<string>();

                if (viewModel.getRelatedResourceParam && !viewModel.IsSuperUser)
                {
                    GetRelatedResourceParam(viewModel);
                    result = viewModel.relatedPoliclinicList.Replace("'", "").Split(',').ToList();
                    viewModel.PoliclinicListForFilter = viewModel.ResourcesToBeReferredPoliclinic.Where(x => result.Contains(x.ObjectID.ToString())).ToList();
                }
                else
                {
                    viewModel.PoliclinicListForFilter = viewModel.ResourcesToBeReferredPoliclinic.ToList();
                }


            }

            return viewModel;
        }


        PatientAdmissionFormViewModel PatientAdmissionFormViewModel(PatientAdmissionFormViewModel viewModel, Patient p, TTObjectContext objectContext)
        {
            var formDefID = Guid.Parse("ae86a7f9-497c-4945-8198-108dc56abbb0");
            var objectDefID = Guid.Parse("417114a6-5caa-4613-ab25-7ef4b28f5f82");
            bool _newPatient = false;
            BindingList<Patient> _pList = Patient.GetPatientByID(objectContext, p.ObjectID.ToString());
            if (_pList.Count == 0) //Isnew mi
            {
                if (objectContext.LocalQuery<Patient>("OBJECTID = '" + p.ObjectID + "'").Count == 0)
                    p = (Patient)objectContext.AddObject(p); //Kayıtlı olmayan hastalarda readonly uyarısı almamak için
                _newPatient = true;
            }
            else
            {
                p = _pList[0];
                _newPatient = false;
            }

            #region KPS
            bool dontControlTrustedInfo = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HERZAMANKPSSORGULA", "FALSE"));

            if (TTObjectClasses.SystemParameter.GetParameterValue("ISKPSACTIVE", "TRUE") == "TRUE" && (p.IsTrusted != true || viewModel.fromVerifiedKPSBtn || dontControlTrustedInfo))
            {
                try
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("KIMLIKNOILEADRESSORGUPARAM", "FALSE") == "TRUE")//eski servis
                    {
                        if (p.UniqueRefNo != null && p.UniqueRefNo.Value != 0 && p.IsTrusted != true && p.Alive != false)
                        {
                            String _uniqueRefNo = Convert.ToString(p.UniqueRefNo);
                            if (_uniqueRefNo.Length > 2)
                            {
                                Int32 firstTwodigits = Convert.ToInt32(_uniqueRefNo.Substring(0, 2));
                                if (firstTwodigits != 99 && firstTwodigits != 98)
                                {
                                    KPSServis.KPSServisSonucuKisiTemelBilgisi response = KPSServis.WebMethods.TcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost, p.UniqueRefNo.Value);
                                    if (string.IsNullOrEmpty(response.Hata))
                                    {
                                        if (_newPatient == false)
                                        {
                                            if (!(p.Name == response.Sonuc.Ad && p.Surname == response.Sonuc.Soyad && p.MotherName == response.Sonuc.AnaAd
                                                  && p.FatherName == response.Sonuc.BabaAd && p.BirthDate.Value.ToString("yyyyMMdd") == Convert.ToDateTime(response.Sonuc.DogumTarihi).ToString("yyyyMMdd")))
                                            {
                                                p.IsTrusted = false;
                                            }
                                            else
                                                p.IsTrusted = true;
                                        }
                                        else
                                        {
                                            p.IsTrusted = true;
                                            viewModel.MernisPatientModel = Patient.GetPatientandAdresInfoFromKPS_OLD(response, p, _newPatient, objectContext);
                                            p.KPSUpdateDate = Common.RecTime();

                                            //adres bilgisi
                                            if (p.PatientAddress == null)
                                                p.PatientAddress = new PatientIdentityAndAddress(objectContext);

                                            p.PatientAddress = Patient.GetKisiAdresBilgisi_OLD(p, objectContext);

                                        }
                                    }
                                    else//KPS servisten dönen hata
                                    {
                                        TTUtils.InfoMessageService.Instance.ShowMessage(response.Hata);
                                    }
                                }
                                else //if (p.Foreign == true && p.ForeignUniqueRefNo.Value > 0)
                                {
                                    KPSServis.KPSServisSonucuYabanciKisiBilgisi response = KPSServis.WebMethods.YabanciTcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(p.UniqueRefNo.Value));
                                    if (string.IsNullOrEmpty(response.Hata))
                                    {
                                        if (_newPatient == false)
                                        {
                                            if (!(p.Name == response.Sonuc.Ad && p.Surname == response.Sonuc.Soyad
                                              && p.FatherName == response.Sonuc.BabaAd && p.BirthDate.Value.ToString("yyyyMMdd") == Convert.ToDateTime(response.Sonuc.DogumTarih).ToString("yyyyMMdd")))
                                            {
                                                p.IsTrusted = false;
                                            }
                                        }
                                        else
                                        {
                                            p.IsTrusted = true;
                                            viewModel.MernisPatientModel = Patient.GetForeignPatientandAdresInfoFromKPS_OLD(response, p, _newPatient, objectContext);

                                        }
                                    }
                                    else//KPS servisten dönen hata
                                    {
                                        TTUtils.InfoMessageService.Instance.ShowMessage(response.Hata);
                                    }
                                }
                            }
                        }
                    }
                    else//new SendToENabiz(this.ObjectContext, this, this.ObjectID, this.ObjectDef.Name, "101", Common.RecTime()); eklenecek 
                    {
                        if (viewModel.fromVerifiedKPSBtn)//KPS den gelen bilgileri direk patientobjesine atabilmesi için
                            _newPatient = true;
                        //viewModel.MernisPatientModel = Patient.GetPatientandAdresInfoFromKPS(p, _newPatient, objectContext);//KPS karşılaştır ekranı burdan taşındığı için buna gerek kalmadı
                        viewModel.MernisPatientModel = Patient.GetPatientandAdresInfoFromKPS(p, true, objectContext);//gelen veriyi patient içine set etmesi için truew gönderildi
                        viewModel.fromVerifiedKPSBtn = false;// daha sonra tekrar bu servis çağrılırsa yeniden sorgulama yapmasın diye


                        /* KPS yüzünden gitmeyen 101 paketleri varsa onlar için tekrar ekle*/
                        //Add101PackageOldSE(p.ObjectID);//KPS yüzendek
                    }
                }
                catch (Exception ex)
                {
                    TTUtils.Logger.WriteException("Error in KPSServis", ex);
                    viewModel.returnMedulaErrorMessage = "KPSError";//daha sonra postscript başında boşaltılıyor. kiosk için geçici çözüm
                    //viewModel.returnMessage += "Mernis bilgileri alınırken bir hata ile karşılaşıldı";
                    if (ex.InnerException != null)
                        TTUtils.InfoMessageService.Instance.ShowMessage(ex.InnerException.Message.ToString());
                    else
                        TTUtils.InfoMessageService.Instance.ShowMessage("Mernis bilgileri alınırken bir hata ile karşılaşıldı");
                }
            }
            #endregion

            //CreatePAForMHRS kPS = new CreatePAForMHRS();
            //kPS.TaskScript();
            //UpdatePatientFromKPS kPS = new UpdatePatientFromKPS();
            //kPS.TaskScript();

            //KioskServices kPS = new KioskServices();
            //ResultSet r= kPS.LoadPatientAdmission1(p.UniqueRefNo);
            //if(r == null)
            //    return null;

            //Schedule kPS = new Schedule();
            //string r = kPS.LoginForMHRS();
            //if (r == null)
            //    return null;

            viewModel._PatientAdmission = PatientAdmission.LoadPatientAdmission(p, objectContext);
            viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientAdmission, formDefID);
            viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientAdmission, formDefID);
            objectContext.LoadFormObjects(formDefID, viewModel._PatientAdmission.ObjectID, objectDefID);
            viewModel.SubEpisode = objectContext.LocalQuery<SubEpisode>().ToArray();
            var se = viewModel._PatientAdmission.FirstSubEpisode;
            var sep = se.FirstSubEpisodeProtocol;
            if (sep == null)
                sep = se.AddSubEpisodeProtocol();

            viewModel.SubEpisodeProtocol = sep;

            FillPatientInfo(objectContext, viewModel);
            FillPatientAdmissionAddressInfo(objectContext, viewModel);
            FillPatientAdmissionHistory(objectContext, viewModel);
            viewModel._PatientAdmission.Building = (ResBuilding)ResBuilding.GetMainBuilding(objectContext).FirstOrDefault();

            LocalQueryToView(viewModel, objectContext);          

            SetDefaultProvisionType(viewModel);
            if (viewModel._PatientAdmission.AdmissionType == null)
                viewModel._PatientAdmission.AdmissionType = viewModel.NormalProvisionType;

            if (viewModel._PatientAdmission.AdmissionType.provizyonTipiKodu == "K")
                viewModel.KurumSevkTalepNo = viewModel._PatientAdmission.KurumSevkTalepNo;

            viewModel.SEProtocolNo = viewModel._PatientAdmission.FirstSubEpisode?.ProtocolNo;
            foreach (EpisodeAction ea in viewModel._PatientAdmission.Episode.EpisodeActions)
            {
                if (ea.SubEpisode.ProtocolNo == viewModel.SEProtocolNo)
                    viewModel.episodeAction = ea;
            }
            viewModel.subEpisode = viewModel._PatientAdmission.FirstSubEpisode;
            if (viewModel._PatientAdmission.Episode.Patient.UniqueRefNo != null)
                viewModel.AppointmentList = PatientAdmission.CheckAppointmentList(viewModel._PatientAdmission.Episode.Patient.ObjectID, Convert.ToInt64(viewModel._PatientAdmission.Episode.Patient.UniqueRefNo), objectContext);

            if (viewModel.AppointmentList != null && viewModel.AppointmentList.Count > 0)
            {
                viewModel.AppointmentListInfo = SetAppointments(viewModel.AppointmentList);
            }

            viewModel.returnMessage = Patient.PatientHasDebt(viewModel._PatientAdmission.Episode.Patient, objectContext);

            if (viewModel._PatientAdmission.ImportantPAInfo != null)
                viewModel.returnMessage += viewModel._PatientAdmission.ImportantPAInfo.ToString();


            SetPayerAndSigortaliTuru(objectContext, viewModel);
            SetPriorityStatus(objectContext, viewModel);
            LoadLastAdmissionStatusInfo(objectContext, viewModel);
            LocalQueryToView(viewModel, objectContext);

            #region parameters&perms
            viewModel.HasBuilding = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HASBUILDING", "FALSE"));
            viewModel.GetTotalSepCount = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETTOTALSEPCOUNT", "FALSE"));
            viewModel.HasTriageArea = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HASTRIAGEAREA", "FALSE"));
            viewModel.RehabilitationApplication = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("REHABILITATIONAPPLICATION", "FALSE"));
            viewModel.DispatchTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("DISPATCHTABACTIVE", "FALSE"));
            viewModel.HealthCommissionTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("HEALTHCOMMISSIONTABACTIVE", "FALSE"));
            viewModel.MainTabActive = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("MAINTABACTIVE", "TRUE"));
            viewModel.CheckMernisRole = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Mernis_Sorgulama);
            viewModel.GizliHastaKabulRole = TTUser.CurrentUser.HasRole(Common.GizliHastaKabulRoleID);
            viewModel.ModifyPatientInfoRole = TTUser.CurrentUser.HasRole(Common.ModifyPatientInfoRoleID);
            viewModel.IsSuperUser = Common.CurrentUser.IsSuperUser;
            viewModel.activeTab = (viewModel._PatientAdmission.AdmissionStatus == null) ? 1 : SetActiveTab(viewModel._PatientAdmission);
            viewModel.hasDoctorKotaRole = TTUser.CurrentUser.HasRole(TTRoleNames.Doktor_Kota_Tanimlama) ? true : false;
            viewModel.hasGiveAppointmentRole = TTUser.CurrentUser.HasRole(TTRoleNames.Randevu_Verme) ? true : false;
            viewModel.HCControlDayLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("HCCONTROLDAYLIMIT", "40"));
            viewModel.ControlPreviousHcExam = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("CONTROLPREVIOUSHCEXAM", "TRUE"));
            viewModel.openKPSLoginInfo = openKPSLoginInfo();
            viewModel.canGetEpicrisisReport = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Kayit_Kabul_Epikriz_Raporu);
            viewModel.getRelatedResourceParam = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETRELATEDRESOURCEPARAM", "TRUE"));
            viewModel.getLastSelectedDoctorandPoliclinic = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETLASTSELECTEDDOCTORANDPOLICLINIC", "TRUE"));
            viewModel.HospitalName = Convert.ToString(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "TRUE"));
            viewModel.VerifiedKpsWithoutApprove = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("VERIFIEDKPSWITHOUTAPPROVE", "TRUE"));
            viewModel.PrintMedulaCodeReport = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("PRINTMEDULACODEREPORT", "TRUE"));
            viewModel.AcilDoktorSecimiZorla = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("ACILDOKTORSECIMIZORLA", "FALSE"));
            viewModel.KurumSevkTalepNoZorla = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("KURUMSEVKTALEPNOZORLA", "FALSE"));

            string paidPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("PAIDPAYERDEFINITION", "4d7b28c8-4f48-4452-afe2-98a30c376b80");
            viewModel.PaidPayerDefinition = objectContext.GetObject<PayerDefinition>(new Guid(paidPayerObjectID), false);

            string healthTourismPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("HEALTHTOURISMPAYERDEFINITION", "adbc5921-3a3a-4a20-beed-471be8c45f23");
            viewModel.HealthTourismPayerDefinition = objectContext.GetObject<PayerDefinition>(new Guid(healthTourismPayerObjectID), false);
            #endregion

            LoadPatientPrivacyTempInfo(viewModel);

            LoadRisLisInfo(viewModel);

            viewModel.ResourcesToBeReferredPoliclinic = GetAllActivePoliclinic();

            List<string> result = new List<string>();

            if (viewModel.getRelatedResourceParam && !viewModel.IsSuperUser)
            {
                GetRelatedResourceParam(viewModel);
                result = viewModel.relatedPoliclinicList.Replace("'", "").Split(',').ToList();
                viewModel.PoliclinicListForFilter = viewModel.ResourcesToBeReferredPoliclinic.Where(x => result.Contains(x.ObjectID.ToString())).ToList();
            }
            else
            {
                viewModel.PoliclinicListForFilter = viewModel.ResourcesToBeReferredPoliclinic.ToList();
            }

            if (viewModel._PatientAdmission.Episode != null && viewModel._PatientAdmission.Episode.Patient != null && viewModel._PatientAdmission.Episode.Patient.Photo != null)
            {
                if (viewModel._PatientAdmission.Episode.Patient.Photo is string)
                {
                    viewModel.PhotoString = viewModel._PatientAdmission.Episode.Patient.Photo.ToString();
                }
                else
                    viewModel.PhotoString = Convert.ToBase64String((byte[])viewModel._PatientAdmission.Episode.Patient.Photo);
            }

            if (viewModel._PatientAdmission.Episode != null && viewModel._PatientAdmission.Episode.Patient != null && viewModel._PatientAdmission.Episode.Patient.MedicalInformation != null)
            {
                viewModel.IsPandemicPatient = viewModel._PatientAdmission.Episode.Patient.MedicalInformation.Pandemic.HasValue ? viewModel._PatientAdmission.Episode.Patient.MedicalInformation.Pandemic.Value : false;
            }

            objectContext.FullPartialllyLoadedObjects();
            return viewModel;
        }

        /// <summary>
        ///  KPS yüzünden gitmeyen 101 paketleri varsa onlar için tekrar ekle
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="objectContext"></param>
        public void Add101PackageOldSE(Guid patientID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<SubEpisode> subEpisodes = SubEpisode.GetByPatient(objectContext, patientID).ToList();

                foreach (var _subepisode in subEpisodes)
                {
                    if (_subepisode.SYSTakipNo == null && _subepisode.Sent101Package.HasValue && _subepisode.Sent101Package.Value && _subepisode.PatientAdmission.IsOldAction != true)
                        new SendToENabiz(objectContext, _subepisode, _subepisode.ObjectID, _subepisode.ObjectDef.Name, "101", Common.RecTime());
                }
                objectContext.Save();
            }
        }

        int SetActiveTab(PatientAdmission pa)
        {
            if (pa.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol || pa.AdmissionStatus == AdmissionStatusEnum.DisaridanGelenKonsultasyon)
                return 2;
            else if (pa.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu)
                return 3;
            else
                return 1;
        }
        public BindingList<PatientAdmissionFormViewModel.vmAppointmentListInfo> SetAppointments(BindingList<Appointment> appointmentList)
        {
            BindingList<PatientAdmissionFormViewModel.vmAppointmentListInfo> app = new BindingList<PatientAdmissionFormViewModel.vmAppointmentListInfo>();
            foreach (var item in appointmentList)
            {
                PatientAdmissionFormViewModel.vmAppointmentListInfo vmApp = new Models.PatientAdmissionFormViewModel.vmAppointmentListInfo();
                vmApp.ObjectID = item.ObjectID;
                vmApp.Masterresourcename = item.MasterResource.Name;
                vmApp.DoctorName = item.Resource != null ? item.Resource.Name : "";
                vmApp.AppDate = item.AppDate;
                vmApp.AppTime = item.StartTime == null ? "" : item.StartTime.Value.ToShortTimeString();
                vmApp.Notes = item.Notes;
                app.Add(vmApp);

            }

            return app;
        }
        void SetPriorityStatus(TTObjectContext objectContext, PatientAdmissionFormViewModel viewModel)
        {
            if (viewModel._PatientAdmission.PriorityStatus == null)
            {
                if (viewModel._PatientAdmission.Payer != null && viewModel._PatientAdmission.Payer.Code != null && viewModel._PatientAdmission.Payer.Code == 28)//SGK (3713/21) öncelik durumu Gazi(G)set edilir
                {
                    viewModel._PatientAdmission.PriorityStatus = PriorityStatusDefinition.GetPriorityStatusByCode(objectContext, "G").FirstOrDefault();
                }
                else if (viewModel._PatientAdmission.Episode != null && viewModel._PatientAdmission.Episode.Patient != null && viewModel._PatientAdmission.Episode.Patient.Age != null && viewModel._PatientAdmission.Episode.Patient.Age >= 65)
                {
                    viewModel._PatientAdmission.PriorityStatus = PriorityStatusDefinition.GetPriorityStatusByCode(objectContext, "Y").FirstOrDefault();
                }
                else if (viewModel._PatientAdmission.Episode != null && viewModel._PatientAdmission.Episode.Patient != null && viewModel._PatientAdmission.Episode.Patient.BirthDate != null && viewModel._PatientAdmission.Episode.Patient.Age != null && viewModel._PatientAdmission.Episode.Patient.Age < 8)
                {
                    viewModel._PatientAdmission.PriorityStatus = PriorityStatusDefinition.GetPriorityStatusByCode(objectContext, "C").FirstOrDefault();
                }
            }
        }

        void SetPoliclinicAndProcedureDoctor(PatientAdmissionFormViewModel viewModel)
        {
            if (viewModel._PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisaridanGelenKonsultasyon || viewModel._PatientAdmission.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol)
            {
                viewModel.tempDispatchPoliclinic = viewModel._PatientAdmission.Policlinic;
                viewModel.tempDispatchProcedureDoctor = viewModel._PatientAdmission.ProcedureDoctor;
            }
            else
            {
                viewModel.tempPoliclinic = viewModel._PatientAdmission.Policlinic;
                viewModel.tempProcedureDoctor = viewModel._PatientAdmission.ProcedureDoctor;
            }
        }

        void SetPayerAndSigortaliTuru(TTObjectContext objectContext, PatientAdmissionFormViewModel viewModel)
        {
            if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("SETDEFAULTPAYERDEFINITION", "FALSE")) == true)
            {

                if (viewModel._PatientAdmission.Episode != null && viewModel._PatientAdmission.Episode.Patient != null && viewModel._PatientAdmission.Episode.Patient.Episodes != null)
                {
                    Episode lastEpisode = viewModel._PatientAdmission.Episode.Patient.Episodes.Where(x => x.ObjectID != viewModel._PatientAdmission.Episode.ObjectID).OrderByDescending(x => x.OpeningDate).FirstOrDefault();
                    SubEpisodeProtocol lastSEP = null;
                    if (lastEpisode != null)
                    {
                        List<SubEpisodeProtocol> sepList = lastEpisode.AllSubEpisodeProtocols();

                        if (sepList.Count > 0)
                            lastSEP = sepList.Where(x => x.PatientAdmission != null && x.Payer.Type.PayerType.Value != PayerTypeEnum.Hospital).OrderByDescending(x => x.CreationDate).FirstOrDefault();

                        if (lastSEP != null && lastSEP.Payer.SelectInPatientAdmission != true)//kurumun yeniden seçilmesi istenmiyor ise
                        {
                            if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("SETDEFAULTPAYERDEFINITION", "FALSE")) == true && lastSEP.Payer == null)
                            {
                                SetDefaultPayerAndSigortaliTuru(objectContext, viewModel);
                                viewModel.showPayerAlert = true;
                            }

                        }
                    }
                    else
                    {
                        SetDefaultPayerAndSigortaliTuru(objectContext, viewModel);
                        viewModel.showPayerAlert = true;
                    }
                }
            }
            else
            {
                PatientAdmission lastPA = PatientAdmission.GetLastPatientAdmission(objectContext, viewModel._PatientAdmission.ObjectID, viewModel._PatientAdmission.Episode.Patient.ObjectID).FirstOrDefault();
                if (lastPA != null && lastPA.Payer != null && lastPA.Payer.SelectInPatientAdmission != true)
                {
                    if (viewModel._PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisaridanGelenKonsultasyon || viewModel._PatientAdmission.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol)
                    {
                        viewModel.tempDispatchPayer = viewModel._PatientAdmission.Payer;
                        viewModel.tempPayer = lastPA.Payer;
                    }
                    else
                        viewModel.tempPayer = viewModel._PatientAdmission.Payer;
                }
                else
                    viewModel.tempPayer = viewModel._PatientAdmission.Payer;
            }
        }

        void SetDefaultPayerAndSigortaliTuru(TTObjectContext objectContext, PatientAdmissionFormViewModel viewModel)
        {
            string sgkPayerObjectID = TTObjectClasses.SystemParameter.GetParameterValue("SGKPAYERDEFINITION", "ef3e2dc7-2ae8-4603-b199-ec4600267856");
            PayerDefinition sgkPayer = objectContext.GetObject(new Guid(sgkPayerObjectID), typeof(PayerDefinition)) as PayerDefinition;

            viewModel._PatientAdmission.Payer = sgkPayer;
            viewModel.tempPayer = sgkPayer;

            viewModel._PatientAdmission.MedulaSigortaliTuru = SigortaliTuru.GetSigortaliTuru("1");

        }
        void FillPatientAdmissionHistory(TTObjectContext objectContext, PatientAdmissionFormViewModel viewModel)
        {
            viewModel.HistoryPatientAdmission = SubEpisodeProtocol.GetPaBySearchPatient(viewModel._PatientAdmission.Episode.Patient.ObjectID);
        }

        void FillPatientInfo(TTObjectContext objectContext, PatientAdmissionFormViewModel viewModel)
        {
            /* if (viewModel._PatientAdmission.Episode.Patient.CityOfBirth != null)
                 objectContext.GetObject<SKRSILKodlari>(viewModel._PatientAdmission.Episode.Patient.CityOfBirth.ObjectID);*/
            if (viewModel._PatientAdmission.Episode.Patient.Nationality == null)
                viewModel._PatientAdmission.Episode.Patient.Nationality = Patient.SetDefaultNationality().FirstOrDefault();
            if (viewModel._PatientAdmission.Episode.Patient.Nationality != null)
                objectContext.GetObject<SKRSUlkeKodlari>(viewModel._PatientAdmission.Episode.Patient.Nationality.ObjectID);

        }

        private TTObjectContext FillPatientAdmissionAddressInfo(TTObjectContext objectContext, PatientAdmissionFormViewModel viewModel)
        {
            if (viewModel._PatientAdmission.PA_Address != null)
            {
                if (viewModel._PatientAdmission.PA_Address.SKRSMahalleKodlari != null)
                    objectContext.GetObject<SKRSMahalleKodlari>(viewModel._PatientAdmission.PA_Address.SKRSMahalleKodlari.ObjectID);
                if (viewModel._PatientAdmission.PA_Address.SKRSKoyKodlari != null)
                    objectContext.GetObject<SKRSKoyKodlari>(viewModel._PatientAdmission.PA_Address.SKRSKoyKodlari.ObjectID);
                if (viewModel._PatientAdmission.PA_Address.SKRSCsbmKodu != null)
                    objectContext.GetObject<SKRSCSBMTipi>(viewModel._PatientAdmission.PA_Address.SKRSCsbmKodu.ObjectID);
                if (viewModel._PatientAdmission.PA_Address.SKRSBucakKodu != null)
                    objectContext.GetObject<SKRSBucakKodlari>(viewModel._PatientAdmission.PA_Address.SKRSBucakKodu.ObjectID);
                if (viewModel._PatientAdmission.PA_Address.SKRSBucakKodu != null)
                    objectContext.GetObject<SKRSIlceKodlari>(viewModel._PatientAdmission.PA_Address.SKRSIlceKodlari.ObjectID);
                if (viewModel._PatientAdmission.PA_Address.SKRSILKodlari != null)
                    objectContext.GetObject<SKRSILKodlari>(viewModel._PatientAdmission.PA_Address.SKRSILKodlari.ObjectID);
                if (viewModel._PatientAdmission.PA_Address.SKRSAdresTipi != null)
                    objectContext.GetObject<SKRSAdresTipi>(viewModel._PatientAdmission.PA_Address.SKRSAdresTipi.ObjectID);
            }

            return objectContext;
        }



        void LocalQueryToView(PatientAdmissionFormViewModel viewModel, TTObjectContext objectContext)
        {
            ContextToViewModel(viewModel, objectContext);

            viewModel.ResourcesToBeReferredGridList = objectContext.LocalQuery<PatientAdmissionResourcesToBeReferred>().ToArray();

            if (viewModel._PatientAdmission.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu)
            {
                foreach (var rr in viewModel.ResourcesToBeReferredGridList)
                {
                    if (string.IsNullOrEmpty(rr.AdmissionQueueNumber))
                    {
                        EpisodeAction ea = viewModel._PatientAdmission.FiredEpisodeActions.FirstOrDefault(dr => dr.MasterResource == rr.Resource);
                        if (ea != null)
                            rr.AdmissionQueueNumber = ea.AdmissionQueueNumber != null ? ea.AdmissionQueueNumber.ToString() : "";
                    }
                }
            }
            viewModel.Citys = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
            viewModel.SigortaliTurus = objectContext.LocalQuery<SigortaliTuru>().ToArray();
            viewModel.IstisnaiHals = objectContext.LocalQuery<IstisnaiHal>().ToArray();
            viewModel.SEPMasters = objectContext.LocalQuery<SEPMaster>().ToArray();
            viewModel.SKRSUlkeKodlaris = objectContext.LocalQuery<SKRSUlkeKodlari>().ToArray();
            viewModel.EDisabledReports = objectContext.LocalQuery<EDisabledReport>().ToArray();
            viewModel.EStatusNotRepCommitteeObjs = objectContext.LocalQuery<EStatusNotRepCommitteeObj>().ToArray();
            viewModel.PriorityStatusDefinitions = objectContext.LocalQuery<PriorityStatusDefinition>().ToArray();
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

        void SavePatientPrivacyTempInfo(PatientAdmissionFormViewModel viewModel, PatientAdmission patientAdmission)
        {
            var p = patientAdmission.Episode.Patient;
            if (TTUser.CurrentUser.HasRole(Common.GizliHastaKabulRoleID) == false)
            {

                if (patientAdmission.PA_Address != null)
                {
                    patientAdmission.PA_Address.HomeAddress = viewModel.tempHomeAddress;
                    patientAdmission.PA_Address.MobilePhone = viewModel.tempMobilePhone;
                }
                p.Name = viewModel.tempName;
                p.Surname = viewModel.tempSurname;
                p.UniqueRefNo = viewModel.tempUniqueRefNo;
            }
            else
            {
                if (p.Privacy == true)
                {
                    p.PrivacyHomeAddress = viewModel.tempHomeAddress;
                    p.PrivacyMobilePhone = viewModel.tempMobilePhone;

                    p.Name = viewModel.tempPrivacyName;
                    p.Surname = viewModel.tempPrivacySurname;

                    p.PrivacyName = viewModel.tempName;
                    p.PrivacySurname = viewModel.tempSurname;
                    p.PrivacyUniqueRefNo = viewModel.tempUniqueRefNo;
                }
                else
                {
                    if (patientAdmission.PA_Address != null)
                    {
                        patientAdmission.PA_Address.HomeAddress = viewModel.tempHomeAddress;
                        patientAdmission.PA_Address.MobilePhone = viewModel.tempMobilePhone;
                    }
                    p.Name = viewModel.tempName;
                    p.Surname = viewModel.tempSurname;
                    p.UniqueRefNo = viewModel.tempUniqueRefNo;
                }
            }

            Patient.SetPrivacyInfo(p);
        }
        private static bool IsValidImage(string base64Data)
        {
            byte[] binaryData = Convert.FromBase64String(base64Data);
            try
            {
                using (MemoryStream ms = new MemoryStream(binaryData))
                {
                    Image.FromStream(ms);
                }
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        partial void PostScript_PatientAdmissionForm(PatientAdmissionFormViewModel viewModel, PatientAdmission patientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //string returnMessage = ControlPreviousTreatmentExceptions(patientAdmission.Episode.Patient.ObjectID);//Bugün içinde Acil müşahede var mı?
            viewModel.returnMedulaErrorMessage = "";

            if (viewModel.ResourcesToBeReferredGridList != null)
            {
                foreach (var item in viewModel.ResourcesToBeReferredGridList)
                {
                    var resourcesToBeReferredImported = (PatientAdmissionResourcesToBeReferred)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)resourcesToBeReferredImported).IsDeleted)
                    {
                        EpisodeAction _deletedHCExamination = patientAdmission.FiredEpisodeActions.Where(z => z.MasterResource.ObjectID == (Guid)item["RESOURCE"]
                        && z.ProcedureDoctor.ObjectID == (Guid)item["PROCEDUREDOCTORTOBEREFERRED"]).FirstOrDefault();

                        if (_deletedHCExamination is PatientExamination)
                        {
                            if (_deletedHCExamination.CurrentStateDefID != PatientExamination.States.Examination)
                                throw new TTUtils.TTException("Muayeneye başlanmış bir polikliniğe ait veriyi silemezsiniz");
                            else
                                _deletedHCExamination.CurrentStateDefID = PatientExamination.States.Cancelled;
                        }

                    }

                }
            }

            //objectContext.AddToRawObjectList(viewModel.SEPMasters);
            //objectContext.AddToRawObjectList(viewModel.SubEpisode);
            //objectContext.AddToRawObjectList(viewModel.SubEpisodeProtocol);
            ////objectContext.AddToRawObjectList(viewModel.ResourcesToBeReferredGridList);
            //objectContext.ProcessRawObjects();


            if (patientAdmission.Episode.Patient == null)
                throw new TTUtils.TTException("Episode.Patient is null");

            if (patientAdmission.Episode.Patient.PatientAddress == null)
                patientAdmission.Episode.Patient.PatientAddress = new PatientIdentityAndAddress(objectContext);

            SavePatientPrivacyTempInfo(viewModel, patientAdmission);

            //Set payer
            if (viewModel.tempDispatchPayer != null)
            {
                patientAdmission.Payer = viewModel.tempDispatchPayer;
                patientAdmission.Policlinic = viewModel.tempDispatchPoliclinic;
                patientAdmission.ProcedureDoctor = viewModel.tempDispatchProcedureDoctor;
            }
            else
            {
                patientAdmission.Payer = viewModel.tempPayer;
                patientAdmission.Policlinic = viewModel.tempPoliclinic;
                patientAdmission.ProcedureDoctor = viewModel.tempProcedureDoctor;
            }

            patientAdmission.KurumSevkTalepNo = viewModel.KurumSevkTalepNo;

            EDisabledReport eDisabledReport = null;
            if (patientAdmission.HCRequestReason != null)
            {
                if (patientAdmission.HCRequestReason.ReasonForExamination != null)
                {
                    if (patientAdmission.HCRequestReason.ReasonForExamination.HCReportTypeDefinition != null)
                    {
                        if (patientAdmission.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
                        {
                            eDisabledReport = patientAdmission.EDisabledReport;
                            //viewModel.disabledReportProperties.EDisabledReportObjectId = eDisabledReport.ObjectID;
                            //eDisabledReport.ApplicationCouncilSituation = EngelliRaporuMuayeneAdimiEnum.PatientAppCreated;
                            //eDisabledReport.ApplicationExplanation = viewModel.disabledReportProperties.ApplicationExplanation;
                            //eDisabledReport.ApplicationReason = viewModel.disabledReportProperties.ApplicationReason;
                            //eDisabledReport.ApplicationType = viewModel.disabledReportProperties.ApplicationType;
                            //eDisabledReport.CorporateApplicationType = viewModel.disabledReportProperties.CorporateApplicationType;
                            //eDisabledReport.PersonalApplicationType = viewModel.disabledReportProperties.PersonalApplicationType;
                            //eDisabledReport.TerrorAccidentInjuryAppReason = viewModel.disabledReportProperties.TerrorAccidentInjuryAppReason;
                            //eDisabledReport.TerrorAccidentInjuryAppType = viewModel.disabledReportProperties.TerrorAccidentInjuryAppType;

                        }
                    }
                }
            }

            EStatusNotRepCommitteeObj eStatusNotRepCommitteeObj = null;
            if (patientAdmission.EStatusNotRepCommitteeObj != null)
            {
                eStatusNotRepCommitteeObj = patientAdmission.EStatusNotRepCommitteeObj;
            }


            viewModel._PatientAdmission = PatientAdmission.SavePatientAdmission(patientAdmission, viewModel.activeTab, viewModel.AddProcedureToHC, eDisabledReport, eStatusNotRepCommitteeObj);
            if (string.IsNullOrEmpty(viewModel.PhotoString) == false && IsValidImage(viewModel.PhotoString))
            {
                byte[] photo = Convert.FromBase64String(viewModel.PhotoString);
                if (photo.Length > 5000000)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25089", "5 Mb'ı aşan boyutta görüntü yükleyemezsiniz!"));
                else if (!FileTypeCheck.fileTypeCheck(photo, "fileName"))
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25690", "Geçersiz dosya tipi!"));
                viewModel._PatientAdmission.Episode.Patient.Photo = photo;
            }
            //parametrik olarak provizyon alınaması durumunda kullanıcıya ücretli kabul/mevcut kurum ile kabul oluşturma ya da kabul iptal seçenekleri sorulur
            if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULATAKIPALMAMETODU", "") == "S")
            {
                if (viewModel.GetProvisionFromMedula == true)
                {
                    string medulaRes = "";

                    try
                    {
                        if (patientAdmission.Episode.Patient.UnIdentified != true && patientAdmission.IsSGKPatientAdmission && patientAdmission.Episode.Patient.Alive != false && patientAdmission.Episode.Patient.Death != true)
                        {
                            if (patientAdmission.SEP != null && patientAdmission.SEP.MedulaTakipNo == null)
                            {
                                SubEpisodeProtocol.MedulaResult mr = patientAdmission.SEP.GetProvisionFromMedula();
                                medulaRes = mr.SonucMesaji;
                                if (mr.Succes == false)
                                {
                                    viewModel.returnMessage = medulaRes;
                                    viewModel.returnMedulaErrorMessage = "ProvisionError";
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(mr.DevredilenKurumAdi))
                                    {
                                        viewModel.medulaTransferredPayerWarningDTO.DevredilenKurumAdi = patientAdmission.SEP.Payer.MedulaDevredilenKurum.devredilenKurumAdi;
                                        viewModel.medulaTransferredPayerWarningDTO.medulaResult = mr;
                                        var patient = viewModel._PatientAdmission.Episode.Patient;
                                        viewModel.medulaTransferredPayerWarningDTO.patient = new PatientDTO
                                        {
                                            BirthDate = patient.BirthDate,
                                            Gender = patient.Sex.ADI,
                                            Name = patient.Name,
                                            Surname = patient.Surname,
                                            TCNo = patient.UniqueRefNo
                                        };
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        viewModel.returnMessage = medulaRes;
                        viewModel.returnMedulaErrorMessage = "ProvisionError";
                    }
                }
            }

            foreach (var firedAction in patientAdmission.FiredEpisodeActions)
            {
                if (firedAction is Consultation)
                {
                    if (firedAction.CurrentStateDefID == Consultation.States.NewRequest)
                    {
                        firedAction.ObjectContext.Update();
                        firedAction.CurrentStateDefID = Consultation.States.RequestAcception;
                    }

                    if (firedAction.CurrentStateDefID == Consultation.States.RequestAcception)
                    {
                        firedAction.ObjectContext.Update();
                        firedAction.CurrentStateDefID = Consultation.States.Consultation;
                    }
                }
            }
        }

        #region ACİL BİRLEŞTİRME
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<ResPoliclinic> GetEmergencyPolList()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ResPoliclinic.GetPoliclinicByMedulaBrans(objectContext, "4400").Where(x => x.IsActive == true).ToList<ResPoliclinic>();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<ResUser.SpecialistDoctorListNQL_Class> GetEmergencyDocList(string ResourceID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ResUser.SpecialistDoctorListNQL(" AND THIS.USERRESOURCES.RESOURCE='" + ResourceID + "' AND ISACTIVE = 1").ToList<ResUser.SpecialistDoctorListNQL_Class>();
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string MergeEmergencyIntervention(MergeEmergencyClass mergeEmergencyClass)
        {
            DateTime dateLimit = Convert.ToDateTime(Common.RecTime()).Date;
            List<Guid> plist = new List<Guid>();
            plist.Add(mergeEmergencyClass.patient.ObjectID);

            using (TTObjectContext context = new TTObjectContext(false))
            {
                List<PatientAdmission> patientAdmissionList = PatientAdmission.GetByDateAndPatients(context, dateLimit, dateLimit.AddDays(1), plist).Where(p => p.CurrentStateDefID != PatientAdmission.States.Cancelled
                && p.Department != null && p.Department.Brans != null && p.Department.Brans.Code == "4400").OrderBy(p => p.ActionDate).ToList();

                if (patientAdmissionList != null && patientAdmissionList.Count > 0)
                {
                    ResUser doctor = context.GetObject(new Guid(mergeEmergencyClass.emergencyDoctor), typeof(ResUser)) as ResUser;
                    ResPoliclinic policlinic = context.GetObject(new Guid(mergeEmergencyClass.emergencyPoliclinic), typeof(ResPoliclinic)) as ResPoliclinic;
                    PatientAdmission.FireEpisodeActionAndSubActionProcedure(patientAdmissionList[0], mergeEmergencyClass.patient, true, doctor, policlinic, mergeEmergencyClass.emergencyTriage);
                    context.Save();
                }
                else
                {
                    throw new Exception("Bugüne Ait Birleştirilecek Uygun Bir Acil Kabulü Bulunamadı");
                }

            }


            return "";
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<string> GetEmergencyExamBarcodeList(Guid PatientAdmission)
        {
            List<string> dateList = new List<string>();
            using (TTObjectContext context = new TTObjectContext(false))
            {
                List<PatientExamination.GetPatientExaminationByPA_Class> examList = PatientExamination.GetPatientExaminationByPA(context, PatientAdmission).OrderBy(p => p.RequestDate).ToList();

                if (examList != null && examList.Count > 0)
                {
                    foreach (PatientExamination.GetPatientExaminationByPA_Class item in examList)
                    {
                        dateList.Add(item.RequestDate.Value.ToString("dd.MM.yyyy HH:mm"));
                    }
                   
                }

            }

            return dateList;

        }



        private string ControlPreviousTreatmentExceptions(Guid patientID)
        {
            DateTime dateLimit = Convert.ToDateTime(Common.RecTime()).Date;
            List<System.Guid> specialityList = new List<System.Guid>();

            System.ComponentModel.BindingList<InPatientPhysicianApplication.GetEmergencyInterventionByPatient_Class> getEmergencies = InPatientPhysicianApplication.GetEmergencyInterventionByPatient(patientID, dateLimit);

            if (getEmergencies != null && getEmergencies.Count > 0)
            {
                throw new Exception("Gün içerisinde hasta \'Acil Müşahedeye\' alındığı için tekrar kabul alamazsınız.");
            }
            return string.Empty;

            ////System.ComponentModel.BindingList<Episode> oldEpisodes = Episode.GetByDayLimitAndMainSpeciality(objectContext, dateLimit.Date, specialityList.ToArray(), patientAdmission.Episode.Patient.ObjectID.ToString(), Convert.ToDateTime(patientAdmission.ActionDate).Date);
            //System.ComponentModel.BindingList<Episode> oldEpisodes2 = Episode.GetSameByDayLimitAndMainSpeciality(objectContext, dateLimit, specialityList.ToArray(), patientAdmission.Episode.Patient.ObjectID.ToString());
            //if (oldEpisodes2 != null && oldEpisodes2.Count > 0)
            //{
            //    foreach (Episode tempEpisode in oldEpisodes2)
            //    {
            //        if (patientAdmission.Episode == null || (patientAdmission.Episode != null && patientAdmission.Episode.ObjectID != tempEpisode.ObjectID))
            //        {
            //            if (tempEpisode.PatientStatus == PatientStatusEnum.Outpatient)
            //            {
            //                foreach (var subEpisode in tempEpisode.SubEpisodes.Where(x => x.CurrentStateDefID != SubEpisode.States.Cancelled))
            //                {
            //                    if (subEpisode.PatientAdmission.AdmissionType.provizyonTipiKodu == patientAdmission.AdmissionType.provizyonTipiKodu)
            //                    {
            //                        if (patientAdmission.Payer == null)
            //                            throw new Exception("gün içerisinde hastanın aynı geliş sebebi ile Acil Kabulü mevcuttur.Lütfen yardımcı menüler altından Acil kabul birleştirme yapınız.");
            //                    }
            //                }
            //            }
            //            else
            //                throw new Exception("Bu iş olmaz");
            //        }
            //    }
            //}

            //throw new Exception("asdasda");
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SevkTalepNoSonuc SevkNoSorgula(string PatientID)
        {
            SevkTalepNoSonuc result = new SevkTalepNoSonuc();
            using (var objectContext = new TTObjectContext(false))
            {
                Patient patient = objectContext.GetObject<Patient>(new Guid(PatientID));
                MedulaYardimciIslemler.kurumSevkTalepNoSorguCevapDVO cevap = patient.kurumSevkTalepNoSorgu();
                result.sonucKodu = cevap.sonucKodu;
                result.sonucMesaji = cevap.sonucMesaji;
                result.SevkTalepNoSonucDetay = new List<SevkTalepNoSonucDetay>();
                if(cevap.sonucKodu =="0000")
                {
                    foreach(MedulaYardimciIslemler.kurumSevkTalepNoSorguDetayDVO detay in cevap.kurumSevkGirisDetay)
                    {
                        SevkTalepNoSonucDetay d = new SevkTalepNoSonucDetay();
                        d.kurumSevkTalepNo = detay.kurumSevkTalepNo;
                        d.hastaBasvuruNo = detay.hastaBasvuruNo;
                        d.saglikTesisKodu = detay.saglikTesisKodu;
                        d.sevkTarihi = detay.sevkTarihi;
                        d.aciklama = detay.aciklama;
                        result.SevkTalepNoSonucDetay.Add(d);
                    }
                }
            }

            return result;
        }


        #endregion

        #region YUPAS BELGE SORGULAMA
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<YurtDisiYardimHakki> GetYupasBelgeList([FromQuery] string ResourceID)
        {
            try
            {
                MedulaYardimciIslemler.yurtDisiYardimHakkiGetirGirisDVO yurtDisiYardimHakkiGetirGirisDVO = new MedulaYardimciIslemler.yurtDisiYardimHakkiGetirGirisDVO();
                yurtDisiYardimHakkiGetirGirisDVO.kisiNo = ResourceID;
                yurtDisiYardimHakkiGetirGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                yurtDisiYardimHakkiGetirGirisDVO.provizyonTarihi = Common.RecTime().ToString("dd.MM.yyyy");

                List<YurtDisiYardimHakki> partialProvision = new List<YurtDisiYardimHakki>();
                int? retValue = null;
                if (TTObjectClasses.SystemParameter.GetParameterValue("MEDULATAKIPALMAMETODU", "") == "S")
                {
                    MedulaYardimciIslemler.yurtDisiYardimHakkiGetirCevapDVO response = MedulaYardimciIslemler.WebMethods.yurtDisiYardimHakkiGetirSync(TTObjectClasses.Sites.SiteLocalHost, yurtDisiYardimHakkiGetirGirisDVO);
                    if (response.sonucKodu == null)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27263", "YUPASS Hatası. Medula'dan cevap alınamıyor!"));
                    else if (response.sonucKodu == "0000")
                    {
                        foreach (MedulaYardimciIslemler.yurtDisiYardimHakkiGetirCevapDetayDVO detayDVO in response.yurtDisiDetay)
                        {
                            YurtDisiYardimHakki yurtDisiYardim = new YurtDisiYardimHakki();

                            yurtDisiYardim.YardimHakID = detayDVO.id;
                            yurtDisiYardim.Aciklama = detayDVO.aciklama;
                            yurtDisiYardim.Formul = detayDVO.formulAdi;

                            partialProvision.Add(yurtDisiYardim);
                        }
                    }
                }

                return partialProvision;
            }
            catch (Exception ex)
            {
                int a = 0;
            }

            return null;
        }
        #endregion

        #region TRIAJ EKRANI AÇMA

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<ShortHcInfo> GetTriageInfoList(string PATIENTADMISSION)
        {
            List<ShortHcInfo> _objectList = new List<ShortHcInfo>();

            using (var objectContext = new TTObjectContext(false))
            {
                List<EmergencyIntervention.GetEmergencyIntByPA_Class> _list = EmergencyIntervention.GetEmergencyIntByPA(objectContext, PATIENTADMISSION).ToList().OrderByDescending(x => x.ActionDate).ToList<EmergencyIntervention.GetEmergencyIntByPA_Class>();
                foreach (var item in _list)
                {
                    ShortHcInfo shortHc = new ShortHcInfo();
                    shortHc.HCReportName = item.ActionDate.Value.ToString("dd/MM/yyyy HH:mm:ss") + " - " + item.Doctor;

                    if (item.Triage != null && item.Triage.HasValue)
                        shortHc.HCReportName += " - " + objectContext.GetObject<SKRSTRIAJKODU>(item.Triage.Value).ADI + " ALAN";

                    shortHc.ObjectID = item.ObjectID.Value;

                    _objectList.Add(shortHc);
                }

                return _objectList;
            }
        }
        #endregion

        partial void AfterContextSaveScript_PatientAdmissionForm(PatientAdmissionFormViewModel viewModel, PatientAdmission patientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (patientAdmission.FirstSubEpisode != null && patientAdmission.FirstSubEpisode.ProtocolNo == null)
                viewModel.SEProtocolNo = patientAdmission.FirstSubEpisode.GetAndSetNextProtocolNo();
            foreach (EpisodeAction ea in viewModel._PatientAdmission.Episode.EpisodeActions)
            {
                if (ea.SubEpisode.ProtocolNo == viewModel.SEProtocolNo)
                    viewModel.episodeAction = ea;
            }
            viewModel.subEpisode = viewModel._PatientAdmission.FirstSubEpisode;


            if (patientAdmission.Episode.Patient.HasMemberChanged("IsTrusted") && patientAdmission.Episode.Patient.IsTrusted == true)
                new SendToENabiz(objectContext, patientAdmission.FirstSubEpisode, patientAdmission.FirstSubEpisode.ObjectID, patientAdmission.FirstSubEpisode.ObjectDef.Name, "101", Common.RecTime());



            if (patientAdmission.FiredEpisodeActions != null)
            {
                foreach (EpisodeAction firedAction in patientAdmission.FiredEpisodeActions)
                {
                    if (firedAction.IsCancelled == false && firedAction.HasActiveQueueItem() == false)
                    {
                        IList<ExaminationQueueDefinition> myQueue = ExaminationQueueDefinition.GetQueueByResource(patientAdmission.ObjectContext, firedAction.MasterResource.ObjectID.ToString());
                        if (myQueue.Count > 0)
                            firedAction.CreateExaminationQueueItem(patientAdmission, myQueue[0], (Boolean)firedAction.Emergency);
                    }
                }
            }
            objectContext.Save();

            if (patientAdmission.HCRequestReason != null)
            {
                if (patientAdmission.HCRequestReason.ReasonForExamination != null)
                {
                    if (patientAdmission.HCRequestReason.ReasonForExamination.HCReportTypeDefinition != null)
                    {
                        if (patientAdmission.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
                        {
                            EDisabledReport eDisabledReport = patientAdmission.ObjectContext.GetObject<EDisabledReport>(viewModel._PatientAdmission.EDisabledReport.ObjectID);
                            if (viewModel._PatientAdmission.Episode.Patient.Age < 18)
                            {
                                eDisabledReport.IsCozgerReport = true;
                                objectContext.Save();
                            }
                        }
                        else
                        {
                            string entegrasyonAktif = TTObjectClasses.SystemParameter.GetParameterValue("EDURUMBILDIRIRKURULENTAKTIF", "FALSE");
                            if (entegrasyonAktif == "TRUE" && patientAdmission.HCRequestReason.ReasonForExamination.IntegratedReporting == true)
                            {
                                EDurumBildirirKurulServiceController.CreateEDurumBildirirKurulApplication(viewModel._PatientAdmission.EStatusNotRepCommitteeObj, objectContext, null);
                            }
                        }
                    }

                }

            }
        }

        void SetDefaultProvisionType(PatientAdmissionFormViewModel viewModel)
        {
            var readOnlyObjectContext = new TTObjectContext(true);
            BindingList<ProvizyonTipi> _emergencyList = ProvizyonTipi.GetProvizyonTipiByKodu(readOnlyObjectContext, "A");
            viewModel.EmergencyProvisionType = _emergencyList[0];
            BindingList<ProvizyonTipi> _normalList = ProvizyonTipi.GetProvizyonTipiByKodu(readOnlyObjectContext, "N");
            viewModel.NormalProvisionType = _normalList[0];
            BindingList<ProvizyonTipi> _3713list = ProvizyonTipi.GetProvizyonTipiByKodu(readOnlyObjectContext, "E");
            viewModel.ProvizyonType3713 = _3713list[0];
        }
        void LoadRisLisInfo(PatientAdmissionFormViewModel viewModel)
        {
            string TCKimlikNo;
            Patient p = viewModel._PatientAdmission.Episode.Patient;
            if (p.UniqueRefNo != null)
                TCKimlikNo = Convert.ToString(p.UniqueRefNo);
            else if (p.PassportNo != null)
                TCKimlikNo = p.PassportNo.ToString();
            else
                TCKimlikNo = "10000000000";

            viewModel.AllProceduresLink = TTObjectClasses.SystemParameter.GetParameterValue("PACSVIEWERURL", "") + "?tc=" + TCKimlikNo + "&usr=extreme";
            viewModel.AllLabProceduresLink = Modules.Tibbi_Surec.Tetkik_Istem_Modulu.ProcedureRequestServiceController.GetURLForAllEpisodeTestResultsForPatientHistory(TCKimlikNo);
        }
        void LoadLastAdmissionStatusInfo(TTObjectContext objectContext, PatientAdmissionFormViewModel viewModel)
        {
            if (viewModel._PatientAdmission.Episode != null && viewModel._PatientAdmission.Episode.Patient != null && viewModel._PatientAdmission.Episode.Patient.Episodes != null)
            {
                Episode lastEpisode = viewModel._PatientAdmission.Episode.Patient.Episodes.Where(x => x.ObjectID != viewModel._PatientAdmission.Episode.ObjectID).OrderByDescending(x => x.OpeningDate).FirstOrDefault();
                SubEpisodeProtocol lastSEP = null;
                if (lastEpisode != null)
                {
                    List<SubEpisodeProtocol> sepList = lastEpisode.AllSubEpisodeProtocols();

                    if (sepList.Count > 0)
                        lastSEP = sepList.Where(x => x.PatientAdmission != null && x.Payer.Type.PayerType.Value != PayerTypeEnum.Hospital).OrderByDescending(x => x.CreationDate).FirstOrDefault();

                    if (lastSEP != null)
                    {
                        if (lastSEP.MedulaVakaTarihi != null)
                            viewModel._PatientAdmission.MedulaVakaTarihi = lastSEP.MedulaVakaTarihi;
                        if (lastSEP.MedulaPlakaNo != null)
                            viewModel.SubEpisodeProtocol.MedulaPlakaNo = lastSEP.MedulaPlakaNo;
                    }
                }

                PatientAdmission lastPA = PatientAdmission.GetLastPatientAdmission(objectContext, viewModel._PatientAdmission.ObjectID, viewModel._PatientAdmission.Episode.Patient.ObjectID).FirstOrDefault();
                if (lastPA != null)
                {
                    if (lastPA.PatientClassGroup != null)
                        viewModel._PatientAdmission.PatientClassGroup = lastPA.PatientClassGroup;

                    if (lastPA.ApplicationReason != null)
                        viewModel._PatientAdmission.ApplicationReason = lastPA.ApplicationReason;
                }
            }
        }
        void LoadPatientPrivacyTempInfo(PatientAdmissionFormViewModel viewModel)
        {
            if (TTUser.CurrentUser.HasRole(Common.GizliHastaKabulRoleID) == false || viewModel._PatientAdmission.Episode.Patient.Privacy != true)
            {
                if (viewModel._PatientAdmission.PA_Address != null)
                {
                    viewModel.tempHomeAddress = viewModel._PatientAdmission.PA_Address.HomeAddress;
                    viewModel.tempMobilePhone = viewModel._PatientAdmission.PA_Address.MobilePhone;
                }

                viewModel.tempName = viewModel._PatientAdmission.Episode.Patient.Name;
                viewModel.tempSurname = viewModel._PatientAdmission.Episode.Patient.Surname;
                viewModel.tempUniqueRefNo = viewModel._PatientAdmission.Episode.Patient.UniqueRefNo;
                //Aşağıdakileri sakın açma
                //viewModel.tempPrivacyName = viewModel._PatientAdmission.Episode.Patient.PrivacyName;
                //viewModel.tempPrivacySurname = viewModel._PatientAdmission.Episode.Patient.PrivacySurname;
            }
            else
            {
                if (viewModel._PatientAdmission.Episode.Patient.Privacy == true)
                {
                    viewModel.tempHomeAddress = viewModel._PatientAdmission.Episode.Patient.PrivacyHomeAddress;
                    viewModel.tempMobilePhone = viewModel._PatientAdmission.Episode.Patient.PrivacyMobilePhone;

                    viewModel.tempPrivacyName = viewModel._PatientAdmission.Episode.Patient.Name;
                    viewModel.tempPrivacySurname = viewModel._PatientAdmission.Episode.Patient.Surname;

                    viewModel.tempName = viewModel._PatientAdmission.Episode.Patient.PrivacyName;
                    viewModel.tempSurname = viewModel._PatientAdmission.Episode.Patient.PrivacySurname;
                    viewModel.tempUniqueRefNo = viewModel._PatientAdmission.Episode.Patient.PrivacyUniqueRefNo;
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Saglik_Kurulu_Sebepleri_Gorme, TTRoleNames.Yatan_Hasta_Saglik_Kurulu)]
        public GetHCRequestReasonDetailsResponse GetHCRequestReasonDetails(Guid requestReasonObjectID)
        {
            GetHCRequestReasonDetailsResponse hCRequestReasonDetailsResponse = new GetHCRequestReasonDetailsResponse();

            HCRequestReasonDetail requestReasonDetail = new HCRequestReasonDetail();
            requestReasonDetail.HospitalsUnits = new List<HCHospitalUnit>();
            using (TTObjectContext context = new TTObjectContext(false))
            {
                HCRequestReason hcRequestReason = context.GetObject(requestReasonObjectID, typeof(HCRequestReason)) as HCRequestReason;
                context.FullPartialllyLoadedObjects();
                if (hcRequestReason.ReasonForExamination != null)
                {
                    requestReasonDetail.ReasonForExaminationDefinition = hcRequestReason.ReasonForExamination;
                    hCRequestReasonDetailsResponse.reportTypeDefinition = hcRequestReason.ReasonForExamination.HCReportTypeDefinition;
                    foreach (HospitalsUnitsDefinitionGrid hospitalUnit in hcRequestReason.ReasonForExamination.HospitalsUnits)
                    {
                        HCHospitalUnit hcHospitalUnit = new HCHospitalUnit();
                        hcHospitalUnit.HospitalsUnit = hospitalUnit;
                        hcHospitalUnit.Policlinic = hospitalUnit.Policklinic;
                        hcHospitalUnit.ProcedureDoctor = hospitalUnit.ProcedureDoctor;
                        hcHospitalUnit.Speciality = hospitalUnit.Speciality;
                        requestReasonDetail.HospitalsUnits.Add(hcHospitalUnit);
                    }
                }
                hCRequestReasonDetailsResponse.requestReasonDetail = requestReasonDetail;
            }

            return hCRequestReasonDetailsResponse;
        }

        public class GetHCRequestReasonDetailsResponse
        {
            public HCRequestReasonDetail requestReasonDetail { get; set; }
            public HCReportTypeDefinition reportTypeDefinition { get; set; }
        }

        public class PolyclinicDoctorBranchGroupModel
        {
            public ResPoliclinic PolyclinicObject
            {
                get;
                set;
            }

            public ResUser ProcedureDoctorObject
            {
                get;
                set;
            }

            public ResDepartment BranchObject
            {
                get;
                set;
            }

            public int DoctorPoliclinicRelationCount;
            public PolyclinicDoctorBranchGroupModel(ResPoliclinic resPol, ResUser resUs, ResDepartment resDep)
            {
                this.PolyclinicObject = resPol;
                this.ProcedureDoctorObject = resUs;
                this.BranchObject = resDep;
                this.DoctorPoliclinicRelationCount = 0;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<PolyclinicDoctorBranchGroupModel> PolyclinicAndBranchByProcedureDoctor(ResUser procedureDoctor)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                IBindingList userResources = UserResource.GetByUser(objectContext, procedureDoctor.ObjectID);
                List<PolyclinicDoctorBranchGroupModel> resultList = new List<PolyclinicDoctorBranchGroupModel>();
                foreach (UserResource ur in userResources)
                {
                    if (ur.Resource is ResPoliclinic)
                    {
                        try
                        {
                            PolyclinicDoctorBranchGroupModel pp = new PolyclinicDoctorBranchGroupModel(null, procedureDoctor, null);
                            ResPoliclinic resPol = (ResPoliclinic)ur.Resource;
                            pp.PolyclinicObject = resPol;
                            pp.BranchObject = resPol.Department;
                            pp.DoctorPoliclinicRelationCount++;
                            resultList.Add(pp);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return resultList;
                        }
                    }
                }


                return resultList;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public PolyclinicDoctorBranchGroupModel BranchByPolyclinic(ResPoliclinic polyclinic)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ResPoliclinic resPoliclinic = objectContext.GetObject<ResPoliclinic>(polyclinic.ObjectID);
                ResDepartment resDepartment = resPoliclinic.Department;
                PolyclinicDoctorBranchGroupModel pp = new PolyclinicDoctorBranchGroupModel(polyclinic, null, resDepartment);

                return pp;
            }
        }
        public void TopluTakipAl(string startdate, string enddate)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<SubEpisodeProtocol.GetPAInfoByDateWithoutProvision_Class> sepList = SubEpisodeProtocol.GetPAInfoByDateWithoutProvision(Convert.ToDateTime(startdate), Convert.ToDateTime(enddate).AddDays(1), Common.CurrentResource.ObjectID);
                if (sepList != null)
                {
                    foreach (var item in sepList)
                    {
                        try
                        {
                            PatientAdmission pa = objectContext.GetObject(item.Paid.Value, typeof(PatientAdmission)) as PatientAdmission;
                            SubEpisodeProtocol.MedulaResult mr = pa.SEP.GetProvisionFromMedula();
                            pa.SEP.MedulaSonucKodu = mr.SonucKodu;
                            pa.SEP.MedulaSonucMesaji = mr.SonucMesaji;
                            if (!String.IsNullOrEmpty(mr.TakipNo))
                                pa.SEP.MedulaTakipNo = mr.TakipNo;

                            objectContext.Save();
                        }
                        catch (Exception)
                        {

                            continue;
                        }

                    }
                }
            }
        }

        [HttpPost]
        public List<DepartmentModel> FillDepartmentList(InputModelForQueries input)
        {
            //RelatedResourceList _list = null;
            //if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETRELATEDRESOURCEPARAM", "TRUE")) && !Common.CurrentUser.IsSuperUser)
            //{
            //    _list = GetRelatedResourceParam2();
            //    input.filter += " AND THIS.OBJECTID IN(" + _list.relatedBransList + ")";
            //}
            List<ResDepartment.GetDepartmentDefinition_Class> DepartmentListFromQuery = ResDepartment.GetDepartmentDefinition(input.filter).ToList();
            List<DepartmentModel> DepartmentList = new List<DepartmentModel>();
            foreach (ResDepartment.GetDepartmentDefinition_Class department in DepartmentListFromQuery)
            {

                DepartmentModel departmentModel = new DepartmentModel();

                departmentModel.Name = department.Name;
                departmentModel.NameShadow = department.Name_Shadow;
                departmentModel.NameLower = department.Name.ToLower();
                departmentModel.NameUpper = department.Name.ToUpper();
                departmentModel.ObjectID = department.ObjectID;
                departmentModel.IsEmergencyDepartment = department.IsEmergencyDepartment;
                DepartmentList.Add(departmentModel);
            }
            //(o.Title == null ? "" : (Common.GetDescriptionOfDataTypeEnum(o.Title.Value) + " ")) + o.Name
            return DepartmentList;
        }

        [HttpPost]
        public List<PoliclinicModel> FillPoliclinicList(InputModelForQueries input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                //RelatedResourceList _list = null;
                //if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("GETRELATEDRESOURCEPARAM", "TRUE")) && !Common.CurrentUser.IsSuperUser)
                //{
                //    _list = GetRelatedResourceParam2();
                //    input.filter += " AND THIS.OBJECTID IN(" + _list.relatedPoliclinicList + ")";
                //}

                List<ResPoliclinic.GetPoliclinicListDefinition_Class> PoliclinicListFromQuery = ResPoliclinic.GetPoliclinicListDefinition(input.filter).ToList();
                List<PoliclinicModel> PoliclinicList = new List<PoliclinicModel>();
                foreach (ResPoliclinic.GetPoliclinicListDefinition_Class klinik in PoliclinicListFromQuery)
                {
                    PoliclinicModel klinikModel = new PoliclinicModel();
                    klinikModel.Name = klinik.Name;
                    klinikModel.ObjectID = klinik.ObjectID;

                    bool _control = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("SHOWPACOUNTBYPOLICLINIC", "FALSE"));

                    if (_control)
                    {
                        BindingList<PatientAdmissionCount> counterList = PatientAdmissionCount.GetPaCountByPoliclinic(objectContext, klinik.ObjectID.Value, Common.RecTime().Date, Common.RecTime().AddDays(1).Date.AddMinutes(-1));
                        if (counterList.Count > 0)
                        {
                            klinikModel.Name += " ( " + Convert.ToInt32(counterList[0].Counter) + " )";
                        }
                    }

                    if (klinik.Department.HasValue)
                    {
                        klinikModel.Department = new DepartmentModel();
                        klinikModel.Department.Name = "";
                        klinikModel.Department.ObjectID = klinik.Department.Value;
                    }
                    PoliclinicList.Add(klinikModel);

                }
                return PoliclinicList;

            }
        }

        [HttpPost]
        public List<FilterDoctorModel> FillDoctorList(InputModelForQueries input)
        {
            List<ResUser.SpecialistDoctorListNQL_Class> DoctorListFromQuery = ResUser.SpecialistDoctorListNQL(input.filter).ToList();
            List<FilterDoctorModel> DoctorList = new List<FilterDoctorModel>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                foreach (ResUser.SpecialistDoctorListNQL_Class doctor in DoctorListFromQuery)
                {
                    FilterDoctorModel doctorModel = new FilterDoctorModel();
                    ResUser _resuser = objectContext.GetObject<ResUser>(doctor.ObjectID.Value) as ResUser;

                    doctorModel.Name = _resuser.GetResUserByPACount();
                    doctorModel.ObjectID = doctor.ObjectID;

                    DoctorList.Add(doctorModel);
                }
                return DoctorList;
            }

            //using (TTObjectContext objectContext = new TTObjectContext(true))
            //{
            //    Array DoctorListFromQuery = ResUser.SpecialistDoctorListNewNQL(objectContext,input.filter).ToArray();
            //    List<FilterDoctorModel> DoctorList = new List<FilterDoctorModel>();
            //    foreach (ResUser doctor in DoctorListFromQuery)
            //    {
            //        FilterDoctorModel doctorModel = new FilterDoctorModel();

            //        doctorModel.Name = doctor.Name + doctor.GetResUserByPACount();
            //        doctorModel.ObjectID = doctor.ObjectID;

            //        DoctorList.Add(doctorModel);
            //    }
            //    return DoctorList;
            //}
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool PersonelIzinKontrol(CommonServiceController.PersonnelTakeOff_Input personnelTakeOff_Input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return Common.PersonelIzinKontrol(personnelTakeOff_Input.ResuserID, personnelTakeOff_Input.ControlDate, objectContext);
            }
        }

        [HttpGet]
        public string ExpectedExaminationTime(Guid paID)
        {
            string expectedExaminationTimeStr = string.Empty;
            using (var objectContext = new TTObjectContext(true))
            {
                PatientAdmission pa = objectContext.GetObject<PatientAdmission>(paID);
                if (pa.ProcedureDoctor != null && pa.Policlinic != null)
                {
                    BindingList<ExaminationQueueDefinition> queueDefList = ExaminationQueueDefinition.GetQueueByResource(objectContext, pa.Policlinic.ObjectID.ToString());//Polikliniğin kuyruğu bulunur
                    ExaminationQueueDefinition queueDef = queueDefList.FirstOrDefault();
                    DateTime expectedExaminationTime = DateTime.Now;//Tahmini muayene olacağı saat
                    DateTime resourceStartTime = DateTime.Now.Date;// kaynak başlama saati
                    DateTime lunchBreakStartTime = Convert.ToDateTime(TTObjectClasses.SystemParameter.GetParameterValue("OGLEARASIBASLAMASAATI", "12:00"));//öğle arası başlama
                    DateTime lunchBreakEndTime = Convert.ToDateTime(TTObjectClasses.SystemParameter.GetParameterValue("OGLEARASIBITISSAATI", "13:00"));//öğle arası bitiş

                    if (pa.Policlinic.ResourceStartTime.HasValue)
                        resourceStartTime = resourceStartTime + pa.Policlinic.ResourceStartTime.Value.TimeOfDay;
                    else
                        resourceStartTime = Convert.ToDateTime(TTObjectClasses.SystemParameter.GetParameterValue("VARSAYILANMUAYENEBASLAMASAATI", "08:30"));

                    int examinationMinute = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("ORTALAMAMUAYENESURESI", "10"));
                    Guid queueDefID = Guid.Empty;
                    if (queueDef != null)
                    {
                        queueDefID = queueDef.ObjectID;
                        if (queueDef.DivertTime.HasValue)
                            examinationMinute = queueDef.DivertTime.Value;
                    }

                    List<Guid> doctorIDs = new List<Guid>();
                    doctorIDs.Add(pa.ProcedureDoctor.ObjectID);
                    BindingList<ExaminationQueueItem> activeQueueItems = ExaminationQueueItem.GetActiveQueueItemsByQueueByDate(objectContext, doctorIDs, queueDefID, pa.CreationDate.Value.AddDays(1).Date, pa.CreationDate.Value.Date);
                    int activeCountBefore = 0;
                    foreach (ExaminationQueueItem examinationQueueItem in activeQueueItems)
                    {
                        if (examinationQueueItem.DivertedTime <= pa.CreationDate)//Sırada bu kabulden önce olan muayene olmamış aktif hasta sayısı bulunur.
                            activeCountBefore++;
                    }
                    if (activeCountBefore > 0)
                    {

                        int totalExaminationDurationBefore = activeCountBefore * examinationMinute;
                        if (pa.CreationDate.Value <= resourceStartTime && resourceStartTime > DateTime.Now) // Kaynak başlama saatinden önce kabul alındıysa ve kaynak başlama zamanı henüz gelmediyse, Kaynak başlama saatine kuyruktaki önceki muayenelerin süresi eklenir.
                            expectedExaminationTime = resourceStartTime.AddMinutes(totalExaminationDurationBefore);
                        else if (pa.CreationDate.Value <= resourceStartTime && resourceStartTime <= DateTime.Now) // Kaynak başlama saatinden önce kabul alındıysa ve kaynak başlama zamanı geçmişse, şu anki zamana kuyruktaki önceki muayenelerin süresi eklenir.
                            expectedExaminationTime = DateTime.Now.AddMinutes(totalExaminationDurationBefore);
                        else if (pa.CreationDate.Value > resourceStartTime) // Kaynak başlama saatinden sonra kabul alındıysa, şu anki zamana kuyruktaki önceki muayenelerin süresi eklenir.
                            expectedExaminationTime = DateTime.Now.AddMinutes(totalExaminationDurationBefore);
                    }
                    else //Hasta ilk sıradaysa, kaynak başlama zamanında muayeneye alınır.
                    {
                        if (resourceStartTime > DateTime.Now) //kaynak başlama zamanı henüz gelmediyse, Kaynak başlama saati alınır.
                            expectedExaminationTime = resourceStartTime;
                        else if (resourceStartTime <= DateTime.Now) //kaynak başlama zamanı geçmişse, şu anki zaman alınır.
                            expectedExaminationTime = DateTime.Now;
                    }

                    if (lunchBreakStartTime <= expectedExaminationTime && expectedExaminationTime <= lunchBreakEndTime) // Tahmini muayene saati öğle arasına denk gelirse, tahmini muayene saati +1 ile +2 saat arası barkodda gösterilir.
                        expectedExaminationTimeStr = expectedExaminationTime.AddHours(1).ToShortTimeString() + "-" + expectedExaminationTime.AddHours(2).ToShortTimeString();
                    else
                        expectedExaminationTimeStr = expectedExaminationTime.ToShortTimeString() + "-" + expectedExaminationTime.AddHours(1).ToShortTimeString();
                }
            }
            return expectedExaminationTimeStr;
        }


        [HttpGet]
        public HastaTemasDurumuResultModel GetHastaTemasDurumu(Guid doctorObjectID, Guid patientObjectID)
        {
            var objectContext = new TTObjectContext(false);
            HastaTemasDurumuResultModel result = new HastaTemasDurumuResultModel();
            long patientTC = 0, doctorTC = 0;
            Guid? selectedPatientID = patientObjectID;
            if (selectedPatientID.HasValue)
            {
                Patient patient = objectContext.GetObject<Patient>(selectedPatientID.Value, false);
                if (patient != null && patient.UniqueRefNo != null)
                    patientTC = Convert.ToInt64(patient.UniqueRefNo);
            }

            Guid? selectedDoctorID = doctorObjectID;
            if (selectedDoctorID.HasValue)
            {
                ResUser doctor = objectContext.GetObject<ResUser>(selectedDoctorID.Value, false);
                if (doctor != null && doctor.Person != null && doctor.Person.UniqueRefNo != null)
                    doctorTC = Convert.ToInt64(doctor.Person.UniqueRefNo);
            }

            if (patientTC == 0)
                throw new Exception(TTUtils.CultureService.GetText("M25801", "Hasta TC Kimlik No Bulunamadı."));
            if (doctorTC == 0)
                throw new Exception(TTUtils.CultureService.GetText("M25525", "Doktor TC Kimlik No Bulunamadı."));

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

            client.DefaultRequestHeaders.Add("KullaniciAdi", username);
            client.DefaultRequestHeaders.Add("Sifre", password);
            client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);

            HttpResponseMessage message = client.GetAsync("http://xxxxxx.com/api/OzellikliIzlem/GetHastaTemasDurumu?TcKimlikNo=" + patientTC + "&HekimKimlikNo=" + doctorTC).GetAwaiter().GetResult();

            if (message.IsSuccessStatusCode)
            {
                string responseResult = message.Content.ReadAsStringAsync().Result;
                HastaTemasDurumuResponse response = JsonConvert.DeserializeObject<HastaTemasDurumuResponse>(responseResult);
                if (response.durum == 1)//hata dönmediyse
                {
                    result.isResponseSuccess = true;
                    if (response.sonuc == null)
                        result.responseMessage = string.Empty;
                    else
                    {
                        result.responseMessage = response.sonuc.durum + " Temas Riski Başlama Zamanı : " + response.sonuc.temasRiskiBaslamaZamani.ToString() + " Temas Riski Bitiş Zamanı : " + response.sonuc.temasRiskiBitisZamani.ToString();
                    }
                }
                else
                {
                    result.isResponseSuccess = false;
                    result.responseMessage = "Hasta temas riski sorgulanırken hata oluştu.";
                }
            }
            return result;
        }

        #region YARDIMCI EKRANLAR
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Anne_Bebek_Eslestirme)]
        public void MatchMother(Guid patientID, Guid motherID, string birthOrderCode)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                BindingList<Patient> patient = Patient.GetPatientByID(objectContext, patientID.ToString());
                if (patient.Count == 0)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26220", "İşlemi gerçekleştirebilmek hasta bilgisini girmelisiniz."));
                Patient mother = objectContext.GetObject(motherID, patient[0].ObjectDef, false) as Patient;
                if (mother == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26218", "İşlemi gerçekleştirebilmek anne bilgisini girmelisiniz."));
                if (birthOrderCode == "" || birthOrderCode == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26219", "İşlemi gerçekleştirebilmek doğum sırası bilgisini girmelisiniz."));
                BindingList<SKRSDogumSirasi> birthOrderlist = SKRSDogumSirasi.GetSKRSDogumSirasiByKodu(objectContext, birthOrderCode.ToString());
                if (birthOrderlist.Count > 0)
                {
                    patient[0].BirthOrder = birthOrderlist[0];
                }
                else
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26219", "İşlemi gerçekleştirebilmek doğum sırası bilgisini girmelisiniz."));
                patient[0].Mother = Patient.MatchMother(patient[0], mother);
                objectContext.Save();
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Silme)]
        public void DeletePatientAdmission(PatientAdmission pa)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                pa = objectContext.GetObject<PatientAdmission>(pa.ObjectID, false) as PatientAdmission;
                if (pa != null)
                {
                    PatientAdmission.DeletePatientAdmission(pa);
                    objectContext.Save();
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme)]
        public bool CheckUnfinishedLaboratoryProcedures(Guid id)
        {
            bool result = false;
            using (var objectContext = new TTObjectContext(false))
            {
                PatientAdmission pa = objectContext.GetObject(id, typeof(PatientAdmission)) as PatientAdmission;
                if (pa != null)
                {
                    foreach (EpisodeAction ea in pa.FiredEpisodeActions)
                    {
                        if (ea is PatientExamination)
                        {
                            //Bu PatientExaminationdaki sonuçlanmamış lab testleri kontrol edilir
                            BindingList<LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode_Class> labProcedures = LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode(ea.SubEpisode.ObjectID.ToString());
                            foreach (LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode_Class procedure in labProcedures)
                            {
                                if (procedure.CurrentStateDefID != LaboratoryProcedure.States.Completed)
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme)]
        public string PrintResultBarcode(Guid id)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                PatientAdmission pa = objectContext.GetObject(id, typeof(PatientAdmission)) as PatientAdmission;
                if (pa != null)
                {
                    if (pa.AdmissionStatus == AdmissionStatusEnum.Acil)
                        throw new TTUtils.TTException("Acil birimine 'Sonuç sıra numarası' alamazsınız.");

                    if (pa.PAStatus == PAStatusEnum.IptalEdildi || pa.PAStatus == PAStatusEnum.KabulSilindi || pa.PAStatus == PAStatusEnum.MuayeneyeGelmedi)
                        throw new TTUtils.TTException(pa.PAStatus + " statüsünde olduğu için 'Sonuç sıra numarası' alamazsınız.");


                    if (pa.Policlinic != null && pa.ResultQueueNumber.Value == null)
                        pa.ResultQueueNumber.GetNextValue(pa.Policlinic.ObjectID.ToString() + DateTime.Today.ToShortDateString());

                    objectContext.Update();

                    foreach (EpisodeAction ea in pa.FiredEpisodeActions)
                    {
                        if (ea is PatientExamination)
                        {
                            ea.WorkListDate = Common.RecTime();

                            ((EpisodeAction)ea).UpdateExaminationQueueItem(pa);
                        }
                    }

                    objectContext.Save();
                }
                return pa.ResultQueueNumber.ToString();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public bool HasSameReceptionForSameReason(Guid Reason, Guid PatientID)
        {
            int dayLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("HCCONTROLDAYLIMIT", "40"));

            //int _count = Convert.ToInt32(PatientAdmission.HasSameReceptionForSameReason(Reason, PatientID, dayLimit).ToArray()[0].Count);
            int _count = Convert.ToInt32(HealthCommittee.HasSameHCExamForSameReason(PatientID, Reason, dayLimit).ToArray()[0].Recordcount);
            bool ControlPreviousHcExam = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("CONTROLPREVIOUSHCEXAM", "TRUE"));

            if (_count > 0 && ControlPreviousHcExam)
                return true;

            return false;
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme, TTRoleNames.Hasta_Kabul_Silme, TTRoleNames.Hasta_Kabul_Kaydetme)]
        public string ControlHCAutoProcedures(Guid Reason)
        {
            string returnMessage = string.Empty;

            using (var objectContext = new TTObjectContext(true))
            {
                ReasonForExaminationDefinition reason = objectContext.GetObject(Reason, "REASONFOREXAMINATIONDEFINITION") as ReasonForExaminationDefinition;
                foreach (var item in reason.HospitalsUnits)
                {
                    if (item.EpisodeActionTemplate != null)
                    {
                        foreach (var item2 in item.EpisodeActionTemplate.ProcedureDefinitions)
                        {
                            returnMessage += item2.ProcedureDefinition.Name + ",\n\r";

                        }
                    }
                }

                return returnMessage;

            }

        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public SearchWithPatientIDResult SearchWithPatientID(string SearchText)
        {
            var result = new SearchWithPatientIDResult();
            if (SearchText != null && SearchText != "undefined")
            {
                using (var context = new TTObjectContext(false))
                {

                    PatientInfoListsModel patientInfoLists = new PatientInfoListsModel();
                    if (!String.IsNullOrEmpty(SearchText))
                    {
                        IList patientSearchList = Patient.SearchByPatientID(SearchText)?.FoundList;
                        if (patientSearchList != null && patientSearchList.Count > 0)
                        {
                            result.Patient = new List<Patient>();
                            result.Patient.Add((Patient)patientSearchList[0]);
                        }

                    }
                }
            }

            return result;

        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
        public string SearchWithProtocolNo(string SearchText)
        {
            var result = "";
            if (SearchText != null && SearchText != "undefined")
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    if (!String.IsNullOrEmpty(SearchText))
                    {
                        BindingList<SubEpisode> seList = SubEpisode.GetByProtocolNo(objectContext, SearchText);
                        SubEpisode se = seList.Where(x => x.CurrentStateDefID != SubEpisode.States.Cancelled).FirstOrDefault();
                        if (se != null)
                        {
                            result = se.PatientAdmission.ObjectID.ToString();
                        }
                    }
                }
            }

            return result;

        }

        #region EPİKRİZ RAPORU
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Kayit_Kabul_Epikriz_Raporu)]
        public List<EpicrisisReport_Class> GetOldInfoForClinic(string patientID)
        {
            List<EpicrisisReport_Class> _listInfo = new List<EpicrisisReport_Class>();

            BindingList<InPatientPhysicianApplication.GetOldInfoForClinic_Class> inpatientPhysicianAppWithResources = InPatientPhysicianApplication.GetOldInfoForClinic(new Guid(patientID));

            foreach (InPatientPhysicianApplication.GetOldInfoForClinic_Class physicianApplication in inpatientPhysicianAppWithResources.OrderByDescending(t => t.Requestdate))
            {
                EpicrisisReport_Class patientInpatient = new EpicrisisReport_Class();
                patientInpatient.ObjectID = physicianApplication.ObjectID.Value;
                patientInpatient.MasterResourceID = physicianApplication.Masterresourceid.Value.ToString();
                patientInpatient.MasterResource = physicianApplication.Masterresource + " - " + physicianApplication.ProtocolNo + "(" + physicianApplication.Requestdate.Value.ToShortDateString();
                if (physicianApplication.Dischargedate != null && physicianApplication.Dischargedate.Value != null)
                {
                    patientInpatient.MasterResource += " - " + physicianApplication.Dischargedate.Value.ToShortDateString() + ")";
                }
                else
                {
                    patientInpatient.MasterResource += " - Halen)";

                }
                _listInfo.Add(patientInpatient);
            }

            return _listInfo;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Kayit_Kabul_Epikriz_Raporu)]
        public List<ResUser> GetDoctorListForEpicrisis(string masterResource)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ResUser.DoctorListObjectNQL(objectContext, " AND ISACTIVE=1 AND  USERRESOURCES(RESOURCE='" + masterResource + "').EXISTS").ToList<ResUser>();
            }
        }
        #endregion


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ResUser[] GetProcedureDoctorToBeReferred(string PoliclinicID = null)
        {
            List<ResUser> resUsers = null;

            using (var objectContext = new TTObjectContext(false))
            {
                string filter = " AND  ISACTIVE = 1";
                if (PoliclinicID != null && PoliclinicID != "")
                {
                    filter += " AND  USERRESOURCES(RESOURCE='" + PoliclinicID + "').EXISTS";
                }
                resUsers = ResUser.GetSpecialistDoctorWithAllInf(objectContext, filter).ToList();

                foreach (var resUser in resUsers)
                {
                    resUser.Name = resUser.GetResUserByPACount();
                }

                return resUsers.ToArray();
            }
        }

        public ResPoliclinic[] GetAllActivePoliclinic()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ResPoliclinic.GetAllActivePoliclinic(objectContext).OrderBy(x => x.Name).ToArray();
            }
        }

        #region MHRS OTOMATİK KABUL
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ResultSet SavePAByMHRSInfo([FromBody] TTObjectClasses.PatientAdmission.MHRS_PA_InputDTO _InputDTO)
        {
            using (var context = new TTObjectContext(false))
            {
                Patient p = Patient.GetPatientsByUniqueRefNo(context, _InputDTO.UniquerefNo).FirstOrDefault();
                if (p == null)
                {
                    p = new Patient(context);
                    p.UniqueRefNo = _InputDTO.UniquerefNo;
                }

                PatientAdmissionFormViewModel viewModel = PatientAdmissionFormLoadInternal(p, context);

                viewModel._PatientAdmission = PatientAdmission.LoadAppointmentInfo(viewModel._PatientAdmission, context, _InputDTO.AppointmentID);

                viewModel.tempPoliclinic = viewModel._PatientAdmission.Policlinic;
                viewModel.tempProcedureDoctor = viewModel._PatientAdmission.ProcedureDoctor;

                #region SET admission Property from client
                //viewModel._PatientAdmission.Department = context.GetObject<ResDepartment>(_InputDTO.DepartmentID);
                //viewModel._PatientAdmission.Policlinic = context.GetObject<ResPoliclinic>(_InputDTO.PoliclinicID);
                //viewModel._PatientAdmission.ProcedureDoctor = context.GetObject<ResUser>(_InputDTO.DoctorID);
                //viewModel._PatientAdmission.
                #endregion

                return PatientAdmissionFormInternal(viewModel, context);
            }

        }
        #endregion

        #region ALINAN KABUL SAYFALAMA
        public LoadResult getPaList([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(true))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODEPROTOCOL"].QueryDefs[loadOptions.Params.NqlName.ToString()];
                Dictionary<string, object> paramList = new Dictionary<string, object>();

                paramList.Add("STARTDATE", loadOptions.Params.StartDate);
                paramList.Add("ENDDATE", loadOptions.Params.EndDate);

                if (loadOptions.Params.NqlName.ToString() != "GetAllPatientInfoByDateWithoutUser")
                    paramList.Add("USERID", Common.CurrentResource.ObjectID);

                //string searchType = loadOptions.Params.searchType;
                //if (!string.IsNullOrEmpty(searchType))
                //{
                //    searchType = " MedulaProcedureType = " + loadOptions.Params.searchType;
                //}

                
                string searchType = "";

                //if (loadOptions.Params.Policlinic.ToString() != "")
                //    searchType = " Policlinic ="+ loadOptions.Params.Policlinic.ToString();

                //loadOptions.Sort = new SortingInfo[1];
                //loadOptions.Sort[0] = new SortingInfo();
                //loadOptions.Sort[0].Desc = false;
                //loadOptions.Sort[0].Selector = " NAME";

                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, searchType);
                //result.data= result.GetData<dynamic>().FindAll(x => x.Policlinic == loadOptions.Params.Policlinic.ToString());
            }
            return result;
        }
        #endregion


        [HttpGet]
        public List<FilterDoctorModel> GetDoctorListForPatientContactStatus()
        {
            List<ResUser.SpecialistDoctorListNQL_Class> DoctorListFromQuery = ResUser.SpecialistDoctorListNQL(" AND ISACTIVE = 1 ").ToList();
            List<FilterDoctorModel> DoctorList = new List<FilterDoctorModel>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                foreach (ResUser.SpecialistDoctorListNQL_Class doctor in DoctorListFromQuery)
                {
                    FilterDoctorModel doctorModel = new FilterDoctorModel();
                    ResUser _resuser = objectContext.GetObject<ResUser>(doctor.ObjectID.Value) as ResUser;

                    doctorModel.Name = doctor.Name;
                    doctorModel.ObjectID = doctor.ObjectID;

                    DoctorList.Add(doctorModel);
                }
                return DoctorList;
            }

            
        }

    }


    #endregion

}

namespace Core.Models
{
    public partial class PatientAdmissionFormViewModel
    {
        public TTObjectClasses.SubEpisode[] SubEpisode
        {
            get;
            set;
        }

        public TTObjectClasses.SubEpisodeProtocol SubEpisodeProtocol
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSILKodlari[] Citys
        {
            get;
            set;
        }

        public TTObjectClasses.SigortaliTuru[] SigortaliTurus
        {
            get;
            set;
        }

        public TTObjectClasses.IstisnaiHal[] IstisnaiHals
        {
            get;
            set;
        }

        public TTObjectClasses.SEPMaster[] SEPMasters
        {
            get;
            set;
        }
        public BindingList<SubEpisodeProtocol.GetPaBySearchPatient_Class> HistoryPatientAdmission
        {
            get;
            set;
        }
        public BindingList<PatientAdmissionResourcesToBeReferred> ResourcesToBeReferredList
        {
            get;
            set;
        }

        public BindingList<Appointment> AppointmentList
        {
            get;
            set;
        }
        public string returnMessage
        {
            get;
            set;
        }
        public string returnMedulaErrorMessage
        {
            get;
            set;
        }
        public MedulaTransferredPayerWarningDTO medulaTransferredPayerWarningDTO { get; set; } = new MedulaTransferredPayerWarningDTO();
        public PayerDefinition tempDispatchPayer { get; set; }
        public PayerDefinition tempPayer { get; set; }
        public ResPoliclinic tempPoliclinic { get; set; }
        public ResPoliclinic tempDispatchPoliclinic { get; set; }
        public ResUser tempProcedureDoctor { get; set; }
        public ResUser tempDispatchProcedureDoctor { get; set; }
        public DepartmentModel tempBranch { get; set; }

        public string AllProceduresLink { get; set; }
        public string AllLabProceduresLink { get; set; }
        public bool showPayerAlert { get; set; }
        public string tempName { get; set; }
        public string tempSurname { get; set; }
        public string tempPrivacyName { get; set; }
        public string tempPrivacySurname { get; set; }
        public long? tempUniqueRefNo { get; set; }
        public string tempHomeAddress { get; set; }
        public string tempMobilePhone { get; set; }
        public BindingList<vmAppointmentListInfo> AppointmentListInfo
        {
            get;
            set;
        }
        public class vmAppointmentListInfo
        {
            public Guid ObjectID;
            public string Masterresourcename;
            public string DoctorName;
            public DateTime? AppDate;
            public string AppTime { get; set; }
            public string Notes;
        }

        public ProvizyonTipi EmergencyProvisionType;
        public ProvizyonTipi NormalProvisionType;
        public ProvizyonTipi ProvizyonType3713;
        public HCRequestReasonDetail HCRequestReasonDetail;
        public Patient.MernisPatientModel MernisPatientModel;
        public string SEProtocolNo;
        public string SEPCount;
        public bool HasBuilding;
        public bool GetTotalSepCount;
        public bool RehabilitationApplication;
        public bool DispatchTabActive;
        public bool HealthCommissionTabActive;
        public bool MainTabActive;
        public bool HasTriageArea;
        public bool CheckMernisRole;
        public bool GizliHastaKabulRole;
        public bool ModifyPatientInfoRole;
        public bool IsSuperUser;
        public bool GetProvisionFromMedula = true;
        public PayerDefinition PaidPayerDefinition;
        public PayerDefinition HealthTourismPayerDefinition;
        public string PhotoString;
        public Guid StarterEpisodeAction;
        public int PaCountByUser;
        public int activeTab;// 1:mainScreen 2:dispatchingAdmission 3:boardOfHealth 
        public bool hasDoctorKotaRole { get; set; }
        public bool openKPSLoginInfo { get; set; }
        public bool hasGiveAppointmentRole { get; set; }
        public bool canGetEpicrisisReport { get; set; }
        public DisabledReportProperties disabledReportProperties = new DisabledReportProperties();

        #region
        public int HCControlDayLimit { get; set; }
        public bool ControlPreviousHcExam { get; set; }
        #endregion

        #region İlişkili olduğu branş,poliklinik 
        public bool getRelatedResourceParam { get; set; }
        public string relatedBransList { get; set; }
        public string relatedPoliclinicList { get; set; }
        public string relatedPoliclinicDoctorList { get; set; }
        #endregion

        public bool getLastSelectedDoctorandPoliclinic { get; set; }

        public List<ResPoliclinic> PoliclinicListForFilter
        {
            get;
            set;
        }

        public ResPoliclinic[] ResourcesToBeReferredPoliclinic
        {
            get;
            set;
        }
        public ResUser[] ProcedureDoctorToBeReferred { get; set; }

        public string HospitalName { get; set; }

        public SubEpisode subEpisode { get; set; }
        public EpisodeAction episodeAction { get; set; }

        public bool VerifiedKpsWithoutApprove { get; set; }//Mernis doğrula ya KPS karşılaştır açsın ya da  direk ezsin

        public bool AddProcedureToHC { get; set; }// Sağlık kuruluna otomatik işlemleri atsın mı atmasın mı

        public bool PrintMedulaCodeReport { get; set; }// Meduladan dönen hatanınraporunu otomatik bassın

        public bool IsPandemicPatient { get; set; }//covid şüphesi olan hasta
        public bool NewPatientBarcode { get; set; }//Gaziler için yeni hasta kabul barkodu

        public bool AcilDoktorSecimiZorla { get; set; }//Pursaklar Acil birimine doktor seçimine zorla
        
        public bool KurumSevkTalepNoZorla { get; set; }//Pursaklar Acil birimine doktor seçimine zorla
        public string KurumSevkTalepNo { get; set; }//clietn model convert olmadığı için veri taşımakta kullanılıyor

    }

    public class HastaTemasDurumuResultModel
    {
        public bool isResponseSuccess { get; set; }
        public string responseMessage { get; set; }
    }
    public class HastaTemasDurumuResponse
    {
        public int durum { get; set; }
        public HastaTemasDurumu sonuc { get; set; }
        public string mesaj { get; set; }
    }

    public class HastaTemasDurumu
    {
        public string durum { get; set; }
        public DateTime? temasRiskiBaslamaZamani { get; set; }
        public DateTime? temasRiskiBitisZamani { get; set; }
    }

    public class DisabledReportProperties
    {
        public string ApplicationExplanation { get; set; }
        public EngelliRaporuMuracaatNedeniEnum? ApplicationReason { get; set; }
        public EngelliRaporuMuracaatTipiEnum? ApplicationType { get; set; }
        public EngelliRaporuKurumsalMuracaatTuruEnum? CorporateApplicationType { get; set; }
        public EngelliRaporuKisiselMuracaatTuruEnum? PersonalApplicationType { get; set; }
        public EngelliRaporuTerorKazaMuracaatNedeniEnum? TerrorAccidentInjuryAppReason { get; set; }
        public EngelliRaporuTerorKazaMuracaatTipiEnum? TerrorAccidentInjuryAppType { get; set; }
        public Guid? EDisabledReportObjectId { get; set; }
    }

    public class HCRequestReasonDetail
    {
        public ReasonForExaminationDefinition ReasonForExaminationDefinition
        {
            get;
            set;
        }

        public List<HCHospitalUnit> HospitalsUnits
        {
            get;
            set;
        }
    }

    public class HCHospitalUnit
    {
        public HospitalsUnitsDefinitionGrid HospitalsUnit
        {
            get;
            set;
        }

        public ResUser ProcedureDoctor
        {
            get;
            set;
        }

        public ResPoliclinic Policlinic
        {
            get;
            set;
        }

        public SpecialityDefinition Speciality
        {
            get;
            set;
        }

        public string AdmissionQueueNumber
        {
            get;
            set;
        }
    }

    public class SearchWithPatientIDResult
    {
        public List<TTObjectClasses.Patient> Patient
        {
            get;
            set;
        }
    }

    public class DepartmentModel
    {
        public string Name { get; set; }
        public string NameUpper { get; set; }
        public string NameLower { get; set; }
        public Guid? ObjectID { get; set; }
        public string NameShadow { get; set; }
        public bool? IsEmergencyDepartment { get; set; }
    }

    public class PoliclinicModel
    {
        public string Name { get; set; }
        public Guid? ObjectID { get; set; }
        public DepartmentModel Department { get; set; }
    }

    public class FilterDoctorModel
    {
        public string Name { get; set; }
        public Guid? ObjectID { get; set; }
    }

    public class InputModelForQueries
    {
        public string filter { get; set; }
    }
    //Client tarafta olusturulan Brans, Poliklinik, Doktor filtreleri.

    public class branchValue
    {
        public DepartmentModel branchvalue { get; set; }
    }

    public class EpicrisisReport_Class
    {
        public Guid ObjectID { get; set; }  //InpatientPhysicianApplication objectdId 
        public string MasterResource { get; set; }  //Yattığı Klinik
        public string MasterResourceID { get; set; }  //Yattığı Klinik
    }

    public class RelatedResourceList
    {
        public string relatedBransList { get; set; }
        public string relatedPoliclinicList { get; set; }
    }

    public class MergeEmergencyClass
    {
        public Patient patient { get; set; }
        public string emergencyDoctor { get; set; }
        public string emergencyPoliclinic { get; set; }
        public SKRSTRIAJKODU emergencyTriage { get; set; }
    }

    public class YurtDisiYardimHakki
    {
        public int YardimHakID { get; set; }
        public string Aciklama { get; set; }
        public string Formul { get; set; }
    }

    #region KIOSK
    public class PatientAdmissionSaveDTO
    {
        public long UniqueRefNo { get; set; }
        public string PoliclinicID { get; set; }
        public string DepartmentID { get; set; }
        public string DoctorID { get; set; }
        public string AppointmentID { get; set; }
        public string MobilePhone { get; set; }
    }

    public class TodayPAListDTO
    {
        public string ObjectID { get; set; }
        public string PolName { get; set; }
        public string DocName { get; set; }
        public string ProtocolNo { get; set; }
        public string ResultQueueNo { get; set; }
    }

    public class ResultDTO
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
        public string MedulaErrorMessage
        {
            get;
            set;
        }
    }
    #endregion


    public class SevkTalepNoSonucDetay
    {
        public string kurumSevkTalepNo { get; set; }
        public string sevkTarihi { get; set; }
        public string saglikTesisKodu { get; set; }
        public string hastaBasvuruNo { get; set; }
        public string aciklama { get; set; }
    }

    public class SevkTalepNoSonuc
    {
        public string sonucKodu { get; set; }
        public string sonucMesaji { get; set; }
        public List<SevkTalepNoSonucDetay> SevkTalepNoSonucDetay { get; set; }
    }


}
