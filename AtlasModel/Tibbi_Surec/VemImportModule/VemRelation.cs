using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class VemRelation
    {
        public Guid ObjectId { get; set; }
        public string VemTableName { get; set; }
        public Guid? HvlObjectID { get; set; }
        public string VemObjectID { get; set; }
        public int? VemID { get; set; }
    }
}