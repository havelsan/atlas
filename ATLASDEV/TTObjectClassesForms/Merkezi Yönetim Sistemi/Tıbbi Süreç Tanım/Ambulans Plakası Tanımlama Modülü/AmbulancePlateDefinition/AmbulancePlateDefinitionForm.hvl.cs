
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
    public partial class AmbulancePlateDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.AmbulancePlateDefinition _AmbulancePlateDefinition
        {
            get { return (TTObjectClasses.AmbulancePlateDefinition)_ttObject; }
        }

        protected ITTLabel labelPlate;
        protected ITTTextBox Plate;
        override protected void InitializeControls()
        {
            labelPlate = (ITTLabel)AddControl(new Guid("0056a283-2393-47d3-af50-f9c9595aaa29"));
            Plate = (ITTTextBox)AddControl(new Guid("a7fd5a4b-8205-4fd2-9b69-51efb34f7151"));
            base.InitializeControls();
        }

        public AmbulancePlateDefinitionForm() : base("AMBULANCEPLATEDEFINITION", "AmbulancePlateDefinitionForm")
        {
        }

        protected AmbulancePlateDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}