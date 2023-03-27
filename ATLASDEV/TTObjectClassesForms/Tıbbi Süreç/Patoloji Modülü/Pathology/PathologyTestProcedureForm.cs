
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
    public partial class PathologyTestProcedureForm 
    {
        //TODO ASLI Formlar Revize edilecek
//        override protected void BindControlEvents()
//        {
//            cmdNumberIncrement.Click += new TTControlEventDelegate(cmdNumberIncrement_Click);
//            GridProtocolNumbers.CellValueChanged += new TTGridCellEventDelegate(GridProtocolNumbers_CellValueChanged);
//            GridProtocolNumbers.CellContentClick += new TTGridCellEventDelegate(GridProtocolNumbers_CellContentClick);
//            btnPrintLabel.Click += new TTControlEventDelegate(btnPrintLabel_Click);
//            ttPrintRequestBarcode.Click += new TTControlEventDelegate(ttPrintRequestBarcode_Click);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            cmdNumberIncrement.Click -= new TTControlEventDelegate(cmdNumberIncrement_Click);
//            GridProtocolNumbers.CellValueChanged -= new TTGridCellEventDelegate(GridProtocolNumbers_CellValueChanged);
//            GridProtocolNumbers.CellContentClick -= new TTGridCellEventDelegate(GridProtocolNumbers_CellContentClick);
//            btnPrintLabel.Click -= new TTControlEventDelegate(btnPrintLabel_Click);
//            ttPrintRequestBarcode.Click -= new TTControlEventDelegate(ttPrintRequestBarcode_Click);
//            base.UnBindControlEvents();
//        }

//        private void cmdNumberIncrement_Click()
//        {
//#region PathologyTestProcedureForm_cmdNumberIncrement_Click
//   this.RunMatPrtNoIncrement(this._Pathology, GridProtocolNumbers);
//#endregion PathologyTestProcedureForm_cmdNumberIncrement_Click
//        }

//        private void GridProtocolNumbers_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region PathologyTestProcedureForm_GridProtocolNumbers_CellValueChanged
//   this.RunGridProtocolNumbersCellValueChanged(rowIndex,this._Pathology, GridProtocolNumbers);
//#endregion PathologyTestProcedureForm_GridProtocolNumbers_CellValueChanged
//        }

//        private void GridProtocolNumbers_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region PathologyTestProcedureForm_GridProtocolNumbers_CellContentClick
//   this.RunCellContentClick(rowIndex,this._Pathology, GridProtocolNumbers);
//#endregion PathologyTestProcedureForm_GridProtocolNumbers_CellContentClick
//        }

//        private void btnPrintLabel_Click()
//        {
//#region PathologyTestProcedureForm_btnPrintLabel_Click
//   this._Pathology.PrintLabel();
//#endregion PathologyTestProcedureForm_btnPrintLabel_Click
//        }

//        private void ttPrintRequestBarcode_Click()
//        {
//#region PathologyTestProcedureForm_ttPrintRequestBarcode_Click
//   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
//            TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
//            cache.Add("VALUE", this._Pathology.ObjectID);
//            parameters.Add("TTOBJECTID", cache);
            
         
//            if(this.ttBarcodePreviewCheck.Value == true)
//            {
//                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_PathologyRequestAccBarcode), true, 1, parameters);
//            }
//            else
//            {
//                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_PathologyRequestAccBarcode), false, 1, parameters);
//            }
//#endregion PathologyTestProcedureForm_ttPrintRequestBarcode_Click
//        }

//        protected override void PreScript()
//        {
//#region PathologyTestProcedureForm_PreScript
//    //base.PreScript();
//            this.DropStateButton(Pathology.States.ProcedureTissueProcedure);
//            this.DropStateButton(Pathology.States.ProcedureAdditionalProcedures);
            
//            //if(this._PathologyTest.ResponsibleDoctor != null && this._PathologyTest.ResponsibleDoctor.ObjectID != Common.CurrentResource.ObjectID)
//            //    this.rtfMacroscopy.ReadOnly = true;
            
//            this._Pathology.PathologyRequest.ProcedureDate = Common.RecTime();       
//            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.GridPathologyMaterials.Columns["Material"]);
//            this.SetProcedureDoctorAsCurrentResource();
//#endregion PathologyTestProcedureForm_PreScript

//            }
            
//        protected override void PostScript(TTObjectStateTransitionDef transDef)
//        {
//#region PathologyTestProcedureForm_PostScript
//    base.PostScript(transDef);
//            this._Pathology.CheckUncompletedSpecialProcedures();
//#endregion PathologyTestProcedureForm_PostScript

//            }
                }
}