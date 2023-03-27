
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
    /// Tıbbi Genetik Tetkik Tanım Formu
    /// </summary>
    public partial class GeneticTestDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.GeneticTestDefinition _GeneticTestDefinition
        {
            get { return (TTObjectClasses.GeneticTestDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTTextBox Name;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage2;
        protected ITTGrid ttgrid3;
        protected ITTListBoxColumn GeneticEquipmentList;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid4;
        protected ITTListBoxColumn ttlistboxcolumn3;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelName;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ChkChargable;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox ttcheckbox1;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("8c316f54-08e2-4916-9aa7-d3a1f1791404"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("1008ccdd-829a-448b-9f47-2ba4d46b2789"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("e3c2551d-bdd2-4021-93d0-eca05697c247"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("cd0ce128-d0bf-47ed-af52-62774e9c45c6"));
            Name = (ITTTextBox)AddControl(new Guid("c5281fdf-a4e7-4dd0-b528-0ee674d25f4d"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4ef32152-a44c-43f4-9a29-2d9f95fa85f6"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("54ece496-a12b-4dc2-9371-49998bfddc38"));
            ttgrid3 = (ITTGrid)AddControl(new Guid("2ba58a3e-dc75-4877-aaa8-2d10e098a17b"));
            GeneticEquipmentList = (ITTListBoxColumn)AddControl(new Guid("54eaac27-1f00-4a07-9425-ea0c66bdda28"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("606fb599-3c6e-4043-9d7b-8aabf8037942"));
            ttgrid4 = (ITTGrid)AddControl(new Guid("cbf38709-722e-4cf1-98e4-9488e599ebf5"));
            ttlistboxcolumn3 = (ITTListBoxColumn)AddControl(new Guid("a22d2336-6f01-44e9-bd56-772eeab193a5"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("ddcb886c-eac7-4497-9b6f-904da7e86d43"));
            labelName = (ITTLabel)AddControl(new Guid("efc88e8a-8401-402e-8aa9-8f284947388f"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("7f279279-a2c5-428b-afab-49043c1a390f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e45bfcb7-2e8e-4aef-b5eb-e324260d48e0"));
            ChkChargable = (ITTCheckBox)AddControl(new Guid("346cffab-ac85-4d0d-9e00-d64a43a2b77e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("727ed4d9-4bad-47ea-8b0c-4bff09e2505d"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("092ecad6-130a-4fb8-8430-1d6d817464fb"));
            base.InitializeControls();
        }

        public GeneticTestDefinitionForm() : base("GENETICTESTDEFINITION", "GeneticTestDefinitionForm")
        {
        }

        protected GeneticTestDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}