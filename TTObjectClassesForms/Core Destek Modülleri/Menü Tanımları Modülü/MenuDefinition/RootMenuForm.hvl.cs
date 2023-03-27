
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
    /// Kök Menü Tanımlama
    /// </summary>
    public partial class RootMenuForm : TTForm
    {
        protected TTObjectClasses.MenuDefinition _MenuDefinition
        {
            get { return (TTObjectClasses.MenuDefinition)_ttObject; }
        }

        protected ITTLabel labelMenuDefNo;
        protected ITTTextBox textboxMenuDefNo;
        protected ITTTextBox OrderNo;
        protected ITTTextBox Caption;
        protected ITTLabel labelOrderNo;
        protected ITTLabel labelMenuGroup;
        protected ITTEnumComboBox MenuGroup;
        protected ITTLabel labelCaption;
        protected ITTGrid NotIncludeSites;
        protected ITTListBoxColumn Site;
        override protected void InitializeControls()
        {
            labelMenuDefNo = (ITTLabel)AddControl(new Guid("3acfb1a6-1966-45d7-ac16-9d5835e19d03"));
            textboxMenuDefNo = (ITTTextBox)AddControl(new Guid("a3064670-0f36-4497-b58f-59b941831949"));
            OrderNo = (ITTTextBox)AddControl(new Guid("ca0ba0c8-8140-4c56-b2ec-0738f8ed8f4a"));
            Caption = (ITTTextBox)AddControl(new Guid("7bef1142-0efd-459a-973a-b7cad6dcdeb4"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("de6cf6e5-62c9-4918-8a5f-d62361914c1a"));
            labelMenuGroup = (ITTLabel)AddControl(new Guid("9d43326d-088a-42b2-8188-4f9fa09fdb7b"));
            MenuGroup = (ITTEnumComboBox)AddControl(new Guid("54040f97-3866-4ecf-aed6-8de84a3c255b"));
            labelCaption = (ITTLabel)AddControl(new Guid("ede2b624-1145-4344-bd32-51688f50188c"));
            NotIncludeSites = (ITTGrid)AddControl(new Guid("5f1e48a4-6897-4e12-b1b9-8a93fe65c3e4"));
            Site = (ITTListBoxColumn)AddControl(new Guid("c07684a5-7044-4bba-9784-02579bd826d0"));
            base.InitializeControls();
        }

        public RootMenuForm() : base("MENUDEFINITION", "RootMenuForm")
        {
        }

        protected RootMenuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}