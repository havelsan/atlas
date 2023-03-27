
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
using Newtonsoft.Json;

namespace TTObjectClasses
{
    /// <summary>
    /// Epikriz Oluşturma  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class CreatingEpicrisis : EpisodeAction, IWorkListEpisodeAction
    {
        public partial class GetCreatingEpicrisis_Class : TTReportNqlObject 
        {
        }

        public partial class VEM_HASTA_EPIKRIZ_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
#endregion PreInsert
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.CreatingEpicrisis;
            }
        }
        
     
        
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObject = this as ITTObject;
            if(theObject.IsNew)
            {
                ReportNo.GetNextValue();
            }
        }
        public static void CheckIfExistsWithSameSpeciality(Episode episode, CreatingEpicrisis creatingEpicrisisParam)
        {
            if(creatingEpicrisisParam.ProcedureSpeciality != null)
            {
                foreach (CreatingEpicrisis creatingEpicrisis in episode.CreatingEpicrisis)
                {
                    if((!creatingEpicrisis.IsCancelled) && (creatingEpicrisis.ObjectID != creatingEpicrisisParam.ObjectID))
                    {
                        if (creatingEpicrisisParam.ProcedureSpeciality == creatingEpicrisis.ProcedureSpeciality)
                        {
                            throw new TTException(SystemMessage.GetMessageV3(1135, new string[] { creatingEpicrisisParam.ProcedureSpeciality.Name.ToString()}));
                        }
                    }
                }
            }
        }
        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);
            //CheckIfExistsWithSameSpeciality(episode);

            /*if (subEpisode.Episode.PatientStatus != PatientStatusEnum.Outpatient && this.MasterAction==null )
            {
                throw new TTException(SystemMessage.GetMessage(1136));
            }*/
            
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            //if (ProcedureDoctor != null)
            //{
            //    #region Epikriz Onay İstek Notification
            //    try
            //    {
            //        NotifyDoctors();

            //    }
            //    catch (Exception e)
            //    {
            //        throw e;
            //    }
            //    #endregion

            //}

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {

            base.PostUpdate();
        //    NotifyDoctors();
            
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CreatingEpicrisis).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CreatingEpicrisis.States.ReportEntry && toState == CreatingEpicrisis.States.PreApproval)
                PostTransition_EntryToPreApproval();
        }

        protected void PostTransition_EntryToPreApproval()
        {
            if (ProcedureDoctor != null)
            {
                #region Epikriz Onay İstek Notification
                try
                {
                    NotifyDoctors();

                }
                catch (Exception e)
                {
                    throw e;
                }
                #endregion

            }
        }


        public CreatingEpicrisis(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = CreatingEpicrisis.States.ReportEntry;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }

        public CreatingEpicrisis(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = CreatingEpicrisis.States.ReportEntry;
            //this.MasterAction = subactionProcedureFlowable;
            Episode = subactionProcedureFlowable.Episode;
        }


        private void NotifyDoctors()
        {
            if (IsOldAction != true)
            {
                List<string> doctorlist = new List<string>();
                string messageText = "";
                if (CurrentStateDefID == CreatingEpicrisis.States.PreApproval || HasMemberChanged("ProcedureDoctor"))
                {
                    if (ProcedureDoctor != null)
                    {
                        doctorlist.Add(ProcedureDoctor.ObjectID.ToString());

                        messageText += ProcedureDoctor != null ? "Sayın " + ProcedureDoctor.Name + ", " : ("Sayın Doktor, ");
                        messageText += RequestDate != null ? (RequestDate.Value.ToString("dd MMMM yyyy") + " tarihi " + RequestDate.Value.ToString("HH:mm") + " saatinde ") : "";
                        messageText += Episode.Patient != null ? ("'" + Episode.Patient.FullName + "' hastası için ") : "";        
                        messageText += (Common.CurrentResource.Name + " tarafından ") ;
                        messageText += "tarafınıza epikriz raporu onay istemi yapılmıştır.";
                    }
                }

                if (doctorlist.Count > 0)
                {
                    TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                    atlasNotification.users = doctorlist;
                    atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                    atlasNotification.contentType = TTUtils.AtlasContentType.Action;

                    atlasNotification.content = messageText;
                    var actionData = new { objectDefName = ObjectDef.Name, objectID = ObjectID, episodeObjectID = Episode.ObjectID, patientObjectID = Episode.Patient.ObjectID, formDefId = CurrentStateDef.FormDefID, inputparam = "" };
                    //ActionData actionData = new ActionData(this.ObjectDef.Name, this.ObjectID, this.CurrentStateDef.FormDefID, "");
                    atlasNotification.actionData = actionData;
                    string notificationStr = JsonConvert.SerializeObject(atlasNotification);

                    TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);
                }
            }
        }


        #endregion Methods

    }
}