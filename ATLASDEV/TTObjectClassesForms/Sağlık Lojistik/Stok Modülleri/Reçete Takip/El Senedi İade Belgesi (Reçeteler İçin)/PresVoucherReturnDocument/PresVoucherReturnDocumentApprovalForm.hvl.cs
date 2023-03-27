
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
    /// El Senedi İade Belgesi (Reçeteler İçin) 
    /// </summary>
    public partial class PresVoucherReturnDocumentApprovalForm : BasePresVoucherReturnDocumentForm
    {
    /// <summary>
    /// El Senedi İade Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresVoucherReturnDocument _PresVoucherReturnDocument
        {
            get { return (TTObjectClasses.PresVoucherReturnDocument)_ttObject; }
        }

        protected ITTTextBoxColumn PresStoreStock;
        protected ITTTextBoxColumn PresDestinationStoreStock;
        override protected void InitializeControls()
        {
            PresStoreStock = (ITTTextBoxColumn)AddControl(new Guid("8c353fd5-8c1a-4497-896a-c5bfce47e46f"));
            PresDestinationStoreStock = (ITTTextBoxColumn)AddControl(new Guid("b602bdbf-d090-49e4-878f-c750bcf2a45c"));
            base.InitializeControls();
        }

        public PresVoucherReturnDocumentApprovalForm() : base("PRESVOUCHERRETURNDOCUMENT", "PresVoucherReturnDocumentApprovalForm")
        {
        }

        protected PresVoucherReturnDocumentApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}