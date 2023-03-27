
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
    /// Hemşirelik Uygulamaları - Günlük Yaşam Aktivitesi Tanımları
    /// </summary>
    public partial class DailyLifeActivityDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.DailyLifeActivityDefinition _DailyLifeActivityDefinition
        {
            get { return (TTObjectClasses.DailyLifeActivityDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelGroup;
        protected ITTEnumComboBox Group;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("f367cc9b-68b5-42bc-84d5-4b9936b8c6b3"));
            Name = (ITTTextBox)AddControl(new Guid("a013f744-312e-4ea4-a2c5-76a1595c8583"));
            labelGroup = (ITTLabel)AddControl(new Guid("db7dd88c-6a05-41af-8499-761178936529"));
            Group = (ITTEnumComboBox)AddControl(new Guid("d0be652d-03b6-4a2d-b1d7-900465942363"));
            Aktif = (ITTCheckBox)AddControl(new Guid("76fdbcfa-8a32-41cc-a5b2-d1b44a68ca94"));
            base.InitializeControls();
        }

        public DailyLifeActivityDefinitionForm() : base("DAILYLIFEACTIVITYDEFINITION", "DailyLifeActivityDefinitionForm")
        {
        }

        protected DailyLifeActivityDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}