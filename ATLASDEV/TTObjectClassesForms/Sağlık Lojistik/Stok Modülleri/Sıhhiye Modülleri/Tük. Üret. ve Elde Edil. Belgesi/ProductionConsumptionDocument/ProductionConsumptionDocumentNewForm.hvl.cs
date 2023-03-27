
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi
    /// </summary>
    public partial class ProductionConsumptionDocumentNewForm : BaseProductionConsumptionDocumentForm
    {
    /// <summary>
    /// Tüketim, Üretim ve Elde Edilenler Belgesi  için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.ProductionConsumptionDocument _ProductionConsumptionDocument
        {
            get { return (TTObjectClasses.ProductionConsumptionDocument)_ttObject; }
        }

        public ProductionConsumptionDocumentNewForm() : base("PRODUCTIONCONSUMPTIONDOCUMENT", "ProductionConsumptionDocumentNewForm")
        {
        }

        protected ProductionConsumptionDocumentNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}