
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
    /// CPT4 - SUT Eşleştirme Tanımları
    /// </summary>
    public partial class MatchingCPT4AndSUTDefinitionsForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// CPT4 ve SUT eşleştirmesi
    /// </summary>
        protected TTObjectClasses.MatchingCPT4AndSUTDefinitions _MatchingCPT4AndSUTDefinitions
        {
            get { return (TTObjectClasses.MatchingCPT4AndSUTDefinitions)_ttObject; }
        }

        protected ITTLabel labelSUTDefinition;
        protected ITTObjectListBox SUTDefinition;
        protected ITTLabel labelCPT4Definition;
        protected ITTObjectListBox CPT4Definition;
        override protected void InitializeControls()
        {
            labelSUTDefinition = (ITTLabel)AddControl(new Guid("ecd18b49-95dd-4da8-9517-afac06d72725"));
            SUTDefinition = (ITTObjectListBox)AddControl(new Guid("f8e02cdc-f943-4ac2-a30b-e5fa3e8c60b4"));
            labelCPT4Definition = (ITTLabel)AddControl(new Guid("ef88840a-3a1c-40bf-bbd9-853eabfabe86"));
            CPT4Definition = (ITTObjectListBox)AddControl(new Guid("cb2b758a-8bae-46c8-b804-12e53b5e0292"));
            base.InitializeControls();
        }

        public MatchingCPT4AndSUTDefinitionsForm() : base("MATCHINGCPT4ANDSUTDEFINITIONS", "MatchingCPT4AndSUTDefinitionsForm")
        {
        }

        protected MatchingCPT4AndSUTDefinitionsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}