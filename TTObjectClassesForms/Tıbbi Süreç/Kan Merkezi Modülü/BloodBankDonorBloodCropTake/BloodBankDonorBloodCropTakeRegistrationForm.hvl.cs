
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
    /// Kan Bankası Donör Kan Alımı Giriş Ekranı
    /// </summary>
    public partial class BloodBankDonorBloodCropTakeRegistrationForm : EpisodeActionForm
    {
    /// <summary>
    /// Dönor Kan Alım
    /// </summary>
        protected TTObjectClasses.BloodBankDonorBloodCropTake _BloodBankDonorBloodCropTake
        {
            get { return (TTObjectClasses.BloodBankDonorBloodCropTake)_ttObject; }
        }

        protected ITTTextBox RequestDescription;
        protected ITTLabel labelRequestDescription;
        override protected void InitializeControls()
        {
            RequestDescription = (ITTTextBox)AddControl(new Guid("b393d791-3631-47de-a6fb-104b7e27508b"));
            labelRequestDescription = (ITTLabel)AddControl(new Guid("b7ecc6b0-b052-4511-bda3-67b3f803e685"));
            base.InitializeControls();
        }

        public BloodBankDonorBloodCropTakeRegistrationForm() : base("BLOODBANKDONORBLOODCROPTAKE", "BloodBankDonorBloodCropTakeRegistrationForm")
        {
        }

        protected BloodBankDonorBloodCropTakeRegistrationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}