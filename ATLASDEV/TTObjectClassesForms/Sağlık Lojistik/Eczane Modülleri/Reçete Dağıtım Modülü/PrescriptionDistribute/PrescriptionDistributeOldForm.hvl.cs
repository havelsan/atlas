
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
    public partial class PrescriptionDistributeOldForm : TTForm
    {
    /// <summary>
    /// Reçete Dağıtım
    /// </summary>
        protected TTObjectClasses.PrescriptionDistribute _PrescriptionDistribute
        {
            get { return (TTObjectClasses.PrescriptionDistribute)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTButton cmdSelectPharmacy;
        protected ITTGrid PharmacyGrid;
        protected ITTTextBoxColumn PharmacyName;
        protected ITTTextBoxColumn Balance;
        protected ITTTextBoxColumn Guid;
        protected ITTComboBox PharmacyCountCombo;
        protected ITTLabel ttlabel2;
        protected ITTButton cmdDistribute;
        protected ITTButton cmdClear;
        protected ITTGroupBox ttgroupbox3;
        protected ITTGrid DistributeGrid;
        protected ITTTextBoxColumn DPrescriptionNo;
        protected ITTTextBoxColumn DPatientNo;
        protected ITTTextBoxColumn DProtocolNo;
        protected ITTTextBoxColumn DQuarantineNo;
        protected ITTTextBoxColumn DResource;
        protected ITTTextBoxColumn DPrice;
        protected ITTTextBoxColumn DPharmacy;
        protected ITTTextBoxColumn PrescriptionGuid;
        protected ITTTextBoxColumn PharmacyGuid;
        protected ITTGroupBox ttgroupbox1;
        protected ITTButton cmdSelect;
        protected ITTButton cmdUnSelect;
        protected ITTGrid PrescriptionGrid;
        protected ITTCheckBoxColumn Distribute;
        protected ITTTextBoxColumn PPrescriptionType;
        protected ITTTextBoxColumn PPrescriptionNo;
        protected ITTTextBoxColumn PPatientName;
        protected ITTTextBoxColumn PQuarantineNo;
        protected ITTTextBoxColumn PProtocolNo;
        protected ITTTextBoxColumn PResource;
        protected ITTTextBoxColumn PPrice;
        protected ITTTextBoxColumn PGuid;
        protected ITTDateTimePicker PrescriptionDateTime;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("366693e4-68e2-4771-bc1e-55d6aa363fa0"));
            cmdSelectPharmacy = (ITTButton)AddControl(new Guid("77038e60-2fc0-4960-a644-48a0200770fa"));
            PharmacyGrid = (ITTGrid)AddControl(new Guid("772b2b72-416d-4578-8bef-6af2fe0ea6d4"));
            PharmacyName = (ITTTextBoxColumn)AddControl(new Guid("69865286-e883-401d-a6e0-d88780b1cbc2"));
            Balance = (ITTTextBoxColumn)AddControl(new Guid("acdca409-738e-4e28-b7ea-c3b1c6f7f372"));
            Guid = (ITTTextBoxColumn)AddControl(new Guid("f0bad645-9e47-4598-ba08-5eac7d953e00"));
            PharmacyCountCombo = (ITTComboBox)AddControl(new Guid("336b2995-0164-48c9-a090-779a3db4c4d9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("179aa1f1-7fe0-42bb-b0da-c1d87b7614fa"));
            cmdDistribute = (ITTButton)AddControl(new Guid("40a87b5d-3abb-4473-ac1a-ce53631274e3"));
            cmdClear = (ITTButton)AddControl(new Guid("1e610578-4cc8-45e7-9099-327271a2a663"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("669bdf68-b4ff-4dce-a707-67bc65e1f372"));
            DistributeGrid = (ITTGrid)AddControl(new Guid("94d2f7df-a4b4-480d-90a2-06d86915c826"));
            DPrescriptionNo = (ITTTextBoxColumn)AddControl(new Guid("0f2089d0-197f-4dd8-a614-df3d65cba753"));
            DPatientNo = (ITTTextBoxColumn)AddControl(new Guid("0d39b396-2144-4e69-8548-a0a8f500f754"));
            DProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("171cb8aa-0cac-46ec-977b-4d6991ce263c"));
            DQuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("edc09b3e-ccc4-4577-87b5-7e7d9fe4c21f"));
            DResource = (ITTTextBoxColumn)AddControl(new Guid("de6b0b82-18ba-4866-9a6b-9aa32bf71a31"));
            DPrice = (ITTTextBoxColumn)AddControl(new Guid("be5d955c-e396-49e2-a687-8657620c459a"));
            DPharmacy = (ITTTextBoxColumn)AddControl(new Guid("dcaf1fcb-25b3-4d12-8c2d-34fb1826da8c"));
            PrescriptionGuid = (ITTTextBoxColumn)AddControl(new Guid("5e4c3f86-0e62-4b03-923b-cf6205da4f1f"));
            PharmacyGuid = (ITTTextBoxColumn)AddControl(new Guid("d966e34c-e384-470d-8061-e8b0450d4301"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c79127fd-2ac8-4285-a6e6-72c8c5cac6fa"));
            cmdSelect = (ITTButton)AddControl(new Guid("79a5a9d5-d243-4a2d-9ec0-a813dbd33773"));
            cmdUnSelect = (ITTButton)AddControl(new Guid("2342626e-d738-466e-af83-182fd4368807"));
            PrescriptionGrid = (ITTGrid)AddControl(new Guid("2f0cf2a3-dce5-4ec5-b026-96c19ad66536"));
            Distribute = (ITTCheckBoxColumn)AddControl(new Guid("96480d94-9c2f-4c9f-b672-20564826ab46"));
            PPrescriptionType = (ITTTextBoxColumn)AddControl(new Guid("02f05ed7-6687-4e80-9860-ecf15b6907c9"));
            PPrescriptionNo = (ITTTextBoxColumn)AddControl(new Guid("42447185-d1e4-48e6-a6b1-cc3ffdffc51f"));
            PPatientName = (ITTTextBoxColumn)AddControl(new Guid("90cee46b-0473-42fd-b936-843c5ca896f3"));
            PQuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("dd9c49db-067c-48cc-946c-e3f6e2d6b4c3"));
            PProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("eca0bf91-71bd-4628-bb37-e3be43d6f35f"));
            PResource = (ITTTextBoxColumn)AddControl(new Guid("94cdc9e7-3b21-4780-9be2-57504af8abc1"));
            PPrice = (ITTTextBoxColumn)AddControl(new Guid("aaca3646-5c98-4e8b-9e98-0df0bb4b41ef"));
            PGuid = (ITTTextBoxColumn)AddControl(new Guid("9efc9fb6-88f2-40e7-a265-44992c78e239"));
            PrescriptionDateTime = (ITTDateTimePicker)AddControl(new Guid("afc43150-24a1-43a5-abe3-1ad78f2c6b0f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e7f82339-667c-49a6-8435-3933c6df0877"));
            base.InitializeControls();
        }

        public PrescriptionDistributeOldForm() : base("PRESCRIPTIONDISTRIBUTE", "PrescriptionDistributeOldForm")
        {
        }

        protected PrescriptionDistributeOldForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}