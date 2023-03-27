
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
    public partial class PrescriptionESignForm : TTUnboundForm
    {
        protected ITTButton btnSaveSignedContent;
        protected ITTTextBox txtSignedContent;
        protected ITTTextBox txtContentForSign;
        protected ITTButton btnCancel;
        protected ITTLabel ttlabel2;
        protected ITTButton btnSignPrescription;
        protected ITTButton btnShowSignCertificate;
        protected ITTLabel ttlabel1;
        protected ITTButton btnSelectSignCertificate;
        protected ITTLabel ttlabel3;
        protected ITTButton btnSendMedula;
        override protected void InitializeControls()
        {
            btnSaveSignedContent = (ITTButton)AddControl(new Guid("924af595-6a4b-4572-8c51-d660945c1144"));
            txtSignedContent = (ITTTextBox)AddControl(new Guid("4737b293-a514-4949-80cc-632be78aea05"));
            txtContentForSign = (ITTTextBox)AddControl(new Guid("cd817c95-8208-4942-9e46-379aa90f45fb"));
            btnCancel = (ITTButton)AddControl(new Guid("8c7ee09d-28d7-4137-809c-283af8007d42"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("747e1f45-9f41-415e-b343-7dd8fe1fc24c"));
            btnSignPrescription = (ITTButton)AddControl(new Guid("4ba969cf-7c68-499a-9f62-17649fb99946"));
            btnShowSignCertificate = (ITTButton)AddControl(new Guid("3a6f62ea-e9b4-4c22-b701-e53ccc1ad7cc"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fbf60211-4f9c-4f7a-83f3-d59fac9e12be"));
            btnSelectSignCertificate = (ITTButton)AddControl(new Guid("1315f7b5-bb9f-40f4-8a3a-af6e805f1b5e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a670a2cc-3cb9-45b4-99ab-728fae8dd648"));
            btnSendMedula = (ITTButton)AddControl(new Guid("cda87c5e-a61f-410d-b8c3-15214598a32a"));
            base.InitializeControls();
        }

        public PrescriptionESignForm() : base("PrescriptionESignForm")
        {
        }

        protected PrescriptionESignForm(string formDefName) : base(formDefName)
        {
        }
    }
}