
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
    /// TITUBB Ürün Malzeme Eşleştirme
    /// </summary>
    public partial class ProductMaterialMatchActionNewForm : TTForm
    {
    /// <summary>
    /// TITUBB Ürün Malzeme Eşleştirme
    /// </summary>
        protected TTObjectClasses.ProductMaterialMatchAction _ProductMaterialMatchAction
        {
            get { return (TTObjectClasses.ProductMaterialMatchAction)_ttObject; }
        }

        protected ITTButton cmdClear;
        protected ITTCheckBox WithOutBarcode;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelMatchReasonWithBarcode;
        protected ITTTextBox tttextbox5;
        protected ITTObjectListBox MatchReasonWithBarcode;
        protected ITTLabel ttlabel6;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox textFirmName;
        protected ITTTextBox textIdentityNumber;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTButton cmdMatch;
        protected ITTGrid ProductMaterialMatchDetails;
        protected ITTListBoxColumn ProductProductMaterialMatchDetail;
        protected ITTListBoxColumn MaterialProductMaterialMatchDetail;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn MatchReason;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            cmdClear = (ITTButton)AddControl(new Guid("dd87d5a7-c732-44e8-bc51-dcca89d219c9"));
            WithOutBarcode = (ITTCheckBox)AddControl(new Guid("52fa3278-37db-409d-9725-3882c67fe547"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("be6e62b5-d730-4ce1-b087-fd5901ee6edd"));
            labelMatchReasonWithBarcode = (ITTLabel)AddControl(new Guid("f6136c0f-3860-4ed4-9e47-a76ce9289630"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("5a8ff5ae-7ca7-48fc-83c8-549a61ffc471"));
            MatchReasonWithBarcode = (ITTObjectListBox)AddControl(new Guid("4b0c9b3f-1b72-4e1f-b67f-b71d1862e82c"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9cd8b85c-182e-40fc-97a4-835a80517219"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("7ed716d4-aa63-42b2-953a-7f78dc516846"));
            textFirmName = (ITTTextBox)AddControl(new Guid("2154ae50-9620-4fff-8784-d05ae1f7d1e5"));
            textIdentityNumber = (ITTTextBox)AddControl(new Guid("22f19cde-e206-4cac-a3fb-c1aec024cdc9"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("609ce2b2-910e-461d-86a8-51d6ece04082"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e264c4c7-6913-4f8c-b5fe-588f186df796"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("953de2b9-f90d-4f88-8166-451a95d1cc63"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("26518b17-5d2d-48d2-a9ef-90555afa9d7d"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("15313d68-fe05-46a9-bc41-8d825c582e86"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e23784bf-4af4-4aa5-b863-9f6361eb9b6b"));
            labelStore = (ITTLabel)AddControl(new Guid("582894cb-8ec3-4b82-8510-e6f110f999dc"));
            Store = (ITTObjectListBox)AddControl(new Guid("0e36add9-3e43-4c29-8aa9-23e4d960b468"));
            cmdMatch = (ITTButton)AddControl(new Guid("e6aa3360-81c9-4d1d-9d1f-69698667dbc5"));
            ProductMaterialMatchDetails = (ITTGrid)AddControl(new Guid("63e95a61-4878-48e1-bcea-90933daa2933"));
            ProductProductMaterialMatchDetail = (ITTListBoxColumn)AddControl(new Guid("f98afed3-baea-4634-93a8-21a386185ae7"));
            MaterialProductMaterialMatchDetail = (ITTListBoxColumn)AddControl(new Guid("2169dd46-0151-40ff-b98b-c7fa48632206"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("30a3169d-e0a7-415d-8a8b-ea9e3ffaf31d"));
            MatchReason = (ITTListBoxColumn)AddControl(new Guid("b20ac21a-7bc9-4f43-a86f-1ad424ed5ed0"));
            labelMaterial = (ITTLabel)AddControl(new Guid("e7e21ee6-9191-4c47-9d64-71f061771c1e"));
            Material = (ITTObjectListBox)AddControl(new Guid("4c3367b5-14e7-4586-8c46-cc6a3cd9138d"));
            labelID = (ITTLabel)AddControl(new Guid("7dd7d334-2c96-4879-8b01-68d8933f2276"));
            ID = (ITTTextBox)AddControl(new Guid("ee83cb4a-97a6-4837-ae2c-922e455a3839"));
            labelActionDate = (ITTLabel)AddControl(new Guid("494f0c11-42bf-4cb3-a4f7-c8617255c973"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("d2a472b5-4f96-4b61-9567-4cf214408e32"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ef356a8b-298c-4d43-90e2-c33555c86cc3"));
            base.InitializeControls();
        }

        public ProductMaterialMatchActionNewForm() : base("PRODUCTMATERIALMATCHACTION", "ProductMaterialMatchActionNewForm")
        {
        }

        protected ProductMaterialMatchActionNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}