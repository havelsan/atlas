
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
    public partial class PresVoucherReturnDocumentNewForm : BasePresVoucherReturnDocumentForm
    {
    /// <summary>
    /// El Senedi İade Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresVoucherReturnDocument _PresVoucherReturnDocument
        {
            get { return (TTObjectClasses.PresVoucherReturnDocument)_ttObject; }
        }

        public PresVoucherReturnDocumentNewForm() : base("PRESVOUCHERRETURNDOCUMENT", "PresVoucherReturnDocumentNewForm")
        {
        }

        protected PresVoucherReturnDocumentNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}