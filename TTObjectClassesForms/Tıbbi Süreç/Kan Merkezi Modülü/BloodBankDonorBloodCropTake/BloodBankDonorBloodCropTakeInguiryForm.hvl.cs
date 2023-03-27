
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
    /// Kan Bankası Donör Kan Alımı Anket Ekranı
    /// </summary>
    public partial class BloodBankDonorBloodCropTakeInguiryForm : EpisodeActionForm
    {
    /// <summary>
    /// Dönor Kan Alım
    /// </summary>
        protected TTObjectClasses.BloodBankDonorBloodCropTake _BloodBankDonorBloodCropTake
        {
            get { return (TTObjectClasses.BloodBankDonorBloodCropTake)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckbox2;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("73ccf1e3-2b6f-4d34-992e-704c48229ace"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("378fd4ab-c80e-4649-802e-e975e4047a93"));
            base.InitializeControls();
        }

        public BloodBankDonorBloodCropTakeInguiryForm() : base("BLOODBANKDONORBLOODCROPTAKE", "BloodBankDonorBloodCropTakeInguiryForm")
        {
        }

        protected BloodBankDonorBloodCropTakeInguiryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}