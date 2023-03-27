
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
    /// Planlı Görev
    /// </summary>
    public partial class ScheduledTaskBaseForm : TTForm
    {
        protected TTObjectClasses.BaseScheduledTask _BaseScheduledTask
        {
            get { return (TTObjectClasses.BaseScheduledTask)_ttObject; }
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
            btnRun = (ITTButton)AddControl(new Guid("05beae87-cb12-48c3-a5b7-f21f27bc5366"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("5c7a6438-8c93-41c0-b934-4a75c07065fd"));
            HistoryTabPage = (ITTTabPage)AddControl(new Guid("199a1712-6461-41d6-93c8-c360ae978c41"));
            GetHistoryButton = (ITTButton)AddControl(new Guid("5dc86830-f5ea-4a4e-8265-7dc3a23a1748"));
            HistoryStartDate = (ITTDateTimePicker)AddControl(new Guid("0f1c1fea-7b80-43d6-b992-4027175920dd"));
            ScheduledTaskHistories = (ITTGrid)AddControl(new Guid("467e3f5b-bc2b-476a-9ea4-0031654fd670"));
            LogDateScheduledTaskHistory = (ITTDateTimePickerColumn)AddControl(new Guid("a9e5909f-bf34-4f80-966d-7ea0a56d9d10"));
            LogScheduledTaskHistory = (ITTTextBoxColumn)AddControl(new Guid("d73f13f6-44c8-45a0-857a-1e6b3bf11e97"));
            HistoryEndDate = (ITTDateTimePicker)AddControl(new Guid("a87b01ce-1cc1-45d7-b0f9-8a19bee85687"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f5008566-8b95-4a4a-9b92-7837a7909c29"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6550992a-118a-4dc4-a956-d86eed88a4d9"));
            TaskName = (ITTTextBox)AddControl(new Guid("daff6299-75e7-458c-8a98-0e2dfead1486"));
            Recurrency = (ITTTextBox)AddControl(new Guid("8fa61cbe-9830-460e-927d-7ba87ae20367"));
            lblExecutionCount = (ITTLabel)AddControl(new Guid("0b96a9b0-b396-456f-9e17-230f1e6a5320"));
            NoEndDate = (ITTCheckBox)AddControl(new Guid("a53032b5-5a01-41ce-b17a-9d89af372e7b"));
            txtWorhHour = (ITTMaskedTextBox)AddControl(new Guid("ce1bb56c-72b0-4aae-89ba-832b6967ac92"));
            labelWorhHour = (ITTLabel)AddControl(new Guid("7e996053-a016-43bf-bca2-3ce07f6ed157"));
            labelTaskName = (ITTLabel)AddControl(new Guid("b5ab1589-df82-41bb-804a-049a5f253d20"));
            labelStartDate = (ITTLabel)AddControl(new Guid("fe6798c0-cf5b-4cb1-933e-dbf4a7295fcf"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("5198d4d3-e817-4161-8593-df173702fc45"));
            labelRecurrency = (ITTLabel)AddControl(new Guid("015ef976-3f43-481e-a27d-c212a7a5a8e3"));
            labelPeriod = (ITTLabel)AddControl(new Guid("2b63c354-0f2c-4ad5-b398-d0d48f3905c1"));
            Period = (ITTEnumComboBox)AddControl(new Guid("7abed190-682e-426f-bb9f-00964197be08"));
            Active = (ITTCheckBox)AddControl(new Guid("b5c0e1d6-e594-412d-ad77-88eb126ae03a"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("0aa7b6ce-62b6-4544-be2c-6898a55e8567"));
            labelEndDate = (ITTLabel)AddControl(new Guid("8f2a7d3c-f176-4463-acd3-b97745073fdc"));
            ttmaskedtextbox1 = (ITTMaskedTextBox)AddControl(new Guid("61351595-f3eb-49fd-ae76-d8bd30cbc398"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2f4aeb5f-5567-4e0e-abac-d8b7ee6b009b"));
            base.InitializeControls();
        }

        public ScheduledTaskBaseForm() : base("BASESCHEDULEDTASK", "ScheduledTaskBaseForm")
        {
        }

        protected ScheduledTaskBaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}