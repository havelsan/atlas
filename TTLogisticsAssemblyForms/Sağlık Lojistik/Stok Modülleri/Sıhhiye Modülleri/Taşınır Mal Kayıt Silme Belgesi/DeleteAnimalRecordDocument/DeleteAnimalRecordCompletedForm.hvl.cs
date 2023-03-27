
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
    public partial class DeleteAnimalRecordCompletedForm : BaseDeleteAnimalRecordForm
    {
    /// <summary>
    /// Taşınır Mal Kayıt Silme Belgesi
    /// </summary>
        protected TTObjectClasses.DeleteAnimalRecordDocument _DeleteAnimalRecordDocument
        {
            get { return (TTObjectClasses.DeleteAnimalRecordDocument)_ttObject; }
        }

        protected ITTTabPage ChattelDocuments;
        protected ITTGrid DocumentRecordLogs;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn NumberOfRowsDocumentRecordLog;
        protected ITTTextBoxColumn TakenGivenPlaceDocumentRecordLog;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        override protected void InitializeControls()
        {
            ChattelDocuments = (ITTTabPage)AddControl(new Guid("a4f7670a-4f08-413b-9838-1ae78442b17b"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("9b08ca6a-7237-4916-8489-f65a93bdb923"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("6c67980c-cb7e-4a3a-8b6a-caedeee4782f"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("8e743152-1736-470d-ac22-4e4ca74a9dbb"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("9589135c-7491-4867-b51d-bae2adc6f07c"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("1f670d81-e843-46c7-80d0-4cecbbeac071"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("1e85815e-ea8f-4b75-bae0-ff9f14de9880"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("487a13e0-446d-4e73-8aa0-dc5956b695d7"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("d3fabf78-542d-42a1-b2c3-ea486b08ebe1"));
            base.InitializeControls();
        }

        public DeleteAnimalRecordCompletedForm() : base("DELETEANIMALRECORDDOCUMENT", "DeleteAnimalRecordCompletedForm")
        {
        }

        protected DeleteAnimalRecordCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}