using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class OperationStatus
    {
        public string CustomMessage
        {
            get;
            set;
        }

        public bool Status = false;
        public string ErrorMessage
        {
            get;
            set;
        }

        public OperationStatus()
        {
        }
    }
}