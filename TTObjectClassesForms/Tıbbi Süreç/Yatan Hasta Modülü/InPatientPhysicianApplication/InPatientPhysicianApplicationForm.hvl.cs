
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
    public partial class InPatientPhysicianApplicationForm : BaseNewDoctorExaminationForm
    {
        protected TTObjectClasses.InPatientPhysicianApplication _InPatientPhysicianApplication
        {
            get { return (TTObjectClasses.InPatientPhysicianApplication)_ttObject; }
        }

        protected ITTLabel labelIsPandemic;
        protected ITTEnumComboBox IsPandemic;
        protected ITTDateTimePicker InpatientObservationEndTime;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker InpatientObservationTime;
        protected ITTGrid DietOrders;
        protected ITTListBoxColumn ProcedureObjectDietOrder;
        protected ITTDateTimePickerColumn PeriodStartTimeDietOrder;
        protected ITTTextBoxColumn RecurrenceDayAmountDietOrder;
        protected ITTDateTimePickerColumn PeriodEndTimeDietOrder;
        protected ITTTextBoxColumn OrderDescriptionDietOrder;
        protected ITTTextBoxColumn AmountForPeriodDietOrder;
        protected ITTEnumComboBoxColumn FrequencyDietOrder;
        protected ITTCheckBoxColumn Breakfast;
        protected ITTCheckBoxColumn Dinner;
        protected ITTCheckBoxColumn Lunch;
        protected ITTCheckBoxColumn NightBreakfast;
        protected ITTCheckBoxColumn Snack1;
        protected ITTCheckBoxColumn Snack2;
        protected ITTCheckBoxColumn Snack3;
        protected ITTGrid InPatientRtfBySpecialities;
        protected ITTTextBoxColumn TitleInPatientRtfBySpeciality;
        protected ITTTextBoxColumn RtfInPatientRtfBySpeciality;
        protected ITTTextBox InpatientProtocolNo;
        protected ITTTextBox ReasonForInpatientAdmission;
        protected ITTGrid GrdConsultation;
        protected ITTListBoxColumn RequestedResource;
        protected ITTListBoxColumn RequestedDoctor;
        protected ITTRichTextBoxControlColumn RequestDescription;
        protected ITTCheckBoxColumn chkEmergency;
        protected ITTCheckBoxColumn chkInPatientBed;
        protected ITTGrid GridDiagnosis;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTTextBoxColumn SecFreeDiagnosis;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelInpatientDepartment;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox Bed;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelRoomGroup;
        protected ITTObjectListBox Room;
        protected ITTLabel labelBed;
        protected ITTDateTimePicker ClinicDischargeDate;
        protected ITTLabel labelClinicDischargeDate;
        protected ITTLabel labelProtocolNo;
        protected ITTRichTextBoxControl rtfComplaint;
        protected ITTRichTextBoxControl rtfHistory;
        protected ITTRichTextBoxControl rtfPhysicalExamination;
        protected ITTLabel labelReasonForInpatientAdmission;
        protected ITTGrid NursingOrderGrid;
        protected ITTButtonColumn RPT;
        protected ITTListBoxColumn nProcedureObject;
        protected ITTDateTimePickerColumn nPeriodStartTime;
        protected ITTEnumComboBoxColumn nFrequency;
        protected ITTTextBoxColumn nAmountForPeriod;
        protected ITTTextBoxColumn nRecurrenceDayAmount;
        protected ITTTextBoxColumn nOrderDescription;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn TreatmentMaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn DistributionType;
        protected ITTListBoxColumn OzelDurum;
        protected ITTTextBoxColumn Notes;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTextBoxColumn KodsuzMalzemeFiyatı;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn SatinAlisTarihi;
        protected ITTObjectListBox ResponsibleNurse;
        protected ITTLabel labelResponsibleNurse;
        protected ITTLabel lableResponsibleDoctor;
        protected ITTObjectListBox ResponsibleDoctor;
        protected ITTLabel labelVentilatorStatus;
        protected ITTObjectListBox VentilatorStatus;
        override protected void InitializeControls()
        {
            labelIsPandemic = (ITTLabel)AddControl(new Guid("9aef435f-01df-4c5a-8ef7-a101a356e856"));
            IsPandemic = (ITTEnumComboBox)AddControl(new Guid("f62067eb-08db-4f31-99b8-8013d9784204"));
            InpatientObservationEndTime = (ITTDateTimePicker)AddControl(new Guid("437aa6fe-78ba-4f89-92fc-b8ab0d79d92a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b36bb97d-5b14-4633-a983-cb1c6ada490d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("028d74ee-a544-477f-b297-af3bce4a1821"));
            InpatientObservationTime = (ITTDateTimePicker)AddControl(new Guid("993a5f2c-9be4-46f7-8adc-d0ca1711c566"));
            DietOrders = (ITTGrid)AddControl(new Guid("8a29fec3-5f8d-4fa4-9191-a927c38c7155"));
            ProcedureObjectDietOrder = (ITTListBoxColumn)AddControl(new Guid("547efde6-1fb2-408a-8d87-0aa41f62fc24"));
            PeriodStartTimeDietOrder = (ITTDateTimePickerColumn)AddControl(new Guid("32e0d895-2bd2-44e4-911b-e83684900c58"));
            RecurrenceDayAmountDietOrder = (ITTTextBoxColumn)AddControl(new Guid("0ca7af15-c64a-40d5-b1b3-691048abfe07"));
            PeriodEndTimeDietOrder = (ITTDateTimePickerColumn)AddControl(new Guid("3e154ea0-c26d-42a6-b103-361bfc064d95"));
            OrderDescriptionDietOrder = (ITTTextBoxColumn)AddControl(new Guid("a5569e94-57a1-457f-ba2b-f065bedd3732"));
            AmountForPeriodDietOrder = (ITTTextBoxColumn)AddControl(new Guid("5c8f6cc2-a0f3-4a83-afe7-0d44b57ff3b6"));
            FrequencyDietOrder = (ITTEnumComboBoxColumn)AddControl(new Guid("e2e87039-0d7e-4261-b8bb-e8a486d83657"));
            Breakfast = (ITTCheckBoxColumn)AddControl(new Guid("729909b4-8618-47ea-8cc4-f1658ba56f01"));
            Dinner = (ITTCheckBoxColumn)AddControl(new Guid("1d58c9ea-0d93-4541-9928-542fdfa5506f"));
            Lunch = (ITTCheckBoxColumn)AddControl(new Guid("87620a69-e2df-437f-a8dd-2e530d7a8013"));
            NightBreakfast = (ITTCheckBoxColumn)AddControl(new Guid("a63ec469-5c86-42e5-b2e6-d4877d010166"));
            Snack1 = (ITTCheckBoxColumn)AddControl(new Guid("645393bb-6bee-43f4-a45a-9533da76ddf8"));
            Snack2 = (ITTCheckBoxColumn)AddControl(new Guid("861c50d5-e1ab-4236-98c6-13dfbab1aa3a"));
            Snack3 = (ITTCheckBoxColumn)AddControl(new Guid("dba93432-b396-467d-bc27-540c8dfa5941"));
            InPatientRtfBySpecialities = (ITTGrid)AddControl(new Guid("e909d346-5c93-498b-ae1b-77857bd94432"));
            TitleInPatientRtfBySpeciality = (ITTTextBoxColumn)AddControl(new Guid("cbe92ad2-6c5d-4146-8f99-ca76b6cec643"));
            RtfInPatientRtfBySpeciality = (ITTTextBoxColumn)AddControl(new Guid("ca59584b-15b7-4a17-beed-66cfca4da92b"));
            InpatientProtocolNo = (ITTTextBox)AddControl(new Guid("4d70ba28-dac5-4778-97fc-7ec4da219628"));
            ReasonForInpatientAdmission = (ITTTextBox)AddControl(new Guid("2b8a95f7-fd12-4740-99fe-ba25050e942b"));
            GrdConsultation = (ITTGrid)AddControl(new Guid("ec1b879f-efdd-481e-b5b1-deabd99510a1"));
            RequestedResource = (ITTListBoxColumn)AddControl(new Guid("1c1ebcf4-f67c-4c91-820f-e7d7700c2adc"));
            RequestedDoctor = (ITTListBoxColumn)AddControl(new Guid("b6a51d24-ad59-4e53-9302-88eeb44a3409"));
            RequestDescription = (ITTRichTextBoxControlColumn)AddControl(new Guid("c86a783d-7d1b-4490-8d06-90010301d779"));
            chkEmergency = (ITTCheckBoxColumn)AddControl(new Guid("cc232483-52c0-497e-a1a0-76ed40a026c9"));
            chkInPatientBed = (ITTCheckBoxColumn)AddControl(new Guid("f667e852-c923-4a21-829e-4c56d4a4a52b"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("d6210a93-2ec9-4e3f-86f2-9cd1091ce420"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("4c11f2fb-dc86-4c7e-913b-893919e92474"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("32e5a795-7925-44d6-8075-88184b3ba825"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("98124fdd-929c-4d66-80a0-b7adef5a75ac"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("447de669-2f6c-40c3-b0a5-02fcc55987b5"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("ac910494-a2ce-47d7-91d5-3fd03b4d1a93"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("a4f4e227-ed77-49fe-9e0d-5452735f02ef"));
            labelInpatientDepartment = (ITTLabel)AddControl(new Guid("b52c5605-7c92-4de5-a0dc-5626fb412e22"));
            labelRoom = (ITTLabel)AddControl(new Guid("a2e83458-6682-494f-bb7f-e18d25b09ea1"));
            Bed = (ITTObjectListBox)AddControl(new Guid("bf0f91d2-ad5a-4215-a6a4-6ec9a273b601"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("f213b633-9e60-49c3-82b9-93a04bd6fa00"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("361c2fb8-87c1-4059-8544-92162b0e6130"));
            Room = (ITTObjectListBox)AddControl(new Guid("dd62852d-24de-4523-ad7b-e0e529ee460d"));
            labelBed = (ITTLabel)AddControl(new Guid("57a695be-2e04-48b4-9769-b7d2344293f0"));
            ClinicDischargeDate = (ITTDateTimePicker)AddControl(new Guid("9f52c1d1-ec7d-4580-826a-04fa88ad0a12"));
            labelClinicDischargeDate = (ITTLabel)AddControl(new Guid("0c790ba4-970e-404b-a3ff-f24f09352aef"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("cd8cdf1e-286b-4667-b30b-ff8ae7984985"));
            rtfComplaint = (ITTRichTextBoxControl)AddControl(new Guid("26ad2d68-d35f-4887-a721-ba6d90330317"));
            rtfHistory = (ITTRichTextBoxControl)AddControl(new Guid("fb642e8b-f4ea-4ea4-88b6-9e5c645eaf17"));
            rtfPhysicalExamination = (ITTRichTextBoxControl)AddControl(new Guid("7da1ab6f-c076-4fc6-be91-4ecaddab00f8"));
            labelReasonForInpatientAdmission = (ITTLabel)AddControl(new Guid("4e74c521-259a-427b-aa71-b1e66fa9167a"));
            NursingOrderGrid = (ITTGrid)AddControl(new Guid("c6e08c7b-6e8f-452c-96a5-ddb110941830"));
            RPT = (ITTButtonColumn)AddControl(new Guid("b8ca54b0-a360-458a-a40a-75b33f2b27a9"));
            nProcedureObject = (ITTListBoxColumn)AddControl(new Guid("5a279a08-2d39-4ac4-be59-9c4dc1c772f9"));
            nPeriodStartTime = (ITTDateTimePickerColumn)AddControl(new Guid("672a4dff-740b-4492-bf0d-04c289515920"));
            nFrequency = (ITTEnumComboBoxColumn)AddControl(new Guid("16c64c9c-d948-4ae3-bc54-5b8d648213eb"));
            nAmountForPeriod = (ITTTextBoxColumn)AddControl(new Guid("c4f5484c-4844-4fbf-a69c-dbd44cdf576a"));
            nRecurrenceDayAmount = (ITTTextBoxColumn)AddControl(new Guid("cd2ff1f4-8e29-474d-a52f-b839fd9d178b"));
            nOrderDescription = (ITTTextBoxColumn)AddControl(new Guid("81eec3ef-a1d2-4e85-8fe0-7232146f8dff"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("9935d920-fb77-4d19-b937-faf5d21a8bfb"));
            TreatmentMaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("460ee8ea-75cb-44bc-a9cc-baf082087ba7"));
            Material = (ITTListBoxColumn)AddControl(new Guid("44501c78-0ff7-4c12-aef6-bd162b2959a1"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("e292ed7b-0b16-4c42-9beb-97eb38b4b3e1"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("e104a1a8-0925-49da-b53f-b152fcafb201"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("e844eca7-ca46-47e8-8725-60809bc48111"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("66550817-5b6a-4f9e-aefa-c6f82ff5205e"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("791a6858-2060-4662-98e2-2ae5ff5d7be4"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("10821a2d-c855-455f-baa3-b9f883573346"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("68eac0f4-d5da-477b-9a63-355e35746aff"));
            KodsuzMalzemeFiyatı = (ITTTextBoxColumn)AddControl(new Guid("2837acbd-db21-4607-b9ba-ffb9aa7baf18"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("d07d1ecf-b4bb-4bc0-bc9d-9edac3f441d4"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("ef041990-5aba-43fc-84c6-9dd10b6c34f9"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("8df0f175-a2e8-4a04-b913-45e85253f868"));
            SatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("da94aee4-826e-4469-8857-9b6175e6298b"));
            ResponsibleNurse = (ITTObjectListBox)AddControl(new Guid("1542a586-349e-4770-a510-e1d688987de8"));
            labelResponsibleNurse = (ITTLabel)AddControl(new Guid("0a148db3-ab7e-4b52-894f-c8f597ce0459"));
            lableResponsibleDoctor = (ITTLabel)AddControl(new Guid("485cd06e-4845-40f2-aca5-eb4a5f650a43"));
            ResponsibleDoctor = (ITTObjectListBox)AddControl(new Guid("13d462ff-1023-4bce-9f8e-669baafa133b"));
            labelVentilatorStatus = (ITTLabel)AddControl(new Guid("494c5629-2a97-41d5-becf-9ee66c683610"));
            VentilatorStatus = (ITTObjectListBox)AddControl(new Guid("60cdfa9c-f789-4f08-80b3-8495977e3737"));
            base.InitializeControls();
        }

        public InPatientPhysicianApplicationForm() : base("INPATIENTPHYSICIANAPPLICATION", "InPatientPhysicianApplicationForm")
        {
        }

        protected InPatientPhysicianApplicationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}