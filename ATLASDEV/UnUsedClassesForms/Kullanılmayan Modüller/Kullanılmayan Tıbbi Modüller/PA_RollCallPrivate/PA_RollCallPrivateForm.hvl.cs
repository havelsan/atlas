
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
    /// Yoklama Eri Kabulü
    /// </summary>
    public partial class PA_RollCallPrivateForm : PatientAdmissionForm
    {
    /// <summary>
    /// Yoklama Eri Kabul 
    /// </summary>
        protected TTObjectClasses.PA_RollCallPrivate _PA_RollCallPrivate
        {
            get { return (TTObjectClasses.PA_RollCallPrivate)_ttObject; }
        }

        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker DocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelMilitaryOffice;
        protected ITTObjectListBox MilitaryOffice;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttlabel5 = (ITTLabel)AddControl(new Guid("64bc52e9-53c6-4958-89a4-179bedff3b6b"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("09687618-4b50-43cf-b274-3c057899ecf3"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("e666180f-62d5-40c0-a901-4029bb81f4ba"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("6f83449e-510d-4c26-ae1b-b07460e7abf7"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("6c3b472c-9325-4faf-a15c-c5c6eb83bbf7"));
            labelMilitaryOffice = (ITTLabel)AddControl(new Guid("38dbe277-3708-4115-af93-eb279185c184"));
            MilitaryOffice = (ITTObjectListBox)AddControl(new Guid("e42a1165-a23a-4ea7-872a-ecab3891c259"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a091c553-0a7a-45f5-a574-f4b23d23d9bd"));
            base.InitializeControls();
        }

        public PA_RollCallPrivateForm() : base("PA_ROLLCALLPRIVATE", "PA_RollCallPrivateForm")
        {
        }

        protected PA_RollCallPrivateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}