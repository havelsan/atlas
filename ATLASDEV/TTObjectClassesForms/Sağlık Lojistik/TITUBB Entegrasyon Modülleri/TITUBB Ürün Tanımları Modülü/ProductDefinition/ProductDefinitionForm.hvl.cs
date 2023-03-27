
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
    /// TITUBB Ürün Tanımı
    /// </summary>
    public partial class ProductDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// TITUBB Ürün Tanımı
    /// </summary>
        protected TTObjectClasses.ProductDefinition _ProductDefinition
        {
            get { return (TTObjectClasses.ProductDefinition)_ttObject; }
        }

        protected ITTGrid ProductSUTMatchs;
        protected ITTTextBoxColumn SUTCodeProductSUTMatchDefinition;
        protected ITTTextBoxColumn SUTNameProductSUTMatchDefinition;
        protected ITTListBoxColumn SUTAppendixProductSUTMatchDefinition;
        protected ITTTextBoxColumn SUTPriceProductSUTMatchDefinition;
        protected ITTCheckBoxColumn IsUseXXXXXXProductSUTMatchDefinition;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelFirm;
        protected ITTObjectListBox Firm;
        protected ITTLabel labelRegistrationDate;
        protected ITTDateTimePicker RegistrationDate;
        protected ITTLabel labelProductNumber;
        protected ITTTextBox ProductNumber;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            ProductSUTMatchs = (ITTGrid)AddControl(new Guid("219d7089-0945-4720-a568-ce769272257d"));
            SUTCodeProductSUTMatchDefinition = (ITTTextBoxColumn)AddControl(new Guid("19db4141-f545-494d-b5fa-f284be09376c"));
            SUTNameProductSUTMatchDefinition = (ITTTextBoxColumn)AddControl(new Guid("4e96fdda-7a81-457c-bbb4-2cc01d80e050"));
            SUTAppendixProductSUTMatchDefinition = (ITTListBoxColumn)AddControl(new Guid("8647a158-83c6-475c-a3bc-8c88ec291e59"));
            SUTPriceProductSUTMatchDefinition = (ITTTextBoxColumn)AddControl(new Guid("db96a216-3220-4a0e-888f-2ddfc19a84ef"));
            IsUseXXXXXXProductSUTMatchDefinition = (ITTCheckBoxColumn)AddControl(new Guid("a135e46c-9545-4eb1-97c9-15590f84e013"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5d6bae6c-51e6-4749-8c17-942c5a0aabb0"));
            labelFirm = (ITTLabel)AddControl(new Guid("65c8f149-2962-4a60-bcb4-ecbba9c82cd6"));
            Firm = (ITTObjectListBox)AddControl(new Guid("d464b897-73dd-460c-8e0d-def55873703c"));
            labelRegistrationDate = (ITTLabel)AddControl(new Guid("7d138f09-77a5-4aad-9a5c-05696a66d6bf"));
            RegistrationDate = (ITTDateTimePicker)AddControl(new Guid("a84edd9e-8b5c-48f7-bc78-f60fdfc82de9"));
            labelProductNumber = (ITTLabel)AddControl(new Guid("506b1a13-7816-4ddf-86f8-96b3e86f556e"));
            ProductNumber = (ITTTextBox)AddControl(new Guid("634c02e4-7e24-458c-8084-fa0b24a53590"));
            Name = (ITTTextBox)AddControl(new Guid("d435ef24-3236-4032-b06e-a83e57d342a1"));
            labelName = (ITTLabel)AddControl(new Guid("4b460c55-e508-4ef2-a69a-fe689b01fa76"));
            base.InitializeControls();
        }

        public ProductDefinitionForm() : base("PRODUCTDEFINITION", "ProductDefinitionForm")
        {
        }

        protected ProductDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}