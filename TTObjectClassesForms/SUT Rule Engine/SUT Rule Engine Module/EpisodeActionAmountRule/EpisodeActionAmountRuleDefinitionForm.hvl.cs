
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
    /// Epizot İşleminde Miktar Kuralı Tanımlama
    /// </summary>
    public partial class EpisodeActionAmountRuleDefinitionForm : RuleBaseDefinitionForm
    {
    /// <summary>
    /// Epizot İşleminde Miktar Kuralı
    /// </summary>
        protected TTObjectClasses.EpisodeActionAmountRule _EpisodeActionAmountRule
        {
            get { return (TTObjectClasses.EpisodeActionAmountRule)_ttObject; }
        }

        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        override protected void InitializeControls()
        {
            labelAmount = (ITTLabel)AddControl(new Guid("e7549c38-d40e-4d14-a98a-329a6b510262"));
            Amount = (ITTTextBox)AddControl(new Guid("8f550b58-6428-465c-af73-e8cd5d2f4fa0"));
            base.InitializeControls();
        }

        public EpisodeActionAmountRuleDefinitionForm() : base("EPISODEACTIONAMOUNTRULE", "EpisodeActionAmountRuleDefinitionForm")
        {
        }

        protected EpisodeActionAmountRuleDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}