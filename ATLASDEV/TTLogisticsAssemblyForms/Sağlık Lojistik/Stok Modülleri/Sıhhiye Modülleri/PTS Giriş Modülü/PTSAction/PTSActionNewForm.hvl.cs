
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
    public partial class PTSActionNewForm : BasePTSActionForm
    {
    /// <summary>
    /// PTS Giriş İşlemi
    /// </summary>
        protected TTObjectClasses.PTSAction _PTSAction
        {
            get { return (TTObjectClasses.PTSAction)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelExaminationReportNo;
        protected ITTDateTimePicker ConclusionDateTime;
        protected ITTTextBox ExaminationReportNo;
        protected ITTLabel labelConclusionDateTime;
        protected ITTLabel labelExaminationReportDate;
        protected ITTTextBox ConclusionNumber;
        protected ITTDateTimePicker ExaminationReportDate;
        protected ITTLabel labelConclusionNumber;
        protected ITTLabel labelContractNumber;
        protected ITTDateTimePicker ContractDateTime;
        protected ITTTextBox ContractNumber;
        protected ITTLabel labelContractDateTime;
        protected ITTLabel labelSupplier;
        protected ITTObjectListBox Supplier;
        protected ITTButton btnGetFromFile;
        protected ITTButton btnGetFromPTSID;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("99267e1a-aa7c-4cae-a383-c91a6b63db9d"));
            labelExaminationReportNo = (ITTLabel)AddControl(new Guid("93ebe680-8ce6-409e-9407-7270bbac1bc4"));
            ConclusionDateTime = (ITTDateTimePicker)AddControl(new Guid("06d8d592-92f3-4a13-9e00-2eb176f19903"));
            ExaminationReportNo = (ITTTextBox)AddControl(new Guid("6ce023f7-0765-4a76-9852-1092b1f2bdb3"));
            labelConclusionDateTime = (ITTLabel)AddControl(new Guid("a5487ac4-e589-48d1-8dfd-2c9d29a86ffd"));
            labelExaminationReportDate = (ITTLabel)AddControl(new Guid("6dde5378-f531-42ef-898c-7e7af3887a88"));
            ConclusionNumber = (ITTTextBox)AddControl(new Guid("36878b70-9ac9-4d4c-b095-b86e6c66c97d"));
            ExaminationReportDate = (ITTDateTimePicker)AddControl(new Guid("0c3226bb-7b77-4031-92e5-cc38a513aab6"));
            labelConclusionNumber = (ITTLabel)AddControl(new Guid("2690f9a3-55e8-48c8-a601-ebdfa85f9d44"));
            labelContractNumber = (ITTLabel)AddControl(new Guid("c043d822-6a1d-4535-a3d7-c5e158079ea3"));
            ContractDateTime = (ITTDateTimePicker)AddControl(new Guid("53ee26b8-a0fa-4424-b006-f012c87a4f5b"));
            ContractNumber = (ITTTextBox)AddControl(new Guid("26152e87-9946-43bf-a3cd-840eb0e3ba8b"));
            labelContractDateTime = (ITTLabel)AddControl(new Guid("0cf331e8-f52e-4a9e-b497-56f9ec63a97b"));
            labelSupplier = (ITTLabel)AddControl(new Guid("d58c22c1-202f-4938-a4c8-aa9d2237d62e"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("49d2fe52-0a93-42c0-9f64-8531cf7cf88f"));
            btnGetFromFile = (ITTButton)AddControl(new Guid("6532a8cb-e95e-437b-80a6-b0e6bcbfca97"));
            btnGetFromPTSID = (ITTButton)AddControl(new Guid("d6a20eb1-0718-423b-895e-d330bd292b42"));
            base.InitializeControls();
        }

        public PTSActionNewForm() : base("PTSACTION", "PTSActionNewForm")
        {
        }

        protected PTSActionNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}