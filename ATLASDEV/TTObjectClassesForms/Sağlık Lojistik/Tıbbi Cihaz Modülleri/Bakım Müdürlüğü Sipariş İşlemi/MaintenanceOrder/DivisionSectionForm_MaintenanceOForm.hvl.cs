
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
    /// Sipariş Açma
    /// </summary>
    public partial class DivisionSectionForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel5;
        protected ITTMaskedTextBox RequestNO;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox OrderNO;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox ManufacturingAmount;
        protected ITTTextBox SpecialWorkAmount;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox OrderTypeList;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker CheckDate;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelOrderNO;
        protected ITTLabel labelID;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker OrderDate;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox DivisionSection;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox ResDivision;
        protected ITTLabel labelResDivision;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel labelResponsibleUser;
        protected ITTObjectListBox ResponsibleUser;
        protected ITTLabel labelWorkShop;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelManufacturingAmount;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelSpecialWorkAmount;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("0678634e-4431-42dc-a70f-3f5ec72ee776"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("d4148548-3881-4843-aebb-183ca3d65dd4"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("25017c8a-0d40-4e60-a01e-7e34adcf67eb"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("21bd3273-ba2a-4891-9256-136195f0853f"));
            RequestNO = (ITTMaskedTextBox)AddControl(new Guid("e8124688-924f-47f3-b934-dde9baddd97c"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("8aad5b7e-7615-44c4-b442-ada64fa90fce"));
            OrderNO = (ITTTextBox)AddControl(new Guid("38a6747c-17b2-49dc-944e-8765d5e26bdc"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("944aeee0-71cc-4e68-9411-b90fbb46e65f"));
            ManufacturingAmount = (ITTTextBox)AddControl(new Guid("40c2e9ce-4074-471f-bd71-d3c5a5327136"));
            SpecialWorkAmount = (ITTTextBox)AddControl(new Guid("5826815b-98c3-4280-8902-7034fe12c9a3"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6680f7d5-53b7-491d-8a4b-279ac7eda9ae"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("5d401f04-4f3c-4bf3-b27c-90da31eccba2"));
            labelOrderName = (ITTLabel)AddControl(new Guid("9df15b57-0653-4c22-8a59-ace24e4ae8e5"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f2bb6819-6b8c-402e-a359-275a87368354"));
            CheckDate = (ITTDateTimePicker)AddControl(new Guid("a0db8ed3-ff0e-42cc-b31c-45ea3ace84df"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("1a66123a-b2a5-4d79-8d9f-ee69b35066f5"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("7f4becb7-0c6e-449a-b597-b33b667c396f"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("890788cc-3717-474f-b6ae-5522b36e589f"));
            labelID = (ITTLabel)AddControl(new Guid("2879985e-7785-4b49-99f4-ddaad0ab55ed"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("4df564f8-fc0a-4b9c-b414-d88cd80c7635"));
            labelFromResource = (ITTLabel)AddControl(new Guid("c3bb1d1c-ea0d-4c0f-91f0-46e88eca9c2e"));
            OrderDate = (ITTDateTimePicker)AddControl(new Guid("d939ba75-9472-4d18-89eb-c08b58381de1"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("9e109a28-db99-4932-8008-83c12672d172"));
            labelActionDate = (ITTLabel)AddControl(new Guid("e8189061-74ce-4d57-92bf-0126480326f7"));
            DivisionSection = (ITTObjectListBox)AddControl(new Guid("87d1eb43-f2e2-4d7c-af17-8f4cec26db15"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("161aa69a-4508-4118-9739-db290f6b0f78"));
            ResDivision = (ITTObjectListBox)AddControl(new Guid("52a3a8f1-95c3-4e61-bd0c-7c9932fd3249"));
            labelResDivision = (ITTLabel)AddControl(new Guid("2079aff1-496f-44a8-9e25-38e25caba2b8"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("2c0043e2-b129-4871-bd40-bfa6c2c6cf6b"));
            labelResponsibleUser = (ITTLabel)AddControl(new Guid("69a4ef35-c64a-44fd-9f39-a40ae7fea5b9"));
            ResponsibleUser = (ITTObjectListBox)AddControl(new Guid("45f09d7c-bed5-45b1-b7e8-481e46bf44e6"));
            labelWorkShop = (ITTLabel)AddControl(new Guid("b4a9ea7b-a201-49e0-bdb7-61cd988d8858"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("90ef262b-15b3-4550-80f2-7e86c23d2307"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("120ee7e2-95a4-439a-be44-585896ebb3b3"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("abd05878-f0a1-4132-a9d9-234a5fa78f11"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("cb126e67-b05e-49a4-b792-8d51c2fa4a75"));
            labelManufacturingAmount = (ITTLabel)AddControl(new Guid("a99dfd66-deda-472f-b741-767d5a1956d1"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e14ee02d-fa21-4638-9e0f-efaa6c51e48b"));
            labelSpecialWorkAmount = (ITTLabel)AddControl(new Guid("e7e1535b-1f3e-4ae3-a882-c980b4d848e2"));
            base.InitializeControls();
        }

        public DivisionSectionForm_MaintenanceO() : base("MAINTENANCEORDER", "DivisionSectionForm_MaintenanceO")
        {
        }

        protected DivisionSectionForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}