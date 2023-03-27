
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
    /// Otopsi Raporu
    /// </summary>
    public partial class AutopsyReportForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region AutopsyReportForm_PreScript
    base.PreScript();
            
            if(this._AutopsyReport.CurrentStateDefID != null && this._AutopsyReport.CurrentStateDefID.Value.Equals(AutopsyReport.States.ReportEntry))
            {
                this.ProtocolNo.Visible = false;
                this.labelProtocolNo.Visible = false;
            }
            
            /******************bu kysym silinecek. test amaçly konuldu.******/
            //            if (_AutopsyReport.Episode == null)
            //            {
            //                TTObjectContext con = _AutopsyReport.ObjectContext;
            //                IList episodes = con.QueryObjects("Episode");
            //                if (episodes.Count == 0)
            //                    throw new TTException("Episode bulunamady.");
            //                _AutopsyReport.Episode = (Episode)episodes[0];
            //            }
            /***************************************************************/
            //CopyToE  Episodedaki Evrak Sayısı, Evrak Tarihi ve  Muayeneye Gönderen Makam Class propertylerine atılır
            if (_AutopsyReport.DocumentDate == null)
            {
                _AutopsyReport.DocumentDate = _AutopsyReport.Episode.DocumentDate;
            }
            if ( String.IsNullOrEmpty(_AutopsyReport.DocumentNumber))
            {
                _AutopsyReport.DocumentNumber = _AutopsyReport.Episode.DocumentNumber;
            }
//            if (_AutopsyReport.SenderChair == null)
//            {
//                _AutopsyReport.SenderChair = _AutopsyReport.Episode.SenderChair;
//                
//            }
            this.SetProcedureDoctorAsCurrentResource();
#endregion AutopsyReportForm_PreScript

            }
                }
}