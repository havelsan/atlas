
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
    public partial class BasePresDeleteRecordDocumentDestroyableForm : BaseDeleteRecordDocumentDestroyableForm
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
#region BasePresDeleteRecordDocumentDestroyableForm_PreScript
    base.PreScript();
            tttabcontrol2.HideTabPage(MaterialTabPage);
            ((ITTListBoxColumn)((ITTGridColumn)this.PresDeleteRecordDocumentDestroyableOutMaterials.Columns[MaterialPresDeleteRecordDocumentDestroyableMaterialOut.Name])).ListFilterExpression = "STOCKS.STORE=" + ConnectionManager.GuidToString(this._PresDeleteRecordDocumentDestroyable.Store.ObjectID) + " AND STOCKS.INHELD > 0 AND STOCKS.MATERIAL.OBJECTDEFID <> " + ConnectionManager.GuidToString(TTObjectDefManager.Instance.ObjectDefs[typeof(FixedAssetDefinition).Name].ID);
#endregion BasePresDeleteRecordDocumentDestroyableForm_PreScript

            }
                }
}