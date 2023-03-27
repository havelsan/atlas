
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
    public partial class UnitStoreGetDataForm : TTDefinitionForm
    {
        protected TTObjectClasses.UnitStoreGetData _UnitStoreGetData
        {
            get { return (TTObjectClasses.UnitStoreGetData)_ttObject; }
        }

        protected ITTTextBox IntegrationScope;
        protected ITTTextBox UnitRecordNo;
        protected ITTTextBox StoreRecordNo;
        protected ITTTextBox StoreDefinition;
        protected ITTTextBox StoreCode;
        protected ITTLabel labelUnitRecordNo;
        protected ITTLabel labelStoreRecordNo;
        protected ITTLabel labelStoreDefinition;
        protected ITTLabel labelStoreCode;
        protected ITTLabel labelIntegrationScope;
        override protected void InitializeControls()
        {
            IntegrationScope = (ITTTextBox)AddControl(new Guid("cceb6ab5-9d26-417a-9212-e72b60c86b5b"));
            UnitRecordNo = (ITTTextBox)AddControl(new Guid("41da12cc-12ab-4a69-9494-7c3a04466939"));
            StoreRecordNo = (ITTTextBox)AddControl(new Guid("95497e43-ffe2-4664-8bd3-0c7a31847c4c"));
            StoreDefinition = (ITTTextBox)AddControl(new Guid("d67fe470-da1f-477e-918c-4593dffdef9d"));
            StoreCode = (ITTTextBox)AddControl(new Guid("7dbec7ac-53bf-491d-a9ad-708657107409"));
            labelUnitRecordNo = (ITTLabel)AddControl(new Guid("745c0d8c-cd49-4fbf-af36-e1ac6076008b"));
            labelStoreRecordNo = (ITTLabel)AddControl(new Guid("8e4d825f-e99f-4ced-b611-dfb7ed5c9004"));
            labelStoreDefinition = (ITTLabel)AddControl(new Guid("5bc0624a-0c45-49be-8b19-1ab3f8d7bde5"));
            labelStoreCode = (ITTLabel)AddControl(new Guid("c88f3a13-9866-48e2-bbc6-cfaee23f3ed3"));
            labelIntegrationScope = (ITTLabel)AddControl(new Guid("5f347285-97d5-4147-a6ce-ac3215ae19b9"));
            base.InitializeControls();
        }

        public UnitStoreGetDataForm() : base("UNITSTOREGETDATA", "UnitStoreGetDataForm")
        {
        }

        protected UnitStoreGetDataForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}