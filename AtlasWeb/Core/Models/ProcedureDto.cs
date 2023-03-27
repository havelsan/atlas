using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class ProcedureDto
    {
        public Guid ObjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class ProcedureList
    {
        public IEnumerable<ProcedureDto> Procedures { get; set; }
        public int TotalCount { get; set; }

        public ProcedureList()
        {

        }

        public ProcedureList(IEnumerable<ProcedureDto> procedures)
        {
            this.Procedures = procedures;
            this.TotalCount = procedures.Count();
        }
    }
}
