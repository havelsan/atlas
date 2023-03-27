
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
    /// Hizmet Talimat/İstek
    /// </summary>
    public partial class ProcedureOrderForm : TTForm
    {
    /// <summary>
    /// Hizmet Talimat/İstek
    /// </summary>
        protected TTObjectClasses.ProcedureOrder _ProcedureOrder
        {
            get { return (TTObjectClasses.ProcedureOrder)_ttObject; }
        }

        protected ITTTabControl TabSubaction;
        protected ITTTabPage ProcedureOrderDetailTab;
        protected ITTGrid OrderDetails;
        protected ITTDateTimePickerColumn nWorklistdate;
        protected ITTDateTimePickerColumn nExecutionDate;
        protected ITTListBoxColumn nProcedureObject;
        protected ITTTextBoxColumn nResult;
        protected ITTTextBoxColumn nNote;
        protected ITTStateComboBoxColumn State;
        protected ITTTextBoxColumn ReasonOfCanceled;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker PeriodStartTime;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        override protected void InitializeControls()
        {
            TabSubaction = (ITTTabControl)AddControl(new Guid("515e21ca-17e7-4cc3-a5a0-6f625ce586f0"));
            ProcedureOrderDetailTab = (ITTTabPage)AddControl(new Guid("2214b057-804b-4f73-9932-77e215ebdab9"));
            OrderDetails = (ITTGrid)AddControl(new Guid("4c7aa89e-e4cb-488c-9782-12509631eacf"));
            nWorklistdate = (ITTDateTimePickerColumn)AddControl(new Guid("9b4cefc5-a43e-46b6-814b-37d24f10ec9a"));
            nExecutionDate = (ITTDateTimePickerColumn)AddControl(new Guid("386a70bd-fc07-4a50-845d-f2426713573a"));
            nProcedureObject = (ITTListBoxColumn)AddControl(new Guid("a789e249-1571-40f2-93e7-5f78c6c26000"));
            nResult = (ITTTextBoxColumn)AddControl(new Guid("cc9c906e-ff09-4f01-8d86-b6a939d9c20c"));
            nNote = (ITTTextBoxColumn)AddControl(new Guid("0f089b66-09fe-466c-b5cf-393dac270c53"));
            State = (ITTStateComboBoxColumn)AddControl(new Guid("8614553d-f6e0-4e8e-8e78-e16bb2a1ea92"));
            ReasonOfCanceled = (ITTTextBoxColumn)AddControl(new Guid("189dc4c5-1230-46e6-8073-058e13176f09"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("077494b3-94e0-4059-aded-2a9ca285ad7c"));
            PeriodStartTime = (ITTDateTimePicker)AddControl(new Guid("fa9389c1-c5ed-449f-94be-cd6e83c978e3"));
            labelActionDate = (ITTLabel)AddControl(new Guid("abe63586-b426-4bd5-8295-cc00137d93d8"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("d56497af-45dd-4719-ab2d-469fc62b55b5"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("b3a7a916-75bf-4d97-a9fe-0d5b4907f701"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("cbd43294-d6ac-4dbc-a9c5-6e50e3f3f93a"));
            base.InitializeControls();
        }

        public ProcedureOrderForm() : base("PROCEDUREORDER", "ProcedureOrderForm")
        {
        }

        protected ProcedureOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}