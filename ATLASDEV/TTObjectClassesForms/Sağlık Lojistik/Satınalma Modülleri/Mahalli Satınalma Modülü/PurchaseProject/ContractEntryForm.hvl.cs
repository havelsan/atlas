
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
    /// Sözleşme Giriş
    /// </summary>
    public partial class ContractEntryForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTButton cmdPrepareContracts;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTTextBox ActCount;
        protected ITTTextBox KIKTenderRegisterNO;
        protected ITTTextBox ActAttribute;
        protected ITTTextBox ConfirmNO;
        protected ITTTextBox ActDefine;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelKIKTenderRegisterNO;
        protected ITTLabel labelConfirmDate;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelConfirmNO;
        protected ITTGrid Contracts;
        protected ITTListBoxColumn Supplier;
        protected ITTButtonColumn Details;
        protected ITTButtonColumn Delete;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker ConfirmDate;
        override protected void InitializeControls()
        {
            cmdPrepareContracts = (ITTButton)AddControl(new Guid("f380fc1b-e3db-4751-8dd5-0ea573a80969"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("122d8d6e-c64b-4366-b01c-16f3819ae2c0"));
            ActCount = (ITTTextBox)AddControl(new Guid("de9fa89f-b2a5-4eb8-9d8f-29df6b90d241"));
            KIKTenderRegisterNO = (ITTTextBox)AddControl(new Guid("90c17cb4-61db-4c33-b3f1-ac6dfd6a5097"));
            ActAttribute = (ITTTextBox)AddControl(new Guid("2a8c9670-7d91-4143-9856-adab71ed5006"));
            ConfirmNO = (ITTTextBox)AddControl(new Guid("34cfd498-8209-4c5c-94f9-b6beff7ce75e"));
            ActDefine = (ITTTextBox)AddControl(new Guid("bbbc886d-8776-4e8c-bda6-dc0920856b6b"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("36d339a4-f351-4ab4-9f14-0ebd9cb8f129"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cf5cbd8c-d2ca-4f1d-a49b-6aa81425104c"));
            labelKIKTenderRegisterNO = (ITTLabel)AddControl(new Guid("8b423a53-481f-412e-bfd8-7f8a27d876a1"));
            labelConfirmDate = (ITTLabel)AddControl(new Guid("1da61fa4-3e2d-4282-b77b-8145a8701eba"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("b532377e-29da-4006-be0c-8b7a491139d8"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("8999578e-d2a0-4748-b35a-8c6de8ef4af0"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("86b10db2-85e7-40df-8fb8-b0f0e40df8cb"));
            labelConfirmNO = (ITTLabel)AddControl(new Guid("cab3cd6b-faab-4817-965d-bfc4efb54a49"));
            Contracts = (ITTGrid)AddControl(new Guid("2f43da66-d0c8-4517-aeeb-cabba1fb80a7"));
            Supplier = (ITTListBoxColumn)AddControl(new Guid("d49c3217-1c1f-4e51-8921-29d6975b5605"));
            Details = (ITTButtonColumn)AddControl(new Guid("b552c696-5531-4b71-9aac-448567730f0c"));
            Delete = (ITTButtonColumn)AddControl(new Guid("550fd8bc-7eee-41d5-8ec5-f83c562f0108"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("f53b32da-49d6-48a7-9504-cadb44921bdc"));
            ConfirmDate = (ITTDateTimePicker)AddControl(new Guid("5138b198-dd9c-45f6-98d7-e2a1cf64f9c1"));
            base.InitializeControls();
        }

        public ContractEntryForm() : base("PURCHASEPROJECT", "ContractEntryForm")
        {
        }

        protected ContractEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}