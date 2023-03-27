
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
    /// Patoloji
    /// </summary>
    public  partial class PathologyRequest : EpisodeActionWithDiagnosis, IWorkListEpisodeAction, IAllocateSpeciality
    {
        public partial class PathologyReqStateInfoNQL_Class : TTReportNqlObject 
        {
        }

        public partial class PathologyResultReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class PathologyRequestPatientInfoReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class PathologyRequestInfoStickerNQL_Class : TTReportNqlObject 
        {
        }

        public partial class PathologyResultPatientInfoReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class SearchPathologies_Class : TTReportNqlObject 
        {
        }

        public partial class PathologyRequestBarcodeNQL_Class : TTReportNqlObject 
        {
        }

        #region IAllocateSpeciality Members
        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        public EpisodeAction GetMyEpisodeAction()
        {
            return MyEpisodeAction;
        }

        public void SetMyEpisodeAction(EpisodeAction value)
        {
            MyEpisodeAction = value;
        }

        public SubActionProcedure GetMySubActionProcedure()
        {
            return MySubActionProcedure;
        }

        public void SetMySubActionProcedure(SubActionProcedure value)
        {
            MySubActionProcedure = value;
        }

        public SpecialityDefinition GetProcedureSpeciality()
        {
            return ProcedureSpeciality;
        }

        public void SetProcedureSpeciality(SpecialityDefinition value)
        {
            ProcedureSpeciality = value;
        }

        #endregion

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            //TODO ASLI Kontrol
            //foreach (Pathology pt in this.Pathologies)
            //{
            //    if(pt.CurrentStateDefID == Pathology.States.Request)
            //    {
            //        PathologyTestDefinition testDef = (PathologyTestDefinition)pt.ProcedureObject;

            //        //this.Update();
            //        pt.CurrentStateDefID = testDef.RequestApprove == true
            //            ? Pathology.States.RequestApprovement
            //            : Pathology.States.RequestAcception;
            //    }                
            //}
      
#endregion PostUpdate
        }


#region Methods
        public PathologyRequest(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            //this.MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = PathologyRequest.States.Accept;
            Episode = episodeAction.Episode;
            ProcedureSpeciality=episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
        }
        
        public PathologyRequest(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = PathologyRequest.States.Accept;
            Episode = subactionProcedureFlowable.Episode;
            ProcedureSpeciality=subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
        }
        
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.Pathology;
            }
        }
       
        
        public override EpisodeAction PrepareEpisodeActionForRemoteMethod(bool withNewObjectID)
        {
            PathologyRequest pathology = (PathologyRequest)base.PrepareEpisodeActionForRemoteMethod(withNewObjectID);
            
            if(withNewObjectID)
            {
          
                pathology.RequestDoctor = null;
            }
            return pathology;
        }
        
   
            
        override public void DoMyActionControlsForProcedureRequest()
        {

            if (RequestDoctor == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26155", "İstek yapan tabip bilgisini giriniz!"));    
        }

        override public void SetMyActionMandatoryProperties()
        {

            RequestDoctor = Common.CurrentResource;

         }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PathologyRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;


            /*new -> request
              request -> cancelled
              request -> procedure
              request -> rejected --Red stateini kontrol et
              procedure -> cancelled */

            if (fromState == PathologyRequest.States.Accept && toState == PathologyRequest.States.Cancelled)
                Cancel();
            else if(fromState == PathologyRequest.States.Accept && toState == PathologyRequest.States.Procedure)
                PostTransition_Request2Procedure();
            else if (fromState == PathologyRequest.States.Procedure && toState == PathologyRequest.States.Cancelled)
                Cancel();
        }


        protected void PostTransition_Request2Procedure()
        {
            // From State : Request   To State : Procedure
            //Patoloji Kabul Yapıldığında Patoloji Yarat
            #region PostTransition_Request2Procedure
            //TTObjectContext newContext = new TTObjectContext(false);
            //Pathology pathology = new Pathology(newContext);
            //pathology.MasterResource = this.MasterResource;

            //pathology.FromResource = this.FromResource;
            //pathology.CurrentStateDefID = Pathology.States.Procedure;
            //pathology.ActionDate = Common.RecTime();
            //pathology.MaterialResponsible = this.MaterialResponsible;
            //pathology.Episode = this.Episode;


            ////pathology.ProcedureObject = testDef;
            ////pathology.EpisodeAction = this;


            //this.Pathologies.Add(pathology);
            //newContext.Save();
            //pathology.CurrentStateDefID = Pathology.States.Procedure;
            //this.CurrentStateDefID = PathologyRequest.States.Procedure;
            //foreach (PathologyMaterial material in this.PathologyMaterials)
            //{
            //    pathology.PathologyMaterial.Add(material);
            //}

            //if (pathology.MatPrtNoString == "" || pathology.MatPrtNoString == null)
            //{
            //    pathology.SeqNo.GetNextValue(Common.RecTime().Year);
            //    pathology.MaterialPrtNoPostFix = Common.RecTime().Year.ToString();
            //    newContext.Save();
            //    pathology.MatPrtNoString = pathology.SeqNo.Value.ToString() + "/" + pathology.MaterialPrtNoPostFix;
            //    newContext.Save();
            //}
            #endregion PostTransition_Request2Procedure
        }

        override public Guid ProcedureRequestStartedStateDefID()
        {
            return (Guid)PathologyRequest.States.Accept;
        }

    }
}