
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
    /// Miad Uzatım (Giriş)
    /// </summary>
    public partial class BaseExtendExpDateInForm : BaseChattelDocumentForm
    {
    /// <summary>
    /// Miad Güncelleme İşlemi (Giriş)
    /// </summary>
        protected TTObjectClasses.ExtendExpDateIn _ExtendExpDateIn
        {
            get { return (TTObjectClasses.ExtendExpDateIn)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ExtendExpDateInDetails;
        protected ITTListBoxColumn MaterialExtendExpDateInDetail;
        protected ITTTextBoxColumn AmountExtendExpDateInDetail;
        protected ITTTextBoxColumn UnitPriceExtendExpDateInDetail;
        protected ITTTextBoxColumn VatRateExtendExpDateInDetail;
        protected ITTDateTimePickerColumn ExpirationDateExtendExpDateInDetail;
        protected ITTTextBoxColumn LotNoExtendExpDateInDetail;
        protected ITTEnumComboBoxColumn StatusExtendExpDateInDetail;
        protected ITTTextBox ExtendExpDateOutID;
        protected ITTLabel labelBudgetTypeDefinition;
        protected ITTObjectListBox BudgetTypeDefinition;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelSupplier;
        protected ITTObjectListBox Supplier;
        protected ITTLabel labelExtendExpDateOutID;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("9dd6a8ef-7222-4c76-ab6b-b00da242b24c"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("d9b81da8-e944-4542-93a3-33a345d798f3"));
            ExtendExpDateInDetails = (ITTGrid)AddControl(new Guid("3a178c8f-07fd-40ca-8da8-793260ea53e6"));
            MaterialExtendExpDateInDetail = (ITTListBoxColumn)AddControl(new Guid("52520979-dbc9-479f-b1df-1834a83b8c16"));
            AmountExtendExpDateInDetail = (ITTTextBoxColumn)AddControl(new Guid("e1804e73-b0f8-4704-9702-904469a95b4c"));
            UnitPriceExtendExpDateInDetail = (ITTTextBoxColumn)AddControl(new Guid("8bd8daf8-298d-4b70-bdc4-db33d28e987e"));
            VatRateExtendExpDateInDetail = (ITTTextBoxColumn)AddControl(new Guid("e6c7c5b6-96bd-4f30-ad24-1671b269a018"));
            ExpirationDateExtendExpDateInDetail = (ITTDateTimePickerColumn)AddControl(new Guid("9c9d57c2-1645-460d-889e-bf430a73be18"));
            LotNoExtendExpDateInDetail = (ITTTextBoxColumn)AddControl(new Guid("d1594788-7442-4124-99cf-4ef643f33c01"));
            StatusExtendExpDateInDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("74392280-25e0-4b4a-abad-7ec1f335e1b0"));
            ExtendExpDateOutID = (ITTTextBox)AddControl(new Guid("6daae680-f666-40f2-aafa-53c4b77397e1"));
            labelBudgetTypeDefinition = (ITTLabel)AddControl(new Guid("5c5f9721-5655-45bc-8a18-2f801876651f"));
            BudgetTypeDefinition = (ITTObjectListBox)AddControl(new Guid("cedd5726-737e-456d-bb35-21ac13cbff53"));
            labelStore = (ITTLabel)AddControl(new Guid("a5bcd843-f767-497b-bb8c-3c55834d86d6"));
            Store = (ITTObjectListBox)AddControl(new Guid("203ba7e1-5fbb-42b6-8fa7-f439d158453b"));
            labelSupplier = (ITTLabel)AddControl(new Guid("5c7d0bdc-1a67-4cbc-a299-c42a4c616c48"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("f0e22a7a-7057-47cb-9b34-42e27155aba4"));
            labelExtendExpDateOutID = (ITTLabel)AddControl(new Guid("cca71b4a-cfe5-412b-a804-770bac471223"));
            base.InitializeControls();
        }

        public BaseExtendExpDateInForm() : base("EXTENDEXPDATEIN", "BaseExtendExpDateInForm")
        {
        }

        protected BaseExtendExpDateInForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}