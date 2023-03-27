
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
    /// Dış Hizmet
    /// </summary>
    public partial class ExternalSubActionProcedure : SubactionProcedureFlowable
    {
        public partial class ExternalSubActionProceduresQuery_Class : TTReportNqlObject
        {
        }

        #region Methods

        private string BranchCodeForDVO(AccountTransaction AccTrx)
        {
            // Havale Edilen birimin uzmanlığı set edilir
            if (ExternalProcedureRequest != null && ExternalProcedureRequest.MasterResource != null)
            {
                foreach (ResourceSpecialityGrid resSpeciality in ExternalProcedureRequest.MasterResource.ResourceSpecialities)
                {
                    if (resSpeciality.Speciality != null)
                        return resSpeciality.Speciality.Code;
                }
            }

            //  Havale Edilen birimin uzmanlığına ulaşılamazsa, içinde bulunduğu takibin branşı set edilir
            if (AccTrx.SubEpisodeProtocol.Brans != null)
                return AccTrx.SubEpisodeProtocol.Brans.Code;

            return null;
        }

        private string DescriptionForDVO(int? maxLength = null)
        {
            if (Report != null)
            {
                string rtfString = Common.GetTextOfRTFString(Report.ToString());
                if (!string.IsNullOrEmpty(rtfString))
                {
                    if (maxLength.HasValue && rtfString.Length > maxLength) // açıklama max maxLength karakter olabiliyor
                        return rtfString.Substring(0, maxLength.Value);

                    return rtfString;
                }
            }

            if (ExternalProcedureRequest != null && !string.IsNullOrEmpty(ExternalProcedureRequest.Description))
            {
                if (maxLength.HasValue && ExternalProcedureRequest.Description.Length > maxLength)
                    return ExternalProcedureRequest.Description.Substring(0, maxLength.Value);

                return ExternalProcedureRequest.Description;
            }

            return null;
        }

        public override string GetDVOIsbtUniteNo()
        {
            if (!string.IsNullOrEmpty(ISBTUnitNumber))
                return ISBTUnitNumber.ToUpper();

            return null;
        }

        public override string GetDVOIsbtBilesenNo()
        {
            if (!string.IsNullOrEmpty(ISBTElementCode))
                return ISBTElementCode.ToUpper();

            return null;
        }

        public override HizmetKayitIslemleri.tahlilSonucDVO[] GetDVOTahlilSonuclari()
        {
            if (ProcedureObject != null && !string.IsNullOrEmpty(Result))
            {
                List<HizmetKayitIslemleri.tahlilSonucDVO> tahlilSonucDVOList = new List<HizmetKayitIslemleri.tahlilSonucDVO>();
                HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();

                if (ProcedureObject is LaboratoryTestDefinition)
                {
                    if (((LaboratoryTestDefinition)ProcedureObject).TahlilTipi != null && !string.IsNullOrEmpty(((LaboratoryTestDefinition)ProcedureObject).TahlilTipi.tahlilTipKodu))
                        tahlilSonucDVO.tahlilTipi = ((LaboratoryTestDefinition)ProcedureObject).TahlilTipi.tahlilTipKodu;
                    else
                        tahlilSonucDVO.tahlilTipi = "0";
                }
                else if (ProcedureObject is PathologyTestDefinition)
                {
                    if (((PathologyTestDefinition)ProcedureObject).TahlilTipi != null && !string.IsNullOrEmpty(((PathologyTestDefinition)ProcedureObject).TahlilTipi.tahlilTipKodu))
                        tahlilSonucDVO.tahlilTipi = ((PathologyTestDefinition)ProcedureObject).TahlilTipi.tahlilTipKodu;
                    else
                        tahlilSonucDVO.tahlilTipi = "0";
                }

                if (Result.Length > 14)
                    tahlilSonucDVO.sonuc = Result.Substring(0, 14);
                else
                    tahlilSonucDVO.sonuc = Result;

                if (!string.IsNullOrEmpty(Unit))
                {
                    if (Unit.Length > 14)
                        tahlilSonucDVO.birim = Unit.Substring(0, 14);
                    else
                        tahlilSonucDVO.birim = Unit;
                }

                tahlilSonucDVOList.Add(tahlilSonucDVO);
                return tahlilSonucDVOList.ToArray();
            }

            return null;
        }

        public override string GetDVOAccession()
        {
            if (ProcedureObject is RadiologyTestDefinition)
            {
                //if (((RadiologyTestDefinition)ProcedureObject).AccessionModalityRequires == true)
                //{
                if (!string.IsNullOrEmpty(AccessionNo))
                    return AccessionNo;
                else
                    return "9998"; // accesion number üretemeyen görüntüler için 9998 veya 9999 gönderin yazıyor kılavuzda
                //}
            }

            return null;
        }

        public override string GetDVOModality()
        {
            if (ProcedureObject is RadiologyTestDefinition)
            {
                RadiologyTestDefinition radiologyTestDefinition = ProcedureObject as RadiologyTestDefinition;
                //if (radiologyTestDefinition.AccessionModalityRequires == true)
                //{
                if (radiologyTestDefinition.IsMR)
                    return "M";

                if (radiologyTestDefinition.IsBT)
                    return "B";
                //}
            }

            return null;
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.tetkikveRadyolojiBilgileri)
            {
                Guid btProcedure = new Guid("100b4e9a-2089-4d69-a88b-370306c42d43"); // BT
                Guid mrProcedure = new Guid("6edf2225-4b77-47a2-9686-61f8c441084e"); // MR

                if (ProcedureObject.ProcedureTree != null && (ProcedureObject.ProcedureTree.ObjectID == mrProcedure || ProcedureObject.ProcedureTree.ObjectID == btProcedure))
                    return DescriptionForDVO(2999); // MR ve BT için açıklama alanının limiti 2999
                else
                    return DescriptionForDVO(199);  // Diğerleri için açıklama alanının limiti 199
            }
            else if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
                return DescriptionForDVO(254);      // Açıklama max 254 karakter olabiliyor

            return DescriptionForDVO();
        }

        public override string GetDVOEuroscore()
        {
            return ((int)MedulaEuroScoreEnum.Empty).ToString();
        }

        public override string GetDVOAnomali()
        {
            return "H";
        }

        public override void GetDVOSetCeneBilgisi(HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            List<int> listEriskin = new List<int>();
            List<int> listSut = new List<int>();
            List<int> listCene = new List<int>();

            if (ToothNumber != null)
            {
                if (Convert.ToInt32(ToothNumber.Value) >= 11 && Convert.ToInt32(ToothNumber.Value) <= 48)
                    listEriskin.Add(Convert.ToInt32(ToothNumber.Value));
                else if (Convert.ToInt32(ToothNumber.Value) >= 51 && Convert.ToInt32(ToothNumber.Value) <= 85)
                    listSut.Add(Convert.ToInt32(ToothNumber.Value));
                else if (Convert.ToInt32(ToothNumber.Value) >= 1 && Convert.ToInt32(ToothNumber.Value) <= 7)
                    listCene.Add(Convert.ToInt32(ToothNumber.Value));
            }

            setEriskinDisler(listEriskin.ToArray(), disBilgisiDVO);
            setSutDisler(listSut.ToArray(), disBilgisiDVO);
            setCeneDisler(listCene.ToArray(), disBilgisiDVO);

            disBilgisiDVO.sagAltCeneAnomaliDis = "_";
            disBilgisiDVO.solAltCeneAnomaliDis = "_";
            disBilgisiDVO.sagUstCeneAnomaliDis = "_";
            disBilgisiDVO.solUstCeneAnomaliDis = "_";
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

        //Tuğba: Tüm,sağ,sol,üst,alt çene string scheması oluşturulur.
        public void setCeneDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {


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
                {  //Üst Çene
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
                {  //Alt Çene
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
                {  //Sağ Üst Çene
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
                {  //Sol Üst Çene
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
                {  //Sağ Alt Çene
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
                {  //Sol Alt Çene
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

        #endregion Methods

    }
}