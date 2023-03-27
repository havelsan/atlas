
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
    public partial class EmergencySurveyForm : TTDefinitionForm
    {
        protected TTObjectClasses.EmergencySurveyDefinition _EmergencySurveyDefinition
        {
            get { return (TTObjectClasses.EmergencySurveyDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelActivityGroup;
        protected ITTEnumComboBox ActivityGroup;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("f5551401-63e1-4a16-b957-7d07543c98a2"));
            Name = (ITTTextBox)AddControl(new Guid("f7889c64-f707-4fae-890d-99b00a4d2a26"));
            labelActivityGroup = (ITTLabel)AddControl(new Guid("950f9a45-520c-4838-985e-b16d7d13f75b"));
            ActivityGroup = (ITTEnumComboBox)AddControl(new Guid("4d51df69-fd03-462f-81a2-10bf91449834"));
            Aktif = (ITTCheckBox)AddControl(new Guid("df6a1b23-157e-4175-9307-a82d66591994"));
            base.InitializeControls();
        }

        public EmergencySurveyForm() : base("EMERGENCYSURVEYDEFINITION", "EmergencySurveyForm")
        {
        }

        protected EmergencySurveyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}