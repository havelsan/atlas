
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
    public partial class NuclearMedicineStatisticsForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            cmdExportToExcel.Click += new TTControlEventDelegate(cmdExportToExcel_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            cmdExportToExcel.Click -= new TTControlEventDelegate(cmdExportToExcel_Click);
            base.UnBindControlEvents();
        }

        private void cmdList_Click()
        {
#region NuclearMedicineStatisticsForm_cmdList_Click
   TestsGrid.Rows.Clear();
            TTObjectContext context = new TTObjectContext(true);
            BindingList<NuclearMedicine> tests;
            DateTime dateMin, dateMax;
            if (txtReportDateMin.NullableValue.HasValue && txtReportDateMax.NullableValue.HasValue)
            {
                dateMin = (DateTime)txtReportDateMin.ControlValue;
                dateMax = (DateTime)txtReportDateMax.ControlValue;
            }
            else
            {
                dateMin = DateTime.MinValue;
                dateMax = DateTime.MaxValue;
            }
            tests = NuclearMedicine.GetByWLFilterExpression(context, GenerateFilterExpression());
            
            foreach (NuclearMedicine nm in tests)
            {
                if(nm == null)
                    continue;
                if(nm.Episode == null)
                    continue;
                if(nm.Episode.Patient == null)
                    continue;
                
                bool addIt = true;
                
                if(addIt)
                {
                    ITTGridRow addedRow = this.TestsGrid.Rows.Add();
                    addedRow.Cells[NameSurname.Name].Value = nm.Episode.Patient.FullName;
                    if (nm.Episode.Patient.ID != null)
                        addedRow.Cells[PatientID.Name].Value = nm.Episode.Patient.ID.ToString();
                    addedRow.Cells[BirthDate.Name].Value = nm.Episode.Patient.BirthDate;
                    addedRow.Cells[Report.Name].Value = nm.Report;
                    addedRow.Cells[ReportDate.Name].Value = nm.ReportDate;
                    addedRow.Cells[FromResource.Name].Value = nm.FromResource;
                }
            }
            labelNuclearMedicineCount.Text = TestsGrid.Rows.Count.ToString();
#endregion NuclearMedicineStatisticsForm_cmdList_Click
        }

        private void cmdExportToExcel_Click()
        {
#region NuclearMedicineStatisticsForm_cmdExportToExcel_Click
   try
            {
                if (TestsGrid.Rows.Count == 0)
                {
                    InfoBox.Show("Dışarıya çıkartmak için en az bir test listelenmiş olmalıdır.");
                    return;
                }

                //SaveFileDialog saveFileDialog = new SaveFileDialog();
                //saveFileDialog.Filter = "Excel 97-2003 Workbook (*.xls)|*.xls";
                //saveFileDialog.DefaultExt = "xls";
                //saveFileDialog.RestoreDirectory = true;

                //DialogResult dialogResult = saveFileDialog.ShowDialog(this);
                //if (dialogResult == DialogResult.OK)
                //{
                //    this.TestsGrid.ExportGridToExcel(saveFileDialog.FileName, false);
                //}
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion NuclearMedicineStatisticsForm_cmdExportToExcel_Click
        }

#region NuclearMedicineStatisticsForm_Methods
        public string GenerateFilterExpression()
        {
            DateTime dateMin;
            DateTime dateMax;
            string filterExpression = string.Empty;
            
            if(string.IsNullOrEmpty(txtReport.Text) == false)
                filterExpression += " AND REPORTTXT LIKE '%" +  Globals.CUCase(txtReport.Text, false, false) + "%'";
            
            if(txtReportDateMin.NullableValue.HasValue && txtReportDateMax.NullableValue.HasValue)
            {
                dateMin = (DateTime)txtReportDateMin.ControlValue;
                dateMax = (DateTime)txtReportDateMax.ControlValue;
                filterExpression += " AND REPORTDATE BETWEEN " + Globals.CreateNQLToDateParameter(dateMin) + " AND " + Globals.CreateNQLToDateParameter(dateMax);
            }
            
            return filterExpression;
        }
        
#endregion NuclearMedicineStatisticsForm_Methods
    }
}