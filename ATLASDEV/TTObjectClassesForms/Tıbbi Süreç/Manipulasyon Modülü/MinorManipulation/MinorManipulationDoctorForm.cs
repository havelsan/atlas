
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
    /// Minör Tıbbi Uygulamaları
    /// </summary>
    public partial class MinorManipulationDoctorForm : EpisodeActionForm
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
#region MinorManipulationDoctorForm_PreScript
    base.PreScript();
            
            /*Listeleme sırasında tanımlanan kriterlere göre sarf listesini filtreler. */
            this.SetProcedureDoctorAsCurrentResource();
                       
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["ManipulationTreatmentMaterial"], (ITTGridColumn)this.GridTreatmentMaterials.Columns["Material"]);
#endregion MinorManipulationDoctorForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MinorManipulationDoctorForm_PostScript
    base.PostScript(transDef);

            if (SubEpisode.IsSGKSubEpisode(_MinorManipulation.SubEpisode))
                this.CheckDiagnosisOzelDurums();

            if (_MinorManipulation.PreDiagnosis.Count == 0 && _MinorManipulation.SecDiagnosis.Count == 0)
                throw new Exception("Vakaya, Tanı girilmeden İşleme Devam Edilemez.");
#endregion MinorManipulationDoctorForm_PostScript

            }
                }
}