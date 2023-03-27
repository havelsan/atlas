
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
    /// Hemşirelik Uygulamaları - Waterlow Bası Riski Değerlendirme 
    /// </summary>
    public partial class WaterlowRiskDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.WaterlowRiskDefinition _WaterlowRiskDefinition
        {
            get { return (TTObjectClasses.WaterlowRiskDefinition)_ttObject; }
        }

        protected ITTLabel labelWaterlowType;
        protected ITTEnumComboBox WaterlowType;
        protected ITTLabel labelScore;
        protected ITTTextBox Score;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelWaterlowType = (ITTLabel)AddControl(new Guid("45352348-b71f-4959-a1e6-8fbb124cf8d9"));
            WaterlowType = (ITTEnumComboBox)AddControl(new Guid("7468e7a0-5f10-4fbf-b9d3-c0061b7a030e"));
            labelScore = (ITTLabel)AddControl(new Guid("13e8f778-3da4-4427-88b0-459390984f5b"));
            Score = (ITTTextBox)AddControl(new Guid("49d6964f-de24-4fb4-8ee1-926f9042caed"));
            labelName = (ITTLabel)AddControl(new Guid("012b8acc-fc66-4b36-b851-dc1180f0cf1f"));
            Name = (ITTTextBox)AddControl(new Guid("c6a83e29-c6e7-4b4b-95b3-945ff792951a"));
            Aktif = (ITTCheckBox)AddControl(new Guid("9475dd0d-5b03-4489-a7b9-910fdbadf800"));
            base.InitializeControls();
        }

        public WaterlowRiskDefinitionForm() : base("WATERLOWRISKDEFINITION", "WaterlowRiskDefinitionForm")
        {
        }

        protected WaterlowRiskDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}