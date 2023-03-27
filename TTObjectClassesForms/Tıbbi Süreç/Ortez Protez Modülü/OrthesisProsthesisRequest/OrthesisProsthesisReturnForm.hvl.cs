
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
    public partial class OrthesisProsthesisReturnForm : EpisodeActionForm
    {
    /// <summary>
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest
        {
            get { return (TTObjectClasses.OrthesisProsthesisRequest)_ttObject; }
        }

        protected ITTObjectListBox MasterResource;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTabControl tttabcontrolDiagnose;
        protected ITTTabPage tttabpageOrthesis;
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
        protected ITTRichTextBoxControl TotalDescription;
        protected ITTLabel labelProtocolNo;
        protected ITTGrid ReturnDescriptionGrid;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTTextBoxColumn ReturnDescription;
        protected ITTTextBoxColumn OwnerUser;
        protected ITTLabel ReturnDescriptionsLabel;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelProcedureDoctor;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("e8ecfe86-eb47-4c4a-8695-9afb87e4899a"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f330aa61-f9fa-442e-902e-b9294d4603f8"));
            tttabcontrolDiagnose = (ITTTabControl)AddControl(new Guid("090a5bf7-3290-46c4-8f71-3b5859ffb70c"));
            tttabpageOrthesis = (ITTTabPage)AddControl(new Guid("743afcad-f4e6-4e72-8bab-bcd295cc2ed9"));
            OrthesisProsthesisProcedures = (ITTGrid)AddControl(new Guid("bd344abe-7571-4597-a39b-89c7b319618e"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("4fd93dc8-7791-4f2a-b438-9e4cae9ef400"));
            SideO = (ITTEnumComboBoxColumn)AddControl(new Guid("1ec4420c-3709-4c20-b73a-6b537f0b7b7e"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d5a8817b-3d0c-41b8-8489-0abb8385aaf1"));
            tttabpageDiagnosis = (ITTTabPage)AddControl(new Guid("f318f44b-f270-4996-9728-ca24a5a0b377"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("4b22ab45-2ccb-4971-b531-acfe62135b54"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("4eeda39c-8cde-44ef-84ab-71416fe54ada"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("0c7a2d1a-947d-4585-a76c-d3dd93ae2e2a"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("53bc2b86-78ab-41ca-98a0-5c284452e2cb"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("5e0ba8a1-aa7a-4ad6-8034-f31153697595"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("0dedb0f0-1645-4c4a-8276-09f973a86845"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("75c784a6-a534-4cc5-a190-a4c82d920586"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("453ea7b3-2a6a-454c-952c-664b6e2a64f1"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("624369b9-b724-443d-9001-0b495f8c0808"));
            TotalDescription = (ITTRichTextBoxControl)AddControl(new Guid("1892b819-7971-4f38-971b-273cfa0da9c0"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("c24c5d0a-5cbf-48c8-bbc2-945717e23c44"));
            ReturnDescriptionGrid = (ITTGrid)AddControl(new Guid("d368df26-3ac2-4663-b015-019e62271ec3"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("6c6660c1-ec71-4428-acf9-c744a4beb980"));
            ReturnDescription = (ITTTextBoxColumn)AddControl(new Guid("26b6cf9f-7d46-46ec-a342-af8165c216bd"));
            OwnerUser = (ITTTextBoxColumn)AddControl(new Guid("9e538ee9-1e4e-415f-8fe1-284150fdf077"));
            ReturnDescriptionsLabel = (ITTLabel)AddControl(new Guid("23d3767b-0e0d-465d-b42f-12a11f010e21"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("3d3d7ce8-7474-4dbc-b98f-5905bd2d67f0"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("11318b4c-62d9-42d1-bc28-2bcc6cfc9381"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("c1e60c0a-c69b-4857-a7e4-67d09fa959d2"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("a0d0f7d0-b0a4-4b33-98d1-4ceee686cc7c"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("9bc34976-fef5-4b4c-a3cf-6e76d0ce829c"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("439ed03e-e7a3-4b5c-aabc-f49bebd39ea5"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("dd8ba6c5-1f03-4d6e-8140-d87a3b9c12d2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5af8cf28-77c8-42e8-a3f4-275e41e34d5d"));
            base.InitializeControls();
        }

        public OrthesisProsthesisReturnForm() : base("ORTHESISPROSTHESISREQUEST", "OrthesisProsthesisReturnForm")
        {
        }

        protected OrthesisProsthesisReturnForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}