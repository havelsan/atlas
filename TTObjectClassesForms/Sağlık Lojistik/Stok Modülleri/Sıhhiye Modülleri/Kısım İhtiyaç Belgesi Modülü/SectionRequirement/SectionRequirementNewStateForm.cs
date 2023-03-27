
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
    /// Kısım İhtiyaç Belgesi
    /// </summary>
    public partial class SectionRequirementNewStateForm : BaseSectionRequirementForm
    {
        protected override void PreScript()
        {
#region SectionRequirementNewStateForm_PreScript
    base.PreScript();
            ((ITTListBoxColumn)((ITTGridColumn)this.StockActionOutDetails.Columns[MaterialName.Name])).ListFilterExpression="STOCKS.STORE= "+ ConnectionManager.GuidToString(this._SectionRequirement.Store.ObjectID) + " AND STOCKS.INHELD>0" ;
#endregion SectionRequirementNewStateForm_PreScript

            }
                }
}