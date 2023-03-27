
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
    public partial class MCCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Kurul İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.MedicalCommittee _MedicalCommittee
        {
            get { return (TTObjectClasses.MedicalCommittee)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox ProtocolNo;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox MedicalCommitteType;
        protected ITTLabel labelDepartment;
        protected ITTLabel labelMedicalCommitteType;
        protected ITTObjectListBox Department;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("2b419295-a27b-4403-82ae-71080651cb58"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6dab3ffb-90aa-45f7-bb15-71c46b9c569b"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("7450e525-da28-4c9b-80d3-12523f829dbd"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("aab0a5b5-5b94-440a-8e45-9213e9050037"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5488c9df-aa92-467b-ac47-1a6646474115"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7228fe59-42e7-4e83-b062-caa8d11a8461"));
            MedicalCommitteType = (ITTObjectListBox)AddControl(new Guid("3a168f0d-a422-40f8-8ee1-ccec0edaa6b4"));
            labelDepartment = (ITTLabel)AddControl(new Guid("1dd11ff8-2125-41ec-85ca-4d99cd5a0263"));
            labelMedicalCommitteType = (ITTLabel)AddControl(new Guid("9acc93a8-33c0-4467-89e4-bb6613a49a4d"));
            Department = (ITTObjectListBox)AddControl(new Guid("be662260-01bc-4255-90b8-3aa812e96db0"));
            base.InitializeControls();
        }

        public MCCancelledForm() : base("MEDICALCOMMITTEE", "MCCancelledForm")
        {
        }

        protected MCCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}