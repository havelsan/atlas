
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
    public partial class BaseDailyDrugScheduleForm : StockActionBaseForm
    {
    /// <summary>
    /// Hemşirelik İlaç İstek
    /// </summary>
        protected TTObjectClasses.DailyDrugSchedule _DailyDrugSchedule
        {
            get { return (TTObjectClasses.DailyDrugSchedule)_ttObject; }
        }

        protected ITTTabControl tttabcontrol3;
        protected ITTTabPage PatientTab;
        protected ITTGrid DailyDrugPatientsGrid;
        protected ITTCheckBoxColumn selecetedPatient;
        protected ITTTextBoxColumn patinetFullName;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage DrugListTab;
        protected ITTGrid DailyDrugSchOrdersGrid;
        protected ITTTextBoxColumn drugOrderName;
        protected ITTTextBoxColumn DoseAmountDailyDrugSchOrder;
        protected ITTTextBoxColumn patientFullName;
        protected ITTTabPage UnDrugListTab;
        protected ITTGrid DailyDrugUnDrugsGrid;
        protected ITTTextBoxColumn UnDrugName;
        protected ITTTextBoxColumn DoseAmountDailyDrugUnDrug;
        protected ITTTextBoxColumn patientNameSurname;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelEndDate;
        protected ITTButton DailyDrugOrderGetByDate;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTDateTimePicker ttdatetimepicker1;
        override protected void InitializeControls()
        {
            tttabcontrol3 = (ITTTabControl)AddControl(new Guid("3f2b453c-1e18-4d4d-8641-cc33c21b6135"));
            PatientTab = (ITTTabPage)AddControl(new Guid("d5238471-7401-491f-b555-4b50e5bb1391"));
            DailyDrugPatientsGrid = (ITTGrid)AddControl(new Guid("89bdddd0-eec2-4e94-96a8-f05742351a5a"));
            selecetedPatient = (ITTCheckBoxColumn)AddControl(new Guid("57cc29da-0a6a-4648-8ba1-28623107734e"));
            patinetFullName = (ITTTextBoxColumn)AddControl(new Guid("747c2c3d-2211-471b-afd8-92438a402358"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("c0521d1a-3d21-4832-8855-558fb235bbfc"));
            DrugListTab = (ITTTabPage)AddControl(new Guid("21f27d79-740e-4a5c-b9d8-c98e8d76347e"));
            DailyDrugSchOrdersGrid = (ITTGrid)AddControl(new Guid("654533a5-7036-41c2-9f26-b9a1ea4b0c29"));
            drugOrderName = (ITTTextBoxColumn)AddControl(new Guid("010c59a5-16ab-4866-aaba-47eda7c33e99"));
            DoseAmountDailyDrugSchOrder = (ITTTextBoxColumn)AddControl(new Guid("d799dfb5-d55c-4308-9e1e-1ee0f203beda"));
            patientFullName = (ITTTextBoxColumn)AddControl(new Guid("850644f6-17c1-469d-a456-cec001965f86"));
            UnDrugListTab = (ITTTabPage)AddControl(new Guid("7a9b8114-6d03-4f6e-bdec-0e9d8b3b7260"));
            DailyDrugUnDrugsGrid = (ITTGrid)AddControl(new Guid("107450b6-b111-43fb-85c3-db42c4270ac1"));
            UnDrugName = (ITTTextBoxColumn)AddControl(new Guid("abbc9c57-3763-41ef-a623-d375dfe6081a"));
            DoseAmountDailyDrugUnDrug = (ITTTextBoxColumn)AddControl(new Guid("9923e6cf-49b1-4a13-b43f-674aa33cfc69"));
            patientNameSurname = (ITTTextBoxColumn)AddControl(new Guid("f4d1cc01-f331-467b-8d84-791f0a630977"));
            StockActionID = (ITTTextBox)AddControl(new Guid("16f80d79-ffee-4c4b-b519-de3e40e2422d"));
            labelStore = (ITTLabel)AddControl(new Guid("80da1f46-a96e-4be8-afde-5d87172ffbaa"));
            Store = (ITTObjectListBox)AddControl(new Guid("7121ae5c-2bbf-4938-aed4-5c49dc556a3a"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("8e109d8a-c6bc-49fb-9b58-f88c858b7223"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("a2bddb22-1dba-48db-b97c-bc70cfd277c2"));
            labelActionDate = (ITTLabel)AddControl(new Guid("eeb1d999-71b3-42a5-86df-420e2c78e521"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("021a7597-1648-40e6-8364-69190a3bed32"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("fceb3186-18a5-4c44-890c-e75e508d5308"));
            labelStartDate = (ITTLabel)AddControl(new Guid("010055a7-02a2-4c6e-a1dd-b690549e4403"));
            labelEndDate = (ITTLabel)AddControl(new Guid("943f5813-2bb1-4774-9c8b-611f64f5da2a"));
            DailyDrugOrderGetByDate = (ITTButton)AddControl(new Guid("d82088da-3598-4903-8e3c-90837e200276"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("d23e8a0d-f100-4ccd-a49d-4be1ea8cf7b8"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("b0786cd8-b579-44bc-9de4-5d1dbd6c4c9e"));
            base.InitializeControls();
        }

        public BaseDailyDrugScheduleForm() : base("DAILYDRUGSCHEDULE", "BaseDailyDrugScheduleForm")
        {
        }

        protected BaseDailyDrugScheduleForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}