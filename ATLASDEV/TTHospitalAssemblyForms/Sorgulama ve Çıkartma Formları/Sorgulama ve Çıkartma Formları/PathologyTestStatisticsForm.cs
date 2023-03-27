
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
    public partial class PathologyTestStatisticsForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            TestsGrid.CellDoubleClick += new TTGridCellEventDelegate(TestsGrid_CellDoubleClick);
            TestsGrid.CellContentClick += new TTGridCellEventDelegate(TestsGrid_CellContentClick);
            cmdExportToExcel.Click += new TTControlEventDelegate(cmdExportToExcel_Click);
            ttRejected.CheckedChanged += new TTControlEventDelegate(ttRejected_CheckedChanged);
            ttCancelled.CheckedChanged += new TTControlEventDelegate(ttCancelled_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            TestsGrid.CellDoubleClick -= new TTGridCellEventDelegate(TestsGrid_CellDoubleClick);
            TestsGrid.CellContentClick -= new TTGridCellEventDelegate(TestsGrid_CellContentClick);
            cmdExportToExcel.Click -= new TTControlEventDelegate(cmdExportToExcel_Click);
            ttRejected.CheckedChanged -= new TTControlEventDelegate(ttRejected_CheckedChanged);
            ttCancelled.CheckedChanged -= new TTControlEventDelegate(ttCancelled_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void cmdList_Click()
        {
#region PathologyTestStatisticsForm_cmdList_Click
   TestsGrid.Rows.Clear();
            //TTObjectContext context = new TTObjectContext(true);
            //BindingList<PathologyTest> tests;
            
            BindingList<Pathology.GetPathologyTestStatisticsByFilter_Class> tests;
            
            /*
            DateTime dateMin, dateMax;
            if (((System.Windows.Forms.DateTimePicker)(txtPatientBirthDateMin)).Checked && ((System.Windows.Forms.DateTimePicker)(txtPatientBirthDateMax)).Checked)
            {
                dateMin = (DateTime)txtPatientBirthDateMin.ControlValue;
                dateMax = (DateTime)txtPatientBirthDateMax.ControlValue;
            }
            else
            {
                dateMin = DateTime.MinValue;
                dateMax = DateTime.MaxValue;
            }
            tests = PathologyTest.GetByFilterExpression(context, dateMin, dateMax, GenerateFilterExpression());
             */
            
            tests = Pathology.GetPathologyTestStatisticsByFilter(GenerateFilterExpression());
            
            
            foreach (Pathology.GetPathologyTestStatisticsByFilter_Class item in tests)
            {
                ITTGridRow addedRow = this.TestsGrid.Rows.Add();
                
                if(!String.IsNullOrEmpty(item.MatPrtNoString))
                    addedRow.Cells[MatPrtNoString.Name].Value = item.MatPrtNoString.Trim();
                
                if(item.UniqueRefNo.HasValue)
                    addedRow.Cells[UniqueRefNo.Name].Value = item.UniqueRefNo.Value.ToString();
                
                addedRow.Cells[NameSurname.Name].Value = item.Name + " " + item.Surname;
                
                if(item.BirthDate.HasValue)
                    addedRow.Cells[BirthDate.Name].Value = item.BirthDate.Value;
                
                if(item.Sex.HasValue)
                {
                    if(item.Sex.Value.ToString() == "KADIN")
                        addedRow.Cells[Sex.Name].Value = "Kadın";
                    else
                        addedRow.Cells[Sex.Name].Value = "Erkek";
                }
                //TODO ASLI ?? methoda bak 
                //if(!String.IsNullOrEmpty(item.Diagnosecomment))
                //    addedRow.Cells[Diagnose.Name].Value = item.Diagnosecomment.Trim();
                
                //if(!String.IsNullOrEmpty(item.Microscopi))
                //    addedRow.Cells[Microscopy.Name].Value = item.Microscopi.Trim();
                
                //if(!String.IsNullOrEmpty(item.Macroscopi))
                //    addedRow.Cells[Macroscopy.Name].Value = item.Macroscopi.Trim();
                
                if(!String.IsNullOrEmpty(item.Responsibledoctor))
                    addedRow.Cells[ResponsibleDoctor.Name].Value = item.Responsibledoctor.Trim();
                
                if(!String.IsNullOrEmpty(item.Specialdoctor))
                    addedRow.Cells[Doctor.Name].Value = item.Specialdoctor.Trim();
                
                if(item.ReportDate.HasValue)
                    addedRow.Cells[ReportDate.Name].Value = item.ReportDate.Value;
                
                if(!String.IsNullOrEmpty(item.Snomeddiagnose))
                    addedRow.Cells[SnomedDiagnosys.Name].Value = item.Snomeddiagnose.Trim();
                
                if(!String.IsNullOrEmpty(item.Consultantdoctor))
                    addedRow.Cells[ConsultantDoctor.Name].Value = item.Consultantdoctor.Trim();
                
                addedRow.Cells[PrintReport.Name].Value = "Yazdır";
                
                addedRow.Cells[PathologyTestObjectID.Name].Value = item.Pathologytestobjectid.Value.ToString().Trim();

                if(item.Panicnotification.HasValue && item.Panicnotification.Value == true)
                {
                    addedRow.Cells[PanicNotification.Name].Value = "VAR";
                }
                else
                {
                    addedRow.Cells[PanicNotification.Name].Value = "YOK";
                }
                
                if(item.ID != null && item.ID.HasValue)
                {
                    addedRow.Cells[ID.Name].Value = item.ID.Value.ToString();
                }

                if(item.CurrentStateDefID.HasValue)
                {
                    switch(item.CurrentStateDefID.Value.ToString().Trim())
                    {
                        case "2548a4ff-174f-4957-9551-8dcbfb6e0545":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Onayda";
                            break;
                        case "0353e400-c663-4c21-8d30-7e50f2befc0b":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "İptal";
                            break;
                        case "173ce0ef-b59f-42d0-bec9-6b63cbb12181":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Materyal İade";
                            break;
                        case "61ba736a-0a59-44bd-9e6d-261256f0f372":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Makroskopi";
                            break;
                        case "c979833f-43c4-408d-b896-93b2bc54eef4":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Ek İşlemler";
                            break;
                        case "385ec184-fb3e-4ee4-9f9f-77455425122d":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Mikroskopi";
                            break;
                        case "ac5599ed-7a29-4ad5-9dd8-bbedab63b659":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Rutin Doku Hücre İşlemi";
                            break;
                        case "9fcf16d5-2910-4268-86d3-2529db5eb3e0":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Red Edildi";
                            break;
                        case "e8a45f00-814f-4194-b719-e0d5889f47c7":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Rapor Edildi";
                            break;
                        case "7d3ea58f-bf6c-4e3e-8b2d-ca67871eb11f":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Tetkik İstek";
                            break;
                        case "f1850750-1295-460a-941f-ac5dfbccf5f7":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "İstek Kabul";
                            break;
                        case "448211dd-0f30-40d9-9328-a08657465cd6":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Baştabip Onay";
                            break;
                        case "d9129e8b-9bf6-4411-b8cf-ade4a5507ae7":
                            addedRow.Cells[CurrentStateDefID.Name].Value = "Sonuç Giriş";
                            break;     
                    }
                }
                
                
            }
            
            /*
            foreach (PathologyTest pt in tests)
            {
                if(pt.EpisodeAction == null)
                    continue;
                if(pt.EpisodeAction.Episode == null)
                    continue;
                if(pt.EpisodeAction.Episode.Patient == null)
                    continue;
                
                bool addIt = true;
                if(txtSnomedDiagnosis.SelectedValue != null)
                {
                    addIt = false;
                    foreach(SnomedDiagnosisGrid snGrid in pt.SnomedDiagnosis)
                    {
                        if(snGrid.SnomedDiagnose != null)
                        {
                            if(snGrid.SnomedDiagnose.ObjectID != null && (Guid)txtSnomedDiagnosis.SelectedObjectID != null)
                            {
                                if(snGrid.SnomedDiagnose.ObjectID == (Guid)txtSnomedDiagnosis.SelectedObjectID)
                                {
                                    addIt = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                
                if(txtConsultantDoctor.SelectedValue != null)
                {
                    addIt = false;
                    foreach(PathologyConsultantDoctor pcDoctor in pt.PathologyConsultantDoctors)
                    {
                        if(pcDoctor.ConsultantDoctor != null)
                        {
                            if(pcDoctor.ConsultantDoctor.ObjectID !=null && (Guid)txtConsultantDoctor.SelectedObjectID != null)
                            {
                                if(pcDoctor.ConsultantDoctor.ObjectID == (Guid)txtConsultantDoctor.SelectedObjectID)
                                {
                                    addIt = true;
                                    break;
                                }
                            }
                                
                        }
                    }
                }
                
                if(addIt)
                {
                    ITTGridRow addedRow = this.TestsGrid.Rows.Add();
                    if(pt.EpisodeAction.Episode.Patient.FullName != null)
                        addedRow.Cells[NameSurname.Name].Value = pt.EpisodeAction.Episode.Patient.FullName;
                    if(pt.EpisodeAction.Episode.Patient.UniqueRefNo != null)
                        addedRow.Cells[UniqueRefNo.Name].Value = pt.EpisodeAction.Episode.Patient.UniqueRefNo.ToString();
                    if(pt.EpisodeAction.Episode.Patient.BirthDate != null)
                        addedRow.Cells[BirthDate.Name].Value = pt.EpisodeAction.Episode.Patient.BirthDate;
                    if(pt.EpisodeAction.Episode.Patient.Sex == SexEnum.Female)
                        addedRow.Cells[Sex.Name].Value = "Kadın";
                    else
                        addedRow.Cells[Sex.Name].Value = "Erkek";
                    if(pt.ReportMicroscopi != null)
                    {
                        addedRow.Cells[Microscopy.Name].Value = pt.ReportMicroscopi;
                        addedRow.Cells[Macroscopy.Name].Value = pt.ReportMacroscopi;
                    }
                    if(pt.ReportDiagnoseComment != null)
                        addedRow.Cells[Diagnose.Name].Value = pt.ReportDiagnoseComment.ToString();
                    if(pt.ReportAdditionalOperation != null)
                        addedRow.Cells[AdditionalOperation.Name].Value = pt.ReportAdditionalOperation;
                    if(pt.MatPrtNoString != null)
                        addedRow.Cells[MatPrtNoString.Name].Value = pt.MatPrtNoString;
                    if(pt.ResponsibleDoctor != null)
                        addedRow.Cells[ResponsibleDoctor.Name].Value = pt.ResponsibleDoctor.Name;
                    if(pt.SpecialDoctor != null)
                        addedRow.Cells[Doctor.Name].Value = pt.SpecialDoctor.Name;
                    if(pt.ReportDate != null)
                        addedRow.Cells[ReportDate.Name].Value = pt.ReportDate;
                    if(pt.SnomedDiagnosis.Count > 0)
                    {
                        if(txtSnomedDiagnosis.SelectedObject == null)
                        {
                            if(((SnomedDiagnosisGrid)pt.SnomedDiagnosis[0]).SnomedDiagnose != null)
                                addedRow.Cells[SnomedDiagnosys.Name].Value = ((SnomedDiagnosisGrid)pt.SnomedDiagnosis[0]).SnomedDiagnose.Name;
                        }
                        else
                            addedRow.Cells[SnomedDiagnosys.Name].Value = ((SnomedDiagnosisDefinition)txtSnomedDiagnosis.SelectedObject).Name;
                    }
                    if (pt.PathologyConsultantDoctors.Count > 0)
                    {
                        if (txtConsultantDoctor.SelectedObject == null)
                        {
                            if(((PathologyConsultantDoctor)pt.PathologyConsultantDoctors[0]).ConsultantDoctor != null)
                                addedRow.Cells[ConsultantDoctor.Name].Value = ((PathologyConsultantDoctor)pt.PathologyConsultantDoctors[0]).ConsultantDoctor.Name;
                        }
                        else
                            addedRow.Cells[ConsultantDoctor.Name].Value = ((ResUser)txtConsultantDoctor.SelectedObject).Name;
                    }
                }
            }
             */
            
            labelPathologyCount.Text = TestsGrid.Rows.Count.ToString();
#endregion PathologyTestStatisticsForm_cmdList_Click
        }

        private void TestsGrid_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
        }

        private void TestsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PathologyTestStatisticsForm_TestsGrid_CellContentClick
   if (columnIndex == 16 && rowIndex != -1)
            {
                ITTGridRow currentRow = this.TestsGrid.Rows[rowIndex];
                if (currentRow.Cells[PathologyTestObjectID.Name].Value != null)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
                    pc.Add("VALUE", currentRow.Cells[PathologyTestObjectID.Name].Value.ToString().Trim());
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_PathologyTestResultReport), true, 1, parameters);
                }
            }
#endregion PathologyTestStatisticsForm_TestsGrid_CellContentClick
        }

        private void cmdExportToExcel_Click()
        {
#region PathologyTestStatisticsForm_cmdExportToExcel_Click
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
                ////saveFileDialog.FileName = "Patoloji_Testleri";

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
#endregion PathologyTestStatisticsForm_cmdExportToExcel_Click
        }

        private void ttRejected_CheckedChanged()
        {
#region PathologyTestStatisticsForm_ttRejected_CheckedChanged
   if (this.ttRejected.Value == true)
                this.ttCancelled.Value = false;
#endregion PathologyTestStatisticsForm_ttRejected_CheckedChanged
        }

        private void ttCancelled_CheckedChanged()
        {
#region PathologyTestStatisticsForm_ttCancelled_CheckedChanged
   if (this.ttCancelled.Value == true)
                this.ttRejected.Value = false;
#endregion PathologyTestStatisticsForm_ttCancelled_CheckedChanged
        }

#region PathologyTestStatisticsForm_Methods
        public string GenerateFilterExpression()
        {
            DateTime dateMin;
            DateTime dateMax;
            string filterExpression = string.Empty;
            
            ResUser respDoc = txtResponsibleDoctor.SelectedObject as ResUser;
            ResUser doctor = txtDoctor.SelectedObject as ResUser;
            ResUser consultantDoctor = txtConsultantDoctor.SelectedObject as ResUser;
            SnomedDiagnosisDefinition snomed = txtSnomedDiagnosis.SelectedObject as SnomedDiagnosisDefinition;
            
            
            if(respDoc != null)
                filterExpression += " AND RESPONSIBLEDOCTOR.OBJECTID = " + ConnectionManager.GuidToString(respDoc.ObjectID);
            /*
            if (respDoc != null)
                filterExpression += " AND RESPONSIBLEDOCTOR = " + ConnectionManager.GuidToString(respDoc.ObjectID);
             */
            
            if (doctor != null)
                filterExpression += " AND SPECIALDOCTOR.OBJECTID = " + ConnectionManager.GuidToString(doctor.ObjectID);
            /*
            if (doctor != null)
                filterExpression += " AND SPECIALDOCTOR = " + ConnectionManager.GuidToString(doctor.ObjectID);
             */
            
            if (consultantDoctor != null)
                filterExpression += " AND PATHOLOGYCONSULTANTDOCTORS.CONSULTANTDOCTOR.OBJECTID = " + ConnectionManager.GuidToString(consultantDoctor.ObjectID);
            /*
            if (consultantDoctor != null)
                filters.Add("PATHOLOGYCONSULTANTDOCTORS(OBJECTID = " + ConnectionManager.GuidToString(consultantDoctor.ObjectID) + ").EXISTS");
             */
            
            if (snomed != null)
                filterExpression += " AND SNOMEDDIAGNOSIS.SNOMEDDIAGNOSE.OBJECTID = " + ConnectionManager.GuidToString(snomed.ObjectID);
            /*
            if (snomed != null)
                filters.Add("SNOMEDDIAGNOSIS(OBJECTID = " + ConnectionManager.GuidToString(snomed.ObjectID) + ").EXISTS");
             */

            if(string.IsNullOrEmpty(txtMakroskopi.Text) == false)
                filterExpression += " AND REPORTMACROSCOPITXT LIKE '%" +  Globals.CUCase(txtMakroskopi.Text, false, false) + "%'";
            
            if(string.IsNullOrEmpty(txtMikroskopi.Text) == false)
                filterExpression += " AND REPORTMICROSCOPITXT LIKE '%" + Globals.CUCase(txtMikroskopi.Text, false, false) + "%'";
            
            if(string.IsNullOrEmpty(txtDiagnose.Text) == false)
                filterExpression += " AND REPORTDIAGNOSECOMMENTTXT LIKE '%" + Globals.CUCase(txtDiagnose.Text, false, false) + "%'";
            
            if(string.IsNullOrEmpty(txtPathologyNo.Text) == false)
                filterExpression += " AND MATPRTNOSTRING LIKE '%" + Globals.CUCase(txtPathologyNo.Text, false, false) + "%'";
            
            if(txtAcceptionDateMin.NullableValue.HasValue && txtAcceptionDateMax.NullableValue.HasValue)
            {
                dateMin = (DateTime)txtAcceptionDateMin.ControlValue;
                dateMax = (DateTime)txtAcceptionDateMax.ControlValue;
                filterExpression += " AND ACCEPTIONDATE BETWEEN " + Globals.CreateNQLToDateParameter(dateMin) + " AND " + Globals.CreateNQLToDateParameter(dateMax);
            }

            if(txtReportDateMin.NullableValue.HasValue && txtReportDateMax.NullableValue.HasValue)
            {
                dateMin = (DateTime)txtReportDateMin.ControlValue;
                dateMax = (DateTime)txtReportDateMax.ControlValue;
                filterExpression += " AND REPORTDATE BETWEEN " + Globals.CreateNQLToDateParameter(dateMin) + " AND " + Globals.CreateNQLToDateParameter(dateMax);
            }
            
            if(txtPatientBirthDateMin.NullableValue.HasValue && txtPatientBirthDateMax.NullableValue.HasValue)
            {
                dateMin = (DateTime)txtPatientBirthDateMin.ControlValue;
                dateMax = (DateTime)txtPatientBirthDateMax.ControlValue;
                filterExpression += " AND EPISODE.PATIENT.BIRTHDATE BETWEEN " + Globals.CreateNQLToDateParameter(dateMin) + " AND " + Globals.CreateNQLToDateParameter(dateMax);
            }
            
            if(this.ttPanicNotification.Value == true)
            {
                filterExpression += " AND SNOMEDDIAGNOSIS.PANICDIAGNOSISNOTIFICATION = '1'";
            }
            
           
            if(this.ttCancelled.Value == true)
            {
                filterExpression += " AND CURRENTSTATEDEFID  = '" + Pathology.States.Cancelled.ToString()+ "'";
            }
            
            return filterExpression;
        }
        
#endregion PathologyTestStatisticsForm_Methods
    }
}