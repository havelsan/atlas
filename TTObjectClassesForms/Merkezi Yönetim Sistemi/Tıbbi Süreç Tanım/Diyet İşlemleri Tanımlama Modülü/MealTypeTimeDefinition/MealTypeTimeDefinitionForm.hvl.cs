
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
    /// Diyet öğünlerinin hastalara verildiği saatler
    /// </summary>
    public partial class MealTypeTimeDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Diyet Öğün Zamanları
    /// </summary>
        protected TTObjectClasses.MealTypeTimeDefinition _MealTypeTimeDefinition
        {
            get { return (TTObjectClasses.MealTypeTimeDefinition)_ttObject; }
        }

        protected ITTLabel labelSnack3;
        protected ITTDateTimePicker Snack3;
        protected ITTLabel labelSnack2;
        protected ITTDateTimePicker Snack2;
        protected ITTLabel labelSnack1;
        protected ITTDateTimePicker Snack1;
        protected ITTLabel labelNightBreakfast;
        protected ITTDateTimePicker NightBreakfast;
        protected ITTLabel labelDinner;
        protected ITTDateTimePicker Dinner;
        protected ITTLabel labelLunch;
        protected ITTDateTimePicker Lunch;
        protected ITTLabel labelBreakfast;
        protected ITTDateTimePicker Breakfast;
        protected ITTCheckBox ttcheckbox1;
        override protected void InitializeControls()
        {
            labelSnack3 = (ITTLabel)AddControl(new Guid("a65315a6-c3f9-401a-a26c-3fd68d329298"));
            Snack3 = (ITTDateTimePicker)AddControl(new Guid("fcf3007d-fb44-4788-8171-a93868db5b71"));
            labelSnack2 = (ITTLabel)AddControl(new Guid("87378830-5d6d-4e97-8ae6-5bc2936d6daf"));
            Snack2 = (ITTDateTimePicker)AddControl(new Guid("660e0ba1-ac3d-4115-ac02-084978dbdd36"));
            labelSnack1 = (ITTLabel)AddControl(new Guid("712c40a5-030d-415f-97db-8c02b0968e00"));
            Snack1 = (ITTDateTimePicker)AddControl(new Guid("eaa9fe3d-1f7d-490d-b619-7884b3ff08e2"));
            labelNightBreakfast = (ITTLabel)AddControl(new Guid("122dd16c-bc5d-4ce8-a89c-8753666cef36"));
            NightBreakfast = (ITTDateTimePicker)AddControl(new Guid("c649dca8-6ce2-4a59-835e-c82e1157f1d0"));
            labelDinner = (ITTLabel)AddControl(new Guid("fef81f33-9cb3-4426-9412-7ca3e6eca318"));
            Dinner = (ITTDateTimePicker)AddControl(new Guid("d3d85f19-efd0-484e-84d8-30dee020dc0e"));
            labelLunch = (ITTLabel)AddControl(new Guid("efad8ffc-d681-4011-945b-8e03333ba2c7"));
            Lunch = (ITTDateTimePicker)AddControl(new Guid("0c4c61cb-5263-4fb1-8902-b1438e066245"));
            labelBreakfast = (ITTLabel)AddControl(new Guid("d9000a1a-1135-4d52-ba07-0773215a6e32"));
            Breakfast = (ITTDateTimePicker)AddControl(new Guid("3a47ceca-d33b-4472-8269-394c88580c7a"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("a75f9885-2f30-4031-b75e-d6800fb0acf1"));
            base.InitializeControls();
        }

        public MealTypeTimeDefinitionForm() : base("MEALTYPETIMEDEFINITION", "MealTypeTimeDefinitionForm")
        {
        }

        protected MealTypeTimeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}