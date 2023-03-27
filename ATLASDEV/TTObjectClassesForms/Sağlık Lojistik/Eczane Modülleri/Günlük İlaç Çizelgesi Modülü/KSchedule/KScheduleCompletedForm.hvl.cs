
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
    public partial class KScheduleCompletedForm : StockActionBaseForm
    {
    /// <summary>
    /// Günlük İlaç Çizelgesi
    /// </summary>
        protected TTObjectClasses.KSchedule _KSchedule
        {
            get { return (TTObjectClasses.KSchedule)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage3;
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
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("17f14baf-371a-4912-aecc-bd9f8e8e5de3"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("394ee95b-b565-4ee5-b1f7-7a0f3c77b102"));
            Drugs = (ITTGrid)AddControl(new Guid("e4345b76-5ba3-4204-8d08-fe40fa0e923d"));
            TDrug = (ITTListBoxColumn)AddControl(new Guid("5085326d-67f7-4503-afbd-fd63d830b58f"));
            TAmount = (ITTTextBoxColumn)AddControl(new Guid("4dfaf6cd-1418-4897-bb91-5aefa2ab745e"));
            QuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("c14fd925-1233-4956-910b-b24ef4b2ef4b"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("44c3f31d-f439-4c38-9472-22ae496b12c7"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("dc650f19-905d-4525-b9f6-9600dcaf7c31"));
            PatientNo = (ITTTextBoxColumn)AddControl(new Guid("10ff6f7b-c9ec-4f5c-8ef7-52c9a316aceb"));
            PatientName = (ITTTextBoxColumn)AddControl(new Guid("8a4ccc56-8095-4cbf-9440-1c09910dda5e"));
            Material = (ITTListBoxColumn)AddControl(new Guid("83f8dff3-7eec-4923-bedf-68fa8c2cbfbd"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("51dbb33b-12f0-4301-beb1-5b2a74ee4e36"));
            ReceivedAmount = (ITTTextBoxColumn)AddControl(new Guid("351f7f13-d372-45a7-b292-50943b883492"));
            QuarantinaNO = (ITTTextBoxColumn)AddControl(new Guid("2b4e2bb3-499b-4c9e-9cd3-243aed29872d"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("908e0d24-60d9-4348-bf52-79f185fc7887"));
            DemandDescription = (ITTTextBoxColumn)AddControl(new Guid("0e02fdab-cae9-4eef-974f-ba211fc52295"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("b00afda2-5f89-4b41-9348-7e76eca6b1ef"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("79319719-1de4-4d97-afe7-926e580fef50"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("adeffe39-cd38-438d-889b-230c9231b95f"));
            UnListDrug = (ITTTextBoxColumn)AddControl(new Guid("1bb664a4-84ac-45f3-87a2-c61309d2676f"));
            Patient = (ITTTextBoxColumn)AddControl(new Guid("dba74b43-eb65-4eb7-bc1e-4c64c5030bae"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("8b9d20ce-68cb-4fff-bac7-f2da6f4421d7"));
            Dose = (ITTTextBoxColumn)AddControl(new Guid("789979fa-3ad4-4016-b0aa-7c5f177eba13"));
            Reason = (ITTTextBoxColumn)AddControl(new Guid("e10d4bca-4ed0-4b05-a618-a6abf20bdb07"));
            Description = (ITTTextBox)AddControl(new Guid("7612b582-6304-45d4-add6-c0224a5206de"));
            StockActionID = (ITTTextBox)AddControl(new Guid("ea435c3a-4ace-4d35-b919-f145df4a4131"));
            IDPatient = (ITTTextBox)AddControl(new Guid("16392a03-2005-473e-b2b1-efa8988b2e00"));
            FullNamePatient = (ITTTextBox)AddControl(new Guid("dabe2fd6-035f-460e-bdce-71515734c5c8"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("ea5ac89d-39c9-43f8-91b1-3d0f0a9ba8e9"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("a470d4b7-0791-4103-8530-ddfe1e24f8ec"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("e2eae802-676c-4f6a-b52b-5136a0e35fbd"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("5f5eb4d6-0e8b-4804-80ca-0ad0b66b3dea"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("4377d22f-c2f0-4e09-9b10-fb36daa77692"));
            labelStore = (ITTLabel)AddControl(new Guid("a7d6300e-3336-4aac-b917-2975a8f8888b"));
            labelDescription = (ITTLabel)AddControl(new Guid("eb0c0621-a985-4c5d-b406-d9c4836f5e41"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("c376f310-b9b8-48db-9ac9-42142bd39703"));
            Store = (ITTObjectListBox)AddControl(new Guid("781bf73c-0d3b-48d7-90f9-a6842659ecb7"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("fedae511-a290-470b-adf1-4ab1c9755c1d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b29751c3-ebb7-43a6-b017-3e14e5799b0a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a3917c1e-1790-4a33-b12e-8db583d20fb1"));
            labelFullNamePatient = (ITTLabel)AddControl(new Guid("bc55ae12-bd6e-45b6-a4b3-5902c4a6de8c"));
            labelIDPatient = (ITTLabel)AddControl(new Guid("4c89eb3a-3281-40dc-8b2a-25075b8e8065"));
            base.InitializeControls();
        }

        public KScheduleCompletedForm() : base("KSCHEDULE", "KScheduleCompletedForm")
        {
        }

        protected KScheduleCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}