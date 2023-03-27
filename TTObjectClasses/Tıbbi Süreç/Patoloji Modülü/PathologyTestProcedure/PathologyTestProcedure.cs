
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
    public partial class PathologyTestProcedure : SubActionProcedure
    {
        public override void SetPerformedDate()
        {
            if (PerformedDate == null)
                PerformedDate = Common.RecTime();
        }

        public override ResUser GetDVOIstemYapanDr()
        {
            if (Pathology != null && Pathology.PathologyRequest != null && Pathology.PathologyRequest.RequestDoctor != null)
                return Pathology.PathologyRequest.RequestDoctor;

            return base.GetDVOIstemYapanDr();
        }

        public override string GetDVOSonuc()
        {
            return PathologyMaterial?.MorfolojiKodu?.MORFOLOJIKOD;
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            return PathologyMaterial?.MorfolojiKodu?.MORFOLOJIKODTANIM;
        }

        public override HizmetKayitIslemleri.tahlilSonucDVO[] GetDVOTahlilSonuclari()
        {
            HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();

            if (ProcedureObject is LaboratoryTestDefinition)
                tahlilSonucDVO.tahlilTipi = ((LaboratoryTestDefinition)ProcedureObject).TahlilTipi != null ? ((LaboratoryTestDefinition)ProcedureObject).TahlilTipi.tahlilTipKodu : "0";
            else
                tahlilSonucDVO.tahlilTipi = "0";

            string morfolojiKod = PathologyMaterial?.MorfolojiKodu?.MORFOLOJIKOD;
            if (!string.IsNullOrWhiteSpace(morfolojiKod))
                tahlilSonucDVO.sonuc = morfolojiKod.Length > 14 ? morfolojiKod.Substring(0, 14) : morfolojiKod;

            tahlilSonucDVO.birim = null;

            // Açıklama olarak "Makroskopi + Mikroskopi" bilgisi gönderilir
            if (PathologyMaterial != null)
            {
                string aciklama = string.Empty;

                if (PathologyMaterial.Macroscopy != null && !string.IsNullOrWhiteSpace(PathologyMaterial.Macroscopy.ToString()))
                    aciklama += "Makroskopi: " + HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(PathologyMaterial.Macroscopy.ToString());

                if (PathologyMaterial.Microscopy != null && !string.IsNullOrWhiteSpace(PathologyMaterial.Microscopy.ToString()))
                {
                    if (!string.IsNullOrWhiteSpace(aciklama))
                        aciklama += " - ";

                    aciklama += "Mikroskopi: " + HtmlRendererServiceFactory.Instance.ConvertHTMLtoPlainText(PathologyMaterial.Microscopy.ToString());
                }

                if (!string.IsNullOrWhiteSpace(aciklama))
                    tahlilSonucDVO.aciklama = aciklama.Length > 2000 ? aciklama.Substring(0, 2000) : aciklama;
            }

            List<HizmetKayitIslemleri.tahlilSonucDVO> tahlilSonucDVOList = new List<HizmetKayitIslemleri.tahlilSonucDVO> { tahlilSonucDVO };
            return tahlilSonucDVOList.ToArray();
        }
    }
}