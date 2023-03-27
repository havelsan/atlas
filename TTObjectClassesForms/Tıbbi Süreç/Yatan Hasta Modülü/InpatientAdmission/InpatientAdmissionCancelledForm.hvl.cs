
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
    /// Hasta Yatış
    /// </summary>
    public partial class InpatientAdmissionCancelledForm : InPatientAdmissionBaseForm
    {
    /// <summary>
    /// Hasta Yatış  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.InpatientAdmission _InpatientAdmission
        {
            get { return (TTObjectClasses.InpatientAdmission)_ttObject; }
        }

        protected ITTTextBox QuarantineProtocolNo;
        protected ITTTextBox ReasonForInpatientAdmission;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox Emergency;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox TreatmentClinic;
        protected ITTLabel labelQuarantineProtocolNo;
        protected ITTLabel labelReasonForInpatientAdmission;
        protected ITTLabel labelTreatmentClinic;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            QuarantineProtocolNo = (ITTTextBox)AddControl(new Guid("7dc744ab-d9fc-4be2-b692-cbb7655f84fb"));
            ReasonForInpatientAdmission = (ITTTextBox)AddControl(new Guid("61feb156-5c23-4b33-a0d7-7ee49788e70f"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("60f07eda-c07f-4aed-8119-bb2e11bfbfa8"));
            Emergency = (ITTCheckBox)AddControl(new Guid("1030f27b-fe9f-4757-aadd-b3138c2f3e70"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("a64fe7cd-da53-4823-98f5-c2da28ac293b"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("48640d3d-1304-48cc-a8ec-1be5e377034c"));
            TreatmentClinic = (ITTObjectListBox)AddControl(new Guid("b46b4eb2-ee17-4420-8f0f-2ae460852827"));
            labelQuarantineProtocolNo = (ITTLabel)AddControl(new Guid("493284b7-dfd3-4bc0-b646-8e984e1f963d"));
            labelReasonForInpatientAdmission = (ITTLabel)AddControl(new Guid("d50d2098-a70c-47b4-afad-56f10b4b3ab9"));
            labelTreatmentClinic = (ITTLabel)AddControl(new Guid("a2caa7f9-cb0b-4199-854d-4a0ccc7c254e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("076c7de4-d809-44af-877f-8148ab225b58"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("dd653b09-726c-4804-825b-1a16dee2b1f3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("da7e96a4-c1a2-42b7-9bb4-43df108fe745"));
            base.InitializeControls();
        }

        public InpatientAdmissionCancelledForm() : base("INPATIENTADMISSION", "InpatientAdmissionCancelledForm")
        {
        }

        protected InpatientAdmissionCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}