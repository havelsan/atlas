
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
    /// Hasta İlaç Hareketleri
    /// </summary>
    public partial class PatientDrugTransactionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            Patient.SelectedObjectChanged += new TTControlEventDelegate(Patient_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Patient.SelectedObjectChanged -= new TTControlEventDelegate(Patient_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void Patient_SelectedObjectChanged()
        {
#region PatientDrugTransactionForm_Patient_SelectedObjectChanged
   //
//            System.Diagnostics.Debugger.Break();
//            TTObjectContext mycontext = new TTObjectContext(true);
//            Patient myPatient =  (Patient) mycontext.QueryObjects("PATIENT", "OBJECTID = '" + this.Patient.SelectedObjectID + "'")[0];
//            
//            ( (TTGrid) this.Episodes).VirtualMode = false;
//            this.Episodes.Rows.Clear();
//            
//            foreach(Episode episode in myPatient.Episodes)
//            {
////                foreach(EpisodeAction episodeAction in episode.EpisodeActions)
////                {
////                    foreach(SubActionMaterial subActionMaterial in episodeAction.SubActionMaterials)
////                    {
////                        ( (TTGrid) this.Episodes).Rows.Add( new object[] {
////                                                               subActionMaterial.Material,subActionMaterial.ActionDate,subActionMaterial.Amount,subActionMaterial.TransDef.Name});
////                    }
////                    
////                }
//            }
#endregion PatientDrugTransactionForm_Patient_SelectedObjectChanged
        }
    }
}