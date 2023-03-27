
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
    public partial class NutritionDietForm : EpisodeActionForm
    {
        protected TTObjectClasses.NutritionDietAction _NutritionDietAction
        {
            get { return (TTObjectClasses.NutritionDietAction)_ttObject; }
        }

        protected ITTLabel labelDate;
        protected ITTDateTimePicker Date;
        protected ITTLabel labelResUser;
        protected ITTObjectListBox ResUser;
        protected ITTButton CalculateData;
        protected ITTCheckBox Snack3DietDefinition;
        protected ITTCheckBox Snack2DietDefinition;
        protected ITTCheckBox Snack1DietDefinition;
        protected ITTCheckBox NightBreakfastDietDefinition;
        protected ITTCheckBox LunchDietDefinition;
        protected ITTCheckBox DinnerDietDefinition;
        protected ITTCheckBox BreakfastDietDefinition;
        protected ITTLabel labelDietDefinition;
        protected ITTObjectListBox DietDefinition;
        protected ITTLabel labelWeight;
        protected ITTTextBox Weight;
        protected ITTTextBox LeanBodyMass;
        protected ITTTextBox IdealBodyWeight;
        protected ITTTextBox Height;
        protected ITTTextBox BodySurfaceArea;
        protected ITTTextBox BodyMassIndex;
        protected ITTTextBox BasalMetabolism;
        protected ITTLabel labelLeanBodyMass;
        protected ITTLabel labelInterpretingBodyMassIndex;
        protected ITTEnumComboBox InterpretingBodyMassIndex;
        protected ITTLabel labelIdealBodyWeight;
        protected ITTLabel labelHeight;
        protected ITTLabel labelControlDate;
        protected ITTDateTimePicker ControlDate;
        protected ITTLabel labelBodySurfaceArea;
        protected ITTLabel labelBodyMassIndex;
        protected ITTLabel labelBasalMetabolism;
        protected ITTLabel labelApplication;
        protected ITTRichTextBoxControl Application;
        override protected void InitializeControls()
        {
            labelDate = (ITTLabel)AddControl(new Guid("9345ef1b-8cbf-4e36-bcd1-88c6f73cf7e9"));
            Date = (ITTDateTimePicker)AddControl(new Guid("34ea3105-7cd0-464d-a687-ce062924d72e"));
            labelResUser = (ITTLabel)AddControl(new Guid("4810f435-5b91-4485-ad21-704509f7a6bb"));
            ResUser = (ITTObjectListBox)AddControl(new Guid("c59e3425-38d8-4008-887f-85d0e6c7fccb"));
            CalculateData = (ITTButton)AddControl(new Guid("b058010c-6bf5-421f-9f0c-46e827ae4ad5"));
            Snack3DietDefinition = (ITTCheckBox)AddControl(new Guid("2fec7cbd-f353-4255-9206-22d703bc908c"));
            Snack2DietDefinition = (ITTCheckBox)AddControl(new Guid("cd345742-ccf8-4058-a4e4-c3e6ce605b1c"));
            Snack1DietDefinition = (ITTCheckBox)AddControl(new Guid("4919ce37-f7da-45a4-9d2b-702fcbbab364"));
            NightBreakfastDietDefinition = (ITTCheckBox)AddControl(new Guid("ca50e490-ebee-4ff4-b4d7-63f5abee8096"));
            LunchDietDefinition = (ITTCheckBox)AddControl(new Guid("a7b579d9-ea6f-403f-ac2c-83a09c0bd735"));
            DinnerDietDefinition = (ITTCheckBox)AddControl(new Guid("17b5e15b-9467-46fd-be2f-a5c71ee2c484"));
            BreakfastDietDefinition = (ITTCheckBox)AddControl(new Guid("2e70a324-83f6-46d9-b4ac-6b95b0d6b45c"));
            labelDietDefinition = (ITTLabel)AddControl(new Guid("1a7ce3a6-1a2d-402a-bddb-bcbfb54d6731"));
            DietDefinition = (ITTObjectListBox)AddControl(new Guid("a130b987-718a-4adb-b917-c62fb8468de6"));
            labelWeight = (ITTLabel)AddControl(new Guid("73197ef5-832c-4075-a49b-fc0664c15e06"));
            Weight = (ITTTextBox)AddControl(new Guid("e0d745bc-4a61-4791-8d92-26f8e6a80c11"));
            LeanBodyMass = (ITTTextBox)AddControl(new Guid("5e0f5745-e307-4525-80c5-851053a14fbc"));
            IdealBodyWeight = (ITTTextBox)AddControl(new Guid("9f738045-53c7-49fc-9453-ac63962aaf2d"));
            Height = (ITTTextBox)AddControl(new Guid("05bb6858-efc7-478a-abff-ee7d52054855"));
            BodySurfaceArea = (ITTTextBox)AddControl(new Guid("49b587c2-ab75-49c2-84e5-f01db0776484"));
            BodyMassIndex = (ITTTextBox)AddControl(new Guid("afb76c02-dac0-415f-9a05-2153dd178a82"));
            BasalMetabolism = (ITTTextBox)AddControl(new Guid("70dc74eb-01b0-43ae-8de2-fe8e79190c3f"));
            labelLeanBodyMass = (ITTLabel)AddControl(new Guid("0bbc0519-1bc7-46d4-877a-eb71a0d21bc1"));
            labelInterpretingBodyMassIndex = (ITTLabel)AddControl(new Guid("99d1ab0d-d677-4c6f-a879-15f404b3139a"));
            InterpretingBodyMassIndex = (ITTEnumComboBox)AddControl(new Guid("ea420a6d-9f9a-4db6-91b3-23975c7c5396"));
            labelIdealBodyWeight = (ITTLabel)AddControl(new Guid("920b70da-ca7f-4b8c-a511-e5ad8fda12de"));
            labelHeight = (ITTLabel)AddControl(new Guid("78e4e760-e707-47ee-a576-d7fa20f81041"));
            labelControlDate = (ITTLabel)AddControl(new Guid("6dc6d0a8-dd78-465c-b294-a0e4dd2ce231"));
            ControlDate = (ITTDateTimePicker)AddControl(new Guid("7dce8a58-26f9-446e-b838-074adc4eb3db"));
            labelBodySurfaceArea = (ITTLabel)AddControl(new Guid("94d7c10a-5161-4f03-b702-2bdfa5e22062"));
            labelBodyMassIndex = (ITTLabel)AddControl(new Guid("39d9ec4b-0f41-414b-bbda-afcd0173dab5"));
            labelBasalMetabolism = (ITTLabel)AddControl(new Guid("231b3290-0ebd-49ae-b2de-5dc675847c97"));
            labelApplication = (ITTLabel)AddControl(new Guid("da721a37-9669-4c43-b716-d657a47eb0d1"));
            Application = (ITTRichTextBoxControl)AddControl(new Guid("744d0f78-7da0-4fd9-9209-d22098057176"));
            base.InitializeControls();
        }

        public NutritionDietForm() : base("NUTRITIONDIETACTION", "NutritionDietForm")
        {
        }

        protected NutritionDietForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}