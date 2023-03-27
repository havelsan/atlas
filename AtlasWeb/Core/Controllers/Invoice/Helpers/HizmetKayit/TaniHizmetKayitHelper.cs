using Core.Controllers.Invoice.Helpers.HizmetKayit;
using System;
using System.Collections.Generic;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;

namespace Core.Controllers.Invoice.Helpers
{
    public class TaniHizmetKayitHelper
    {
        public static void SetMedulaStatusToNewForUnsuccessfulDiagnosis(string SEPObjectID, TTObjectContext objectcontext)
        {
            //TTObjectContext objectcontext = new TTObjectContext(false);
            List<Guid> stateList = new List<Guid>();
            stateList.Add(SEPDiagnosis.States.MedulaEntryUnsuccessful);
            IList<SEPDiagnosis> sdList = SEPDiagnosis.GetBySEPAndState(objectcontext, new Guid(SEPObjectID), stateList);
            foreach (SEPDiagnosis sd in sdList)
                sd.CurrentStateDefID = SEPDiagnosis.States.New;
        }

        public static void GetHizmetKayitGirisDVODiagnosisGridList(string SEPObjectID, HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList, TTObjectContext objectcontext, List<Guid> states, bool ASync)
        {
            // Tanılarıın hızmet kaydını yapmak ıcın gerekli kod parçası
            IList<SEPDiagnosis> sdList = SEPDiagnosis.GetBySEPAndState(objectcontext, new Guid(SEPObjectID), states);
            if (sdList.Count > 0)
            {
                HizmetKayitHelper.loadHizmetTakipBilgileri(hizmetKayitGirisDVOWithList, sdList[0]);
                // Maximumda 19 tane tanı ilk seferde hizmet kaydına gönderilebilir
                int maxHizmetSayisi = Convert.ToInt32(SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));
                for (int i = 0; i < sdList.Count && i < (maxHizmetSayisi - 1); i++)
                {
                    HizmetKayitHelper.LoadHizmetBilgileri(hizmetKayitGirisDVOWithList, sdList[i]);
                    if (ASync)
                        sdList[i].CurrentStateDefID = SEPDiagnosis.States.MedulaSentServer;
                }
            }
        }

        public static void ControlRepeatedDiagnosis(string SEPObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(false);
            List<Guid> stateList = new List<Guid>();
            stateList.Add(SEPDiagnosis.States.New);
            IList<SEPDiagnosis> sdList = SEPDiagnosis.GetBySEPAndState(objectcontext, new Guid(SEPObjectID), stateList);
            if (sdList.Count > 0)
            {
                List<Guid> exStateList = new List<Guid>();
                exStateList.Add(SEPDiagnosis.States.MedulaEntryUnsuccessful);
                exStateList.Add(SEPDiagnosis.States.MedulaEntrySuccessful);
                IList<SEPDiagnosis> exsdList = SEPDiagnosis.GetBySEPAndState(objectcontext, new Guid(SEPObjectID), exStateList);
                for (int i = 0; i < sdList.Count && exsdList.Count > 0; i++)
                {
                    for (int k = 0; k < exsdList.Count; k++)
                    {
                        if (sdList[i].DiagnoseCode == exsdList[k].DiagnoseCode)
                            sdList[i].CurrentStateDefID = SEPDiagnosis.States.MedulaDontSend;
                    }
                }

                for (int i = 0; i < sdList.Count; i++)
                {
                    for (int k = 0; k < sdList.Count; k++)
                    {
                        if (k > i && sdList[i].DiagnoseCode == sdList[k].DiagnoseCode && sdList[k].CurrentStateDefID != SEPDiagnosis.States.MedulaDontSend)
                            sdList[k].CurrentStateDefID = SEPDiagnosis.States.MedulaDontSend;
                    }
                }
            }

            Utils.SaveAndDisposeContext(objectcontext);
        }

        //public static SubEpisodeProtocol.MedulaResult TaniHizmetKayitSync(List<string> diagnosisGridIDs)
        //{
        //    // GetDVO Deneme
        //    if (diagnosisGridIDs.Count > 0)
        //    {
        //        TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayitGirisDVO = GetTaniHizmetKayitGirisDVO(diagnosisGridIDs, false);
        //        TTObjectClasses.XXXXXXMedulaServices.HizmetKayitParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HizmetKayitParam(hizmetKayitGirisDVO, diagnosisGridIDs);
        //        TTObjectContext objectcontext = new TTObjectContext(false);
        //        HizmetKayitIslemleri.hizmetKayitCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetKayitSync(TTObjectClasses.Sites.SiteLocalHost, null, hizmetKayitGirisDVO);
        //        inputParam.HizmetKayitCompletedInternal(result, hizmetKayitGirisDVO, objectcontext, true);
        //        Utils.SaveAndDisposeContext(objectcontext);
        //        return Utils.GetMedulaResult(result);
        //    }
        //    return null;
        //}
        private static TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO GetTaniHizmetKayitGirisDVO(List<string> SEPDiagnosisIDs, bool ASync)
        {
            TTObjectContext objectcontext = new TTObjectContext(false);
            HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList = new HizmetKayitGirisDVOWithList();
            for (int i = 0; i < SEPDiagnosisIDs.Count; i++)
            {
                SEPDiagnosis sd = (SEPDiagnosis)objectcontext.GetObject(new Guid(SEPDiagnosisIDs[i]), typeof (SEPDiagnosis));
                if (i == 0)
                    HizmetKayitHelper.loadHizmetTakipBilgileri(hizmetKayitGirisDVOWithList, sd);
                HizmetKayitHelper.LoadHizmetBilgileri(hizmetKayitGirisDVOWithList, sd);
                if (ASync)
                    sd.CurrentStateDefID = SEPDiagnosis.States.MedulaSentServer;
            }

            Utils.SaveAndDisposeContext(objectcontext);
            return hizmetKayitGirisDVOWithList.HizmetKayitGirisDVO;
        }
    }
}