
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
    /// Nükleer Tıp Rapor Edildi Formu
    /// </summary>
    public partial class NuclearMedicineReportedForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            cmdReport.Click += new TTControlEventDelegate(cmdReport_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdReport.Click -= new TTControlEventDelegate(cmdReport_Click);
            base.UnBindControlEvents();
        }

        private void cmdReport_Click()
        {
            #region NuclearMedicineReportedForm_cmdReport_Click
            //this._NuclearMedicine.ShowViewer();

            //TODO:ShowEdit!
            //string accessionNoStr = this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo.ToString();
            //string patientIdStr = this._NuclearMedicine.Episode.Patient.ID.ToString();
            //TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
            var a = 1;
            #endregion NuclearMedicineReportedForm_cmdReport_Click
        }

        protected override void PreScript()
        {
#region NuclearMedicineReportedForm_PreScript
    base.PreScript();
            if (this._NuclearMedicine.NuclearMedicineTests.Count > 0)
            {
                if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject != null)
                {
                    nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
                }
            }
#endregion NuclearMedicineReportedForm_PreScript

            }
                }
}