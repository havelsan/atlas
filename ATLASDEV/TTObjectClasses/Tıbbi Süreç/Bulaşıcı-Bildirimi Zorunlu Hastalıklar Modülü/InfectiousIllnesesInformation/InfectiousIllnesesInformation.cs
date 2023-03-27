
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
    /// Bulaşıcı/Bildirimi Zorunlu Hastalık Bilgileri 
    /// </summary>
    public  partial class InfectiousIllnesesInformation : EpisodeAction, IWorkListEpisodeAction
    {
        public partial class GetInfectiousIllnesesInformationNQL_Class : TTReportNqlObject 
        {
        }

        protected void PreTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
#region PreTransition_New2Cancelled
            
            Cancel();
#endregion PreTransition_New2Cancelled
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
          

#endregion PostTransition_New2Completed
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            
            Cancel();
#endregion PreTransition_Completed2Cancelled
        }

#region Methods
        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList;
            if(base.OldActionPropertyList()==null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            else
                propertyList = base.OldActionPropertyList();
            //-------------------------------------
            
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25814", "Hastalık İsmi"), Common.ReturnObjectAsString(IllnesesName)));
            if(InfectiousIllnesesDiagnosis != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M22736", "Tanı"), Common.ReturnObjectAsString(InfectiousIllnesesDiagnosis.Name)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25813", "Hastalığın Başladığı Tarih"),Common.ReturnObjectAsString(StartTimeOfInfectious)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M19916", "Ölü"),Common.ReturnObjectAsString(NotAlive)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject("Doktor",Common.ReturnObjectAsString(ProcedureDoctor)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M10469", "Açıklama"),Common.ReturnObjectAsString(Description)));
            //---------------------------------------
            return propertyList;
            
        }
        public InfectiousIllnesesInformation(TTObjectContext context, ResSection masterResource) : base(context)
        {
            MasterResource = masterResource;
            CurrentStateDefID=InfectiousIllnesesInformation.States.New;
        }
        
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.InfectiousIllnesesInformation;
            }
        }
        public override void Cancel()
        {
            base.Cancel();
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InfectiousIllnesesInformation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InfectiousIllnesesInformation.States.New && toState == InfectiousIllnesesInformation.States.Cancelled)
                PreTransition_New2Cancelled();
            else if (fromState == InfectiousIllnesesInformation.States.Completed && toState == InfectiousIllnesesInformation.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InfectiousIllnesesInformation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InfectiousIllnesesInformation.States.New && toState == InfectiousIllnesesInformation.States.Completed)
                PostTransition_New2Completed();
        }

    }
}