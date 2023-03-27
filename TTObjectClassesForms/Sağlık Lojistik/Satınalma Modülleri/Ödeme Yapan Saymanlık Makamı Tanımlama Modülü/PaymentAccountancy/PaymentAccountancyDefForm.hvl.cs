
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
    public partial class PaymentAccountancyDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Ödeme Yapan Saymanlık Makamı
    /// </summary>
        protected TTObjectClasses.PaymentAccountancy _PaymentAccountancy
        {
            get { return (TTObjectClasses.PaymentAccountancy)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("7d54dff0-c2fc-4a02-9d9a-02079c5a0227"));
            Name = (ITTTextBox)AddControl(new Guid("e9d3df8a-18cc-4177-976c-139df51bb75c"));
            base.InitializeControls();
        }

        public PaymentAccountancyDefForm() : base("PAYMENTACCOUNTANCY", "PaymentAccountancyDefForm")
        {
        }

        protected PaymentAccountancyDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}