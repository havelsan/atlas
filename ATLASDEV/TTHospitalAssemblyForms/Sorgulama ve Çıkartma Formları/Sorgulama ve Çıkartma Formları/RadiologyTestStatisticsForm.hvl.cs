
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
    public partial class RadiologyTestStatisticsForm : TTUnboundForm
    {
        protected ITTGroupBox ttgroupbox1;
        protected ITTDateTimePicker txtReportDateMin;
        protected ITTDateTimePicker txtReportDateMax;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox txtTestDef;
        protected ITTTextBox txtReport;
        protected ITTButton cmdList;
        protected ITTGrid TestsGrid;
        protected ITTTextBoxColumn PatientID;
        protected ITTTextBoxColumn NameSurname;
        protected ITTDateTimePickerColumn BirthDate;
        protected ITTTextBoxColumn EpisodePatientStatus;
        protected ITTTextBoxColumn PatientGroup;
        protected ITTTextBoxColumn TestCode;
        protected ITTTextBoxColumn TestName;
        protected ITTTextBoxColumn RequestDoctor;
        protected ITTTextBoxColumn FromResource;
        protected ITTTextBoxColumn ReportedBy;
        protected ITTDateTimePickerColumn ReportDate;
        protected ITTTextBoxColumn Report;
        protected ITTButtonColumn PrintReport;
        protected ITTTextBoxColumn RadiologyTestObjectID;
        protected ITTLabel lblReport;
        protected ITTLabel txtListedProceduresCountlabel;
        protected ITTLabel labelRadiologyTestCount;
        protected ITTButton cmdExportToExcel;
        protected ITTObjectListBox txtRequestDoctor;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox txtReportedBy;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox txtFromResource;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("d8d21b0b-bbce-44f1-97e0-0f68c27b5d8c"));
            txtReportDateMin = (ITTDateTimePicker)AddControl(new Guid("12b41617-cc36-45bc-bb40-1d6adba9a300"));
            txtReportDateMax = (ITTDateTimePicker)AddControl(new Guid("8a0bee95-1338-4a30-bf0f-b8e0daa89261"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("fb42f71d-61fc-4e0e-8eea-c281844a24a8"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("34a78d73-5648-4871-9b37-df8ce1813b8a"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("4c95bebd-6a49-4f35-8150-02b31ee68d34"));
            txtTestDef = (ITTObjectListBox)AddControl(new Guid("29b08283-2b9c-4353-a4c0-0cc75b6a859c"));
            txtReport = (ITTTextBox)AddControl(new Guid("7db66376-58dc-4423-b03f-0d23077d7ea9"));
            cmdList = (ITTButton)AddControl(new Guid("98bcf9bd-9900-4dbd-846e-431795dcb0ca"));
            TestsGrid = (ITTGrid)AddControl(new Guid("e3175922-3740-4b14-8d94-392c4c4cc821"));
            PatientID = (ITTTextBoxColumn)AddControl(new Guid("c306f9b7-682b-4cda-9f4d-33c7bdd0a538"));
            NameSurname = (ITTTextBoxColumn)AddControl(new Guid("037848cc-8a6b-44b1-812c-c84cbdc74bee"));
            BirthDate = (ITTDateTimePickerColumn)AddControl(new Guid("d8b971d4-7155-4a1c-abf9-255a3b522e5a"));
            EpisodePatientStatus = (ITTTextBoxColumn)AddControl(new Guid("513126ec-76b9-487a-b058-b63e4913bd3e"));
            PatientGroup = (ITTTextBoxColumn)AddControl(new Guid("382d8f14-dcc1-4dcc-92f8-9964b8c9e890"));
            TestCode = (ITTTextBoxColumn)AddControl(new Guid("9f92850b-0381-4082-9fdd-5327170cf165"));
            TestName = (ITTTextBoxColumn)AddControl(new Guid("ef915d89-0197-4037-a548-e56bb2b353a8"));
            RequestDoctor = (ITTTextBoxColumn)AddControl(new Guid("80645f89-8f89-4fb4-8372-1007f1e773c2"));
            FromResource = (ITTTextBoxColumn)AddControl(new Guid("2d3db4dd-8ac1-4257-b27b-9bec6a4dd6c1"));
            ReportedBy = (ITTTextBoxColumn)AddControl(new Guid("dc620bc5-00fc-4822-82d2-ac3543cc4373"));
            ReportDate = (ITTDateTimePickerColumn)AddControl(new Guid("ed9d9f98-0e53-4e2a-bce6-8a9e52d1ee2f"));
            Report = (ITTTextBoxColumn)AddControl(new Guid("7fd09b3c-309c-490c-8886-e2d7a10e6287"));
            PrintReport = (ITTButtonColumn)AddControl(new Guid("0b59e118-d5d3-4507-a1c3-c0df7d2489f5"));
            RadiologyTestObjectID = (ITTTextBoxColumn)AddControl(new Guid("1b7d464d-5c5e-4019-bb40-a27c6175f3b1"));
            lblReport = (ITTLabel)AddControl(new Guid("90dffa42-84aa-4786-afdc-b8910cf5954d"));
            txtListedProceduresCountlabel = (ITTLabel)AddControl(new Guid("641543b1-584c-42b6-ab51-287f92a56af2"));
            labelRadiologyTestCount = (ITTLabel)AddControl(new Guid("a188b43b-b48d-440e-b998-05028deb56c3"));
            cmdExportToExcel = (ITTButton)AddControl(new Guid("c50bf471-ca89-409a-a92c-71622548fdcf"));
            txtRequestDoctor = (ITTObjectListBox)AddControl(new Guid("8043cc61-22ca-44d7-9544-8b1b473afa0d"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("5af4b8a5-0057-4207-a7ca-ebf8975d8440"));
            txtReportedBy = (ITTObjectListBox)AddControl(new Guid("49e731c0-73a8-4969-810c-ab98a9e89332"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("49fb7a35-bd40-46d5-a28e-b69ae173f628"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("edb9492a-f489-4e7a-9334-f5662a2d2556"));
            txtFromResource = (ITTObjectListBox)AddControl(new Guid("2bcd2bf9-ce6d-47b2-a690-00f1c77d6b26"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("73007327-9dac-46e9-af57-cb767a952adb"));
            base.InitializeControls();
        }

        public RadiologyTestStatisticsForm() : base("RadiologyTestStatisticsForm")
        {
        }

        protected RadiologyTestStatisticsForm(string formDefName) : base(formDefName)
        {
        }
    }
}