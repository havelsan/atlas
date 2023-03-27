
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
    public  partial class BaseNursingSystemInterrogation : BaseNursingDataEntry
    {
        public override string GetApplicationSummary()
        {
            string tempString = " Veri Girilen Sorgulama Grupları: ";

            var query = NursingSystemInterrogations.GroupBy(x => x.SystemInterrogation.ActivityGroup.Value).Select(g => g.First());
            foreach (var nursingSystemInterrogation in query)
            {
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.Breast)
                    tempString += TTUtils.CultureService.GetText("M26502", "Meme,");
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.Eye)
                    tempString += TTUtils.CultureService.GetText("M25737", "Göz,");
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.General)
                    tempString += TTUtils.CultureService.GetText("M25704", "Genel,");
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.GIS)
                    tempString += "GİS,";
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.HeadNeckEyes)
                    tempString += TTUtils.CultureService.GetText("M25241", "Baş Boyun,");
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.Hormonal)
                    tempString += TTUtils.CultureService.GetText("M25983", "Hormonal,");
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.KVS)
                    tempString += "KVS,";
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.Man)
                    tempString += TTUtils.CultureService.GetText("M25606", "Erkek,");
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.Musculoskeletal)
                    tempString += "Kas İskelet,";
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.Respiratory)
                    tempString += TTUtils.CultureService.GetText("M26912", "Solunum,");
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.Spiritual)
                    tempString += TTUtils.CultureService.GetText("M26768", "Ruhsal Durum,");
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.Temper)
                    tempString += TTUtils.CultureService.GetText("M26890", "Sinir,");
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.Urology)
                    tempString += "ÜRO,";
                if (nursingSystemInterrogation.SystemInterrogation.ActivityGroup.Value == NursingSystemInterrogationEnum.Woman)
                    tempString += TTUtils.CultureService.GetText("M26255", "Kadın,");

            }

            return tempString;
        }
    }
}