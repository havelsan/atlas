//$D14DFC34
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
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using Core.Services;
using Newtonsoft.Json;

namespace Core.Controllers
{
    public partial class ChildGrowthVisitsServiceController
    {
        partial void PreScript_VisitDetailsForm(VisitDetailsFormViewModel viewModel, ChildGrowthVisits childGrowthVisits, TTObjectContext objectContext)
        {
            Guid? selectedPatientObjectID = viewModel.GetSelectedPatientID();
            if (selectedPatientObjectID.HasValue)
            {
                Patient patient = objectContext.GetObject<Patient>(selectedPatientObjectID.Value);
                viewModel._ChildGrowthVisits.Patient = patient;
                viewModel.PatientID = patient.ObjectID;
                viewModel.PatientSex = patient.Sex;
                viewModel._ChildGrowthVisits.CalculatedAge = patient.CalculatedAge;
                DateTime endDate = DateTime.Now;
                DateTime startDate = Convert.ToDateTime(patient.BirthDate);
                viewModel._ChildGrowthVisits.CalculatedAgeByDay = Common.DateDiff(Common.DateIntervalEnum.Month, endDate, startDate); //aya göre değiştirildi -- Convert.ToInt32((endDate - startDate).TotalDays);
                if (childGrowthVisits.VisitDate == null)
                    childGrowthVisits.VisitDate = DateTime.Now;
                if (childGrowthVisits.Date == null)
                    childGrowthVisits.Date = DateTime.Now;

            }

            viewModel.SKRSBebekteRiskFaktorleriList = SKRSBebekteRiskFaktorleri.GetSKRSBebekteRiskFaktorleriList(objectContext, " ").ToList();
            viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklerList = SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler.GetSKRSBebeginCocugunBeyinGelisiminiEtkRisk(objectContext, " ").ToList();
            viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleriList = SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri.GetSKRSEbeveyninPsikolojikGelisimiDestekleyiciAktv(objectContext, "").ToList();

        
          
          
            if(viewModel._ChildGrowthVisits.InfantRiskFactors.Count > 0)
            {
                List<SKRSBebekteRiskFaktorleri> rList = new List<SKRSBebekteRiskFaktorleri>();
                foreach (var data in viewModel._ChildGrowthVisits.InfantRiskFactors)
                {
                    rList.Add(data.SKRSBebekteRiskFaktorleri);  
                }
                viewModel.SKRSBebekteRiskFaktorleris = rList.ToArray();

            }
            else
                viewModel.SKRSBebekteRiskFaktorleris = new SKRSBebekteRiskFaktorleri[0];

            if(viewModel._ChildGrowthVisits.ChildBrainDevelopmentRiskFactors.Count > 0)
            {
                List<SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler> aList = new List<SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler>();
                foreach (var data in viewModel._ChildGrowthVisits.ChildBrainDevelopmentRiskFactors)
                {
                    aList.Add(data.SKRSBebeginBeyinGlsEtkRiskler);

                }
                viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers = aList.ToArray();
            }
            else
                viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers = new SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler[0];

            
            if(viewModel._ChildGrowthVisits.ParentalActivitiesForPsychologicalDevelopment.Count > 0)
            {
                List<SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri> bList = new List<SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri>();
                foreach (var data in viewModel._ChildGrowthVisits.ParentalActivitiesForPsychologicalDevelopment)
                {
                    bList.Add(data.SKRSEbeveynPsikoGlsmDestkAktv);
                

                }
                viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris = bList.ToArray();

            }
            else
                viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris = new SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri[0];


           
        }

        partial void PostScript_VisitDetailsForm(VisitDetailsFormViewModel viewModel, ChildGrowthVisits childGrowthVisits, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

            if (viewModel.SKRSBebekteRiskFaktorleris != null)
            {
                while (viewModel.SKRSBebekteRiskFaktorleris.Count() != childGrowthVisits.InfantRiskFactors.Count)
                {
                    if (viewModel.SKRSBebekteRiskFaktorleris.Count() < childGrowthVisits.InfantRiskFactors.Count)
                        ((ITTObject)childGrowthVisits.InfantRiskFactors[0]).Delete();
                    else
                    {
                        var infantRiskFact = new InfantRiskFactors(objectContext);
                        childGrowthVisits.InfantRiskFactors.Add(infantRiskFact);
                    }
                }
            }

            if (viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers != null)
            {
                while (viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers.Count() != childGrowthVisits.ChildBrainDevelopmentRiskFactors.Count)
                {
                    if (viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers.Count() < childGrowthVisits.ChildBrainDevelopmentRiskFactors.Count)
                        ((ITTObject)childGrowthVisits.ChildBrainDevelopmentRiskFactors[0]).Delete();
                    else
                    {
                        var childBrainDevelopmentRiskFactor = new ChildBrainDevelopmentRiskFactors(objectContext);
                        childGrowthVisits.ChildBrainDevelopmentRiskFactors.Add(childBrainDevelopmentRiskFactor);
                    }
                }
            }

            if (viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris != null)
            {

                while (viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris.Count() != childGrowthVisits.ParentalActivitiesForPsychologicalDevelopment.Count)
                {
                    if (viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris.Count() < childGrowthVisits.ParentalActivitiesForPsychologicalDevelopment.Count)
                        ((ITTObject)childGrowthVisits.ParentalActivitiesForPsychologicalDevelopment[0]).Delete();
                    else
                    {
                        var parentalActivitiesForPsychologicalDevelopment = new ParentalActivitiesForPsychologicalDevelopment(objectContext);
                        childGrowthVisits.ParentalActivitiesForPsychologicalDevelopment.Add(parentalActivitiesForPsychologicalDevelopment);
                    }
                }
            }
            var i = 0;
            if (viewModel.SKRSBebekteRiskFaktorleris != null)
            {
                foreach (var item in viewModel.SKRSBebekteRiskFaktorleris)
                {
                    childGrowthVisits.InfantRiskFactors[i++].SKRSBebekteRiskFaktorleri = item;
                }
            }
            i = 0;
            if (viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers != null)
            {
                foreach (var item in viewModel.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers)
                {
                    childGrowthVisits.ChildBrainDevelopmentRiskFactors[i++].SKRSBebeginBeyinGlsEtkRiskler = item;
                }
            }
            i = 0;
            if (viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris != null)
            {
                foreach (var item in viewModel.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris)
                {
                    childGrowthVisits.ParentalActivitiesForPsychologicalDevelopment[i++].SKRSEbeveynPsikoGlsmDestkAktv = item;
                }
            }
            objectContext.Save();

            PatientAdmission lastPA = PatientAdmission.GetLastPatientAdmissionByPatient(objectContext, childGrowthVisits.Patient.ObjectID).FirstOrDefault();
            if (lastPA != null)
            {
                new SendToENabiz(objectContext, lastPA.FirstSubEpisode, childGrowthVisits.ObjectID, childGrowthVisits.ObjectDef.Name, "209", Common.RecTime());
                new SendToENabiz(objectContext, lastPA.FirstSubEpisode, childGrowthVisits.ObjectID, childGrowthVisits.ObjectDef.Name, "210", Common.RecTime());
                new SendToENabiz(objectContext, lastPA.FirstSubEpisode, childGrowthVisits.ObjectID, childGrowthVisits.ObjectDef.Name, "212", Common.RecTime());
            }


            
        }

        public class PercentileInfo
        {
            public decimal age;
            public decimal? P3;
            public decimal? P15;
            public decimal? P50;
            public decimal? P85;
            public decimal? P97;
            public decimal? PatientInfo;
        }

        public class Input
        {
            public string graphName
            {
                get;
                set;
            }

            public string sex
            {
                get;
                set;
            }

            public string PatientID
            {
                get;
                set;
            }
        }

        public class GetPatientVisits_Input
        {
            public string PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetPercentileInfo(Input inputObj)
        {
            //yaşa göre olan grafikler aya göre hesaplanmalı
            IList<PercentileInfo> percentileList = new List<PercentileInfo>();
            IBindingList percentiles = ChildPercentileValues.GetChildPercentileValuesNql(inputObj.sex, inputObj.graphName);
            var objectContext = new TTObjectContext(true);
            foreach (ChildPercentileValues.GetChildPercentileValuesNql_Class pInfo in percentiles)
            {
                if (inputObj.graphName == "WFH")
                {
                    PercentileInfo p = new PercentileInfo();
                    p.age = Convert.ToDecimal(pInfo.Length.Replace('.', ','));
                    p.P3 = Convert.ToDecimal(pInfo.P3.Replace('.', ','));
                    p.P15 = Convert.ToDecimal(pInfo.P15.Replace('.', ','));
                    p.P50 = Convert.ToDecimal(pInfo.P50.Replace('.', ','));
                    p.P85 = Convert.ToDecimal(pInfo.P85.Replace('.', ','));
                    p.P97 = Convert.ToDecimal(pInfo.P97.Replace('.', ','));
                    p.PatientInfo = null;
                    percentileList.Add(p);
                }
                else
                {
                    PercentileInfo p = new PercentileInfo();
                    DateTime now = DateTime.Now;
                    DateTime startDate = now.AddDays(Convert.ToInt32(pInfo.Day) * -1);
                    p.age = Common.DateDiff(Common.DateIntervalEnum.Month, now, startDate); //Convert.ToInt32(pInfo.Day);
                    p.P3 = Convert.ToDecimal(pInfo.P3.Replace('.', ','));
                    p.P15 = Convert.ToDecimal(pInfo.P15.Replace('.', ','));
                    p.P50 = Convert.ToDecimal(pInfo.P50.Replace('.', ','));
                    p.P85 = Convert.ToDecimal(pInfo.P85.Replace('.', ','));
                    p.P97 = Convert.ToDecimal(pInfo.P97.Replace('.', ','));
                    p.PatientInfo = null;
                    percentileList.Add(p);
                }
            }

            IBindingList patientVisits = ChildGrowthVisits.GetPatientVisits(objectContext, inputObj.PatientID);
            foreach (ChildGrowthVisits visit in patientVisits)
            {
                if (inputObj.graphName == "WFH")
                {
                    if (visit.Height != null && visit.Weight != null)
                    {
                        PercentileInfo p = new PercentileInfo();
                        p.age = Convert.ToInt32(visit.Height);
                        p.P3 = null;
                        p.P15 = null;
                        p.P50 = null;
                        p.P85 = null;
                        p.P97 = null;
                        p.PatientInfo = Convert.ToDecimal(visit.Weight.ToString().Replace('.', ','));
                        percentileList.Add(p);
                    }
                }
                else if (inputObj.graphName == "LHFA")
                {
                    if (visit.CalculatedAgeByDay != null && visit.Height != null)
                    {
                        PercentileInfo p = new PercentileInfo();
                        p.age = Convert.ToInt32(visit.CalculatedAgeByDay); // güne göre age
                        p.P3 = null;
                        p.P15 = null;
                        p.P50 = null;
                        p.P85 = null;
                        p.P97 = null;
                        p.PatientInfo = Convert.ToDecimal(visit.Height);
                        percentileList.Add(p);
                    }
                }
                else if (inputObj.graphName == "WFA")
                {
                    if (visit.CalculatedAgeByDay != null && visit.Weight != null)
                    {
                        PercentileInfo p = new PercentileInfo();
                        p.age = Convert.ToInt32(visit.CalculatedAgeByDay); // güne göre age
                        p.P3 = null;
                        p.P15 = null;
                        p.P50 = null;
                        p.P85 = null;
                        p.P97 = null;
                        p.PatientInfo = Convert.ToDecimal(visit.Weight.ToString().Replace('.', ','));
                        percentileList.Add(p);
                    }
                }
                else if (inputObj.graphName == "BFA")
                {
                    if (visit.CalculatedAgeByDay != null && visit.BMI != null)
                    {
                        PercentileInfo p = new PercentileInfo();
                        p.age = Convert.ToInt32(visit.CalculatedAgeByDay); // güne göre age
                        p.P3 = null;
                        p.P15 = null;
                        p.P50 = null;
                        p.P85 = null;
                        p.P97 = null;
                        p.PatientInfo = Convert.ToDecimal(visit.BMI.ToString().Replace('.', ','));
                        percentileList.Add(p);
                    }
                }
                else if (inputObj.graphName == "HCFA")
                {
                    if (visit.CalculatedAgeByDay != null && visit.BMI != null)
                    {
                        PercentileInfo p = new PercentileInfo();
                        p.age = Convert.ToInt32(visit.CalculatedAgeByDay); // güne göre age
                        p.P3 = null;
                        p.P15 = null;
                        p.P50 = null;
                        p.P85 = null;
                        p.P97 = null;
                        p.PatientInfo = Convert.ToDecimal(visit.BMI.ToString().Replace('.', ','));
                        percentileList.Add(p);
                    }
                }
                else if (inputObj.graphName == "ACFA")
                {
                    if (visit.CalculatedAgeByDay != null && visit.ArmCircle != null)
                    {
                        PercentileInfo p = new PercentileInfo();
                        p.age = Convert.ToInt32(visit.CalculatedAgeByDay); // güne göre age
                        p.P3 = null;
                        p.P15 = null;
                        p.P50 = null;
                        p.P85 = null;
                        p.P97 = null;
                        p.PatientInfo = Convert.ToDecimal(visit.ArmCircle.ToString().Replace('.', ','));
                        percentileList.Add(p);
                    }
                }
                else if (inputObj.graphName == "SSFA")
                {
                    if (visit.CalculatedAgeByDay != null && visit.Subscapular != null)
                    {
                        PercentileInfo p = new PercentileInfo();
                        p.age = Convert.ToInt32(visit.CalculatedAgeByDay); // güne göre age
                        p.P3 = null;
                        p.P15 = null;
                        p.P50 = null;
                        p.P85 = null;
                        p.P97 = null;
                        p.PatientInfo = Convert.ToDecimal(visit.Subscapular.ToString().Replace('.', ','));
                        percentileList.Add(p);
                    }
                }
                else if (inputObj.graphName == "TSFA")
                {
                    if (visit.CalculatedAgeByDay != null && visit.TricepsSkinfold != null)
                    {
                        PercentileInfo p = new PercentileInfo();
                        p.age = Convert.ToInt32(visit.CalculatedAgeByDay); // güne göre age
                        p.P3 = null;
                        p.P15 = null;
                        p.P50 = null;
                        p.P85 = null;
                        p.P97 = null;
                        p.PatientInfo = Convert.ToDecimal(visit.TricepsSkinfold.ToString().Replace('.', ','));
                        percentileList.Add(p);
                    }
                }
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(percentileList, settings);
        }

        [HttpGet]
        public EnumLookupItem[] GetEnumValues(string enumName)
        {
            LookupService service = new LookupService();
            var result = service.EnumList(enumName);
            return result.ToArray();
        }
    }
}

namespace Core.Models
{
    public partial class VisitDetailsFormViewModel : BaseViewModel
    {
        public Guid PatientID
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSCinsiyet PatientSex
        {
            get;
            set;
        }

        public List<TTObjectClasses.SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri> SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleriList
        {
            get;
            set;
        }

        public List<TTObjectClasses.SKRSBebekteRiskFaktorleri> SKRSBebekteRiskFaktorleriList
        {
            get;
            set;
        }

        public List<TTObjectClasses.SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler> SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklerList
        {
            get;
            set;
        }
    }
}
