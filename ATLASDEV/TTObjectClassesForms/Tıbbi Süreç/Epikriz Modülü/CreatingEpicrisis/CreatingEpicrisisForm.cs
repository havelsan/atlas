
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
    /// Epikriz Oluşturma
    /// </summary>
    public partial class CreatingEpicrisisForm : EpisodeActionForm
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
#region CreatingEpicrisisForm_PreScript
    this._CreatingEpicrisis.CheckForDiagnosis();
            
            this.SetProcedureDoctorAsCurrentResource();
            base.PreScript();
#endregion CreatingEpicrisisForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region CreatingEpicrisisForm_ClientSidePreScript
    base.ClientSidePreScript();
#endregion CreatingEpicrisisForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CreatingEpicrisisForm_PostScript
    base.PostScript(transDef);
#endregion CreatingEpicrisisForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region CreatingEpicrisisForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
#endregion CreatingEpicrisisForm_ClientSidePostScript

        }

#region CreatingEpicrisisForm_Methods
        public virtual void IfNullSelectProcedureSpeciality()
        {
            if (this._EpisodeAction.ProcedureSpeciality == null)
            {
                IfNullSelectProcedureSpeciality();
                CreatingEpicrisis.CheckIfExistsWithSameSpeciality( this._CreatingEpicrisis.Episode, this._CreatingEpicrisis);
            }
        }
        
#endregion CreatingEpicrisisForm_Methods
    }
}