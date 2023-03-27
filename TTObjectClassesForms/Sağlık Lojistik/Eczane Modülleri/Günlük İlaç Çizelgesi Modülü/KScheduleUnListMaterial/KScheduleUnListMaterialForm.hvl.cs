
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
    /// Çıkmayan İlaçlar Detayı
    /// </summary>
    public partial class KScheduleUnListMaterialForm : TTForm
    {
        protected TTObjectClasses.KScheduleUnListMaterial _KScheduleUnListMaterial
        {
            get { return (TTObjectClasses.KScheduleUnListMaterial)_ttObject; }
        }

        protected ITTGrid DrugOrderDetails;
        protected ITTDateTimePickerColumn OrderPlannedDateDrugOrderDetail;
        protected ITTEnumComboBoxColumn FrequencyDrugOrderDetail;
        protected ITTTextBoxColumn DoseAmountDrugOrderDetail;
        protected ITTTextBoxColumn AmountDrugOrderDetail;
        protected ITTLabel labelUnlistReason;
        protected ITTTextBox UnlistReason;
        protected ITTTextBox UnlistPatient;
        protected ITTTextBox UnlistDrug;
        protected ITTTextBox UnlistAmount;
        protected ITTLabel labelUnlistPatient;
        protected ITTLabel labelUnlistDrug;
        protected ITTLabel labelUnlistAmount;
        override protected void InitializeControls()
        {
            DrugOrderDetails = (ITTGrid)AddControl(new Guid("29ac742b-284d-44cf-a7ff-8cf559722e4f"));
            OrderPlannedDateDrugOrderDetail = (ITTDateTimePickerColumn)AddControl(new Guid("c6456d35-fa12-4235-acbe-0a716ddb091a"));
            FrequencyDrugOrderDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("4a47d4dc-6551-4a1b-a9db-f00f9078d8f4"));
            DoseAmountDrugOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("bf9fae93-f73d-46ad-bc95-1db95138ee6c"));
            AmountDrugOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("744041e5-6464-4f9c-b2b3-7bfeae01e0ab"));
            labelUnlistReason = (ITTLabel)AddControl(new Guid("c89843c3-6947-448f-8f4c-e1d5712a4542"));
            UnlistReason = (ITTTextBox)AddControl(new Guid("55f10484-fda8-4d9d-9bdb-c6feb1fa0430"));
            UnlistPatient = (ITTTextBox)AddControl(new Guid("56c6d593-d7de-421e-aae4-61625258b4e2"));
            UnlistDrug = (ITTTextBox)AddControl(new Guid("ffc31391-98a1-463d-bb61-59bf39b8e18a"));
            UnlistAmount = (ITTTextBox)AddControl(new Guid("be6645d4-5f11-49bc-9984-cdcb0031b5fe"));
            labelUnlistPatient = (ITTLabel)AddControl(new Guid("0eac909b-66ce-4c3a-bc28-6d352322711b"));
            labelUnlistDrug = (ITTLabel)AddControl(new Guid("5738037d-07d2-42f9-93ef-fd4f475a4c6f"));
            labelUnlistAmount = (ITTLabel)AddControl(new Guid("21a5392a-dc02-4310-b074-52a85d5be6f7"));
            base.InitializeControls();
        }

        public KScheduleUnListMaterialForm() : base("KSCHEDULEUNLISTMATERIAL", "KScheduleUnListMaterialForm")
        {
        }

        protected KScheduleUnListMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}