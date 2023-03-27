
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
    /// Kan Bankası Kan Bağışı Girişi
    /// </summary>
    public partial class BloodDonationEntryForm : EpisodeActionForm
    {
    /// <summary>
    /// Kan Bağışı Girişi
    /// </summary>
        protected TTObjectClasses.BloodDonationEntry _BloodDonationEntry
        {
            get { return (TTObjectClasses.BloodDonationEntry)_ttObject; }
        }

        public BloodDonationEntryForm() : base("BLOODDONATIONENTRY", "BloodDonationEntryForm")
        {
        }

        protected BloodDonationEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}