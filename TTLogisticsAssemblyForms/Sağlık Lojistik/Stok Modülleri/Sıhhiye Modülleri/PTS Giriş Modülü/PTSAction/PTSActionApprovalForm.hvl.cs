
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
    public partial class PTSActionApprovalForm : BasePTSActionForm
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
            Supplier = (ITTObjectListBox)AddControl(new Guid("582fe25c-8475-449a-9d0d-2a241d9e19cc"));
            labelSupplier = (ITTLabel)AddControl(new Guid("e46e9058-6d60-4ff3-997d-5416a677a339"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("5f760e06-40ec-4b45-860c-a058e2b6cc4f"));
            labelExaminationReportNo = (ITTLabel)AddControl(new Guid("86fbe9ba-4738-4ec8-a99e-6a5a45001bdc"));
            ConclusionDateTime = (ITTDateTimePicker)AddControl(new Guid("a7552cb6-cff9-4306-bb51-6af47f3d5bfd"));
            ExaminationReportNo = (ITTTextBox)AddControl(new Guid("b366c799-a1ed-46da-9854-b88554622ede"));
            labelConclusionDateTime = (ITTLabel)AddControl(new Guid("d9686143-8826-4c1b-8391-49e8e15c2a7e"));
            labelExaminationReportDate = (ITTLabel)AddControl(new Guid("b073e104-a221-4d5d-9e8e-587b737877fc"));
            ConclusionNumber = (ITTTextBox)AddControl(new Guid("9db3d4b7-b29e-47d0-8e6b-da3d4f87a711"));
            ExaminationReportDate = (ITTDateTimePicker)AddControl(new Guid("1a2da9d5-7846-4f18-8e8c-88f3e82880c9"));
            labelConclusionNumber = (ITTLabel)AddControl(new Guid("0fbe18ea-7684-4ad8-bd7f-f48a74e84faa"));
            labelContractNumber = (ITTLabel)AddControl(new Guid("686c8685-c293-4f0c-ac09-bc2803fe1a7e"));
            ContractDateTime = (ITTDateTimePicker)AddControl(new Guid("1ce9ab52-11b8-4407-bb54-f815a8025ac5"));
            ContractNumber = (ITTTextBox)AddControl(new Guid("34cab89d-d40d-4815-8246-40e7ef0ac51c"));
            labelContractDateTime = (ITTLabel)AddControl(new Guid("3b3ef373-f9e1-4524-8565-35e21212f5f6"));
            base.InitializeControls();
        }

        public PTSActionApprovalForm() : base("PTSACTION", "PTSActionApprovalForm")
        {
        }

        protected PTSActionApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}