
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
    /// Malzeme Detayları
    /// </summary>
    public partial class DistributionDocumentMaterialForm : BaseStockActionDetailOutForm
    {
    /// <summary>
    /// Dağıtım Belgesinde malzeme detaylarını tutan sınıftır
    /// </summary>
        protected TTObjectClasses.DistributionDocumentMaterial _DistributionDocumentMaterial
        {
            get { return (TTObjectClasses.DistributionDocumentMaterial)_ttObject; }
        }

        public DistributionDocumentMaterialForm() : base("DISTRIBUTIONDOCUMENTMATERIAL", "DistributionDocumentMaterialForm")
        {
        }

        protected DistributionDocumentMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}