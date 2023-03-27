
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
    /// Hastanın Önemli Tıbbi Bilgilerinin Grişinin Yapıldığı Nesnedir.
    /// </summary>
    public  partial class ImportantMedicalInformation : EpisodeAction
    {
        protected override void PostInsert()
        {
#region PostInsert
            
            if (Episode.Patient.ImportantMedicalInformation!=null)
            {
                if(ObjectID!=Episode.Patient.ImportantMedicalInformation.ObjectID){
                    Episode.Patient.ImportantMedicalInformation.UnActive=true;
                    ((ITTObject)Episode.Patient.ImportantMedicalInformation).Cancel();
                }
            }
            Episode.Patient.ImportantMedicalInformation=(ImportantMedicalInformation)this;
#endregion PostInsert
        }

        protected void PostTransition_Completed2InActive()
        {
            // From State : Completed   To State : InActive
#region PostTransition_Completed2InActive
            Cancel();
#endregion PostTransition_Completed2InActive
        }

        protected void UndoTransition_Completed2InActive(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : InActive
#region UndoTransition_Completed2InActive
            NoBackStateBack();
#endregion UndoTransition_Completed2InActive
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
#region UndoTransition_New2Completed
            
            NoBackStateBack();
#endregion UndoTransition_New2Completed
        }

        protected void PostTransition_New2InActive()
        {
            // From State : New   To State : InActive
#region PostTransition_New2InActive
            Cancel();
#endregion PostTransition_New2InActive
        }

        protected void UndoTransition_New2InActive(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : InActive
#region UndoTransition_New2InActive
            NoBackStateBack();
#endregion UndoTransition_New2InActive
        }

#region Methods
        //        protected override List<OldActionPropertyObject> OldActionPropertyList()
        //        {
        //            List<OldActionPropertyObject> propertyList;
        //            if(base.OldActionPropertyList()==null)
        //                propertyList = new List<OldActionPropertyObject>();
        //            else
        //                propertyList = base.OldActionPropertyList();
        //            //-------------------------------------
//
        //            propertyList.Add(new OldActionPropertyObject("Kan Grubu", Common.ReturnObjectAsString(BloodGroup)));
        //            propertyList.Add(new OldActionPropertyObject("Aile",Common.ReturnObjectAsString(ParentHistory)));
        //            propertyList.Add(new OldActionPropertyObject("Özgeçmiş", Common.ReturnObjectAsString(PatientHistory)));
        //            propertyList.Add(new OldActionPropertyObject("Sosyal", Common.ReturnObjectAsString(SocialHistory)));
//
        //            //---------------------------------------
        //            return propertyList;
//
        //        }
        
        //        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        //        {
        //            List<List<List<OldActionPropertyObject>>> gridList;
        //            if(base.OldActionChildRelationList()==null)
        //                gridList=new List<List<List<OldActionPropertyObject>>>();
        //            else
        //                gridList=base.OldActionChildRelationList();
//
        //            List<List<OldActionPropertyObject>> gridFolderContentsRowList = new List<List<OldActionPropertyObject>>();
//
        //            foreach( Vaccination vc in Vaccinations )
        //            {
        //                List<OldActionPropertyObject> gridFolderContentsRowColumnList=new List<OldActionPropertyObject>();
        //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Aşı",Common.ReturnObjectAsString(vc.Name)));
        //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Geçerliliği",Common.ReturnObjectAsString(vc.Effectiveness)));
        //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Risk",Common.ReturnObjectAsString(vc.Risk)));
        //                gridFolderContentsRowList.Add(gridFolderContentsRowColumnList);
        //            }
        //            gridList.Add(gridFolderContentsRowList);
//
        //            gridFolderContentsRowList = new List<List<OldActionPropertyObject>>();
//
        //            foreach(Allergy all in Allergies )
        //            {
        //                List<OldActionPropertyObject> gridFolderContentsRowColumnList=new List<OldActionPropertyObject>();
//
        //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Allerji",Common.ReturnObjectAsString(all.Name)));
        //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Reaksiyon",Common.ReturnObjectAsString(all.Reaction )));
        //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Risk",Common.ReturnObjectAsString(all.Risk)));
        //                gridFolderContentsRowList.Add(gridFolderContentsRowColumnList);
        //            }
        //            gridList.Add(gridFolderContentsRowList);
//
//
        //            gridFolderContentsRowList = new List<List<OldActionPropertyObject>>();
//
        //            foreach(DiagnosisGrid diagnosis in DiagnosisHistory )
        //            {
        //                List<OldActionPropertyObject> gridFolderContentsRowColumnList=new List<OldActionPropertyObject>();
//
        //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Tarih",Common.ReturnObjectAsString(diagnosis.DiagnoseDate )));
        //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Tanı",Common.ReturnObjectAsString(diagnosis.Diagnose.Name)));
        //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Tanıyı Koyan",Common.ReturnObjectAsString(diagnosis.ResponsibleUser.Name)));
        //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Ana Tanı",Common.ReturnObjectAsString(diagnosis.IsMainDiagnose )));
        //                gridFolderContentsRowList.Add(gridFolderContentsRowColumnList);
        //            }
        //            gridList.Add(gridFolderContentsRowList);
//
//
        //            return gridList;
        //        }
        
        
        
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.ImportantMedicalInformation;
            }
        }

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);
            var episode = subEpisode.Episode;
            if (episode != null)
            {
               
                
                if (episode.Patient.ImportantMedicalInformation!=null)
                {
                    WarnAllMedicalPersonnel=episode.Patient.ImportantMedicalInformation.WarnAllMedicalPersonnel;
                    PatientHistory = episode.Patient.ImportantMedicalInformation.PatientHistory;
                    BloodGroup = episode.Patient.ImportantMedicalInformation.BloodGroup;
                    ParentHistory = episode.Patient.ImportantMedicalInformation.ParentHistory;
                    SocialHistory = episode.Patient.ImportantMedicalInformation.SocialHistory;
                    IsPregnant = episode.Patient.ImportantMedicalInformation.IsPregnant;
                    
                    
                    lock(episode.Patient.ImportantMedicalInformation.Vaccinations)
                    {
                        while(episode.Patient.ImportantMedicalInformation.Vaccinations.Count>0)
                        {
                            Vaccinations.Add(episode.Patient.ImportantMedicalInformation.Vaccinations[0]);
                        }
                    }
                    
                    lock(episode.Patient.ImportantMedicalInformation.Allergies)
                    {
                        while(episode.Patient.ImportantMedicalInformation.Allergies.Count>0)
                        {
                            Allergies.Add(episode.Patient.ImportantMedicalInformation.Allergies[0]);
                        }
                    }
                    
                    
                    
                    lock(episode.Patient.ImportantMedicalInformation.DiagnosisHistory)
                    {
                        while(episode.Patient.ImportantMedicalInformation.DiagnosisHistory.Count>0)
                        {
                            DiagnosisHistory.Add(episode.Patient.ImportantMedicalInformation.DiagnosisHistory[0]);
                        }
                    }
                    lock(episode.Patient.ImportantMedicalInformation.CancelledDiagnosis)
                    {
                        while(episode.Patient.ImportantMedicalInformation.CancelledDiagnosis.Count>0)
                        {
                            CancelledDiagnosis.Add(episode.Patient.ImportantMedicalInformation.CancelledDiagnosis[0]);
                        }
                    }
                }

                
            }
        }
        
        
        public ImportantMedicalInformation(Episode episode, ResSection fromResource, TTObjectContext objectContext):this(objectContext)
        {
            CurrentStateDefID=ImportantMedicalInformation.States.New;
            ActionDate = Common.RecTime();
            MasterResource = (ResSection)Common.GetCurrentHospital(objectContext);
            FromResource = (ResSection)fromResource;
            Episode = episode;
            Episode.Patient.ImportantMedicalInformation=(ImportantMedicalInformation)this;
            Update();
            CurrentStateDefID=ImportantMedicalInformation.States.Completed;
        }
        
        public class TestDataSetSerialization
        {
            public List<Episode> EpisodeList = new List<Episode>();
        }
        
      
        public override void Cancel()
        {
            if (UnActive!=true)
                throw new Exception(SystemMessage.GetMessage(512));
            else
                base.Cancel();
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ImportantMedicalInformation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ImportantMedicalInformation.States.Completed && toState == ImportantMedicalInformation.States.InActive)
                PostTransition_Completed2InActive();
            else if (fromState == ImportantMedicalInformation.States.New && toState == ImportantMedicalInformation.States.InActive)
                PostTransition_New2InActive();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ImportantMedicalInformation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ImportantMedicalInformation.States.Completed && toState == ImportantMedicalInformation.States.InActive)
                UndoTransition_Completed2InActive(transDef);
            else if (fromState == ImportantMedicalInformation.States.New && toState == ImportantMedicalInformation.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == ImportantMedicalInformation.States.New && toState == ImportantMedicalInformation.States.InActive)
                UndoTransition_New2InActive(transDef);
        }

    }
}