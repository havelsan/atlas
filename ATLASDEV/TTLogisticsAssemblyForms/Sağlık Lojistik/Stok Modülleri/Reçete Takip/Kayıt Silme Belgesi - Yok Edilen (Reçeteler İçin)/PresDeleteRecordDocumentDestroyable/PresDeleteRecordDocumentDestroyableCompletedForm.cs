
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
    /// Kayıt Silme Belgesi - Yok Edilen Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresDeleteRecordDocumentDestroyableCompletedForm : BasePresDeleteRecordDocumentDestroyableForm
    {
        protected override void PreScript()
        {
#region PresDeleteRecordDocumentDestroyableCompletedForm_PreScript
    base.PreScript();
            if(this._PresDeleteRecordDocumentDestroyable.StockActionInspection == null)
                DropCurrentStateReport(TTObjectDefManager.Instance.ReportDefs[new Guid("1c95415c-307f-41fa-a79a-b8aa82cb0df3")].ReportDefID);
#endregion PresDeleteRecordDocumentDestroyableCompletedForm_PreScript

            }
                }
}