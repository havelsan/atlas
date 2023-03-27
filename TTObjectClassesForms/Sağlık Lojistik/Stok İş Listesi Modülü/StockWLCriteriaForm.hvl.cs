
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
    /// Filtre
    /// </summary>
    public partial class StockWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTObjectListBox UserSearchBox;
        protected ITTTextBox StockActionID;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTComboBox StatusBox;
        protected ITTListView MResources;
        protected ITTLabel lblSelectedUnits;
        protected ITTButton SelectAllButton;
        protected ITTButton ClearButton;
        protected ITTLabel lblUser;
        override protected void InitializeControls()
        {
            UserSearchBox = (ITTObjectListBox)AddControl(new Guid("3a838622-67c2-4a4a-b9bc-6b4dd2d5c5a8"));
            StockActionID = (ITTTextBox)AddControl(new Guid("e379bb9c-8703-4952-9f70-3e345f1c62ae"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("30ba89d9-1451-44b1-8358-013f89d2a721"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7e8626ff-87b8-4835-a5ec-4afcc3e0f69d"));
            StatusBox = (ITTComboBox)AddControl(new Guid("5c0c5d98-7f4b-4a4e-9372-bcf5aca65144"));
            MResources = (ITTListView)AddControl(new Guid("2e7e0cee-54f3-4e65-86d1-0a005bb7a7ef"));
            lblSelectedUnits = (ITTLabel)AddControl(new Guid("e2ba1e93-3687-40db-8d7f-48ffb6d45e25"));
            SelectAllButton = (ITTButton)AddControl(new Guid("11cef03b-5e18-4003-8dfb-75f60179b804"));
            ClearButton = (ITTButton)AddControl(new Guid("d82619db-5169-4c7b-99de-51c948842241"));
            lblUser = (ITTLabel)AddControl(new Guid("bfc2fd12-af04-4922-9f61-8ebbe72583e5"));
            base.InitializeControls();
        }

        public StockWLCriteriaForm() : base("StockWLCriteriaForm")
        {
        }

        protected StockWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}