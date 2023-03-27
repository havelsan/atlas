
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
    /// Şehit Ailesi Kabulü
    /// </summary>
    public partial class PA_MartyFamilyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Şehit Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_MartyrFamily _PA_MartyrFamily
        {
            get { return (TTObjectClasses.PA_MartyrFamily)_ttObject; }
        }

        protected ITTObjectListBox Relationship;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTTextBox RetirementFundID;
        protected ITTObjectListBox MilitaryOffice;
        protected ITTLabel ttlabel2;
        protected ITTTextBox HealtSlipNumber;
        protected ITTLabel labelRelationship;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel labelMilitaryOffice;
        override protected void InitializeControls()
        {
            Relationship = (ITTObjectListBox)AddControl(new Guid("6a11197f-bc1a-4349-bf0f-0f6b79a5e729"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5119230c-f986-4317-8c5b-1187d16673d8"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("d36cabe0-f8cf-46f8-a077-255b41505b2e"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("e051e4a9-9bde-458f-aade-2cccce0411da"));
            MilitaryOffice = (ITTObjectListBox)AddControl(new Guid("7107fd67-2739-450c-a7e2-304a04d01188"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f2e7a3b0-ab07-4a27-ac19-7304f05a8d35"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("d5cbae9b-304f-4ef4-8a92-7ce36103daa0"));
            labelRelationship = (ITTLabel)AddControl(new Guid("28323af8-79bb-4a96-83b2-9906b98a5bfd"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("dd78559c-eb83-4507-b5fb-c7a6df935a7a"));
            labelMilitaryOffice = (ITTLabel)AddControl(new Guid("6b73f2f8-77e6-4eb5-b0b7-ed13b4a02231"));
            base.InitializeControls();
        }

        public PA_MartyFamilyForm() : base("PA_MARTYRFAMILY", "PA_MartyFamilyForm")
        {
        }

        protected PA_MartyFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}