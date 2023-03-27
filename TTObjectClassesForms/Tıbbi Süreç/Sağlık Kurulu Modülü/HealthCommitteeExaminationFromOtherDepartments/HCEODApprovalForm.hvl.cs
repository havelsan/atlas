
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
    /// Diğer Birim(ler)den Sağlık Kurulu Muayenesi 
    /// </summary>
    public partial class HCEODApprovalForm : EpisodeActionForm
    {
    /// <summary>
    /// Diğer Birimlerden Sağlık Kurulu Muayenesi
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExaminationFromOtherDepartments _HealthCommitteeExaminationFromOtherDepartments
        {
            get { return (TTObjectClasses.HealthCommitteeExaminationFromOtherDepartments)_ttObject; }
        }

        protected ITTTextBox ExplanationOfRejection;
        protected ITTTextBox ProtocolNo;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel labelReasonForAdmission;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelReasonForExamination;
        override protected void InitializeControls()
        {
            ExplanationOfRejection = (ITTTextBox)AddControl(new Guid("dbf46ce8-5b70-42ad-b43e-066e369df255"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("0b85d7fa-ba2f-4ef1-82ab-a90c20481798"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("f93c8389-67cd-4386-b4cf-0b2c3975803d"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("8362b339-941a-4a75-be9c-29d60db31e5f"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("60e3515a-0470-400e-afa2-52e859e1315c"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("a9d55975-832c-44a1-98da-70aee4860d07"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("516036a8-f975-448a-8c64-75a442b8f6e6"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("40fa10f9-c457-4f90-866a-83848e926574"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("27e98a6b-e6cb-4a19-a081-8fbc9b99a809"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f0c0b085-fb32-45de-a4ed-af4e2a49f9f4"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("2c9da344-f92e-46d7-9949-bbae904ca86d"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("333dcede-0290-4526-88dd-ffb353a07a1a"));
            base.InitializeControls();
        }

        public HCEODApprovalForm() : base("HEALTHCOMMITTEEEXAMINATIONFROMOTHERDEPARTMENTS", "HCEODApprovalForm")
        {
        }

        protected HCEODApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}