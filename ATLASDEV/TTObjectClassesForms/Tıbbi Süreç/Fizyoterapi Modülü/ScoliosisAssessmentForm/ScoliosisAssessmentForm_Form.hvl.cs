
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
    public partial class ScoliosisAssessmentForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Skolyoz Değerlendirmesi
    /// </summary>
        protected TTObjectClasses.ScoliosisAssessmentForm _ScoliosisAssessmentForm
        {
            get { return (TTObjectClasses.ScoliosisAssessmentForm)_ttObject; }
        }

        protected ITTLabel labelLegsLength;
        protected ITTEnumComboBox LegsLength;
        protected ITTLabel labelFeetPosture;
        protected ITTEnumComboBox FeetPosture;
        protected ITTLabel labelLegPosture;
        protected ITTEnumComboBox LegPosture;
        protected ITTLabel labelSpinePosture;
        protected ITTEnumComboBox SpinePosture;
        protected ITTLabel labelScapulaPosture;
        protected ITTEnumComboBox ScapulaPosture;
        protected ITTLabel labelShoulderPosture;
        protected ITTEnumComboBox ShoulderPosture;
        protected ITTLabel labelChestPosture;
        protected ITTEnumComboBox ChestPosture;
        protected ITTLabel labelHeadPosture;
        protected ITTEnumComboBox HeadPosture;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelLegsLength = (ITTLabel)AddControl(new Guid("bccb0c10-d30e-447e-871d-1db276c42b20"));
            LegsLength = (ITTEnumComboBox)AddControl(new Guid("7cce3b3e-b752-4595-b057-051a328ff3f1"));
            labelFeetPosture = (ITTLabel)AddControl(new Guid("34853853-909f-4553-bd8f-fc6a23a60077"));
            FeetPosture = (ITTEnumComboBox)AddControl(new Guid("a4a6f1c1-d63a-475d-acbc-b88cfccfdb6e"));
            labelLegPosture = (ITTLabel)AddControl(new Guid("adb6a248-ffdf-4b7d-b71a-b8ba44a9bf67"));
            LegPosture = (ITTEnumComboBox)AddControl(new Guid("71f81a0b-6431-46ac-916c-08fa659ed5d3"));
            labelSpinePosture = (ITTLabel)AddControl(new Guid("f8d9dd46-5b4b-42df-ad24-568a640966c4"));
            SpinePosture = (ITTEnumComboBox)AddControl(new Guid("5650b1b0-8446-43fa-9793-8a7d1ab93ce1"));
            labelScapulaPosture = (ITTLabel)AddControl(new Guid("c5259c53-6555-4040-9d27-8dc30af20276"));
            ScapulaPosture = (ITTEnumComboBox)AddControl(new Guid("64f8e6cc-6b80-4cbd-8bfb-d802cdf12d65"));
            labelShoulderPosture = (ITTLabel)AddControl(new Guid("8da64101-2a56-49c6-b8ec-a86f75586b64"));
            ShoulderPosture = (ITTEnumComboBox)AddControl(new Guid("019cb1db-8417-47a1-bfca-d30c6c7b13b4"));
            labelChestPosture = (ITTLabel)AddControl(new Guid("402aac3a-8e5d-4977-9956-b59d6bdad859"));
            ChestPosture = (ITTEnumComboBox)AddControl(new Guid("8ae4e709-1f67-49fe-8e95-2bbcdb3ade79"));
            labelHeadPosture = (ITTLabel)AddControl(new Guid("02ea5ad5-5bf5-4e2e-bd5f-b4a863dd1bb9"));
            HeadPosture = (ITTEnumComboBox)AddControl(new Guid("4dad0e45-c3cb-40e2-9e8c-fa76240ee5d8"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("6cbd9041-99d4-40b9-9845-cd87dcb5f3a6"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("78c486b3-c2f6-4f4c-bc29-f963503a6798"));
            labelCode = (ITTLabel)AddControl(new Guid("5d27a075-ec63-4773-a1d0-534bbadc086a"));
            Code = (ITTTextBox)AddControl(new Guid("0d1b4598-d0fd-49db-8f6d-070b77bdbbf3"));
            base.InitializeControls();
        }

        public ScoliosisAssessmentForm() : base("SCOLIOSISASSESSMENTFORM", "ScoliosisAssessmentForm")
        {
        }

        protected ScoliosisAssessmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}