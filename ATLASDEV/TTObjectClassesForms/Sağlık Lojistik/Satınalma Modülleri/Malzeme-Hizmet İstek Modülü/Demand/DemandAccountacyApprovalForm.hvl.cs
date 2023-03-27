
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
    /// Saymanlık Onay
    /// </summary>
    public partial class DemandAccountacyApprovalForm : TTForm
    {
    /// <summary>
    /// Malzeme/Hizmet İstek modülü için ana sınıftır
    /// </summary>
        protected TTObjectClasses.Demand _Demand
        {
            get { return (TTObjectClasses.Demand)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ItemsGrid;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn ApprovedAmount;
        protected ITTTextBoxColumn StoreStocks;
        protected ITTTextBoxColumn AccountancyAmount;
        protected ITTTextBoxColumn TransferAmount;
        protected ITTButtonColumn StockDetails;
        protected ITTTextBoxColumn Description2;
        protected ITTRichTextBoxControlColumn SpRefToAdMatters;
        protected ITTRichTextBoxControlColumn FeasibilityEtude;
        protected ITTListBoxColumn Patient;
        protected ITTTextBoxColumn TechnicalSpecificationNo;
        protected ITTTabPage tttabpage2;
        protected ITTGrid TransfersGrid;
        protected ITTListBoxColumn ReturnStore;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTButtonColumn cmdCancel;
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
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("9fc11d81-9ae9-47d1-93ea-1d1d45cd3e5f"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("c8036083-3bea-4e2d-a1c5-5b4c38c7a301"));
            ItemsGrid = (ITTGrid)AddControl(new Guid("c6811246-8876-4de2-8b52-1c4256df0c28"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("be96849f-03db-4fa4-a478-338f3c5fd099"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("8891ba66-44f8-4278-a60d-85ad8e0f226f"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("94ba3d81-2990-4672-b78e-1d2a310f0428"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("3264ba0c-7929-4243-ada2-5893be64d5df"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b9b0a7d1-f91d-4ccd-babf-30b0b91db24a"));
            ApprovedAmount = (ITTTextBoxColumn)AddControl(new Guid("08b32fa6-e697-4042-b2f7-62e882f40908"));
            StoreStocks = (ITTTextBoxColumn)AddControl(new Guid("d85c7474-d205-404b-9ae7-df590b28960b"));
            AccountancyAmount = (ITTTextBoxColumn)AddControl(new Guid("821fa216-6fbd-42cd-880d-3a7a71371c8e"));
            TransferAmount = (ITTTextBoxColumn)AddControl(new Guid("7108b713-fbaa-451c-9a2e-d24fa781a5c6"));
            StockDetails = (ITTButtonColumn)AddControl(new Guid("3e717438-d4c4-4dbc-b0bc-22a57062fa81"));
            Description2 = (ITTTextBoxColumn)AddControl(new Guid("86dca33d-eded-4344-b530-d8ced80ae326"));
            SpRefToAdMatters = (ITTRichTextBoxControlColumn)AddControl(new Guid("e126f9be-a45e-4e97-a687-64696aa07d75"));
            FeasibilityEtude = (ITTRichTextBoxControlColumn)AddControl(new Guid("e51b822e-c91d-48da-bcc8-27868ac524da"));
            Patient = (ITTListBoxColumn)AddControl(new Guid("d1359bb1-8b63-4465-a2f2-85e890a54bf9"));
            TechnicalSpecificationNo = (ITTTextBoxColumn)AddControl(new Guid("cbbe3b57-9a7b-4e57-8b4a-8cad22aee757"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("a5ee6f5d-dce5-44f5-a764-bfbc7a45642e"));
            TransfersGrid = (ITTGrid)AddControl(new Guid("46081ec7-227f-478e-9c72-bad8274783b5"));
            ReturnStore = (ITTListBoxColumn)AddControl(new Guid("82a49d82-64d1-4742-832e-e5b37e87e9d0"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("d44152c2-e990-42cc-82f6-0a040e613a9d"));
            Material = (ITTListBoxColumn)AddControl(new Guid("671755bb-cc9c-49cd-9d9a-566b18ca6209"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("8029c113-3017-4db2-8bd8-f2023a8beca2"));
            cmdCancel = (ITTButtonColumn)AddControl(new Guid("dba1c491-01ca-4bef-95b0-194bc9cf665c"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("b3d43d56-5449-4f82-8749-d04511c78cb2"));
            cmdApproveAll = (ITTButton)AddControl(new Guid("433914d0-d1f9-4d6f-a8da-3488617cc422"));
            labelDescription = (ITTLabel)AddControl(new Guid("6225e296-7db3-445b-8c5f-efaa9fcac22a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6b16eb2c-fbad-47fa-a71e-fbbfa586513a"));
            labelActionDate = (ITTLabel)AddControl(new Guid("a9a45d92-2aee-402b-8474-989b771bf688"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("2f118162-48fe-42b9-aa86-a3093db27b3b"));
            RequestNO = (ITTTextBox)AddControl(new Guid("dc0a323d-9c19-4692-b163-caba78919980"));
            labelID = (ITTLabel)AddControl(new Guid("41fe4f6f-21ce-4293-b344-3daf590d9197"));
            Description = (ITTTextBox)AddControl(new Guid("32eb73be-d997-4452-a0ec-ed40e1788c36"));
            labelDemandType = (ITTLabel)AddControl(new Guid("2b9917dd-9c09-4328-896d-3fa263d4625c"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("cb2ff9cb-b5a8-4dca-a27e-193f65305790"));
            DemandType = (ITTEnumComboBox)AddControl(new Guid("cabb8227-527a-4536-a132-db3269df1c19"));
            base.InitializeControls();
        }

        public DemandAccountacyApprovalForm() : base("DEMAND", "DemandAccountacyApprovalForm")
        {
        }

        protected DemandAccountacyApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}