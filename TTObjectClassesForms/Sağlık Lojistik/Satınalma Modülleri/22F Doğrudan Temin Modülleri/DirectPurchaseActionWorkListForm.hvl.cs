
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
    public partial class DirectPurchaseActionWorkListForm : BaseCriteriaForm
    {
        protected ITTComboBox TestCombo;
        protected ITTLabel ttlabel2;
        protected ITTComboBox StatusBox;
        protected ITTListView MResources;
        protected ITTLabel lblSelectedUnits;
        protected ITTButton SelectButton;
        protected ITTTextBox PatientBox;
        protected ITTTextBox TenderNumber;
        protected ITTTextBox ActionID;
        protected ITTLabel lblPatient;
        protected ITTButton btnDelete;
        protected ITTLabel lblTenderNumber;
        protected ITTButton SelectAllButton;
        protected ITTButton ClearButton;
        protected ITTLabel lblActionID;
        override protected void InitializeControls()
        {
            TestCombo = (ITTComboBox)AddControl(new Guid("fced22ea-5b22-4a85-a505-a812e7be0e17"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("24d94386-35e3-4091-944c-2e84ef000412"));
            StatusBox = (ITTComboBox)AddControl(new Guid("f59954d3-c29d-43a7-b088-c768851deca4"));
            MResources = (ITTListView)AddControl(new Guid("8723e4e0-a927-44bd-b2e6-ea2d0d96ca7d"));
            lblSelectedUnits = (ITTLabel)AddControl(new Guid("94511ce2-8de6-49b9-a563-1ee29d5ace46"));
            SelectButton = (ITTButton)AddControl(new Guid("6b98f167-436e-4e37-b34e-c194fd05ff03"));
            PatientBox = (ITTTextBox)AddControl(new Guid("7caefd35-5eca-4048-b540-5a5a0622b012"));
            TenderNumber = (ITTTextBox)AddControl(new Guid("8598b48e-bac5-4313-82e7-1f0c49bbef3b"));
            ActionID = (ITTTextBox)AddControl(new Guid("65db7bb6-8acb-48d0-b465-962d926e3bac"));
            lblPatient = (ITTLabel)AddControl(new Guid("3a1bfadc-c8e8-47a1-aba3-e2b8ec097cd8"));
            btnDelete = (ITTButton)AddControl(new Guid("774d237e-adda-4f6e-ba84-10b2a5e92db9"));
            lblTenderNumber = (ITTLabel)AddControl(new Guid("d0922ecb-79d0-4183-9390-a6106de43256"));
            SelectAllButton = (ITTButton)AddControl(new Guid("04c1a043-3cb8-4bb2-86db-813e4d287ac4"));
            ClearButton = (ITTButton)AddControl(new Guid("971a6911-d10f-4186-aba3-3c09207de4f4"));
            lblActionID = (ITTLabel)AddControl(new Guid("7fd09316-a258-4956-9005-12e770508059"));
            base.InitializeControls();
        }

        public DirectPurchaseActionWorkListForm() : base("DirectPurchaseActionWorkListForm")
        {
        }

        protected DirectPurchaseActionWorkListForm(string formDefName) : base(formDefName)
        {
        }
    }
}