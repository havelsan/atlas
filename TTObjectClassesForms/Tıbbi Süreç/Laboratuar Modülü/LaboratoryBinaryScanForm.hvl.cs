
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
    /// İKİLİ TARAMA
    /// </summary>
    public partial class LaboratoryBinaryScanForm : TTUnboundForm
    {
        protected ITTButton ttSave;
        protected ITTLabel ttlabel15;
        protected ITTGroupBox ttgroupbox4;
        protected ITTCheckBox ttTwinPregnancy;
        protected ITTCheckBox ttIVF;
        protected ITTCheckBox ttInsulinDependentDiabetes;
        protected ITTCheckBox ttSmoking;
        protected ITTLabel ttlabel14;
        protected ITTTextBox ttMaternalWeight;
        protected ITTLabel ttlabel13;
        protected ITTGroupBox ttgroupbox3;
        protected ITTCheckBox ttNasalBone;
        protected ITTCheckBox ttAbnormalitiesOnUltrasound;
        protected ITTLabel ttlabel12;
        protected ITTTextBox ttNuchalTranslucency;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel10;
        protected ITTTextBox ttCrlMeasurement;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ttUltrasoundDate;
        protected ITTLabel ttlabel8;
        protected ITTGroupBox ttgroupbox2;
        protected ITTDateTimePicker ttLastMenstrualDate;
        protected ITTLabel ttlabel7;
        protected ITTDateTimePicker ttSerumReceiptDate;
        protected ITTLabel ttlabel6;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox ttPhoneNumber;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker ttPatientBirthDate;
        protected ITTLabel ttlabel4;
        protected ITTTextBox ttPatientSurname;
        protected ITTLabel ttlabel3;
        protected ITTTextBox ttPatientName;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttSave = (ITTButton)AddControl(new Guid("d87b76e1-3b7b-410d-84f6-0571b8e7ac88"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("4d58f08a-cb9b-4220-a441-f0e0f1126a0b"));
            ttgroupbox4 = (ITTGroupBox)AddControl(new Guid("821c6aa6-dc20-4a1d-a420-b0236b9d7238"));
            ttTwinPregnancy = (ITTCheckBox)AddControl(new Guid("b057d27d-125c-483e-b65a-05710dac9743"));
            ttIVF = (ITTCheckBox)AddControl(new Guid("44fa4527-f232-4721-984b-83ced054c156"));
            ttInsulinDependentDiabetes = (ITTCheckBox)AddControl(new Guid("899c04b5-0643-4693-9126-08605ef6aacc"));
            ttSmoking = (ITTCheckBox)AddControl(new Guid("a7432e7e-20e5-4ee8-9eb5-67b3887636bf"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("c6329e55-6527-4917-921b-ce27bcd08633"));
            ttMaternalWeight = (ITTTextBox)AddControl(new Guid("eb950320-b4f5-4775-a06d-d648b34f5c9a"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("b95c79cd-e771-480e-a86c-d1943f1d1082"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("da4e9fd9-e5b7-458a-8563-8f843d2c8452"));
            ttNasalBone = (ITTCheckBox)AddControl(new Guid("c7945224-3cce-42e1-89c8-d6d24f354736"));
            ttAbnormalitiesOnUltrasound = (ITTCheckBox)AddControl(new Guid("fc5baccb-fc20-4f8a-93d9-925e85f56799"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("e483bc38-913a-4924-a071-eb19665f091a"));
            ttNuchalTranslucency = (ITTTextBox)AddControl(new Guid("8fe1ecaf-43f0-4a64-9825-b26d1e306113"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("b925a468-fffb-4109-ad0e-3d671741de94"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("e631a94f-e82e-4558-829b-1265ef9ae71a"));
            ttCrlMeasurement = (ITTTextBox)AddControl(new Guid("c8f0ba75-7b52-4b79-90cf-f98e191f14e3"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("eb51b66b-17b6-4294-abc8-469f426ae4be"));
            ttUltrasoundDate = (ITTDateTimePicker)AddControl(new Guid("4a18abdb-d9a2-440e-8d93-865125968dd1"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("698f8ded-eeca-4c02-8303-c7558c1a1b14"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("924e6553-93a7-4a6e-ba7a-3bc9e66ae404"));
            ttLastMenstrualDate = (ITTDateTimePicker)AddControl(new Guid("f521927d-042d-445a-86bd-2c0707273731"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("ddb9569e-016b-4b8b-91de-4c07de8c6729"));
            ttSerumReceiptDate = (ITTDateTimePicker)AddControl(new Guid("5dd13206-f41c-473b-ae0a-b8aa8574e074"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("ba179883-7a09-47b0-85c0-7257e34acf0f"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("ea79fa95-4bf9-4d30-a87b-80bfffd160df"));
            ttPhoneNumber = (ITTTextBox)AddControl(new Guid("bc80f646-1374-45e4-842a-ff1d39e35ab6"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("3e0503ee-df98-415e-a404-4ab7b722572b"));
            ttPatientBirthDate = (ITTDateTimePicker)AddControl(new Guid("c35c3509-fb26-4932-9e9b-9a33d830d628"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5a087b7d-aeee-4fdf-855a-5432305d5365"));
            ttPatientSurname = (ITTTextBox)AddControl(new Guid("775f88a5-2fef-461e-9542-2bfcaf5d301d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("84109590-efa7-4481-9b12-cb99983346fb"));
            ttPatientName = (ITTTextBox)AddControl(new Guid("f3764044-8923-49b1-866a-2028d7654bda"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("70a68f69-32b2-4900-a1e3-b1e13f3e4aac"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("ed11a8ad-3793-400f-8977-9d59e89146bd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("285162cd-f080-48c3-971d-d75b4f10b52e"));
            base.InitializeControls();
        }

        public LaboratoryBinaryScanForm() : base("LaboratoryBinaryScanForm")
        {
        }

        protected LaboratoryBinaryScanForm(string formDefName) : base(formDefName)
        {
        }
    }
}