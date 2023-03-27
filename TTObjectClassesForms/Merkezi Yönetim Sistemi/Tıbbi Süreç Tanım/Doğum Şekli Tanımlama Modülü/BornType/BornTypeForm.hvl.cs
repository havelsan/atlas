
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
    /// Doğum Şekli Tanımları
    /// </summary>
    public partial class BornTypeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Doğum Şekli
    /// </summary>
        protected TTObjectClasses.BornType _BornType
        {
            get { return (TTObjectClasses.BornType)_ttObject; }
        }

        protected ITTLabel labelType;
        protected ITTTextBox Type;
        protected ITTLabel labelMainType;
        protected ITTEnumComboBox MainType;
        override protected void InitializeControls()
        {
            labelType = (ITTLabel)AddControl(new Guid("d36ee2f0-b8bd-49c2-8064-1f709c2b82c2"));
            Type = (ITTTextBox)AddControl(new Guid("978782ae-34ae-4d01-b9ad-d281b0b1af6b"));
            labelMainType = (ITTLabel)AddControl(new Guid("f79b0108-4181-4f3e-a69d-e4c1bb0ab69b"));
            MainType = (ITTEnumComboBox)AddControl(new Guid("6c42a3a5-54cc-4d83-a9d0-1fa0795ce2dd"));
            base.InitializeControls();
        }

        public BornTypeForm() : base("BORNTYPE", "BornTypeForm")
        {
        }

        protected BornTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}