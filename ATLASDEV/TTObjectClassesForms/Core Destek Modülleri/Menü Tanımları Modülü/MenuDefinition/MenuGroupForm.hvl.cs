
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
    /// Menü Grubu Tanımlama
    /// </summary>
    public partial class MenuGroupForm : TTForm
    {
        protected TTObjectClasses.MenuDefinition _MenuDefinition
        {
            get { return (TTObjectClasses.MenuDefinition)_ttObject; }
        }

        protected ITTLabel labelMenuDefNo;
        protected ITTTextBox textboxMenuDefNo;
        protected ITTTextBox OrderNo;
        protected ITTTextBox Caption;
        protected ITTObjectListBox ParentMenu;
        protected ITTLabel labelOrderNo;
        protected ITTLabel labelMenuGroup;
        protected ITTEnumComboBox MenuGroup;
        protected ITTLabel labelCaption;
        protected ITTLabel labelParentMenu;
        protected ITTGrid NotIncludeSites;
        protected ITTListBoxColumn Site;
        override protected void InitializeControls()
        {
            labelMenuDefNo = (ITTLabel)AddControl(new Guid("beeb34c0-8cb0-4da0-9861-b8dbf4f00cfc"));
            textboxMenuDefNo = (ITTTextBox)AddControl(new Guid("ef6b263c-1fdc-4564-9e3d-bf40ec2a31ae"));
            OrderNo = (ITTTextBox)AddControl(new Guid("13e64994-354c-4426-8b76-8f1a110e55ff"));
            Caption = (ITTTextBox)AddControl(new Guid("43832a64-8c33-4cea-ab3c-af2ab93fdd04"));
            ParentMenu = (ITTObjectListBox)AddControl(new Guid("0c72d9ea-4353-4c41-8e9f-b00b998319d7"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("2ef6f8d5-56f8-4e29-9578-6fa61b96a8cf"));
            labelMenuGroup = (ITTLabel)AddControl(new Guid("6c92ae58-71fb-436e-beea-813f2142d513"));
            MenuGroup = (ITTEnumComboBox)AddControl(new Guid("3f824bdc-91e9-4d2a-8a2a-918a675f8cb9"));
            labelCaption = (ITTLabel)AddControl(new Guid("198479e5-f96c-4818-9c96-3852451aeae3"));
            labelParentMenu = (ITTLabel)AddControl(new Guid("67b97ffc-a882-4836-8e61-f242c1d4256a"));
            NotIncludeSites = (ITTGrid)AddControl(new Guid("481cab3e-22ad-49b4-8121-e0ccc43eb930"));
            Site = (ITTListBoxColumn)AddControl(new Guid("b09ef857-e484-40f1-87f1-1a2bbda63f7e"));
            base.InitializeControls();
        }

        public MenuGroupForm() : base("MENUDEFINITION", "MenuGroupForm")
        {
        }

        protected MenuGroupForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}