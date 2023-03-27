
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
    /// Adli Tıp Raporları
    /// </summary>
    public partial class ForensicMedicalCancelledForm : EpisodeActionForm
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
#region ForensicMedicalCancelledForm_PreScript
    base.PreScript();
            //todo bg
            
            // if (this._ForensicMedicalReport.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.MaterialAdmission)
            //{
            //    this.Report.DisplayText="Materyal Sonuç";
            //    this.labelMaterialSendDate.Visible=true;
            //    this.MaterialSendDate.Visible=true;
            //    this.labelMaterialSender.Visible=true;
            //    this.MaterialSender.Visible=true;
            //}
            //else
            {
                //this.labelMaterialSendDate.Visible=false;
                //this.MaterialSendDate.Visible=false;
                //this.labelMaterialSender.Visible=false;
                //this.MaterialSender.Visible=false;
            }
#endregion ForensicMedicalCancelledForm_PreScript

            }
                }
}