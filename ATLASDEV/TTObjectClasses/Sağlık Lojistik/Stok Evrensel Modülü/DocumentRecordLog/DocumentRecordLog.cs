
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public  partial class DocumentRecordLog : TTObject
    {
        public partial class CensusReportNQL_DocumentRecLogByObjectDef_Class : TTReportNqlObject 
        {
        }

        public partial class GetDocumentRecordLogReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class CensusReportNQL_DocumentRecLogAllCensusFixes_Class : TTReportNqlObject 
        {
        }

        public partial class CensusReportNQL_DocumentRecLogAllDeleteRecords_Class : TTReportNqlObject 
        {
        }

        public partial class SearchDocumentRecordLogRQ_Class : TTReportNqlObject 
        {
        }

        public partial class CensusReportNQL_DocumentRecLogAllCensusFixesInOut_Class : TTReportNqlObject 
        {
        }

        public partial class CensusReportNQL_DocRecLogByInOutIncludeCancels_Class : TTReportNqlObject 
        {
        }

#region Methods
        public void PrintStateReports()
        {
//            foreach (TTObjectStateReportDef objectStateReportDef in CurrentStateDef.ReportDefs)
//            {
//                TTObjectReportDef objectReportDef = (TTObjectReportDef)objectStateReportDef;
//                if (this.DocumentTransactionType == DocumentTransactionTypeEnum.In)
//                    if (objectReportDef.ReportDef.CodeName.Equals(typeof(TTReportClasses.I_ChattelDocumentOutDetailReport).Name))
//                        continue;
//                if (this.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
//                    if (objectReportDef.ReportDef.CodeName.Equals(typeof(TTReportClasses.I_ChattelDocumentInDetailReport).Name))
//                        continue;
//
//
//                bool printReport;
//
//                if (objectReportDef.AskUser)
//                {
//                    TTRepo rtTool.AskUserForm askUserForm = new TTRepo rtTool.AskUserForm(ref objectReportDef);
//                    askUse rForm.ShowDialog(parent);
//                    if (askUserForm.DialogResult == System.Windows.Forms.DialogResult.OK)
//                        printReport = true;
//                    else
//                        printReport = false;
//                }
//                else
//                {
//                    printReport = true;
//                }
//
//                if (printReport)
//                {
//
//                    Dicti onary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
//                    TTRe por tTool.PropertyCache<object> newParameterItem = new TTRe portTool.PropertyCache<object>();
//                    newPar ameterItem.Add("Value", ObjectID.ToString(), "T", "TTOBJECTID");
//                    para meters.Add("TTOBJECTID", newParameterItem);
//
//                    Type reportType = objectReportDef.ReportDef.ModuleDef.AssemblyDef.Assembly.GetType("TTReportClasses.I_" + objectReportDef.ReportDef.CodeName);
//                    TTRepo rt Tool.TTRe port.PrintR eport(parent, reportType, objectReportDef.IsDisplay, objectReportDef.DuplicateCount, parameters);
//                }
//            }

        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockAction).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == DocumentRecordLog.States.Completed && toState == DocumentRecordLog.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : New   To State : Completed
            #region PreTransition_New2Completed
            this.MKYSStatus = MKYSControlEnum.Cancelled;
            #endregion PreTransition_New2Completed
        }
    }
}