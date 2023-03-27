
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
    /// İş İstek
    /// </summary>
    public partial class CMRActionRequestForm : CMRActionBaseForm
    {
    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek
    /// </summary>
        protected TTObjectClasses.CMRActionRequest _CMRActionRequest
        {
            get { return (TTObjectClasses.CMRActionRequest)_ttObject; }
        }

        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTTextBox FaultDescription;
        protected ITTTextBox UserTel;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTLabel labelFixedAssetType;
        protected ITTLabel labelUserTel;
        protected ITTObjectListBox DeviceUser;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelDeviceUser;
        protected ITTEnumComboBox FixedAssetType;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage UserParameterTabPage;
        protected ITTGrid UserMaintenances;
        protected ITTListBoxColumn Parameter;
        protected ITTCheckBoxColumn Checked;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage ContentsTabPage;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn ContentDistType;
        protected ITTTextBoxColumn Comments;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox SenderSection;
        protected ITTLabel labelSenderSection;
        protected ITTEnumComboBox RequestType;
        protected ITTLabel ttlabel1;
        protected ITTLabel GuaranyStatuslabel;
        override protected void InitializeControls()
        {
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("18030f81-f76e-4b14-8f22-81debdf31a04"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("69d83b1a-ec8f-4d4a-b4da-f3567943e58c"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("d939f98a-b7dc-4e8b-87b2-d21c2a77b86d"));
            FaultDescription = (ITTTextBox)AddControl(new Guid("13492b14-82ff-462a-b6c8-1559671197f5"));
            UserTel = (ITTTextBox)AddControl(new Guid("37c7db4d-afa9-4928-8157-ae1eeb2019fc"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("47207289-6953-4801-ad67-2ccd047e8980"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("064ce849-21d1-4ce8-bcc3-defef15adc1a"));
            labelFixedAssetType = (ITTLabel)AddControl(new Guid("acbd5d39-b142-4982-a8db-f512e646f42a"));
            labelUserTel = (ITTLabel)AddControl(new Guid("93c0b3ca-3b48-4aa3-a0c6-09b6c15b6930"));
            DeviceUser = (ITTObjectListBox)AddControl(new Guid("955a822b-532b-4373-858c-084d26f97771"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("bb81cdba-843e-41dc-b9c9-4d4dd9ffb512"));
            labelDeviceUser = (ITTLabel)AddControl(new Guid("7b10cc42-9ebe-4558-a509-b2c106762f70"));
            FixedAssetType = (ITTEnumComboBox)AddControl(new Guid("3426ac3a-96f0-42bc-b221-d5a5cff2aaa2"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("ba5c4838-3c64-4594-8389-c5ef6acdabc7"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("3ceae1e6-5bdc-4b2a-8d1a-3bd601ab108a"));
            UserParameterTabPage = (ITTTabPage)AddControl(new Guid("75840407-f337-4154-83d8-d0c5e3eded7c"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("85065284-32cd-4e5d-bb49-f8e5b7c97425"));
            Parameter = (ITTListBoxColumn)AddControl(new Guid("b660e7b1-c576-4c8f-a08a-90a36be249ca"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("2829f37b-df7b-482b-9ded-dc3dac0d888a"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("d39568c7-e332-4161-88c2-5829aa55c317"));
            ContentsTabPage = (ITTTabPage)AddControl(new Guid("56562ef2-0fea-4a7b-8396-8f4ddfa79a12"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("be5cf734-af75-45a1-8741-ac12239e245e"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("4f992e26-90b1-4036-9f90-e46cf2b8e338"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("f2ee673e-4f70-45a0-bb38-b95830c16156"));
            ContentDistType = (ITTListBoxColumn)AddControl(new Guid("85ad8b83-733b-4622-947c-80afa9bec60c"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("6bdc0a70-3d5e-480e-bb05-347809015ba7"));
            RequestNO = (ITTTextBox)AddControl(new Guid("c1c856cd-9a84-491e-83d4-9b955560cf31"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("2b085395-bd6e-4d0e-afa6-dc960274265d"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("b2de34e4-2cbe-4ef9-b58d-9751ed437d62"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("9d7606fb-3187-4ffe-8282-94dec20b1eeb"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("70c2e38c-a887-4f5c-b09a-7b824372d848"));
            labelSenderSection = (ITTLabel)AddControl(new Guid("f94513d5-1d0f-4165-b5b9-24d39541351c"));
            RequestType = (ITTEnumComboBox)AddControl(new Guid("e29fd471-148d-4f8f-8564-148a8091eaf5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("02bfb119-d69c-4c98-a848-07d92b414274"));
            GuaranyStatuslabel = (ITTLabel)AddControl(new Guid("ab00a3bc-f231-467e-b6cb-6d81e8c53440"));
            base.InitializeControls();
        }

        public CMRActionRequestForm() : base("CMRACTIONREQUEST", "CMRActionRequestForm")
        {
        }

        protected CMRActionRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}