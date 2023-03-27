
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
    /// Muayene Tedavi Sonuç Kopya Sayısı Tanımları
    /// </summary>
    public partial class TreamentDischargeByPatientGroupDefinitionForm : TerminologyManagerDefForm
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
#region TreamentDischargeByPatientGroupDefinitionForm_PostScript
    base.PostScript(transDef);
            BindingList<TreatmentDischargeByPatientGroupDefinition.GetTreatmentDischargeByPatientGroupDefinition_Class> definitionList=TreatmentDischargeByPatientGroupDefinition.GetTreatmentDischargeByPatientGroupDefinition("WHERE PATIENTGROUP=" + this._TreatmentDischargeByPatientGroupDefinition.PatientGroup.GetHashCode());
            if (definitionList.Count>0 && ((definitionList[0].ObjectID).ToString()!=this._TreatmentDischargeByPatientGroupDefinition.ObjectID.ToString()))
            {
                throw new Exception(SystemMessage.GetMessageV3(1269, new string[] { this._TreatmentDischargeByPatientGroupDefinition.PatientGroup.ToString() }));
            }
#endregion TreamentDischargeByPatientGroupDefinitionForm_PostScript

            }
                }
}