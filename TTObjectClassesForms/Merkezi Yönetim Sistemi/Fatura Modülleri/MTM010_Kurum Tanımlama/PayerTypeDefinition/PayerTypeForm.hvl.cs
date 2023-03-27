
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
    /// Kurum Türü Tanımı
    /// </summary>
    public partial class PayerTypeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kurum tipi
    /// </summary>
        protected TTObjectClasses.PayerTypeDefinition _PayerTypeDefinition
        {
            get { return (TTObjectClasses.PayerTypeDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox PayerType;
        protected ITTCheckBox ISACTIVE;
        protected ITTTextBox ID;
        protected ITTTextBox NAME;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelSKRSSosyalGuvenceDurumu;
        protected ITTObjectListBox SKRSSosyalGuvenceDurumu;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("c9b58f07-0295-4f62-927e-f7a1c639c349"));
            PayerType = (ITTEnumComboBox)AddControl(new Guid("08c378b0-1739-455e-b64c-2866a5fe0f8c"));
            ISACTIVE = (ITTCheckBox)AddControl(new Guid("0ed96fb9-0596-4937-8621-af77034028f5"));
            ID = (ITTTextBox)AddControl(new Guid("04325147-ffa9-4e0e-94e7-1ef2e7b13e68"));
            NAME = (ITTTextBox)AddControl(new Guid("b6baeb65-114c-4557-ae97-b84634564ee3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e11e6371-d280-4355-9ec6-3798e1e328e8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a4fa49cb-35db-4aef-ac74-a831ed3544ef"));
            labelSKRSSosyalGuvenceDurumu = (ITTLabel)AddControl(new Guid("025d90b0-96a3-41f1-87bf-a8ab95da1747"));
            SKRSSosyalGuvenceDurumu = (ITTObjectListBox)AddControl(new Guid("783c54a3-57db-450f-a6d7-bb53064f175f"));
            base.InitializeControls();
        }

        public PayerTypeForm() : base("PAYERTYPEDEFINITION", "PayerTypeForm")
        {
        }

        protected PayerTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}