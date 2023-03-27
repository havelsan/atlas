
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
    public partial class DisTaahhutOkuKisiForm : BaseMedulaActionForm
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
#region DisTaahhutOkuKisiForm_PreScript
    base.PreScript();
            _DisTaahhutOkuKisi.taahhutKisiOkuDVO.saglikTesisKodu= _DisTaahhutOkuKisi.HealthFacilityID.Value;
#endregion DisTaahhutOkuKisiForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DisTaahhutOkuKisiForm_PostScript
    base.PostScript(transDef);
            CheckTheIdentificationNumber(tcKimlikNoTaahhutKisiOkuDVO.Text);
#endregion DisTaahhutOkuKisiForm_PostScript

            }
                }
}