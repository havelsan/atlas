using System;
using System.Collections.Generic;
using TTDataDictionary;
using TTObjectClasses;

namespace Core.Models
{
    public class CommisionDefinitionViewModel
    {

    }

    public class CommisionDefinitionInitiDataSource
    {
        public List<CommisionDefinitionDataSource> CommisionDefinitionDataSources { get; set; }
        public List<ResUserDataSource> ResUserDataSources { get; set; }
    }

    public class CommisionDefinitionDataSource
    {
        public Guid ObjectID { get; set; }
        public string Description { get; set; }
        public CommisionTypeEnum CommisionType { get; set; }
        public bool IsActive { get; set; }
    }

    public class CommisionDefinitionInputDTO
    {
        public bool isNew { get; set; }
        public Guid ObjectID { get; set; }
        public CommisionTypeEnum CommisionType { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public List<CommisionMemberDTO> CommisionMembers { get; set; }
    }

    public class CommisionMemberDTO
    {
        public Guid ObjectID { get; set; }
        public SignUserTypeEnum SignUserType { get; set; }
        public Guid ReUserObjectID { get; set; }
        public string ResUserName { get; set; }
        public ResUser ResUser { get; set; }
    }

    public class ResUserDataSource
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
    }
}
