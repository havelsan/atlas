
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
    public partial class MorgueDeliveryForm : EpisodeActionForm
    {
    /// <summary>
    /// Morg İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Morgue _Morgue
        {
            get { return (TTObjectClasses.Morgue)_ttObject; }
        }

        protected ITTLabel labelExternalDoctorFixedUniqueNo;
        protected ITTTextBox ExternalDoctorFixedUniqueNo;
        protected ITTTextBox ExternalDoctorFixed;
        protected ITTTextBox BirthPlacePerson;
        protected ITTTextBox MorgueCupboardNo;
        protected ITTTextBox DeathBodyAdmittedTo;
        protected ITTTextBox DeathOrderNo;
        protected ITTTextBox CITIZENSHIPNOOFADMITTED;
        protected ITTTextBox TombVillage;
        protected ITTTextBox ADDRESOFADMITTED;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox PatientName;
        protected ITTTextBox PHONENUMBEROFADMITTED;
        protected ITTTextBox GraveyardPlotNo;
        protected ITTLabel labelExternalDoctorFixed;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox deliveredByLst;
        protected ITTLabel ttlabel21;
        protected ITTEnumComboBox DeathPlace;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelMorgueCupboardNo;
        protected ITTLabel labelTombTown;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox MernisDeathReason;
        protected ITTLabel labelDateTimeOfDeath;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTObjectListBox DoctorFixed;
        protected ITTLabel labelTombVillage;
        protected ITTDateTimePicker DateTimeOfDeath;
        protected ITTLabel ttlabel14;
        protected ITTObjectListBox SenderDoctor;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelSenderDoctor;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker BithDate;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelReasonForDeath;
        protected ITTObjectListBox DiedClinic;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker DateOfEntrance;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel17;
        protected ITTLabel labelDoctorFixed;
        protected ITTLabel ttlabel13;
        protected ITTDateTimePicker DateOfSentToGrave;
        protected ITTObjectListBox SKRSTombCity;
        protected ITTObjectListBox SKRSTombTown;
        override protected void InitializeControls()
        {
            labelExternalDoctorFixedUniqueNo = (ITTLabel)AddControl(new Guid("c033ed6e-6c57-447e-9f19-12a5eb3c0320"));
            ExternalDoctorFixedUniqueNo = (ITTTextBox)AddControl(new Guid("1b9967ed-90eb-46f2-9971-08caa2ad2be4"));
            ExternalDoctorFixed = (ITTTextBox)AddControl(new Guid("a50dea3b-a0c1-4b61-9968-90631c735a94"));
            BirthPlacePerson = (ITTTextBox)AddControl(new Guid("a4771769-88c6-4576-9001-c701d6164cb7"));
            MorgueCupboardNo = (ITTTextBox)AddControl(new Guid("90259902-62a8-4d33-85bf-95f6f23350aa"));
            DeathBodyAdmittedTo = (ITTTextBox)AddControl(new Guid("2432889c-50af-426d-aa6e-465f4a9c2a60"));
            DeathOrderNo = (ITTTextBox)AddControl(new Guid("4e4ef11a-710b-42af-b8b7-ca98ed9817a9"));
            CITIZENSHIPNOOFADMITTED = (ITTTextBox)AddControl(new Guid("15110a25-5fba-4c35-9ea0-9d67158cb66c"));
            TombVillage = (ITTTextBox)AddControl(new Guid("0a37dd2a-1216-4ba8-8bc8-6c5f2b4a5368"));
            ADDRESOFADMITTED = (ITTTextBox)AddControl(new Guid("52e9c575-0f67-4a2f-8b3d-25f5015d992a"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("a4bda7ad-fb75-42b3-a35f-e334a666cddc"));
            PatientName = (ITTTextBox)AddControl(new Guid("dde3b098-e146-4319-a2e3-45930432cd60"));
            PHONENUMBEROFADMITTED = (ITTTextBox)AddControl(new Guid("67713f17-425a-42cd-8040-8d66c722d008"));
            GraveyardPlotNo = (ITTTextBox)AddControl(new Guid("dadb634a-6766-4183-9b1a-1689a5f87dc2"));
            labelExternalDoctorFixed = (ITTLabel)AddControl(new Guid("c4f337c7-891d-4514-8d1c-c506ce9d99f8"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("deb1b7ab-4899-41ae-a004-c9293191cbb2"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("1b7d593a-5914-4a58-a6af-7b9bbbd7349f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cf3d729c-faf9-460c-bc8e-97091e84978e"));
            deliveredByLst = (ITTObjectListBox)AddControl(new Guid("fa231dae-11fa-44c4-be7c-cfdd274164ec"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("ba933920-4685-4be2-b81e-a6a0ae634c0b"));
            DeathPlace = (ITTEnumComboBox)AddControl(new Guid("5657a287-0402-49f7-b4d4-fa05b9ece17d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("b2c5cc47-b765-480c-abdb-3a154147d632"));
            labelMorgueCupboardNo = (ITTLabel)AddControl(new Guid("de9121c5-c379-49f0-ab2d-07d5880ff340"));
            labelTombTown = (ITTLabel)AddControl(new Guid("ddb8a8c6-3864-46c6-bdf9-baf43c26c080"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b4025813-00e7-4143-ad94-e976569a84df"));
            MernisDeathReason = (ITTObjectListBox)AddControl(new Guid("dfe27478-a0f9-4157-9a12-3ea4d4d17794"));
            labelDateTimeOfDeath = (ITTLabel)AddControl(new Guid("72b78afb-6ff1-4baa-b913-33de6d908f8f"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("5c158b02-f9eb-4a0f-958d-9b780df0487c"));
            DoctorFixed = (ITTObjectListBox)AddControl(new Guid("00d79be7-3802-4290-a979-38c071a2a12a"));
            labelTombVillage = (ITTLabel)AddControl(new Guid("f7023578-54f0-4a45-aee0-a72256553382"));
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("67dcb690-6009-41c0-95d3-8d4b98f8a2da"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("c4e09c5a-d65e-4e2f-9661-b67f1b18bffb"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("12dece78-7de3-4ac6-868a-da9efe6bf001"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("1be04fe7-c831-4f30-bc82-b11c3dbbe191"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("4f4866d1-c6c6-4255-9e67-81c39f01cc1c"));
            labelSenderDoctor = (ITTLabel)AddControl(new Guid("7ac19870-f646-410b-b474-e29532caaf22"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("087ba2f1-2890-4ae7-ace1-60edc0740474"));
            BithDate = (ITTDateTimePicker)AddControl(new Guid("bc33eb61-1e99-47a6-967a-8de7e03e6da0"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("701f6189-98c2-4890-8b5d-8839142f9064"));
            labelReasonForDeath = (ITTLabel)AddControl(new Guid("96b86ec2-e137-4c04-adc0-e3238ed07bbc"));
            DiedClinic = (ITTObjectListBox)AddControl(new Guid("d6003153-927f-46f8-b792-f60ae5450792"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c1e6ab30-7494-4079-9d65-7c98991c24e7"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("c9464da0-4bd1-4c09-a6f8-9ab420704883"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3ec45b21-603d-4440-a8a3-1c1789432afc"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("af6d66ce-72bd-49a6-b9d5-335505c27679"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("08b445f1-a45d-4a2e-b9f0-8929b479ee23"));
            DateOfEntrance = (ITTDateTimePicker)AddControl(new Guid("9888998c-2df5-4d58-8deb-d4d0154bcfd1"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("3d75239d-e3fe-4ab5-8941-562594810521"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("8b01cb2c-657d-4245-8c11-3b22a2c4e95e"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("7b562e3e-e74b-44f3-9380-74aba9137e82"));
            labelDoctorFixed = (ITTLabel)AddControl(new Guid("21500979-a869-4130-8702-fdba5692b6ef"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("ebd8f26c-cc40-40e1-96e7-d8962fb3f4ad"));
            DateOfSentToGrave = (ITTDateTimePicker)AddControl(new Guid("6b958f46-0534-4a7a-af63-f9f78ce6585b"));
            SKRSTombCity = (ITTObjectListBox)AddControl(new Guid("3280b125-3f33-4ebc-bb44-0ab7f6ea7fdd"));
            SKRSTombTown = (ITTObjectListBox)AddControl(new Guid("7be139be-6344-4ff1-915d-73c32e661f66"));
            base.InitializeControls();
        }

        public MorgueDeliveryForm() : base("MORGUE", "MorgueDeliveryForm")
        {
        }

        protected MorgueDeliveryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}