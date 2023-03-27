
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
    public partial class GynecologyForm : TTForm
    {
        protected TTObjectClasses.Gynecology _Gynecology
        {
            get { return (TTObjectClasses.Gynecology)_ttObject; }
        }

        protected ITTLabel labelReproductiveAbnormality;
        protected ITTObjectListBox ReproductiveAbnormality;
        protected ITTLabel labelVulvaVagen;
        protected ITTTextBox VulvaVagen;
        protected ITTTextBox VaginalDischargeInformation;
        protected ITTTextBox Uterus;
        protected ITTTextBox TumorMarkers;
        protected ITTTextBox ReproductiveAbnormalitiesInfo;
        protected ITTTextBox PelvicExamination;
        protected ITTTextBox MenstrualCycleInformation;
        protected ITTTextBox HirsutismInformation;
        protected ITTTextBox GynecologicalHistory;
        protected ITTTextBox GenitalExamination;
        protected ITTTextBox GenitalAbnormalitiesInfo;
        protected ITTTextBox DysuriaInformation;
        protected ITTTextBox DyspareuniaInformation;
        protected ITTTextBox Cervix;
        protected ITTTextBox BasalUltrasound;
        protected ITTLabel labelVaginalDischargeInformation;
        protected ITTCheckBox VaginalDischarge;
        protected ITTLabel labelUterus;
        protected ITTLabel labelTumorMarkers;
        protected ITTLabel labelReproductiveAbnormalitiesInfo;
        protected ITTLabel labelPreviousBirthControlMethod;
        protected ITTEnumComboBox PreviousBirthControlMethod;
        protected ITTLabel labelPelvicExamination;
        protected ITTLabel labelMenstrualCycleInformation;
        protected ITTLabel labelMenstrualCycleAbnormalities;
        protected ITTEnumComboBox MenstrualCycleAbnormalities;
        protected ITTLabel labelLastSmearDate;
        protected ITTDateTimePicker LastSmearDate;
        protected ITTLabel labelLastExaminationDate;
        protected ITTDateTimePicker LastExaminationDate;
        protected ITTLabel labelHirsutismInformation;
        protected ITTCheckBox Hirsutism;
        protected ITTLabel labelGynecologicalHistory;
        protected ITTLabel labelGenitalExamination;
        protected ITTLabel labelGenitalAbnormalitiesInfo;
        protected ITTLabel labelGenitalAbnormalities;
        protected ITTEnumComboBox GenitalAbnormalities;
        protected ITTLabel labelDysuriaInformation;
        protected ITTCheckBox Dysuria;
        protected ITTLabel labelDyspareuniaInformation;
        protected ITTCheckBox Dyspareunia;
        protected ITTLabel labelCurrentBirthControlMethod;
        protected ITTEnumComboBox CurrentBirthControlMethod;
        protected ITTLabel labelCervix;
        protected ITTLabel labelBasalUltrasound;
        override protected void InitializeControls()
        {
            labelReproductiveAbnormality = (ITTLabel)AddControl(new Guid("43090a81-5d73-48bb-bb4f-bcae6e1ff97c"));
            ReproductiveAbnormality = (ITTObjectListBox)AddControl(new Guid("24d46d30-2417-406b-8545-3972b2390168"));
            labelVulvaVagen = (ITTLabel)AddControl(new Guid("6ad60f10-aa01-4ba2-a367-41a2c4911fb1"));
            VulvaVagen = (ITTTextBox)AddControl(new Guid("34436fc6-1bc7-4e7d-a7bf-a1f0ad3e0ff6"));
            VaginalDischargeInformation = (ITTTextBox)AddControl(new Guid("40817ab6-5825-4df6-85d6-0d14390479ee"));
            Uterus = (ITTTextBox)AddControl(new Guid("40d7704c-61b0-4289-8856-63e6c60291c3"));
            TumorMarkers = (ITTTextBox)AddControl(new Guid("264a54d5-c093-4885-9774-9339e4ffa593"));
            ReproductiveAbnormalitiesInfo = (ITTTextBox)AddControl(new Guid("70bbc1d0-cba3-4602-994d-084aa916110e"));
            PelvicExamination = (ITTTextBox)AddControl(new Guid("dccb19bd-0ce2-4052-823c-6d1cc179ce70"));
            MenstrualCycleInformation = (ITTTextBox)AddControl(new Guid("7e9caff7-fffe-4f41-a8a8-d91b29908d84"));
            HirsutismInformation = (ITTTextBox)AddControl(new Guid("caf1daae-d293-4c42-99cb-6596022e9b8b"));
            GynecologicalHistory = (ITTTextBox)AddControl(new Guid("6dcd69a3-5296-4ace-a4e9-464cd14d81f2"));
            GenitalExamination = (ITTTextBox)AddControl(new Guid("45e1b428-c693-411d-894c-08dbbb75e2ec"));
            GenitalAbnormalitiesInfo = (ITTTextBox)AddControl(new Guid("0efba369-c3fa-484b-82c9-c16b0f4b77e5"));
            DysuriaInformation = (ITTTextBox)AddControl(new Guid("90a9de15-a790-4a82-9563-bbdf3b51023d"));
            DyspareuniaInformation = (ITTTextBox)AddControl(new Guid("3a54a344-46f8-4b9b-af66-a4a50fde8a5c"));
            Cervix = (ITTTextBox)AddControl(new Guid("ccc29cfa-f7c6-469a-95ce-dccb2a6a8ba9"));
            BasalUltrasound = (ITTTextBox)AddControl(new Guid("ac725f13-bf5e-4f71-902c-b49bf9fab4cc"));
            labelVaginalDischargeInformation = (ITTLabel)AddControl(new Guid("89ffa936-ce49-4380-bcd1-529fce9cc4eb"));
            VaginalDischarge = (ITTCheckBox)AddControl(new Guid("e3d22612-348a-4b02-b41d-55a8d871f0f2"));
            labelUterus = (ITTLabel)AddControl(new Guid("999f68f3-64e5-41d1-9d47-f5cb1eb7e16f"));
            labelTumorMarkers = (ITTLabel)AddControl(new Guid("9cd62a21-df58-4bed-8cef-835ff63a511a"));
            labelReproductiveAbnormalitiesInfo = (ITTLabel)AddControl(new Guid("15265023-8a6d-47cf-a4c7-678e107206dd"));
            labelPreviousBirthControlMethod = (ITTLabel)AddControl(new Guid("7c0ab612-b608-4c2e-8974-795be2608442"));
            PreviousBirthControlMethod = (ITTEnumComboBox)AddControl(new Guid("6e561938-6884-4e22-9119-e44f3bb06e15"));
            labelPelvicExamination = (ITTLabel)AddControl(new Guid("1c51f50a-f459-46c0-ab7d-eb43592a7066"));
            labelMenstrualCycleInformation = (ITTLabel)AddControl(new Guid("ceeaccdd-a43c-4c8f-b261-b47bab27f1fb"));
            labelMenstrualCycleAbnormalities = (ITTLabel)AddControl(new Guid("4ecb8262-4580-4949-b5c0-8ea6fcc659eb"));
            MenstrualCycleAbnormalities = (ITTEnumComboBox)AddControl(new Guid("92405227-58d0-4a8a-b0b3-215e0bd4f09e"));
            labelLastSmearDate = (ITTLabel)AddControl(new Guid("332ce6f7-888f-4162-96e3-ec654ea207e6"));
            LastSmearDate = (ITTDateTimePicker)AddControl(new Guid("0c3b99be-0f95-418c-842b-f0125822e61c"));
            labelLastExaminationDate = (ITTLabel)AddControl(new Guid("65bbbd2e-6a51-4f32-8cf3-6fae3dff051d"));
            LastExaminationDate = (ITTDateTimePicker)AddControl(new Guid("e54799e5-aace-402c-becb-cf59d43c48d8"));
            labelHirsutismInformation = (ITTLabel)AddControl(new Guid("88b30c8b-933d-4133-8be1-77e72a873042"));
            Hirsutism = (ITTCheckBox)AddControl(new Guid("c352c694-c61f-4681-99be-7bdfdf2bd083"));
            labelGynecologicalHistory = (ITTLabel)AddControl(new Guid("91bd0870-3c71-40e4-8dd8-1d2311205dcc"));
            labelGenitalExamination = (ITTLabel)AddControl(new Guid("0dd62427-ae3a-456a-a2d0-30b282962487"));
            labelGenitalAbnormalitiesInfo = (ITTLabel)AddControl(new Guid("eaf66684-d1e3-44ae-bca3-26aeb419005b"));
            labelGenitalAbnormalities = (ITTLabel)AddControl(new Guid("4dd4b5ac-197a-4f0c-a865-4bfd5a758fef"));
            GenitalAbnormalities = (ITTEnumComboBox)AddControl(new Guid("79cb9afe-d177-4185-b2c4-0e787ac7e082"));
            labelDysuriaInformation = (ITTLabel)AddControl(new Guid("c645a6cf-6825-4c61-ac9b-36d2cfca622d"));
            Dysuria = (ITTCheckBox)AddControl(new Guid("76858aaf-745b-410e-aedf-46b291b49929"));
            labelDyspareuniaInformation = (ITTLabel)AddControl(new Guid("f8584718-4125-4e7e-9415-5a218a91587d"));
            Dyspareunia = (ITTCheckBox)AddControl(new Guid("2e002075-37b1-46ce-932e-406a2b0ae8e1"));
            labelCurrentBirthControlMethod = (ITTLabel)AddControl(new Guid("9af305d2-eba2-44ff-a92d-ec3e08f46dbf"));
            CurrentBirthControlMethod = (ITTEnumComboBox)AddControl(new Guid("6bfb6171-d174-4987-8583-e5e75ebf7ee8"));
            labelCervix = (ITTLabel)AddControl(new Guid("b3dd0933-9c10-4714-96de-ad8f7408acef"));
            labelBasalUltrasound = (ITTLabel)AddControl(new Guid("dc39d14c-5852-46e6-bdf0-095ebd658cfd"));
            base.InitializeControls();
        }

        public GynecologyForm() : base("GYNECOLOGY", "GynecologyForm")
        {
        }

        protected GynecologyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}