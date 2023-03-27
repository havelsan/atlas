
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
    /// Mali Tablo Özellikleri
    /// </summary>
    public partial class FinancialStatementSelectionForm : TTForm
    {
    /// <summary>
    /// Mali Tablolar
    /// </summary>
        protected TTObjectClasses.MhSFinancialStatements _MhSFinancialStatements
        {
            get { return (TTObjectClasses.MhSFinancialStatements)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ShowEmptyLines;
        protected ITTLabel labelScale;
        protected ITTEnumComboBox Scale;
        protected ITTCheckBox FromStart;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTLabel labelMonth;
        protected ITTEnumComboBox Month;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("401a4bba-6e88-4656-9a4f-0cabe3db1391"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7f7eb046-dee1-41fb-8142-1bf0261d3a56"));
            ShowEmptyLines = (ITTCheckBox)AddControl(new Guid("826caad2-3d7e-4c19-849e-23adfb7b2a9d"));
            labelScale = (ITTLabel)AddControl(new Guid("9a0c98fb-aeed-4f65-af8b-5cb9254adf58"));
            Scale = (ITTEnumComboBox)AddControl(new Guid("4d67851e-3112-4dc8-8106-50d21015a31f"));
            FromStart = (ITTCheckBox)AddControl(new Guid("c070c7cc-f1e1-425f-b886-6033cdc01572"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("05f65d18-6714-4bc4-b2c3-9b7338c13d1e"));
            labelMonth = (ITTLabel)AddControl(new Guid("aa259eb5-2855-47fb-abdd-d5a4bf58ea27"));
            Month = (ITTEnumComboBox)AddControl(new Guid("93c2e03d-bc90-4201-9b0e-deff217e0f43"));
            base.InitializeControls();
        }

        public FinancialStatementSelectionForm() : base("MHSFINANCIALSTATEMENTS", "FinancialStatementSelectionForm")
        {
        }

        protected FinancialStatementSelectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}