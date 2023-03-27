
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
    /// Tıbbi Genetik Tamamlandı Formu
    /// </summary>
    public partial class GeneticCompletedForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            TestToStudyTTListBox.SelectedObjectChanged += new TTControlEventDelegate(TestToStudyTTListBox_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            TestToStudyTTListBox.SelectedObjectChanged -= new TTControlEventDelegate(TestToStudyTTListBox_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void TestToStudyTTListBox_SelectedObjectChanged()
        {
#region GeneticCompletedForm_TestToStudyTTListBox_SelectedObjectChanged
   if( this._Genetic.GeneticTests.Count > 0 ){
                GeneticTest gt = new GeneticTest(_Genetic.ObjectContext);
                gt.ProcedureObject = (GeneticTestDefinition)this.TestToStudyTTListBox.SelectedObject;
                this._Genetic.GeneticTests.Add(gt);
            }
#endregion GeneticCompletedForm_TestToStudyTTListBox_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region GeneticCompletedForm_PreScript
    base.PreScript();
            if( this._Genetic.GeneticTests.Count > 0 ){
                this.TestToStudyTTListBox.SelectedObject = (GeneticTestDefinition)((GeneticTest)this._Genetic.GeneticTests[0]).ProcedureObject ;
            }
            foreach(ITTTabPage tabPage in TabTextInfos.TabPages)
            {
                if(tabPage.Visible == false)
                    TabTextInfos.HideTabPage(tabPage);
            }
#endregion GeneticCompletedForm_PreScript

            }
                }
}