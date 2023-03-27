
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
    /// İş listesi kolon tanımı
    /// </summary>
    public partial class WLColumnDefForm : TTForm
    {
        protected TTObjectClasses.WorkListColumnDefinition _WorkListColumnDefinition
        {
            get { return (TTObjectClasses.WorkListColumnDefinition)_ttObject; }
        }

        protected ITTGrid WorklistColumnConditions;
        protected ITTTextBoxColumn Name;
        protected ITTTextBoxColumn ConditionColor;
        protected ITTTextBoxColumn ConditionValue;
        protected ITTCheckBoxColumn IsBold;
        protected ITTLabel labelTypeName;
        protected ITTTextBox TypeName;
        protected ITTTextBox MemberName;
        protected ITTTextBox DateFormat;
        protected ITTTextBox ColumnWidth;
        protected ITTTextBox ColumnOrder;
        protected ITTTextBox ColumnName;
        protected ITTTextBox Caption;
        protected ITTLabel labelMemberName;
        protected ITTCheckBox IsVisible;
        protected ITTCheckBox IsUnique;
        protected ITTCheckBox IsObject;
        protected ITTCheckBox IsEnum;
        protected ITTLabel labelDateFormat;
        protected ITTLabel labelColumnWidth;
        protected ITTLabel labelColumnOrder;
        protected ITTLabel labelColumnName;
        protected ITTLabel labelCaption;
        override protected void InitializeControls()
        {
            WorklistColumnConditions = (ITTGrid)AddControl(new Guid("7cf2db06-a921-4fde-bbfa-aa5693ee4e58"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("1cc9fd93-faf1-40d7-b23a-812e3e7cb407"));
            ConditionColor = (ITTTextBoxColumn)AddControl(new Guid("fed9eb67-3055-4e50-97b0-9354338d41cf"));
            ConditionValue = (ITTTextBoxColumn)AddControl(new Guid("68ee8873-a686-43a3-8879-02aff80f453a"));
            IsBold = (ITTCheckBoxColumn)AddControl(new Guid("fb9d34ad-7b4e-44f2-9862-76681965011a"));
            labelTypeName = (ITTLabel)AddControl(new Guid("4979118b-0dba-4780-a8c6-28daafc9e044"));
            TypeName = (ITTTextBox)AddControl(new Guid("554087b0-a1c8-4d1c-82f6-4401a286a10d"));
            MemberName = (ITTTextBox)AddControl(new Guid("276cbc38-ad26-415f-9273-16e620f04864"));
            DateFormat = (ITTTextBox)AddControl(new Guid("6383bfd7-bfe4-4176-800a-6af8d0a84ce7"));
            ColumnWidth = (ITTTextBox)AddControl(new Guid("acd56286-3b08-469f-bdb9-7fd63df3df80"));
            ColumnOrder = (ITTTextBox)AddControl(new Guid("e0a22ffb-3a90-4736-bd7c-c4fdadf644ba"));
            ColumnName = (ITTTextBox)AddControl(new Guid("254a650b-c5d2-4a71-aa2a-a27bf685a2d8"));
            Caption = (ITTTextBox)AddControl(new Guid("3262007f-318c-40c7-af0b-1274397b6baa"));
            labelMemberName = (ITTLabel)AddControl(new Guid("7eaacfb1-cc72-4638-9880-5a3775ccc612"));
            IsVisible = (ITTCheckBox)AddControl(new Guid("6b9a82f6-3973-4620-8476-c0b0127b548f"));
            IsUnique = (ITTCheckBox)AddControl(new Guid("4ee9c714-5d63-4f31-abc8-5275a57c75ea"));
            IsObject = (ITTCheckBox)AddControl(new Guid("85106899-6281-4f24-8cb8-2c08833b6add"));
            IsEnum = (ITTCheckBox)AddControl(new Guid("648e362f-30ee-483c-bb6d-ea173c87b0ec"));
            labelDateFormat = (ITTLabel)AddControl(new Guid("40d64bf9-9b94-4fb8-b9a8-895c4affe338"));
            labelColumnWidth = (ITTLabel)AddControl(new Guid("de5247d2-4dc7-45d5-9831-80304f8468f2"));
            labelColumnOrder = (ITTLabel)AddControl(new Guid("52bbfbf6-5de2-44ac-9f2f-9ee276d3d008"));
            labelColumnName = (ITTLabel)AddControl(new Guid("a70e639b-2783-4705-a188-af08753d6b4a"));
            labelCaption = (ITTLabel)AddControl(new Guid("038137fb-cf3e-49ce-bb78-e97bb4344ba2"));
            base.InitializeControls();
        }

        public WLColumnDefForm() : base("WORKLISTCOLUMNDEFINITION", "WLColumnDefForm")
        {
        }

        protected WLColumnDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}