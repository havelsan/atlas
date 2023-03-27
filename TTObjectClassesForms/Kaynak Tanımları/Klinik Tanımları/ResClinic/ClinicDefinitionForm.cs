
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
    /// Klinik Tanımı
    /// </summary>
    public partial class ClinicDefinitionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            PercentageOfEmptyBedFor112.TextChanged += new TTControlEventDelegate(PercentageOfEmptyBedFor112_TextChanged);
            IsEmergencyClinic.CheckedChanged += new TTControlEventDelegate(IsEmergencyClinic_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PercentageOfEmptyBedFor112.TextChanged -= new TTControlEventDelegate(PercentageOfEmptyBedFor112_TextChanged);
            IsEmergencyClinic.CheckedChanged -= new TTControlEventDelegate(IsEmergencyClinic_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void PercentageOfEmptyBedFor112_TextChanged()
        {
            #region ClinicDefinitionForm_PercentageOfEmptyBedFor112_TextChanged
            string PercentageOfEmptyBedFor112Text = PercentageOfEmptyBedFor112.Text;
            if (this.PercentageOfEmptyBedFor112.Text.Length > 3)
            {
                this.PercentageOfEmptyBedFor112.Text = PercentageOfEmptyBedFor112Text[0].ToString();
                this.PercentageOfEmptyBedFor112.Text = this.PercentageOfEmptyBedFor112.Text.ToString() + PercentageOfEmptyBedFor112Text[1].ToString();
                this.PercentageOfEmptyBedFor112.Text = this.PercentageOfEmptyBedFor112.Text.ToString() + PercentageOfEmptyBedFor112Text[2].ToString();
                if (Convert.ToInt32(this.PercentageOfEmptyBedFor112.Text) > 100)
                {
                    this.PercentageOfEmptyBedFor112.Text = PercentageOfEmptyBedFor112Text[0].ToString();
                    this.PercentageOfEmptyBedFor112.Text = this.PercentageOfEmptyBedFor112.Text.ToString() + PercentageOfEmptyBedFor112Text[1].ToString();
                }
            }
            #endregion ClinicDefinitionForm_PercentageOfEmptyBedFor112_TextChanged
        }

        private void IsEmergencyClinic_CheckedChanged()
        {
            #region ClinicDefinitionForm_IsEmergencyClinic_CheckedChanged
            if (_ResClinic.IsEmergencyClinic == true)
            {
                this.IsEtiquettePrinted.Visible = true;
                this.labelEtiquetteCount.Visible = true;
                this.EtiquetteCount.Visible = true;
            }
            else
            {
                this.IsEtiquettePrinted.Visible = false;
                this.labelEtiquetteCount.Visible = false;
                this.EtiquetteCount.Visible = false;

                this.IsEtiquettePrinted.Value = false;
                this.EtiquetteCount.Text = null;
            }
            #endregion ClinicDefinitionForm_IsEmergencyClinic_CheckedChanged
        }

        protected override void PreScript()
        {
            #region ClinicDefinitionForm_PreScript
            base.PreScript();
            if (_ResClinic.IsToBeConsultation != false)
                _ResClinic.IsToBeConsultation = true;

            if (_ResClinic.IsEmergencyClinic == true)
            {
                this.IsEtiquettePrinted.Visible = true;
                this.labelEtiquetteCount.Visible = true;
                this.EtiquetteCount.Visible = true;
            }
            else
            {
                this.IsEtiquettePrinted.Visible = false;
                this.labelEtiquetteCount.Visible = false;
                this.EtiquetteCount.Visible = false;
            }
            #endregion ClinicDefinitionForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region ClinicDefinitionForm_PostScript
            base.PostScript(transDef);


            if (this._ResClinic.IsEmergencyClinic == true)
            {
                this._ResClinic.EnabledType = ResourceEnableType.BothInpatientAndOutPatient;//Acil Kliniklerde hem yatan hem ayaktan hasta bakılır.
            }
            else
            {
                this._ResClinic.EnabledType = ResourceEnableType.InPatient;
            }
            if (this._ResClinic.Hospital == null)
            {
                Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
                ResHospital hospital = (ResHospital)this._ResClinic.ObjectContext.GetObject(hospID, typeof(ResHospital));
                this._ResClinic.Hospital = hospital;
            }
            #endregion ClinicDefinitionForm_PostScript

        }

        #region ClinicDefinitionForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            ResWard.SendResWardToDietRationSystem(this._ResClinic);

            #endregion ClinicDefinitionForm_Methods
        }
    }
}