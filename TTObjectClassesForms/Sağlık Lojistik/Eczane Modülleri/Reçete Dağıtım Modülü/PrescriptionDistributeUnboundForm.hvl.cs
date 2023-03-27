
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
    public partial class PrescriptionDistributeUnboundForm : TTUnboundForm
    {
        protected ITTButton ttbutton2;
        protected ITTButton ttbutton1;
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
        override protected void InitializeControls()
        {
            ttbutton2 = (ITTButton)AddControl(new Guid("502eefa9-9797-4a84-94be-76a977fa1635"));
            ttbutton1 = (ITTButton)AddControl(new Guid("22d21074-59e0-45b7-b425-7ee822e88e5c"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("d84db80a-5f26-4e29-95cc-a1bc1f6a20df"));
            cmdSelect = (ITTButton)AddControl(new Guid("9c5bb66e-7a60-4e30-9efb-84e30f2cc5ae"));
            cmdUnSelect = (ITTButton)AddControl(new Guid("ca67da43-c859-485c-8dcf-ab634b46ac20"));
            PrescriptionGrid = (ITTGrid)AddControl(new Guid("bef58a0d-4026-410a-ac6a-e581741e2993"));
            Distribute = (ITTCheckBoxColumn)AddControl(new Guid("74701fe4-d22a-4cfe-8cde-f27b77ddbc5d"));
            PPrescriptionType = (ITTTextBoxColumn)AddControl(new Guid("401ee8f7-b640-4d1c-8868-077617afedab"));
            PPrescriptionNo = (ITTTextBoxColumn)AddControl(new Guid("8a443f1b-218e-4a35-89af-7b6bbc45b160"));
            PPatientName = (ITTTextBoxColumn)AddControl(new Guid("bd8d581b-c334-4deb-a104-8bcd8d1ae2c4"));
            PQuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("1ff1e09d-55f3-48f9-a4f8-de6167bdd8fe"));
            PProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("946b5add-300a-4a64-ad69-258c5729c547"));
            PResource = (ITTTextBoxColumn)AddControl(new Guid("46bbb528-bdfd-407b-94f2-ebeca218d96a"));
            PPrice = (ITTTextBoxColumn)AddControl(new Guid("745ff47b-6185-4f19-998f-3c9337cdfca2"));
            PGuid = (ITTTextBoxColumn)AddControl(new Guid("7cad2018-091c-4fc7-83c7-55e52c4111ad"));
            PrescriptionDateTime = (ITTDateTimePicker)AddControl(new Guid("d6524547-fd26-495f-b8e0-41e7e29d8d67"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5c1dd3e1-16c7-4bcb-b64f-6e2fc80d69a8"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("1324766c-0689-4e76-9d62-853d6a13743b"));
            cmdSelectPharmacy = (ITTButton)AddControl(new Guid("a9beb369-c188-4b00-bf0f-b085b21e3f3a"));
            PharmacyGrid = (ITTGrid)AddControl(new Guid("30958353-52ac-470a-87ba-25883e5487ff"));
            PharmacyName = (ITTTextBoxColumn)AddControl(new Guid("b3faea4b-f618-49bf-a99b-338b131b9abe"));
            Balance = (ITTTextBoxColumn)AddControl(new Guid("351cb5a5-42c2-4776-9e0f-b453b7308ff8"));
            Guid = (ITTTextBoxColumn)AddControl(new Guid("a212d288-bcc8-41b2-8e85-7a32961e9f39"));
            PharmacyCountCombo = (ITTComboBox)AddControl(new Guid("03684af5-e85c-46cc-9e11-fd0aa53809f9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f8ca75eb-eaab-48cd-a2b2-422463cdc7c1"));
            cmdDistribute = (ITTButton)AddControl(new Guid("0d44c2b5-a59a-46e0-9351-8ba8d9f7f163"));
            cmdClear = (ITTButton)AddControl(new Guid("0788bdb9-3973-4dd2-9d48-4abc41c9be36"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("10518833-fc38-4fd7-af27-b4cd09f7a7d4"));
            DistributeGrid = (ITTGrid)AddControl(new Guid("32c786cf-a1b6-4fad-9d74-8ac0cc9b183e"));
            DPrescriptionNo = (ITTTextBoxColumn)AddControl(new Guid("f145d70c-3aeb-4370-8c78-b7a66abf38a2"));
            DPatientNo = (ITTTextBoxColumn)AddControl(new Guid("e7668065-6c36-46a9-b836-d661654829d4"));
            DProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("7b71f901-ac01-4244-a682-142d13b76608"));
            DQuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("86b074a7-6b6a-4c9b-9159-1cd4eafd6300"));
            DResource = (ITTTextBoxColumn)AddControl(new Guid("b776d3d5-8bac-4852-abeb-f84af9d54242"));
            DPrice = (ITTTextBoxColumn)AddControl(new Guid("59901e5b-0d1b-4d69-849e-876d7e7b665e"));
            DPharmacy = (ITTTextBoxColumn)AddControl(new Guid("a4d1d794-7700-4292-bfb1-5e019842b6a1"));
            PrescriptionGuid = (ITTTextBoxColumn)AddControl(new Guid("13c41d77-d4af-43f7-ae62-f6b0c20b4cc9"));
            PharmacyGuid = (ITTTextBoxColumn)AddControl(new Guid("b5a90c99-8d82-4b9f-ae87-2d54990b5e16"));
            base.InitializeControls();
        }

        public PrescriptionDistributeUnboundForm() : base("PrescriptionDistributeUnboundForm")
        {
        }

        protected PrescriptionDistributeUnboundForm(string formDefName) : base(formDefName)
        {
        }
    }
}