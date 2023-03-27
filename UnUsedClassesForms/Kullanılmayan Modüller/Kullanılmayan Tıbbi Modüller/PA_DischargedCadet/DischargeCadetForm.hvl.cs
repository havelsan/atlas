
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
    /// Ayrılmış XXXXXX Öğrenci (Özel Statülü)
    /// </summary>
    public partial class DischargeCadetForm : PatientAdmissionForm
    {
    /// <summary>
    /// Özel Statülü XXXXXX Öğrenci
    /// </summary>
        protected TTObjectClasses.PA_DischargedCadet _PA_DischargedCadet
        {
            get { return (TTObjectClasses.PA_DischargedCadet)_ttObject; }
        }

        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelDocumentNumber;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelProtocol;
        protected ITTLabel labelCity;
        protected ITTLabel labelFoundation;
        protected ITTObjectListBox PayerCity;
        protected ITTTextBox RetirementFundID;
        protected ITTObjectListBox Protocol;
        protected ITTLabel labelRetirementFundID;
        protected ITTObjectListBox Payer;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox HealtSlipNumber;
        override protected void InitializeControls()
        {
            DocumentNumber = (ITTTextBox)AddControl(new Guid("5ef7262e-876f-421b-969d-55d15dd41c2f"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("2aaa1246-b828-4e19-a76b-96abec2e1623"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("0661da15-9770-4258-9da1-c6ccae32ac9b"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("53a2728e-0620-4fe3-ad13-3a9ecaf65c0f"));
            labelProtocol = (ITTLabel)AddControl(new Guid("2351450a-9f6d-4e59-8c36-a1cacf65e7eb"));
            labelCity = (ITTLabel)AddControl(new Guid("5955d333-542e-4704-8afa-adccafb11183"));
            labelFoundation = (ITTLabel)AddControl(new Guid("f8bd7dd5-01fa-4f7c-aeaa-e7cf161a838a"));
            PayerCity = (ITTObjectListBox)AddControl(new Guid("6be8559b-0166-44ef-86e5-0a2f8be97348"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("e365a323-fae6-4370-bc56-7999cd522489"));
            Protocol = (ITTObjectListBox)AddControl(new Guid("d203a580-8417-46e8-9624-207dc0c76749"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("9e5c249b-9e0c-4505-844d-76381965e61b"));
            Payer = (ITTObjectListBox)AddControl(new Guid("fef073cc-ae79-4dc7-8a15-2a8270d0f099"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("bb0063c7-5b23-4005-98c1-03855851cb8b"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("9d704133-2a21-4eee-9574-14fba2c0cfa1"));
            base.InitializeControls();
        }

        public DischargeCadetForm() : base("PA_DISCHARGEDCADET", "DischargeCadetForm")
        {
        }

        protected DischargeCadetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}