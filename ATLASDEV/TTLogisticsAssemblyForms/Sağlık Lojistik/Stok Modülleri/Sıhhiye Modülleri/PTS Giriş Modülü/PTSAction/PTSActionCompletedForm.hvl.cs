
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
    public partial class PTSActionCompletedForm : BasePTSActionForm
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
            Supplier = (ITTObjectListBox)AddControl(new Guid("d753564d-9e1b-4e94-8381-2fe4789055de"));
            labelSupplier = (ITTLabel)AddControl(new Guid("c25aed52-1640-467a-927b-c95c6a2accd1"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("7dfac85d-a6bc-4fbb-9d86-9089cd9087e8"));
            lblDocumentStatus = (ITTLabel)AddControl(new Guid("67c97ddd-2280-4cfd-9512-917c5c1f63cc"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("e9c6cb34-00e5-4d8f-807b-3ad5ec339088"));
            labelExaminationReportNo = (ITTLabel)AddControl(new Guid("fe65a75c-63b7-4c88-a813-9cea1994a3bd"));
            ConclusionDateTime = (ITTDateTimePicker)AddControl(new Guid("d1d487b2-ed11-4948-b4c3-c83a5730b2d5"));
            ExaminationReportNo = (ITTTextBox)AddControl(new Guid("ceb67800-9b53-4dbc-a218-2f84f2272436"));
            labelConclusionDateTime = (ITTLabel)AddControl(new Guid("454487ba-af66-4a13-885f-2a3be0df31da"));
            labelExaminationReportDate = (ITTLabel)AddControl(new Guid("46abcce8-3efc-4c69-afb5-624e822ea11d"));
            ConclusionNumber = (ITTTextBox)AddControl(new Guid("db448c82-691e-4e03-b4b7-7b6ff7e37434"));
            ExaminationReportDate = (ITTDateTimePicker)AddControl(new Guid("194f3f07-3051-4fc9-9f35-20756066dd46"));
            labelConclusionNumber = (ITTLabel)AddControl(new Guid("36dd4c2e-ecc4-4b01-b658-b5f8f86bf0ec"));
            labelContractNumber = (ITTLabel)AddControl(new Guid("4ebbacdc-5abc-48aa-9c32-a9472eec229f"));
            ContractDateTime = (ITTDateTimePicker)AddControl(new Guid("1dd0775c-b140-46f7-98ee-a81c95e49ad1"));
            ContractNumber = (ITTTextBox)AddControl(new Guid("4c6f8f97-d2a6-4f62-a56e-837be1045b2d"));
            labelContractDateTime = (ITTLabel)AddControl(new Guid("d9d8b8e8-2231-48a3-a6be-37096d726461"));
            base.InitializeControls();
        }

        public PTSActionCompletedForm() : base("PTSACTION", "PTSActionCompletedForm")
        {
        }

        protected PTSActionCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}