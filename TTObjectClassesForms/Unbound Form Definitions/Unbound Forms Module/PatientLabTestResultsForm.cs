
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
    public partial class PatientLabTestResults : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            LaboratoryResultsGrid.CellContentClick += new TTGridCellEventDelegate(LaboratoryResultsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            LaboratoryResultsGrid.CellContentClick -= new TTGridCellEventDelegate(LaboratoryResultsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void cmdList_Click()
        {
#region PatientLabTestResults_cmdList_Click
   DateTime minDate = Common.RecTime().AddMonths(Convert.ToInt32(cmdMonths.SelectedItem.Value) * -1);
            FillLaboratoryResultsGrid(minDate);
#endregion PatientLabTestResults_cmdList_Click
        }

        private void LaboratoryResultsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PatientLabTestResults_LaboratoryResultsGrid_CellContentClick
   if(LaboratoryResultsGrid.CurrentCell == null)
                return;
            
            if (LaboratoryResultsGrid.CurrentCell.OwningRow.Cells["ObjectID"].Value != null)
            {
                TTObjectContext context = new TTObjectContext(true);
                Guid saID = new Guid(LaboratoryResultsGrid.CurrentCell.OwningRow.Cells["ObjectID"].Value.ToString());
                SubActionProcedure sa = (SubActionProcedure)context.GetObject(saID, typeof(SubActionProcedure));
                LaboratoryProcedure labProcedure = sa as LaboratoryProcedure;
                if (labProcedure != null)
                {
                    GridSubProcedures.Rows.Clear();
                    foreach (LaboratorySubProcedure laboratorySubProcedure in labProcedure.LaboratorySubProcedures)
                    {
                        ITTGridRow gridRow = GridSubProcedures.Rows.Add();

                        if (string.IsNullOrEmpty(laboratorySubProcedure.ProcedureObject.Name) == false)
                            gridRow.Cells[TestName.Name].Value = laboratorySubProcedure.ProcedureObject.Name;

                        if (string.IsNullOrEmpty(laboratorySubProcedure.Result) == false)
                            gridRow.Cells[result.Name].Value = laboratorySubProcedure.Result;

                        if (laboratorySubProcedure.Warning != null)
                            gridRow.Cells[Warning.Name].Value = laboratorySubProcedure.Warning;

                        if (string.IsNullOrEmpty(laboratorySubProcedure.Reference) == false)
                            gridRow.Cells[Reference.Name].Value = laboratorySubProcedure.Reference;

                        if (string.IsNullOrEmpty(laboratorySubProcedure.Unit) == false)
                            gridRow.Cells[unit.Name].Value = laboratorySubProcedure.Unit;

                        if(laboratorySubProcedure.SpecialReference != null)
                            gridRow.Cells[SpecialReference.Name].Value = Common.GetRTFOfTextString(laboratorySubProcedure.SpecialReference.ToString());
                    }
                }
            }
#endregion PatientLabTestResults_LaboratoryResultsGrid_CellContentClick
        }

#region PatientLabTestResults_Methods
        private Patient _currentPatient;
        public Patient CurrentPatient
        {
            get
            {return this._currentPatient;}
            set
            {_currentPatient = value;}
        }
        
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            for(int i = 1; i < 7; i++)
            {
                TTComboBoxItem item = new TTComboBoxItem(i.ToString(), i);
                cmdMonths.Items.Add(item);
            }
            cmdMonths.SelectedIndex = 2;
            DateTime minDate = Common.RecTime().AddMonths(Convert.ToInt32(cmdMonths.SelectedItem.Value) * -1);
            FillLaboratoryResultsGrid(minDate);
        }
        
        public void FillLaboratoryResultsGrid(DateTime minDate)
        {
            LaboratoryResultsGrid.Rows.Clear();
            GridSubProcedures.Rows.Clear();
            TTObjectContext context = new TTObjectContext(true);

            BindingList<SubActionProcedure> testProcedureList;
            testProcedureList = SubActionProcedure.GetTestsByPatient(context, this.CurrentPatient.ObjectID.ToString(), minDate);
            foreach (SubActionProcedure testProcedure in testProcedureList)
            {
                // rapor için parametre
                if (testProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    ITTGridRow gridRow = LaboratoryResultsGrid.Rows.Add();
                    gridRow.Cells["ProcedureDate"].Value = testProcedure.WorkListDate;
                    gridRow.Cells["Procedure"].Value = (testProcedure.ProcedureObject != null ? testProcedure.ProcedureObject.Name : "");
                    if (testProcedure is GeneticTest)
                        gridRow.Cells["ProcedureResult"].Value = ((GeneticTest)testProcedure).Genetic.Report;
                    else if (testProcedure is NuclearMedicineTest)
                        gridRow.Cells["ProcedureResult"].Value = ((NuclearMedicineTest)testProcedure).NuclearMedicine.Report;
                    else if (testProcedure is LaboratoryProcedure)
                        gridRow.Cells["ProcedureResult"].Value = Common.GetRTFOfTextString(((LaboratoryProcedure)testProcedure).Result);
                 //TODO ASLI rapor düzenlenmeli makroskopiler pathologymaterial objectinde 
                    //else if (testProcedure is PathologyTestProcedure) 
                    //{
                    //    string patReports = "Makroskopi Raporu\r\n" + Common.GetTextOfRTFString(((PathologyTestProcedure)testProcedure).Pathology.ReportMacroscopi.ToString()) + "\r\n";
                    //    patReports += "Mikroskopi Raporu\r\n" + Common.GetTextOfRTFString(((PathologyTestProcedure)testProcedure).Pathology.ReportMicroscopi.ToString()) + "\r\n";
                    //    patReports += "Doku İşlemi\r\n" + Common.GetTextOfRTFString(((PathologyTestProcedure)testProcedure).Pathology.ReportTissueProcedure.ToString()) + "\r\n";
                    //    gridRow.Cells["ProcedureResult"].Value = Common.GetRTFOfTextString(patReports);
                    //}
                    else if (testProcedure is RadiologyTest)
                        gridRow.Cells["ProcedureResult"].Value = ((RadiologyTest)testProcedure).Report;
                    gridRow.Cells["ObjectID"].Value = testProcedure.ObjectID;
                }
            }
        }
        
#endregion PatientLabTestResults_Methods
    }
}