
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
    /// MSB İlaç Üretim İşlemi
    /// </summary>
    public partial class MilitaryDrugProductionBaseForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            ProducedMaterial.SelectedObjectChanged += new TTControlEventDelegate(ProducedMaterial_SelectedObjectChanged);
            TestRequest.Click += new TTControlEventDelegate(TestRequest_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ProducedMaterial.SelectedObjectChanged -= new TTControlEventDelegate(ProducedMaterial_SelectedObjectChanged);
            TestRequest.Click -= new TTControlEventDelegate(TestRequest_Click);
            base.UnBindControlEvents();
        }

        private void ProducedMaterial_SelectedObjectChanged()
        {
#region MilitaryDrugProductionBaseForm_ProducedMaterial_SelectedObjectChanged
   if (this.ProducedMaterial.SelectedObject != null)
            {
                this.ProductAnnualReqDet.ReadOnly = false;
            }
#endregion MilitaryDrugProductionBaseForm_ProducedMaterial_SelectedObjectChanged
        }

        private void TestRequest_Click()
        {
#region MilitaryDrugProductionBaseForm_TestRequest_Click
   DrugProductionTest dpt = this._MilitaryDrugProductionProcedure.DrugProductionTests.AddNew();
            dpt.FromMilitaryDrugProductionProcedure = true;
            dpt.CurrentStateDefID = DrugProductionTest.States.Request;
            foreach(ProductTreeAnalyseTest ptat in _MilitaryDrugProductionProcedure.ProducedMaterial.ProductTreeAnalyseTests)
            {
                DrugProductionTestDetail dptd = dpt.DrugProductionTestDetails.AddNew();
                dptd.ProductAnalysisTestDefinition = ptat.ProductAnalysisTestDefinition;
                dptd.RequestedBy = (ResUser)Common.CurrentUser.UserObject;
            }
            
            DPT_RequestForm dpt_RequestForm = new DPT_RequestForm();
            DialogResult dialogResult = dpt_RequestForm.ShowEdit(this, dpt);
            if (dialogResult == DialogResult.Cancel)
                ((ITTObject)dpt).Delete();
#endregion MilitaryDrugProductionBaseForm_TestRequest_Click
        }

        protected override void PreScript()
        {
#region MilitaryDrugProductionBaseForm_PreScript
    int i = 0;
            foreach(DrugProductionTest dpt in _MilitaryDrugProductionProcedure.DrugProductionTests)
            {
                if(dpt.CurrentStateDefID == DrugProductionTest.States.Completed)
                    i++;
            }
            
            this.labelRepeatCount.Text = i.ToString();
#endregion MilitaryDrugProductionBaseForm_PreScript

            }
            
#region MilitaryDrugProductionBaseForm_Methods
        protected void GetCurrentStageTest(ITTGrid analysisDetails, ProductTreeDefinition productTreeDefinition, TTObjectStateDef objectStateDef)
        {
            if (this._MilitaryDrugProductionProcedure.MilitaryDrugProductionProcedureAnalysisDetails.Count > 0 && this._MilitaryDrugProductionProcedure.MilitaryDrugProductionProcedureAnalysisDetails.Select("ENTEREDSTATEDEFID = " + ConnectionManager.GuidToString(objectStateDef.StateDefID)).Count > 0)
            {
                IList militaryDrugProductionProcedureAnalysisDetails = this._MilitaryDrugProductionProcedure.MilitaryDrugProductionProcedureAnalysisDetails.Select("ENTEREDSTATEDEFID = " + ConnectionManager.GuidToString(objectStateDef.StateDefID));
                foreach (MilitaryDrugProductionProcedureAnalysisDetail militaryDrugProductionProcedureAnalysisDetail in militaryDrugProductionProcedureAnalysisDetails)
                {
                    ITTGridRow row = analysisDetails.Rows.Add();
                    row.Cells["UnBoundTestDefinition"].Value = militaryDrugProductionProcedureAnalysisDetail.ProductAnalysisTestDefinition.ObjectID;
                    row.Cells["UnBoundTestResult"].Value = militaryDrugProductionProcedureAnalysisDetail.TestResult;
                    row.Cells["UnBoundTestPersonnel"].Value = militaryDrugProductionProcedureAnalysisDetail.TestPersonnel.ObjectID;
                }
            }
//            else
//            {
//                IList productAnalysisTestDetails = productTreeDefinition.ProductionService.ProductAnalysisTestDetails.Select("");
//                if (productAnalysisTestDetails.Count > 0)
//                {
//                    TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(AnalysisStageEnum).Name];
//                    foreach (ProductAnalysisTestDetail productAnalysisTestDetail in productAnalysisTestDetails)
//                    {
//                        EnumValueDef enumValueDef = dataType.EnumValueDefs[objectStateDef.Name];
//
//                        IList tests = productAnalysisTestDetail.ProductAnalysisTestDefinition.AnalysisTestStageDetails.Select("ANALYSISSTAGE = " + enumValueDef.Value);
//                        if (tests != null && tests.Count > 0)
//                        {
//                            ProductAnalysisTestStageDetail productAnalysisTestStageDetail = (ProductAnalysisTestStageDetail)tests[0];
//                            ITTGridRow row = analysisDetails.Rows.Add();
//                            row.Cells["UnBoundTestDefinition"].Value = productAnalysisTestStageDetail.ProductAnalysisTestDefinition.ObjectID;
//                            row.Cells["UnBoundTestPersonnel"].Value = Common.CurrentResource.ObjectID;
//                        }
//                    }
//                }
//            }

        }

        protected void SaveCurrentStageTest(ITTGrid analysisDetails, TTObjectStateDef objectStateDef)
        {
            if (this._MilitaryDrugProductionProcedure.MilitaryDrugProductionProcedureAnalysisDetails.Count > 0 && this._MilitaryDrugProductionProcedure.MilitaryDrugProductionProcedureAnalysisDetails.Select("ENTEREDSTATEDEFID = " + ConnectionManager.GuidToString(objectStateDef.StateDefID)).Count > 0)
            {
                IList militaryDrugProductionProcedureAnalysisDetails = this._MilitaryDrugProductionProcedure.MilitaryDrugProductionProcedureAnalysisDetails.Select("ENTEREDSTATEDEFID = " + ConnectionManager.GuidToString(objectStateDef.StateDefID));
                foreach (MilitaryDrugProductionProcedureAnalysisDetail militaryDrugProductionProcedureAnalysisDetail in militaryDrugProductionProcedureAnalysisDetails)
                    ((ITTObject)militaryDrugProductionProcedureAnalysisDetail).Delete();
            }

            bool requiredErr = false;
            foreach (ITTGridRow row in analysisDetails.Rows)
            {
                if (row.Cells["UnBoundTestResult"].Value == null)
                {
                    requiredErr = true;
                    break;
                }
            }

            if (requiredErr)
                throw new TTException("Test Sonucu boş olamaz.");

            foreach (ITTGridRow row in analysisDetails.Rows)
            {
                MilitaryDrugProductionProcedureAnalysisDetail analysisDetail = this._MilitaryDrugProductionProcedure.MilitaryDrugProductionProcedureAnalysisDetails.AddNew();
                if (row.Cells["UnBoundTestDefinition"].Value != null)
                {
                    ProductAnalysisTestDefinition testDefinition = this._MilitaryDrugProductionProcedure.ObjectContext.GetObject((Guid)row.Cells["UnBoundTestDefinition"].Value, typeof(ProductAnalysisTestDefinition)) as ProductAnalysisTestDefinition;
                    if (testDefinition != null)
                        analysisDetail.ProductAnalysisTestDefinition = testDefinition;
                }

                if (row.Cells["UnBoundTestPersonnel"].Value != null)
                {
                    ResUser resUser = this._MilitaryDrugProductionProcedure.ObjectContext.GetObject((Guid)row.Cells["UnBoundTestPersonnel"].Value, typeof(ResUser)) as ResUser;
                    if (resUser != null)
                        analysisDetail.TestPersonnel = resUser;
                }
                analysisDetail.TestResult = row.Cells["UnBoundTestResult"].Value.ToString();
                analysisDetail.EnteredStateDefID = objectStateDef.StateDefID;
            }
        }
        
#endregion MilitaryDrugProductionBaseForm_Methods
    }
}