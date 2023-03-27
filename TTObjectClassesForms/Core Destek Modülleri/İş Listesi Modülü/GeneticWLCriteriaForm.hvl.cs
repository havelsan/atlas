
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Tıbbi Genetik İş Listesi
    /// </summary>
    public partial class GeneticWLCriteriaForm : EpisodeActionWLCriteriaForm
    {
        protected ITTTextBox GeneticSampleNo;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            GeneticSampleNo = (ITTTextBox)AddControl(new Guid("1ea2ecb7-6746-4c7c-8452-bbba4015a20d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3ceed75f-2dc0-4aaf-a0b9-ae9ba957ec36"));
            base.InitializeControls();
        }

        public GeneticWLCriteriaForm() : base("GeneticWLCriteriaForm")
        {
        }

        protected GeneticWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}