
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
    public partial class PatientOnVacationForm : TTForm
    {
    /// <summary>
    /// İzinli Hasta Çıkış Bilgileri
    /// </summary>
        protected TTObjectClasses.PatientOnVacation _PatientOnVacation
        {
            get { return (TTObjectClasses.PatientOnVacation)_ttObject; }
        }

        protected ITTLabel labelApproveDoctor;
        protected ITTObjectListBox ApproveDoctor;
        protected ITTLabel labelRelativesPhoneNumber;
        protected ITTTextBox RelativesPhoneNumber;
        protected ITTTextBox RelativesName;
        protected ITTTextBox VacationAdress;
        protected ITTTextBox DayCount;
        protected ITTLabel labelRelativesName;
        protected ITTLabel labelVacationAdress;
        protected ITTLabel labelDayCount;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        override protected void InitializeControls()
        {
            labelApproveDoctor = (ITTLabel)AddControl(new Guid("bde63a4d-e1e6-46be-bda6-935846b4b414"));
            ApproveDoctor = (ITTObjectListBox)AddControl(new Guid("8148f140-b48a-44f5-a033-c35cb2aa003f"));
            labelRelativesPhoneNumber = (ITTLabel)AddControl(new Guid("e2cba29c-ca63-4908-98a3-5ba6105f7f54"));
            RelativesPhoneNumber = (ITTTextBox)AddControl(new Guid("140f4bd8-6795-4c28-b977-1972d14ac67c"));
            RelativesName = (ITTTextBox)AddControl(new Guid("48c29cd2-6766-41ae-990b-2cb5f99ebfb5"));
            VacationAdress = (ITTTextBox)AddControl(new Guid("d3eb326f-8174-4a95-9711-659be3851f24"));
            DayCount = (ITTTextBox)AddControl(new Guid("0807db6b-b54d-49f8-b96c-f6198420d314"));
            labelRelativesName = (ITTLabel)AddControl(new Guid("debb7fd9-9013-4199-991a-318b7617d0f0"));
            labelVacationAdress = (ITTLabel)AddControl(new Guid("d78ae175-3ab8-4553-8341-c44c3bd954bd"));
            labelDayCount = (ITTLabel)AddControl(new Guid("056fb8e9-ff0d-4f24-93d7-986b6b7b7222"));
            labelEndDate = (ITTLabel)AddControl(new Guid("368c11e9-e815-4efb-872d-b79d7c3616c6"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("71990b6d-09d4-49a3-a643-fcca644272b4"));
            labelStartDate = (ITTLabel)AddControl(new Guid("7372c9e2-79c6-4f61-8fbf-df1f35622ba0"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("e07f7532-0cc3-44ed-8a9c-d85cac81e30a"));
            base.InitializeControls();
        }

        public PatientOnVacationForm() : base("PATIENTONVACATION", "PatientOnVacationForm")
        {
        }

        protected PatientOnVacationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}