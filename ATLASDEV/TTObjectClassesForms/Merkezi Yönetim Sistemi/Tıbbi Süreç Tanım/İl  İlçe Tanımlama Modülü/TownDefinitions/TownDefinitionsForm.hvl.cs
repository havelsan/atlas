
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
    /// İl/İlçe Tanımlama
    /// </summary>
    public partial class TownDefinitionsForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// İl/İlçe Tanımlama
    /// </summary>
        protected TTObjectClasses.TownDefinitions _TownDefinitions
        {
            get { return (TTObjectClasses.TownDefinitions)_ttObject; }
        }

        protected ITTLabel labelCity;
        protected ITTObjectListBox City;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTTextBox ExternalCode;
        protected ITTTextBox MernisCode;
        protected ITTLabel labelCode;
        protected ITTLabel labelExternalCode;
        protected ITTLabel labelMernisCode;
        protected ITTCheckBox chkActive;
        override protected void InitializeControls()
        {
            labelCity = (ITTLabel)AddControl(new Guid("0c8d1db7-6513-45b4-a5ee-3257756a2410"));
            City = (ITTObjectListBox)AddControl(new Guid("bf400113-3895-46d6-9124-f8028d8434d2"));
            labelName = (ITTLabel)AddControl(new Guid("c8b9fc84-b1f8-47ea-8738-91fec8244f25"));
            Name = (ITTTextBox)AddControl(new Guid("42fcfef9-54fb-492d-a4bf-1b4d3b5cc2a1"));
            Code = (ITTTextBox)AddControl(new Guid("84472919-8e18-4a9f-b03f-63ab33e3d188"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("92448c63-beca-4aa3-ae11-4305c28ee40a"));
            MernisCode = (ITTTextBox)AddControl(new Guid("e7b2424c-fcac-4e3a-9339-52c430742839"));
            labelCode = (ITTLabel)AddControl(new Guid("7cfec0a9-b11c-47aa-9338-eea08fbfdf14"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("fe3ddca2-ec05-4412-9cda-92c38658ebe6"));
            labelMernisCode = (ITTLabel)AddControl(new Guid("8b6250d5-4ceb-4315-961d-f7cb1b7d48cc"));
            chkActive = (ITTCheckBox)AddControl(new Guid("76e67259-0210-4ffc-b495-1f539841a3b6"));
            base.InitializeControls();
        }

        public TownDefinitionsForm() : base("TOWNDEFINITIONS", "TownDefinitionsForm")
        {
        }

        protected TownDefinitionsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}