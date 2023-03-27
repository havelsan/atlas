//$C2FB8EDA
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class MagistralPreparationActionServiceController : Controller
    {
        public class GetMagistralDefinition_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        public class GetMagistralDefinition_Output
        {
            public MagistralPreparationDefinition magistralDef
            {
                get;
                set;
            }

            public List<MagistralDefUsedDrug> magistralDefUsedDrugs
            {
                get;
                set;
            }

            public List<MagistralDefUsedChemical> magistralDefUsedChemicals
            {
                get;
                set;
            }

            public List<MagistralDefUsedConsMat> magistralDefUsedConsMats
            {
                get;
                set;
            }

            public MagistralPackagingType magistralPackagingType
            {
                get;
                set;
            }

            public MagistralPackagingSubType magistralPackagingSubType
            {
                get;
                set;
            }

            public MagistralPreparationType magistralPreparationType
            {
                get;
                set;
            }

            public MagistralPreparationSubType magistralPreparationSubType
            {
                get;
                set;
            }
        }

        [HttpPost]
        public GetMagistralDefinition_Output GetMagistralDefinition(GetMagistralDefinition_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                GetMagistralDefinition_Output output = new Controllers.MagistralPreparationActionServiceController.GetMagistralDefinition_Output();
                output.magistralDef = (MagistralPreparationDefinition)objectContext.GetObject(input.OBJECTID, typeof (MagistralPreparationDefinition));
                output.magistralPackagingType = output.magistralDef.MagistralPackagingType;
                output.magistralPackagingSubType = output.magistralDef.MagistralPackagingSubType;
                output.magistralPreparationType = output.magistralDef.MagistralPreparationType;
                output.magistralPreparationSubType = output.magistralDef.MagistralPreparationSubType;
                output.magistralDefUsedDrugs = new List<MagistralDefUsedDrug>();
                output.magistralDefUsedChemicals = new List<MagistralDefUsedChemical>();
                output.magistralDefUsedConsMats = new List<MagistralDefUsedConsMat>();
                foreach (MagistralDefUsedDrug drug in output.magistralDef.MagistralDefUsedDrugs)
                {
                    output.magistralDefUsedDrugs.Add(drug);
                }

                foreach (MagistralDefUsedChemical chemical in output.magistralDef.MagistralDefUsedChemicals)
                {
                    output.magistralDefUsedChemicals.Add(chemical);
                }

                foreach (MagistralDefUsedConsMat material in output.magistralDef.MagistralDefUsedConsMats)
                {
                    output.magistralDefUsedConsMats.Add(material);
                }

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public Material GetMagistralPackagingSubTypeMaterial(GetMagistralDefinition_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                MagistralPackagingSubType subtype = (MagistralPackagingSubType)objectContext.GetObject(input.OBJECTID, typeof (MagistralPackagingSubType));
                objectContext.FullPartialllyLoadedObjects();
                return subtype.Material;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Majistral_Ilac_Hazirlama_Istek, TTRoleNames.Majistral_Ilac_Hazirlama_Majistral_Hazirlama, TTRoleNames.Majistral_Ilac_Hazirlama_Onay)]
        public Material GetChemicalMaterial(GetMagistralDefinition_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                MagistralChemicalDefinition chemicalDef = (MagistralChemicalDefinition)objectContext.GetObject(input.OBJECTID, typeof (MagistralChemicalDefinition));
                objectContext.FullPartialllyLoadedObjects();
                return chemicalDef.Material;
            }
        }
    }
}