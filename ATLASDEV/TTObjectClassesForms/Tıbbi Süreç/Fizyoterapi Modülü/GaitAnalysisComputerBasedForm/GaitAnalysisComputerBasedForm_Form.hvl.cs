
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
    public partial class GaitAnalysisComputerBasedForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Yürüme Analizi (Bilgisayar Sistemli Kinetik-Kinematik Analiz)
    /// </summary>
        protected TTObjectClasses.GaitAnalysisComputerBasedForm _GaitAnalysisComputerBasedForm
        {
            get { return (TTObjectClasses.GaitAnalysisComputerBasedForm)_ttObject; }
        }

        protected ITTLabel labelGaitAnalysis;
        protected ITTTextBox GaitAnalysis;
        protected ITTTextBox Code;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelGaitAnalysis = (ITTLabel)AddControl(new Guid("c626d660-4520-400b-a4e0-bed69ff8c8f2"));
            GaitAnalysis = (ITTTextBox)AddControl(new Guid("536564cb-e10b-4254-9042-f05608ddbdb0"));
            Code = (ITTTextBox)AddControl(new Guid("9eea1900-ace8-403a-aa01-035bbff0ef64"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("526db919-9346-4aff-bcde-d2d0d33432c7"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("08949e69-fe5e-45a2-88a1-29f5e864ca0b"));
            labelCode = (ITTLabel)AddControl(new Guid("03f4205a-c8d3-4320-a41b-80df731d35b9"));
            base.InitializeControls();
        }

        public GaitAnalysisComputerBasedForm() : base("GAITANALYSISCOMPUTERBASEDFORM", "GaitAnalysisComputerBasedForm")
        {
        }

        protected GaitAnalysisComputerBasedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}