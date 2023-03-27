
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
    /// El Senedi Dağıtım Belgesi
    /// </summary>
    public partial class VoucherDistributingDocumentApprovalForm : BaseVoucherDistributingDocumentForm
    {
    /// <summary>
    /// El Senedi Dağıtım Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.VoucherDistributingDocument _VoucherDistributingDocument
        {
            get { return (TTObjectClasses.VoucherDistributingDocument)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn RequireMaterial;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn StoreInheld;
        protected ITTTextBoxColumn DestinationInheld;
        protected ITTListDefComboBoxColumn StockLevelType;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ac0d24f0-e07a-4f6f-841d-97732bd3393e"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("c7c728d3-a0c9-44ed-b6b3-8b5fedb04491"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("ad7bc0bc-d1c3-49c6-8b01-b5ad2a5f4dc3"));
            Detail = (ITTButtonColumn)AddControl(new Guid("6bc58db4-cac4-4e1a-ad03-e6319272ae2b"));
            Material = (ITTListBoxColumn)AddControl(new Guid("714d1a94-6325-4654-ba20-42ff7f6a84f4"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("b9e82ce5-3538-4f7d-ada8-b550ad3a0dd9"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("38267c72-7f57-4647-97f4-a1e59afda407"));
            RequireMaterial = (ITTTextBoxColumn)AddControl(new Guid("ac66bb56-513e-4084-a4ab-d41fb09bbddc"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("4e220a5d-a8b1-4d38-83c9-c6ebe31e7210"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("cd6c1b3c-c12f-4494-a2c4-4ae45dba0ecb"));
            DestinationInheld = (ITTTextBoxColumn)AddControl(new Guid("0f6251cd-57dc-4b99-ac1a-4c3cb27d2b69"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("ba1ace7a-ccd2-413a-9a72-e44c0eb44d03"));
            base.InitializeControls();
        }

        public VoucherDistributingDocumentApprovalForm() : base("VOUCHERDISTRIBUTINGDOCUMENT", "VoucherDistributingDocumentApprovalForm")
        {
        }

        protected VoucherDistributingDocumentApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}