
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
    public partial class BaseGrantMaterialForm : BaseChattelDocumentForm
    {
    /// <summary>
    /// Bağış Yardım
    /// </summary>
        protected TTObjectClasses.GrantMaterial _GrantMaterial
        {
            get { return (TTObjectClasses.GrantMaterial)_ttObject; }
        }

        protected ITTTextBox GranttedByUniqNo;
        protected ITTTextBox MaterialGranttedBy;
        protected ITTButton TTFirma;
        protected ITTLabel labelBudgetTypeDefinition;
        protected ITTObjectListBox BudgetTypeDefinition;
        protected ITTLabel labelGranttedByUniqNo;
        protected ITTLabel labelMKYS_EMalzemeGrup;
        protected ITTEnumComboBox MKYS_EMalzemeGrup;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDestinationStore;
        protected ITTLabel labelMaterialGranttedBy;
        protected ITTTabControl ChattelDocumentTabcontrol;
        protected ITTTabPage ChattelDocumentDetailTabpage;
        protected ITTGrid GrantMaterialDetails;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn MaterialGrantMaterialDetail;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistiributionType;
        protected ITTTextBoxColumn AmountGrantMaterialDetail;
        protected ITTTextBoxColumn NotDiscountedUnitPrice;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn LotNoGrantMaterialDetail;
        protected ITTDateTimePickerColumn ExpirationDateGrantMaterialDetail;
        protected ITTListBoxColumn StockLevelType;
        protected ITTTextBoxColumn RetrievalYearGrantMaterialDetail;
        protected ITTDateTimePickerColumn ProductionDateGrantMaterialDetail;
        protected ITTEnumComboBox MKYS_ETedarikTuru;
        protected ITTLabel labelMKYS_ETedarikTuru;
        override protected void InitializeControls()
        {
            GranttedByUniqNo = (ITTTextBox)AddControl(new Guid("a493e932-a629-44f4-90d3-0c130da7c50e"));
            MaterialGranttedBy = (ITTTextBox)AddControl(new Guid("78739020-6cbb-40db-8869-c2ffa59628cd"));
            TTFirma = (ITTButton)AddControl(new Guid("c94188ec-6a56-4f27-bbfd-9b397e5e81ba"));
            labelBudgetTypeDefinition = (ITTLabel)AddControl(new Guid("dec30444-613e-4bfc-8529-6ed1401b06d8"));
            BudgetTypeDefinition = (ITTObjectListBox)AddControl(new Guid("f07df021-1c28-44a6-994f-aadab892caa8"));
            labelGranttedByUniqNo = (ITTLabel)AddControl(new Guid("9824ac66-e8f6-4a3a-9356-43b33679530d"));
            labelMKYS_EMalzemeGrup = (ITTLabel)AddControl(new Guid("cb64e568-d35a-42f4-bfc0-ba6071415f5f"));
            MKYS_EMalzemeGrup = (ITTEnumComboBox)AddControl(new Guid("e8ae9586-cb64-43bc-86bd-3105fe55e257"));
            Store = (ITTObjectListBox)AddControl(new Guid("75e373fc-f51d-461a-8091-1fa6826f5f02"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("2f648801-c171-4ec9-8dd0-d8aa72436ee7"));
            labelMaterialGranttedBy = (ITTLabel)AddControl(new Guid("02bf2cc0-88d8-4d11-8b27-b2c491f26755"));
            ChattelDocumentTabcontrol = (ITTTabControl)AddControl(new Guid("ebee9530-43da-4bf9-a229-3393a573f5c3"));
            ChattelDocumentDetailTabpage = (ITTTabPage)AddControl(new Guid("399d2d43-b83d-4c91-921e-01b96d4b244e"));
            GrantMaterialDetails = (ITTGrid)AddControl(new Guid("eeb124d1-ff51-4c1c-9d57-63e81cc9e5aa"));
            Detail = (ITTButtonColumn)AddControl(new Guid("cbc169fc-7755-4ae4-a526-c69756a12e53"));
            MaterialGrantMaterialDetail = (ITTListBoxColumn)AddControl(new Guid("1a12c36e-6b03-4e4b-ad9f-70c361147f09"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("d23d9200-d13f-422c-abc6-11eadc1ddecd"));
            DistiributionType = (ITTTextBoxColumn)AddControl(new Guid("60fda7ec-5376-4054-be65-376c88678a5d"));
            AmountGrantMaterialDetail = (ITTTextBoxColumn)AddControl(new Guid("c84c82cf-eff3-4ccf-bf76-3447f75bd07a"));
            NotDiscountedUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("2611808e-aba8-4983-883d-1a95dc651bed"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("782f24f1-713f-444c-ae17-2ef983807301"));
            LotNoGrantMaterialDetail = (ITTTextBoxColumn)AddControl(new Guid("ba9ee0c5-8e5b-44a4-a7de-1cc4456b7141"));
            ExpirationDateGrantMaterialDetail = (ITTDateTimePickerColumn)AddControl(new Guid("8b34c618-6ae5-4988-81a8-6eff70915088"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("987c9b83-3925-4711-bd33-d9e282172bf8"));
            RetrievalYearGrantMaterialDetail = (ITTTextBoxColumn)AddControl(new Guid("23e4d979-44cd-44c7-a2a5-6ef9b2fc77b5"));
            ProductionDateGrantMaterialDetail = (ITTDateTimePickerColumn)AddControl(new Guid("f5fa061a-68fc-4c94-bdbc-90b9da83d684"));
            MKYS_ETedarikTuru = (ITTEnumComboBox)AddControl(new Guid("713d0da9-a07e-4011-94e7-bb2b942ee1b7"));
            labelMKYS_ETedarikTuru = (ITTLabel)AddControl(new Guid("e2a6d829-f1af-4313-a781-d028bce19f7b"));
            base.InitializeControls();
        }

        public BaseGrantMaterialForm() : base("GRANTMATERIAL", "BaseGrantMaterialForm")
        {
        }

        protected BaseGrantMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}