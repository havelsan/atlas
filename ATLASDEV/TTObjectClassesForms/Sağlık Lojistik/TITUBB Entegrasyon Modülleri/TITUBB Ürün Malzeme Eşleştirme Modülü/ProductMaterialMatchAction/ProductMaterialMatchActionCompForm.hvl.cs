
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
    public partial class ProductMaterialMatchActionCompForm : TTForm
    {
    /// <summary>
    /// TITUBB Ürün Malzeme Eşleştirme
    /// </summary>
        protected TTObjectClasses.ProductMaterialMatchAction _ProductMaterialMatchAction
        {
            get { return (TTObjectClasses.ProductMaterialMatchAction)_ttObject; }
        }

        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel5;
        protected ITTGrid ProductMaterialMatchDetails;
        protected ITTListBoxColumn ProductProductMaterialMatchDetail;
        protected ITTListBoxColumn MaterialProductMaterialMatchDetail;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn MatchReason;
        override protected void InitializeControls()
        {
            labelStore = (ITTLabel)AddControl(new Guid("75868688-c331-41cf-98a1-962cb051ff7b"));
            Store = (ITTObjectListBox)AddControl(new Guid("305736df-5ad8-47f5-9789-b1e73d06312b"));
            labelID = (ITTLabel)AddControl(new Guid("20e55847-9903-439a-bb2f-07630472d609"));
            ID = (ITTTextBox)AddControl(new Guid("0c96ee94-277b-45f9-a550-3eacd6968cf1"));
            labelActionDate = (ITTLabel)AddControl(new Guid("c14a4d01-0944-4384-88cf-e5c6d021a267"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("a3b14690-3b41-41ee-9e95-065ddea2de40"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("79c7bf83-fc3b-415c-a57c-c0d663057349"));
            ProductMaterialMatchDetails = (ITTGrid)AddControl(new Guid("d68f713d-4425-4a60-a1eb-6e7714a2473c"));
            ProductProductMaterialMatchDetail = (ITTListBoxColumn)AddControl(new Guid("98d0fbb2-d6a7-4ca6-9cbc-c9fc1a3d5175"));
            MaterialProductMaterialMatchDetail = (ITTListBoxColumn)AddControl(new Guid("992e709d-21f3-4a20-bfd0-b3bf6255e5eb"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("b29d69f5-d4f0-4044-bd2d-891bb50b841d"));
            MatchReason = (ITTListBoxColumn)AddControl(new Guid("e50c97d8-de88-48ed-93c6-e88ca94a867b"));
            base.InitializeControls();
        }

        public ProductMaterialMatchActionCompForm() : base("PRODUCTMATERIALMATCHACTION", "ProductMaterialMatchActionCompForm")
        {
        }

        protected ProductMaterialMatchActionCompForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}