
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
    /// Tanı Tedavi Odası Tanımı
    /// </summary>
    public partial class TreatmentDiagnosisRoomDefinitionForm : TTForm
    {
    /// <summary>
    /// Tanı Tedavi Odası
    /// </summary>
        protected TTObjectClasses.ResTreatmentDiagnosisRoom _ResTreatmentDiagnosisRoom
        {
            get { return (TTObjectClasses.ResTreatmentDiagnosisRoom)_ttObject; }
        }

        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelName;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTCheckBox IsActive;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelStore = (ITTLabel)AddControl(new Guid("2899ce37-859d-494d-9658-f433f8bd01c2"));
            Store = (ITTObjectListBox)AddControl(new Guid("d74d4cea-08f2-4318-9732-63125df89c1a"));
            labelQref = (ITTLabel)AddControl(new Guid("3817c7cd-39ba-4643-a01f-79e1cbf22084"));
            Qref = (ITTTextBox)AddControl(new Guid("9a2a41c9-fd75-4e1d-9160-f6f51dabf8e5"));
            Name = (ITTTextBox)AddControl(new Guid("0f10c80b-3297-4f0f-913d-b7d8f2be9793"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("d03aae2a-5ae5-4bf0-a02b-9d083a6de486"));
            Location = (ITTTextBox)AddControl(new Guid("30eaab00-6a3f-416c-a06f-a7bc90e189a5"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("12ea11f8-f64f-4b99-85d3-dc827adb125c"));
            labelName = (ITTLabel)AddControl(new Guid("b759c802-48e8-4316-aba0-20c64ee52c45"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("0a678211-9f5e-42c5-b8a4-69811448af10"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("024218ad-be42-4aff-b642-6479e66b9e8b"));
            IsActive = (ITTCheckBox)AddControl(new Guid("dabf21b4-5916-40fd-a0e2-43f3f939438b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e3186d89-95c5-4919-9e5a-e3e729301c07"));
            labelLocation = (ITTLabel)AddControl(new Guid("4f3e461c-0993-4787-bb46-a019aa919f2d"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("14743a86-5ba2-4565-b144-44f40ad5e99e"));
            base.InitializeControls();
        }

        public TreatmentDiagnosisRoomDefinitionForm() : base("RESTREATMENTDIAGNOSISROOM", "TreatmentDiagnosisRoomDefinitionForm")
        {
        }

        protected TreatmentDiagnosisRoomDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}