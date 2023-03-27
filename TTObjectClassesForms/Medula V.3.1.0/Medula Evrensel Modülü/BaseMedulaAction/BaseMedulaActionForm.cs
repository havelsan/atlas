
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
    /// Temel Süreç Formu
    /// </summary>
    public partial class BaseMedulaActionForm : TTForm
    {
        protected override void PreScript()
        {
#region BaseMedulaActionForm_PreScript
    if (TTUser.CurrentUser.IsSuperUser == false)
                cmdOK.Visible = false;

            if (((ITTObject)_BaseMedulaAction).IsNew == false)
            {
                foreach (TTObjectStateTransitionDef objectStateTransitionDef in _BaseMedulaAction.CurrentStateDef.OutgoingTransitions)
                {
                    if (objectStateTransitionDef.ToStateDef.BaseStateDefID.HasValue)
                    {
                        if (objectStateTransitionDef.ToStateDef.BaseStateDefID.Equals(BaseMedulaAction.States.SentMedula))
                            this.DropStateButton(objectStateTransitionDef.ToStateDefID);
                        if (objectStateTransitionDef.ToStateDef.BaseStateDefID.Equals(BaseMedulaAction.States.CompletedSuccessfully))
                            this.DropStateButton(objectStateTransitionDef.ToStateDefID);
                        if (objectStateTransitionDef.ToStateDef.BaseStateDefID.Equals(BaseMedulaAction.States.CompletedUnsuccessfully))
                            this.DropStateButton(objectStateTransitionDef.ToStateDefID);

                        if (TTUser.CurrentUser.IsSuperUser == false)
                        {
                            if (objectStateTransitionDef.ToStateDef.BaseStateDefID.Equals(BaseMedulaAction.States.Cancelled))
                                this.DropStateButton(objectStateTransitionDef.ToStateDefID);
                        }
                    }
                }
            }
            else
            {
                foreach (TTObjectStateTransitionDef objectStateTransitionDef in _BaseMedulaAction.CurrentStateDef.OutgoingTransitions)
                {
                    if (objectStateTransitionDef.ToStateDef.BaseStateDefID.HasValue)
                    {
                        if (TTUser.CurrentUser.IsSuperUser == false)
                        {
                            if (objectStateTransitionDef.ToStateDef.BaseStateDefID.Equals(BaseMedulaAction.States.Cancelled))
                                this.DropStateButton(objectStateTransitionDef.ToStateDefID);
                        }
                    }
                }
            }
#endregion BaseMedulaActionForm_PreScript

            }
            
#region BaseMedulaActionForm_Methods
        public void CheckTheIdentificationNumber(string identificationNumber)
        {
            if (string.IsNullOrEmpty(identificationNumber))
                throw new TTException("TC Kimlik Numarası boş olamaz.");

            string id = identificationNumber.Trim();

            if (string.IsNullOrEmpty(id))
                throw new TTException("TC Kimlik Numarası boş olamaz.");

            if (id.Length != 11)
                throw new TTException("TC Kimlik Numarası 11 rakamlı olmalıdır.\r\nGirdiğiniz rakam sayısı : " + id.Length);

            if (Globals.IsCitizenShipID(id) == false)
                throw new TTException("TC Kimlik Numarası geçerli değildir.\r\nGirdiğiniz TC Kimlik Numarası : " + id);

        }
        
#endregion BaseMedulaActionForm_Methods
    }
}