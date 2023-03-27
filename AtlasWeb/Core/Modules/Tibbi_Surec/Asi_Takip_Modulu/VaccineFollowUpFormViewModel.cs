//$0D71C568
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using Core.Services;
using TTDefinitionManagement;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class VaccineFollowUpServiceController : Controller
    {
        partial void PreScript_VaccineFollowUpForm(VaccineFollowUpFormViewModel viewModel, VaccineFollowUp vaccineFollowUp, TTObjectContext objectContext)
        {
            viewModel.PatientID = viewModel._VaccineFollowUp.Episode.Patient.ObjectID;
        }

        [HttpGet]
        public EnumLookupItem[] GetEnumValues(string enumName)
        {
            LookupService service = new LookupService();
            var result = service.EnumList(enumName);
            return result.ToArray();
        }

        [HttpGet]
        public VaccineDefinitionsModel[] PrepareVaccineCalendar(Guid PatientID, bool fromPrepareCalendar)
        {
            var objectContextPatient = new TTObjectContext(true);
            Patient patient = (Patient)objectContextPatient.GetObject(PatientID, TTObjectDefManager.Instance.GetObjectDef(typeof(Patient)));
            IList<VaccineDefinitionsModel> resultList = new List<VaccineDefinitionsModel>();
            var objectContext = new TTObjectContext(true);
            int ageRange = -1;
            if (patient.Age >= 0 && patient.Age <= 3)
                ageRange = Convert.ToInt32(VaccinationAgeTypeEnum.Age_0_3);
            else if (patient.Age >= 4 && patient.Age <= 6)
                ageRange = Convert.ToInt32(VaccinationAgeTypeEnum.Age_4_6);
            else if (patient.Age >= 10 && patient.Age <= 12)
                ageRange = Convert.ToInt32(VaccinationAgeTypeEnum.Age_10_12);
            else if (patient.Age > 12)
                ageRange = Convert.ToInt32(VaccinationAgeTypeEnum.Adult);
            BindingList<VaccineDefinition> vaccineDefList = new BindingList<VaccineDefinition>();
            if (fromPrepareCalendar)
                vaccineDefList = VaccineDefinition.GetVaccineDefinitionNQL(objectContext, ageRange);
            else
                vaccineDefList = VaccineDefinition.GetAllVaccinesNQL(objectContext);
            foreach (var vaccineDef in vaccineDefList)
            {
                VaccineDefinitionsModel def = new VaccineDefinitionsModel();
                def.ObjectID = vaccineDef.ObjectID;
                def.VaccineCode = vaccineDef.Code;
                def.VaccineName = vaccineDef.Name;
                if (vaccineDef.PeriodCriterion == PeriodCriterionEnum.FromBirth)
                    def.StartDate = Convert.ToDateTime(patient.BirthDate);
                else
                    def.StartDate = DateTime.Now;
                def.AsiKoduSKRS = vaccineDef.SKRSAsiKodu;
                IList<VaccinePeriodDefinitionsModel> periodList = new List<VaccinePeriodDefinitionsModel>();
                var appDate = def.StartDate;
                foreach (var period in vaccineDef.VaccinePeriodGrid.OrderBy(p => p.PeriodNumber))
                {
                    VaccinePeriodDefinitionsModel p = new VaccinePeriodDefinitionsModel();
                    p.PeriodNo = period.PeriodNumber.Value;
                    p.PeriodName = period.PeriodDescription;
                    p.Period = period.Period.Value;
                    p.PeriodUnit = period.PeriodType.Value;
                    if (period.PeriodType == PeriodUnitTypeEnum.DayPeriod)
                        appDate = appDate.AddDays(period.Period.Value);
                    else if (period.PeriodType == PeriodUnitTypeEnum.WeekPeriod)
                        appDate = appDate.AddDays(period.Period.Value * 7);
                    else if (period.PeriodType == PeriodUnitTypeEnum.MonthPeriod)
                        appDate = appDate.AddMonths(period.Period.Value);
                    else if (period.PeriodType == PeriodUnitTypeEnum.YearPeriod)
                        appDate = appDate.AddYears(period.Period.Value);
                    p.AppointmentDate = appDate;
                    periodList.Add(p);
                }

                def.VaccinePeriodList = periodList.ToList();
                resultList.Add(def);
            }

            return resultList.ToArray();
        }

        [HttpGet]
        public VaccinePeriodDefinitionsModel[] CalculateAppointmentDate(string StartDate, Guid ObjectID)
        {
            var objectContext = new TTObjectContext(true);
            IList<VaccinePeriodDefinitionsModel> periodList = new List<VaccinePeriodDefinitionsModel>();
            BindingList<VaccineDefinition> vaccineDefList = VaccineDefinition.GetVaccineDefinitionByObjectIDNQL(objectContext, ObjectID);
            if (vaccineDefList.Count > 0)
            {
                var appDate = Convert.ToDateTime(StartDate);
                foreach (var period in vaccineDefList[0].VaccinePeriodGrid.OrderBy(p => p.PeriodNumber))
                {
                    VaccinePeriodDefinitionsModel p = new VaccinePeriodDefinitionsModel();
                    p.PeriodNo = period.PeriodNumber.Value;
                    p.PeriodName = period.PeriodDescription;
                    p.Period = period.Period.Value;
                    p.PeriodUnit = period.PeriodType.Value;
                    if (period.PeriodType == PeriodUnitTypeEnum.DayPeriod)
                        appDate = appDate.AddDays(period.Period.Value);
                    else if (period.PeriodType == PeriodUnitTypeEnum.WeekPeriod)
                        appDate = appDate.AddDays(period.Period.Value * 7);
                    else if (period.PeriodType == PeriodUnitTypeEnum.MonthPeriod)
                        appDate = appDate.AddMonths(period.Period.Value);
                    else if (period.PeriodType == PeriodUnitTypeEnum.YearPeriod)
                        appDate = appDate.AddYears(period.Period.Value);
                    p.AppointmentDate = appDate;
                    periodList.Add(p);
                }
            }

            return periodList.ToArray();
        }

        [HttpPost]
        public void SaveVaccineFollowUpForm(VaccineFollowUpFormViewModel viewModel)
        {
            TTObjectContext tempContext = new TTObjectContext(false);

            using (var objectContext = new TTObjectContext(false))
            {
                VaccineFollowUp vaccineFollowUp = null;
                if (viewModel._VaccineFollowUp.ObjectContext == null)
                    vaccineFollowUp = (VaccineFollowUp)tempContext.AddObject(viewModel._VaccineFollowUp);

                vaccineFollowUp = (VaccineFollowUp)tempContext.GetObject(viewModel._VaccineFollowUp.ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(VaccineFollowUp)));

                if (((ITTObject)vaccineFollowUp).IsNew)
                {
                    vaccineFollowUp = (VaccineFollowUp)objectContext.AddObject(viewModel._VaccineFollowUp);
                }
                else
                    vaccineFollowUp = (VaccineFollowUp)objectContext.GetObject(viewModel._VaccineFollowUp.ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(VaccineFollowUp)));




                Patient patient = (Patient)objectContext.GetObject(vaccineFollowUp.Episode.Patient.ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(Patient)));

                if (viewModel.VaccineDetailsGridList != null)
                {
                    foreach (var item in viewModel.VaccineDetailsGridList)
                    {
                        if (item.CurrentStateDefID != VaccineDetails.States.Canceled)
                        {
                            var vaccineDetailsImported = (VaccineDetails)objectContext.AddObject(item);
                            vaccineDetailsImported.VaccineFollowUp = vaccineFollowUp;
                            vaccineDetailsImported.Patient = patient;
                           
                        }
                    }
                }

                objectContext.Save();
            }
        }

        [HttpPost]
        public void CancelVaccine(VaccineDetails vaccine)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var vaccineDetailsImported = objectContext.GetObject<VaccineDetails>(vaccine.ObjectID); 
                vaccineDetailsImported.CurrentStateDefID = VaccineDetails.States.Deleted;
                objectContext.Save();
            }
        }

        [HttpPost]
        public VaccineFollowUpFormViewModel LoadVaccineFollowupFromPatientID(TTObjectClasses.VaccineFollowUp vaccineFollowUp)
        {
            //Her açıldığında detaylar kaydedildiğinde set etmek için bir episodeaction oluşturuluyor. 
            var FormDefID = Guid.Parse("1f9761b5-df2d-4045-8daa-b547ff5c2e9b");
            var ObjectDefID = Guid.Parse("d36320bd-8295-482b-8cbc-7bfadb52d524");
            var viewModel = new VaccineFollowUpFormViewModel();
            var objectContextPatient = new TTObjectContext(true);
            var objectContext = new TTObjectContext(false);
            TTObjectClasses.VaccineFollowUp vf = objectContext.AddObject(vaccineFollowUp) as TTObjectClasses.VaccineFollowUp;
            Patient patient = (Patient)objectContextPatient.GetObject(vf.Episode.Patient.ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(Patient)));
            if (patient.VaccineDetails.Count > 0)
            {
                using (objectContext)
                {
                    viewModel._VaccineFollowUp = vf;
                    viewModel.PatientID = vf.Episode.Patient.ObjectID;
                    List<VaccineDetails> vList = new List<VaccineDetails>();
                    foreach (var vaccine in patient.VaccineDetails)
                    {
                        if(vaccine.CurrentStateDefID != VaccineDetails.States.Deleted)
                            vList.Add(vaccine);

                    }

                    viewModel.VaccineDetailsGridList = vList.ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (objectContext)
                {
                    viewModel._VaccineFollowUp = new VaccineFollowUp(objectContext);
                    viewModel._VaccineFollowUp = vf;
                    var entryStateID = Guid.Parse("ad3d097b-88ee-43cc-83a1-05146a4e7445");
                    viewModel._VaccineFollowUp.CurrentStateDefID = entryStateID;
                    viewModel.PatientID = vf.Episode.Patient.ObjectID;
                    viewModel.VaccineDetailsGridList = new TTObjectClasses.VaccineDetails[] { };
                }
            }

            return viewModel;
        }


        [HttpGet]
        public LoginUserInfo GetUserInfo()
        {
            LoginUserInfo result = new LoginUserInfo();

            Guid Doctor = new Guid("9431A69C-1A2A-4DCF-B1D3-6B1368318F89"); // Uzman Doktor
            Guid Nurse = new Guid("94572f05-fa8b-4c5a-8f5e-9414e3f1e509");

            if (Common.CurrentResource.UserType == UserTypeEnum.Doctor)
                result.IsDoctor = true;

            if (Common.CurrentResource.UserType == UserTypeEnum.Nurse || Common.CurrentResource.UserType == UserTypeEnum.HeadNurse)
                result.IsNurse = true;

            result.UserInfo = new ResUser();
            result.UserInfo = Common.CurrentResource;


            return result;
        }

    }
}

namespace Core.Models
{
    public partial class VaccineFollowUpFormViewModel
    {
        public Guid PatientID
        {
            get;
            set;
        }
    }

    public class VaccineDefinitionsModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string VaccineCode
        {
            get;
            set;
        }

        public string VaccineName
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public SKRSAsiKodu AsiKoduSKRS
        {
            get;
            set;
        }

        public List<VaccinePeriodDefinitionsModel> VaccinePeriodList
        {
            get;
            set;
        }

        public VaccineDefinitionsModel()
        {
            this.VaccinePeriodList = new List<VaccinePeriodDefinitionsModel>();
        }
    }

    public class VaccinePeriodDefinitionsModel
    {
        public int PeriodNo
        {
            get;
            set;
        }

        public string PeriodName
        {
            get;
            set;
        }

        public int Period
        {
            get;
            set;
        }

        public PeriodUnitTypeEnum PeriodUnit
        {
            get;
            set;
        }

        public DateTime AppointmentDate
        {
            get;
            set;
        }
    }

    public class LoginUserInfo
    {
        public ResUser UserInfo
        {
            get;
            set;
        }
        public bool IsDoctor = false;
        public bool IsNurse = false;

    }
}