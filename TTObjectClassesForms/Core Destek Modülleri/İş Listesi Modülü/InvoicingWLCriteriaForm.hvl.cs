
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
    /// Döner Sermaye İş Listesi
    /// </summary>
    public partial class InvoicingWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTLabel IDLbl;
        protected ITTTextBox ActionID;
        override protected void InitializeControls()
        {
            IDLbl = (ITTLabel)AddControl(new Guid("090875db-0506-4bcb-bc61-45f3cdd1ddbe"));
            ActionID = (ITTTextBox)AddControl(new Guid("aba15349-c939-4dfe-97a3-383703a45a61"));
            base.InitializeControls();
        }

        public InvoicingWLCriteriaForm() : base("InvoicingWLCriteriaForm")
        {
        }

        protected InvoicingWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}