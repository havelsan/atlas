
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
    /// Diş İşlemleri İstek Türleri Tanımları
    /// </summary>
    public partial class DenatalRequestTypeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Diş İşlemleri İstek Türleri Tanımları
    /// </summary>
        protected TTObjectClasses.DentalRequestTypeDefinition _DentalRequestTypeDefinition
        {
            get { return (TTObjectClasses.DentalRequestTypeDefinition)_ttObject; }
        }

        protected ITTLabel labelType;
        protected ITTTextBox Type;
        override protected void InitializeControls()
        {
            labelType = (ITTLabel)AddControl(new Guid("6840d23e-653f-47b1-a73c-6fe3fbda076c"));
            Type = (ITTTextBox)AddControl(new Guid("b05eaca5-687b-4ee3-89ae-0ed7a4ef3d9d"));
            base.InitializeControls();
        }

        public DenatalRequestTypeForm() : base("DENTALREQUESTTYPEDEFINITION", "DenatalRequestTypeForm")
        {
        }

        protected DenatalRequestTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}