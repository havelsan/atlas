
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
    /// Hemşirelik İşlemleri Şablon
    /// </summary>
    public  partial class NursingApplicationTemplate : BaseAction, IWorkListBaseAction
    {
        protected void PreTransition_Create2Complated()
        {
            // From State : Create   To State : Complated
#region PreTransition_Create2Complated
            
            
            if(NursingAppTempDetails.Count > 0 )
            {
                string description = TemplateName;
                IList userTemplates = Common.CurrentResource.UserTemplates.Select("TAOBJECTDEFID = " + ConnectionManager.GuidToString(ObjectDef.ID) + " AND DESCRIPTION = '" + description + "'");
                
                if (userTemplates.Count == 0)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    UserTemplate userTemplate = new UserTemplate(context);
                    userTemplate.ResUser = (ResUser)Common.CurrentResource;
                    userTemplate.Description = description;
                    userTemplate.TAObjectID = ObjectID;
                    userTemplate.TAObjectDefID = ObjectDef.ID;
                    userTemplate.FiliterData = "NURSINGAPPLICATIONTEM";
                    context.Save();
                    context.Dispose();
                }
                else
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(description + " isimli şablonunuz bulunduğu için şablon kayıt edilemedi");
                }
            }
            else
                throw new Exception("Şablon için sarf malzeme seçilmemiştir.");
            
            
           

#endregion PreTransition_Create2Complated
        }

        protected void UndoTransition_Create2Complated(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Create   To State : Complated
#region UndoTransition_Create2Complated
            NoBackStateBack();
#endregion UndoTransition_Create2Complated
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NursingApplicationTemplate).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == NursingApplicationTemplate.States.Create && toState == NursingApplicationTemplate.States.Complated)
                PreTransition_Create2Complated();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NursingApplicationTemplate).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == NursingApplicationTemplate.States.Create && toState == NursingApplicationTemplate.States.Complated)
                UndoTransition_Create2Complated(transDef);
        }

    }
}