
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
    /// Şartname Tanımı
    /// </summary>
    public partial class SpecificationDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Şartname Tanımı
    /// </summary>
        protected TTObjectClasses.SpecificationDefinition _SpecificationDefinition
        {
            get { return (TTObjectClasses.SpecificationDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTGrid ClausesGrid;
        protected ITTTextBoxColumn ClauseNo;
        protected ITTRichTextBoxControlColumn Clause;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        protected ITTTextBox Name;
        protected ITTLabel labelDate;
        protected ITTDateTimePicker Date;
        protected ITTTextBox Code;
        protected ITTTextBox No;
        protected ITTLabel labelCategory;
        protected ITTEnumComboBox Category;
        protected ITTLabel labelNo;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("a5ea63c9-d041-474c-a928-a3052a81714e"));
            ClausesGrid = (ITTGrid)AddControl(new Guid("b2b47d7e-19fe-4541-9f3d-d996c23babb9"));
            ClauseNo = (ITTTextBoxColumn)AddControl(new Guid("6105d97d-f955-4f8e-b73e-6b00604f8d21"));
            Clause = (ITTRichTextBoxControlColumn)AddControl(new Guid("8f0bd6c0-a014-46ae-9374-81c440776b92"));
            labelName = (ITTLabel)AddControl(new Guid("144843fd-4445-4389-89c7-352fb93b23e9"));
            labelCode = (ITTLabel)AddControl(new Guid("ecd2aae4-715b-4219-8294-41ae6c151101"));
            Name = (ITTTextBox)AddControl(new Guid("fa8a222f-a15b-4330-ad6b-53116489a001"));
            labelDate = (ITTLabel)AddControl(new Guid("b3352ad0-493b-4836-b6f1-660f2dc59a2d"));
            Date = (ITTDateTimePicker)AddControl(new Guid("1952f3c9-9a0f-4011-a543-7d596aa98d1c"));
            Code = (ITTTextBox)AddControl(new Guid("0d9d9bcd-732c-40a8-8515-80283dc03676"));
            No = (ITTTextBox)AddControl(new Guid("86aec849-abf8-420a-a561-89ffcee06e34"));
            labelCategory = (ITTLabel)AddControl(new Guid("6a15b23d-28a1-4622-94fc-af504cd72cf9"));
            Category = (ITTEnumComboBox)AddControl(new Guid("3ef48f12-7105-4ec2-837f-d363d87dfb0d"));
            labelNo = (ITTLabel)AddControl(new Guid("d22178f6-e2fc-455d-a692-f5e61a3cc6d9"));
            base.InitializeControls();
        }

        public SpecificationDefinitionForm() : base("SPECIFICATIONDEFINITION", "SpecificationDefinitionForm")
        {
        }

        protected SpecificationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}