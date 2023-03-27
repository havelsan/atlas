
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
    /// Hemşireye Emirler
    /// </summary>
    public partial class NursingOrderForm : TTForm
    {
    /// <summary>
    /// Hemşire Takip Gözlem Talimatları (Klinik İşlemleri) 'nin Gerçekleştirildiği Nesnedir
    /// </summary>
        protected TTObjectClasses.NursingOrder _NursingOrder
        {
            get { return (TTObjectClasses.NursingOrder)_ttObject; }
        }

        protected ITTLabel ttlabel;
        protected ITTEnumComboBox Frequency;
        protected ITTTextBox RecurrenceDayAmount;
        protected ITTLabel labelRecurrenceDayAmount;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker PeriodStartTime;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelOrderDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage NursingOrderDetailTab;
        protected ITTGrid OrderDetails;
        protected ITTDateTimePickerColumn nWorklistdate;
        protected ITTDateTimePickerColumn nExecutionDate;
        protected ITTListBoxColumn nProcedureObject;
        protected ITTTextBoxColumn nResult;
        protected ITTTextBoxColumn nNote;
        protected ITTStateComboBoxColumn State;
        protected ITTTextBoxColumn ReasonOfCanceled;
        protected ITTTextBox AmountForPeriod;
        protected ITTLabel labelAmountForPeriod;
        override protected void InitializeControls()
        {
            ttlabel = (ITTLabel)AddControl(new Guid("6e2617c2-abcf-402c-a62f-18f8dd921f13"));
            Frequency = (ITTEnumComboBox)AddControl(new Guid("8d93a8a3-a84f-4669-bb03-c90c35fdba14"));
            RecurrenceDayAmount = (ITTTextBox)AddControl(new Guid("be349f4b-fee4-4948-ad84-05d51e289a0d"));
            labelRecurrenceDayAmount = (ITTLabel)AddControl(new Guid("c84cedbe-36d8-4cf3-b3ce-d42a8361db7d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("02384860-b9d0-4481-a58f-554ae188d246"));
            PeriodStartTime = (ITTDateTimePicker)AddControl(new Guid("18c40701-355e-4744-a970-0c17ce0c92dd"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("5fff2223-0cdc-431c-b655-48e5112c107d"));
            labelProcedure = (ITTLabel)AddControl(new Guid("61957b3f-9a7a-42f5-9e1b-54316f9453b1"));
            labelOrderDate = (ITTLabel)AddControl(new Guid("bd1291f4-04f3-4da3-b0a8-bb9e26d3ce5d"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("07e6d992-eea1-4b4a-8cc1-e158cb2ad24e"));
            NursingOrderDetailTab = (ITTTabPage)AddControl(new Guid("671ca1f8-9afb-4f0b-a5be-d240aea13bd9"));
            OrderDetails = (ITTGrid)AddControl(new Guid("796b964d-800a-47e3-acda-d694bbfd7835"));
            nWorklistdate = (ITTDateTimePickerColumn)AddControl(new Guid("3e450921-7075-4684-a645-cbaeee8ab8e4"));
            nExecutionDate = (ITTDateTimePickerColumn)AddControl(new Guid("2f9fb6ff-d9ea-4471-a671-7453e0c9a74c"));
            nProcedureObject = (ITTListBoxColumn)AddControl(new Guid("63f3864e-f155-41c9-8e74-a2c324226c8d"));
            nResult = (ITTTextBoxColumn)AddControl(new Guid("ce74f78f-2229-4216-9062-b1e32f25901b"));
            nNote = (ITTTextBoxColumn)AddControl(new Guid("86974fdd-c431-4037-b14e-88e5282aa795"));
            State = (ITTStateComboBoxColumn)AddControl(new Guid("6cf0e361-2b46-471e-ad54-3baf60f733a8"));
            ReasonOfCanceled = (ITTTextBoxColumn)AddControl(new Guid("3eb6ab01-0e6e-4494-a9fb-b281a49eee82"));
            AmountForPeriod = (ITTTextBox)AddControl(new Guid("3ffcb0ea-5e84-492b-880c-ebb291a1bc81"));
            labelAmountForPeriod = (ITTLabel)AddControl(new Guid("8a4fd37f-15b7-4add-ab44-f81b7d422150"));
            base.InitializeControls();
        }

        public NursingOrderForm() : base("NURSINGORDER", "NursingOrderForm")
        {
        }

        protected NursingOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}