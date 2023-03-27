
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
    /// Bakımevi
    /// </summary>
    public partial class DispensaryRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Bakımevi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Dispensary _Dispensary
        {
            get { return (TTObjectClasses.Dispensary)_ttObject; }
        }

        protected ITTRichTextBoxControl LastEvents;
        protected ITTTextBox txtProtocolNo;
        protected ITTTextBox GhaziDiagnosis;
        protected ITTTextBox NumberOfStayDays;
        protected ITTTextBox NumberOfLastStayDays;
        protected ITTTextBox ReasonForStay;
        protected ITTLabel lblProtocolNo;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelNumberOfStayDays;
        protected ITTCheckBox IsCompanionNeeded;
        protected ITTLabel labelReasonForStay;
        protected ITTLabel labelNumberOfLastStayDays;
        protected ITTLabel labelGhaziDiagnosis;
        override protected void InitializeControls()
        {
            LastEvents = (ITTRichTextBoxControl)AddControl(new Guid("0df66f77-142e-4719-83f0-45360bfd6568"));
            txtProtocolNo = (ITTTextBox)AddControl(new Guid("20acda00-a41f-4ce3-9b88-6542aed026b0"));
            GhaziDiagnosis = (ITTTextBox)AddControl(new Guid("5d4bb422-5417-4f7e-8466-14970301fc89"));
            NumberOfStayDays = (ITTTextBox)AddControl(new Guid("23544153-7c68-43cc-bcbe-35effa40467b"));
            NumberOfLastStayDays = (ITTTextBox)AddControl(new Guid("e70591dc-4d0d-472c-bea8-5236ac49f497"));
            ReasonForStay = (ITTTextBox)AddControl(new Guid("81a2cc13-5e13-4dd2-ad9a-7a3fdde42dd3"));
            lblProtocolNo = (ITTLabel)AddControl(new Guid("5aa93913-92fe-4341-bc67-6b553208a7cd"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("e1909987-4e3d-4611-adc0-7ca07547d24a"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("6a5a05ae-b9f2-450c-b6f2-6ab085216c93"));
            labelNumberOfStayDays = (ITTLabel)AddControl(new Guid("b70db1c1-52fb-424f-8b4c-16e884ad242e"));
            IsCompanionNeeded = (ITTCheckBox)AddControl(new Guid("0ef0000f-751a-4eb5-8dac-608a548c14a8"));
            labelReasonForStay = (ITTLabel)AddControl(new Guid("d53ff965-dd60-4665-92e3-66cd2a647649"));
            labelNumberOfLastStayDays = (ITTLabel)AddControl(new Guid("377e2919-92c5-423d-bd39-919c123d76b9"));
            labelGhaziDiagnosis = (ITTLabel)AddControl(new Guid("0b1bad0f-3be4-43e6-b40e-f38de6c2c581"));
            base.InitializeControls();
        }

        public DispensaryRequestForm() : base("DISPENSARY", "DispensaryRequestForm")
        {
        }

        protected DispensaryRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}