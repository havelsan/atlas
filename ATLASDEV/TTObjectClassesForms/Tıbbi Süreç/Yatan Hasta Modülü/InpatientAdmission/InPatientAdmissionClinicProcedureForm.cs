
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
    /// Hasta Yatış
    /// </summary>
    public partial class InPatientAdmissionClinicProcedure : InPatientAdmissionBaseForm
    {
        override protected void BindControlEvents()
        {
            TratmentClinicsGrid.CellContentClick += new TTGridCellEventDelegate(TratmentClinicsGrid_CellContentClick);      
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            TratmentClinicsGrid.CellContentClick -= new TTGridCellEventDelegate(TratmentClinicsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void TratmentClinicsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region InPatientAdmissionClinicProcedure_TratmentClinicsGrid_CellContentClick
   /*
   if (((ITTGridCell)TratmentClinicsGrid.CurrentCell).OwningColumn.Name == "CokluOzelDurum")
            {

                InPatientTreatmentClinicApp_CokluOzelDurum codf = new InPatientTreatmentClinicApp_CokluOzelDurum();
                InPatientTreatmentClinicApplication inp = (InPatientTreatmentClinicApplication)TratmentClinicsGrid.CurrentCell.OwningRow.TTObject;
                codf.ShowEdit(this.FindForm(), inp);
            }*/
#endregion InPatientAdmissionClinicProcedure_TratmentClinicsGrid_CellContentClick
        }

       

        protected override void PreScript()
        {
#region InPatientAdmissionClinicProcedure_PreScript
    base.PreScript();



#endregion InPatientAdmissionClinicProcedure_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region InPatientAdmissionClinicProcedure_PostScript
    base.PostScript(transDef);
#endregion InPatientAdmissionClinicProcedure_PostScript

            }
         }
}