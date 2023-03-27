
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
    public partial class LaboratoryResultsReportForm : TTUnboundForm
    {
        protected ITTListView ttPatientList;
        protected ITTGroupBox ttgroupboxPatient;
        protected ITTLabel ttlabelPatientSurname;
        protected ITTLabel ttlabelPatientName;
        protected ITTLabel ttlabelUniquerefno;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTListView ttActionDetails;
        protected ITTButton ttbuttonSearch;
        protected ITTListView ttActionList;
        protected ITTTextBox ttBarcode;
        protected ITTTextBox ttUniquerefNo;
        protected ITTCheckBox ttReportPreviewCheck;
        protected ITTLabel ttlabel1;
        protected ITTButton ttPrint;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttPatientList = (ITTListView)AddControl(new Guid("795ddfca-d156-41b3-9283-a789908869f9"));
            ttgroupboxPatient = (ITTGroupBox)AddControl(new Guid("a8644e3b-4577-4629-97f3-da326c58c469"));
            ttlabelPatientSurname = (ITTLabel)AddControl(new Guid("4f737e97-a53b-47d9-b39d-7e84aa520090"));
            ttlabelPatientName = (ITTLabel)AddControl(new Guid("e4a02a71-d2a6-4bb5-a4ae-8e464b5a5d10"));
            ttlabelUniquerefno = (ITTLabel)AddControl(new Guid("beee730a-9f9e-4f19-a1db-5e3897e6681c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("8059fa1c-1886-4295-a804-064877467249"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4024ec72-005f-4d5e-afe4-dc33f97693ab"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1208c839-d47d-4d0e-a8be-47abe9d16807"));
            ttActionDetails = (ITTListView)AddControl(new Guid("60f67751-0837-42d9-976b-2080d84fd28d"));
            ttbuttonSearch = (ITTButton)AddControl(new Guid("0ff62c75-88e6-47d5-84d0-54dcfe76a1a5"));
            ttActionList = (ITTListView)AddControl(new Guid("26e30e88-d088-4c8e-9adf-ca2d476e2ab2"));
            ttBarcode = (ITTTextBox)AddControl(new Guid("a7ab367b-463b-4002-8018-9d7385154852"));
            ttUniquerefNo = (ITTTextBox)AddControl(new Guid("8336ba3f-6fba-489c-ae52-5b0d6caa4110"));
            ttReportPreviewCheck = (ITTCheckBox)AddControl(new Guid("6536f27f-60e4-4490-892e-88723ba91d1f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("91db9706-9a07-4fc2-87ef-77eef4a57716"));
            ttPrint = (ITTButton)AddControl(new Guid("c0b78f0d-f675-47d8-96d5-0048dc9f84eb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("671a4750-5074-4f51-8714-f782586143b7"));
            base.InitializeControls();
        }

        public LaboratoryResultsReportForm() : base("LaboratoryResultsReportForm")
        {
        }

        protected LaboratoryResultsReportForm(string formDefName) : base(formDefName)
        {
        }
    }
}