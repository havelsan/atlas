using System;

namespace AtlasModel.Enterprise
{
    public class TTAssemblyReferenceDef
    {
        public Guid AssemblyDefId { get; set; }
        public Guid ReferencedAssemblyDefId { get; set; }
        public int CheckOutStatus { get; set; }
    }
}
