
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
    /// K-Çizelgesi
    /// </summary>
    public partial class KScheduleForm : StockActionBaseForm
    {
    /// <summary>
    /// Günlük İlaç Çizelgesi
    /// </summary>
        protected TTObjectClasses.KSchedule _KSchedule
        {
            get { return (TTObjectClasses.KSchedule)_ttObject; }
        }

        protected ITTLabel labelFullNamePatient;
        protected ITTTextBox FullNamePatient;
        protected ITTTextBox IDPatient;
        protected ITTTextBox Description;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelIDPatient;
        protected ITTDateTimePicker StartDate;
        protected ITTObjectListBox DestinationStore;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker EndDate;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn ReceivedAmount;
        protected ITTTextBoxColumn DemandDescription;
        protected ITTTextBoxColumn DemandAmount;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTTabPage tttabpage2;
        protected ITTGrid UnSupplyGrid;
        protected ITTTextBoxColumn UnListDrug;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Dose;
        protected ITTTextBoxColumn Reason;
        protected ITTLabel labelStore;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStockActionID;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDestinationStore;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            labelFullNamePatient = (ITTLabel)AddControl(new Guid("d3c97c47-0cac-4df7-bcb6-4fbb253bc0f1"));
            FullNamePatient = (ITTTextBox)AddControl(new Guid("8cf376ac-872a-46c2-8212-694f04f27349"));
            IDPatient = (ITTTextBox)AddControl(new Guid("545c4622-d64c-4d86-91d5-19458bc2586b"));
            Description = (ITTTextBox)AddControl(new Guid("445bb51a-83aa-4f81-a7cb-0be181503fe3"));
            StockActionID = (ITTTextBox)AddControl(new Guid("6625a779-db1e-4e37-9425-69c21ecc2906"));
            labelIDPatient = (ITTLabel)AddControl(new Guid("381d50dc-47e9-468b-b7ed-9d740deb06fe"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("35461b3f-1fc5-4167-86cd-015ac17bd32e"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("dec58e14-f3e8-4927-80dd-0d0b68b550d8"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("6568de94-4b10-425b-b308-1789a4c17e69"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("37d2845a-5abf-4b58-99e4-2d78e099c676"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("4332cbd5-360c-4151-83be-540d15576bf5"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("35f23918-2618-4b3e-8f94-892368bb76a1"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("dcd05aad-a120-4104-8eeb-53da62f6f79a"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("287f2e0d-22d1-4e30-bd57-744d85378850"));
            Material = (ITTListBoxColumn)AddControl(new Guid("bc4be31c-3161-4417-a008-9a7effb12ed7"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("8148a5c5-101e-43e9-8275-00928d9608f8"));
            ReceivedAmount = (ITTTextBoxColumn)AddControl(new Guid("0d5f3d4f-73e6-4256-8317-bfa0b0c1452b"));
            DemandDescription = (ITTTextBoxColumn)AddControl(new Guid("6cc165b7-e9e2-442c-a2c2-5894a8a9bf36"));
            DemandAmount = (ITTTextBoxColumn)AddControl(new Guid("ce8b841e-2c1b-4231-b7bb-79b75a2f329f"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("4bac196c-3ca0-4b6e-a1be-7e983d2ca035"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("d9d999d8-370b-48f3-96d9-f4bb634180d4"));
            UnSupplyGrid = (ITTGrid)AddControl(new Guid("b04efde2-cc64-4b36-99ff-8e7a54468660"));
            UnListDrug = (ITTTextBoxColumn)AddControl(new Guid("c77ef7a4-5da7-4afe-b7b8-6828a1d0af7c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("9e8d07f5-7afb-435d-947d-77c7fa2c932c"));
            Dose = (ITTTextBoxColumn)AddControl(new Guid("af8416ca-1c6c-4989-8d7c-5b0b7969ba9e"));
            Reason = (ITTTextBoxColumn)AddControl(new Guid("bb0db118-10e4-441a-827c-3085ba69f3a0"));
            labelStore = (ITTLabel)AddControl(new Guid("d1374cbd-e27e-44ae-ae6a-8cdeeb9f64af"));
            labelDescription = (ITTLabel)AddControl(new Guid("ab2a587a-dda5-4bc4-b51d-a62a82688a8c"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("54406149-4034-4511-9c2e-cf9e07366c72"));
            Store = (ITTObjectListBox)AddControl(new Guid("81e1ed0c-96ec-47de-bddb-d0f46b21d6df"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("97e45cd8-6d26-4427-b2e0-ecbfd653f05f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d6aaa65c-17c5-41f1-9576-23c81d3ce8da"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("59f6c912-b8ed-4d71-9d06-23224c7c0b34"));
            base.InitializeControls();
        }

        public KScheduleForm() : base("KSCHEDULE", "KScheduleForm")
        {
        }

        protected KScheduleForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}