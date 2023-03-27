
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
    /// Fiyat Listesi Grubu Tanımlama
    /// </summary>
    public partial class PricingListGroupForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Fiyat listesi grubu
    /// </summary>
        protected TTObjectClasses.PricingListGroupDefinition _PricingListGroupDefinition
        {
            get { return (TTObjectClasses.PricingListGroupDefinition)_ttObject; }
        }

        protected ITTLabel TTLABEL4;
        protected ITTValueListBox PRICELIST;
        protected ITTTextBox Description;
        protected ITTTextBox EXTERNALCODE;
        protected ITTLabel TTLABEL3;
        protected ITTLabel TTLABEL2;
        protected ITTLabel TTLABEL1;
        protected ITTValueListBox PRICEGROUP;
        override protected void InitializeControls()
        {
            TTLABEL4 = (ITTLabel)AddControl(new Guid("18645134-de07-42ce-a7fa-4d75ed3897dc"));
            PRICELIST = (ITTValueListBox)AddControl(new Guid("cfe3f63a-21f1-48bb-949b-5583ca6eb7e9"));
            Description = (ITTTextBox)AddControl(new Guid("7fda0ed2-7a69-45ce-8f19-72f7f52afd0b"));
            EXTERNALCODE = (ITTTextBox)AddControl(new Guid("cbe70e0a-6c67-4638-b8b3-ad63254c600d"));
            TTLABEL3 = (ITTLabel)AddControl(new Guid("bda39b72-4938-4ca8-bec6-94d0d7566123"));
            TTLABEL2 = (ITTLabel)AddControl(new Guid("b6d16d2a-f8fb-40dc-b904-d31126f94df5"));
            TTLABEL1 = (ITTLabel)AddControl(new Guid("95ecb44f-1f66-42c9-b509-d45a9486c58b"));
            PRICEGROUP = (ITTValueListBox)AddControl(new Guid("e5f98062-dd24-4c37-86c6-e59431cfbb17"));
            base.InitializeControls();
        }

        public PricingListGroupForm() : base("PRICINGLISTGROUPDEFINITION", "PricingListGroupForm")
        {
        }

        protected PricingListGroupForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}