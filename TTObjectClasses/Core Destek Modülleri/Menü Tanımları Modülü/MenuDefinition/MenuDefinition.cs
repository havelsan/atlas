
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public  partial class MenuDefinition : TerminologyManagerDef
    {
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            CheckObjectOrUnboundForm();
#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            CheckObjectOrUnboundForm();
#endregion PreUpdate
        }

#region Methods
        private static TTObjectDef _objectDef;

        public MenuDefinition GetMenuDefByObjDefName(string objectDefinitionName)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            foreach (MenuDefinition md in MenuDefinition.GetMenuDefinition(objectContext, objectDefinitionName ))
                return md;
            return null;
        }
        
        
        public override string ToString()
        {
            if (ParentMenu == null)
                return MenuGroup + "  " + TTUtils.CultureService.GetText("M25170", "Ana Menu")+ OrderNo + "  " + Caption;
            else
                return MenuGroup + "  " + ParentMenu.Caption + "  "+OrderNo + "  " + Caption;
        }
        
        private static SortedList<string, MenuDefinition> _patientMenu;
        public static SortedList<string, MenuDefinition> PatientMenu
        {
            get { return _patientMenu; }
        }

        private static SortedList<string, MenuDefinition> _generalMenu;
        public static SortedList<string, MenuDefinition> GeneralMenu
        {
            get { return _generalMenu; }
        }

        private static SortedList<string, MenuDefinition> _reportMenu;
        public static SortedList<string, MenuDefinition> ReportMenu
        {
            get { return _reportMenu; }
        }

        private static SortedList<string, MenuDefinition> _unboundFormMenu;
        public static SortedList<string, MenuDefinition> UnboundFormMenu
        {
            get { return _unboundFormMenu; }
        }
        
        private static SortedList<string, MenuDefinition> _definitionMenu;
        public static SortedList<string, MenuDefinition> DefinitionMenu
        {
            get { return _definitionMenu; }
        }

        private static SortedList<string, MenuDefinition> _stockMenu;
        public static SortedList<string, MenuDefinition> StockMenu
        {
            get { return _stockMenu; }
        }

        private static SortedList<string, MenuDefinition> _medulaMenu;
        public static SortedList<string, MenuDefinition> MedulaMenu
        {
            get { return _medulaMenu; }
        }

        private static SortedList<string, MenuDefinition> _errorReportMenu;
        public static SortedList<string, MenuDefinition> ErrorReportMenu
        {
            get { return _errorReportMenu; }
        }
        
        static MenuDefinition()
        {
            _objectDef = TTObjectDefManager.Instance.ObjectDefs[typeof(MenuDefinition).Name];

            TTObjectContext context = new TTObjectContext(true);
           
            TTObjectRelationDef objectRelationDef = _objectDef.AllChildRelationDefs[new Guid("0957a0cb-fc01-45a3-ba8c-4e5080705973")];
            context.AddRelationDefForLoadChildrenLocally(objectRelationDef);
            context.QueryObjects(typeof(MenuDefinition).Name);
                                 
            _patientMenu = new SortedList<string, MenuDefinition>();
            _generalMenu = new SortedList<string, MenuDefinition>();
            _reportMenu = new SortedList<string, MenuDefinition>();
            _unboundFormMenu = new SortedList<string, MenuDefinition>();
            _definitionMenu = new SortedList<string, MenuDefinition>();
            _stockMenu = new SortedList<string, MenuDefinition>();
            _medulaMenu = new SortedList<string, MenuDefinition>();
            _errorReportMenu = new SortedList<string, MenuDefinition>();
            foreach (MenuDefinition md in context.LocalQuery(typeof(MenuDefinition).Name, "PARENTMENU IS NULL"))
            {
                if (md.ParentMenu == null)
                {
                    string key = md.OrderNo.Value.ToString("0000") + md.Caption;

                    if (md.MenuGroup == MenuTypeEnum.PatientMenu && _patientMenu.ContainsKey(key)==false)
                        _patientMenu.Add(key, md);
                    else if (md.MenuGroup == MenuTypeEnum.GeneralMenu  && _generalMenu.ContainsKey(key)==false)
                        _generalMenu.Add(key, md);
                    else if (md.MenuGroup == MenuTypeEnum.ReportMenu && _reportMenu.ContainsKey(key)==false)
                        _reportMenu.Add(key, md);
                    else if (md.MenuGroup == MenuTypeEnum.UnboundFormMenu && _unboundFormMenu.ContainsKey(key)==false)
                        _unboundFormMenu.Add(key, md);
                    else if (md.MenuGroup == MenuTypeEnum.DefinitionMenu && _definitionMenu.ContainsKey(key)==false)
                        _definitionMenu.Add(key, md);
                    else if (md.MenuGroup == MenuTypeEnum.StockMenu && _stockMenu.ContainsKey(key)==false)
                        _stockMenu.Add(key, md);
                    else if (md.MenuGroup == MenuTypeEnum.MedulaMenu && _medulaMenu.ContainsKey(key) == false)
                        _medulaMenu.Add(key, md);
                    else if (md.MenuGroup == MenuTypeEnum.ErrorReportMenu && _errorReportMenu.ContainsKey(key) == false)
                        _errorReportMenu.Add(key, md);
                }
            }
            
        }
        
        public void CheckObjectOrUnboundForm()
        {
            if(ObjectDefinitionName!=null && UnboundFormName!=null)
                throw new Exception(SystemMessage.GetMessage(590));
        }
        
        public static bool IsHealthCommitteeOfProfessorsActive()
        {
            TTObjectContext context = new TTObjectContext(true);
            IList mdl=MenuDefinition.GetMenuDefinition(context,typeof(HealthCommitteeOfProfessors).Name.ToUpperInvariant());
            if(mdl!=null && mdl.Count>0)
            {
                return true;
            }
            return false;
        }
        
#endregion Methods

    }
}