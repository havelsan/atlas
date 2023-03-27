
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
    /// İlk Değerlendirme
    /// </summary>
    public partial class StageApprovalForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTObjectListBox WorkShopList;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel9;
        protected ITTLabel GuaranyStatuslabel;
        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker deliveryDate;
        protected ITTTextBox tttextbox3;
        protected ITTLabel labelDescription;
        protected ITTLabel labelFromResource;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel1;
        protected ITTTextBox RequestNO;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTTextBox Description;
        protected ITTObjectListBox Section;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelRequestNO;
        protected ITTLabel lblDeliveryDate;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FixedAsset;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelToResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTObjectListBox FromResource;
        protected ITTObjectListBox Stage;
        override protected void InitializeControls()
        {
            WorkShopList = (ITTObjectListBox)AddControl(new Guid("7fd27470-4b84-49c4-84bf-446b87eb5669"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("75270e39-5a42-4107-a2bb-1af03e4d1db6"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("840dcaaa-9260-4103-80c0-cad3d34aed94"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("40d64471-3945-47e9-8cf8-6c6781cf9f2e"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("3c936d7b-d561-465b-a635-30c5979292eb"));
            GuaranyStatuslabel = (ITTLabel)AddControl(new Guid("67004abe-1ab0-4f5f-a755-9039762d41ab"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("8b8274c4-5e64-4f13-8d22-04c574e449ce"));
            deliveryDate = (ITTDateTimePicker)AddControl(new Guid("ea77285b-eb92-4315-8c39-12c2f09d5525"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("7a1ca881-cde1-4073-847f-237531ba7a25"));
            labelDescription = (ITTLabel)AddControl(new Guid("f4724c2c-d6ac-4ae8-879e-466f99957f22"));
            labelFromResource = (ITTLabel)AddControl(new Guid("a86a6d3d-6bd1-426b-a9ec-4ae0dac2f1ac"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("98c068a5-7992-4cc2-84c3-68d8ac746ba7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("29c3442e-bc85-462b-ba20-6ccf6c338631"));
            RequestNO = (ITTTextBox)AddControl(new Guid("51c354a3-773c-45ca-943d-75766c6d59fb"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("38356485-bbfd-48a9-8a98-78170ca35282"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("4bcc44a8-8501-4613-b7a5-5fea584b497b"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("99da70a4-b78e-4125-aecf-6f14cccab482"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("5377b120-e954-4c12-aaa7-c7969be9a001"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("0f9b895b-e941-4186-bfaf-4a554de8376d"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("e3310354-dc9c-4c98-9f86-0fd271b75916"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("ab2c9710-4043-45b5-b91c-a46783a443c5"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("1c895ad1-18a8-4a10-8af1-138866d4a44e"));
            Description = (ITTTextBox)AddControl(new Guid("69849924-24c2-476e-a4ed-7d29d7bf7ed6"));
            Section = (ITTObjectListBox)AddControl(new Guid("be9c0e1c-47c1-4f03-a05c-8565dedf72ab"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("3c25bfea-5e9e-4fab-8d64-8a56c36c47ad"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("40d22f1f-80bc-4198-a41f-8af508be0334"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("c66b076e-d9a4-42c8-b5a8-8cedc6e590cd"));
            lblDeliveryDate = (ITTLabel)AddControl(new Guid("0e5cd26b-bcc8-4911-9999-8e8ddb319ac3"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("59628e33-b59f-40df-8e9e-97f192c84ab6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("8b6c0764-58b7-48a0-8d5a-9bc10e0bce17"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("f26fb982-62c8-4dcb-ba6a-9d4d1c5f5fc4"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("ff9d0076-f458-41e4-a0b3-caaea5381246"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("17aace53-5ed4-4245-9b6e-cf62dc98cab5"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("b8d19ab9-dc43-44b4-ac1f-d5d5704ce497"));
            labelToResource = (ITTLabel)AddControl(new Guid("46a3d89e-9f12-4000-847f-e311a931838e"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("2f23c402-ef9c-4e15-99a4-e93e87eab823"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("bb2d7bd9-0049-4864-a905-f5ece46ebc60"));
            Stage = (ITTObjectListBox)AddControl(new Guid("268e5a0e-55b1-4dc3-9874-0c6ec7321ede"));
            base.InitializeControls();
        }

        public StageApprovalForm() : base("REPAIR", "StageApprovalForm")
        {
        }

        protected StageApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}