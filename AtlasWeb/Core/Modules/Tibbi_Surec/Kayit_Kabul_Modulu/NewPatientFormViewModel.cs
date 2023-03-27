//$C703DE7E
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using static TTObjectClasses.UserResource;
using Microsoft.AspNetCore.Mvc;
using TTStorageManager.Security;
using Core.Security;
using Infrastructure.Helpers;
using System.IO;
using System.Drawing;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class PatientServiceController
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kayit_Gorme, TTRoleNames.Hasta_Kayit_Kaydetme, TTRoleNames.Hasta_Kayit_Silme)]
        public NewPatientFormViewModel NewPatientFormLoadClient(Patient id)
        {
            var viewModel = new NewPatientFormViewModel();
            Patient p = id;
            Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();
            if (p != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel = this.NewPatientFormViewModel(viewModel, p, objectContext);
                }
            }

            return viewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kayit_Gorme, TTRoleNames.Hasta_Kayit_Kaydetme, TTRoleNames.Hasta_Kayit_Silme)]
        public NewPatientFormViewModel GenerateNewPatient(long UniquerefNo)
        {
            var viewModel = new NewPatientFormViewModel();
            
            Patient.MernisPatientModel mpm = new Patient.MernisPatientModel();
            
                using (var objectContext = new TTObjectContext(false))
                {
                    Patient p = new Patient(objectContext);
                    p.UniqueRefNo = UniquerefNo;
                    viewModel = this.NewPatientFormViewModel(viewModel, p, objectContext);
                    this.SavePatientForm(viewModel,objectContext);
                }
            

            return viewModel;
        }

        internal BaseViewModel SavePatientForm(NewPatientFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("e6391e17-8388-4d44-ae95-83f0784b682d");

            var patient = (Patient)objectContext.GetLoadedObject(viewModel._Patient.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(patient, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Patient, formDefID);
            var transDef = patient.TransDef;
            PostScript_NewPatientForm(viewModel, patient, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(patient);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(patient);
            AfterContextSaveScript_NewPatientForm(viewModel, patient, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }

        NewPatientFormViewModel NewPatientFormViewModel(NewPatientFormViewModel viewModel, Patient p, TTObjectContext objectContext)
        {
            var formDefID = Guid.Parse("e6391e17-8388-4d44-ae95-83f0784b682d");
            var objectDefID = Guid.Parse("54d381eb-0ea3-4021-a400-4c1dda89ab37");
            bool _newPatient = false;

            #region AddorGetObject
            BindingList<Patient> _pList = Patient.GetPatientByID(objectContext, p.ObjectID.ToString());
            if (_pList.Count == 0) //Isnew mi
            {
                if (objectContext.LocalQuery<Patient>("OBJECTID = '" + p.ObjectID + "'").Count == 0)
                    p = (Patient)objectContext.AddObject(p); //Kayıtlı olmayan hastalarda readonly uyarısı almamak için
                _newPatient = true;
            }
            else
            {
                // p = (Patient)objectContext.GetObject(p.ObjectID, "PATIENT");
                p = _pList[0];
                _newPatient = false;
            }
            #endregion

            #region KPS
            if (TTObjectClasses.SystemParameter.GetParameterValue("ISKPSACTIVE", "TRUE") == "TRUE" && p.IsTrusted != true)
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
                                            p.KPSUpdateDate = Common.RecTime();

                                            viewModel.MernisPatientModel = Patient.GetPatientandAdresInfoFromKPS_OLD(response, p, _newPatient, objectContext);

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
                    else
                    {
                        viewModel.MernisPatientModel = Patient.GetPatientandAdresInfoFromKPS(p, true, objectContext);//gelen veriyi patient içine set etmesi için truew gönderildi
                        /* KPS yüzünden gitmeyen 101 paketleri varsa onlar için tekrar ekle*/
                        PatientAdmissionServiceController pasc = new PatientAdmissionServiceController();
                        pasc.Add101PackageOldSE(p.ObjectID);//KPS yüzendek
                        pasc.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    TTUtils.Logger.WriteException("Error in KPSServis", ex);
                }
            }
            #endregion

            viewModel._Patient = p as Patient;
            viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Patient, formDefID);
            viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Patient, formDefID);
            objectContext.LoadFormObjects(formDefID, viewModel._Patient.ObjectID, objectDefID);

            FillPatientInfo(objectContext, viewModel);
            FillPatientAdmissionAddressInfo(objectContext, viewModel);
            if (viewModel._Patient.Photo != null)
            {
                if (viewModel._Patient.Photo is string)
                {
                    viewModel.PhotoString = viewModel._Patient.Photo.ToString();
                }
                else
                    viewModel.PhotoString = Convert.ToBase64String((byte[])viewModel._Patient.Photo);
            }
            LocalQueryToView(viewModel, objectContext);
            objectContext.FullPartialllyLoadedObjects();

            viewModel.GizliHastaKabulRole = TTUser.CurrentUser.HasRole(Common.GizliHastaKabulRoleID);
            viewModel.ModifyPatientInfoRole = TTUser.CurrentUser.HasRole(Common.ModifyPatientInfoRoleID);
            LoadPatientPrivacyTempInfo(viewModel);

            return viewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kayit_Gorme, TTRoleNames.Hasta_Kayit_Kaydetme, TTRoleNames.Hasta_Kayit_Silme)]
        public NewPatientFormViewModel PatientEmptyForm()
        {
            var formDefID = Guid.Parse("e6391e17-8388-4d44-ae95-83f0784b682d");
            var objectDefID = Guid.Parse("54d381eb-0ea3-4021-a400-4c1dda89ab37");
            var viewModel = new NewPatientFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Patient = new Patient(objectContext);
                viewModel._Patient.Nationality = Patient.SetDefaultNationality().FirstOrDefault();
                viewModel.SKRSUlkeKodlaris = objectContext.LocalQuery<SKRSUlkeKodlari>().ToArray();

                if (viewModel._Patient.PatientAddress == null)
                    viewModel._Patient.PatientAddress = new PatientIdentityAndAddress(objectContext);

                viewModel.GizliHastaKabulRole = TTUser.CurrentUser.HasRole(Common.GizliHastaKabulRoleID);
                viewModel.ModifyPatientInfoRole = TTUser.CurrentUser.HasRole(Common.ModifyPatientInfoRoleID);

                FillPatientInfo(objectContext, viewModel);

                LocalQueryToView(viewModel, objectContext);
            }

            return viewModel;
        }
        partial void PreScript_NewPatientForm(NewPatientFormViewModel viewModel, Patient patient, TTObjectContext objectContext)
        {
            viewModel._Patient.Nationality = Patient.SetDefaultNationality().FirstOrDefault();
            viewModel.SKRSUlkeKodlaris = objectContext.LocalQuery<SKRSUlkeKodlari>().ToArray();

            if (viewModel._Patient.PatientAddress == null)
                viewModel._Patient.PatientAddress = new PatientIdentityAndAddress(objectContext);

            viewModel.GizliHastaKabulRole = TTUser.CurrentUser.HasRole(Common.GizliHastaKabulRoleID);
            viewModel.ModifyPatientInfoRole = TTUser.CurrentUser.HasRole(Common.ModifyPatientInfoRoleID);

            if (patient.Photo != null)
            {
                if (patient.Photo is string)
                {
                    viewModel.PhotoString = patient.Photo.ToString();
                }
                else
                    viewModel.PhotoString = Convert.ToBase64String((byte[])patient.Photo);
            }

            FillPatientInfo(objectContext, viewModel);

            LoadPatientPrivacyTempInfo(viewModel);
        }

        void FillPatientInfo(TTObjectContext objectContext, NewPatientFormViewModel viewModel)
        {
          /*  if (viewModel._Patient.CityOfBirth != null)
                objectContext.GetObject<SKRSILKodlari>(viewModel._Patient.CityOfBirth.ObjectID);*/
            if (viewModel._Patient.Nationality == null)
                viewModel._Patient.Nationality = Patient.SetDefaultNationality().FirstOrDefault();
            if (viewModel._Patient.Nationality != null)
                objectContext.GetObject<SKRSUlkeKodlari>(viewModel._Patient.Nationality.ObjectID);
        }
        private TTObjectContext FillPatientAdmissionAddressInfo(TTObjectContext objectContext, NewPatientFormViewModel viewModel)
        {
            if (viewModel._Patient.PatientAddress == null)
                viewModel._Patient.PatientAddress = new PatientIdentityAndAddress(objectContext);


            if (viewModel._Patient.PatientAddress.SKRSMahalleKodlari != null)
                objectContext.GetObject<SKRSMahalleKodlari>(viewModel._Patient.PatientAddress.SKRSMahalleKodlari.ObjectID);
            if (viewModel._Patient.PatientAddress.SKRSKoyKodlari != null)
                objectContext.GetObject<SKRSKoyKodlari>(viewModel._Patient.PatientAddress.SKRSKoyKodlari.ObjectID);
            if (viewModel._Patient.PatientAddress.SKRSCsbmKodu != null)
                objectContext.GetObject<SKRSCSBMTipi>(viewModel._Patient.PatientAddress.SKRSCsbmKodu.ObjectID);
            if (viewModel._Patient.PatientAddress.SKRSBucakKodu != null)
                objectContext.GetObject<SKRSBucakKodlari>(viewModel._Patient.PatientAddress.SKRSBucakKodu.ObjectID);
            if (viewModel._Patient.PatientAddress.SKRSBucakKodu != null)
                objectContext.GetObject<SKRSIlceKodlari>(viewModel._Patient.PatientAddress.SKRSIlceKodlari.ObjectID);
            if (viewModel._Patient.PatientAddress.SKRSILKodlari != null)
                objectContext.GetObject<SKRSILKodlari>(viewModel._Patient.PatientAddress.SKRSILKodlari.ObjectID);
            if (viewModel._Patient.PatientAddress.SKRSAdresTipi != null)
                objectContext.GetObject<SKRSAdresTipi>(viewModel._Patient.PatientAddress.SKRSAdresTipi.ObjectID);


            return objectContext;
        }
        void LocalQueryToView(NewPatientFormViewModel viewModel, TTObjectContext objectContext)
        {
            ContextToViewModel(viewModel, objectContext);
        }
 
        void LoadPatientPrivacyTempInfo(NewPatientFormViewModel viewModel)
        {
            if (viewModel.GizliHastaKabulRole == false || viewModel._Patient.Privacy != true)
            {
                if (viewModel._Patient.PatientAddress != null)
                {
                    viewModel.tempHomeAddress = viewModel._Patient.PatientAddress.HomeAddress;
                    viewModel.tempMobilePhone = viewModel._Patient.PatientAddress.MobilePhone;
                }

                viewModel.tempName = viewModel._Patient.Name;
                viewModel.tempSurname = viewModel._Patient.Surname;
                viewModel.tempUniqueRefNo = viewModel._Patient.UniqueRefNo;
                //Aşağıdakileri sakın açma
                //viewModel.tempPrivacyName = viewModel._PatientAdmission.Episode.Patient.PrivacyName;
                //viewModel.tempPrivacySurname = viewModel._PatientAdmission.Episode.Patient.PrivacySurname;
            }
            else
            {
                if (viewModel._Patient.Privacy == true)
                {
                    viewModel.tempHomeAddress = viewModel._Patient.PrivacyHomeAddress;
                    viewModel.tempMobilePhone = viewModel._Patient.PrivacyMobilePhone;

                    viewModel.tempPrivacyName = viewModel._Patient.Name;
                    viewModel.tempPrivacySurname = viewModel._Patient.Surname;

                    viewModel.tempName = viewModel._Patient.PrivacyName;
                    viewModel.tempSurname = viewModel._Patient.PrivacySurname;
                    viewModel.tempUniqueRefNo = viewModel._Patient.PrivacyUniqueRefNo;
                }
            }
        }
        void SavePatientPrivacyTempInfo(NewPatientFormViewModel viewModel, Patient patient)
        {
            if (viewModel.GizliHastaKabulRole == false)
            {

                if (patient.PatientAddress != null)
                {
                    patient.PatientAddress.HomeAddress = viewModel.tempHomeAddress;
                    patient.PatientAddress.MobilePhone = viewModel.tempMobilePhone;
                }
                patient.Name = viewModel.tempName;
                patient.Surname = viewModel.tempSurname;
                patient.UniqueRefNo = viewModel.tempUniqueRefNo;

                if (patient.Privacy == true)
                {
                    if (patient.HasMemberChanged("Privacy") || patient.HasMemberChanged("NAME") || patient.HasMemberChanged("SURNAME") || patient.HasMemberChanged("UniqueRefNo") || patient.PatientAddress.HasMemberChanged("HomeAddress") || patient.PatientAddress.HasMemberChanged("MobilePhone"))
                        throw new Exception(TTUtils.CultureService.GetText("M25730", "Gizli hastada değişiklik yapma yetkiniz yoktur."));
                }
            }
            else
            {
                if (patient.Privacy == true)
                {
                    patient.PrivacyHomeAddress = viewModel.tempHomeAddress;
                    patient.PrivacyMobilePhone = viewModel.tempMobilePhone;

                    patient.Name = viewModel.tempPrivacyName;
                    patient.Surname = viewModel.tempPrivacySurname;

                    patient.PrivacyName = viewModel.tempName;
                    patient.PrivacySurname = viewModel.tempSurname;
                    patient.PrivacyUniqueRefNo = viewModel.tempUniqueRefNo;
                }
                else
                {
                    if (patient.PatientAddress != null)
                    {
                        patient.PatientAddress.HomeAddress = viewModel.tempHomeAddress;
                        patient.PatientAddress.MobilePhone = viewModel.tempMobilePhone;
                    }
                    patient.Name = viewModel.tempName;
                    patient.Surname = viewModel.tempSurname;
                    patient.UniqueRefNo = viewModel.tempUniqueRefNo;
                }
            }

            Patient.SetPrivacyInfo(patient);
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

        partial void PostScript_NewPatientForm(NewPatientFormViewModel viewModel, Patient patient, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            objectContext.ProcessRawObjects();

            if (string.IsNullOrEmpty(viewModel.PhotoString) == false && IsValidImage(viewModel.PhotoString))
            {
                byte[] photo = Convert.FromBase64String(viewModel.PhotoString);
                if (photo.Length > 5000000)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25089", "5 Mb'ı aşan boyutta görüntü yükleyemezsiniz!"));
                else if (!FileTypeCheck.fileTypeCheck(photo, "fileName"))
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25690", "Geçersiz dosya tipi!"));
                patient.Photo = photo;
            }

            SavePatientPrivacyTempInfo(viewModel, patient);
            viewModel._Patient = Patient.SavePatient(patient);
        }
        partial void AfterContextSaveScript_NewPatientForm(NewPatientFormViewModel viewModel, Patient patient, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (patient.ID.Value == null)
            {
                patient.NameIsUpdated = true;
                patient.SurnameIsUpdated = true;

                TTSequence.allowSetSequenceValue = true;
                patient.ID.SetSequenceValue(0);
                patient.ID.GetNextValue();
            }

            objectContext.Save();

        }

    }
}

namespace Core.Models
{
    public partial class NewPatientFormViewModel
    {
        public Patient.MernisPatientModel MernisPatientModel;

        public bool GizliHastaKabulRole;
        public bool ModifyPatientInfoRole;
        public string tempName { get; set; }
        public string tempSurname { get; set; }
        public string tempPrivacyName { get; set; }
        public string tempPrivacySurname { get; set; }
        public long? tempUniqueRefNo { get; set; }
        public string tempHomeAddress { get; set; }
        public string tempMobilePhone { get; set; }
        public string PhotoString { get; set; }
    }
}
