
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
    /// İşlem Kaynak Eşleştirme Tanımları
    /// </summary>
    public partial class ActionDefaultMasterResourceDefinitionForm : TTDefinitionForm
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
#region ActionDefaultMasterResourceDefinitionForm_PostScript
    base.PostScript(transDef);
              IList definitionList=ActionDefaultMasterResourceDefinition.GetActionDefaultMasterResourceDefinition("WHERE ACTIONTYPE=" + this._ActionDefaultMasterResourceDefinition.ActionType.GetHashCode() + " AND OBJECTID<>'" + this._ActionDefaultMasterResourceDefinition.ObjectID.ToString() +  "'");
            if (definitionList.Count>0){
                throw new Exception("Daha önce "+this._ActionDefaultMasterResourceDefinition.ActionType + " Kabul tipi için  tanım yapılmıştır.Lütfen eski tanım üzerinde düzeltme yapınız. ");
            }
#endregion ActionDefaultMasterResourceDefinitionForm_PostScript

            }
                }
}