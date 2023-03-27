
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
    /// Satın Alma Kalemi Talep
    /// </summary>
    public partial class PurchaseItemDemandForm : TTForm
    {
    /// <summary>
    /// Satınalma Kalemi Talep
    /// </summary>
        protected TTObjectClasses.PurchaseItemDemand _PurchaseItemDemand
        {
            get { return (TTObjectClasses.PurchaseItemDemand)_ttObject; }
        }

        protected ITTLabel labelWorkListDescription;
        protected ITTTextBox WorkListDescription;
        protected ITTTextBox ItemName;
        protected ITTLabel labelItemName;
        override protected void InitializeControls()
        {
            labelWorkListDescription = (ITTLabel)AddControl(new Guid("59d3a925-9561-427e-906e-2a819a4805ef"));
            WorkListDescription = (ITTTextBox)AddControl(new Guid("bbba0f9a-9a95-4fec-88e3-c2808f7480b4"));
            ItemName = (ITTTextBox)AddControl(new Guid("66254a61-53e8-40b2-84b0-4c75acd243df"));
            labelItemName = (ITTLabel)AddControl(new Guid("f899c61b-1320-4f07-8a75-8a5feb682c3f"));
            base.InitializeControls();
        }

        public PurchaseItemDemandForm() : base("PURCHASEITEMDEMAND", "PurchaseItemDemandForm")
        {
        }

        protected PurchaseItemDemandForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}