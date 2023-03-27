
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
    /// Hemşirelik Uygulamaları - Düşme Riski Tanımları
    /// </summary>
    public partial class FallingDownRiskForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.FallingDownRiskDefinition _FallingDownRiskDefinition
        {
            get { return (TTObjectClasses.FallingDownRiskDefinition)_ttObject; }
        }

        protected ITTLabel labelType;
        protected ITTEnumComboBox Type;
        protected ITTLabel labelScore;
        protected ITTTextBox Score;
        protected ITTTextBox NAME;
        protected ITTLabel labelNAME;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelType = (ITTLabel)AddControl(new Guid("bfdab345-9ba0-46b3-acff-e1b605f30239"));
            Type = (ITTEnumComboBox)AddControl(new Guid("61cf4679-a68c-42cc-a1c7-3c70dd56c0f6"));
            labelScore = (ITTLabel)AddControl(new Guid("33775e9b-6d20-4348-b7c4-59620c13a1e7"));
            Score = (ITTTextBox)AddControl(new Guid("083931ca-b47b-461f-9e6a-54ddac54121c"));
            NAME = (ITTTextBox)AddControl(new Guid("2d232eee-d67d-45cd-aa99-5edb52a5e7c2"));
            labelNAME = (ITTLabel)AddControl(new Guid("a0b71973-a40f-49c7-ac63-6753b2ecf7f0"));
            Aktif = (ITTCheckBox)AddControl(new Guid("5129b522-543f-4217-b206-235966adc590"));
            base.InitializeControls();
        }

        public FallingDownRiskForm() : base("FALLINGDOWNRISKDEFINITION", "FallingDownRiskForm")
        {
        }

        protected FallingDownRiskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}