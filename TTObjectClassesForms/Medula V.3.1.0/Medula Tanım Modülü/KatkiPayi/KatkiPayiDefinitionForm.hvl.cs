
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
    /// Katkı Payı Tanımlama
    /// </summary>
    public partial class KatkiPayiDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Katkı Payı
    /// </summary>
        protected TTObjectClasses.KatkiPayi _KatkiPayi
        {
            get { return (TTObjectClasses.KatkiPayi)_ttObject; }
        }

        protected ITTLabel labelkatkiPayiAdi;
        protected ITTTextBox katkiPayiAdi;
        protected ITTLabel labelkatkiPayiKodu;
        protected ITTTextBox katkiPayiKodu;
        override protected void InitializeControls()
        {
            labelkatkiPayiAdi = (ITTLabel)AddControl(new Guid("7637c098-4395-4042-83d4-b97c5a9ff4f8"));
            katkiPayiAdi = (ITTTextBox)AddControl(new Guid("9f020993-4d5f-417b-99ba-2a3d58e4becd"));
            labelkatkiPayiKodu = (ITTLabel)AddControl(new Guid("b5439962-0303-449b-b91a-97ed91d7b33f"));
            katkiPayiKodu = (ITTTextBox)AddControl(new Guid("8b924a8d-cdcc-4f8b-b965-eadfccad340d"));
            base.InitializeControls();
        }

        public KatkiPayiDefinitionForm() : base("KATKIPAYI", "KatkiPayiDefinitionForm")
        {
        }

        protected KatkiPayiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}