
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
    /// XXXXXXlik Şubesi Tanımları
    /// </summary>
    public partial class MilitaryOfficeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// XXXXXXlik Şubesi Tanımları
    /// </summary>
        protected TTObjectClasses.MilitaryOffice _MilitaryOffice
        {
            get { return (TTObjectClasses.MilitaryOffice)_ttObject; }
        }

        protected ITTLabel labelExternalCode;
        protected ITTTextBox ExternalCode;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTCheckBox Active;
        protected ITTObjectListBox City;
        protected ITTLabel labelCity;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            labelExternalCode = (ITTLabel)AddControl(new Guid("86e2a82e-cacb-41fa-bcd1-cdd76dbd804b"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("eb6dfff7-37fe-4a9e-84b0-741532f9b9e3"));
            labelName = (ITTLabel)AddControl(new Guid("cb2624d8-4c0c-47e0-ada6-4fb4179f40bb"));
            Name = (ITTTextBox)AddControl(new Guid("a54ad302-453f-4d7f-94c1-5293a450c746"));
            labelCode = (ITTLabel)AddControl(new Guid("81075ffe-b287-4ef3-beda-eb2a1578b73b"));
            Code = (ITTTextBox)AddControl(new Guid("287b05ff-0704-452e-ab39-269a2a38d3c5"));
            Active = (ITTCheckBox)AddControl(new Guid("d9bea30a-358b-4b3c-909e-7c4ee92e66de"));
            City = (ITTObjectListBox)AddControl(new Guid("b91a91e2-dcd8-4497-a18e-884c34e72574"));
            labelCity = (ITTLabel)AddControl(new Guid("e7042715-1673-40fd-bcc1-9923a6a263b3"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("9de6a064-e1c9-431b-bb41-c4a23e1989db"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1446740b-7330-4c82-a555-401ca1a6c227"));
            base.InitializeControls();
        }

        public MilitaryOfficeForm() : base("MILITARYOFFICE", "MilitaryOfficeForm")
        {
        }

        protected MilitaryOfficeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}