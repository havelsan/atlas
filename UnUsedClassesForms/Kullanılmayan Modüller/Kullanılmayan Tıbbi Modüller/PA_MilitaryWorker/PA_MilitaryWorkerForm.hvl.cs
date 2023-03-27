
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
    /// XXXXXX İşçi Kabulü
    /// </summary>
    public partial class PA_MilitaryWorkerForm : PatientAdmissionForm
    {
    /// <summary>
    /// XXXXXX İşçi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_MilitaryWorker _PA_MilitaryWorker
        {
            get { return (TTObjectClasses.PA_MilitaryWorker)_ttObject; }
        }

        protected ITTObjectListBox assasmntDeptlst;
        protected ITTObjectListBox salaryPayLst;
        protected ITTLabel ttlabel833;
        protected ITTLabel ttlabel133;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel labelForcesCommand;
        protected ITTObjectListBox SenderChair;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTTextBox HealtSlipNumber;
        protected ITTObjectListBox MilitaryClass;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelMilitaryClass;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker DocumentDate;
        override protected void InitializeControls()
        {
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("62bb300b-1d87-4b74-8520-943eead1febf"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("44cf63a9-70b5-4af5-81ee-a92b9c03ce21"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("2be46101-b131-43f7-8935-0bb177fa36d8"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("7509847c-aacf-4cb2-af2d-cd8f6d65f39c"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("8f53e2f5-be14-4325-b6e2-894c8b64fcb9"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("99d97ca3-c9b3-400f-9c0f-39300f74da49"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("0ea801de-1e48-4cd2-9dc3-28d2ba53cab6"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("e01d003e-f3db-45ef-89b3-4c4ebe69473b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a55e1782-e19a-4652-8fe7-4cc273d59482"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("9d41cf17-0725-42df-8cd7-5ac318b05339"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("400dc2a8-635c-4be2-9b42-619f09ea5e16"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("90ccf199-13be-459d-84cf-827d06808980"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f5d40b63-7335-4b6d-85b3-a4e224c14c4e"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("6ab9b9eb-7088-427c-be87-af5517b05cf7"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("1e1271c4-8469-4353-808f-b9cdc0d3d259"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("2396b219-7289-4799-b800-ba9d504e2577"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("52501d5c-002d-4855-80c0-d4126eab7dd5"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("5fe70288-4f51-4326-a1e9-e48f3a2180fe"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("416e6f95-874e-4d7d-81c8-f5c29a363718"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("2ccab652-2f4f-48ba-85e8-fe840e9a1dea"));
            base.InitializeControls();
        }

        public PA_MilitaryWorkerForm() : base("PA_MILITARYWORKER", "PA_MilitaryWorkerForm")
        {
        }

        protected PA_MilitaryWorkerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}