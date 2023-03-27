using Infrastructure.Filters;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.Controllers
{
    //[Authorize]
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class SystemParameterController : Controller
    {
        public class GetParameterValueInput
        {
            public string name;
            public string defaultValue;
        }

        [HttpPost]
        public string GetParameterValue(GetParameterValueInput input)
        {
            return TTObjectClasses.SystemParameter.GetParameterValue(input.name, input.defaultValue);
        }

        [HttpPost]
        public List<Yerlesim> GetYerlesimYerleri(string filter, int ? parentId, IDictionary<string, object> parameters)
        {
            List<Yerlesim> yerlesimler = new List<Yerlesim>();
            int id = parentId == null ? 0 : parentId.Value;
            yerlesimler.Add(new Yerlesim()
            {Id = id + 10, YerlesimAdi = "Türkiye", ParentId = parentId, AltYerlesimleriVar = true});
            yerlesimler.Add(new Yerlesim()
            {Id = id + 20, YerlesimAdi = "Almanya", ParentId = parentId, AltYerlesimleriVar = true});
            return yerlesimler;
        }

        [HttpGet]
        public bool IsPatientExaminationParticipationControl()
        {
            return TTObjectClasses.SystemParameter.IsPatientExaminationParticipationControl;
        }

        [HttpGet]
        public bool IsDigitalSignatureIntegration()
        {
            return TTObjectClasses.SystemParameter.IsDigitalSignatureIntegration;
        }

        [HttpGet]
        public bool IsUniversityHospital()
        {
            return TTObjectClasses.SystemParameter.IsUniversityHospital;
        }

        [HttpGet]
        public bool IsMedulaTest()
        {
            return TTObjectClasses.SystemParameter.IsMedulaTest;
        }

        [HttpGet]
        public bool IsMedula()
        {
            return TTObjectClasses.SystemParameter.IsMedula;
        }

        [HttpGet]
        public bool IsMedulaIntegration()
        {
            return TTObjectClasses.SystemParameter.IsMedulaIntegration;
        }

        [HttpGet]
        public bool IsWorkWithOutStock()
        {
            return TTObjectClasses.SystemParameter.IsWorkWithOutStock;
        }
    }
}