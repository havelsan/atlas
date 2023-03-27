
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
    public partial class MorgueApprovalForm : EpisodeActionForm
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
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox Cupboard;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox MaterialsAdmittedFrom;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelMaterialsAdmittedTo;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox MorgueCupboardNo;
        protected ITTTextBox DeathBodyAdmittedTo;
        protected ITTLabel labelMaterialsAdmittedFrom;
        protected ITTLabel ttlabel6;
        protected ITTTextBox MaterialsAdmittedTo;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox MernisDeathReason;
        protected ITTLabel labelQuarantineCupboardNo;
        protected ITTObjectListBox DoctorFixed;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage Materials;
        protected ITTGrid MaterialsGrid;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTListBoxColumn ExMaterials;
        protected ITTTextBoxColumn ExAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn ExNotes;
        protected ITTObjectListBox SenderDoctor;
        protected ITTLabel labelMorgueCupboardNo;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker DateTimeOfDeath;
        protected ITTTabPage tttabpageReport;
        protected ITTRichTextBoxControl Report;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("25ce0b22-ee68-4777-b0d6-1b1468d81664"));
            tttabpageMorgue = (ITTTabPage)AddControl(new Guid("24b941f1-cc95-48a8-9433-2628952a132a"));
            externalDoctFixed = (ITTTextBox)AddControl(new Guid("01f5dd00-bdd8-403c-800b-0c67f28816c8"));
            DeathPlace = (ITTEnumComboBox)AddControl(new Guid("0fb17c65-d409-4a86-a2d6-1aebc8dbd35a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("3eceb83c-7120-415c-8022-365e6f24fc0b"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("6c794ead-4d28-4141-9ae8-96ac1bf115ba"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("7eadd916-e146-4beb-bc49-a3458a73c4c5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("084b9464-6f3b-4ab5-9920-5d4f1f24b259"));
            Cupboard = (ITTObjectListBox)AddControl(new Guid("205680bb-3e35-46cc-8772-b07b5eeb6247"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d4a31dcd-0345-4ebd-b9e8-a871f339f8e2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("78daf398-780c-46f2-aeaa-01fe75a43010"));
            MaterialsAdmittedFrom = (ITTObjectListBox)AddControl(new Guid("bc4d4751-92d3-4f64-a057-b5cafd68644c"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("4cd6dcb0-e203-4e69-b0f4-9bec242755e5"));
            labelMaterialsAdmittedTo = (ITTLabel)AddControl(new Guid("d05fa32e-115f-4266-afba-6769db756667"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("d0f07e5a-c3bc-46be-9a8b-eabd3f7ae8f5"));
            MorgueCupboardNo = (ITTTextBox)AddControl(new Guid("1592582e-983c-4145-9994-8eb754fdbdb0"));
            DeathBodyAdmittedTo = (ITTTextBox)AddControl(new Guid("ba61e087-96f0-4c0b-a415-9c7782bdfa9e"));
            labelMaterialsAdmittedFrom = (ITTLabel)AddControl(new Guid("53536e98-8338-4b14-8258-241d8e48f5dc"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("356a1fd7-178a-4d6d-806d-2b80baf4ed82"));
            MaterialsAdmittedTo = (ITTTextBox)AddControl(new Guid("b8f5c396-3f2b-4e34-9faf-a189e5ef006e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cf18c9af-8e8c-47b9-a952-a8d41654b708"));
            MernisDeathReason = (ITTObjectListBox)AddControl(new Guid("3acdd69b-1fb3-4233-956e-6d373bf435e9"));
            labelQuarantineCupboardNo = (ITTLabel)AddControl(new Guid("f23f1367-d35a-42a2-b789-da3bb86aff15"));
            DoctorFixed = (ITTObjectListBox)AddControl(new Guid("097805e3-836e-4856-a0a3-3b9ffae2b398"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("c3111ed1-3db8-4d13-8e77-1949ceda63b4"));
            Materials = (ITTTabPage)AddControl(new Guid("c0bab9db-36bd-4e37-b41b-b4229b9f10d7"));
            MaterialsGrid = (ITTGrid)AddControl(new Guid("1091ee74-fee9-4889-a9ee-78af8c1bf728"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("0a3069e4-3d03-428b-8318-0df35c6add2e"));
            ExMaterials = (ITTListBoxColumn)AddControl(new Guid("b1894c9e-5164-4839-8be6-722b19afa091"));
            ExAmount = (ITTTextBoxColumn)AddControl(new Guid("e9775979-da23-4e31-9db9-71b7738c6cbb"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("dce7808d-1a21-4cc2-b027-09200f216628"));
            ExNotes = (ITTTextBoxColumn)AddControl(new Guid("674c44c3-ba69-4e89-bf65-f24ecce47f1f"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("641083f7-593e-4c79-b291-fdad27f0764a"));
            labelMorgueCupboardNo = (ITTLabel)AddControl(new Guid("438a1aef-b219-45f9-beb0-4d274f8acd93"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("106853b1-aeaf-445c-85a0-c79695e21b97"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("2e80a91e-2d84-4819-9e9f-4ebdb775d80c"));
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("0db1fc88-cd75-4820-bc46-92e27c7a5745"));
            tttabpageReport = (ITTTabPage)AddControl(new Guid("9c50656b-ae9d-47c7-bbe2-088b65168f67"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("d09a5466-2549-458e-b45e-f6eb46b99f72"));
            base.InitializeControls();
        }

        public MorgueApprovalForm() : base("MORGUE", "MorgueApprovalForm")
        {
        }

        protected MorgueApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}