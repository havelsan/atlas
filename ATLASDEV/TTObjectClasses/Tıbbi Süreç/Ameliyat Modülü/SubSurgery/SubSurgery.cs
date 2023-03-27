
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
    /// Aynı Seansda Birden Fazla Bölüm Ameliyat Gerçekleştirdiğinde Diğer Bölümler İçin Kullanılan Nesnedir 
    /// </summary>
    public  partial class SubSurgery : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public partial class SubSurgeryReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class SubSurgeryReportBySurgeryNQL_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "SURGERY":
                    {
                        Surgery value = (Surgery)newValue;
#region SURGERY_SetParentScript
                        if(value!=null)
            {
                MedulaHastaKabul=value.MedulaHastaKabul;
            }
#endregion SURGERY_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
    

#endregion PostInsert
        }

        protected void PostTransition_SubSurgeryReport2Cancelled()
        {
            // From State : SubSurgeryReport   To State : Cancelled
#region PostTransition_SubSurgeryReport2Cancelled
            Cancel();
#endregion PostTransition_SubSurgeryReport2Cancelled
        }

        protected void UndoTransition_SubSurgeryReport2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SubSurgeryReport   To State : Cancelled
#region UndoTransition_SubSurgeryReport2Cancelled
            NoBackStateBack();
#endregion UndoTransition_SubSurgeryReport2Cancelled
        }

        protected void PreTransition_SubSurgeryReport2Completed()
        {
            // From State : SubSurgeryReport   To State : Completed
#region PreTransition_SubSurgeryReport2Completed
            
            
            SubSurgeryProceduresIsResquired();
            //SurgeryPersonnelIsResquired(); Artık SurgerProcedure Formunda kontrol ediliyor
            if (SurgeryReportNo.Value==null)
                SurgeryReportNo.GetNextValue(FromResource.ObjectID.ToString(), Common.RecTime().Year);

#endregion PreTransition_SubSurgeryReport2Completed
        }

        protected void PostTransition_SubSurgeryReport2Completed()
        {
            // From State : SubSurgeryReport   To State : Completed
            #region PostTransition_SubSurgeryReport2Completed
            CheckDirectPurchaseGridToComplete();
            SetMySubSurgeryProceduresPerformedDate();
            ControlAndCreateAnesthesiaAndNewBornProcedure();
            Surgery.CheckAndComplete(this);
#endregion PostTransition_SubSurgeryReport2Completed
        }

        protected void UndoTransition_SubSurgeryReport2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SubSurgeryReport   To State : Completed
#region UndoTransition_SubSurgeryReport2Completed
            
            
            if(Surgery.CurrentStateDefID==Surgery.States.Completed )
            {
                throw new Exception(SystemMessage.GetMessage(618));
            }
            ControlAndCancelAnesthesiaAndNewBornProcedure();
#endregion UndoTransition_SubSurgeryReport2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
#region UndoTransition_Completed2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Completed2Cancelled
        }


#region Methods
        public SubSurgery(Surgery surgery,ResSection fromResource,ResUser procedureDoctor) : this(surgery.ObjectContext)
        {
            SetMandatoryEpisodeActionProperties((EpisodeAction)surgery,surgery.MasterResource,fromResource,true);
            ProcedureDoctor=procedureDoctor;
            Surgery=surgery;
            SecondaryMasterResource=surgery.FromResource;
            CurrentStateDefID = SubSurgery.States.SubSurgeryReport;
        }
        
        public void SubSurgeryProceduresIsResquired()
        {
            if (SubSurgeryProcedures.Count<1)
            {
                throw new Exception(SystemMessage.GetMessage(619));
            }
        }

        // Artıl SurgeryProcedureFormda yapılıyor.
        public void SurgeryPersonnelIsResquired()
        {
           
                        string errorString="";
            //            foreach( SurgeryProcedure sP in this.SubSurgeryProcedures)
            //            {
            //                if (sP.SurgeryPersonnel.Count<1)
            //                {
            //                    errorString= sP.ProcedureObject.Name + " ameliyatı için Ameliyat Ekibi Girmediniz \n ";
            //                }
            //                if(errorString!="")
            //                {
            //                    throw new Exception(errorString);
            //                }
            //            }
             // Şimdilik personel zorlması kaldırıldı Sorumlu doktor seçilmesi yeterli
             foreach( SurgeryProcedure sP in SubSurgeryProcedures)
             {
                 if (sP.ProcedureDoctor==null)
                 {
                     errorString= sP.ProcedureObject.Name + " ameliyatı için Sorumlu Cerrah girmediniz \n ";
                 }
                 if(errorString!="")
                 {
                     throw new Exception(errorString);
                 }
             }
        }
        public override void Cancel()
        {
            base.Cancel();
            if(SurgeryParticipantDepartment.Count>0)
                SurgeryParticipantDepartment[0].SubSurgery=null;
            if(Surgery!=null)
            {
                Surgery.CheckAndComplete(this);
            }
            
        }
       
        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList;
            if(base.OldActionPropertyList()==null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            else
                propertyList = base.OldActionPropertyList();
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25166", "Ameliyatı Tarihi"),Common.ReturnObjectAsString(Surgery.SurgeryStartTime)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M20821", "Rapor No"),Common.ReturnObjectAsString(SurgeryReportNo)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M20864", "Rapor Tarihi"),Common.ReturnObjectAsString(SurgeryReportDate)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject("Rapor ",Common.ReturnObjectAsString(SurgeryReport)));
            if(ProcedureDoctor!=null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22142", "Sorumlu Doktor"),Common.ReturnObjectAsString(ProcedureDoctor.Name)));
            if(ProcedureSpeciality!=null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M27149", "Uzmanlık Dalı"),Common.ReturnObjectAsString(ProcedureSpeciality.Name)));
            
            return propertyList;
        }
        
        
        protected override List<List<List<EpisodeAction.OldActionPropertyObject>>> OldActionChildRelationList()
        {
            List<List<List<EpisodeAction.OldActionPropertyObject>>> gridList;
            if(base.OldActionChildRelationList()==null)
                gridList=new List<List<List<EpisodeAction.OldActionPropertyObject>>>();
            else
                gridList=base.OldActionChildRelationList();
            
            // Ek Ameliyat İşlemleri
            List<List<EpisodeAction.OldActionPropertyObject>> gridSubSurgeryProceduresRowList=new List<List<EpisodeAction.OldActionPropertyObject>>();
            foreach(SurgeryProcedure Procedure in SubSurgeryProcedures)
            {
                List<EpisodeAction.OldActionPropertyObject> gridSubSurgeryProceduresRowColumnList=new List<EpisodeAction.OldActionPropertyObject>();
                gridSubSurgeryProceduresRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M16886", "İşlem Tarihi"),Common.ReturnObjectAsString(Procedure.ActionDate)));
                gridSubSurgeryProceduresRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25156", "Ameliyat İşlemi"),Common.ReturnObjectAsString(Procedure.ProcedureObject.Name)));
                gridSubSurgeryProceduresRowList.Add(gridSubSurgeryProceduresRowColumnList);
            }
            gridList.Add(gridSubSurgeryProceduresRowList);
            
            return gridList;
        }


        public void ControlAndCreateAnesthesiaAndNewBornProcedure()
        {
            if (!Surgery.HasUncompletedSurgery(this))
            {
                //Surgery.AccountingOperation();
                Surgery.CreateAnesthesiaAndNewBornProcedure();
            }
        }

        public void ControlAndCancelAnesthesiaAndNewBornProcedure()
        {
            if (!Surgery.HasUncompletedSurgery(this))
                Surgery.CancelAnesthesiaAndNewBornProcedure();
        }

        public void SetMySubSurgeryProceduresPerformedDate()
        {
            if(Surgery.SurgeryEndTime != null)
            {
                foreach (var subSurgeryProcedure in SubSurgeryProcedures)
                {
                    if (subSurgeryProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        subSurgeryProcedure.PerformedDate = Surgery.SurgeryEndTime;
                }
            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SubSurgery).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SubSurgery.States.SubSurgeryReport && toState == SubSurgery.States.Completed)
                PreTransition_SubSurgeryReport2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SubSurgery).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SubSurgery.States.SubSurgeryReport && toState == SubSurgery.States.Cancelled)
                PostTransition_SubSurgeryReport2Cancelled();
            else if (fromState == SubSurgery.States.SubSurgeryReport && toState == SubSurgery.States.Completed)
                PostTransition_SubSurgeryReport2Completed();
            else if (fromState == SubSurgery.States.Completed && toState == SubSurgery.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SubSurgery).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SubSurgery.States.SubSurgeryReport && toState == SubSurgery.States.Cancelled)
                UndoTransition_SubSurgeryReport2Cancelled(transDef);
            else if (fromState == SubSurgery.States.SubSurgeryReport && toState == SubSurgery.States.Completed)
                UndoTransition_SubSurgeryReport2Completed(transDef);
            else if (fromState == SubSurgery.States.Completed && toState == SubSurgery.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }

    }
}