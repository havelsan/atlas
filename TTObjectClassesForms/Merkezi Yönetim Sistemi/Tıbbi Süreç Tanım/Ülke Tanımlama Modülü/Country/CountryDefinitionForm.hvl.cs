
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
    /// Ülke Tanımlama
    /// </summary>
    public partial class CountryDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Ülke Tanımları
    /// </summary>
        protected TTObjectClasses.Country _Country
        {
            get { return (TTObjectClasses.Country)_ttObject; }
        }

        protected ITTLabel labelMernisCode;
        protected ITTTextBox MernisCode;
        protected ITTTextBox Name;
        protected ITTTextBox ExternalCode;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTLabel labelExternalCode;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelMernisCode = (ITTLabel)AddControl(new Guid("d3127c3f-015f-4ce2-8f36-9a1be1a1d8a8"));
            MernisCode = (ITTTextBox)AddControl(new Guid("da1ae05e-8954-4670-ad80-4a861745de78"));
            Name = (ITTTextBox)AddControl(new Guid("b80cadd9-031b-4f86-8560-13fd4086e0fa"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("9fb027df-8699-4699-9e7a-cf66e014a80e"));
            Code = (ITTTextBox)AddControl(new Guid("13002f19-7b6b-4554-8666-4989bd60ba45"));
            labelName = (ITTLabel)AddControl(new Guid("dee6b4f8-5ca1-4d2f-b08e-35d676606705"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("64531482-b02f-45b0-9cd1-3cff441940db"));
            labelCode = (ITTLabel)AddControl(new Guid("a78ffba0-6b5f-4615-8d63-5df3ba84ff46"));
            base.InitializeControls();
        }

        public CountryDefinitionForm() : base("COUNTRY", "CountryDefinitionForm")
        {
        }

        protected CountryDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}