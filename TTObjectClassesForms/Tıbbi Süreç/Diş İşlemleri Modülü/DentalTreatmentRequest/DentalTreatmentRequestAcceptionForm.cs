
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
    /// Diş Tedavi
    /// </summary>
    public partial class DentalTreatmentRequestAcceptionForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            SuggestedTreatments.CellContentClick += new TTGridCellEventDelegate(SuggestedTreatments_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SuggestedTreatments.CellContentClick -= new TTGridCellEventDelegate(SuggestedTreatments_CellContentClick);
            base.UnBindControlEvents();
        }

        private void SuggestedTreatments_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalTreatmentRequestAcceptionForm_SuggestedTreatments_CellContentClick
   if (this.SuggestedTreatments.CurrentCell.OwningColumn.Name.Equals(ToothSchema.Name))
                this.SuggestedTreatments.ShowTTObject(rowIndex, false);

            if (SuggestedTreatments.Rows.Count > 0 && SuggestedTreatments.CurrentCell != null)
            {
                if ((((ITTGridCell)SuggestedTreatments.CurrentCell).OwningColumn != null) && (((ITTGridCell)SuggestedTreatments.CurrentCell).OwningColumn.Name == "Delete"))
                {

                    ITTGridCell currentCell = SuggestedTreatments.CurrentCell;
                    if (currentCell != null)
                    {
                        ITTGridRow currentRow = currentCell.OwningRow;
                        if (currentRow != null)
                        {
                            if (ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayır", "E,H", "Emin misiniz?", "Tedavi isteğini silmek istediğinizden emin misiniz?") == "E")
                            {
                                DentalTreatmentRequestSuggestedTreatment dTR = (DentalTreatmentRequestSuggestedTreatment)SuggestedTreatments.Rows[rowIndex].TTObject;
                                if (dTR.CurrentStateDefID != DentalExaminationSuggestedTreatment.States.Cancelled)
                                {
                                    dTR.CurrentStateDefID = DentalExaminationSuggestedTreatment.States.Cancelled;
                                    _DentalTreatmentRequest.ObjectContext.Update();
                                    SuggestedTreatments.RefreshRows();
                                }
                            }
                        }
                    }
                }
            }
#endregion DentalTreatmentRequestAcceptionForm_SuggestedTreatments_CellContentClick
        }

        protected override void PreScript()
        {
#region DentalTreatmentRequestAcceptionForm_PreScript
    base.PreScript();
#endregion DentalTreatmentRequestAcceptionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalTreatmentRequestAcceptionForm_PostScript
    base.PostScript(transDef);
#endregion DentalTreatmentRequestAcceptionForm_PostScript

            }
                }
}