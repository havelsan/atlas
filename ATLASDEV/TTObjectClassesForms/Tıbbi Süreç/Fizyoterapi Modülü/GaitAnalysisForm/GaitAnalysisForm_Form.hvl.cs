
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
    public partial class GaitAnalysisForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Yürüme Analizi 
    /// </summary>
        protected TTObjectClasses.GaitAnalysisForm _GaitAnalysisForm
        {
            get { return (TTObjectClasses.GaitAnalysisForm)_ttObject; }
        }

        protected ITTLabel labelGMFCS;
        protected ITTTextBox GMFCS;
        protected ITTTextBox PULSESProfile;
        protected ITTTextBox FIM;
        protected ITTTextBox BarthelIndex;
        protected ITTTextBox RivermeadAssessment;
        protected ITTTextBox FAC;
        protected ITTTextBox Code;
        protected ITTLabel labelPULSESProfile;
        protected ITTLabel labelFIM;
        protected ITTLabel labelBarthelIndex;
        protected ITTLabel labelRivermeadAssessment;
        protected ITTLabel labelFAC;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelGMFCS = (ITTLabel)AddControl(new Guid("50d89b4d-70ad-44ec-8ce8-a45777417563"));
            GMFCS = (ITTTextBox)AddControl(new Guid("3bc1f5e3-a209-4ad9-a2dd-5eb819811bab"));
            PULSESProfile = (ITTTextBox)AddControl(new Guid("22cfb64a-d786-454c-9c63-946bac52def8"));
            FIM = (ITTTextBox)AddControl(new Guid("dddc4a11-0429-4f73-a358-bd06a3ae827f"));
            BarthelIndex = (ITTTextBox)AddControl(new Guid("d3d502ee-4de1-4480-812b-b68759c5d061"));
            RivermeadAssessment = (ITTTextBox)AddControl(new Guid("283ba3e3-f03d-4c7b-9c96-f216d872e10b"));
            FAC = (ITTTextBox)AddControl(new Guid("73218deb-2f4d-4b80-9107-c06cea4108a9"));
            Code = (ITTTextBox)AddControl(new Guid("40523a8d-cf95-417b-802e-5a5775deceff"));
            labelPULSESProfile = (ITTLabel)AddControl(new Guid("43a65873-c6ec-4d95-8911-28ed854aa323"));
            labelFIM = (ITTLabel)AddControl(new Guid("0f10e9a3-2886-44a9-881a-52936e8e9bf2"));
            labelBarthelIndex = (ITTLabel)AddControl(new Guid("f8ff70ed-8c0c-472a-ab36-e9fce05e939f"));
            labelRivermeadAssessment = (ITTLabel)AddControl(new Guid("fbe0e9b9-e755-42c3-a59f-5bb70b4f82dc"));
            labelFAC = (ITTLabel)AddControl(new Guid("cfcf7cab-e708-4535-89f1-6711c8932545"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("056075f8-30d0-4d30-afd5-4aa0b5b552f0"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("dbfa90cd-a16c-4cef-8d53-19d96e4f1d4b"));
            labelCode = (ITTLabel)AddControl(new Guid("5d2906c8-b20d-4e97-a359-99c0c99f976c"));
            base.InitializeControls();
        }

        public GaitAnalysisForm() : base("GAITANALYSISFORM", "GaitAnalysisForm")
        {
        }

        protected GaitAnalysisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}