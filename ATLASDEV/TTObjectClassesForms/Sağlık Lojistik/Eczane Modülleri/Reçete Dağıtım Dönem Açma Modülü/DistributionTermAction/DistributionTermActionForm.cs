
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Reçete Dağıtım Dönem Açma
    /// </summary>
    public partial class DistributionTermActionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region DistributionTermActionForm_PreScript
    base.PreScript();
    this.DropStateButton(DistributionTermAction.States.Cancelled);
    BindingList<ExternalPharmacyDistributionTerm> ClosedDistributionTerm = ExternalPharmacyDistributionTerm.GetOpenDistributionTerm(_DistributionTermAction.ObjectContext);
    if (ClosedDistributionTerm.Count > 0)
    {
        _DistributionTermAction.CloseTerm = ClosedDistributionTerm[0];
        _DistributionTermAction.StartDate = ((DateTime)ClosedDistributionTerm[0].EndDate).AddDays(1);
    }
    else
    {
        _DistributionTermAction.StartDate = Common.RecTime();
    }
#endregion DistributionTermActionForm_PreScript

            }
                }
}