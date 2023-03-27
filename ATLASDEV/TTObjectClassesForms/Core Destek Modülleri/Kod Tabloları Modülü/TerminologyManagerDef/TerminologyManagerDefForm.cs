
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
    /// TerminologyManagerDefForm
    /// </summary>
    public partial class TerminologyManagerDefForm : TTDefinitionForm
    {
        protected override void PreScript()
        {
#region TerminologyManagerDefForm_PreScript
    base.PreScript();

            /*
            bool isReadonly = true;
            if (this.IsEditor.HasValue)
                isReadonly = !this.IsEditor.Value;

            List<string> myLocalProperties = this._TerminologyManagerDef.GetMyLocalPropertyNamesList();
            foreach (Control ctl in this.pnlControls.Controls)
                SetControlReadOnlyStatus(ctl, myLocalProperties, isReadonly);
                */
               //TerminologyManager artık gerek kalmadıgı için kapatıldı.
#endregion TerminologyManagerDefForm_PreScript

            }
            
#region TerminologyManagerDefForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            //TerminologyManagerDef.RunSendTerminologyManagerDef(this._TerminologyManagerDef);,
            //Tüm Sahalara mesaj göndermesini engellemek için kapatıldı.
        }

        protected void SetControlReadOnlyStatus(Control ctl, List<string> myLocalProperties, bool isReadonly)
        {
            if (ctl is TTVisual.ITTBindableControl)//butonlar gelmez
            {
                TTVisual.ITTBindableControl control = (ITTBindableControl)ctl;
                if (!string.IsNullOrEmpty(control.DataMember))
                {
                    if (control is TTGrid)//Gridler için
                    {
                        System.Reflection.PropertyInfo propInfo = this._TerminologyManagerDef.GetType().GetProperty(control.DataMember);
                        if (propInfo != null)
                        {
                            if (propInfo.PropertyType.ReflectedType.IsSubclassOf(typeof(TerminologyManagerDef)))
                                ((ITTComponentBase)control).ReadOnly = isReadonly;
                            else
                                ((ITTComponentBase)control).ReadOnly = !isReadonly;
                        }
                    }
                    else
                    {
                        bool isLocalProperty = false;
                        if (myLocalProperties != null)
                        {
                            foreach (string propertyName in myLocalProperties)
                            {
                                if (propertyName.ToUpperInvariant() == control.DataMember)
                                {
                                    isLocalProperty = true;
                                    break;
                                }
                            }
                        }

                        if (isLocalProperty)
                            ((ITTComponentBase)control).ReadOnly = false;
                        else
                            ((ITTComponentBase)control).ReadOnly = isReadonly;
                    }
                }
            }

            foreach (Control childControl in ctl.Controls)
            {
                this.SetControlReadOnlyStatus(childControl, myLocalProperties, isReadonly);
            }
        }
        
#endregion TerminologyManagerDefForm_Methods
    }
}