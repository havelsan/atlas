
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
    /// Teslim Tesellüm[Stok Numaralı]
    /// </summary>
    public partial class MaterialDeliveryForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialRepair _MaterialRepair
        {
            get { return (TTObjectClasses.MaterialRepair)_ttObject; }
        }

        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox DelivererUser;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelRequestNO;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTObjectListBox ResponsibleWorkShopUser;
        protected ITTLabel labelResponsibleWorkShopUser;
        override protected void InitializeControls()
        {
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("744d3e9f-825b-45cf-8a60-b9a7a50e6ff3"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("19aeb0a3-7778-49f0-b443-ba136ded40db"));
            RequestNO = (ITTTextBox)AddControl(new Guid("eabd7b0b-7f72-47e9-af86-0cbff547702a"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("99754d17-4e6c-4c7f-97aa-7a19f15269ea"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("3fe28871-a266-4e0e-93fd-03733aa7510f"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("5d0a0547-6e03-4051-8d38-e827e2a4e2a7"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("f59150c9-a4f7-41fd-810c-83b849f0c0cf"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("93bc9d45-129b-4f0b-8604-5db3508cfa38"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("8a65ba8b-20c2-48b1-9c1a-1b88d36352b2"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("15cd7dcb-d19e-4ba0-ab93-2209b1453316"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("c55aebc3-132f-409d-a11b-0d85a8f63ede"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("2a704176-ac98-461e-b66b-76e4bfabc3e1"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("2c1bd5f8-4d84-47a8-8516-cac2fe57b212"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("e004a695-8ef1-4c4c-a00a-223db3361a6e"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("80f67c9c-7374-4bfc-a0ac-2ed5be6e0e52"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("8a43d1b2-9ddd-4be1-ba48-9571867367a0"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("0639dab2-afad-4fb0-84c0-4fc9500fa963"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("cd12cb21-56d7-4578-94bc-e163c1210f4a"));
            labelFromResource = (ITTLabel)AddControl(new Guid("96f2361c-0171-463a-90af-a8b56dd9464a"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("87dc1150-4d68-4a7d-bda6-d020a16c4740"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("66b2f535-4d40-4f2c-9d80-cc6f920bbc5b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("5a6442ed-f913-4717-9cd7-deabc684a1a1"));
            DelivererUser = (ITTObjectListBox)AddControl(new Guid("4d867b5d-402e-46d3-8f44-c80a5488e4f4"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("b36cf79b-42ff-4732-a32f-0ff3ac8c8787"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("7e72568a-bd85-48d3-9fc5-e77af07dff3a"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("e63ed7b5-db22-4dbd-87ac-4fc219ce50d8"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("c8df9008-7ad1-4981-84af-e12fe9764c24"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("c34794d1-f07d-4764-86b9-69b9233a7cb9"));
            ResponsibleWorkShopUser = (ITTObjectListBox)AddControl(new Guid("f30548a3-1da1-4d37-92c2-d9cc1d23efc6"));
            labelResponsibleWorkShopUser = (ITTLabel)AddControl(new Guid("f2ffa28b-5ca1-4b1f-8c07-5cab4e66215b"));
            base.InitializeControls();
        }

        public MaterialDeliveryForm() : base("MATERIALREPAIR", "MaterialDeliveryForm")
        {
        }

        protected MaterialDeliveryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}