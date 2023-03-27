using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.Bond;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;
using Core.Security;
using System.Collections;
using System.ComponentModel;

namespace Core.Controllers.EquivalentMaterialReport
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class CovidDrugReportServiceController : Controller
    {

        [HttpPost]
        public CovidDrugReportFormGridViewModel GetCovidList(CovidDrugReportSearchModel searchModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                DateTime startDate = new DateTime(searchModel.StartDate.Year, searchModel.StartDate.Month, searchModel.StartDate.Day, 0, 0, 0);
                DateTime endDate = new DateTime(searchModel.EndDate.Year, searchModel.EndDate.Month, searchModel.EndDate.Day, 23, 59, 59);
                CovidDrugReportFormGridViewModel output = new CovidDrugReportFormGridViewModel();
                BindingList<SubActionMaterial.GetCovidOutPatientList_Class> outpatients = SubActionMaterial.GetCovidOutPatientList(startDate, endDate);
                BindingList<DrugOrderDetail.GetCovidInpatientList_Class> inpatients = DrugOrderDetail.GetCovidInpatientList(startDate, endDate);

                List<Guid> hidList = new List<Guid>();
                List<Guid> favList = new List<Guid>();
                List<Guid> hidFavList = new List<Guid>();
                List<Guid> antiList = new List<Guid>();
                List<Guid> steList = new List<Guid>();

                List<Guid> inHidList = new List<Guid>();
                List<Guid> inFavList = new List<Guid>();
                List<Guid> inHidFavList = new List<Guid>();
                List<Guid> inAntiList = new List<Guid>();
                List<Guid> inSteList = new List<Guid>();

                foreach (SubActionMaterial.GetCovidOutPatientList_Class outpatient in outpatients)
                {
                    DrugDefinition drug = (DrugDefinition)objectContext.GetObject(outpatient.Drug.Value, typeof(DrugDefinition));
                    if(drug.DrugActiveIngredients.Select(x=> x.ActiveIngredient.ObjectID == new Guid("238caa32-7745-4bba-9701-0c5c0e9fcc8a")).Any())
                    {
                        if(favList.Contains(outpatient.ObjectID.Value) == false)
                        {
                            if (hidList.Contains(outpatient.ObjectID.Value) == false)
                                hidList.Add(outpatient.ObjectID.Value);
                        }
                        else
                        {
                            if (hidFavList.Contains(outpatient.ObjectID.Value) == false)
                                hidFavList.Add(outpatient.ObjectID.Value);

                            favList.Remove(outpatient.ObjectID.Value);
                        }
                    }

                    if (drug.DrugActiveIngredients.Select(x => x.ActiveIngredient.ObjectID == new Guid("98cb12a9-3c42-4b82-b3fb-e67d2eefb0a7")).Any())
                    {
                        if (hidList.Contains(outpatient.ObjectID.Value) == false)
                        {
                            if (favList.Contains(outpatient.ObjectID.Value) == false)
                                favList.Add(outpatient.ObjectID.Value);
                        }
                        else
                        {
                            if (hidFavList.Contains(outpatient.ObjectID.Value) == false)
                                hidFavList.Add(outpatient.ObjectID.Value);

                            hidList.Remove(outpatient.ObjectID.Value);
                        }
                    }

                    if(drug.DrugSpecifications.Select(x=> x.DrugSpecification = DrugSpecificationEnum.Antibiotics).Any())
                    {
                        if (antiList.Contains(outpatient.ObjectID.Value) == false)
                            antiList.Add(outpatient.ObjectID.Value);
                    }

                    if (drug.DrugSpecifications.Select(x => x.DrugSpecification = DrugSpecificationEnum.Steroid).Any())
                    {
                        if (steList.Contains(outpatient.ObjectID.Value) == false)
                            steList.Add(outpatient.ObjectID.Value);
                    }
                }

                foreach (DrugOrderDetail.GetCovidInpatientList_Class inpatient in inpatients)
                {
                    DrugDefinition drug = (DrugDefinition)objectContext.GetObject(inpatient.Drug.Value, typeof(DrugDefinition));
                    if (drug.DrugActiveIngredients.Select(x => x.ActiveIngredient.ObjectID == new Guid("238caa32-7745-4bba-9701-0c5c0e9fcc8a")).Any())
                    {
                        if (inFavList.Contains(inpatient.ObjectID.Value) == false)
                        {
                            if (inHidList.Contains(inpatient.ObjectID.Value) == false)
                                inHidList.Add(inpatient.ObjectID.Value);
                        }
                        else
                        {
                            if (inHidFavList.Contains(inpatient.ObjectID.Value) == false)
                                inHidFavList.Add(inpatient.ObjectID.Value);

                            inFavList.Remove(inpatient.ObjectID.Value);
                        }
                    }

                    if (drug.DrugActiveIngredients.Select(x => x.ActiveIngredient.ObjectID == new Guid("98cb12a9-3c42-4b82-b3fb-e67d2eefb0a7")).Any())
                    {
                        if (inHidList.Contains(inpatient.ObjectID.Value) == false)
                        {
                            if (inFavList.Contains(inpatient.ObjectID.Value) == false)
                                inFavList.Add(inpatient.ObjectID.Value);
                        }
                        else
                        {
                            if (inHidFavList.Contains(inpatient.ObjectID.Value) == false)
                                inHidFavList.Add(inpatient.ObjectID.Value);

                            inHidList.Remove(inpatient.ObjectID.Value);
                        }
                    }

                    if (drug.DrugSpecifications.Select(x => x.DrugSpecification = DrugSpecificationEnum.Antibiotics).Any())
                    {
                        if (inAntiList.Contains(inpatient.ObjectID.Value) == false)
                            inAntiList.Add(inpatient.ObjectID.Value);
                    }

                    if (drug.DrugSpecifications.Select(x => x.DrugSpecification = DrugSpecificationEnum.Steroid).Any())
                    {
                        if (inSteList.Contains(inpatient.ObjectID.Value) == false)
                            inSteList.Add(inpatient.ObjectID.Value);
                    }
                }

                output.HidOutpatient = hidList.Count();
                output.FavOutpatient = favList.Count();
                output.HidFavOutpatient = hidFavList.Count();
                output.AntiOutpatient = antiList.Count();
                output.SteOutpatient = steList.Count();

                output.HidInpatient = inHidList.Count();
                output.FavInpatient = inFavList.Count();
                output.HidFavInpatient = inHidFavList.Count();
                output.AntiInpatient = inAntiList.Count();
                output.SteInpatient = inSteList.Count();


                return output;
            }
        }
    }


    //Listeleme için sunucuya gönderilecek olan arama kriterleri
    public class CovidDrugReportSearchModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


    public class CovidDrugReportFormGridViewModel
    {
        public double HidOutpatient { get; set; }
        public double FavOutpatient { get; set; }
        public double HidFavOutpatient { get; set; }
        public double AntiOutpatient { get; set; }
        public double SteOutpatient { get; set; }
        public double HidInpatient { get; set; }
        public double FavInpatient { get; set; }
        public double HidFavInpatient { get; set; }
        public double AntiInpatient { get; set; }
        public double SteInpatient { get; set; }
    }
}