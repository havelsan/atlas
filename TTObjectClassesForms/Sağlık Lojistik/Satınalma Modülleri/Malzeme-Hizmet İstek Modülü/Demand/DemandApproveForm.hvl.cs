
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
    /// Onay (Malzeme İsteği)
    /// </summary>
    public partial class DemandApproveForm : TTForm
    {
    /// <summary>
    /// Malzeme/Hizmet İstek modülü için ana sınıftır
    /// </summary>
        protected TTObjectClasses.Demand _Demand
        {
            get { return (TTObjectClasses.Demand)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ItemsGrid;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn ApprovedAmount;
        protected ITTTextBoxColumn StoreStocks;
        protected ITTTextBoxColumn Description2;
        protected ITTRichTextBoxControlColumn SpRefToAdMatters;
        protected ITTRichTextBoxControlColumn FeasibilityEtude;
        protected ITTListBoxColumn Patient;
        protected ITTTextBoxColumn TechnicalSpecificationNo;
        protected ITTGroupBox ttgroupbox2;
        protected ITTButton cmdApproveAll;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelID;
        protected ITTTextBox Description;
        protected ITTLabel labelDemandType;
        protected ITTDateTimePicker ActionDate;
        protected ITTEnumComboBox DemandType;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("b7aa2d2f-8c95-4c5d-aabc-85b211473730"));
            ItemsGrid = (ITTGrid)AddControl(new Guid("32a296b9-c602-41b6-92b3-58a6f2ec1296"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("870cbf37-488d-442e-a12a-b6aed59156de"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("71c25b87-c384-46e6-b244-e1a40a7ad740"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("d7381a22-7f77-4363-870a-06a737d40caf"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("3fda40d5-c2bc-4bfb-98ce-591c84332df5"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d55c2ae8-21ba-4b55-9eb1-ae3d33a7a8fc"));
            ApprovedAmount = (ITTTextBoxColumn)AddControl(new Guid("03d3bfef-3f11-4b58-86e1-224b58731b28"));
            StoreStocks = (ITTTextBoxColumn)AddControl(new Guid("7baf7c7a-5384-4805-bb92-35606fd102a0"));
            Description2 = (ITTTextBoxColumn)AddControl(new Guid("08adecbe-9623-47e8-a453-d300ec5d9e02"));
            SpRefToAdMatters = (ITTRichTextBoxControlColumn)AddControl(new Guid("e7e1904b-3242-484a-b698-b325740602da"));
            FeasibilityEtude = (ITTRichTextBoxControlColumn)AddControl(new Guid("43c0b9d9-87be-4996-bc1f-668fa73d853b"));
            Patient = (ITTListBoxColumn)AddControl(new Guid("c1b9c662-8002-4bab-9a4f-dcdc2ecc0770"));
            TechnicalSpecificationNo = (ITTTextBoxColumn)AddControl(new Guid("b518d644-f927-4bfb-82f3-fb186f2ee20c"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("6be2b736-26e9-4311-991b-3f926d62792f"));
            cmdApproveAll = (ITTButton)AddControl(new Guid("8a94b779-9199-41c1-bf65-7c8931936ce9"));
            labelDescription = (ITTLabel)AddControl(new Guid("84c1b0c1-583f-44aa-b7f4-ddaff839628c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7fa1f2e6-fdde-4839-976f-abbada590190"));
            labelActionDate = (ITTLabel)AddControl(new Guid("de84e612-8d54-498a-8d91-a175ba3fe5be"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("b1b9deae-433d-463d-b0ad-8142640fe823"));
            RequestNO = (ITTTextBox)AddControl(new Guid("357d7d18-b187-4d82-aa23-4d1cdf8d3d8d"));
            labelID = (ITTLabel)AddControl(new Guid("51c1f61c-3b3a-46f0-a5a6-9cf1cda04a3c"));
            Description = (ITTTextBox)AddControl(new Guid("44498f69-d5ca-46ea-8649-b15668367b71"));
            labelDemandType = (ITTLabel)AddControl(new Guid("a0921d29-584b-4b6f-a7ab-d43ea40c3a6e"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("0ca14cb0-cd86-4430-89d8-9c43d89b70e0"));
            DemandType = (ITTEnumComboBox)AddControl(new Guid("540cbf20-c06b-4458-afb1-8ac88f2f90bc"));
            base.InitializeControls();
        }

        public DemandApproveForm() : base("DEMAND", "DemandApproveForm")
        {
        }

        protected DemandApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}