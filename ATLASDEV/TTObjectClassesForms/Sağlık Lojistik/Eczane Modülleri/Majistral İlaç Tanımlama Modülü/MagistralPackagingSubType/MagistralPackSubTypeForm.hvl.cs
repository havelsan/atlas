
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
    /// Majistral Ambalaj Tipi Malzeme Eşleştirme
    /// </summary>
    public partial class MagistralPackSubTypeForm : TTDefinitionForm
    {
    /// <summary>
    /// Majistral Ambalaj Tipi Eşleştirme
    /// </summary>
        protected TTObjectClasses.MagistralPackagingSubType _MagistralPackagingSubType
        {
            get { return (TTObjectClasses.MagistralPackagingSubType)_ttObject; }
        }

        protected ITTLabel labelMagistralPackagingType;
        protected ITTObjectListBox MagistralPackagingType;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelMagistralPackagingType = (ITTLabel)AddControl(new Guid("f8d5defd-f677-4a99-9d5e-10a348bbf5f9"));
            MagistralPackagingType = (ITTObjectListBox)AddControl(new Guid("1455b8fb-d0b4-4c53-9e7e-95cbb83c9f3f"));
            labelMaterial = (ITTLabel)AddControl(new Guid("08a9b689-04ff-4610-afd8-3312e7a8cd3b"));
            Material = (ITTObjectListBox)AddControl(new Guid("d127859e-d64d-4a4b-bceb-872b29149de1"));
            labelName = (ITTLabel)AddControl(new Guid("ce9fa106-2a2a-4397-809e-4d27acc31f84"));
            Name = (ITTTextBox)AddControl(new Guid("8e503148-d43f-46b8-9df7-d9c15281d2b2"));
            base.InitializeControls();
        }

        public MagistralPackSubTypeForm() : base("MAGISTRALPACKAGINGSUBTYPE", "MagistralPackSubTypeForm")
        {
        }

        protected MagistralPackSubTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}