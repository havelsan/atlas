
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
    public partial class CensusFixedCompletedForm : BaseCensusFixedForm
    {
    /// <summary>
    /// Sayım Düzeltme Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.CensusFixed _CensusFixed
        {
            get { return (TTObjectClasses.CensusFixed)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLogTabpage;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage documentRecordLogTab;
        protected ITTGrid DocumentRecordLogs;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTEnumComboBoxColumn BUDGETYPE;
        protected ITTTextBoxColumn NumberOfRowsDocumentRecordLog;
        protected ITTTextBoxColumn TakenGivenPlaceDocumentRecordLog;
        protected ITTTextBoxColumn ReceiptNumber;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTTextBox SequenceNumber;
        protected ITTTextBox RegistrationNumber;
        protected ITTLabel labelRegistrationNumber;
        protected ITTLabel labelSequenceNumber;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("1b57dab6-71cc-410b-becd-c17d66b227eb"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e3208403-a62e-49a6-af2d-a977a2a850a6"));
            documentRecordLogTab = (ITTTabPage)AddControl(new Guid("fd8df744-75d1-4a58-9f77-1057628a7228"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("970315ce-e548-40eb-af9e-42abafe1b918"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("bdce035e-c898-408e-a6ea-a718956d033b"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("22957da4-ee1a-4730-a854-1735304d1da9"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("c27c952f-0caa-405e-9d2a-6a1476b34c41"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("82876f0f-675f-4edf-996a-2e40aab041c7"));
            BUDGETYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("080cecde-ce53-4a6f-a567-552344f7816b"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("b9b91093-b08e-4b82-92a1-d93e1be04e8c"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("cc539384-17c3-4f6f-ba40-fc81ac9ec73f"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("024d194b-074d-4ea1-a46b-478a9cc2c5f3"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("2fabde7b-55d0-498f-82e7-737aef2f7923"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("e1689014-0150-4493-bbbc-2de219f7d67f"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("20335389-81a4-490b-99b5-4ce09695683b"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("5987ba40-a32e-4265-9b9d-29f531f4b24b"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("1a148e8f-3984-4237-b416-0fb28e6ddec0"));
            SendToMKYS = (ITTButton)AddControl(new Guid("3b4176dc-f202-450d-9173-92ffe71b1069"));
            base.InitializeControls();
        }

        public CensusFixedCompletedForm() : base("CENSUSFIXED", "CensusFixedCompletedForm")
        {
        }

        protected CensusFixedCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}