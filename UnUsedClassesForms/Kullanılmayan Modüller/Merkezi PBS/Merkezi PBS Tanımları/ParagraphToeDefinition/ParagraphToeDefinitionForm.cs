
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
    public partial class ParagraphToeDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            SectionId.SelectedObjectChanged += new TTControlEventDelegate(SectionId_SelectedObjectChanged);
            MainToeId.SelectedObjectChanged += new TTControlEventDelegate(MainToeId_SelectedObjectChanged);
            OfficeId.SelectedObjectChanged += new TTControlEventDelegate(OfficeId_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SectionId.SelectedObjectChanged -= new TTControlEventDelegate(SectionId_SelectedObjectChanged);
            MainToeId.SelectedObjectChanged -= new TTControlEventDelegate(MainToeId_SelectedObjectChanged);
            OfficeId.SelectedObjectChanged -= new TTControlEventDelegate(OfficeId_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void SectionId_SelectedObjectChanged()
        {
#region ParagraphToeDefinitionForm_SectionId_SelectedObjectChanged
   if(_ParagraphToeDefinition.SectionId != null)
                _ParagraphToeDefinition.OfficeId = _ParagraphToeDefinition.SectionId.OfficeId;
         
            /* if(_ParagraphToeDefinitio.OfficeId != null)
                _SectionDefinition.UnitId = _SectionDefinition.OfficeId.UnitId;
 */
#endregion ParagraphToeDefinitionForm_SectionId_SelectedObjectChanged
        }

        private void MainToeId_SelectedObjectChanged()
        {
#region ParagraphToeDefinitionForm_MainToeId_SelectedObjectChanged
   if(_ParagraphToeDefinition.MainToeId != null)
                     this.OfficeId.ListFilterExpression = " UNITID = '"+_ParagraphToeDefinition.MainToeId.UnitId.ObjectID+"'" ;
                  //   _ParagraphToeDefinition.SectionId.UnitId = _ParagraphToeDefinition.MainToeId.UnitId;
#endregion ParagraphToeDefinitionForm_MainToeId_SelectedObjectChanged
        }

        private void OfficeId_SelectedObjectChanged()
        {
#region ParagraphToeDefinitionForm_OfficeId_SelectedObjectChanged
   if(_ParagraphToeDefinition.OfficeId != null)
                     this.SectionId.ListFilterExpression = " OFFICEID = '"+_ParagraphToeDefinition.OfficeId.ObjectID+"'" ;
#endregion ParagraphToeDefinitionForm_OfficeId_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region ParagraphToeDefinitionForm_PreScript
    base.PreScript();
                 if(_ParagraphToeDefinition != null && _ParagraphToeDefinition.MainToeId != null)
                     this.OfficeId.ListFilterExpression = " UNITID = '"+_ParagraphToeDefinition.MainToeId.UnitId.ObjectID+"'" ;
#endregion ParagraphToeDefinitionForm_PreScript

            }
                }
}