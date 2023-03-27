//$EB61372C
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using Infrastructure.Helpers;
using Infrastructure.Models;
using TTStorageManager.Security;

namespace Core.Controllers
{
    public partial class PatientServiceController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles( TTRoleNames.Kimlik_Bilgileri_Gorme, TTRoleNames.Kimlik_Bilgileri_Duzeltme)]
        public PatientCompareFormViewModel PatientCompareFormPreLoad(Guid? id)
        {
            var FormDefID = Guid.Parse("6b584df9-380e-4dc9-b6f4-30e9ad67a534");
            var ObjectDefID = Guid.Parse("54d381eb-0ea3-4021-a400-4c1dda89ab37");
            var viewModel = new PatientCompareFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                if (id.HasValue && id.Value != Guid.Empty)
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._Patient = objectContext.GetObject<Patient>(id.Value, false) as Patient;
                    viewModel.HomeAddress = viewModel._Patient.PatientAddress.HomeAddress;
                    viewModel.SKRSUlkeKodlaris = objectContext.LocalQuery<SKRSUlkeKodlari>().ToArray();
                    viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
                    viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
                    viewModel.SKRSMaritalStatuss = objectContext.LocalQuery<SKRSMedeniHali>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
                else
                {
                    viewModel._Patient = new Patient(objectContext);

                }

                if (viewModel._Patient != null)
                    SetKPS(viewModel, viewModel._Patient, objectContext);

                viewModel.KimlikBilgileriDuzeltme = TTUser.CurrentUser.HasRole(Common.KimlikBilgileriDuzeltmeRoleID);

                LocalQueryToView(viewModel, objectContext);

                objectContext.FullPartialllyLoadedObjects();

                return viewModel;
            }       
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Kimlik_Bilgileri_Duzeltme)]
        public void PatientCompareForm(PatientCompareFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var patient = (Patient)objectContext.AddObject(viewModel._Patient);
                if (viewModel._Patient.IsTrusted == false)//arşiv bilgileri seçilmiş ise
                {
                    if ((viewModel._Patient.BirthDate != viewModel._KPSInfo.KPSBirthDate) || (viewModel._Patient.BirthPlace != viewModel._KPSInfo.KPSBirthPlace) || (viewModel._Patient.ExDate != viewModel._KPSInfo.KPSExDate)
                        || (viewModel._Patient.FatherName != viewModel._KPSInfo.KPSFatherName) || (viewModel._Patient.MotherName != viewModel._KPSInfo.KPSMotherName) || (viewModel._Patient.Name != viewModel._KPSInfo.KPSName)
                        || (viewModel._Patient.Nationality != viewModel._KPSInfo.KPSNationality) || (viewModel._Patient.Sex != viewModel._KPSInfo.KPSSex) || (viewModel._Patient.Surname != viewModel._KPSInfo.KPSSurname)
                        || (viewModel._Patient.UniqueRefNo != viewModel._KPSInfo.KPSUniqueRefNo) || (viewModel._Patient.SKRSMaritalStatus != viewModel._KPSInfo.SKRSMaritalStatus))
                        patient.IsTrusted = false;
                    else
                        patient.IsTrusted = true;
                }

                patient.PatientAddress.HomeAddress = viewModel.HomeAddress;
                patient.KPSUpdateDate = Common.RecTime();
                if (patient.Foreign.HasValue && patient.Foreign.Value)
                    patient.OtherBirthPlace = viewModel._KPSInfo.KPSBirthPlace;
                objectContext.Save();

                PatientAdmissionServiceController pasc = new PatientAdmissionServiceController();
                pasc.Add101PackageOldSE(patient.ObjectID);//KPS yüzendek
                pasc.Dispose();
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Kimlik_Bilgileri_Gorme, TTRoleNames.Kimlik_Bilgileri_Duzeltme)]
        public PatientCompareFormViewModel NewPatientCompareForm(Patient id)
        {
            var viewModel = new PatientCompareFormViewModel();

            Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();

            using (var objectContext = new TTObjectContext(false))
            {
                Patient p = objectContext.GetObject<Patient>(id.ObjectID, false) as Patient;
                if (p != null)
                {
                    viewModel = this.NewPatientFormViewModel(viewModel, p, objectContext);
                }

                return viewModel;
            }         
        }

        public void SetKPS(PatientCompareFormViewModel viewModel, Patient p, TTObjectContext objectContext)
        {
            #region AddorGetObject
            BindingList<Patient> _pList = Patient.GetPatientByID(objectContext, p.ObjectID.ToString());
            if (_pList.Count == 0) //Isnew mi
            {
                if (objectContext.LocalQuery<Patient>("OBJECTID = '" + p.ObjectID + "'").Count == 0)
                    p = (Patient)objectContext.AddObject(p);
            }
            else
                p = _pList[0];

            #endregion

            #region KPS

            try
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("KIMLIKNOILEADRESSORGUPARAM", "FALSE") == "TRUE")//eski servis
                {
                    if (p.UniqueRefNo != null && p.UniqueRefNo.Value != 0 && p.Alive != false)
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
                                    p.IsTrusted = true;
                                    viewModel._KPSInfo = Patient.GetPatientandAdresInfoFromKPS_OLD(response, p, false, objectContext);

                                    if (p.PatientAddress == null)
                                        p.PatientAddress = new PatientIdentityAndAddress(objectContext);

                                    p.PatientAddress = Patient.GetKisiAdresBilgisi_OLD(p, objectContext);

                                   
                                    PatientAdmission lastPA = PatientAdmission.GetLastPatientAdmissionByPatient(objectContext,viewModel._Patient.ObjectID).FirstOrDefault();
                                    if (lastPA != null)
                                    {
                                        new SendToENabiz(objectContext, lastPA.FirstSubEpisode, lastPA.FirstSubEpisode.ObjectID, lastPA.FirstSubEpisode.ObjectDef.Name, "101", Common.RecTime());
                                    }                                    
                                }
                                else
                                {
                                    TTUtils.InfoMessageService.Instance.ShowMessage(response.Hata);
                                }
                            }
                            else
                            {
                                KPSServis.KPSServisSonucuYabanciKisiBilgisi response = KPSServis.WebMethods.YabanciTcKimlikNoIleKisiSorgulaSync(Sites.SiteLocalHost, Convert.ToInt64(p.UniqueRefNo.Value));
                                if (string.IsNullOrEmpty(response.Hata))
                                {
                                    p.IsTrusted = true;
                                    viewModel._KPSInfo = Patient.GetForeignPatientandAdresInfoFromKPS_OLD(response, p, false, objectContext);

                                    PatientAdmission lastPA = PatientAdmission.GetLastPatientAdmissionByPatient(objectContext, viewModel._Patient.ObjectID).FirstOrDefault();
                                    if (lastPA != null)
                                    {
                                        new SendToENabiz(objectContext, lastPA.FirstSubEpisode, lastPA.FirstSubEpisode.ObjectID, lastPA.FirstSubEpisode.ObjectDef.Name, "101", Common.RecTime());
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
                else
                    viewModel._KPSInfo = Patient.GetPatientandAdresInfoFromKPS(p, false, objectContext);
            }
            catch (Exception ex)
            {
                TTUtils.Logger.WriteException("Error in KPSServis : ", ex);

                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                else
                {
                    throw ex;
                }
                
            }

            #endregion
        }
        PatientCompareFormViewModel NewPatientFormViewModel(PatientCompareFormViewModel viewModel, Patient p, TTObjectContext objectContext)
        {
            var FormDefID = Guid.Parse("6b584df9-380e-4dc9-b6f4-30e9ad67a534");
            var ObjectDefID = Guid.Parse("54d381eb-0ea3-4021-a400-4c1dda89ab37");

            SetKPS(viewModel, p, objectContext);

            viewModel._Patient = p as Patient;
            viewModel.KimlikBilgileriDuzeltme = TTUser.CurrentUser.HasRole(TTObjectClasses.TTRoleNames.Kimlik_Bilgileri_Duzeltme);

            objectContext.LoadFormObjects(FormDefID, viewModel._Patient.ObjectID, ObjectDefID);

            LocalQueryToView(viewModel, objectContext);

            objectContext.FullPartialllyLoadedObjects();

            return viewModel;
        }
        void LocalQueryToView(PatientCompareFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
            viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
            viewModel.SKRSUlkeKodlaris = objectContext.LocalQuery<SKRSUlkeKodlari>().ToArray();
            viewModel.SKRSMaritalStatuss = objectContext.LocalQuery<SKRSMedeniHali>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCinsiyetList", viewModel.SKRSCinsiyets);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMedeniHaliList", viewModel.SKRSMaritalStatuss);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSUlkeKodlariList", viewModel.SKRSUlkeKodlaris);

        }
    }
}

namespace Core.Models
{
    public class PatientCompareFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Patient _Patient
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSUlkeKodlari[] SKRSUlkeKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSCinsiyet[] SKRSCinsiyets
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris
        {
            get;
            set;
        }
        public Patient.MernisPatientModel _KPSInfo
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSMedeniHali[] SKRSMaritalStatuss { get; set; }
        public bool KimlikBilgileriDuzeltme { get; set; }

        public string HomeAddress { get; set; }
    }
}