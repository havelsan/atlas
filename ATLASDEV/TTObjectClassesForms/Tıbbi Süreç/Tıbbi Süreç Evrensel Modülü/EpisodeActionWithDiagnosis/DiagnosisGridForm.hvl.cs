
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
    public partial class DiagnosisGridForm : TTForm
    {
        protected TTObjectClasses.EpisodeActionWithDiagnosis _EpisodeActionWithDiagnosis
        {
            get { return (TTObjectClasses.EpisodeActionWithDiagnosis)_ttObject; }
        }

        protected ITTGrid GridDiagnosis;
        protected ITTButtonColumn AddToFavorite;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTEnumComboBoxColumn PreSecDiagnosis;
        protected ITTListBoxColumn ResponsibleDoctor;
        protected ITTTextBoxColumn FreeDiagnosis;
        override protected void InitializeControls()
        {
            GridDiagnosis = (ITTGrid)AddControl(new Guid("5cd13155-8023-48c8-8f2b-61b3dc0f9b29"));
            AddToFavorite = (ITTButtonColumn)AddControl(new Guid("aa369c55-42c8-4e74-9a5e-b3e8625ff4a7"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("d5d71335-8751-4bdd-8291-4fce515c444b"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("2c8ed053-30a3-456e-ba1a-e4eb5c5da301"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("8fd0b2bf-d99c-4cf7-a39a-f38ae428e5ae"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("2d893c5e-8f50-4a36-8705-4f9c46e8c027"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("d758e47f-70a6-4a44-b483-71e2668cea4d"));
            PreSecDiagnosis = (ITTEnumComboBoxColumn)AddControl(new Guid("0efbfb91-d400-4a25-85da-c7734de5aa5d"));
            ResponsibleDoctor = (ITTListBoxColumn)AddControl(new Guid("023f563a-1fb6-4bcb-87c7-25a8b07ac6e6"));
            FreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("44b27416-8b43-40a5-b7b8-330035990587"));
            base.InitializeControls();
        }

        public DiagnosisGridForm() : base("EPISODEACTIONWITHDIAGNOSIS", "DiagnosisGridForm")
        {
        }

        protected DiagnosisGridForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}