
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
    /// Geri ödeme kapsamında olan ilaç listesi
    /// </summary>
    public partial class DrugListTask : BaseScheduledTask
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
                        if (((YardimciIslemler.ilacListesiSorguCevapDVO)returnValue).sonucKodu == "0000")
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

            try
            {
                YardimciIslemler.ilacListesiSorguIstekDVO request = new YardimciIslemler.ilacListesiSorguIstekDVO();
                request.doktorTcKimlikNo = Convert.ToInt64(TTObjectClasses.SystemParameter.GetParameterValue("MEDULADOKTORKIMLIKNO", "10000000000"));
                request.tesisKodu = SystemParameter.GetSaglikTesisKodu(); 
                request.islemTarihi = System.DateTime.Now.ToString("dd.MM.yyyy");
                
                string userName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME", "XXXXXX");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD", "XXXXXX");

                YardimciIslemler.ilacListesiSorguCevapDVO responseActiveDrugList = YardimciIslemler.WebMethods.aktifIlacListesiSorgulaSync(Sites.SiteLocalHost, userName, password, request);

                if (responseActiveDrugList.sonucKodu == "0000")
                {
                    if (responseActiveDrugList.ilacListesi != null)
                    {
                        string s = "";
                        foreach (YardimciIslemler.ilacDVO item in responseActiveDrugList.ilacListesi)
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            IBindingList list = context.QueryObjects(typeof(DrugDefinition).Name, "BARCODE = '" + item.barkod.ToString() + "'");
                            if (list.Count > 0)
                            {
                                foreach (DrugDefinition drugDefinition in list)
                                {
                                    BindingList<EtkinMadde> etkinMaddeList = EtkinMadde.GetEtkinMaddeByCode(context, item.etkinMaddeKodu);
                                    if (etkinMaddeList.Count == 1)
                                    {
                                        if (drugDefinition.EtkinMadde == null)
                                        {
                                            drugDefinition.EtkinMadde = etkinMaddeList[0];
                                        }
                                        else {
                                            if (drugDefinition.EtkinMadde.ObjectID != etkinMaddeList[0].ObjectID)
                                                drugDefinition.EtkinMadde = etkinMaddeList[0];
                                        }
                                    }
                                    int y = Convert.ToInt32(item.yatanOdenmeSarti);
                                    drugDefinition.InpatientReportType = (DrugReportType)y;

                                    int a = Convert.ToInt32(item.ayaktanOdenmeSarti);
                                    drugDefinition.OutpatientReportType = (DrugReportType)a;
                                }
                                try
                                {
                                    context.Save();
                                }
                                catch (Exception)
                                {

                                }
                            }
                            context.Dispose();
                        }
                        AddLog("İlaç Etkin Madde ve Ayaktan / Yatan Ödeme şartları güncellendi.");
                    }
                }
                else
                    throw new Exception(responseActiveDrugList.sonucMesaji);

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