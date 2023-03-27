
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
    /// Hizmet Fiyat Eşleştirme
    /// </summary>
    public partial class ProcedurePricingDetailMatchingForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hizmet Tanımı
    /// </summary>
        protected TTObjectClasses.ProcedureDefinition _ProcedureDefinition
        {
            get { return (TTObjectClasses.ProcedureDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTGrid GRIDPROCEDUREPRICE;
        protected ITTListBoxColumn a;
        protected ITTListBoxColumn aaa;
        protected ITTTextBoxColumn aa;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("b8abb29a-3994-4ecc-b342-3cfb9e16b26b"));
            GRIDPROCEDUREPRICE = (ITTGrid)AddControl(new Guid("9bf3c296-cbff-4076-b9b5-f345ceba8578"));
            a = (ITTListBoxColumn)AddControl(new Guid("9031beea-10d0-4e52-bad6-e4d9ba2cdb83"));
            aaa = (ITTListBoxColumn)AddControl(new Guid("1771fc71-d17e-4e4b-87a9-acd0b1b84af0"));
            aa = (ITTTextBoxColumn)AddControl(new Guid("96befaaa-68de-40e5-ac05-b99a6f9e50e7"));
            base.InitializeControls();
        }

        public ProcedurePricingDetailMatchingForm() : base("PROCEDUREDEFINITION", "ProcedurePricingDetailMatchingForm")
        {
        }

        protected ProcedurePricingDetailMatchingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}