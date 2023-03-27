
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
    /// Epizotta Miktar Kuralı Tanımlama
    /// </summary>
    public partial class EpisodeAmountRuleDefinitionForm : RuleBaseDefinitionForm
    {
    /// <summary>
    /// Epizotta Miktar Kuralı
    /// </summary>
        protected TTObjectClasses.EpisodeAmountRule _EpisodeAmountRule
        {
            get { return (TTObjectClasses.EpisodeAmountRule)_ttObject; }
        }

        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        override protected void InitializeControls()
        {
            labelAmount = (ITTLabel)AddControl(new Guid("35f94de4-4d44-4bd6-a4f9-290b9cc6b219"));
            Amount = (ITTTextBox)AddControl(new Guid("cf0dd516-9635-4a82-aab5-495cff73e2d9"));
            base.InitializeControls();
        }

        public EpisodeAmountRuleDefinitionForm() : base("EPISODEAMOUNTRULE", "EpisodeAmountRuleDefinitionForm")
        {
        }

        protected EpisodeAmountRuleDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}