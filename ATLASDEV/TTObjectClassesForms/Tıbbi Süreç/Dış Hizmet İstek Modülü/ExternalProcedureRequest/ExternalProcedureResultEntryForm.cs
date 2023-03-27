
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
    /// Dış XXXXXX Hizmet Sonuç Giriş
    /// </summary>
    public partial class ExternalProcedureResultEntryForm : TTForm
    {
        override protected void BindControlEvents()
        {
            GridEpisodeDiagnosis.CellContentClick += new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridEpisodeDiagnosis.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            base.UnBindControlEvents();
        }

        private void GridEpisodeDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ExternalProcedureResultEntryForm_GridEpisodeDiagnosis_CellContentClick
   //            if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "cokluOzelDurum")
//            {
//                
//                ExternalProcedureCokluOzelDurum epcod = new ExternalProcedureCokluOzelDurum();
//                epcod.ShowEdit(this.FindForm(), this._ExternalProcedureRequest);
//            }
#endregion ExternalProcedureResultEntryForm_GridEpisodeDiagnosis_CellContentClick
        }

        protected override void PreScript()
        {
#region ExternalProcedureResultEntryForm_PreScript
    base.PreScript();
            EpisodeAction.CheckPaid(_ExternalProcedureRequest.ObjectID);
#endregion ExternalProcedureResultEntryForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ExternalProcedureResultEntryForm_PostScript
    base.PostScript(transDef);
#endregion ExternalProcedureResultEntryForm_PostScript

            }
                }
}