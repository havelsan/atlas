
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
    /// Diyet İşlemleri Tanımlama
    /// </summary>
    public partial class DietDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Diyet İşlemleri Tanımlama
    /// </summary>
        protected TTObjectClasses.DietDefinition _DietDefinition
        {
            get { return (TTObjectClasses.DietDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel labelPatientType;
        protected ITTEnumComboBox PatientType;
        protected ITTGrid CourseGrid;
        protected ITTListBoxColumn CourseDefinitionCourseGrid;
        protected ITTCheckBox Snack3;
        protected ITTCheckBox Snack2;
        protected ITTCheckBox Snack1;
        protected ITTCheckBox NightBreakfast;
        protected ITTCheckBox Dinner;
        protected ITTCheckBox Lunch;
        protected ITTCheckBox Breakfast;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox1;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("8ca73ec0-0713-480a-bcda-215e1a034b32"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("8768e812-e219-45fb-b557-b0f8ab577576"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("de38d43c-3277-45d2-8771-b7eabe86c300"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("625b7a98-2b3f-4f20-a9f3-29e39ae2844d"));
            labelPatientType = (ITTLabel)AddControl(new Guid("bffac020-c2e5-4d6c-af21-b0c75f9e8bed"));
            PatientType = (ITTEnumComboBox)AddControl(new Guid("abb84164-6ba4-401e-8038-f383bee87bfc"));
            CourseGrid = (ITTGrid)AddControl(new Guid("ea1fd34b-8cbd-4991-a2b0-1a1927a930f7"));
            CourseDefinitionCourseGrid = (ITTListBoxColumn)AddControl(new Guid("3142433e-791e-4936-9049-4eb75f6d1f6d"));
            Snack3 = (ITTCheckBox)AddControl(new Guid("9f0e132d-4e63-4d2c-995e-839516ee9b14"));
            Snack2 = (ITTCheckBox)AddControl(new Guid("7a1e28eb-a81e-4ff6-9e14-cd4f69d6ecb1"));
            Snack1 = (ITTCheckBox)AddControl(new Guid("0b301533-5703-4656-af26-edb567d1225a"));
            NightBreakfast = (ITTCheckBox)AddControl(new Guid("53574e86-5087-4f37-82ba-235fcd3f9028"));
            Dinner = (ITTCheckBox)AddControl(new Guid("b7b24650-cc53-4f4a-8667-5768f4ebe97e"));
            Lunch = (ITTCheckBox)AddControl(new Guid("d5f90df2-a83f-4747-b745-8a82dd080ccf"));
            Breakfast = (ITTCheckBox)AddControl(new Guid("e8536c3f-4d58-42f2-87a8-2e9b3fb63739"));
            labelQref = (ITTLabel)AddControl(new Guid("02fc267f-8928-4eb1-b3e9-38f5dd39738d"));
            Qref = (ITTTextBox)AddControl(new Guid("9dc6b42c-03b6-4374-aa97-968c9910dfea"));
            Name = (ITTTextBox)AddControl(new Guid("02e2d33e-e0f8-404c-8aa8-09a517d524aa"));
            EnglishName = (ITTTextBox)AddControl(new Guid("67aed4ea-b4df-4f17-84bb-16aaa64173d0"));
            Description = (ITTTextBox)AddControl(new Guid("3cded5bf-3f19-4a4d-b515-9da9b02adc3c"));
            Code = (ITTTextBox)AddControl(new Guid("027d27cf-126f-4090-968f-f626e6572c9c"));
            labelName = (ITTLabel)AddControl(new Guid("b15fdb1d-a32d-4e9f-b00c-80b2b32a4d1e"));
            IsActive = (ITTCheckBox)AddControl(new Guid("51e9d247-99a7-4a88-99a2-9a53c0280be3"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("b49d1239-6cf8-4ff5-a346-2f499a11f421"));
            labelDescription = (ITTLabel)AddControl(new Guid("062da8b5-fc18-4b22-89e8-2dc2dc2bb279"));
            labelCode = (ITTLabel)AddControl(new Guid("3f63f26e-b15e-46cb-a3af-985374947e0a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e771ff3b-d612-4f2b-bc26-c469253b46f0"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("ca0de655-c58c-4a16-8bf8-fee21e91f747"));
            base.InitializeControls();
        }

        public DietDefinitionForm() : base("DIETDEFINITION", "DietDefinitionForm")
        {
        }

        protected DietDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}