
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
    /// Ambalajlama İş İstek
    /// </summary>
    public partial class PackagingDepActionCompForm : TTForm
    {
    /// <summary>
    /// Ambalajlama İş İstek
    /// </summary>
        protected TTObjectClasses.PackagingDepartmentAction _PackagingDepartmentAction
        {
            get { return (TTObjectClasses.PackagingDepartmentAction)_ttObject; }
        }

        protected ITTButton cmdSectionRequirement;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid PackagingDepConsMaterials;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn DistType;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTabPage tttabpage2;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn ReqMat;
        protected ITTListBoxColumn ReqDistType;
        protected ITTTextBoxColumn ReqAmount;
        protected ITTTextBoxColumn SuppAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn Store;
        protected ITTLabel labelResDivision;
        protected ITTObjectListBox ResDivision;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelRequestNo;
        protected ITTTextBox RequestNo;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Result;
        protected ITTLabel labelResult;
        protected ITTGrid SectionRequirements;
        protected ITTTextBoxColumn StockActionID;
        protected ITTStateComboBoxColumn State;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            cmdSectionRequirement = (ITTButton)AddControl(new Guid("ae79aecf-521f-46ba-bbdb-640f53da097b"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("265c069c-0080-47fc-9705-9e9f85ad60b5"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("7b241208-20a2-4f73-a0f0-cc9592fcd6f9"));
            PackagingDepConsMaterials = (ITTGrid)AddControl(new Guid("914d65ff-1c74-44a8-a45e-f7387d603e72"));
            Material = (ITTListBoxColumn)AddControl(new Guid("7c5005fb-87b8-4a76-ba83-649b9533f47d"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("923049d3-5176-4e4d-9279-3b6f2978fb70"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("4e096c85-053d-4053-b68e-1559886f092a"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("0a9b2782-cfc0-45c2-a560-95f1b50fcba4"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("d58562cf-1e64-43d9-a14b-b8813345ca74"));
            ReqMat = (ITTListBoxColumn)AddControl(new Guid("851ce055-15eb-441c-a548-a7cb81a15cb9"));
            ReqDistType = (ITTListBoxColumn)AddControl(new Guid("8515aa39-2ff2-407d-8e06-b8a0576a3ce7"));
            ReqAmount = (ITTTextBoxColumn)AddControl(new Guid("a501569a-933f-415c-b827-2e2b98d1564d"));
            SuppAmount = (ITTTextBoxColumn)AddControl(new Guid("c9e7d0a9-24a4-416d-a067-7bcd03b6c73e"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("a27ffc88-1424-4fca-94fa-be09973ee0ad"));
            Store = (ITTListBoxColumn)AddControl(new Guid("c5b6a4be-ca8e-44ef-8431-15626b5e5467"));
            labelResDivision = (ITTLabel)AddControl(new Guid("23a6a0ca-5aa2-488e-a414-4ba330f4a8df"));
            ResDivision = (ITTObjectListBox)AddControl(new Guid("0cc70fa1-cc60-406c-b7c8-e5333727b5cc"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("61e48073-c959-4ed1-91cc-78904e80afbd"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("d0d6cac6-7cbf-41ab-bb00-36db6882712b"));
            labelStartDate = (ITTLabel)AddControl(new Guid("8467454c-5fb8-4c9b-ae0e-318b7ae5663e"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("72aad3e5-2d0b-40f0-a4ca-8a575156f955"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("55c28b5a-2463-4086-a124-ad3e305bd546"));
            RequestNo = (ITTTextBox)AddControl(new Guid("50175f5e-f450-4070-879c-a7ac5de0a8c9"));
            labelDescription = (ITTLabel)AddControl(new Guid("4b212a61-10b1-4572-8da9-74567decac7d"));
            Description = (ITTTextBox)AddControl(new Guid("d49f6434-44ef-4995-8f70-7c97a58574a1"));
            Result = (ITTTextBox)AddControl(new Guid("b8ec0e77-26f8-4f62-9b5d-51e08caae2ee"));
            labelResult = (ITTLabel)AddControl(new Guid("6bba58e0-ceb1-4ae9-a502-e9bbef2a64f1"));
            SectionRequirements = (ITTGrid)AddControl(new Guid("f3d08766-03d3-4e00-be7d-0a85a374cc49"));
            StockActionID = (ITTTextBoxColumn)AddControl(new Guid("4fc9621b-5fc4-4330-b82c-26f9b353dae4"));
            State = (ITTStateComboBoxColumn)AddControl(new Guid("08ee470f-7218-4baa-8e05-785ea4a41c37"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1df961cc-2452-4c01-a9ab-1fb4f4508d6f"));
            base.InitializeControls();
        }

        public PackagingDepActionCompForm() : base("PACKAGINGDEPARTMENTACTION", "PackagingDepActionCompForm")
        {
        }

        protected PackagingDepActionCompForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}