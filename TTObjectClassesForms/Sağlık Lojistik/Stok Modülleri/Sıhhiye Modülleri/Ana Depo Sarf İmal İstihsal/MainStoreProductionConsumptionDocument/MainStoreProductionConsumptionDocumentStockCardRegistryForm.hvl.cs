
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
    /// Ana Depodan Sarf İmal İstihsal Belgesi 
    /// </summary>
    public partial class MainStoreProductionConsumptionDocumentStockCardRegistryForm : BaseMainStoreProductionConsumptionDocument
    {
    /// <summary>
    /// Ana Depodan Sarf İmal İstihsal Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.MainStoreProductionConsumptionDocument _MainStoreProductionConsumptionDocument
        {
            get { return (TTObjectClasses.MainStoreProductionConsumptionDocument)_ttObject; }
        }

        protected ITTLabel LABELREGISTRATIONNUMBER;
        protected ITTTextBox REGISTRATIONNUMBER;
        protected ITTLabel LABELSEQUENCENUMBER;
        protected ITTTextBox SEQUENCENUMBER;
        override protected void InitializeControls()
        {
            LABELREGISTRATIONNUMBER = (ITTLabel)AddControl(new Guid("40d15834-cc4b-4050-bcd9-068605225988"));
            REGISTRATIONNUMBER = (ITTTextBox)AddControl(new Guid("8d1bdec5-96ac-4779-86ff-a3e60e47771f"));
            LABELSEQUENCENUMBER = (ITTLabel)AddControl(new Guid("cedf56c9-e10f-4ca4-8625-2e2a4415f21c"));
            SEQUENCENUMBER = (ITTTextBox)AddControl(new Guid("8c14e774-a725-43e3-b1ab-8b16e27620db"));
            base.InitializeControls();
        }

        public MainStoreProductionConsumptionDocumentStockCardRegistryForm() : base("MAINSTOREPRODUCTIONCONSUMPTIONDOCUMENT", "MainStoreProductionConsumptionDocumentStockCardRegistryForm")
        {
        }

        protected MainStoreProductionConsumptionDocumentStockCardRegistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}