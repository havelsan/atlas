
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
    public partial class SearchDocumentRecordLogForm : TTListForm
    {
        protected ITTComboBox SubjectComboBox;
        protected ITTLabel labelBelgeCesidi;
        protected ITTLabel labelTakenGivenPlace;
        protected ITTTextBox TakenGivenPlace;
        protected ITTTextBox DocumentRecordLogNumber;
        protected ITTLabel labelDocumentRecordLogNumber;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelAccountingTerm;
        protected ITTObjectListBox Accountancy;
        protected ITTObjectListBox AccountingTerm;
        protected ITTLabel labelAccountancy;
        override protected void InitializeControls()
        {
            SubjectComboBox = (ITTComboBox)AddControl(new Guid("464c9be8-bdfb-48e2-ad96-03edd7068d58"));
            labelBelgeCesidi = (ITTLabel)AddControl(new Guid("0449417e-e112-43c4-99c0-9ce6c3908b6f"));
            labelTakenGivenPlace = (ITTLabel)AddControl(new Guid("b1789461-9001-4534-9143-07efba8aebee"));
            TakenGivenPlace = (ITTTextBox)AddControl(new Guid("58595ca0-02c7-4370-86d1-6694cad05149"));
            DocumentRecordLogNumber = (ITTTextBox)AddControl(new Guid("6efd020f-a380-492b-a464-27f7f70ecd01"));
            labelDocumentRecordLogNumber = (ITTLabel)AddControl(new Guid("dd6cb887-a7fa-4c7d-9a28-0e3ecfc9f4ac"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("b5cd9949-8a90-49dd-a3af-e213ba6de831"));
            labelStartDate = (ITTLabel)AddControl(new Guid("f0de9a8a-2691-43c6-b393-5970d8226391"));
            labelEndDate = (ITTLabel)AddControl(new Guid("69e0ffdc-69ff-453a-b916-edc85fefa263"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("f72dca3b-59b7-42e8-b966-9d42156d6dfe"));
            labelAccountingTerm = (ITTLabel)AddControl(new Guid("aa32f57e-65d2-4974-81f9-b419443d9ced"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("35c1c74d-dbb4-49ef-91c5-1e7115c5a76c"));
            AccountingTerm = (ITTObjectListBox)AddControl(new Guid("88941002-227b-461e-a0f2-3f36a79e0d01"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("cdadd5f2-d0d1-4276-95c9-a005bac6082f"));
            base.InitializeControls();
        }

        public SearchDocumentRecordLogForm(TTList ttList) : base(ttList, "DOCUMENTRECORDLOG", "SearchDocumentRecordLogForm")
        {
        }
    }
}