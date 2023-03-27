
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
    /// Nükleer Tıp İşlemde Formu
    /// </summary>
    public partial class NuclearMedicineProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel12;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox RADIOPHARMACYDESC;
        protected ITTTabPage tttabpage3;
        protected ITTTextBox NUCMEDDOCTORNOTE;
        protected ITTTextBox nucMedSelectedTesttxt;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel15;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel11;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox IsEmergency;
        protected ITTLabel ttlabel9;
        protected ITTTextBox REQUESTDOCTORPHONE;
        protected ITTObjectListBox REQUESTDOCTOR;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTTextBox PATIENTPHONENUMBER;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker INJECTIONDATE;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTTextBox PATIENTWEIGHT;
        protected ITTDateTimePicker ProcedureDate;
        protected ITTLabel labelProcessTime;
        protected ITTTabControl TABNuclearMedicine;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridNuclearMedicineMaterial;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Note;
        protected ITTTextBoxColumn Barkod;
        protected ITTTabPage RadPharmMatTab;
        protected ITTGrid ttgrid2;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTCheckBoxColumn IsInjection;
        protected ITTTextBoxColumn tttextboxcolumn3;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTListBoxColumn Units;
        protected ITTTabPage tttabpage4;
        protected ITTGrid DirectPurchaseGrids;
        protected ITTListBoxColumn MaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn AmountDirectPurchaseGrid;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f7de2b02-c174-41c8-bd90-839c7a778d36"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("75ef7075-5677-46e2-9853-064682cd44fd"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("f2f38e77-f9fd-468a-9086-c4768476b6fb"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("d4191110-5bcc-4407-b102-1321d61ff25d"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("8d66494a-cc69-4bfa-9858-4c48c5e43ed8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("925f101f-29aa-4c9b-bd55-f9902a101a19"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("369c4111-9f02-44fc-8589-3a7833f77f64"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("d435291a-667d-4b33-9260-a279aada5ee8"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("31946f53-4d5b-4b0c-9e63-0826aaca0fcf"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("89495e70-dce9-4c16-be41-dcca9c887545"));
            RADIOPHARMACYDESC = (ITTTextBox)AddControl(new Guid("3922cb48-7b9d-494c-9321-a6a22535caad"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("a475d42f-3a4e-4e9c-a8bc-069dcb021963"));
            NUCMEDDOCTORNOTE = (ITTTextBox)AddControl(new Guid("01422d63-9fa5-4d9d-8d20-fdd7a7e2a63c"));
            nucMedSelectedTesttxt = (ITTTextBox)AddControl(new Guid("56c57655-7c23-4884-8119-b51bf9ccbd7e"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("b3109366-1f62-4392-a39b-c7bfd0ccbeb3"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("cec9ff9e-2659-482c-aa39-2c0e838d78c1"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("04bf8dbf-7c79-41f9-bca3-afdb85fe1c58"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("448ec9ba-673a-4048-af05-f9caf3255789"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("69dc4194-3e58-40c2-ba8f-d775ee8636d0"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("8559f3bc-b6b7-4b07-b217-56cebbe4f5d8"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("9f5dbb86-5506-49a4-bbc8-6a6cfc864d1f"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("1175381e-7d1c-4f27-b673-a32065330e27"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("f4b39ce2-b2d0-4209-9867-515217f3f050"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("41cfafda-92ef-4025-a9db-7e45d0c38dfb"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("a5fdf896-7ac4-48c4-b54d-f545c5c01092"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("0f8f370f-957f-4c83-b91f-b1cb50caada3"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("1364d728-1db3-4ff6-9e81-420743ed03f0"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("1b4385c3-699e-480c-acda-0961f6100a5a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("673b3865-41d9-4068-bccf-24ea83f18974"));
            IsEmergency = (ITTCheckBox)AddControl(new Guid("2e56eeca-521e-4d08-b5ea-f570c88fdb41"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("fefe88fc-a956-454e-a6cb-d4bad57448c2"));
            REQUESTDOCTORPHONE = (ITTTextBox)AddControl(new Guid("ad4ff49e-b645-446b-916a-058e2cae256b"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("013d6e96-849e-47d4-93e8-661b1e4059ab"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("f9a96f35-f423-40e0-aca4-4aa161bb84d3"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("32d9e26c-4d1e-42cc-aa2d-bbb4a53c4d54"));
            PATIENTPHONENUMBER = (ITTTextBox)AddControl(new Guid("cf4da704-67ab-486d-961d-12b9f389cd93"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("5e0e24ba-de57-4d2a-bade-a2a040bda487"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("6ebdcc7d-9399-419d-b8a1-90c33c5f4aba"));
            INJECTIONDATE = (ITTDateTimePicker)AddControl(new Guid("e1dd2d5e-8a24-4b86-b080-bf35caea8e4a"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("cf9f912b-4448-4574-b857-40ecf059302f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c4ba82a8-c5d2-410c-8b37-f939d1291cf4"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("7cb3487a-6a52-4f90-897e-0c4c8dc4f6a6"));
            PATIENTWEIGHT = (ITTTextBox)AddControl(new Guid("e88dbe4b-ce08-4c78-b986-19ffdd805ed8"));
            ProcedureDate = (ITTDateTimePicker)AddControl(new Guid("ab9ead21-8cff-426a-94de-0c15d3111f40"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("47793f44-5831-45e0-be42-4757e8c0268a"));
            TABNuclearMedicine = (ITTTabControl)AddControl(new Guid("71b3a436-479b-4990-8cb0-f2ce4d7d41ef"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("c5194cfd-968e-4402-969e-5dafb26042ef"));
            GridNuclearMedicineMaterial = (ITTGrid)AddControl(new Guid("6074bc1c-cccb-44e0-94f3-870b37226873"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b87645f0-e501-46eb-901e-11619ce1db04"));
            Material = (ITTListBoxColumn)AddControl(new Guid("160d0939-d243-4e03-8f9c-fcb59cf9e61a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("3eb8e1ae-d76c-410e-88a7-4d60979294c3"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("713bc074-15f0-4f18-8e28-100735b1f1f6"));
            Barkod = (ITTTextBoxColumn)AddControl(new Guid("263872a6-1859-4b4f-b757-24a5bcc7f152"));
            RadPharmMatTab = (ITTTabPage)AddControl(new Guid("10914c86-a1ae-4f2f-9c4a-1a17575f3573"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("66612f13-b737-4726-8db8-5297d3565fd3"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("aabbd244-e129-4853-a141-98c4ade827b5"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("a231b2ed-a038-4b04-aa85-4444c5996a8c"));
            IsInjection = (ITTCheckBoxColumn)AddControl(new Guid("3730203b-db09-443e-8b26-aafcaa8a2293"));
            tttextboxcolumn3 = (ITTTextBoxColumn)AddControl(new Guid("0d4bccaa-6bb0-41ce-91c2-eb22394e0471"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("e78c0a71-60cb-4d9d-a8bf-b8580c8718cd"));
            Units = (ITTListBoxColumn)AddControl(new Guid("13cf2fca-9302-4835-8993-06b5847fbf40"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("09156bb9-67a6-4bba-b70d-a2f72e42a306"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("273d84bb-b633-4676-aaf3-8b263e2f3863"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("ed3be732-902f-4a47-b882-41f3ce0c30a0"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("11cbdbc6-bf10-4ffc-9e86-a33a221e7eb5"));
            base.InitializeControls();
        }

        public NuclearMedicineProcedureForm() : base("NUCLEARMEDICINE", "NuclearMedicineProcedureForm")
        {
        }

        protected NuclearMedicineProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}