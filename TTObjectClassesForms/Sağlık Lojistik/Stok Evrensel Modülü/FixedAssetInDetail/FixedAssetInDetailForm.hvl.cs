
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
    /// Demirbaş Malzeme Detayları
    /// </summary>
    public partial class FixedAssetInDetailForm : TTForm
    {
        protected TTObjectClasses.FixedAssetInDetail _FixedAssetInDetail
        {
            get { return (TTObjectClasses.FixedAssetInDetail)_ttObject; }
        }

        protected ITTCheckBox OtherModel;
        protected ITTCheckBox OtherMark;
        protected ITTCheckBox OtherMainClass;
        protected ITTCheckBox OtherLenght;
        protected ITTCheckBox OtherEdge;
        protected ITTCheckBox OtherBody;
        protected ITTButton ttbutton1;
        protected ITTLabel labelFixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker GuarantyEndDate;
        protected ITTLabel labelStockCardMaterial;
        protected ITTObjectListBox StockCardMaterial;
        protected ITTLabel labelNameMaterial;
        protected ITTTextBox NameMaterial;
        protected ITTTextBox BarcodeMaterial;
        protected ITTTextBox SerialNumberFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox ReferansNoFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox MarkModelReasonFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox GuarantiePeriodFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox DescriptionFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelBarcodeMaterial;
        protected ITTLabel labelSetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelUseStartDateFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker UseStartDateFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelSerialNumberFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelReferansNoFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelProductionDateFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker ProductionDateFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelOperationStatusFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox OperationStatusFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelMarkModelStatusFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox MarkModelStatusFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelMarkModelReasonFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelIsDemodedFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox IsDemodedFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelGuarantyStatusFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox GuarantyStatusFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelGuarantyStartDateFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker GuarantyStartDateFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelGuarantiePeriodFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelDetailTypeFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox DetailTypeFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelDetailClassFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox DetailClassFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelDescriptionFixedAssetMaterialDefinitionDetail;
        override protected void InitializeControls()
        {
            OtherModel = (ITTCheckBox)AddControl(new Guid("503915fd-cd73-4b61-9e38-9f398b1869b4"));
            OtherMark = (ITTCheckBox)AddControl(new Guid("2c35ef1d-ffd0-4311-a183-17ec29f49c56"));
            OtherMainClass = (ITTCheckBox)AddControl(new Guid("50aa0e6e-a063-404d-9985-f546d9c4dab0"));
            OtherLenght = (ITTCheckBox)AddControl(new Guid("2ab6a883-a0cd-45d4-9f40-38a63f7714f3"));
            OtherEdge = (ITTCheckBox)AddControl(new Guid("f65f207d-be53-4f21-9a73-377842959c4c"));
            OtherBody = (ITTCheckBox)AddControl(new Guid("9052d74a-c135-4d3c-b6cd-d4d7e8157797"));
            ttbutton1 = (ITTButton)AddControl(new Guid("0af39bbb-07de-41ed-a710-b2c84fdd5580"));
            labelFixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("81ecaa95-d0d1-4cd9-81dc-48cbb6d00221"));
            FixedAssetDetailLengthDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("1b2766b4-5abc-4d73-9fd2-c74f0af67b6d"));
            labelFixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("ae051e52-7e93-4bc6-96e8-37bf8a3577fa"));
            FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("f28a3f0a-9f58-4677-a47d-34b3e132d04e"));
            labelFixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("b9a84c56-61c9-40c0-ad7b-bc1d30e15879"));
            FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("90897167-2978-498d-b3df-a519e8f4dbce"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a8d0a363-0a5c-4e1b-9b51-3c6617203ec3"));
            GuarantyEndDate = (ITTDateTimePicker)AddControl(new Guid("25aef79d-45c7-42c3-bb1f-6da614e37695"));
            labelStockCardMaterial = (ITTLabel)AddControl(new Guid("570e434e-0fd2-4f2f-8a35-14b36c241239"));
            StockCardMaterial = (ITTObjectListBox)AddControl(new Guid("6ec1dd19-be8f-4013-a2a5-446296e1fd71"));
            labelNameMaterial = (ITTLabel)AddControl(new Guid("321866c2-e789-48b0-922f-70cd5caf6bc6"));
            NameMaterial = (ITTTextBox)AddControl(new Guid("1a7596c0-0c4a-4793-8cb3-1818ff4b70f2"));
            BarcodeMaterial = (ITTTextBox)AddControl(new Guid("73e4c712-610b-448c-b42b-3981c1aa85fc"));
            SerialNumberFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("0ab0efc6-de5d-474e-b3bf-0b26046d1fa6"));
            ReferansNoFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("efe06f51-f561-4590-bce2-82efa4f5c09e"));
            MarkModelReasonFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("c7c72607-1e44-4080-baf0-d36b9a506cda"));
            GuarantiePeriodFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("263bc241-69f4-4cdb-af86-7907c59686ea"));
            DescriptionFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("ff35b4e1-79ef-4b27-b88f-1517feec11b7"));
            labelBarcodeMaterial = (ITTLabel)AddControl(new Guid("eb25a908-0619-447c-9de8-78b426b2cb59"));
            labelSetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("31b59bc3-c00b-420e-81cd-8648ca238116"));
            SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("fed31cd7-6ddd-4e72-a1af-f67f5723a0b3"));
            labelFixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("23c7681e-d235-4009-854c-ed9884fb1f76"));
            FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("73556535-b565-4bab-aaf1-bb650564d0a3"));
            labelFixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("76d40266-579f-456a-bbeb-65683980f202"));
            FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("ccbb6a61-fa1d-4c2b-9c29-5f978f867435"));
            labelFixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("18bcac25-d92e-4077-8189-202c582e286f"));
            FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("4a19344e-5aaa-44f7-9f67-d4c7bea8f74f"));
            labelUseStartDateFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("48a34e9e-54b4-493d-9c78-d63e9a65fa25"));
            UseStartDateFixedAssetMaterialDefinitionDetail = (ITTDateTimePicker)AddControl(new Guid("d8f8a356-a426-4d00-ab54-3b06a96ba32d"));
            labelSerialNumberFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("e12bddce-cd45-4894-9777-8b684e7bb06f"));
            labelReferansNoFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("ad057b65-79fe-4b44-a1b0-b29ec777303f"));
            labelProductionDateFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("f6aa0a2f-d3ba-4818-8a9c-56b5b9e911df"));
            ProductionDateFixedAssetMaterialDefinitionDetail = (ITTDateTimePicker)AddControl(new Guid("14f11e12-64d3-4242-ae78-4f56673d082a"));
            labelOperationStatusFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("3a888cef-2a3d-485c-bdfd-bf6167b759f8"));
            OperationStatusFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("030fc574-d502-4f5d-a910-eb2734d9f7d6"));
            labelMarkModelStatusFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("f1b2a938-8d75-48c1-a16c-954c9c5919b0"));
            MarkModelStatusFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("2f960ff1-91e6-46e5-b6e5-ec57d9572af6"));
            labelMarkModelReasonFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("d6c31c70-db39-4542-8c60-640eead50b06"));
            labelIsDemodedFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("0ce44d18-73c2-4c29-9063-fea6c76dbefe"));
            IsDemodedFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("87e2eafa-ebd3-43d2-ba63-794325145e8e"));
            labelGuarantyStatusFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("e7dcb8e6-7c12-4398-a248-1bfdfd510fc8"));
            GuarantyStatusFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("ca1d0f05-a4e6-4474-aba9-5451f43075a4"));
            labelGuarantyStartDateFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("3107b954-927e-49c0-b5d6-7aaf4c53896e"));
            GuarantyStartDateFixedAssetMaterialDefinitionDetail = (ITTDateTimePicker)AddControl(new Guid("e48e6a2f-5dca-4b97-8254-336ef4cc3b1b"));
            labelGuarantiePeriodFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("e58a62eb-a953-4e8c-bd22-7f93d8f322a9"));
            labelDetailTypeFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("3f2c978a-b785-49bd-ba9a-f285ae74f3cd"));
            DetailTypeFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("425ea546-b4fd-4176-a84d-507f2fb9c146"));
            labelDetailClassFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("42f38f59-0ea4-480e-a4ed-6fcf43086520"));
            DetailClassFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("a180634e-772c-4290-9ccf-6d36e38715a6"));
            labelDescriptionFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("2f91223a-66e2-4eec-8a10-244887f594bc"));
            base.InitializeControls();
        }

        public FixedAssetInDetailForm() : base("FIXEDASSETINDETAIL", "FixedAssetInDetailForm")
        {
        }

        protected FixedAssetInDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}