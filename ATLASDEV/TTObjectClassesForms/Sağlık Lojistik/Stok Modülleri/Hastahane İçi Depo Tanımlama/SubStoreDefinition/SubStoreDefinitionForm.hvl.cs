
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
    /// Hastahane İçi Depo Tanımları
    /// </summary>
    public partial class SubStoreDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// XXXXXX İçi Depo Tanımları
    /// </summary>
        protected TTObjectClasses.SubStoreDefinition _SubStoreDefinition
        {
            get { return (TTObjectClasses.SubStoreDefinition)_ttObject; }
        }

        protected ITTEnumComboBox MKYS_CikisHareketTuru;
        protected ITTCheckBox IsEmergencyStore;
        protected ITTTextBox UnitCode;
        protected ITTTextBox UnitRegistryNo;
        protected ITTTextBox DependantUnitID;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTTextBox QREF;
        protected ITTLabel labelUnitCode;
        protected ITTLabel labelUnitRegistryNo;
        protected ITTLabel labelDependantUnitID;
        protected ITTCheckBox AutoReturningDocumentCreat;
        protected ITTLabel labelSubStore;
        protected ITTObjectListBox SubStore;
        protected ITTButton MKYS_SendStore;
        protected ITTObjectListBox StoreResponsible;
        protected ITTLabel labelName;
        protected ITTLabel labelStatus;
        protected ITTLabel labelQREF;
        protected ITTEnumComboBox Status;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStoreResponsible;
        protected ITTCheckBox IsActive;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            MKYS_CikisHareketTuru = (ITTEnumComboBox)AddControl(new Guid("9061c04f-606a-4a60-b1dc-8833e05895b1"));
            IsEmergencyStore = (ITTCheckBox)AddControl(new Guid("2c1b0f23-b007-451a-9e1a-d46da340be79"));
            UnitCode = (ITTTextBox)AddControl(new Guid("dbe43d48-0346-4e3e-8b18-502ce8de416d"));
            UnitRegistryNo = (ITTTextBox)AddControl(new Guid("b509a8e9-baed-4c3a-b045-d88d180aabc8"));
            DependantUnitID = (ITTTextBox)AddControl(new Guid("2a091d06-06b1-4d75-a764-c7be0c67ff76"));
            Description = (ITTTextBox)AddControl(new Guid("88fd3d40-8f8e-42d3-be1a-1a7c7dd3bd7a"));
            Name = (ITTTextBox)AddControl(new Guid("75328564-c64c-4868-b35e-5e3efc450e34"));
            QREF = (ITTTextBox)AddControl(new Guid("3e3e567d-c0f9-4b67-9832-a1187201d2e7"));
            labelUnitCode = (ITTLabel)AddControl(new Guid("b9d6c89d-b395-431b-ba84-5e306f304ccb"));
            labelUnitRegistryNo = (ITTLabel)AddControl(new Guid("72e3caa2-7098-444d-afee-2a96ef156181"));
            labelDependantUnitID = (ITTLabel)AddControl(new Guid("454e99b0-fe15-4976-999a-e0a4dccf7bcd"));
            AutoReturningDocumentCreat = (ITTCheckBox)AddControl(new Guid("d4cb3b89-452d-40ae-9e65-3e19bd9a1ab2"));
            labelSubStore = (ITTLabel)AddControl(new Guid("0a66ff67-dca0-4f81-864c-e724f4e96cfc"));
            SubStore = (ITTObjectListBox)AddControl(new Guid("cd7490ed-a82e-459a-a324-932b863f38b1"));
            MKYS_SendStore = (ITTButton)AddControl(new Guid("020d1ee7-a64e-48d7-bd57-04a01131d696"));
            StoreResponsible = (ITTObjectListBox)AddControl(new Guid("986193d5-aab1-4dd5-a13d-0e2912afb126"));
            labelName = (ITTLabel)AddControl(new Guid("9b3fb898-80ed-4c16-b620-3ff8d349d30c"));
            labelStatus = (ITTLabel)AddControl(new Guid("0f4f3660-640e-4fe0-898a-4805ed46ce85"));
            labelQREF = (ITTLabel)AddControl(new Guid("bf22397e-b9aa-4ee4-ba6d-552e5cb449e4"));
            Status = (ITTEnumComboBox)AddControl(new Guid("1fcbfdfe-8994-44f5-84d1-7b085d3903b1"));
            labelDescription = (ITTLabel)AddControl(new Guid("5dc2323e-abb0-40ec-a300-8e991647eb20"));
            labelStoreResponsible = (ITTLabel)AddControl(new Guid("86d75325-cd54-4fd4-845a-a19ef40c7fdb"));
            IsActive = (ITTCheckBox)AddControl(new Guid("bcc5ba56-22bf-4232-a212-bf1b295eab3c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("30c51a7d-787f-4031-b72b-83133fcee490"));
            base.InitializeControls();
        }

        public SubStoreDefinitionForm() : base("SUBSTOREDEFINITION", "SubStoreDefinitionForm")
        {
        }

        protected SubStoreDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}