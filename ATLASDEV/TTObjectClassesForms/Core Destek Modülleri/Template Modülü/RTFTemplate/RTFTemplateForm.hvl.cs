
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
    /// Metin Şablon Tanımı
    /// </summary>
    public partial class RTFTemplateForm : TTDefinitionForm
    {
        protected TTObjectClasses.RTFTemplate _RTFTemplate
        {
            get { return (TTObjectClasses.RTFTemplate)_ttObject; }
        }

        protected ITTButton btnCreateNewGroup;
        protected ITTRichTextBoxControl Content;
        protected ITTLabel labelRTFTemplateGroup;
        protected ITTObjectListBox bTemplateGroup;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox MenuCaption;
        protected ITTLabel labelMenuCaption;
        protected ITTButton btnEditGroup;
        override protected void InitializeControls()
        {
            btnCreateNewGroup = (ITTButton)AddControl(new Guid("69e85d8e-7832-4c52-92aa-5f04486b4196"));
            Content = (ITTRichTextBoxControl)AddControl(new Guid("ad48cb0f-263d-4513-88f1-12f39b6ee134"));
            labelRTFTemplateGroup = (ITTLabel)AddControl(new Guid("42c83523-e44d-436c-aa8e-d763d88e6441"));
            bTemplateGroup = (ITTObjectListBox)AddControl(new Guid("16aab576-757c-4fe0-b788-cdf80646cc96"));
            labelDescription = (ITTLabel)AddControl(new Guid("c1703b68-ca9e-404c-a5a3-6d5c7f59d4a2"));
            Description = (ITTTextBox)AddControl(new Guid("b2039b9a-bced-4569-acd3-2d0ecffe1dbb"));
            MenuCaption = (ITTTextBox)AddControl(new Guid("fea8c3df-c4e3-4f4b-9085-1bc3ce3c75b5"));
            labelMenuCaption = (ITTLabel)AddControl(new Guid("1ed4f43d-40fa-412e-bef4-90790b0d9f37"));
            btnEditGroup = (ITTButton)AddControl(new Guid("619a8703-f7b8-44ac-a556-796a51fe74dd"));
            base.InitializeControls();
        }

        public RTFTemplateForm() : base("RTFTEMPLATE", "RTFTemplateForm")
        {
        }

        protected RTFTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}