
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
    public partial class MainStoreProductionConsumptionDocumentForm : BaseMainStoreProductionConsumptionDocument
    {
    /// <summary>
    /// Ana Depodan Sarf İmal İstihsal Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.MainStoreProductionConsumptionDocument _MainStoreProductionConsumptionDocument
        {
            get { return (TTObjectClasses.MainStoreProductionConsumptionDocument)_ttObject; }
        }

        public MainStoreProductionConsumptionDocumentForm() : base("MAINSTOREPRODUCTIONCONSUMPTIONDOCUMENT", "MainStoreProductionConsumptionDocumentForm")
        {
        }

        protected MainStoreProductionConsumptionDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}