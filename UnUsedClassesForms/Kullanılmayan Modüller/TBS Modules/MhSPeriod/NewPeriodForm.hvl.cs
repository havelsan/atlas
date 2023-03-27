
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
    /// Yeni Çalışma Yılı
    /// </summary>
    public partial class NewPeriodForm : TTForm
    {
    /// <summary>
    /// Çalışma Yılı
    /// </summary>
        protected TTObjectClasses.MhSPeriod _MhSPeriod
        {
            get { return (TTObjectClasses.MhSPeriod)_ttObject; }
        }

        protected ITTLabel labelDepartment;
        protected ITTTextBox UnitCode;
        protected ITTLabel labelPayrollDivisionCode;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelUnitCode;
        protected ITTLabel labelYear;
        protected ITTListDefComboBox TemplateChartOfAccounts;
        protected ITTTextBox Alias;
        protected ITTTextBox Year;
        protected ITTTextBox Department;
        protected ITTLabel labelAlias;
        protected ITTTextBox PayrollDivisionCode;
        override protected void InitializeControls()
        {
            labelDepartment = (ITTLabel)AddControl(new Guid("c42a385d-0a8c-4ac0-b374-1513b7f16972"));
            UnitCode = (ITTTextBox)AddControl(new Guid("132b16c3-93f7-44e6-aa5d-283501758fb2"));
            labelPayrollDivisionCode = (ITTLabel)AddControl(new Guid("ea24e62c-02ff-4b88-b999-26df2108b9fc"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b91b66bb-0842-4450-beb1-5d032a1ae6d8"));
            labelUnitCode = (ITTLabel)AddControl(new Guid("a3f11c16-bd57-4148-8db3-5c1139969bca"));
            labelYear = (ITTLabel)AddControl(new Guid("ce47c6cc-818a-4029-a65a-6890d0ec13fc"));
            TemplateChartOfAccounts = (ITTListDefComboBox)AddControl(new Guid("d1d29c82-e75e-4f79-bba1-77b632f3b288"));
            Alias = (ITTTextBox)AddControl(new Guid("a322675f-3b34-4bbe-862f-a0aec8996b85"));
            Year = (ITTTextBox)AddControl(new Guid("3563e4fd-413a-4522-84fc-ea0bd3160710"));
            Department = (ITTTextBox)AddControl(new Guid("39bc5da5-95ac-4cca-9bbf-e6d07cc46455"));
            labelAlias = (ITTLabel)AddControl(new Guid("760d3197-794b-4ec5-99d8-dd7f7c68ca3a"));
            PayrollDivisionCode = (ITTTextBox)AddControl(new Guid("f37660a1-8557-4594-9420-da7967795618"));
            base.InitializeControls();
        }

        public NewPeriodForm() : base("MHSPERIOD", "NewPeriodForm")
        {
        }

        protected NewPeriodForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}