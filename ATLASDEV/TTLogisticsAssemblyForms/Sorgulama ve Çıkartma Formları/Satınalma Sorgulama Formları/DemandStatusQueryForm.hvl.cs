
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
    public partial class DemandStatusQueryForm : TTUnboundForm
    {
        protected ITTGrid DemandDetails;
        protected ITTTextBoxColumn PurchaseItemDef;
        protected ITTTextBoxColumn Status;
        protected ITTTextBox txtDemandNo;
        protected ITTLabel ttlabel2;
        protected ITTButton cmdQuery;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            DemandDetails = (ITTGrid)AddControl(new Guid("c85ee484-9869-4601-b97a-32d99572b78d"));
            PurchaseItemDef = (ITTTextBoxColumn)AddControl(new Guid("4a53e103-2a77-4ff9-b0d0-2a2b22e6ea84"));
            Status = (ITTTextBoxColumn)AddControl(new Guid("20d42a49-816e-4c1c-8993-08abd2741526"));
            txtDemandNo = (ITTTextBox)AddControl(new Guid("d4e5fe09-da0e-4e14-819c-4ad47b6e4e5e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("826ed236-d923-4998-bc9d-d362c62497eb"));
            cmdQuery = (ITTButton)AddControl(new Guid("80813419-da6d-46ca-87ca-b66f94e23f4b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("048e5e67-43e0-4568-b726-8ed7ec9e6ba3"));
            base.InitializeControls();
        }

        public DemandStatusQueryForm() : base("DemandStatusQueryForm")
        {
        }

        protected DemandStatusQueryForm(string formDefName) : base(formDefName)
        {
        }
    }
}