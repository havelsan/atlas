
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
    /// Stok Ayırt
    /// </summary>
    public partial class StockReservationForm : BaseStockReservationForm
    {
        override protected void BindControlEvents()
        {
            SaveButton.Click += new TTControlEventDelegate(SaveButton_Click);
            CancelButton.Click += new TTControlEventDelegate(CancelButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SaveButton.Click -= new TTControlEventDelegate(SaveButton_Click);
            CancelButton.Click -= new TTControlEventDelegate(CancelButton_Click);
            base.UnBindControlEvents();
        }

        private void SaveButton_Click()
        {
#region StockReservationForm_SaveButton_Click
   try
            {
                double reservedAmount = Convert.ToDouble(SelectedStock.ReservedAmount + Convert.ToDouble(this.Amount.Text));
                if (reservedAmount > SelectedStock.Inheld)
                    throw new TTException("Ayırtılmışların toplamı mevcuttan büyük olamaz.\r\nMevcut : " + SelectedStock.Inheld + "\r\nAyırtılmış Miktar : " + reservedAmount);

                TTObjectContext objectContext = new TTObjectContext(false);
                StockReservation stockReservation = new StockReservation(objectContext);
                stockReservation.Stock = objectContext.GetObject(SelectedStock.ObjectID, typeof(Stock)) as Stock;
                stockReservation.Amount = Convert.ToDouble(this.Amount.Text);
                stockReservation.Description = this.Description.Text;
                stockReservation.CurrentStateDefID = StockReservation.States.Reserved;
                objectContext.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                InfoBox.Show(this, ex);
            }
#endregion StockReservationForm_SaveButton_Click
        }

        private void CancelButton_Click()
        {
#region StockReservationForm_CancelButton_Click
   this.DialogResult = DialogResult.Cancel;
            this.Close();
#endregion StockReservationForm_CancelButton_Click
        }
    }
}