
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
    /// HizmetTalimatı Tanımları
    /// </summary>
    public partial class ProcedureOrderDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hizmet Talimatı Tanımları
    /// </summary>
        protected TTObjectClasses.ProcedureOrderDefinition _ProcedureOrderDefinition
        {
            get { return (TTObjectClasses.ProcedureOrderDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTObjectListBox ProcedureOrderResource;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTCheckBox Chargable;
        protected ITTLabel labelProcedureOrderResource;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("f3e1ac32-4093-4dfe-b921-ca26da4a92f4"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("84ad117d-8d94-4ddd-8d37-70d12b0ff8ed"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("07e9230d-e30f-4e69-830a-26301e988350"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("bf46e2fc-e4cc-4e9a-8885-3d32e8f6e1de"));
            ProcedureOrderResource = (ITTObjectListBox)AddControl(new Guid("f1b95ce0-8988-4c6d-8b66-075d88c472c6"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("370bfb36-80ee-4888-b8aa-47e75eda6073"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("6aa74740-3eee-4f54-b201-aac2a5aeb48f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("307e7a99-7d2a-44eb-a104-c5f0b59bd902"));
            labelQref = (ITTLabel)AddControl(new Guid("ff782bfa-cb82-4a72-a798-ebbda45de613"));
            Qref = (ITTTextBox)AddControl(new Guid("653d2196-2981-4010-9c11-5690bf58844e"));
            Name = (ITTTextBox)AddControl(new Guid("f9e5958b-0700-47f8-b83b-01ea16a56aa7"));
            EnglishName = (ITTTextBox)AddControl(new Guid("463fe6a2-ab2a-497c-ae78-a7f03e6f4003"));
            Description = (ITTTextBox)AddControl(new Guid("f8a8f9b3-96e9-4836-8352-2a10519fe8ba"));
            Code = (ITTTextBox)AddControl(new Guid("6fc25118-9d58-4107-bffa-1f10f2d26ddd"));
            labelName = (ITTLabel)AddControl(new Guid("c49b61d1-cf59-403d-a1dc-98f2e394fcde"));
            IsActive = (ITTCheckBox)AddControl(new Guid("6dba7ed9-f9f4-4998-a2e7-718ff59b47f4"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("5b391d67-9244-45fd-9577-8154a40fb834"));
            labelDescription = (ITTLabel)AddControl(new Guid("fef3348f-0a61-4477-b1b9-6503a901c8fc"));
            labelCode = (ITTLabel)AddControl(new Guid("d70bebf8-9806-4d83-8357-5bbceefa757f"));
            Chargable = (ITTCheckBox)AddControl(new Guid("1becc007-86a5-4df4-bb31-c883404f0205"));
            labelProcedureOrderResource = (ITTLabel)AddControl(new Guid("4240eacd-88aa-4251-a9c5-d38e99a166b3"));
            base.InitializeControls();
        }

        public ProcedureOrderDefinitionForm() : base("PROCEDUREORDERDEFINITION", "ProcedureOrderDefinitionForm")
        {
        }

        protected ProcedureOrderDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}