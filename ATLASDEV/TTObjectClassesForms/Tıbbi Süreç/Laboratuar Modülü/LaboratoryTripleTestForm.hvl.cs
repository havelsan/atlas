
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
    /// <summary>
    /// Triple Test İstek Formu
    /// </summary>
    public partial class LaboratoryTripleTestForm : TTUnboundForm
    {
        protected ITTButton ttSave;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel ttlabel14;
        protected ITTTextBox ttGestationalAge;
        protected ITTTextBox ttBiparietalDiameter;
        protected ITTLabel ttlabel13;
        protected ITTDateTimePicker ttUltrasoundDate;
        protected ITTLabel ttlabel12;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox ttCycleLength;
        protected ITTLabel ttlabel11;
        protected ITTDateTimePicker ttLastMenstrualDate;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTTextBox ttSmokingNumberPerADay;
        protected ITTLabel ttlabel8;
        protected ITTCheckBox ttSmoking;
        protected ITTCheckBox ttIsHaveDiabetes;
        protected ITTTextBox ttPatientWeight;
        protected ITTLabel ttlabel7;
        protected ITTTextBox ttPatientPhoneNumber;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker ttPatientBirthDate;
        protected ITTLabel ttlabel5;
        protected ITTTextBox ttPatientBirthPlace;
        protected ITTLabel ttlabel4;
        protected ITTTextBox ttPatientSurname;
        protected ITTTextBox ttPatientName;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttSave = (ITTButton)AddControl(new Guid("7a967990-d07b-4967-b18e-f63571fdba1c"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("5175c0b8-78fc-439d-ae62-57bd2d9aa5f8"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("38fb7748-1f8f-45af-8405-0e1aa02a472b"));
            ttGestationalAge = (ITTTextBox)AddControl(new Guid("63a9b8ba-81da-4fb3-b928-4dc0e9e0f6d9"));
            ttBiparietalDiameter = (ITTTextBox)AddControl(new Guid("f5a62180-15fc-4230-9315-85ce19e93a54"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("4144c877-29ea-41e2-83d4-37c16a339dc3"));
            ttUltrasoundDate = (ITTDateTimePicker)AddControl(new Guid("cb507d77-0788-4942-8f81-72ae93732864"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("d0f057fc-0262-4f80-8829-dacf9006f76a"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("028fb761-bf1a-4a08-a18d-2bb579725b27"));
            ttCycleLength = (ITTTextBox)AddControl(new Guid("2b5a2d9d-6a06-4f2d-a189-1f5951f8cd3b"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("a8a521c6-05ba-41aa-9a12-b7cb01eafc4d"));
            ttLastMenstrualDate = (ITTDateTimePicker)AddControl(new Guid("39b1855b-3ef5-4b4b-9bec-cce3f33b2ca4"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("a8ce8cbc-7c4a-4319-9712-763103877b08"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("02825803-397d-4051-9e9a-6420d2b276de"));
            ttSmokingNumberPerADay = (ITTTextBox)AddControl(new Guid("8f9d4577-704b-47dd-92ed-5281d68c79dc"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("18112287-4b69-41f9-b554-c7efe9c4376c"));
            ttSmoking = (ITTCheckBox)AddControl(new Guid("11452652-05bf-41b0-96f8-3811e8b75aa1"));
            ttIsHaveDiabetes = (ITTCheckBox)AddControl(new Guid("aaa16373-dff9-4f38-8cdd-453eadd8676a"));
            ttPatientWeight = (ITTTextBox)AddControl(new Guid("00e57d59-7e58-4f03-afbf-748cb144a877"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("e42d5f7c-4d93-488c-a0b8-877949a1842e"));
            ttPatientPhoneNumber = (ITTTextBox)AddControl(new Guid("cb9c6f4c-5f43-4980-a67f-a6ea5f10c011"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9b148080-b0f7-4ba5-b984-7ae25365c1cb"));
            ttPatientBirthDate = (ITTDateTimePicker)AddControl(new Guid("15ca6bb8-8190-4154-a014-a96202c9b058"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6df5611d-f522-4652-91e7-bcf2e772a67f"));
            ttPatientBirthPlace = (ITTTextBox)AddControl(new Guid("0a386c41-3ab9-4e21-915b-fbbdd351eebb"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("962cedf8-ce87-4c05-b3ee-84540b0b7a5d"));
            ttPatientSurname = (ITTTextBox)AddControl(new Guid("ffb15781-a367-42dd-829b-23ab70cf49a4"));
            ttPatientName = (ITTTextBox)AddControl(new Guid("934e1916-304e-44d9-a819-a453eed51e3f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("886e0a0d-ba30-4a31-85f4-497d8750ebd5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d76a8094-9a28-47a5-97e0-676b6615fd6f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f744cc8f-8874-4f6e-997b-92cdf59fa4eb"));
            base.InitializeControls();
        }

        public LaboratoryTripleTestForm() : base("LaboratoryTripleTestForm")
        {
        }

        protected LaboratoryTripleTestForm(string formDefName) : base(formDefName)
        {
        }
    }
}