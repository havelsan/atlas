
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
    /// Ana Hasta Grup Tanımı
    /// </summary>
    public partial class MainPatientGroupDefinitionForm : TerminologyManagerDefForm
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
#region MainPatientGroupDefinitionForm_PostScript
    base.PostScript(transDef);
            BindingList<MainPatientGroupDefinition.GetMainPatientGroupDefinition_Class>  definitionList=MainPatientGroupDefinition.GetMainPatientGroupDefinition("WHERE MAINPATIENTGROUPENUM=" + this._MainPatientGroupDefinition.MainPatientGroupEnum.GetHashCode() );
            if (definitionList.Count>0 && ((definitionList[0].ObjectID).ToString()!=this._MainPatientGroupDefinition.ObjectID.ToString()))
                throw new Exception(SystemMessage.GetMessageV3(1271, new string[] {this._MainPatientGroupDefinition.MainPatientGroupEnum.ToString()}));
            
            this._MainPatientGroupDefinition.Name=Common.GetEnumValueDefOfEnumValue(this._MainPatientGroupDefinition.MainPatientGroupEnum).DisplayText;
#endregion MainPatientGroupDefinitionForm_PostScript

            }
                }
}