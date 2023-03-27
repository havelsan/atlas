
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class BasePrescriptionConsumptionDocumentForm : BaseProductionConsumptionDocumentForm
    {
    /// <summary>
    /// Tüketim, Üretim ve Elde Edilenler Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PrescriptionConsumptionDocument _PrescriptionConsumptionDocument
        {
            get { return (TTObjectClasses.PrescriptionConsumptionDocument)_ttObject; }
        }

        protected ITTTabPage PrescriptionTabPage;
        protected ITTGrid PresConsumptionDocOutMaterials;
        protected ITTListBoxColumn MaterialPrescriptionConsumptionDocumentMaterialOut;
        protected ITTTextBoxColumn PrescriptionBarcode;
        protected ITTTextBoxColumn PrescriptionDistributionType;
        protected ITTTextBoxColumn AmountPrescriptionConsumptionDocumentMaterialOut;
        protected ITTListBoxColumn StockLevelTypePrescriptionConsumptionDocumentMaterialOut;
        protected ITTEnumComboBoxColumn StatusPrescriptionConsumptionDocumentMaterialOut;
        override protected void InitializeControls()
        {
            PrescriptionTabPage = (ITTTabPage)AddControl(new Guid("812ffe5c-6bfc-4b13-95cf-c9ec92ac7960"));
            PresConsumptionDocOutMaterials = (ITTGrid)AddControl(new Guid("902dd1be-ec71-41c6-ad36-f66d46c8c682"));
            MaterialPrescriptionConsumptionDocumentMaterialOut = (ITTListBoxColumn)AddControl(new Guid("1dce541c-0105-4872-905c-57bc0f1a7d01"));
            PrescriptionBarcode = (ITTTextBoxColumn)AddControl(new Guid("80fffb07-7e64-4656-b79b-a872bfb7d408"));
            PrescriptionDistributionType = (ITTTextBoxColumn)AddControl(new Guid("4427892a-aa32-4e53-933f-85abfdc1c2d1"));
            AmountPrescriptionConsumptionDocumentMaterialOut = (ITTTextBoxColumn)AddControl(new Guid("c2b6eef6-aa52-4d3f-92b2-0b2f8c10bbc2"));
            StockLevelTypePrescriptionConsumptionDocumentMaterialOut = (ITTListBoxColumn)AddControl(new Guid("275cc2cf-280b-4039-9eb5-72a2b7e0ef71"));
            StatusPrescriptionConsumptionDocumentMaterialOut = (ITTEnumComboBoxColumn)AddControl(new Guid("e629e424-3f9c-4a36-b3ce-cd974d82e504"));
            base.InitializeControls();
        }

        public BasePrescriptionConsumptionDocumentForm() : base("PRESCRIPTIONCONSUMPTIONDOCUMENT", "BasePrescriptionConsumptionDocumentForm")
        {
        }

        protected BasePrescriptionConsumptionDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}