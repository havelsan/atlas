
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
    public partial class VoucherDistributingDocumentMaterialForm : BaseStockActionDetailOutForm
    {
    /// <summary>
    /// El Senedi Dağıtım Belgesinde malzeme detaylarını tutan sınıftır
    /// </summary>
        protected TTObjectClasses.VoucherDistributingDocumentMaterial _VoucherDistributingDocumentMaterial
        {
            get { return (TTObjectClasses.VoucherDistributingDocumentMaterial)_ttObject; }
        }

        public VoucherDistributingDocumentMaterialForm() : base("VOUCHERDISTRIBUTINGDOCUMENTMATERIAL", "VoucherDistributingDocumentMaterialForm")
        {
        }

        protected VoucherDistributingDocumentMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}