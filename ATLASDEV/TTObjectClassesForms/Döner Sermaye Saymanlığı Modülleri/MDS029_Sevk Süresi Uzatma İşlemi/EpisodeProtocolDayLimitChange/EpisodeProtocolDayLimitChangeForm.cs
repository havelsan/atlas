
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
    /// Sevk Süresi Uzatma
    /// </summary>
    public partial class EpisodeProtocolDayLimitChangeForm : TTForm
    {
        override protected void BindControlEvents()
        {
            GridEpisodeProtocolDayLimits.CellValueChanged += new TTGridCellEventDelegate(GridEpisodeProtocolDayLimits_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridEpisodeProtocolDayLimits.CellValueChanged -= new TTGridCellEventDelegate(GridEpisodeProtocolDayLimits_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GridEpisodeProtocolDayLimits_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region EpisodeProtocolDayLimitChangeForm_GridEpisodeProtocolDayLimits_CellValueChanged
   if (columnIndex == 3)
            {
                
                DateTime eOpenDate = (DateTime) _EpisodeProtocolDayLimitChange.Episode.OpeningDate;
                DateTime postponeDate = eOpenDate.AddDays(Convert.ToInt32(GridEpisodeProtocolDayLimits.Rows[rowIndex].Cells[columnIndex].Value));
                GridEpisodeProtocolDayLimits.Rows[rowIndex].Cells[4].Value = postponeDate.Date.ToShortDateString();
                
            }
            if (columnIndex == 4)
            {
                
                DateTime eOpenDate = (DateTime) _EpisodeProtocolDayLimitChange.Episode.OpeningDate;
                DateTime postponeDate = (DateTime) GridEpisodeProtocolDayLimits.Rows[rowIndex].Cells[4].Value;
                int nDayLimit = postponeDate.DayOfYear - eOpenDate.DayOfYear;
                GridEpisodeProtocolDayLimits.Rows[rowIndex].Cells[3].Value = nDayLimit;
                
            }
#endregion EpisodeProtocolDayLimitChangeForm_GridEpisodeProtocolDayLimits_CellValueChanged
        }

        protected override void PreScript()
        {
#region EpisodeProtocolDayLimitChangeForm_PreScript
    Episode myEpisode = _EpisodeProtocolDayLimitChange.Episode;
            IList EPList = null; // EpisodeProtocol.GetByEpisode(_EpisodeProtocolDayLimitChange.ObjectContext, myEpisode.ObjectID.ToString());
            this.cmdOK.Visible = false;
            if (_EpisodeProtocolDayLimitChange.CurrentStateDefID == EpisodeProtocolDayLimitChange.States.New)
            {
                _EpisodeProtocolDayLimitChange.EpisodeProtocolDayLimitChangeDetails.Clear();
                
                foreach (EpisodeProtocol ep in EPList)
                {
                    EpisodeProtocolDayLimitChangeDetail epDayLimitDetail = new EpisodeProtocolDayLimitChangeDetail(_EpisodeProtocolDayLimitChange.ObjectContext);
                    epDayLimitDetail.PAYERNAME = ep.Payer.Name.ToString();
                    epDayLimitDetail.PROTOCOLNAME= ep.Protocol.Name.ToString();
                    epDayLimitDetail.DAYLIMIT = (int) ep.DayLimit;
                    epDayLimitDetail.EPOBJECTID = ep.ObjectID.ToString();
                    epDayLimitDetail.PROTOCOLSTATUS = ep.CurrentStateDef.DisplayText.ToString();
                    _EpisodeProtocolDayLimitChange.EpisodeProtocolDayLimitChangeDetails.Add(epDayLimitDetail);
                }
            }
            
            
            for (int i=0; i < this.GridEpisodeProtocolDayLimits.Rows.Count ; i++ )
            {
                if (this.GridEpisodeProtocolDayLimits.Rows[i].Cells[2].Value.ToString() != "AÇIK")
                {
                    this.GridEpisodeProtocolDayLimits.Rows[i].Cells[3].ReadOnly =  true ;
                    this.GridEpisodeProtocolDayLimits.Rows[i].Cells[4].ReadOnly =  true ;
                    this.GridEpisodeProtocolDayLimits.Rows[i].Cells[5].ReadOnly =  true ;
                }
                else
                    this.GridEpisodeProtocolDayLimits.Rows[i].Cells[5].Required =  true ;
            }
#endregion EpisodeProtocolDayLimitChangeForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region EpisodeProtocolDayLimitChangeForm_PostScript
    base.PostScript(transDef);
//            for (int i=0; i < this.GridEpisodeProtocolDayLimits.Rows.Count ; i++ )
//            {
//                if (this.GridEpisodeProtocolDayLimits.Rows[i].Cells[2].Value.ToString() == "AÇIK" && this.GridEpisodeProtocolDayLimits.Rows[i].Cells[5].Value.ToString() == "")
//                    throw new TTException("Uzatma Sebebi boş olamaz !");
//                this.GridEpisodeProtocolDayLimits.Rows[i].Cells[5].Required = true
//            }
#endregion EpisodeProtocolDayLimitChangeForm_PostScript

            }
                }
}