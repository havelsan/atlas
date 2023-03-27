
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
    /// Otomatik başlatılacak işlem/hizmet tanımları
    /// </summary>
    public partial class PAStartedActionsForm : TTDefinitionForm
    {
    /// <summary>
    /// Hasta kabul esnasında başlatılacak işlem/hizmetler
    /// </summary>
        protected TTObjectClasses.PatientAdmissionStartedActions _PatientAdmissionStartedActions
        {
            get { return (TTObjectClasses.PatientAdmissionStartedActions)_ttObject; }
        }

        protected ITTEnumComboBox AdmissionStatus;
        protected ITTPanel ttpanel1;
        protected ITTGrid ProcedureObjectGrid;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListDefComboBoxColumn Resource;
        protected ITTListBoxColumn MainResource;
        protected ITTLabel ttlabel4;
        protected ITTGrid ActionTypeGrid;
        protected ITTEnumComboBoxColumn Actiontype;
        protected ITTListDefComboBoxColumn EpisodeActionPoliclinic;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox SKRSVakaTuru;
        protected ITTLabel lblSkrsVakaTuru;
        protected ITTEnumComboBox DefualtActionType;
        protected ITTLabel labelDefualtActionType;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            AdmissionStatus = (ITTEnumComboBox)AddControl(new Guid("d11ca688-2b22-40f5-aa28-2df9eea6f96e"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("22c17f6c-4c2d-416b-9e74-7312884076e6"));
            ProcedureObjectGrid = (ITTGrid)AddControl(new Guid("eae2bec9-369c-42ba-a1fb-95bf7da4cd81"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("28b6f827-4ae2-495e-9edf-df0dd3730bad"));
            Resource = (ITTListDefComboBoxColumn)AddControl(new Guid("5b3e2241-f267-4ac9-8d79-fb7c38488fd8"));
            MainResource = (ITTListBoxColumn)AddControl(new Guid("946e3259-5689-4be1-aa19-5a68a8cbcaea"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("ed80b08e-2f4d-46cd-aad4-4cd645336c86"));
            ActionTypeGrid = (ITTGrid)AddControl(new Guid("22053af9-91d6-4100-9fae-035d988924ec"));
            Actiontype = (ITTEnumComboBoxColumn)AddControl(new Guid("4cc60b76-2826-4ac5-afdd-6a8484450c35"));
            EpisodeActionPoliclinic = (ITTListDefComboBoxColumn)AddControl(new Guid("f765813b-791c-4cc9-9740-c6be0494836b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("743a6a6e-bf4f-4f4b-bdf7-dfa484101c74"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f0c6fd4a-d78b-4f87-a139-c983b39c8490"));
            SKRSVakaTuru = (ITTObjectListBox)AddControl(new Guid("f793e0a8-d887-4c88-b66f-4656000dbbe8"));
            lblSkrsVakaTuru = (ITTLabel)AddControl(new Guid("6d4c69d2-8e42-4f7b-ab7b-5c0310e361c9"));
            DefualtActionType = (ITTEnumComboBox)AddControl(new Guid("5c62d539-f656-49a6-98a8-659097cb9017"));
            labelDefualtActionType = (ITTLabel)AddControl(new Guid("1ebb3b71-2f9c-4d7e-9a81-3c63fcc35c80"));
            IsActive = (ITTCheckBox)AddControl(new Guid("dbf1e22a-6088-4d8e-9e59-a433feaeb40e"));
            base.InitializeControls();
        }

        public PAStartedActionsForm() : base("PATIENTADMISSIONSTARTEDACTIONS", "PAStartedActionsForm")
        {
        }

        protected PAStartedActionsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}