
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
    public partial class EpisodeActionWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTCheckBox chkPrivacyPatient;
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
        override protected void InitializeControls()
        {
            chkPrivacyPatient = (ITTCheckBox)AddControl(new Guid("85cd117b-e0f2-4338-bd5a-2eacac1f46f4"));
            TestCombo = (ITTComboBox)AddControl(new Guid("05178387-3d19-4c46-bc72-8358c38144cb"));
            PatientStatus = (ITTComboBox)AddControl(new Guid("8d16a467-3bc2-4ea9-9c88-5a7b5b5ccfe0"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7fcfbaeb-5e9d-4e51-b923-6ed749028c55"));
            StatusBox = (ITTComboBox)AddControl(new Guid("5e07e54a-3f1a-47e6-857d-dadb8e3ed1da"));
            MResources = (ITTListView)AddControl(new Guid("ac1ae223-a352-4816-bc63-3e27b106a5dc"));
            lblSelectedUnits = (ITTLabel)AddControl(new Guid("ed23e26b-8a49-4f52-95c8-663272af80d3"));
            SelectButton = (ITTButton)AddControl(new Guid("6c01d170-8c30-4984-b9e5-45de70d0109e"));
            PatientBox = (ITTTextBox)AddControl(new Guid("efe5ac6a-3fac-4f4c-a6c6-e558dc9b0523"));
            ActionID = (ITTTextBox)AddControl(new Guid("6c5959a4-1b50-412b-85ca-b6da5b251b2d"));
            lblPatient = (ITTLabel)AddControl(new Guid("7caf7d65-236d-4620-9597-46c5955db087"));
            ttbutton1 = (ITTButton)AddControl(new Guid("ba423689-438f-4681-a4fd-cad69369cde2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("135c7ab3-5fa2-4f8c-b8e0-fcb619554597"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("04d33b4d-7818-44f1-834b-23ee84ddbe20"));
            chkOnlyAuthorizedUser = (ITTCheckBox)AddControl(new Guid("1c31bbf3-c4b1-4d06-8bb9-735a891f4561"));
            chkPlan = (ITTCheckBox)AddControl(new Guid("516bdb5a-201b-4d91-bcc6-d51d91d79446"));
            chkEmergency = (ITTCheckBox)AddControl(new Guid("fc9fc01f-7d06-4ad5-af58-048cdceae3c3"));
            SelectAllButton = (ITTButton)AddControl(new Guid("5ece0f47-9b18-4638-b09d-dda360d78921"));
            ClearButton = (ITTButton)AddControl(new Guid("ebfbeded-49a1-4689-939b-750fcb569f2e"));
            base.InitializeControls();
        }

        public EpisodeActionWLCriteriaForm() : base("EpisodeActionWLCriteriaForm")
        {
        }

        protected EpisodeActionWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}