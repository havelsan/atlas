
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
    /// Sevk Nedeni Tanımlama
    /// </summary>
    public partial class SevkNedeniDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Sevk Nedeni
    /// </summary>
        protected TTObjectClasses.SevkNedeni _SevkNedeni
        {
            get { return (TTObjectClasses.SevkNedeni)_ttObject; }
        }

        protected ITTLabel labelSevkNedeniKodu;
        protected ITTTextBox SevkNedeniKodu;
        protected ITTLabel labelSevkNedeniAdi;
        protected ITTTextBox SevkNedeniAdi;
        override protected void InitializeControls()
        {
            labelSevkNedeniKodu = (ITTLabel)AddControl(new Guid("8f070e21-d667-4e4e-994c-de0a59b75245"));
            SevkNedeniKodu = (ITTTextBox)AddControl(new Guid("ff6269c5-ee48-499c-b0ea-11ccea91624e"));
            labelSevkNedeniAdi = (ITTLabel)AddControl(new Guid("e852acf5-cd13-44f7-aacf-0bc91832cf37"));
            SevkNedeniAdi = (ITTTextBox)AddControl(new Guid("07f183a9-25ba-40bd-b6db-3dda7b71d9df"));
            base.InitializeControls();
        }

        public SevkNedeniDefinitionForm() : base("SEVKNEDENI", "SevkNedeniDefinitionForm")
        {
        }

        protected SevkNedeniDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}