
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
    /// Kalibrasyon Prosedür Tanımlama
    /// </summary>
    public partial class CalibrationTestDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.CalibrationTestDefinition _CalibrationTestDefinition
        {
            get { return (TTObjectClasses.CalibrationTestDefinition)_ttObject; }
        }

        protected ITTButton cmdOpenButton;
        protected ITTButton cmdAddButton;
        protected ITTLabel labelApplicableTestCount;
        protected ITTTextBox ApplicableTestCount;
        protected ITTLabel labelProcedureName;
        protected ITTTextBox ProcedureName;
        protected ITTLabel labelProcedureNo;
        protected ITTTextBox ProcedureNo;
        protected ITTLabel labelRevisionNo;
        protected ITTTextBox RevisionNo;
        protected ITTLabel labelApprovalDate;
        protected ITTDateTimePicker ApprovalDate;
        override protected void InitializeControls()
        {
            cmdOpenButton = (ITTButton)AddControl(new Guid("8c0c32f5-4563-40f4-b571-d5e137f184c1"));
            cmdAddButton = (ITTButton)AddControl(new Guid("3221c487-063c-4a43-9cf0-c7f8a4ff70e6"));
            labelApplicableTestCount = (ITTLabel)AddControl(new Guid("afcc6b98-5641-4f14-b3b7-03fa7e3d68a2"));
            ApplicableTestCount = (ITTTextBox)AddControl(new Guid("63c643e9-62ca-4e02-999d-d4f453f3b5b3"));
            labelProcedureName = (ITTLabel)AddControl(new Guid("90fe2f4b-808a-4e8c-8e2c-37ddf0cb30d4"));
            ProcedureName = (ITTTextBox)AddControl(new Guid("7c77be8b-2c21-4f01-a202-8e297b268a01"));
            labelProcedureNo = (ITTLabel)AddControl(new Guid("9b939ca8-7bf7-4635-908a-df4e6365fa17"));
            ProcedureNo = (ITTTextBox)AddControl(new Guid("b2b8e60e-9d4b-46c8-841c-8c51a310beb7"));
            labelRevisionNo = (ITTLabel)AddControl(new Guid("2ac93bae-0a86-4cbc-b942-49ad7fb2d134"));
            RevisionNo = (ITTTextBox)AddControl(new Guid("00cc0ace-21d2-4214-9749-dae5abaf2b95"));
            labelApprovalDate = (ITTLabel)AddControl(new Guid("8b0b80b6-3860-492d-a327-faa1173d5eb7"));
            ApprovalDate = (ITTDateTimePicker)AddControl(new Guid("f467a5c1-3039-45b3-8352-59aabe3cda0f"));
            base.InitializeControls();
        }

        public CalibrationTestDefinitionForm() : base("CALIBRATIONTESTDEFINITION", "CalibrationTestDefinitionForm")
        {
        }

        protected CalibrationTestDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}