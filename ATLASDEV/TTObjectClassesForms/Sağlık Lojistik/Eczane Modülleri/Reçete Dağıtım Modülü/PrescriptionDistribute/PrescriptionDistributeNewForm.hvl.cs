
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
    /// Reçete Dağıtım
    /// </summary>
    public partial class PrescriptionDistributeNewForm : TTForm
    {
    /// <summary>
    /// Reçete Dağıtım
    /// </summary>
        protected TTObjectClasses.PrescriptionDistribute _PrescriptionDistribute
        {
            get { return (TTObjectClasses.PrescriptionDistribute)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox3;
        protected ITTGrid DistributeDetails;
        protected ITTListBoxColumn PrescriptionPaper;
        protected ITTTextBoxColumn DistPrescNo;
        protected ITTTextBoxColumn DistPatientNo;
        protected ITTTextBoxColumn DistProtocolNo;
        protected ITTTextBoxColumn DistQuarantineNo;
        protected ITTTextBoxColumn DistResource;
        protected ITTTextBoxColumn DistPrice;
        protected ITTTextBoxColumn DistPharmacy;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid PharmacyDetails;
        protected ITTTextBoxColumn Pharmacy;
        protected ITTTextBoxColumn Balance;
        protected ITTTextBoxColumn PrescriptionCount;
        protected ITTTextBoxColumn PharmacyGuid;
        protected ITTButton cmdDistribute;
        protected ITTButton cmdSelectPharmacy;
        protected ITTComboBox PharmacyCountCombo;
        protected ITTLabel ttlabel2;
        protected ITTButton cmdClear;
        protected ITTGroupBox QuarantineProtocolNo;
        protected ITTGrid PrescriptionDetails;
        protected ITTCheckBoxColumn Distribute;
        protected ITTTextBoxColumn PrescriptionType;
        protected ITTTextBoxColumn DistributeNo;
        protected ITTTextBoxColumn PrescriptionNo;
        protected ITTTextBoxColumn PatientName;
        protected ITTTextBoxColumn PatientMilitaryUnit;
        protected ITTTextBoxColumn QuarantineNo;
        protected ITTTextBoxColumn ProtocolNo;
        protected ITTTextBoxColumn Resource;
        protected ITTTextBoxColumn Price;
        protected ITTTextBoxColumn PrescriptionGuid;
        protected ITTButton cmdSelect;
        protected ITTButton cmdUnSelect;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        protected ITTTextBox ID;
        protected ITTDateTimePicker PrescriptionDateTime;
        protected ITTLabel labelID;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("0fb24c4f-bbdb-4eaa-9faa-1d40c8394ee9"));
            DistributeDetails = (ITTGrid)AddControl(new Guid("c1543484-807b-4467-bb2a-bcda77c544a5"));
            PrescriptionPaper = (ITTListBoxColumn)AddControl(new Guid("bd2ab6ae-b97c-4779-803a-6e5dce10809a"));
            DistPrescNo = (ITTTextBoxColumn)AddControl(new Guid("2c81c007-20ed-49de-825e-bce1243d9d1a"));
            DistPatientNo = (ITTTextBoxColumn)AddControl(new Guid("36abec6f-274c-44ef-9d0f-e70fae8bcb99"));
            DistProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("589a6fc5-cc1a-4f78-9d8a-5864ad6fd72d"));
            DistQuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("b44f14f5-8863-489c-8683-9713d4b6e5fe"));
            DistResource = (ITTTextBoxColumn)AddControl(new Guid("67c1fbdb-8121-4038-ab05-8dc4437007e1"));
            DistPrice = (ITTTextBoxColumn)AddControl(new Guid("9c96176b-1aac-4397-bd9b-4aebbe2c085c"));
            DistPharmacy = (ITTTextBoxColumn)AddControl(new Guid("dc9826f5-bca1-417d-987d-e3d0f7f7640d"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("994b6591-dc20-4f80-aa02-407c17f58dcd"));
            PharmacyDetails = (ITTGrid)AddControl(new Guid("1dea5a00-a3db-4e15-86f9-41889cf7378c"));
            Pharmacy = (ITTTextBoxColumn)AddControl(new Guid("65eb5347-7b05-4e12-ba6a-76c6761d4082"));
            Balance = (ITTTextBoxColumn)AddControl(new Guid("efd0d8d9-ce45-4ed6-80a4-3f4c6010aed9"));
            PrescriptionCount = (ITTTextBoxColumn)AddControl(new Guid("74295ba3-edb8-4e09-b910-7e426e29e45c"));
            PharmacyGuid = (ITTTextBoxColumn)AddControl(new Guid("0cd2fa49-3b3b-4e1b-8ea2-49b9aa2f38a4"));
            cmdDistribute = (ITTButton)AddControl(new Guid("ba774835-d5e1-4a4e-9d16-7eca9dd153ec"));
            cmdSelectPharmacy = (ITTButton)AddControl(new Guid("e00c86f0-7126-4e64-b317-08a19420fcca"));
            PharmacyCountCombo = (ITTComboBox)AddControl(new Guid("325f1e4a-f718-4fa5-8508-23300399fdff"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("47786cd0-7695-4475-8679-3a36dbf8e916"));
            cmdClear = (ITTButton)AddControl(new Guid("2a574318-de22-43dc-beeb-6846cb020755"));
            QuarantineProtocolNo = (ITTGroupBox)AddControl(new Guid("5865786b-d7b2-4614-a928-fa89cac345cd"));
            PrescriptionDetails = (ITTGrid)AddControl(new Guid("9b992d00-f25f-43e9-8289-9607565d3276"));
            Distribute = (ITTCheckBoxColumn)AddControl(new Guid("f374de2c-50e6-4ddb-b680-82505a15be0c"));
            PrescriptionType = (ITTTextBoxColumn)AddControl(new Guid("0248b919-8910-44f5-8b9d-276ea77b2675"));
            DistributeNo = (ITTTextBoxColumn)AddControl(new Guid("043b98f4-4298-4b43-8955-e0aafeb292e1"));
            PrescriptionNo = (ITTTextBoxColumn)AddControl(new Guid("f80c9c55-23a0-4f8b-89f1-8b12c9f42e81"));
            PatientName = (ITTTextBoxColumn)AddControl(new Guid("f0b03bdb-d042-4f3a-a0f8-1894593863a4"));
            PatientMilitaryUnit = (ITTTextBoxColumn)AddControl(new Guid("6eec404d-8d19-49b0-9ce5-c576024ab52b"));
            QuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("908fdfc2-358d-497a-bc2e-5c234f9c3c13"));
            ProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("b2aad5f7-20e4-434f-80fc-d57212aa47e6"));
            Resource = (ITTTextBoxColumn)AddControl(new Guid("efddabdb-bfc3-4638-9ce7-52d7a580f9a2"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("9eb52853-14ba-45e4-8537-13316d7cad0d"));
            PrescriptionGuid = (ITTTextBoxColumn)AddControl(new Guid("70e17bf7-a967-450a-aecf-38ba70fda56b"));
            cmdSelect = (ITTButton)AddControl(new Guid("bfe5949e-23b9-45ef-a277-dd8341a8a207"));
            cmdUnSelect = (ITTButton)AddControl(new Guid("d7fd0b3a-cb92-42c0-87c3-ac670113e6b2"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("2f141172-94f6-42cb-96f4-bcc708048ed5"));
            labelActionDate = (ITTLabel)AddControl(new Guid("5a01fe93-774e-4c28-be54-713e43e72f45"));
            ID = (ITTTextBox)AddControl(new Guid("0932e683-6b3d-403e-addb-30dd41762c25"));
            PrescriptionDateTime = (ITTDateTimePicker)AddControl(new Guid("f7ff89d4-4f5f-4936-9d5a-f7fc72f09c32"));
            labelID = (ITTLabel)AddControl(new Guid("0a72fe09-73b4-45c7-81fc-87074929fc1d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a00c3e7c-dd4c-44e0-8184-bd12d183b254"));
            base.InitializeControls();
        }

        public PrescriptionDistributeNewForm() : base("PRESCRIPTIONDISTRIBUTE", "PrescriptionDistributeNewForm")
        {
        }

        protected PrescriptionDistributeNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}