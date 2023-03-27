
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
    /// PTS Giriş İşlemi
    /// </summary>
    public partial class PTSActionCreateInputForm : BasePTSActionForm
    {
    /// <summary>
    /// PTS Giriş İşlemi
    /// </summary>
        protected TTObjectClasses.PTSAction _PTSAction
        {
            get { return (TTObjectClasses.PTSAction)_ttObject; }
        }

        protected ITTObjectListBox Supplier;
        protected ITTLabel labelSupplier;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel lblDocumentStatus;
        protected ITTLabel ttlabel8;
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
        override protected void InitializeControls()
        {
            Supplier = (ITTObjectListBox)AddControl(new Guid("3b3fb4f1-10df-4e28-860f-f62fc139789a"));
            labelSupplier = (ITTLabel)AddControl(new Guid("b7d6d608-6428-4b9a-b82a-0849e84a5f58"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("0d8855ef-f6c8-4b06-8912-f53e30d004aa"));
            lblDocumentStatus = (ITTLabel)AddControl(new Guid("ab96d9da-468c-4f33-a19f-70781dab5382"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("52f062b2-0a17-43e3-9778-ba77ba11b402"));
            labelExaminationReportNo = (ITTLabel)AddControl(new Guid("278d7a3e-fbc6-4b2f-ae57-8919e2ce226a"));
            ConclusionDateTime = (ITTDateTimePicker)AddControl(new Guid("f8c4d7db-5908-44c8-b621-0f0699b30946"));
            ExaminationReportNo = (ITTTextBox)AddControl(new Guid("e6cfde96-9e54-474c-8caa-1b24904bf84f"));
            labelConclusionDateTime = (ITTLabel)AddControl(new Guid("66187882-591a-4043-841f-ef497abba855"));
            labelExaminationReportDate = (ITTLabel)AddControl(new Guid("b79a7926-bf06-4bba-be42-e1b2b611657c"));
            ConclusionNumber = (ITTTextBox)AddControl(new Guid("b34b4472-0300-45d6-a5e3-cb1fa22fabab"));
            ExaminationReportDate = (ITTDateTimePicker)AddControl(new Guid("e6a6a6d5-a414-4de5-9fb4-5e192fa1458b"));
            labelConclusionNumber = (ITTLabel)AddControl(new Guid("9af7d3b2-803e-496f-be16-c54f3f185a88"));
            labelContractNumber = (ITTLabel)AddControl(new Guid("9156cbf5-400b-4f42-b4a9-ce4d6efa08e2"));
            ContractDateTime = (ITTDateTimePicker)AddControl(new Guid("c0adce4e-0a0f-4fc1-be24-92a824fb3e63"));
            ContractNumber = (ITTTextBox)AddControl(new Guid("b84b0e42-d75c-4448-91ac-58be8284b97f"));
            labelContractDateTime = (ITTLabel)AddControl(new Guid("96a68644-dddd-43e2-bb6d-1f8759b2568a"));
            base.InitializeControls();
        }

        public PTSActionCreateInputForm() : base("PTSACTION", "PTSActionCreateInputForm")
        {
        }

        protected PTSActionCreateInputForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}