
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
    public partial class EpisodeActionTemplateForm : TTDefinitionForm
    {
    /// <summary>
    /// Vaka İşlemleri Şablonu
    /// </summary>
        protected TTObjectClasses.EpisodeActionTemplate _EpisodeActionTemplate
        {
            get { return (TTObjectClasses.EpisodeActionTemplate)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTGrid ProcedureDefinitions;
        protected ITTListBoxColumn ProcedureDefinition;
        protected ITTLabel labelResource;
        protected ITTObjectListBox Resource;
        protected ITTLabel labelActionType;
        protected ITTEnumComboBox ActionType;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("0edb19c5-f8c3-4df2-92e4-a8043aeed8ca"));
            Description = (ITTTextBox)AddControl(new Guid("8ebe9349-9cf8-4940-88b7-631649a834a0"));
            ProcedureDefinitions = (ITTGrid)AddControl(new Guid("a29e0fa0-0e1b-4558-83ec-f3890a9f7f2f"));
            ProcedureDefinition = (ITTListBoxColumn)AddControl(new Guid("a89a86c0-39b0-43d6-805c-41d19fe88ab6"));
            labelResource = (ITTLabel)AddControl(new Guid("f7f74d94-5673-4d2d-a8b1-f62bb9ae5b6c"));
            Resource = (ITTObjectListBox)AddControl(new Guid("f1364f27-be9d-4131-ac21-8996cf4ce638"));
            labelActionType = (ITTLabel)AddControl(new Guid("9230db78-c968-46c0-92ca-6086c40afd75"));
            ActionType = (ITTEnumComboBox)AddControl(new Guid("91f42dc7-2a99-4c43-9381-0b93159d3be4"));
            base.InitializeControls();
        }

        public EpisodeActionTemplateForm() : base("EPISODEACTIONTEMPLATE", "EpisodeActionTemplateForm")
        {
        }

        protected EpisodeActionTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}