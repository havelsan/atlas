
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
    /// Garanti Onarımı
    /// </summary>
    public partial class GuarantyRepairForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTButton cmdSupplierDef;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel labelRequestNO;
        protected ITTTextBox tttextbox1;
        protected ITTObjectListBox FromResource;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel2;
        protected ITTTextBox RequestNO;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount2;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTTextBox tttextbox3;
        protected ITTLabel labelDescription;
        protected ITTLabel labelFromResource;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker RequestDate;
        protected ITTEnumComboBox RepairPlace;
        protected ITTTextBox Description;
        protected ITTTextBox tttextbox4;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel ttlabel7;
        override protected void InitializeControls()
        {
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("7b65ed84-1836-4e1e-b1e1-710f774c9f98"));
            cmdSupplierDef = (ITTButton)AddControl(new Guid("9e49d094-2d93-430a-a797-ed6ca76e611f"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("cebb2ecf-ea8f-4364-be93-ef4ce511726a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("dadd0377-f8ee-460e-8a23-2d346abc6a87"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("a82c4ade-7699-4b43-a97a-6801fb2b39cf"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("763b4947-5a31-45d0-84b2-02ab0c7844e2"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("e2684ecb-d234-4353-a0e1-6b2be75d7647"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("9cd19d57-2845-4b53-851a-97659883db80"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("552d5c9f-b789-43d9-b35d-5b04e36b0426"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("d8906baf-8926-4cc1-91ef-57f437ce3bdc"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("6874256f-0078-4c05-8e44-ab35a7c5d8d7"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("af5ea65f-8856-47d1-ad64-b8c30de4cd76"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b92b5a89-cbf1-4db5-ae41-225c68d29278"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("3f3857d9-3103-4244-aac8-58b6a21ba946"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a2786d5e-9c4b-4bee-9d3f-7fa330fa4a5f"));
            RequestNO = (ITTTextBox)AddControl(new Guid("e79c642f-1698-45ca-8e13-d397192698bf"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("5a6cbb49-2b26-4373-b635-1afc0d2f960b"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("aba4ed5a-7820-4ee7-b089-52ae032bbad9"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("ab7b26f2-43a7-4bf0-8624-47105fe1b859"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("12786733-6d05-4650-8f64-b75b6105035d"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("a1e9b0a1-de98-48a8-b396-12c8658efddd"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("c3be68c8-08b9-4399-954f-5db86ebfa329"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("110f62df-a478-4bb9-93c5-d52df682ae70"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("f605abff-f038-4a0e-8109-8526de847331"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("11ef9889-815c-4b20-8c29-a3de7a850d11"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("aa078979-db1f-40a7-8eed-404ae14eba0e"));
            labelDescription = (ITTLabel)AddControl(new Guid("7bdf7a97-3c70-43fd-bd6a-54fe6bfd0aaa"));
            labelFromResource = (ITTLabel)AddControl(new Guid("4bc4e6ec-b19a-48df-8174-5401c2aaa49d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f7f445c6-ed92-470b-af83-37ee6a70515e"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("42600706-bb59-48e2-867f-78bddffd7dc3"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("17c938ad-de8e-41c7-88dc-0e70d828b1e5"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3d3f3f62-7104-4b7c-bd10-e081b9a26bbd"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("c9a03572-eb30-4e82-8229-7e09d2c32bb7"));
            Description = (ITTTextBox)AddControl(new Guid("66c92997-62bd-4d88-8df9-e16f0d98d66b"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("f86263d7-a059-4d21-949a-53321d7080eb"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("9c6de46b-5d30-4833-be4b-41e4cac21905"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("9ee2b887-8e80-44ff-82cc-efa68bd89f83"));
            base.InitializeControls();
        }

        public GuarantyRepairForm() : base("REPAIR", "GuarantyRepairForm")
        {
        }

        protected GuarantyRepairForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}