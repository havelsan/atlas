
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
    public partial class ExaminationQueueManagementForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnCompletedQueueItemsReport.Click += new TTControlEventDelegate(btnCompletedQueueItemsReport_Click);
            tttabcontrolExaminationQueue.SelectedTabChanged += new TTControlEventDelegate(tttabcontrolExaminationQueue_SelectedTabChanged);
            QueueItemsGrid.CellContentClick += new TTGridCellEventDelegate(QueueItemsGrid_CellContentClick);
            cmdListQueue.Click += new TTControlEventDelegate(cmdListQueue_Click);
            cmdSearchPatient.Click += new TTControlEventDelegate(cmdSearchPatient_Click);
            cmdListPatientItems.Click += new TTControlEventDelegate(cmdListPatientItems_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnCompletedQueueItemsReport.Click -= new TTControlEventDelegate(btnCompletedQueueItemsReport_Click);
            tttabcontrolExaminationQueue.SelectedTabChanged -= new TTControlEventDelegate(tttabcontrolExaminationQueue_SelectedTabChanged);
            QueueItemsGrid.CellContentClick -= new TTGridCellEventDelegate(QueueItemsGrid_CellContentClick);
            cmdListQueue.Click -= new TTControlEventDelegate(cmdListQueue_Click);
            cmdSearchPatient.Click -= new TTControlEventDelegate(cmdSearchPatient_Click);
            cmdListPatientItems.Click -= new TTControlEventDelegate(cmdListPatientItems_Click);
            base.UnBindControlEvents();
        }

        private void btnCompletedQueueItemsReport_Click()
        {
#region ExaminationQueueManagementForm_btnCompletedQueueItemsReport_Click
   TTReportTool.TTReport.PrintReport(this, typeof(TTReportClasses.I_CompletedQueueItemsReport), true, 1, null);
#endregion ExaminationQueueManagementForm_btnCompletedQueueItemsReport_Click
        }

        private void tttabcontrolExaminationQueue_SelectedTabChanged()
        {
#region ExaminationQueueManagementForm_tttabcontrolExaminationQueue_SelectedTabChanged
   if(tttabcontrolExaminationQueue.SelectedTab.Name == "tabpageCompletedItems")
            {
                TTObjectContext context = new TTObjectContext(true);
                List<Guid> queueDefs = new List<Guid>();
                //queueDefs.Add((Guid)QueueListBox.SelectedObjectID);
                foreach(Resource outPatientResource in Common.CurrentResource.OutPatientUserResources)
                {
                    BindingList<ExaminationQueueDefinition> qList = ExaminationQueueDefinition.GetQueueByResource(context, outPatientResource.ObjectID.ToString());
                    foreach(ExaminationQueueDefinition qd in qList)
                    {
                        queueDefs.Add(qd.ObjectID);
                    }
                }
                //BindingList<ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class> retCompletedList = ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors(Common.RecTime().Date.AddDays(1), Common.RecTime().Date, queueDefs);
                BindingList<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy_Class> retCompletedList = ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy(Common.RecTime().Date, Common.RecTime().Date.AddDays(1), queueDefs);
                
                gridCompletedItems.Rows.Clear();
                foreach (ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy_Class eqiClass in retCompletedList)
                {
                    ResUser user = (ResUser)context.GetObject((Guid)eqiClass.CompletedBy, typeof(ResUser).Name);
                    ITTGridRow row2 = gridCompletedItems.Rows.Add();
                    row2.Cells[DoctorName.Name].Value = user.Person.FullName;
                    row2.Cells[CompletedItemCount.Name].Value = Convert.ToInt32(eqiClass.Count);
                }
            }
#endregion ExaminationQueueManagementForm_tttabcontrolExaminationQueue_SelectedTabChanged
        }

        private void QueueItemsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ExaminationQueueManagementForm_QueueItemsGrid_CellContentClick
   if(QueueItemsGrid.CurrentCell == null)
                return;
            
            bool refreshRequired = false;
            TTObjectContext context = new TTObjectContext(false);
            Guid itemID = new Guid(QueueItemsGrid.CurrentCell.OwningRow.Cells[QueueItemObjectID.Name].Value.ToString());
            ExaminationQueueItem item = (ExaminationQueueItem)context.GetObject(itemID, typeof(ExaminationQueueItem).Name);
            
            if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns[ChangeQueue.Name])
            {
                if (item.Doctor != null)
                {
                    InfoBox.Show("Doktoru belli muayenenin kuyruğunu değiştiremezsiniz");
                    return;
                }
                MultiSelectForm form = new MultiSelectForm();
                foreach (ExaminationQueueDefinition queueDef in context.QueryObjects(typeof(ExaminationQueueDefinition).Name))
                {
                    form.AddMSItem(queueDef.Name, queueDef.ObjectID.ToString(), queueDef);
                }
                string sKey = form.GetMSItem(this, "Aktarılacak Kuyruğu.", false, false, false, false, true, false);
                if (!String.IsNullOrEmpty(sKey))
                {
                    Guid queueDefID = new Guid(sKey);
                    item.ExaminationQueueDefinition = context.GetObject(queueDefID, typeof(ExaminationQueueDefinition).Name) as ExaminationQueueDefinition;
                    refreshRequired = true;
                }
            }
            else if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns[ClearDoctor.Name])
            {
                if(item.Doctor == null)
                {
                    InfoBox.Show("Hastanın atanmış bir doktor bulunmamakta.");
                    return;
                }
                else
                {
                    item.Doctor = null;
                    InfoBox.Show("Hastanın atanan doktoru kaldırılmıştır.");
                    refreshRequired = true;
                }
            }
            else if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns[DeleteQueue.Name])
            {
                item.CurrentStateDefID = ExaminationQueueItem.States.Cancelled;
                InfoBox.Show("Hasta Kuyruktan Silindi", MessageIconEnum.InformationMessage);
                refreshRequired = true;
            }
            else if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns[QueueUp.Name])
                QueueChange(true, QueueItemsGrid.CurrentCell.RowIndex);
            else if (QueueItemsGrid.CurrentCell.OwningColumn == QueueItemsGrid.Columns[QueueDown.Name])
                QueueChange(false, QueueItemsGrid.CurrentCell.RowIndex);
            
            if(refreshRequired)
            {
                QueueItemsGrid.Rows.Clear();
                context.Save();
                ListExaminations();
            }
#endregion ExaminationQueueManagementForm_QueueItemsGrid_CellContentClick
        }

        private void cmdListQueue_Click()
        {
#region ExaminationQueueManagementForm_cmdListQueue_Click
   if(QueueListBox.SelectedObjectID == null)
            {
                InfoBox.Show("Kuyruk seçtikten sonra listeleyiniz");
                return;
            }
            
            ExaminationQueueDefinition queueDef = (ExaminationQueueDefinition)QueueListBox.SelectedObject;
            if(Common.CurrentResource.SelectedOutPatientResource.ObjectID != queueDef.ResSection.ObjectID && Common.CurrentUser.IsSuperUser == false)
            {
                InfoBox.Show("Biriminize bağlı olmayan kuyrukları düzenleyemezsiniz. Birim değiştiriniz.");
                return;
            }
            
            ListExaminations();
#endregion ExaminationQueueManagementForm_cmdListQueue_Click
        }

        private void cmdSearchPatient_Click()
        {
#region ExaminationQueueManagementForm_cmdSearchPatient_Click
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
#endregion ExaminationQueueManagementForm_cmdSearchPatient_Click
        }

        private void cmdListPatientItems_Click()
        {
#region ExaminationQueueManagementForm_cmdListPatientItems_Click
   if(txtPatientName.Tag == null)
            {
                InfoBox.Show("Hasta seçtikten sonra listeleyiniz");
                return;
            }
            
            QueueItemsGrid.Rows.Clear();
            TTObjectContext context = new TTObjectContext(false);
            Guid patientGuid = new Guid(txtPatientName.Tag.ToString());
            BindingList<ExaminationQueueItem> list = ExaminationQueueItem.GetPatientQueueItems(context, Common.RecTime().AddHours(-12), Common.RecTime().AddHours(12), patientGuid);
            
            if (list.Count == 0)
                InfoBox.Show("Bu hastaya ait aktif muayene sırası bulunamadı");
            else
            {
                foreach (ExaminationQueueItem item in list)
                {
                    ITTGridRow row = QueueItemsGrid.Rows.Add();
                    if (item.Appointment != null)
                        row.Cells[HasAppointment.Name].Value = true;
                    else
                        row.Cells[HasAppointment.Name].Value = false;

                    if (item.CurrentStateDefID == ExaminationQueueItem.States.Diverted)
                    {
                        row.Cells[Diverted.Name].Value = true;
                        row.Cells[DivertedTime.Name].Value = ((DateTime)item.DivertedTime).ToShortTimeString();
                    }
                    
                    row.Cells[Name.Name].Value = item.Patient.FullName;
                    if(item.ExaminationQueueDefinition != null)
                        row.Cells[ExaminationQueueName.Name].Value = item.ExaminationQueueDefinition.Name;
                    row.Cells[QueueItemObjectID.Name].Value = item.ObjectID.ToString();
                    row.Cells[CallTime.Name].Value = ((DateTime)item.CallTime).ToShortTimeString();
                }
            }
#endregion ExaminationQueueManagementForm_cmdListPatientItems_Click
        }

#region ExaminationQueueManagementForm_Methods
        private void ListExaminations()
        {
            labelCompletedItemsCount.Text = string.Empty;
            QueueItemsGrid.Rows.Clear();
            
            TTObjectContext context = new TTObjectContext(false);
            ExaminationQueueDefinition queueDefinition = (ExaminationQueueDefinition)context.GetObject(new Guid(QueueListBox.SelectedObjectID.ToString()), typeof(ExaminationQueueDefinition).Name);
            Dictionary<Guid, Common.SortedExaminationQueueItems> list = new Dictionary<Guid, Common.SortedExaminationQueueItems>();
            list = TTObjectClasses.Common.GetSortedQueueItemsV2(context, queueDefinition, true);
            List<ExaminationQueueItem> retList = new List<ExaminationQueueItem>();

            foreach (KeyValuePair<Guid, Common.SortedExaminationQueueItems> kp in list)
            {
                Common.SortedExaminationQueueItems sortedItem = kp.Value;
                foreach (ExaminationQueueItem item in sortedItem.ExaminationQueueItemList)
                {
                    retList.Add(item);
                }
            }


            while (true)
            {
                bool exchanged = false;
                for (int j = 0; j < retList.Count; j++)
                {
                    ExaminationQueueItem item = retList[j];
                    for (int k = j + 1; k < retList.Count; k++)
                    {
                        ExaminationQueueItem item2 = retList[k];
                        if (item.CalculatedEnteranceTime > item2.CalculatedEnteranceTime)
                        {
                            exchanged = true;
                            retList[j] = item2;
                            retList[k] = item;
                            break;
                        }
                    }
                    if (exchanged)
                        break;
                }
                if (exchanged == false)
                    break;
            }

            foreach (ExaminationQueueItem item in retList)
            {
                if (cbIncludeNoAdmissions.Value == false && item.EpisodeAction == null)
                    continue;

                ITTGridRow row = QueueItemsGrid.Rows.Add();
                if (item.Appointment != null)
                    row.Cells[HasAppointment.Name].Value = true;
                else
                    row.Cells[HasAppointment.Name].Value = false;

                if (item.CurrentStateDefID == ExaminationQueueItem.States.Diverted)
                {
                    row.Cells[Diverted.Name].Value = true;
                    row.Cells[DivertedTime.Name].Value = ((DateTime)item.DivertedTime).ToShortTimeString();
                }

                row.Cells[Name.Name].Value = item.Patient.FullName;
                if (item.ExaminationQueueDefinition != null)
                    row.Cells[ExaminationQueueName.Name].Value = item.ExaminationQueueDefinition.Name;
                row.Cells[QueueItemObjectID.Name].Value = item.ObjectID.ToString();
                row.Cells[CallTime.Name].Value = ((DateTime)item.CallTime).ToShortTimeString();
                row.Cells[Priority.Name].Value = item.PriorityReason;
                if (item.Doctor != null)
                    row.Cells[Doctor.Name].Value = item.Doctor.Name;
            }
            
            DateTime startDate = Common.RecTime().Date;
            BindingList<ExaminationQueueItem.GetCompletedExaminationQueueItems_Class> completedItems = ExaminationQueueItem.GetCompletedExaminationQueueItems(startDate, Common.RecTime(), QueueListBox.SelectedObjectID.ToString());
            labelCompletedItemsCount.Text = "Bugün bu kuyrukta " + completedItems.Count + " adet muayene/işlemin kabulü yapılmıştır.";

            /*SelectedTabChanged e taşındı.*/
            /*List<Guid> queueDefs = new List<Guid>();
            //queueDefs.Add((Guid)QueueListBox.SelectedObjectID);
            BindingList<ExaminationQueueDefinition> qList = ExaminationQueueDefinition.GetQueueByResource(context, TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource.ObjectID.ToString());
            foreach(ExaminationQueueDefinition qd in qList)
            {
                queueDefs.Add(qd.ObjectID);
            }
            //BindingList<ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class> retCompletedList = ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors(Common.RecTime().Date.AddDays(1), Common.RecTime().Date, queueDefs);
            BindingList<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy_Class> retCompletedList = ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy(Common.RecTime().Date, Common.RecTime().Date.AddDays(1), queueDefs);
            
            gridCompletedItems.Rows.Clear();
            foreach (ExaminationQueueItem.GetCompletedItemsGroupedByCompletedBy_Class eqiClass in retCompletedList)
            {
                ResUser user = (ResUser)context.GetObject((Guid)eqiClass.CompletedBy, typeof(ResUser).Name);
                ITTGridRow row2 = gridCompletedItems.Rows.Add();
                row2.Cells[DoctorName.Name].Value = user.Person.FullName;
                row2.Cells[CompletedItemCount.Name].Value = Convert.ToInt32(eqiClass.Count);
            }*/
        }
        
        private void QueueChange(bool up, int currentIndex)
        {
            int targetIndex;
            if(up)
                targetIndex = QueueItemsGrid.CurrentCell.RowIndex - 1;
            else
                targetIndex = QueueItemsGrid.CurrentCell.RowIndex + 1;
            
            if(targetIndex == -1)
                return;

            TTObjectContext context = new TTObjectContext(false);

            if(QueueItemsGrid.Rows[currentIndex].Cells[QueueItemObjectID.Name].Value == null ||
               QueueItemsGrid.Rows[targetIndex].Cells[QueueItemObjectID.Name].Value == null)
                return;
            
            ExaminationQueueItem currentItem = (ExaminationQueueItem)context.GetObject(new Guid(QueueItemsGrid.Rows[currentIndex].Cells[QueueItemObjectID.Name].Value.ToString()), typeof(ExaminationQueueItem).Name);
            ExaminationQueueItem targetItem = (ExaminationQueueItem)context.GetObject(new Guid(QueueItemsGrid.Rows[targetIndex].Cells[QueueItemObjectID.Name].Value.ToString()), typeof(ExaminationQueueItem).Name);

            if (currentItem == null || targetItem == null)
                return;

            currentItem.Priority = targetItem.Priority;
            if(up)
                currentItem.DivertedTime = ((DateTime)targetItem.DivertedTime).AddSeconds(-1);
            else
                currentItem.DivertedTime = ((DateTime)targetItem.DivertedTime).AddSeconds(+1);
            
            context.Save();
            context.Dispose();
            
            ListExaminations();
        }
        
#endregion ExaminationQueueManagementForm_Methods
    }
}