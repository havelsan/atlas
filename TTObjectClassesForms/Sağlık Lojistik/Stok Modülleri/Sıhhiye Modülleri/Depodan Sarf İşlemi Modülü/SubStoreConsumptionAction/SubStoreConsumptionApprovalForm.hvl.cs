
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
    /// Depodan Sarf
    /// </summary>
    public partial class SubStoreConsumptionApprovalForm : BaseSubStoreConsumptionActionForm
    {
    /// <summary>
    /// Depodan Sarf İşlemi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.SubStoreConsumptionAction _SubStoreConsumptionAction
        {
            get { return (TTObjectClasses.SubStoreConsumptionAction)_ttObject; }
        }

        public SubStoreConsumptionApprovalForm() : base("SUBSTORECONSUMPTIONACTION", "SubStoreConsumptionApprovalForm")
        {
        }

        protected SubStoreConsumptionApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}