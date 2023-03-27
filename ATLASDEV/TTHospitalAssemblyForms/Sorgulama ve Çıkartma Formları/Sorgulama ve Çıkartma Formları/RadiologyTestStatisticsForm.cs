
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
    public partial class RadiologyTestStatisticsForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            //wsPersusTestBtn.Click += new TTControlEventDelegate(wsPersusTestBtn_Click);

            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            TestsGrid.CellContentClick += new TTGridCellEventDelegate(TestsGrid_CellContentClick);
            cmdExportToExcel.Click += new TTControlEventDelegate(cmdExportToExcel_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            //wsPersusTestBtn.Click -= new TTControlEventDelegate(wsPersusTestBtn_Click);

            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            TestsGrid.CellContentClick -= new TTGridCellEventDelegate(TestsGrid_CellContentClick);
            cmdExportToExcel.Click -= new TTControlEventDelegate(cmdExportToExcel_Click);
            base.UnBindControlEvents();
        }
        //private void wsPersusTestBtn_Click()
        //{
        //    PersusWS per = new PersusWS();
            
        //    //TTMessage loginResult = PersusWS.WebMethods.loginAsync(Sites.SiteLocalHost, null, "atlas","321persus", "10000000000");


        //}
        private void cmdList_Click()
        {
#region RadiologyTestStatisticsForm_cmdList_Click
   TestsGrid.Rows.Clear();
            //TTObjectContext context = new TTObjectContext(true);
            //BindingList<RadiologyTest> tests;

            BindingList<RadiologyTest.GetRadiologyTestStatisticsByFilter_Class> tests;

            DateTime dateMin, dateMax;
            if (txtReportDateMin.NullableValue.HasValue && txtReportDateMax.NullableValue.HasValue)
            {
                dateMin = (DateTime)txtReportDateMin.ControlValue;
                dateMax = (DateTime)txtReportDateMax.ControlValue;
            }
            else
            {
                DialogResult result = MessageBox.Show("Rapor Tarihi için 'Başlangıç' ve 'Bitiş' seçmediniz. Devam etmek istiyor musunuz?","Uyarı!", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    dateMin = DateTime.MinValue;
                    dateMax = DateTime.MaxValue;
                }
                else
                {
                    return;
                }
            }
            
            //tests = RadiologyTest.GetByFilterExpressionStatistics(context, GenerateFilterExpression());

            tests = RadiologyTest.GetRadiologyTestStatisticsByFilter(GenerateFilterExpression());
            
            //BURALAR

            
            foreach (RadiologyTest.GetRadiologyTestStatisticsByFilter_Class item in tests)
            {
                ITTGridRow addedRow = this.TestsGrid.Rows.Add();

                if (item.Patientid.HasValue)
                    addedRow.Cells[PatientID.Name].Value = item.Patientid.Value.ToString();

                addedRow.Cells[NameSurname.Name].Value = item.Name + " " + item.Surname;

                if (item.BirthDate.HasValue)
                    addedRow.Cells[BirthDate.Name].Value = item.BirthDate.Value;

                addedRow.Cells[TestCode.Name].Value = item.Testcode;

                addedRow.Cells[TestName.Name].Value = item.Testname;

                addedRow.Cells[RequestDoctor.Name].Value = item.Requestdoctor;

                addedRow.Cells[FromResource.Name].Value = item.Fromresource;

                if (item.ReportTxt != null)
                {
                    addedRow.Cells[Report.Name].Value = item.ReportTxt.Trim();
                    
                    /* 
                     * //Bu kod burda dursun.Belki lazım olur.
                    string reportResult = System.Text.Encoding.Default.GetString(TTBinaryData.GetBinaryData(new Guid(item.Report.ToString())));
                    //string rtfResult = Common.GetRTFOfTextString(reportResult);
                    //string textResult = Common.GetTextOfRTFString(reportResult);
                    addedRow.Cells[Report.Name].Value = Common.GetRTFOfTextString(reportResult);
                     */
                }

                if (item.ReportDate.HasValue)
                    addedRow.Cells[ReportDate.Name].Value = item.ReportDate.Value;

                addedRow.Cells[ReportedBy.Name].Value = item.Reportedby;

                addedRow.Cells[PrintReport.Name].Value = "Yazdır";
                
                addedRow.Cells[RadiologyTestObjectID.Name].Value = item.Radiologytestobjectid.Value.ToString().Trim();
                
                if(item.PatientStatus.HasValue)
                {
                    addedRow.Cells[EpisodePatientStatus.Name].Value = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(item.PatientStatus.Value);
                }
                
         
            }
            

            /*
            foreach (RadiologyTest rt in tests)
            {
                if(rt.EpisodeAction == null)
                    continue;
                if(rt.EpisodeAction.Episode == null)
                    continue;
                if(rt.EpisodeAction.Episode.Patient == null)
                    continue;
                
                bool addIt = true;
                
                if(addIt)
                {
                    ITTGridRow addedRow = this.TestsGrid.Rows.Add();
                    addedRow.Cells[NameSurname.Name].Value = rt.EpisodeAction.Episode.Patient.FullName;
                    if(rt.EpisodeAction.Episode.Patient.ID != null)
                        addedRow.Cells[PatientID.Name].Value = rt.EpisodeAction.Episode.Patient.ID.ToString();
                    addedRow.Cells[BirthDate.Name].Value = rt.EpisodeAction.Episode.Patient.BirthDate;
                    addedRow.Cells[Report.Name].Value = rt.Report;
                    addedRow.Cells[ReportDate.Name].Value = rt.ReportDate;
                    addedRow.Cells[FromResource.Name].Value = rt.FromResource;
                }
            }
             */


            labelRadiologyTestCount.Text = TestsGrid.Rows.Count.ToString();
#endregion RadiologyTestStatisticsForm_cmdList_Click
        }

        private void TestsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region RadiologyTestStatisticsForm_TestsGrid_CellContentClick
   if (columnIndex == 12 && rowIndex != -1)
            {
                ITTGridRow currentRow = this.TestsGrid.Rows[rowIndex];
                if (currentRow.Cells[RadiologyTestObjectID.Name].Value != null)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
                    pc.Add("VALUE", currentRow.Cells[RadiologyTestObjectID.Name].Value.ToString().Trim());
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_RadiologyTestResultReport), true, 1, parameters);
                }
            }
#endregion RadiologyTestStatisticsForm_TestsGrid_CellContentClick
        }

        private void cmdExportToExcel_Click()
        {
#region RadiologyTestStatisticsForm_cmdExportToExcel_Click
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
#endregion RadiologyTestStatisticsForm_cmdExportToExcel_Click
        }

#region RadiologyTestStatisticsForm_Methods
        public string GenerateFilterExpression()
        {
            DateTime dateMin;
            DateTime dateMax;
            string filterExpression = string.Empty;

            ResUser requestDoctor = txtRequestDoctor.SelectedObject as ResUser;
            ResUser reportedBy = txtReportedBy.SelectedObject as ResUser;
            ResSection fromResource = txtFromResource.SelectedObject as ResSection;
            RadiologyTestDefinition testDef = txtTestDef.SelectedObject as RadiologyTestDefinition;
            
            if(string.IsNullOrEmpty(txtReport.Text) == false)
                filterExpression += " AND REPORTTXT LIKE '%" +  Globals.CUCase(txtReport.Text, false, false) + "%'";
            
            //            if(!string.IsNullOrEmpty(txtCode.Text))
            //                filterExpression += " AND THIS:PROCEDUREOBJECT.CODE LIKE '%" + Globals.CUCase(txtCode.Text,false,false) + "%'";

            if(testDef != null)
                filterExpression += " AND THIS:PROCEDUREOBJECT.OBJECTID = " + ConnectionManager.GuidToString(testDef.ObjectID);

            if (requestDoctor != null)
                filterExpression += " AND THIS:RADIOLOGY.REQUESTDOCTOR.OBJECTID = " + ConnectionManager.GuidToString(requestDoctor.ObjectID);
            
            if(reportedBy != null)
                filterExpression += " AND THIS.REPORTEDBY.OBJECTID = " + ConnectionManager.GuidToString(reportedBy.ObjectID);

            if (fromResource != null)
                filterExpression += " AND THIS:FROMRESOURCE.OBJECTID = " + ConnectionManager.GuidToString(fromResource.ObjectID);
            
            if(txtReportDateMin.NullableValue.HasValue && txtReportDateMax.NullableValue.HasValue)
            {
                dateMin = (DateTime)txtReportDateMin.ControlValue;
                dateMax = (DateTime)txtReportDateMax.ControlValue;
                filterExpression += " AND REPORTDATE BETWEEN " + Globals.CreateNQLToDateParameter(dateMin) + " AND " + Globals.CreateNQLToDateParameter(dateMax);
            }
            
            return filterExpression;
        }
        
#endregion RadiologyTestStatisticsForm_Methods
    }
}