
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
    /// Set / Sistem / Ünite Tanımı 
    /// </summary>
    public partial class SetSystemUnitDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.SetSystemUnitDefinition _SetSystemUnitDefinition
        {
            get { return (TTObjectClasses.SetSystemUnitDefinition)_ttObject; }
        }

        protected ITTCheckBox NeedMaintenance;
        protected ITTCheckBox NeedCalibration;
        protected ITTLabel labelNameSites;
        protected ITTTextBox NameSites;
        protected ITTTextBox GuarantiePeriod;
        protected ITTTextBox UsePlaces;
        protected ITTTextBox UseGoal;
        protected ITTTextBox ReferansNo;
        protected ITTTextBox LifePeriod;
        protected ITTTextBox TechnicalSpecificationsNo;
        protected ITTTextBox MaterialCategory;
        protected ITTTextBox Desciption;
        protected ITTTextBox Barcode;
        protected ITTTextBox Name;
        protected ITTLabel labelProducer;
        protected ITTObjectListBox Producer;
        protected ITTLabel labelFixedAssetDetailModelDef;
        protected ITTObjectListBox FixedAssetDetailModelDef;
        protected ITTLabel labelFixedAssetDetailMarkDef;
        protected ITTObjectListBox FixedAssetDetailMarkDef;
        protected ITTLabel labelMaintenancePeriod;
        protected ITTEnumComboBox MaintenancePeriod;
        protected ITTLabel labelGuarantiePeriod;
        protected ITTLabel labelUsePlaces;
        protected ITTLabel labelUseGoal;
        protected ITTLabel labelReferansNo;
        protected ITTLabel labelGuarantyStartDate;
        protected ITTDateTimePicker GuarantyStartDate;
        protected ITTLabel labelLifePeriod;
        protected ITTLabel labelTechnicalSpecificationsNo;
        protected ITTLabel labelMaterialCategory;
        protected ITTLabel labelDesciption;
        protected ITTLabel labelCalibrationPeriod;
        protected ITTEnumComboBox CalibrationPeriod;
        protected ITTLabel labelBarcode;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            NeedMaintenance = (ITTCheckBox)AddControl(new Guid("b15bb7af-d738-4f0a-a480-da32f406d8ba"));
            NeedCalibration = (ITTCheckBox)AddControl(new Guid("232077a0-00ef-4f14-8345-844d2a585454"));
            labelNameSites = (ITTLabel)AddControl(new Guid("93d4d624-2bec-485c-861f-07fd41caecfe"));
            NameSites = (ITTTextBox)AddControl(new Guid("be16cc01-6c9d-4ef1-8dd9-4716b7c1a85f"));
            GuarantiePeriod = (ITTTextBox)AddControl(new Guid("4b7d9ef8-a333-4179-8415-7d29a286f30c"));
            UsePlaces = (ITTTextBox)AddControl(new Guid("0f08eb19-a824-48e2-8479-b62da4764088"));
            UseGoal = (ITTTextBox)AddControl(new Guid("cf487577-8047-4edd-8efc-bd7c0136e0ac"));
            ReferansNo = (ITTTextBox)AddControl(new Guid("79dca2ea-fdd5-4537-8766-203ba2a9f55b"));
            LifePeriod = (ITTTextBox)AddControl(new Guid("1d77975d-9768-4fc4-b5b7-5a487ac52c5d"));
            TechnicalSpecificationsNo = (ITTTextBox)AddControl(new Guid("c91c6736-aaee-4d5f-8cf9-a5f743fbc3e4"));
            MaterialCategory = (ITTTextBox)AddControl(new Guid("2b4fb4c7-0c33-48c6-9cde-a16c82653893"));
            Desciption = (ITTTextBox)AddControl(new Guid("278f4ef7-c020-456e-9cc0-4867065f13aa"));
            Barcode = (ITTTextBox)AddControl(new Guid("6d5af6f7-e665-48e0-a28e-ddb001c65025"));
            Name = (ITTTextBox)AddControl(new Guid("5f86cf5a-b562-451d-bc04-8e557efd1d64"));
            labelProducer = (ITTLabel)AddControl(new Guid("12450f39-4f13-411b-99f5-3b04147d32c8"));
            Producer = (ITTObjectListBox)AddControl(new Guid("a20e5935-876e-4918-b892-8b7d2dc6ce8c"));
            labelFixedAssetDetailModelDef = (ITTLabel)AddControl(new Guid("fc2f487c-16fd-4570-8ea8-44ee6701939d"));
            FixedAssetDetailModelDef = (ITTObjectListBox)AddControl(new Guid("0ce66037-0e56-4950-98f2-af2fb65fc59f"));
            labelFixedAssetDetailMarkDef = (ITTLabel)AddControl(new Guid("3104cdf2-10b7-4c92-a53b-f30c38e02887"));
            FixedAssetDetailMarkDef = (ITTObjectListBox)AddControl(new Guid("b7108194-3c41-4e13-84de-1a267b119861"));
            labelMaintenancePeriod = (ITTLabel)AddControl(new Guid("c80c2dbf-e454-4840-840f-a9ea88890cae"));
            MaintenancePeriod = (ITTEnumComboBox)AddControl(new Guid("962018df-9a1e-4091-88f1-b17459bcb3fa"));
            labelGuarantiePeriod = (ITTLabel)AddControl(new Guid("98b1e28e-27cd-47b8-8793-316d87e2de9e"));
            labelUsePlaces = (ITTLabel)AddControl(new Guid("f4a43c4a-229a-4259-8dc8-792927fae783"));
            labelUseGoal = (ITTLabel)AddControl(new Guid("2b61ed02-bf58-4c51-acee-985e4699c85f"));
            labelReferansNo = (ITTLabel)AddControl(new Guid("93606d68-0402-4f84-8fdd-a60493a4bc6b"));
            labelGuarantyStartDate = (ITTLabel)AddControl(new Guid("f5f816a1-3d22-4f4e-be99-885d0fd5b18e"));
            GuarantyStartDate = (ITTDateTimePicker)AddControl(new Guid("7ba15edf-ade1-471f-8155-7e5c1d797054"));
            labelLifePeriod = (ITTLabel)AddControl(new Guid("322cc9f0-dbc2-4d07-a35e-b199ac38d222"));
            labelTechnicalSpecificationsNo = (ITTLabel)AddControl(new Guid("6e710e49-71bc-4cb1-b6e7-fbf2f5094501"));
            labelMaterialCategory = (ITTLabel)AddControl(new Guid("e6483daa-b014-40ad-910a-26b25c410b8d"));
            labelDesciption = (ITTLabel)AddControl(new Guid("fa36cf3e-d87d-46af-ab34-5a58ee468ae7"));
            labelCalibrationPeriod = (ITTLabel)AddControl(new Guid("7805b994-48e5-438c-a892-e391e1e5505a"));
            CalibrationPeriod = (ITTEnumComboBox)AddControl(new Guid("cd59beab-ae4f-46fc-a848-43c5c9fc99e6"));
            labelBarcode = (ITTLabel)AddControl(new Guid("4009eb16-1d37-463a-be36-2e719a3e3758"));
            labelName = (ITTLabel)AddControl(new Guid("9294b45a-c883-43fe-bbb4-d8760763779b"));
            base.InitializeControls();
        }

        public SetSystemUnitDefinitionForm() : base("SETSYSTEMUNITDEFINITION", "SetSystemUnitDefinitionForm")
        {
        }

        protected SetSystemUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}