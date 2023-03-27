
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
    /// Reçete Detayları
    /// </summary>
    public partial class PrescriptionDetailForm : TTForm
    {
        protected TTObjectClasses.PrescriptionConsDocMatOut _PrescriptionConsDocMatOut
        {
            get { return (TTObjectClasses.PrescriptionConsDocMatOut)_ttObject; }
        }

        protected ITTGrid PrescriptionConsumptionDetails;
        protected ITTDateTimePickerColumn ActionDatePrescriptionConsumptionDetail;
        protected ITTTextBoxColumn ActionIDPrescriptionConsumptionDetail;
        protected ITTTextBoxColumn ActionDescriptionPrescriptionConsumptionDetail;
        protected ITTTextBoxColumn PrescriptionNoPrescriptionConsumptionDetail;
        protected ITTTextBoxColumn PatienFullNamePrescriptionConsumptionDetail;
        protected ITTTextBoxColumn DocktorFullNamePrescriptionConsumptionDetail;
        protected ITTTextBoxColumn Amount;
        override protected void InitializeControls()
        {
            PrescriptionConsumptionDetails = (ITTGrid)AddControl(new Guid("c90bb98b-861b-43a7-942b-34bd222f0985"));
            ActionDatePrescriptionConsumptionDetail = (ITTDateTimePickerColumn)AddControl(new Guid("c2f1e217-5cd2-4f6a-a69e-00692606075e"));
            ActionIDPrescriptionConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("993cf11d-4940-461b-a102-286a038734b6"));
            ActionDescriptionPrescriptionConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("1c81a472-4ed1-4466-a35d-f1d517e86b27"));
            PrescriptionNoPrescriptionConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("7ab7946c-e8cd-4ea6-ba55-b7888e325111"));
            PatienFullNamePrescriptionConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("9d9ab585-b2cd-4c33-b4d2-b6ed89402bdc"));
            DocktorFullNamePrescriptionConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("c2419c3d-211d-4876-af1b-ed86691f184d"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("32061c45-f0b5-4b35-9584-2ce0ece7ce57"));
            base.InitializeControls();
        }

        public PrescriptionDetailForm() : base("PRESCRIPTIONCONSDOCMATOUT", "PrescriptionDetailForm")
        {
        }

        protected PrescriptionDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}