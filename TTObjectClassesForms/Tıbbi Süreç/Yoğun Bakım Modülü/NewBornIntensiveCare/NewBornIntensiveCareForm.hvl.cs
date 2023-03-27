
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
    public partial class NewBornIntensiveCareForm : TTForm
    {
        protected TTObjectClasses.NewBornIntensiveCare _NewBornIntensiveCare
        {
            get { return (TTObjectClasses.NewBornIntensiveCare)_ttObject; }
        }

        protected ITTLabel labelBirthDatePerson;
        protected ITTDateTimePicker BirthDatePerson;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tabApgar;
        protected ITTTabPage tabBallard;
        protected ITTTabPage tabSnappe;
        protected ITTTabPage tabWeightChart;
        protected ITTTabPage tabBloodPressure;
        protected ITTTabPage tabPhototherapy;
        protected ITTTabPage tabClinical;
        protected ITTTabPage tabGeneralInfo;
        protected ITTTextBox Length;
        protected ITTTextBox IntensiveCareDay;
        protected ITTTextBox HeadCircumference;
        protected ITTTextBox GestationalWeek;
        protected ITTTextBox GestationalDay;
        protected ITTTextBox CorrectedAge;
        protected ITTTextBox ChronicalAge;
        protected ITTTextBox ChestCircumference;
        protected ITTTextBox BirthWeight;
        protected ITTLabel labelLength;
        protected ITTLabel labelIntensiveCareDay;
        protected ITTLabel labelHeadCircumference;
        protected ITTLabel labelGestationalWeek;
        protected ITTLabel labelGestationalDay;
        protected ITTLabel labelCorrectedAge;
        protected ITTLabel labelChronicalAge;
        protected ITTLabel labelChestCircumference;
        protected ITTLabel labelBirthWeight;
        protected ITTLabel labelBirthTime;
        protected ITTDateTimePicker BirthTime;
        override protected void InitializeControls()
        {
            labelBirthDatePerson = (ITTLabel)AddControl(new Guid("1442e8ae-2920-4076-8f5a-7a9961f5ef3f"));
            BirthDatePerson = (ITTDateTimePicker)AddControl(new Guid("e7a15aa7-cd91-4ce6-896c-2a7ea87d4eda"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ee2a57b4-02d1-41d2-bc5a-71024fcdceb5"));
            tabApgar = (ITTTabPage)AddControl(new Guid("d4819b40-4983-4053-b045-f768a0bbf7eb"));
            tabBallard = (ITTTabPage)AddControl(new Guid("759a5e68-e412-42da-a0a6-2676b671e320"));
            tabSnappe = (ITTTabPage)AddControl(new Guid("697dd7c7-8a2f-41e9-a3d0-9d35ab5cc2cd"));
            tabWeightChart = (ITTTabPage)AddControl(new Guid("2b0b671a-02c2-44bc-95c3-a5fee7a6683d"));
            tabBloodPressure = (ITTTabPage)AddControl(new Guid("e41ea3dd-cb85-48f8-ba21-cd3f4e63ff49"));
            tabPhototherapy = (ITTTabPage)AddControl(new Guid("8f5a4b13-d056-4814-8f78-f0b0c006882d"));
            tabClinical = (ITTTabPage)AddControl(new Guid("582be374-a578-4ceb-b790-eb312c7723c3"));
            tabGeneralInfo = (ITTTabPage)AddControl(new Guid("dfb4a934-300c-4881-8d28-6112e78a0085"));
            Length = (ITTTextBox)AddControl(new Guid("04800457-15d4-47a4-baeb-2568b5eb8f1e"));
            IntensiveCareDay = (ITTTextBox)AddControl(new Guid("7e020e61-f099-42f6-bbd3-7fd099c03226"));
            HeadCircumference = (ITTTextBox)AddControl(new Guid("b78523bd-9e93-4d79-b950-3c8884a2a751"));
            GestationalWeek = (ITTTextBox)AddControl(new Guid("e43959c0-4327-4053-b0cd-7bf22f91c245"));
            GestationalDay = (ITTTextBox)AddControl(new Guid("c2d25f3a-8713-4b39-8435-5121f56d2fc5"));
            CorrectedAge = (ITTTextBox)AddControl(new Guid("c888cacb-928a-42e8-80e6-f9748392a36f"));
            ChronicalAge = (ITTTextBox)AddControl(new Guid("cbaaa36f-2c49-4855-93b4-46f2b1ae17e7"));
            ChestCircumference = (ITTTextBox)AddControl(new Guid("17eadf86-da3c-48e8-b23a-a4a0cc9f47ab"));
            BirthWeight = (ITTTextBox)AddControl(new Guid("e82097f8-b5af-43f5-89da-26435c282089"));
            labelLength = (ITTLabel)AddControl(new Guid("80441250-9432-46f8-8057-34040e225ddb"));
            labelIntensiveCareDay = (ITTLabel)AddControl(new Guid("926c8165-501e-4a0a-8c94-a2f6c0e98072"));
            labelHeadCircumference = (ITTLabel)AddControl(new Guid("230319b5-c68f-41c8-ad94-bef8c283b71e"));
            labelGestationalWeek = (ITTLabel)AddControl(new Guid("3d2d0c4e-5800-4137-bd4b-9ff9de3595ff"));
            labelGestationalDay = (ITTLabel)AddControl(new Guid("d77dab0e-b796-4697-baf2-4a2eaa2c09b3"));
            labelCorrectedAge = (ITTLabel)AddControl(new Guid("60aa9666-50a1-4b8c-9bd6-02fc4f38250e"));
            labelChronicalAge = (ITTLabel)AddControl(new Guid("7dc95c4d-a864-4ea4-abda-f65541ec1e6c"));
            labelChestCircumference = (ITTLabel)AddControl(new Guid("aeddd557-0c38-46da-bb86-5198cf237a43"));
            labelBirthWeight = (ITTLabel)AddControl(new Guid("38c9a096-b471-4502-b7e5-90d7e2b81830"));
            labelBirthTime = (ITTLabel)AddControl(new Guid("6a4c2e26-e34a-4d53-a279-083f6ffac1b9"));
            BirthTime = (ITTDateTimePicker)AddControl(new Guid("c12c8ba5-f591-4461-a8a6-eeffd13464f0"));
            base.InitializeControls();
        }

        public NewBornIntensiveCareForm() : base("NEWBORNINTENSIVECARE", "NewBornIntensiveCareForm")
        {
        }

        protected NewBornIntensiveCareForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}