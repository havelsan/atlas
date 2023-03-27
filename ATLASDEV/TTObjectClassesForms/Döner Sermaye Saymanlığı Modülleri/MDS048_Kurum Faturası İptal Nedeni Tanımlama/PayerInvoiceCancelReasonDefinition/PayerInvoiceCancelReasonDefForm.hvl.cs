
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
    /// Kurum Faturası İptal Nedeni Tanımı
    /// </summary>
    public partial class PayerInvoiceCancelReasonDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kurum Faturası İptal Nedeni Tanımı
    /// </summary>
        protected TTObjectClasses.PayerInvoiceCancelReasonDefinition _PayerInvoiceCancelReasonDefinition
        {
            get { return (TTObjectClasses.PayerInvoiceCancelReasonDefinition)_ttObject; }
        }

        protected ITTTextBox Code;
        protected ITTTextBox Name;
        protected ITTLabel labelCode;
        protected ITTLabel labelName;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            Code = (ITTTextBox)AddControl(new Guid("8a771526-d2f4-439a-a48c-93f1c6e504ad"));
            Name = (ITTTextBox)AddControl(new Guid("a441fc54-2e49-4018-be3a-9828da204150"));
            labelCode = (ITTLabel)AddControl(new Guid("66242502-1864-41a9-9643-626292697931"));
            labelName = (ITTLabel)AddControl(new Guid("4e08b311-2330-4362-91c1-ded28e5f051f"));
            Active = (ITTCheckBox)AddControl(new Guid("d1d161b5-0dc2-4c5e-915c-96816a79b425"));
            base.InitializeControls();
        }

        public PayerInvoiceCancelReasonDefForm() : base("PAYERINVOICECANCELREASONDEFINITION", "PayerInvoiceCancelReasonDefForm")
        {
        }

        protected PayerInvoiceCancelReasonDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}