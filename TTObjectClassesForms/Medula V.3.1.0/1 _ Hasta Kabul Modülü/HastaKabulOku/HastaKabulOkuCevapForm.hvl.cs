
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
    /// Hasta Kabul Oku Cevap
    /// </summary>
    public partial class HastaKabulOkuCevapForm : BaseHastaKabulOkuCevapForm
    {
    /// <summary>
    /// Hasta Kabul Oku
    /// </summary>
        protected TTObjectClasses.HastaKabulOku _HastaKabulOku
        {
            get { return (TTObjectClasses.HastaKabulOku)_ttObject; }
        }

        public HastaKabulOkuCevapForm() : base("HASTAKABULOKU", "HastaKabulOkuCevapForm")
        {
        }

        protected HastaKabulOkuCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}