
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
    public partial class DentalTreatmentForm : BaseDentalEpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            SecDiagnosisGrid.CellContentClick += new TTGridCellEventDelegate(SecDiagnosisGrid_CellContentClick);
            DentalTreatments.CellDoubleClick += new TTGridCellEventDelegate(DentalTreatments_CellDoubleClick);
            DentalTreatments.CellContentClick += new TTGridCellEventDelegate(DentalTreatments_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SecDiagnosisGrid.CellContentClick -= new TTGridCellEventDelegate(SecDiagnosisGrid_CellContentClick);
            DentalTreatments.CellDoubleClick -= new TTGridCellEventDelegate(DentalTreatments_CellDoubleClick);
            DentalTreatments.CellContentClick -= new TTGridCellEventDelegate(DentalTreatments_CellContentClick);
            base.UnBindControlEvents();
        }

        private void SecDiagnosisGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalTreatmentForm_SecDiagnosisGrid_CellContentClick
   if (this.SecDiagnosisGrid.CurrentCell.OwningColumn.Name.Equals(SecToothSchema.Name))
                this.SecDiagnosisGrid.ShowTTObject(rowIndex, false);
#endregion DentalTreatmentForm_SecDiagnosisGrid_CellContentClick
        }

        private void DentalTreatments_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalTreatmentForm_DentalTreatments_CellDoubleClick
   // Çift tıklanan Diş Tedavi işlemli açılır

            //            if (this.DentalTreatments.CurrentCell.RowIndex < this._DentalTreatmentRequest.DentalTreatments.Count)
            //            {
            //                Guid actionID =(Guid)_DentalTreatmentRequest.DentalTreatments[this.DentalTreatments.CurrentCell.RowIndex].ObjectID;             
            //                TTObjectContext objectContext = new TTObjectContext(false);
            //                
            //                try
            //                {
            //                    DentalTreatmentProcedure  dentalTreatment  = (DentalTreatmentProcedure)(objectContext.GetObject(actionID, typeof(DentalTreatmentProcedure)));
            //                    TTForm frm = TTForm.GetEditForm(dentalTreatment);
            //                    if (frm == null)
            //                    {
            //                        MessageBox.Show(dentalTreatment.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından işlem açılamamaktadır");
            //                    }
            //                    frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
            //                    frm.ShowEdit(this.FindForm(),dentalTreatment);
            //                }
            //                catch (System.Exception ex)
            //                {
            //                    MessageBox.Show(ex.ToString());
            //                }
            //                finally
            //                {
            //                    objectContext.Dispose();
            //                }
            //            }
#endregion DentalTreatmentForm_DentalTreatments_CellDoubleClick
        }

        private void DentalTreatments_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalTreatmentForm_DentalTreatments_CellContentClick
   if (this.DentalTreatments.CurrentCell.OwningColumn.Name.Equals(ProcedureToothSchema.Name))
                this.DentalTreatments.ShowTTObject(rowIndex, false);
#endregion DentalTreatmentForm_DentalTreatments_CellContentClick
        }

        protected override void PreScript()
        {
#region DentalTreatmentForm_PreScript
    base.PreScript();
            try {
                this.DentalExaminationFile.Text = Common.GetTextOfRTFString(this.DentalExaminationFile.Text);
            } catch(Exception e) {
                //TODO
            }
#endregion DentalTreatmentForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalTreatmentForm_PostScript
    base.PostScript(transDef);
#endregion DentalTreatmentForm_PostScript

            }
            
#region DentalTreatmentForm_Methods
        //        void ShowAction_ObjectUpdated(TTObject ttObject)
        //        {
        //            ttObject.ObjectContext.Save();
        //        }
        
#endregion DentalTreatmentForm_Methods
    }
}