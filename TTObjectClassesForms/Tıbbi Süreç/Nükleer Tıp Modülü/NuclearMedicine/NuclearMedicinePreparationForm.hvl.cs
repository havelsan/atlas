
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
    /// Nükleer Tıp Hazırlık Formu
    /// </summary>
    public partial class NuclearMedicinePreparationForm : EpisodeActionForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTGroupBox ReasonForAdmission1;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel9;
        protected ITTButton cmdPrintBarcode;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox nucMedSelectedTesttxt;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTTextBox RADIOPHARMACYDESC;
        protected ITTObjectListBox REQUESTDOCTOR;
        protected ITTTextBox tttextbox2;
        protected ITTCheckBox IsEmergency;
        protected ITTLabel ttlabel15;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel10;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel ttlabel7;
        protected ITTTextBox REQUESTDOCTORPHONE;
        protected ITTTextBox PatientPhone;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTTextBox PATIENTWEIGHT;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTLabel labelProcessTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelPreInformation;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTabControl TABNuclearMedicine;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridNuclearMedicineMaterial;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Note;
        protected ITTTabPage RadPharmMatTab;
        protected ITTGrid GridRadPharmMaterials;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTListBoxColumn PharmMaterial;
        protected ITTCheckBoxColumn IsInjection;
        protected ITTTextBoxColumn tttextboxcolumn3;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTListBoxColumn Units;
        override protected void InitializeControls()
        {
            ReasonForAdmission1 = (ITTGroupBox)AddControl(new Guid("0f591947-24ec-4b98-818b-2511cbc19f33"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("361a7d19-0176-4f29-9682-e3d633158d2b"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("4d0d7a56-629f-4aa2-b9ac-c3b310b730a8"));
            cmdPrintBarcode = (ITTButton)AddControl(new Guid("e78cf37b-3380-4854-820b-e711ce22bae9"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("332efaf8-1994-46eb-a9a3-3675b645d546"));
            nucMedSelectedTesttxt = (ITTTextBox)AddControl(new Guid("fe6ccdfd-e123-4950-be21-29a897a190ed"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("004a06de-7469-49b8-af22-0f4fd6dd9835"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("7c73ae69-854d-4f3b-90f5-227e480e3d6d"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("a318e72e-e8ef-45df-a1f9-a7e750ec7194"));
            RADIOPHARMACYDESC = (ITTTextBox)AddControl(new Guid("ce268cb5-4328-495a-b5e4-3046cbb2c4d6"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("d400fd4a-44be-4210-9c67-66814c2a6d32"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("b6c5cfad-bd80-4372-a3b3-8bf5ee90eb77"));
            IsEmergency = (ITTCheckBox)AddControl(new Guid("f0ab8c4e-2df2-442f-a6ce-d715306fb5c9"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("e6cbcddf-a80b-4b53-b60b-1b6fe266f204"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("3ead7cab-8c5b-4497-a1a6-ecf0286448aa"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("4ddcbce1-f041-4ad8-86e8-aca2ca0b147e"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("cce3aaa9-239c-4b05-b8bf-0781fd00f074"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("d9c7660e-1494-4057-8981-2c5ca8c9d6b6"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9aa08848-8559-492d-8f49-ec8b4243b389"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("f225e245-d42f-4e07-9ccd-bb20921b947b"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("34ef299e-434c-43f3-a5d3-419755a191aa"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("41e293f6-4458-407c-9227-fef99ac96560"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("9138bdab-ed3d-4da2-937b-f5f4550f3070"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("ec6a6683-577d-4c64-9342-d5e4bdbd4562"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("46469e01-2ba7-4ac7-a0b1-e306526904b8"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("5174993e-cb7b-4349-a549-140e59ce1ebf"));
            REQUESTDOCTORPHONE = (ITTTextBox)AddControl(new Guid("77cb86aa-c26e-404d-adaf-d83b8df6c7e6"));
            PatientPhone = (ITTTextBox)AddControl(new Guid("bff8f289-ccb6-43dc-8ed5-f33199a13b02"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e5f26cf1-3ad2-4b8e-b8a3-5b0571b1d069"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("8fbc5364-331b-48bc-8983-be9f69531862"));
            PATIENTWEIGHT = (ITTTextBox)AddControl(new Guid("2416d838-ec85-48a8-bbd9-27b1f7ceb97a"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3e68a1a5-bb78-4708-9db1-39e1d3cbe581"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e99e3936-aa83-4261-a686-8b2b08df8d1c"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("44d49c1c-7d94-422d-9b5a-f638acebc706"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("f808d153-d346-4a85-863e-84574f375baf"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("6a0660e4-b906-4c44-a470-97b122c3deaa"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("f28c1038-9f97-4772-b597-b58c126f78c8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6f0f4ed5-a196-448d-b081-ea9c1cf7d498"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("22ab1ae9-a0ad-4990-8637-bd193eab8bba"));
            TABNuclearMedicine = (ITTTabControl)AddControl(new Guid("2574dd90-345f-4bd1-9a93-f406b0c227d7"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("82ffcf50-407d-4073-b6b8-a44d533d40ad"));
            GridNuclearMedicineMaterial = (ITTGrid)AddControl(new Guid("d327d531-fb09-4138-a60c-5641285627aa"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("dcbe0d34-8dab-4e3d-8c02-b4aaf929b43f"));
            Material = (ITTListBoxColumn)AddControl(new Guid("25f61b97-7611-4d79-a5d8-35a081e22fad"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("0f7b1728-95d1-418e-8ada-e41c975e9aac"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("f35b80db-f9c1-4cfc-b410-4b9b6d23e917"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("6d7a5719-2815-4c80-9881-eea91f5299f4"));
            RadPharmMatTab = (ITTTabPage)AddControl(new Guid("11167b5b-1460-4d88-bda4-89a38a3a126e"));
            GridRadPharmMaterials = (ITTGrid)AddControl(new Guid("f233a9f5-12cd-428b-8824-3d1410e1de95"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("5699385a-405f-4fee-ba59-7bb88813a414"));
            PharmMaterial = (ITTListBoxColumn)AddControl(new Guid("a1c4d8a4-57f6-40c1-876c-deb339c6dfb3"));
            IsInjection = (ITTCheckBoxColumn)AddControl(new Guid("da05f314-5b43-435e-bb05-e1e4d24a6598"));
            tttextboxcolumn3 = (ITTTextBoxColumn)AddControl(new Guid("2bcce8a7-11bb-4c19-9ddc-38ff1629b569"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("5b2bb0e1-2bf4-47ce-8610-47fc5d74aaa9"));
            Units = (ITTListBoxColumn)AddControl(new Guid("adcbdf0c-3617-4627-b955-c10c5ebcc3c5"));
            base.InitializeControls();
        }

        public NuclearMedicinePreparationForm() : base("NUCLEARMEDICINE", "NuclearMedicinePreparationForm")
        {
        }

        protected NuclearMedicinePreparationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}