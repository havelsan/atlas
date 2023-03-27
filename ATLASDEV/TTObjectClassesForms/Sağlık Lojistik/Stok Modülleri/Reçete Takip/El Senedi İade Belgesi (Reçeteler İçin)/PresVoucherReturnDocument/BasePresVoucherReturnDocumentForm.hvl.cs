
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
    /// El Senedi İade Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class BasePresVoucherReturnDocumentForm : BaseVoucherReturnDocumentForm
    {
    /// <summary>
    /// El Senedi İade Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresVoucherReturnDocument _PresVoucherReturnDocument
        {
            get { return (TTObjectClasses.PresVoucherReturnDocument)_ttObject; }
        }

        protected ITTTabPage PrescriptionTabPage;
        protected ITTGrid PresVoucherReturnDocumentMaterials;
        protected ITTListBoxColumn MaterialPresVoucherReturnDocMat;
        protected ITTTextBoxColumn PresBarcode;
        protected ITTListBoxColumn PresDistributionType;
        protected ITTTextBoxColumn ExistingPresVoucherReturnDocMat;
        protected ITTTextBoxColumn RequireAmountPresVoucherReturnDocMat;
        protected ITTTextBoxColumn AmountPresVoucherReturnDocMat;
        protected ITTListBoxColumn StockLevelTypePresVoucherReturnDocMat;
        override protected void InitializeControls()
        {
            PrescriptionTabPage = (ITTTabPage)AddControl(new Guid("a43520b5-cdcd-4a21-a858-1e0e9fa3e4b6"));
            PresVoucherReturnDocumentMaterials = (ITTGrid)AddControl(new Guid("748d9067-e0c5-4905-8895-73df247eb9c4"));
            MaterialPresVoucherReturnDocMat = (ITTListBoxColumn)AddControl(new Guid("53c6b410-81b1-45a1-bdc0-d0912e8dbf0d"));
            PresBarcode = (ITTTextBoxColumn)AddControl(new Guid("59d0dcef-e4d4-4324-913c-135c17a521b0"));
            PresDistributionType = (ITTListBoxColumn)AddControl(new Guid("27d27c77-b236-4063-8ad2-577955a841d5"));
            ExistingPresVoucherReturnDocMat = (ITTTextBoxColumn)AddControl(new Guid("5d15bfa0-e1f9-49a3-b0cf-8cb2c864d0ec"));
            RequireAmountPresVoucherReturnDocMat = (ITTTextBoxColumn)AddControl(new Guid("edcbea16-4fe3-4213-b11c-9e9dc0552828"));
            AmountPresVoucherReturnDocMat = (ITTTextBoxColumn)AddControl(new Guid("7a3922ff-8d85-4802-8af1-b03f69edcfb9"));
            StockLevelTypePresVoucherReturnDocMat = (ITTListBoxColumn)AddControl(new Guid("aa151e86-297b-4225-ae3d-24cba69fcaeb"));
            base.InitializeControls();
        }

        public BasePresVoucherReturnDocumentForm() : base("PRESVOUCHERRETURNDOCUMENT", "BasePresVoucherReturnDocumentForm")
        {
        }

        protected BasePresVoucherReturnDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}