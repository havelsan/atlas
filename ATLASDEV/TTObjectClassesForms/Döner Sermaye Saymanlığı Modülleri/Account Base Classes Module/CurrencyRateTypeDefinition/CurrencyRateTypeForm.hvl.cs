
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
    /// Para Birimleri Kur Alış Satış Tipi
    /// </summary>
    public partial class CurrencyRateTypeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kur Alış Satış Tipi
    /// </summary>
        protected TTObjectClasses.CurrencyRateTypeDefinition _CurrencyRateTypeDefinition
        {
            get { return (TTObjectClasses.CurrencyRateTypeDefinition)_ttObject; }
        }

        protected ITTTextBox NAME;
        protected ITTTextBox CODE;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            NAME = (ITTTextBox)AddControl(new Guid("aba7f1d0-63e7-4fa2-85f2-9f4f6a4e7b15"));
            CODE = (ITTTextBox)AddControl(new Guid("49e33d7a-697c-4933-90da-ff01fc558843"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5e6a96d5-2701-4dd9-943a-fb65daca9a1f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("86f79be5-94e0-4803-be9a-89eaf76ceeb6"));
            base.InitializeControls();
        }

        public CurrencyRateTypeForm() : base("CURRENCYRATETYPEDEFINITION", "CurrencyRateTypeForm")
        {
        }

        protected CurrencyRateTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}