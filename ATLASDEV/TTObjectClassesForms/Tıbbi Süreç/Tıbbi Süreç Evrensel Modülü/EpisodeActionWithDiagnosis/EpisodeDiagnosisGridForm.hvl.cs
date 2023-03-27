
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
    public partial class EpisodeDiagnosisGridForm : TTForm
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
            GridDiagnosis = (ITTGrid)AddControl(new Guid("d3cc1aa8-b8bd-4399-a6c7-a804559aee7c"));
            AddToFavorite = (ITTButtonColumn)AddControl(new Guid("136131dc-919e-4cee-a18a-dd8f78d45a48"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("e1ad4404-0ed6-4fa7-b6d3-ab7562deeb88"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("7c3e90e0-2290-4ebb-9119-7ff43c478cc8"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("c9db88dc-d6fa-48bc-a4aa-cf4447813906"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("0d62eff0-8da5-4260-8656-ba3ba691c858"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("68f5015e-6c22-4fe1-b3f3-515285d12fde"));
            PreSecDiagnosis = (ITTEnumComboBoxColumn)AddControl(new Guid("4ad4c43e-f5a0-4beb-9a1a-6eb83127d854"));
            ResponsibleDoctor = (ITTListBoxColumn)AddControl(new Guid("52a320cf-e605-495d-8b22-1dc8664f7dc4"));
            FreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("aa17e3be-63e9-413b-8706-d0e6f2985fb7"));
            base.InitializeControls();
        }

        public EpisodeDiagnosisGridForm() : base("EPISODEACTIONWITHDIAGNOSIS", "EpisodeDiagnosisGridForm")
        {
        }

        protected EpisodeDiagnosisGridForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}