
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
    /// XXXXXX Sivil Memur Adayı Kabulü
    /// </summary>
    public partial class PA_MilitaryCivilOfficialCandidateForm : PatientAdmissionForm
    {
    /// <summary>
    /// XXXXXX Sivil Memur Adayı Kabul 
    /// </summary>
        protected TTObjectClasses.PA_MilitaryCivilOfficialCandidate _PA_MilitaryCivilOfficialCandidate
        {
            get { return (TTObjectClasses.PA_MilitaryCivilOfficialCandidate)_ttObject; }
        }

        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker DocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelSenderChair;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox MilitaryClass;
        override protected void InitializeControls()
        {
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("a9d979e3-162b-467d-8db5-87e39217f967"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("87bf3da1-5e19-43d3-aa03-2df8c525c8a8"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("77074056-7e68-4960-8a65-048b6001148e"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("20b00499-4041-4042-8a3f-151ab7546a06"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5e8aa3c4-faae-401e-bafd-273a38292829"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("6f281d79-92f3-4bfa-9b17-2fff8d7fb147"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("e13da54c-c687-4979-9746-c43ff67528f8"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("3755df65-13d1-49f1-bb38-cb2d0e276bb1"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e6308a05-54dd-4ed4-856c-d2dcb5ed49b3"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("c4fd4605-bd1b-451a-a4f4-f37082b42046"));
            base.InitializeControls();
        }

        public PA_MilitaryCivilOfficialCandidateForm() : base("PA_MILITARYCIVILOFFICIALCANDIDATE", "PA_MilitaryCivilOfficialCandidateForm")
        {
        }

        protected PA_MilitaryCivilOfficialCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}