
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
    /// Hemşirelik Uygulamaları - Nanda Tanı Tanımları
    /// </summary>
    public partial class NursingProblemDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hemşirelik Tanısı Tanımlama Modülü (Hemşirelik Sorunu)
    /// </summary>
        protected TTObjectClasses.NursingProblemDefinition _NursingProblemDefinition
        {
            get { return (TTObjectClasses.NursingProblemDefinition)_ttObject; }
        }

        protected ITTGrid NursingProblemTargetRelations;
        protected ITTListBoxColumn NursingTargetNursingProblemTargetRelation;
        protected ITTGrid NursingReasonProblemRelations;
        protected ITTListBoxColumn NursingReasonNursingProblemReasonRelation;
        protected ITTGrid NursingProblemCareRelations;
        protected ITTListBoxColumn NursingCare;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox Aktif;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            NursingProblemTargetRelations = (ITTGrid)AddControl(new Guid("66b602fc-b013-471d-a8ed-0f93016d8483"));
            NursingTargetNursingProblemTargetRelation = (ITTListBoxColumn)AddControl(new Guid("4eaf3971-b72b-439c-bc59-2e7e60651595"));
            NursingReasonProblemRelations = (ITTGrid)AddControl(new Guid("b4d2b558-f779-4765-80cb-9ad6d8a4ddd5"));
            NursingReasonNursingProblemReasonRelation = (ITTListBoxColumn)AddControl(new Guid("54b0d44d-7fe4-4c5e-bb4f-dded4bd42701"));
            NursingProblemCareRelations = (ITTGrid)AddControl(new Guid("b39c3d5d-abdd-4f95-b912-c940f6bc4abe"));
            NursingCare = (ITTListBoxColumn)AddControl(new Guid("d5a1ad39-dbb3-4090-805b-71b0dc013343"));
            labelName = (ITTLabel)AddControl(new Guid("3d708d20-139f-4b43-ad3a-81935a3116d7"));
            Name = (ITTTextBox)AddControl(new Guid("d26d689d-16b1-4365-8c7e-ef968b76e554"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("bfca292d-85e6-4a90-86a4-ff4e1af04dd4"));
            Aktif = (ITTCheckBox)AddControl(new Guid("bb904f96-0679-4f16-8791-4333217fbf70"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4f6d669d-3603-4477-900b-56c50c6973b6"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a71ebb7e-da8a-4288-b0b0-950069adf634"));
            base.InitializeControls();
        }

        public NursingProblemDefinitionForm() : base("NURSINGPROBLEMDEFINITION", "NursingProblemDefinitionForm")
        {
        }

        protected NursingProblemDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}