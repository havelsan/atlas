
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
    /// İade Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class BasePresReturningDocumentForm : BaseReturningDocumentForm
    {
    /// <summary>
    /// İade Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresReturningDocument _PresReturningDocument
        {
            get { return (TTObjectClasses.PresReturningDocument)_ttObject; }
        }

        protected ITTTabPage PrescriptionTabPage;
        protected ITTGrid PresReturningDocumentMaterials;
        protected ITTListBoxColumn MaterialPresReturningDocMaterial;
        protected ITTTextBoxColumn PresBarcode;
        protected ITTTextBoxColumn PresDistributionType;
        protected ITTTextBoxColumn PresInheld;
        protected ITTTextBoxColumn RequireAmountPresReturningDocMaterial;
        protected ITTTextBoxColumn AmountPresReturningDocMaterial;
        protected ITTListBoxColumn StockLevelTypePresReturningDocMaterial;
        override protected void InitializeControls()
        {
            PrescriptionTabPage = (ITTTabPage)AddControl(new Guid("faebafe4-3640-4ede-86fa-c50e45437062"));
            PresReturningDocumentMaterials = (ITTGrid)AddControl(new Guid("fba48d4e-e774-459a-a2af-72c7bae8e9fa"));
            MaterialPresReturningDocMaterial = (ITTListBoxColumn)AddControl(new Guid("bc69a65d-75b3-4e7f-8eca-ef7e97fc38e7"));
            PresBarcode = (ITTTextBoxColumn)AddControl(new Guid("33fbd907-3a67-45c1-b1a6-b9899053533f"));
            PresDistributionType = (ITTTextBoxColumn)AddControl(new Guid("120abd8e-6925-47be-8a87-cc3081ed1cd4"));
            PresInheld = (ITTTextBoxColumn)AddControl(new Guid("98eb5322-c515-4fc9-ae4e-149a1ed816cb"));
            RequireAmountPresReturningDocMaterial = (ITTTextBoxColumn)AddControl(new Guid("518450f8-9ec4-44fb-8add-7f7417304c21"));
            AmountPresReturningDocMaterial = (ITTTextBoxColumn)AddControl(new Guid("088bfdae-10a9-40aa-bdf6-8fdb1e230fef"));
            StockLevelTypePresReturningDocMaterial = (ITTListBoxColumn)AddControl(new Guid("a594aa3a-e124-4d8d-a99a-fff1f028b6c1"));
            base.InitializeControls();
        }

        public BasePresReturningDocumentForm() : base("PRESRETURNINGDOCUMENT", "BasePresReturningDocumentForm")
        {
        }

        protected BasePresReturningDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}