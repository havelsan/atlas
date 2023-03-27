
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
    public partial class VerbalAndPerformanceTestsForm : TTForm
    {
        protected TTObjectClasses.VerbalAndPerformanceTests _VerbalAndPerformanceTests
        {
            get { return (TTObjectClasses.VerbalAndPerformanceTests)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelAddedUser;
        protected ITTObjectListBox AddedUser;
        protected ITTLabel labelPerformanceSystem;
        protected ITTLabel labelVerbalTests;
        protected ITTLabel labelVocabulary;
        protected ITTTextBox Vocabulary;
        protected ITTTextBox Trial;
        protected ITTTextBox Similarities;
        protected ITTTextBox PieceAssembly;
        protected ITTTextBox PatternWithCubes;
        protected ITTTextBox Password;
        protected ITTTextBox NumberSequence;
        protected ITTTextBox Mazes;
        protected ITTTextBox ImageEditing;
        protected ITTTextBox ImageCompletion;
        protected ITTTextBox GeneralInformation;
        protected ITTTextBox Arithmetic;
        protected ITTLabel labelTrial;
        protected ITTLabel labelSimilarities;
        protected ITTLabel labelPieceAssembly;
        protected ITTLabel labelPatternWithCubes;
        protected ITTLabel labelPassword;
        protected ITTLabel labelNumberSequence;
        protected ITTLabel labelMazes;
        protected ITTLabel labelImageEditing;
        protected ITTLabel labelImageCompletion;
        protected ITTLabel labelGeneralInformation;
        protected ITTLabel labelArithmetic;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("499023cb-54e2-4843-8953-c356a6520bc6"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("1d9df3b6-94af-4c9d-b630-9ab16a62999c"));
            labelAddedUser = (ITTLabel)AddControl(new Guid("411f718d-855e-4852-b44a-6c1b7983acf5"));
            AddedUser = (ITTObjectListBox)AddControl(new Guid("5ea299b4-7de7-405a-b069-142eab615d26"));
            labelPerformanceSystem = (ITTLabel)AddControl(new Guid("639a9af3-61ff-4b37-a1fc-f5f1eb7895ef"));
            labelVerbalTests = (ITTLabel)AddControl(new Guid("f3c51f9d-2e2c-4342-b7c0-15e5b966fbe6"));
            labelVocabulary = (ITTLabel)AddControl(new Guid("c3123e64-549b-4711-83b6-df81be02e3dd"));
            Vocabulary = (ITTTextBox)AddControl(new Guid("97a91472-371a-4b3a-878b-916dd02b9493"));
            Trial = (ITTTextBox)AddControl(new Guid("289df3ba-e8f2-4f6e-b3ad-bb9e067f11a1"));
            Similarities = (ITTTextBox)AddControl(new Guid("bf621011-3c82-4446-8905-e1ad9f9783b9"));
            PieceAssembly = (ITTTextBox)AddControl(new Guid("bc4152c3-76ed-4b7d-9791-c590ab98b046"));
            PatternWithCubes = (ITTTextBox)AddControl(new Guid("80fdc5c9-187c-4c52-ba7f-23157938cce9"));
            Password = (ITTTextBox)AddControl(new Guid("db6f395e-2059-4dfe-ad21-700cd851e195"));
            NumberSequence = (ITTTextBox)AddControl(new Guid("e98d2d1f-ab9a-431f-b600-a4ff8292bdc3"));
            Mazes = (ITTTextBox)AddControl(new Guid("9ee2a380-8532-4382-aea5-32ed943243b2"));
            ImageEditing = (ITTTextBox)AddControl(new Guid("c4d7ee07-41ac-485c-9604-849718ffeabd"));
            ImageCompletion = (ITTTextBox)AddControl(new Guid("558fb111-a9b5-41cb-b4ba-86c6c2db39c0"));
            GeneralInformation = (ITTTextBox)AddControl(new Guid("815e7516-21d1-4ea1-983a-453539623749"));
            Arithmetic = (ITTTextBox)AddControl(new Guid("3d7f8edd-7cf1-48e8-8bee-5ed4dac659f4"));
            labelTrial = (ITTLabel)AddControl(new Guid("d59ba699-c7f2-4744-9abf-342efa31429e"));
            labelSimilarities = (ITTLabel)AddControl(new Guid("e36661ef-a797-440a-8c16-f98d4618a87a"));
            labelPieceAssembly = (ITTLabel)AddControl(new Guid("17d150a6-af1c-48f8-bf8e-d95844b4cc95"));
            labelPatternWithCubes = (ITTLabel)AddControl(new Guid("af7699c0-ee2b-4c8e-8b84-94479c4cf5a5"));
            labelPassword = (ITTLabel)AddControl(new Guid("226123ee-bfea-4d6c-b37f-1de71677fd9c"));
            labelNumberSequence = (ITTLabel)AddControl(new Guid("a955326f-3119-431c-a463-d62cfac8f001"));
            labelMazes = (ITTLabel)AddControl(new Guid("928f1c58-7ea7-4ec0-bb7e-94865cb22ae1"));
            labelImageEditing = (ITTLabel)AddControl(new Guid("4493dbaf-ff11-4cfa-8d13-b70aec98f740"));
            labelImageCompletion = (ITTLabel)AddControl(new Guid("54f5172e-9a0b-4bac-94b9-84d9b29530fa"));
            labelGeneralInformation = (ITTLabel)AddControl(new Guid("b51ba56b-c0b5-4413-bb21-b431e1584ea9"));
            labelArithmetic = (ITTLabel)AddControl(new Guid("85d26d97-3751-45ef-9f8f-5a45fc463ab7"));
            base.InitializeControls();
        }

        public VerbalAndPerformanceTestsForm() : base("VERBALANDPERFORMANCETESTS", "VerbalAndPerformanceTestsForm")
        {
        }

        protected VerbalAndPerformanceTestsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}