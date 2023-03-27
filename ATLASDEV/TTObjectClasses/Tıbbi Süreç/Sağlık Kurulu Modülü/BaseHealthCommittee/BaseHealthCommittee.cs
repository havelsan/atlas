
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
    public  partial class BaseHealthCommittee : EpisodeActionWithDiagnosis
    {
#region Methods
        //        override protected void OnConstruct()
        //        {
        //            base.OnConstruct();
        //            ///// Bu kısım silinecek.
        //            if (((ITTObject)this).IsNew == true)
        //            {
        //                TTObjectContext con = this.ObjectContext;
        //                IList episodes = con.QueryObjects("Episode");
        //                if (episodes.Count == 0)
        //                    throw new TTException("Episode bulunamady.");
        //                this.Episode = (Episode)episodes[3];
        //                IList resource = this.ObjectContext.QueryObjects("Resource");
        //                this.MasterResource = (Resource)resource[20];
        //                this.FromResource = (Resource)resource[61];
        //            }
        //        }
        
        /// <summary>
        /// Bitmemiş SK Muayeneleri varsa, hata mesajı verir.
        /// </summary>
        
        public void throwExceptionForUnfinishedHCExaminations(){
            String resources;
            resources= CheckLinkedAction();
            if(resources != "" )
            {
                throw new TTException(SystemMessage.GetMessageV2(975, resources.Substring(0, (resources.Length - 1)))); 
            }
        }
        
        /// <summary>
        /// Çağıran actionun linked actionları arasında tamamalnmamış olanlar varsa, birimleri bir stringte return eder.
        /// </summary>
        /// <returns>String</returns>
        
        
        public String CheckLinkedAction()
        {
            String resources = "" ;
            String res = "" ;
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this);
            foreach( EpisodeAction episodeAction in arrList)
            {
                if(!episodeAction.IsCancelled){
                    if (episodeAction.CurrentStateDefID != HealthCommitteeExamination.States.Completed && episodeAction.CurrentStateDefID != ExaminationApproval.States.Completed && episodeAction.CurrentStateDefID != HealthCommitteeExaminationFromOtherHospitals.States.Resulted )
                    {
                        resources= resources + episodeAction.MasterResource.Name + ", " ;
                    }
                }
            }
            if(resources.Trim() != "")
            {
                res = resources.Substring(0, (resources.Length -1));
            }
            return res;
            
        }
        
        /// <summary>
        ///  HospitalsUnits griddeki bütün satırları siler.
        /// </summary>
        protected override void ClearHospitalsUnits()
        {
            _HospitalsUnits.Clear() ;
        }
        
        /// <summary>
        /// HospitalsUnits gride  isteği yapan XXXXXX/birimi ekler.
        /// </summary>
        public override void AddRequesterHospitalsUnits()
        {
            //this.ClearHospitalsUnits();
            BaseHealthCommittee_HospitalsUnitsGrid hospitalsUnits= new BaseHealthCommittee_HospitalsUnitsGrid(ObjectContext);
            
            //YAPILACAKLAR//requesterHospitalsUnitsDefinitionGrid.ExaminationHospital'a mevcut hastene atanacak//YAPILDI..yilmaz
            Guid hospID = new Guid(SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)ObjectContext.GetObject(hospID, typeof(ResHospital));
            //hospitalsUnits.Hospital = hospital;
            hospitalsUnits.Unit= MasterResource;
            _HospitalsUnits.Add(hospitalsUnits);
        }

        public static void AddRequesterHospitalsUnitsForBaseHealthCommittee(BaseHealthCommittee baseHealthCommittee)
        {
            //this.ClearHospitalsUnits();
            BaseHealthCommittee_HospitalsUnitsGrid hospitalsUnits = new BaseHealthCommittee_HospitalsUnitsGrid(baseHealthCommittee.ObjectContext);

            //YAPILACAKLAR//requesterHospitalsUnitsDefinitionGrid.ExaminationHospital'a mevcut hastene atanacak//YAPILDI..yilmaz
            Guid hospID = new Guid(SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)baseHealthCommittee.ObjectContext.GetObject(hospID, typeof(ResHospital));
            //hospitalsUnits.Hospital = hospital;
            hospitalsUnits.Unit = baseHealthCommittee.MasterResource;
            baseHealthCommittee._HospitalsUnits.Add(hospitalsUnits);
        }

        /// <summary>
        /// HospitalsUnits gride  definition ekranındn gelen 1 satırı add eder.
        /// </summary>
        /// <param name="hospitalsUnitsDefinitionGrid"></param>
        protected override void AddHospitalsUnits(HospitalsUnitsDefinitionGrid hospitalsUnitsDefinitionGrid)
        {
            BaseHealthCommittee_HospitalsUnitsGrid  hospitalsUnitsGrid =new BaseHealthCommittee_HospitalsUnitsGrid(ObjectContext);
            //hospitalsUnitsGrid.Hospital= hospitalsUnitsDefinitionGrid.ExaminationHospital;
            hospitalsUnitsGrid.Unit = hospitalsUnitsDefinitionGrid.Policklinic as ResSection;
            _HospitalsUnits.Add(hospitalsUnitsGrid);
        }
        
        /// <summary>
        /// HospitalsUnitsGrid gridini Reason For Ex. tanım ekranından girilern bilgilere göre doldur.
        /// </summary>
        public override void FillHospitalsUnitsGridDueToReasonForExamination()
        {
            if (MyReasonForExamination() != null)
            {
                ClearHospitalsUnits();
                AddRequesterHospitalsUnits();
                foreach(HospitalsUnitsDefinitionGrid hospitalsUnitsDefinitionGrid in MyReasonForExamination().HospitalsUnits)
                {
                    if (IsHospitalsUnitsAllowedToBeAppended(hospitalsUnitsDefinitionGrid )==true)
                    {
                        AddHospitalsUnits(hospitalsUnitsDefinitionGrid);
                    }
                }
            }
        }
        
        public override EpisodeAction PrepareEpisodeActionForRemoteMethod(bool withNewObjectID)
        {
            return base.PrepareEpisodeActionForRemoteMethod(withNewObjectID);
        }
        
#endregion Methods

    }
}