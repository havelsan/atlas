using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using ReportClasses.ReportUtils;
using TTInstanceManagement;

namespace AtlasDataSource.Controllers
{
    public class EpikrizRaporu
    {
        public static EpikrizRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<EpikrizRaporuData>(parameters, "GetEpikrizRaporuData");
        }

        public static EpikrizRaporuData GetEpikrizRaporuData(string parameters)
        {
            EpikrizRaporuData data = new EpikrizRaporuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<EpikrizRaporuParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    CreatingEpicrisis epicrisisObject = objectContext.GetObject<CreatingEpicrisis>(param.EpicrisisObjectID);
                    EpisodeAction episodeAction = (EpisodeAction)epicrisisObject.MasterAction;
            //        EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(param.EpisodeActionObjectID);

                    Episode episode = episodeAction.Episode;
                    Patient patient = episode.Patient;
                    SubEpisode subEpisode = episodeAction.SubEpisode;
                    data.HastaAdiSoyadi = patient.Name + " " + patient.Surname;
                    data.HastaTC = patient.UniqueRefNo.ToString();
                    data.HastaDogumYeri = patient.BirthPlace;
                    data.HastaDogumTarihi = patient.BirthDate;
                    data.HastaAdres = patient.PatientAddress.HomeAddress;
                    data.HastaCinsiyet = patient.Sex.ADI;
                    data.Telefon = patient.MobilePhone;
                    data.HastaKabulNo = subEpisode.ProtocolNo;
                    data.XXXXXXAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");

                //    data.YattigiServis = episodeAction.MasterResource;
                   // data.KabulNo = sub
                    SubEpisode firstSubEpisode = episodeAction.SubEpisode;
                    while(firstSubEpisode.OldSubEpisode != null)
                    {
                        firstSubEpisode = firstSubEpisode.OldSubEpisode;
                    }

                    foreach (EpisodeAction episodeAct in firstSubEpisode.EpisodeActions)
                    {
                        if (episodeAct is PatientExamination)
                        {
                            data.PoliklinikMuayeneTarihi = ((PatientExamination)episodeAct).ProcessEndDate;
                            data.Poliklinik = ((PatientExamination)episodeAct).MasterResource.Name;
                            data.PoliklinikMuayeneDoktoru = ((PatientExamination)episodeAct).ProcedureDoctor.Name;
                            data.PoliklinikMuayeneKabulNo = firstSubEpisode.ProtocolNo;
                        }

                    }

                    data.KabulTarihi = firstSubEpisode.OpeningDate;

                    EpisodeAction starterEpisodeAction = subEpisode.StarterEpisodeAction;
                    if (starterEpisodeAction != null && starterEpisodeAction is InPatientTreatmentClinicApplication)
                    {
                        if (((InPatientTreatmentClinicApplication)starterEpisodeAction).ClinicDischargeDate != null)
                            data.HastaCikisTarihi = ((InPatientTreatmentClinicApplication)starterEpisodeAction).ClinicDischargeDate;
                        if (((InPatientTreatmentClinicApplication)starterEpisodeAction).ClinicInpatientDate != null)
                            data.HastaYatisTarihi = ((InPatientTreatmentClinicApplication)starterEpisodeAction).ClinicInpatientDate; //bu kontrol sorulacak.
                    }
                    else
                    {
                        data.HastaCikisTarihi = subEpisode.ClosingDate;
                        data.HastaYatisTarihi = subEpisode.OpeningDate;
                    }

                    data.HastaninYattigiBolum = episodeAction.MasterResource.Name;
                    data.YatisIstemYapanDoktor = episodeAction.ProcedureDoctor.Name;
                    data.KurumAdi = subEpisode.LastSubEpisodeProtocol.Payer.Name;

                    if (starterEpisodeAction != null && starterEpisodeAction is InPatientTreatmentClinicApplication)
                    {
                        InPatientTreatmentClinicApplication TreatmentClinicApp = (InPatientTreatmentClinicApplication)starterEpisodeAction;

                        if (starterEpisodeAction.SubEpisode.InpatientStatus != null)
                        {
                            if (starterEpisodeAction.SubEpisode.InpatientStatus.Value == InpatientStatusEnum.Discharged
                                || starterEpisodeAction.SubEpisode.InpatientStatus.Value == InpatientStatusEnum.Predischarged)
                            {
                                if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)
                                {
                                    data.YatisGunSayisi = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days;
                                }
                            }

                            else if (starterEpisodeAction.SubEpisode.InpatientStatus.Value == InpatientStatusEnum.Inpatient)
                            {
                                if (TreatmentClinicApp.ClinicInpatientDate != null)
                                    data.YatisGunSayisi = (Common.RecTime() - TreatmentClinicApp.ClinicInpatientDate.Value).Days + 1;

                            }
                        }

                        else
                        {
                            if (TreatmentClinicApp.TreatmentDischarge != null && TreatmentClinicApp.TreatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.Discharged)
                            {
                                if (TreatmentClinicApp.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Transferred)
                                {
                                    if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yatış ve taburcu tarihi var ise yatış gün sayısı hesaplama
                                    {
                                        data.YatisGunSayisi = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days;
                                    }
                                }

                                else
                                {
                                    if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yatış ve taburcu tarihi var ise yatış gün sayısı hesaplama
                                    {
                                        data.YatisGunSayisi = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days;
                                    }
                                }
                            }

                            else if (TreatmentClinicApp.TreatmentDischarge != null && TreatmentClinicApp.TreatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.PreDischarge)
                            {
                                if (TreatmentClinicApp.ClinicDischargeDate != null && TreatmentClinicApp.ClinicInpatientDate != null)//yatış ve taburcu tarihi var ise yatış gün sayısı hesaplama
                                {
                                    data.YatisGunSayisi = (TreatmentClinicApp.ClinicDischargeDate.Value - TreatmentClinicApp.ClinicInpatientDate.Value).Days;
                                }
                            }
                            else
                            {
                                if (TreatmentClinicApp.ClinicInpatientDate != null)//yatış tarihi var ise yatış gün sayısı hesaplama
                                {
                                    data.YatisGunSayisi = (Common.RecTime() - TreatmentClinicApp.ClinicInpatientDate.Value).Days + 1;
                                }
                            }
                        }
                        data.YatisDoktoru = TreatmentClinicApp.ProcedureDoctor.Name;
                    }

                 //   data.YatisGunSayisi = (DateTime.Today - (DateTime)data.HastaCikisTarihi).TotalDays;


                    BindingList<DiagnosisGrid.GetDiagnosisBySubEpisode_Class> diagnosis = DiagnosisGrid.GetDiagnosisBySubEpisode(subEpisode.ObjectID.ToString(), episode.ObjectID.ToString());
                    data.Tanilar = new List<EpikrizTaniData>();

                    foreach (DiagnosisGrid.GetDiagnosisBySubEpisode_Class d in diagnosis)
                    {
                        EpikrizTaniData tani = new EpikrizTaniData();
                        tani.TaniKodu = d.Code;
                        tani.TaniAdi = d.Name;
                        tani.TaniTarih = Convert.ToDateTime(d.Diagnosedate);

                        data.Tanilar.Add(tani);
                    }


                    data.Oyku = (episode.PatientHistory == null || episode.PatientHistory == "") ? "" : TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(episode.PatientHistory.ToString()); 
                    data.FizikMuayene = (episode.PhysicalExamination == null || episode.PhysicalExamination == "") ? "" : TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(episode.PhysicalExamination.ToString());
                    data.Yakinmalar = (epicrisisObject.COMPLAINTANDSTORY == null || epicrisisObject.COMPLAINTANDSTORY == "") ? "" : TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(epicrisisObject.COMPLAINTANDSTORY?.ToString());
                    data.Oyku = (epicrisisObject.STORY == null || epicrisisObject.STORY == "") ? "" : TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(epicrisisObject.STORY.ToString());
                    data.OzSoyGecmisi = (epicrisisObject.AUTOBIOGRAPHY == null || epicrisisObject.AUTOBIOGRAPHY == "") ? "" : TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(epicrisisObject.AUTOBIOGRAPHY.ToString()); 
                    data.FizikMuayene = (epicrisisObject.PHYSICALEXAMINATION == null || epicrisisObject.PHYSICALEXAMINATION == "") ? "" : TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(epicrisisObject.PHYSICALEXAMINATION.ToString());
                    data.Bulgular = (epicrisisObject.SYMPTOM == null || epicrisisObject.SYMPTOM == "") ? "" : TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(epicrisisObject.SYMPTOM.ToString()); 
                    data.YapilanTedavi = (epicrisisObject.PROCEDURE == null || epicrisisObject.PROCEDURE == "") ? "" : TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(epicrisisObject.PROCEDURE.ToString()); 
                    data.Oneriler = (epicrisisObject.Suggestion == null || epicrisisObject.Suggestion == "" ) ? "" : TTUtils.HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(epicrisisObject.Suggestion.ToString()); 
                    

                    BindingList<RadiologyTest.GetRadiologyTestBySubEpisode_Class> radiologyTetkik = RadiologyTest.GetRadiologyTestBySubEpisode(subEpisode.ObjectID.ToString());
                    data.RadyolojiTetkikler = new List<RadyolojiTetkikData>();

                    foreach (RadiologyTest.GetRadiologyTestBySubEpisode_Class tetkik in radiologyTetkik)
                    {
                        RadiologyTest radTest = objectContext.GetObject<RadiologyTest>(tetkik.ObjectID.Value);
                        RadyolojiTetkikData rdTetkik = new RadyolojiTetkikData();
                        rdTetkik.RadyolojiTetkiki = radTest.ProcedureObject.Name;
                        rdTetkik.RadyolojiTetkikKodu = radTest.ProcedureObject.Code;
                        rdTetkik.RadyolojiTetkikTarihi = tetkik.ActionDate;

                        data.RadyolojiTetkikler.Add(rdTetkik);
                    }

                    /*               BindingList<Pathology.GetPathologyTestBySubEpisode_Class> pathologyTetkik = Pathology.GetPathologyTestBySubEpisode(subEpisode.ObjectID.ToString());
                                   data.PatolojiTetkikler = new List<PatolojiTetkikData>();

                                   foreach(Pathology.GetPathologyTestBySubEpisode_Class pato in pathologyTetkik)
                                   {
                                       PathologyTestProcedure ptTest = objectContext.GetObject<PathologyTestProcedure>(pato.ObjectID.Value);
                                       PatolojiTetkikData ptTetkik = new PatolojiTetkikData();
                                       ptTetkik.PatolojiTetkiki = ptTest.ProcedureObject.Name;
                                       ptTetkik.PatolojiTetkikKodu = ptTest.ProcedureObject.Code;
                                       ptTetkik.PatolojiTetkikTarihi = ptTest.ActionDate;

                                   }
                                   */
                    BindingList<NuclearMedicineTest.GetNuclearMedicineTestBySubEpisode_Class> nukleerTipTetkik = NuclearMedicineTest.GetNuclearMedicineTestBySubEpisode(subEpisode.ObjectID.ToString());
                    data.NukleerTipTetkikler = new List<NukleerTipTetkikData>();

                    foreach (NuclearMedicineTest.GetNuclearMedicineTestBySubEpisode_Class nukleerTetkik in nukleerTipTetkik)
                    {
                        NuclearMedicineTest nucTest = objectContext.GetObject<NuclearMedicineTest>(nukleerTetkik.ObjectID.Value);
                        NukleerTipTetkikData nucTetkik = new NukleerTipTetkikData();

                        nucTetkik.NukleerTipTetkiki = nucTest.ProcedureObject.Name;
                        nucTetkik.NukleerTipTetkikKodu = nucTest.ProcedureObject.Code;
                        nucTetkik.NukleerTipTetkikTarihi = nukleerTetkik.ActionDate;

                        data.NukleerTipTetkikler.Add(nucTetkik);
                    }

                    BindingList<GeneticTest.GetGeneticTestBySubEpisode_Class> tibbiGenetikTetkik = GeneticTest.GetGeneticTestBySubEpisode(subEpisode.ObjectID.ToString());
                    data.TibbiGenetikTetkikler = new List<TibbiGenetikTetkikData>();

                    foreach (GeneticTest.GetGeneticTestBySubEpisode_Class genetikTetkik in tibbiGenetikTetkik)
                    {
                        GeneticTest genTest = objectContext.GetObject<GeneticTest>(genetikTetkik.ObjectID.Value);
                        TibbiGenetikTetkikData genTetkik = new TibbiGenetikTetkikData();

                        genTetkik.TibbiGenetikTetkiki = genTest.ProcedureObject.Name;
                        genTetkik.TibbiGenetikTetkikKodu = genTest.ProcedureObject.Code;
                        genTetkik.TibbiGenetikTetkikTarihi = genetikTetkik.ActionDate;

                        data.TibbiGenetikTetkikler.Add(genTetkik);
                    }



                    BindingList<InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class> klinikIzlemSorgu = InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode(subEpisode.ToString(), episode.ToString());
                    data.KlinikIzlem = new List<KlinikIzlemData>();

                    foreach (InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class izlem in klinikIzlemSorgu)
                    {
                        KlinikIzlemData klinikIzlem = new KlinikIzlemData();

                        klinikIzlem.KlinikIzlemTarih = izlem.ProgressDate;
                        klinikIzlem.KlinikIzlemAciklamasi = izlem.Description.ToString();

                        data.KlinikIzlem.Add(klinikIzlem);
                    }

                    BindingList<SurgeryProcedure.GetSurgeryProceduresBySubEpisode_Class> ameliyatlar = SurgeryProcedure.GetSurgeryProceduresBySubEpisode(subEpisode.ToString(), episode.ToString());
                    data.Ameliyatlar = new List<AmeliyatveAnesteziData>();

                    foreach (SurgeryProcedure.GetSurgeryProceduresBySubEpisode_Class ameliyat in ameliyatlar)
                    {
                        SurgeryProcedure surgeryProcedure = objectContext.GetObject<SurgeryProcedure>(ameliyat.ObjectID.Value);
                        AmeliyatveAnesteziData ameliyatInfo = new AmeliyatveAnesteziData();
                        ameliyatInfo.AmeliyatTarih = ameliyat.Surgerydate;
                        ameliyatInfo.AmeliyatAdi = ameliyat.Name;
                        ameliyatInfo.AmeliyatKodu = ameliyat.Code;

                        if (surgeryProcedure != null)
                        {
                            if (surgeryProcedure.Surgery != null)
                            {
                                if (surgeryProcedure.Surgery.AnesthesiaAndReanimation != null)
                                {
                                    if (surgeryProcedure.Surgery.AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures != null && surgeryProcedure.Surgery.AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures.Count > 0)
                                    {
                                        ameliyatInfo.AnesteziTuru = surgeryProcedure.Surgery.AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures[0].ProcedureObject.Name;
                                        ameliyatInfo.AnesteziKodu = surgeryProcedure.Surgery.AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures[0].ProcedureObject.MySUTCode;
                                    }

                                }
                            }
                        }

                        data.Ameliyatlar.Add(ameliyatInfo);
                    }

                    BindingList<PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class> tibbiIslemler = PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic(episode.ToString());
                    data.PlanliTibbiİslemler = new List<PlanliTibbiİslemlerData>();

                    foreach (PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class islem in tibbiIslemler)
                    {
                        PlannedMedicalActionOrderDetail planliIslem = objectContext.GetObject<PlannedMedicalActionOrderDetail>(islem.ObjectID.Value);
                        PlanliTibbiİslemlerData tibbiIslem = new PlanliTibbiİslemlerData();
                        tibbiIslem.PlanliTibbiİslem = planliIslem.ProcedureObject.Name;
                        tibbiIslem.PlanliTibbiİslemKodu = planliIslem.ProcedureObject.MySUTCode;
                        tibbiIslem.PlanliTibbiİslemTarih = islem.ActionDate;

                        data.PlanliTibbiİslemler.Add(tibbiIslem);
                    }

                    BindingList<ManipulationProcedure.GetManipulationProceduresBySubEpisode_Class> cerrahiUygulamalar = ManipulationProcedure.GetManipulationProceduresBySubEpisode(subEpisode.ObjectID.ToString());
                    data.TibbiCerahiUygulamalar = new List<TibbiCerrahiUygulamalarData>();

                    foreach (ManipulationProcedure.GetManipulationProceduresBySubEpisode_Class uygulama in cerrahiUygulamalar)
                    {
                        ManipulationProcedure pro = objectContext.GetObject<ManipulationProcedure>(uygulama.ObjectID.Value);
                        TibbiCerrahiUygulamalarData cerrahiUygulama = new TibbiCerrahiUygulamalarData();

                        cerrahiUygulama.TibbiCerrahiUygulama = pro.ProcedureObject.Name;
                        cerrahiUygulama.TibbiCerrahiUygulamaKodu = pro.ProcedureObject.Code;
                        cerrahiUygulama.TibbiCerrahiUygulamaTarih = uygulama.ActionDate;

                        data.TibbiCerahiUygulamalar.Add(cerrahiUygulama);
                    }

                    BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class> ortezProtezListe = OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode(subEpisode.ObjectID.ToString());
                    data.OrtezProtezIslemleri = new List<OrtezProtezData>();

                    foreach (OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class ortezProtez in ortezProtezListe)
                    {
                        OrthesisProsthesisProcedure ortezProtezVeri = objectContext.GetObject<OrthesisProsthesisProcedure>(ortezProtez.ObjectID.Value);
                        OrtezProtezData ortezProtezModel = new OrtezProtezData();

                        ortezProtezModel.OrtezProtezİslemi = ortezProtezVeri.ProcedureObject.Name;
                        ortezProtezModel.OrtezProtezIslemiKodu = ortezProtezVeri.ProcedureObject.Code;
                        ortezProtezModel.OrtezProtezIslemiTarih = ortezProtez.ActionDate;

                        data.OrtezProtezIslemleri.Add(ortezProtezModel);
                    }

                    BindingList<BaseTreatmentMaterial> materialList = BaseTreatmentMaterial.GetMaterialBySubEpisode(objectContext, subEpisode.ObjectID, episode.ObjectID.ToString());
                    data.TibbiMalzemeler = new List<TibbiMalzemeData>();

                    foreach (BaseTreatmentMaterial material in materialList)
                    {
                        TibbiMalzemeData malzeme = new TibbiMalzemeData();
                        if (material.PricingDate != null)
                            malzeme.TibbiMalzemeTarih = material.PricingDate;
                        else
                            malzeme.TibbiMalzemeTarih = material.ActionDate;
                        malzeme.TibbiMalzemeAdi = material.Material.Name;
                        malzeme.TibbiMalzemeKodu = material.Material.Code;

                        data.TibbiMalzemeler.Add(malzeme);

                    }

                    BindingList<DrugOrder> drugList = DrugOrder.GetDrugOrdersBySubEpisode(objectContext, subEpisode.ObjectID, episode.ObjectID.ToString());
                    data.Ilaclar = new List<IlacData>();

                    foreach (DrugOrder drug in drugList)
                    {
                        IlacData ilac = new IlacData();

                        ilac.IlacAdi = drug.Material.Name;
                        ilac.IlacKodu = drug.Material.Code;
                        ilac.IlacTarih = drug.PlannedStartTime;

                        data.Ilaclar.Add(ilac);
                    }

                    BindingList<BloodBankBloodProducts.GetBloodProductBySubEpisode_Class> bloodList = BloodBankBloodProducts.GetBloodProductBySubEpisode(subEpisode.ObjectID, episode.ObjectID.ToString());
                    data.KanUrunleri = new List<KanUrunleriData>();

                    foreach (BloodBankBloodProducts.GetBloodProductBySubEpisode_Class blood in bloodList)
                    {
                        KanUrunleriData urun = new KanUrunleriData();

                        urun.KanUrunleriAdi = blood.Procedurename;
                        urun.KanUrunleriKodu = blood.ProductNumber;
                        urun.KanUrunleriTarih = blood.RequestDate;

                        data.KanUrunleri.Add(urun);
                    }

                    BindingList<PMAddingProcedure> procedureList = PMAddingProcedure.GetPMProcedureBySubEpisode(objectContext, subEpisode.ObjectID, episode.ObjectID);
                    data.Hizmetler = new List<HizmetData>();

                    foreach (PMAddingProcedure procedure in procedureList)
                    {
                        HizmetData hizmet = new HizmetData();
                        hizmet.HizmetAdi = procedure.ProcedureObject.Name;
                        hizmet.HizmetKodu = procedure.ProcedureObject.MySUTCode;

                        if (procedure.PricingDate != null)
                        {
                            hizmet.HizmetTarih = procedure.PricingDate;
                        }

                        else
                            hizmet.HizmetTarih = procedure.ActionDate;

                        data.Hizmetler.Add(hizmet);
                    }

                    BindingList<CompanionApplication.GetCompanionApplicationBySubEpisode_Class> companionList = CompanionApplication.GetCompanionApplicationBySubEpisode(subEpisode.ObjectID.ToString(), episode.ToString());
                    data.Refakatciler = new List<RefakatciData>();
                    foreach (CompanionApplication.GetCompanionApplicationBySubEpisode_Class companion in companionList)
                    {
                        RefakatciData refakatci = new RefakatciData();

                        refakatci.RefaketciAdi = companion.CompanionName;
                        refakatci.RefakatciAdres = companion.CompanionAddress;
                        refakatci.RefaketciCinsiyet = companion.Companionsex;
                        refakatci.RefaketciKalacagiGunSayisi = companion.StayingDateCount;
                        refakatci.Tarih = companion.RequestDate;

                        int birthYear = Convert.ToDateTime(companion.CompanionBirthDate).Year;
                        int patientAge = DateTime.Now.Year - birthYear;

                        refakatci.RefaketciYas = patientAge.ToString();

                        data.Refakatciler.Add(refakatci);

                    }

                    BindingList<EpisodeAction> consFromOtherHospList = EpisodeAction.GetConsFromOtherHospOfSubEpisode(objectContext, subEpisode.ObjectID, episode.ObjectID.ToString());
                    data.Konsultasyonlar = new List<KonsultasyonData>();

                    foreach (EpisodeAction ea in consFromOtherHospList)
                    {
                        if (ea is ConsultationFromOtherHospital && ea.CurrentStateDefID == ConsultationFromOtherHospital.States.Completed)
                        {
                            KonsultasyonData konsultasyon = new KonsultasyonData();
                            ConsultationFromOtherHospital consFromOtherHosp = (ConsultationFromOtherHospital)ea;

                            konsultasyon.KonsultasyonTarihi = ea.ActionDate;
                            if (consFromOtherHosp.RequesterHospital != null)
                                konsultasyon.IstekYapanXXXXXX = consFromOtherHosp.RequesterHospital.Name;
                            konsultasyon.IstekYapanBirim = consFromOtherHosp.RequesterResourceName;
                            if (consFromOtherHosp.RequestedReferableHospital != null && consFromOtherHosp.RequestedReferableHospital.ResOtherHospital != null)
                                konsultasyon.IstekYapilanXXXXXX = consFromOtherHosp.RequestedReferableHospital.ResOtherHospital.Name;
                            else if (consFromOtherHosp.RequestedExternalHospital != null)
                                konsultasyon.IstekYapilanXXXXXX = consFromOtherHosp.RequestedExternalHospital.Name;

                            if (consFromOtherHosp.RequestedReferableResource != null)
                                konsultasyon.IsteKYapilanBirim = consFromOtherHosp.RequestedReferableResource.ResourceName;
                            else if (consFromOtherHosp.RequestedExternalDepartment != null)
                                konsultasyon.IsteKYapilanBirim = consFromOtherHosp.RequestedExternalDepartment.Name;
                            konsultasyon.IstekSebebi = consFromOtherHosp.RequestDescription;
                            if (consFromOtherHosp.ConsultationResultAndOffers != null)
                                konsultasyon.KonsultasyonSonucuveOneriler = consFromOtherHosp.ConsultationResultAndOffers.ToString();

                            data.Konsultasyonlar.Add(konsultasyon);
                        }
                    }

                    Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
                    ResHospital hospital = (ResHospital)objectContext.GetObject(hospID, typeof(ResHospital));
                    BindingList<SubActionProcedure> consProcedureList = SubActionProcedure.GetAllConsultationProcOfSubEpisode(objectContext, episode.ObjectID.ToString(), subEpisode.ObjectID.ToString());

                    foreach (SubActionProcedure spf in consProcedureList)
                    {
                        if (spf is ConsultationProcedure && ((ConsultationProcedure)spf).Consultation.CurrentStateDefID == Consultation.States.Completed)
                        {
                            KonsultasyonData konsultasyon = new KonsultasyonData();
                            konsultasyon.KonsultasyonTarihi = spf.ActionDate;

                            ConsultationProcedure consProcedure = (ConsultationProcedure)spf;
                            if (hospital != null) {
                                konsultasyon.IstekYapanXXXXXX = hospital.Name;
                                konsultasyon.IstekYapilanXXXXXX = hospital.Name;
                            }

                            if (consProcedure.Consultation.RequesterResource != null)
                                konsultasyon.IstekYapanBirim = consProcedure.Consultation.RequesterResource.Name;
                            if (consProcedure.Consultation.MasterResource != null)
                                konsultasyon.IsteKYapilanBirim = consProcedure.Consultation.MasterResource.Name;
                            if (consProcedure.Consultation.RequestDescription != null)
                                konsultasyon.IstekSebebi = consProcedure.Consultation.RequestDescription.ToString();
                            if (consProcedure.Consultation.ConsultationResultAndOffers != null)
                                konsultasyon.KonsultasyonSonucuveOneriler = consProcedure.Consultation.ConsultationResultAndOffers.ToString();

                            data.Konsultasyonlar.Add(konsultasyon);
                        }
                    }


                    BindingList<EpisodeAction> anesthesiaConsList = EpisodeAction.GetAllAnesthesiaConsultationOfSubEpisode(objectContext, subEpisode.ObjectID.ToString(), episode.ObjectID.ToString());
                    foreach (EpisodeAction ea in anesthesiaConsList)
                    {
                        if (ea is AnesthesiaConsultation && ea.CurrentStateDefID == AnesthesiaConsultation.States.Completed)
                        {
                            KonsultasyonData konsultasyon = new KonsultasyonData();
                            konsultasyon.KonsultasyonTarihi = ea.ActionDate;
                            AnesthesiaConsultation anesthesiaConsultation = (AnesthesiaConsultation)ea;

                            if (hospital != null) {
                                konsultasyon.IstekYapanXXXXXX = hospital.Name;
                                konsultasyon.IstekYapilanXXXXXX = hospital.Name;
                            }

                            if (anesthesiaConsultation.FromResource != null)
                                konsultasyon.IstekYapanBirim = anesthesiaConsultation.FromResource.Name;
                            if (anesthesiaConsultation.MasterResource != null)
                                konsultasyon.IsteKYapilanBirim = anesthesiaConsultation.MasterResource.Name;
                            if (anesthesiaConsultation.ConsultationRequestNote != null)
                                konsultasyon.IstekSebebi = anesthesiaConsultation.ConsultationRequestNote.ToString();
                            if (anesthesiaConsultation.ConsultationResult != null)
                                konsultasyon.KonsultasyonSonucuveOneriler = anesthesiaConsultation.ConsultationResult.ToString();

                            data.Konsultasyonlar.Add(konsultasyon);

                        }
                    }

                    BindingList<EpisodeAction> reportList = EpisodeAction.GetAllReportsOfPatient(objectContext, episodeAction.Episode.Patient.ObjectID.ToString());
                    data.HastaRaporlariListesi = new List<PatientReportInfo>();
                    if (reportList.Count > 0)
                    {
                        List<PatientReportInfo> patientReportInfoList = new List<PatientReportInfo>();
                        foreach (EpisodeAction report in reportList)
                        {
                            PatientReportInfo patientReportInfo = new PatientReportInfo();

                            if (report is ParticipatnFreeDrugReport)
                            {
                                patientReportInfo.RaporAdi = ((ParticipatnFreeDrugReport)report).ObjectDef.ApplicationName;
                                patientReportInfo.KabulNo = ((ParticipatnFreeDrugReport)report).SubEpisode.ProtocolNo;
                                patientReportInfo.Açıklama = ((ParticipatnFreeDrugReport)report).Description == null ? "" : ((ParticipatnFreeDrugReport)report).Description.ToString();
                                patientReportInfo.RaporTarihi = ((ParticipatnFreeDrugReport)report).ReportStartDate;
                            }

                            if (report is StatusNotificationReport)
                            {
                                patientReportInfo.RaporAdi = ((StatusNotificationReport)report).ObjectDef.ApplicationName;
                                patientReportInfo.KabulNo = ((StatusNotificationReport)report).SubEpisode.ProtocolNo;
                                patientReportInfo.Açıklama = ((StatusNotificationReport)report).Description == null ? "" : ((StatusNotificationReport)report).Description.ToString();
                                patientReportInfo.RaporTarihi = ((StatusNotificationReport)report).StartDate;

                            }
                            if (report is MedulaTreatmentReport)
                            {
                                patientReportInfo.RaporAdi = ((MedulaTreatmentReport)report).ObjectDef.ApplicationName;
                                patientReportInfo.KabulNo = ((MedulaTreatmentReport)report).SubEpisode.ProtocolNo;
                                patientReportInfo.Açıklama = ((MedulaTreatmentReport)report).Description == null ? "" : ((MedulaTreatmentReport)report).Description.ToString();
                                patientReportInfo.RaporTarihi = ((MedulaTreatmentReport)report).StartDate;
                            }
                            if (report is MedicalStuffReport)
                            {
                                patientReportInfo.RaporAdi = ((MedicalStuffReport)report).ObjectDef.ApplicationName;
                                patientReportInfo.KabulNo = ((MedicalStuffReport)report).SubEpisode.ProtocolNo;
                                patientReportInfo.Açıklama = ((MedicalStuffReport)report).Description == null ? "" : ((MedicalStuffReport)report).Description.ToString();
                                patientReportInfo.RaporTarihi = ((MedicalStuffReport)report).StartDate;

                            }
                            if(patientReportInfo != null)
                                data.HastaRaporlariListesi.Add(patientReportInfo);
                        }
                    }

                }
            }

            return data;
        }
    }
        
        [Serializable]
        public class EpikrizRaporuParameters
        {
            [DataMember]
            public Guid EpicrisisObjectID { get; set; }
        }

    [Serializable]
    public class EpikrizRaporuData
        {
            [DataMember]
            public string HastaAdiSoyadi { get; set; }
            [DataMember]
            public string HastaTC { get; set; }
            [DataMember]
            public string HastaCinsiyet { get; set; }
            [DataMember]
            public string HastaKabulNo { get; set; }
            [DataMember]
            public string HastaDogumYeri { get; set; }
            [DataMember]
            public DateTime? HastaDogumTarihi { get; set; }
            [DataMember]
            public string HastaAdres { get; set; }
            [DataMember]
            public DateTime? HastaYatisTarihi { get; set; }
            [DataMember]
            public DateTime? HastaCikisTarihi { get; set; }
            [DataMember]
            public string YatisIstemYapanDoktor { get; set; }
            [DataMember]
            public string HastaninYattigiBolum { get; set; }
            [DataMember]
            public string KurumAdi { get; set; }
            [DataMember]
            public string Telefon { get; set; }
            [DataMember]
            public List<EpikrizTaniData> Tanilar { get; set; }
            [DataMember]
            public string Yakinmalar { get; set; }
            [DataMember]
            public string Oyku { get; set; }
            [DataMember]
            public string FizikMuayene { get; set; }
            [DataMember]
            public string SaglikKuruluRaporu { get; set; }
            [DataMember]
            public List<RadyolojiTetkikData> RadyolojiTetkikler { get; set; }
            [DataMember]
            public List<PatolojiTetkikData> PatolojiTetkikler { get; set; }
            [DataMember]
            public List<NukleerTipTetkikData> NukleerTipTetkikler { get; set; }
            [DataMember]
            public List<TibbiGenetikTetkikData> TibbiGenetikTetkikler { get; set; }
            [DataMember]
            public List <KlinikIzlemData> KlinikIzlem { get; set; }
            [DataMember]
            public List<AmeliyatveAnesteziData> Ameliyatlar { get; set; }
            [DataMember]
            public List<PlanliTibbiİslemlerData> PlanliTibbiİslemler { get; set; }
            [DataMember]
            public List <TibbiCerrahiUygulamalarData> TibbiCerahiUygulamalar { get; set; }
            [DataMember]
            public List<OrtezProtezData> OrtezProtezIslemleri { get; set; }
            [DataMember]
            public List<TibbiMalzemeData> TibbiMalzemeler { get; set; }
            [DataMember]
            public List<IlacData> Ilaclar { get; set; }
            [DataMember]
            public List<KanUrunleriData> KanUrunleri { get; set; }
            [DataMember]
            public List<HizmetData> Hizmetler { get; set; }
            [DataMember]
            public List<RefakatciData> Refakatciler { get; set; }
            [DataMember]
            public List<KonsultasyonData> Konsultasyonlar { get; set; }
            [DataMember]
            public string IletisimBilgileri { get; set; }
            [DataMember]
            public DateTime? KabulTarihi { get; set; }
            [DataMember]
            public string KabulNo { get; set; }
           [DataMember]
        public string XXXXXXAdi { get; set; }
        [DataMember]
        public DateTime YatisTarihi { get; set; }

        [DataMember]
        public string OzSoyGecmisi { get; set; }
        [DataMember]
        public string Bulgular { get; set; }
        [DataMember]
        public string YapilanTedavi { get; set; }
        [DataMember]
        public string Oneriler { get; set; }
        [DataMember]
        public DateTime? PoliklinikMuayeneTarihi { get; set; }
        [DataMember]
        public string PoliklinikMuayeneKabulNo { get; set; }
        [DataMember]
        public string PoliklinikMuayeneDoktoru { get; set; }
        [DataMember]
        public string Poliklinik { get; set; }
        [DataMember]
        public string YattigiServis { get; set; }
        [DataMember]
        public double YatisGunSayisi { get; set; }
        [DataMember]
        public string YatisDoktoru { get; set; }
        [DataMember]
        public string TaburcuTipi { get; set; }
        [DataMember]
        public List <PatientReportInfo> HastaRaporlariListesi { get; set; }
    }

    [Serializable]

    public class EpikrizTaniData
        {
            [DataMember]
            public string TaniKodu { get; set; }
            [DataMember]
            public string TaniAdi { get; set; }
            [DataMember]
            public DateTime? TaniTarih { get; set; }
        }
    [Serializable]

    public class RadyolojiTetkikData
        {
            [DataMember]
            public string RadyolojiTetkiki { get; set; }
            [DataMember]
            public string RadyolojiTetkikKodu { get; set; }
            [DataMember]
            public DateTime? RadyolojiTetkikTarihi { get; set; }
        }

    [Serializable]

    public class NukleerTipTetkikData
        {
            [DataMember]
            public string NukleerTipTetkiki { get; set; }
            [DataMember]
            public string NukleerTipTetkikKodu { get; set; }
            [DataMember]
            public DateTime? NukleerTipTetkikTarihi { get; set; }
        }

        public class TibbiGenetikTetkikData
        {
            [DataMember]
            public string TibbiGenetikTetkiki { get; set; }
            [DataMember]
            public string TibbiGenetikTetkikKodu { get; set; }
            [DataMember]
            public DateTime? TibbiGenetikTetkikTarihi { get; set; }
        }
    [Serializable]

    public class KlinikIzlemData
        {
            [DataMember]
            public DateTime? KlinikIzlemTarih { get; set; }
            [DataMember]
            public string KlinikIzlemAciklamasi { get; set; }
        }
    [Serializable]

    public class AmeliyatveAnesteziData
        {
            [DataMember]
            public DateTime? AmeliyatTarih { get; set; }
            [DataMember]
            public string AmeliyatAdi { get; set; }
            [DataMember]
            public string AmeliyatKodu { get; set; }
            [DataMember]
            public string AnesteziTuru { get; set; }
            [DataMember]
            public string AnesteziKodu { get; set; }
        }
    [Serializable]

    public class PlanliTibbiİslemlerData
        {
            [DataMember]
            public DateTime? PlanliTibbiİslemTarih { get; set; }
            [DataMember]
            public string PlanliTibbiİslem { get; set; }
            [DataMember]
            public string PlanliTibbiİslemKodu { get; set; }
        }
    [Serializable]

    public class TibbiCerrahiUygulamalarData
        {
            [DataMember]
            public DateTime? TibbiCerrahiUygulamaTarih { get; set; }
            [DataMember]
            public string TibbiCerrahiUygulama { get; set; }
            [DataMember]
            public string TibbiCerrahiUygulamaKodu { get; set; }
        }
    [Serializable]

    public class OrtezProtezData
        {
            [DataMember]
            public DateTime? OrtezProtezIslemiTarih { get; set; }
            [DataMember]
            public string OrtezProtezİslemi { get; set; }
            [DataMember]
            public string OrtezProtezIslemiKodu { get; set; }
        }
    [Serializable]

    public class TibbiMalzemeData
        {
            [DataMember]
            public DateTime? TibbiMalzemeTarih { get; set; }
            [DataMember]
            public string TibbiMalzemeAdi { get; set; }
            [DataMember]
            public string TibbiMalzemeKodu { get; set; }
        }
    [Serializable]

    public class IlacData
        {
            [DataMember]
            public DateTime? IlacTarih { get; set; }
            [DataMember]
            public string IlacAdi { get; set; }
            [DataMember]
            public string IlacKodu { get; set; }
        }
    [Serializable]

    public class KanUrunleriData
        {
            [DataMember]
            public DateTime? KanUrunleriTarih { get; set; }
            [DataMember]
            public string KanUrunleriAdi { get; set; }
            [DataMember]
            public string KanUrunleriKodu { get; set; }
        }
    [Serializable]

    public class HizmetData
        {
            [DataMember]
            public DateTime? HizmetTarih { get; set; }
            [DataMember]
            public string HizmetAdi { get; set; }
            [DataMember]
            public string HizmetKodu { get; set; }

        }
    [Serializable]

    public class RefakatciData
        {
            [DataMember]
            public DateTime? Tarih { get; set; }
            [DataMember]
            public string RefaketciAdi { get; set; }
            [DataMember]
            public string RefaketciYas { get; set; }
            [DataMember]
            public string RefaketciCinsiyet { get; set; }
            [DataMember]
            public int? RefaketciKalacagiGunSayisi { get; set; }
            [DataMember]
            public string RefakatciAdres { get; set; }
        }
    [Serializable]

    public class KonsultasyonData
        {
            [DataMember]
            public DateTime? KonsultasyonTarihi { get; set; }
            [DataMember]
            public string IstekYapanXXXXXX { get; set; }
            [DataMember]
            public string IstekYapanBirim { get; set; }
            [DataMember]
            public string IstekYapilanXXXXXX { get; set; }
            [DataMember]
            public string IsteKYapilanBirim { get; set; }
            [DataMember]
            public string IstekSebebi { get; set; }
            [DataMember]
            public string KonsultasyonSonucuveOneriler { get; set; }
        }

    public class PatientReportInfo
    {
        [DataMember]
        public DateTime? RaporTarihi { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public string Açıklama { get; set; }
        [DataMember]
        public string RaporAdi { get; set; }
    }


    }
