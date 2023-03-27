
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
    /// Üç Uzman Tabip İmzalı Rapor
    /// </summary>
    public partial class HCTSRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Üç Uzman Tabip İmzalı Rapor  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeWithThreeSpecialist _HealthCommitteeWithThreeSpecialist
        {
            get { return (TTObjectClasses.HealthCommitteeWithThreeSpecialist)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpageHTC;
        protected ITTObjectListBox ttobjectlistboxDepartment;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel labelReasonForAdmission;
        protected ITTTextBox NumberOfProcess;
        protected ITTLabel ttlabel5;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel12;
        protected ITTLabel labelReasonForExamination;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTObjectListBox ReasonForAdmission;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("96d912eb-9115-46dd-bfae-89bc08e0d512"));
            tttabpageHTC = (ITTTabPage)AddControl(new Guid("377709e9-b303-4c7c-9f16-acd35f0e79ea"));
            ttobjectlistboxDepartment = (ITTObjectListBox)AddControl(new Guid("9e84b70e-4c3d-4b59-8f7c-71fefef34066"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bb6ad9e2-e451-4d55-8eef-a76eab1de569"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("60c9658b-7628-492a-b508-118fa8f71dfe"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("b1313ab8-23ad-4be1-a76b-fd93b47a0ce8"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("757264e5-4916-41d2-afb0-f1bf99918ee1"));
            NumberOfProcess = (ITTTextBox)AddControl(new Guid("bde1f7b3-44f9-4a92-9548-300b98135e93"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("1169ded4-d6cd-4b86-9d65-ee41e3e234ef"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("fe92773f-a5b8-466b-b0db-92222bc62a96"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("607b1c3e-96d3-46b9-a7a4-55304e985741"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("fe707db1-9ebd-4821-bf63-ce4ffe6f4014"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("2d611f5e-33f4-4593-afbf-087695ba9e2e"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("46a33a11-2e63-46aa-9b50-56c087358159"));
            base.InitializeControls();
        }

        public HCTSRequestForm() : base("HEALTHCOMMITTEEWITHTHREESPECIALIST", "HCTSRequestForm")
        {
        }

        protected HCTSRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}