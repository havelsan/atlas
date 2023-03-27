
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
    /// Ana Depo(Saymanlık) Tanımları
    /// </summary>
    public partial class MainStoreDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Ana Depo (Saymanlık Deposu) Tanımı
    /// </summary>
        protected TTObjectClasses.MainStoreDefinition _MainStoreDefinition
        {
            get { return (TTObjectClasses.MainStoreDefinition)_ttObject; }
        }

        protected ITTGrid StoreSMSUsers;
        protected ITTListBoxColumn ResUserStoreSMSUser;
        protected ITTLabel labelUnitRecordNo;
        protected ITTTextBox UnitRecordNo;
        protected ITTTextBox StoreRecordNo;
        protected ITTTextBox StoreCode;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTTextBox QREF;
        protected ITTLabel labelStoreRecordNo;
        protected ITTLabel labelStoreCode;
        protected ITTLabel labelIntegrationScope;
        protected ITTEnumComboBox IntegrationScope;
        protected ITTLabel labelMKYS_ButceTuru;
        protected ITTEnumComboBox MKYS_ButceTuru;
        protected ITTLabel labelAccountManager;
        protected ITTObjectListBox AccountManager;
        protected ITTButton cmdInfoCard;
        protected ITTLabel labelGoodsAccountant;
        protected ITTObjectListBox GoodsResponsible;
        protected ITTLabel labelGoodsResponsible;
        protected ITTEnumComboBox Status;
        protected ITTObjectListBox GoodsAccountant;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelAccountancy;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelStatus;
        protected ITTLabel labelName;
        protected ITTLabel labelQREF;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            StoreSMSUsers = (ITTGrid)AddControl(new Guid("0553f8e3-2a61-4a13-97cc-9ae6bc00c85a"));
            ResUserStoreSMSUser = (ITTListBoxColumn)AddControl(new Guid("d4352bea-a66c-46ea-9d7b-73cf53516b8b"));
            labelUnitRecordNo = (ITTLabel)AddControl(new Guid("a7c375ac-9238-4b41-8ee2-c99163914e29"));
            UnitRecordNo = (ITTTextBox)AddControl(new Guid("a59d7b8a-709d-4ff1-9390-e32a048f6d6b"));
            StoreRecordNo = (ITTTextBox)AddControl(new Guid("6ba86b05-3f61-4849-a485-ba3b2b8aaa84"));
            StoreCode = (ITTTextBox)AddControl(new Guid("e8ba4bb2-4afa-4779-b13e-40df2be03865"));
            Description = (ITTTextBox)AddControl(new Guid("fe7a3744-10e5-4812-8184-1ae4aac8221f"));
            Name = (ITTTextBox)AddControl(new Guid("6b39d229-cfc5-455b-9951-672bd72c4fc4"));
            QREF = (ITTTextBox)AddControl(new Guid("2bf04331-a9a3-436a-b732-c175cec3f095"));
            labelStoreRecordNo = (ITTLabel)AddControl(new Guid("73e3d7e3-3d5d-45cc-b8b4-a1068b2163f0"));
            labelStoreCode = (ITTLabel)AddControl(new Guid("11110f2e-c248-4f37-a5ed-f36bc7b6314f"));
            labelIntegrationScope = (ITTLabel)AddControl(new Guid("a1260f20-a431-44cb-847a-22d1a5c9b78b"));
            IntegrationScope = (ITTEnumComboBox)AddControl(new Guid("40e91c32-9c08-4ff5-8cdb-3981d041fd7d"));
            labelMKYS_ButceTuru = (ITTLabel)AddControl(new Guid("f07c2477-4fcb-4406-899d-5bbf7dfa2bcf"));
            MKYS_ButceTuru = (ITTEnumComboBox)AddControl(new Guid("de804d2d-8412-44f1-a0d9-5b853117028f"));
            labelAccountManager = (ITTLabel)AddControl(new Guid("dc26a90e-7dc4-40df-b226-87eb3bb64398"));
            AccountManager = (ITTObjectListBox)AddControl(new Guid("fe9e9f77-af20-45b8-8967-bae516f1f23f"));
            cmdInfoCard = (ITTButton)AddControl(new Guid("6ebd429c-3622-4a98-a58b-4905b074a080"));
            labelGoodsAccountant = (ITTLabel)AddControl(new Guid("a5f3ab6e-2215-4949-aa3c-e84b9c237134"));
            GoodsResponsible = (ITTObjectListBox)AddControl(new Guid("854117e0-c204-4cff-a216-d6b86efc311d"));
            labelGoodsResponsible = (ITTLabel)AddControl(new Guid("768fe007-e424-4df5-a533-e3fc1e3c198e"));
            Status = (ITTEnumComboBox)AddControl(new Guid("a3997d0b-0c46-4c56-8f6c-21c505f681ea"));
            GoodsAccountant = (ITTObjectListBox)AddControl(new Guid("baac1538-b36d-46f3-9ab8-72b0abcb5d64"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("3fd26239-6be7-4bce-a763-38bbb2cd4784"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("06e22a6b-3ffd-4e31-8648-3dffc718073e"));
            IsActive = (ITTCheckBox)AddControl(new Guid("01ee3beb-7cf7-45cf-97e3-6ce08f3744ea"));
            labelStatus = (ITTLabel)AddControl(new Guid("cf204cb0-4f63-4000-b35e-7d323f045f4c"));
            labelName = (ITTLabel)AddControl(new Guid("fb3d9582-8a51-43a5-84dc-e6a646a91649"));
            labelQREF = (ITTLabel)AddControl(new Guid("5f848b82-8478-4611-9fe6-ff8fb2bf2724"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6f79ebfe-25b1-4257-83f6-8ee0204da910"));
            base.InitializeControls();
        }

        public MainStoreDefinitionForm() : base("MAINSTOREDEFINITION", "MainStoreDefinitionForm")
        {
        }

        protected MainStoreDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}