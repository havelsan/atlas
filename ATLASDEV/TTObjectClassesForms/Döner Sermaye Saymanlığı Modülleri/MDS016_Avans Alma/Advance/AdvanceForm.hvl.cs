
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
    /// Avans Alma
    /// </summary>
    public partial class AdvanceForm : TTForm
    {
    /// <summary>
    /// Avans Alma İşlemi
    /// </summary>
        protected TTObjectClasses.Advance _Advance
        {
            get { return (TTObjectClasses.Advance)_ttObject; }
        }

        protected ITTLabel labelCashOfficeName;
        protected ITTLabel ttlabel6;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox PAYEENAME;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox CREDITCARDDOCUMENTNO;
        protected ITTTextBox Description;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTTextBox CREDITCARDSPECIALNO;
        protected ITTTextBox TOTALPRICE;
        protected ITTTextBox RECEIPTSPECIALNO;
        protected ITTTextBox RECEIPTNO;
        protected ITTLabel labelTotalPrice;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker DOCUMENTDATE;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel14;
        protected ITTEnumComboBox ttenumcombobox1;
        override protected void InitializeControls()
        {
            labelCashOfficeName = (ITTLabel)AddControl(new Guid("7a552576-0bf2-4405-8f0e-014861f03b48"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9fb3fe39-71c2-4d28-bee3-0400eb052e31"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("00f499c2-1faf-4561-b5f8-76a400e809da"));
            PAYEENAME = (ITTTextBox)AddControl(new Guid("d1272334-25d5-42be-a805-7861a9c685bc"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("49eef4cc-d0e2-4487-b243-86517626d04e"));
            CREDITCARDDOCUMENTNO = (ITTTextBox)AddControl(new Guid("323703a8-b291-46bc-a6e7-8f0b89ad467e"));
            Description = (ITTTextBox)AddControl(new Guid("364e929b-9b85-4c56-9792-97c1ba17a013"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("1f95b7d0-ba15-4be6-b3bf-b2a75d9256fe"));
            CREDITCARDSPECIALNO = (ITTTextBox)AddControl(new Guid("28f3008e-3f35-4cee-8e5b-ccd2a6a004d2"));
            TOTALPRICE = (ITTTextBox)AddControl(new Guid("14e6de78-f88e-4c0f-ae6b-d6de9fc9ad4b"));
            RECEIPTSPECIALNO = (ITTTextBox)AddControl(new Guid("a4904f15-3479-4f24-8293-f195383b4297"));
            RECEIPTNO = (ITTTextBox)AddControl(new Guid("82aa94ef-da24-4da0-baaa-f2d6ceb11bcd"));
            labelTotalPrice = (ITTLabel)AddControl(new Guid("78abae3b-f963-4b6f-a544-5598806b4dc7"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("db1e58f3-46e2-4a72-83ee-6b064134e240"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("60c3de59-e674-4dba-bd72-78cf16707116"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b87382a0-96c6-4204-abc1-962fd60c6e80"));
            DOCUMENTDATE = (ITTDateTimePicker)AddControl(new Guid("5cbb2ab1-b77d-4937-adab-9d1735a92158"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("1931c618-d51f-4362-9ab4-a9ae045e241a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c3cb9d29-597d-4437-b610-c618a8098ed9"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("033d1896-456c-4df7-ac01-cc1696033869"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c398f98f-b8f1-4592-83e0-d76988410171"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("5ef193e8-2e84-470e-b6f6-e813e45c5ad8"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("d67868ea-3c80-4854-9dcf-c025942a5096"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("ab627e22-59ea-4e00-b80f-8f9a9ba3fc9c"));
            base.InitializeControls();
        }

        public AdvanceForm() : base("ADVANCE", "AdvanceForm")
        {
        }

        protected AdvanceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}