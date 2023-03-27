using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models.Medula
{
    public class GridData : BaseModel
    {
        public string one
        {
            get;
            set;
        }

        public string two
        {
            get;
            set;
        }

        public DateTime dateOfFilter
        {
            get;
            set;
        }
    }
}