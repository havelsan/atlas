
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
    /// Tıbbi Genetik Paket Tanım Formu
    /// </summary>
    public partial class GeneticAcceptTemplateForm : TTDefinitionForm
    {
    /// <summary>
    /// Genetik Paket Tanımları
    /// </summary>
        protected TTObjectClasses.GeneticAcceptTemplateDefinition _GeneticAcceptTemplateDefinition
        {
            get { return (TTObjectClasses.GeneticAcceptTemplateDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTGrid GRIDUSERRESOURCES;
        protected ITTListBoxColumn Test;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox NAME;
        protected ITTObjectListBox RESUSER;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("1f47fd05-7882-42e8-90e5-0a06a9044ca9"));
            GRIDUSERRESOURCES = (ITTGrid)AddControl(new Guid("91c5ca90-182f-4c75-9a62-52bc89871e3a"));
            Test = (ITTListBoxColumn)AddControl(new Guid("2ef85bd8-6d4c-41be-a84a-cc61fd34b96f"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("98270f5c-5afc-413a-87ec-0888825ebdd8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4be52886-d864-491c-8bf8-099d42346e7a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("caaf83a9-28f2-4b12-8277-6c2e718fbe7c"));
            NAME = (ITTTextBox)AddControl(new Guid("27b4b344-e2c3-41f8-8498-be469f3bfc05"));
            RESUSER = (ITTObjectListBox)AddControl(new Guid("9627adcd-b020-4cf9-97bb-b0d6b168a575"));
            base.InitializeControls();
        }

        public GeneticAcceptTemplateForm() : base("GENETICACCEPTTEMPLATEDEFINITION", "GeneticAcceptTemplateForm")
        {
        }

        protected GeneticAcceptTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}