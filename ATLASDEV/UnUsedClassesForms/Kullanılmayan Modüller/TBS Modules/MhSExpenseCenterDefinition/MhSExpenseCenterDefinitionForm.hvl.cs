
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
    /// Masraf Merkezi Tanımlama
    /// </summary>
    public partial class MhSExpenseCenterDefinitionForm : TTForm
    {
    /// <summary>
    /// Masraf Merkezi
    /// </summary>
        protected TTObjectClasses.MhSExpenseCenterDefinition _MhSExpenseCenterDefinition
        {
            get { return (TTObjectClasses.MhSExpenseCenterDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("88629938-1788-419f-a3f6-313476ff2954"));
            Code = (ITTTextBox)AddControl(new Guid("2553abf4-a698-4a4b-9805-346cbd9aaba3"));
            labelName = (ITTLabel)AddControl(new Guid("52a05286-3d84-41ec-820c-60ca20c5497e"));
            labelCode = (ITTLabel)AddControl(new Guid("822e127a-5abb-4f83-8035-fc50880ec0ff"));
            base.InitializeControls();
        }

        public MhSExpenseCenterDefinitionForm() : base("MHSEXPENSECENTERDEFINITION", "MhSExpenseCenterDefinitionForm")
        {
        }

        protected MhSExpenseCenterDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}