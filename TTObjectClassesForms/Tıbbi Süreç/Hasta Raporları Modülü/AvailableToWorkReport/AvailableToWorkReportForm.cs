
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
    /// Hizmet Akdiyle Çalışanlar İçin Çalışabilir Kağıdı
    /// </summary>
    public partial class AvailableToWorkReportForm : EpisodeActionForm
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
#region AvailableToWorkReportForm_PreScript
    base.PreScript();                                              
            
            foreach(PatientExamination pe in this._AvailableToWorkReport.Episode.PatientExaminations)
            {
                if(pe.CurrentStateDefID != PatientExamination.States.Cancelled)
                {
                    this.PoliclinicSequenceNo.Text = pe.ProtocolNo.ToString();
                    this.Vdate.Text = pe.RequestDate.ToString();
                }
            }
#endregion AvailableToWorkReportForm_PreScript

            }
                }
}