
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
    public partial class MedicalStuffReportForm : TTForm
    {
    /// <summary>
    /// Tıbbi Malzeme Raporu.
    /// </summary>
        protected TTObjectClasses.MedicalStuffReport _MedicalStuffReport
        {
            get { return (TTObjectClasses.MedicalStuffReport)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox ReportNo;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelReportDecision;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTLabel labelReportNo;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage TabPage;
        protected ITTGrid MedicalStuffGrid;
        protected ITTTextBoxColumn Name;
        protected ITTTextBoxColumn Code;
        protected ITTListBoxColumn StuffGroup;
        protected ITTTextBoxColumn StuffAmount;
        protected ITTTextBoxColumn PeriodUnit;
        protected ITTEnumComboBoxColumn PeriodUnitType;
        protected ITTListBoxColumn StuffUsageType;
        protected ITTTextBoxColumn OdyometryTestId;
        protected ITTListBoxColumn StuffUseofPlace;
        protected ITTTextBoxColumn StuffDescription;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox MedicalStuffList;
        protected ITTCheckBox chkFtrHeyetRaporu;
        protected ITTObjectListBox lstTabip3;
        protected ITTLabel lblTabip3;
        protected ITTLabel lblTabip2;
        protected ITTObjectListBox lstTabip2;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("50360c88-0859-4a6c-824c-e5a7b63401c8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("69319aaf-b4d8-4dbf-bb10-996a4e4ef763"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5e34324b-e492-4928-91fd-81d772e1fedd"));
            ReportNo = (ITTTextBox)AddControl(new Guid("b1d25e79-642b-4b53-9b57-dd7cf0471e66"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("c1fa1453-b6a0-482a-98ba-be083755704d"));
            labelReportDecision = (ITTLabel)AddControl(new Guid("239a764d-e0fd-4219-84fa-0b85f6045046"));
            labelDescription = (ITTLabel)AddControl(new Guid("67a25c12-4d11-46bc-9462-07babb25f0bc"));
            labelStartDate = (ITTLabel)AddControl(new Guid("699de6aa-37f7-44c3-8509-d5871d202a12"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("84bebe1d-062b-4466-bf89-23278087da0f"));
            labelEndDate = (ITTLabel)AddControl(new Guid("e91b57ad-fe45-4a6c-a9bc-03fdac63b649"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("efe3b3dc-36c9-44e6-bd72-846aa0562c46"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("81f03069-a18b-44f3-8b4e-1e6ce173c4b1"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("4adfeec8-30a4-4dde-bcb2-c925255c6900"));
            labelReportNo = (ITTLabel)AddControl(new Guid("6fe46926-4a42-4769-8026-c1770c8c77a2"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ea440f08-d8f8-4f89-b6f5-9330331dad94"));
            TabPage = (ITTTabPage)AddControl(new Guid("5a71da44-4d54-4211-bf8a-3bfd5293ab30"));
            MedicalStuffGrid = (ITTGrid)AddControl(new Guid("6cf7d055-c709-4d12-a38c-f73be4d7afa7"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("b4ad8225-ae41-4b4e-b215-6a2370afe0eb"));
            Code = (ITTTextBoxColumn)AddControl(new Guid("2ae74ab7-47fe-4ac3-a85e-d7c2a3ee0657"));
            StuffGroup = (ITTListBoxColumn)AddControl(new Guid("6901aca9-9977-46f7-8e1d-6c40fc8dd73c"));
            StuffAmount = (ITTTextBoxColumn)AddControl(new Guid("b44b5c51-593b-4063-8748-db2d68a933d7"));
            PeriodUnit = (ITTTextBoxColumn)AddControl(new Guid("cb6040e4-604b-4ac2-92f5-214eb55495ba"));
            PeriodUnitType = (ITTEnumComboBoxColumn)AddControl(new Guid("81139096-c617-4eaa-94a6-828b6f0792e2"));
            StuffUsageType = (ITTListBoxColumn)AddControl(new Guid("39618011-6fa0-40fd-96f4-c6ab316a30d6"));
            OdyometryTestId = (ITTTextBoxColumn)AddControl(new Guid("df7e7abe-39ba-4da8-a624-a49524d7e220"));
            StuffUseofPlace = (ITTListBoxColumn)AddControl(new Guid("948df74a-a02f-4383-9a42-cc48e899206f"));
            StuffDescription = (ITTTextBoxColumn)AddControl(new Guid("7f2f9915-0089-49a5-a2f3-880d2c058ae9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d9df1983-a67e-4447-9d4b-2c369eec27ec"));
            MedicalStuffList = (ITTObjectListBox)AddControl(new Guid("a58de2d8-f53e-4e2f-bb04-ddbeb78d9130"));
            chkFtrHeyetRaporu = (ITTCheckBox)AddControl(new Guid("1f45fcd1-0fd7-4914-8596-183f4e82d041"));
            lstTabip3 = (ITTObjectListBox)AddControl(new Guid("ec3f531f-0583-4eb3-9220-e1d7de8d79ca"));
            lblTabip3 = (ITTLabel)AddControl(new Guid("3b58ca28-7231-4155-a281-847557f5ba66"));
            lblTabip2 = (ITTLabel)AddControl(new Guid("3217ed3f-9e2a-4537-850d-df0da1d74fd2"));
            lstTabip2 = (ITTObjectListBox)AddControl(new Guid("23c48248-cbcf-4b7a-b4f5-013a99663111"));
            base.InitializeControls();
        }

        public MedicalStuffReportForm() : base("MEDICALSTUFFREPORT", "MedicalStuffReportForm")
        {
        }

        protected MedicalStuffReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}