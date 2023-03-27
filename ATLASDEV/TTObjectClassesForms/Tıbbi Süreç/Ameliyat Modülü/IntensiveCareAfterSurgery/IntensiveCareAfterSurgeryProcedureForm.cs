
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
    /// Ameliyat Sonrası Yoğun Bakım
    /// </summary>
    public partial class IntensiveCareAfterSurgeryProcedureForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            IntensiveCareEstimatings.CellValueChanged += new TTGridCellEventDelegate(IntensiveCareEstimatings_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IntensiveCareEstimatings.CellValueChanged -= new TTGridCellEventDelegate(IntensiveCareEstimatings_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void IntensiveCareEstimatings_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region IntensiveCareAfterSurgeryProcedureForm_IntensiveCareEstimatings_CellValueChanged
            if (IntensiveCareEstimatings.CurrentCell.OwningColumn.Name != "TotalScore")
            {
                if (rowIndex < this.IntensiveCareEstimatings.Rows.Count && rowIndex > -1)
                {
                    int? toplam = 0;
                    IntensiveCareEstimatingGrid intensiveCareEstimating = (IntensiveCareEstimatingGrid)((ITTGridRow)IntensiveCareEstimatings.Rows[rowIndex]).TTObject;
                    if (intensiveCareEstimating.Activite != null)
                        toplam += intensiveCareEstimating.Activite.Value.GetHashCode();
                    if (intensiveCareEstimating.Circulation != null)
                        toplam += intensiveCareEstimating.Circulation.Value.GetHashCode();
                    if (intensiveCareEstimating.Respiration != null)
                        toplam += intensiveCareEstimating.Respiration.Value.GetHashCode();
                    if (intensiveCareEstimating.Wakefulness != null)
                        toplam += intensiveCareEstimating.Wakefulness.Value.GetHashCode();
                    if (intensiveCareEstimating.Color != null)
                        toplam += intensiveCareEstimating.Color.Value.GetHashCode();
                    intensiveCareEstimating.TotalScore = toplam;
                }
            }

            #endregion IntensiveCareAfterSurgeryProcedureForm_IntensiveCareEstimatings_CellValueChanged
        }

        protected override void PreScript()
        {
            #region IntensiveCareAfterSurgeryProcedureForm_PreScript
            base.PreScript();

            this.DropStateButton(IntensiveCareAfterSurgery.States.Discharged);
            this.SetTreatmentMaterialListFilter(this._IntensiveCareAfterSurgery.ObjectDef, (ITTGridColumn)this.GridTreatmentMaterials.Columns["SMMaterial"]);
            #endregion IntensiveCareAfterSurgeryProcedureForm_PreScript

        }
    }
}