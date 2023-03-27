
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
    public partial class DiagnosisSelectionForm : TTForm
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
#region DiagnosisSelectionForm_PreScript
    base.PreScript();
#endregion DiagnosisSelectionForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region DiagnosisSelectionForm_ClientSidePreScript
    base.ClientSidePreScript();
//                        GridFavoriteDiagnosis.SetDataSource((IBindingList)Common.CurrentResource.FavoriteDiagnosis);
//
//                        GridLast10DiagnosisOfPatientBySpeciality.SetDataSource(DiagnosisGrid.GetLast10DiagnosisOfPatient(this._EpisodeActionWithDiagnosis.Episode.Patient.ObjectID.ToString(), this._EpisodeActionWithDiagnosis.ProcedureSpeciality.ObjectID.ToString(),string.Empty));
//
//                        int dayPeriod = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("LIMITDAYOFTOP10DIAGNOSISOFUSER", "30"));
//                        GridTop10DiagnosisOfUser.SetDataSource(DiagnosisGrid.GetTop10DiagnosisDefinitionOfUser(Common.CurrentResource.ObjectID.ToString() , Common.RecTime().AddDays(-1*dayPeriod)));
#endregion DiagnosisSelectionForm_ClientSidePreScript

        }
    }
}