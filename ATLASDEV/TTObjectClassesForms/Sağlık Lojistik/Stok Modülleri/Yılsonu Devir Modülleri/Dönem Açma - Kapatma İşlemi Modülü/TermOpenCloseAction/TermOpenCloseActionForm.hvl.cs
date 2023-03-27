
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
    /// Dönem Açma / Kapatma
    /// </summary>
    public partial class TermOpenCloseActionForm : TTForm
    {
    /// <summary>
    /// Dönem Açma / Kapatma İşlemi
    /// </summary>
        protected TTObjectClasses.TermOpenCloseAction _TermOpenCloseAction
        {
            get { return (TTObjectClasses.TermOpenCloseAction)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelDescriptionAccountingTerm;
        protected ITTTextBox DescriptionAccountingTerm;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker ttdatetimepicker4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox ttenumcombobox2;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox CloseTermAccountancy;
        protected ITTLabel labelCloseTerm;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("97cc07fb-60b4-462f-98ef-4ae139d4e284"));
            labelDescriptionAccountingTerm = (ITTLabel)AddControl(new Guid("cd1256ec-8917-4c2c-a82e-9ad131627513"));
            DescriptionAccountingTerm = (ITTTextBox)AddControl(new Guid("6239933d-acfc-4077-b023-068a8730343e"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("82258b6a-b882-4568-a28c-759c8f49af1a"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("df366083-bd79-46c2-b3af-756f2f900020"));
            ttdatetimepicker4 = (ITTDateTimePicker)AddControl(new Guid("0e39433f-c73d-49ee-98ca-056bbc018757"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("dfb76800-e304-442f-96cb-75579487ce79"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("eaa362c3-f0d4-45a8-b0c0-fd1e64f7296e"));
            ttenumcombobox2 = (ITTEnumComboBox)AddControl(new Guid("c1ce8025-37b3-435f-bc5a-3407e08c661b"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("876f193b-461b-49df-a2c1-6be4bda2e3fc"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b5e61b57-8526-49ff-a6e6-e0359e299ed0"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("adc4c554-87a0-4707-aaa8-fd8d58f0bd07"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("0f450d46-b677-446a-b5bf-429f8aa5a6a3"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("f961426d-6b41-437d-b025-cb32d76c7026"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("a02b7b72-71fa-4758-9280-92ed499d8e92"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d8d6154e-6766-4671-8616-e84d13854f0c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("bd7e2c8f-49e0-4108-b2ab-1a75455854fd"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("73cda7e7-e4ea-4085-9cc0-794294a89aed"));
            labelID = (ITTLabel)AddControl(new Guid("d181dfd0-accb-4ef6-9fd4-ee250608b8e8"));
            ID = (ITTTextBox)AddControl(new Guid("a0a6f65e-2999-4a77-a262-2bc9733c6b01"));
            labelActionDate = (ITTLabel)AddControl(new Guid("cbce8fda-d40d-4ae0-b32b-9f2565e361d0"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("b61532ed-ae40-4039-9bb4-081c0b7f8e7c"));
            CloseTermAccountancy = (ITTObjectListBox)AddControl(new Guid("bf419a14-6b41-4735-b7e9-b5a400d71de9"));
            labelCloseTerm = (ITTLabel)AddControl(new Guid("b6006e89-dc91-4d45-af9d-82992d279110"));
            base.InitializeControls();
        }

        public TermOpenCloseActionForm() : base("TERMOPENCLOSEACTION", "TermOpenCloseActionForm")
        {
        }

        protected TermOpenCloseActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}