
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
    /// Rapor Teşhis Listesi
    /// </summary>
    public  partial class ReportDiagnosticList : BaseScheduledTask
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
                    if (returnValue is YardimciIslemler.raporTeshisListesiSorguCevapDVO)
                    {
                        if (((YardimciIslemler.raporTeshisListesiSorguCevapDVO)returnValue).sonucKodu.Equals("0"))
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            YardimciIslemler.raporTeshisListesiSorguCevapDVO responseList =new YardimciIslemler.raporTeshisListesiSorguCevapDVO();
                            responseList.raporTeshisListesi = ((YardimciIslemler.raporTeshisListesiSorguCevapDVO)returnValue).raporTeshisListesi;
                            responseList.sonucMesaji=((YardimciIslemler.raporTeshisListesiSorguCevapDVO)returnValue).sonucMesaji;
                            responseList.uyariMesaji = ((YardimciIslemler.raporTeshisListesiSorguCevapDVO)returnValue).uyariMesaji;
                            context.Save();

                        }
                        else
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            YardimciIslemler.raporTeshisListesiSorguCevapDVO responseList = new YardimciIslemler.raporTeshisListesiSorguCevapDVO();
                            responseList.raporTeshisListesi = null;
                            responseList.sonucMesaji = ((YardimciIslemler.raporTeshisListesiSorguCevapDVO)returnValue).sonucMesaji;
                            responseList.uyariMesaji = ((YardimciIslemler.raporTeshisListesiSorguCevapDVO)returnValue).uyariMesaji;
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
                throw new TTException(TTUtils.CultureService.GetText("M26754", "Rapor Teşhis Listesini Alabilmek İçin Dosya Yolunu Seçmelisiniz"));
            }
            try
            {
                ReportDiagnosticList.DrugListWebCaller callerObject = new ReportDiagnosticList.DrugListWebCaller();
                callerObject.ObjectID = ObjectID;
                YardimciIslemler.raporTeshisListesiSorguIstekDVO request = new YardimciIslemler.raporTeshisListesiSorguIstekDVO();
                 request.doktorTcKimlikNo=Convert.ToInt64(TTObjectClasses.SystemParameter.GetParameterValue("MEDULADOKTORKIMLIKNO", "0"));
                request.tesisKodu = SystemParameter.GetSaglikTesisKodu();  

                TTMessage responseReportDiagnosticList = YardimciIslemler.WebMethods.raporTeshisListesiSorgula(Sites.SiteLocalHost,callerObject, request);
                if(responseReportDiagnosticList.ReturnValue!=null)
                {
                    foreach (YardimciIslemler.raporTeshisDVO item in ((YardimciIslemler.raporTeshisListesiSorguCevapDVO)responseReportDiagnosticList.ReturnValue).raporTeshisListesi)
                    {
                        IList reportDiagnosticList = objectContextReadOnly.QueryObjects("DIAGNOSISDEFINITION", "CODE='" + item.raporTeshisKodu + "' ");
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
                                    sw.WriteLine(TTUtils.CultureService.GetText("M26753", "Rapor Teşhis Listesi"));
                                    sw.WriteLine("\r\n");
                                }
                                sw.WriteLine(item.raporTeshisKodu + "  " + item.aciklama);
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