using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class UserResourceSelectionController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public UserResourceSelectionModel UserResourceSelectionView(Guid? id)
        {
            var viewModel = new UserResourceSelectionModel();
            using (var objectContext = new TTObjectContext(false))
            {
                if (Common.CurrentResource.UserResources.Count == 0)
                {
                    throw new Exception(SystemMessage.GetMessageV2(347, TTUtils.CultureService.GetText("M26351", "Kullanıcının bağlı olduğu birim bulunamadı!")));
                }
                else
                {
                    //if (Common.CurrentResource.SelectedResources.Count == 0)
                    Common.CurrentResource.FillUserResources();
                    viewModel.OutPatientResourceList = new List<Resource>();
                    viewModel.QueueList = new List<ExaminationQueueDefinition>();
                    viewModel.InPatientResourceList = new List<Resource>();
                    viewModel.SecMasterResourceList = new List<Resource>();
                    viewModel.OutPatientResourceList = Common.CurrentResource.OutPatientUserResources;
                    viewModel.InPatientResourceList = Common.CurrentResource.InPatientUserResources;
                    viewModel.SecMasterResourceList = Common.CurrentResource.SecMasterUserResources;
                    if (Common.CurrentResource.SelectedResources.Count > 0)
                    {
                        viewModel.SelectedOutPatientResource = Common.CurrentResource.SelectedOutPatientResource;
                        viewModel.SelectedInPatientResource = Common.CurrentResource.SelectedInPatientResource;
                        viewModel.SelectedSecMasterResource = Common.CurrentResource.SelectedSecMasterResource;
                    }
                    else
                    {
                        if (Common.CurrentResource.OutPatientUserResources.Count > 0)
                            viewModel.SelectedOutPatientResource = Common.CurrentResource.OutPatientUserResources[0] as ResSection;
                        if (Common.CurrentResource.InPatientUserResources.Count > 0)
                            viewModel.SelectedInPatientResource = Common.CurrentResource.InPatientUserResources[0] as ResSection;
                        if (Common.CurrentResource.SecMasterUserResources.Count > 0)
                            viewModel.SelectedSecMasterResource = Common.CurrentResource.SecMasterUserResources[0] as ResSection;
                    }

                    //ContextToViewModel(viewModel, objectContext);
                    //PreScript_UserResourceSelectionView(viewModel, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        void ContextToViewModel(UserResourceSelectionModel viewModel, TTObjectContext objectContext)
        {
            viewModel.OutPatientResourceList = objectContext.LocalQuery<Resource>().ToList();
            viewModel.QueueList = objectContext.LocalQuery<ExaminationQueueDefinition>().ToList();
            viewModel.InPatientResourceList = objectContext.LocalQuery<Resource>().ToList();
            viewModel.SecMasterResourceList = objectContext.LocalQuery<Resource>().ToList();
        }

        void PreScript_UserResourceSelectionView(UserResourceSelectionModel viewModel, TTObjectContext objectContext)
        {

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void UpdateSelectedUserResources(UserResourceSelectionModel viewModel)
        {
            if (viewModel != null)
            {
                if (viewModel.SelectedOutPatientResource != null)
                    Common.CurrentResource.SelectedOutPatientResource = viewModel.SelectedOutPatientResource as ResSection;
                if (viewModel.SelectedOutPatientResource != null)
                    Common.CurrentResource.SelectedQueue = viewModel.SelectedQueue as ExaminationQueueDefinition;
                if (viewModel.SelectedInPatientResource != null)
                    Common.CurrentResource.SelectedInPatientResource = viewModel.SelectedInPatientResource as ResSection;
                if (viewModel.SelectedSecMasterResource != null)
                    Common.CurrentResource.SelectedSecMasterResource = viewModel.SelectedSecMasterResource as ResSection;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public UserResourceSelectionModel setIfSingleUserResources()
        {
            var viewModel = new UserResourceSelectionModel();
            viewModel.OutPatientResourceList = new List<Resource>();
            viewModel.QueueList = new List<ExaminationQueueDefinition>();
            viewModel.InPatientResourceList = new List<Resource>();
            viewModel.SecMasterResourceList = new List<Resource>();
            viewModel.SelectedOutPatientResource = null;
            viewModel.SelectedQueue = null;
            viewModel.SelectedInPatientResource = null;
            viewModel.SelectedSecMasterResource = null;

            Common.CurrentResource.FillUserResources();
            viewModel.OutPatientResourceList = new List<Resource>();
            viewModel.QueueList = new List<ExaminationQueueDefinition>();
            viewModel.InPatientResourceList = new List<Resource>();
            viewModel.SecMasterResourceList = new List<Resource>();
            viewModel.OutPatientResourceList = Common.CurrentResource.OutPatientUserResources;
            viewModel.InPatientResourceList = Common.CurrentResource.InPatientUserResources;
            viewModel.SecMasterResourceList = Common.CurrentResource.SecMasterUserResources;
            if (viewModel.OutPatientResourceList.Count > 1 || viewModel.InPatientResourceList.Count > 1)
                return viewModel;
            if (Common.CurrentResource.OutPatientUserResources.Count == 1)
                viewModel.SelectedOutPatientResource = Common.CurrentResource.OutPatientUserResources[0] as ResSection;
            if (Common.CurrentResource.InPatientUserResources.Count == 1)
                viewModel.SelectedInPatientResource = Common.CurrentResource.InPatientUserResources[0] as ResSection;
            if (Common.CurrentResource.SecMasterUserResources.Count == 1)
                viewModel.SelectedSecMasterResource = Common.CurrentResource.SecMasterUserResources[0] as ResSection;
            if (viewModel.SelectedOutPatientResource != null)
            {
                CommonServiceController commonService = new CommonServiceController();
                CommonServiceController.GetSortedQueueItemsByArray_Input input = new CommonServiceController.GetSortedQueueItemsByArray_Input();
                input.currentResUserID = Common.CurrentResource.ObjectID;
                input.outPatientResID = Common.CurrentResource.SelectedOutPatientResource.ObjectID;
                input.includeCalleds = false;
                BindingList<ExaminationQueueDefinition> queueList = commonService.GetQueueDefinition(input);
                viewModel.QueueList = queueList.ToList();
                if (queueList.Count == 1)
                    viewModel.SelectedQueue = queueList[0];
            }

            return viewModel;
        }

    }
}
