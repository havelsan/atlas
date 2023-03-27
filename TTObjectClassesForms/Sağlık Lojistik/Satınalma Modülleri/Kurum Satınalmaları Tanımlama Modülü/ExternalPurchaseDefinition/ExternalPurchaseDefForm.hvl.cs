
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
    /// Kurum Satınalma Tanımları
    /// </summary>
    public partial class ExternalPurchaseDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Kurum Satınalmaları Tanımlama Modülü
    /// </summary>
        protected TTObjectClasses.ExternalPurchaseDefinition _ExternalPurchaseDefinition
        {
            get { return (TTObjectClasses.ExternalPurchaseDefinition)_ttObject; }
        }

        protected ITTLabel labelSupplier;
        protected ITTObjectListBox Supplier;
        protected ITTLabel labelPurchaseItemDef;
        protected ITTObjectListBox PurchaseItemDef;
        protected ITTLabel labelUnitPrice;
        protected ITTTextBox UnitPrice;
        protected ITTLabel labelPurchasedBy;
        protected ITTTextBox PurchasedBy;
        protected ITTLabel labelPurchaseDate;
        protected ITTDateTimePicker PurchaseDate;
        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        override protected void InitializeControls()
        {
            labelSupplier = (ITTLabel)AddControl(new Guid("4ff085bc-62f1-4a17-bcd9-773053f660f6"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("01c4b692-3ed8-4466-a3b1-cf33ae2e4cd5"));
            labelPurchaseItemDef = (ITTLabel)AddControl(new Guid("d1c01a62-694e-4b23-83a2-e3d31192bbdd"));
            PurchaseItemDef = (ITTObjectListBox)AddControl(new Guid("562f44e1-687a-4f61-8722-470feb29d5ed"));
            labelUnitPrice = (ITTLabel)AddControl(new Guid("9bc9ce89-dd3e-44a7-8b98-19abac96b8f0"));
            UnitPrice = (ITTTextBox)AddControl(new Guid("b36605b8-3c58-4e4a-b10b-957f9adb6ff4"));
            labelPurchasedBy = (ITTLabel)AddControl(new Guid("57af0aea-553a-42d2-9c12-4c1d14989aba"));
            PurchasedBy = (ITTTextBox)AddControl(new Guid("71f6862d-fd58-44e1-974b-93b38e97b8a4"));
            labelPurchaseDate = (ITTLabel)AddControl(new Guid("ceca5429-5635-4475-a771-fa717c446565"));
            PurchaseDate = (ITTDateTimePicker)AddControl(new Guid("8530ca61-0ace-4b31-81d6-b9272e3ccd98"));
            labelAmount = (ITTLabel)AddControl(new Guid("ff0eaca6-b1fe-4689-8a26-981660a46653"));
            Amount = (ITTTextBox)AddControl(new Guid("1ac155e7-8d38-43cc-b404-9cabcee790cd"));
            base.InitializeControls();
        }

        public ExternalPurchaseDefForm() : base("EXTERNALPURCHASEDEFINITION", "ExternalPurchaseDefForm")
        {
        }

        protected ExternalPurchaseDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}