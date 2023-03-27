
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
    /// Tıbbi Genetik Tetkik İstek Formu
    /// </summary>
    public partial class GeneticRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Genetik İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Genetic _Genetic
        {
            get { return (TTObjectClasses.Genetic)_ttObject; }
        }

        protected ITTObjectListBox TestToStudyTTListBox;
        protected ITTButton cmdPrintBarcode;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox RequestDescription;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox PreDiagnosis;
        protected ITTTextBox SendenMaterial;
        protected ITTTextBox PatientAge;
        protected ITTTextBox tttextbox3;
        protected ITTObjectListBox PatientRoom;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox PatientClinic;
        protected ITTLabel ttlabel7;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTTextBoxColumn EntryActionType;
        protected ITTEnumComboBox PatientSexEnum;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox RequestedDoctor;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox RepeatReason;
        protected ITTLabel ttlabel6;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox EmergencyCheckBox;
        protected ITTGrid grdGeneticTests;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn Amount;
        protected ITTButton btnSelectTemplate;
        protected ITTLabel ttlabel12;
        override protected void InitializeControls()
        {
            TestToStudyTTListBox = (ITTObjectListBox)AddControl(new Guid("0e562916-d10e-461c-a176-4a1a07f7edd7"));
            cmdPrintBarcode = (ITTButton)AddControl(new Guid("4cad2108-fb32-4d5b-bb1a-7de433e0c45d"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("791d0a95-665f-4641-ac15-a79687955c41"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("8b0387da-d8dc-465a-8c9b-244fe31dd421"));
            RequestDescription = (ITTTextBox)AddControl(new Guid("f81c84b3-b2e1-4d30-b8bf-a998fa0dc802"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("d47f6815-73e9-444d-a998-3fa0e0464169"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("95f3597e-aeaf-45bd-8bf5-b054813a02b5"));
            SendenMaterial = (ITTTextBox)AddControl(new Guid("05f5256b-8cba-4263-b4d9-d7882d27c8b8"));
            PatientAge = (ITTTextBox)AddControl(new Guid("51f139bb-cd11-4cb6-b25a-64f90c23def9"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("60cf9b55-2218-40de-94b6-5a450e362fea"));
            PatientRoom = (ITTObjectListBox)AddControl(new Guid("8085de90-f322-41dc-b3d0-17f0b389bbbc"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("9b560081-655e-476c-b40d-b27f2806dfd1"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("30bc20b6-c094-4ed5-98ca-26b2b6f5823a"));
            PatientClinic = (ITTObjectListBox)AddControl(new Guid("40f25681-a68b-4d47-a1f8-1bcfe3b4ef7b"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("ff0d557a-8b79-4af9-9b57-1ee89ef84c38"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("496452b1-c3ed-41ef-ba82-2a71d59080cd"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("44a00c23-020f-408d-9264-c6f534756caf"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("1b591516-8c9c-4b97-a499-bcf667893809"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("e11e5b18-b332-4aaf-8d50-cfd63338488a"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("13f1e0a1-c763-429f-8288-a449e0bf249b"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("19f1a7e5-d81a-4e7e-878f-c6b76dd60d5e"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("213ee9a1-6a5c-4b64-9308-0f6537b4836a"));
            EntryActionType = (ITTTextBoxColumn)AddControl(new Guid("73c04bb2-03a9-4848-a283-579095435041"));
            PatientSexEnum = (ITTEnumComboBox)AddControl(new Guid("741d1614-e76a-4968-9265-f335cb57e372"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("727b6836-bfcf-46e8-b595-3ab025f172f8"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c2aeac88-d88c-4c57-af11-572f1ad206c2"));
            RequestedDoctor = (ITTObjectListBox)AddControl(new Guid("60817106-a545-494b-abe4-51a7a558bb72"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1e87475c-07ab-4845-9af4-08eb7689feaa"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9c208b97-4899-4be2-9797-6ecf91152a18"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("4bafbc5d-9044-4051-ab5b-e2efbd484a8f"));
            RepeatReason = (ITTObjectListBox)AddControl(new Guid("fa53c73b-ca14-429f-b64c-880f3fe45d73"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("a55163aa-eb09-4386-bd1f-020c09382c86"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("7c426a45-ddcf-4f87-a13d-e3b6786124c4"));
            EmergencyCheckBox = (ITTCheckBox)AddControl(new Guid("12d08e5b-ad26-4fc5-8656-82dac4c72d11"));
            grdGeneticTests = (ITTGrid)AddControl(new Guid("b8055a9f-3254-41e7-b374-d1b912fe652e"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("0dddb44e-7cc8-47b9-a46b-d6c95115741e"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("55467229-dfa4-4b9d-b057-f9b2fabc623d"));
            btnSelectTemplate = (ITTButton)AddControl(new Guid("3259a9f5-0b14-4b95-9109-9e5fc3028a33"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("2613af6b-8b21-46e2-b49c-e96e8ce918cb"));
            base.InitializeControls();
        }

        public GeneticRequestForm() : base("GENETIC", "GeneticRequestForm")
        {
        }

        protected GeneticRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}