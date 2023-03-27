
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
    /// Ortez Protez
    /// </summary>
    public partial class OrthesisProsthesisHealthCommitteeForm : EpisodeActionForm
    {
    /// <summary>
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest
        {
            get { return (TTObjectClasses.OrthesisProsthesisRequest)_ttObject; }
        }

        protected ITTObjectListBox MasterResource;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage OrthesisProthesis;
        protected ITTGrid OrthesisProsthesisProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTEnumComboBoxColumn SideO;
        protected ITTTextBoxColumn Amount;
        protected ITTTabPage tttabpageDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTRichTextBoxControl TotalDescription;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelReasonOfExamination;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("9e28bdb9-92af-4c3f-8168-94ed3476ac81"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("969f33aa-c188-422b-a525-46848e3ced51"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("bfcc7d0d-1ce4-423e-bd86-6b7259d16a00"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("0c2eb962-7b9e-4d06-bd13-21ac2c1e05f1"));
            OrthesisProthesis = (ITTTabPage)AddControl(new Guid("fd6d5042-f3f1-4451-9f5b-051a95a2251c"));
            OrthesisProsthesisProcedures = (ITTGrid)AddControl(new Guid("07700558-f782-49ac-a33f-0b23ff7aa161"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("3d638b1e-8540-495e-bafe-6355084c4d01"));
            SideO = (ITTEnumComboBoxColumn)AddControl(new Guid("90da6bc5-938c-4539-a032-7036e9e3b678"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("fd80af02-9404-4a90-86b6-bb84958a480f"));
            tttabpageDiagnosis = (ITTTabPage)AddControl(new Guid("6afc1391-8df8-4998-accc-56c008a39ac4"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("94fcffa6-f2fb-450b-8cff-ec90679c8c87"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("6ebc30c0-b9e4-4eec-b35b-365c6790d1c2"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("3e504c24-ff4c-4125-99fc-12f560015cfd"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("558a9bef-9fca-4bf9-b889-f48a7c1ea9cc"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("b557d69b-3f89-4e84-b89b-b2a7b7a1e476"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("c4d92db4-f502-4d13-b578-bb63326d5a9b"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("790d851a-8a0c-4b9b-b724-bcf01bf41dfe"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("3af7a034-e440-460e-b30d-ec758d3ab250"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("c8492ce7-0eed-4f88-8614-2b80b33c98b3"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("e64c261d-73dc-4164-866a-35d9419d5613"));
            TotalDescription = (ITTRichTextBoxControl)AddControl(new Guid("394567ee-0d11-4718-a751-5793b99c96b1"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("1948fbfd-e030-4026-9082-7151b89b803f"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("71b2c56f-4737-43a0-8b90-a0c1a1d1bd2c"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("02bdedc6-49bd-4066-9266-d0b942132a96"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("354b8be2-b91f-47f0-90c3-def6e952e86d"));
            labelReasonOfExamination = (ITTLabel)AddControl(new Guid("2357b070-0b2d-45be-98bf-df4cd4ec3d39"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("c26dfb1f-f025-48b6-a6c9-f9af7133df8e"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("bff1f340-2f88-497b-8dbe-0d72f7d85935"));
            base.InitializeControls();
        }

        public OrthesisProsthesisHealthCommitteeForm() : base("ORTHESISPROSTHESISREQUEST", "OrthesisProsthesisHealthCommitteeForm")
        {
        }

        protected OrthesisProsthesisHealthCommitteeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}