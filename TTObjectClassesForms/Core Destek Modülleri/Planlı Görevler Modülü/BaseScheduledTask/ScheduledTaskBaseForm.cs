
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
    /// Planlı Görev
    /// </summary>
    public partial class ScheduledTaskBaseForm : TTForm
    {
        override protected void BindControlEvents()
        {
            btnRun.Click += new TTControlEventDelegate(btnRun_Click);
            GetHistoryButton.Click += new TTControlEventDelegate(GetHistoryButton_Click);
            Recurrency.TextChanged += new TTControlEventDelegate(Recurrency_TextChanged);
            NoEndDate.CheckedChanged += new TTControlEventDelegate(NoEndDate_CheckedChanged);
            Period.SelectedIndexChanged += new TTControlEventDelegate(Period_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnRun.Click -= new TTControlEventDelegate(btnRun_Click);
            GetHistoryButton.Click -= new TTControlEventDelegate(GetHistoryButton_Click);
            Recurrency.TextChanged -= new TTControlEventDelegate(Recurrency_TextChanged);
            NoEndDate.CheckedChanged -= new TTControlEventDelegate(NoEndDate_CheckedChanged);
            Period.SelectedIndexChanged -= new TTControlEventDelegate(Period_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void btnRun_Click()
        {
#region ScheduledTaskBaseForm_btnRun_Click
   TTObjectContext objectContext = new TTObjectContext(false);

            try
            {
                
                TTObject ttObject = this._BaseScheduledTask;
                ttObject = objectContext.GetObject(ttObject.ObjectID, ttObject.ObjectDef);

                if (ttObject == null)
                {
                    InfoBox.Show("Object not found");
                    return;
                }
                else
                {
                    System.Reflection.MethodInfo methodInfo = ttObject.GetType().GetMethod("TaskScript", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                    if (methodInfo != null)
                    {
                        object queueDef = methodInfo.Invoke(ttObject, new object[] { });
                        InfoBox.Show("Task Completed.", MessageIconEnum.InformationMessage);
                    }
                    else
                    {
                        InfoBox.Show("Task Script Method not found");
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion ScheduledTaskBaseForm_btnRun_Click
        }

        private void GetHistoryButton_Click()
        {
#region ScheduledTaskBaseForm_GetHistoryButton_Click
   string injectionNQL = string.Empty;
            if (this.HistoryStartDate.NullableValue.HasValue)
            {
                if (this.HistoryEndDate.NullableValue.HasValue)
                    injectionNQL = " AND LOGDATE BETWEEN " + Globals.CreateNQLToDateParameter(this.HistoryStartDate.NullableValue.Value) + " AND " + Globals.CreateNQLToDateParameter(this.HistoryEndDate.NullableValue.Value);
                else
                    injectionNQL = " AND LOGDATE >= " + Globals.CreateNQLToDateParameter(this.HistoryStartDate.NullableValue.Value);
            }
            else
            {
                if (this.HistoryEndDate.NullableValue.HasValue)
                    injectionNQL = " AND LOGDATE <= " + Globals.CreateNQLToDateParameter(this.HistoryEndDate.NullableValue.Value);
            }

            IList histories = ScheduledTaskHistory.GetScheduledTaskHistories(this._BaseScheduledTask.ObjectContext, this._BaseScheduledTask.ObjectID, injectionNQL);

            foreach(ScheduledTaskHistory history in histories)
            {
                ITTGridRow historyRow = ScheduledTaskHistories.Rows.Add();
                historyRow.Cells[LogDateScheduledTaskHistory.Name].Value = history.LogDate;
                historyRow.Cells[LogScheduledTaskHistory.Name].Value = history.Log;
            }
           
#endregion ScheduledTaskBaseForm_GetHistoryButton_Click
        }

        private void Recurrency_TextChanged()
        {
#region ScheduledTaskBaseForm_Recurrency_TextChanged
   this.SetEndDate();
#endregion ScheduledTaskBaseForm_Recurrency_TextChanged
        }

        private void NoEndDate_CheckedChanged()
        {
#region ScheduledTaskBaseForm_NoEndDate_CheckedChanged
   if (NoEndDate.Value == true)
            {
                labelEndDate.Visible = false;
                EndDate.Visible = false;
                EndDate.Text = null;
                _BaseScheduledTask.Recurrency = null;
                labelRecurrency.Visible = false;
                Recurrency.Visible = false;
            }
            else
            {
                labelEndDate.Visible = true;
                EndDate.Visible = true;
                _BaseScheduledTask.Recurrency = 1;
                labelRecurrency.Visible = true;
                Recurrency.Visible = true;
                SetEndDate();
            }
#endregion ScheduledTaskBaseForm_NoEndDate_CheckedChanged
        }

        private void Period_SelectedIndexChanged()
        {
#region ScheduledTaskBaseForm_Period_SelectedIndexChanged
   if ((int)this.Period.SelectedItem.Value == 0) //Bir Defa
            {
                Recurrency.Text = "1";
                labelRecurrency.Visible = false;
                Recurrency.Visible = false;
                labelEndDate.Visible = false;
                EndDate.Visible = false;
                labelWorhHour.Visible = true;
                txtWorhHour.Visible = true;
            }
            else if ((int)this.Period.SelectedItem.Value == 4) //Saatte Bir
            {
                labelWorhHour.Visible = false;
                txtWorhHour.Visible = false;
            }
            else
            {
                labelRecurrency.Visible = true;
                Recurrency.Visible = true;
                labelEndDate.Visible = true;
                EndDate.Visible = true;
                labelWorhHour.Visible = true;
                txtWorhHour.Visible = true;
            }

            this.SetEndDate();
#endregion ScheduledTaskBaseForm_Period_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region ScheduledTaskBaseForm_PreScript
    base.PreScript();

            if (_BaseScheduledTask.ExecutionCount == null)
                lblExecutionCount.Text = "Bu planlı görev henüz hiç çalışmadı";
            else
                lblExecutionCount.Text = "Bu planlı görev şimdiye kadar " + _BaseScheduledTask.ExecutionCount.ToString() + " defa çalışmıştır";

            if (NoEndDate.Value == null)
                NoEndDate.Value = false;

            if ((bool)NoEndDate.Value)
            {
                labelEndDate.Visible = false;
                EndDate.Visible = false;
                EndDate.Text = null;
                labelRecurrency.Visible = false;
                Recurrency.Visible = false;
            }
#endregion ScheduledTaskBaseForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ScheduledTaskBaseForm_PostScript
    base.PostScript(transDef);

            if (_BaseScheduledTask.Recurrency == 0)
                throw new TTUtils.TTException("Geçersiz tekrar sayısı.");

            if (_BaseScheduledTask.Recurrency == 1 && _BaseScheduledTask.Period != ScheduledTaskPeriodEnum.OneTime)
                throw new TTUtils.TTException("Tek tekrar için bu periyod seçilemez.");

            if (_BaseScheduledTask.Period != ScheduledTaskPeriodEnum.Hourly && string.IsNullOrEmpty(_BaseScheduledTask.WorkHour.ToString()))
                throw new TTUtils.TTException("Bu tekrar periyodu için çalışma saati boş geçilemez.");
#endregion ScheduledTaskBaseForm_PostScript

            }
            
#region ScheduledTaskBaseForm_Methods
        public void SetEndDate()
        {
            if (string.IsNullOrEmpty(Recurrency.Text) == false && _BaseScheduledTask.StartDate != null)
            {
                int rec = Convert.ToInt32(Recurrency.Text);
                if (rec == 0)
                    throw new TTUtils.TTException("Olmazzz");

                switch ((int)this.Period.SelectedItem.Value)
                {
                    case 0: //One Time
                        break;
                    case 1: //Everyday
                        _BaseScheduledTask.EndDate = ((DateTime)_BaseScheduledTask.StartDate).AddDays(rec);
                        break;
                    case 2: //Every Week
                        _BaseScheduledTask.EndDate = ((DateTime)_BaseScheduledTask.StartDate).AddDays(rec * 7);
                        break;
                    case 3: //Every Month
                        _BaseScheduledTask.EndDate = ((DateTime)_BaseScheduledTask.StartDate).AddMonths(rec);
                        break;
                    case 4: //Everyday
                        _BaseScheduledTask.EndDate = ((DateTime)_BaseScheduledTask.StartDate).AddHours(rec);
                        break;
                    default:
                        break;
                }
            }
        }
        
#endregion ScheduledTaskBaseForm_Methods
    }
}