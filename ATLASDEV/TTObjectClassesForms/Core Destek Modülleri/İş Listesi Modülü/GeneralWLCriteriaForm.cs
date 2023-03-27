
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
    /// Genel İş Listesi
    /// </summary>
    public partial class GeneralWLCriteriaForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region GeneralWLCriteriaForm_Methods
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return BaseAction.GetByBaseActionWorklistDate(context, dtStart, dtEnd, sExpression);
        }
        
        public override void OnSave()
        {
            base.OnSave();
        }
        
#endregion GeneralWLCriteriaForm_Methods
    }
}