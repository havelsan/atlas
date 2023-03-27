using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTUtils.RequirementManager;
using System.ComponentModel;

namespace TTObjectClasses.Tıbbi_Süreç.Kayıt___Kabul_Modülü.Requirements
{
    public class PatientInfoRequirements : IRequirement
    {
        Patient patient = null;
        public PatientInfoRequirements(Patient patientParam)
        {
            patient = patientParam;

        }

        public RequirementResultCode ExecuteRequirement()
        {
            RequirementResultCode requirementResultCode = new RequirementResultCode();
            requirementResultCode.resultCode = 0;
            requirementResultCode.resultMessage = "Success";

            if (patient == null)
            {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26893", "Sistemde hasta tanımlı değildir.");
                return requirementResultCode;
            }

            if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("CHECKMERNISNUMBER", "TRUE")) == true)
            {
                if (!Common.CheckMernisNumber(Convert.ToInt64(patient.UniqueRefNo)))
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25693", "Geçersiz TC Kimlik Numarası.");
                    return requirementResultCode;
                }
            }
                if (patient.Name == null)
            {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25107", "Ad alanı boş bırakılamaz.");
                return requirementResultCode;
            }

            if (patient.Surname == null)
            {
                requirementResultCode.resultCode = 1;
                requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26943", "Soyad alanı boş bırakılamaz.");
                return requirementResultCode;
            }
                        
            if (patient.UnIdentified == false)
            {
                if (patient.MotherName == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25185", "Anne adı alanı boş bırakılamaz.");
                    return requirementResultCode;
                }

                if (patient.FatherName == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25221", "Baba adı alanı boş bırakılamaz.");
                    return requirementResultCode;
                }

                if (patient.BirthDate == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25515", "Doğum tarihi alanı boş bırakılamaz.");
                    return requirementResultCode;
                }

                if(patient.BirthDate>Common.RecTime())
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25516", "Doğum tarihi alanı bugünün tarihinden büyük olamaz.");
                    return requirementResultCode;
                }
                
                if (patient.Sex == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25366", "Cinsiyet alanı boş bırakılamaz.");
                    return requirementResultCode;
                }

                if (patient.Nationality == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M27147", "Uyruk alanı boş bırakılamaz.");
                    return requirementResultCode;
                }

                if (patient.BirthPlace == null && patient.BirthPlace == "" && patient.Nationality.Kodu == "TR")
                {
                    requirementResultCode.resultCode = 7;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25518", "Doğum yeri alanı boş bırakılamaz.");
                    return requirementResultCode;
                }
                       
                if (patient.OtherBirthPlace == null &&  patient.OtherBirthPlace == "" && patient.Nationality.Kodu != "TR" )
                {
                    requirementResultCode.resultCode = 7;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25518", "Doğum yeri alanı boş bırakılamaz.");
                    return requirementResultCode;
                }

                if (patient.Death == true && patient.ExDate == null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26663", "Ölüm tarihi alanı boş bırakılamaz.");
                    return requirementResultCode;
                }

                if (patient.Death == true && patient.ExDate > Common.RecTime())
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M26664", "Ölüm tarihi alanı bugünün tarihinden büyük olamaz.");
                    return requirementResultCode;
                }
                if (patient.Death == true && patient.BirthDate > patient.ExDate)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25517", "Doğum tarihi alanı ölüm tarihinden büyük olamaz.");
                    return requirementResultCode;
                }

                //Hasta sistemde kayıtlı ise hata dönmeli
                if (patient.UniqueRefNo != null)
                {
                    BindingList<Patient> patientList = Patient.GetPatientByUniqueRefNoAndObjID(patient.ObjectContext, (long)(patient.UniqueRefNo.Value),patient.ObjectID);
                    if (patientList.Count > 0)
                    {
                       /* if (patientList.Count == 2)
                        {
                            Patient p = (Patient)patientList[1];
                            if (p.UniqueRefNo.Value == this.patient.UniqueRefNo.Value && p.Name != this.patient.Name && p.Surname != this.patient.Surname && p.MotherName != this.patient.MotherName && p.FatherName != this.patient.MotherName)
                            {
                                requirementResultCode.resultCode = 1;
                                requirementResultCode.resultMessage = "Bu TC Kimlik numarasına ait hasta dosyası bulunmaktadır.Hasta dosya no : " + p.ID;
                                return requirementResultCode;
                            }
                        }
                        else */
                        if (patientList.Count == 1)
                        {
                            Patient p = (Patient)patientList[0];
                            if (p.UniqueRefNo.Value == patient.UniqueRefNo.Value)
                            {
                                requirementResultCode.resultCode = 1;
                                requirementResultCode.resultMessage = "Bu TC Kimlik numarasına ait hasta dosyası bulunmaktadır.Hasta dosya no : " + p.ID;
                                return requirementResultCode;
                            }
                        }
                        else
                        {
                            requirementResultCode.resultCode = 1;
                            requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M25341", "Bu TC Kimlik numarasına ait birden fazla hasta dosyası bulunmaktadır.Dosya eşleştirme yapınız.");
                            return requirementResultCode;
                        }
                    }
                }

                //Gizli Hasta kontrolü
                if (patient.Privacy != null)
                {
                    if (patient.Privacy == true)
                    {
                        if (patient.PrivacyName == null)
                        {
                            requirementResultCode.resultCode = 1;
                            requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M00000", "'Rumuz ad' bilgisi giriniz.");
                            return requirementResultCode;
                        }
                        if (patient.PrivacySurname == null)
                        {
                            requirementResultCode.resultCode = 1;
                            requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M00000", "'Rumuz soyad' bilgisi giriniz.");
                            return requirementResultCode;
                        }
                    }
                }

               
            }
            else if(patient.UnIdentified == true)
            {
                if (patient.UniqueRefNo != null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M00000", "Kimlik Numarası alanı dolu olan hastalarda 'Kimliği belirsiz' işaretlenemez.");
                    return requirementResultCode;
                }
                if (!string.IsNullOrEmpty(patient.PassportNo))
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M00000","Pasaport No alanı dolu olan hastalarda 'Kimliği belirsiz' işaretlenemez.");
                    return requirementResultCode;
                }
                if (patient.YUPASSNO != null)
                {
                    requirementResultCode.resultCode = 1;
                    requirementResultCode.resultMessage = TTUtils.CultureService.GetText("M00000", "YUPASS No alanı dolu olan hastalarda 'Kimliği belirsiz' işaretlenemez.");
                    return requirementResultCode;
                }
            }
            return requirementResultCode;
        }
    }
  
}