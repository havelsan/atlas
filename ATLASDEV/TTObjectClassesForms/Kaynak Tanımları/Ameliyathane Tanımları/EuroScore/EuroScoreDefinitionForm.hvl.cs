
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
    /// Euro Score Tanımlama
    /// </summary>
    public partial class EuroScoreDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Euro Score Soru Tanımları
    /// </summary>
        protected TTObjectClasses.EuroScore _EuroScore
        {
            get { return (TTObjectClasses.EuroScore)_ttObject; }
        }

        protected ITTLabel labelSelectionCaption;
        protected ITTTextBox SelectionCaption;
        protected ITTTextBox LogisticEuroScore;
        protected ITTTextBox EuroScore;
        protected ITTTextBox ScreenOrder;
        protected ITTTextBox EuroScoreQuestion;
        protected ITTLabel labelLogisticEuroScore;
        protected ITTLabel labelEuroScore;
        protected ITTLabel labelScreenOrder;
        protected ITTLabel labelEuroScoreQuestion;
        override protected void InitializeControls()
        {
            labelSelectionCaption = (ITTLabel)AddControl(new Guid("02ddeb11-b92f-4042-8b02-ab7eecc98fb8"));
            SelectionCaption = (ITTTextBox)AddControl(new Guid("ff03b77b-3803-469a-ad78-ef7c76d33325"));
            LogisticEuroScore = (ITTTextBox)AddControl(new Guid("4a3b56cd-1a38-426e-8ce6-032cb0f4b536"));
            EuroScore = (ITTTextBox)AddControl(new Guid("387dbbdf-ee3e-4e76-84f5-67348498cbaf"));
            ScreenOrder = (ITTTextBox)AddControl(new Guid("67699104-8595-4a55-a9c1-5e196ffb4a93"));
            EuroScoreQuestion = (ITTTextBox)AddControl(new Guid("6aa116e9-15c6-41ab-a0da-58ac465a848b"));
            labelLogisticEuroScore = (ITTLabel)AddControl(new Guid("20a376a5-51d0-40cc-9387-1c90c04a496f"));
            labelEuroScore = (ITTLabel)AddControl(new Guid("8ac41bb5-82cb-4b05-885b-43595e5d764f"));
            labelScreenOrder = (ITTLabel)AddControl(new Guid("13c9ceb9-7150-4ea1-adc5-b29857b0a320"));
            labelEuroScoreQuestion = (ITTLabel)AddControl(new Guid("2f6fe446-5fd3-4979-8411-78e29dca4350"));
            base.InitializeControls();
        }

        public EuroScoreDefinitionForm() : base("EUROSCORE", "EuroScoreDefinitionForm")
        {
        }

        protected EuroScoreDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}