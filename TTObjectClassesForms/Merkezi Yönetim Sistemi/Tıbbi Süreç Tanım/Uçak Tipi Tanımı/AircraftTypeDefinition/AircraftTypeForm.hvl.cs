
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
    /// Uçak Tipi Tanımı
    /// </summary>
    public partial class AircraftTypeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Uçak Tipi Tanımı
    /// </summary>
        protected TTObjectClasses.AircraftTypeDefinition _AircraftTypeDefinition
        {
            get { return (TTObjectClasses.AircraftTypeDefinition)_ttObject; }
        }

        protected ITTTextBox NAME;
        protected ITTTextBox CODE;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            NAME = (ITTTextBox)AddControl(new Guid("202e87eb-555d-463f-be1d-9800e26c1e15"));
            CODE = (ITTTextBox)AddControl(new Guid("43793343-ec0e-4f50-b222-4850260098ff"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b8a9fb61-3a07-4f7e-b4a8-f07ccc2af356"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5ae9cb86-0b6b-4422-b891-e84379623a17"));
            base.InitializeControls();
        }

        public AircraftTypeForm() : base("AIRCRAFTTYPEDEFINITION", "AircraftTypeForm")
        {
        }

        protected AircraftTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}