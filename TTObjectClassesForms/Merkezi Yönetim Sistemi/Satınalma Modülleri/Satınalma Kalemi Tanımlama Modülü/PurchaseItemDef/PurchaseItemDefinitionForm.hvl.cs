
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
    /// Satınalma Kalemi Tanımları
    /// </summary>
    public partial class PurchaseItemDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Satınalma Kalemi Tanımlama
    /// </summary>
        protected TTObjectClasses.PurchaseItemDef _PurchaseItemDef
        {
            get { return (TTObjectClasses.PurchaseItemDef)_ttObject; }
        }

        protected ITTLabel labelGMDNDefinition;
        protected ITTObjectListBox GMDNDefinition;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox StockCardListBox;
        protected ITTTextBox ProcedureName;
        protected ITTTextBox txtTempDistType;
        protected ITTLabel labelProcedureName;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            labelGMDNDefinition = (ITTLabel)AddControl(new Guid("ba17a5c3-cc76-455f-9834-ee63c7a44d48"));
            GMDNDefinition = (ITTObjectListBox)AddControl(new Guid("8b43852b-9b7b-47e4-a32a-ac0b8fefb29e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f0522dcf-277c-47e5-ac10-ddf15eb0bb4c"));
            StockCardListBox = (ITTObjectListBox)AddControl(new Guid("88fa042c-e6c7-4d56-b2f0-1a8cbdda607c"));
            ProcedureName = (ITTTextBox)AddControl(new Guid("16aaeaee-a871-433f-a038-588b95888a43"));
            txtTempDistType = (ITTTextBox)AddControl(new Guid("ef858e82-7ecb-4e77-9eca-ca2ae70bebed"));
            labelProcedureName = (ITTLabel)AddControl(new Guid("167f5469-1c5a-416f-8a1e-7b9fdbb17206"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("83683d66-7e99-4c01-9985-f28c33d2814f"));
            base.InitializeControls();
        }

        public PurchaseItemDefinitionForm() : base("PURCHASEITEMDEF", "PurchaseItemDefinitionForm")
        {
        }

        protected PurchaseItemDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}