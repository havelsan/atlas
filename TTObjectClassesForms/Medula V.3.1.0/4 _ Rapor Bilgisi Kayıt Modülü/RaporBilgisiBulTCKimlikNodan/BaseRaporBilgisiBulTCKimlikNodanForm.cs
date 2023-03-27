
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
    public partial class BaseRaporBilgisiBulTCKimlikNodanForm : BaseMedulaActionForm
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
#region BaseRaporBilgisiBulTCKimlikNodanForm_PreScript
    base.PreScript();
            _RaporBilgisiBulTCKimlikNodan.raporOkuTCKimlikNodanDVO.kullaniciTesisKodu = _RaporBilgisiBulTCKimlikNodan.HealthFacilityID.Value;
#endregion BaseRaporBilgisiBulTCKimlikNodanForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseRaporBilgisiBulTCKimlikNodanForm_PostScript
    base.PostScript(transDef);
            
            CheckTheIdentificationNumber(tckimlikNoRaporOkuTCKimlikNodanDVO.Text);
#endregion BaseRaporBilgisiBulTCKimlikNodanForm_PostScript

            }
                }
}