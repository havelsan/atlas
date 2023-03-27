
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
    /// K-Çizelgesi İstek Hazırlama
    /// </summary>
    public partial class KScheduleApprovalForm : StockActionBaseForm
    {
    /// <summary>
    /// Günlük İlaç Çizelgesi
    /// </summary>
        protected TTObjectClasses.KSchedule _KSchedule
        {
            get { return (TTObjectClasses.KSchedule)_ttObject; }
        }

        protected ITTGrid KSchedulePatienOwnDrugs;
        protected ITTListBoxColumn MaterialKSchedulePatienOwnDrug;
        protected ITTTextBoxColumn DrugAmountKSchedulePatienOwnDrug;
        protected ITTEnumComboBoxColumn StockActionStatusKSchedulePatienOwnDrug;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage3;
        protected ITTTextBox tttextbox1;
        protected ITTGrid Drugs;
        protected ITTListBoxColumn TDrug;
        protected ITTTextBoxColumn TAmount;
        protected ITTTextBoxColumn QuarantineNo;
        protected ITTTabPage tttabpage1;
        protected ITTGrid StockActionOutDetails;
        protected ITTTextBoxColumn PatientNo;
        protected ITTTextBoxColumn PatientName;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn ReceivedAmount;
        protected ITTTextBoxColumn QuarantinaNO;
        protected ITTTextBoxColumn StoreInheld;
        protected ITTTextBoxColumn DemandDescription;
        protected ITTEnumComboBoxColumn StatusStockActionDetail;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTTabPage tttabpage2;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn UnListDrug;
        protected ITTTextBoxColumn Patient;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Dose;
        protected ITTTextBoxColumn Reason;
        protected ITTTextBox Description;
        protected ITTTextBox StockActionID;
        protected ITTTextBox IDPatient;
        protected ITTTextBox FullNamePatient;
        protected ITTDateTimePicker StartDate;
        protected ITTObjectListBox DestinationStore;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStore;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStockActionID;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDestinationStore;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelFullNamePatient;
        protected ITTLabel labelIDPatient;
        override protected void InitializeControls()
        {
            KSchedulePatienOwnDrugs = (ITTGrid)AddControl(new Guid("6b06c143-8f8a-445b-8be1-649537263e6b"));
            MaterialKSchedulePatienOwnDrug = (ITTListBoxColumn)AddControl(new Guid("3609b1c9-a7f1-4d17-918e-7ad69653fdcd"));
            DrugAmountKSchedulePatienOwnDrug = (ITTTextBoxColumn)AddControl(new Guid("387e1aac-0139-4526-aecb-cb90fa0c4f79"));
            StockActionStatusKSchedulePatienOwnDrug = (ITTEnumComboBoxColumn)AddControl(new Guid("bc58cb76-7331-461b-9277-073d8787a89f"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("36e87001-e101-4ab4-b9e7-32fc6fbdcad5"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("0f4c6915-6da6-4d79-89f1-a1f671a4a9eb"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("815163ac-5f32-40b3-81d9-f64e03ee81c6"));
            Drugs = (ITTGrid)AddControl(new Guid("b998d165-603e-4a98-b8af-63ee68cd71ad"));
            TDrug = (ITTListBoxColumn)AddControl(new Guid("ed96d860-1c18-407c-80a4-f6d2e9febb6f"));
            TAmount = (ITTTextBoxColumn)AddControl(new Guid("e6c4a559-91f4-400c-87e7-bada746b0ea6"));
            QuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("d5bbe332-8722-48be-9dd9-f58a4ef7b421"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("eea5473d-7f16-4666-945b-6268c03573b8"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("af21c031-7102-4521-8697-254990c02034"));
            PatientNo = (ITTTextBoxColumn)AddControl(new Guid("73c112d3-08a7-4b9a-b18f-85eb8f8a5cb9"));
            PatientName = (ITTTextBoxColumn)AddControl(new Guid("27157b7b-b959-4240-92c1-7a30e197c3b0"));
            Material = (ITTListBoxColumn)AddControl(new Guid("603cb3f0-798d-478b-a659-74717a4f4681"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("8ff54389-d315-482e-9e14-91de1513ea92"));
            ReceivedAmount = (ITTTextBoxColumn)AddControl(new Guid("23751c00-62be-4569-96c4-bca56a35b227"));
            QuarantinaNO = (ITTTextBoxColumn)AddControl(new Guid("d803cf97-1723-4988-82a7-8a72553f9dbc"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("927b9802-4e8a-488d-9a91-7003c71c64a0"));
            DemandDescription = (ITTTextBoxColumn)AddControl(new Guid("c1fe99bb-5147-4647-b397-a805b96dba33"));
            StatusStockActionDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("190770b0-8edd-48e7-ac52-ad03b3389cac"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("af7b9f24-dbca-4b5b-a3f0-8b9f3e9008e4"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("63d6b03f-e924-471f-8fc1-0357d2a773e9"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("92f7f93a-6596-40f6-895e-f68eb0495178"));
            UnListDrug = (ITTTextBoxColumn)AddControl(new Guid("e66ba4ab-5a86-4840-bc3d-1939e2aa2f87"));
            Patient = (ITTTextBoxColumn)AddControl(new Guid("8b09a522-6c34-4285-82e9-80b81eddf8dc"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("9f69c362-e1a8-4cd0-82f6-eadf1f976270"));
            Dose = (ITTTextBoxColumn)AddControl(new Guid("95fbfdff-97a9-4ed9-ae40-d69418ff3151"));
            Reason = (ITTTextBoxColumn)AddControl(new Guid("d0b9e7d0-0111-46ab-af52-d9a1b0059e56"));
            Description = (ITTTextBox)AddControl(new Guid("f6a65e70-833b-4af6-a3a6-4f52d5bc714e"));
            StockActionID = (ITTTextBox)AddControl(new Guid("06710c2c-ed15-4da4-8a54-8c820e58df4a"));
            IDPatient = (ITTTextBox)AddControl(new Guid("15e705c3-2f5a-4c9e-975e-2a399788caa8"));
            FullNamePatient = (ITTTextBox)AddControl(new Guid("8fad955c-8fb8-4e94-9999-fa65c6919136"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("c7659f5a-5158-4264-976d-b79782348d91"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("ef160ccc-a792-4a30-a297-4a90068f2399"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("66fdfe61-fa45-44c9-9fba-89f543e7293f"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("3adea3e0-1f2c-41f5-894e-589c32da21a0"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("d1f9ad8d-6ac5-40b4-9553-d6de8624cd0c"));
            labelStore = (ITTLabel)AddControl(new Guid("e1825410-1db2-45aa-93f3-9969af89c600"));
            labelDescription = (ITTLabel)AddControl(new Guid("24b6e10b-0456-4e8d-aa4a-edb94406b20e"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("9e94bb6f-31d9-42e5-aae4-e0dfd9bfe6cc"));
            Store = (ITTObjectListBox)AddControl(new Guid("25ef8627-2241-44a7-95c8-993ee45483c8"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("7dbc278f-5d51-40e4-815b-4411cdeb8a3f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fbba0abb-b5b8-459d-a918-bd8ed99021b7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b39d387f-0b19-4eac-b166-ddd0c99d12a9"));
            labelFullNamePatient = (ITTLabel)AddControl(new Guid("3dd6ac31-7312-4b5a-b064-28d50fde85a9"));
            labelIDPatient = (ITTLabel)AddControl(new Guid("71bdd5d5-2696-4f1c-87c1-a0e25c95fed1"));
            base.InitializeControls();
        }

        public KScheduleApprovalForm() : base("KSCHEDULE", "KScheduleApprovalForm")
        {
        }

        protected KScheduleApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}