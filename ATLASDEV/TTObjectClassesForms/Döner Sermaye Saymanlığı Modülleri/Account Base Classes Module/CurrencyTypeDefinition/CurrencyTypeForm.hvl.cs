
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
    /// Para Birimi Tanımı
    /// </summary>
    public partial class CurrencyTypeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Para birimleri tanimi
    /// </summary>
        protected TTObjectClasses.CurrencyTypeDefinition _CurrencyTypeDefinition
        {
            get { return (TTObjectClasses.CurrencyTypeDefinition)_ttObject; }
        }

        protected ITTTextBox CODE;
        protected ITTTextBox NAME;
        protected ITTTextBox QREF;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox IsActive;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            CODE = (ITTTextBox)AddControl(new Guid("a49e1e53-9c5b-449a-b340-6377914f7b55"));
            NAME = (ITTTextBox)AddControl(new Guid("990fdc82-7886-45db-9948-888db36af41d"));
            QREF = (ITTTextBox)AddControl(new Guid("ba5f3613-fae4-49e3-aa76-a5945ec19d21"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("e8c8aa35-4625-4da7-8892-350949fa902b"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("b5e7decb-8137-46e0-9de1-982be3e32455"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("0570018e-9e53-428a-becc-8d54818c4c65"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b42d5075-66df-4526-a760-e05c0c852a8c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0b25f2e5-2d0f-4fb7-9f3c-ebd8eded5336"));
            IsActive = (ITTCheckBox)AddControl(new Guid("b9e0a36e-3398-451a-a404-23282cf40de6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d04f257c-1737-422b-b713-ec493e089d67"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ec4222f8-b528-42f8-a8bb-5f28a696d8eb"));
            base.InitializeControls();
        }

        public CurrencyTypeForm() : base("CURRENCYTYPEDEFINITION", "CurrencyTypeForm")
        {
        }

        protected CurrencyTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}