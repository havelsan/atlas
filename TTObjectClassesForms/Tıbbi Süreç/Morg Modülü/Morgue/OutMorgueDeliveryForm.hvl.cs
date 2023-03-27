
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
    public partial class OutMorgueDeliveryForm : EpisodeActionForm
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
        protected ITTObjectListBox SKRSTombTown;
        protected ITTObjectListBox SKRSTombCity;
        protected ITTLabel ttlabel20;
        protected ITTLabel ttlabel21;
        protected ITTEnumComboBox DeathPlace;
        protected ITTLabel ttlabel19;
        protected ITTLabel labelTombTown;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel18;
        protected ITTLabel labelTombVillage;
        protected ITTTextBox TombVillage;
        protected ITTLabel labelDoctorFixed;
        protected ITTTextBox tttextbox3;
        protected ITTObjectListBox deliveredByLst;
        protected ITTObjectListBox MernisDeathReason;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel14;
        protected ITTEnumComboBox PatientSex;
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
        protected ITTLabel labelDateTimeOfDeath;
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
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("2d924af0-aabc-4ca1-85c8-86aa3fe99917"));
            tttabpageMorgue = (ITTTabPage)AddControl(new Guid("9e2a22b4-1b63-49d9-9756-7d3657d34b5c"));
            SKRSTombTown = (ITTObjectListBox)AddControl(new Guid("0c6bc049-997d-4ecf-a015-b3ddb7d1b1ae"));
            SKRSTombCity = (ITTObjectListBox)AddControl(new Guid("4897a836-44e0-4c97-8da3-bfadfba31716"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("5c3cba03-b80d-48eb-a9bf-a48daf489ac5"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("0b27f0af-8cc8-4161-b6ae-47168a796d79"));
            DeathPlace = (ITTEnumComboBox)AddControl(new Guid("c8d7489f-8922-43e3-b8e5-77547c06ce4d"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("d8db4304-ea84-4b6a-adb5-01e382ddcb8a"));
            labelTombTown = (ITTLabel)AddControl(new Guid("a97cd3e4-b0d2-4a81-a81e-cc4d847b93ee"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("8b4e9855-e804-483f-b2e1-acaf994efc8b"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("d4e94d92-1dc8-4708-ae28-c00a06d508df"));
            labelTombVillage = (ITTLabel)AddControl(new Guid("1f444e69-10c0-42f2-b2f0-bd4542b3a445"));
            TombVillage = (ITTTextBox)AddControl(new Guid("d5c4c21a-63f3-494a-ad32-6cc2e3acb72d"));
            labelDoctorFixed = (ITTLabel)AddControl(new Guid("fd591bd8-46e6-4f22-b1f1-0d77038e7ff0"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("38951d36-c9a2-4312-868c-c67910915e0c"));
            deliveredByLst = (ITTObjectListBox)AddControl(new Guid("50a0fcdc-d6e6-4e6b-94f4-5de0b7d862ba"));
            MernisDeathReason = (ITTObjectListBox)AddControl(new Guid("60bc27ce-ff88-4598-8d1b-d84411e3c076"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("839ffd8d-f171-4379-bf1a-1a60a6ee4f37"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("53597c50-3383-47c9-bc0c-f46808ad52d3"));
            PatientSex = (ITTEnumComboBox)AddControl(new Guid("0114e216-e688-46b2-93df-a2111b30f2e6"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("3ac8f920-e130-4d76-b22f-b96033f4327f"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("719ac8b6-245b-44a4-98b3-34618b58166c"));
            BithDate = (ITTDateTimePicker)AddControl(new Guid("b0bec07b-b6f6-4dd2-aef9-ec902ef0fafc"));
            BirthPalce = (ITTObjectListBox)AddControl(new Guid("b0dedf34-a13a-4655-b397-477677474c04"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("7c71b067-9a0e-4b31-a557-6b5f6c4327b3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ccc5a257-ab12-46b2-a30a-7b53311bf228"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c4afbe5d-b41f-454a-b540-b159d62874fa"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("387178d6-cf82-4283-8e0d-a6bcb5cfee39"));
            PatientName = (ITTTextBox)AddControl(new Guid("3fe5ab55-0a1e-45aa-be9f-7312e4dd8de5"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("5784232a-e598-442b-aca9-3f1285a1811f"));
            GraveyardPlotNo = (ITTTextBox)AddControl(new Guid("9e2d8964-39be-4858-a763-6dc1db3ce52c"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("7334600c-5fb9-4dc9-9af9-df1e9400cdcc"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("53f4122f-0b26-4bea-b962-f55c40e60347"));
            DateOfSentToGrave = (ITTDateTimePicker)AddControl(new Guid("88b7c5d8-e34c-47e3-874b-2eaddb4c2ee1"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("b936ab9b-aee3-4cf6-a5d1-4a1bf0c2356f"));
            PHONENUMBEROFADMITTED = (ITTTextBox)AddControl(new Guid("75dd9b5d-65b2-41d5-9332-37379f77184e"));
            DateOfEntrance = (ITTDateTimePicker)AddControl(new Guid("0a973696-abf2-41df-b401-8b97edb64430"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("9cc0b489-47bc-4e68-b937-43dc09eeed31"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("bae75cf2-3e76-419b-b25e-9a566f68c183"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("dea05d62-5ace-42fe-8514-04f776e8b749"));
            DiedClinic = (ITTObjectListBox)AddControl(new Guid("46f5a7a7-409b-4f41-ab64-787de3390e4a"));
            labelReasonForDeath = (ITTLabel)AddControl(new Guid("4043791c-ea1e-4104-9ed6-51e10f343205"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("be8b4586-c183-4e75-8eef-7f248b38ffe4"));
            ADDRESOFADMITTED = (ITTTextBox)AddControl(new Guid("3ede6959-a143-4260-ab04-5c62d3d1ff7a"));
            labelSenderDoctor = (ITTLabel)AddControl(new Guid("1dfd03bb-ee3e-4dfe-8408-a54f30d54237"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("85680fa9-43f3-4b82-a9ee-1f22b178a697"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("5b5a1bb8-a616-42e9-867a-68e8e38f22bf"));
            CITIZENSHIPNOOFADMITTED = (ITTTextBox)AddControl(new Guid("bf63e988-2203-46c4-93e5-2e4b33941191"));
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("408483e7-484e-4094-a01b-b3fa70f94bf2"));
            labelDateTimeOfDeath = (ITTLabel)AddControl(new Guid("a6e09527-f754-406d-9c85-8af6f48f9b8e"));
            DeathOrderNo = (ITTTextBox)AddControl(new Guid("5f2b3cf8-c1b2-4f6e-8da3-c5cdeafc4618"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("94aa4e8b-5e05-4028-ad11-3126034c0a6f"));
            labelMorgueCupboardNo = (ITTLabel)AddControl(new Guid("5386df70-1f30-4c83-8110-9131422781a8"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("e4df869d-a8ec-4a0d-8660-0d249b50a879"));
            DeathBodyAdmittedTo = (ITTTextBox)AddControl(new Guid("d5229db2-ea12-4aa3-9b7d-cec8e862fafb"));
            MorgueCupboardNo = (ITTTextBox)AddControl(new Guid("540542f8-5e04-45f5-a32b-ab638052c0af"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2075c631-9fa4-4cf6-b1ea-8355fc12e53c"));
            tttabpageReport = (ITTTabPage)AddControl(new Guid("cff97a24-dff0-4743-b19a-67be06d349b9"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("91a2861a-89d1-47d4-8fb2-9791dd45f6b0"));
            base.InitializeControls();
        }

        public OutMorgueDeliveryForm() : base("MORGUE", "OutMorgueDeliveryForm")
        {
        }

        protected OutMorgueDeliveryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}