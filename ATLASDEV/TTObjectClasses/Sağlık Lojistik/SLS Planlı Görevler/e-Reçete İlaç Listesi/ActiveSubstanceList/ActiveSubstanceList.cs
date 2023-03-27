
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
    /// Etkin Madde Listesi
    /// </summary>
    public  partial class ActiveSubstanceList : BaseScheduledTask
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
                    if (returnValue is YardimciIslemler.etkinMaddeListesiSorguCevapDVO)
                    {
                        if (((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).sonucKodu.Equals("0"))
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            YardimciIslemler.etkinMaddeListesiSorguCevapDVO responseList =new YardimciIslemler.etkinMaddeListesiSorguCevapDVO();
                            responseList.etkinMaddeListesi = ((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).etkinMaddeListesi;
                            responseList.sonucMesaji=((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).sonucMesaji;
                            responseList.uyariMesaji = ((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).uyariMesaji;
                            context.Save();

                        }
                        else
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            YardimciIslemler.etkinMaddeListesiSorguCevapDVO responseList = new YardimciIslemler.etkinMaddeListesiSorguCevapDVO();
                            responseList.etkinMaddeListesi = null;
                            responseList.sonucMesaji = ((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).sonucMesaji;
                            responseList.uyariMesaji = ((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)returnValue).uyariMesaji;
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
            TTObjectContext objectContextReadOnly = new TTObjectContext(true);
            int count = 0;
            string filename = string.Empty;
            if (string.IsNullOrEmpty(FilePath))
            {
                throw new TTException(TTUtils.CultureService.GetText("M25619", "Etkin Madde Listesini Alabilmek İçin Dosya Yolunu Seçmelisiniz"));
            }
            try
            {
                ActiveSubstanceList.DrugListWebCaller callerObject = new ActiveSubstanceList.DrugListWebCaller();
                callerObject.ObjectID = ObjectID;
                YardimciIslemler.etkinMaddeListesiSorguIstekDVO request = new YardimciIslemler.etkinMaddeListesiSorguIstekDVO();
                 request.doktorTcKimlikNo=Convert.ToInt64(TTObjectClasses.SystemParameter.GetParameterValue("MEDULADOKTORKIMLIKNO", "0"));
                request.tesisKodu = SystemParameter.GetSaglikTesisKodu();

                TTMessage responseActiveSubstanceList = YardimciIslemler.WebMethods.etkinMaddeListesiSorgula(Sites.SiteLocalHost, callerObject, request);
                if(responseActiveSubstanceList.ReturnValue!=null)
                {
                    foreach (YardimciIslemler.etkinMaddeDVO item in ((YardimciIslemler.etkinMaddeListesiSorguCevapDVO)responseActiveSubstanceList.ReturnValue).etkinMaddeListesi)
                    {
                        IList reportDiagnosticList = objectContextReadOnly.QueryObjects("ETKINMADDE", "ETKINMADDEKODU='" + item.kodu + "' ");
                        if (reportDiagnosticList.Count < 1)
                        {
                            count++;
                            if (count == 1)
                            {
                                if (string.IsNullOrEmpty(filename))
                                {
                                    filename = FilePath;
                                    System.IO.StreamWriter _file = System.IO.File.CreateText(filename);
                                }

                            }
                            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.Open(filename, System.IO.FileMode.Append), Encoding.UTF8))
                            {
                                if (count == 1)
                                {
                                    sw.WriteLine(TTUtils.CultureService.GetText("M25618", "Etkin Madde Listesi"));
                                    sw.WriteLine("\r\n");
                                }
                                sw.WriteLine(item.kodu + "  " + item.adi + "  " + item.icerikMiktari);
                                sw.WriteLine("\r\n");
                                sw.Close();
                            }
                        }
                        objectContextReadOnly.Dispose();
                    }
                }
                
                
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