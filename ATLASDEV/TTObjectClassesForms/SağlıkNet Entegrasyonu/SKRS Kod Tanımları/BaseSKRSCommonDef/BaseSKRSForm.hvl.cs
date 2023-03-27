
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
    /// SKRS Form
    /// </summary>
    public partial class BaseSKRSForm : TTForm
    {
    /// <summary>
    /// Ortak SKRS Kodlarının bağlı olduğu base
    /// </summary>
        protected TTObjectClasses.BaseSKRSCommonDef _BaseSKRSCommonDef
        {
            get { return (TTObjectClasses.BaseSKRSCommonDef)_ttObject; }
        }

        public BaseSKRSForm() : base("BASESKRSCOMMONDEF", "BaseSKRSForm")
        {
        }

        protected BaseSKRSForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}