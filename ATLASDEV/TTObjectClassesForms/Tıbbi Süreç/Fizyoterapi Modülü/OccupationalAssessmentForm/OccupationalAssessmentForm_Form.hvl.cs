
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
    public partial class OccupationalAssessmentForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Mesleki Değerlendirme
    /// </summary>
        protected TTObjectClasses.OccupationalAssessmentForm _OccupationalAssessmentForm
        {
            get { return (TTObjectClasses.OccupationalAssessmentForm)_ttObject; }
        }

        protected ITTLabel labelPOP;
        protected ITTTextBox POP;
        protected ITTTextBox DASH;
        protected ITTTextBox FCE;
        protected ITTTextBox CHART;
        protected ITTTextBox Code;
        protected ITTLabel labelDASH;
        protected ITTLabel labelFCE;
        protected ITTLabel labelCHART;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelPOP = (ITTLabel)AddControl(new Guid("09aa52b9-47dc-4fd3-9365-19a4d72fc644"));
            POP = (ITTTextBox)AddControl(new Guid("62eaa5b2-6291-43b7-9396-a2e0a665f437"));
            DASH = (ITTTextBox)AddControl(new Guid("b206455d-7472-4e8a-8aee-0c52f7ec3190"));
            FCE = (ITTTextBox)AddControl(new Guid("7ad04c20-8063-4709-803e-97b429e8f8f8"));
            CHART = (ITTTextBox)AddControl(new Guid("e3fcd3b7-90f2-469e-9de8-828e3b725544"));
            Code = (ITTTextBox)AddControl(new Guid("5e437de0-3d77-4034-8607-e289f596e0e3"));
            labelDASH = (ITTLabel)AddControl(new Guid("5b9d8f93-fa19-420c-a197-3f79c55a0443"));
            labelFCE = (ITTLabel)AddControl(new Guid("ed38094a-92b7-4e67-be8a-ecbec1cad57a"));
            labelCHART = (ITTLabel)AddControl(new Guid("6a310b40-40ba-4ca6-847f-f80ccbc7c349"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("4ff49548-1f64-4dd2-aae0-bc98e44bb0cc"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("15a825dc-0ace-45cc-870c-aa1cee437454"));
            labelCode = (ITTLabel)AddControl(new Guid("337c6eb1-f653-4132-9bd3-00baf859e5f7"));
            base.InitializeControls();
        }

        public OccupationalAssessmentForm() : base("OCCUPATIONALASSESSMENTFORM", "OccupationalAssessmentForm")
        {
        }

        protected OccupationalAssessmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}