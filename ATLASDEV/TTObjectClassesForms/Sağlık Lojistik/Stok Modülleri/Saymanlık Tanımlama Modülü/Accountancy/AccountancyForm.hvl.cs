
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
    /// Saymanlık Tanımları
    /// </summary>
    public partial class AccountancyForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Saymanlık Tanımları
    /// </summary>
        protected TTObjectClasses.Accountancy _Accountancy
        {
            get { return (TTObjectClasses.Accountancy)_ttObject; }
        }

        protected ITTLabel labelGLNNo;
        protected ITTTextBox GLNNo;
        protected ITTTextBox AccountancyCode;
        protected ITTTextBox Name;
        protected ITTTextBox QREF;
        protected ITTTextBox Address;
        protected ITTTextBox AccountancyNO;
        protected ITTLabel labelUnitStoreGetData;
        protected ITTObjectListBox UnitStoreGetData;
        protected ITTCheckBox IsNonBarcode;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelName;
        protected ITTLabel labelQREF;
        protected ITTLabel labelAccountancyCode;
        protected ITTObjectListBox AccountancyMilitaryUnit;
        protected ITTLabel labelAddress;
        protected ITTLabel labelAccountancyNO;
        override protected void InitializeControls()
        {
            labelGLNNo = (ITTLabel)AddControl(new Guid("5829eaf0-afdb-420b-b170-8417a011b0b8"));
            GLNNo = (ITTTextBox)AddControl(new Guid("385b1ca9-d124-4e9a-ad32-640fc5893a9d"));
            AccountancyCode = (ITTTextBox)AddControl(new Guid("10284dde-0f2e-4a27-a97e-625cbd813d07"));
            Name = (ITTTextBox)AddControl(new Guid("25151da8-a4d4-409a-95b1-6954424cc922"));
            QREF = (ITTTextBox)AddControl(new Guid("7f69829e-2e05-4a88-a582-a70ac5b4ea0f"));
            Address = (ITTTextBox)AddControl(new Guid("8b9958fe-cc95-4ff5-84d2-25e69bfa13be"));
            AccountancyNO = (ITTTextBox)AddControl(new Guid("d5507fd0-5342-49d3-a01f-c80a72c6e8d3"));
            labelUnitStoreGetData = (ITTLabel)AddControl(new Guid("4cab4371-dc6b-410e-a760-8c77762c0b89"));
            UnitStoreGetData = (ITTObjectListBox)AddControl(new Guid("c95eae91-ca72-48ef-a4e1-0919b00b1256"));
            IsNonBarcode = (ITTCheckBox)AddControl(new Guid("0297e146-1268-427e-aabd-4e5c91cf5ba4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("22f75b7c-b522-4ae8-a115-53368f34f79c"));
            labelName = (ITTLabel)AddControl(new Guid("fc3154f9-3744-4d47-b289-38885585ddb3"));
            labelQREF = (ITTLabel)AddControl(new Guid("a727ca1e-674a-4a9b-8a0a-5d4060b77928"));
            labelAccountancyCode = (ITTLabel)AddControl(new Guid("bfe0411c-2db2-4929-aca7-a9312723e9bd"));
            AccountancyMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("0b279889-1776-4bbb-b703-c23aeee34204"));
            labelAddress = (ITTLabel)AddControl(new Guid("2d80a078-7f26-4b5d-a45a-0d10d5c22488"));
            labelAccountancyNO = (ITTLabel)AddControl(new Guid("bfb24ce8-6535-4d34-a172-0b11c3004b76"));
            base.InitializeControls();
        }

        public AccountancyForm() : base("ACCOUNTANCY", "AccountancyForm")
        {
        }

        protected AccountancyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}