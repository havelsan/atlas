
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
    /// Demirbaş Bilgileri
    /// </summary>
    public partial class CMRActionUpdateForm : TTForm
    {
    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek
    /// </summary>
        protected TTObjectClasses.CMRActionRequest _CMRActionRequest
        {
            get { return (TTObjectClasses.CMRActionRequest)_ttObject; }
        }

        protected ITTLabel labelVoltageFixedAssetMaterialDefinition;
        protected ITTTextBox VoltageFixedAssetMaterialDefinition;
        protected ITTTextBox SerialNumberFixedAssetMaterialDefinition;
        protected ITTTextBox PowerFixedAssetMaterialDefinition;
        protected ITTTextBox ModelFixedAssetMaterialDefinition;
        protected ITTTextBox MarkFixedAssetMaterialDefinition;
        protected ITTTextBox FrequencyFixedAssetMaterialDefinition;
        protected ITTTextBox FixedAssetNOFixedAssetMaterialDefinition;
        protected ITTLabel labelSerialNumberFixedAssetMaterialDefinition;
        protected ITTLabel labelProductionDateFixedAssetMaterialDefinition;
        protected ITTDateTimePicker ProductionDateFixedAssetMaterialDefinition;
        protected ITTLabel labelPowerFixedAssetMaterialDefinition;
        protected ITTLabel labelModelFixedAssetMaterialDefinition;
        protected ITTLabel labelMarkFixedAssetMaterialDefinition;
        protected ITTLabel labelGuarantyStartDateFixedAssetMaterialDefinition;
        protected ITTDateTimePicker GuarantyStartDateFixedAssetMaterialDefinition;
        protected ITTLabel labelGuarantyEndDateFixedAssetMaterialDefinition;
        protected ITTDateTimePicker GuarantyEndDateFixedAssetMaterialDefinition;
        protected ITTLabel labelFrequencyFixedAssetMaterialDefinition;
        protected ITTLabel labelFixedAssetNOFixedAssetMaterialDefinition;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        override protected void InitializeControls()
        {
            labelVoltageFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("821091d8-0733-4b49-a9b4-60bc3bc7fd3c"));
            VoltageFixedAssetMaterialDefinition = (ITTTextBox)AddControl(new Guid("49e2c3a8-6d6c-4b14-9cfb-f0fd1ff6f1d3"));
            SerialNumberFixedAssetMaterialDefinition = (ITTTextBox)AddControl(new Guid("ef40e0a1-ba7e-4f35-813c-5c7e9278ee4f"));
            PowerFixedAssetMaterialDefinition = (ITTTextBox)AddControl(new Guid("bea986de-65b0-4253-9505-b7264a2ef5a6"));
            ModelFixedAssetMaterialDefinition = (ITTTextBox)AddControl(new Guid("5fbcfa61-02ec-4cf2-a668-e3674def58d8"));
            MarkFixedAssetMaterialDefinition = (ITTTextBox)AddControl(new Guid("b42fc5e1-d104-45c2-a1a4-49490803c882"));
            FrequencyFixedAssetMaterialDefinition = (ITTTextBox)AddControl(new Guid("0fb6f4cb-79d2-486a-8d45-ce5754931022"));
            FixedAssetNOFixedAssetMaterialDefinition = (ITTTextBox)AddControl(new Guid("5645932b-7abf-4562-8694-cf099f6e0cf5"));
            labelSerialNumberFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("0ec39714-4946-44dc-97b0-6a98021c4fae"));
            labelProductionDateFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("a9a1a29f-60b7-4818-9e92-c919981853cd"));
            ProductionDateFixedAssetMaterialDefinition = (ITTDateTimePicker)AddControl(new Guid("712d8e53-1b4f-422f-b7fe-5d003b06a6e5"));
            labelPowerFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("1173edfb-83d7-450a-a9fa-0608bcb4a394"));
            labelModelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("28f4bf00-838a-4658-990d-8efb2bc0adac"));
            labelMarkFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("f53c502b-a225-4fc4-bb58-aab93c4e705d"));
            labelGuarantyStartDateFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("a18efce6-8167-4bbb-9228-3c5bd4f175a8"));
            GuarantyStartDateFixedAssetMaterialDefinition = (ITTDateTimePicker)AddControl(new Guid("45c66fab-eca6-4d7f-86eb-974f6ff45c99"));
            labelGuarantyEndDateFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("692a3173-d67c-49d9-9618-f0db723299a1"));
            GuarantyEndDateFixedAssetMaterialDefinition = (ITTDateTimePicker)AddControl(new Guid("f542c060-76b4-404c-8857-39f7acf6d14c"));
            labelFrequencyFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("9b431ba5-cc21-4a24-9387-5f5024b34ab3"));
            labelFixedAssetNOFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("7ff38cd5-12d3-4d78-a5dd-9ff1ee563ed3"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("10e5c60c-ac2f-40d2-837a-8ed770bba68f"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("3431065d-cb9c-4182-9246-68323c358cee"));
            base.InitializeControls();
        }

        public CMRActionUpdateForm() : base("CMRACTIONREQUEST", "CMRActionUpdateForm")
        {
        }

        protected CMRActionUpdateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}