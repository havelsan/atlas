//$3FD1C76C
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public partial class MemberOfHealthCommitteeDefinitionServiceController
    {
        partial void PreScript_MemberOfHealthCommitteeDefinitionForm(MemberOfHealthCommitteeDefinitionFormViewModel viewModel, MemberOfHealthCommitteeDefinition memberOfHealthCommitteeDefinition, TTObjectContext objectContext)
        {
            #region Saðlýk Kurulu
            viewModel.DoctorList = ResUser.GetAllUser(objectContext, " WHERE USERTYPE IN (0,2,3) AND ISACTIVE=1 ").ToArray(); ;
            viewModel.ResSectionList = ResPoliclinic.GetAllActivePoliclinic(objectContext).ToArray();

            #endregion
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ResSection[] GetResSectionsByDoctor(string DoctorID = null)
        {
            using (var objectContext=new TTObjectContext(false))
            {
                List<ResSection> list = new List<ResSection>();

                ResUser pDoctor = objectContext.GetObject(new Guid(DoctorID), typeof(ResUser)) as ResUser;

                foreach (ResSection sect in pDoctor.SelectedResources)
                {
                    if(list.Any(x=> x.ObjectID == sect.ObjectID) == false)
                        list.Add(sect);
                }
                objectContext.FullPartialllyLoadedObjects();
                return list.ToArray();
            }

        }
    }
}

namespace Core.Models
{
    public partial class MemberOfHealthCommitteeDefinitionFormViewModel: BaseViewModel
    {
        public ResSection[] ResSectionList
        {
            get;
            set;
        }

        public ResUser[] DoctorList
        {
            get;
            set;
        }
    }
}
