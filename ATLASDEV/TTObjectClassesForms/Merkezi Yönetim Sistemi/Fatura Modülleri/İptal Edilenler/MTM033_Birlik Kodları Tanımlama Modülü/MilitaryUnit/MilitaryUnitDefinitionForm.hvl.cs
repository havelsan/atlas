
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
    /// Birlik Tanımlama
    /// </summary>
    public partial class MilitaryUnitDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Birlik Kodları Tanımları
    /// </summary>
        protected TTObjectClasses.MilitaryUnit _MilitaryUnit
        {
            get { return (TTObjectClasses.MilitaryUnit)_ttObject; }
        }

        protected ITTLabel labelForcesCommand;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel labelLinkedName;
        protected ITTTextBox LinkedName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelSite;
        protected ITTObjectListBox Site;
        protected ITTCheckBox IsSupported;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        protected ITTCheckBox Active;
        protected ITTCheckBox OnlySenderChair;
        protected ITTCheckBox IsHCSenderChair;
        override protected void InitializeControls()
        {
            labelForcesCommand = (ITTLabel)AddControl(new Guid("5533466b-5405-453f-90fe-dff5915c00b4"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("be4a6c8a-0919-42b7-ac38-4084f510b0da"));
            labelLinkedName = (ITTLabel)AddControl(new Guid("38b3cd99-15dd-41a7-b799-c35d5697bbd4"));
            LinkedName = (ITTTextBox)AddControl(new Guid("e9af3f46-51c5-431e-ac8e-ec8555d74334"));
            Name = (ITTTextBox)AddControl(new Guid("88a90333-a128-4aef-9fd2-b10e1a4929a9"));
            Code = (ITTTextBox)AddControl(new Guid("103dfba3-ec32-4958-9c24-41f6dd977029"));
            labelSite = (ITTLabel)AddControl(new Guid("3a715c10-8cf2-4e4c-84bc-fd64434f2da9"));
            Site = (ITTObjectListBox)AddControl(new Guid("4bbb9733-d731-40e3-81d6-faed585c9ac0"));
            IsSupported = (ITTCheckBox)AddControl(new Guid("5e29b015-89b6-441e-ab9e-b290670395e7"));
            labelName = (ITTLabel)AddControl(new Guid("1cb23d81-7034-41fd-8498-44fb99104df9"));
            labelCode = (ITTLabel)AddControl(new Guid("8d8c3971-36bd-4899-b85c-c548dd7183e1"));
            Active = (ITTCheckBox)AddControl(new Guid("a312d6a9-97cf-4f0f-bb1d-e9604f12de10"));
            OnlySenderChair = (ITTCheckBox)AddControl(new Guid("195d1609-a413-4041-af8b-82f64c5c27eb"));
            IsHCSenderChair = (ITTCheckBox)AddControl(new Guid("36dc3896-cebf-4ca0-ada0-af956c0f8d29"));
            base.InitializeControls();
        }

        public MilitaryUnitDefinitionForm() : base("MILITARYUNIT", "MilitaryUnitDefinitionForm")
        {
        }

        protected MilitaryUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}