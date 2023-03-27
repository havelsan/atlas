
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
    /// Yatan Hasta İş Listesi
    /// </summary>
    public partial class InpatientWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTComboBox TestCombo;
        protected ITTComboBox PatientStatus;
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
        protected ITTLabel ttlabel3;
        protected ITTCheckBox chkOnlyAuthorizedUser;
        protected ITTCheckBox chkPlan;
        protected ITTCheckBox chkEmergency;
        protected ITTButton SelectAllButton;
        protected ITTButton ClearButton;
        protected ITTComboBox SecMasterResourcesCombo;
        protected ITTLabel lblSecMasterResource;
        protected ITTButton SecMasterSelectAll;
        protected ITTButton SecMasterClearButton;
        protected ITTListView SecMResources;
        protected ITTCheckBox chkPrivacyPatient;
        override protected void InitializeControls()
        {
            TestCombo = (ITTComboBox)AddControl(new Guid("1de9aab8-9f8a-4e45-bbf2-959490c43f62"));
            PatientStatus = (ITTComboBox)AddControl(new Guid("a5596ef2-6262-434f-936b-c6c3f2e1d167"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d49cbbda-99ee-4627-87fb-402be99d7e5c"));
            StatusBox = (ITTComboBox)AddControl(new Guid("d3d52079-b33e-4f3d-98a6-a18bc84f9a61"));
            MResources = (ITTListView)AddControl(new Guid("d9e1dff7-c23f-40c1-b3a6-df435dc7d084"));
            lblSelectedUnits = (ITTLabel)AddControl(new Guid("d1e9616d-2811-4319-9532-854e31fa332d"));
            SelectButton = (ITTButton)AddControl(new Guid("d9bbddb4-5333-4b3c-9756-d45f7f773ac1"));
            PatientBox = (ITTTextBox)AddControl(new Guid("584d427f-bddd-43e2-aedc-c1e6dee4f746"));
            ActionID = (ITTTextBox)AddControl(new Guid("3ed05505-cf1b-4213-abe8-9bf568a208af"));
            lblPatient = (ITTLabel)AddControl(new Guid("9d2e62f7-c4e3-46f2-b345-4890bf9a670c"));
            ttbutton1 = (ITTButton)AddControl(new Guid("d8abfa81-6da3-4514-8847-005952f23db4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a30139fc-50f3-4195-a434-ff2ef4490731"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("47f358b7-805c-40f4-9971-5a92016ba423"));
            chkOnlyAuthorizedUser = (ITTCheckBox)AddControl(new Guid("3b060f6e-e51a-4490-a646-5fe1965747dc"));
            chkPlan = (ITTCheckBox)AddControl(new Guid("32800599-43ef-4b31-ae08-45bd9ba06abb"));
            chkEmergency = (ITTCheckBox)AddControl(new Guid("7a660ade-a2fd-4dae-8359-40b014588971"));
            SelectAllButton = (ITTButton)AddControl(new Guid("df96877a-9ada-4098-9748-e802567848a1"));
            ClearButton = (ITTButton)AddControl(new Guid("b536a050-e6e7-438a-8114-b65ab27a664b"));
            SecMasterResourcesCombo = (ITTComboBox)AddControl(new Guid("d3a49b31-7af1-4067-aac9-06da696e3287"));
            lblSecMasterResource = (ITTLabel)AddControl(new Guid("e819ab14-c917-4587-8bc2-db09c7744885"));
            SecMasterSelectAll = (ITTButton)AddControl(new Guid("8458f5d0-31a6-4678-ba1d-45895e99a7f4"));
            SecMasterClearButton = (ITTButton)AddControl(new Guid("6707ee67-4c61-4b1a-854e-a7d0872931e2"));
            SecMResources = (ITTListView)AddControl(new Guid("21329e0c-89e5-48b9-9492-2e2456ce1c20"));
            chkPrivacyPatient = (ITTCheckBox)AddControl(new Guid("c309b531-a8f4-49f7-803e-67dd6e3da585"));
            base.InitializeControls();
        }

        public InpatientWLCriteriaForm() : base("InpatientWLCriteriaForm")
        {
        }

        protected InpatientWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}