
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
    public partial class NursingNutritionAssessmentForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Beslenme Değerlendirme
    /// </summary>
        protected TTObjectClasses.NursingNutritionAssessment _NursingNutritionAssessment
        {
            get { return (TTObjectClasses.NursingNutritionAssessment)_ttObject; }
        }

        protected ITTLabel labelNursingDiet;
        protected ITTObjectListBox NursingDiet;
        protected ITTLabel labelTooth;
        protected ITTObjectListBox Tooth;
        protected ITTLabel labelUrge;
        protected ITTObjectListBox Urge;
        protected ITTLabel labelSwallow;
        protected ITTObjectListBox Swallow;
        protected ITTLabel labelPanorama;
        protected ITTObjectListBox Panorama;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTCheckBox NasogastricTube;
        protected ITTLabel labelRightLegCircle;
        protected ITTTextBox RightLegCircle;
        protected ITTTextBox LeftLegCircle;
        protected ITTTextBox AbdominalCircle;
        protected ITTTextBox WeightChangeNote;
        protected ITTTextBox WeightChange;
        protected ITTTextBox Height;
        protected ITTTextBox Weight;
        protected ITTLabel labelLeftLegCircle;
        protected ITTCheckBox Gastronomy;
        protected ITTLabel labelAbdominalCircle;
        protected ITTLabel labelWeightChangeNote;
        protected ITTLabel labelWeightChange;
        protected ITTLabel labelHeight;
        protected ITTLabel labelWeight;
        override protected void InitializeControls()
        {
            labelNursingDiet = (ITTLabel)AddControl(new Guid("7329138b-ea87-413f-9bac-df9f3d86b85c"));
            NursingDiet = (ITTObjectListBox)AddControl(new Guid("bb7cce58-bde7-4cdd-96e0-b7e1d736c929"));
            labelTooth = (ITTLabel)AddControl(new Guid("93a3c305-f770-439e-86ef-1b45e954a4a7"));
            Tooth = (ITTObjectListBox)AddControl(new Guid("e7aa35eb-b452-418f-bef0-d0d137b1fcaa"));
            labelUrge = (ITTLabel)AddControl(new Guid("838c42fb-04f6-4d11-aba4-df695dd4ae9f"));
            Urge = (ITTObjectListBox)AddControl(new Guid("afa0717e-77ab-46b6-97f9-4b7677355c91"));
            labelSwallow = (ITTLabel)AddControl(new Guid("4e4511f6-5200-4556-907c-1ee538efb1c6"));
            Swallow = (ITTObjectListBox)AddControl(new Guid("fe790425-8873-4ea7-a7c6-6e627ededf14"));
            labelPanorama = (ITTLabel)AddControl(new Guid("83bde2cb-2a05-4519-a712-87ff573c1751"));
            Panorama = (ITTObjectListBox)AddControl(new Guid("024c8bbf-3cc1-4e79-8b01-b7b7fff3d0f7"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("f1b31461-7498-49db-98ce-69377020fa55"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("f8d96a47-5a48-4f5a-b98e-d65a2f179ed6"));
            NasogastricTube = (ITTCheckBox)AddControl(new Guid("b313ed4c-6ca4-4dda-8809-7f8b0daa55c0"));
            labelRightLegCircle = (ITTLabel)AddControl(new Guid("131f71f9-1ce5-4d3f-b494-ab1ca7ea11a6"));
            RightLegCircle = (ITTTextBox)AddControl(new Guid("9f4c8397-52b3-47b9-af79-75ce33fc86cc"));
            LeftLegCircle = (ITTTextBox)AddControl(new Guid("84cc18b5-39f4-4d61-ae75-2f9d12ac0211"));
            AbdominalCircle = (ITTTextBox)AddControl(new Guid("6886951f-7ffe-4212-ad20-aea979adc014"));
            WeightChangeNote = (ITTTextBox)AddControl(new Guid("35323a15-4b66-4333-8d2c-694c98b9a342"));
            WeightChange = (ITTTextBox)AddControl(new Guid("6ffdb377-1e11-4205-aced-2f8debe3c49e"));
            Height = (ITTTextBox)AddControl(new Guid("c8c333f9-37d9-4cb5-b978-b66c2eed667a"));
            Weight = (ITTTextBox)AddControl(new Guid("3a157034-22a6-40fa-9549-98728a810de2"));
            labelLeftLegCircle = (ITTLabel)AddControl(new Guid("e75f6ae0-62b9-46ee-b710-68a7341664ad"));
            Gastronomy = (ITTCheckBox)AddControl(new Guid("22a54c57-dbf4-4232-970c-95dd15ba5257"));
            labelAbdominalCircle = (ITTLabel)AddControl(new Guid("3cc1fa50-4d5b-4a14-ac70-1bff6e6daf8f"));
            labelWeightChangeNote = (ITTLabel)AddControl(new Guid("fd542b09-dc1f-4f54-9d06-d406a73ce387"));
            labelWeightChange = (ITTLabel)AddControl(new Guid("454c3c2e-ecab-4a62-81e5-8fa2630a5c60"));
            labelHeight = (ITTLabel)AddControl(new Guid("fec636dc-5b5b-4dad-9c0a-5bf70e465edf"));
            labelWeight = (ITTLabel)AddControl(new Guid("83080420-86aa-49b8-a88c-e55ef672cddb"));
            base.InitializeControls();
        }

        public NursingNutritionAssessmentForm() : base("NURSINGNUTRITIONASSESSMENT", "NursingNutritionAssessmentForm")
        {
        }

        protected NursingNutritionAssessmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}