
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
    /// Genel Üretim İşlemi
    /// </summary>
    public partial class GeneralProductionActionAppForm : BaseGeneralProductionActionFrom
    {
    /// <summary>
    /// Genel Üretim İşlemi
    /// </summary>
        protected TTObjectClasses.GeneralProductionAction _GeneralProductionAction
        {
            get { return (TTObjectClasses.GeneralProductionAction)_ttObject; }
        }

        public GeneralProductionActionAppForm() : base("GENERALPRODUCTIONACTION", "GeneralProductionActionAppForm")
        {
        }

        protected GeneralProductionActionAppForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}