
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
    /// Laboratuvar Tetkik İnceleme Formu
    /// </summary>
    public partial class LaboratoryForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            tttabcontrol1.SelectedTabChanged += new TTControlEventDelegate(tttabcontrol1_SelectedTabChanged);
            ttbSampleControl.Click += new TTControlEventDelegate(ttbSampleControl_Click);
            ttgSampleAccept.CellContentClick += new TTGridCellEventDelegate(ttgSampleAccept_CellContentClick);
            ttbProcedure.Click += new TTControlEventDelegate(ttbProcedure_Click);
            ttbGetListSamCont.Click += new TTControlEventDelegate(ttbGetListSamCont_Click);
            ttbSaveProcedure.Click += new TTControlEventDelegate(ttbSaveProcedure_Click);
            ttbGetListProcedure.Click += new TTControlEventDelegate(ttbGetListProcedure_Click);
            ttgProcedure.CellContentClick += new TTGridCellEventDelegate(ttgProcedure_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttabcontrol1.SelectedTabChanged -= new TTControlEventDelegate(tttabcontrol1_SelectedTabChanged);
            ttbSampleControl.Click -= new TTControlEventDelegate(ttbSampleControl_Click);
            ttgSampleAccept.CellContentClick -= new TTGridCellEventDelegate(ttgSampleAccept_CellContentClick);
            ttbProcedure.Click -= new TTControlEventDelegate(ttbProcedure_Click);
            ttbGetListSamCont.Click -= new TTControlEventDelegate(ttbGetListSamCont_Click);
            ttbSaveProcedure.Click -= new TTControlEventDelegate(ttbSaveProcedure_Click);
            ttbGetListProcedure.Click -= new TTControlEventDelegate(ttbGetListProcedure_Click);
            ttgProcedure.CellContentClick -= new TTGridCellEventDelegate(ttgProcedure_CellContentClick);
            base.UnBindControlEvents();
        }

        private void tttabcontrol1_SelectedTabChanged()
        {
#region LaboratoryForm_tttabcontrol1_SelectedTabChanged
   //            
            //            int i = tttabcontrol1.SelectedIndex;
            //            switch(i)
            //            {
            //                case 0:
            //                    this.fillTestInformations(LaboratoryTest.States.SampleAccept);
            //                    break;
            //                case 1:
            //                    this.fillTestInformations(LaboratoryTest.States.SampleControl);
            //                    break;
            //            }
#endregion LaboratoryForm_tttabcontrol1_SelectedTabChanged
        }

        private void ttbSampleControl_Click()
        {
#region LaboratoryForm_ttbSampleControl_Click
   //            toSampleControl();
#endregion LaboratoryForm_ttbSampleControl_Click
        }

        private void ttgSampleAccept_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LaboratoryForm_ttgSampleAccept_CellContentClick
   //showDetail(rowIndex, columnIndex);
#endregion LaboratoryForm_ttgSampleAccept_CellContentClick
        }

        private void ttbProcedure_Click()
        {
#region LaboratoryForm_ttbProcedure_Click
   //            toProcedure();
#endregion LaboratoryForm_ttbProcedure_Click
        }

        private void ttbGetListSamCont_Click()
        {
#region LaboratoryForm_ttbGetListSamCont_Click
   //            fillTestInformations(LaboratoryTest.States.SampleControl);
#endregion LaboratoryForm_ttbGetListSamCont_Click
        }

        private void ttbSaveProcedure_Click()
        {
#region LaboratoryForm_ttbSaveProcedure_Click
   //            LaboratoryTest lt;
            //            
            //            for (int i = 0 ; i < ttgProcedure.Rows.Count -1 ; ++i)
            //            {
            //                
            //                IList tests = LaboratoryTest.GetByObjectID(_Laboratory.ObjectContext,
            //                                                           ttgProcedure.Rows[i].Cells[6].Value.ToString());
            //                lt = (LaboratoryTest) tests[0];
            //                
            //                if(lt.LaboratoryTestResults.Count <= 1)
            //                {
            //                    LaboratoryTestResult res = (LaboratoryTestResult)lt.LaboratoryTestResults[0];
            //                    res.Result = ttgProcedure.Rows[i].Cells[1].Value.ToString();
            //                }
            //                
            //                lt.ObjectContext.Save();
            //            }
#endregion LaboratoryForm_ttbSaveProcedure_Click
        }

        private void ttbGetListProcedure_Click()
        {
#region LaboratoryForm_ttbGetListProcedure_Click
   //            fillTestInformations(LaboratoryTest.States.Procedure);
#endregion LaboratoryForm_ttbGetListProcedure_Click
        }

        private void ttgProcedure_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LaboratoryForm_ttgProcedure_CellContentClick
   //            showDetail(rowIndex, columnIndex);
#endregion LaboratoryForm_ttgProcedure_CellContentClick
        }

        protected override void PreScript()
        {
#region LaboratoryForm_PreScript
    base.PreScript();
           

            //                          ****//this.getTestInformations();
            //                          this.fillTestInformations(LaboratoryTest.States.SampleAccept);
            //                          ****//GetLabTestAndStatus();
#endregion LaboratoryForm_PreScript

            }
            
#region LaboratoryForm_Methods
        //
        //        public  TTObjectContext LabTestContext;
        //        private int currentBarcode = 13;
        //        private List<LaboratoryTestTubeDefinition> tubesRequested;
        //        
        //        
        //        protected override void OnCancelClick()
        //        {
        //            if (LabTestContext != null)
        //                LabTestContext.Dispose();
        //            
        //            base.OnCancelClick();
        //        }
        //        
        //        
        //
        //        private void TTForm_ObjectUpdated(TTObject ttObject)
        //        {
        //         
        //            ttObject.ObjectContext.Save();
        //        }
        //        
        //        
        //        
        //        private void fillTestInformations(Guid currentState)
        //        {
        //            string testObjId = string.Empty;
        //
        //            Guid? g;
        //            LaboratoryTestDefinition ltd = null;
        //            ITTGrid currentGrid = null;
        //            
        //            if(currentState == LaboratoryTest.States.SampleAccept ||
        //               currentState == LaboratoryTest.States.SampleControl)
        //            {
        //                
        //                if(currentState == LaboratoryTest.States.SampleAccept)
        //                    currentGrid = ttgSampleAccept;
        //                else if(currentState == LaboratoryTest.States.SampleControl)
        //                    currentGrid = ttgSampleControl;
        //                
        //                foreach(LaboratoryTest lt in _Laboratory.LaboratoryTests)
        //                {
        //                    g = lt.CurrentStateDefID;
        //                    if(g == currentState)
        //                    {
        //                        ITTGridRow newRow;
        //                        
        //                        newRow = currentGrid.Rows.Add();
        //                        
        //                        ltd = (LaboratoryTestDefinition)lt.MasterTestDef;
        //                        newRow.Cells[0].Value = ltd.Name;
        //                        IList depList = ltd.Departments;
        //                        if(depList.Count > 0)
        //                        {
        //                            LaboratoryGridDepartmentDefinition depDef = (LaboratoryGridDepartmentDefinition)
        //                                depList[0];
        //                            newRow.Cells[1].Value = depDef.Department.Name;
        //                        }
        //                        
        //                        testObjId = lt.ObjectID.ToString();
        //                        newRow.Cells[5].Value = testObjId.ToString();
        //                        
        //                    }
        //                }
        //            }
        //            else if(currentState == LaboratoryTest.States.Procedure)
        //            {
        //                currentGrid = ttgProcedure;
        //                foreach(LaboratoryTest lt in _Laboratory.LaboratoryTests)
        //                {
        //                    g = lt.CurrentStateDefID;
        //                    if(g == currentState)
        //                    {
        //                        ITTGridRow newRow;
        //                        newRow = currentGrid.Rows.Add();
        //                        
        //                        ltd = (LaboratoryTestDefinition)lt.MasterTestDef;
        //                        
        //                        if(lt.LaboratoryTestResults.Count <= 1)
        //                        {
        //                            newRow.Cells[0].Value = ltd.Name;
        //                            newRow.Cells[1].Value = lt.LaboratoryTestResults[0].Result;
        //                            newRow.Cells[2].Value = ltd.TestUnit.TestUnit;
        //                        }
        //                        else
        //                        {
        //                            newRow.Cells[0].Value = ltd.Name;
        //                            newRow.Cells[1].Value = "DETAIL";
        //                            newRow.Cells[2].Value = string.Empty;
        //                            newRow.Cells[3].Value = string.Empty;
        //                            newRow.Cells[4].Value = string.Empty;
        //                        }
        //                        
        //                        testObjId = lt.ObjectID.ToString();
        //                        newRow.Cells[6].Value = testObjId.ToString();
        //                        
        //                    }
        //                }
        //            }
        //            
        //        }
        //        
        //        private void toSampleControl()
        //        {
        //            LaboratoryTest lt = null;
        //            tubesRequested = new List<LaboratoryTestTubeDefinition>();
        //            
        //            foreach(ITTGridRow dgr in ttgSampleAccept.Rows)
        //            {
        //                if (dgr.Cells[4].Value != null && dgr.Cells[4].Value.ToString() == "True")
        //                {
        //                    if(dgr.Cells[5].Value != null && dgr.Cells[5].Value.ToString() != string.Empty)
        //                    {
        //                        IList tests = LaboratoryTest.GetByObjectID(_Laboratory.ObjectContext,
        //                                                                   dgr.Cells[5].Value.ToString());
        //                        lt = (LaboratoryTest) tests[0];
        //                        
        //                        determineSampleTypes(lt.MasterTestDef);
        //                        
        //                        if (lt == null)
        //                            continue;
        //                        
        //                        lt.CurrentStateDefID = LaboratoryTest.States.SampleControl;
        //                        lt.ObjectContext.Save();
        //                    }
        //                }
        //            }
        //            
        //            this.Close();
        //        }
        //        
        //        
        //        private void toProcedure()
        //        {
        //            LaboratoryTest lt = null;
        //            foreach(ITTGridRow dgr in ttgSampleControl.Rows)
        //            {
        //                if(dgr.Cells[5].Value != null && dgr.Cells[5].Value.ToString() != string.Empty &&
        //                   (bool)dgr.Cells[4].Value)
        //                {
        //                    IList tests = LaboratoryTest.GetByObjectID(_Laboratory.ObjectContext,
        //                                                               dgr.Cells[5].Value.ToString());
        //                    lt = (LaboratoryTest) tests[0];
        //                    if (lt == null)
        //                        continue;
        //                    
        //                    lt.CurrentStateDefID = LaboratoryTest.States.Procedure;
        //                    lt.ObjectContext.Save();
        //                }
        //            }
        //            
        //            this.Close();
        //        }
        //        
        //        
        //        protected override void OnOkClick(TTObjectStateTransitionDef transDef)
        //        {
        //            base.OnOkClick(transDef);
        //            /*
        //            LaboratoryTest lt;
        //            
        //            for (int i = 0 ; i < ttgrid2.Rows.Count -1 ; ++i)
        //            {
        //                
        //                IList tests = LaboratoryTest.GetByObjectID(_Laboratory.ObjectContext,
        //                                                           ttgrid2.Rows[i].Cells[5].Value.ToString());
        //                lt = (LaboratoryTest) tests[0];
        //                
        //                if(lt.LaboratoryTestResults.Count <= 1)
        //                {
        //                    LaboratoryTestResult res = (LaboratoryTestResult)lt.LaboratoryTestResults[0];
        //                    res.Result = ttgrid2.Rows[i].Cells[1].Value.ToString();
        //                }
        //                
        //                lt.ObjectContext.Save();
        //            }
        //             */
        //        }
        //        
        //        
        //        
        //        private void showDetail(int rowIndex, int columnIndex)
        //        {
        //            
        //            if(columnIndex == 1)
        //            {
        //                LaboratoryTest test;
        //                LaboratoryTestDefinition td;
        //                
        //                TTObjectContext context = new TTObjectContext(false);
        //                
        //                IList lst = LaboratoryTest.GetByObjectID(context,
        //                                                         ttgProcedure.Rows[rowIndex].Cells[6].Value.ToString());
        //                if (lst.Count > 0)
        //                {
        //                    test = (LaboratoryTest)lst[0];
        //                    
        //                    if(test != null)
        //                    {
        //                        if(test.LaboratoryTestResults.Count > 1)
        //                        {
        //                            LaboratoryResultDetail lrd = new LaboratoryResultDetail();
        //                            TTObject obj = context.GetObject(_Laboratory.ObjectID, _Laboratory.ObjectDef);
        //                            lrd.CurrentTest = ttgProcedure.Rows[rowIndex].Cells[6].Value.ToString();
        //                            lrd.ShowEdit(this, obj);
        //                        }
        //                    }
        //                }
        //            }
        //            
        //        }
        //        
        //        private void determineSampleTypes(LaboratoryTestDefinition def)
        //        {
        //            bool isExists = false;
        //            LaboratoryTestTubeDefinition tube = def.TestTube;
        //            
        //            if(tubesRequested.Count > 0)
        //            {
        //                for(int i = 0 ; i < tubesRequested.Count ; ++i)
        //                {
        //                    if(tubesRequested[i] == tube)
        //                        isExists = true;
        //                    
        //                }
        //                if(!isExists)
        //                    tubesRequested.Add(tube);
        //            }
        //            else
        //                tubesRequested.Add(tube);
        //        }
        //
        
#endregion LaboratoryForm_Methods
    }
}