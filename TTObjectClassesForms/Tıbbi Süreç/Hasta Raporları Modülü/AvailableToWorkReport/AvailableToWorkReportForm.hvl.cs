
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
    /// Hizmet Akdiyle Çalışanlar İçin Çalışabilir Kağıdı
    /// </summary>
    public partial class AvailableToWorkReportForm : EpisodeActionForm
    {
    /// <summary>
    /// Hizmet Akdiyle Çalışanlar İçin Çlışabilir Kağıdının Yazıldığı Temel Nesnedir 
    /// </summary>
        protected TTObjectClasses.AvailableToWorkReport _AvailableToWorkReport
        {
            get { return (TTObjectClasses.AvailableToWorkReport)_ttObject; }
        }

        protected ITTObjectListBox Doctor;
        protected ITTDateTimePicker TreatmentTerminationDate;
        protected ITTLabel labelTreatmentTerminationDate;
        protected ITTDateTimePicker Vdate;
        protected ITTTextBox Serial;
        protected ITTTextBox PoliclinicSequenceNo;
        protected ITTTextBox No;
        protected ITTTextBox Analysis;
        protected ITTTextBox tttextbox7;
        protected ITTTextBox tttextbox8;
        protected ITTLabel labelSerial;
        protected ITTLabel labelPoliclinicSequenceNo;
        protected ITTLabel labelNo;
        protected ITTLabel labelVdate;
        protected ITTLabel labelAnalysis;
        protected ITTLabel labelTreatment;
        protected ITTLabel labelDispatch;
        protected ITTLabel labelProperWorkDate;
        protected ITTDateTimePicker ProperWorkDate;
        protected ITTLabel labelDoctor;
        override protected void InitializeControls()
        {
            Doctor = (ITTObjectListBox)AddControl(new Guid("4d30a23d-db35-4143-987f-274dd602ba44"));
            TreatmentTerminationDate = (ITTDateTimePicker)AddControl(new Guid("70b9c426-e242-4c2a-99cc-5ea2071ffaa2"));
            labelTreatmentTerminationDate = (ITTLabel)AddControl(new Guid("a08804f4-2e4a-495c-bdf4-5213acb2b5a3"));
            Vdate = (ITTDateTimePicker)AddControl(new Guid("77ef3a82-7a08-4e92-91d2-97b3581ae594"));
            Serial = (ITTTextBox)AddControl(new Guid("4ae33d23-4d83-483c-b3b7-39333d22cea2"));
            PoliclinicSequenceNo = (ITTTextBox)AddControl(new Guid("06007dd3-8f5c-495d-9ae0-a83c26e45468"));
            No = (ITTTextBox)AddControl(new Guid("46d2dfd9-5fd8-4836-bb5f-8d2903827c5b"));
            Analysis = (ITTTextBox)AddControl(new Guid("57ca2549-bf29-48e7-b3dd-f7aba1030f74"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("904662a7-277c-48b8-ad4f-f6f58c981ccf"));
            tttextbox8 = (ITTTextBox)AddControl(new Guid("f2bc3787-9d89-4ae3-93ee-f92a191189a5"));
            labelSerial = (ITTLabel)AddControl(new Guid("a87929da-018a-470c-aed0-2da1c15a9549"));
            labelPoliclinicSequenceNo = (ITTLabel)AddControl(new Guid("b5d7b4c8-d852-4a2d-8e03-d3bbc87b6a58"));
            labelNo = (ITTLabel)AddControl(new Guid("1bb15cb4-e1ec-4308-bf9a-8b3ae4ce7513"));
            labelVdate = (ITTLabel)AddControl(new Guid("7a9fea31-2227-421f-9344-25bde0bd1d29"));
            labelAnalysis = (ITTLabel)AddControl(new Guid("71136f3d-3f61-4adb-a679-89077d8db389"));
            labelTreatment = (ITTLabel)AddControl(new Guid("3a0ebcd8-3532-4ce3-be3b-0c0ed1130df0"));
            labelDispatch = (ITTLabel)AddControl(new Guid("d0c2395d-f4ea-4259-b4c1-dbbe9e5418e8"));
            labelProperWorkDate = (ITTLabel)AddControl(new Guid("4c05b827-752d-41ac-b3d9-dc9d6e01db60"));
            ProperWorkDate = (ITTDateTimePicker)AddControl(new Guid("a4cd14c0-70b1-420d-8192-ddc33d22b24b"));
            labelDoctor = (ITTLabel)AddControl(new Guid("c0b414e1-a8c3-471d-8451-e154ec2d581c"));
            base.InitializeControls();
        }

        public AvailableToWorkReportForm() : base("AVAILABLETOWORKREPORT", "AvailableToWorkReportForm")
        {
        }

        protected AvailableToWorkReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}