
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
    /// Yemekte Kullanılan Malzeme
    /// </summary>
    public partial class NewMealSupplyForm : TTForm
    {
    /// <summary>
    /// DLR002_Yemek Malzeme
    /// </summary>
        protected TTObjectClasses.MLRMealSupply _MLRMealSupply
        {
            get { return (TTObjectClasses.MLRMealSupply)_ttObject; }
        }

        protected ITTLabel labelAmountOfSupply;
        protected ITTLabel labelTotalSupplyCalorie;
        protected ITTLabel labelSupply;
        protected ITTObjectListBox Supply;
        protected ITTTextBox TotalSupplyCalorie;
        protected ITTTextBox AmountOfSupply;
        override protected void InitializeControls()
        {
            labelAmountOfSupply = (ITTLabel)AddControl(new Guid("320ca906-2211-42da-af5c-4c418f362b3e"));
            labelTotalSupplyCalorie = (ITTLabel)AddControl(new Guid("1d8766d7-707e-4f2d-a562-41e9c374c4f0"));
            labelSupply = (ITTLabel)AddControl(new Guid("e250df4c-f8e4-431d-b17d-b92e4a2c633b"));
            Supply = (ITTObjectListBox)AddControl(new Guid("9a27370c-84a8-4c12-821e-a70a15997961"));
            TotalSupplyCalorie = (ITTTextBox)AddControl(new Guid("ac1642a6-3373-4f9b-88f6-dad381a27924"));
            AmountOfSupply = (ITTTextBox)AddControl(new Guid("ea8ae90f-22c8-4dad-b608-eefc33bcad07"));
            base.InitializeControls();
        }

        public NewMealSupplyForm() : base("MLRMEALSUPPLY", "NewMealSupplyForm")
        {
        }

        protected NewMealSupplyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}