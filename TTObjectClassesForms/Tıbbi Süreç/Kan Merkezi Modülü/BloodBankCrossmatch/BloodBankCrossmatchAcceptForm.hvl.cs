
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
    /// Kan Bankası Crossmatch Testi Kabul Ekranı
    /// </summary>
    public partial class BloodBankCrossmatchAcceptForm : EpisodeActionForm
    {
    /// <summary>
    /// Crossmatch Testi
    /// </summary>
        protected TTObjectClasses.BloodBankCrossmatch _BloodBankCrossmatch
        {
            get { return (TTObjectClasses.BloodBankCrossmatch)_ttObject; }
        }

        public BloodBankCrossmatchAcceptForm() : base("BLOODBANKCROSSMATCH", "BloodBankCrossmatchAcceptForm")
        {
        }

        protected BloodBankCrossmatchAcceptForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}