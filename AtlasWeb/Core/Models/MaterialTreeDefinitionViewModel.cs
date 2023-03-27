using System;
using System.Collections.Generic;
using TTDataDictionary;

namespace Core.Models
{
    public class MaterialTreeDefinitionViewModel
    {

    }

    public class MaterialTreeDefinitionDataSource
    {
        public List<MaterialTreeDef> materialTreeDefs { get; set; }
        public List<ParentMaterialTreeDef> parentMaterialTreeDefs { get; set; }
    }

    public class MaterialTreeDef
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ParentMaterialTreeDef ParentMaterialTree { get; set; }
        public bool IsGroup { get; set; }
    }

    public class ParentMaterialTreeDef
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class MaterialTreeInputDTO
    {
        public bool isNew { get; set; }
        public Guid ObjectID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? ParentMaterialTreeObjectId { get; set; }
        public bool IsGroup { get; set; }
    }
}
