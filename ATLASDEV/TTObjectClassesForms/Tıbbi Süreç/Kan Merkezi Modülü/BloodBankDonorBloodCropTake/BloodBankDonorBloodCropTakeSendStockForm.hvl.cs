
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
    /// Kan Bankası Donör Kan Alımı Stoğa Gönder Ekranı
    /// </summary>
    public partial class BloodBankDonorBloodCropTakeSendStockForm : EpisodeActionForm
    {
    /// <summary>
    /// Dönor Kan Alım
    /// </summary>
        protected TTObjectClasses.BloodBankDonorBloodCropTake _BloodBankDonorBloodCropTake
        {
            get { return (TTObjectClasses.BloodBankDonorBloodCropTake)_ttObject; }
        }

        public BloodBankDonorBloodCropTakeSendStockForm() : base("BLOODBANKDONORBLOODCROPTAKE", "BloodBankDonorBloodCropTakeSendStockForm")
        {
        }

        protected BloodBankDonorBloodCropTakeSendStockForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}