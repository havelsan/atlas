
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
    public partial class EmergencyInterventionNursingDetailForm : EpisodeActionForm
    {
    /// <summary>
    /// Acil Hemşirelik Hizmetleri
    /// </summary>
        protected TTObjectClasses.EmergencyInterventionNursingDetail _EmergencyInterventionNursingDetail
        {
            get { return (TTObjectClasses.EmergencyInterventionNursingDetail)_ttObject; }
        }

        protected ITTTabControl tttabTani;
        protected ITTTabPage TabTani;
        protected ITTGrid GridDiagnosis;
        protected ITTListBoxColumn Diagnose;
        protected ITTTextBoxColumn FreeDiagnosis;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid UsedMaterial;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn MMaterial;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn MNotes;
        protected ITTTabPage EkUygulamalar;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn SDateTime;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        override protected void InitializeControls()
        {
            tttabTani = (ITTTabControl)AddControl(new Guid("74f7c1e0-ead5-47a4-9c8f-fbfae5b45384"));
            TabTani = (ITTTabPage)AddControl(new Guid("c4a25320-bae6-41a5-be93-28c4ed34eb25"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("1ab18a53-412a-4040-bac1-e873722e7c58"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("a00d338a-c11d-46d9-90a0-307563f217c8"));
            FreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("a1b45210-1d6a-42e2-b286-871144dc04dd"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("c8ac4d9d-d094-4298-85e2-369572735eb7"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("bf51ce2b-eee8-4d00-a975-eed2b220c86b"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("d5e7eb1b-2c32-47b1-b78b-a15c87c1f07f"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("0fd82094-eabc-43af-bb1d-785d56723fa4"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("4fceebb7-2e21-4328-a4b0-f5181e24463e"));
            UsedMaterial = (ITTGrid)AddControl(new Guid("a2ed1e17-773b-4836-a558-d108c5f3baf4"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("808b0282-9f3c-43b9-a120-60307563b489"));
            MMaterial = (ITTListBoxColumn)AddControl(new Guid("0a400452-d0b5-4bcf-a379-0a8670697a5f"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("84ba371e-2ec4-4df6-867a-f0f2dc8912b1"));
            MNotes = (ITTTextBoxColumn)AddControl(new Guid("1ee10f2f-b815-4dbe-9c9d-9af4ea64c085"));
            EkUygulamalar = (ITTTabPage)AddControl(new Guid("70b8f7e7-ea92-493a-b077-23b1d75ea2d3"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("0965ff8a-70cd-4759-8055-d8e33be11174"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("d1f892a5-56e9-464b-b610-bcfde5fe2cc9"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("9740a4c8-bd2b-4a03-be89-570fff7a02c1"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("e63ff7c8-0b00-4bac-8c56-821b3c452522"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("3f777240-0bc9-4958-aca7-29954cdc4c66"));
            base.InitializeControls();
        }

        public EmergencyInterventionNursingDetailForm() : base("EMERGENCYINTERVENTIONNURSINGDETAIL", "EmergencyInterventionNursingDetailForm")
        {
        }

        protected EmergencyInterventionNursingDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}