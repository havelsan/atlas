
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
    /// Hazine Payı Tanım Bilgileri
    /// </summary>
    public partial class TresureCutOptionsForm : TTForm
    {
    /// <summary>
    /// Hazine Payı Parametreleri
    /// </summary>
        protected TTObjectClasses.MhSTreasureCutOptionsDefinition _MhSTreasureCutOptionsDefinition
        {
            get { return (TTObjectClasses.MhSTreasureCutOptionsDefinition)_ttObject; }
        }

        protected ITTObjectListBox ChargingSlipDebitAccount;
        protected ITTTextBox SpecialAccountNo;
        protected ITTLabel labelWhyPaid;
        protected ITTLabel labelParentDepartment;
        protected ITTObjectListBox PaymentSlipCreditAccount;
        protected ITTLabel labelRegisteredTo;
        protected ITTTextBox ParentDepartment;
        protected ITTTextBox ToWhom;
        protected ITTTextBox CutRatio;
        protected ITTLabel labelCutRatio;
        protected ITTLabel labelSpecialAccountNo;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox CompanyName;
        protected ITTObjectListBox ChargingSlipCreditAccount;
        protected ITTLabel labelPaymentSlipCreditAccount;
        protected ITTLabel labelCompanyName;
        protected ITTLabel labelChargingSlipDebitAccount;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelToWhom;
        protected ITTLabel ttlabel4;
        protected ITTTextBox RegisteredTo;
        protected ITTTextBox WhyPaid;
        protected ITTObjectListBox PaymentSlipDebitAccount;
        protected ITTLabel labelChargingSlipCreditAccount;
        override protected void InitializeControls()
        {
            ChargingSlipDebitAccount = (ITTObjectListBox)AddControl(new Guid("65a93536-6249-4f45-9591-184a4d08cb72"));
            SpecialAccountNo = (ITTTextBox)AddControl(new Guid("e767df71-cc66-47e8-9fee-f17a0407a184"));
            labelWhyPaid = (ITTLabel)AddControl(new Guid("3215678b-16aa-481c-8667-cc4777d0fed2"));
            labelParentDepartment = (ITTLabel)AddControl(new Guid("17998ecc-9d36-487a-aecb-aa54a4beeb48"));
            PaymentSlipCreditAccount = (ITTObjectListBox)AddControl(new Guid("68d89b20-ceac-4aee-916a-d86a0b70f8ee"));
            labelRegisteredTo = (ITTLabel)AddControl(new Guid("7f6b98f7-36c9-4edc-8661-c7258fa7f470"));
            ParentDepartment = (ITTTextBox)AddControl(new Guid("b797b633-3d63-48b2-8fd3-ab095f01d7c7"));
            ToWhom = (ITTTextBox)AddControl(new Guid("e0e01291-4db2-4c7f-adae-b02849411908"));
            CutRatio = (ITTTextBox)AddControl(new Guid("e6f0ae29-4694-4c9e-81a8-b45988ff4a6d"));
            labelCutRatio = (ITTLabel)AddControl(new Guid("b2d82d94-5b16-47da-bee4-7dc354edb836"));
            labelSpecialAccountNo = (ITTLabel)AddControl(new Guid("704864e4-d6b6-4709-88aa-8ae4b6118d1f"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("dce00927-ff50-4768-a1bb-7d9356061022"));
            CompanyName = (ITTTextBox)AddControl(new Guid("2647dc7a-fa34-4f74-ba3c-65b8503e3d76"));
            ChargingSlipCreditAccount = (ITTObjectListBox)AddControl(new Guid("880e3c2d-84a5-4895-a2ea-6c8cc800137b"));
            labelPaymentSlipCreditAccount = (ITTLabel)AddControl(new Guid("5b00a8a3-458a-42fc-8249-6c787f406291"));
            labelCompanyName = (ITTLabel)AddControl(new Guid("eda03fd4-fcb1-48cb-8290-8496db1f5c73"));
            labelChargingSlipDebitAccount = (ITTLabel)AddControl(new Guid("4e6491cd-5640-49ee-b33a-4e7a7468e9b1"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("618bfb72-969b-4689-ba94-240a83f1b5ff"));
            labelToWhom = (ITTLabel)AddControl(new Guid("085e9c6e-edd5-4b7e-96c2-1209dda7b8e0"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("62c952a1-0f41-4a98-acff-15dfe0d9ca73"));
            RegisteredTo = (ITTTextBox)AddControl(new Guid("3187ff9e-3d73-4f54-bf99-12dc239f13c5"));
            WhyPaid = (ITTTextBox)AddControl(new Guid("b7cf4c15-c270-49dc-b5ad-2c23a18bcafa"));
            PaymentSlipDebitAccount = (ITTObjectListBox)AddControl(new Guid("856d70d8-18ec-4591-8034-faaf80cc4018"));
            labelChargingSlipCreditAccount = (ITTLabel)AddControl(new Guid("2035d3d5-4fb7-4ee0-befd-f2289773f301"));
            base.InitializeControls();
        }

        public TresureCutOptionsForm() : base("MHSTREASURECUTOPTIONSDEFINITION", "TresureCutOptionsForm")
        {
        }

        protected TresureCutOptionsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}