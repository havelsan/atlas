
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
    public partial class PathologyRequestMainForm : TTForm
    {
    /// <summary>
    /// Patoloji İstek
    /// </summary>
        protected TTObjectClasses.PathologyRequest _PathologyRequest
        {
            get { return (TTObjectClasses.PathologyRequest)_ttObject; }
        }

        protected ITTLabel labelMaterialResponsible;
        protected ITTTextBox MaterialResponsible;
        protected ITTTextBox RequestMaterialNumber;
        protected ITTTextBox PhoneNumberResUser;
        protected ITTTextBox AcceptionNote;
        protected ITTLabel labelRequestMaterialNumber;
        protected ITTGrid DiagnosisDiagnosisGrid;
        protected ITTListBoxColumn DiagnoseDiagnosisGrid;
        protected ITTEnumComboBoxColumn DiagnosisTypeDiagnosisGrid;
        protected ITTDateTimePickerColumn DiagnoseDateDiagnosisGrid;
        protected ITTListBoxColumn ResponsibleDoctorDiagnosisGrid;
        protected ITTLabel labelPhoneNumberResUser;
        protected ITTLabel labelRequestDoctor;
        protected ITTObjectListBox RequestDoctor;
        protected ITTGrid PathologyMaterials;
        protected ITTDateTimePickerColumn DateOfSampleTaken;
        protected ITTTextBoxColumn MaterialNumber;
        protected ITTListBoxColumn YerlesimYeriPathologyMaterial;
        protected ITTListBoxColumn AlindigiDokununTemelOzelligiPathologyMaterial;
        protected ITTListBoxColumn NumuneAlinmaSekliPathologyMaterial;
        protected ITTTextBoxColumn ClinicalFindingsPathologyMaterial;
        protected ITTTextBoxColumn DescriptionPathologyMaterial;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelAcceptionNote;
        protected ITTLabel labelAcceptionDate;
        protected ITTDateTimePicker AcceptionDate;
        override protected void InitializeControls()
        {
            labelMaterialResponsible = (ITTLabel)AddControl(new Guid("59db650d-cd06-4394-b63f-7c973a71650a"));
            MaterialResponsible = (ITTTextBox)AddControl(new Guid("ee7832c7-354e-42c6-97fa-d78f1b323502"));
            RequestMaterialNumber = (ITTTextBox)AddControl(new Guid("c89031de-a993-4659-95fb-20d2cc4cf339"));
            PhoneNumberResUser = (ITTTextBox)AddControl(new Guid("4e380bc2-7dea-4d61-a90c-ece8ab14ce28"));
            AcceptionNote = (ITTTextBox)AddControl(new Guid("82913d40-9d06-41e1-8375-173ab638e230"));
            labelRequestMaterialNumber = (ITTLabel)AddControl(new Guid("1e7df55d-abfd-4a3a-b437-b695965ec79a"));
            DiagnosisDiagnosisGrid = (ITTGrid)AddControl(new Guid("684daf6b-4c83-483a-819f-2ad2acb565f3"));
            DiagnoseDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("e44406d7-406a-4337-81fb-1fd76b012f48"));
            DiagnosisTypeDiagnosisGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("dce86125-0280-4a12-a47d-c27e2367c2f9"));
            DiagnoseDateDiagnosisGrid = (ITTDateTimePickerColumn)AddControl(new Guid("cc93762a-3f27-455d-8494-36ef8a3fdba9"));
            ResponsibleDoctorDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("59d30891-7bcb-4d9b-838d-fdf00bef00fb"));
            labelPhoneNumberResUser = (ITTLabel)AddControl(new Guid("a8247521-4c84-48f3-893d-87ece2821ad2"));
            labelRequestDoctor = (ITTLabel)AddControl(new Guid("1902e2a8-e02e-4060-8d49-96fbd8aff33c"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("aa0c44d2-144f-474f-b14f-eda8344f6e63"));
            PathologyMaterials = (ITTGrid)AddControl(new Guid("0bae1038-6ddc-481e-8671-87bb7a97992a"));
            DateOfSampleTaken = (ITTDateTimePickerColumn)AddControl(new Guid("12544d80-0d54-4368-9103-54390b284b71"));
            MaterialNumber = (ITTTextBoxColumn)AddControl(new Guid("e727a180-bbb2-48bf-9c6c-566b66d5db1b"));
            YerlesimYeriPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("8db85849-1f15-495e-8132-5c2791648443"));
            AlindigiDokununTemelOzelligiPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("5813507a-079a-4f48-8902-17aa7a80e3b0"));
            NumuneAlinmaSekliPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("3d295294-27c3-466a-a210-6dd650a9920b"));
            ClinicalFindingsPathologyMaterial = (ITTTextBoxColumn)AddControl(new Guid("0cf0f1f3-f8d7-4ecb-8cd6-a9793dee7e76"));
            DescriptionPathologyMaterial = (ITTTextBoxColumn)AddControl(new Guid("9776617c-d516-45a5-858c-a62d04429824"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("4458332b-050e-4a9d-b9f9-45279eb0509c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("66cec538-9809-4d32-9c8d-bbf0c0fca565"));
            labelAcceptionNote = (ITTLabel)AddControl(new Guid("d9d6cd70-fc69-4bad-bb3d-acd3c2436c36"));
            labelAcceptionDate = (ITTLabel)AddControl(new Guid("02c4a104-83a5-4177-9b90-dd1dd8a11729"));
            AcceptionDate = (ITTDateTimePicker)AddControl(new Guid("a7b96423-a1e7-4e04-981b-9ece9238b465"));
            base.InitializeControls();
        }

        public PathologyRequestMainForm() : base("PATHOLOGYREQUEST", "PathologyRequestMainForm")
        {
        }

        protected PathologyRequestMainForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}