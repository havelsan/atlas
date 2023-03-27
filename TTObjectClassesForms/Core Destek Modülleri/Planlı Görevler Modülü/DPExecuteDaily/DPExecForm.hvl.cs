
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
    public partial class DPExecForm : TTForm
    {
        protected TTObjectClasses.DPExecuteDaily _DPExecuteDaily
        {
            get { return (TTObjectClasses.DPExecuteDaily)_ttObject; }
        }

        protected ITTButton btnRun;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage HistoryTabPage;
        protected ITTButton GetHistoryButton;
        protected ITTDateTimePicker HistoryStartDate;
        protected ITTGrid ScheduledTaskHistories;
        protected ITTDateTimePickerColumn LogDateScheduledTaskHistory;
        protected ITTTextBoxColumn LogScheduledTaskHistory;
        protected ITTDateTimePicker HistoryEndDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTTextBox TaskName;
        protected ITTTextBox Recurrency;
        protected ITTLabel lblExecutionCount;
        protected ITTCheckBox NoEndDate;
        protected ITTMaskedTextBox txtWorhHour;
        protected ITTLabel labelWorhHour;
        protected ITTLabel labelTaskName;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelRecurrency;
        protected ITTLabel labelPeriod;
        protected ITTEnumComboBox Period;
        protected ITTCheckBox Active;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelEndDate;
        protected ITTMaskedTextBox ttmaskedtextbox1;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            btnRun = (ITTButton)AddControl(new Guid("b979add2-5faa-478f-b012-41d2a1cb9dab"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("b7e30c75-3d08-4aed-90c0-11ba050d7a91"));
            HistoryTabPage = (ITTTabPage)AddControl(new Guid("df40b5ac-f8f1-49be-afd1-2abef086e430"));
            GetHistoryButton = (ITTButton)AddControl(new Guid("366d993c-e9fb-4f66-9e79-d9ce5065fea2"));
            HistoryStartDate = (ITTDateTimePicker)AddControl(new Guid("e2c41c34-1367-4e28-8468-4c5635c22ebf"));
            ScheduledTaskHistories = (ITTGrid)AddControl(new Guid("e50a0c54-879e-491a-aeef-441ca98bcfaf"));
            LogDateScheduledTaskHistory = (ITTDateTimePickerColumn)AddControl(new Guid("426245cb-aecb-4184-b87c-1b7ef97ad753"));
            LogScheduledTaskHistory = (ITTTextBoxColumn)AddControl(new Guid("433871f6-24fb-44f5-94b1-60562b0e7fb1"));
            HistoryEndDate = (ITTDateTimePicker)AddControl(new Guid("0c703083-4ed3-45ef-9fae-7f69dcc00cbf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4f357766-5093-4dc5-b762-85c64fd4b6db"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1f427b0e-86ba-4e0a-ba70-23c620a0182c"));
            TaskName = (ITTTextBox)AddControl(new Guid("4d3b8d7a-f148-4def-9012-f8727ad778b7"));
            Recurrency = (ITTTextBox)AddControl(new Guid("f230ee28-796a-4514-b4dc-b9eb00942fa4"));
            lblExecutionCount = (ITTLabel)AddControl(new Guid("21638d07-80d9-403f-819e-fb8738807711"));
            NoEndDate = (ITTCheckBox)AddControl(new Guid("c683268d-7da6-43ea-b7b3-0dca3cdc8321"));
            txtWorhHour = (ITTMaskedTextBox)AddControl(new Guid("20ec6627-a8d8-4633-932f-baae8257a7dc"));
            labelWorhHour = (ITTLabel)AddControl(new Guid("7e6d8e71-0f64-49f0-abe0-dd3c2f0e21a8"));
            labelTaskName = (ITTLabel)AddControl(new Guid("17ad4cd5-3b47-49da-8dc9-c5bfe36c13e7"));
            labelStartDate = (ITTLabel)AddControl(new Guid("60e0f075-902c-4c06-b823-1ef134a7a1e8"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("c2e2c3ab-a0af-411a-a2a0-dd5d0e9aa6af"));
            labelRecurrency = (ITTLabel)AddControl(new Guid("feaf9de9-769c-476f-bdb3-650f4ddecfd9"));
            labelPeriod = (ITTLabel)AddControl(new Guid("85bf595c-9ef0-4064-89c3-834e2269e436"));
            Period = (ITTEnumComboBox)AddControl(new Guid("ee156780-e882-4eaf-8aea-e41b6a83ba4f"));
            Active = (ITTCheckBox)AddControl(new Guid("b130e2d2-201e-4a1c-951b-5ccd87683042"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("d01bc274-afe4-4f68-a633-7a8dca371a58"));
            labelEndDate = (ITTLabel)AddControl(new Guid("b5715177-a9cf-401c-815f-ab3a77b5fabb"));
            ttmaskedtextbox1 = (ITTMaskedTextBox)AddControl(new Guid("9557a208-e4dc-4719-bb7c-14e00f67ee4f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("56fe008a-d1e5-4b13-a00a-629d4b727de0"));
            base.InitializeControls();
        }

        public DPExecForm() : base("DPEXECUTEDAILY", "DPExecForm")
        {
        }

        protected DPExecForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}