
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
    public partial class CousesOfTheHekDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.CousesOfTheHekDefinition _CousesOfTheHekDefinition
        {
            get { return (TTObjectClasses.CousesOfTheHekDefinition)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Counter;
        protected ITTLabel labelCounter;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("b55345bf-6887-4f25-a3a2-59bc9229906b"));
            Description = (ITTTextBox)AddControl(new Guid("dcbf861f-a08a-45c7-a2ee-4e9666c68097"));
            Counter = (ITTTextBox)AddControl(new Guid("d73b66af-f6b5-45bd-a25f-66e453cb1ae1"));
            labelCounter = (ITTLabel)AddControl(new Guid("3d15abf7-80fe-4d50-993e-722bef69d2aa"));
            base.InitializeControls();
        }

        public CousesOfTheHekDefinitionForm() : base("COUSESOFTHEHEKDEFINITION", "CousesOfTheHekDefinitionForm")
        {
        }

        protected CousesOfTheHekDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}