
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
    public partial class HCExaminationComponentForm : TTForm
    {
        protected TTObjectClasses.HCExaminationComponent _HCExaminationComponent
        {
            get { return (TTObjectClasses.HCExaminationComponent)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelReasonForExamination;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTLabel labelWeight;
        protected ITTTextBox Weight;
        protected ITTTextBox OfferOfDecision;
        protected ITTTextBox NumberOfProcess;
        protected ITTTextBox Height;
        protected ITTTextBox DisabledRatio;
        protected ITTTextBox ttTREATMENTINFO;
        protected ITTTextBox ttCLINICALINFO;
        protected ITTTextBox ttRADIOLOGICALINFO;
        protected ITTTextBox ttLABORATORYINFO;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelReport;
        protected ITTLabel labelOfferOfDecision;
        protected ITTLabel labelNumberOfProcess;
        protected ITTCheckBox IsHealthy;
        protected ITTLabel labelHeight;
        protected ITTLabel labelDisabledRatio;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("cc187c46-e8b1-42f3-8134-1246414998e7"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("7d712470-a62c-46d2-aefa-563b9577e005"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("586deb5e-81c0-4166-99c3-9fce24c05075"));
            labelWeight = (ITTLabel)AddControl(new Guid("bb355c2e-7833-4ee5-a3a5-687cda7b6fa0"));
            Weight = (ITTTextBox)AddControl(new Guid("ec8be165-1bf3-44ee-87e3-daf3a2c7471c"));
            OfferOfDecision = (ITTTextBox)AddControl(new Guid("be8d6811-a5ce-4ae5-a40a-e4d9c95200a8"));
            NumberOfProcess = (ITTTextBox)AddControl(new Guid("4ac1f4d7-074c-4212-9bfd-abdb329f873c"));
            Height = (ITTTextBox)AddControl(new Guid("43cadc8e-b7b7-4b7b-8329-ac9d005d6395"));
            DisabledRatio = (ITTTextBox)AddControl(new Guid("c95cfaf0-0ee3-4635-9978-60cd87cd0002"));
            ttTREATMENTINFO = (ITTTextBox)AddControl(new Guid("a48e4f85-4882-4be6-9916-aeb37d9cdbd4"));
            ttCLINICALINFO = (ITTTextBox)AddControl(new Guid("ce7d54cb-852e-4447-bf2c-7d8a91d87516"));
            ttRADIOLOGICALINFO = (ITTTextBox)AddControl(new Guid("d634ed53-ef04-4cc4-969c-61bf4030ce52"));
            ttLABORATORYINFO = (ITTTextBox)AddControl(new Guid("7e5a5ec0-d15f-4a25-ab31-6880dd64906c"));
            labelReportDate = (ITTLabel)AddControl(new Guid("ae1a9150-03b9-4999-a083-ecc82ee90077"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("c82e3c90-21a2-4dcf-8df1-06cb9edfd75a"));
            labelReport = (ITTLabel)AddControl(new Guid("91538e50-a4a2-4e1b-94fb-86f0365d9b7a"));
            labelOfferOfDecision = (ITTLabel)AddControl(new Guid("203b9e7c-e5f0-47b6-88e9-d41f040d5e50"));
            labelNumberOfProcess = (ITTLabel)AddControl(new Guid("b63ad36f-e227-49f6-b5fc-6365a66b246f"));
            IsHealthy = (ITTCheckBox)AddControl(new Guid("85c9c82c-34db-49c6-8543-260aa53f88ea"));
            labelHeight = (ITTLabel)AddControl(new Guid("4c488838-3a30-49db-8ad6-b9c3fa27d71a"));
            labelDisabledRatio = (ITTLabel)AddControl(new Guid("1e2f07fb-2bcd-4fdd-bf3e-b9eed5dffa12"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ce4e99cd-7579-4a6b-b182-11980992056c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e2238dbe-f3ad-4887-9473-67dd71e016db"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("aaaa786b-92bb-49d6-a3d3-4963f4d60b31"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("79b27ceb-f8b7-4536-b50f-64fc47b0fe62"));
            base.InitializeControls();
        }

        public HCExaminationComponentForm() : base("HCEXAMINATIONCOMPONENT", "HCExaminationComponentForm")
        {
        }

        protected HCExaminationComponentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}