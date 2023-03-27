
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
    public partial class ConsultationRequestAcception : EpisodeActionForm
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
#region ConsultationRequestAcception_PreScript
    base.PreScript();
            if (this._Consultation.MasterResource is ResPoliclinic && ((ResPoliclinic)this._Consultation.MasterResource).PatientCallSystemInUse == true)
            {

            }
            else
                this.DropStateButton(Consultation.States.InsertedIntoQueue);

            if (this._Consultation.CurrentStateDefID == Consultation.States.InsertedIntoQueue)
                this.DropStateButton(Consultation.States.Appointment);
#endregion ConsultationRequestAcception_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ConsultationRequestAcception_PostScript
    base.PostScript(transDef);

            
            if (this._Consultation.ProcedureDoctor == null)
            {
                int count = this._Consultation.AuthorizedUsers.Count;
                if(count > 0)
                {
                    this._Consultation.ProcedureDoctor = (ResUser)this._Consultation.AuthorizedUsers[count-1].User;
                }
            }
#endregion ConsultationRequestAcception_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ConsultationRequestAcception_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            CreateQueueItem(transDef);
#endregion ConsultationRequestAcception_ClientSidePostScript

        }
    }
}