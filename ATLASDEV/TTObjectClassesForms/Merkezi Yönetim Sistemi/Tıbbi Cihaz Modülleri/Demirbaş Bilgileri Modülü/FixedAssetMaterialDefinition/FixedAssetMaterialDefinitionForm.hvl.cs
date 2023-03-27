
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
    public partial class FixedAssetMaterialDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Demirbaş Bilgileri Tanımlama
    /// </summary>
        protected TTObjectClasses.FixedAssetMaterialDefinition _FixedAssetMaterialDefinition
        {
            get { return (TTObjectClasses.FixedAssetMaterialDefinition)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ContentsTabpage;
        protected ITTGrid Contents;
        protected ITTTextBoxColumn ContentName;
        protected ITTTextBoxColumn ContentAmount;
        protected ITTListBoxColumn ContentDistributionType;
        protected ITTTabPage PictureTabpage;
        protected ITTPictureBoxControl ttpictureboxcontrol1;
        protected ITTTabPage GuarantyDescriptionTabpage;
        protected ITTRichTextBoxControl GuarantyDescription;
        protected ITTTextBox SerialNumber;
        protected ITTTextBox Model;
        protected ITTTextBox Description;
        protected ITTTextBox Mark;
        protected ITTTextBox FixedAssetNO;
        protected ITTTextBox Power;
        protected ITTTextBox Frequency;
        protected ITTTextBox Voltage;
        protected ITTTextBox TMKNO;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel CalibrationStatusLabel;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox objFixedAssetDefinition;
        protected ITTLabel labelGuarantyStartDate;
        protected ITTLabel labelSerialNumber;
        protected ITTLabel labelFixedAssetNO;
        protected ITTLabel labelModel;
        protected ITTDateTimePicker GuarantyEndDate;
        protected ITTDateTimePicker GuarantyStartDate;
        protected ITTLabel labelDescription;
        protected ITTLabel labelMark;
        protected ITTLabel labelGuarantyEndDate;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker ProductionDate;
        protected ITTLabel labelProductionDate;
        protected ITTLabel labelPower;
        protected ITTLabel labelFrequency;
        protected ITTLabel labelVoltage;
        protected ITTEnumComboBox Status;
        protected ITTLabel labelStatus;
        protected ITTLabel labelTMKNO;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f23982ce-3fc6-4586-9c46-78741905bbf1"));
            ContentsTabpage = (ITTTabPage)AddControl(new Guid("e20f9dfd-edd4-437f-9b71-8cc76eab8249"));
            Contents = (ITTGrid)AddControl(new Guid("ae5d4163-c55e-4697-92d9-3ad0f284576e"));
            ContentName = (ITTTextBoxColumn)AddControl(new Guid("e5a64105-ef42-4df3-9062-e894c2afc5fa"));
            ContentAmount = (ITTTextBoxColumn)AddControl(new Guid("1466f767-b74f-42cc-bcc7-85f554a406f3"));
            ContentDistributionType = (ITTListBoxColumn)AddControl(new Guid("bdbf94b0-135d-4323-831c-68eadcb1cd99"));
            PictureTabpage = (ITTTabPage)AddControl(new Guid("41139381-92fc-4182-9b2b-d211d7bc9d9f"));
            ttpictureboxcontrol1 = (ITTPictureBoxControl)AddControl(new Guid("8e73ec06-dc66-42ab-9a4d-8cb5d3d58e2c"));
            GuarantyDescriptionTabpage = (ITTTabPage)AddControl(new Guid("8bdea4a7-3830-45a1-8245-9699c0468e4e"));
            GuarantyDescription = (ITTRichTextBoxControl)AddControl(new Guid("e1cf6fc8-9444-4ece-881f-140eec23c899"));
            SerialNumber = (ITTTextBox)AddControl(new Guid("63cd29da-1a54-44a4-bc29-25e2eaf41126"));
            Model = (ITTTextBox)AddControl(new Guid("12ef728f-87c6-4255-ae22-3e3d03c1ffd4"));
            Description = (ITTTextBox)AddControl(new Guid("92efafe3-1a75-43d5-84d2-831a7b97af11"));
            Mark = (ITTTextBox)AddControl(new Guid("a0cb363f-fe7a-4801-b1d5-baec7411dd4b"));
            FixedAssetNO = (ITTTextBox)AddControl(new Guid("dd6098fc-80e7-4878-aa2a-f7da47eecc85"));
            Power = (ITTTextBox)AddControl(new Guid("073e4c0d-66f2-4261-ba56-c30a4860bc9c"));
            Frequency = (ITTTextBox)AddControl(new Guid("f29971b1-d75e-4131-b56b-54dd891201fb"));
            Voltage = (ITTTextBox)AddControl(new Guid("3c36c4c2-59b6-47e2-8d2a-5b4644e78872"));
            TMKNO = (ITTTextBox)AddControl(new Guid("b9f6a185-ac1b-45c8-b3b7-35f4990abd34"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("f1d4a7a8-3d58-437e-b1b1-0a7ea389f2b8"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("959ec0e7-97dc-4bb5-b912-aca12f20b074"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("58d33dcd-1ffc-40dc-a08e-16ecf63278d2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("a97bbf1c-ce45-4373-84e9-46c1bbfe8d4f"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("9d3748e6-891d-41cb-9ed0-782744c9107e"));
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("9f36d191-03a1-4aa6-9bdc-2c70334f1c51"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("af54912f-4656-4ba0-b40d-60d82d1e5df2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("199b6656-82d1-4a72-be23-7f73a2f11d56"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("43604ff4-3da6-47d7-933b-12546fe99cb2"));
            objFixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("2a0ecf7d-c3e7-4d86-bd27-766135ade224"));
            labelGuarantyStartDate = (ITTLabel)AddControl(new Guid("f8d54ee5-385d-4f18-940f-0681b19d2168"));
            labelSerialNumber = (ITTLabel)AddControl(new Guid("dfa9ccdf-a5ab-4251-8065-1a3969c9638b"));
            labelFixedAssetNO = (ITTLabel)AddControl(new Guid("8be6d2de-95be-4b8c-bbe6-1e53926a310d"));
            labelModel = (ITTLabel)AddControl(new Guid("e897292c-0601-4917-8c30-24f205e1bb65"));
            GuarantyEndDate = (ITTDateTimePicker)AddControl(new Guid("ddf2f56e-34b1-4b3d-b464-2ff7ce682834"));
            GuarantyStartDate = (ITTDateTimePicker)AddControl(new Guid("23b11866-dae7-47f4-beff-43e11ab8ba76"));
            labelDescription = (ITTLabel)AddControl(new Guid("8e76c531-2961-45ab-8506-624859f3e0fc"));
            labelMark = (ITTLabel)AddControl(new Guid("bb18207f-ae57-44ed-89da-7a841afbe4e5"));
            labelGuarantyEndDate = (ITTLabel)AddControl(new Guid("f7225e0f-d3bd-46c1-97d0-cddc320a50c4"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("46d44f36-3b4d-4aa1-85c2-4f1357b4c588"));
            ProductionDate = (ITTDateTimePicker)AddControl(new Guid("f6806aa3-e50d-4d9c-b93e-787b2daec861"));
            labelProductionDate = (ITTLabel)AddControl(new Guid("9291f67f-5fd5-45e4-a5b7-baa6a5008d4c"));
            labelPower = (ITTLabel)AddControl(new Guid("114bdfc6-b682-45db-ab66-46a3df4f6827"));
            labelFrequency = (ITTLabel)AddControl(new Guid("6196db85-f1d1-4b7d-b2d3-51072867b19f"));
            labelVoltage = (ITTLabel)AddControl(new Guid("c542f61b-efb9-4a43-8276-6aaa613c6e04"));
            Status = (ITTEnumComboBox)AddControl(new Guid("23987e87-4984-4a78-b847-1e22142eb0cd"));
            labelStatus = (ITTLabel)AddControl(new Guid("512ea68e-f0fc-4133-bc8f-31a53a73c8c9"));
            labelTMKNO = (ITTLabel)AddControl(new Guid("6f0ede69-afbf-449c-8c5d-a7aeda0bd6d2"));
            base.InitializeControls();
        }

        public FixedAssetMaterialDefinitionForm() : base("FIXEDASSETMATERIALDEFINITION", "FixedAssetMaterialDefinitionForm")
        {
        }

        protected FixedAssetMaterialDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}