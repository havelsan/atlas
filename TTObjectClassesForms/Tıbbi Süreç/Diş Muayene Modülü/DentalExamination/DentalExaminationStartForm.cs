
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
    /// Oral Diagnoz ve Radyoloji
    /// </summary>
    public partial class DentalExaminationStartForm : EpisodeActionForm
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
#region DentalExaminationStartForm_PreScript
    bool isAllowed = false;
            if(!EpisodeAction.IsFiredByPatientAdmission(this._DentalExamination))
            {
                List<string> DisBransKodlari = new List<string>();
                DisBransKodlari.Add("5100");
                DisBransKodlari.Add("5150");
                DisBransKodlari.Add("5200");
                DisBransKodlari.Add("5300");
                DisBransKodlari.Add("5400");
                DisBransKodlari.Add("5500");
                DisBransKodlari.Add("5600");
                DisBransKodlari.Add("5700");
                
                if(this._DentalExamination is DentalConsultation)
                {
                    if(DisBransKodlari.Contains(this._DentalExamination.ProcedureSpeciality.Code))
                        isAllowed = true;
                    else
                        isAllowed = false;
                }
                else
                {
                    if(DisBransKodlari.Contains(this._DentalExamination.Episode.MainSpeciality.Code))
                        isAllowed = true;
                    else
                        isAllowed = false;
                }
            }
            else
                isAllowed = true;
            
            if(isAllowed == true)
            {
                base.PreScript();

                this.SetProcedureDoctorAsCurrentResource();

                this.DropStateButton(DentalExamination.States.Cancelled);
                if (this._DentalExamination.CurrentStateDefID == DentalExamination.States.New)
                {
                    this.DropStateButton(DentalExamination.States.Appointment);
                }               
               
            }
            else
                throw new TTUtils.TTException(SystemMessage.GetMessage(145));
#endregion DentalExaminationStartForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalExaminationStartForm_PostScript
    base.PostScript(transDef);
            if(transDef != null)
            {
                if (transDef.ToStateDefID != DentalExamination.States.PatientNoShown)
                {
                    if(_DentalExamination.ProcedureDoctor == null)
                    {
                          if (this._DentalExamination.ProcedureDoctor == null)
                {
                    foreach (AuthorizedUser authorizedUser in this._DentalExamination.AuthorizedUsers)
                    {
                        this._DentalExamination.ProcedureDoctor = (ResUser)authorizedUser.User;
                        break;
                    }
                }
                    }
                }
            }
            else
            {
               if (this._DentalExamination.ProcedureDoctor == null)
                {
                    foreach (AuthorizedUser authorizedUser in this._DentalExamination.AuthorizedUsers)
                    {
                        this._DentalExamination.ProcedureDoctor = (ResUser)authorizedUser.User;
                        break;
                    }
                }
            }
#endregion DentalExaminationStartForm_PostScript

            }
                }
}