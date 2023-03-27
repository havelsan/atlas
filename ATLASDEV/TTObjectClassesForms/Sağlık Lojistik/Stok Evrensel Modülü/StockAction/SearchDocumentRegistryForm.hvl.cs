
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
    public partial class SearchDocumentRegistryForm : TTListForm
    {
        protected ITTLabel labelRegistrationNumber;
        protected ITTDateTimePicker StartDate;
        protected ITTTextBox SequenceNumber;
        protected ITTTextBox RegistrationNumber;
        protected ITTObjectListBox FromStore;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelAccountancy;
        protected ITTLabel labelFromStore;
        protected ITTObjectListBox AccountingTerm;
        protected ITTLabel labelAccountingTerm;
        protected ITTLabel labelSequenceNumber;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTComboBox SubjectComboBox;
        protected ITTLabel labelBelgeCesidi;
        override protected void InitializeControls()
        {
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("e16f8655-e01e-4d2d-bf02-82ef230da958"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("36857697-a51e-4e7f-81a7-240d97c4f30d"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("b0822672-447b-4fc7-b40f-4e743f8023d1"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("9a951e53-3875-4470-90e0-375c67c64459"));
            FromStore = (ITTObjectListBox)AddControl(new Guid("a658d6ef-740b-4608-bcf8-0c992a7fb102"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("84a85812-cdcd-4c06-9aea-0cbda54e8448"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("2b312bd9-7458-40c0-848f-49b1d3eca875"));
            labelFromStore = (ITTLabel)AddControl(new Guid("dc7cf40b-02d3-4e6e-a00e-c1de9c97617d"));
            AccountingTerm = (ITTObjectListBox)AddControl(new Guid("aedb4bae-a9a9-41ad-90a6-5baefecc8a14"));
            labelAccountingTerm = (ITTLabel)AddControl(new Guid("13f89c6a-ed02-4c66-9581-cadfd9eb1d8c"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("4c2b9c18-019f-46e6-bb3c-fc159ba4b457"));
            labelStartDate = (ITTLabel)AddControl(new Guid("04bd5a2b-d348-49cd-befe-92383d5bbd88"));
            labelEndDate = (ITTLabel)AddControl(new Guid("050775e7-a406-4a94-a2a0-9dac8af44d3a"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("99aca3ec-b0a9-4b55-acfc-756da343df6e"));
            SubjectComboBox = (ITTComboBox)AddControl(new Guid("e1d83074-2f51-4904-990d-e58002940d15"));
            labelBelgeCesidi = (ITTLabel)AddControl(new Guid("a8249936-ce9b-4d06-a07e-73a750c77a19"));
            base.InitializeControls();
        }

        public SearchDocumentRegistryForm(TTList ttList) : base(ttList, "STOCKACTION", "SearchDocumentRegistryForm")
        {
        }
    }
}