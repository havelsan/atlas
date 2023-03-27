using System;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTObjectClasses;
using Core.Models;

namespace Core.Models
{
    public class InvoiceSEPSearchResultFormModel
    {
        public InvoiceSEPResultGridForm InvoiceSEPResultList
        {
            get;
            set;
        }

        public InvoiceSEPSearchResultFormModel()
        {
            this.InvoiceSEPResultList = new InvoiceSEPResultGridForm();
        }
    }

    public class InvoiceSEPResultGridForm
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

        public string ProtocolNo
        {
            get;
            set;
        }

        public string MedulaBasvuruNo
        {
            get;
            set;
        }

        public Currency? MedulaFaturaTutari
        {
            get;
            set;
        }

        public Currency? Hbystutari
        {
            get;
            set;
        }

        public string MedulaTakipNo
        {
            get;
            set;
        }

        public string Baglitakipno
        {
            get;
            set;
        } //TODO:AAE Bağlı Takip ismi değişecek.

        public DateTime? MedulaProvizyonTarihi
        {
            get;
            set;
        }
        public DateTime? Inpatientdate
        {
            get;
            set;
        }
        public DateTime? Dischargedate
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

        public Guid? SubEpisode
        {
            get;
            set;
        }

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

        public long Id
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

        public string Izlemusername
        {
            get;
            set;
        }
        public string Icname
        {
            get;
            set;
        }
        public string Icno
        {
            get;
            set;
        }
        public string MedulaSonucKodu
        {
            get;
            set;
        }
        public string MedulaSonucMesaji
        {
            get;
            set;
        }
        public string Ressectionname
        {
            get;
            set;
        }
    }
}