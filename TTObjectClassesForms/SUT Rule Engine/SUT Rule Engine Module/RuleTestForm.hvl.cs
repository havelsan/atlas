
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
    /// RuleTestForm
    /// </summary>
    public partial class RuleTestForm : TTUnboundForm
    {
        protected ITTTextBox AmountTextBox;
        protected ITTListView SUTMaterialDetailsListView;
        protected ITTComboBox EpisodeComboBox;
        protected ITTTextBox tttextbox1;
        protected ITTButton CheckRule;
        protected ITTObjectListBox PatientListBox;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox MaterialListBox;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureListBox;
        protected ITTLabel ttlabel4;
        protected ITTComboBox EpisodeActionComboBox;
        protected ITTLabel ttlabel5;
        protected ITTListView SUTProcedureDetailsListView;
        override protected void InitializeControls()
        {
            AmountTextBox = (ITTTextBox)AddControl(new Guid("60b2c4a5-af13-4ff8-9ec8-8bf9970d6d89"));
            SUTMaterialDetailsListView = (ITTListView)AddControl(new Guid("2a6f3fb1-6b52-4bab-9881-5be3f9344c1d"));
            EpisodeComboBox = (ITTComboBox)AddControl(new Guid("f30adc43-b728-4456-b623-1f5c1678988b"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("7cb4b644-520a-4c44-9906-b0734235aa73"));
            CheckRule = (ITTButton)AddControl(new Guid("b99ff010-0c10-4850-87a3-4bde622efa23"));
            PatientListBox = (ITTObjectListBox)AddControl(new Guid("07f83d44-f55d-4105-acac-ed494ab1cb41"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("feeb92fc-766b-482e-8c38-c7bbe6118626"));
            MaterialListBox = (ITTObjectListBox)AddControl(new Guid("bb2507d8-8cd5-4c67-9019-5a3ff80a1fa8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ae8f8810-8f77-4b88-bd94-e49a64ec3079"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("70920834-d0ed-41aa-b41a-4e759bf17020"));
            ProcedureListBox = (ITTObjectListBox)AddControl(new Guid("71844b65-c0e7-4b42-be85-50f07c9cf0b4"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("776557d8-510c-4ba3-9b62-874b26c1bd66"));
            EpisodeActionComboBox = (ITTComboBox)AddControl(new Guid("6df5bdd3-82f2-460a-a33e-7f1dcba2bc24"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6654174a-5fda-447e-8a45-db8c229c43f0"));
            SUTProcedureDetailsListView = (ITTListView)AddControl(new Guid("70d07384-cd48-4b0e-9263-714ce1b2f3c2"));
            base.InitializeControls();
        }

        public RuleTestForm() : base("RuleTestForm")
        {
        }

        protected RuleTestForm(string formDefName) : base(formDefName)
        {
        }
    }
}