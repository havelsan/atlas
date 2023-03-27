
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
    public partial class EtkinMaddeTeshisEslestirme : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {
            string log = string.Empty;
            if(TTObjectClasses.SystemParameter.GetParameterValue("MEDULAETKENMADDEGUNCELLEMESI", "FALSE") == "TRUE")
            {
                try
                {
                    TTObjectContext objectContext = new TTObjectContext(false);

                    long doktorTC = Convert.ToInt64(TTObjectClasses.SystemParameter.GetParameterValue("MEDULADOKTORKIMLIKNO", "0"));
                    int tesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));

                    YardimciIslemler.etkinMaddeListesiSorguIstekDVO requestEtkinMadde = new YardimciIslemler.etkinMaddeListesiSorguIstekDVO();
                    //doktorTC = 10000000000;
                    //tesisKodu = 11069941;
                    requestEtkinMadde.doktorTcKimlikNo = doktorTC;
                    requestEtkinMadde.tesisKodu = tesisKodu;

                    YardimciIslemler.etkinMaddeListesiSorguCevapDVO raporEtkinMadde = YardimciIslemler.WebMethods.etkinMaddeListesiSorgulaSync(Sites.SiteLocalHost, requestEtkinMadde);
                    if (raporEtkinMadde != null && raporEtkinMadde.sonucKodu.Equals("0000") && raporEtkinMadde.etkinMaddeListesi != null)
                    {
                        var existActiveIngredients = EtkinMadde.GetAllEtkinMaddeDef(objectContext).Where(t => t.IsActive != null && t.IsActive == true);

                        foreach (EtkinMadde existIngredient in existActiveIngredients)
                        {
                            var foundIngredients = raporEtkinMadde.etkinMaddeListesi.Where(t => t.kodu == existIngredient.etkinMaddeKodu).ToList();

                            if(foundIngredients.Count == 0)
                            {
                                existIngredient.IsActive = false;
                            }
                        }
                        objectContext.Save();

                        foreach (YardimciIslemler.etkinMaddeDVO etkinMadde in raporEtkinMadde.etkinMaddeListesi)
                        {
                            BindingList<EtkinMadde> emList = EtkinMadde.GetEtkinMaddeByCode(objectContext, etkinMadde.kodu);
                            if (emList.Count == 0)
                            {
                                EtkinMadde em = new EtkinMadde(objectContext);
                                em.etkinMaddeAdi = etkinMadde.adi;
                                em.etkinMaddeKodu = etkinMadde.kodu;
                                em.form = etkinMadde.formu;
                                em.icerikMiktari = string.IsNullOrEmpty(etkinMadde.icerikMiktari) ? "1" : etkinMadde.icerikMiktari;
                                em.baslangicTarihi = Common.RecTime();
                                em.IsActive = true;
                            }
                            else
                            {
                                foreach (EtkinMadde em in emList)
                                {
                                    em.etkinMaddeAdi = etkinMadde.adi;
                                    em.form = etkinMadde.formu; ;
                                    em.icerikMiktari = string.IsNullOrEmpty(etkinMadde.icerikMiktari) ? em.icerikMiktari : etkinMadde.icerikMiktari;
                                    if (string.IsNullOrEmpty(em.icerikMiktari))
                                        em.icerikMiktari = "1";
                                    em.IsActive = true;
                                }
                            }
                        }
                        objectContext.Save();
                    }

                    YardimciIslemler.etkinMaddeListesiSorguCevapDVO raporYurtDisiEtkinMadde = YardimciIslemler.WebMethods.yurtdisiIlacEtkinMaddeListesiSorgulaSync(Sites.SiteLocalHost, requestEtkinMadde);
                    if (raporYurtDisiEtkinMadde != null && raporYurtDisiEtkinMadde.sonucKodu.Equals("0000") && raporYurtDisiEtkinMadde.etkinMaddeListesi != null)
                    {
                        var existActiveIngredients = EtkinMadde.GetAllEtkinMaddeDef(objectContext).Where(t => t.IsActive != null && t.IsActive == true);

                        foreach (EtkinMadde existIngredient in existActiveIngredients)
                        {
                            var foundIngredients = raporYurtDisiEtkinMadde.etkinMaddeListesi.Where(t => t.kodu == existIngredient.etkinMaddeKodu).ToList();

                            if (foundIngredients.Count == 0)
                            {
                                existIngredient.IsActive = false;
                            }
                        }
                        objectContext.Save();

                        foreach (YardimciIslemler.etkinMaddeDVO etkinMadde in raporYurtDisiEtkinMadde.etkinMaddeListesi)
                        {
                            BindingList<EtkinMadde> emList = EtkinMadde.GetEtkinMaddeByCode(objectContext, etkinMadde.kodu);
                            if (emList.Count == 0)
                            {
                                EtkinMadde em = new EtkinMadde(objectContext);
                                em.etkinMaddeAdi = etkinMadde.adi;
                                em.etkinMaddeKodu = etkinMadde.kodu;
                                em.form = etkinMadde.formu;
                                em.icerikMiktari = string.IsNullOrEmpty(etkinMadde.icerikMiktari) ? "1" : etkinMadde.icerikMiktari;
                                em.baslangicTarihi = Common.RecTime();
                                em.IsActive = true;
                            }
                            else
                            {
                                foreach (EtkinMadde em in emList)
                                {
                                    em.etkinMaddeAdi = etkinMadde.adi;
                                    em.form = etkinMadde.formu; ;
                                    em.icerikMiktari = string.IsNullOrEmpty(etkinMadde.icerikMiktari) ? em.icerikMiktari : etkinMadde.icerikMiktari;
                                    if (string.IsNullOrEmpty(em.icerikMiktari))
                                        em.icerikMiktari = "1";
                                    em.IsActive = true;
                                }
                            }
                        }
                        objectContext.Save();
                    }



                    YardimciIslemler.raporTeshisListesiSorguIstekDVO requestTeshis = new YardimciIslemler.raporTeshisListesiSorguIstekDVO();
                    //doktorTC = 10000000000;
                    //tesisKodu = 11069941;
                    requestTeshis.doktorTcKimlikNo = doktorTC;
                    requestTeshis.tesisKodu = tesisKodu;

                    YardimciIslemler.raporTeshisListesiSorguCevapDVO responseTeshis = YardimciIslemler.WebMethods.raporTeshisListesiSorgulaSync(Sites.SiteLocalHost, requestTeshis);
                    if (responseTeshis != null)
                    {
                        if (responseTeshis.sonucKodu.Equals("0000"))
                        {
                            foreach (YardimciIslemler.raporTeshisDVO raporTeshis in responseTeshis.raporTeshisListesi)
                            {
                                BindingList<Teshis> teshisList = Teshis.GetTesihisByCode(objectContext, raporTeshis.raporTeshisKodu);
                                if (teshisList.Count == 0)
                                {
                                    Teshis teshis = new Teshis(objectContext);
                                    teshis.teshisKodu = Convert.ToInt32(raporTeshis.raporTeshisKodu);
                                    teshis.teshisAdi = raporTeshis.aciklama;
                                    teshis.IsActive = true;
                                }
                                else
                                {
                                    foreach (Teshis teshis in teshisList)
                                    {
                                        teshis.teshisAdi = raporTeshis.aciklama;
                                        teshis.teshisKodu = Convert.ToInt32(raporTeshis.raporTeshisKodu);
                                        teshis.IsActive = true;
                                    }
                                }
                            }
                            objectContext.Save();
                        }
                    }


                    YardimciIslemler.etkinMaddeSutListesiSorguIstekDVO request = new YardimciIslemler.etkinMaddeSutListesiSorguIstekDVO();
                    request.doktorTcKimlikNo = doktorTC;
                    request.tesisKodu = tesisKodu;
                    request.raporTarihi = DateTime.Now.ToString("dd.MM.yyyy");

                    BindingList<EtkinMadde> etkinMaddeList = EtkinMadde.GetAllEtkinMaddeDef(objectContext);
                    foreach (EtkinMadde etkinMadde in etkinMaddeList)
                    {
                        if (etkinMadde.TeshisEtkinMaddeGrid == null || etkinMadde.TeshisEtkinMaddeGrid.Count == 0)
                        {
                            request.etkinMaddeKodu = etkinMadde.etkinMaddeKodu;
                            try
                            {
                                YardimciIslemler.etkinMaddeSutListesiSorguCevapDVO response = YardimciIslemler.WebMethods.etkinMaddeSutListesiSorgulaSync(Sites.SiteLocalHost, request);
                                if (response != null)
                                {
                                    if (response.sonucKodu.Equals("0000") && response.etkinMaddeSutListesi != null)
                                    {
                                        foreach (YardimciIslemler.etkinMaddeSutDVO item in response.etkinMaddeSutListesi)
                                        {
                                            foreach (YardimciIslemler.raporTeshisDVO teshis in item.raporTeshisListesi)
                                            {
                                                BindingList<Teshis> teshisList = Teshis.GetTesihisByCode(objectContext, teshis.raporTeshisKodu);
                                                if (teshisList.Count > 0)
                                                {
                                                    TeshisEtkinMaddeGrid added = etkinMadde.TeshisEtkinMaddeGrid.Where(t => t.Teshis.ObjectID == teshisList[0].ObjectID).FirstOrDefault();

                                                    if (added == null)
                                                    {
                                                        TeshisEtkinMaddeGrid teshisEtkinMaddeGrid = new TeshisEtkinMaddeGrid(objectContext);
                                                        teshisEtkinMaddeGrid.Teshis = teshisList[0];
                                                        teshisEtkinMaddeGrid.EtkinMadde = etkinMadde;
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                                System.Threading.Thread.Sleep(750);
                            }
                            catch (Exception ex)
                            {
                                System.Threading.Thread.Sleep(5000);
                                log += ex.ToString();
                            }
                        }
                    }
                    objectContext.Save();
                }
                catch (Exception ex)
                {
                    log += ex.ToString();
                }
                finally
                {
                    if (string.IsNullOrEmpty(log))
                        log = TTUtils.CultureService.GetText("M26698", "Planlı görev başarıyla tamamlanmıştır.");
                    AddLog(log);
                }
            }
           
        }
        #endregion Methods
    }
}