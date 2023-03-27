using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class RadiologyTemplateServiceController : Controller
    {
        [HttpGet]
        public RadiologyTemplateFormViewModel LoadRadiologyTemplateFormViewModel()
        {
            RadiologyTemplateFormViewModel model = new RadiologyTemplateFormViewModel();
            model.RadiologyProcedureList = new List<RadiologyProcedureInfo>();
            model.RadiologyDoctorList = new List<RadiologyDoctorInfo>();
            model.TemplateList = new List<RadiologyTemplateInfo>();

            using (var objectContext = new TTObjectContext(true))
            {

                //Radyoloji İşlemleri Listeleri
                List<RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class> radiologyTests = RadiologyTestDefinition.GetRadiologyTestDefinitionNQL(" WHERE ISACTIVE = 1 ").ToList();
                foreach (RadiologyTestDefinition.GetRadiologyTestDefinitionNQL_Class test in radiologyTests)
                {
                    RadiologyProcedureInfo o = new RadiologyProcedureInfo();
                    o.ObjectID = test.ObjectID.ToString();
                    o.Code = test.Code;
                    o.Name = test.Code +"-" +test.Name;
                    model.RadiologyProcedureList.Add(o);

                }

                List<RadiologyTemplate.GetRadiologyTemplates_Class> radiologyTemplates = RadiologyTemplate.GetRadiologyTemplates().ToList();
                foreach (RadiologyTemplate.GetRadiologyTemplates_Class template in radiologyTemplates)
                {
                    RadiologyTemplateInfo o = new RadiologyTemplateInfo();
                    o.ObjectID = template.ObjectID.ToString();
                    o.Name = template.TemplateName;
                    model.TemplateList.Add(o);

                }

                List<ResUser.RadiologyUsersNQL_Class> radiologyDoctorList = ResUser.RadiologyUsersNQL(" AND USERTYPE <> 7 ").ToList();
                foreach(ResUser.RadiologyUsersNQL_Class doctor in radiologyDoctorList)
                {
                    RadiologyDoctorInfo d = new RadiologyDoctorInfo();
                    d.ObjectID = doctor.ObjectID.ToString();
                    d.Name = doctor.Name;
                    model.RadiologyDoctorList.Add(d);
                }


            }

            return model;
        }

      

        [HttpPost]
        public RadiologyTemplateInfo[] SaveRadiologyTemplateFormViewModel(RadiologyTemplateInput input)
        {
            List<RadiologyTemplateInfo> templateList = new List<RadiologyTemplateInfo>();
            using (var objectContext = new TTObjectContext(false))
            {
               
                if(input.IsNew == true) { 
                    RadiologyTemplate radiologyTemplate = new RadiologyTemplate(objectContext);
                    radiologyTemplate.TemplateName = input.TemplateName;
                    radiologyTemplate.Report = input.Report;
                    radiologyTemplate.Results = input.Results;
                    radiologyTemplate.ComparisonInfo = input.ComparisonInfo;
                    radiologyTemplate.RadiographyTechnique = input.RadiographyTechnique;
                    radiologyTemplate.IsActive = true;
                    foreach(RadiologyProcedureInfo test in input.SelectedRadiologyProcedures)
                    {
                        RadiologyTempProcedures tempProcedure = new RadiologyTempProcedures(objectContext);
                        tempProcedure.RadiologyTemplate = radiologyTemplate;
                        tempProcedure.RadiologyTestDefinition = objectContext.GetObject<RadiologyTestDefinition>(new Guid(test.ObjectID));

                    }

                    foreach(RadiologyDoctorInfo doctor in input.SelectedRadiologyDoctors)
                    {
                        RadiologyTempDoctors tempDoctor = new RadiologyTempDoctors(objectContext);
                        tempDoctor.RadiologyTemplate = radiologyTemplate;
                        tempDoctor.ResUser = objectContext.GetObject<ResUser>(new Guid(doctor.ObjectID));
                    }

                }else
                {
                    RadiologyTemplate radiologyTemplate = objectContext.GetObject<RadiologyTemplate>(new Guid(input.ObjectID));
                    radiologyTemplate.TemplateName = input.TemplateName;
                    radiologyTemplate.Report = input.Report;
                    radiologyTemplate.Results = input.Results;
                    radiologyTemplate.ComparisonInfo = input.ComparisonInfo;
                    radiologyTemplate.RadiographyTechnique = input.RadiographyTechnique;
                    radiologyTemplate.IsActive = true;

                    foreach (RadiologyTempProcedures item in radiologyTemplate.RadiologyTempProcedures.Select(string.Empty))
                    {

                        ((ITTObject)item).Delete();
                           
                    }

                    foreach (RadiologyProcedureInfo test in input.SelectedRadiologyProcedures)
                    {
                        RadiologyTempProcedures tempProcedure = new RadiologyTempProcedures(objectContext);
                        tempProcedure.RadiologyTemplate = radiologyTemplate;
                        tempProcedure.RadiologyTestDefinition = objectContext.GetObject<RadiologyTestDefinition>(new Guid(test.ObjectID));

                    }

                    foreach (RadiologyTempDoctors item in radiologyTemplate.RadiologyTempDoctors.Select(string.Empty))
                    {

                        ((ITTObject)item).Delete();

                    }

                    foreach (RadiologyDoctorInfo doctor in input.SelectedRadiologyDoctors)
                    {
                        RadiologyTempDoctors tempDoctor = new RadiologyTempDoctors(objectContext);
                        tempDoctor.RadiologyTemplate = radiologyTemplate;
                        tempDoctor.ResUser = objectContext.GetObject<ResUser>(new Guid(doctor.ObjectID));
                    }

                }

                objectContext.Save();

                List<RadiologyTemplate.GetRadiologyTemplates_Class> radiologyTemplates = RadiologyTemplate.GetRadiologyTemplates().ToList();
                foreach (RadiologyTemplate.GetRadiologyTemplates_Class template in radiologyTemplates)
                {
                    RadiologyTemplateInfo o = new RadiologyTemplateInfo();
                    o.ObjectID = template.ObjectID.ToString();
                    o.Name = template.TemplateName;
                    templateList.Add(o);

                }
            }
            return templateList.ToArray();
        }

        [HttpGet]
        public void DeleteRadiologyTemplate(string TemplateObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                RadiologyTemplate template = objectContext.GetObject<RadiologyTemplate>(new Guid(TemplateObjectID));
                template.IsActive = false;
                objectContext.Save();
            }
        }

        [HttpGet]
        public RadiologyTemplateInput LoadSelectedRadiologyTemplate(string TemplateObjectID)
        {
            RadiologyTemplateInput template = new RadiologyTemplateInput();
            using (var objectContext = new TTObjectContext(true))
            {
                RadiologyTemplate radiologyTemplate = objectContext.GetObject<RadiologyTemplate>(new Guid(TemplateObjectID));
                template.ObjectID = radiologyTemplate.ObjectID.ToString();
                template.TemplateName = radiologyTemplate.TemplateName;
                template.Report = radiologyTemplate.Report;
                template.Results = radiologyTemplate.Results;
                template.ComparisonInfo = radiologyTemplate.ComparisonInfo;
                template.RadiographyTechnique = radiologyTemplate.RadiographyTechnique;
                template.IsActive = radiologyTemplate.IsActive==null?false:Convert.ToBoolean(radiologyTemplate.IsActive);
                template.SelectedRadiologyProcedures = new List<RadiologyProcedureInfo>();
                template.SelectedRadiologyDoctors = new List<RadiologyDoctorInfo>();
                template.IsNew = false;

                foreach (RadiologyTempProcedures procedure in radiologyTemplate.RadiologyTempProcedures)
                {
                    RadiologyProcedureInfo tempProcedure = new RadiologyProcedureInfo();
                    tempProcedure.Name = procedure.RadiologyTestDefinition.Code +"-"+procedure.RadiologyTestDefinition.Name;
                    tempProcedure.ObjectID = procedure.RadiologyTestDefinition.ObjectID.ToString();
                    tempProcedure.Code = procedure.RadiologyTestDefinition.Code;
                    template.SelectedRadiologyProcedures.Add(tempProcedure);

                }

                foreach (RadiologyTempDoctors doctor in radiologyTemplate.RadiologyTempDoctors)
                {
                    RadiologyDoctorInfo tempDoctor = new RadiologyDoctorInfo();
                    tempDoctor.ObjectID = doctor.ResUser.ObjectID.ToString();
                    tempDoctor.Name = doctor.ResUser.Name;
                    template.SelectedRadiologyDoctors.Add(tempDoctor);
                }


            }

            return template;
        }
    }
}

namespace Core.Models
{
    public class RadiologyTemplateFormViewModel
    {
        public List<RadiologyProcedureInfo> RadiologyProcedureList {get;set;}
        public List<RadiologyTemplateInfo> TemplateList { get; set; }
        public List<RadiologyDoctorInfo> RadiologyDoctorList { get; set; }

    }

    public class RadiologyProcedureInfo
    {
        public string ObjectID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class RadiologyTemplateInfo
    {
        public string ObjectID { get; set; }
        public string Name { get; set; }
    }
    public class RadiologyDoctorInfo
    {
        public string ObjectID { get; set; }
        public string Name { get; set; }
    }

    public class RadiologyTemplateInput
    {
        public object Report { get; set; }
        public object RadiographyTechnique { get; set; }
        public object ComparisonInfo { get; set; }
        public object Results { get; set; }
        public string TemplateName { get; set; }
        public string ObjectID { get; set; }
        public bool IsActive { get; set; }
        public bool IsNew { get; set; }
        public List<RadiologyProcedureInfo> SelectedRadiologyProcedures { get; set; }
        public List<RadiologyDoctorInfo> SelectedRadiologyDoctors { get; set; }
    }

}