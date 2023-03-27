
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
    /// Nükleer Tetkik İstek Açıklama Formu
    /// </summary>
    public partial class NuclearMedicineRequestInfoForm : TTForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTLabel labelPreInformation;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTextBox txtRequestCorrectionReason;
        protected ITTLabel lblRequestCorrectionReason;
        protected ITTCheckBox IsEmergency;
        override protected void InitializeControls()
        {
            labelPreInformation = (ITTLabel)AddControl(new Guid("a955dce3-5538-4c64-9d09-055ee5452046"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("846d6a15-bbaf-4332-a058-7122138f0519"));
            txtRequestCorrectionReason = (ITTTextBox)AddControl(new Guid("8ac8fd5b-caf0-4a54-ac1a-a0f573dcfc6b"));
            lblRequestCorrectionReason = (ITTLabel)AddControl(new Guid("1842c098-0b03-453e-acf3-30904e922b4d"));
            IsEmergency = (ITTCheckBox)AddControl(new Guid("68332828-3721-4d6f-9179-035813bf125d"));
            base.InitializeControls();
        }

        public NuclearMedicineRequestInfoForm() : base("NUCLEARMEDICINE", "NuclearMedicineRequestInfoForm")
        {
        }

        protected NuclearMedicineRequestInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}