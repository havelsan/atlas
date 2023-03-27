
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Baş Tabib / Birlik XXXXXXı Onay
    /// </summary>
    public partial class ConsultantApprovalForm : RUL_BaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region ConsultantApprovalForm_PreScript
    base.PreScript();
            
            if (_ReferToUpperLevel.ReferType == ReferTypeEnum.TeamRequest)
            {
                this.DropStateButton(ReferToUpperLevel.States.TemporaryAdmissionRegistry);
            }
            else
            {
                this.DropStateButton(ReferToUpperLevel.States.TeamRequest);
            }
#endregion ConsultantApprovalForm_PreScript

            }
            
#region ConsultantApprovalForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == ReferToUpperLevel.States.UpperLevelCommander)
            {
                Sites site = _ReferToUpperLevel.Stage.MilitaryUnit.Site;
                TTObjectContext trashContext = new TTObjectContext (false);
                ReferToUpperLevel newRUL = (ReferToUpperLevel)trashContext.GetObject(_ReferToUpperLevel.ObjectID, _ReferToUpperLevel.ObjectDef);
                newRUL.Stage = null;
                if(_ReferToUpperLevel.FixedAssetMaterialDefinition !=null)
                {
                    FixedAssetMaterialDefinition newFAMD = (FixedAssetMaterialDefinition)trashContext.GetObject(_ReferToUpperLevel.FixedAssetMaterialDefinition.ObjectID, _ReferToUpperLevel.FixedAssetMaterialDefinition.ObjectDef);
                    newFAMD.Personnel = null;
                    newFAMD.Resource = null;
                    newFAMD.ResUser = null;
                    newFAMD.Service = null;
                    newFAMD.Stock = null;
                    
                  //  TTMessage message = ReferToUpperLevel.RemoteMethods.CreateReferToUpperLevel(site.ObjectID, newRUL,newFAMD);
                    trashContext.Dispose();
                }
               
            }
        }
        
#endregion ConsultantApprovalForm_Methods
    }
}