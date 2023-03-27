using System;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTObjectClasses;

namespace Core.Models
{
    
    public class HasLaundryRolesModel
    {
        public bool hasLaundryMainFormRole { get; set; }
        public bool hasCleaningFormRole { get; set; }
        public bool hasLaundryDefinitionFormRole { get; set; }
        public bool hasLaundryStatusFormRole { get; set; }
        public HasLaundryRolesModel()
        {
            this.hasLaundryMainFormRole = false;
            this.hasCleaningFormRole = false;
            this.hasLaundryDefinitionFormRole = false;
            this.hasLaundryStatusFormRole = false; 
        }
    }

    public class LinenGroupModel
    {
        public Guid? ObjectID { get; set; }
        public string Name { get; set; }
        public string IntegrationCode { get; set; }
    }
    public class DeleteLinenDefinitionModel
    {
        public Guid? ObjectID { get; set; }
        public int Type { get; set; }
    }

    public class LinenLocationModel
    {
        public Guid? ObjectID { get; set; }
        public string Location { get; set; }
        public string MahalNo { get; set; }
        public string IntegrationCode { get; set; }
    }

    public class LinenTypeModel
    {
        public Guid? ObjectID { get; set; }
        public string Type { get; set; }
        public int? MaxWashingCount { get; set; }
        public Guid? LinenGroup { get; set; }
        public string IntegrationCode { get; set; }
    }


    public class LaundryStatusQueryModel
    {
        public Guid? Type { get; set; }
        public Guid? Group { get; set; }
        public Guid? Location { get; set; }
        public bool? ExpiredLinens { get; set; }
    }
    public class LaundryStatusResultModel
    {
        public Guid? Type { get; set; }
        public Guid? Group { get; set; }
        public Guid? Location { get; set; }
        public int TotalCount { get; set; }
        public int UsedCount { get; set; }
        public int ExpiredCount { get; set; }
        public int ExceededMWC { get; set; }
    }
    public class BedCleaningFormResultModel
    {
        public Guid? ObjectID { get; set; }
        public string ResSection { get; set; }
        public string RoomGroup { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public bool? IsClean { get; set; }
    }
}