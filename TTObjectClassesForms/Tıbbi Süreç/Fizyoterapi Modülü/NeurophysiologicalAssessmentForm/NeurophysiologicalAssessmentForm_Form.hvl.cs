
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
    /// Nörofizyolojik Değerlendirme
    /// </summary>
    public partial class NeurophysiologicalAssessmentForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Nörofizyolojik Değerlendirme
    /// </summary>
        protected TTObjectClasses.NeurophysiologicalAssessmentForm _NeurophysiologicalAssessmentForm
        {
            get { return (TTObjectClasses.NeurophysiologicalAssessmentForm)_ttObject; }
        }

        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTTextBox Vojta;
        protected ITTTextBox Rood;
        protected ITTTextBox Kabat;
        protected ITTTextBox ChedokeStrokeAssessmentScale;
        protected ITTTextBox BobathBrunstrum;
        protected ITTLabel labelVojta;
        protected ITTLabel labelRood;
        protected ITTLabel labelKabat;
        protected ITTLabel labelChedokeStrokeAssessmentScale;
        protected ITTLabel labelBobathBrunstrum;
        override protected void InitializeControls()
        {
            labelCreationDate = (ITTLabel)AddControl(new Guid("9b41b314-afd2-4a7d-a305-16122091f6ba"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("3395c323-3cf6-4e4a-838d-04e8a16e3fe6"));
            labelCode = (ITTLabel)AddControl(new Guid("7c8dd55f-44ec-451a-8cee-7417728af56f"));
            Code = (ITTTextBox)AddControl(new Guid("503189f1-b956-4615-ac5b-63ca32bfe3c3"));
            Vojta = (ITTTextBox)AddControl(new Guid("8fc67bba-aad6-4cc2-9ac2-09b61e938ef7"));
            Rood = (ITTTextBox)AddControl(new Guid("75dcfb5e-1486-423b-a83e-98ff6440711c"));
            Kabat = (ITTTextBox)AddControl(new Guid("ea29d740-9c92-4cf1-b03c-a69a85cb1fbc"));
            ChedokeStrokeAssessmentScale = (ITTTextBox)AddControl(new Guid("fdf03207-72c2-4d77-aa15-8a8bf208aadf"));
            BobathBrunstrum = (ITTTextBox)AddControl(new Guid("4557b64b-dc62-4eea-b407-db22753474cf"));
            labelVojta = (ITTLabel)AddControl(new Guid("a0eb8aea-3a0c-47cf-aacc-07678c53869f"));
            labelRood = (ITTLabel)AddControl(new Guid("abdbbc7c-e269-4dbf-a753-2e469c1afccc"));
            labelKabat = (ITTLabel)AddControl(new Guid("cbe8a2f3-92d9-4961-b808-d8c3b08553c7"));
            labelChedokeStrokeAssessmentScale = (ITTLabel)AddControl(new Guid("ccbe8fdf-eb3e-4231-9583-bbe3aac2624c"));
            labelBobathBrunstrum = (ITTLabel)AddControl(new Guid("9b22f802-748e-4257-843d-7c178af13a88"));
            base.InitializeControls();
        }

        public NeurophysiologicalAssessmentForm() : base("NEUROPHYSIOLOGICALASSESSMENTFORM", "NeurophysiologicalAssessmentForm")
        {
        }

        protected NeurophysiologicalAssessmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}