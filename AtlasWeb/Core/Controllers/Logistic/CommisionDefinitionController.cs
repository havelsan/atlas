using Core.Models;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class CommisionDefinitionController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public CommisionDefinitionInitiDataSource getAllCommisionDefinition()
        {
            CommisionDefinitionInitiDataSource output = new CommisionDefinitionInitiDataSource();
            output.CommisionDefinitionDataSources = new List<CommisionDefinitionDataSource>();
            output.ResUserDataSources = new List<ResUserDataSource>();
            BindingList<CommisionDefinition.GetAllCommisionDefinition_Class> getAllCommisions = CommisionDefinition.GetAllCommisionDefinition(string.Empty);
            foreach (CommisionDefinition.GetAllCommisionDefinition_Class commision in getAllCommisions)
            {
                CommisionDefinitionDataSource item = new CommisionDefinitionDataSource();
                item.ObjectID = commision.ObjectID.Value;
                item.Description = commision.Description;
                item.CommisionType = commision.CommisionType.Value;
                if (commision.IsActive.HasValue)
                    item.IsActive = commision.IsActive.Value;
                else
                    item.IsActive = false;
                output.CommisionDefinitionDataSources.Add(item);
            }
            BindingList<ResUser.GetAllUserReportNQL_Class> users = ResUser.GetAllUserReportNQL("ORDER BY NAME");
            foreach (ResUser.GetAllUserReportNQL_Class user in users)
            {
                ResUserDataSource userItem = new ResUserDataSource();
                userItem.ObjectID = user.ObjectID.Value;
                userItem.Name = user.Name;
                output.ResUserDataSources.Add(userItem);
            }
            return output;
        }

        public class GetCommisionDefinition_Input
        {
            public Guid ObjectID { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public CommisionDefinitionInputDTO getCommisionDefinition(GetCommisionDefinition_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                CommisionDefinition commisionDefinition = (CommisionDefinition)objectContext.GetObject(input.ObjectID, typeof(CommisionDefinition));
                CommisionDefinitionInputDTO output = new CommisionDefinitionInputDTO();
                output.isNew = false;
                output.CommisionType = commisionDefinition.CommisionType.Value;
                output.Description = commisionDefinition.Description;
                output.EndDate = commisionDefinition.EndDate;
                output.IsActive = commisionDefinition.IsActive.Value;
                output.ObjectID = commisionDefinition.ObjectID;
                output.StartDate = commisionDefinition.StartDate;
                output.CommisionMembers = new List<CommisionMemberDTO>();
                foreach (CommisionDefinitionMember member in commisionDefinition.CommisionDefinitionMembers)
                {
                    CommisionMemberDTO commision = new CommisionMemberDTO();
                    commision.ObjectID = member.ObjectID;
                    commision.SignUserType = member.SignUserType.Value;
                    commision.ReUserObjectID = member.ResUser.ObjectID;
                    output.CommisionMembers.Add(commision);
                }

                return output;
            }
        }

        public class GetCommisionDefinitionByCommisionType_Input
        {
            public CommisionTypeEnum CommisionType { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<CommisionDefinitionInputDTO> getCommisionDefinitionByCommisionType(GetCommisionDefinitionByCommisionType_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                List<CommisionDefinitionInputDTO> output = new List<CommisionDefinitionInputDTO>();
                IBindingList getCommisions = objectContext.QueryObjects("COMMISIONDEFINITION", "COMMISIONTYPE = " + ((int)input.CommisionType).ToString() + " AND ISACTIVE= 1");

                foreach (CommisionDefinition commision in getCommisions)
                {
                    CommisionDefinitionInputDTO item = new CommisionDefinitionInputDTO();
                    item.ObjectID = commision.ObjectID;
                    item.Description = commision.Description;
                    item.CommisionType = commision.CommisionType.Value;
                    item.StartDate = commision.StartDate;
                    item.EndDate = commision.EndDate;
                    if (commision.IsActive.HasValue)
                        item.IsActive = commision.IsActive.Value;
                    else
                        item.IsActive = false;
                    item.CommisionMembers = new List<CommisionMemberDTO>();
                    foreach (CommisionDefinitionMember member in commision.CommisionDefinitionMembers)
                    {
                        CommisionMemberDTO memberDTO = new CommisionMemberDTO();
                        memberDTO.ObjectID = member.ObjectID;
                        memberDTO.ReUserObjectID = member.ResUser.ObjectID;
                        memberDTO.SignUserType = member.SignUserType.Value;
                        memberDTO.ResUserName = member.ResUser.Name;
                        memberDTO.ResUser = member.ResUser;
                        item.CommisionMembers.Add(memberDTO);
                    }
                    output.Add(item);
                    objectContext.FullPartialllyLoadedObjects();
                }
                return output;
            }
        }


        [HttpPost]
        public string saveObject(CommisionDefinitionInputDTO input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                CommisionDefinition commisionDefinition = null;
                if (input.isNew == true)
                {
                    commisionDefinition = new CommisionDefinition(objectContext);
                    foreach (CommisionMemberDTO memberDTO in input.CommisionMembers)
                    {
                        CommisionDefinitionMember member = new CommisionDefinitionMember(objectContext);
                        member.CommisionDefinition = commisionDefinition;
                        ResUser resUser = (ResUser)objectContext.GetObject(memberDTO.ReUserObjectID, typeof(ResUser));
                        member.ResUser = resUser;
                        member.SignUserType = memberDTO.SignUserType;
                    }

                }
                else
                {
                    commisionDefinition = objectContext.GetObject<CommisionDefinition>(input.ObjectID);
                    foreach (CommisionDefinitionMember member in commisionDefinition.CommisionDefinitionMembers)
                    {
                        CommisionMemberDTO findDTO = input.CommisionMembers.Where(x => x.ObjectID == member.ObjectID).FirstOrDefault();
                        ResUser resUser = (ResUser)objectContext.GetObject(findDTO.ReUserObjectID, typeof(ResUser));
                        member.ResUser = resUser;
                        member.SignUserType = findDTO.SignUserType;
                    }
                }
                commisionDefinition.Description = input.Description;
                commisionDefinition.CommisionType = input.CommisionType;
                commisionDefinition.EndDate = input.EndDate;
                commisionDefinition.IsActive = input.IsActive;
                commisionDefinition.StartDate = input.StartDate;
                
                objectContext.Save();
                objectContext.Dispose();
                return "Kayıt İşlemi Yapılmıştır";
            }
            catch
            {
                return "Kayıt İşlemi Sırasında Hata Alınmıştır..";
            }
        }
    }
}
