using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;
using Core.Models;
using TTDataDictionary;

namespace Core.Models
{
    public class InvoiceEpisodeSearchResultFormModel
    {
        public InvoiceEpisodeResultGridForm InvoiceEpisodeResultList
        {
            get;
            set;
        }

        public InvoiceEpisodeSearchResultFormModel()
        {
            this.InvoiceEpisodeResultList = new InvoiceEpisodeResultGridForm();
        }
    }

    public class InvoiceEpisodeResultGridForm
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public Guid? Episode
        {
            get;
            set;
        }

        public string HospitalProtocolNo
        {
            get;
            set;
        }

        public Currency? FaturaTutari
        {
            get;
            set;
        }

        public Currency? HBYSTutari
        {
            get;
            set;
        }

        public DateTime? Date
        {
            get;
            set;
        }
        public DateTime? InPatientDate
        {
            get;
            set;
        }
        public DateTime? DischargeDate
        {
            get;
            set;
        }

        public string Patientname
        {
            get;
            set;
        }

        public string Patientsurname
        {
            get;
            set;
        }

        public string Specialityname
        {
            get;
            set;
        }

        public object Status
        {
            get;
            set;
        } //TODO: AAE Kontrol edilecek. 

        public string Tedavituru
        {
            get;
            set;
        }

        public long ? UniqueRefNo
        {
            get;
            set;
        }

        public string Payername
        {
            get;
            set;
        }

        public int ? PayetTypeEnum
        {
            get;
            set;
        }
        public string ICName
        {
            get;
            set;
        }
        public string ICNo
        {
            get;
            set;
        }
    }
}