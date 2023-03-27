
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
    public partial class MCAcceptForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Kurul İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.MedicalCommittee _MedicalCommittee
        {
            get { return (TTObjectClasses.MedicalCommittee)_ttObject; }
        }

        protected ITTTextBox ProtocolNo;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel2;
        protected ITTRichTextBoxControl Subject;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox MedicalCommitteType;
        protected ITTLabel labelDepartment;
        protected ITTLabel labelMedicalCommitteType;
        protected ITTObjectListBox Department;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker ttdatetimepicker2;
        override protected void InitializeControls()
        {
            ProtocolNo = (ITTTextBox)AddControl(new Guid("5347b017-8d21-44b2-82d7-1b3c4e49c5f5"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("d8eb18ee-af9f-4d36-ab94-5745456b2b4f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("0dd774d3-0450-4ec1-92a3-2f82ed218390"));
            Subject = (ITTRichTextBoxControl)AddControl(new Guid("6ac2ccea-7f4a-4fb7-b4fe-49150cc3be94"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d173ffd6-380f-452d-a29f-342c4eafd911"));
            MedicalCommitteType = (ITTObjectListBox)AddControl(new Guid("1ee47886-eb32-4c27-b35d-e6246c443da5"));
            labelDepartment = (ITTLabel)AddControl(new Guid("4d08181f-a26b-4ea8-a8d1-ada9b4d43e7b"));
            labelMedicalCommitteType = (ITTLabel)AddControl(new Guid("84368877-ecc8-47b4-8340-7a933995514c"));
            Department = (ITTObjectListBox)AddControl(new Guid("61263a00-b61b-4592-86ea-4a56240bd617"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("cb5aefd9-0eb8-4641-83e5-8c7152a69b45"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4b598bce-a02e-49ae-9188-cea3e475a172"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("32c2c58b-7fbf-479c-b92b-23295672f4a1"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("4d04446d-fd5c-410b-9b87-cfd778aa3b6a"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("5924d4a9-5d7d-4a5d-b44e-068ef3386575"));
            base.InitializeControls();
        }

        public MCAcceptForm() : base("MEDICALCOMMITTEE", "MCAcceptForm")
        {
        }

        protected MCAcceptForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}