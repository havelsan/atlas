
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
    public partial class PatientLabTestResults : TTUnboundForm
    {
        protected ITTButton cmdList;
        protected ITTComboBox cmdMonths;
        protected ITTLabel lblAylik;
        protected ITTGrid LaboratoryResultsGrid;
        protected ITTDateTimePickerColumn ProcedureDate;
        protected ITTTextBoxColumn Procedure;
        protected ITTRichTextBoxControlColumn ProcedureResult;
        protected ITTTextBoxColumn ObjectID;
        protected ITTGrid GridSubProcedures;
        protected ITTTextBoxColumn TestName;
        protected ITTTextBoxColumn result;
        protected ITTEnumComboBoxColumn Warning;
        protected ITTTextBoxColumn Reference;
        protected ITTTextBoxColumn unit;
        protected ITTRichTextBoxControlColumn SpecialReference;
        override protected void InitializeControls()
        {
            cmdList = (ITTButton)AddControl(new Guid("12bd1022-7f63-4473-afae-47fb99846afe"));
            cmdMonths = (ITTComboBox)AddControl(new Guid("2a0d9a77-3840-469c-9c8b-ccc7e74b8b93"));
            lblAylik = (ITTLabel)AddControl(new Guid("c4d83c4f-8582-4362-bacb-68d533f52cb9"));
            LaboratoryResultsGrid = (ITTGrid)AddControl(new Guid("6aad27cf-4838-49f8-8c72-f9bc856fa2ec"));
            ProcedureDate = (ITTDateTimePickerColumn)AddControl(new Guid("babd2615-f48f-4058-aaae-bd085a28844d"));
            Procedure = (ITTTextBoxColumn)AddControl(new Guid("859cca42-cf22-4379-a043-93f6ae9f802e"));
            ProcedureResult = (ITTRichTextBoxControlColumn)AddControl(new Guid("8ef6f553-dc0c-4a37-bb0c-43d9da4766d3"));
            ObjectID = (ITTTextBoxColumn)AddControl(new Guid("fba496e2-8947-4366-9f09-b047e274ecf6"));
            GridSubProcedures = (ITTGrid)AddControl(new Guid("f5a29000-1f8d-4ced-a4eb-2e4e1d826b07"));
            TestName = (ITTTextBoxColumn)AddControl(new Guid("3e8a882e-1704-404b-a59d-1abbc04defc5"));
            result = (ITTTextBoxColumn)AddControl(new Guid("668d57f6-0042-4513-ab5d-74bf069fc852"));
            Warning = (ITTEnumComboBoxColumn)AddControl(new Guid("a74e6883-7a22-4cc8-b6f4-f3281b3dd6d3"));
            Reference = (ITTTextBoxColumn)AddControl(new Guid("ceef0eec-afa4-4a7f-9673-cc65d10aef75"));
            unit = (ITTTextBoxColumn)AddControl(new Guid("797befc4-9302-4d9a-9d23-57366cfc4540"));
            SpecialReference = (ITTRichTextBoxControlColumn)AddControl(new Guid("b9402bba-4b6c-4824-8816-d232bfda7871"));
            base.InitializeControls();
        }

        public PatientLabTestResults() : base("PatientLabTestResults")
        {
        }

        protected PatientLabTestResults(string formDefName) : base(formDefName)
        {
        }
    }
}