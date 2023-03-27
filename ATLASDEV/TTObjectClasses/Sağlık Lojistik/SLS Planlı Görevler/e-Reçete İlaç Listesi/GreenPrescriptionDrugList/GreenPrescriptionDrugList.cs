
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Yeşil  Reçete İlaç Listesi
    /// </summary>
    public  partial class GreenPrescriptionDrugList : BaseScheduledTask
    {
#region Methods
        [Serializable]
        public class DrugListWebCaller : IWebMethodCallback
        {
            private Guid _objectID;
            public Guid ObjectID
            {
                get { return _objectID; }
                set { _objectID = value; }
            }

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {

                if (messageException == null && returnValue != null)
                {
                    if (returnValue is YardimciIslemler.ilacListesiSorguCevapDVO)
                    {
                        if (((YardimciIslemler.ilacListesiSorguCevapDVO)returnValue).sonucKodu.Equals("0"))
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            YardimciIslemler.ilacListesiSorguCevapDVO responseList = new YardimciIslemler.ilacListesiSorguCevapDVO();
                            responseList.ilacListesi = ((YardimciIslemler.ilacListesiSorguCevapDVO)returnValue).ilacListesi;
                            responseList.sonucMesaji = ((YardimciIslemler.ilacListesiSorguCevapDVO)returnValue).sonucMesaji;
                            responseList.uyariMesaji = ((YardimciIslemler.ilacListesiSorguCevapDVO)returnValue).uyariMesaji;
                            context.Save();

                        }
                        else
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            YardimciIslemler.ilacListesiSorguCevapDVO responseList = new YardimciIslemler.ilacListesiSorguCevapDVO();
                            responseList.ilacListesi = null;
                            responseList.sonucMesaji = ((YardimciIslemler.ilacListesiSorguCevapDVO)returnValue).sonucMesaji;
                            responseList.uyariMesaji = ((YardimciIslemler.ilacListesiSorguCevapDVO)returnValue).uyariMesaji;
                            context.Save();
                        }
                    }

                }
                return false;
            }

            public TTObjectContext ObjectContext { get { return new TTObjectContext(false); } }
        }

        public override void TaskScript()
        {
            int count = 0;
            string filename = string.Empty;

            if (string.IsNullOrEmpty(FilePath) == true)
                throw new TTException(TTUtils.CultureService.GetText("M26064", "İlaç Listesini Alabilmek İçin Dosya Yolunu Seçmelisiniz"));
            else
                filename = System.IO.Path.Combine(FilePath, "YESILRECETEILACLAR.txt");

            try
            {
                GreenPrescriptionDrugList.DrugListWebCaller callerObject = new GreenPrescriptionDrugList.DrugListWebCaller();
                callerObject.ObjectID = ObjectID;
                YardimciIslemler.ilacListesiSorguIstekDVO request = new YardimciIslemler.ilacListesiSorguIstekDVO();
                request.doktorTcKimlikNo = Convert.ToInt64(TTObjectClasses.SystemParameter.GetParameterValue("MEDULADOKTORKIMLIKNO", "10000000000"));
                request.tesisKodu = SystemParameter.GetSaglikTesisKodu(); ;
                request.islemTarihi = System.DateTime.Now.ToString("dd.MM.yyyy");

                YardimciIslemler.ilacListesiSorguCevapDVO responseGreenPrescriptionDrugList = YardimciIslemler.WebMethods.yesilReceteIlacListesiSorgulaSync(Sites.SiteLocalHost, request);
                if (responseGreenPrescriptionDrugList.sonucKodu == "0000")
                {
                    if (responseGreenPrescriptionDrugList.ilacListesi != null)
                    {
                        string s = "";
                        foreach (YardimciIslemler.ilacDVO item in responseGreenPrescriptionDrugList.ilacListesi)
                        {
                            count++;
                            if (count == 1)
                            {
                                if (string.IsNullOrEmpty(filename) == false)
                                {
                                    System.IO.File.Delete(filename);
                                }
                                s = System.DateTime.Now.ToShortDateString() + "\r\n";
                            }
                            TTObjectContext context = new TTObjectContext(true);
                            IBindingList list = context.QueryObjects(typeof(DrugDefinition).Name, "BARCODE = '" + item.barkod.ToString() + "'");
                            if (list.Count == 0)
                                s += TTUtils.CultureService.GetText("M27238", "Yeni ilaç = \t")+ item.barkod + "\t" + item.ilacAdi + "\r\n";
                            else
                            {
                                DrugDefinition drug = (DrugDefinition)list[0];
                                if (item.ilacAdi != drug.Name)
                                    s += "Farklı adlı ilaç = \t" + item.barkod + "\t" + item.ilacAdi + "\t" + drug.Name + "\r\n";
                            }
                        }
                        TTUtils.Globals.Write2Log(s, filename);
                        AddLog(TTUtils.CultureService.GetText("M27251", "Yeşil Reçete İlaçları aktarıldı."));
                    }
                }
                else
                    throw new Exception(responseGreenPrescriptionDrugList.sonucMesaji);

            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }

        public override void AddLog(string log)
        {
            base.AddLog(log);
        }
        
#endregion Methods

    }
}