using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTObjectRelationDef
    {
        public Guid RelationDefId { get; set; }
        public string ParentName { get; set; }
        public string ChildrenName { get; set; }
        public string ParentCaption { get; set; }
        public string ChildCaption { get; set; }
        public Guid ParentObjectDefId { get; set; }
        public Guid ChildObjectDefId { get; set; }
        public Guid? OverridesRelationDefId { get; set; }
        public RelationCardinalityEnum Cardinality { get; set; }
        public bool IsParentRequired { get; set; }
        public bool IsEmbedded { get; set; }
        public bool IsProtected { get; set; }
        public bool IsDynamic { get; set; }
        public string SetParentScript { get; set; }
        public Guid? SortChildrenByPropertyId { get; set; }
        public short CheckOutStatus { get; set; }
        public string CacheTableName { get; set; }
        public short IsIndexed { get; set; }
        public bool IsNoLock { get; set; }
        public string Description { get; set; }
        public bool SortByDescending { get; set; }
    }
}