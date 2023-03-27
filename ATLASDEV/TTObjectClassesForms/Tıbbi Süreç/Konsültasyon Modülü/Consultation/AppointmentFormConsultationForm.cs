
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
    public partial class AppointmentFormConsultation : AppointmentFormBase
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AppointmentFormConsultation_PostScript
    if (transDef != null)
            {
                if (transDef.ToStateDef.Status != StateStatusEnum.Cancelled && transDef.ToStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                {
                    foreach (Appointment appointment in EpisodeAction.GetMyNewAppointments(this._Consultation.ObjectID))
                    {
                        AuthorizedUser authorizedUser = new AuthorizedUser(this._Consultation.ObjectContext);
                        authorizedUser.User = (ResUser)appointment.Resource;
                        this._Consultation.AuthorizedUsers.Add(authorizedUser);
                        this._Consultation.ProcedureDoctor = (ResUser)appointment.Resource;
                    }
                }
                else
                {
                    //YAPILACAK : Obje delete i yapıldığında aşağıdaki kod açılacak.
                    //this._ConsultationProcedure.AuthorizedUsers.DeleteChildren();
                    AuthorizedUser authorizedUser = new AuthorizedUser(this._Consultation.ObjectContext);
                    authorizedUser.User = (ResUser)this._Consultation.ProcedureDoctor;
                    this._Consultation.AuthorizedUsers.Add(authorizedUser);
                }
            }
            base.PostScript(transDef);
#endregion AppointmentFormConsultation_PostScript

            }
                }
}