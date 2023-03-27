
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
    /// Onay Makamı Tanımları
    /// </summary>
    public partial class ConfirmationUnitDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Onay Makamı Tanımları 
    /// </summary>
        protected TTObjectClasses.ConfirmationUnitDefinition _ConfirmationUnitDefinition
        {
            get { return (TTObjectClasses.ConfirmationUnitDefinition)_ttObject; }
        }

        protected ITTGrid SendingCheckedHealthComiteeReportCHCRGrid;
        protected ITTListBoxColumn TheUnit;
        protected ITTListBoxColumn TheReports;
        protected ITTListBoxColumn Result;
        protected ITTTextBoxColumn ConsignmentNo;
        protected ITTDateTimePickerColumn EndDate;
        protected ITTTextBoxColumn ReportNo;
        protected ITTDateTimePickerColumn StartDate;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox ID;
        protected ITTTextBox Code;
        protected ITTLabel labelID;
        protected ITTLabel labelCode;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            SendingCheckedHealthComiteeReportCHCRGrid = (ITTGrid)AddControl(new Guid("b8be99ac-917a-4e0a-bfda-6d80e424d45c"));
            TheUnit = (ITTListBoxColumn)AddControl(new Guid("9e617c20-5e0a-4e07-9d07-270c96e992b8"));
            TheReports = (ITTListBoxColumn)AddControl(new Guid("e78c8092-52b6-4bc5-a4af-142914d6a6ee"));
            Result = (ITTListBoxColumn)AddControl(new Guid("baaa3848-8419-47ff-a7ab-f346a9345567"));
            ConsignmentNo = (ITTTextBoxColumn)AddControl(new Guid("7c325966-6cd0-4c19-8af4-eca0df9806b6"));
            EndDate = (ITTDateTimePickerColumn)AddControl(new Guid("302a1b60-9b9d-4dcc-b6dd-3b8d0f56806f"));
            ReportNo = (ITTTextBoxColumn)AddControl(new Guid("118b9426-e154-433c-a495-16575b63ce51"));
            StartDate = (ITTDateTimePickerColumn)AddControl(new Guid("d379ca44-9c23-4c41-913a-6ca6e2b47954"));
            labelName = (ITTLabel)AddControl(new Guid("fe8b6b60-de50-43cd-9a38-ac46633b417a"));
            Name = (ITTTextBox)AddControl(new Guid("64c17916-b68d-4431-a7d2-5c43df241167"));
            ID = (ITTTextBox)AddControl(new Guid("40df7d48-250b-43f8-b642-ffb30e8727b7"));
            Code = (ITTTextBox)AddControl(new Guid("da1e7bd1-3bfb-4525-a223-07501437fb98"));
            labelID = (ITTLabel)AddControl(new Guid("4ac368fa-25eb-418f-a473-fe0239e4b2b8"));
            labelCode = (ITTLabel)AddControl(new Guid("d7a516e8-16be-4a1c-8e10-7a26b27da9a9"));
            Active = (ITTCheckBox)AddControl(new Guid("b0e867d0-a13c-4bea-b41d-44565ce83386"));
            base.InitializeControls();
        }

        public ConfirmationUnitDefinitionForm() : base("CONFIRMATIONUNITDEFINITION", "ConfirmationUnitDefinitionForm")
        {
        }

        protected ConfirmationUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}