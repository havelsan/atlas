
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
    /// Normal Doğum İşlemleri
    /// </summary>
    public partial class RegularObstetricCesareanReqForm : EpisodeActionForm
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
#region RegularObstetricCesareanReqForm_PreScript
    base.PreScript();
            _RegularObstetric.Note= "Hastanın Normal Doğum İşlemi tamamlanamamıştır, Ameliyat İşlemi başlatılmıştır. Hasta Dosyasından başlatılan işlemi takip edebilirsiniz." ;
#endregion RegularObstetricCesareanReqForm_PreScript

            }
                }
}