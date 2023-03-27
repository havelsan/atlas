
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
    /// Üst Kademeye Sevk[Stok Numaralı]
    /// </summary>
    public partial class MaterialUpperStageForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialRepair _MaterialRepair
        {
            get { return (TTObjectClasses.MaterialRepair)_ttObject; }
        }

        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox RulStatus;
        protected ITTTextBox Description;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox4;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTLabel labelFromMilitaryUnit;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage UserMaintenanceTabPage;
        protected ITTGrid UserMaintenances;
        protected ITTListBoxColumn UserParameter;
        protected ITTCheckBoxColumn Checked;
        protected ITTTextBoxColumn UserDescription;
        protected ITTTabPage UnitMaintenanceTabPage;
        protected ITTGrid UnitMaintenances;
        protected ITTListBoxColumn UnitParameter;
        protected ITTCheckBoxColumn UnitChecked;
        protected ITTTextBoxColumn UnitDescription;
        protected ITTTabPage ContensTabPage;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTObjectListBox FixedAssetDefinition;
        override protected void InitializeControls()
        {
            RequestNO = (ITTTextBox)AddControl(new Guid("72bc1a0e-8503-481f-8122-6d478641050a"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("a438a3f6-f083-4f56-ba07-f2d47a5eecc0"));
            RulStatus = (ITTTextBox)AddControl(new Guid("2b40d518-9d1f-4f5a-b9ae-4c17fdd45d8f"));
            Description = (ITTTextBox)AddControl(new Guid("6f5ec0e4-698a-4963-8122-e9b853f70641"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("9edfe552-9847-487c-8deb-f3a02e0bbb57"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("df60d609-466f-4922-8c92-397b46f5767b"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("35b37122-41b1-44c7-a8b6-d66b53a26d54"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("16e73002-36a2-4a84-8483-17ab3a448759"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("0133780e-0683-4701-8f52-cf82922f5f8f"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("721366b6-061c-409b-94af-68c830068fa3"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("d6749bb5-a504-4354-8e2e-eb83a9c2a026"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("6ca8f93c-6403-4b43-b71b-ef49e2986676"));
            labelFromMilitaryUnit = (ITTLabel)AddControl(new Guid("2bfc5d61-ff19-4c38-905c-ad541590f2ae"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("082c0b37-e5a9-4446-b457-556eb830ecee"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("285f10ec-0d3a-4ef7-b291-8c9131aa5754"));
            labelFromResource = (ITTLabel)AddControl(new Guid("d218b060-b222-424f-ad86-b81696105f24"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("9e91ca20-1c6b-4240-afd0-69c765aa327e"));
            labelToResource = (ITTLabel)AddControl(new Guid("dcf8c2a2-7e2a-44e0-91ee-2a017369c8b6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("7033c5d0-f199-480a-8929-4842b643158b"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("0a09e430-5ac9-40c9-b865-2578031f7b72"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3e7425c8-4dcb-4471-8957-7759b4153cf7"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("d8a3add0-d258-4c14-8a69-0b0512ffbf1a"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("3974aef8-da95-484d-9ae3-6470151b1c5f"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("c1be8a8e-4294-4c4a-a9e3-11fdda6ee3a2"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("b5d19d96-ff52-4bf4-80a5-720af9cd8600"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("355e2417-3999-4d31-be6f-894156f83312"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("d2981018-b9c2-4fda-bf5e-50423e193a7b"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("7cd05260-8809-4a64-873e-0fc6cc2cdece"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("fd909de4-782e-4bb9-9bd1-4c89837b4428"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("c31306e2-1f95-48f5-8199-61aff29bc530"));
            labelDescription = (ITTLabel)AddControl(new Guid("a4c7d902-863c-4ee6-ba5a-74fbd4097ac7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1fc8bd69-4d66-429c-9f5b-ab62e70fc56d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1154b67d-0900-4b18-8c6c-722c39af85f2"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("86820b0c-173e-40fc-b8a5-36b40290e588"));
            UserMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("55e9317f-414b-4ae7-83cc-dec5b4690c5f"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("6b68aa66-1727-4899-bbf6-27ea3d26efa1"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("96a6b2af-45e5-4a2a-85fe-ce631a3ccd8d"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("7ae915c1-9720-43d7-8121-f7ff138d4b80"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("32e6e8d3-3a70-4352-a1b0-c95ae9fa91de"));
            UnitMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("93335348-d92e-45f2-8afc-a7db2c0e93e2"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("a01da375-05ff-4063-8112-fc6cf1e1448a"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("fa9fbcdc-c6b7-4049-9d8f-75fd696c5a2f"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("13952de6-0b31-4c04-a8f7-3b3309bfab7a"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("a5770bbb-b0af-490f-8d57-fc3b5e020a0f"));
            ContensTabPage = (ITTTabPage)AddControl(new Guid("9384b323-3778-4ffc-a3d6-5039a1efe384"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("c8f4ba7c-22c3-4488-ae1c-d7a35f0a5ffe"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("4bc7f1d7-a8d1-438e-b623-5da612a329a6"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("87319bf0-81bf-4a1f-a066-adf45a1fd6ae"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("bc36c65e-532d-4503-ab8d-2c333569873b"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("3e17423b-9def-49f8-9fcd-e4385e2c32fb"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("ca24dfcb-f96a-4be8-b563-3f1d647860d3"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("c0809143-c6e2-4dbf-90a1-a2b1d08bc32d"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("18a313a3-4f9c-4c47-8584-b6f587ca23df"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("e021d7e4-088c-45f8-9884-55027c878120"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("a8a02b98-a6d2-44b5-874a-228f3428d484"));
            base.InitializeControls();
        }

        public MaterialUpperStageForm() : base("MATERIALREPAIR", "MaterialUpperStageForm")
        {
        }

        protected MaterialUpperStageForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}