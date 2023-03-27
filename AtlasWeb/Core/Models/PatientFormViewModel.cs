using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Models
{
    public class TedaviSekli
    {
        public long Id
        {
            get;
            set;
        }

        public string Tipi
        {
            get;
            set;
        }
    }

    public partial class PatientFormViewModel
    {
        public List<TedaviSekli> TedaviSekilleri
        {
            get;
            set;
        }

        public int ? YUPASSNO
        {
            get;
            set;
        }

        public double ? ForeignUniqueRefNo
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string FatherName
        {
            get;
            set;
        }

        public long[] UniqueRefNoMulti
        {
            get;
            set;
        }

        public long ? UniqueRefNo
        {
            get;
            set;
        }

        public SKRSDogumSirasi BirthOrder
        {
            get;
            set;
        }

        public Guid? Mother
        {
            get;
            set;
        }

        public bool IsNewBorn
        {
            get;
            set;
        }

        public Guid? TownOfBirth
        {
            get;
            set;
        }

        public Guid? CityOfBirth
        {
            get;
            set;
        }

        public BloodGroupEnum BloodGroup
        {
            get;
            set;
        }

        public MaritalStatusEnum MaritalStatus
        {
            get;
            set;
        }

        public bool BDYearOnly
        {
            get;
            set;
        }

        public SexEnum Sex
        {
            get;
            set;
        }

        public Guid? CountryOfBirth
        {
            get;
            set;
        }

        public bool UnIdentified
        {
            get;
            set;
        }

        public bool Foreign
        {
            get;
            set;
        }

        public Guid? TownOfRegistry
        {
            get;
            set;
        }

        public Guid? CityOfRegistry
        {
            get;
            set;
        }

        public bool NotRequiredQuota
        {
            get;
            set;
        }

        public bool IsRelativeOfSoldier
        {
            get;
            set;
        }

        public DateTime? BirthDate
        {
            get;
            set;
        }

        public DateTime? ExDate
        {
            get;
            set;
        }
    }
}