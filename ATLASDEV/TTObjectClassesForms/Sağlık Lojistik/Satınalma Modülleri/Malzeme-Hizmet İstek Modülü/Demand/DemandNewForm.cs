
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
    /// Belge Kayıt (Malzeme İsteği)
    /// </summary>
    public partial class DemandNewForm : TTForm
    {
        override protected void BindControlEvents()
        {
            DemandDetails.CellContentClick += new TTGridCellEventDelegate(DemandDetails_CellContentClick);
            DemandType.SelectedIndexChanged += new TTControlEventDelegate(DemandType_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DemandDetails.CellContentClick -= new TTGridCellEventDelegate(DemandDetails_CellContentClick);
            DemandType.SelectedIndexChanged -= new TTControlEventDelegate(DemandType_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void DemandDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DemandNewForm_DemandDetails_CellContentClick
   if (DemandDetails.CurrentCell.OwningColumn.Name == "SelectPatient")
            {
                using(PatientSearchForm theForm = new PatientSearchForm())
                {
                    Patient patient = (Patient)theForm.GetSelectedObject();
                    if(patient != null)
                    {
                        //_PatientConsumptionCancel.Patient = patient;
                        //cmdSearchPatient.Text = patient.UniqueRefNo.ToString() + " - " + patient.FullName;
                        DemandDetail dd = (DemandDetail)((ITTGridRow)this.DemandDetails.Rows[rowIndex]).TTObject;
                        dd.Patient = patient;
                        (this.DemandDetails.Rows[rowIndex].Cells["Patient"]).Value = patient.UniqueRefNo.ToString() + " - " + patient.FullName;
                    }
                    else
                        InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
                }
            }
#endregion DemandNewForm_DemandDetails_CellContentClick
        }

        private void DemandType_SelectedIndexChanged()
        {
#region DemandNewForm_DemandType_SelectedIndexChanged
   //
//            if(DemandType.SelectedItem == null)
//                return;
//            
//            _Demand.DemandDetails.DeleteChildren();
//            if(Convert.ToByte(DemandType.SelectedItem.Value) != 1)//İBF değil
//            {
//                IBFType.SelectedObject = null;
//                IBFType.Visible = false;
//                IBFTypeLabel.Visible = false;
//                IBFYear.Visible = false;
//                IBFYearLabel.Visible = false;
//                cmdList.Visible = false;
//            }
//            else
//            {
//                IBFType.Visible = true;
//                IBFTypeLabel.Visible = true;
//                IBFYear.Visible = true;
//                IBFYearLabel.Visible = true;
//                cmdList.Visible = true;
//            }
#endregion DemandNewForm_DemandType_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region DemandNewForm_PreScript
    base.PreScript();
#endregion DemandNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DemandNewForm_PostScript
    _Demand.CheckNullAmounts();
#endregion DemandNewForm_PostScript

            }
                }
}