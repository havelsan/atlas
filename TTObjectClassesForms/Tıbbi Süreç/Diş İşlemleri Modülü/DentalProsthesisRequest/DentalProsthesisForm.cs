
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
    /// Diş Protez
    /// </summary>
    public partial class DentalProsthesisForm : BaseDentalEpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            SecDiagnosisGrid.CellContentClick += new TTGridCellEventDelegate(SecDiagnosisGrid_CellContentClick);
            SuggestedProsthesis.CellContentClick += new TTGridCellEventDelegate(SuggestedProsthesis_CellContentClick);
            DentalProsthesis.CellDoubleClick += new TTGridCellEventDelegate(DentalProsthesis_CellDoubleClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SecDiagnosisGrid.CellContentClick -= new TTGridCellEventDelegate(SecDiagnosisGrid_CellContentClick);
            SuggestedProsthesis.CellContentClick -= new TTGridCellEventDelegate(SuggestedProsthesis_CellContentClick);
            DentalProsthesis.CellDoubleClick -= new TTGridCellEventDelegate(DentalProsthesis_CellDoubleClick);
            base.UnBindControlEvents();
        }

        private void SecDiagnosisGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalProsthesisForm_SecDiagnosisGrid_CellContentClick
   if(this.SecDiagnosisGrid.CurrentCell.OwningColumn.Name.Equals(SecToothSchema.Name))
              this.SecDiagnosisGrid.ShowTTObject(rowIndex, false);
#endregion DentalProsthesisForm_SecDiagnosisGrid_CellContentClick
        }

        private void SuggestedProsthesis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalProsthesisForm_SuggestedProsthesis_CellContentClick
   if(this.SuggestedProsthesis.CurrentCell.OwningColumn.Name.Equals(SuggestedToothSchema.Name))
              this.SuggestedProsthesis.ShowTTObject(rowIndex, false);
#endregion DentalProsthesisForm_SuggestedProsthesis_CellContentClick
        }

        private void DentalProsthesis_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalProsthesisForm_DentalProsthesis_CellDoubleClick
   // Çift tıklanan Diş protez işlemli açılır
            //            DentalProsthesisProcedure  dentalProsthesis =_DentalProsthesisRequest.DentalProsthesis[this.DentalProsthesis.CurrentCell.RowIndex];
            //            TTForm frm = TTForm.GetEditForm(dentalProsthesis);
            //            if (frm == null)
            //            {
            //                MessageBox.Show(dentalProsthesis.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından işlem açılamamaktadır");
            //            }
            //            else
            //            {
            //                frm.ShowEdit(this.FindForm(),dentalProsthesis);
            //            }
            //            if (this.DentalProsthesis.CurrentCell.RowIndex < this._DentalProsthesisRequest.DentalProsthesis.Count)
            //            {
            //                Guid actionID =(Guid)_DentalProsthesisRequest.DentalProsthesis[this.DentalProsthesis.CurrentCell.RowIndex].ObjectID;
            //                TTObjectContext objectContext = new TTObjectContext(false);
//
            //                try
            //                {
            //                    DentalProsthesisProcedure  dentalProsthesis = (DentalProsthesisProcedure)(objectContext.GetObject(actionID, typeof(DentalProsthesisProcedure)));
            //                    TTForm frm = TTForm.GetEditForm(dentalProsthesis);
            //                    if (frm == null)
            //                    {
            //                        MessageBox.Show(dentalProsthesis.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından işlem açılamamaktadır");
            //                    }
            //                    frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
            //                    frm.ShowEdit(this.FindForm(),dentalProsthesis);
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
#endregion DentalProsthesisForm_DentalProsthesis_CellDoubleClick
        }

        protected override void PreScript()
        {
#region DentalProsthesisForm_PreScript
    base.PreScript();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"], (ITTGridColumn)this.UsedMaterials.Columns["Material"]);
            try {
                this.DentalExaminationFile.Text = Common.GetTextOfRTFString(this.DentalExaminationFile.Text);
            } catch(Exception e) {
                //TODO
            }
#endregion DentalProsthesisForm_PreScript

            }
            
#region DentalProsthesisForm_Methods
        //        void ShowAction_ObjectUpdated(TTObject ttObject)
//        {
//           // ttObject.ObjectContext.Save();
//        }
        
#endregion DentalProsthesisForm_Methods
    }
}