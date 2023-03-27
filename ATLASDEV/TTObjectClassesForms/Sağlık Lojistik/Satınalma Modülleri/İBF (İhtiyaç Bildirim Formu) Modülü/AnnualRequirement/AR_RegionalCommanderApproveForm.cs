
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
    /// Bölge XXXXXX / XXXXXX Onay
    /// </summary>
    public partial class AR_RegionalCommanderApproveForm : AR_BaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region AR_RegionalCommanderApproveForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            
            List<TTObject> ttObjects = _AnnualRequirement.FillDetailsForRemote();
            //TTMessage message = AnnualRequirement.RemoteMethods.SaveIBF((Guid)Sites.SiteMerkezSagKom, ttObjects);
        }
        
#endregion AR_RegionalCommanderApproveForm_Methods
    }
}