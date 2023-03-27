
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
    public partial class AdvanceInfoForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTLabel labelPayMaster;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTTextBox ConfirmNO;
        protected ITTLabel labelPurchaseProjectNO;
        override protected void InitializeControls()
        {
            labelPayMaster = (ITTLabel)AddControl(new Guid("e8966988-5546-4549-81ea-0db4b4b8126c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8f1bc66c-558b-4ae3-805c-48e1a8ed5400"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("534f321f-2827-475a-bf49-5a93c2c6e7a1"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("76dc7740-7322-4fb2-a3fc-6bd36ce8ed98"));
            ConfirmNO = (ITTTextBox)AddControl(new Guid("ede03251-48ff-4d77-8e34-e8bb657ff559"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("8c0ee022-d3be-40a2-8252-c04586aca9ff"));
            base.InitializeControls();
        }

        public AdvanceInfoForm() : base("PURCHASEPROJECT", "AdvanceInfoForm")
        {
        }

        protected AdvanceInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}