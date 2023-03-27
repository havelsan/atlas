//$929AB790
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class MemberOfHealthCommitteeDefinitionServiceController : Controller
    {
        [HttpGet]
        public MemberOfHealthCommitteeDefinitionFormViewModel MemberOfHealthCommitteeDefinitionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return MemberOfHealthCommitteeDefinitionFormInternal(input);
        }

        [HttpPost]
        public MemberOfHealthCommitteeDefinitionFormViewModel MemberOfHealthCommitteeDefinitionFormLoad(FormLoadInput input)
        {
            return MemberOfHealthCommitteeDefinitionFormInternal(input);
        }

        [HttpGet]
        public MemberOfHealthCommitteeDefinitionFormViewModel MemberOfHealthCommitteeDefinitionFormInternal(FormLoadInput input)
        {
            Guid? id = input.Id;

            var formDefID = Guid.Parse("dbefdc93-b192-4485-82df-e63e9e61046d");
            var objectDefID = Guid.Parse("ae1e3373-0ed5-43b9-ba32-51a62e352455");
            var viewModel = new MemberOfHealthCommitteeDefinitionFormViewModel();
            viewModel.ActiveIDsModel = input.Model;

            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MemberOfHealthCommitteeDefinition = objectContext.GetObject(id.Value, objectDefID) as MemberOfHealthCommitteeDefinition;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MemberOfHealthCommitteeDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MemberOfHealthCommitteeDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MemberOfHealthCommitteeDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MemberOfHealthCommitteeDefinition);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_MemberOfHealthCommitteeDefinitionForm(viewModel, viewModel._MemberOfHealthCommitteeDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._MemberOfHealthCommitteeDefinition = new MemberOfHealthCommitteeDefinition(objectContext);
                    viewModel.MembersGridList = new TTObjectClasses.HealthCommitteMemberGrid[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MemberOfHealthCommitteeDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MemberOfHealthCommitteeDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MemberOfHealthCommitteeDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MemberOfHealthCommitteeDefinition);
                    PreScript_MemberOfHealthCommitteeDefinitionForm(viewModel, viewModel._MemberOfHealthCommitteeDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel MemberOfHealthCommitteeDefinitionForm(MemberOfHealthCommitteeDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return MemberOfHealthCommitteeDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel MemberOfHealthCommitteeDefinitionFormInternal(MemberOfHealthCommitteeDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("dbefdc93-b192-4485-82df-e63e9e61046d");
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.MembersGridList);
            objectContext.AddToRawObjectList(viewModel._MemberOfHealthCommitteeDefinition);
            objectContext.ProcessRawObjects();

            var memberOfHealthCommitteeDefinition = (MemberOfHealthCommitteeDefinition)objectContext.GetLoadedObject(viewModel._MemberOfHealthCommitteeDefinition.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(memberOfHealthCommitteeDefinition, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MemberOfHealthCommitteeDefinition, formDefID);

            if (viewModel.MembersGridList != null)
            {
                foreach (var item in viewModel.MembersGridList)
                {
                    var membersImported = (HealthCommitteMemberGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)membersImported).IsDeleted)
                        continue;
                    membersImported.MemberOfHealthCommitteeDef = memberOfHealthCommitteeDefinition;
                }
            }
            var transDef = memberOfHealthCommitteeDefinition.TransDef;
            PostScript_MemberOfHealthCommitteeDefinitionForm(viewModel, memberOfHealthCommitteeDefinition, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(memberOfHealthCommitteeDefinition);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(memberOfHealthCommitteeDefinition);
            AfterContextSaveScript_MemberOfHealthCommitteeDefinitionForm(viewModel, memberOfHealthCommitteeDefinition, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_MemberOfHealthCommitteeDefinitionForm(MemberOfHealthCommitteeDefinitionFormViewModel viewModel, MemberOfHealthCommitteeDefinition memberOfHealthCommitteeDefinition, TTObjectContext objectContext);
        partial void PostScript_MemberOfHealthCommitteeDefinitionForm(MemberOfHealthCommitteeDefinitionFormViewModel viewModel, MemberOfHealthCommitteeDefinition memberOfHealthCommitteeDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_MemberOfHealthCommitteeDefinitionForm(MemberOfHealthCommitteeDefinitionFormViewModel viewModel, MemberOfHealthCommitteeDefinition memberOfHealthCommitteeDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(MemberOfHealthCommitteeDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.MembersGridList = viewModel._MemberOfHealthCommitteeDefinition.Members.OfType<HealthCommitteMemberGrid>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorAndTechnicianList", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class MemberOfHealthCommitteeDefinitionFormViewModel
    {
        public TTObjectClasses.MemberOfHealthCommitteeDefinition _MemberOfHealthCommitteeDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.HealthCommitteMemberGrid[] MembersGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }
    }
}
