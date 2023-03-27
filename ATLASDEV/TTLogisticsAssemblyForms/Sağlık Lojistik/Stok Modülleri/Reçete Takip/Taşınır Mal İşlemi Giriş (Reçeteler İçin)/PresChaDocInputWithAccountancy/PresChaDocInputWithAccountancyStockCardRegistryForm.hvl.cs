
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
    /// Taşınır Mal İşlemi Giriş (Reçeteler İçin)
    /// </summary>
    public partial class PresChaDocInputWithAccountancyStockCardRegistryForm : BasePresChaDocInputWithAccountancyForm
    {
    /// <summary>
    /// Taşınır Mal İşlemi Giriş (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresChaDocInputWithAccountancy _PresChaDocInputWithAccountancy
        {
            get { return (TTObjectClasses.PresChaDocInputWithAccountancy)_ttObject; }
        }

        public PresChaDocInputWithAccountancyStockCardRegistryForm() : base("PRESCHADOCINPUTWITHACCOUNTANCY", "PresChaDocInputWithAccountancyStockCardRegistryForm")
        {
        }

        protected PresChaDocInputWithAccountancyStockCardRegistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}