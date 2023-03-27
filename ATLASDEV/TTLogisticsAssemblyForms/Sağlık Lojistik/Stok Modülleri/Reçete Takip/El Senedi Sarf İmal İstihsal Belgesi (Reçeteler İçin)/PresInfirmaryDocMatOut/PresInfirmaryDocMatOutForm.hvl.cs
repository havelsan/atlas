
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
    public partial class PresInfirmaryDocMatOutForm : TTForm
    {
        protected TTObjectClasses.PresInfirmaryDocMatOut _PresInfirmaryDocMatOut
        {
            get { return (TTObjectClasses.PresInfirmaryDocMatOut)_ttObject; }
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
            PrescriptionConsumptionDetails = (ITTGrid)AddControl(new Guid("db417d20-f239-4a02-87f8-dfc5a5052caf"));
            ActionDatePrescriptionConsumptionDetail = (ITTDateTimePickerColumn)AddControl(new Guid("2531587c-048d-44a1-bec0-7ea388140f84"));
            ActionIDPrescriptionConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("eae00826-8ad4-4d62-976b-f6c69a7afa76"));
            ActionDescriptionPrescriptionConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("0a8faecb-9450-44a3-a2c7-109361d51708"));
            PrescriptionNoPrescriptionConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("f16d0309-d2bb-460a-9c00-b1127fd6659d"));
            PatienFullNamePrescriptionConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("2f0ac75a-910d-435d-9329-f4353e9afd72"));
            DocktorFullNamePrescriptionConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("4814c1f8-3299-4bb3-a3d5-fa186cd70cda"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("a7987220-fb14-4c89-80ad-9edcec4b103a"));
            base.InitializeControls();
        }

        public PresInfirmaryDocMatOutForm() : base("PRESINFIRMARYDOCMATOUT", "PresInfirmaryDocMatOutForm")
        {
        }

        protected PresInfirmaryDocMatOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}