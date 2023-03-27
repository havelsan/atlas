
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
    /// Satınalma İşlemleri İçin Firmalardan İstenen Belgeler
    /// </summary>
    public partial class PurchasingDocumentsForFirmsDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.PurchasingDocumentsForFirmsDefinition _PurchasingDocumentsForFirmsDefinition
        {
            get { return (TTObjectClasses.PurchasingDocumentsForFirmsDefinition)_ttObject; }
        }

        protected ITTTextBox DocumentName;
        protected ITTLabel labelDocumentName;
        override protected void InitializeControls()
        {
            DocumentName = (ITTTextBox)AddControl(new Guid("dc335e79-e8c2-4e6e-9c6c-1f6af192e813"));
            labelDocumentName = (ITTLabel)AddControl(new Guid("06c8a706-45f8-407e-9ab0-5c83132e3ba4"));
            base.InitializeControls();
        }

        public PurchasingDocumentsForFirmsDefinitionForm() : base("PURCHASINGDOCUMENTSFORFIRMSDEFINITION", "PurchasingDocumentsForFirmsDefinitionForm")
        {
        }

        protected PurchasingDocumentsForFirmsDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}