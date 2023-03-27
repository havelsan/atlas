
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
    /// Döner Sermaye Hasta İade Nedeni Tanım Ekranı
    /// </summary>
    public partial class FinancialReturnReasonForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Döner Sermaye Hasta İade Nedeni Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.FinancialReturnReasonDefinition _FinancialReturnReasonDefinition
        {
            get { return (TTObjectClasses.FinancialReturnReasonDefinition)_ttObject; }
        }

        protected ITTTextBox NAME;
        protected ITTTextBox CODE;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            NAME = (ITTTextBox)AddControl(new Guid("98aa1539-bce5-4d7b-aabe-7a8e00adbbb2"));
            CODE = (ITTTextBox)AddControl(new Guid("fdb0112e-ddd3-47cf-a12b-1d74df8d46c8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b8af939a-eced-4897-a945-b5d1bf01eefc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a8644d26-5995-4456-b284-cc8b1a2d0735"));
            base.InitializeControls();
        }

        public FinancialReturnReasonForm() : base("FINANCIALRETURNREASONDEFINITION", "FinancialReturnReasonForm")
        {
        }

        protected FinancialReturnReasonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}