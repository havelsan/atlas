
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
    /// Morg İşlemleri
    /// </summary>
    public partial class MorgueCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Morg İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Morgue _Morgue
        {
            get { return (TTObjectClasses.Morgue)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageMorgue;
        protected ITTTextBox externalDoctFixed;
        protected ITTEnumComboBox DeathPlace;
        protected ITTObjectListBox deliveredByLst;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTEnumComboBox PatientSex;
        protected ITTLabel ttlabel14;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker BithDate;
        protected ITTObjectListBox BirthPalce;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTTextBox PatientName;
        protected ITTLabel labelProtocolNo;
        protected ITTTextBox GraveyardPlotNo;
        protected ITTLabel ttlabel17;
        protected ITTLabel ttlabel13;
        protected ITTDateTimePicker DateOfSentToGrave;
        protected ITTLabel labelDoctorFixed;
        protected ITTLabel ttlabel12;
        protected ITTTextBox PHONENUMBEROFADMITTED;
        protected ITTDateTimePicker DateOfEntrance;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel16;
        protected ITTObjectListBox DiedClinic;
        protected ITTLabel labelReasonForDeath;
        protected ITTLabel ttlabel10;
        protected ITTTextBox ADDRESOFADMITTED;
        protected ITTLabel labelSenderDoctor;
        protected ITTLabel ttlabel15;
        protected ITTObjectListBox SenderDoctor;
        protected ITTTextBox CITIZENSHIPNOOFADMITTED;
        protected ITTDateTimePicker DateTimeOfDeath;
        protected ITTObjectListBox DoctorFixed;
        protected ITTLabel labelDateTimeOfDeath;
        protected ITTObjectListBox ReasonForDeath;
        protected ITTTextBox DeathOrderNo;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelMorgueCupboardNo;
        protected ITTLabel ttlabel8;
        protected ITTTextBox DeathBodyAdmittedTo;
        protected ITTTextBox MorgueCupboardNo;
        protected ITTLabel ttlabel3;
        protected ITTTabPage tttabpageReport;
        protected ITTRichTextBoxControl Report;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("ac6daff5-aee5-4794-96b6-f13d5fa1e6f1"));
            tttabpageMorgue = (ITTTabPage)AddControl(new Guid("a3021664-ca46-438a-87c5-abe72ea0915d"));
            externalDoctFixed = (ITTTextBox)AddControl(new Guid("fe0b97d8-84da-4067-b204-666ff3aedee9"));
            DeathPlace = (ITTEnumComboBox)AddControl(new Guid("bf63ce87-a285-42b1-b37f-af65c0a378a9"));
            deliveredByLst = (ITTObjectListBox)AddControl(new Guid("40e3c61d-9fe4-448b-99fa-70339301e147"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("fdbf387a-3e34-4d61-8f4a-df83819fd1db"));
            PatientSex = (ITTEnumComboBox)AddControl(new Guid("c3052d71-7abc-47dd-b135-c1a9d1fff184"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("ded4eb19-18f5-4156-8ff5-a529769d604b"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("61ee1e50-b12a-4464-b2cb-9198edcc40b3"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("86556527-05cc-430b-ae11-2d17b49be5bc"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("da40d3ef-4e20-470a-a2dc-c69f0289b151"));
            BithDate = (ITTDateTimePicker)AddControl(new Guid("5e0be275-4f79-4af0-8f7d-423fe05b6989"));
            BirthPalce = (ITTObjectListBox)AddControl(new Guid("03940d08-97e8-49c8-84b8-e0a1d298bd39"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("1d6a14aa-7a0b-40c7-aa29-581e397708cc"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8c237ada-06c6-4a69-99d2-34a5a6ff005c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("08067a3b-b7d2-4141-b52d-1ec4e7905a1a"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("76505946-3d87-4cc9-9824-b6602488d5d4"));
            PatientName = (ITTTextBox)AddControl(new Guid("598aabb1-41da-4904-9b67-1a19491088be"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("d20de4b2-5b46-4ccd-b9cd-b2435b64817d"));
            GraveyardPlotNo = (ITTTextBox)AddControl(new Guid("09d05d0f-056f-465b-908d-83433ce15ba2"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("13c296a4-8aeb-462e-a92a-e6b82011e4b5"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("dbbbabc0-9bf8-420d-9648-06a9a086d2cd"));
            DateOfSentToGrave = (ITTDateTimePicker)AddControl(new Guid("31444594-8b31-46ac-b2aa-d5018cc08ff2"));
            labelDoctorFixed = (ITTLabel)AddControl(new Guid("ee6fb4de-e472-4072-9f85-46106150f19a"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("8595bd41-247a-4dd1-adff-1447b0deaede"));
            PHONENUMBEROFADMITTED = (ITTTextBox)AddControl(new Guid("f2713f63-c9a2-4593-84a8-f29d6c4247b1"));
            DateOfEntrance = (ITTDateTimePicker)AddControl(new Guid("be4ca6ad-87c2-4f7f-9018-99a1343f63a7"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("2e2d0918-4b97-4569-ae04-8203cb23b894"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("b31b85d3-8779-4f35-858a-eec7eeb0614a"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("f67eb2ac-6dce-468e-8c2f-919de7968e9c"));
            DiedClinic = (ITTObjectListBox)AddControl(new Guid("aac144c3-f1d0-4176-b7ab-dcb15f9409d3"));
            labelReasonForDeath = (ITTLabel)AddControl(new Guid("59a4cc65-b172-4003-a122-6ad74095ddd9"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("ee16b66e-bf77-449c-b61e-968cf26dc9bd"));
            ADDRESOFADMITTED = (ITTTextBox)AddControl(new Guid("54e29f2b-38e1-411e-b3e8-ee526e030244"));
            labelSenderDoctor = (ITTLabel)AddControl(new Guid("991dbb0d-f826-4a4d-becd-43063123ddf4"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("a3ecf275-b4bf-4d90-adc8-29c37e525e0b"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("8feb397f-a3d2-485d-aaad-5d1efcd1d46c"));
            CITIZENSHIPNOOFADMITTED = (ITTTextBox)AddControl(new Guid("9ffe9632-7d29-465f-a374-eef39277f4d9"));
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("b69091d2-a41b-4330-a57b-bcf1d9eb4594"));
            DoctorFixed = (ITTObjectListBox)AddControl(new Guid("e02cd5a1-6557-4231-936f-9f7c613aaba8"));
            labelDateTimeOfDeath = (ITTLabel)AddControl(new Guid("913d3f1a-c201-4335-914e-117f91a2436e"));
            ReasonForDeath = (ITTObjectListBox)AddControl(new Guid("f4dae200-8681-4f65-8b7b-d333d1361da1"));
            DeathOrderNo = (ITTTextBox)AddControl(new Guid("257d7727-9933-44bf-a269-d66bd45e1bbc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("23d1f23c-b76e-4403-905d-ecd8ba204a0c"));
            labelMorgueCupboardNo = (ITTLabel)AddControl(new Guid("305d4dab-bed8-48aa-a416-b139c9da4576"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("3866c076-9a4f-43ec-a29d-10e84b00bb73"));
            DeathBodyAdmittedTo = (ITTTextBox)AddControl(new Guid("2cfd9317-9f31-4e97-a02c-f1ad37c1bfc4"));
            MorgueCupboardNo = (ITTTextBox)AddControl(new Guid("4e8eb947-ba23-4ca0-8707-0a0c1b4f8fd2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("83e3e426-be11-48ff-a634-86c452907a32"));
            tttabpageReport = (ITTTabPage)AddControl(new Guid("341de2c9-d601-4b46-9d59-93e9976055ae"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("26528f51-a454-47e1-bd04-55dc66066e03"));
            base.InitializeControls();
        }

        public MorgueCancelledForm() : base("MORGUE", "MorgueCancelledForm")
        {
        }

        protected MorgueCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}