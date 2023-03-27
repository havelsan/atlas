
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
    /// Tıbbi Genetik Red Edildi Formu
    /// </summary>
    public partial class GeneticRejectedForm : EpisodeActionForm
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
#region GeneticRejectedForm_PreScript
    base.PreScript();
            if( this._Genetic.GeneticTests.Count > 0 ){
                ((GeneticTest)this._Genetic.GeneticTests[0]).ProcedureObject = (GeneticTestDefinition)this.TestToStudyTTListBox.SelectedObject;
            }
#endregion GeneticRejectedForm_PreScript

            }
                }
}