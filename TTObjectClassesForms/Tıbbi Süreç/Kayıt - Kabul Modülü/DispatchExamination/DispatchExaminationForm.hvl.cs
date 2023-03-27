
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
    /// Tani ve Tahlil/Tetkik seçim ekranı
    /// </summary>
    public partial class DispatchExaminationForm : TTForm
    {
    /// <summary>
    /// HİZMET PROTOKOL KABUL NESNESİ
    /// </summary>
        protected TTObjectClasses.DispatchExamination _DispatchExamination
        {
            get { return (TTObjectClasses.DispatchExamination)_ttObject; }
        }

        protected ITTGrid GridDiagnosis;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTTextBoxColumn SecFreeDiagnosis;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn SDateTime;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTListBoxColumn AdditionalProcedureDoctor;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        protected ITTListBoxColumn AdditionalMasterResource;
        override protected void InitializeControls()
        {
            GridDiagnosis = (ITTGrid)AddControl(new Guid("40e98f1c-31ff-4458-9cd5-d0b611723fd7"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("957763fe-19ae-4124-9c3e-3e5d6bee5a2a"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("78c44845-9dc3-4357-8636-e8b5a30ceb2a"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("598741bd-e5a6-4be9-bd15-a8592033c4ca"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("e39dfc36-c08e-4e90-984a-46812fbf0669"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("4cb387cb-4d44-4d5e-8758-284d4fa5e01f"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("3fc04cb5-e2d6-45c9-83f0-273424a3414f"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("8c8584ba-5b7d-496e-b20e-3c56ca9c9604"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("a81bfba1-3aa9-4a8a-ab68-5161ddbac4c6"));
            AdditionalProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("df1d19ac-bb14-4c8e-b38d-7d7654252585"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("2e9f8a17-95fa-4164-abff-89399f480c32"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("52382ebc-272e-449a-a886-342a3179b33c"));
            AdditionalMasterResource = (ITTListBoxColumn)AddControl(new Guid("01f3baf3-f875-48e6-9e73-08958ce7e9b7"));
            base.InitializeControls();
        }

        public DispatchExaminationForm() : base("DISPATCHEXAMINATION", "DispatchExaminationForm")
        {
        }

        protected DispatchExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}