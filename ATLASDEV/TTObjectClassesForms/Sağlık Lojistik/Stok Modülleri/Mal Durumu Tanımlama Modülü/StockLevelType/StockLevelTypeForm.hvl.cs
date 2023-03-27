
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
    /// Malzemenin Durumu
    /// </summary>
    public partial class StockLevelTypeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Malzeme Durumu
    /// </summary>
        protected TTObjectClasses.StockLevelType _StockLevelType
        {
            get { return (TTObjectClasses.StockLevelType)_ttObject; }
        }

        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("adb4728e-6ad9-48c1-b010-25b76dfad0ea"));
            labelDescription = (ITTLabel)AddControl(new Guid("aab4f45e-1736-4cde-bcb4-514b9059e63a"));
            Description = (ITTTextBox)AddControl(new Guid("201c6a97-bc3a-4464-a604-2eacabbccb06"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("40dcac64-564c-403b-9b30-b17c3da8bdc3"));
            base.InitializeControls();
        }

        public StockLevelTypeForm() : base("STOCKLEVELTYPE", "StockLevelTypeForm")
        {
        }

        protected StockLevelTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}