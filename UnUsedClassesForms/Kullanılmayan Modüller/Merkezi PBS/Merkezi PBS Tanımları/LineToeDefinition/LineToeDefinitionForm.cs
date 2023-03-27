
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
    public partial class LineToeDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            SectionId.SelectedObjectChanged += new TTControlEventDelegate(SectionId_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SectionId.SelectedObjectChanged -= new TTControlEventDelegate(SectionId_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void SectionId_SelectedObjectChanged()
        {
#region LineToeDefinitionForm_SectionId_SelectedObjectChanged
   mainToeDescr.Text  =string.Empty;
              paragraphToeDescr.Text =  string.Empty;

 if (_LineToeDefinition.SectionId != null && _LineToeDefinition.SectionId.OfficeId != null && _LineToeDefinition.SectionId.OfficeId.UnitId != null && _LineToeDefinition.SectionId.OfficeId.UnitId.UnitEnclosureID != null)
            {
                mainToeDescr.Text  = _LineToeDefinition.SectionId.OfficeId.UnitId.MAINTOECODE+ " - " +
                _LineToeDefinition.SectionId.OfficeId.UnitId.UnitEnclosureID.NAME + " - " +
                    _LineToeDefinition.SectionId.OfficeId.UnitId.NAME;
              paragraphToeDescr.Text =  _LineToeDefinition.SectionId.PARAGRAPHTOECODE+ " - " + _LineToeDefinition.SectionId.OfficeId.NAME + " - " + _LineToeDefinition.SectionId.NAME;

            }
#endregion LineToeDefinitionForm_SectionId_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region LineToeDefinitionForm_PreScript
    base.PreScript();
             mainToeDescr.Text  = string.Empty;
              paragraphToeDescr.Text = string.Empty;

          if (_LineToeDefinition.SectionId != null && _LineToeDefinition.SectionId.OfficeId != null && _LineToeDefinition.SectionId.OfficeId.UnitId != null && _LineToeDefinition.SectionId.OfficeId.UnitId.UnitEnclosureID != null)
            {
                mainToeDescr.Text  = _LineToeDefinition.SectionId.OfficeId.UnitId.MAINTOECODE+ " - " +
                _LineToeDefinition.SectionId.OfficeId.UnitId.UnitEnclosureID.NAME + " - " +
                    _LineToeDefinition.SectionId.OfficeId.UnitId.NAME;
              paragraphToeDescr.Text =  _LineToeDefinition.SectionId.PARAGRAPHTOECODE+ " - " + _LineToeDefinition.SectionId.OfficeId.NAME + " - " + _LineToeDefinition.SectionId.NAME;

            }
#endregion LineToeDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region LineToeDefinitionForm_PostScript
    base.PostScript(transDef);
    IList lineTode = _LineToeDefinition.ObjectContext.QueryObjects("LINETOEDEFINITION","LINETOECODE = '"+_LineToeDefinition.LINETOECODE+"' AND  SECTIONID='" + _LineToeDefinition.SectionId.ObjectID.ToString()+"'");
           bool save = true;
            foreach(LineToeDefinition line in lineTode)
            {
                if(line.ObjectID != _LineToeDefinition.ObjectID)
                {
                    save = false;
                    break;
                }
            }
                
            if(save == false)
                throw new TTException("Aynı Satır Numarası mevcut olduğundan kayıt işlemi iptal edildi.");
#endregion LineToeDefinitionForm_PostScript

            }
                }
}