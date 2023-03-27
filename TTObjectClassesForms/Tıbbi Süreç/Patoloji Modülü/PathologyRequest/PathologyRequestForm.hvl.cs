
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
    /// Patoloji Tetkik İstek Formu
    /// </summary>
    public partial class PathologyRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Patoloji İstek
    /// </summary>
        protected TTObjectClasses.PathologyRequest _PathologyRequest
        {
            get { return (TTObjectClasses.PathologyRequest)_ttObject; }
        }

        protected ITTLabel labelRequestMaterialNumber;
        protected ITTTextBox RequestMaterialNumber;
        protected ITTTextBox REQUESTDOCTORPHONENUMBER;
        protected ITTLabel ttlabel3;
        protected ITTTabControl TabPathologyProcedure;
        protected ITTTabPage TabPageProcedure;
        protected ITTGrid PathologyMaterials;
        protected ITTDateTimePickerColumn DateOfSampleTakenPathologyMaterial;
        protected ITTTextBoxColumn MaterialNumberPathologyMaterial;
        protected ITTListBoxColumn YerlesimYeriPathologyMaterial;
        protected ITTListBoxColumn AlindigiDokununTemelOzelligiPathologyMaterial;
        protected ITTListBoxColumn NumuneAlinmaSekliPathologyMaterial;
        protected ITTTextBoxColumn ClinicalFindingsPathologyMaterial;
        protected ITTTextBoxColumn DescriptionPathologyMaterial;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox REQUESTDOCTOR;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn ttcheckboxcolumn1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn ttcheckboxcolumn2;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn2;
        override protected void InitializeControls()
        {
            labelRequestMaterialNumber = (ITTLabel)AddControl(new Guid("9eb0029a-1a75-4b4a-bdc7-0b0f6eec97de"));
            RequestMaterialNumber = (ITTTextBox)AddControl(new Guid("dae79a33-ad92-4ee0-b0d3-dac836376a6e"));
            REQUESTDOCTORPHONENUMBER = (ITTTextBox)AddControl(new Guid("f9d937bb-4fc5-4757-881a-4264ba4b38da"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c1e51247-1e3c-4d68-9578-67d975f302df"));
            TabPathologyProcedure = (ITTTabControl)AddControl(new Guid("c3cf76ff-0e88-4744-80a8-9fc104044ab4"));
            TabPageProcedure = (ITTTabPage)AddControl(new Guid("f096431a-2ed0-404b-86dc-5976324083d2"));
            PathologyMaterials = (ITTGrid)AddControl(new Guid("2ac0719b-c14c-40db-85c1-d276f75048a9"));
            DateOfSampleTakenPathologyMaterial = (ITTDateTimePickerColumn)AddControl(new Guid("5e1759c1-fcb7-472f-ad66-255de9195ca8"));
            MaterialNumberPathologyMaterial = (ITTTextBoxColumn)AddControl(new Guid("b12c33ce-8093-406d-97e2-ea495dda9e7d"));
            YerlesimYeriPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("9ff3da11-bef6-406b-935c-d4e83b41f367"));
            AlindigiDokununTemelOzelligiPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("418e960e-945d-4eb2-8697-7e7567463379"));
            NumuneAlinmaSekliPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("1fae6e0a-433f-4d4f-8aef-ed1e8e5b9a22"));
            ClinicalFindingsPathologyMaterial = (ITTTextBoxColumn)AddControl(new Guid("da70d766-c1e6-4b80-aabd-24a82d816cc7"));
            DescriptionPathologyMaterial = (ITTTextBoxColumn)AddControl(new Guid("780abca6-6405-43cf-aa9e-874bda6a1241"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f1628fb8-2171-46f7-b5bd-494fec9442d0"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("7f8c7b5b-83ef-4c62-bc27-68d8aa314917"));
            labelActionDate = (ITTLabel)AddControl(new Guid("4357ac84-376f-4334-a2ba-9e044a8f05e7"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("f02f403a-7db4-4ef1-88cf-e495211c53fa"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("bf6977db-dd20-42e1-8f5e-b86d9aebb084"));
            ttcheckboxcolumn1 = (ITTCheckBoxColumn)AddControl(new Guid("f798f328-3006-41a4-8d4c-c9aa9cab9b39"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("119c0ea4-a67a-4f14-aecf-4fbafd0a3e5c"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("75d49081-bde3-4ac7-9edf-4de611b995e3"));
            ttcheckboxcolumn2 = (ITTCheckBoxColumn)AddControl(new Guid("802a2c4e-673d-489e-9044-ab19f92e5503"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("85a54889-09c1-49bb-b03c-d69b3b257d4b"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("8b312252-c445-4ef8-9287-93d3220581f9"));
            ttenumcomboboxcolumn2 = (ITTEnumComboBoxColumn)AddControl(new Guid("5ca68e02-575c-4120-a9fe-2bd28c80ccc9"));
            base.InitializeControls();
        }

        public PathologyRequestForm() : base("PATHOLOGYREQUEST", "PathologyRequestForm")
        {
        }

        protected PathologyRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}