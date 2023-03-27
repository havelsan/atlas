
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
    /// Hasta Kabul Oku
    /// </summary>
    public partial class BaseHastaKabulOkuForm : BaseMedulaActionForm
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
#region BaseHastaKabulOkuForm_PreScript
    base.PreScript();

            ITTObject iTTObject = (ITTObject)_BaseHastaKabulOku;
            if (iTTObject.IsNew)
                _BaseHastaKabulOku.takipOkuGirisDVO.saglikTesisKodu = _BaseHastaKabulOku.HealthFacilityID.Value;
#endregion BaseHastaKabulOkuForm_PreScript

            }
                }
}