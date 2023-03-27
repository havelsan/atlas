using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportClasses.Controllers.ReportModels;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Modules.Medical.Yatan_Hasta_Rapor
{
    public class YemekCikanHastaListesi
    {
        public static List<YemekCikanHastaListesiData> GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<List<YemekCikanHastaListesiData>>(parameters, "GetYemekCikanHastaListesiData");
        }

        public static List<YemekCikanHastaListesiData> GetYemekCikanHastaListesiData(string parameters)
        {
            List<YemekCikanHastaListesiData> returnData = new List<YemekCikanHastaListesiData>();
            if (parameters == null)
            {
                YemekCikanHastaListesiParam aa = new YemekCikanHastaListesiParam();
                //aa.AllClinics = true;
                //aa.SelectedClinicList = new List<string>();
                //aa.BaslangicTarihi = DateTime.Now;
                //aa.BitisTarihi = DateTime.Now.AddDays(-50);

                parameters = Newtonsoft.Json.JsonConvert.SerializeObject(aa);
            }

            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false)) //RTF alanların texti nqlde alınamadığı için eklendi.
                {
                    var param = Newtonsoft.Json.JsonConvert.DeserializeObject<YemekCikanHastaListesiParam>(parameters.ToString());
                    string filter = "";

                    if (param.OgunListesi != null && param.OgunListesi.Count > 0)
                    {
                        filter += " AND (1 = 0  ";

                        foreach (int kod in param.OgunListesi)
                        {
                            if (kod == 1)
                                filter += " OR THIS.MealType.Breakfast = 1 ";
                            else if (kod == 2)
                                filter += " OR THIS.MealType.Lunch = 1 ";
                            else if (kod == 3)
                                filter += " OR THIS.MealType.Dinner = 1 ";
                            else if (kod == 4)
                                filter += " OR THIS.MealType.NightBreakfast = 1 ";
                            else if (kod == 5)
                                filter += " OR THIS.MealType.Snack1 = 1 ";
                            else if (kod == 6)
                                filter += " OR THIS.MealType.Snack2 = 1 ";
                            else if (kod == 7)
                                filter += " OR THIS.MealType.Snack3 = 1 ";
                        }


                        filter += " )";
                    }

                    BindingList<DietOrderDetail.GetInpatientDietList_Class> dietList = DietOrderDetail.GetInpatientDietList(param.BaslangicTarihi.Date, param.BitisTarihi.Date, filter);
                    if (dietList.Count > 0)
                    {
                        foreach (DietOrderDetail.GetInpatientDietList_Class item in dietList)
                        {
                            YemekCikanHastaListesiData yatakListesiRaporData = new YemekCikanHastaListesiData();

                            yatakListesiRaporData.ObjectID = item.ObjectID.Value;
                            yatakListesiRaporData.Yatak = item.Yatak;
                            yatakListesiRaporData.Oda = item.Oda;
                            yatakListesiRaporData.OdaGrup = item.Odagrup;
                            yatakListesiRaporData.Klinik = item.Servis;
                            yatakListesiRaporData.HastaAdi = item.Hastaadi + ' ' + item.Hastasoyadi;
                            yatakListesiRaporData.DiyetTuru = item.Diyetturu;
                            yatakListesiRaporData.Kahvalti = !item.Kahvalti.HasValue ? false : item.Kahvalti.Value;
                            yatakListesiRaporData.Oglen = !item.Oglen.HasValue ? false : item.Oglen.Value;
                            yatakListesiRaporData.Aksam = !item.Aksam.HasValue ? false : item.Aksam.Value;
                            yatakListesiRaporData.GeceKahvaltisi = !item.Gecekahvalti.HasValue ? false : item.Gecekahvalti.Value;
                            yatakListesiRaporData.AraOgun1 = !item.Araogun1.HasValue ? false : item.Araogun1.Value;
                            yatakListesiRaporData.AraOgun2 = !item.Araogun2.HasValue ? false : item.Araogun2.Value;
                            yatakListesiRaporData.AraOgun3 = !item.Araogun3.HasValue ? false : item.Araogun3.Value;

                            returnData.Add(yatakListesiRaporData);
                        }

                    }
                }

            }
            return returnData;
        }
    }

    [Serializable]
    public class YemekCikanHastaListesiParam
    {
        [DataMember]
        public DateTime BaslangicTarihi { get; set; }
        [DataMember]
        public DateTime BitisTarihi { get; set; }
        [DataMember]
        public List<int> OgunListesi { get; set; }

    }

    [Serializable]
    public class YemekCikanHastaListesiData
    {
        [DataMember]
        public Guid ObjectID { get; set; }
        [DataMember]
        public string Yatak { get; set; }
        [DataMember]
        public string Oda { get; set; }
        [DataMember]
        public string OdaGrup { get; set; }
        [DataMember]
        public string Klinik { get; set; }
        //public Guid KlinikID { get; set; }
        [DataMember]
        public string HastaAdi { get; set; }
        [DataMember]
        public string DiyetTuru { get; set; }
        [DataMember]
        public bool Kahvalti { get; set; }
        [DataMember]
        public bool Oglen { get; set; }
        [DataMember]
        public bool Aksam { get; set; }
        [DataMember]
        public bool GeceKahvaltisi { get; set; }
        [DataMember]
        public bool AraOgun1 { get; set; }
        [DataMember]
        public bool AraOgun2 { get; set; }
        [DataMember]
        public bool AraOgun3 { get; set; }

    }

}
