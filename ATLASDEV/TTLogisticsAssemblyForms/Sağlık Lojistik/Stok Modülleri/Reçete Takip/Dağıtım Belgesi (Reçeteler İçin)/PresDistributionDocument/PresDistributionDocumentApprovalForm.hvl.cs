
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
    /// Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresDistributionDocumentApprovalForm : BasePresDistributionDocumentForm
    {
    /// <summary>
    /// Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresDistributionDocument _PresDistributionDocument
        {
            get { return (TTObjectClasses.PresDistributionDocument)_ttObject; }
        }

        public PresDistributionDocumentApprovalForm() : base("PRESDISTRIBUTIONDOCUMENT", "PresDistributionDocumentApprovalForm")
        {
        }

        protected PresDistributionDocumentApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}