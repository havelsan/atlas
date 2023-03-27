
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
    /// Eski Emanet işlemlerini kaybetmemek için yaratıldı
    /// </summary>
    public partial class InPatientTreatmentClinicAcceptionTempForm : TTForm
    {
    /// <summary>
    /// Klinik İşlemleri
    /// </summary>
        protected TTObjectClasses.InPatientTreatmentClinicApplication _InPatientTreatmentClinicApplication
        {
            get { return (TTObjectClasses.InPatientTreatmentClinicApplication)_ttObject; }
        }

        protected ITTPanel ttpanel2;
        protected ITTButton btnShowGivenMaterialsStatus;
        protected ITTCheckBox NoCupboard;
        protected ITTLabel ttlabelGivenStatus;
        protected ITTGrid GridMoney;
        protected ITTDateTimePickerColumn ProcessDate;
        protected ITTEnumComboBoxColumn QuarantineProcessType;
        protected ITTListBoxColumn MonetaryUnit;
        protected ITTTextBoxColumn MoneyAmount;
        protected ITTTextBoxColumn ReceiptNo;
        protected ITTTextBoxColumn MoneyWhoTake;
        protected ITTTextBoxColumn MoneyWhoGiven;
        protected ITTTextBoxColumn MoneyDescription;
        protected ITTLabel ttlabelTakenStatus;
        protected ITTGrid ValuableMaterials;
        protected ITTDateTimePickerColumn ValuableMaterialsProcessDate;
        protected ITTEnumComboBoxColumn ValuableMaterialsQuarantineProcessType;
        protected ITTListBoxColumn ValuableMaterialsMaterial;
        protected ITTTextBoxColumn ValuableMaterialsAmount;
        protected ITTTextBoxColumn ValuableMaterialsWhoTake;
        protected ITTTextBoxColumn ValuableMaterialsWhoGive;
        protected ITTTextBoxColumn ValuableMaterialsDescription;
        protected ITTLabel ttlabel6;
        protected ITTGrid GridInpatientAdmissionTakenMaterials;
        protected ITTDateTimePickerColumn TakenMaterialsProcessDate;
        protected ITTListBoxColumn TakenMaterialsMaterial;
        protected ITTTextBoxColumn TakenMaterialsAmount;
        protected ITTTextBoxColumn TakenMaterialsWhoTake;
        protected ITTTextBoxColumn TakenMaterialsWhoGive;
        protected ITTTextBoxColumn TakenMaterialsDescription;
        protected ITTTextBox TakenStatus;
        protected ITTGrid GridInpatientAdmissionGivenMaterials;
        protected ITTDateTimePickerColumn GivenMaterialsProcessDate;
        protected ITTListBoxColumn GivenMaterialsMaterialType;
        protected ITTTextBoxColumn GivenMaterialsAmount;
        protected ITTTextBoxColumn GivenMaterialsWhoTake;
        protected ITTTextBoxColumn GivenMaterialsWhoGive;
        protected ITTTextBoxColumn GivenMaterialsDescription;
        protected ITTObjectListBox Cupboard;
        protected ITTTextBox GivenStatus;
        protected ITTLabel labelGridInpatientAdmissionTakenMaterials;
        protected ITTLabel labelGridMoney;
        protected ITTLabel labelGridInpatientAdmissionGivenMaterials;
        protected ITTLabel labelValuableMaterials;
        override protected void InitializeControls()
        {
            ttpanel2 = (ITTPanel)AddControl(new Guid("639d4c84-3091-4831-a93c-6a3ba1cf0fc2"));
            btnShowGivenMaterialsStatus = (ITTButton)AddControl(new Guid("65f2bda4-fccf-400e-950b-51cdb71bc92e"));
            NoCupboard = (ITTCheckBox)AddControl(new Guid("6e70b4a8-dd2f-40fe-a954-09f4e7027dff"));
            ttlabelGivenStatus = (ITTLabel)AddControl(new Guid("4f80372c-206f-420a-84c5-6edf14f20ccc"));
            GridMoney = (ITTGrid)AddControl(new Guid("d8ef1a9d-93b4-4371-ac37-65dc2b3f171c"));
            ProcessDate = (ITTDateTimePickerColumn)AddControl(new Guid("a991535b-2550-4365-92de-29b017072747"));
            QuarantineProcessType = (ITTEnumComboBoxColumn)AddControl(new Guid("dee745e8-72ee-4af4-a55e-a325c3dd46ea"));
            MonetaryUnit = (ITTListBoxColumn)AddControl(new Guid("480a38e8-cdcf-4eac-a1ec-2fc88bb3c888"));
            MoneyAmount = (ITTTextBoxColumn)AddControl(new Guid("38288eed-726a-4af3-b401-99ea8f0213fc"));
            ReceiptNo = (ITTTextBoxColumn)AddControl(new Guid("56924fb4-60af-4ada-85db-7c97b53e38ef"));
            MoneyWhoTake = (ITTTextBoxColumn)AddControl(new Guid("9566b28b-d7d4-41e5-8e06-898950ab3dbe"));
            MoneyWhoGiven = (ITTTextBoxColumn)AddControl(new Guid("7e4e97dc-d45c-44b2-bbf8-295041f4a68b"));
            MoneyDescription = (ITTTextBoxColumn)AddControl(new Guid("8d1ba0fb-4cb4-4d18-85f3-b575ee969295"));
            ttlabelTakenStatus = (ITTLabel)AddControl(new Guid("ac488cfc-028f-47df-9c5e-a0115f3f51b1"));
            ValuableMaterials = (ITTGrid)AddControl(new Guid("80198e8b-2c48-4eb6-828c-e9d996caedb5"));
            ValuableMaterialsProcessDate = (ITTDateTimePickerColumn)AddControl(new Guid("1392ddb5-3e6a-4aa2-8d97-7257c0cfabad"));
            ValuableMaterialsQuarantineProcessType = (ITTEnumComboBoxColumn)AddControl(new Guid("09223be9-7808-4b8d-a88c-369424ecefc8"));
            ValuableMaterialsMaterial = (ITTListBoxColumn)AddControl(new Guid("479b296e-6218-40d7-b5bd-5ece6ce9809c"));
            ValuableMaterialsAmount = (ITTTextBoxColumn)AddControl(new Guid("250519ec-179f-420c-b08b-6d8ac1fee936"));
            ValuableMaterialsWhoTake = (ITTTextBoxColumn)AddControl(new Guid("667b4410-8a42-4cd4-9569-6bf2efb5c521"));
            ValuableMaterialsWhoGive = (ITTTextBoxColumn)AddControl(new Guid("ce877e3d-153a-422e-a802-bab341f844f8"));
            ValuableMaterialsDescription = (ITTTextBoxColumn)AddControl(new Guid("22c7b5ee-6937-4fab-8fa3-0396408921c9"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("f97c16da-09d3-46e1-a423-6ea820ebbe15"));
            GridInpatientAdmissionTakenMaterials = (ITTGrid)AddControl(new Guid("179f9d60-14b5-457e-ae73-bf8ced5be135"));
            TakenMaterialsProcessDate = (ITTDateTimePickerColumn)AddControl(new Guid("b7fb18e9-037e-4b73-bb7e-8c19f241156f"));
            TakenMaterialsMaterial = (ITTListBoxColumn)AddControl(new Guid("d70d7c74-c989-4a12-b92d-e0b2a0e780f2"));
            TakenMaterialsAmount = (ITTTextBoxColumn)AddControl(new Guid("44aeaaee-e537-4ea0-a79d-a9f4a8eb0103"));
            TakenMaterialsWhoTake = (ITTTextBoxColumn)AddControl(new Guid("14c45e25-0b8e-479f-8167-f8f50e4a83d4"));
            TakenMaterialsWhoGive = (ITTTextBoxColumn)AddControl(new Guid("7e999598-7cc2-46ba-831c-353cf0471390"));
            TakenMaterialsDescription = (ITTTextBoxColumn)AddControl(new Guid("4eacc6bd-fb5a-41e1-923d-db574162e4ad"));
            TakenStatus = (ITTTextBox)AddControl(new Guid("8634f2b3-7252-46a5-abcd-6b600c17400e"));
            GridInpatientAdmissionGivenMaterials = (ITTGrid)AddControl(new Guid("0a8785f3-96c8-4738-8cec-9aae9a0b6934"));
            GivenMaterialsProcessDate = (ITTDateTimePickerColumn)AddControl(new Guid("d93988ba-3d1f-424c-8658-61a02548fd54"));
            GivenMaterialsMaterialType = (ITTListBoxColumn)AddControl(new Guid("170f2af5-021f-4f2e-a5b9-8a4bd923efb1"));
            GivenMaterialsAmount = (ITTTextBoxColumn)AddControl(new Guid("06eb6d47-5e6c-47f5-9aed-e26d1692308b"));
            GivenMaterialsWhoTake = (ITTTextBoxColumn)AddControl(new Guid("61cf5f4a-e6f9-4b89-96ae-71cae0cd5ded"));
            GivenMaterialsWhoGive = (ITTTextBoxColumn)AddControl(new Guid("d2ad3d2a-d60d-45d9-acee-fc5f7305bbf3"));
            GivenMaterialsDescription = (ITTTextBoxColumn)AddControl(new Guid("677c67fd-93ce-4d4b-a993-4c9846a5bbcd"));
            Cupboard = (ITTObjectListBox)AddControl(new Guid("6bcdcbb2-84c7-4ef8-be18-04e5e43625ba"));
            GivenStatus = (ITTTextBox)AddControl(new Guid("727e2924-74f0-4735-800f-fe1f308c7a21"));
            labelGridInpatientAdmissionTakenMaterials = (ITTLabel)AddControl(new Guid("fe7f5440-be69-474b-a7b6-d81df6a4fad6"));
            labelGridMoney = (ITTLabel)AddControl(new Guid("0aec0fca-e8ab-494d-af76-5181df1133f7"));
            labelGridInpatientAdmissionGivenMaterials = (ITTLabel)AddControl(new Guid("0442efd5-4c6d-48db-bcd0-ee94579effd3"));
            labelValuableMaterials = (ITTLabel)AddControl(new Guid("f8870a02-dc71-48d6-b80a-019f3224c231"));
            base.InitializeControls();
        }

        public InPatientTreatmentClinicAcceptionTempForm() : base("INPATIENTTREATMENTCLINICAPPLICATION", "InPatientTreatmentClinicAcceptionTempForm")
        {
        }

        protected InPatientTreatmentClinicAcceptionTempForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}