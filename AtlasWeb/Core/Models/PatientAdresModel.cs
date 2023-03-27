using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class PatientAdresModel
    {
        public int Id
        {
            get;
            set;
        }

        public int PatientId
        {
            get;
            set;
        }

        public string AcikAdres
        {
            get;
            set;
        }

        public int IlId
        {
            get;
            set;
        }

        public int IlceId
        {
            get;
            set;
        }
    }
}