
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
    /// Taşınır Mal İşlemi Giriş (Reçeteler İçin)
    /// </summary>
    public partial class BasePresChaDocInputWithAccountancyForm : BaseChattelDocumentInputWithAccountancyForm
    {
    /// <summary>
    /// Taşınır Mal İşlemi Giriş (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresChaDocInputWithAccountancy _PresChaDocInputWithAccountancy
        {
            get { return (TTObjectClasses.PresChaDocInputWithAccountancy)_ttObject; }
        }

        protected ITTTabPage PrescriptionTabPage;
        protected ITTGrid PresChaDocInputWithAccountancyDetails;
        protected ITTListBoxColumn MaterialPresChaDocInputDetWithAccountancy;
        protected ITTTextBoxColumn PresBarcode;
        protected ITTTextBoxColumn PresDistiributionType;
        protected ITTTextBoxColumn SentAmountPresChaDocInputDetWithAccountancy;
        protected ITTTextBoxColumn AmountPresChaDocInputDetWithAccountancy;
        protected ITTTextBoxColumn PresConflictAmount;
        protected ITTTextBoxColumn UnitPricePresChaDocInputDetWithAccountancy;
        protected ITTTextBoxColumn PresTotalPrice;
        protected ITTTextBoxColumn LotNoPresChaDocInputDetWithAccountancy;
        protected ITTDateTimePickerColumn ExpirationDatePresChaDocInputDetWithAccountancy;
        protected ITTListBoxColumn StockLevelTypePresChaDocInputDetWithAccountancy;
        protected ITTTextBoxColumn ConflictSubjectPresChaDocInputDetWithAccountancy;
        protected ITTEnumComboBoxColumn StatusPresChaDocInputDetWithAccountancy;
        override protected void InitializeControls()
        {
            PrescriptionTabPage = (ITTTabPage)AddControl(new Guid("38466f67-49ff-401a-8b84-c22f5e905bb1"));
            PresChaDocInputWithAccountancyDetails = (ITTGrid)AddControl(new Guid("a68d97ce-a55b-42dc-8852-5abd9ee86dc4"));
            MaterialPresChaDocInputDetWithAccountancy = (ITTListBoxColumn)AddControl(new Guid("bfc4c19b-ecce-4d67-873c-924d1e0b58d2"));
            PresBarcode = (ITTTextBoxColumn)AddControl(new Guid("4d57c058-157e-48d7-9248-ea7f7d381a99"));
            PresDistiributionType = (ITTTextBoxColumn)AddControl(new Guid("68d208d5-3c94-45a9-91c3-61ac7b280f93"));
            SentAmountPresChaDocInputDetWithAccountancy = (ITTTextBoxColumn)AddControl(new Guid("51acf7c2-8766-44b4-833c-58b3065e1818"));
            AmountPresChaDocInputDetWithAccountancy = (ITTTextBoxColumn)AddControl(new Guid("1189eca1-d948-42df-ac8f-9c685ee7590c"));
            PresConflictAmount = (ITTTextBoxColumn)AddControl(new Guid("dea55141-cbf4-423a-a493-ebce68004eed"));
            UnitPricePresChaDocInputDetWithAccountancy = (ITTTextBoxColumn)AddControl(new Guid("78b1c963-83ce-48f4-b7ce-4abebd0d5430"));
            PresTotalPrice = (ITTTextBoxColumn)AddControl(new Guid("59357cde-02c1-49ba-b306-2993ea53cb72"));
            LotNoPresChaDocInputDetWithAccountancy = (ITTTextBoxColumn)AddControl(new Guid("cbf90af9-3819-4219-b7d3-6bcf4cb347ab"));
            ExpirationDatePresChaDocInputDetWithAccountancy = (ITTDateTimePickerColumn)AddControl(new Guid("414245a6-e76c-4331-bd21-815aad2b9ca6"));
            StockLevelTypePresChaDocInputDetWithAccountancy = (ITTListBoxColumn)AddControl(new Guid("8f9a1505-d4ec-446d-b038-f1c49d3d80b4"));
            ConflictSubjectPresChaDocInputDetWithAccountancy = (ITTTextBoxColumn)AddControl(new Guid("4778e61c-a959-489f-9887-4d4d64c7e4d0"));
            StatusPresChaDocInputDetWithAccountancy = (ITTEnumComboBoxColumn)AddControl(new Guid("8ecf3a58-807b-4fcc-a33e-b9a28fa27c01"));
            base.InitializeControls();
        }

        public BasePresChaDocInputWithAccountancyForm() : base("PRESCHADOCINPUTWITHACCOUNTANCY", "BasePresChaDocInputWithAccountancyForm")
        {
        }

        protected BasePresChaDocInputWithAccountancyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}