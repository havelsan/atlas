
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
    /// Yeme Yeri Tanımları
    /// </summary>
    public partial class NutritionDietPlaceDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Yeme Yerleri Tanımları
    /// </summary>
        protected TTObjectClasses.NutritionDietPlaceDefinition _NutritionDietPlaceDefinition
        {
            get { return (TTObjectClasses.NutritionDietPlaceDefinition)_ttObject; }
        }

        protected ITTLabel labelPlace;
        protected ITTTextBox Place;
        override protected void InitializeControls()
        {
            labelPlace = (ITTLabel)AddControl(new Guid("d67cbd79-c5f2-4673-b6c5-ad7f37c634b0"));
            Place = (ITTTextBox)AddControl(new Guid("fb4b25cf-63de-4b11-a4ee-ec948f07ebb1"));
            base.InitializeControls();
        }

        public NutritionDietPlaceDefinitionForm() : base("NUTRITIONDIETPLACEDEFINITION", "NutritionDietPlaceDefinitionForm")
        {
        }

        protected NutritionDietPlaceDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}