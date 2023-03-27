
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
    public partial class SupplyRequestPoolApprovalForm : BaseSupplyRequestPoolForm
    {
    /// <summary>
    /// Satınalma Talep Havuzu
    /// </summary>
        protected TTObjectClasses.SupplyRequestPool _SupplyRequestPool
        {
            get { return (TTObjectClasses.SupplyRequestPool)_ttObject; }
        }

        public SupplyRequestPoolApprovalForm() : base("SUPPLYREQUESTPOOL", "SupplyRequestPoolApprovalForm")
        {
        }

        protected SupplyRequestPoolApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}