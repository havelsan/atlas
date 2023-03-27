
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
    /// Randevu Sırası Nesnesi
    /// </summary>
    public  partial class ExaminationQueueItem : TTObject
    {
        public partial class GetActiveExaminationItems_Class : TTReportNqlObject 
        {
        }

        public partial class GetCompletedExaminationQueueItemsGroupedByDoctors_Class : TTReportNqlObject 
        {
        }

        public partial class GetActiveQueueItemsCountInQueueInDate_Class : TTReportNqlObject 
        {
        }

        public partial class GetCompletedItemsGroupedByCompletedBy_Class : TTReportNqlObject 
        {
        }

        public partial class GetCompletedExaminationQueueItems_Class : TTReportNqlObject 
        {
        }

        public partial class GetCompletedItemsGroupedByCompletedByAndDate_Class : TTReportNqlObject 
        {
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();

            if (CurrentStateDefID == ExaminationQueueItem.States.Cancelled || CurrentStateDefID == ExaminationQueueItem.States.Completed)
            {
                ExaminationQueueHistory eh = new ExaminationQueueHistory(ObjectContext);
                eh.Appointment = Appointment;
                eh.ExaminationQueueDefinition = ExaminationQueueDefinition;
                eh.CallTime = CallTime;
                eh.DivertedTime = DivertedTime;
                eh.Doctor = Doctor;
                eh.ExaminationQueueItem = this;
                eh.Patient = Patient;
                eh.QueueDate = QueueDate;
                eh.Priority = Priority;
                eh.DestinationResource = DestinationResource;
                eh.EpisodeAction = EpisodeAction;
                eh.SubactionProcedureFlowable = SubactionProcedureFlowable;
                eh.CompletedBy = CompletedBy;
                eh.HistoryDate = Common.RecTime();
            }
            
            if(CurrentStateDefID.Equals(ExaminationQueueItem.States.Completed) && CompletedBy == null)
            {
                if(Common.CurrentDoctor != null)
                    CompletedBy = Common.CurrentDoctor;
            }
            

#endregion PostUpdate
        }

        protected void PostTransition_New2Diverted()
        {
            // From State : New   To State : Diverted
#region PostTransition_New2Diverted
            DivertTheItem();
#endregion PostTransition_New2Diverted
        }

        protected void PostTransition_Called2Diverted()
        {
            // From State : Called   To State : Diverted
#region PostTransition_Called2Diverted
            DivertTheItem();
#endregion PostTransition_Called2Diverted
        }

#region Methods
        public int OrderNO;
        public DateTime CalculatedEnteranceTime;
        private void DivertTheItem()
        {
            long divertTime = 60;
            if (ExaminationQueueDefinition != null)
            {
                if (ExaminationQueueDefinition.DivertTime.HasValue)
                    divertTime = ExaminationQueueDefinition.DivertTime.Value;
            }
            DivertedTime = TTObjectClasses.Common.RecTime().AddMinutes(divertTime);
            if (Priority.HasValue == true && Priority.Value == 0)
            {
//                foreach(KeyValuePair<int, string> kp in this.EpisodeAction.SubEpisode.PatientAdmission.GetMyPriority(this.ExaminationQueueDefinition, false))
//                {
//                    this.Priority = kp.Key;
//                    this.PriorityReason = kp.Value;
//                    break;
//                }
                
            }
            else //2.kez ertelendiğinde ve sonraki her ertelenmesinde diverttime katlanarak artsın.
            {
                long divertingCount = 0;
                long allowedDivertingCount = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("ALLOWEDDIVERTINGCOUNT","1").ToString());
                foreach (TTObjectState objectState in GetStateHistory())
                {
                    if (objectState.StateDefID.Equals(ExaminationQueueItem.States.Diverted))
                        divertingCount++;
                }
                if(divertingCount >= allowedDivertingCount)
                {
                    //this.Priority += 1000;
                    divertTime = divertTime * divertingCount;
                    DivertedTime = TTObjectClasses.Common.RecTime().AddMinutes(divertTime);
                }
            }
        }

        public static string GetCalledQueueItems(List<Guid> examinationQueueDefinitions)
        {
            TTObjectContext context = new TTObjectContext(true);
            BindingList<ExaminationQueueItem> retList = null;
            DateTime startDate = Common.RecTime().Date;
            DateTime endDate = startDate.AddHours(23).AddMinutes(59);
            retList = ExaminationQueueItem.GetCalledItems(context, examinationQueueDefinitions, endDate, startDate);
            
            StringBuilder strb = new StringBuilder();
            foreach (ExaminationQueueItem item in retList)
            {
                if(item["APPOINTMENT"] == null)
                    strb.AppendLine("_Appointment");
                else
                    strb.AppendLine(item["APPOINTMENT"].ToString() + "_Appointment");
                strb.AppendLine(item.CallTime.ToString() + "_CallTime");
                strb.AppendLine(item.CurrentStateDefID.ToString() + "_CurrentStateDefID");
                strb.AppendLine(item.Patient.FullName + "_FullName");
                if(item.DestinationResource != null)
                    strb.AppendLine(item.DestinationResource.Name + "_DestinationResource");
                else
                    strb.AppendLine("_DestinationResource");
                strb.AppendLine(item.OrderNO.ToString() + "_OrderNo");
                if(item["EPISODEACTION"] == null)
                    strb.AppendLine("_EpisodeAction");
                else
                    strb.AppendLine(item.EpisodeAction.ObjectID.ToString() + "_EpisodeAction");
                if(item.DivertedTime != null)
                    strb.AppendLine(item.DivertedTime.ToString() + "_DivertedTime");
                strb.AppendLine(item.LastState.BranchDate.ToString() + "_LastBranchDate");
                if(item.IsEmergency != null)
                    strb.AppendLine(item.IsEmergency.ToString() + "_IsEmergency");
            }
            return strb.ToString();
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ExaminationQueueItem).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ExaminationQueueItem.States.New && toState == ExaminationQueueItem.States.Diverted)
                PostTransition_New2Diverted();
            else if (fromState == ExaminationQueueItem.States.Called && toState == ExaminationQueueItem.States.Diverted)
                PostTransition_Called2Diverted();
        }

    }
}