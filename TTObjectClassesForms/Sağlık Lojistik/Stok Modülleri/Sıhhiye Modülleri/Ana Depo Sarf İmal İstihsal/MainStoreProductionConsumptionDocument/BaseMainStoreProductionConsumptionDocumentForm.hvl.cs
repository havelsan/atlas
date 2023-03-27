
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
    /// Ana Depodan Sarf İmal İstihsal Belgesi 
    /// </summary>
    public partial class BaseMainStoreProductionConsumptionDocument : StockActionBaseForm
    {
    /// <summary>
    /// Ana Depodan Sarf İmal İstihsal Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.MainStoreProductionConsumptionDocument _MainStoreProductionConsumptionDocument
        {
            get { return (TTObjectClasses.MainStoreProductionConsumptionDocument)_ttObject; }
        }

        protected ITTTextBox STOCKACTIONID;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker TRANSACTIONDATE;
        protected ITTObjectListBox Store;
        protected ITTLabel LABELSTORE;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker EndDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel LABELSTOCKACTIONID;
        protected ITTLabel LABELTRANSACTIONDATE;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialOutTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn Existing;
        protected ITTTextBoxColumn Amount;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            STOCKACTIONID = (ITTTextBox)AddControl(new Guid("c12204e0-a0fa-4035-9dbf-df2bc18c9c52"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f5f84d8e-5359-42d2-ba88-4c2f65a5c9e6"));
            TRANSACTIONDATE = (ITTDateTimePicker)AddControl(new Guid("1971b763-c605-4cbf-9e61-2d0f75aa065c"));
            Store = (ITTObjectListBox)AddControl(new Guid("2c97308c-3509-4566-8b44-8890f6b93ea7"));
            LABELSTORE = (ITTLabel)AddControl(new Guid("1e834b19-e10e-4fb3-b013-c2771ab23c9c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6e629496-f39f-4b6a-a5b0-6a06d77654a9"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("3439ebe3-df8f-45f2-a82a-b7bb682f5b4a"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("dd369ab1-5da5-4691-b961-7e1891d9788e"));
            LABELSTOCKACTIONID = (ITTLabel)AddControl(new Guid("2b281d36-8802-4f8e-9f9a-aa9a9e094c7a"));
            LABELTRANSACTIONDATE = (ITTLabel)AddControl(new Guid("e0e48ed3-7925-40dd-ab5d-632a2bec3c6e"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("24219da3-787c-408a-a39e-b907fc3e4396"));
            MaterialOutTabPage = (ITTTabPage)AddControl(new Guid("ea5d3c37-66b4-4c59-b04b-b7026f3cb514"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("c872beef-98c0-45eb-b412-c05222b84249"));
            Material = (ITTListBoxColumn)AddControl(new Guid("d2d51c31-ffd0-4d68-9951-85511f2ceba9"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("dd28e29a-8b7a-45d6-a611-c3c9dad28fdf"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("094183e5-2101-4385-913a-ec904f3b79b6"));
            Existing = (ITTTextBoxColumn)AddControl(new Guid("10ec2c2f-992f-47c8-abe0-9662abf6c8a5"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("71250eae-0e63-4b9c-9f0d-6f35f0887fd7"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("d393feee-ed23-4eea-8139-cad751470ae7"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("93ac3c21-2536-4aee-8738-9e411ee6b7bf"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("bc4d7455-42c6-4dfb-b677-de9292acd98e"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("89a4407f-67ea-4bb1-8db0-dda987045dd0"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("d158e907-b028-49fb-8539-64ad1fa24e3a"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("e9a8f0bd-7c77-4ba8-a161-86aa06a708f0"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("51dd311f-4eaa-4263-9441-05cda5752502"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("a160e1ad-974f-427a-87c4-1e0a824bd11d"));
            Description = (ITTTextBox)AddControl(new Guid("ff052cf4-ae6c-4b05-8d66-001b6075e075"));
            base.InitializeControls();
        }

        public BaseMainStoreProductionConsumptionDocument() : base("MAINSTOREPRODUCTIONCONSUMPTIONDOCUMENT", "BaseMainStoreProductionConsumptionDocument")
        {
        }

        protected BaseMainStoreProductionConsumptionDocument(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}