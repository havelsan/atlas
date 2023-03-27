
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
    /// Sevke Tabi Yedek Subay Aday Adayı Kabulü
    /// </summary>
    public partial class PA_ConsignmentReserveOfficerCandidateForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sevke Tabi Yedek Subay Aday  Adayı Kabul 
    /// </summary>
        protected TTObjectClasses.PA_ConsignmentReserveOfficerCandidate _PA_ConsignmentReserveOfficerCandidate
        {
            get { return (TTObjectClasses.PA_ConsignmentReserveOfficerCandidate)_ttObject; }
        }

        protected ITTLabel labelDocumentNumber;
        protected ITTObjectListBox MilitaryOffice;
        protected ITTLabel labelMilitaryOffice;
        protected ITTLabel labelSenderChair;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox SenderChair;
        override protected void InitializeControls()
        {
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("497ebad2-5669-4f35-9f46-447664845e9f"));
            MilitaryOffice = (ITTObjectListBox)AddControl(new Guid("1e18043c-5bb2-4cff-8426-69e0ff637bf8"));
            labelMilitaryOffice = (ITTLabel)AddControl(new Guid("084304c2-9e57-4a0c-8b04-8ea12a29d23d"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("0886f27c-6c3e-4254-8a90-a47af2b4ebab"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("4dee5ca4-2168-4509-960d-b4a6bc4461fe"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("65510373-8687-4e3a-9979-e3dcbdf6d677"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("145ff8b9-e047-4ff4-bde9-e5c3ae94b5f1"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("6cd4adc4-7330-41f4-b4d8-f5d63b6e3d12"));
            base.InitializeControls();
        }

        public PA_ConsignmentReserveOfficerCandidateForm() : base("PA_CONSIGNMENTRESERVEOFFICERCANDIDATE", "PA_ConsignmentReserveOfficerCandidateForm")
        {
        }

        protected PA_ConsignmentReserveOfficerCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}