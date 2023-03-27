
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
    /// Tıbbi Kurul Heyet Teşkili Tanımlama
    /// </summary>
    public partial class MemberOfMedicalCommitteeDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Tıbbi Kurul Heyet Teşkili Tanımlama
    /// </summary>
        protected TTObjectClasses.MemberOfMedicalCommitteeDefinition _MemberOfMedicalCommitteeDefinition
        {
            get { return (TTObjectClasses.MemberOfMedicalCommitteeDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTObjectListBox MedicalCommitteeType;
        protected ITTLabel labelMedicalCommitteeType;
        protected ITTLabel labelStartDate;
        protected ITTGrid Members;
        protected ITTListBoxColumn Doctor;
        protected ITTListBoxColumn Speciality;
        protected ITTCheckBoxColumn MedicalCommiteeMember;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("05ba3267-4d07-4f5b-b376-0df3560c901a"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("a8040597-ddb8-42b9-977c-391973c38162"));
            labelEndDate = (ITTLabel)AddControl(new Guid("a2706f68-19d2-4aa7-a0c0-6a9ef6102d1d"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("0990c9d8-b7f3-47b7-8d50-6e84e3656ece"));
            MedicalCommitteeType = (ITTObjectListBox)AddControl(new Guid("ece0f128-fed0-43f2-b25b-85f9d8ee2277"));
            labelMedicalCommitteeType = (ITTLabel)AddControl(new Guid("f33b4534-8467-4698-879a-91e37ccb74e3"));
            labelStartDate = (ITTLabel)AddControl(new Guid("ffdb1bf5-4871-4d26-ba89-dc862b274b29"));
            Members = (ITTGrid)AddControl(new Guid("de74ad9b-2d8d-4de6-8ed3-f7d7a214b1ad"));
            Doctor = (ITTListBoxColumn)AddControl(new Guid("c40ae7eb-fb49-42d6-96ec-2d2cc5b16138"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("d4483f1d-a713-4290-bb2c-d57a385f5085"));
            MedicalCommiteeMember = (ITTCheckBoxColumn)AddControl(new Guid("282a7724-fc72-4ba3-b30b-4e71732d565d"));
            base.InitializeControls();
        }

        public MemberOfMedicalCommitteeDefinitionForm() : base("MEMBEROFMEDICALCOMMITTEEDEFINITION", "MemberOfMedicalCommitteeDefinitionForm")
        {
        }

        protected MemberOfMedicalCommitteeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}