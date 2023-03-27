
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
    /// Akrabalık Derecesi Tanımlama
    /// </summary>
    public partial class RelationshipDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Yakınlık Derecesi Tanımları
    /// </summary>
        protected TTObjectClasses.RelationshipDefinition _RelationshipDefinition
        {
            get { return (TTObjectClasses.RelationshipDefinition)_ttObject; }
        }

        protected ITTLabel labelShortName;
        protected ITTTextBox ShortName;
        protected ITTLabel labelExternalCode;
        protected ITTTextBox ExternalCode;
        protected ITTLabel labelRelationship;
        protected ITTTextBox Relationship;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            labelShortName = (ITTLabel)AddControl(new Guid("96947c06-8692-4c2a-a958-dc4bbe122eb2"));
            ShortName = (ITTTextBox)AddControl(new Guid("bf14d3d0-908d-42db-8e82-1f097947ba27"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("670d6b00-05c7-40db-a0cf-1c3d0535d018"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("e935757c-3559-4939-937c-be1301cdb789"));
            labelRelationship = (ITTLabel)AddControl(new Guid("c5ced13a-0646-47f6-a66b-836196e6f33e"));
            Relationship = (ITTTextBox)AddControl(new Guid("5699969d-78b3-4054-82cc-f520fc36753f"));
            labelCode = (ITTLabel)AddControl(new Guid("4f420a73-8fe4-4933-9dd8-9ac17a5e85f6"));
            Code = (ITTTextBox)AddControl(new Guid("cbbbf7b1-64e6-414d-b67d-07b384d6b9f9"));
            base.InitializeControls();
        }

        public RelationshipDefinitionForm() : base("RELATIONSHIPDEFINITION", "RelationshipDefinitionForm")
        {
        }

        protected RelationshipDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}