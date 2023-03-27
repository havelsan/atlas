
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
    public partial class DailyActivityTestsForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Günlük Yaşam Aktiviteleri Testi
    /// </summary>
        protected TTObjectClasses.DailyActivityTestsForm _DailyActivityTestsForm
        {
            get { return (TTObjectClasses.DailyActivityTestsForm)_ttObject; }
        }

        protected ITTLabel labelKatzIndex;
        protected ITTTextBox KatzIndex;
        protected ITTTextBox BASFI;
        protected ITTTextBox HealthAssessmentQuostionnarie;
        protected ITTTextBox FonctionalIndependenceMeasure;
        protected ITTTextBox BarthelTest;
        protected ITTTextBox Code;
        protected ITTLabel labelBASFI;
        protected ITTLabel labelHealthAssessmentQuostionnarie;
        protected ITTLabel labelFonctionalIndependenceMeasure;
        protected ITTLabel labelBarthelTest;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelKatzIndex = (ITTLabel)AddControl(new Guid("9b32e02a-56f3-4310-9717-07d7e1af2868"));
            KatzIndex = (ITTTextBox)AddControl(new Guid("e67c4ae1-891d-4fe2-983d-d4f0415a7146"));
            BASFI = (ITTTextBox)AddControl(new Guid("dcc5d9ec-5d9a-47dc-a12b-08d85a0a4220"));
            HealthAssessmentQuostionnarie = (ITTTextBox)AddControl(new Guid("81975825-6028-40fa-b89b-8c5c092e962c"));
            FonctionalIndependenceMeasure = (ITTTextBox)AddControl(new Guid("883e6700-84ee-4b3a-ab9c-d0df1af11eb7"));
            BarthelTest = (ITTTextBox)AddControl(new Guid("040c3883-a12d-4805-9121-87a6a1c410b6"));
            Code = (ITTTextBox)AddControl(new Guid("64b2997e-6374-436c-9fc8-40aa95f95fab"));
            labelBASFI = (ITTLabel)AddControl(new Guid("917fff84-e9b8-4720-a015-2e3718992072"));
            labelHealthAssessmentQuostionnarie = (ITTLabel)AddControl(new Guid("200c2e54-2d90-4497-a997-47235ca331ae"));
            labelFonctionalIndependenceMeasure = (ITTLabel)AddControl(new Guid("573feac4-2953-4791-a6c4-dce7ee99600f"));
            labelBarthelTest = (ITTLabel)AddControl(new Guid("c5053d3e-a6ae-437e-b0f0-4db526f1f649"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("1223ad7a-eb5f-40d2-97a6-76def6a7a759"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("c2b2210f-e4e0-45f8-9d98-9f9240a4894c"));
            labelCode = (ITTLabel)AddControl(new Guid("5c8c1193-16f0-4504-9d18-9c3ba12379f2"));
            base.InitializeControls();
        }

        public DailyActivityTestsForm() : base("DAILYACTIVITYTESTSFORM", "DailyActivityTestsForm")
        {
        }

        protected DailyActivityTestsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}