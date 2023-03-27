
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
    /// K-Çizelgesi MKYS 
    /// </summary>
    public partial class KScheduleMkysForm : StockActionBaseForm
    {
    /// <summary>
    /// Günlük İlaç Çizelgesi
    /// </summary>
        protected TTObjectClasses.KSchedule _KSchedule
        {
            get { return (TTObjectClasses.KSchedule)_ttObject; }
        }

        protected ITTLabel labelMKYS_CikisStokHareketTuru;
        protected ITTEnumComboBox MKYS_CikisStokHareketTuru;
        protected ITTLabel labelMKYS_EButceTur;
        protected ITTEnumComboBox MKYS_EButceTur;
        protected ITTLabel labelMKYS_CikisIslemTuru;
        protected ITTEnumComboBox MKYS_CikisIslemTuru;
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
        protected ITTTextBox MKYS_MakbuzNo;
        protected ITTTextBox MKYS_CikisYapilanKisiTCNo;
        protected ITTTextBox MKYS_TeslimAlan;
        protected ITTTextBox MKYS_TeslimEden;
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
        protected ITTDateTimePicker MKYS_MakbuzTarihi;
        protected ITTLabel lblMKYS_MakbuzNo;
        protected ITTLabel lblMKYS_MakbuzTarihi;
        protected ITTLabel lblMKYS_CikisYapilanKisiTCNo;
        protected ITTLabel lblMKYS_TeslimEden;
        protected ITTLabel lblMKYS_TeslimAlan;
        protected ITTButton btnMKYSGonder;
        override protected void InitializeControls()
        {
            labelMKYS_CikisStokHareketTuru = (ITTLabel)AddControl(new Guid("f84f6d91-67e1-42ee-804d-ac244c4b2e24"));
            MKYS_CikisStokHareketTuru = (ITTEnumComboBox)AddControl(new Guid("0ddfa4c8-1aa4-4ca5-80b4-4da91c43b438"));
            labelMKYS_EButceTur = (ITTLabel)AddControl(new Guid("48cd8ecb-8042-4038-a82a-a828475898a6"));
            MKYS_EButceTur = (ITTEnumComboBox)AddControl(new Guid("890b299b-db30-4986-9d8d-52402cbf34fb"));
            labelMKYS_CikisIslemTuru = (ITTLabel)AddControl(new Guid("23504c86-e8d5-4dbc-b8c0-4e1c4e2bbd9d"));
            MKYS_CikisIslemTuru = (ITTEnumComboBox)AddControl(new Guid("b48843e0-b5bc-40f6-b176-d7530c7f1b12"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4b1c9fa4-3dd3-4398-9f10-a7d33327b3eb"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("88e05a1f-a575-42bb-822a-b1b45b8a4980"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6c5cd51b-29d4-4c52-8ea9-27604694c77d"));
            Drugs = (ITTGrid)AddControl(new Guid("4bea13c4-48df-4137-8a5c-c6bd339a2e88"));
            TDrug = (ITTListBoxColumn)AddControl(new Guid("e83f7f4b-c05f-4eb9-9994-5d08cd0e9d36"));
            TAmount = (ITTTextBoxColumn)AddControl(new Guid("08a18cd2-3765-4f1e-9a66-b88c910f3067"));
            QuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("cf127415-70f4-42e6-ae2d-a7d994fe8977"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("71792b74-7744-4c0f-810c-aeb4b4f66cb8"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("7d2651eb-c85d-48af-87c4-3d475263f5a4"));
            PatientNo = (ITTTextBoxColumn)AddControl(new Guid("4222c25e-f423-453f-ba29-ddd42a613f7f"));
            PatientName = (ITTTextBoxColumn)AddControl(new Guid("3d282a72-a9c1-4821-96d0-54a695c01045"));
            Material = (ITTListBoxColumn)AddControl(new Guid("5e50b54e-5d8e-4cf0-a928-b724c095e5ab"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("59543fce-33ed-4f4f-95c9-2063b4ea2854"));
            ReceivedAmount = (ITTTextBoxColumn)AddControl(new Guid("1da10a70-bea4-49cc-ae8f-2afbb47071b5"));
            QuarantinaNO = (ITTTextBoxColumn)AddControl(new Guid("26afed3f-9c72-4c98-bbc7-5a59f611e43c"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("0dca7bb6-2e04-48e1-ab98-e0b8ff0416d7"));
            DemandDescription = (ITTTextBoxColumn)AddControl(new Guid("9842fc94-1102-476c-8f76-853a188f8027"));
            StatusStockActionDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("b094bacd-5dae-476e-b52d-8644451f41e0"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("ac132649-d440-4674-8b59-86cbf51ad4de"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("12146768-216a-4cf5-9ef0-00d6025d719b"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("17ed19de-9de3-42d1-9452-9533a6b12997"));
            UnListDrug = (ITTTextBoxColumn)AddControl(new Guid("d22e1009-b76c-4117-a647-c0b74d600d60"));
            Patient = (ITTTextBoxColumn)AddControl(new Guid("458fa15e-c53f-4e95-b2c8-6743b577299d"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("e530f7b8-8704-47f1-aa26-5a2d37924911"));
            Dose = (ITTTextBoxColumn)AddControl(new Guid("eb9513f3-091f-4d01-882f-90dec0bd670c"));
            Reason = (ITTTextBoxColumn)AddControl(new Guid("3077b911-114b-4e8a-8e65-cbc28d25048a"));
            Description = (ITTTextBox)AddControl(new Guid("d42c86af-11f5-42c1-bcaa-e596315793f0"));
            StockActionID = (ITTTextBox)AddControl(new Guid("e5fadf42-73fa-4ed3-8580-9b117e89f8c2"));
            MKYS_MakbuzNo = (ITTTextBox)AddControl(new Guid("bbff5f17-c128-4565-88bb-1729d7585648"));
            MKYS_CikisYapilanKisiTCNo = (ITTTextBox)AddControl(new Guid("2b489f4c-0882-4bac-a038-ceecb8f55dff"));
            MKYS_TeslimAlan = (ITTTextBox)AddControl(new Guid("2347090e-6a38-45dd-a96f-357f0671c499"));
            MKYS_TeslimEden = (ITTTextBox)AddControl(new Guid("cbbaddea-b891-4ac2-a002-6909ad7f1035"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("adb18ef5-ad8f-44ed-b42c-38779c1dd2ff"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("72bf036c-c187-42b7-bcd5-5a11ffc6855a"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("7a4f7461-0535-4c0e-87eb-39a21189df09"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("2de8bf77-0331-4e01-ac51-29994814f27f"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("b9590387-2e68-4204-8503-b47cd0c6a4e7"));
            labelStore = (ITTLabel)AddControl(new Guid("74cea0a7-f751-4804-9739-986aa10a7112"));
            labelDescription = (ITTLabel)AddControl(new Guid("75e0107a-40d0-46c7-a62e-bfea087f2e63"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("a05b0695-7052-42bc-8805-c2c4faf9f857"));
            Store = (ITTObjectListBox)AddControl(new Guid("f56a1fe8-e400-4e8d-b067-220c393932e3"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("58c5a4a9-1a3a-454b-b076-4ba3c32bf678"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("88529760-a42a-49bd-a703-d446a4e851ce"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a3a3c359-76c7-4a8a-ba6e-84d661f65c8b"));
            MKYS_MakbuzTarihi = (ITTDateTimePicker)AddControl(new Guid("e7244402-0999-40a4-9ce4-dab918c72fca"));
            lblMKYS_MakbuzNo = (ITTLabel)AddControl(new Guid("b8101fb4-a3c8-4662-a5a9-7a7f50a822e7"));
            lblMKYS_MakbuzTarihi = (ITTLabel)AddControl(new Guid("3047781a-fe29-4ab3-964d-10c779862859"));
            lblMKYS_CikisYapilanKisiTCNo = (ITTLabel)AddControl(new Guid("8a327911-314f-4c86-aae4-570a1dcfb745"));
            lblMKYS_TeslimEden = (ITTLabel)AddControl(new Guid("a113d560-c8ef-410f-a170-e9e96e635177"));
            lblMKYS_TeslimAlan = (ITTLabel)AddControl(new Guid("f081d4c0-3719-4f90-bec0-6a6679d499b5"));
            btnMKYSGonder = (ITTButton)AddControl(new Guid("cc495a66-b143-4251-9aa4-95333ebcfb77"));
            base.InitializeControls();
        }

        public KScheduleMkysForm() : base("KSCHEDULE", "KScheduleMkysForm")
        {
        }

        protected KScheduleMkysForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}