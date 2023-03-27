
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
    /// Kontrol Muayenesi
    /// </summary>
    public partial class FollowUpExaminationNewForm : EpisodeActionForm
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
#region FollowUpExaminationNewForm_PreScript
    base.PreScript();
            
            //Episode altında kontrol muayene sureci varsa yenisi baslatilmamali
            foreach (EpisodeAction ea in _FollowUpExamination.Episode.EpisodeActions)
            {
                if (ea is FollowUpExamination )
                {
                    FollowUpExamination fe = (FollowUpExamination)ea;
                    if (fe.ObjectID != _FollowUpExamination.ObjectID)
                    {
                        if (fe.CurrentStateDefID != FollowUpExamination.States.Cancelled && fe.CurrentStateDefID != FollowUpExamination.States.PatientNoShown)
                        {
                            if (Convert.ToDateTime(fe.ActionDate).Date == Convert.ToDateTime(_FollowUpExamination.ActionDate).Date )
                              throw new TTException("Hastanın episode unda aynı gün tarihli Kontrol Muayenesi işlemi bulunmaktadır. Yeni Kontrol Muayenesi başlatılamaz!");
                        }
                    }
                }
            }

            this.SetProcedureDoctorAsCurrentResource();
            //DP için kaldırıldı. Field ın linkedrelationpath ine kontrol konuldu.
            /*  string objectIDs = String.Empty;
            IList resourceSpecialityGrids = ResourceSpecialityGrid.GetBySpeciality(_FollowUpExamination.ObjectContext, _FollowUpExamination.ProcedureSpeciality.ObjectID);
            foreach(ResourceSpecialityGrid  resourceSpecialityGrid in resourceSpecialityGrids)
            {
                if(resourceSpecialityGrid.Resource is ResUser)
                {
                    if(objectIDs.Length > 0)
                        objectIDs += ",";
                    objectIDs += "'" + resourceSpecialityGrid.Resource.ObjectID.ToString() + "'";
                    
                }
            }
            if(objectIDs.Length > 0)
                this.Doktor.ListFilterExpression = " OBJECTID IN (" + objectIDs + ")";
            else
                this.Doktor.ListFilterExpression = " 1=0";*/
            #endregion FollowUpExaminationNewForm_PreScript

        }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region FollowUpExaminationNewForm_PostScript
    base.PostScript(transDef);
            if(transDef != null)
            {
                if (transDef.ToStateDefID != FollowUpExamination.States.PatientNoShown)
                {
                    if(_FollowUpExamination.ProcedureDoctor == null)
                        throw new Exception("Sorumlu Doktor Seçmeniz Gerekmektedir!");
                }
            }
            
            
            //DP için kapatıldı
            /*if(transDef != null)
            {
                if (transDef.ToStateDefID != FollowUpExamination.States.PatientNoShown)
                {
                    if(_FollowUpExamination.ProcedureDoctor == null)
                    {
                        if (this._FollowUpExamination.ProcedureDoctor == null)
                        {
                            foreach (AuthorizedUser authorizedUser in this._FollowUpExamination.AuthorizedUsers)
                            {
                                this._FollowUpExamination.ProcedureDoctor = (ResUser)authorizedUser.User;
                                return;
                            }
                        }
                    }
                }
            }
            else
            {                
                if (this._FollowUpExamination.ProcedureDoctor == null)
                {
                    foreach (AuthorizedUser authorizedUser in this._FollowUpExamination.AuthorizedUsers)
                    {
                        this._FollowUpExamination.ProcedureDoctor = (ResUser)authorizedUser.User;
                        return;
                    }
                }
            }*/
#endregion FollowUpExaminationNewForm_PostScript

            }
                }
}