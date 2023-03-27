
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
    /// Sayım Düzeltme Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresCensusFixedNewForm : BasePresCensusFixedForm
    {
    /// <summary>
    /// Sayım Düzeltme Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresCensusFixed _PresCensusFixed
        {
            get { return (TTObjectClasses.PresCensusFixed)_ttObject; }
        }

        public PresCensusFixedNewForm() : base("PRESCENSUSFIXED", "PresCensusFixedNewForm")
        {
        }

        protected PresCensusFixedNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}