
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
    public partial class NuclearMedicineStatisticsForm : TTUnboundForm
    {
        protected ITTButton cmdList;
        protected ITTGrid TestsGrid;
        protected ITTTextBoxColumn PatientID;
        protected ITTTextBoxColumn NameSurname;
        protected ITTDateTimePickerColumn BirthDate;
        protected ITTRichTextBoxControlColumn Report;
        protected ITTTextBoxColumn FromResource;
        protected ITTDateTimePickerColumn ReportDate;
        protected ITTTextBox txtReport;
        protected ITTLabel lblReport;
        protected ITTLabel txtListedProceduresCountlabel;
        protected ITTLabel labelNuclearMedicineCount;
        protected ITTDateTimePicker txtReportDateMin;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel14;
        protected ITTDateTimePicker txtReportDateMax;
        protected ITTButton cmdExportToExcel;
        override protected void InitializeControls()
        {
            cmdList = (ITTButton)AddControl(new Guid("be326291-df3b-40e1-8f36-34a9e4e4b8f8"));
            TestsGrid = (ITTGrid)AddControl(new Guid("9336a992-3672-40d3-976a-836ebd764f0c"));
            PatientID = (ITTTextBoxColumn)AddControl(new Guid("8a03af33-3868-42c6-9384-bf304ae9108a"));
            NameSurname = (ITTTextBoxColumn)AddControl(new Guid("721d2532-32b1-405a-90db-6d1106819ee7"));
            BirthDate = (ITTDateTimePickerColumn)AddControl(new Guid("1c483b82-c19c-481e-b17f-50eadf7dc3ef"));
            Report = (ITTRichTextBoxControlColumn)AddControl(new Guid("72797bf7-c1ab-452c-9771-968bf60c1133"));
            FromResource = (ITTTextBoxColumn)AddControl(new Guid("a3980b5c-f15d-4404-9074-994dc5aebc2a"));
            ReportDate = (ITTDateTimePickerColumn)AddControl(new Guid("028b14aa-8d70-41ff-ba0e-28c0659d364b"));
            txtReport = (ITTTextBox)AddControl(new Guid("bec108cf-f8fd-4c25-87c8-2e9ac9626352"));
            lblReport = (ITTLabel)AddControl(new Guid("ecb6404e-cea0-49e3-a14c-779ea17145d3"));
            txtListedProceduresCountlabel = (ITTLabel)AddControl(new Guid("4da6ddae-82ab-42e8-99c7-74bd0bd4e165"));
            labelNuclearMedicineCount = (ITTLabel)AddControl(new Guid("a40a20ec-7acb-4ca7-b6b1-39becd8e8832"));
            txtReportDateMin = (ITTDateTimePicker)AddControl(new Guid("8dc3e907-6bc0-4257-8eae-52aecd888f0b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("7f1bd6ee-892c-4b59-a5c4-32c90e8424fc"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("b68d22aa-e0be-473a-acc0-3ce0148b220a"));
            txtReportDateMax = (ITTDateTimePicker)AddControl(new Guid("e82694c8-6ea3-4d93-81e8-dbbeb767028d"));
            cmdExportToExcel = (ITTButton)AddControl(new Guid("c48c26cd-fa78-4436-9a6d-0ee17a12d9a4"));
            base.InitializeControls();
        }

        public NuclearMedicineStatisticsForm() : base("NuclearMedicineStatisticsForm")
        {
        }

        protected NuclearMedicineStatisticsForm(string formDefName) : base(formDefName)
        {
        }
    }
}