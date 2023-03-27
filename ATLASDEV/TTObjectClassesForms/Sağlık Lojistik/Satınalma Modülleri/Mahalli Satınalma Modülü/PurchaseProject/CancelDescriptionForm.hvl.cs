
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
    /// İptal Edilen İhale Bilgileri
    /// </summary>
    public partial class CancelDescriptionForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("6d5aefb5-1ab3-4bee-99ec-0bb518da55d5"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("57ed238e-735d-4b26-94db-1473b1165ee0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("18f8ccdf-fc67-42b4-9cf9-c992824cea55"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("0d053275-2f76-47b4-8d33-4b5bced3e06c"));
            base.InitializeControls();
        }

        public CancelDescriptionForm() : base("PURCHASEPROJECT", "CancelDescriptionForm")
        {
        }

        protected CancelDescriptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}