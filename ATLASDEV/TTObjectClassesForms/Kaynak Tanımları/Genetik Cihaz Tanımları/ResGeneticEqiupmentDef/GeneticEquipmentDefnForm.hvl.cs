
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
    /// Tıbbi Genetik Cihaz Tanımları
    /// </summary>
    public partial class GeneticEquipmentDefnForm : TTDefinitionForm
    {
        protected TTObjectClasses.ResGeneticEqiupmentDef _ResGeneticEqiupmentDef
        {
            get { return (TTObjectClasses.ResGeneticEqiupmentDef)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("e8454530-7288-4e04-8b8b-c56b1492947e"));
            Name = (ITTTextBox)AddControl(new Guid("6f67e07b-abb1-4f04-af25-f3b7117dc46e"));
            Active = (ITTCheckBox)AddControl(new Guid("b10bf9df-72ea-4180-b478-9903ca944f85"));
            base.InitializeControls();
        }

        public GeneticEquipmentDefnForm() : base("RESGENETICEQIUPMENTDEF", "GeneticEquipmentDefnForm")
        {
        }

        protected GeneticEquipmentDefnForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}