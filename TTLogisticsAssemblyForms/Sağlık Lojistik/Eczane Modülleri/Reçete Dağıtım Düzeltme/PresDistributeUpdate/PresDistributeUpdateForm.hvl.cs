
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
    /// Reçete Dağıtım Düzeltme
    /// </summary>
    public partial class PresDistributeUpdateForm : TTForm
    {
    /// <summary>
    /// Reçete Dağıtım Düzeltme
    /// </summary>
        protected TTObjectClasses.PresDistributeUpdate _PresDistributeUpdate
        {
            get { return (TTObjectClasses.PresDistributeUpdate)_ttObject; }
        }

        protected ITTButton cmdGetPrescriptionDis;
        protected ITTGrid PresDistributeUpdateDetails;
        protected ITTCheckBoxColumn IsCancelPresDistributeUpdateDetail;
        protected ITTTextBoxColumn PrescriptionNo;
        protected ITTTextBoxColumn PatientNamePresDistributeUpdateDetail;
        protected ITTTextBoxColumn PatientProtocolNoPresDistributeUpdateDetail;
        protected ITTTextBoxColumn PatientQuarantineNoPresDistributeUpdateDetail;
        protected ITTTextBoxColumn PricePresDistributeUpdateDetail;
        protected ITTListBoxColumn ExternalPharmacyPresDistributeUpdateDetail;
        protected ITTListBoxColumn PrescriptionPresDistributeUpdateDetail;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTTextBox DistributeID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelDistributeID;
        override protected void InitializeControls()
        {
            cmdGetPrescriptionDis = (ITTButton)AddControl(new Guid("4ba9a331-5f65-4dc7-8685-8e9fdb96d8f7"));
            PresDistributeUpdateDetails = (ITTGrid)AddControl(new Guid("3f0de23c-55ab-4010-8f90-4bf6673dbad7"));
            IsCancelPresDistributeUpdateDetail = (ITTCheckBoxColumn)AddControl(new Guid("792e3ce0-adb1-49d0-8ebc-5cc783885af4"));
            PrescriptionNo = (ITTTextBoxColumn)AddControl(new Guid("e3484a96-84ac-424e-b8f9-8a4d857f9e3f"));
            PatientNamePresDistributeUpdateDetail = (ITTTextBoxColumn)AddControl(new Guid("7de6d437-ad1a-4431-a0f7-78c636373bba"));
            PatientProtocolNoPresDistributeUpdateDetail = (ITTTextBoxColumn)AddControl(new Guid("a585a335-f52d-46c7-b0da-65b7e78c2f71"));
            PatientQuarantineNoPresDistributeUpdateDetail = (ITTTextBoxColumn)AddControl(new Guid("d4192967-3fd4-4e63-8543-2bba47c4a3c2"));
            PricePresDistributeUpdateDetail = (ITTTextBoxColumn)AddControl(new Guid("5d267d61-72ee-4cf5-8d11-4b0b6919f080"));
            ExternalPharmacyPresDistributeUpdateDetail = (ITTListBoxColumn)AddControl(new Guid("a425abe6-7fc7-433b-9973-dac3cf4690d5"));
            PrescriptionPresDistributeUpdateDetail = (ITTListBoxColumn)AddControl(new Guid("2f282ebd-3f3f-4bcc-95a8-16650d810b5c"));
            labelID = (ITTLabel)AddControl(new Guid("07f24e05-0613-494e-bab2-e43b5eb5a01d"));
            ID = (ITTTextBox)AddControl(new Guid("dbfee4c2-afbd-4c65-a2b3-749507cbe07a"));
            DistributeID = (ITTTextBox)AddControl(new Guid("a700aee8-f149-43ad-a5e6-08c15257c4cf"));
            labelActionDate = (ITTLabel)AddControl(new Guid("ede24caa-79d9-4000-9f15-171564f3c88f"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("bc35f8f9-bde8-4b65-a879-9a2e14c8ca51"));
            labelDistributeID = (ITTLabel)AddControl(new Guid("2f37445d-6098-4193-a465-84cafe4da369"));
            base.InitializeControls();
        }

        public PresDistributeUpdateForm() : base("PRESDISTRIBUTEUPDATE", "PresDistributeUpdateForm")
        {
        }

        protected PresDistributeUpdateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}