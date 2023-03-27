
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
    /// Mali Tablo Tanımı
    /// </summary>
    public partial class MhSFinancialStatementDefinitionForm : TTForm
    {
        protected TTObjectClasses.MhSFinancialStatementDefinition _MhSFinancialStatementDefinition
        {
            get { return (TTObjectClasses.MhSFinancialStatementDefinition)_ttObject; }
        }

        protected ITTLabel labelStatementType;
        protected ITTTextBox tttextbox1;
        protected ITTTabPage tttabpage2;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTGrid Items;
        protected ITTTextBox Name;
        protected ITTLabel ttlabel3;
        protected ITTTabPage tttabpage1;
        protected ITTEnumComboBox StatementType;
        protected ITTTabControl tttabcontrol1;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelStatementType = (ITTLabel)AddControl(new Guid("895b4eac-4817-4bfb-b5be-0c200f4ec01d"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("65998187-f924-4013-abf2-1d3ccf5d6d02"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("c6734281-e85e-469c-ba2a-5923e7fa9b2e"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("44c04482-ed84-41fb-8483-a89e88396b71"));
            Items = (ITTGrid)AddControl(new Guid("1ac10ad3-b4e1-453c-8c80-95391aa26654"));
            Name = (ITTTextBox)AddControl(new Guid("fc6101a8-17ab-479c-98cc-999fffdc8117"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("14990357-3f15-4d33-af1d-ba767680d806"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("bfb98ceb-5743-421d-933c-b4a4f952d9e7"));
            StatementType = (ITTEnumComboBox)AddControl(new Guid("a3ca9f5c-8972-4f21-8fc4-c7a337aa6f60"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("2da52034-58d0-4cda-a144-ef10f47da8e4"));
            labelName = (ITTLabel)AddControl(new Guid("095e7675-9467-4d72-95b5-cfd34dcaafeb"));
            base.InitializeControls();
        }

        public MhSFinancialStatementDefinitionForm() : base("MHSFINANCIALSTATEMENTDEFINITION", "MhSFinancialStatementDefinitionForm")
        {
        }

        protected MhSFinancialStatementDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}