
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
    public partial class RadiologyRequestDentalToothSchema : TTForm
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
#region RadiologyRequestDentalToothSchema_PreScript
    base.PreScript();
            this.cmdCancel.Visible = false;
#endregion RadiologyRequestDentalToothSchema_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyRequestDentalToothSchema_PostScript
    base.PostScript(transDef);
            //cancel a basılmış mı kontrolü yapılacak.
            this.addToothNumberList(this.Controls);
            /*if(ToothNumbersList.Count <= 0)
            {
                throw new TTException("İlgili tetkik için diş seçimi zorunludur." );
                return;
            }*/
#endregion RadiologyRequestDentalToothSchema_PostScript

            }
            
#region RadiologyRequestDentalToothSchema_Methods
        public List<ToothNumberEnum> ToothNumbersList = new List<ToothNumberEnum>();
        
        private void addToothNumberList(Control.ControlCollection controls)
        {
            //ToothNumbersList = new List<ToothNumberEnum>();
            foreach (Control currControl in controls)
            {
                if (currControl.GetType().Equals(typeof(TTCheckBox)) && currControl.Name.StartsWith("ch") && ((TTCheckBox)currControl).Checked)
                {
                    TTCheckBox currChkbox = (TTCheckBox)currControl;
                    TTDataDictionary.EnumValueDef enumValueDef = Common.GetEnumValueDefOfEnumValueV2("ToothNumberEnum",Int32.Parse(currChkbox.Name.Substring(2, currChkbox.Name.Length - 2)));
                    
                    if(enumValueDef != null)
                        ToothNumbersList.Add((ToothNumberEnum)enumValueDef.EnumValue);
                    //selectedCheckboxes.Add(currChkbox);
                }
                if (currControl.HasChildren)
                {
                    this.addToothNumberList(currControl.Controls);
                }
            }
        }
        
#endregion RadiologyRequestDentalToothSchema_Methods
    }
}