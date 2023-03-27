
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
    /// Yemek Ekle
    /// </summary>
    public partial class NewRegimeMealGroupForm : TTForm
    {
        protected TTObjectClasses.MLRRegimeMealGroup _MLRRegimeMealGroup
        {
            get { return (TTObjectClasses.MLRRegimeMealGroup)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTObjectListBox MealGroup;
        protected ITTLabel labelMealGroup;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("f849a401-b4a5-42a0-837d-10558e1a41f5"));
            MealGroup = (ITTObjectListBox)AddControl(new Guid("2b1a4c76-3d5c-47df-a8c9-476d4c4ef6a0"));
            labelMealGroup = (ITTLabel)AddControl(new Guid("5b35d838-9eef-499a-970f-726d373d5de9"));
            base.InitializeControls();
        }

        public NewRegimeMealGroupForm() : base("MLRREGIMEMEALGROUP", "NewRegimeMealGroupForm")
        {
        }

        protected NewRegimeMealGroupForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}