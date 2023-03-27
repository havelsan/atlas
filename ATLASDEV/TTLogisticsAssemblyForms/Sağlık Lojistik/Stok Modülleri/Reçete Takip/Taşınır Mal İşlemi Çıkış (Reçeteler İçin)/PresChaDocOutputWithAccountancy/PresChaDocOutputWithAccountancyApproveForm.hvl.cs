
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
    /// Taşınır Mal İşlemi Çıkış (Reçeteler İçin)
    /// </summary>
    public partial class PresChaDocOutputWithAccountancyApproveForm : BasePresChaDocOutputWithAccountancyForm
    {
    /// <summary>
    /// Taşınır Mal İşlemi Çıkış (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresChaDocOutputWithAccountancy _PresChaDocOutputWithAccountancy
        {
            get { return (TTObjectClasses.PresChaDocOutputWithAccountancy)_ttObject; }
        }

        public PresChaDocOutputWithAccountancyApproveForm() : base("PRESCHADOCOUTPUTWITHACCOUNTANCY", "PresChaDocOutputWithAccountancyApproveForm")
        {
        }

        protected PresChaDocOutputWithAccountancyApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}