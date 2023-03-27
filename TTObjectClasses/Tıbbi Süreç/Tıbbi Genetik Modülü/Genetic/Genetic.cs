
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
    /// Tıbbi Genetik İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class Genetic : EpisodeActionWithDiagnosis, IWorkListGenetic, IWorkListEpisodeAction, ITreatmentMaterialCollection
    {
        public partial class GeneticReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GeneticSampleReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GeneticResultReportPatientInfoQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetByGeneticFilterExpressionReport_Class : TTReportNqlObject 
        {
#region GetByGeneticFilterExpressionReport_Methods
            
        public string RefNo
        {
            get
            {
                if (Foreign == true)
                    return "(*) " + Convert.ToString(UniqueRefNo);
                else
                    return Convert.ToString(UniqueRefNo);
            }
        }
            
#endregion GetByGeneticFilterExpressionReport_Methods

        }

        public partial class GetByGeneticWorklistDateReport_Class : TTReportNqlObject 
        {
#region GetByGeneticWorklistDateReport_Methods
            
        public string RefNo
        {
            get
            {
                if (Foreign == true)
                    return "(*) " + Convert.ToString(UniqueRefNo);
                else
                    return Convert.ToString(UniqueRefNo);
            }
        }
            
#endregion GetByGeneticWorklistDateReport_Methods

        }

        protected void PreTransition_Approvement2Request()
        {
            // From State : Approvement   To State : Request
#region PreTransition_Approvement2Request
            
            //this.DisplayRepeatReason();

#endregion PreTransition_Approvement2Request
        }

        protected void PreTransition_Approvement2RequestAcception()
        {
            // From State : Approvement   To State : RequestAcception
#region PreTransition_Approvement2RequestAcception
            
            //this.DisplayRepeatReason();

#endregion PreTransition_Approvement2RequestAcception
        }

        protected void PreTransition_Approvement2Completed()
        {
            // From State : Approvement   To State : Completed
#region PreTransition_Approvement2Completed
            
            if(OlapDate == null)
                OlapDate = DateTime.Now;
#endregion PreTransition_Approvement2Completed
        }

        protected void PostTransition_Approvement2Completed()
        {
            // From State : Approvement   To State : Completed
#region PostTransition_Approvement2Completed
            
            //ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            //if(currentResUser != null)
                //this.ApprovedBy = currentResUser;
                //Puan alacak kişi ProcedureDoctor olarak değiştirildiği için commentlendi.
                ApprovedBy = ProcedureDoctor;
               
                SetMySubActionProceduresPerformedDate();
                  

#endregion PostTransition_Approvement2Completed
        }

        protected void PreTransition_Approvement2Procedure()
        {
            // From State : Approvement   To State : Procedure
#region PreTransition_Approvement2Procedure
            
            //this.DisplayRepeatReason();
            

#endregion PreTransition_Approvement2Procedure
        }

        protected void PostTransition_Analysis2Approvement()
        {
            // From State : Analysis   To State : Approvement
#region PostTransition_Analysis2Approvement
            
            ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            if(currentResUser != null)
                AnalizedBy = currentResUser;

#endregion PostTransition_Analysis2Approvement
        }

#region Methods
        public Genetic(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = Genetic.States.Request;
            ProcedureSpeciality=episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }
        
        public Genetic(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = Genetic.States.Request;
            ProcedureSpeciality=subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
            Episode = subactionProcedureFlowable.Episode;
        }
        
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.Genetic;
            }
        }
        /// <summary>
        /// Tekrar nedenlerinin oluşturulduğu metoddur.Pre transitionda kullanılır.
        /// </summary>
      
        
        
        
            override public Guid ProcedureRequestStartedStateDefID()
        {
             return (Guid)Genetic.States.RequestAcception;
        }
            
        override public void DoMyActionControlsForProcedureRequest()
        {
           if (!GeneticSampleNo.Value.HasValue)
                GeneticSampleNo.GetNextValue();

        }
        
         override  public void SetMyActionMandatoryProperties()
        {
            RequestDoctor = Common.CurrentResource;
            Emergency = false;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Genetic).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Genetic.States.Approvement && toState == Genetic.States.Request)
                PreTransition_Approvement2Request();
            else if (fromState == Genetic.States.Approvement && toState == Genetic.States.RequestAcception)
                PreTransition_Approvement2RequestAcception();
            else if (fromState == Genetic.States.Approvement && toState == Genetic.States.Completed)
                PreTransition_Approvement2Completed();
            else if (fromState == Genetic.States.Approvement && toState == Genetic.States.Procedure)
                PreTransition_Approvement2Procedure();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Genetic).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Genetic.States.Approvement && toState == Genetic.States.Completed)
                PostTransition_Approvement2Completed();
            else if (fromState == Genetic.States.Analysis && toState == Genetic.States.Approvement)
                PostTransition_Analysis2Approvement();
        }

    }
}