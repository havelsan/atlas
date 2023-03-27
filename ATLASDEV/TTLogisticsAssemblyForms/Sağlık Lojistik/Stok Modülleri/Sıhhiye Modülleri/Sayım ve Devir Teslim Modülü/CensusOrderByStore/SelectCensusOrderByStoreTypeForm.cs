
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
    /// Depoya Göre Sayım Emri Tipi ve Masa Seçimi
    /// </summary>
    public partial class SelectCensusOrderByStoreTypeForm : TTForm
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
#region SelectCensusOrderByStoreTypeForm_PreScript
    base.PreScript();
            _CensusOrderByStore.CensusOrderType = CensusOrderTypeEnum.HaveInheld ;
#endregion SelectCensusOrderByStoreTypeForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SelectCensusOrderByStoreTypeForm_PostScript
    base.PostScript(transDef);
#endregion SelectCensusOrderByStoreTypeForm_PostScript

            }
                }
}