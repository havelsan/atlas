
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
    public partial class PrescriptionDistributeApprovalForm : TTForm
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
        protected ITTDateTimePicker PrescriptionDateTime;
        protected ITTLabel labelID;
        protected ITTLabel ttlabel1;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTToolStrip tttoolstrip21;
        override protected void InitializeControls()
        {
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("d44b9a6b-05f8-4c22-9708-69a7f70aa6ce"));
            DistributeDetails = (ITTGrid)AddControl(new Guid("a73677a7-770a-49a1-972a-dd9c576bafa6"));
            DistPrescNo = (ITTTextBoxColumn)AddControl(new Guid("2da91ad6-04e0-4405-9fb3-dcde861b5a2f"));
            DistPatientNo = (ITTTextBoxColumn)AddControl(new Guid("6730544d-78e9-4248-99d5-80961a54bcc6"));
            DistProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("186f4598-2697-49bf-babb-1addd8ffa239"));
            DistQuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("bcc2a17c-51ef-411d-816e-c96801c3179f"));
            DistResource = (ITTTextBoxColumn)AddControl(new Guid("35ee6b35-80cf-49cb-9a63-4087d6a36461"));
            DistPrice = (ITTTextBoxColumn)AddControl(new Guid("aad06180-f3fb-40c7-ab87-2f0bb5e35816"));
            DistPharmacy = (ITTTextBoxColumn)AddControl(new Guid("6da3665c-9eb9-4a0d-bd96-48d3e7c1b42a"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("a4f8b457-5dd4-477b-8e38-3f05d1b2ce9c"));
            PharmacyDetails = (ITTGrid)AddControl(new Guid("a6ae3834-5db5-49a9-8d52-bd0440bdf2e8"));
            Pharmacy = (ITTTextBoxColumn)AddControl(new Guid("7c38eb52-0a88-4904-a075-1a762799f2a0"));
            Balance = (ITTTextBoxColumn)AddControl(new Guid("bff15691-b16d-462b-ac9c-9f7e387da3de"));
            PharmacyGuid = (ITTTextBoxColumn)AddControl(new Guid("41aa854e-28ac-48df-b126-4d76078ceadd"));
            cmdDistribute = (ITTButton)AddControl(new Guid("d8e6cf5a-4d84-4706-8a80-c579666618ac"));
            cmdSelectPharmacy = (ITTButton)AddControl(new Guid("916e12ba-3bf0-4fbb-a786-679ce59d6c79"));
            PharmacyCountCombo = (ITTComboBox)AddControl(new Guid("9fc48827-d34c-41ac-9cf7-5fce199e370d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3f74803d-1fcf-41ed-873e-fd6c1436eeee"));
            cmdClear = (ITTButton)AddControl(new Guid("ba74c3b5-6ae1-4fec-964e-826ebbe34bcc"));
            QuarantineProtocolNo = (ITTGroupBox)AddControl(new Guid("2e10fd43-e118-49b1-b440-5da03a74b174"));
            PrescriptionDetails = (ITTGrid)AddControl(new Guid("43d24904-7900-43ec-86bf-d97134dc44d0"));
            Distribute = (ITTCheckBoxColumn)AddControl(new Guid("165767ee-0469-4782-be08-8bb441234464"));
            PrescriptionType = (ITTTextBoxColumn)AddControl(new Guid("424235a4-e794-4862-8e00-c74ac01f92e7"));
            PrescriptionNo = (ITTTextBoxColumn)AddControl(new Guid("771ade29-dbf2-44d4-a05d-3693ad381cb3"));
            PatientName = (ITTTextBoxColumn)AddControl(new Guid("57d76e11-f942-4c2c-a229-77999fb42cc6"));
            PatientMilitaryUnit = (ITTTextBoxColumn)AddControl(new Guid("a9cf7ba9-fe39-4606-84cd-d0c3011073a5"));
            QuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("0c303498-d5d1-4f11-a198-d0f049fd0b7a"));
            ProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("707cc5fb-3456-4835-83b0-019b4486a4d2"));
            Resource = (ITTTextBoxColumn)AddControl(new Guid("4ded69e6-4781-433d-aaa7-1e3c0da23ea7"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("1c92b624-ffd4-42f3-88a5-04f4df13a7e3"));
            PrescriptionGuid = (ITTTextBoxColumn)AddControl(new Guid("da3fe45a-11ac-4839-aa27-fa8ebb94adba"));
            cmdSelect = (ITTButton)AddControl(new Guid("7a95f967-03f9-4a50-8b01-b416c6b091df"));
            cmdUnSelect = (ITTButton)AddControl(new Guid("93ff320a-ce66-4662-84da-0b0375fd2291"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("a775e75b-e988-4130-bb1c-194520c09223"));
            PrescriptionDateTime = (ITTDateTimePicker)AddControl(new Guid("89a41e4b-78f0-4d55-9290-f4e1e849df02"));
            labelID = (ITTLabel)AddControl(new Guid("3ed4ea59-2590-4012-a9cb-070eba2b206b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("be17f213-7911-4a32-9a36-2d696e4cd7e3"));
            ID = (ITTTextBox)AddControl(new Guid("c3f83d05-fe82-49f8-bc50-1af046962820"));
            labelActionDate = (ITTLabel)AddControl(new Guid("9dffaeef-2e8e-4fc2-b297-478f5f8b9d4e"));
            tttoolstrip21 = (ITTToolStrip)AddControl(new Guid("631c7509-6ab8-45f5-9351-f4753d1e0f42"));
            base.InitializeControls();
        }

        public PrescriptionDistributeApprovalForm() : base("PRESCRIPTIONDISTRIBUTE", "PrescriptionDistributeApprovalForm")
        {
        }

        protected PrescriptionDistributeApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}