
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
    /// Tıbbi/Cerrahi Uygulamaları
    /// </summary>
    public partial class ManiplationRequestingDoctorAcception : EpisodeActionForm
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
#region ManiplationRequestingDoctorAcception_PreScript
    base.PreScript();
            
             if(Common.CurrentDoctor == null)
                this.GridDiagnosis.ReadOnly = true;
            else
                this.GridDiagnosis.ReadOnly = false;
#endregion ManiplationRequestingDoctorAcception_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ManiplationRequestingDoctorAcception_PostScript
    base.PostScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID != Manipulation.States.Cancelled)
                {
                    if(this._Manipulation.ManipulationRequest != null && !(this._Manipulation.ManipulationRequest.MasterAction is HealthCommitteeExaminationFromOtherDepartments) && !(this._Manipulation.ManipulationRequest.MasterAction is HealthCommittee))
                    {
                    if (this._Manipulation.Episode.Diagnosis.Count <= 0)
                        if (this._Manipulation.Diagnosis.Count <= 0)
                            throw new Exception(SystemMessage.GetMessage(635));
                    }
                }
                //                if(transDef.ToStateDefID==Manipulation.States.RequestAcception)
                //                {
                //                    TTFormClasses.StringEntryForm frm = new TTFormClasses.StringEntryForm();
                //                    this._Manipulation.ReasonToContinue=frm.ShowAndGetStringForm("İşleme Devam Etme Sebebi");
                //                }
            }
#endregion ManiplationRequestingDoctorAcception_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ManiplationRequestingDoctorAcception_ClientSidePostScript
    base.ClientSidePostScript(transDef);
#endregion ManiplationRequestingDoctorAcception_ClientSidePostScript

        }

#region ManiplationRequestingDoctorAcception_Methods
        //        protected override void OnOkClick(TTObjectStateTransitionDef transDef)
        //        {
        //            if(transDef!=null)
        //            {
        //                if(transDef.ToStateDefID==Manipulation.States.RequestAcception)
        //                {
        //                    TTFormClasses.StringEntryForm frm = new TTFormClasses.StringEntryForm();
        //                    this._Manipulation.ReasonToContinue=frm.ShowAndGetStringForm("İşleme Devam Etme Sebebi");
        //                }
        //            }
        //            base.OnOkClick(transDef);
        //        }
        
#endregion ManiplationRequestingDoctorAcception_Methods
    }
}