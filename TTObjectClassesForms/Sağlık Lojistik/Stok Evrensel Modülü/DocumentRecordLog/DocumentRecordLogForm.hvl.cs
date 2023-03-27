
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
    public partial class DocumentRecordLogForm : TTForm
    {
        protected TTObjectClasses.DocumentRecordLog _DocumentRecordLog
        {
            get { return (TTObjectClasses.DocumentRecordLog)_ttObject; }
        }

        protected ITTLabel labelTakenGivenPlace;
        protected ITTTextBox TakenGivenPlace;
        protected ITTTextBox Subject;
        protected ITTTextBox NumberOfRows;
        protected ITTTextBox DocumentRecordLogNumber;
        protected ITTTextBox Descriptions;
        protected ITTLabel labelSubject;
        protected ITTLabel labelNumberOfRows;
        protected ITTLabel labelDocumentTransactionType;
        protected ITTEnumComboBox DocumentTransactionType;
        protected ITTLabel labelDocumentRecordLogNumber;
        protected ITTLabel labelDocumentDateTime;
        protected ITTDateTimePicker DocumentDateTime;
        protected ITTLabel labelDescriptions;
        override protected void InitializeControls()
        {
            labelTakenGivenPlace = (ITTLabel)AddControl(new Guid("c50366c7-bcff-4661-80d4-834d75f9e7c4"));
            TakenGivenPlace = (ITTTextBox)AddControl(new Guid("2f195a09-d916-4734-9d74-7f2a8c1a3f3f"));
            Subject = (ITTTextBox)AddControl(new Guid("6ef83c39-1b31-4ecd-b819-cb825f8f19c0"));
            NumberOfRows = (ITTTextBox)AddControl(new Guid("9c055c80-aaa3-4c67-8c88-3d9ee3ebd396"));
            DocumentRecordLogNumber = (ITTTextBox)AddControl(new Guid("2dbb358b-ec0f-46c1-8eee-7bb59608ac32"));
            Descriptions = (ITTTextBox)AddControl(new Guid("92ce6b37-7e3f-464a-bf27-1733c02f42f2"));
            labelSubject = (ITTLabel)AddControl(new Guid("50b463b5-9476-43d9-a59e-fb55b44e2594"));
            labelNumberOfRows = (ITTLabel)AddControl(new Guid("e5400365-96de-4f8c-a999-414a3ed519d6"));
            labelDocumentTransactionType = (ITTLabel)AddControl(new Guid("f45509ad-a942-4a9b-9aea-eb2ae5c3c070"));
            DocumentTransactionType = (ITTEnumComboBox)AddControl(new Guid("263c6ad2-77b7-4f09-b959-ecc5d4380349"));
            labelDocumentRecordLogNumber = (ITTLabel)AddControl(new Guid("0afc41f6-c114-4535-986b-8f68d728cbf7"));
            labelDocumentDateTime = (ITTLabel)AddControl(new Guid("5444b692-3269-4d06-a454-bcd8eadc46d9"));
            DocumentDateTime = (ITTDateTimePicker)AddControl(new Guid("aab2b9bb-15bd-4446-9a89-1f1187057df7"));
            labelDescriptions = (ITTLabel)AddControl(new Guid("cb5f6581-ea50-42de-8ff5-22217f57fb84"));
            base.InitializeControls();
        }

        public DocumentRecordLogForm() : base("DOCUMENTRECORDLOG", "DocumentRecordLogForm")
        {
        }

        protected DocumentRecordLogForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}