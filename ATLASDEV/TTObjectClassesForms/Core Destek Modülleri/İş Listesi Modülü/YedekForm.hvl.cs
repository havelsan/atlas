
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
    /// Yedek Form
    /// </summary>
    public partial class YedekForm : BaseCriteriaForm
    {
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
        override protected void InitializeControls()
        {
            PatientStatus = (ITTComboBox)AddControl(new Guid("76d67323-110b-45ea-ad33-d5171f730639"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("46377e5c-d4b7-449f-a5d9-90771b1e40fe"));
            StatusBox = (ITTComboBox)AddControl(new Guid("739d13df-dd99-4519-a82c-d6c947d4b8d2"));
            MResources = (ITTListView)AddControl(new Guid("e3e4a15c-90e3-471b-a8eb-e968e8b893b9"));
            lblSelectedUnits = (ITTLabel)AddControl(new Guid("3503dc75-d682-40b8-a5ef-9b402f36b64d"));
            SelectButton = (ITTButton)AddControl(new Guid("20001ad7-62e9-45dd-93d1-95d344197651"));
            PatientBox = (ITTTextBox)AddControl(new Guid("40ce6786-8f27-4252-8c64-a80eb4d47268"));
            ActionID = (ITTTextBox)AddControl(new Guid("768cf8b1-6592-4194-8a99-5ddacfdcc6e6"));
            lblPatient = (ITTLabel)AddControl(new Guid("1fedbf76-9ba3-4b27-aa11-5528d3fa7c95"));
            ttbutton1 = (ITTButton)AddControl(new Guid("8a70cce5-e500-4ca9-ad44-c064c3a52938"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2e642aac-4c9f-4b40-a8aa-c672fb3494c3"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("06560e46-607e-4ff1-939a-6e1619db94d4"));
            chkOnlyAuthorizedUser = (ITTCheckBox)AddControl(new Guid("5b458e6f-f565-4639-87b1-803d8b7fa86b"));
            chkPlan = (ITTCheckBox)AddControl(new Guid("ab0a6e80-8d6a-48cc-a567-69d251adfbe6"));
            chkEmergency = (ITTCheckBox)AddControl(new Guid("ecf8fbce-c881-4bf0-8452-7426923be903"));
            base.InitializeControls();
        }

        public YedekForm() : base("YedekForm")
        {
        }

        protected YedekForm(string formDefName) : base(formDefName)
        {
        }
    }
}