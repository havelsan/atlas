
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
    /// Medula'da bulunan tanıları sisteme entegre etmeye yarayan servis
    /// </summary>
    public partial class MedulaDiagnosisUpdater : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "Medula Diagnosis Updater Started : " + Common.RecTime();
            try
            {

                UpdateDiagnosisDefinitions();
                logTxt += " - Has Finished Succesfully : " + Common.RecTime();

            }
            catch (Exception ex)
            {
                logTxt += " - ERROR: " + ex.ToString() + ": " + Common.RecTime();

            }
            AddLog(logTxt);




        }


        public void UpdateDiagnosisDefinitions()
        {

            char[] LetterList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                var diagnosisList = DiagnosisDefinition.GetDiagnosisDefinitions(objectContext, "");

                foreach (char letter in LetterList)
                {
                    MedulaYardimciIslemler.taniAraGirisWSDVO input = new MedulaYardimciIslemler.taniAraGirisWSDVO();
                    input.icd10Kodu = letter.ToString();
                    input.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                    MedulaYardimciIslemler.taniAraCevapDVO taniAraCevapDVO = MedulaYardimciIslemler.WebMethods.taniAraSync(Sites.SiteLocalHost, input);

                    if (taniAraCevapDVO != null)
                    {
                        foreach (var tani in taniAraCevapDVO.tanilar)
                        {

                            var existDiagnosis = MedulaDiagnosisDefinition.GetDiagnosisByCode(objectContext,tani.icd10Kodu).FirstOrDefault();
                            if (existDiagnosis == null)
                            {
                                MedulaDiagnosisDefinition medulaDiagnosisDefinition = new MedulaDiagnosisDefinition(objectContext);
                                medulaDiagnosisDefinition.Code = tani.icd10Kodu;
                                medulaDiagnosisDefinition.Name = tani.taniAdi;
                                medulaDiagnosisDefinition.Name_Shadow = tani.taniAdi.ToUpper();
                                objectContext.Save();
                            }

                        }

                    }
                }


            }
        }
    }
}