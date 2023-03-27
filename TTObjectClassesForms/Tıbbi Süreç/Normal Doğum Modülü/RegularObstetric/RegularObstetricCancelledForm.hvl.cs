
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
    /// Normal Doğum İşlemleri
    /// </summary>
    public partial class RegularObstetricCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Normal Doğum
    /// </summary>
        protected TTObjectClasses.RegularObstetric _RegularObstetric
        {
            get { return (TTObjectClasses.RegularObstetric)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelProcessTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManipulationTab;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn RegularObstetricActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn RegularObstetricDoctor;
        protected ITTTabPage PersonnelTab;
        protected ITTGrid GridPersonnel;
        protected ITTListBoxColumn Personnel;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UseAmount;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn StockOutAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Notes;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("8ca2fec2-18b3-4b62-be0f-5ea0b27f5f23"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("c154556e-8459-457b-9601-42ffd88c49c0"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("c80a2d73-3d36-49fa-8d30-b530478bb769"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("8b3af9a9-7d3a-4555-9b98-930d5eba9b6f"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("23fb479e-51fd-433d-b55c-edc68d65983b"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("787b8e89-b5be-4ee4-9113-0b21e4b96cef"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("0ff0d68a-7742-44ba-be35-9fa5faf38d22"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("7a4525a4-ae17-47b5-b9c1-89639ccd9cd5"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("8493e1db-9c89-41f1-b093-e2fd6c035024"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("91368e50-6445-48a3-9abf-2a2cc615211c"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("328693ce-dae9-4247-9144-81c74762bf7c"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("d6dd23e8-2a67-48b9-8db6-de39ee129eec"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("93227d47-708a-4ca1-bb87-cfcadcad710c"));
            GridManipulations = (ITTGrid)AddControl(new Guid("19d7b7f5-1ef3-4586-ba07-38715d5e444d"));
            RegularObstetricActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("eb0ab44b-2cad-4fe6-87f3-252ce02b5371"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("73487c54-4144-4cc6-ba25-7db9cea80203"));
            RegularObstetricDoctor = (ITTListBoxColumn)AddControl(new Guid("7fb2aa1d-189d-4562-953f-15b8e8bb9fb1"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("79121129-b8c2-415a-86bb-b5bd2cdfab36"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("715b9c83-da80-44c5-a6b1-91b5a3214cb7"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("f49afc31-7d37-45fe-a0ec-a8c324bf7904"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("4abb35be-0092-4de8-adaf-49e5c23d74b2"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("d4623f91-edaa-4f8b-9d7d-16e80a4bb491"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("483faad8-69a2-4fb9-8a79-b8fa164d4f72"));
            Material = (ITTListBoxColumn)AddControl(new Guid("2a0c20ca-c05d-4f94-ba3a-ee4845064ae5"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("dc0d4542-8af4-4ac2-97c8-5ec2c01020d9"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("c67720e1-d501-416a-b1cc-91193e45b433"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("0ce90bb0-83d7-484a-999f-ffddff3ca76a"));
            StockOutAmount = (ITTTextBoxColumn)AddControl(new Guid("0f42c00e-08b3-4754-99c6-25baa4a48b72"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("f07fa790-27b4-48b8-979d-55d55a3b92da"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("58d7774d-006e-4d7d-9f29-c1cfe6e87ec9"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("ee0c4f17-2c84-4741-a51e-95dd5665452b"));
            base.InitializeControls();
        }

        public RegularObstetricCancelledForm() : base("REGULAROBSTETRIC", "RegularObstetricCancelledForm")
        {
        }

        protected RegularObstetricCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}