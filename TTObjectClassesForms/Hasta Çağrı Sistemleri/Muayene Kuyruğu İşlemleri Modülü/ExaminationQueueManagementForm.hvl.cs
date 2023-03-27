
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
    public partial class ExaminationQueueManagementForm : TTUnboundForm
    {
        protected ITTButton btnCompletedQueueItemsReport;
        protected ITTTabControl tttabcontrolExaminationQueue;
        protected ITTTabPage tabpageWaitingItems;
        protected ITTGrid QueueItemsGrid;
        protected ITTTextBoxColumn CallTime;
        protected ITTTextBoxColumn Name;
        protected ITTCheckBoxColumn HasAppointment;
        protected ITTCheckBoxColumn Diverted;
        protected ITTTextBoxColumn DivertedTime;
        protected ITTTextBoxColumn Priority;
        protected ITTTextBoxColumn ExaminationQueueName;
        protected ITTButtonColumn ChangeQueue;
        protected ITTButtonColumn DeleteQueue;
        protected ITTTextBoxColumn Doctor;
        protected ITTButtonColumn ClearDoctor;
        protected ITTTextBoxColumn QueueItemObjectID;
        protected ITTButtonColumn QueueUp;
        protected ITTButtonColumn QueueDown;
        protected ITTTabPage tabpageCompletedItems;
        protected ITTGrid gridCompletedItems;
        protected ITTTextBoxColumn DoctorName;
        protected ITTTextBoxColumn CompletedItemCount;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage SearchInQueue;
        protected ITTCheckBox cbIncludeNoAdmissions;
        protected ITTLabel labelCompletedItemsCount;
        protected ITTButton cmdListQueue;
        protected ITTObjectListBox QueueListBox;
        protected ITTLabel ttlabel1;
        protected ITTTabPage SearchByName;
        protected ITTButton cmdSearchPatient;
        protected ITTTextBox txtPatientName;
        protected ITTLabel ttlabel3;
        protected ITTButton cmdListPatientItems;
        override protected void InitializeControls()
        {
            btnCompletedQueueItemsReport = (ITTButton)AddControl(new Guid("ca560d57-b71e-460f-b91a-707f60f5ef5b"));
            tttabcontrolExaminationQueue = (ITTTabControl)AddControl(new Guid("f23da893-930b-49cd-b725-43bd949fe50a"));
            tabpageWaitingItems = (ITTTabPage)AddControl(new Guid("3fe068d2-02e2-4b60-8520-c905a676c858"));
            QueueItemsGrid = (ITTGrid)AddControl(new Guid("19a90a83-ecb2-4796-8f65-2892f79064f7"));
            CallTime = (ITTTextBoxColumn)AddControl(new Guid("fa225b63-db1d-42ff-b949-1e156c065d89"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("17473eb8-f6b4-402e-a8ac-189fbe45482a"));
            HasAppointment = (ITTCheckBoxColumn)AddControl(new Guid("ba30103d-992d-4c37-b3f8-0d7a3722118a"));
            Diverted = (ITTCheckBoxColumn)AddControl(new Guid("12191b4b-ed76-4a27-80ad-8a3daa451981"));
            DivertedTime = (ITTTextBoxColumn)AddControl(new Guid("c4e9b70f-9f3f-4929-9124-5651320f1e56"));
            Priority = (ITTTextBoxColumn)AddControl(new Guid("53196670-2505-41d7-922b-628b7620693b"));
            ExaminationQueueName = (ITTTextBoxColumn)AddControl(new Guid("491268f0-c8e0-4d48-84d0-9c22050689a1"));
            ChangeQueue = (ITTButtonColumn)AddControl(new Guid("92fe147b-907b-4cae-b8e9-8dd2de3277ab"));
            DeleteQueue = (ITTButtonColumn)AddControl(new Guid("ddeb4ef9-a968-4cf9-a29b-862c165debcb"));
            Doctor = (ITTTextBoxColumn)AddControl(new Guid("3a364668-c39a-44be-b2b8-79b2bcffe691"));
            ClearDoctor = (ITTButtonColumn)AddControl(new Guid("cd502f70-6a61-4704-9752-a3ff9129e8ff"));
            QueueItemObjectID = (ITTTextBoxColumn)AddControl(new Guid("6f197e17-842a-4b19-94dc-f17e9dc19f9a"));
            QueueUp = (ITTButtonColumn)AddControl(new Guid("b8b33cf3-207e-42fa-8a9e-e79759550102"));
            QueueDown = (ITTButtonColumn)AddControl(new Guid("7f967ca0-9d49-4fec-8284-a59d41afa95c"));
            tabpageCompletedItems = (ITTTabPage)AddControl(new Guid("e5012d5d-3763-42e5-8287-02abfad9f3c9"));
            gridCompletedItems = (ITTGrid)AddControl(new Guid("11bb0a09-f6d4-4a84-a847-9a2f5973456b"));
            DoctorName = (ITTTextBoxColumn)AddControl(new Guid("13c66169-2bca-4adb-9cc0-6e4b1ff5dba1"));
            CompletedItemCount = (ITTTextBoxColumn)AddControl(new Guid("679fd47e-b1a8-4ac3-807e-09092211ba6e"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6387bd4b-6069-4a32-82d3-7118ab224311"));
            SearchInQueue = (ITTTabPage)AddControl(new Guid("0ba9259a-803f-48c9-a848-ba800af723ac"));
            cbIncludeNoAdmissions = (ITTCheckBox)AddControl(new Guid("23127c70-9c09-48d6-996e-b39697c776b1"));
            labelCompletedItemsCount = (ITTLabel)AddControl(new Guid("acb725ad-23a8-4000-9c62-d0f52fc7806c"));
            cmdListQueue = (ITTButton)AddControl(new Guid("6e7c67ae-4220-45cd-b15e-291efcdbb137"));
            QueueListBox = (ITTObjectListBox)AddControl(new Guid("7e517052-559e-4bc3-a1b7-5c33a4700b38"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2a32b544-152d-4983-841b-2f4fd3a4ef7b"));
            SearchByName = (ITTTabPage)AddControl(new Guid("30bbb2ec-282c-4e23-ab71-79de09bd44e5"));
            cmdSearchPatient = (ITTButton)AddControl(new Guid("20dd5748-fbc8-4bef-8e85-242c9dc7d9f9"));
            txtPatientName = (ITTTextBox)AddControl(new Guid("28f6a6b7-b28a-4c3e-88c3-057f13d99d5d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3adbfc4e-1cf3-43d3-b95f-23961cc03b49"));
            cmdListPatientItems = (ITTButton)AddControl(new Guid("4d55e559-5571-4cd0-86a9-7d1c007c19fc"));
            base.InitializeControls();
        }

        public ExaminationQueueManagementForm() : base("ExaminationQueueManagementForm")
        {
        }

        protected ExaminationQueueManagementForm(string formDefName) : base(formDefName)
        {
        }
    }
}