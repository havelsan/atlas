
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
    /// Ölüm Raporu
    /// </summary>
    public partial class DeathMinutesRecordForm : EpisodeActionForm
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
#region DeathMinutesRecordForm_PreScript
    if (this._DeathMinutesRecord.CurrentStateDefID != DeathMinutesRecord.States.Cancelled)
            {
                base.PreScript();
                this.SetProcedureDoctorAsCurrentResource();
                if(this._DeathMinutesRecord.CurrentStateDefID != null && this._DeathMinutesRecord.CurrentStateDefID.Value.Equals(DeathMinutesRecord.States.ReportEntry))
                {
                    this.ProtocolNo.Visible = false;
                    this.labelProtocolNo.Visible = false;
                }
                /******************bu kysym silinecek. test amaçlı konuldu.******/
                //                if (_DeathMinutesRecord.Episode == null)
                //                {
                //                    TTObjectContext con = _DeathMinutesRecord.ObjectContext;
                //                    IList episodes = con.QueryObjects("Episode");
                //                    if (episodes.Count == 0)
                //                        throw new TTException("Episode bulunamady.");
                //                   _DeathMinutesRecord.Episode = (Episode)episodes[0];
                //                }
                /***************************************************************/
                //CopyToE  Episodedaki Evrak Sayısı, Evrak Tarihi ve  Muayeneye Gönderen Makam Class propertylerine atılır
                if (_DeathMinutesRecord.DocumentDate == null)
                {
                    _DeathMinutesRecord.DocumentDate = _DeathMinutesRecord.Episode.DocumentDate;
                }
                if ( String.IsNullOrEmpty(_DeathMinutesRecord.DocumentNumber) )
                {
                    _DeathMinutesRecord.DocumentNumber = _DeathMinutesRecord.Episode.DocumentNumber;
                }
//                if (_DeathMinutesRecord.SenderChair == null)
//                {
//                    _DeathMinutesRecord.SenderChair = _DeathMinutesRecord.Episode.SenderChair;
//                    
//                }
            }
#endregion DeathMinutesRecordForm_PreScript

            }
                }
}