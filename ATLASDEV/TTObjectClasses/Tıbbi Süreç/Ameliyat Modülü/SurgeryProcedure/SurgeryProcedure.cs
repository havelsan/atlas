
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
    /// Ameliyat Kategorisi
    /// </summary>
    public partial class SurgeryProcedure : BaseSurgeryProcedure
    {
        public partial class GetSurgeryProceduresByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetSurgeryProceduresBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledSurgeryProcedure_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetSurgeryProcedures_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetSurgeryCountByPatient_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetSurgeryCountBySUTCode_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_Ameliyat_Class : TTReportNqlObject
        {
        }

        public partial class GetSurgeryPersonnelBySurgery_Class : TTReportNqlObject
        {
        }

        /// <summary>
        /// Medula için sağ sol bilgisi
        /// </summary>
        public string MedulaSagSol
        {
            get
            {
                try
                {
                    #region MedulaSagSol_GetScript                   
                    if (Position != null) 
                    {
                        if (Position == SurgeryLeftRight.Right)
                            return "1";
                        else if (Position == SurgeryLeftRight.Left)
                            return "2";
                        else if (Position == SurgeryLeftRight.AllTheSame)
                            return "3";
                    }

                    return null;
                    #endregion MedulaSagSol_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MedulaSagSol") + " : " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Medula için ameliyatın kesi bilgisi
        /// </summary>
        public string MedulaKesi
        {
            get
            {
                try
                {
                    #region MedulaKesi_GetScript                    
                    /*
                 1 Aynı seans + aynı kesi
                 2 Farklı seans + farklı kesi
                 3 Aynı seansta + farklı kesi
                 4 Aynı seansta + farklı kesi + farklı klinik kod
                 5 Aynı seansta + aynı kesi + farklı klinik kod

                 Ameliyatları hep içinde bulundukları action daki ameliyatlar ile karşılaştırıp kesi bilgisine ulaştığımız için
                 hiç (2 Farklı seans + farklı kesi) göndermiyoruz Medulaya. 1, 3, 4 ve 5 gönderiyoruz.
                 */

                    SurgeryProcedure bigSurgeryProcedure = null;
                    double bigSurgeryPoint = 0;

                    foreach (SurgeryProcedure sp in Surgery.SurgeryProcedures)
                    {
                        //if (sp.ProcedureObject.GetSUTPoint() != null)
                        {
                            if ((double)sp.ProcedureObject.GetSUTPoint() > bigSurgeryPoint)
                            {
                                bigSurgeryProcedure = sp;
                                bigSurgeryPoint = (double)sp.ProcedureObject.GetSUTPoint();
                            }
                        }
                    }

                    if (bigSurgeryProcedure != null)
                    {
                        if (ObjectID.Equals(bigSurgeryProcedure.ObjectID))
                            return null;
                        else
                        {
                            SpecialityDefinition thisSpeciality = new SpecialityDefinition();
                            SpecialityDefinition bigSpeciality = new SpecialityDefinition();

                            // bu SurgeryProcedure in klinik kodu bulunur
                            if (this is MainSurgeryProcedure)
                                thisSpeciality = ((MainSurgeryProcedure)this).MainSurgery.ProcedureSpeciality;
                            else if (this is SubSurgeryProcedure)
                                thisSpeciality = ((SubSurgeryProcedure)this).SubSurgery.ProcedureSpeciality;
                            else
                                thisSpeciality = null;

                            // en büyük puanlı SurgeryProcedure in klinik kodu bulunur
                            if (bigSurgeryProcedure is MainSurgeryProcedure)
                                bigSpeciality = ((MainSurgeryProcedure)bigSurgeryProcedure).MainSurgery.ProcedureSpeciality;
                            else if (bigSurgeryProcedure is SubSurgeryProcedure)
                                bigSpeciality = ((SubSurgeryProcedure)bigSurgeryProcedure).SubSurgery.ProcedureSpeciality;
                            else
                                bigSpeciality = null;

                            if (IncisionType == bigSurgeryProcedure.IncisionType)   // Aynı Kesi
                            {
                                if (thisSpeciality != null && bigSpeciality != null && thisSpeciality.ObjectID.Equals(bigSpeciality.ObjectID))
                                    return "1";    // Aynı seans + Aynı Kesi
                                else
                                    return "5";    // Aynı seans + Aynı Kesi + Farklı Klinik Kod
                            }
                            else   // Farklı Kesi
                            {
                                if (thisSpeciality != null && bigSpeciality != null && thisSpeciality.ObjectID.Equals(bigSpeciality.ObjectID))
                                    return "3";    // Aynı seans + Farklı Kesi
                                else
                                    return "4";    // Aynı seans + Farklı Kesi + Farklı Klinik Kod
                            }
                        }
                    }

                    return null;
                    #endregion MedulaKesi_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MedulaKesi") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            if (IsOldAction != true) // aktarılan bazı işlemler SUTle eşleşmemiş olabilir
            {
                if (SutPoint == null)
                {
                    SutPoint = ProcedureObject.GetSUTPoint();
                }
            }

            #endregion PreInsert
        }

        #region Methods

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (Department != null) // Ameliyatı gerçekleştiren birim koduna bakılır
            {
                foreach (ResourceSpecialityGrid resSpeciality in Department.ResourceSpecialities)
                {
                    if (resSpeciality.Speciality != null)
                        return resSpeciality.Speciality.Code;
                }
            }

            return null;
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (Surgery != null && Surgery.SurgeryReport != null)
            {
                string rtfReport = Common.GetTextOfRTFString(Surgery.SurgeryReport.ToString());
                if (!string.IsNullOrEmpty(rtfReport))
                {
                    if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.tetkikveRadyolojiBilgileri)
                    {
                        if (rtfReport.Length > 199) // açıklama max 200 karakter olabiliyor
                            return rtfReport.Substring(0, 199);
                    }
                    else if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
                    {
                        if (rtfReport.Length > 254) // açıklama max 254 karakter olabiliyor
                            return rtfReport.Substring(0, 254);
                    }

                    return rtfReport;
                }
            }

            return null;
        }

        public override string GetDVOAyniFarkliKesi(object DVO)
        {
            return AyniFarkliKesi?.ayniFarkliKesiKodu;
        }

        public override string GetDVOSagSol()
        {
            if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri) 
                return MedulaSagSol;

            return MedulaSagSol_LR(Position); 
        }

        public override string GetDVOEuroscore()
        {
            return MedulaEuroScore;
        }

        public override string GetDVOAnomali()
        {
            return ToothAnomaly == true ? "E" : "H";
        }

        public override int? GetDVODisTaahhutNo()
        {
            return ToothCommitmentNumber;
        }

        public override void GetDVOSetCeneBilgisi(HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            if (!string.IsNullOrEmpty(ToothNumber))
            {
                List<int> listEriskin = new List<int>();
                List<int> listSut = new List<int>();
                List<int> listAnomali = new List<int>();
                List<int> listCene = new List<int>();

                string[] toothNumbers = ToothNumber.Split(',');
                foreach (string toothNumber in toothNumbers)
                {
                    if (Convert.ToInt32(toothNumber) >= 11 && Convert.ToInt32(toothNumber) <= 48)
                        listEriskin.Add(Convert.ToInt32(toothNumber));
                    else if (Convert.ToInt32(toothNumber) >= 51 && Convert.ToInt32(toothNumber) <= 85)
                        listSut.Add(Convert.ToInt32(toothNumber));
                    else if (Convert.ToInt32(toothNumber) >= 91 && Convert.ToInt32(toothNumber) <= 94)
                        listAnomali.Add(Convert.ToInt32(toothNumber));
                    else if (Convert.ToInt32(toothNumber) >= 1 && Convert.ToInt32(toothNumber) <= 7)
                        listCene.Add(Convert.ToInt32(toothNumber));
                }

                setEriskinDisler(listEriskin.ToArray(), disBilgisiDVO);
                setSutDisler(listSut.ToArray(), disBilgisiDVO);
                setAnomaliDisler(listAnomali.ToArray(), disBilgisiDVO);
                setCeneDisler(listCene.ToArray(), disBilgisiDVO);
            }
        }

        public void SetMedulaAyniFarkliKesi()
        {
            /*
                 1 Aynı seans + aynı kesi
                 2 Farklı seans + farklı kesi
                 3 Aynı seansta + farklı kesi
                 4 Aynı seansta + farklı kesi + farklı klinik kod
                 5 Aynı seansta + aynı kesi + farklı klinik kod

                 Ameliyatları hep içinde bulundukları action daki ameliyatlar ile karşılaştırıp kesi bilgisine ulaştığımız için
                 hiç (2 Farklı seans + farklı kesi) göndermiyoruz Medulaya. 1, 3, 4 ve 5 gönderiyoruz.
             */
            AyniFarkliKesi = null;

            SurgeryProcedure bigSurgeryProcedure = null;
            double bigSurgeryPoint = 0;
            bool procedureObjectNotFound = false;

            foreach (SurgeryProcedure sp in Surgery.SurgeryProcedures)
            {
                if (sp.ProcedureObject != null)
                {
                    //                    if (sp.ProcedureObject.GetSUTPoint() != null)
                    {
                        if ((double)sp.ProcedureObject.GetSUTPoint() > bigSurgeryPoint)
                        {
                            bigSurgeryProcedure = sp;
                            bigSurgeryPoint = (double)sp.ProcedureObject.GetSUTPoint();
                        }
                    }
                }
                else
                {
                    procedureObjectNotFound = true;
                    break;
                }
            }

            if (bigSurgeryProcedure != null && procedureObjectNotFound == false)
            {
                // En büyük puanlı ameliyatın AyniFarkliKesi bilgisi null olmalı
                if (!ObjectID.Equals(bigSurgeryProcedure.ObjectID))
                {
                    SpecialityDefinition thisSpeciality = null;
                    SpecialityDefinition bigSpeciality = null;

                    // bu SurgeryProcedure in klinik kodu bulunur
                    if (this is MainSurgeryProcedure)
                        thisSpeciality = ((MainSurgeryProcedure)this).MainSurgery.ProcedureSpeciality;
                    else if (this is SubSurgeryProcedure)
                        thisSpeciality = ((SubSurgeryProcedure)this).SubSurgery.ProcedureSpeciality;
                    else
                        thisSpeciality = null;

                    // en büyük puanlı SurgeryProcedure in klinik kodu bulunur
                    if (bigSurgeryProcedure is MainSurgeryProcedure)
                        bigSpeciality = ((MainSurgeryProcedure)bigSurgeryProcedure).MainSurgery.ProcedureSpeciality;
                    else if (bigSurgeryProcedure is SubSurgeryProcedure)
                        bigSpeciality = ((SubSurgeryProcedure)bigSurgeryProcedure).SubSurgery.ProcedureSpeciality;
                    else
                        bigSpeciality = null;

                    if (IncisionType == bigSurgeryProcedure.IncisionType)   // Aynı Kesi
                    {
                        if (thisSpeciality != null && bigSpeciality != null && thisSpeciality.ObjectID.Equals(bigSpeciality.ObjectID))
                            AyniFarkliKesi = AyniFarkliKesi.GetAyniFarkliKesi("1");    // Aynı seans + Aynı Kesi
                        else
                            AyniFarkliKesi = AyniFarkliKesi.GetAyniFarkliKesi("5");    // Aynı seans + Aynı Kesi + Farklı Klinik Kod
                    }
                    else   // Farklı Kesi
                    {
                        if (thisSpeciality != null && bigSpeciality != null && thisSpeciality.ObjectID.Equals(bigSpeciality.ObjectID))
                            AyniFarkliKesi = AyniFarkliKesi.GetAyniFarkliKesi("3");    // Aynı seans + Farklı Kesi
                        else
                            AyniFarkliKesi = AyniFarkliKesi.GetAyniFarkliKesi("4");    // Aynı seans + Farklı Kesi + Farklı Klinik Kod
                    }
                }
            }
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
                    else if (str[j] == k)
                    {
                        eDis[l] = "E";
                        break;
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
                    else if (str[j] == k)
                    {
                        sDis[l] = "E";
                        break;
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

        public void setAnomaliDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] aDis = new String[4];

            disBilgisiDVO.sagUstCeneAnomaliDis = "";//91
            disBilgisiDVO.solUstCeneAnomaliDis = "";//92
            disBilgisiDVO.sagAltCeneAnomaliDis = "";//93
            disBilgisiDVO.solAltCeneAnomaliDis = "";//94

            for (int i = 0; i < aDis.Length; i++)
                aDis[i] = "_";

            for (int j = 0; j < str.Length; j++)
            {
                for (int k = 91, l = 0; k <= aDis.Length + 90 && l < aDis.Length; k++, l++)
                {
                    if (str[j] == k)
                    {
                        aDis[l] = "E";
                        break;
                    }
                }
            }

            disBilgisiDVO.sagUstCeneAnomaliDis = aDis[0];
            disBilgisiDVO.solUstCeneAnomaliDis = aDis[1];
            disBilgisiDVO.sagAltCeneAnomaliDis = aDis[2];
            disBilgisiDVO.solAltCeneAnomaliDis = aDis[3];
        }

        public void setCeneDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == 1) //Tüm Çene
                {
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }
                if (str[j] == 2) //Ãœst Çene
                {
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }
                if (str[j] == 3) //Alt Çene
                {
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }
                if (str[j] == 4) //Sağ Ãœst Çene
                {
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }
                if (str[j] == 5) //Sol Ãœst Çene
                {
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }
                if (str[j] == 6) //Sağ Alt Çene
                {
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }
                if (str[j] == 7) //Sol Alt Çene
                {
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

        public override bool HasChangedToSendToDoctorPerformance()
        {

            if (HasMemberChanged("AyniFarkliKesi") || HasMemberChanged("ProcedureDoctor2") || HasMemberChanged("HasChangedAtChildObjects"))
                return true;
            return false;
        }

        public bool IsNeededEuroScoreEmpty()
        {
            if (ProcedureObject is SurgeryDefinition && ((SurgeryDefinition)ProcedureObject).IsNeedEuroScore == true)
            {
                if (EuroScoreOfProcedure == null)
                    return true;

            }
            return false;
        }


        public bool IsSecondDoctorNeededByGILPoint()
        {
            if (ProcedureObject is SurgeryDefinition && ((SurgeryDefinition)ProcedureObject).GILPoint != null)
            {
                if (((SurgeryDefinition)ProcedureObject).GILPoint > 1500)
                    return true;

            }
            return false;
        }

        public void ArrangeProcedureDoctorAndAddContext(Boolean OnlyOneProcedureDoctor, TTObjectClasses.ResUser[] SelectedResponsibleDoctorList)
        {
            if (OnlyOneProcedureDoctor)
            {
                if (ProcedureDoctor == null)
                {
                    throw new Exception(ProcedureObject.Name + " ameliyatı için: Sorumlu Cerrah girmediniz");
                }
                var selectedResponsibleDoctorList = new List<ResUser>();
                selectedResponsibleDoctorList.Add(ProcedureDoctor);
                SelectedResponsibleDoctorList = selectedResponsibleDoctorList.ToArray();

            }
            int doctorCount = SelectedResponsibleDoctorList.Count();
            int oldDoctorCount = SurgeryResponsibleDoctors.Count;

            while (doctorCount < oldDoctorCount)
            {
                ((ITTObject)SurgeryResponsibleDoctors[oldDoctorCount - 1]).Delete();
                oldDoctorCount--;
            }

            doctorCount = 0;
            oldDoctorCount = SurgeryResponsibleDoctors.Count - 1;
            foreach (var responsibleDoctor in SelectedResponsibleDoctorList)
            {
                if (doctorCount == 0 && !OnlyOneProcedureDoctor)
                { ProcedureDoctor = responsibleDoctor; }

                // eskiden girilenin doktor sayısı yeni girilene eşitse yada büyükse günceller
                if (doctorCount <= oldDoctorCount)
                {
                    SurgeryResponsibleDoctors[doctorCount].ResponsibleDoctor = responsibleDoctor;
                }
                else // eskiden girilenin doktor sayısı yeni girilenden küçükse yeni yaratır
                {
                    SurgeryResponsibleDoctor surgeryResponsibleDoctors = new SurgeryResponsibleDoctor(ObjectContext);
                    surgeryResponsibleDoctors.ResponsibleDoctor = responsibleDoctor;
                    SurgeryResponsibleDoctors.Add(surgeryResponsibleDoctors);
                }
                doctorCount++;
            }
        }

        public override void CreatePackageProcedure(double? discountPercent = null, bool applyDiscountPercentChange = false)
        {
            if (IsOldAction == true)
                return;

            if (ProcedureObject is PackageProcedureDefinition) // Zaten paket hizmet ise paket oluşturulmaz
                return;

            PackageProcedureDefinition packageProcedure = ProcedureObject.MyPackageProcedure();
            if (packageProcedure != null)
            {
                SurgeryPackageProcedure spp = SurgeryPackageProcedure.Select("").Where(x => x.IsCancelled == false).FirstOrDefault();
                if (spp == null)
                    spp = new SurgeryPackageProcedure(ObjectContext);

                spp.ActionDate = ActionDate;
                spp.PricingDate = PricingDate;
                spp.CreationDate = CreationDate;
                spp.Amount = 1;
                spp.CurrentStateDefID = TTObjectClasses.SurgeryPackageProcedure.States.Completed;
                spp.ProcedureObject = packageProcedure;
                spp.MasterSubActionProcedure = this;
                spp.SurgeryProcedure = this;
                spp.EpisodeAction = Surgery;
                spp.Surgery = Surgery;
                spp.SetPerformedDate();
                PackageProcedureObject = packageProcedure;

                if (spp.AccountTransactions.Count == 0)
                {
                    spp.DiscountPercent = discountPercent;
                    spp.AccountOperation(AccountOperationTimeEnum.PREPOST);
                }
                else if (spp.DiscountPercent != discountPercent && applyDiscountPercentChange)
                {   // applyDiscountPercentChange in nedeni, Ameliyat adımında yeni bir ameliyat eklendiğinde bu metod önce Surgery.AccountingOperation() dan çağırıldıktan sonra,
                    // SubActionProcedure.PreInsert() ten de çağırıldığı ve bu çağırımda discountPercent parametresi null geldiği için spp.DiscountPercent i tekrar null lamasın ve
                    // ChangeMyProtocol çalışıp ameliyatı indirimsiz olarak tekrar fiyatlandırmasın diye 
                    spp.DiscountPercent = discountPercent;
                    spp.ChangeMyProtocol(SubEpisode.OpenSubEpisodeProtocol);
                }

                spp.SetIncisionAndDateOfAccountTransactions();
            }
        }

        public void SetIncisionAndDateOfAccountTransactions()
        {
            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.CurrentStateDefID == AccountTransaction.States.New || at.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || at.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful)
                {
                    at.AyniFarkliKesi = AyniFarkliKesi;

                    if (Surgery != null && Surgery.SurgeryStartTime.HasValue)
                        at.TransactionDate = Surgery.SurgeryStartTime;
                }
            }
        }

        public override void AccountOperationAfterUpdate() { }

        #endregion Methods

    }
}