//$D3D1EFDA
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public partial class NursingCareServiceController
    {
        partial void PreScript_NursingCareMainForm(NursingCareMainFormViewModel viewModel, NursingCare nursingCare, TTObjectContext objectContext)
        {
            if (!((ITTObject)nursingCare).IsNew)
            {
                viewModel.NursingProblemDefinitions = NursingProblemDefinition.GetAllNursingProbDef(objectContext, " WHERE ISACTIVE = 1").ToArray();
                viewModel.NursingCareDefinitions = NursingCareDefinition.GetNursingCareDefinitionByProblemID(objectContext, nursingCare.NursingProblem.ObjectID.ToString()).ToArray();
                viewModel.NursingReasonDefinitions = GetNursingReasonDefinitionByProblemID(nursingCare.NursingProblem.ObjectID);
                viewModel.NursingCareDefinitions = GetNursingCareDefinitionListByProblemID(nursingCare.NursingProblem.ObjectID);
                viewModel.NursingTargetDefinitions = GetNursingTargetDefinitionListByProblemID(nursingCare.NursingProblem.ObjectID);

                if (!viewModel.ReadOnly)
                {
                    using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                    {
                        viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingCare);
                    }
                }
            }
            else
            {
                viewModel.NursingProblemDefinitions = NursingProblemDefinition.GetAllNursingProbDef(objectContext, " WHERE ISACTIVE = 1 ").ToArray();
            }

            if (nursingCare.ApplicationUser == null)
            {
                nursingCare.ApplicationUser = Common.CurrentResource;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public NursingCareDefinition[] GetNursingCareDefinitionListByProblemID(Guid ObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return NursingCareDefinition.GetNursingCareDefinitionByProblemID(objectContext, ObjectID.ToString()).ToArray();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public NursingReasonDefinition[] GetNursingReasonDefinitionByProblemID(Guid ObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return NursingReasonDefinition.GetNursingReasonDefinitionByProblemID(objectContext, ObjectID.ToString()).ToArray();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public NursingTargetDefinition[] GetNursingTargetDefinitionListByProblemID(Guid ObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return NursingTargetDefinition.GetNursingTargetDefinitionByProblemID(objectContext, ObjectID.ToString()).ToArray();
            }
        }

        
        //[HttpGet]
        //[AtlasRequiredRoles(TTRoleNames.Everyone)]
        //public NursingTargetDefinition[] GetNursingTargetDefinitionListByCareID(Guid ObjectID)
        //{
        //    using (var objectContext = new TTObjectContext(false))
        //    {
        //        return NursingTargetDefinition.GetNursingTargetDefinitionByCareID(objectContext, ObjectID).ToArray();
        //    }
        //}

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public NursingDefinitionListsByProblemID GetNursingDefinitionListsByProblemID(Guid ObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                NursingDefinitionListsByProblemID nursingDefListsByProblemID = new NursingDefinitionListsByProblemID();
                nursingDefListsByProblemID.nursingCareDefinitionList = NursingCareDefinition.GetNursingCareDefinitionByProblemID(objectContext, ObjectID.ToString()).ToArray();
                nursingDefListsByProblemID.nursingReasonDefinitionList = NursingReasonDefinition.GetNursingReasonDefinitionByProblemID(objectContext, ObjectID.ToString()).ToArray();
                nursingDefListsByProblemID.nursingTargetDefinitionList = NursingTargetDefinition.GetNursingTargetDefinitionByProblemID(objectContext, ObjectID.ToString()).ToArray();
                

                return nursingDefListsByProblemID;
            }
        }



    }
}

namespace Core.Models
{
    public partial class NursingCareMainFormViewModel
    {
        //List<NursingProblemDefinition> nursingProblemDefinitionList = new List<NursingProblemDefinition>();
        //List<NursingCareDefinition> nursingCareDefinitionList = new List<NursingCareDefinition>();
        //List<NursingTargetDefinition> nursingTargetDefinitionList = new List<NursingTargetDefinition>();
        //List<NursingReasonDefinition> nursingReasonDefinitionList = new List<NursingReasonDefinition>();
    }

    public class NursingDefinitionListsByProblemID
    {
        public NursingCareDefinition[] nursingCareDefinitionList = new List<NursingCareDefinition>().ToArray();
        public NursingTargetDefinition[] nursingTargetDefinitionList = new List<NursingTargetDefinition>().ToArray();
        public NursingReasonDefinition[] nursingReasonDefinitionList = new List<NursingReasonDefinition>().ToArray();
    }
}