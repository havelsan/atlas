
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
    /// Fiyat Listesi Tanımı
    /// </summary>
    public partial class PricingListForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Fiyat Listesi
    /// </summary>
        protected TTObjectClasses.PricingListDefinition _PricingListDefinition
        {
            get { return (TTObjectClasses.PricingListDefinition)_ttObject; }
        }

        protected ITTTextBox NAME;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox CODE;
        override protected void InitializeControls()
        {
            NAME = (ITTTextBox)AddControl(new Guid("c07ef68e-643c-44d3-8fb9-4f919f636f65"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("04879d5b-dacc-466f-9839-a0e224b77d19"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cdeafd8c-e8c2-4c3e-b657-cbb349fc3462"));
            CODE = (ITTTextBox)AddControl(new Guid("f8a899c2-459e-4677-888d-d1fa27d6063a"));
            base.InitializeControls();
        }

        public PricingListForm() : base("PRICINGLISTDEFINITION", "PricingListForm")
        {
        }

        protected PricingListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}