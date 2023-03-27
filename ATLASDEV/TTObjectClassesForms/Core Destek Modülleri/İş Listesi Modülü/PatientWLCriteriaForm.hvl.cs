
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
    public partial class PatientWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTCheckBox Emergency;
        protected ITTLabel ttlabel2;
        protected ITTComboBox StatusBox;
        protected ITTListView MResources;
        protected ITTLabel lblSelectedUnits;
        protected ITTButton SelectButton;
        protected ITTTextBox PatientBox;
        protected ITTTextBox ActionID;
        protected ITTLabel lblPatient;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel1;
        protected ITTButton SelectAllButton;
        protected ITTButton ClearButton;
        override protected void InitializeControls()
        {
            Emergency = (ITTCheckBox)AddControl(new Guid("efd66167-0455-4884-8f3f-7be12f2f0cf3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("da952cba-93e9-49c3-9cdf-941d57f249cb"));
            StatusBox = (ITTComboBox)AddControl(new Guid("2c22d09e-ceac-4df7-b516-3021acb72616"));
            MResources = (ITTListView)AddControl(new Guid("04a9b4b4-0102-4365-ab80-250ff27cb606"));
            lblSelectedUnits = (ITTLabel)AddControl(new Guid("f0cac3b7-4872-452c-a3eb-351d04e7b0d1"));
            SelectButton = (ITTButton)AddControl(new Guid("cf62a0f3-5026-47f0-93ac-a4abff4f0546"));
            PatientBox = (ITTTextBox)AddControl(new Guid("f6482d97-cab1-45ab-b2a4-38ae0b2360b5"));
            ActionID = (ITTTextBox)AddControl(new Guid("1009106a-fc98-4d74-848e-3a3de7f8f0d7"));
            lblPatient = (ITTLabel)AddControl(new Guid("733964ac-97cf-4279-8a60-2ab71b84b0ed"));
            ttbutton1 = (ITTButton)AddControl(new Guid("5b92354a-d5d4-4be9-ae1e-e71054d64bc0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("10544942-3e91-4205-b697-99a4730d9940"));
            SelectAllButton = (ITTButton)AddControl(new Guid("ac915a79-2ea6-4408-b885-d2923b8bb179"));
            ClearButton = (ITTButton)AddControl(new Guid("136fb86d-cb0d-4f69-8984-4bde6f44b816"));
            base.InitializeControls();
        }

        public PatientWLCriteriaForm() : base("PatientWLCriteriaForm")
        {
        }

        protected PatientWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}