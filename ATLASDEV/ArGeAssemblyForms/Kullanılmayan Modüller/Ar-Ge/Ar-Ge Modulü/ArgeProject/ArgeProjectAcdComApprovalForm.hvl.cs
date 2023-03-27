
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
    public partial class ArgeProjectAcdComApprovalForm : ArgeProjectPreClaimAppealForm
    {
    /// <summary>
    /// Proje Başvuru Formu
    /// </summary>
        protected TTObjectClasses.ArgeProject _ArgeProject
        {
            get { return (TTObjectClasses.ArgeProject)_ttObject; }
        }

        protected ITTTabPage tttabpage21;
        protected ITTLabel labelAcademicCommAddInfoAcademicCommClaim;
        protected ITTTextBox AcademicCommAddInfoAcademicCommClaim;
        protected ITTTabPage tttabpage22;
        protected ITTLabel labelProjectRaportor;
        protected ITTObjectListBox ProjectRaportor;
        protected ITTLabel ttlabel1;
        protected ITTGrid Advisiors;
        protected ITTListBoxColumn ArgeProjectAdvisorProjectAdvisor;
        override protected void InitializeControls()
        {
            tttabpage21 = (ITTTabPage)AddControl(new Guid("1809a466-c0b6-4fed-9bd5-98fb11838526"));
            labelAcademicCommAddInfoAcademicCommClaim = (ITTLabel)AddControl(new Guid("3edb6a54-0583-4c1c-b87e-c0b388d80ba9"));
            AcademicCommAddInfoAcademicCommClaim = (ITTTextBox)AddControl(new Guid("18898b00-b9a3-4694-9e40-d6ec50983773"));
            tttabpage22 = (ITTTabPage)AddControl(new Guid("074ea6fd-dbe8-4709-8dc0-51e27d0bbfda"));
            labelProjectRaportor = (ITTLabel)AddControl(new Guid("be98b0c4-042e-4bb0-8f81-a54d5ec58c2c"));
            ProjectRaportor = (ITTObjectListBox)AddControl(new Guid("0a97539a-3a8a-44f9-bb9c-6da4cb5f6681"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8d5195d2-0223-41f6-8f50-11f0c9f309bf"));
            Advisiors = (ITTGrid)AddControl(new Guid("eab7d605-48b7-4a29-a348-b4af26bf9ac2"));
            ArgeProjectAdvisorProjectAdvisor = (ITTListBoxColumn)AddControl(new Guid("1e525bdc-501d-41b1-96ac-701272223a7a"));
            base.InitializeControls();
        }

        public ArgeProjectAcdComApprovalForm() : base("ARGEPROJECT", "ArgeProjectAcdComApprovalForm")
        {
        }

        protected ArgeProjectAcdComApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}