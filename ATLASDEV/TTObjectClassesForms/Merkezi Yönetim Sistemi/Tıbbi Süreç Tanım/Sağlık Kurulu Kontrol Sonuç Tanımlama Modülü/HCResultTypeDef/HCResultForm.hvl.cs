
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
    /// Sağlık Kurulu Sonuç Tanımları
    /// </summary>
    public partial class HCResultForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Sağlık Kurulu Sonuç Tanımları
    /// </summary>
        protected TTObjectClasses.HCResultTypeDef _HCResultTypeDef
        {
            get { return (TTObjectClasses.HCResultTypeDef)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("ad075e59-7bea-422d-819d-3cccfc7b7e9a"));
            Name = (ITTTextBox)AddControl(new Guid("02bb1798-ee89-487f-ac5f-5550702d0ffa"));
            Code = (ITTTextBox)AddControl(new Guid("670f6e55-e68c-4f04-b1f9-6eadb96bfb59"));
            labelCode = (ITTLabel)AddControl(new Guid("0ea1f01b-059d-4824-8a81-9c1c7ed34777"));
            base.InitializeControls();
        }

        public HCResultForm() : base("HCRESULTTYPEDEF", "HCResultForm")
        {
        }

        protected HCResultForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}