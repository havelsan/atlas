
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
    public partial class NursingBodilyFluidAnalysisForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Sıvı Giriş Çıkış Takibi
    /// </summary>
        protected TTObjectClasses.NursingBodyFluidAnalysis _NursingBodyFluidAnalysis
        {
            get { return (TTObjectClasses.NursingBodyFluidAnalysis)_ttObject; }
        }

        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelTotalVomit;
        protected ITTTextBox TotalVomit;
        protected ITTTextBox TotalVenousFluid;
        protected ITTTextBox TotalUrine;
        protected ITTTextBox TotalSuppliedBlood;
        protected ITTTextBox TotalStool;
        protected ITTTextBox TotalSludge;
        protected ITTTextBox TotalOtherBodilyFluidsTaken;
        protected ITTTextBox TotalOtherBodilyFluidLoss;
        protected ITTTextBox TotalOralIntake;
        protected ITTTextBox TotalNGC;
        protected ITTTextBox TotalMilkAmount;
        protected ITTTextBox TotalMed;
        protected ITTTextBox TotalIrrigation;
        protected ITTTextBox TotalDrainage;
        protected ITTTextBox TotalBloodLoss;
        protected ITTTextBox TotalAspiration;
        protected ITTTextBox TotalPAC;
        protected ITTLabel labelTotalVenousFluid;
        protected ITTLabel labelTotalUrine;
        protected ITTLabel labelTotalSuppliedBlood;
        protected ITTLabel labelTotalStool;
        protected ITTLabel labelTotalSludge;
        protected ITTLabel labelTotalOtherBodilyFluidsTaken;
        protected ITTLabel labelTotalOtherBodilyFluidLoss;
        protected ITTLabel labelTotalOralIntake;
        protected ITTLabel labelTotalNGC;
        protected ITTLabel labelTotalMilkAmount;
        protected ITTLabel labelTotalMed;
        protected ITTLabel labelTotalIrrigation;
        protected ITTLabel labelTotalDrainage;
        protected ITTLabel labelTotalBloodLoss;
        protected ITTLabel labelTotalAspiration;
        protected ITTLabel labelTotalPAC;
        override protected void InitializeControls()
        {
            labelApplicationDate = (ITTLabel)AddControl(new Guid("c781667a-ed1f-4621-80a9-5b9096d42bd0"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("08b46880-9e85-4420-9cb3-0a3b6a5999ab"));
            labelTotalVomit = (ITTLabel)AddControl(new Guid("a049fee6-19a1-48c2-8011-a4eabeb0328e"));
            TotalVomit = (ITTTextBox)AddControl(new Guid("a2f50b8f-1997-4cd8-b654-8939a260f23f"));
            TotalVenousFluid = (ITTTextBox)AddControl(new Guid("52daa437-c46e-40f9-9f32-a7521d52229b"));
            TotalUrine = (ITTTextBox)AddControl(new Guid("d8c36975-6553-483d-88a7-47cde19bf429"));
            TotalSuppliedBlood = (ITTTextBox)AddControl(new Guid("b4767bb2-c2d4-4e12-8636-10fc4efdf78a"));
            TotalStool = (ITTTextBox)AddControl(new Guid("eaca752e-e554-48aa-8b30-fabcbdbfc262"));
            TotalSludge = (ITTTextBox)AddControl(new Guid("0cb9bd9e-8a9e-4c3e-95f0-894637dfbda9"));
            TotalOtherBodilyFluidsTaken = (ITTTextBox)AddControl(new Guid("fd1f2068-c548-4572-af1a-54c16eb9c5af"));
            TotalOtherBodilyFluidLoss = (ITTTextBox)AddControl(new Guid("c49572bc-03f9-4d23-930a-4d01e79e1612"));
            TotalOralIntake = (ITTTextBox)AddControl(new Guid("ccdb63fa-0695-475b-9818-223a9edc9b74"));
            TotalNGC = (ITTTextBox)AddControl(new Guid("d61a8722-8664-4090-9057-ddaf48013700"));
            TotalMilkAmount = (ITTTextBox)AddControl(new Guid("8823e500-2339-42b6-bfc1-9b277461b3d5"));
            TotalMed = (ITTTextBox)AddControl(new Guid("50b1a8fd-298a-4c4d-b342-4cb2a87d1ecb"));
            TotalIrrigation = (ITTTextBox)AddControl(new Guid("603f11ce-2591-4cbb-911f-48caa8672f6c"));
            TotalDrainage = (ITTTextBox)AddControl(new Guid("4de992b1-170f-41ef-934b-02580c266129"));
            TotalBloodLoss = (ITTTextBox)AddControl(new Guid("deaea390-7869-4169-b52b-d947b2d13151"));
            TotalAspiration = (ITTTextBox)AddControl(new Guid("26d70092-a147-43d5-b77d-0eb5bd3d7c2f"));
            TotalPAC = (ITTTextBox)AddControl(new Guid("41d9e568-e155-4742-a334-690ebefb3fd1"));
            labelTotalVenousFluid = (ITTLabel)AddControl(new Guid("22657eae-a66e-4cf0-87b1-4a2ce8339010"));
            labelTotalUrine = (ITTLabel)AddControl(new Guid("2d914d65-c1b9-41f8-93aa-c8917e3fb14f"));
            labelTotalSuppliedBlood = (ITTLabel)AddControl(new Guid("f6270cb5-1d7b-4923-ab37-c5ace238bd77"));
            labelTotalStool = (ITTLabel)AddControl(new Guid("8aab7d15-064a-40d8-a3e0-cef1c92d3907"));
            labelTotalSludge = (ITTLabel)AddControl(new Guid("7d41d618-1784-40a1-8b82-832681f5589f"));
            labelTotalOtherBodilyFluidsTaken = (ITTLabel)AddControl(new Guid("883aed51-6f96-4e31-9652-00d00f46f770"));
            labelTotalOtherBodilyFluidLoss = (ITTLabel)AddControl(new Guid("168305ed-eed9-4eec-9c70-3b62a37b2c8d"));
            labelTotalOralIntake = (ITTLabel)AddControl(new Guid("b16aa1cf-eeb0-43f8-bf54-be0b6b7668c5"));
            labelTotalNGC = (ITTLabel)AddControl(new Guid("2cffe51d-ff1a-4653-a1be-7d288848883f"));
            labelTotalMilkAmount = (ITTLabel)AddControl(new Guid("10ee6c5a-6b8b-43f6-9403-e6cd4688bfd6"));
            labelTotalMed = (ITTLabel)AddControl(new Guid("af0d47c9-e793-44a9-a148-6d79eb6a9d6f"));
            labelTotalIrrigation = (ITTLabel)AddControl(new Guid("6f4447e9-be60-43ca-a6ea-6a562ff87d3d"));
            labelTotalDrainage = (ITTLabel)AddControl(new Guid("97a2dd7f-8fa7-4504-84ac-e88f29e73b19"));
            labelTotalBloodLoss = (ITTLabel)AddControl(new Guid("f3be6837-e933-4af8-a89c-d51d35570800"));
            labelTotalAspiration = (ITTLabel)AddControl(new Guid("8878a2df-c5c4-4d1d-b910-34036c40b011"));
            labelTotalPAC = (ITTLabel)AddControl(new Guid("2e9e4b36-b42e-444e-8bfa-f549a15477e6"));
            base.InitializeControls();
        }

        public NursingBodilyFluidAnalysisForm() : base("NURSINGBODYFLUIDANALYSIS", "NursingBodilyFluidAnalysisForm")
        {
        }

        protected NursingBodilyFluidAnalysisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}