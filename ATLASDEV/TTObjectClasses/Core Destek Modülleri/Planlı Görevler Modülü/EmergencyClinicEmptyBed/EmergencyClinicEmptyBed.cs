
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
    public  partial class EmergencyClinicEmptyBed : BaseScheduledTask
    {
#region Methods
        public override  void TaskScript()
        {
            string log = string.Empty;
            try
            {
                string ipAddr = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112IP", null);
                TTUtils.TTWebServiceUri uri = new TTUtils.TTWebServiceUri(ipAddr);
                string userName112 = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME", null);
                string password112 = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD", null);
              
                TTObjectContext context = new TTObjectContext(true);
                BindingList<ResBed.GetAllClinicsEmptybedCounts_Class> emptyBedList = ResBed.GetAllClinicsEmptybedCounts(context);
                BindingList<ResBed.GetAllClinicsBeds_Class> bedList = ResBed.GetAllClinicsBeds(context);
                BindingList<ResBed.GetEmptyBedsWithVentilator_Class> emptyBedVentilatorList = ResBed.GetEmptyBedsWithVentilator(context);
                BindingList<ResBed.GetAllBedsWithVentilator_Class> bedVentilatorList = ResBed.GetAllBedsWithVentilator(context);
                BindingList<ResBed.GetEmptyBedsKuvez_Class> emptyBedKuvezList = ResBed.GetEmptyBedsKuvez(context);
                BindingList<ResBed.GetAllBedsKuvez_Class> bedKuvezList = ResBed.GetAllBedsKuvez(context);

                Acil112Servis.BolumBilgisi[] bolumBilgileriListesi = new Acil112Servis.BolumBilgisi[100];
                if (bedList.Count > 0)
                {
                    int i = 0;
                    foreach (ResBed.GetAllClinicsBeds_Class bed in bedList)
                    {  
                        Acil112Servis.BolumBilgisi bolumBilgileri = new Acil112Servis.BolumBilgisi();
                        bolumBilgileri.BolumKod = ((Acil112Servis.BolumKodlari)Enum.Parse(typeof(Acil112Servis.BolumKodlari),bed.Clinic !=null ? bed.Clinic.ToString() : ""));
                        if (bed.PercentageOfEmptyBedFor112 == null || bed.PercentageOfEmptyBedFor112 == 0)
                        {
                            bolumBilgileri.ToplamYatak = bed.Yataksayisi != null ? Convert.ToInt32(bed.Yataksayisi) / 2 : 0; ///default olarak 50% 'si alınacak
                        }
                        else
                        {
                            double ToplamYatak2 = (Convert.ToDouble(bed.PercentageOfEmptyBedFor112) / 100);
                            bolumBilgileri.ToplamYatak = bed.Yataksayisi != null ? Convert.ToInt32(ToplamYatak2 * Convert.ToInt64(bed.Yataksayisi)) : 0;
                           // bolumBilgileri.ToplamYatak = bed.Yataksayisi != null ? Convert.ToInt32((Convert.ToDecimal(bed.Yataksayisi) / 100)) * Convert.ToInt32(bed.PercentageOfEmptyBedFor112) : 0;
                        }
                        if (emptyBedList.Count > 0)
                        {
                            foreach (ResBed.GetAllClinicsEmptybedCounts_Class emptyBed in emptyBedList)
                            {
                                if (bed.Clinic != null && emptyBed.Clinic != null)
                                {
                                    if (bed.Clinic == emptyBed.Clinic)
                                    {
                                        if (bed.PercentageOfEmptyBedFor112 == null || bed.PercentageOfEmptyBedFor112 == 0)
                                        {
                                            bolumBilgileri.BosYatak = emptyBed.Yataksayisi != null ? Convert.ToInt32(emptyBed.Yataksayisi) / 2 : 0; ///default olarak 50% 'si alınacak
                                        }
                                        else
                                        {
                                            double ToplamYatak2 = (Convert.ToDouble(bed.PercentageOfEmptyBedFor112) / 100);
                                            bolumBilgileri.BosYatak = bed.Yataksayisi != null ? Convert.ToInt32(ToplamYatak2 * Convert.ToInt64(emptyBed.Yataksayisi)) : 0;
                                           // bolumBilgileri.BosYatak = emptyBed.Yataksayisi != null ? Convert.ToInt32((Convert.ToDecimal(emptyBed.Yataksayisi) / 100)) * Convert.ToInt32(bed.PercentageOfEmptyBedFor112) : 0;
                                        }
                                    }
                                }
                            }
                        }
                        if (emptyBedVentilatorList.Count > 0)
                        {
                            foreach (ResBed.GetEmptyBedsWithVentilator_Class emptyBedVentilator in emptyBedVentilatorList)
                            {
                                if (bed.Clinic != null && emptyBedVentilator.Clinic != null)
                                {
                                    if (bed.Clinic == emptyBedVentilator.Clinic)
                                    {
                                        if (bed.PercentageOfEmptyBedFor112 == null || bed.PercentageOfEmptyBedFor112 == 0)
                                        {
                                            bolumBilgileri.BosVentil = emptyBedVentilator.Yataksayisi != null ? Convert.ToInt32(emptyBedVentilator.Yataksayisi) / 2 : 0;
                                        }
                                        else
                                        {
                                            double ToplamYatak2 = (Convert.ToDouble(bed.PercentageOfEmptyBedFor112) / 100);
                                            bolumBilgileri.BosVentil = emptyBedVentilator.Yataksayisi != null ? Convert.ToInt32(ToplamYatak2 * Convert.ToInt64(emptyBedVentilator.Yataksayisi)) : 0;
                                            // bolumBilgileri.BosYatak = emptyBed.Yataksayisi != null ? Convert.ToInt32((Convert.
                                           // bolumBilgileri.BosVentil = emptyBedVentilator.Yataksayisi != null ? Convert.ToInt32((Convert.ToDecimal(emptyBedVentilator.Yataksayisi) / 100)) * Convert.ToInt32(bed.PercentageOfEmptyBedFor112) : 0;
                                        }
                                    }
                                }
                            }
                        }
                        if (bedVentilatorList.Count > 0)
                        {
                            foreach (ResBed.GetAllBedsWithVentilator_Class bedVentilator in bedVentilatorList)
                            {
                                if (bed.Clinic != null && bedVentilator.Clinic != null)
                                {
                                    if (bed.Clinic == bedVentilator.Clinic)
                                    {
                                        if (bed.PercentageOfEmptyBedFor112 == null || bed.PercentageOfEmptyBedFor112 == 0)
                                        {
                                            bolumBilgileri.ToplamVentil = bedVentilator.Yataksayisi != null ? Convert.ToInt32(bedVentilator.Yataksayisi) / 2 : 0;
                                        }
                                        else
                                        {
                                            double ToplamYatak2 = (Convert.ToDouble(bed.PercentageOfEmptyBedFor112) / 100);
                                            bolumBilgileri.ToplamVentil = bedVentilator.Yataksayisi != null ? Convert.ToInt32(ToplamYatak2 * Convert.ToInt64(bedVentilator.Yataksayisi)) : 0;
                                            //bolumBilgileri.ToplamVentil = bedVentilator.Yataksayisi != null ? Convert.ToInt32((Convert.ToDecimal(bedVentilator.Yataksayisi) / 100)) * Convert.ToInt32(bed.PercentageOfEmptyBedFor112) : 0;
                                        }
                                    }
                                }
                            }
                        }
                        if (emptyBedKuvezList.Count > 0)
                        {
                            foreach (ResBed.GetEmptyBedsKuvez_Class emptyBedKuvez in emptyBedKuvezList)
                            {
                                if (bed.Clinic != null && emptyBedKuvez.Clinic != null)
                                {
                                    if (bed.Clinic == emptyBedKuvez.Clinic)
                                    {
                                        if (bed.PercentageOfEmptyBedFor112 == null || bed.PercentageOfEmptyBedFor112 == 0)
                                        {
                                            bolumBilgileri.BosKuvez = emptyBedKuvez.Yataksayisi != null ? Convert.ToInt32(emptyBedKuvez.Yataksayisi) / 2 : 0;
                                        }
                                        else
                                        {
                                            double ToplamYatak2 = (Convert.ToDouble(bed.PercentageOfEmptyBedFor112) / 100);
                                            bolumBilgileri.BosKuvez = emptyBedKuvez.Yataksayisi != null ? Convert.ToInt32(ToplamYatak2 * Convert.ToInt64(emptyBedKuvez.Yataksayisi)) : 0;
                                            //bolumBilgileri.BosKuvez = emptyBedKuvez.Yataksayisi != null ? Convert.ToInt32((Convert.ToDecimal(emptyBedKuvez.Yataksayisi) / 100)) * Convert.ToInt32(bed.PercentageOfEmptyBedFor112) : 0;
                                        }
                                    }
                                }
                            }
                        }
                        if (bedKuvezList.Count > 0)
                        {
                            foreach (ResBed.GetAllBedsKuvez_Class bedKuvez in bedKuvezList)
                            {
                                if (bed.Clinic != null && bedKuvez.Clinic != null)
                                {
                                    if (bed.Clinic == bedKuvez.Clinic)
                                    {
                                        if (bed.PercentageOfEmptyBedFor112 == null || bed.PercentageOfEmptyBedFor112 == 0)
                                        {
                                            bolumBilgileri.ToplamKuvez = bedKuvez.Yataksayisi != null ? Convert.ToInt32(bedKuvez.Yataksayisi) / 2 : 0;
                                        }
                                        else
                                        {
                                            double ToplamYatak2 = (Convert.ToDouble(bed.PercentageOfEmptyBedFor112) / 100);
                                            bolumBilgileri.ToplamKuvez = Convert.ToInt32(ToplamYatak2 * Convert.ToInt64(bolumBilgileri.ToplamKuvez));
                                          //  bolumBilgileri.ToplamKuvez =  bolumBilgileri.ToplamKuvez  != null ? Convert.ToInt32((Convert.ToDecimal(bedKuvez.Yataksayisi) / 100)) * Convert.ToInt32(bed.PercentageOfEmptyBedFor112) : 0;
                                        }
                                    }
                                }
                            }
                        }
                        bolumBilgileriListesi[i] = bolumBilgileri;
                        i++;
                    }
                    TTObjectClasses.Acil112Servis.WebMethods.AdetleriGonder_ArraySync(Sites.SiteLocalHost,uri, userName112, password112, bolumBilgileriListesi, ipAddr);
                }
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
        
#endregion Methods

    }
}