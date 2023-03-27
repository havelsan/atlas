
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
    /// MSB İlaç Üretim İşlemi - Proses
    /// </summary>
    public partial class MilitaryDrugProductionProcedureProsessForm : MilitaryDrugProductionBaseForm
    {
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MilitaryDrugProductionProcedureProsessForm_PostScript
    if (transDef != null)
            {
                if (transDef.ToStateDefID == MilitaryDrugProductionProcedure.States.Released)
                {
                    foreach (DrugProductionTest drugProductionTest in this._MilitaryDrugProductionProcedure.DrugProductionTests)
                    {
                        if (drugProductionTest.CurrentStateDefID == DrugProductionTest.States.Request || drugProductionTest.CurrentStateDefID == DrugProductionTest.States.QualityControl)
                            throw new TTException(SystemMessage.GetMessage(17));
                    }
                    DrugProductionTest dpt = this._MilitaryDrugProductionProcedure.DrugProductionTests.AddNew();
                    dpt.FromMilitaryDrugProductionProcedure = true;
                    dpt.ReleaseTest = true;
                    dpt.RequestApprovedBy = Common.CurrentUser.UserObject as ResUser;
                    dpt.CurrentStateDefID = DrugProductionTest.States.Request;
                    //                    foreach (ProductAnalysisTestStageDetail productAnalysisTestStageDetail in this._MilitaryDrugProductionProcedure.ObjectContext.QueryObjects(typeof(ProductAnalysisTestStageDetail).Name, "ANALYSISSTAGE = " + (int)AnalysisStageEnum.Released))
                    //                    {
                    //                        DrugProductionTestDetail dptd = dpt.DrugProductionTestDetails.AddNew();
                    //                        dptd.ProductAnalysisTestDefinition = productAnalysisTestStageDetail.ProductAnalysisTestDefinition;
//
                    //                    }
                    dpt.Update();
                    dpt.CurrentStateDefID = DrugProductionTest.States.QualityControl;
                }
            }
#endregion MilitaryDrugProductionProcedureProsessForm_PostScript

            }
            
#region MilitaryDrugProductionProcedureProsessForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            foreach (DrugProductionTest drugProductionTest in this._MilitaryDrugProductionProcedure.DrugProductionTests)
            {
                if (drugProductionTest.FromMilitaryDrugProductionProcedure)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> newParameterItem = new TTReportTool.PropertyCache<object>();
                    newParameterItem.Add("Value", drugProductionTest.ObjectID.ToString(), "T", "TTOBJECTID");
                    parameters.Add("TTOBJECTID", newParameterItem);

                    if(Convert.ToBoolean(drugProductionTest.ReleaseTest.Value) == false)
                    {
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_OnAnalizKontrolFormu), true, 0, parameters);
                    }
                    else
                    {
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_FizikselAnalizKontrolFormu), true, 0, parameters);
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SerbestBirakmaRaporu), true, 0, parameters);
                    }
                    
                }
                
                
            }
        }
        
#endregion MilitaryDrugProductionProcedureProsessForm_Methods
    }
}