
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
    public partial class MedulaTransferImportedFileForm : BaseMedulaTransferForm
    {
    /// <summary>
    /// Medulaya Aktar
    /// </summary>
        protected TTObjectClasses.MedulaTransfer _MedulaTransfer
        {
            get { return (TTObjectClasses.MedulaTransfer)_ttObject; }
        }

        public MedulaTransferImportedFileForm() : base("MEDULATRANSFER", "MedulaTransferImportedFileForm")
        {
        }

        protected MedulaTransferImportedFileForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}