
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
    /// BaseMedulaDefinitionActionForm
    /// </summary>
    public partial class BaseMedulaDefinitionActionForm : TTForm
    {
        protected override void PreScript()
        {
#region BaseMedulaDefinitionActionForm_PreScript
    if (((ITTObject)_BaseMedulaDefinitionAction).IsNew == false)
            {
                foreach (TTObjectStateTransitionDef objectStateTransitionDef in _BaseMedulaDefinitionAction.CurrentStateDef.OutgoingTransitions)
                {
                    if (objectStateTransitionDef.ToStateDef.BaseStateDefID.HasValue)
                    {
                        if (objectStateTransitionDef.ToStateDef.BaseStateDefID.Equals(BaseMedulaDefinitionAction.States.SentMedula))
                            this.DropStateButton(objectStateTransitionDef.ToStateDefID);
                        if (objectStateTransitionDef.ToStateDef.BaseStateDefID.Equals(BaseMedulaDefinitionAction.States.Successfully))
                            this.DropStateButton(objectStateTransitionDef.ToStateDefID);
                        if (objectStateTransitionDef.ToStateDef.BaseStateDefID.Equals(BaseMedulaDefinitionAction.States.Unsuccessfully))
                            this.DropStateButton(objectStateTransitionDef.ToStateDefID);

                        if(TTUser.CurrentUser.IsSuperUser == false)
                        {
                            if (objectStateTransitionDef.ToStateDef.BaseStateDefID.Equals(BaseMedulaAction.States.Cancelled))
                                this.DropStateButton(objectStateTransitionDef.ToStateDefID);
                        }
                    }
                }
            }
#endregion BaseMedulaDefinitionActionForm_PreScript

            }
                }
}