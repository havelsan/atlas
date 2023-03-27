
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
    public partial class RaporUzatForm : BaseRaporUzatForm
    {
        protected override void PreScript()
        {
#region RaporUzatForm_PreScript
    base.PreScript();
            _RaporUzat.isgoremezlikRaporEkDVO.kullaniciTesisKodu = _RaporUzat.HealthFacilityID.Value;
#endregion RaporUzatForm_PreScript

            }
                }
}