
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
    public partial class NursingApplicationMainForm : TTForm
    {
    /// <summary>
    /// Hemşirelik Hizmetlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.NursingApplication _NursingApplication
        {
            get { return (TTObjectClasses.NursingApplication)_ttObject; }
        }

        protected ITTObjectListBox Bed;
        protected ITTLabel labelResponsibleNurse;
        protected ITTLabel labelHospitalInpatientDate;
        protected ITTObjectListBox Room;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelRoomGroup;
        protected ITTLabel labelBed;
        protected ITTObjectListBox ResponsibleNurse;
        protected ITTLabel labelResponsibleDoctor;
        protected ITTObjectListBox ResponsibleDoctor;
        protected ITTDateTimePicker HospitalInpatientDate;
        protected ITTLabel labelRoom;
        protected ITTGrid GridDiagnosis;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTTextBoxColumn SecFreeDiagnosis;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTDateTimePicker InpatientObservationEndTime;
        protected ITTLabel ttlabel21;
        protected ITTDateTimePicker InpatientObservationTime;
        protected ITTLabel ttlabel10;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn MMaterial;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn MNotes;
        override protected void InitializeControls()
        {
            Bed = (ITTObjectListBox)AddControl(new Guid("e748697a-e0a1-448c-b97f-29ce36da6b45"));
            labelResponsibleNurse = (ITTLabel)AddControl(new Guid("f5228fc0-cd46-431f-84ef-e13fb46ca2fd"));
            labelHospitalInpatientDate = (ITTLabel)AddControl(new Guid("b2e287ba-80cc-462b-841a-440f4cb5da7f"));
            Room = (ITTObjectListBox)AddControl(new Guid("94c13ad5-7d99-4748-9994-effd9e453b87"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("5687c98d-23c1-4ec3-b894-d1e7fe169f73"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("71f6867f-040e-426c-978a-02aa0ea3946b"));
            labelBed = (ITTLabel)AddControl(new Guid("16638b74-b117-45c0-90a5-0f1163357eb2"));
            ResponsibleNurse = (ITTObjectListBox)AddControl(new Guid("56980e1b-b269-43de-92ba-9fe15140ca1d"));
            labelResponsibleDoctor = (ITTLabel)AddControl(new Guid("5ef94614-4769-4029-9d43-827709946792"));
            ResponsibleDoctor = (ITTObjectListBox)AddControl(new Guid("28ae684d-8c85-4288-9263-dd4d5fb05878"));
            HospitalInpatientDate = (ITTDateTimePicker)AddControl(new Guid("f57640ef-cea3-453c-bf9e-ac141285b17c"));
            labelRoom = (ITTLabel)AddControl(new Guid("6b86b749-0e01-4911-b261-eaed05c2e3ff"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("4db76099-cc2d-4a2e-9ed3-16d6df6ccc22"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("16e00a8a-9731-4186-880f-00e63c67fbb5"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("77e5698e-71fa-4c2e-8415-45ec9d90b1f9"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("8a750478-d336-456c-975b-351b76f7694d"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("2c2e2628-2b2e-4a28-8e1b-285cc940ba42"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("76265257-28f1-4598-878b-acc15774b057"));
            InpatientObservationEndTime = (ITTDateTimePicker)AddControl(new Guid("72acd85c-0c59-4e22-9a3c-f8ad086a3f60"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("503f9e4b-73c0-42b4-bcc5-ddcb1783fd3a"));
            InpatientObservationTime = (ITTDateTimePicker)AddControl(new Guid("b4e37013-f1b2-492b-8009-840ec65ea923"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("5d937241-f82b-44a1-9642-70a994f78afb"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("57aab925-207f-4529-aad3-16b94ef4e32f"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("26248e5f-cf04-47c3-bc11-4b50a1872712"));
            MMaterial = (ITTListBoxColumn)AddControl(new Guid("82ff06c3-0a52-4c1c-9178-7415439236e7"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("fc5a5467-cc72-437b-8d02-1499bbc205f5"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("7f691a76-a1a4-4270-a8cd-89b7fc6aa77d"));
            MNotes = (ITTTextBoxColumn)AddControl(new Guid("127b70a5-3615-4ac7-8c40-7c27badadee9"));
            base.InitializeControls();
        }

        public NursingApplicationMainForm() : base("NURSINGAPPLICATION", "NursingApplicationMainForm")
        {
        }

        protected NursingApplicationMainForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}