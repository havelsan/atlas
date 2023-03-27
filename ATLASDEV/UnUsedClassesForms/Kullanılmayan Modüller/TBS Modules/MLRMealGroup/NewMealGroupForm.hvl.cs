
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
    /// yeni yemek grubu
    /// </summary>
    public partial class NewMealGroupForm : TTForm
    {
    /// <summary>
    /// DLR006_Yemek Grubu
    /// </summary>
        protected TTObjectClasses.MLRMealGroup _MLRMealGroup
        {
            get { return (TTObjectClasses.MLRMealGroup)_ttObject; }
        }

        protected ITTTextBox Description;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            Description = (ITTTextBox)AddControl(new Guid("b1acc69a-db58-47d2-9e95-346f022c73f6"));
            labelName = (ITTLabel)AddControl(new Guid("64ab1ec7-e9f7-4ee9-b1cb-74e1576ab9d1"));
            Name = (ITTTextBox)AddControl(new Guid("0eee3ece-43cb-4849-9839-ac943209c85f"));
            labelDescription = (ITTLabel)AddControl(new Guid("1090104d-f9da-4970-9602-e0625ef47a8f"));
            base.InitializeControls();
        }

        public NewMealGroupForm() : base("MLRMEALGROUP", "NewMealGroupForm")
        {
        }

        protected NewMealGroupForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}