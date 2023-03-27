
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
    public partial class PathologyTestStatisticsForm : TTUnboundForm
    {
        protected ITTCheckBox ttPanicNotification;
        protected ITTButton cmdList;
        protected ITTGrid TestsGrid;
        protected ITTTextBoxColumn MatPrtNoString;
        protected ITTTextBoxColumn UniqueRefNo;
        protected ITTTextBoxColumn NameSurname;
        protected ITTDateTimePickerColumn BirthDate;
        protected ITTTextBoxColumn Sex;
        protected ITTTextBoxColumn Diagnose;
        protected ITTTextBoxColumn Microscopy;
        protected ITTTextBoxColumn Macroscopy;
        protected ITTTextBoxColumn AdditionalOperation;
        protected ITTTextBoxColumn ResponsibleDoctor;
        protected ITTTextBoxColumn Doctor;
        protected ITTDateTimePickerColumn ReportDate;
        protected ITTTextBoxColumn SnomedDiagnosys;
        protected ITTTextBoxColumn PanicNotification;
        protected ITTTextBoxColumn ConsultantDoctor;
        protected ITTTextBoxColumn CurrentStateDefID;
        protected ITTButtonColumn PrintReport;
        protected ITTTextBoxColumn ID;
        protected ITTTextBoxColumn PathologyTestObjectID;
        protected ITTTextBox txtMakroskopi;
        protected ITTTextBox txtMikroskopi;
        protected ITTTextBox txtPathologyNo;
        protected ITTTextBox txtDiagnose;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox txtResponsibleDoctor;
        protected ITTDateTimePicker txtAcceptionDateMin;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel1;
        protected ITTLabel txtListedProceduresCountlabel;
        protected ITTLabel labelPathologyCount;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker txtReportDateMin;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker txtAcceptionDateMax;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTDateTimePicker txtReportDateMax;
        protected ITTDateTimePicker txtPatientBirthDateMin;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker txtPatientBirthDateMax;
        protected ITTButton cmdExportToExcel;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox txtDoctor;
        protected ITTObjectListBox txtSnomedDiagnosis;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel16;
        protected ITTObjectListBox txtConsultantDoctor;
        protected ITTLabel ttlabel17;
        protected ITTCheckBox ttRejected;
        protected ITTCheckBox ttCancelled;
        override protected void InitializeControls()
        {
            ttPanicNotification = (ITTCheckBox)AddControl(new Guid("cf103bb2-a831-4cd6-af03-745efbec6246"));
            cmdList = (ITTButton)AddControl(new Guid("a0d8e77e-820b-43f5-9b20-95eb73d0f15a"));
            TestsGrid = (ITTGrid)AddControl(new Guid("d008fcfe-79b1-42e7-8304-20c1fd7a898a"));
            MatPrtNoString = (ITTTextBoxColumn)AddControl(new Guid("61dbd3b4-ac9e-48b1-9bf1-337f93ac54f8"));
            UniqueRefNo = (ITTTextBoxColumn)AddControl(new Guid("d12a4c90-2c7a-4b37-bce4-11e4ebcbac3f"));
            NameSurname = (ITTTextBoxColumn)AddControl(new Guid("333e0a42-1690-459d-8303-4ad38937d1a3"));
            BirthDate = (ITTDateTimePickerColumn)AddControl(new Guid("3918786f-5a9c-48bf-9feb-cbc466e65747"));
            Sex = (ITTTextBoxColumn)AddControl(new Guid("5c8cb854-a8e4-4ee3-b13e-3b68807c3ff2"));
            Diagnose = (ITTTextBoxColumn)AddControl(new Guid("cdcd012a-583d-499a-9801-49a0a01242e6"));
            Microscopy = (ITTTextBoxColumn)AddControl(new Guid("4481e581-e30f-4285-a99b-1d5c69142f41"));
            Macroscopy = (ITTTextBoxColumn)AddControl(new Guid("6fd6595b-b96d-4591-8e94-8b659c09b165"));
            AdditionalOperation = (ITTTextBoxColumn)AddControl(new Guid("59f9e2bf-4a28-45b6-ada4-bf3e1e281175"));
            ResponsibleDoctor = (ITTTextBoxColumn)AddControl(new Guid("57cc26b1-9697-47ca-bab7-b2602c71492e"));
            Doctor = (ITTTextBoxColumn)AddControl(new Guid("aadfa64a-e504-42e6-b0cd-444cc9a3a869"));
            ReportDate = (ITTDateTimePickerColumn)AddControl(new Guid("4a7606e7-8ed5-403c-8f14-2505c740fe85"));
            SnomedDiagnosys = (ITTTextBoxColumn)AddControl(new Guid("9779582a-9b6e-4092-8069-b11e5b59a916"));
            PanicNotification = (ITTTextBoxColumn)AddControl(new Guid("e35f78f8-de81-435c-bf2f-24022b5f7b89"));
            ConsultantDoctor = (ITTTextBoxColumn)AddControl(new Guid("6cfc11a3-f31d-49a9-9022-76162ccaa2bc"));
            CurrentStateDefID = (ITTTextBoxColumn)AddControl(new Guid("720904c6-d228-46cf-951d-02c6f5a82a8d"));
            PrintReport = (ITTButtonColumn)AddControl(new Guid("21b4743c-732c-40a3-adbd-66d82ae50c1b"));
            ID = (ITTTextBoxColumn)AddControl(new Guid("9473d9a7-e639-49fc-8706-ed94f407291b"));
            PathologyTestObjectID = (ITTTextBoxColumn)AddControl(new Guid("994147cb-318f-4150-92ff-15a11ffd3e6f"));
            txtMakroskopi = (ITTTextBox)AddControl(new Guid("9cf3ca9e-1156-4036-8d14-72a3c930adf8"));
            txtMikroskopi = (ITTTextBox)AddControl(new Guid("7361f7f3-d37a-4427-b900-b182a40ddaca"));
            txtPathologyNo = (ITTTextBox)AddControl(new Guid("43a4decf-32c6-42fa-a290-55d99433a808"));
            txtDiagnose = (ITTTextBox)AddControl(new Guid("20ec45ff-1323-4c21-9f3c-218cd8dd9682"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("d13dbe80-f9a0-433a-8789-2226ee70e26c"));
            txtResponsibleDoctor = (ITTObjectListBox)AddControl(new Guid("a76f6a9d-5510-46b7-a62b-faf672056f7d"));
            txtAcceptionDateMin = (ITTDateTimePicker)AddControl(new Guid("cfa9b04d-c783-418d-a635-705004e24e92"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("946da045-5fc6-49e9-9f9f-ccf621916397"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("709d044e-a471-40fa-89c1-5aae06eceba3"));
            txtListedProceduresCountlabel = (ITTLabel)AddControl(new Guid("e77fae6f-827e-4f12-a567-9f8f5465f727"));
            labelPathologyCount = (ITTLabel)AddControl(new Guid("47f909e9-b182-463f-b316-9d5d8557b586"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c7f8b90d-ddbd-463e-86a6-f10e2d6622e5"));
            txtReportDateMin = (ITTDateTimePicker)AddControl(new Guid("73115da7-6a40-4b8e-a02d-a6f26b0118e2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("41a8a0e8-182c-4d68-9491-8104bb625e7b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("497c54d2-9c42-47a8-864f-7d8cdb503ab5"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("b3434b10-320e-4617-b5ae-c205468c4d39"));
            txtAcceptionDateMax = (ITTDateTimePicker)AddControl(new Guid("ffcbc972-2c04-433e-a637-f5dc07d8839b"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("787d963a-edcf-4898-88f6-97eac6d1244c"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("a4e6eb07-d978-4510-96fb-8eb0ddcf1f1f"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("4e9c33a1-80e5-409c-b144-27b9f0269425"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("d36d5683-ba36-4f11-9b28-f3383e75e33d"));
            txtReportDateMax = (ITTDateTimePicker)AddControl(new Guid("799cfe4b-03b9-4a22-a4a9-9a3653f48926"));
            txtPatientBirthDateMin = (ITTDateTimePicker)AddControl(new Guid("b2181765-3342-4e87-bb9c-2adf7b6eaf2d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("f8657c6d-22a2-410c-8e0a-f22916df7918"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("c9e9c9d5-901e-4768-9abe-46b4f7fdceca"));
            txtPatientBirthDateMax = (ITTDateTimePicker)AddControl(new Guid("7875bdd8-7540-49b8-b062-a6a374961b85"));
            cmdExportToExcel = (ITTButton)AddControl(new Guid("94fbb7d5-ce95-4531-b94b-485cc63f384a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("f15b3bbd-f28c-419d-9438-aa5632f77dc9"));
            txtDoctor = (ITTObjectListBox)AddControl(new Guid("2c5ce958-a297-4acd-b33c-b9a1cb1aeb7d"));
            txtSnomedDiagnosis = (ITTObjectListBox)AddControl(new Guid("d368115b-f83e-4a5b-b6d0-7f28d42eafe1"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("119a84e3-84ee-4153-b2ca-4a048c94c2b9"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("0d6f533d-b3b8-4f3b-91b8-09d02d82bc72"));
            txtConsultantDoctor = (ITTObjectListBox)AddControl(new Guid("c15f4490-a9a7-44a8-b064-a1b3b6ead573"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("b755ec6c-3dcb-4639-97de-611259abace5"));
            ttRejected = (ITTCheckBox)AddControl(new Guid("09aff9cb-14eb-45ce-ab08-8165f668ec64"));
            ttCancelled = (ITTCheckBox)AddControl(new Guid("e4cb23ef-c77f-4528-a04d-97790407ccec"));
            base.InitializeControls();
        }

        public PathologyTestStatisticsForm() : base("PathologyTestStatisticsForm")
        {
        }

        protected PathologyTestStatisticsForm(string formDefName) : base(formDefName)
        {
        }
    }
}