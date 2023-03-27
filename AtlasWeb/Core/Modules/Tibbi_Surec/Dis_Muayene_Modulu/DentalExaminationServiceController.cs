//$83FC78E4
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Collections;
using TTDefinitionManagement;
using static Core.Controllers.OrtodontiFormController;
using TTDataDictionary;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class DentalExaminationServiceController : Controller
    {
        public class GetUnCompletedDentalExams_Input
        {
            public string PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalExamination> GetUnCompletedDentalExams(GetUnCompletedDentalExams_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DentalExamination.GetUnCompletedDentalExams(objectContext, input.PATIENT);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetDentalExamination_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalExamination.OLAP_GetDentalExamination_Class> OLAP_GetDentalExamination(OLAP_GetDentalExamination_Input input)
        {
            var ret = DentalExamination.OLAP_GetDentalExamination(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetCancelledDentalExamination_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalExamination.OLAP_GetCancelledDentalExamination_Class> OLAP_GetCancelledDentalExamination(OLAP_GetCancelledDentalExamination_Input input)
        {
            var ret = DentalExamination.OLAP_GetCancelledDentalExamination(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetExcludesDentalProceduresAreCompleted_Input
        {
            public IList<Guid> STATE
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalExamination> GetExcludesDentalProceduresAreCompleted(GetExcludesDentalProceduresAreCompleted_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DentalExamination.GetExcludesDentalProceduresAreCompleted(objectContext, input.STATE, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public List<ProcedureDefinition> GetDentalProcedures()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                IBindingList dentalProcedures = objectContext.QueryObjects("PROCEDUREDEFINITION", "OBJECTDEFNAME IN ('DENTALPROSTHESISDEFINITION','DENTALTREATMENTDEFINITION') AND ISACTIVE = 1", "NAME");
                List<ProcedureDefinition> ret = new List<ProcedureDefinition>();
                foreach (ProcedureDefinition p in dentalProcedures)
                    ret.Add(p);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class AddDentalProcedures_Input
        {
            public List<string> checkList
            {
                get;
                set;
            }

            public List<ProcedureDefinition> procedureList
            {
                get;
                set;
            }

            public DentalExamination dentalExamination
            {
                get;
                set;
            }
        }

        [HttpPost]
        public List<DentalProcedure> AddDentalProcedures(AddDentalProcedures_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.dentalExamination != null)
                    input.dentalExamination = (TTObjectClasses.DentalExamination)objectContext.AddObject(input.dentalExamination);
                List<DentalProcedure> ret = new List<DentalProcedure>();
                foreach (string tooth in input.checkList)
                {
                    foreach (ProcedureDefinition procedure in input.procedureList)
                    {
                        DentalProcedure dentalPro = new DentalProcedure(objectContext);
                        ProcedureDefinition gProcedure = (ProcedureDefinition)objectContext.GetObject(procedure.ObjectID, typeof(ProcedureDefinition));
                        dentalPro.ProcedureObject = gProcedure;
                        dentalPro.ToothNumber = (ToothNumberEnum)int.Parse(tooth);
                        SubEpisodeProtocol sep = input.dentalExamination.SubEpisode.OpenSubEpisodeProtocol;
                        dentalPro.DentalExamination = input.dentalExamination;
                        double patientPrice = sep.Protocol.GetPrice(gProcedure, input.dentalExamination.Episode.PatientStatus, null, Common.RecTime(), null, input.dentalExamination.Episode.Patient.Age, true);
                        dentalPro.PatientPrice = patientPrice;
                        ret.Add(dentalPro);
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class MustehaklikKontrol_Input
        {
            public DentalProcedure dentalProcedure
            {
                get;
                set;
            }

            public DentalExamination dentalExamination
            {
                get;
                set;
            }

            public ProcedureDefinition procedureDefinition
            {
                get;
                set;
            }
        }

        [HttpPost]
        public AddDentalProcedures_Output MustehaklikKontrol(MustehaklikKontrol_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.dentalExamination != null)
                    input.dentalExamination = (TTObjectClasses.DentalExamination)objectContext.AddObject(input.dentalExamination);
                if (input.procedureDefinition != null)
                    input.procedureDefinition = (TTObjectClasses.ProcedureDefinition)objectContext.GetObject(input.procedureDefinition.ObjectID, typeof(ProcedureDefinition));
                AddDentalProcedures_Output output = fireMustehaklikKontrol(input.dentalProcedure, input.dentalExamination, input.procedureDefinition);
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class AddDentalProcedures_Output
        {
            public bool succsess
            {
                get;
                set;
            }

            public bool isRecourdable
            {
                get;
                set;
            }

            public string errorMessage
            {
                get;
                set;
            }

            public string resultMessage
            {
                get;
                set;
            }
        }

        private AddDentalProcedures_Output fireMustehaklikKontrol(DentalProcedure dentalProcedure, DentalExamination dentalExamination, ProcedureDefinition procedureDefinition)
        {
            AddDentalProcedures_Output output = new AddDentalProcedures_Output();
            output.isRecourdable = false;
            output.succsess = true;
            output.errorMessage = string.Empty;
            output.resultMessage = string.Empty;
            if (dentalExamination.SubEpisode.SGKSEP == null)
                throw new Exception("Medula kaydı olmayanlar hastalarda sorgulama yapılamaz!");

            HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayit = new HizmetKayitIslemleri.hizmetKayitGirisDVO();
            hizmetKayit.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            hizmetKayit.ktsHbysKodu = TTObjectClasses.SystemParameter.GetKtsHbysKodu();
            hizmetKayit.hastaBasvuruNo = dentalExamination.SubEpisode.SGKSEP.MedulaBasvuruNo;
            hizmetKayit.takipNo = dentalExamination.SubEpisode.SGKSEP.MedulaTakipNo;

            HizmetKayitIslemleri.disBilgisiDVO[] disBilgileri = new HizmetKayitIslemleri.disBilgisiDVO[1];
            disBilgileri[0] = getDisBilgisiDVOWithPropertiesSet(dentalProcedure, dentalExamination, procedureDefinition);
            hizmetKayit.disBilgileri = disBilgileri;
            
            Guid? procedureID = dentalExamination.SubactionProcedures[0].ProcedureObject.ObjectID;
            HizmetKayitIslemleri.hizmetKayitCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetKayitSync(TTObjectClasses.Sites.SiteLocalHost, procedureID, hizmetKayit);
            if (result.hataliKayitlar != null)
            {
                string hataMesajlari = "";
                for (int i = 0; i < result.hataliKayitlar.Length; i++)
                {
                    HizmetKayitIslemleri.hataliIslemBilgisiDVO hata = result.hataliKayitlar[i];
                    if (hata != null)
                    {
                        IEnumerator disBilgiEnum = hizmetKayit.disBilgileri.GetEnumerator();
                        while (disBilgiEnum.MoveNext())
                        {
                            HizmetKayitIslemleri.disBilgisiDVO tempDisBilgisi = (HizmetKayitIslemleri.disBilgisiDVO)disBilgiEnum.Current;
                            if (tempDisBilgisi != null && tempDisBilgisi.hizmetSunucuRefNo.Equals(hata.hizmetSunucuRefNo))
                            {
                                hataMesajlari += tempDisBilgisi.sutKodu + " - ";
                                break;
                            }
                        }

                        hataMesajlari += hata.hataKodu + " - " + hata.hataMesaji + " \n";
                    }
                    else
                    {
                        hataMesajlari += result.sonucMesaji + " \n";
                    }
                }

                output.succsess = false;
                output.errorMessage = hataMesajlari;
            }

            if (result.islemBilgileri != null && result.islemBilgileri.Length > 0 && result.islemBilgileri[0] != null)
            {
                HizmetKayitIslemleri.hizmetIptalGirisDVO hizmetIptal = new HizmetKayitIslemleri.hizmetIptalGirisDVO();
                hizmetIptal.saglikTesisKodu = hizmetKayit.saglikTesisKodu;
                hizmetIptal.ktsHbysKodu = TTObjectClasses.SystemParameter.GetKtsHbysKodu();
                hizmetIptal.takipNo = hizmetKayit.takipNo;

                String[] islemNumaralari = new String[result.islemBilgileri.Length];
                hizmetIptal.islemSiraNumaralari = new String[result.islemBilgileri.Length];
                for (int i = 0; i < result.islemBilgileri.Length; i++)
                {
                    hizmetIptal.islemSiraNumaralari[i] = result.islemBilgileri[i].islemSiraNo;
                    if (SubEpisode.IsSGKSubEpisode(dentalExamination.SubEpisode))
                    {
                        output.isRecourdable = true;
                    }
                }

                System.Threading.Thread.Sleep(2000);
                HizmetKayitIslemleri.hizmetIptalCevapDVO iptalResult = HizmetKayitIslemleri.WebMethods.hizmetIptalSync(TTObjectClasses.Sites.SiteLocalHost, hizmetIptal);
                if (!"0000".Equals(iptalResult.sonucKodu))
                {
                    int count = 0;
                    while (count < 3 && !"0000".Equals(iptalResult.sonucKodu))
                    {
                        System.Threading.Thread.Sleep(2000);
                        iptalResult = HizmetKayitIslemleri.WebMethods.hizmetIptalSync(TTObjectClasses.Sites.SiteLocalHost, hizmetIptal);
                        count++;
                    }

                    if (!"0000".Equals(iptalResult.sonucKodu))
                    {
                        String islemNoSilinemeyen = "";
                        for (int i = 0; i < hizmetIptal.islemSiraNumaralari.Length; i++)
                        {
                            islemNoSilinemeyen += hizmetIptal.islemSiraNumaralari[i];
                        }

                        output.resultMessage = islemNoSilinemeyen + " işlem numaralı hizmetler müstehaklık sorgusu sonucunda meduladan silinememiştir. Bu işlem numaralarını Bilgi İşleme acilen bildiriniz!";
                    }
                }
                else
                {
                    output.resultMessage = "Müstehaklık sorgusu başarıyla yapılmış ve bir hata alınmamıştır.";
                }
            }

            return output;
        }

        private HizmetKayitIslemleri.disBilgisiDVO getDisBilgisiDVOWithPropertiesSet(DentalProcedure dentalProcedure, DentalExamination dentalExamination, ProcedureDefinition procedureDefinition)
        {
            String disNo = null;
            String pozisyon = null;
            //String disSema = null;
            String durum = null;
            String ayniFarkliKesi = null;
            String disTaahhutNo = null;
            String anomali = null;
            //String anesteziDrTescilNo = null;
            String ozelDurum = null;
            String cokluOzelDurum = null;
            ProcedureDefinition procedure = procedureDefinition;
            if (dentalProcedure.ToothNumber != null)
                disNo = ((int)dentalProcedure.ToothNumber).ToString();
            //  if (row.Cells[3] != null && row.Cells[3].Value != null)
            durum = TTUtils.CultureService.GetText("M24515", "Yeni");
            if (dentalProcedure.AyniFarkliKesi != null)
                ayniFarkliKesi = dentalProcedure.AyniFarkliKesi.ToString();
            if (dentalProcedure.Anomali != null)
                anomali = dentalProcedure.Anomali.ToString();
            if (dentalProcedure.OzelDurum != null)
                ozelDurum = dentalProcedure.OzelDurum.ToString();
            /*if (row.Cells[9] != null && row.Cells[9].Value != null)
                cokluOzelDurum = row.Cells[9].Value.ToString();*/
            HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO = new HizmetKayitIslemleri.disBilgisiDVO();
            String bransKodu = null;
            if (dentalExamination.GetType() == typeof(TTObjectClasses.DentalConsultation))
            {
                DentalExamination dentalExamCons = ((TTObjectClasses.DentalConsultation)(dentalExamination)).DentalExamination_Cons;
                if (dentalExamCons != null && dentalExamCons.DentalConsultationRequest != null && dentalExamCons.DentalConsultationRequest.Count > 0 && dentalExamCons.DentalConsultationRequest[0] != null)
                {
                    ResPoliclinic polic = dentalExamCons.DentalConsultationRequest[0].ConsultationDepartment;
                    if (polic != null && polic.Brans != null && polic.Brans.Code != null)
                    {
                        bransKodu = polic.Brans.Code;
                    }
                }
            }

            if (bransKodu == null && dentalExamination.Episode.MainSpeciality != null)
                bransKodu = dentalExamination.Episode.MainSpeciality.Code;
            if (bransKodu != null)
                disBilgisiDVO.bransKodu = bransKodu;
            if (dentalExamination.ProcedureDoctor != null)
                disBilgisiDVO.drTescilNo = dentalExamination.ProcedureDoctor.DiplomaRegisterNo;
            if (string.IsNullOrEmpty(disBilgisiDVO.drTescilNo))
                disBilgisiDVO.drTescilNo = Common.GetDoctorRegisterNoByBranchCode(disBilgisiDVO.bransKodu);
            if (anomali != null && anomali.Equals(true))
            {
                disBilgisiDVO.anomali = "E";
            }
            else if (anomali != null && anomali.Equals(false))
            {
                disBilgisiDVO.anomali = "H";
            }
            else
            {
                disBilgisiDVO.anomali = "H";
            }

            disBilgisiDVO.adet = 1;
            //disBilgisiDVO.adetSpecified = true;
            disBilgisiDVO.hizmetSunucuRefNo = Guid.NewGuid().ToString().Substring(0, 20);
            disBilgisiDVO.islemTarihi = Common.RecTime().ToString("dd.MM.yyyy");
            List<int> listEriskin = new List<int>();
            List<int> listSut = new List<int>();
            List<int> listAnomali = new List<int>();
            List<int> listCene = new List<int>();
            if (Convert.ToInt32(disNo) >= 11 && Convert.ToInt32(disNo) <= 48)
                listEriskin.Add(Convert.ToInt32(disNo));
            else if (Convert.ToInt32(disNo) >= 51 && Convert.ToInt32(disNo) <= 85)
                listSut.Add(Convert.ToInt32(disNo));
            else if (Convert.ToInt32(disNo) >= 91 && Convert.ToInt32(disNo) <= 94)
                listAnomali.Add(Convert.ToInt32(disNo));
            else if (Convert.ToInt32(disNo) >= 1 && Convert.ToInt32(disNo) <= 7)
                listCene.Add(Convert.ToInt32(disNo));
            setEriskinDisler(listEriskin.ToArray(), disBilgisiDVO);
            setSutDisler(listSut.ToArray(), disBilgisiDVO);
            setAnomaliDisler(listAnomali.ToArray(), disBilgisiDVO);
            setCeneDisler(listCene.ToArray(), disBilgisiDVO);
            disBilgisiDVO.sutKodu = procedure.MySUTCode;
            if (ayniFarkliKesi != null)
                disBilgisiDVO.ayniFarkliKesi = ayniFarkliKesi;
            else
                disBilgisiDVO.ayniFarkliKesi = null;
            if (ozelDurum != null)
            {
                OzelDurum ozelDurumObj = dentalExamination.ObjectContext.GetObject(Guid.Parse(ozelDurum), typeof(OzelDurum).Name) as OzelDurum;
                disBilgisiDVO.ozelDurum = ozelDurumObj.ozelDurumKodu;
            }
            else
                disBilgisiDVO.ozelDurum = null;
            if (disTaahhutNo != null)
                disBilgisiDVO.disTaahhutNo = Convert.ToInt32(disTaahhutNo);
            else
                disBilgisiDVO.disTaahhutNo = null;
            //disBilgisiDVO.disTaahhutNoSpecified = true;
            if (cokluOzelDurum != null)
            {
                List<String> listCokluOzelDurum = new List<String>();
                String[] cokluOzelDurumArr = cokluOzelDurum.Split(';');
                disBilgisiDVO.cokluOzelDurum = cokluOzelDurumArr;
            }
            else
                disBilgisiDVO.cokluOzelDurum = null;
            /*if (this._DentalExamination.ResUser != null && this._DentalExamination.ResUser.DiplomaRegisterNo != null)
                disBilgisiDVO.drAnesteziTescilNo = this._DentalExamination.ResUser.DiplomaRegisterNo.ToString();
            else
                disBilgisiDVO.drAnesteziTescilNo = null;*/
            return disBilgisiDVO;
        }

        public void setEriskinDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] eDis = new String[32];
            disBilgisiDVO.sagUstCene = "";
            disBilgisiDVO.solUstCene = "";
            disBilgisiDVO.solAltCene = "";
            disBilgisiDVO.sagAltCene = "";
            for (int i = 0; i < eDis.Length; i++)
                eDis[i] = "_";
            for (int j = 0; j < str.Length; j++)
            {
                for (int k = 11, l = 0; k <= eDis.Length + 16 && l < eDis.Length; k++, l++)
                {
                    if (k == 18 || k == 28 || k == 38 || k == 48)
                    {
                        if (str[j] == k)
                        {
                            eDis[l] = "E";
                            break;
                        }

                        k = k + 2;
                    }
                    else
                    {
                        if (str[j] == k)
                        {
                            eDis[l] = "E";
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < eDis.Length; i++)
            {
                if (i >= 0 && i < 8)
                    disBilgisiDVO.sagUstCene = disBilgisiDVO.sagUstCene + eDis[i];
                if (i >= 8 && i < 16)
                    disBilgisiDVO.solUstCene = disBilgisiDVO.solUstCene + eDis[i];
                if (i >= 16 && i < 24)
                    disBilgisiDVO.solAltCene = disBilgisiDVO.solAltCene + eDis[i];
                if (i >= 24 && i < 32)
                    disBilgisiDVO.sagAltCene = disBilgisiDVO.sagAltCene + eDis[i];
            }
        }

        //Tuğba:  Süt dişlerin string scheması oluşturulur.
        public void setSutDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] sDis = new String[20];
            disBilgisiDVO.sagSutUstCene = "";
            disBilgisiDVO.solSutUstCene = "";
            disBilgisiDVO.solSutAltCene = "";
            disBilgisiDVO.sagSutAltCene = "";
            for (int i = 0; i < sDis.Length; i++)
                sDis[i] = "_";
            for (int j = 0; j < str.Length; j++)
            {
                for (int k = 51, l = 0; k <= sDis.Length + 65 && l < sDis.Length; k++, l++)
                {
                    if (k == 55 || k == 65 || k == 75 || k == 85)
                    {
                        if (str[j] == k)
                        {
                            sDis[l] = "E";
                            break;
                        }

                        k = k + 5;
                    }
                    else
                    {
                        if (str[j] == k)
                        {
                            sDis[l] = "E";
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < sDis.Length; i++)
            {
                if (i >= 0 && i < 5)
                    disBilgisiDVO.sagSutUstCene = disBilgisiDVO.sagSutUstCene + sDis[i];
                if (i >= 5 && i < 10)
                    disBilgisiDVO.solSutUstCene = disBilgisiDVO.solSutUstCene + sDis[i];
                if (i >= 10 && i < 15)
                    disBilgisiDVO.solSutAltCene = disBilgisiDVO.solSutAltCene + sDis[i];
                if (i >= 15 && i < 20)
                    disBilgisiDVO.sagSutAltCene = disBilgisiDVO.sagSutAltCene + sDis[i];
            }
        }

        //Tuğba:  Anomalili dişlerin string scheması oluşturulur.
        public void setAnomaliDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] aDis = new String[4];
            disBilgisiDVO.sagUstCeneAnomaliDis = ""; //91
            disBilgisiDVO.solUstCeneAnomaliDis = ""; //92
            disBilgisiDVO.sagAltCeneAnomaliDis = ""; //93
            disBilgisiDVO.solAltCeneAnomaliDis = ""; //94
            for (int i = 0; i < aDis.Length; i++)
                aDis[i] = "_";
            for (int j = 0; j < str.Length; j++)
                for (int k = 91, l = 0; k <= aDis.Length + 90 && l < aDis.Length; k++, l++)
                {
                    if (str[j] == k)
                    {
                        aDis[l] = "E";
                        break;
                    }
                }

            disBilgisiDVO.sagUstCeneAnomaliDis = aDis[0];
            disBilgisiDVO.solUstCeneAnomaliDis = aDis[1];
            disBilgisiDVO.sagAltCeneAnomaliDis = aDis[2];
            disBilgisiDVO.solAltCeneAnomaliDis = aDis[3];
        }

        //Tuğba: Tüm,sağ,sol,üst,alt çene string scheması oluşturulur.
        public void setCeneDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == 1)
                { //Tüm Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }

                if (str[j] == 2)
                { //Üst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }

                if (str[j] == 3)
                { //Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }

                if (str[j] == 4)
                { //Sağ Üst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }

                if (str[j] == 5)
                { //Sol Üst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }

                if (str[j] == 6)
                { //Sağ Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }

                if (str[j] == 7)
                { //Sol Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "________";
                }
            }
        }

        public class GetDepartment_Input
        {
            public DentalProsthesisDefinition dentalProsthesisDefinition
            {
                get;
                set;
            }
        }

        [HttpPost]
        public GetDepartment_Output GetDepartment(GetDepartment_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.dentalProsthesisDefinition != null)
                    input.dentalProsthesisDefinition = (TTObjectClasses.DentalProsthesisDefinition)objectContext.AddObject(input.dentalProsthesisDefinition);
                GetDepartment_Output output = new GetDepartment_Output();
                if (input.dentalProsthesisDefinition.Departments.Count > 0)
                {
                    output.department = input.dentalProsthesisDefinition.Departments[0].Department;
                }

                output.actionDate = Common.RecTime();
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class GetDepartment_Output
        {
            public DateTime actionDate
            {
                get;
                set;
            }

            public ResSection department
            {
                get;
                set;
            }
        }

        public class SaveOrtodontiForm_Input
        {
            public Patient patient
            {
                get;
                set;
            }

            public TedaviRaporiIslemKodlari tedaviRaporiIslemKodlari
            {
                get;
                set;
            }

            public DateTime reportTime
            {
                get;
                set;
            }

            public string txtFormNumarasi
            {
                get;
                set;
            }

            public ActiveMedulaProvision activeMedulaProvision
            {
                get;
                set;
            }
        }

        public class SaveOrtodontiFormOutputDVO
        {
            public string txtFormNumarasi
            {
                get;
                set;
            }

            public string txtSonucMesaji
            {
                get;
                set;
            }

            public string txtSonucKodu
            {
                get;
                set;
            }
        }

        [HttpPost]
        public SaveOrtodontiFormOutputDVO SaveOrtodontiForm(SaveOrtodontiForm_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                SaveOrtodontiFormOutputDVO output = new SaveOrtodontiFormOutputDVO();
                OrtodontiIslemleri.ortodontiFormuKaydetGirisDVO _ortodontiFormuKaydetGirisDVO = new OrtodontiIslemleri.ortodontiFormuKaydetGirisDVO();
                TedaviRaporiIslemKodlari sut = input.tedaviRaporiIslemKodlari; //(SUTDefinition)((TTListBox)this.lstSUTKodu).SelectedObject;
                _ortodontiFormuKaydetGirisDVO.sutKodu = sut.TedaviRaporuIslemKodu;
                _ortodontiFormuKaydetGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _ortodontiFormuKaydetGirisDVO.islemTarihi = Convert.ToDateTime(input.reportTime).ToString("dd.MM.yyyy");
                _ortodontiFormuKaydetGirisDVO.tcKimlikNo = input.patient.UniqueRefNo.ToString();
                if (string.IsNullOrEmpty(input.txtFormNumarasi))
                    _ortodontiFormuKaydetGirisDVO.formNo = "0";
                else
                    _ortodontiFormuKaydetGirisDVO.formNo = input.txtFormNumarasi;
                if (input.activeMedulaProvision != null)
                {
                    _ortodontiFormuKaydetGirisDVO.provizyonNo = input.activeMedulaProvision.BarsvuruNo;
                }
                else
                {
                    _ortodontiFormuKaydetGirisDVO.provizyonNo = string.Empty;
                }

                OrtodontiIslemleri.ortodontiFormuKaydetCevapDVO response = OrtodontiIslemleri.WebMethods.ortodontiFormuKaydetSync(Sites.SiteLocalHost, _ortodontiFormuKaydetGirisDVO);
                if (response != null)
                {
                    if (response.sonucKodu == "0000")
                    {
                        output.txtFormNumarasi = response.formNo.ToString();
                        output.txtSonucMesaji = response.sonucMesaji;
                        output.txtSonucKodu = response.sonucKodu;
                    }
                    else
                    {
                        output.txtFormNumarasi = "";
                        output.txtSonucMesaji = response.sonucMesaji;
                        output.txtSonucKodu = response.sonucKodu;
                    }

                    output.txtSonucMesaji = response.sonucMesaji;
                }

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class ReadOrtodontiForm_Input
        {
            public Patient patient
            {
                get;
                set;
            }

            public TedaviRaporiIslemKodlari tedaviRaporiIslemKodlari
            {
                get;
                set;
            }

            public string txtFormNumarasi
            {
                get;
                set;
            }
        }

        public class ReadOrtodontiFormOutputDVO
        {
            public string txtFormNumarasi
            {
                get;
                set;
            }

            public string txtIslemTuru
            {
                get;
                set;
            }

            public string txtSonucKodu
            {
                get;
                set;
            }

            public string txtSonucMesaji
            {
                get;
                set;
            }

            public string txtProvizyonNo1
            {
                get;
                set;
            }

            public DateTime IslemTarihi1
            {
                get;
                set;
            }

            public string txtTesis1
            {
                get;
                set;
            }

            public string txtProvizyonNo2
            {
                get;
                set;
            }

            public DateTime IslemTarihi2
            {
                get;
                set;
            }

            public string txtTesis2
            {
                get;
                set;
            }

            public string txtProvizyonNo3
            {
                get;
                set;
            }

            public DateTime IslemTarihi3
            {
                get;
                set;
            }

            public string txtTesis3
            {
                get;
                set;
            }
        }

        [HttpPost]
        public ReadOrtodontiFormOutputDVO ReadOrtodontiForm(ReadOrtodontiForm_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ReadOrtodontiFormOutputDVO output = new ReadOrtodontiFormOutputDVO();
                OrtodontiIslemleri.ortodontiFormuOkuGirisDVO _ortodontiFormuOkuGirisDVO = new OrtodontiIslemleri.ortodontiFormuOkuGirisDVO();
                TedaviRaporiIslemKodlari sut = input.tedaviRaporiIslemKodlari;
                _ortodontiFormuOkuGirisDVO.sutKodu = sut.TedaviRaporuIslemKodu;
                _ortodontiFormuOkuGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _ortodontiFormuOkuGirisDVO.tcKimlikNo = input.patient.UniqueRefNo.ToString();
                if (string.IsNullOrEmpty(input.txtFormNumarasi))
                    _ortodontiFormuOkuGirisDVO.formNo = "0";
                else
                    _ortodontiFormuOkuGirisDVO.formNo = input.txtFormNumarasi;
                OrtodontiIslemleri.ortodontiFormuOkuCevapDVO response = OrtodontiIslemleri.WebMethods.ortodontiFormuOkuSync(Sites.SiteLocalHost, _ortodontiFormuOkuGirisDVO);
                if (response != null)
                {
                    if (response.sonucKodu == "0000")
                    {
                        output.txtFormNumarasi = response.formNo.ToString();
                        output.txtIslemTuru = response.islemTuru;
                        output.txtSonucKodu = response.sonucKodu;
                        output.txtSonucMesaji = response.sonucMesaji;
                        output.txtProvizyonNo1 = response.provizyonNo1;
                        if (response.islem_tarihi_1 != null || response.islem_tarihi_1 != "null")
                            output.IslemTarihi1 = Convert.ToDateTime(response.islem_tarihi_1);
                        if (response.tesis_kodu_1 != 0)
                        {
                            string tesisAdi = Common.GetSaglikTesisleri(response.tesis_kodu_1.ToString());
                            if (string.IsNullOrEmpty(tesisAdi) == false)
                                output.txtTesis1 = tesisAdi;
                        }

                        output.txtProvizyonNo2 = response.provizyonNo2;
                        if (response.islem_tarihi_2 != null || response.islem_tarihi_2 != "null")
                            output.IslemTarihi2 = Convert.ToDateTime(response.islem_tarihi_2);
                        if (response.tesis_kodu_2 != 0)
                        {
                            string tesisAdi = Common.GetSaglikTesisleri(response.tesis_kodu_2.ToString());
                            if (string.IsNullOrEmpty(tesisAdi) == false)
                                output.txtTesis2 = tesisAdi;
                        }

                        output.txtProvizyonNo3 = response.provizyonNo3;
                        if (response.islem_tarihi_3 != null || response.islem_tarihi_3 != "null")
                            output.IslemTarihi3 = Convert.ToDateTime(response.islem_tarihi_3);
                        if (response.tesis_kodu_3 != 0)
                        {
                            string tesisAdi = Common.GetSaglikTesisleri(response.tesis_kodu_3.ToString());
                            if (string.IsNullOrEmpty(tesisAdi) == false)
                                output.txtTesis3 = tesisAdi;
                        }
                    }
                    else
                    {
                        output.txtSonucMesaji = response.sonucMesaji;
                        output.txtSonucKodu = response.sonucKodu;
                        output.txtProvizyonNo1 = "";
                        output.txtTesis1 = "";
                        output.txtProvizyonNo2 = "";
                        output.txtTesis2 = "";
                        output.txtProvizyonNo3 = "";
                        output.txtTesis3 = "";
                    }

                    output.txtSonucMesaji = response.sonucMesaji;
                }

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public ReadOrtodontiFormOutputDVO DeleteOrtodontiForm(ReadOrtodontiForm_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ReadOrtodontiFormOutputDVO output = new ReadOrtodontiFormOutputDVO();
                OrtodontiIslemleri.ortodontiFormuIptalGirisDVO _ortodontiFormuIptalGirisDVO = new OrtodontiIslemleri.ortodontiFormuIptalGirisDVO();
                TedaviRaporiIslemKodlari sut = input.tedaviRaporiIslemKodlari;
                _ortodontiFormuIptalGirisDVO.sutKodu = sut.TedaviRaporuIslemKodu;
                _ortodontiFormuIptalGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _ortodontiFormuIptalGirisDVO.tcKimlikNo = input.patient.UniqueRefNo.ToString();
                ;
                if (string.IsNullOrEmpty(input.txtFormNumarasi))
                    _ortodontiFormuIptalGirisDVO.formNo = "0";
                else
                    _ortodontiFormuIptalGirisDVO.formNo = input.txtFormNumarasi;
                OrtodontiIslemleri.ortodontiFormuIptalCevapDVO response = OrtodontiIslemleri.WebMethods.ortodontiFormuIptalSync(Sites.SiteLocalHost, _ortodontiFormuIptalGirisDVO);
                if (response != null)
                {
                    if (response.sonucKodu == "0000")
                    {
                        output.txtFormNumarasi = response.formNo.ToString();
                        output.txtSonucMesaji = response.sonucMesaji;
                        output.txtSonucKodu = response.sonucKodu;
                        output.txtProvizyonNo1 = "";
                        output.txtTesis1 = "";
                        output.txtProvizyonNo2 = "";
                        output.txtTesis2 = "";
                        output.txtProvizyonNo3 = "";
                        output.txtTesis3 = "";
                    }
                    else
                    {
                        output.txtSonucMesaji = response.sonucMesaji;
                        output.txtSonucKodu = response.sonucKodu;
                        output.txtProvizyonNo1 = "";
                        output.txtTesis1 = "";
                        output.txtProvizyonNo2 = "";
                        output.txtTesis2 = "";
                        output.txtProvizyonNo3 = "";
                        output.txtTesis3 = "";
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class CalcPatientPrice_Input
        {
            public DentalProcedure dentalProcedure
            {
                get;
                set;
            }

            public DentalExamination dentalExamination
            {
                get;
                set;
            }

            public ProcedureDefinition procedureDefinition
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Dis_Muayene_Muayene, TTRoleNames.Dis_Muayene_Gorme, TTRoleNames.Dis_Muayene_Tamamlandi, TTRoleNames.SorumluDoktorTamamlanmisIslemGorme, TTRoleNames.Dis_Muayene_Iptal)]
        public CalcPatientPrice_Output CalcPatientPrice(CalcPatientPrice_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                CalcPatientPrice_Output output = new CalcPatientPrice_Output();

                DentalExamination de = objectContext.GetObject<DentalExamination>(input.dentalExamination.ObjectID);
                ProcedureDefinition procedure = objectContext.GetObject<ProcedureDefinition>(input.procedureDefinition.ObjectID);
                SubEpisodeProtocol sep = de.SubEpisode.OpenSubEpisodeProtocol;

                if (input.dentalProcedure.PatientPay == true)
                {
                    IList pricingListDefinitions = null;
                    ArrayList pricingDetailList = new ArrayList();

                    pricingListDefinitions = PricingListDefinition.GetByCode(objectContext, "4");

                    if (pricingListDefinitions.Count > 0)
                    {
                        PricingListDefinition pld = (PricingListDefinition)pricingListDefinitions[0];
                        pricingDetailList = procedure.GetProcedurePricingDetail(pld, DateTime.Now);

                        if (pricingDetailList.Count > 0)
                            output.patientPrice = (Currency)((PricingDetailDefinition)pricingDetailList[0]).Price;
                        else
                        {
                            double patientPrice = sep.Protocol.GetPrice(procedure, de.Episode.PatientStatus, null, Common.RecTime(), null, de.Episode.Patient.Age, false);
                            output.patientPrice = (Currency)(patientPrice * 1.5);
                        }
                    }
                }
                else
                    output.patientPrice = sep.Protocol.GetPrice(procedure, de.Episode.PatientStatus, null, Common.RecTime(), null, de.Episode.Patient.Age, true);

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class Paid_Input
        {
            public System.Guid dentalExaminationId
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Dis_Muayene_Muayene, TTRoleNames.Dis_Muayene_Gorme, TTRoleNames.Dis_Muayene_Tamamlandi, TTRoleNames.SorumluDoktorTamamlanmisIslemGorme, TTRoleNames.Dis_Muayene_Iptal)]
        public string Paid(Paid_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                DentalExamination dentalExamination = objectContext.GetObject<DentalExamination>(input.dentalExaminationId);
                if (dentalExamination != null && !dentalExamination.Paid())
                    return SystemMessage.GetMessage(141);

                return string.Empty;
            }
        }
    }

    public class CalcPatientPrice_Output
    {
        public Currency patientPrice
        {
            get;
            set;
        }
    }
}
