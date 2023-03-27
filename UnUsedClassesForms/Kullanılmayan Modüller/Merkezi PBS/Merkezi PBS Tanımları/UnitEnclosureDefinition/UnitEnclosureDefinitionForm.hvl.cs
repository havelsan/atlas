
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
    public partial class UnitEnclosureDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.UnitEnclosureDefinition _UnitEnclosureDefinition
        {
            get { return (TTObjectClasses.UnitEnclosureDefinition)_ttObject; }
        }

        protected ITTLabel labelParentId;
        protected ITTObjectListBox ParentId;
        protected ITTLabel labelMilitaryUnit;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelSEQUENCE;
        protected ITTTextBox SEQUENCE;
        protected ITTTextBox NAME;
        protected ITTTextBox DESCRIPTION;
        protected ITTLabel labelNAME;
        protected ITTLabel labelDESCRIPTION;
        override protected void InitializeControls()
        {
            labelParentId = (ITTLabel)AddControl(new Guid("5ccf939e-d952-40f6-95e5-4bcc76f7a4a6"));
            ParentId = (ITTObjectListBox)AddControl(new Guid("c5d9723a-c1ec-462e-a43c-a74f1396c6b4"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("9b7fc397-61df-44b1-ae9a-a7d6f3b5ff08"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("47bd5b31-84af-420d-a84d-3a2fad0216f7"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("ae85ccff-bbd7-4d43-ba72-bc7324eaeed7"));
            labelSEQUENCE = (ITTLabel)AddControl(new Guid("dcc33b76-cdb5-4c54-b7ce-056a51d0f57b"));
            SEQUENCE = (ITTTextBox)AddControl(new Guid("151c7b9f-c713-481e-aa04-9ed9f1364d8a"));
            NAME = (ITTTextBox)AddControl(new Guid("d3bceed2-8a05-4441-9706-52a979c9bdc2"));
            DESCRIPTION = (ITTTextBox)AddControl(new Guid("2775e0f6-5f99-4830-8509-e889b4506cac"));
            labelNAME = (ITTLabel)AddControl(new Guid("f7aa97d6-5a06-4e6a-a9b5-04ed392480a6"));
            labelDESCRIPTION = (ITTLabel)AddControl(new Guid("63298278-a46a-42ea-a5f8-2956e7da491a"));
            base.InitializeControls();
        }

        public UnitEnclosureDefinitionForm() : base("UNITENCLOSUREDEFINITION", "UnitEnclosureDefinitionForm")
        {
        }

        protected UnitEnclosureDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}