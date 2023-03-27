
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
    /// Doğum Raporları Giriş
    /// </summary>
    public partial class BirthReportRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnAddBirthReport.Click += new TTControlEventDelegate(btnAddBirthReport_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnAddBirthReport.Click -= new TTControlEventDelegate(btnAddBirthReport_Click);
            base.UnBindControlEvents();
        }

        private void btnAddBirthReport_Click()
        {
#region BirthReportRequestForm_btnAddBirthReport_Click
   if (CreateNewBirthReport())
            {
                this.cmdCancel.Enabled = false;
            }
#endregion BirthReportRequestForm_btnAddBirthReport_Click
        }

        protected override void PreScript()
        {
#region BirthReportRequestForm_PreScript
    base.PreScript();
          //  DropStateButton(BirthReportRequest.States.Complete);
#endregion BirthReportRequestForm_PreScript

            }
            
#region BirthReportRequestForm_Methods
        /// <summary>
        /// Yeni Doğum Raporu isteği başlatır.
        /// </summary>
        
#endregion BirthReportRequestForm_Methods

#region BirthReportRequestForm_ClientSideMethods
        public bool CreateNewBirthReport()
        {

            //TODO:ShowEdit!
            //BirthReport birthReport;
            ////            TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._BirthReportRequest.ObjectContext.BeginSavePoint();
            //try
            //{
            //    birthReport = new BirthReport(this._BirthReportRequest.ObjectContext, this._BirthReportRequest);
            //    TTForm frm = TTForm.GetEditForm(birthReport);
            //    if (frm.ShowEdit(this.FindForm(), birthReport) == DialogResult.OK)
            //    {
            //        this._BirthReportRequest.ObjectContext.Save();
            //        Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            //        TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
            //        cache.Add("VALUE", birthReport.ObjectID.ToString());
            //        parameters.Add("TTOBJECTID", cache);
            //        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_BirthReportReport), true, 1, parameters);
            //    }
            //    else
            //    {
            //        this._BirthReportRequest.ObjectContext.RollbackSavePoint(savePointGuid);
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this._BirthReportRequest.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //    return false;
            //}
            return true;
        }
        
#endregion BirthReportRequestForm_ClientSideMethods
    }
}