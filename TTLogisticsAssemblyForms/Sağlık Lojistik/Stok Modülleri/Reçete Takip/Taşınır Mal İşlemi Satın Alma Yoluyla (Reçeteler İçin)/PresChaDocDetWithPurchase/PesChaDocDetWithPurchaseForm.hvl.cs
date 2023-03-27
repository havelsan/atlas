
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
    public partial class PesChaDocDetWithPurchaseForm : BaseStockActionDetailInForm
    {
        protected TTObjectClasses.PresChaDocDetWithPurchase _PresChaDocDetWithPurchase
        {
            get { return (TTObjectClasses.PresChaDocDetWithPurchase)_ttObject; }
        }

        protected ITTTabPage PrescriptionPaperTabPage;
        protected ITTButton ttbuttonSorgula;
        protected ITTTextBox seriNo;
        protected ITTLabel ttCiltno;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox bitNo;
        protected ITTTextBox basNo;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel9;
        protected ITTGrid PrescriptionPaperInDetails;
        protected ITTTextBoxColumn SerialNoPrescriptionPaperInDetail;
        protected ITTTextBoxColumn VolumeNoPrescriptionPaperInDetail;
        protected ITTLabel ttlabel10;
        override protected void InitializeControls()
        {
            PrescriptionPaperTabPage = (ITTTabPage)AddControl(new Guid("fbb83f45-1ac4-492e-8881-62f9e6add372"));
            ttbuttonSorgula = (ITTButton)AddControl(new Guid("b0184ebb-0448-419c-b08e-c15077010d6c"));
            seriNo = (ITTTextBox)AddControl(new Guid("e11edce0-9c54-42fa-92f6-9728064c9b53"));
            ttCiltno = (ITTLabel)AddControl(new Guid("d06cca2b-5798-4277-a5d1-6978511b7e01"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("0813bb9e-4a62-4aa6-b973-587e0ce9d070"));
            bitNo = (ITTTextBox)AddControl(new Guid("c7e9b890-4a71-4538-9eb1-d7239437e116"));
            basNo = (ITTTextBox)AddControl(new Guid("001ce1a6-98bd-4156-8140-c23016c856a8"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("9e5ddf32-6926-4646-a1a2-f34ed053adc4"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("c515fdbd-9695-4d0c-baed-f88cda09a809"));
            PrescriptionPaperInDetails = (ITTGrid)AddControl(new Guid("a181ba1d-8b29-43ea-943f-04bc480ca38e"));
            SerialNoPrescriptionPaperInDetail = (ITTTextBoxColumn)AddControl(new Guid("f5b1c554-92e8-4040-966f-9441f5ae23bd"));
            VolumeNoPrescriptionPaperInDetail = (ITTTextBoxColumn)AddControl(new Guid("b4af20f1-8288-4eca-9ada-6fe706819d53"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("e1eef719-390a-4ac2-8126-dd7ebcfd5afe"));
            base.InitializeControls();
        }

        public PesChaDocDetWithPurchaseForm() : base("PRESCHADOCDETWITHPURCHASE", "PesChaDocDetWithPurchaseForm")
        {
        }

        protected PesChaDocDetWithPurchaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}