
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
    /// Sağlık Kurulu İş Listesi
    /// </summary>
    public partial class HealthCommitteeWLForm : BaseCriteriaForm
    {
        protected ITTTextBox ReportNo;
        protected ITTTextBox PatientBox;
        protected ITTTextBox ActionID;
        protected ITTLabel ReportNoLabel;
        protected ITTComboBox TestCombo;
        protected ITTComboBox PatientStatus;
        protected ITTLabel ttlabel2;
        protected ITTComboBox StatusBox;
        protected ITTLabel lblSelectedUnits;
        protected ITTButton SelectButton;
        protected ITTLabel lblPatient;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox chkOnlyAuthorizedUser;
        protected ITTCheckBox chkPlan;
        protected ITTCheckBox chkEmergency;
        protected ITTButton SelectAllButton;
        protected ITTButton ClearButton;
        protected ITTListView MResources;
        protected ITTComboBox HospitalName;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            ReportNo = (ITTTextBox)AddControl(new Guid("b2434134-5da7-42bf-983a-18bc3dbec231"));
            PatientBox = (ITTTextBox)AddControl(new Guid("d678ea7a-b64d-4eca-b40d-ee6ea39c65ec"));
            ActionID = (ITTTextBox)AddControl(new Guid("ef48f848-b791-46a1-8c3f-843ed51cd42e"));
            ReportNoLabel = (ITTLabel)AddControl(new Guid("f9f2e485-d53e-46b7-88d0-922aa62302c8"));
            TestCombo = (ITTComboBox)AddControl(new Guid("96ee9509-9ea7-449f-8736-5c74c4d103b2"));
            PatientStatus = (ITTComboBox)AddControl(new Guid("7fcd6860-dc91-4ed0-99e0-a05a35a77306"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8a0032ba-bd06-4a8e-96f5-234cb50d9c6d"));
            StatusBox = (ITTComboBox)AddControl(new Guid("362fc198-d104-4634-b6d6-b6c164044d1a"));
            lblSelectedUnits = (ITTLabel)AddControl(new Guid("cf94dc08-6b4c-4d25-b341-38fe0b6e0854"));
            SelectButton = (ITTButton)AddControl(new Guid("fc2a507f-b7a2-4423-9c1e-a6ccdb5245d4"));
            lblPatient = (ITTLabel)AddControl(new Guid("3f4134c1-1a0d-437e-88e5-2a789067b8d7"));
            ttbutton1 = (ITTButton)AddControl(new Guid("90059129-ff5e-4889-8f02-6c13da524fdb"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6647fe93-13ea-4dd2-b8d2-69f181b7ab83"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("fc7673fb-3eb7-40dc-896b-635e64da8948"));
            chkOnlyAuthorizedUser = (ITTCheckBox)AddControl(new Guid("07948cf7-25d8-493c-a654-632e39d03eea"));
            chkPlan = (ITTCheckBox)AddControl(new Guid("90d75b57-930e-4506-b6a7-87c3129b5eb7"));
            chkEmergency = (ITTCheckBox)AddControl(new Guid("774b35b2-1e90-440f-b90f-5f125bbdddd8"));
            SelectAllButton = (ITTButton)AddControl(new Guid("5e173739-9507-4e13-8e0e-754c3f10a3fe"));
            ClearButton = (ITTButton)AddControl(new Guid("84cb6e0b-eeb0-4a6e-b6ac-7f04b55e7110"));
            MResources = (ITTListView)AddControl(new Guid("11f3c6f6-a7d4-4316-9754-1b08d44c0f10"));
            HospitalName = (ITTComboBox)AddControl(new Guid("3718881b-8a2b-44f3-801f-23ea1e1c0f22"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d9b5ee25-3244-4872-ac0d-ee289a47889f"));
            base.InitializeControls();
        }

        public HealthCommitteeWLForm() : base("HealthCommitteeWLForm")
        {
        }

        protected HealthCommitteeWLForm(string formDefName) : base(formDefName)
        {
        }
    }
}