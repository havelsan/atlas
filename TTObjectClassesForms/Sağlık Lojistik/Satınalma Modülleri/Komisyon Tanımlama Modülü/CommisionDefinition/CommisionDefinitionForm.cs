
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
    /// Komisyon Tanımlama
    /// </summary>
    public partial class CommisionDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CommisionDefinitionForm_PostScript
    base.PostScript(transDef);
    
//            IList commision = CommisionDefinition.GetCommisionByType((CommisionTypeEnum)CommisionType.SelectedItem.Value);
//            if (commision.Count > 0)
//                throw new TTUtils.TTException("Bu komisyon türü daha önce tanımlanmış");
#endregion CommisionDefinitionForm_PostScript

            }
                }
}