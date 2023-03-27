
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
    /// Paket İçine Hizmet/Malzeme Aktarma
    /// </summary>
    public partial class PackageTransferForm : TTForm
    {
    /// <summary>
    /// Paket İçine Hizmet/Malzeme Aktarma
    /// </summary>
        protected TTObjectClasses.PackageTransfer _PackageTransfer
        {
            get { return (TTObjectClasses.PackageTransfer)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTGrid GridEpisodeProtocols;
        protected ITTTextBoxColumn PAYERNAME;
        protected ITTTextBoxColumn PROTOCOLNAME;
        protected ITTTextBoxColumn PROTOCOLSTATUS;
        protected ITTButtonColumn LISTSUBACTIONS;
        protected ITTLabel ttlabel3;
        protected ITTGrid GridProtocolSubActionPackages;
        protected ITTDateTimePickerColumn TRXDATE;
        protected ITTTextBoxColumn EXTERNALCODE;
        protected ITTTextBoxColumn DESC;
        protected ITTTextBoxColumn STATUS;
        protected ITTCheckBoxColumn TARGETPACKAGE;
        protected ITTTabControl TABHizmetMalzeme;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GridProtocolSubActionProcedures;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn DESCRIPTION;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn PACKAGEINFO;
        protected ITTCheckBoxColumn TRANSFER;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GridProtocolSubActionMaterials;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTTextBoxColumn tttextboxcolumn5;
        protected ITTTextBoxColumn tttextboxcolumn6;
        protected ITTTextBoxColumn tttextboxcolumn7;
        protected ITTCheckBoxColumn TRANSFERTARGETPACKAGE;
        protected ITTButton UnSelectAllMaterialBtn;
        protected ITTButton SelectAllMaterialBtn;
        protected ITTDateTimePicker FILTERENDDATE;
        protected ITTLabel labelProtocolEndDate;
        protected ITTLabel labelProtocolStartDate;
        protected ITTDateTimePicker FILTERSTARTDATE;
        protected ITTButton FilterButton;
        protected ITTObjectListBox MATERIAL;
        protected ITTObjectListBox PROCEDURE;
        protected ITTLabel MaterialLbl;
        protected ITTLabel ProcedureLbl;
        protected ITTButton UnSelectAllProcedureBtn;
        protected ITTButton SelectAllProcedureBtn;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("1b7e0c41-e7d5-4afe-91d5-1c37dfa6cbba"));
            GridEpisodeProtocols = (ITTGrid)AddControl(new Guid("61115854-8999-4a32-aafd-498f641276b4"));
            PAYERNAME = (ITTTextBoxColumn)AddControl(new Guid("74e2d3dc-a347-4005-81e5-b723bcd0064d"));
            PROTOCOLNAME = (ITTTextBoxColumn)AddControl(new Guid("52221efb-2de8-4453-a1b8-904c96744b92"));
            PROTOCOLSTATUS = (ITTTextBoxColumn)AddControl(new Guid("841dc1d4-9388-4f48-9bc8-141a2f2af338"));
            LISTSUBACTIONS = (ITTButtonColumn)AddControl(new Guid("f6978811-7bb5-47c4-9580-065ac38e4c66"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("91cb7879-d154-4ad4-9f7f-655133190433"));
            GridProtocolSubActionPackages = (ITTGrid)AddControl(new Guid("1cf471d4-da68-4254-a8c2-bf1dd9ab0a49"));
            TRXDATE = (ITTDateTimePickerColumn)AddControl(new Guid("a9decf1a-72b4-4ade-a119-b020e7909ffe"));
            EXTERNALCODE = (ITTTextBoxColumn)AddControl(new Guid("80a4ba3d-f28d-43dc-9999-a7a96927e1e3"));
            DESC = (ITTTextBoxColumn)AddControl(new Guid("be2993e3-7ca3-4590-8128-1a1ce56ebec7"));
            STATUS = (ITTTextBoxColumn)AddControl(new Guid("67d44774-0bac-4d73-b02c-28dc00e19d76"));
            TARGETPACKAGE = (ITTCheckBoxColumn)AddControl(new Guid("41943ad3-0633-4ee6-a5d3-546cf7c0a68a"));
            TABHizmetMalzeme = (ITTTabControl)AddControl(new Guid("9ae2802d-74fa-45cc-861d-ead3243bd23a"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("394bfb48-74d1-4d18-afa1-1c07da8c39bb"));
            GridProtocolSubActionProcedures = (ITTGrid)AddControl(new Guid("7f24f2be-6dae-4b28-855e-44e8a6af54c8"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("33844454-0e62-4b47-9c5d-7a0210e5a74c"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("9b3ce494-b1b2-4dad-85ba-d7a61e13b7b8"));
            DESCRIPTION = (ITTTextBoxColumn)AddControl(new Guid("91afa3e1-340b-4903-8abe-cf0c8177b956"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("83dc9fb7-bbc9-4400-8f58-c6357dc7d557"));
            PACKAGEINFO = (ITTTextBoxColumn)AddControl(new Guid("7ca794bd-00fc-4cd7-b2cc-7ecbb98e2b4a"));
            TRANSFER = (ITTCheckBoxColumn)AddControl(new Guid("48149aa0-c913-4d07-8cdc-d7eb9e51687f"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("83fcdb51-893f-4a13-9aca-af5463e8fd49"));
            GridProtocolSubActionMaterials = (ITTGrid)AddControl(new Guid("5d86d9ac-e092-405e-8851-a263c0cba280"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("a5a225f4-fb5f-4fb7-9ac2-5716ae601515"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("0204cdc9-c585-42fb-a4e1-5ee614c73866"));
            tttextboxcolumn5 = (ITTTextBoxColumn)AddControl(new Guid("b137c9a4-1db7-44ad-9a69-bde01d826e06"));
            tttextboxcolumn6 = (ITTTextBoxColumn)AddControl(new Guid("b41c01ef-3081-441a-9b92-c24ce654b74e"));
            tttextboxcolumn7 = (ITTTextBoxColumn)AddControl(new Guid("dc0ac4c6-7fd2-4f92-9e5c-d8ed7cd5151e"));
            TRANSFERTARGETPACKAGE = (ITTCheckBoxColumn)AddControl(new Guid("59d05638-a0b0-4e53-9e64-6a92a4bc11ed"));
            UnSelectAllMaterialBtn = (ITTButton)AddControl(new Guid("41f213c9-7352-4637-807d-fbefad6d859a"));
            SelectAllMaterialBtn = (ITTButton)AddControl(new Guid("0be5cffe-7740-4aae-8361-b30c99a685c3"));
            FILTERENDDATE = (ITTDateTimePicker)AddControl(new Guid("f52f9f2a-9425-4972-8b3d-774e6e029abd"));
            labelProtocolEndDate = (ITTLabel)AddControl(new Guid("7c8f637b-b81f-4b32-bb35-68c62439fe2c"));
            labelProtocolStartDate = (ITTLabel)AddControl(new Guid("e16f89ec-6ff3-4505-8441-373772ead72c"));
            FILTERSTARTDATE = (ITTDateTimePicker)AddControl(new Guid("53b736f2-b2a5-47bf-8095-bbc0f89d1496"));
            FilterButton = (ITTButton)AddControl(new Guid("cd4cdb0a-8c78-4ac9-8b62-a70a344597d2"));
            MATERIAL = (ITTObjectListBox)AddControl(new Guid("a1c4c69e-f5d5-4971-90c4-81ff70f5815e"));
            PROCEDURE = (ITTObjectListBox)AddControl(new Guid("8eaf66dc-2659-4294-8d25-2f6c42f7a9d6"));
            MaterialLbl = (ITTLabel)AddControl(new Guid("be1cab79-8ae6-4596-abac-90c407198b3f"));
            ProcedureLbl = (ITTLabel)AddControl(new Guid("fef26360-b855-4c8e-a368-d16317546988"));
            UnSelectAllProcedureBtn = (ITTButton)AddControl(new Guid("b8b4c267-c22c-467f-88f4-0631ef9894f0"));
            SelectAllProcedureBtn = (ITTButton)AddControl(new Guid("ce5063bc-c79b-4173-9b78-728f7ca8fea0"));
            base.InitializeControls();
        }

        public PackageTransferForm() : base("PACKAGETRANSFER", "PackageTransferForm")
        {
        }

        protected PackageTransferForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}