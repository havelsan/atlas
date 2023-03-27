
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
    /// Birleştirilen Malzemeyi Düzeltme
    /// </summary>
    public  partial class JoinMaterialRemoval : BaseAction, IWorkListBaseAction
    {
        protected void PreTransition_New2Removal()
        {
            // From State : New   To State : Removal
#region PreTransition_New2Removal
            
          Material.JoinedMaterial = null;

#endregion PreTransition_New2Removal
        }

        protected void PreTransition_Removal2Complated()
        {
            // From State : Removal   To State : Complated
#region PreTransition_Removal2Complated
            
            
            
            Material mat = (Material)ObjectContext.GetObject((Guid)JoinMaterial, typeof(Material));
            Material.JoinedMaterial = mat;

#endregion PreTransition_Removal2Complated
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(JoinMaterialRemoval).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == JoinMaterialRemoval.States.New && toState == JoinMaterialRemoval.States.Removal)
                PreTransition_New2Removal();
            else if (fromState == JoinMaterialRemoval.States.Removal && toState == JoinMaterialRemoval.States.Complated)
                PreTransition_Removal2Complated();
        }

    }
}