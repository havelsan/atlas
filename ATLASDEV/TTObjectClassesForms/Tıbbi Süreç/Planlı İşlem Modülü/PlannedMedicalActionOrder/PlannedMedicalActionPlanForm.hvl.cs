
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
    public partial class PlannedMedicalActionPlanForm : BasePlannedMedicalActionOrderForm
    {
    /// <summary>
    /// Planlı Tıbbi İşlem Emri
    /// </summary>
        protected TTObjectClasses.PlannedMedicalActionOrder _PlannedMedicalActionOrder
        {
            get { return (TTObjectClasses.PlannedMedicalActionOrder)_ttObject; }
        }

        protected ITTLabel labelTreatmentStartDateTime;
        protected ITTDateTimePicker TreatmentStartDateTime;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentUnit;
        protected ITTRichTextBoxControl ReasonOfRejection;
        protected ITTLabel labelTreatmentProperties;
        protected ITTTextBox Duration;
        protected ITTTextBox ApplicationArea;
        protected ITTTextBox Amount;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox OrderNote;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelApplicationArea;
        protected ITTLabel labelNote;
        protected ITTLabel labelDuration;
        protected ITTLabel labelAmount;
        protected ITTLabel labelProcedureObject;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelProtocolNo;
        protected ITTLabel labelReasonOfRejection;
        protected ITTLabel labelOrderProcedureDoctor;
        protected ITTObjectListBox OrderProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        override protected void InitializeControls()
        {
            labelTreatmentStartDateTime = (ITTLabel)AddControl(new Guid("c056dd72-b56c-4c51-bafb-45fc43fc4e0e"));
            TreatmentStartDateTime = (ITTDateTimePicker)AddControl(new Guid("a20097cf-d7da-4ed3-93e5-5a5e9a59718e"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("43368c1d-3585-42d2-94f9-3019808c5a1a"));
            TreatmentUnit = (ITTObjectListBox)AddControl(new Guid("f66c2b12-9198-4f25-99ee-71caeb29043b"));
            ReasonOfRejection = (ITTRichTextBoxControl)AddControl(new Guid("5ca6a1d0-2353-4fe5-b513-49bd75cd0a99"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("5720313d-8306-4261-861b-81c7affd48a5"));
            Duration = (ITTTextBox)AddControl(new Guid("b7f2b5fc-d0d2-4653-ae5b-f2435f3ff561"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("1ee4a446-3887-44c7-aafa-c4fe00bc423d"));
            Amount = (ITTTextBox)AddControl(new Guid("7e49afac-5585-4e2d-bc60-d0e623daaff1"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("918105e9-cac7-42f5-afaf-f9405a43e74a"));
            OrderNote = (ITTTextBox)AddControl(new Guid("b3a9f5d2-265a-45b4-8512-2f4e48c3cc48"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("d5ab1fd8-3d20-4564-b234-be2c75c0362e"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("6038650a-358d-4015-94d8-a874b50286a9"));
            labelNote = (ITTLabel)AddControl(new Guid("d7d01552-0adb-42e3-8682-3e5fd45c901f"));
            labelDuration = (ITTLabel)AddControl(new Guid("258d7b1d-922f-426f-8b2c-2b1fbc7ea02c"));
            labelAmount = (ITTLabel)AddControl(new Guid("709e0da1-34e8-4ce4-839a-d70b23ff599f"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("7af3ae12-5578-4ff0-8298-ed6a83c938f5"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("5c5825ad-39e0-4e96-a919-bccf1c443b65"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("be270f7b-6ff7-4541-8552-3a3ef5ad3e1e"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("0ebeab0c-268a-40c1-a104-8c2aaa8146aa"));
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("9cd2bd9f-b639-48da-9283-b24da820456c"));
            labelReasonOfRejection = (ITTLabel)AddControl(new Guid("4bcc8ff4-3a85-4877-b985-0367a99de9e1"));
            labelOrderProcedureDoctor = (ITTLabel)AddControl(new Guid("f1e12df9-7559-43e6-8b98-63e77849f6cc"));
            OrderProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("7e4778f5-9504-424a-a75e-714823a438cf"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("f1142569-98f4-483b-a188-6d7f7f1b4020"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("0b022da7-a045-40ff-bbfe-9de3d94cac75"));
            base.InitializeControls();
        }

        public PlannedMedicalActionPlanForm() : base("PLANNEDMEDICALACTIONORDER", "PlannedMedicalActionPlanForm")
        {
        }

        protected PlannedMedicalActionPlanForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}