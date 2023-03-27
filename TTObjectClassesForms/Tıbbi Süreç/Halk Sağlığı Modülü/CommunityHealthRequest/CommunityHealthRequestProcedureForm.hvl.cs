
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
    public partial class CommunityHealthRequestProcedureForm : ActionForm
    {
        protected TTObjectClasses.CommunityHealthRequest _CommunityHealthRequest
        {
            get { return (TTObjectClasses.CommunityHealthRequest)_ttObject; }
        }

        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelApprovalDoctor;
        protected ITTObjectListBox ApprovalDoctor;
        protected ITTGrid ProcedureGrid;
        protected ITTDateTimePickerColumn ActionDateCommunityHealthProcedure;
        protected ITTListBoxColumn ProcedureObjectCommunityHealthProcedure;
        protected ITTTextBoxColumn AmountCommunityHealthProcedure;
        protected ITTTextBoxColumn ResultCommunityHealthProcedure;
        protected ITTTextBoxColumn Meq;
        protected ITTTextBoxColumn MVal;
        protected ITTTextBoxColumn DescriptionCommunityHealthProcedure;
        protected ITTLabel labelCommunityHealthPayer;
        protected ITTObjectListBox CommunityHealthPayer;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelSampleType;
        protected ITTTextBox SampleType;
        protected ITTTextBox SamplePlace;
        protected ITTTextBox Description;
        protected ITTTextBox Deliverer;
        protected ITTTextBox Adresses;
        protected ITTLabel labelSamplePlace;
        protected ITTLabel labelDescription;
        protected ITTLabel labelDeliverer;
        protected ITTLabel labelAdresses;
        protected ITTLabel lblTeknisyen;
        protected ITTObjectListBox Technician;
        override protected void InitializeControls()
        {
            labelReportDate = (ITTLabel)AddControl(new Guid("cc918f0e-97fa-4427-bf45-8a84f2247280"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("a387f2c1-15e8-4bb6-8360-5db04a3fa2e0"));
            labelApprovalDoctor = (ITTLabel)AddControl(new Guid("82e9f53b-1db2-498f-85f7-81cd357eff45"));
            ApprovalDoctor = (ITTObjectListBox)AddControl(new Guid("b292ed65-4c93-44f8-b471-ebe13eb9be5e"));
            ProcedureGrid = (ITTGrid)AddControl(new Guid("78f49a8d-1420-4c4a-b01b-fcc5bfe50a20"));
            ActionDateCommunityHealthProcedure = (ITTDateTimePickerColumn)AddControl(new Guid("144df1a0-1f17-4b95-b3df-e061cc918ca2"));
            ProcedureObjectCommunityHealthProcedure = (ITTListBoxColumn)AddControl(new Guid("a7805678-8207-40ba-952d-68702066a580"));
            AmountCommunityHealthProcedure = (ITTTextBoxColumn)AddControl(new Guid("a1454084-d2c5-4ddb-bb93-e76d1c14da29"));
            ResultCommunityHealthProcedure = (ITTTextBoxColumn)AddControl(new Guid("7760555a-fdf4-4b5a-88b3-918a17285f73"));
            Meq = (ITTTextBoxColumn)AddControl(new Guid("ce86792e-547d-4145-bd1f-1de303007b39"));
            MVal = (ITTTextBoxColumn)AddControl(new Guid("a5f37c3a-a160-460e-a89a-5410d1276886"));
            DescriptionCommunityHealthProcedure = (ITTTextBoxColumn)AddControl(new Guid("29fe95e1-2ad3-418a-998e-290a6acecd46"));
            labelCommunityHealthPayer = (ITTLabel)AddControl(new Guid("fbac4cd4-756a-47f2-bc83-3df36762a582"));
            CommunityHealthPayer = (ITTObjectListBox)AddControl(new Guid("43cd201b-5d3c-4f1b-9809-7c439e17b3bf"));
            labelActionDate = (ITTLabel)AddControl(new Guid("cfbf7d4e-c9fa-4d8a-9f04-867746b0ef20"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("20d02687-9454-48d6-81c1-b874cf625e94"));
            labelSampleType = (ITTLabel)AddControl(new Guid("13579467-2d21-4438-a6e7-a9b4f7fb83ae"));
            SampleType = (ITTTextBox)AddControl(new Guid("b732c728-8153-4b65-b281-368ae47887f9"));
            SamplePlace = (ITTTextBox)AddControl(new Guid("0a2b873c-c96b-4aa0-97ff-55e15b08145f"));
            Description = (ITTTextBox)AddControl(new Guid("227ed9bd-155f-4f5d-a627-0efbfecd5a91"));
            Deliverer = (ITTTextBox)AddControl(new Guid("53bfdc43-0407-4fc2-85cf-0adcc333c5c7"));
            Adresses = (ITTTextBox)AddControl(new Guid("51119c5c-6ffe-4adf-ad83-f5b250c0f2e4"));
            labelSamplePlace = (ITTLabel)AddControl(new Guid("2cd397af-6095-45f9-86b2-fee72fd83a7c"));
            labelDescription = (ITTLabel)AddControl(new Guid("284c419c-2357-4c33-84fe-5950271b9618"));
            labelDeliverer = (ITTLabel)AddControl(new Guid("8b868131-d7d3-43a6-84f5-8029705e0f74"));
            labelAdresses = (ITTLabel)AddControl(new Guid("2c240e79-9ed3-46f8-afa8-f91056f0152e"));
            lblTeknisyen = (ITTLabel)AddControl(new Guid("b43e68dc-59f4-4719-b093-0a5c702453c6"));
            Technician = (ITTObjectListBox)AddControl(new Guid("2afddbcd-1c4d-444e-9e91-a48a588fe551"));
            base.InitializeControls();
        }

        public CommunityHealthRequestProcedureForm() : base("COMMUNITYHEALTHREQUEST", "CommunityHealthRequestProcedureForm")
        {
        }

        protected CommunityHealthRequestProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}