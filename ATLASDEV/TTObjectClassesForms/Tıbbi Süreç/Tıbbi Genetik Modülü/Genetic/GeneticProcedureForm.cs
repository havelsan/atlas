
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
    /// Tıbbi Genetik İşlemde Formu
    /// </summary>
    public partial class GeneticProcedureForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            cmdPrintBarcode.Click += new TTControlEventDelegate(cmdPrintBarcode_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdPrintBarcode.Click -= new TTControlEventDelegate(cmdPrintBarcode_Click);
            base.UnBindControlEvents();
        }

        private void cmdPrintBarcode_Click()
        {
            /*
#region GeneticProcedureForm_cmdPrintBarcode_Click
            Genetic.PrintGeneticBarcode(this._Genetic);
#endregion GeneticProcedureForm_cmdPrintBarcode_Click */
        }

        protected override void PreScript()
        {
#region GeneticProcedureForm_PreScript
    base.PreScript();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.GridGeneticMaterials.Columns["Material"]);
            if( this._Genetic.GeneticTests.Count > 0 ){
                this.TestToStudyTTListBox.SelectedObject= (GeneticTestDefinition)((GeneticTest)this._Genetic.GeneticTests[0]).ProcedureObject ;
                //if(this.ReportRTF.Text.IndexOf("Bu rapor hasta")== -1)
                //    this.ReportRTF.Text = this.ReportRTF.Text + "\r\n\r\n Not: Bu çıktı içeriği ön çalışma olup, rapor özelliği taşımamaktadır."; 
            }
#endregion GeneticProcedureForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region GeneticProcedureForm_PostScript
    base.PostScript(transDef);
            
            ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            this._Genetic.Technician = currentResUser;
#endregion GeneticProcedureForm_PostScript

            }
                }
}