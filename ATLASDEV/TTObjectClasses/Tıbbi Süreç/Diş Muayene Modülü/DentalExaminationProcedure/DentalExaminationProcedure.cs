
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
    public partial class DentalExaminationProcedure : SubActionProcedure
    {
        #region Methods
        public DentalExaminationProcedure(DentalExamination dentalExamination, string guid) : this(dentalExamination.ObjectContext)
        {
            Guid procedureGuid = new Guid(guid);
            //YAPILACAKLAR//Standart procedürler kod içinde nasıl çekilecek hangi özelliği ortak olacak Guidi ortak olacak mı?
            ProcedureObject = (ProcedureDefinition)dentalExamination.ObjectContext.GetObject(procedureGuid, "PROCEDUREDEFINITION");
            ProcedureDoctor = dentalExamination.ProcedureDoctor;
            ProcedureByUser = dentalExamination.ProcedureDoctor;
            PerformedDate = Common.RecTime();
            dentalExamination.DentalExaminationProcedures.Add(this);
        }

        public OzelDurum GetOzelDurum()
        {
            // Diş kontrol muayenesinin diş muayene hizmetinin özel durum bilgisi "1 İşlem Tutarını Talep Etmiyorum" olacak
            if (DentalExamination.SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKontrol)
                return OzelDurum.GetOzelDurum("1");

            return null;
        }

        public override string GetDVOOzelDurum(AccountTransaction accTrx)
        {
            if (accTrx.OzelDurum == null)
            {
                OzelDurum ozelDurum = GetOzelDurum();
                if (ozelDurum != null)
                {
                    if (!accTrx.ObjectContext.IsReadOnly)
                        accTrx.OzelDurum = ozelDurum;

                    return ozelDurum.ozelDurumKodu;
                }
            }

            return null;
        }
        
        //Tuğba:  Erişkin dişlerin string scheması oluşturulur.
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

            disBilgisiDVO.sagUstCeneAnomaliDis = "";//91
            disBilgisiDVO.solUstCeneAnomaliDis = "";//92
            disBilgisiDVO.sagAltCeneAnomaliDis = "";//93
            disBilgisiDVO.solAltCeneAnomaliDis = "";//94


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


            disBilgisiDVO.sagUstCeneAnomaliDis = "_";
            disBilgisiDVO.solUstCeneAnomaliDis = "_";
            disBilgisiDVO.sagAltCeneAnomaliDis = "_";
            disBilgisiDVO.solAltCeneAnomaliDis = "_";
            disBilgisiDVO.sagSutUstCene = "_____";
            disBilgisiDVO.solSutUstCene = "_____";
            disBilgisiDVO.solSutAltCene = "_____";
            disBilgisiDVO.sagSutAltCene = "_____";
            disBilgisiDVO.sagUstCene = "________";
            disBilgisiDVO.solUstCene = "________";
            disBilgisiDVO.solAltCene = "________";
            disBilgisiDVO.sagAltCene = "________";

            for (int j = 0; j < str.Length; j++)
            {

                if (str[j] == 1)
                {  //Tüm Çene
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
                {  //Ãœst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    //disBilgisiDVO.sagAltCeneAnomaliDis="_";
                    //disBilgisiDVO.solAltCeneAnomaliDis="_";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    //disBilgisiDVO.solSutAltCene="_____";
                    //disBilgisiDVO.sagSutAltCene="_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    //disBilgisiDVO.solAltCene="________";
                    //disBilgisiDVO.sagAltCene="________";
                }
                if (str[j] == 3)
                {  //Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    //disBilgisiDVO.sagSutUstCene="_____";
                    //disBilgisiDVO.solSutUstCene="_____";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    //disBilgisiDVO.sagUstCene="________";
                    //disBilgisiDVO.solUstCene="________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }
                if (str[j] == 4)
                {  //Sağ Ãœst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    //disBilgisiDVO.solUstCeneAnomaliDis="_";
                    //disBilgisiDVO.sagAltCeneAnomaliDis="_";
                    //disBilgisiDVO.solAltCeneAnomaliDis="_";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    //disBilgisiDVO.solSutUstCene="_____";
                    //disBilgisiDVO.solSutAltCene="_____";
                    //disBilgisiDVO.sagSutAltCene="_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    //disBilgisiDVO.solUstCene="________";
                    //disBilgisiDVO.solAltCene="________";
                    //disBilgisiDVO.sagAltCene="________";
                }
                if (str[j] == 5)
                {  //Sol Ãœst Çene
                    //disBilgisiDVO.sagUstCeneAnomaliDis="_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    //disBilgisiDVO.sagAltCeneAnomaliDis="_";
                    //disBilgisiDVO.solAltCeneAnomaliDis="_";
                    //disBilgisiDVO.sagSutUstCene="_____";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    //disBilgisiDVO.solSutAltCene="_____";
                    //disBilgisiDVO.sagSutAltCene="_____";
                    //disBilgisiDVO.sagUstCene="________";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    //disBilgisiDVO.solAltCene="________";
                    //disBilgisiDVO.sagAltCene="________";
                }
                if (str[j] == 6)
                {  //Sağ Alt Çene
                    //disBilgisiDVO.sagUstCeneAnomaliDis="_";
                    //disBilgisiDVO.solUstCeneAnomaliDis="_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    //disBilgisiDVO.solAltCeneAnomaliDis="_";
                    //disBilgisiDVO.sagSutUstCene="_____";
                    //disBilgisiDVO.solSutUstCene="_____";
                    //disBilgisiDVO.solSutAltCene="_____";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    //disBilgisiDVO.sagUstCene="________";
                    //disBilgisiDVO.solUstCene="________";
                    //disBilgisiDVO.solAltCene="________";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }
                if (str[j] == 7)
                {  //Sol Alt Çene
                    //disBilgisiDVO.sagUstCeneAnomaliDis="_";
                    //disBilgisiDVO.solUstCeneAnomaliDis="_";
                    //disBilgisiDVO.sagAltCeneAnomaliDis="_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    //disBilgisiDVO.sagSutUstCene="_____";
                    //disBilgisiDVO.solSutUstCene="_____";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    //disBilgisiDVO.sagSutAltCene="_____";
                    //disBilgisiDVO.sagUstCene="________";
                    //disBilgisiDVO.solUstCene="________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    //disBilgisiDVO.sagAltCene="________";
                }

            }

        }

        public override void SetPerformedDate()
        {
            if (CreationDate == null || (CreationDate != null && DentalExamination.ProcessDate != null && CreationDate > DentalExamination.ProcessDate))
                CreationDate = DentalExamination.ProcessDate;
            if (PerformedDate == null && DentalExamination.ProcessEndDate != null)
                PerformedDate = DentalExamination.ProcessEndDate;
            if (PerformedDate != null && CreationDate != null && CreationDate >= PerformedDate)
                PerformedDate = CreationDate.Value.AddMinutes(1);
            //Geçmişe dönük hizmet girildiğinde saat - dakika farkıyla subepisode un açılış tarihinden önceye hizmet girilemesin diye eklendi.
            if (PerformedDate != null && PerformedDate <= SubEpisode.OpeningDate)
            {
                CreationDate = SubEpisode.OpeningDate.Value.AddMinutes(1);
                PerformedDate = SubEpisode.OpeningDate.Value.AddMinutes(2);
            }
        }

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (CurrentStateDefID == DentalExaminationProcedure.States.Completed)
                return true;
            return isNewInserted;
        }


        #endregion Methods

    }
}