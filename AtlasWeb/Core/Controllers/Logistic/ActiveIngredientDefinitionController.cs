using Core.Models;
using DevExpress.Utils.Extensions;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using TTReportClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class ActiveIngredientDefinitionController : Controller
    {

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetActiveIngredientDefinition getActiveIngredientDef()
        {
            using (var objectContext = new TTObjectContext(true))
            {

                GetActiveIngredientDefinition returnOTD = new GetActiveIngredientDefinition();
                List<ActiveIngredientDefDataSource> orderTemplateDefinitionDataSource = ActiveIngredientDefinition.GetActiveIngredientDefinitions(string.Empty).Select(x => new ActiveIngredientDefDataSource()
                {
                    Name = x.Name,
                    ObjectID = x.ObjectID.Value,
                    Code = x.Code
                }).ToList();

                returnOTD.activeIngredientDefDataSource = orderTemplateDefinitionDataSource;

                var maxDoseUnits = objectContext.QueryObjects<UnitDefinition>();
                returnOTD.maxDoseUnitList = maxDoseUnits.Select(x => new MaxDoseUnitList()
                {
                    Name = x.Name,
                    ObjectID = x.ObjectID
                }).ToList();

                objectContext.FullPartialllyLoadedObjects();
                return returnOTD;
            }
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ActiveIngredientDefinitionDTO getActiveIngredientDefinitionDTO(GettActiveIngredientDefinition_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                ActiveIngredientDefinitionDTO ingredientDefinitionDTO = new ActiveIngredientDefinitionDTO();
                ActiveIngredientDefinition activeIngredientDefinition = (ActiveIngredientDefinition)objectContext.GetObject(input.ObjectID, typeof(ActiveIngredientDefinition));

                ingredientDefinitionDTO.Name = activeIngredientDefinition.Name;
                ingredientDefinitionDTO.Code = activeIngredientDefinition.Code;
                ingredientDefinitionDTO.ObjectID = activeIngredientDefinition.ObjectID;
                ingredientDefinitionDTO.ActiveIngredientDefDetails = new List<ActiveIngredientDetailDTO>();

                foreach (ActiveIngredientDetail x in activeIngredientDefinition.ActiveIngredientDetails.Select(string.Empty))
                {
                    ActiveIngredientDetailDTO detailDTO = new ActiveIngredientDetailDTO();
                    detailDTO.ObjectID = x.ObjectID;
                    detailDTO.EndAge = x.EndAge;
                    detailDTO.StartingAge = x.StartingAge;
                    detailDTO.MaxDose = x.MaxDose;
                    detailDTO.Sex = x.Sex;
                    detailDTO.MaxDoseUnit = x.MaxDoseUnit == null ? Guid.Empty : x.MaxDoseUnit.ObjectID;
                    ingredientDefinitionDTO.ActiveIngredientDefDetails.Add(detailDTO);
                }
                objectContext.FullPartialllyLoadedObjects();
                return ingredientDefinitionDTO;
            }
        }


        [HttpPost]
        public string saveObject(ActiveIngredientDefinitionDTO input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                ActiveIngredientDefinition activeIngredientDefinition;
                if (input.isNew == true)
                {
                    activeIngredientDefinition = new ActiveIngredientDefinition(objectContext);
                  
                }
                else
                {
                    activeIngredientDefinition = objectContext.GetObject<ActiveIngredientDefinition>(input.ObjectID);
                    foreach (ActiveIngredientDetail item in activeIngredientDefinition.ActiveIngredientDetails.Select(string.Empty))
                    {
                        ((ITTObject)item).Delete();
                    }
                }
                activeIngredientDefinition.Name = input.Name;
                activeIngredientDefinition.Code = input.Code;

                foreach (ActiveIngredientDetailDTO x in input.ActiveIngredientDefDetails)
                {
                    ActiveIngredientDetail newDetail = new ActiveIngredientDetail(objectContext);
                    newDetail.EndAge = x.EndAge;
                    newDetail.StartingAge = x.StartingAge;
                    newDetail.MaxDose = x.MaxDose;
                    if (x.MaxDoseUnit != null || x.MaxDoseUnit != Guid.Empty)
                        newDetail.MaxDoseUnit = objectContext.GetObject<UnitDefinition>((Guid)x.MaxDoseUnit);
                    newDetail.ActiveIngredient = activeIngredientDefinition;
                }

                objectContext.Save();
                objectContext.Dispose();
                return "Etken Madde Kayıt İşlemi Yapılmıştır";
            }
            catch
            {
                return " Etken Madde İşlemi Sırasında Hata Alınmıştır..";
            }
        }



        public class ActiveIngredientDefDataSource
        {

            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
        }

        public class GetActiveIngredientDefinition
        {
            public List<ActiveIngredientDefDataSource> activeIngredientDefDataSource { get; set; }
            public List<MaxDoseUnitList> maxDoseUnitList { get; set; }
        }

        public class GettActiveIngredientDefinition_Input
        {
            public Guid ObjectID { get; set; }
        }

        public class ActiveIngredientDefinitionDTO
        {
            public bool isNew { get; set; }
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public List<ActiveIngredientDetailDTO> ActiveIngredientDefDetails { get; set; }
        }


        public class ActiveIngredientDetailDTO
        {
            public Guid ObjectID { get; set; }
            public int? StartingAge { get; set; }
            public int? EndAge { get; set; }
            public Double? MaxDose { get; set; }
            public SexEnum? Sex { get; set; }
            public Guid? MaxDoseUnit { get; set; }
        }

        public class MaxDoseUnitList
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
        }
    }
}
