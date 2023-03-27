
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
    public partial class RegularObstetricCompletedForm : EpisodeActionForm
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
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("a07703fc-fd0b-4c72-b3a8-c74477493a2d"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("e0e1719e-983c-452f-b1f0-ec116a220556"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("dd7dac48-7b26-434f-8647-8067467448f8"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("ae6a90f6-c07d-47a5-867f-b4d2ff54b4ab"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("60e402d8-d246-43de-b58d-087680e88660"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("6479a6d3-7c99-4329-b311-8737bb5fe1de"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("9e7d62d9-211e-4452-9faf-e0d62a6a8327"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("259dbb55-75a9-4b9f-8b0d-802ec9b25451"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("afa26484-9825-4959-ad29-0cfc96480a55"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("e598d5b7-32c5-40f2-b764-d635bcb69b3d"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("aa0db73e-e417-44ac-91f3-cf9b9625f536"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("bb94c055-205e-436e-b5f2-7801e7d746a2"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("25b777b3-652d-4650-b4ba-338d46669f32"));
            GridManipulations = (ITTGrid)AddControl(new Guid("973ed229-94c4-4272-8b40-c54838453118"));
            RegularObstetricActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("e3a82f25-9c4a-4a70-9884-0b441d7b5583"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("eaae84f2-19e6-4cf9-ad23-7124d0497a93"));
            RegularObstetricDoctor = (ITTListBoxColumn)AddControl(new Guid("0c33cb34-1ae0-456a-a0ab-34b8c4b8950b"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("282f5af7-e83b-43eb-996e-98a44d1190f7"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("7734bb0b-c827-4858-94b1-6c401bf66569"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("d31ee067-bf25-4ca1-b6c1-0dd598dd7302"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("1331ed2a-9a55-4d2b-9d55-96de465d8008"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("81c4ff70-38df-4940-b730-c7d6eb7b48e3"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("71702782-23e1-423c-86cd-eca27452c222"));
            Material = (ITTListBoxColumn)AddControl(new Guid("eaa3b835-61ed-408a-b6ef-0c24f66ea6a4"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("f79573c6-1664-49aa-b50e-08322d3378e8"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("0b67589c-664d-4513-b3e1-54556b606565"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("3069bb06-e635-4678-a41d-e58dcce9129b"));
            StockOutAmount = (ITTTextBoxColumn)AddControl(new Guid("9788bab9-1659-43f7-986c-a7d2a49e594f"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("8ce5e140-e822-470f-be4f-c52ed17bccd3"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("c3746b6e-8f17-463b-8052-97c4d7a70bcd"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("e73c765f-c928-49d0-b4c8-ad3993d89033"));
            base.InitializeControls();
        }

        public RegularObstetricCompletedForm() : base("REGULAROBSTETRIC", "RegularObstetricCompletedForm")
        {
        }

        protected RegularObstetricCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}