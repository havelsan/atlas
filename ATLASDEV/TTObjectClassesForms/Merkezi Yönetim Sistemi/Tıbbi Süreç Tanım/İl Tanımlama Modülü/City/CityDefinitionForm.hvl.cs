
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
    /// İl Tanımlama
    /// </summary>
    public partial class CityDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// İl Tanımları
    /// </summary>
        protected TTObjectClasses.City _City
        {
            get { return (TTObjectClasses.City)_ttObject; }
        }

        protected ITTCheckBox chkActive;
        protected ITTLabel labelMernisCode;
        protected ITTTextBox MernisCode;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTTextBox ExternalCode;
        protected ITTLabel labelCountry;
        protected ITTObjectListBox Country;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        protected ITTLabel labelExternalCode;
        override protected void InitializeControls()
        {
            chkActive = (ITTCheckBox)AddControl(new Guid("060186d6-715c-4c27-9946-4c6eed0ce9ad"));
            labelMernisCode = (ITTLabel)AddControl(new Guid("0daf52c6-8459-43b9-823f-1c1dde91d26e"));
            MernisCode = (ITTTextBox)AddControl(new Guid("ac9b24ce-d3c1-4d93-a45b-486f94477c5d"));
            Name = (ITTTextBox)AddControl(new Guid("d7ad2f86-4416-407c-93d8-5d00af8f3333"));
            Code = (ITTTextBox)AddControl(new Guid("42fb0544-80fc-4c26-9777-a755dc402932"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("01517b33-1a08-4b6e-9276-7b46288c9860"));
            labelCountry = (ITTLabel)AddControl(new Guid("7f97b090-1bab-49b8-8c89-2eebd97f9fbb"));
            Country = (ITTObjectListBox)AddControl(new Guid("f3866de7-8b40-451c-a915-75292d45661c"));
            labelName = (ITTLabel)AddControl(new Guid("872e91e6-65c9-4ab7-a68b-097a15712b84"));
            labelCode = (ITTLabel)AddControl(new Guid("aa191b98-79aa-4dbd-a52d-052c55dd048e"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("91697a75-d146-458c-aefa-9e03750f0396"));
            base.InitializeControls();
        }

        public CityDefinitionForm() : base("CITY", "CityDefinitionForm")
        {
        }

        protected CityDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}