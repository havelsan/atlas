using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Models
{
    public class PatientRecordModel
    {
        public int Id
        {
            get;
            set;
        }

        public string Adi
        {
            get;
            set;
        }

        public string Soyadi
        {
            get;
            set;
        }

        public string KimlikNo
        {
            get;
            set;
        }

        public DateTime Dob
        {
            get;
            set;
        }

        public bool Yabanci
        {
            get;
            set;
        }

        public bool Varmi
        {
            get;
            set;
        }

        public string Mask
        {
            get;
            set;
        }

        public string[] Veri
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

        public string SeciliNesne
        {
            get;
            set;
        }

        public PatientAdresModel Adres
        {
            get;
            set;
        }

        public List<SelectListItem> Iller
        {
            get;
            set;
        }
    }
}