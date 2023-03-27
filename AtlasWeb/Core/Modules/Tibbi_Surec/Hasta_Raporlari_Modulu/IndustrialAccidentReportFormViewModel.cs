using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class IndustrialAccidentReportFormViewModel
    {
        //Is Yeri Bilgileri
        public string IsYeriNo { get; set; }
        public string Unite { get; set; }
        public string IsYeriAdres { get; set; }
        public string IsYeriUnvan { get; set; }
        public string IsYeriIl { get; set; }

        //Sigortalı Bilgileri
        public string AdiSoyadi { get; set; }
        public string TCKimlikNo { get; set; }
        public string Gorevi { get; set; }
        public string Tel { get; set; }
        public string YaraninTuru { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Uyruk { get; set; }
        public string YaraninVucuttakiYeri { get; set; }
        public string Arac { get; set; }
        public DateTime? BildirimTarihi { get; set; }

        //Meslek Hastaligi
        public string CalisilanOrtam { get; set; }
        public string SaptanmaSekli { get; set; }
        public string MeslekHastaligiEtkeni { get; set; }
        public DateTime? TaniTarihi { get; set; }
        public string MeslekHastaligiEtkenSuresi { get; set; }
        public string IsGoremezlikSeviyesi { get; set; }
        public DateTime? BildirimTarihi2 { get; set; }

        public string SubepisodeID { get; set; }
        public bool IsNew { get; set; }
        public string ObjectID { get; set; }

    }


}
