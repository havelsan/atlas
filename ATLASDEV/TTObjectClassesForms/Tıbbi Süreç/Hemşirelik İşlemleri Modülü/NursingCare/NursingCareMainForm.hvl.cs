
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
    /// Hemşirelik Bakımı
    /// </summary>
    public partial class NursingCareMainForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// NursingNanda
    /// </summary>
        protected TTObjectClasses.NursingCare _NursingCare
        {
            get { return (TTObjectClasses.NursingCare)_ttObject; }
        }

        protected ITTLabel labelNursingResult;
        protected ITTEnumComboBox NursingResult;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelNursingProblem;
        protected ITTObjectListBox NursingProblem;
        protected ITTLabel labelNote;
        protected ITTTextBox Note;
        protected ITTGrid NursingCareGrids;
        protected ITTListBoxColumn NursingCareList;
        protected ITTGrid NursingReasonGrids;
        protected ITTListBoxColumn NursingReasonGrid;
        protected ITTGrid NursingTargetGrids;
        protected ITTListBoxColumn NursingTargetGrid;
        override protected void InitializeControls()
        {
            labelNursingResult = (ITTLabel)AddControl(new Guid("fbcd36c0-230e-47b7-ac58-6f079e806bdd"));
            NursingResult = (ITTEnumComboBox)AddControl(new Guid("13e71cfd-38b1-4a0a-8b90-02cc802adf88"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("6312e25d-8c6d-426c-829b-18c689bdfd38"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("b5f8ee2f-5e8e-411f-beb5-8fb5330857e7"));
            labelNursingProblem = (ITTLabel)AddControl(new Guid("3a80c558-8d5a-4ea3-a579-9297eb2d5e80"));
            NursingProblem = (ITTObjectListBox)AddControl(new Guid("77395609-b38e-44ad-aeff-a3a633b53cde"));
            labelNote = (ITTLabel)AddControl(new Guid("f27c2b7a-f743-4dde-8931-e2d310d84e90"));
            Note = (ITTTextBox)AddControl(new Guid("767986ed-691a-4753-9056-f7db23d0f793"));
            NursingCareGrids = (ITTGrid)AddControl(new Guid("d5253493-abb8-41d2-bd28-7634b6dc1857"));
            NursingCareList = (ITTListBoxColumn)AddControl(new Guid("c04160ad-d65d-4f41-b871-f2345cc5c702"));
            NursingReasonGrids = (ITTGrid)AddControl(new Guid("17c0aef1-05b7-43d4-a7be-6ef70fe888da"));
            NursingReasonGrid = (ITTListBoxColumn)AddControl(new Guid("3f5d3b09-d030-47d9-8438-17d9bfbe78e9"));
            NursingTargetGrids = (ITTGrid)AddControl(new Guid("4bd53081-61cf-4c74-82a5-73345acdbbcc"));
            NursingTargetGrid = (ITTListBoxColumn)AddControl(new Guid("658ac624-2806-43cd-a1bc-698a52545ce9"));
            base.InitializeControls();
        }

        public NursingCareMainForm() : base("NURSINGCARE", "NursingCareMainForm")
        {
        }

        protected NursingCareMainForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}