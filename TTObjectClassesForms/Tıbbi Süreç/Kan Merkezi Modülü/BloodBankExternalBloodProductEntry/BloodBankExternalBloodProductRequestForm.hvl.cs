
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
    /// Kan Bankası Dışarıdan Kan Ürünü İstek Ekranı
    /// </summary>
    public partial class BloodBankExternalBloodProductRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Dışarıdan Hastaya Kan Ürünü Girişi
    /// </summary>
        protected TTObjectClasses.BloodBankExternalBloodProductEntry _BloodBankExternalBloodProductEntry
        {
            get { return (TTObjectClasses.BloodBankExternalBloodProductEntry)_ttObject; }
        }

        public BloodBankExternalBloodProductRequestForm() : base("BLOODBANKEXTERNALBLOODPRODUCTENTRY", "BloodBankExternalBloodProductRequestForm")
        {
        }

        protected BloodBankExternalBloodProductRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}