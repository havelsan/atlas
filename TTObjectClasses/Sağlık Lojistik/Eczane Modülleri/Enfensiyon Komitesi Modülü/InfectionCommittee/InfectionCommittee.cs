
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
    /// Enfeksiyon Komitesi
    /// </summary>
    public partial class InfectionCommittee : EpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            #region PostTransition_New2Completed

            foreach (InfectionCommitteeDetail detail in InfectionCommitteeDetails)
                detail.DrugOrder.CurrentStateDefID = DrugOrder.States.Planned; 
            
            #endregion PostTransition_New2Completed
        }

        protected void PostTransition_New2Cancel()
        {
            #region PostTransition_New2Cancel
            if (string.IsNullOrEmpty(this.CancelReason))
                throw new Exception("İptal nedeni girilmeden işlem iptal edilemez."); 

            ResUser doctor = null;
            string drugNames = string.Empty;
            foreach (InfectionCommitteeDetail detail in InfectionCommitteeDetails)
            {
                detail.DrugOrder.CurrentStateDefID = DrugOrder.States.Cancelled;
                detail.DrugOrder.EHUCancelReason = this.CancelReason;
                doctor = detail.DrugOrder.RequestedByUser;
                drugNames = drugNames + " " + detail.DrugOrder.Material.Name;
            }
            string messageBody = drugNames + " isimli ilaç(lar) EHU tarafından iptal edilmiştir. Nedeni : " + this.CancelReason;

            UserMessage newMessage = new UserMessage(this.ObjectContext);
            newMessage.InitializeSentMessage();
            newMessage.ToUser = doctor;
            newMessage.Subject = "EHU İptal";
            newMessage.MessageBody = messageBody;
            newMessage.IsSystemMessage = true;
            newMessage.IsSplashMessage = false;
            newMessage.MessageFeedback = true;

            #endregion PostTransition_New2Cancel
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InfectionCommittee).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InfectionCommittee.States.New && toState == InfectionCommittee.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == InfectionCommittee.States.New && toState == InfectionCommittee.States.Cancel)
                PostTransition_New2Cancel();
        }
    }
}