
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
    public partial class HCEODNewForm : EpisodeActionForm
    {
    /// <summary>
    /// Diğer Birimlerden Sağlık Kurulu Muayenesi
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExaminationFromOtherDepartments _HealthCommitteeExaminationFromOtherDepartments
        {
            get { return (TTObjectClasses.HealthCommitteeExaminationFromOtherDepartments)_ttObject; }
        }

        protected ITTEnumComboBox PatientGroup;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelReasonForAdmission;
        protected ITTLabel ttlabel4;
        protected ITTTextBox ProtocolNo;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTLabel labelReasonForExamination;
        override protected void InitializeControls()
        {
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("9a903c19-53b5-4392-9726-1fe589d18f97"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("db0e74cd-0241-41ea-8cde-30fa28b26f67"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("d8bd4a16-820a-4abb-a66a-3d649146cfba"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("dfeb1723-6f3d-4b49-bb6f-5d3389665a18"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("cd6bc460-c9c7-4baa-b80f-8a4f9ec4ec66"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("00e392cb-ec1d-420d-b969-9bd9556a0fb0"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("079ba6dc-42e3-4f0b-9352-df6ff8da87bc"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("99fc2667-f779-46d0-897a-ec08e37b3bf6"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("5a8f82ec-07dd-410b-9ae4-9b4c4a470c71"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("3c602856-2849-4c8e-8d58-bbaa2bf732bd"));
            base.InitializeControls();
        }

        public HCEODNewForm() : base("HEALTHCOMMITTEEEXAMINATIONFROMOTHERDEPARTMENTS", "HCEODNewForm")
        {
        }

        protected HCEODNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}