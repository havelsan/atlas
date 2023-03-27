using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ENabizPackageDefinition
    {
        public Guid ObjectId { get; set; }
        public int? PackageID { get; set; }
        public string PackageName { get; set; }
    }
}