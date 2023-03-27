
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
    /// E-Reçete Elektronik İmza
    /// </summary>
    public partial class PrescriptionSignForm : TTUnboundForm
    {
        protected ITTTextBox txtContentForSign;
        protected ITTLabel ttlabel2;
        protected ITTButton btnSignPrescription;
        protected ITTButton btnShowSignCertificate;
        protected ITTButton btnCancel;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            txtContentForSign = (ITTTextBox)AddControl(new Guid("b39a4f05-fa36-4ab6-b358-18b3011e006d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6b1f9651-acc3-4f2d-9682-5dccefacdae3"));
            btnSignPrescription = (ITTButton)AddControl(new Guid("adad1986-9343-43f6-a835-cd1b7a7aa5ff"));
            btnShowSignCertificate = (ITTButton)AddControl(new Guid("4c8f7050-ab86-403f-9ee1-2e7ead6a75f2"));
            btnCancel = (ITTButton)AddControl(new Guid("903fdc98-0a5a-4689-ae9c-d28cdc0ff040"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8314f208-92c1-4aec-ba2e-d1909bac151a"));
            base.InitializeControls();
        }

        public PrescriptionSignForm() : base("PrescriptionSignForm")
        {
        }

        protected PrescriptionSignForm(string formDefName) : base(formDefName)
        {
        }
    }
}