
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
    public partial class NursingInitiativeDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hemşirelik Ağrı Değerlendirme Girişimi Tanımları
    /// </summary>
        protected TTObjectClasses.NursingInitiativeDefinition _NursingInitiativeDefinition
        {
            get { return (TTObjectClasses.NursingInitiativeDefinition)_ttObject; }
        }

        protected ITTLabel labelOrderNo;
        protected ITTTextBox OrderNo;
        protected ITTTextBox Initiative;
        protected ITTLabel labelInitiative;
        override protected void InitializeControls()
        {
            labelOrderNo = (ITTLabel)AddControl(new Guid("74f4a79c-22f3-4ac5-83ff-124eac5e9e42"));
            OrderNo = (ITTTextBox)AddControl(new Guid("6cd959a7-099a-4d6c-a27c-8d0ab48e2692"));
            Initiative = (ITTTextBox)AddControl(new Guid("8a7ea9bf-3600-463f-9b97-88a6c7f707a9"));
            labelInitiative = (ITTLabel)AddControl(new Guid("c1e4a8bd-b885-4f5c-a86a-35530c5008c5"));
            base.InitializeControls();
        }

        public NursingInitiativeDefinitionForm() : base("NURSINGINITIATIVEDEFINITION", "NursingInitiativeDefinitionForm")
        {
        }

        protected NursingInitiativeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}