
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
    /// Sipariş Genel İşlemleri
    /// </summary>
    public partial class SpecialWorkForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage3;
        protected ITTGrid RepairConsumedMaterials;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn SparePartMaterialDescription;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTabPage tttabpage4;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn UsedMaterial;
        protected ITTListBoxColumn UsedMaterialDistType;
        protected ITTTextBoxColumn RequestAmountForDepot;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn UsedAmount;
        protected ITTTabPage tttabpage5;
        protected ITTGrid UsedMaterialWorkSteps;
        protected ITTListBoxColumn WorkStepUsedMaterial;
        protected ITTListBoxColumn WorkStepUsedMaterialDistType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitAmout;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox RequestNO;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel11;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox RepairWorkLoad;
        protected ITTTextBox SpecialWorkAmount;
        protected ITTLabel labelSpecialWorkAmount;
        protected ITTLabel labelRepairWorkLoad;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox tttextbox4;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel10;
        protected ITTTextBox OrderNO;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox OrderTypeList;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelID;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelOrderNO;
        protected ITTLabel ttlabel1;
        protected ITTTabPage tttabpage2;
        protected ITTButton cmdForkWorkStep;
        protected ITTObjectListBox SenderSection;
        protected ITTTextBox tttextbox2;
        protected ITTGrid WorkStepsGrid;
        protected ITTListBoxColumn WorkShop;
        protected ITTListBoxColumn Personel;
        protected ITTTextBoxColumn Workload;
        protected ITTTextBoxColumn Comments;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel8;
        protected ITTToolStrip tttoolstrip1;
        protected ITTCheckBox chkOrderCompleted;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel7;
        override protected void InitializeControls()
        {
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("30b10b38-c0f5-46c3-a858-f9e6d6ce6b5b"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("66593061-6972-4e2c-9777-95336c0460d1"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("b333655a-fde9-4030-890c-12f26f554ab3"));
            Material = (ITTListBoxColumn)AddControl(new Guid("726addd9-f3bc-4314-a686-e2ed89674eed"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("96c1b87a-c091-437f-b823-b12f0af5131b"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("29ce509e-bb1d-4099-9e68-5e9805550ff1"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("c1c05174-2cc4-4d44-8042-fb1e013a07c0"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("88319224-08d7-4445-a9be-4e3db4269a09"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("4316b49b-cf6c-43ea-ab5b-c2eb545d300d"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("5691a16c-1698-45f4-9f59-d43e2a8cb55f"));
            UsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("8b92deee-458d-4b5c-9a02-a25a7e410adb"));
            RequestAmountForDepot = (ITTTextBoxColumn)AddControl(new Guid("244c08c8-59f1-4fd4-921c-281c54345ba0"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("4396f610-ca63-4e59-be35-b7e74f81829a"));
            UsedAmount = (ITTTextBoxColumn)AddControl(new Guid("080c43fb-3339-490d-99e1-e4ee3184dac2"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("6896e5dd-a783-4657-9466-44c453822ffc"));
            UsedMaterialWorkSteps = (ITTGrid)AddControl(new Guid("f46e31f7-c5e2-4380-9c49-fa27055f6b89"));
            WorkStepUsedMaterial = (ITTListBoxColumn)AddControl(new Guid("56c85694-2a90-42ef-a001-dc663ceefd5e"));
            WorkStepUsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("13931c96-9cf1-41a3-acc5-8878f83565cc"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d4f7a1ff-9cef-4fe0-acc8-02c19fd4689d"));
            UnitAmout = (ITTTextBoxColumn)AddControl(new Guid("bd707784-c094-4b64-a9e5-17cb81aa5633"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("abf60762-f4ed-4e2b-919c-d2209fd35869"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("65d3c80d-a499-4d5f-b5a5-35025e24ab49"));
            RequestNO = (ITTTextBox)AddControl(new Guid("b9a08d62-c65b-4e18-849d-f865cc1e23d4"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("f1c23783-a64c-4384-a0af-ae060c8dbf67"));
            labelActionDate = (ITTLabel)AddControl(new Guid("63dc85b1-b01c-4827-8340-2f783aa8c3c6"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("40dd80f5-495c-4701-af9f-9d215506c940"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("ee1a9396-cd5b-42b6-9536-3060f4cc8b36"));
            RepairWorkLoad = (ITTTextBox)AddControl(new Guid("5a870a4b-bd87-4d6b-b42c-745c0a8e3950"));
            SpecialWorkAmount = (ITTTextBox)AddControl(new Guid("e59e2bf6-3376-48ff-9eb5-d200d67f5277"));
            labelSpecialWorkAmount = (ITTLabel)AddControl(new Guid("4d2edf55-1f8f-473b-9586-d9be215eac48"));
            labelRepairWorkLoad = (ITTLabel)AddControl(new Guid("d22cc709-c44e-47e6-9de0-5638e1e2a9fb"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("eb3dc27a-9aed-4398-875a-843a5f865b3d"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("02cf6066-314d-4b04-9633-eabd6714a635"));
            labelOrderName = (ITTLabel)AddControl(new Guid("2d5a4e62-e274-440e-b845-9b80dcf7d362"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("aedf1e76-bb17-482a-b7da-231271415a3c"));
            OrderNO = (ITTTextBox)AddControl(new Guid("a03c8747-1349-43ce-8e97-cefb9a48a6ae"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("2ad6d4ec-14cd-4939-9863-878d28a6e8a8"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("0253a8f9-fb45-4020-bd7f-e5c941b89fc9"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("5808c0ba-9d7a-4deb-831d-c4d399b4bb42"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("483e303a-68b9-45ad-948e-ef09272ee7cc"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("c085b5c7-8f40-4c2d-99b3-70635f7ffbcb"));
            labelID = (ITTLabel)AddControl(new Guid("18f82e5f-cb72-4fd0-a344-4927e86d8218"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("b0f7f021-1440-40a7-ba8d-cfbd1d18b133"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("911cda2b-1fb0-4788-96fd-2ea3db8f9a0c"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("e827ba5d-7b3b-4cc2-a420-654dc411c956"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("50ba9eb2-24fc-45dd-88a6-ee250ac08863"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("437b8d3a-74cd-401d-8a79-280e55702abe"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("9b3bd8c5-34d2-46b1-97a2-f34ed8420ed8"));
            cmdForkWorkStep = (ITTButton)AddControl(new Guid("ae341953-f873-4e65-8a84-8556330a2918"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("4163cbc9-fe69-42a9-957c-0658f1ac7cbc"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("90a961a8-ae67-49b7-9cbf-3106c739169d"));
            WorkStepsGrid = (ITTGrid)AddControl(new Guid("238afbf8-280f-4dca-a5bf-ea04f6d0f63e"));
            WorkShop = (ITTListBoxColumn)AddControl(new Guid("13de57ae-586f-4c08-8344-0610fd540705"));
            Personel = (ITTListBoxColumn)AddControl(new Guid("61814c38-a081-442c-92ce-5fe7db465f11"));
            Workload = (ITTTextBoxColumn)AddControl(new Guid("118166bd-c6f3-485c-931f-970e6f398537"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("60e32bda-b8d7-44a8-9266-ff46b8d49013"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("39d22613-6e41-419d-a5a0-2c90c84201d2"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("c8df9957-b5f6-4649-a4e6-9d6a592ee16e"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("86cd449f-fe7a-46ab-b0f2-05295cfb2d30"));
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("cee20146-48ea-40e4-930b-ebd6f857257b"));
            chkOrderCompleted = (ITTCheckBox)AddControl(new Guid("5f30c9d4-fe0e-43df-9541-049c225149e5"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("1d677b75-9ffb-4857-9a59-5aaf746fa9d3"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("30e6331b-135a-4552-9cca-9aeb4dc8d32d"));
            base.InitializeControls();
        }

        public SpecialWorkForm_MaintenanceO() : base("MAINTENANCEORDER", "SpecialWorkForm_MaintenanceO")
        {
        }

        protected SpecialWorkForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}