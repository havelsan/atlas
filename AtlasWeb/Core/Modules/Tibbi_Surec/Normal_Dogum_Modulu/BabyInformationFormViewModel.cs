//$19F42E35
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.IO;
using System.Drawing;

namespace Core.Controllers
{
    public partial class BabyObstetricInformationServiceController
    {
        partial void PreScript_BabyInformationForm(BabyInformationFormViewModel viewModel, BabyObstetricInformation babyObstetricInformation, TTObjectContext objectContext)
        {

            if (viewModel._BabyObstetricInformation.Apgar1 == null)
            {
                viewModel._BabyObstetricInformation.Apgar1 = new Apgar(objectContext);
            }
            if (viewModel._BabyObstetricInformation.Apgar5 == null)
            {
                viewModel._BabyObstetricInformation.Apgar5 = new Apgar(objectContext);
            }

            if (viewModel._BabyObstetricInformation.BabyStatus == null)//Bebek Default olarak 'Canlý'
            {
                viewModel._BabyObstetricInformation.BabyStatus = BirthReportBabyStatus.Alive;
            }

            viewModel.Apgars = objectContext.LocalQuery<Apgar>().ToArray();

            if (viewModel._BabyObstetricInformation.Photo != null)
            {
                if (viewModel._BabyObstetricInformation.Photo is string)
                {
                    viewModel.PhotoString = viewModel._BabyObstetricInformation.Photo.ToString();
                }
                else
                    viewModel.PhotoString = Convert.ToBase64String((byte[])viewModel._BabyObstetricInformation.Photo);
            }

            ContextToViewModel(viewModel, objectContext);
        }

        partial void PostScript_BabyInformationForm(BabyInformationFormViewModel viewModel, BabyObstetricInformation babyObstetricInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //TODO MERVE
            //using (objectContext = new TTObjectContext(false))
            //{}
                babyObstetricInformation.RegularObstetric = viewModel._RegularObstetric;
                babyObstetricInformation.MotherPatient = viewModel._RegularObstetric.Patient;

                //Canlý Doðan Bebek için Arþiv Oluþturulacak --> tc ve adres gibi bilgiler anneden kopyalayýp bebeðe ekleniyor. && babyObstetricInformation.Patient==null
                if (babyObstetricInformation.BabyStatus == BirthReportBabyStatus.Alive)
                {
                    Patient _patient;
                    if (babyObstetricInformation.Patient == null)
                    {
                        _patient = new Patient(objectContext);
                        //babyObstetricInformation.Patient = new Patient(objectContext);
                    }
                    else
                    {
                        _patient = babyObstetricInformation.Patient;
                    }


                    //yenidoðan bilgileri :
                    _patient.Name = babyObstetricInformation.Name != null ? babyObstetricInformation.Name : "BEBEK" + viewModel.babyCount;
                    _patient.Mother = babyObstetricInformation.MotherPatient;
                    _patient.BirthDate = babyObstetricInformation.BirthDateTime;
                    _patient.Sex = babyObstetricInformation.Gender;
                    _patient.Weight = babyObstetricInformation.Weigth;
                    _patient.BirthOrder = babyObstetricInformation.BirthOrder;
                    _patient.FatherName = babyObstetricInformation.FatherName;
                    _patient.HeadCircumference = babyObstetricInformation.HeadCircumference;
                    _patient.Heigth = babyObstetricInformation.Height;
                    _patient.Surname = babyObstetricInformation.Surname;

                    //Anneden kopyalanan bilgiler :
                    _patient.PatientAddress = babyObstetricInformation.MotherPatient.PatientAddress;
                    _patient.Nationality = babyObstetricInformation.MotherPatient.Nationality;

                    _patient.MotherName = babyObstetricInformation.MotherPatient.Name;


                    babyObstetricInformation.Patient = _patient;


                if (string.IsNullOrEmpty(viewModel.PhotoString) == false && IsValidImage(viewModel.PhotoString))
                {
                    byte[] photo = Convert.FromBase64String(viewModel.PhotoString);
                    if (photo.Length > 5000000)
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25089", "5 Mb'ý aþan boyutta görüntü yükleyemezsiniz!"));
                    else if (!FileTypeCheck.fileTypeCheck(photo, "fileName"))
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25690", "Geçersiz dosya tipi!"));
                    babyObstetricInformation.Photo = photo;
                }

                _patient.Photo = babyObstetricInformation.Photo;


                ////if (babyObstetricInformation.Patient == null)
                ////{
                ////    babyObstetricInformation.Patient = new Patient(objectContext);
                ////}


                ////yenidoðan bilgileri :
                //babyObstetricInformation.Patient.Name = babyObstetricInformation.Name != null ? babyObstetricInformation.Name : "BEBEK" + viewModel.babyCount;
                //babyObstetricInformation.Patient.Mother = babyObstetricInformation.MotherPatient;
                //babyObstetricInformation.Patient.BirthDate = babyObstetricInformation.BirthDateTime;
                //babyObstetricInformation.Patient.Sex = babyObstetricInformation.Gender;
                //babyObstetricInformation.Patient.Weight = babyObstetricInformation.Weigth;
                //babyObstetricInformation.Patient.BirthOrder = babyObstetricInformation.BirthOrder;
                //babyObstetricInformation.Patient.FatherName = babyObstetricInformation.FatherName;
                //babyObstetricInformation.Patient.HeadCircumference = babyObstetricInformation.HeadCircumference;
                //babyObstetricInformation.Patient.Heigth = babyObstetricInformation.Height;
                //babyObstetricInformation.Patient.Surname = babyObstetricInformation.Surname;

                ////Anneden kopyalanan bilgiler :
                //babyObstetricInformation.Patient.PatientAddress = babyObstetricInformation.MotherPatient.PatientAddress;
                //babyObstetricInformation.Patient.Nationality = babyObstetricInformation.MotherPatient.Nationality;
            }





            ////////Canlý Doðan Bebek için Arþiv Oluþturulacak --> tc ve adres gibi bilgiler için anne patient'ý kopyalanýp bebek bilgileri aktarýlýyor.
            //////Patient newCopyPatient = babyObstetricInformation.MotherPatient;
            ////////yenidoðan bilgileri :
            //////newCopyPatient.IsNewBorn = true;
            //////newCopyPatient.Mother = babyObstetricInformation.MotherPatient;
            //////newCopyPatient.BirthDate = babyObstetricInformation.BirthDateTime;
            //////newCopyPatient.Sex = babyObstetricInformation.Gender;
            //////newCopyPatient.Weight = babyObstetricInformation.Weigth;
            //////newCopyPatient.BirthOrder = babyObstetricInformation.BirthOrder;
            //////newCopyPatient.FatherName = babyObstetricInformation.FatherName;
            //////newCopyPatient.HeadCircumference = babyObstetricInformation.HeadCircumference;
            //////newCopyPatient.Heigth = babyObstetricInformation.Height;
            ////////anne bilgilerinden silinenler
            //////newCopyPatient.ActivePregnancy = null;
            //////newCopyPatient.BirthPlace = null;
            //////newCopyPatient.BloodGroupType = null;
            //////newCopyPatient.ChestCircumference = null;
            //////newCopyPatient.CityOfBirth = null;
            //////newCopyPatient.CityOfRegistry = null;
            //////newCopyPatient.CountryOfBirth = null;
            //////newCopyPatient.EducationStatus = null;
            //////newCopyPatient.EyeColor = null;

            //Doðum Sonucu Giriliyor.
            PregnancyResult pregnancyResult = new PregnancyResult(objectContext);
                pregnancyResult.BabyStatus = babyObstetricInformation.BabyStatus;
                pregnancyResult.BirthResult = babyObstetricInformation.RegularObstetric.BirthResult;
                pregnancyResult.BirthType = babyObstetricInformation.BirthType;
                pregnancyResult.BirthWeight = babyObstetricInformation.Weigth;
                pregnancyResult.Pregnancy = babyObstetricInformation.RegularObstetric.Pregnancy;
                        
        }

        public static void AddViewModelToContext(TTObjectContext objectContext, BabyInformationFormViewModel viewModel)
        {
            var babyService = new BabyObstetricInformationServiceController();
            babyService.BabyInformationFormInternal(viewModel, objectContext);
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
    }
}

namespace Core.Models
{
    public partial class BabyInformationFormViewModel : BaseViewModel
    {
        public RegularObstetric _RegularObstetric { get; set; }
        public int babyCount { get; set; }
    }
}
