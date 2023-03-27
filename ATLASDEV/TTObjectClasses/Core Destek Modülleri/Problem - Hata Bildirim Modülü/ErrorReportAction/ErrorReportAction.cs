
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
    /// Problem / Hata Bildirimi
    /// </summary>
    public  partial class ErrorReportAction : BaseAction, IErrorReportWorkList
    {
        public partial class GetErrorReportAction_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "FROMUSER":
                    {
                        ResUser value = (ResUser)newValue;
#region FROMUSER_SetParentScript
                        FromTelephone = value.PhoneNumber;
#endregion FROMUSER_SetParentScript
                    }
                    break;
                case "ERRORREPORTCATEGORY":
                    {
                        ErrorReportCategory value = (ErrorReportCategory)newValue;
#region ERRORREPORTCATEGORY_SetParentScript
                        ToResource = value.ToResource;
#endregion ERRORREPORTCATEGORY_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PreTransition_Approved2Assigned()
        {
            // From State : Approved   To State : Assigned
#region PreTransition_Approved2Assigned
            

            SolutionStartDateTime = Common.RecTime();
#endregion PreTransition_Approved2Assigned
        }

        protected void PreTransition_Assigned2Completed()
        {
            // From State : Assigned   To State : Completed
#region PreTransition_Assigned2Completed
            

            SolutionEndDateTime = Common.RecTime();
#endregion PreTransition_Assigned2Completed
        }

        protected void PreTransition_New2Approved()
        {
            // From State : New   To State : Approved
#region PreTransition_New2Approved
            
            







            if (ErrorReportInventory != null)
            {

                //envanter seçilmiş, açık kayıt var mı kontrol edelim
                TTObjectContext tto = new TTObjectContext(true);

                BindingList<ErrorReportAction> errReps = ErrorReportAction.ErrorReportByInventoryQuery(tto, ErrorReportInventory.ObjectID);

                foreach (ErrorReportAction errRep in errReps)
                {

                    if (errRep.LastState.StateDefID == ErrorReportAction.States.Approved || errRep.LastState.StateDefID == ErrorReportAction.States.Assigned)
                    {
                        throw new TTException(SystemMessage.GetMessageV3(998, new string[] { errRep.ErrorReportInventory.No.Value.ToString(), errRep.ErrorReportInventory.Name.ToString(), errRep.ActionDate.Value.ToString(), errRep.FromResource.Name.ToString(), errRep.FromUser.Name.ToString(), errRep.FromTelephone.ToString() }));
                    }

                }

            }







            //envanter no kaldırıldı bu kısım eski kaldırılabilir
            if (InventoryNo.HasValue)
            {
                //envanter no girilmiş, açık kayıt var mı kontrol edelim
                TTObjectContext tto = new TTObjectContext(true);

                BindingList<ErrorReportAction> errReps = ErrorReportAction.ErrorReportByInventoryNoQuery(tto, InventoryNo.Value);

                foreach (ErrorReportAction errRep in errReps)
                {

                    if (errRep.LastState.StateDefID == ErrorReportAction.States.Approved || errRep.LastState.StateDefID == ErrorReportAction.States.Assigned || errRep.LastState.StateDefID == ErrorReportAction.States.New)
                    {
                        throw new TTException(SystemMessage.GetMessageV3(999, new string[] { InventoryNo.Value.ToString(), errRep.ActionDate.Value.Date.ToString(), errRep.FromResource.Name.ToString(), errRep.FromUser.Name.ToString(), errRep.FromTelephone.ToString() }));
                    }

                }
            }

#endregion PreTransition_New2Approved
        }

        protected void PostTransition_New2Approved()
        {
            // From State : New   To State : Approved
#region PostTransition_New2Approved
            

            //            
            //            TTObjectContext tto = new TTObjectContext(false);
            //            ErrorReportAction errRepAction = (ErrorReportAction)tto.GetObject(this.ObjectID, typeof(ErrorReportAction));
            //            if (errRepAction.ErrorReportCategory.OwnerResource != null)
            //            {
            //                errRepAction.OwnerResource = errRepAction.ErrorReportCategory.OwnerResource;
            //                errRepAction.CurrentStateDefID = ErrorReportAction.States.Assigned;
            //            }
            //            if (errRepAction.ErrorReportCategory.CategoryPriority != null)
            //            {
            //                errRepAction.ErrorPriority = errRepAction.ErrorReportCategory.CategoryPriority;
            //                errRepAction.CurrentStateDefID = ErrorReportAction.States.Assigned;
            //            }


#endregion PostTransition_New2Approved
        }

        protected void UndoTransition_New2Approved(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Approved
#region UndoTransition_New2Approved
            NoBackStateBack();
#endregion UndoTransition_New2Approved
        }

        protected void PreTransition_New2Assigned()
        {
            // From State : New   To State : Assigned
#region PreTransition_New2Assigned
            
            




            if (ErrorReportInventory != null)
            {

                //envanter seçilmiş, açık kayıt var mı kontrol edelim
                TTObjectContext tto = new TTObjectContext(true);

                BindingList<ErrorReportAction> errReps = ErrorReportAction.ErrorReportByInventoryQuery(tto, ErrorReportInventory.ObjectID);

                foreach (ErrorReportAction errRep in errReps)
                {

                    if (errRep.LastState.StateDefID == ErrorReportAction.States.Approved || errRep.LastState.StateDefID == ErrorReportAction.States.Assigned || errRep.LastState.StateDefID == ErrorReportAction.States.New)
                    {
                        throw new TTException(SystemMessage.GetMessageV3(998, new string[] { errRep.ErrorReportInventory.No.Value.ToString(),errRep.ErrorReportInventory.Name.ToString(), errRep.ActionDate.Value.ToString(), errRep.FromResource.Name.ToString(),errRep.FromUser.Name.ToString(),errRep.FromTelephone.ToString()}));
                    }

                }

            }
            
                //varsayılan birimi atayalım               
                if (ErrorReportCategory.OwnerResource != null)
                {
                    OwnerResource = ErrorReportCategory.OwnerResource;

                }
                if (ErrorReportCategory.CategoryPriority != null)
                {
                    ErrorPriority = ErrorReportCategory.CategoryPriority;
                }

                //solution start time
                SolutionStartDateTime = Common.RecTime();            

#endregion PreTransition_New2Assigned
        }

        protected void UndoTransition_New2Assigned(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Assigned
#region UndoTransition_New2Assigned
            NoBackStateBack();
#endregion UndoTransition_New2Assigned
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
            {
                ErrorReportNO.GetNextValue(ActionDate.Value.Year);
            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ErrorReportAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ErrorReportAction.States.Approved && toState == ErrorReportAction.States.Assigned)
                PreTransition_Approved2Assigned();
            else if (fromState == ErrorReportAction.States.Assigned && toState == ErrorReportAction.States.Completed)
                PreTransition_Assigned2Completed();
            else if (fromState == ErrorReportAction.States.New && toState == ErrorReportAction.States.Approved)
                PreTransition_New2Approved();
            else if (fromState == ErrorReportAction.States.New && toState == ErrorReportAction.States.Assigned)
                PreTransition_New2Assigned();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ErrorReportAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ErrorReportAction.States.New && toState == ErrorReportAction.States.Approved)
                PostTransition_New2Approved();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ErrorReportAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ErrorReportAction.States.New && toState == ErrorReportAction.States.Approved)
                UndoTransition_New2Approved(transDef);
            else if (fromState == ErrorReportAction.States.New && toState == ErrorReportAction.States.Assigned)
                UndoTransition_New2Assigned(transDef);
        }

    }
}