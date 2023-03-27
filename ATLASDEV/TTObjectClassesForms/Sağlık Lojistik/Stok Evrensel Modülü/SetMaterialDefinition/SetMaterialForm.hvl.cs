
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
    /// Set Malzeme Tanımı
    /// </summary>
    public partial class SetMaterialForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Set Malzeme Tanımı
    /// </summary>
        protected TTObjectClasses.SetMaterialDefinition _SetMaterialDefinition
        {
            get { return (TTObjectClasses.SetMaterialDefinition)_ttObject; }
        }

        protected ITTObjectListBox SetMalzemeListBox;
        protected ITTGrid SubCodesGrid;
        protected ITTTextBoxColumn MaterialCode;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            SetMalzemeListBox = (ITTObjectListBox)AddControl(new Guid("0f23979c-6bd1-4ae2-9c8e-8df97c118054"));
            SubCodesGrid = (ITTGrid)AddControl(new Guid("4ffe6be0-f96a-4bab-bc13-c7aea7f9f2f2"));
            MaterialCode = (ITTTextBoxColumn)AddControl(new Guid("87341c48-e8b0-40db-812e-ea9552fdf0d6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("376036e0-4903-4d7e-bf78-b454aef5b02d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("35521099-e7ef-4e56-8900-d419502b6c97"));
            base.InitializeControls();
        }

        public SetMaterialForm() : base("SETMATERIALDEFINITION", "SetMaterialForm")
        {
        }

        protected SetMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}