
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
    public partial class OrthesisProsthesisRequestForm : EpisodeActionForm
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
        protected ITTTextBoxColumn SpecificNote;
        protected ITTTextBoxColumn Price;
        protected ITTEnumComboBoxColumn SideO;
        protected ITTTextBoxColumn Amount;
        protected ITTCheckBoxColumn IsPrintReport;
        protected ITTCheckBoxColumn PatientPays;
        protected ITTEnumComboBoxColumn PayRatioO;
        protected ITTCheckBoxColumn IsRequestReport;
        protected ITTListBoxColumn Technician;
        protected ITTRichTextBoxControl TotalDescription;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelProcedureDoctor;
        protected ITTGrid ReturnDescriptionGrid;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTTextBoxColumn ReturnDescription;
        protected ITTTextBoxColumn OwnerUser;
        protected ITTLabel ReturnDescriptionsLabel;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("371a0dca-b9ce-4cdd-8460-d9294e5bb4ef"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("da2867de-a461-43e5-b5fa-b6258e56a1b2"));
            tttabcontrolDiagnose = (ITTTabControl)AddControl(new Guid("345d1a94-d280-4e60-b8ad-6eabd7a47937"));
            tttabpageOrthesis = (ITTTabPage)AddControl(new Guid("bb46b150-408f-428b-b566-a2b950f77cbe"));
            OrthesisProsthesisProcedures = (ITTGrid)AddControl(new Guid("a3343343-3c6f-4c27-be46-f55cd8ca5a89"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("4c934a10-0399-4f0a-9657-59afc16ecf56"));
            SpecificNote = (ITTTextBoxColumn)AddControl(new Guid("9deadf3b-1c1d-411f-a385-2a8efe34bba5"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("dc801fa6-0a56-458d-aa9b-edff66c2c1b7"));
            SideO = (ITTEnumComboBoxColumn)AddControl(new Guid("c5a5b3e2-8f7e-4e5f-8403-b52d52b8fbd1"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6b83bbd5-007c-4733-9908-59f644e2a46f"));
            IsPrintReport = (ITTCheckBoxColumn)AddControl(new Guid("3df84cad-4193-4dbd-af97-af35938895f9"));
            PatientPays = (ITTCheckBoxColumn)AddControl(new Guid("d430043b-6024-4353-a3b1-4b991f270933"));
            PayRatioO = (ITTEnumComboBoxColumn)AddControl(new Guid("3ef31117-5522-4945-9dae-83cda5b0aa37"));
            IsRequestReport = (ITTCheckBoxColumn)AddControl(new Guid("0c98834c-9fd2-46e2-99a7-19c4dd693d55"));
            Technician = (ITTListBoxColumn)AddControl(new Guid("46a8d733-18f8-4228-b01f-057ade0fef28"));
            TotalDescription = (ITTRichTextBoxControl)AddControl(new Guid("d5158ce3-933f-47bd-b3f5-d501dda78079"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("f4a83c14-d604-4b96-8890-c6ef684fc5ae"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("9148ed70-12a9-42f5-8d90-42319870ae5b"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("6a20a8a3-c74d-457c-a2d9-0c7784a0e43e"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("ff379c35-fb42-4a97-af8e-9178fcfb1638"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("f1e4c163-7c4d-4178-869f-cc271707ad23"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("c9384ffb-63f4-4100-a734-d6a99c575047"));
            ReturnDescriptionGrid = (ITTGrid)AddControl(new Guid("eaeb859f-34c0-4acb-83fc-a4d1a321457d"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("b221fc88-d966-4e4d-ac7b-32943a4fb060"));
            ReturnDescription = (ITTTextBoxColumn)AddControl(new Guid("5748ef64-c8a1-4dbd-ac80-6d9b77667848"));
            OwnerUser = (ITTTextBoxColumn)AddControl(new Guid("a4bd7d3b-d939-4082-95ec-f89ad9c106dc"));
            ReturnDescriptionsLabel = (ITTLabel)AddControl(new Guid("80cbf58f-f163-473d-9e8b-bd7333168cb2"));
            base.InitializeControls();
        }

        public OrthesisProsthesisRequestForm() : base("ORTHESISPROSTHESISREQUEST", "OrthesisProsthesisRequestForm")
        {
        }

        protected OrthesisProsthesisRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}