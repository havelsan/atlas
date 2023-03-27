
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
    public partial class TreatmentDischargeSearchForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdListToExcel.Click += new TTControlEventDelegate(cmdListToExcel_Click);
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            cmdExportToExcel.Click += new TTControlEventDelegate(cmdExportToExcel_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdListToExcel.Click -= new TTControlEventDelegate(cmdListToExcel_Click);
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            cmdExportToExcel.Click -= new TTControlEventDelegate(cmdExportToExcel_Click);
            base.UnBindControlEvents();
        }

        private void cmdListToExcel_Click()
        {
#region TreatmentDischargeSearchForm_cmdListToExcel_Click
   try
            {
                
                //SaveFileDialog saveFileDialog = new SaveFileDialog();
                //saveFileDialog.Filter = "Text |*.txt";
                //saveFileDialog.DefaultExt = "txt";
                //saveFileDialog.RestoreDirectory = true;
                
                //StringBuilder sb = new StringBuilder();

                //DialogResult dialogResult = saveFileDialog.ShowDialog(this);
                //if (dialogResult == DialogResult.OK)
                //{
                //    TTObjectContext context = new TTObjectContext(true);
                //    BindingList<TreatmentDischarge> treatmentDischarges;
                    
                //    string filterExpression = GenerateFilterExpression();
                    
                //    treatmentDischarges = TreatmentDischarge.GetTreatmentDischargeByDate(context,filterExpression);
                    
                //    string uniqueRefno = " ";
                //    string patientNameSurname= " ";
                //    string patientBirthDate = " ";
                //    string patientGender = " ";
                //    string emergency = " ";
                //    string requestDate = " ";
                //    string worklistDate = " ";
                //    string dischargeDate = " ";
                //    string dischargeType = " ";
                //    string dischargeToPlace = " ";
                //    string conclusion = " ";
                //    string procedureSpeciality = " ";
                //    string protocolNo = " ";
                //    string procedureDoctor = " ";
                    
                //    sb.AppendFormat("{0}£{1}£{2}£{3}£{4}£{5}£{6}£{7}£{8}£{9}£{10}£{11}£{12}£{13}","TC Kimlik Numarası","Hasta Adı Soyadı","Hasta Doğum Tarihi","Cinsiyeti","Acil","İstek Tarihi","İşlem Tarihi","Karar Tarihi","Taburcu Tipi","Taburcu Gidiş Yeri","Karar","İşlemin Yapıldığı Uzmanlık Dalı","Protokol No","Tedavi Kararını Yazan Doktor");
                //    sb.AppendLine();
                    
                //    foreach (TreatmentDischarge item in treatmentDischarges)
                //    {
                        
                //        if(item.Episode.Patient != null)
                //        {
                //            if(!String.IsNullOrEmpty(item.Episode.Patient.Name))
                //                patientNameSurname += item.Episode.Patient.Name + " ";
                            
                //            if(!String.IsNullOrEmpty(item.Episode.Patient.Surname))
                //                patientNameSurname += item.Episode.Patient.Surname;
                            
                //            if(item.Episode.Patient.BirthDate != null)
                //                patientBirthDate = String.Format("{0:dd/MM/yyyy}", item.Episode.Patient.BirthDate);
                            
                //            if(item.Episode.Patient.UniqueRefNo.HasValue)
                //                uniqueRefno  = item.Episode.Patient.UniqueRefNo.Value.ToString();
                            
                //            if(item.Episode.Patient.Sex.HasValue)
                //                patientGender = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(item.Episode.Patient.Sex.Value).DisplayText;
                //        }
                        
                //        if(item.Emergency != null)
                //        {
                //            if(item.Emergency.Value == true)
                //                emergency = "Evet";
                //            else
                //                emergency = "Hayır";
                //        }
                        
                //        if(item.WorkListDate != null)
                //        {
                //            worklistDate = String.Format("{0:dd/MM/yyyy HH:mm}", item.WorkListDate);
                //        }

                //        if(item.RequestDate != null)
                //        {
                //            requestDate = String.Format("{0:dd/MM/yyyy HH:mm}", item.RequestDate);
                //        }

                //        if(item.DischargeDate != null)
                //        {
                //            dischargeDate = String.Format("{0:dd/MM/yyyy HH:mm}", item.DischargeDate);
                //        }
                        
                //        if(item.DischargeType != null)
                //        {
                //            dischargeType = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(item.DischargeType.Value).DisplayText;
                //        }
                        
                //        if(item.DischargeToPlace != null)
                //        {
                //            dischargeToPlace = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(item.DischargeToPlace.Value).DisplayText;
                //        }
                        
                //        if(item.ProcedureSpeciality != null)
                //        {
                //            procedureSpeciality = item.ProcedureSpeciality.Name.Trim();
                //        }
                        
                //        if(item.ProtocolNo.Value != null)
                //        {
                //            protocolNo = item.ProtocolNo.Value.ToString();
                //        }
                        
                //        if(item.ProcedureDoctor != null)
                //        {
                //            procedureDoctor = item.ProcedureDoctor.Name.Trim();
                //        }
                        
                //        if(item.Conclusion != null)
                //        {
                //            conclusion = Common.GetTextOfRTFString(item.Conclusion.ToString());
                //            conclusion = conclusion.Replace("\n",String.Empty).Replace("\r",String.Empty);
                //        }
                        
                //        sb.AppendFormat("{0}£{1}£{2}£{3}£{4}£{5}£{6}£{7}£{8}£{9}£{10}£{11}£{12}£{13}",uniqueRefno,patientNameSurname,patientBirthDate,patientGender,emergency,requestDate,worklistDate,dischargeDate,dischargeType,dischargeToPlace,conclusion,procedureSpeciality,protocolNo,procedureDoctor);
                //        sb.AppendLine();
                        
                //        uniqueRefno = " ";
                //        patientNameSurname= " ";
                //        patientBirthDate = " ";
                //        patientGender = " ";
                //        emergency = " ";
                //        requestDate = " ";
                //        worklistDate = " ";
                //        dischargeDate = " ";
                //        dischargeType = " ";
                //        dischargeToPlace = " ";
                //        conclusion = " ";
                //        procedureSpeciality = " ";
                //        protocolNo = " ";
                //        procedureDoctor = " ";
                //    }
                //    sb.AppendLine();
                    
                //    System.IO.File.WriteAllText(System.IO.Path.GetFullPath(saveFileDialog.FileName),sb.ToString());
                    
                //    MessageBox.Show("Sorgulama işlemi tamamlanmıştır.Sonuçları kontrol edebilirsiniz.");
                //}
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
            finally
            {
                
            }
#endregion TreatmentDischargeSearchForm_cmdListToExcel_Click
        }

        private void cmdList_Click()
        {
//#region TreatmentDischargeSearchForm_cmdList_Click
//   TreatmentsGrid.Rows.Clear();
//            TTObjectContext context = new TTObjectContext(true);
//            BindingList<TreatmentDischarge> treatmentDischarges;
            
//            string filterExpression = GenerateFilterExpression();
            
//            /*treatmentDischarges*/ = TreatmentDischarge.GetTreatmentDischargeByDate(context,filterExpression);
            
//            string patientNameSurname = string.Empty;
            
//            foreach (TreatmentDischarge item in treatmentDischarges)
//            {
//                patientNameSurname = string.Empty;
                
//                ITTGridRow addedRow = this.TreatmentsGrid.Rows.Add();
                
//                if(item.Episode.Patient != null)
//                {
//                    if(!String.IsNullOrEmpty(item.Episode.Patient.Name))
//                        patientNameSurname += item.Episode.Patient.Name + " ";
                    
//                    if(!String.IsNullOrEmpty(item.Episode.Patient.Surname))
//                        patientNameSurname += item.Episode.Patient.Surname;
                    
//                    addedRow.Cells[PatientNameSurname.Name].Value = patientNameSurname.Trim();
                    
//                    if(item.Episode.Patient.BirthDate != null)
//                        addedRow.Cells[PatientBirthDate.Name].Value = item.Episode.Patient.BirthDate.Value;
                    
//                    if(item.Episode.Patient.UniqueRefNo.HasValue)
//                        addedRow.Cells[PatientUniquerefno.Name].Value = item.Episode.Patient.UniqueRefNo.Value.ToString();

//                    if (item.Episode.Patient.Sex.ADI.ToString() == "KADIN")
//                        addedRow.Cells[PatientGender.Name].Value = "Kadın";
//                    else
//                        addedRow.Cells[PatientGender.Name].Value = "Erkek";
         
//                }
                
//                if(item.Emergency != null)
//                {
//                    if(item.Emergency.Value == true)
//                        addedRow.Cells[Emergency.Name].Value = "Evet";
//                    else
//                        addedRow.Cells[Emergency.Name].Value = "Hayır";
//                }
                
                
//                if(item.WorkListDate != null)
//                {
//                    addedRow.Cells[WorklistDate.Name].Value = item.WorkListDate.Value;
//                }
                
//                if(item.RequestDate != null)
//                {
//                    addedRow.Cells[RequestDate.Name].Value = item.RequestDate.Value;
//                }
                
//                if(item.DischargeDate != null)
//                {
//                    addedRow.Cells[DischargeDate.Name].Value = item.DischargeDate.Value;
//                }
                
//                if(item.DischargeType != null)
//                {
//                    addedRow.Cells[DischargeType.Name].Value = item.DischargeType.Name;
//                }
                
                
//                if(item.ProcedureSpeciality != null)
//                {
//                    addedRow.Cells[ProcedureSpeciality.Name].Value = item.ProcedureSpeciality.Name.Trim();
//                }
                
//                if(item.ProtocolNo.Value != null)
//                {
//                    addedRow.Cells[ProtocolNo.Name].Value = item.ProtocolNo.Value.ToString();
//                }
                
//                if(item.ProcedureDoctor != null)
//                {
//                    addedRow.Cells[ProcedureDoctor.Name].Value = item.ProcedureDoctor.Name.Trim();
//                }
                
//                if(item.Conclusion != null)
//                {
//                    addedRow.Cells[Conclusion.Name].Value = Common.GetTextOfRTFString(item.Conclusion.ToString());
//                }
                
//            }
//#endregion TreatmentDischargeSearchForm_cmdList_Click
        }

        private void cmdExportToExcel_Click()
        {
#region TreatmentDischargeSearchForm_cmdExportToExcel_Click
   try
            {
                if (TreatmentsGrid.Rows.Count == 0)
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
                //    this.TreatmentsGrid.ExportGridToExcel(saveFileDialog.FileName, false);
                //}
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion TreatmentDischargeSearchForm_cmdExportToExcel_Click
        }

#region TreatmentDischargeSearchForm_Methods
        public string GenerateFilterExpression()
        {
            DateTime dateMin;
            DateTime dateMax;
            string filterExpression = string.Empty;
            
            if(txtRequestDateMin.NullableValue.HasValue && txtRequestDateMax.NullableValue.HasValue)
            {
                dateMin = (DateTime)txtRequestDateMin.ControlValue;
                dateMax = (DateTime)txtRequestDateMax.ControlValue;
                filterExpression += " AND REQUESTDATE BETWEEN " + Globals.CreateNQLToDateParameter(dateMin) + " AND " + Globals.CreateNQLToDateParameter(dateMax);
            }
            
            return filterExpression;
        }
        
#endregion TreatmentDischargeSearchForm_Methods
    }
}