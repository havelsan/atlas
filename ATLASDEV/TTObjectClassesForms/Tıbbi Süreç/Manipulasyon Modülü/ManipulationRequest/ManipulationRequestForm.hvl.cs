
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
    /// Tıbbi/Cerrahi Uygulama İstek
    /// </summary>
    public partial class ManipulationRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İstek Yapılan Nesnedir 
    /// </summary>
        protected TTObjectClasses.ManipulationRequest _ManipulationRequest
        {
            get { return (TTObjectClasses.ManipulationRequest)_ttObject; }
        }

        protected ITTTextBox IDEpisode;
        protected ITTTextBox MedulaRaporBilgileri;
        protected ITTTextBox MedulaRaporTakipNo;
        protected ITTLabel lblRaporBilgileri;
        protected ITTLabel labelMedulaRaporTakipNo;
        protected ITTCheckBox chkDisXXXXXXRaporu;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTRichTextBoxControl PreInformation;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage Manipulation;
        protected ITTGrid GridManipulationProcedures;
        protected ITTDateTimePickerColumn ManipulationActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn Department;
        protected ITTTextBoxColumn Description;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTCheckBox ApprovalFormGiven;
        protected ITTButton cmdHistory;
        protected ITTGrid ManipulationGrid;
        protected ITTDateTimePickerColumn OldManipulationActionDate;
        protected ITTListBoxColumn OldProcedureObject;
        protected ITTCheckBoxColumn OldEmergency;
        protected ITTListBoxColumn OldDepartment;
        protected ITTListBoxColumn OldManipulationDoctor;
        protected ITTTextBoxColumn OldDescription;
        override protected void InitializeControls()
        {
            IDEpisode = (ITTTextBox)AddControl(new Guid("9d8e48b1-19dd-40d6-a5f6-5c6399a0969e"));
            MedulaRaporBilgileri = (ITTTextBox)AddControl(new Guid("36873569-437e-41c3-9653-95083de0c2f3"));
            MedulaRaporTakipNo = (ITTTextBox)AddControl(new Guid("4c85dd58-1d97-428e-9e92-404d21fb2da7"));
            lblRaporBilgileri = (ITTLabel)AddControl(new Guid("3dcfdb74-ffa0-4a60-931c-2e56a334cb3a"));
            labelMedulaRaporTakipNo = (ITTLabel)AddControl(new Guid("e1c4290f-6a89-4cdd-857a-593b526fca81"));
            chkDisXXXXXXRaporu = (ITTCheckBox)AddControl(new Guid("94f840e7-578d-45ac-95b5-c9ea7c3698a9"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("42035ba6-2c09-4aff-b330-2c688141ad12"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("6f45be2f-bb18-4b47-8709-a44c5fa650cf"));
            PreInformation = (ITTRichTextBoxControl)AddControl(new Guid("1fff32f8-3547-4460-91ed-dbb928858021"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("10e1232b-28bf-442a-b9f1-11c555d762cb"));
            Manipulation = (ITTTabPage)AddControl(new Guid("4fce42aa-a58f-47e0-b9eb-5de46b388fc8"));
            GridManipulationProcedures = (ITTGrid)AddControl(new Guid("45021411-8f64-465c-adf2-9f3237cda32e"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("9de1acc8-7238-4714-84dc-34fe8ab956b3"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("bd1df893-db01-457f-8d08-99da1b85be09"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("875bd3fc-a7b8-45a5-b886-57ba7ad6f6de"));
            Department = (ITTListBoxColumn)AddControl(new Guid("c197e8d4-e26e-40d4-b222-999655539b9b"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("fde96a30-118c-4534-ab0e-dfd48bb4d676"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("49867b5c-6400-4d4a-91af-e5e124462cdf"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("92f714d7-7d38-46f6-aaac-76d40acb42b4"));
            ApprovalFormGiven = (ITTCheckBox)AddControl(new Guid("0ad64ff6-f2eb-4e28-b9fe-8f16f55482c6"));
            cmdHistory = (ITTButton)AddControl(new Guid("5396984e-9485-42c8-97fd-5d28959209b9"));
            ManipulationGrid = (ITTGrid)AddControl(new Guid("ad61b86b-27a3-4d4f-b47f-e434d03083a9"));
            OldManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("96ce5327-0377-41cc-b99d-ca85fdba2f56"));
            OldProcedureObject = (ITTListBoxColumn)AddControl(new Guid("cd78c2da-5dbc-4295-86e2-d5118a9e55af"));
            OldEmergency = (ITTCheckBoxColumn)AddControl(new Guid("0d7b5da5-b6a5-42bf-8b65-914b586ef9ca"));
            OldDepartment = (ITTListBoxColumn)AddControl(new Guid("c4912885-af68-4f41-8c94-539cf8375a9a"));
            OldManipulationDoctor = (ITTListBoxColumn)AddControl(new Guid("7ceaf591-d092-4bee-b5ae-7c5140f2b66e"));
            OldDescription = (ITTTextBoxColumn)AddControl(new Guid("2b9a4bd6-154b-429e-a007-0a851281bb09"));
            base.InitializeControls();
        }

        public ManipulationRequestForm() : base("MANIPULATIONREQUEST", "ManipulationRequestForm")
        {
        }

        protected ManipulationRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}