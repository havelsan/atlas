
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
    /// Sıvı Giriş - Çıkış Bilgileri
    /// </summary>
    public partial class NursingBodilyFluidIntakeOutputForm : BaseNursingDataEntryForm
    {
        protected TTObjectClasses.NursingBodilyFluidIntakeOutput _NursingBodilyFluidIntakeOutput
        {
            get { return (TTObjectClasses.NursingBodilyFluidIntakeOutput)_ttObject; }
        }

        protected ITTLabel outputLabel;
        protected ITTLabel intakeLabel;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelOtherFluidOutput;
        protected ITTTextBox OtherFluidOutput;
        protected ITTTextBox BloodLoss;
        protected ITTTextBox Stool;
        protected ITTTextBox Drainage4;
        protected ITTTextBox Drainage3;
        protected ITTTextBox Drainage2;
        protected ITTTextBox Drainage1;
        protected ITTTextBox Vomit;
        protected ITTTextBox Aspiration;
        protected ITTTextBox Urine;
        protected ITTTextBox FluidOutputFurtherExplanation;
        protected ITTTextBox FluidIntakeFurtherExplanation;
        protected ITTTextBox OtherFluidIntake;
        protected ITTTextBox PAC;
        protected ITTTextBox Sludge;
        protected ITTTextBox MilkAmount;
        protected ITTTextBox MilkType;
        protected ITTTextBox Irrigation;
        protected ITTTextBox SuppliedBlood;
        protected ITTTextBox Medicine;
        protected ITTTextBox VenousFluid;
        protected ITTTextBox NasogastricTube;
        protected ITTTextBox OralIntake;
        protected ITTTextBox Note;
        protected ITTLabel labelBloodLoss;
        protected ITTLabel labelStool;
        protected ITTLabel labelDrainage4;
        protected ITTLabel labelDrainage3;
        protected ITTLabel labelDrainage2;
        protected ITTLabel labelDrainage1;
        protected ITTLabel labelVomit;
        protected ITTLabel labelAspiration;
        protected ITTLabel labelUrine;
        protected ITTLabel labelFluidOutputFurtherExplanation;
        protected ITTLabel labelFluidIntakeFurtherExplanation;
        protected ITTLabel labelOtherFluidIntake;
        protected ITTLabel labelPAC;
        protected ITTLabel labelSludge;
        protected ITTLabel labelMilkAmount;
        protected ITTLabel labelMilkType;
        protected ITTLabel labelIrrigation;
        protected ITTLabel labelSuppliedBlood;
        protected ITTLabel labelMedicine;
        protected ITTLabel labelVenousFluid;
        protected ITTLabel labelNasogastricTube;
        protected ITTLabel labelOralIntake;
        protected ITTLabel labelNote;
        override protected void InitializeControls()
        {
            outputLabel = (ITTLabel)AddControl(new Guid("ad06c182-5d9c-4a68-b47f-2f5052741a70"));
            intakeLabel = (ITTLabel)AddControl(new Guid("fa40885b-ada3-42d0-9bd3-f0be93f2684e"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("4816cb9c-6a39-45c9-8f21-33c9731023d2"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("11cbcb8c-6d0c-4737-b796-a5955cbb092b"));
            labelOtherFluidOutput = (ITTLabel)AddControl(new Guid("e81b6dfe-c5d3-4bd2-937b-474e991bd6aa"));
            OtherFluidOutput = (ITTTextBox)AddControl(new Guid("09a74888-af16-4079-8291-ce76813f8b3c"));
            BloodLoss = (ITTTextBox)AddControl(new Guid("e607a8b5-f581-4d5d-b88e-70dc12e5ddd7"));
            Stool = (ITTTextBox)AddControl(new Guid("565d7299-5e10-4513-8941-4287f032dcf9"));
            Drainage4 = (ITTTextBox)AddControl(new Guid("6aa0a4f4-ff0e-4835-a467-b35319e66a9c"));
            Drainage3 = (ITTTextBox)AddControl(new Guid("a03dd012-79e9-436d-802e-a5f6f81a51df"));
            Drainage2 = (ITTTextBox)AddControl(new Guid("9f29f5ad-ca0d-4230-bb8f-a0e77b4f0ab7"));
            Drainage1 = (ITTTextBox)AddControl(new Guid("2e9180fa-1200-4e4f-ba4b-0a5fbc1c0ea3"));
            Vomit = (ITTTextBox)AddControl(new Guid("b47a95ae-3e12-4ec2-bd5b-0de72b9d1df5"));
            Aspiration = (ITTTextBox)AddControl(new Guid("966b1e9d-ec76-4c36-8cca-685570e2c0ea"));
            Urine = (ITTTextBox)AddControl(new Guid("656d3e6c-b3f1-4899-8930-99c12090178b"));
            FluidOutputFurtherExplanation = (ITTTextBox)AddControl(new Guid("dcdd0bee-a307-4cdf-b964-a389e28faf66"));
            FluidIntakeFurtherExplanation = (ITTTextBox)AddControl(new Guid("da4f7f64-38c2-44b8-a97d-59fd304ceebb"));
            OtherFluidIntake = (ITTTextBox)AddControl(new Guid("fee43c72-64ce-40dc-b4ac-626edf5abe3d"));
            PAC = (ITTTextBox)AddControl(new Guid("d8b9e627-c04e-4750-b94b-679b0edd829b"));
            Sludge = (ITTTextBox)AddControl(new Guid("f695aa73-da66-49d0-b44c-77c2586f79ff"));
            MilkAmount = (ITTTextBox)AddControl(new Guid("6783ff07-8431-429d-899c-4d6436b241b3"));
            MilkType = (ITTTextBox)AddControl(new Guid("11da2dae-d587-4167-b430-a78ffe486a5b"));
            Irrigation = (ITTTextBox)AddControl(new Guid("6a2d5c4d-a717-43a9-87dc-0ece51d1ae30"));
            SuppliedBlood = (ITTTextBox)AddControl(new Guid("9ab32dfe-22ea-4a8b-aa10-ac01d38f8f86"));
            Medicine = (ITTTextBox)AddControl(new Guid("2c2f67b8-718f-41d4-80fd-2406027812dc"));
            VenousFluid = (ITTTextBox)AddControl(new Guid("06aa0ab2-c19f-414d-b7e3-742d56483ba8"));
            NasogastricTube = (ITTTextBox)AddControl(new Guid("6ae43f69-931a-46f8-88de-c7628ac79350"));
            OralIntake = (ITTTextBox)AddControl(new Guid("80e22acb-2291-4e8c-9dcd-602c5f40212d"));
            Note = (ITTTextBox)AddControl(new Guid("2eab03bd-0739-48c5-8c48-14e1fa5b7403"));
            labelBloodLoss = (ITTLabel)AddControl(new Guid("5f7a0317-aeb6-4930-af44-d7b19229973e"));
            labelStool = (ITTLabel)AddControl(new Guid("39e823b8-6096-4e24-888c-40929340fe3e"));
            labelDrainage4 = (ITTLabel)AddControl(new Guid("68e45d22-dc76-492d-b787-64d35f9d3740"));
            labelDrainage3 = (ITTLabel)AddControl(new Guid("ec671429-704f-4bb0-869b-9bda86763f0e"));
            labelDrainage2 = (ITTLabel)AddControl(new Guid("f6b5e516-ecbe-43a0-809d-7789d0481bae"));
            labelDrainage1 = (ITTLabel)AddControl(new Guid("312e7fec-40cf-4fd8-a073-42dda3ec38b5"));
            labelVomit = (ITTLabel)AddControl(new Guid("f53de910-cd14-436b-a5ad-1ee0d07b0831"));
            labelAspiration = (ITTLabel)AddControl(new Guid("f25b56cb-e988-4e38-826d-2738e2aa8e28"));
            labelUrine = (ITTLabel)AddControl(new Guid("eb72acfc-d6e3-4d80-9b35-83284360a7ca"));
            labelFluidOutputFurtherExplanation = (ITTLabel)AddControl(new Guid("818ffdfc-6b5d-424b-8eb7-9552c0bc33a1"));
            labelFluidIntakeFurtherExplanation = (ITTLabel)AddControl(new Guid("db626cb3-e8f6-44ab-938c-7a76405e83c2"));
            labelOtherFluidIntake = (ITTLabel)AddControl(new Guid("afd42f76-0766-4d05-9308-d81668e0e248"));
            labelPAC = (ITTLabel)AddControl(new Guid("a8e5ca19-74a1-4fc2-9456-47b5757c3a18"));
            labelSludge = (ITTLabel)AddControl(new Guid("4e8bab8d-60ae-4fac-906b-97b728657554"));
            labelMilkAmount = (ITTLabel)AddControl(new Guid("df2fec68-4d02-4c44-b955-f4545e3c9ab0"));
            labelMilkType = (ITTLabel)AddControl(new Guid("acd4fd40-2559-4652-8c45-d6a3d20d0d84"));
            labelIrrigation = (ITTLabel)AddControl(new Guid("e2b798c5-926d-4158-8eca-276fe3a12794"));
            labelSuppliedBlood = (ITTLabel)AddControl(new Guid("5aa83bb5-eae2-4c2b-881e-31360d4e6817"));
            labelMedicine = (ITTLabel)AddControl(new Guid("90ac8d1f-c869-4509-af00-1578d51360d0"));
            labelVenousFluid = (ITTLabel)AddControl(new Guid("b64f460f-3f0d-44d1-b3cd-4dd0f5e2fab7"));
            labelNasogastricTube = (ITTLabel)AddControl(new Guid("ae5d51d6-eb52-4553-96b6-ebf4821f71e2"));
            labelOralIntake = (ITTLabel)AddControl(new Guid("7f0d45f6-5935-4938-ba2d-1fe97a73e701"));
            labelNote = (ITTLabel)AddControl(new Guid("1ac4ea90-e6c2-4791-a0cf-6f71dcb00c42"));
            base.InitializeControls();
        }

        public NursingBodilyFluidIntakeOutputForm() : base("NURSINGBODILYFLUIDINTAKEOUTPUT", "NursingBodilyFluidIntakeOutputForm")
        {
        }

        protected NursingBodilyFluidIntakeOutputForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}