
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
    /// Lojman Bölge Tanımlama
    /// </summary>
    public partial class NewApartmentAreaForm : TTForm
    {
    /// <summary>
    /// Lojman Bölge Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSApartmentAreaDefinition _MPBSApartmentAreaDefinition
        {
            get { return (TTObjectClasses.MPBSApartmentAreaDefinition)_ttObject; }
        }

        protected ITTLabel labelAreaName;
        protected ITTLabel labelNumberOfApartment;
        protected ITTTextBox NumberOfApartment;
        protected ITTTextBox AreaName;
        override protected void InitializeControls()
        {
            labelAreaName = (ITTLabel)AddControl(new Guid("537e1247-5c3c-4974-979d-0b4fd10d823d"));
            labelNumberOfApartment = (ITTLabel)AddControl(new Guid("038d726c-39fe-4451-a24a-153fe22ee119"));
            NumberOfApartment = (ITTTextBox)AddControl(new Guid("aee74dbe-e10a-4240-8fa9-4bd06a0133e7"));
            AreaName = (ITTTextBox)AddControl(new Guid("bfb630bd-00dd-4b09-b4f0-6161b88da0ba"));
            base.InitializeControls();
        }

        public NewApartmentAreaForm() : base("MPBSAPARTMENTAREADEFINITION", "NewApartmentAreaForm")
        {
        }

        protected NewApartmentAreaForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}