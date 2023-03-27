
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
    /// Sayım Düzeltme Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresCensusFixedCompletedForm : BasePresCensusFixedForm
    {
    /// <summary>
    /// Sayım Düzeltme Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresCensusFixed _PresCensusFixed
        {
            get { return (TTObjectClasses.PresCensusFixed)_ttObject; }
        }

        protected ITTTextBox SequenceNumber;
        protected ITTTextBox RegistrationNumber;
        protected ITTLabel labelRegistrationNumber;
        protected ITTLabel labelSequenceNumber;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTCheckBoxColumn ttcheckboxcolumn1;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox tttextbox3;
        protected ITTTabPage DocumentRecordLogTabpage;
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
            SequenceNumber = (ITTTextBox)AddControl(new Guid("4327a873-fdd7-4e7d-b69d-0ff45ab946b4"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("646a263f-ed1b-45b9-84e1-d3506436efec"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("ebcf3f87-7fec-45d1-bbb4-dc2648928626"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("b4d2cc96-2dc4-40b5-a3ee-c2b1b0e31b52"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("31a45417-e2d6-4680-be19-cbfda1079f81"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("1050d5a5-c73c-4358-8aeb-877543342ad1"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("572c08cb-3bf6-429e-a8d5-e8990b480569"));
            ttenumcomboboxcolumn1 = (ITTEnumComboBoxColumn)AddControl(new Guid("b00b0ebd-0a18-46d5-b461-a2b514533e2f"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("82347462-8c83-4864-862f-3c49b1ec0bbf"));
            ttcheckboxcolumn1 = (ITTCheckBoxColumn)AddControl(new Guid("8c466796-f021-4f2a-af07-f5e807537f8f"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("5e81998a-6236-4860-a74b-c4227f67accf"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("2b026d56-c78c-4dbc-b94a-df59b24ff1e9"));
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("7ec867f9-1bcb-4e37-8036-d86b00ca34ae"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("1ac67e82-abd0-41f0-8c82-43d09206322c"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("c04c4b73-9de7-4cf4-89b7-bc472fb31911"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("15f575ef-58cc-40f1-b6c5-fc4765e60ae9"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("01a6bd95-69fd-49e9-8c39-3171d9c98aed"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("2e2a59df-ec54-4ad5-94e3-9557163c9bd5"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("f813073e-0e09-4252-b32c-56cb84467d8c"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("5c3b408c-ced5-47e8-a83e-ece65becdf29"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("50a5162f-4449-42e8-80f3-769bbb442750"));
            base.InitializeControls();
        }

        public PresCensusFixedCompletedForm() : base("PRESCENSUSFIXED", "PresCensusFixedCompletedForm")
        {
        }

        protected PresCensusFixedCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}