
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
    public partial class NursingWoundAssessmentScaleForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Bası Yarası Değerlendirme Skalası Formu
    /// </summary>
        protected TTObjectClasses.NursingWoundAssessmentScale _NursingWoundAssessmentScale
        {
            get { return (TTObjectClasses.NursingWoundAssessmentScale)_ttObject; }
        }

        protected ITTLabel labelNursingWoundTime;
        protected ITTEnumComboBox NursingWoundTime;
        protected ITTLabel labelGradeDistribution;
        protected ITTEnumComboBox GradeDistribution;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelSurgery;
        protected ITTLabel labelDM;
        protected ITTLabel labelAppetite;
        protected ITTLabel labelMedicineUsage;
        protected ITTLabel labelSkinType;
        protected ITTCheckBox SurgeryLongerThan2Hours;
        protected ITTCheckBox SurgeryOrthopedic;
        protected ITTCheckBox DMCigaretteUsage;
        protected ITTCheckBox DMAnemia;
        protected ITTCheckBox DMPeripheralVascularDisease;
        protected ITTCheckBox DMHeartFailure;
        protected ITTCheckBox DMTerminalCachexia;
        protected ITTCheckBox AppetiteAnorexia;
        protected ITTCheckBox AppetiteOnlyLiquid;
        protected ITTCheckBox AppetiteNg;
        protected ITTCheckBox AppetitePoor;
        protected ITTCheckBox AppetiteAverage;
        protected ITTCheckBox MedicineUsage;
        protected ITTCheckBox SkinIntegrityBroken;
        protected ITTCheckBox SkinDiscolored;
        protected ITTCheckBox SkinColdAndMoist;
        protected ITTCheckBox SkinDropsy;
        protected ITTCheckBox SkinDry;
        protected ITTCheckBox SkinThin;
        protected ITTCheckBox SkinHealthy;
        protected ITTLabel labelMobility;
        protected ITTEnumComboBox Mobility;
        protected ITTLabel labelNeurologicalDisorders;
        protected ITTEnumComboBox NeurologicalDisorders;
        protected ITTLabel labelContinence;
        protected ITTEnumComboBox Continence;
        protected ITTLabel labelBodyType;
        protected ITTEnumComboBox BodyType;
        override protected void InitializeControls()
        {
            labelNursingWoundTime = (ITTLabel)AddControl(new Guid("b9f86ebf-e3ef-449c-b54b-4f1defbbe78e"));
            NursingWoundTime = (ITTEnumComboBox)AddControl(new Guid("088ef8d4-6e2c-4798-84d8-0bb1cc02040c"));
            labelGradeDistribution = (ITTLabel)AddControl(new Guid("f8c982cb-a4f2-41a0-99ed-979dee91d041"));
            GradeDistribution = (ITTEnumComboBox)AddControl(new Guid("f01c24a9-de25-4f54-ae91-8532e893ed3f"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("7a05eabc-1c6a-4aee-9c2c-74b9c3a8eac6"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("2242da4d-12d5-478e-a88b-039f41d5cb13"));
            labelSurgery = (ITTLabel)AddControl(new Guid("e0770a65-b9c3-43bb-9141-b16ee8992c0f"));
            labelDM = (ITTLabel)AddControl(new Guid("ef1a42e5-40f0-4cc7-b1cd-bf6ec8742cbb"));
            labelAppetite = (ITTLabel)AddControl(new Guid("86723718-24d6-4e30-a459-b0cdb9fca11b"));
            labelMedicineUsage = (ITTLabel)AddControl(new Guid("6fa25742-9b0c-4273-9d14-233c54987c75"));
            labelSkinType = (ITTLabel)AddControl(new Guid("ef028434-9744-4fc0-839e-a1f490a63847"));
            SurgeryLongerThan2Hours = (ITTCheckBox)AddControl(new Guid("1fa9a99b-e184-4f39-9c2b-53c5d412067b"));
            SurgeryOrthopedic = (ITTCheckBox)AddControl(new Guid("5f4a0312-cb17-467b-870b-beed3e80d4c4"));
            DMCigaretteUsage = (ITTCheckBox)AddControl(new Guid("da39db06-de9e-4931-9caa-e869265d01cf"));
            DMAnemia = (ITTCheckBox)AddControl(new Guid("9a7808ac-9d28-4e01-9c3d-7e73790056a2"));
            DMPeripheralVascularDisease = (ITTCheckBox)AddControl(new Guid("2b222136-2a15-4f25-bff8-9b5eb4d49455"));
            DMHeartFailure = (ITTCheckBox)AddControl(new Guid("c5b3f0b7-71c8-4ff7-8b78-0169721f405f"));
            DMTerminalCachexia = (ITTCheckBox)AddControl(new Guid("223fd019-e626-4038-8d28-91fd0ab7cb22"));
            AppetiteAnorexia = (ITTCheckBox)AddControl(new Guid("85ff1e89-afa2-4dc0-b846-e231f23de11a"));
            AppetiteOnlyLiquid = (ITTCheckBox)AddControl(new Guid("81939ce4-aedf-4e7f-baaa-e9d33fa5b991"));
            AppetiteNg = (ITTCheckBox)AddControl(new Guid("9976c557-cd44-49f3-bd9e-d93bc1fa1856"));
            AppetitePoor = (ITTCheckBox)AddControl(new Guid("fac54f42-a70c-4b5d-a7ba-a8086db96871"));
            AppetiteAverage = (ITTCheckBox)AddControl(new Guid("cc3c2bbc-ec98-4e9c-b968-bf136d8f15e3"));
            MedicineUsage = (ITTCheckBox)AddControl(new Guid("3cbab9f8-ec12-4b80-bdf5-c63ec4629125"));
            SkinIntegrityBroken = (ITTCheckBox)AddControl(new Guid("a9990774-a441-4e25-b2bb-838a284d0070"));
            SkinDiscolored = (ITTCheckBox)AddControl(new Guid("89e20570-d0df-4ea3-bf4a-0061e0c61666"));
            SkinColdAndMoist = (ITTCheckBox)AddControl(new Guid("b7dba641-7e19-4b21-8d6d-331c0e91a876"));
            SkinDropsy = (ITTCheckBox)AddControl(new Guid("60e85291-7fb2-4d06-a750-74134a366512"));
            SkinDry = (ITTCheckBox)AddControl(new Guid("132e0fb3-e5fc-4329-953a-500bdae6609d"));
            SkinThin = (ITTCheckBox)AddControl(new Guid("0cfd56b6-9b17-46af-a217-2ce37cbc22d0"));
            SkinHealthy = (ITTCheckBox)AddControl(new Guid("fc6f37d1-3e56-4d61-afbb-ca555670d85c"));
            labelMobility = (ITTLabel)AddControl(new Guid("c55a3960-e4eb-4853-99be-39998c6d98ce"));
            Mobility = (ITTEnumComboBox)AddControl(new Guid("009105c5-c985-48b4-9cdc-d22f83812240"));
            labelNeurologicalDisorders = (ITTLabel)AddControl(new Guid("4aa540ca-982d-4180-bb8f-b4c0bf285a1d"));
            NeurologicalDisorders = (ITTEnumComboBox)AddControl(new Guid("fc884123-a053-40f3-b801-00dc03f5c1e6"));
            labelContinence = (ITTLabel)AddControl(new Guid("8154b45e-0f2c-4f47-88d8-b03e46642e6f"));
            Continence = (ITTEnumComboBox)AddControl(new Guid("9fe75284-9fdb-4f94-873f-3b36ab49b221"));
            labelBodyType = (ITTLabel)AddControl(new Guid("bdb37565-4e28-4e6b-9d42-40c114cdea39"));
            BodyType = (ITTEnumComboBox)AddControl(new Guid("2696db0e-e281-4da6-b5b0-0d8b1a41c861"));
            base.InitializeControls();
        }

        public NursingWoundAssessmentScaleForm() : base("NURSINGWOUNDASSESSMENTSCALE", "NursingWoundAssessmentScaleForm")
        {
        }

        protected NursingWoundAssessmentScaleForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}