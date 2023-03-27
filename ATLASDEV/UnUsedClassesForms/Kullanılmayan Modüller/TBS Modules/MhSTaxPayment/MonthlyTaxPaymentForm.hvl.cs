
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
    /// Aylık Vergi Hesaplatma
    /// </summary>
    public partial class MonthlyTaxPayment : TTForm
    {
    /// <summary>
    /// Vergi Ödeme İşlemleri
    /// </summary>
        protected TTObjectClasses.MhSTaxPayment _MhSTaxPayment
        {
            get { return (TTObjectClasses.MhSTaxPayment)_ttObject; }
        }

        protected ITTLabel labelStampTax;
        protected ITTTextBox labelPaymentSlipJournalNo;
        protected ITTTextBox DecisionStamp;
        protected ITTLabel labelMonth;
        protected ITTTextBox StampTax;
        protected ITTLabel labelIncomeTax;
        protected ITTTextBox IncomeTax;
        protected ITTLabel labelDate;
        protected ITTTextBox labelPaymentSlipNo;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel7;
        protected ITTDateTimePicker Date;
        protected ITTLabel labelDecisionStamp;
        protected ITTEnumComboBox Month;
        override protected void InitializeControls()
        {
            labelStampTax = (ITTLabel)AddControl(new Guid("e1920267-4c52-42b1-9658-2b84c9e3fbc6"));
            labelPaymentSlipJournalNo = (ITTTextBox)AddControl(new Guid("bfaea1c9-a0f5-41a8-9de7-42f2e90ad1a8"));
            DecisionStamp = (ITTTextBox)AddControl(new Guid("3ad2086e-d3ab-4531-979e-53f23009c1a8"));
            labelMonth = (ITTLabel)AddControl(new Guid("94fbb12a-82f8-4dad-841f-5f6d91916774"));
            StampTax = (ITTTextBox)AddControl(new Guid("de93ade5-c669-468a-bde7-5e9aab406740"));
            labelIncomeTax = (ITTLabel)AddControl(new Guid("966724a7-3417-4e31-ba1e-5e8972e75fdf"));
            IncomeTax = (ITTTextBox)AddControl(new Guid("0506791a-894a-4577-b486-6e3973cd90a8"));
            labelDate = (ITTLabel)AddControl(new Guid("42207132-d35e-4617-90cc-a39a6f522c1c"));
            labelPaymentSlipNo = (ITTTextBox)AddControl(new Guid("b45d3526-752f-4fc9-b178-a10112dc66e4"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9e94a1fb-5413-4695-95d3-9c3a021c548f"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("4e54c78e-2f9e-4eac-b06d-9b0b989ba779"));
            Date = (ITTDateTimePicker)AddControl(new Guid("0a6dd155-d0b5-4e8f-9e85-c521687b5566"));
            labelDecisionStamp = (ITTLabel)AddControl(new Guid("06ec6aec-08a3-49e0-95a5-ec43c7386ce3"));
            Month = (ITTEnumComboBox)AddControl(new Guid("bdd58c86-835f-4b22-8317-ef54c9004c8e"));
            base.InitializeControls();
        }

        public MonthlyTaxPayment() : base("MHSTAXPAYMENT", "MonthlyTaxPayment")
        {
        }

        protected MonthlyTaxPayment(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}