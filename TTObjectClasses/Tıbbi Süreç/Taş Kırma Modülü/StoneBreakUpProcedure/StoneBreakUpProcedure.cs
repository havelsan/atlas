
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
    /// Taş Kırma İşlemi
    /// </summary>
    public  partial class StoneBreakUpProcedure : BaseStoneBreakUpProcedure
    {
        public partial class GetByEpisode_Class : TTReportNqlObject 
        {
        }

#region Methods
        /// <summary>
        /// Belirli bir taraf ve bölge için bir taş kırma işlemi 3 ay içinde max 3 kez yapılabilir.Ayrıca 1. taş kırma işleminden itibaren 3 ay içinde istenen işlemeler 2. ve 3. işlem olurken 1. işlemden 3 ay geçtikten sonra başlatılan işlemde tekrar 1 işlem olur.
        /// </summary>
        /// <returns></returns>
        protected int MyNumberOfProcedure(DateTime refDate)
        {
            int numberOfProcedure=1;
            IList episodeStoneBreakUpProcedures = StoneBreakUpProcedure.GetPastProcedureByZoneAndPart(ObjectContext,ZoneOfStone.Value,PartOfStone.ObjectID.ToString(),Episode.Patient.ObjectID.ToString(), Convert.ToDateTime(refDate),ObjectID.ToString());
            if (episodeStoneBreakUpProcedures.Count>0)
            {
                int mountlimit = Convert.ToInt16(SystemParameter.GetParameterValue("STONEBREAKUPMOUNTLIMIT","6"));
                DateTime limitDate = Convert.ToDateTime(((StoneBreakUpProcedure)episodeStoneBreakUpProcedures[0]).ProcedureDate);
                foreach (StoneBreakUpProcedure stoneBreakUpProcedure in episodeStoneBreakUpProcedures )
                {
                    if (Convert.ToDateTime(stoneBreakUpProcedure.ProcedureDate) <= Convert.ToDateTime(refDate))
                    {
                        if (limitDate.AddMonths(mountlimit) >= Convert.ToDateTime(refDate))
                        {
                            numberOfProcedure++;
                        }
                        else if(limitDate.AddMonths(mountlimit)< Convert.ToDateTime(stoneBreakUpProcedure.ProcedureDate))
                        {
                            limitDate = Convert.ToDateTime(stoneBreakUpProcedure.ProcedureDate);
                            numberOfProcedure=1;
                        }
                    }
                }
                
            }
            
            return numberOfProcedure;
            
            //E?er hastaya ait hiç  stoneBreakUpProcedure yoksa 1. i?lemdir demekdir.
            //             ArrayList stoneBreakUpProcedureArrayList = new ArrayList();
            //            foreach(Episode episode in this.Episode.Patient.Episodes)
            //            {
            //                foreach (StoneBreakUpRequest stoneBreakUpRequest in  episode.StoneBreakUpRequests)
            //                {
            //                    IList episodeStoneBreakUpProcedures = stoneBreakUpRequest.StoneBreakUpProcedures.Select(" STATE_STATUS <> STATE_IS_CANCELLED AND ZONEOFSTONE = " + this.ZoneOfStone.GetHashCode().ToString() + " AND PARTOFSTONE = '" + this.PartOfStone.ObjectID.ToString() + "'");
            //                    foreach (StoneBreakUpProcedure stoneBreakUpProcedure in episodeStoneBreakUpProcedures )
            //                    {
            //                        //ArrayList'e  yalnızca kendi haricindeki  geçmiş zamanlı işlemler ve aynı zamanlı işlemlerden henüz NumberOfProcedure'ü belirlenmemiş olanlar atanıyor  ki  ileri tarihli procedürler için numara artmasın
            //                        if(this != stoneBreakUpProcedure)
            //                        {
            //                            if (Convert.ToDateTime(stoneBreakUpProcedure.ActionDate)< Convert.ToDateTime(this.ActionDate) || (Convert.ToDateTime(this.ActionDate)==Convert.ToDateTime(stoneBreakUpProcedure.ActionDate) && stoneBreakUpProcedure.NumberOfProcedure!=null))
            //                            {
            //                                stoneBreakUpProcedureArrayList.Add(Convert.ToDateTime(stoneBreakUpProcedure.ActionDate));
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            int numberOfProcedure=1;
            //            if (stoneBreakUpProcedureArrayList.Count>0)
            //            {
            //                stoneBreakUpProcedureArrayList.Sort();
            //                DateTime refDate = Convert.ToDateTime(stoneBreakUpProcedureArrayList[0]);
            //                for (int i = 0; i < stoneBreakUpProcedureArrayList.Count; i++)
            //                {
            //                    if (Convert.ToDateTime(stoneBreakUpProcedureArrayList[i]) <= Convert.ToDateTime(this.ActionDate))
            //                    {
            //                        if (refDate.AddMonths(3) >= Convert.ToDateTime(this.ActionDate))
            //                        {
            //                            numberOfProcedure++;
//
            //                        }
            //                        else if(refDate.AddMonths(3)< Convert.ToDateTime(stoneBreakUpProcedureArrayList[i]))
            //                        {
            //                            refDate = Convert.ToDateTime(stoneBreakUpProcedureArrayList[i]);
            //                            numberOfProcedure=1;
            //                        }
            //                    }
            //                }
            //            }
            //            return numberOfProcedure; //E?er hastaya ait hiç  stoneBreakUpProcedure yoksa 1. i?lemdir demekdir.
        }
        
        protected StoneBreakUpDefinition GetProcedureBySeance(int seance)
        {
            // ilk bulduğu seansı döndürür zaten her seansdan ancak 1 tane tanımlanabilir.
            IList stoneBreakUpDefinitionList=StoneBreakUpDefinition.GetBySeance(ObjectContext,seance);
            foreach(StoneBreakUpDefinition stoneBreakUpDefinition in stoneBreakUpDefinitionList)
            {
                return stoneBreakUpDefinition;
            }
            return null;
        }
        
        public static void SetProcedureObject(DateTime refDateTime, StoneBreakUpProcedure stoneBreakUpProcedure)
        {
            int numberOfProcedure= stoneBreakUpProcedure.MyNumberOfProcedure(refDateTime);
            int mountlimit =  Convert.ToInt16(SystemParameter.GetParameterValue("STONEBREAKUPMOUNTLIMIT","6"));
            bool setProcedure=false;
            if(numberOfProcedure>3)
                throw new Exception(SystemMessage.GetMessageV3(1193, new string[] {mountlimit.ToString(), stoneBreakUpProcedure.ZoneOfStone.ToString(), stoneBreakUpProcedure.PartOfStone.PartOfStone.ToString()}));
            else
            {
                if(stoneBreakUpProcedure.ProcedureObject!=null)
                {
                    if (((StoneBreakUpDefinition)stoneBreakUpProcedure.ProcedureObject).Seance!=numberOfProcedure)
                        setProcedure=true;
                }
                else
                    setProcedure=true;
            }
            if (setProcedure)
            {
                //O seansa ait ilk procedurü döndürür
                StoneBreakUpDefinition eswl = stoneBreakUpProcedure.GetProcedureBySeance(numberOfProcedure);
                if(eswl==null)
                    throw new  Exception(SystemMessage.GetMessageV3(1194,new string[] {numberOfProcedure.ToString()}));
                else
                {
                    stoneBreakUpProcedure.ProcedureObject = eswl;
                    stoneBreakUpProcedure.NumberOfProcedure=numberOfProcedure;
                }
            }
        }
        

        public bool HasProcedureAfterProcedureDate()
        {
            IList futureProcedures=StoneBreakUpProcedure.GetFutureProcedureByZoneAndPart(ObjectContext,ZoneOfStone.Value,PartOfStone.ObjectID.ToString(),Episode.Patient.ObjectID.ToString(), Convert.ToDateTime(ProcedureDate),ObjectID.ToString());
            if (futureProcedures.Count>0)
            {
                return true;
            }
            return false;
        }
        
        
        public static void CreateStoneBreakUpPackageProcedure(StoneBreakUpProcedure stoneBreakUpProcedure)
        {
            if(stoneBreakUpProcedure.StoneBreakUpRequest != null && stoneBreakUpProcedure.ProcedureObject != null && stoneBreakUpProcedure.ProcedureObject.PackageProcedure != null && stoneBreakUpProcedure.StoneBreakUpRequest.SubEpisode.IsSGK)
            {
                StoneBreakUpPackageProcedure SBUPackage = new StoneBreakUpPackageProcedure(stoneBreakUpProcedure.ObjectContext);
                SBUPackage.ActionDate = stoneBreakUpProcedure.ActionDate;
                SBUPackage.Amount = stoneBreakUpProcedure.Amount;
                SBUPackage.CurrentStateDefID = StoneBreakUpPackageProcedure.States.Completed;
                SBUPackage.ProcedureObject = stoneBreakUpProcedure.ProcedureObject.PackageProcedure;
                SBUPackage.MasterSubActionProcedure = stoneBreakUpProcedure;
                SBUPackage.EpisodeAction = stoneBreakUpProcedure.StoneBreakUpRequest;
                SBUPackage.PricingDate = stoneBreakUpProcedure.PricingDate;

                // Paket hizmet oluşacaksa, normal hizmetin ücretlenmesine gerek yok
                stoneBreakUpProcedure.Eligible = false;
            }
        }
      
        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return StoneBreakUpRequest?.AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override string GetDVORaporTakipNo()
        {
            return StoneBreakUpRequest?.MedulaRaporTakipNo;
        }

        public override void SetPerformedDate()
        {
                PerformedDate = StoneBreakUpRequest.ProcessDate.Value;

        }
        

        #endregion Methods

    }
}