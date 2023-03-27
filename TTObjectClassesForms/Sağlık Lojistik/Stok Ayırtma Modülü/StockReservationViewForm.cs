
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
    /// Ayırtılmışları Görüntüleme
    /// </summary>
    public partial class StockReservationViewForm : BaseStockReservationForm
    {
        override protected void BindControlEvents()
        {
            StockReservations.CellContentClick += new TTGridCellEventDelegate(StockReservations_CellContentClick);
            CancelButton.Click += new TTControlEventDelegate(CancelButton_Click);
            SaveButton.Click += new TTControlEventDelegate(SaveButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockReservations.CellContentClick -= new TTGridCellEventDelegate(StockReservations_CellContentClick);
            CancelButton.Click -= new TTControlEventDelegate(CancelButton_Click);
            SaveButton.Click -= new TTControlEventDelegate(SaveButton_Click);
            base.UnBindControlEvents();
        }

        private void StockReservations_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region StockReservationViewForm_StockReservations_CellContentClick
   ITTGridColumn clickedColumn = this.StockReservations.Columns[columnIndex];
            if (clickedColumn.Name == CancelReservation.Name)
            {
                try
                {
                    ITTGridRow changedRow = this.StockReservations.Rows[rowIndex];
                    ITTGridCell outDetailsCountCell = changedRow.Cells[OutDetailsCount.Name];
                    if (outDetailsCountCell.Value != null)
                    {
                        int outDetailsCount = Convert.ToInt32(outDetailsCountCell.Value);
                        if (outDetailsCount > 0)
                            throw new TTException("Buradan iptal edilemez bağlı olduğu stok işlemini iptal etmeniz gerekmektedir.");
                    }

                    ITTGridCell reservationNewStateDefIDCell = changedRow.Cells[ReservationNewStateDefID.Name];
                    ITTGridCell reservationCurrentStateNameCell = changedRow.Cells[ReservationCurrentStateName.Name];
                    reservationNewStateDefIDCell.Value = StockReservation.States.Cancelled;
                    reservationCurrentStateNameCell.Value = "İptal";
                }
                catch (Exception ex)
                {
                    InfoBox.Show(this, ex);
                }
            }
#endregion StockReservationViewForm_StockReservations_CellContentClick
        }

        private void CancelButton_Click()
        {
#region StockReservationViewForm_CancelButton_Click
   this.DialogResult = DialogResult.Cancel;
            this.Close();
#endregion StockReservationViewForm_CancelButton_Click
        }

        private void SaveButton_Click()
        {
#region StockReservationViewForm_SaveButton_Click
   try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                foreach (ITTGridRow row in this.StockReservations.Rows)
                {
                    ITTGridCell changedCell = row.Cells[ReservationNewStateDefID.Name];
                    if (changedCell.Value != null)
                    {
                        StockReservation stockReservation = (StockReservation)objectContext.GetObject((Guid)row.Cells[StockReservationObjectID.Name].Value, typeof(StockReservation));
                        stockReservation.CancelReservation();
                    }
                }

                objectContext.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                InfoBox.Show(this, ex);
            }
#endregion StockReservationViewForm_SaveButton_Click
        }

#region StockReservationViewForm_Methods
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            IList stockReservations = this.SelectedStock.StockReservations.Select("CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(StockReservation.States.Reserved));
            foreach (StockReservation stockReservation in stockReservations)
            {
                ITTGridRow row = this.StockReservations.Rows.Add();
                row.Cells[ReservationDescription.Name].Value = stockReservation.Description;
                row.Cells[ReservationAmount.Name].Value = stockReservation.Amount;
                row.Cells[ReservationCurrentStateName.Name].Value = stockReservation.CurrentStateDef.DisplayText;
                row.Cells[StockReservationObjectID.Name].Value = stockReservation.ObjectID;
                IList outDetails = stockReservation.StockActionOutDetails.Select("");
                row.Cells[OutDetailsCount.Name].Value = outDetails.Count;
            }
        }
        
#endregion StockReservationViewForm_Methods
    }
}