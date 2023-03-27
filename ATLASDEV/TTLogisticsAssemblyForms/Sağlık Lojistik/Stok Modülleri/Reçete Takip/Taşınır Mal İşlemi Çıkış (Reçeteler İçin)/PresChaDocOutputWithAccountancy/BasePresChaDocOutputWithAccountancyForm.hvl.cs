
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
    /// Taşınır Mal İşlemi Çıkış (Reçeteler İçin)
    /// </summary>
    public partial class BasePresChaDocOutputWithAccountancyForm : BaseChattelDocumentOutputWithAccountancy
    {
    /// <summary>
    /// Taşınır Mal İşlemi Çıkış (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresChaDocOutputWithAccountancy _PresChaDocOutputWithAccountancy
        {
            get { return (TTObjectClasses.PresChaDocOutputWithAccountancy)_ttObject; }
        }

        protected ITTTabPage PrescriptionTabPage;
        protected ITTGrid PresChaDocOutputWithAccountancyDetails;
        protected ITTListBoxColumn MaterialPresChaDocOutputDetWithAccountancy;
        protected ITTTextBoxColumn PresBarcode;
        protected ITTTextBoxColumn PresDistributionType;
        protected ITTTextBoxColumn PresInheld;
        protected ITTTextBoxColumn AmountPresChaDocOutputDetWithAccountancy;
        protected ITTTextBoxColumn PresUnitPrice;
        protected ITTTextBoxColumn PresPrice;
        protected ITTListBoxColumn StockLevelTypePresChaDocOutputDetWithAccountancy;
        protected ITTDateTimePickerColumn InvoiceDatePresChaDocOutputDetWithAccountancy;
        protected ITTEnumComboBoxColumn StatusPresChaDocOutputDetWithAccountancy;
        override protected void InitializeControls()
        {
            PrescriptionTabPage = (ITTTabPage)AddControl(new Guid("ced06643-8f1d-4534-8245-68b2245b42d7"));
            PresChaDocOutputWithAccountancyDetails = (ITTGrid)AddControl(new Guid("f9152e0f-fdf3-4305-b060-4e99f87ca77a"));
            MaterialPresChaDocOutputDetWithAccountancy = (ITTListBoxColumn)AddControl(new Guid("4c1a9468-2276-44be-87b6-21b6912cd7c7"));
            PresBarcode = (ITTTextBoxColumn)AddControl(new Guid("3739723d-472c-48b9-9e6e-335bc6af96fe"));
            PresDistributionType = (ITTTextBoxColumn)AddControl(new Guid("06941644-934d-4760-aefc-8c0adff0be5f"));
            PresInheld = (ITTTextBoxColumn)AddControl(new Guid("e90377ab-5aed-4b6a-8f6b-7f73e9c5ba4b"));
            AmountPresChaDocOutputDetWithAccountancy = (ITTTextBoxColumn)AddControl(new Guid("b60e1e56-7584-47de-82a8-05aeb81b9a47"));
            PresUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("71abcca6-ac11-45a0-938e-8a3123d0f004"));
            PresPrice = (ITTTextBoxColumn)AddControl(new Guid("aef59e40-0347-4150-a8ce-ec20cf7e6f66"));
            StockLevelTypePresChaDocOutputDetWithAccountancy = (ITTListBoxColumn)AddControl(new Guid("a9325981-4ab5-4a60-b589-0e6783c10554"));
            InvoiceDatePresChaDocOutputDetWithAccountancy = (ITTDateTimePickerColumn)AddControl(new Guid("255ba9ad-a974-4533-bfbc-5f964a1d205c"));
            StatusPresChaDocOutputDetWithAccountancy = (ITTEnumComboBoxColumn)AddControl(new Guid("4c8ecd26-9253-489a-b0f2-8e767188f208"));
            base.InitializeControls();
        }

        public BasePresChaDocOutputWithAccountancyForm() : base("PRESCHADOCOUTPUTWITHACCOUNTANCY", "BasePresChaDocOutputWithAccountancyForm")
        {
        }

        protected BasePresChaDocOutputWithAccountancyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}