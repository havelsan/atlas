
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
    /// Laboratuvar Şablonl Tanım Formu
    /// </summary>
    public partial class LaboratoryAcceptTemplateForm : TTDefinitionForm
    {
    /// <summary>
    /// Laboratuvar Kabul Panel Tanımı
    /// </summary>
        protected TTObjectClasses.LaboratoryAcceptTemplateDefinition _LaboratoryAcceptTemplateDefinition
        {
            get { return (TTObjectClasses.LaboratoryAcceptTemplateDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTGrid GRIDUSERRESOURCES;
        protected ITTListBoxColumn Test;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox NAME;
        protected ITTObjectListBox TESTTUBEDEFINITION;
        protected ITTObjectListBox RESUSER;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("0034dcd5-48e5-4f2a-844f-7846e3fd7ca0"));
            GRIDUSERRESOURCES = (ITTGrid)AddControl(new Guid("19937487-5253-4caa-99f4-7b5b8af41fd1"));
            Test = (ITTListBoxColumn)AddControl(new Guid("b7b8a2aa-9bd7-4e0d-b984-07c1085c2a2b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e127a1a8-4365-4248-b67e-691e050e54f8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("229383a8-e919-49f6-acdc-8d82da7757bb"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("419a62be-bbd1-48de-b813-45d7513deb07"));
            NAME = (ITTTextBox)AddControl(new Guid("f4c06c90-9d08-432e-b823-9303902bb9e3"));
            TESTTUBEDEFINITION = (ITTObjectListBox)AddControl(new Guid("d9f70644-88f4-4d83-bc0e-03db06c294fe"));
            RESUSER = (ITTObjectListBox)AddControl(new Guid("fbfc9820-389e-4d87-8749-7f419a39b1ed"));
            base.InitializeControls();
        }

        public LaboratoryAcceptTemplateForm() : base("LABORATORYACCEPTTEMPLATEDEFINITION", "LaboratoryAcceptTemplateForm")
        {
        }

        protected LaboratoryAcceptTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}