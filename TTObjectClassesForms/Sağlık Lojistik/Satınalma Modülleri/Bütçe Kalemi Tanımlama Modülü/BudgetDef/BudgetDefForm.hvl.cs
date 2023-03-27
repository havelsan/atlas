
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
    public partial class BudgetDefForm : TTDefinitionForm
    {
        protected TTObjectClasses.BudgetDef _BudgetDef
        {
            get { return (TTObjectClasses.BudgetDef)_ttObject; }
        }

        protected ITTLabel labelDefinition;
        protected ITTTextBox Definition;
        protected ITTTextBox Code4;
        protected ITTTextBox Code3;
        protected ITTTextBox Code2;
        protected ITTTextBox Code1;
        protected ITTLabel labelCode4;
        protected ITTLabel labelCode3;
        protected ITTLabel labelCode2;
        protected ITTLabel labelCode1;
        protected ITTLabel labelBudgetItemType;
        protected ITTEnumComboBox BudgetItemType;
        override protected void InitializeControls()
        {
            labelDefinition = (ITTLabel)AddControl(new Guid("28fb337c-7715-4112-af17-0356116ba38f"));
            Definition = (ITTTextBox)AddControl(new Guid("fbdc80fb-ee1c-43b2-b90c-0ee3295d9df6"));
            Code4 = (ITTTextBox)AddControl(new Guid("ee06c6bc-05b3-4587-b0e6-4470405ef8d6"));
            Code3 = (ITTTextBox)AddControl(new Guid("78776f0b-7280-4dd4-8c9b-cc70229006ff"));
            Code2 = (ITTTextBox)AddControl(new Guid("1d914e7d-069d-4dcc-b407-eac25c3402e3"));
            Code1 = (ITTTextBox)AddControl(new Guid("45cb8ee2-55d6-48cf-9c47-df6b5035ff3b"));
            labelCode4 = (ITTLabel)AddControl(new Guid("e8dc2737-c7b6-4472-abca-296a8e88163c"));
            labelCode3 = (ITTLabel)AddControl(new Guid("05f820c4-263e-4e81-9f9a-22eaf591891a"));
            labelCode2 = (ITTLabel)AddControl(new Guid("afb68244-ea81-43d7-831f-952457b9c613"));
            labelCode1 = (ITTLabel)AddControl(new Guid("65f19fca-44a8-4adf-b5b0-47cdb02ce541"));
            labelBudgetItemType = (ITTLabel)AddControl(new Guid("958b5623-5e11-4e3b-beb5-8ad5b73e1203"));
            BudgetItemType = (ITTEnumComboBox)AddControl(new Guid("45fbc572-5150-4512-9033-0d35eb84cb5c"));
            base.InitializeControls();
        }

        public BudgetDefForm() : base("BUDGETDEF", "BudgetDefForm")
        {
        }

        protected BudgetDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}