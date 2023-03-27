
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
    /// Tıbbi Kurullar
    /// </summary>
    public partial class MCRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Kurul İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.MedicalCommittee _MedicalCommittee
        {
            get { return (TTObjectClasses.MedicalCommittee)_ttObject; }
        }

        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel3;
        protected ITTTextBox TempBox;
        protected ITTTextBox ProtocolNo;
        protected ITTRichTextBoxControl Subject;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox MedicalCommitteType;
        protected ITTLabel labelDepartment;
        protected ITTLabel labelMedicalCommitteType;
        protected ITTObjectListBox Department;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker ttdatetimepicker2;
        override protected void InitializeControls()
        {
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("f093a424-9e2d-4db4-b83c-90ae28b3a8c0"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("6bfdda0c-9049-4102-9eb2-665945810d36"));
            TempBox = (ITTTextBox)AddControl(new Guid("8e4c8721-7053-47ea-ae57-071bd35b8453"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("2b98aa14-0893-49ac-b540-e926efb15227"));
            Subject = (ITTRichTextBoxControl)AddControl(new Guid("641305d7-7ef5-4b3b-b567-164bf69e01e6"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fd7046a1-4ff8-456f-9d1a-16408d994886"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6d7d8cd8-ff15-4dc5-b0b8-3658d1467ce6"));
            MedicalCommitteType = (ITTObjectListBox)AddControl(new Guid("012b48bf-f78b-4fa0-ba9d-2ba2b3905494"));
            labelDepartment = (ITTLabel)AddControl(new Guid("c1c75574-963d-4807-a843-4c5f0ed3918d"));
            labelMedicalCommitteType = (ITTLabel)AddControl(new Guid("176c9ed2-daae-4abb-8d5d-ccf252bc1e27"));
            Department = (ITTObjectListBox)AddControl(new Guid("9bb6b00d-3349-482a-8236-fea2cfd3e040"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("9a84d98f-ff70-428c-81bf-6800d82af18d"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("aefd83de-91f9-4400-b8ad-782dd5a32e92"));
            base.InitializeControls();
        }

        public MCRequestForm() : base("MEDICALCOMMITTEE", "MCRequestForm")
        {
        }

        protected MCRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}