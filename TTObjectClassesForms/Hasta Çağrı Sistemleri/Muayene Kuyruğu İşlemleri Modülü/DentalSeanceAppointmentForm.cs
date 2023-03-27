
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
    /// Diş Sıraya Alınan Hastalar
    /// </summary>
    public partial class DentalSeanceAppointment : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            TTListBoxProcedure.SelectedObjectChanged += new TTControlEventDelegate(TTListBoxProcedure_SelectedObjectChanged);
            ttbuttonExportExcel.Click += new TTControlEventDelegate(ttbuttonExportExcel_Click);
            cmdSearchPatient.Click += new TTControlEventDelegate(cmdSearchPatient_Click);
            cmdListPatientItems.Click += new TTControlEventDelegate(cmdListPatientItems_Click);
            QueueItemsGrid.CellContentClick += new TTGridCellEventDelegate(QueueItemsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            TTListBoxProcedure.SelectedObjectChanged -= new TTControlEventDelegate(TTListBoxProcedure_SelectedObjectChanged);
            ttbuttonExportExcel.Click -= new TTControlEventDelegate(ttbuttonExportExcel_Click);
            cmdSearchPatient.Click -= new TTControlEventDelegate(cmdSearchPatient_Click);
            cmdListPatientItems.Click -= new TTControlEventDelegate(cmdListPatientItems_Click);
            QueueItemsGrid.CellContentClick -= new TTGridCellEventDelegate(QueueItemsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void TTListBoxProcedure_SelectedObjectChanged()
        {
#region DentalSeanceAppointment_TTListBoxProcedure_SelectedObjectChanged
   //if(this.TTListBoxProcedure.SelectedObject != null) {
   //             QueueItemsGrid.Rows.Clear();
   //             TTObjectContext context = new TTObjectContext(false);
   //             BindingList<TTObjectClasses.DentalQueue> list = null;
   //             list = TTObjectClasses.DentalQueue.DentalQueueItemsByProcedure(context, Common.RecTime().AddDays(-10), Common.RecTime().AddDays(10), (Guid)this.TTListBoxProcedure.SelectedObjectID);                              
   //             if (list.Count == 0) {
   //                 InfoBox.Show("Bu işlem için aktif muayene sırası bulunamadı");
   //             }
   //             else
   //             {
   //                 foreach (TTObjectClasses.DentalQueue item in list)
   //                 {
   //                     ITTGridRow row = QueueItemsGrid.Rows.Add();
   //                     DateTime dt = ((DateTime)item.QueueDate);
   //                     row.Cells[0].Value = dt.ToLongDateString() + " " + dt.ToLongTimeString();
   //                     row.Cells[1].Value = item.ObjectID.ToString();
   //                     row.Cells[2].Value = item.Description;
   //                     row.Cells[3].Value = item.OrderNo;
   //                     row.Cells[4].Value = item.ProcedureDefinition.Code + "-" + item.ProcedureDefinition.Name;
   //                     row.Cells[5].Value = item.ToothNumbers;
   //                 }
   //             }
   //         }
#endregion DentalSeanceAppointment_TTListBoxProcedure_SelectedObjectChanged
        }

        private void ttbuttonExportExcel_Click()
        {
#region DentalSeanceAppointment_ttbuttonExportExcel_Click
   try
                {
                if (QueueItemsGrid.Rows.Count == 0)
                {
                    InfoBox.Show("Dışarıya çıkartmak için en az bir hata kaydı listelenmiş olmalıdır.");
                    return;
                }

                //SaveFileDialog saveFileDialog = new SaveFileDialog();
                //saveFileDialog.Filter = "Excel 97-2003 Workbook (*.xls)|*.xls";
                //saveFileDialog.DefaultExt = "xls";
                //saveFileDialog.RestoreDirectory = true;

                //DialogResult dialogResult = saveFileDialog.ShowDialog(this);
                //if (dialogResult == DialogResult.OK)
                //{
                //    this.QueueItemsGrid.ExportGridToExcel(saveFileDialog.FileName, false);
                //}
            }
                catch (Exception ex)
                {
                    InfoBox.Show(ex);
                }
#endregion DentalSeanceAppointment_ttbuttonExportExcel_Click
        }

        private void cmdSearchPatient_Click()
        {
#region DentalSeanceAppointment_cmdSearchPatient_Click
   using (PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();

                if (patient != null)
                {
                    txtPatientName.Tag = patient.ObjectID;
                    txtPatientName.Text = patient.UniqueRefNo.ToString() + " - " + patient.FullName;
                }
                else
                    InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
            }
#endregion DentalSeanceAppointment_cmdSearchPatient_Click
        }

        private void cmdListPatientItems_Click()
        {
#region DentalSeanceAppointment_cmdListPatientItems_Click
   //QueueItemsGrid.Rows.Clear();
   //         TTObjectContext context = new TTObjectContext(false);
   //         BindingList<TTObjectClasses.DentalQueue> list = null;
   //         Guid patientGuid = Guid.Empty;
   //         if (txtPatientName != null && txtPatientName.Tag != null && !"".Equals(txtPatientName.Tag.ToString())) {
   //             patientGuid = new Guid(txtPatientName.Tag.ToString());
   //             list = TTObjectClasses.DentalQueue.DentalQueueItems(context,patientGuid, Common.RecTime().AddDays(10), Common.RecTime().AddDays(-10));
   //         }
   //         else {
   //             list = TTObjectClasses.DentalQueue.DentalQueueItemsAll(context, Common.RecTime().AddDays(-10), Common.RecTime().AddDays(10));
   //         }
            
   //         if (list.Count == 0) {
   //             if (patientGuid.Equals(Guid.Empty))
   //                 InfoBox.Show("Bu hastaya ait aktif muayene sırası bulunamadı");
   //             else
   //                 InfoBox.Show("Aktif muayene sırası bulunamadı");
   //         }
   //         else
   //         {
   //             foreach (TTObjectClasses.DentalQueue item in list)
   //             {
   //                 ITTGridRow row = QueueItemsGrid.Rows.Add();
   //                 DateTime dt = ((DateTime)item.QueueDate);
   //                 row.Cells[0].Value = dt.ToLongDateString() + " " + dt.ToLongTimeString();                  
   //                 row.Cells[1].Value = item.ObjectID.ToString();
   //                 row.Cells[2].Value = item.Description;
   //                 row.Cells[3].Value = item.OrderNo;
   //                 row.Cells[4].Value = item.ProcedureDefinition.Code + "-" + item.ProcedureDefinition.Name;
   //                 row.Cells[5].Value = item.ToothNumbers;
   //             }
   //         }
#endregion DentalSeanceAppointment_cmdListPatientItems_Click
        }

        private void QueueItemsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalSeanceAppointment_QueueItemsGrid_CellContentClick
   //if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns["DeleteProcedure"]) {
   //             string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Hasta Sıra", "İşlem silinecek, onaylıyor musunuz?");
   //             if (result == "E")
   //             {
   //                 TTObjectContext context = new TTObjectContext(false);
   //                 //TTObjectClasses.DentalQueue dq = (TTObjectClasses.DentalQueue)QueueItemsGrid.CurrentCell.OwningRow.TTObject;
   //                 //((ITTObject)dq).Delete();
                 
   //                 BindingList<TTObjectClasses.DentalQueue> dentalList = TTObjectClasses.DentalQueue.GetDentalQueueById(context,new Guid(QueueItemsGrid.Rows[rowIndex].Cells[1].Value.ToString()));
   //                 ((ITTObject)dentalList[0]).Delete();
   //                 QueueItemsGrid.Rows.RemoveAt(rowIndex);
   //                 context.Save();
   //             }
   //         }
   //         else {
   //             List<ITTGridRow> newRows = null;
   //             if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns["CallTime"]) {
   //                 //QueueItemsGrid.Sort(0);
   //                 newRows = new List<ITTGridRow>();
   //                 foreach(ITTGridRow row in QueueItemsGrid.Rows) {
   //                     if (newRows.Count == 0)
   //                         newRows.Add(row);
   //                     else {
   //                         int indx = -1;
   //                         bool found = false;
   //                         foreach(ITTGridRow newRow in newRows) {
   //                             indx++;
   //                             if (row.Cells[0].Value != null && newRow.Cells[0].Value != null)
   //                                 if (Convert.ToDateTime(row.Cells[0].Value).CompareTo(Convert.ToDateTime(newRow.Cells[0].Value)) < 0) {
   //                                 indx = indx > 0 ? (indx - 1) : 0;
   //                                 found = true;
   //                                 break;
   //                             }
   //                         }
   //                         if (found) {
   //                             if (newRows.Count > indx)
   //                                 newRows.Insert(indx, row);
   //                             else
   //                                 newRows.Add(row);
   //                         }
   //                         else
   //                             newRows.Add(row);
   //                     }
   //                 }
   //             }
   //             else  if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns["Desc"]) {
   //                 //QueueItemsGrid.Sort(2);
   //                 newRows = new List<ITTGridRow>();
   //                 foreach(ITTGridRow row in QueueItemsGrid.Rows) {
   //                     if (newRows.Count == 0)
   //                         newRows.Add(row);
   //                     else {
   //                         int indx = -1;
   //                         bool found = false;
   //                         foreach(ITTGridRow newRow in newRows) {
   //                             indx++;
   //                             if (row.Cells[2].Value != null && newRow.Cells[2].Value != null)
   //                                 if (row.Cells[2].Value.ToString().CompareTo(newRow.Cells[2].Value.ToString()) < 0)
   //                             {
   //                                 indx = indx > 0 ? (indx - 1) : 0;
   //                                 found = true;
   //                                 break;
   //                             }
   //                         }
   //                         if (found) {
   //                             if (newRows.Count > indx)
   //                                 newRows.Insert(indx, row);
   //                             else
   //                                 newRows.Add(row);
   //                         }
   //                         else
   //                             newRows.Add(row);
   //                     }
   //                 }
   //             }
   //             else if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns["OrderNo"]) {
   //                 //QueueItemsGrid.Sort(3);
   //                 newRows = new List<ITTGridRow>();
   //                 foreach(ITTGridRow row in QueueItemsGrid.Rows) {
   //                     if (newRows.Count == 0)
   //                         newRows.Add(row);
   //                     else {
   //                         int indx = -1;
   //                         bool found = false;
   //                         foreach(ITTGridRow newRow in newRows) {
   //                             indx++;
   //                             if (row.Cells[3].Value != null && newRow.Cells[3].Value != null)
   //                                 if (row.Cells[3].Value.ToString().CompareTo(newRow.Cells[3].Value.ToString()) < 0)
   //                             {
   //                                 indx = indx > 0 ? (indx - 1) : 0;
   //                                 found = true;
   //                                 break;
   //                             }
   //                         }
   //                         if (found) {
   //                             if (newRows.Count > indx)
   //                                 newRows.Insert(indx, row);
   //                             else
   //                                 newRows.Add(row);
   //                         }
   //                         else
   //                             newRows.Add(row);
   //                     }
   //                 }
   //             }
   //             else if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns["Procedure"]) {
   //                 //QueueItemsGrid.Sort(4);
   //                 newRows = new List<ITTGridRow>();
   //                 foreach(ITTGridRow row in QueueItemsGrid.Rows) {
   //                     if (newRows.Count == 0)
   //                         newRows.Add(row);
   //                     else {
   //                         int indx = -1;
   //                         bool found = false;
   //                         foreach(ITTGridRow newRow in newRows) {
   //                             indx++;
   //                             if (row.Cells[4].Value != null && newRow.Cells[4].Value != null)
   //                                 if (row.Cells[4].Value.ToString().CompareTo(newRow.Cells[4].Value.ToString()) < 0)
   //                             {
   //                                 indx = indx > 0 ? (indx - 1) : 0;
   //                                 found = true;
   //                                 break;
   //                             }
   //                         }
   //                         if (found) {
   //                             if (newRows.Count > indx)
   //                                 newRows.Insert(indx, row);
   //                             else
   //                                 newRows.Add(row);
   //                         }
   //                         else
   //                             newRows.Add(row);
   //                     }
   //                 }
   //             }
   //             else if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns["ToothNumbers"]) {
   //                 //QueueItemsGrid.Sort(5);
   //                 newRows = new List<ITTGridRow>();
   //                 foreach(ITTGridRow row in QueueItemsGrid.Rows) {
   //                     if (newRows.Count == 0)
   //                         newRows.Add(row);
   //                     else {
   //                         int indx = -1;
   //                         bool found = false;
   //                         foreach(ITTGridRow newRow in newRows) {
   //                             indx++;
   //                             if (row.Cells[5].Value != null && newRow.Cells[5].Value != null)
   //                                 if (row.Cells[5].Value.ToString().CompareTo(newRow.Cells[5].Value.ToString()) < 0)
   //                             {
   //                                 indx = indx > 0 ? (indx - 1) : 0;
   //                                 found = true;
   //                                 break;
   //                             }
   //                         }
   //                         if (found) {
   //                             if (newRows.Count > indx)
   //                                 newRows.Insert(indx, row);
   //                             else
   //                                 newRows.Add(row);
   //                         }
   //                         else
   //                             newRows.Add(row);
   //                     }
   //                 }
   //             }
   //             if (newRows != null && newRows.Count > 0) {
   //                 QueueItemsGrid.Rows.Clear();
   //                 foreach(ITTGridRow row in newRows) {
   //                     ITTGridRow newRow =  QueueItemsGrid.Rows.Add();
   //                     newRow.Cells[0].Value = row.Cells[0].Value;
   //                     newRow.Cells[1].Value = row.Cells[1].Value;
   //                     newRow.Cells[2].Value = row.Cells[2].Value;
   //                     newRow.Cells[3].Value = row.Cells[3].Value;
   //                     newRow.Cells[4].Value = row.Cells[4].Value;
   //                     newRow.Cells[5].Value = row.Cells[5].Value;
   //                 }
   //             }
   //         }
#endregion DentalSeanceAppointment_QueueItemsGrid_CellContentClick
        }
    }
}