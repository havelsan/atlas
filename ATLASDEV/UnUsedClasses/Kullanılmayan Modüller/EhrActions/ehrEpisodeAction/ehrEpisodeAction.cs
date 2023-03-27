
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
    public partial class ehrEpisodeAction : BaseEhr, IOldActions, Itest
    {
        #region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            // if(((ITTObject)this).IsNew==true)
            if (CurrentStateDefID == null)
            {
                CurrentStateDefID = ehrEpisodeAction.States.Active;
            }
        }

        public virtual List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            bool checkShowProperties = Common.IsAttributeExists(typeof(NotShowEhrPropertiesOnOldActions), this);
            string notShowEhrPropertiesOnOldActionsString = "";
            if (checkShowProperties)
                notShowEhrPropertiesOnOldActionsString = ObjectDef.AllAttributes[typeof(NotShowEhrPropertiesOnOldActions).Name.ToUpperInvariant()].Parameters["Properties"].Value.ToString().ToUpperInvariant();
            foreach (TTObjectPropertyDef propDef in ObjectDef.AllPropertyDefs)
            {
                if (!(notShowEhrPropertiesOnOldActionsString.Contains("," + propDef.CodeName.ToUpperInvariant() + ",")))
                {
                    System.Reflection.PropertyInfo propInfo = GetType().GetProperty(propDef.CodeName.ToString());
                    if (propInfo != null)
                    {
                        string caption = propDef.Caption == null ? propDef.Description : propDef.Caption;
                        if (String.IsNullOrEmpty(caption))
                            caption = propDef.CodeName;
                        propertyList.Add(new EpisodeAction.OldActionPropertyObject(caption, Common.ReturnObjectAsString(propInfo.GetValue(this, null))));
                    }
                }
            }

            foreach (TTObjectRelationDef relDef in ObjectDef.AllParentRelationDefs)
            {
                if (!(notShowEhrPropertiesOnOldActionsString.Contains("," + relDef.CodeName.ToUpperInvariant() + ",")))
                {
                    System.Reflection.PropertyInfo propInfo = GetType().GetProperty(relDef.CodeName.ToString());
                    if (propInfo != null)
                    {
                        object propValue = propInfo.GetValue(this, null);
                        bool add = true;
                        if (propValue == null || (propValue is ehrEpisode))
                            add = false;
                        if (add)
                        {
                            string caption = relDef.ParentCaption == null ? relDef.ParentName : relDef.ParentCaption;
                            propertyList.Add(new EpisodeAction.OldActionPropertyObject(caption, Common.ReturnObjectAsString(propValue)));
                        }
                    }
                }
            }


            return propertyList;
        }

        public virtual List<List<List<EpisodeAction.OldActionPropertyObject>>> OldActionChildRelationList()
        {
            List<List<List<EpisodeAction.OldActionPropertyObject>>> gridList = new List<List<List<EpisodeAction.OldActionPropertyObject>>>();
            bool checkShowChildCol = Common.IsAttributeExists(typeof(NotShowEhrChildColOnOldActions), this);
            string notShowEhrChildColOnOldActionsString = "";
            if (checkShowChildCol)
                notShowEhrChildColOnOldActionsString = ObjectDef.AllAttributes[typeof(NotShowEhrChildColOnOldActions).Name.ToUpperInvariant()].Parameters["ChildCol"].Value.ToString().ToUpperInvariant();
            foreach (TTObjectRelationDef relDef in ObjectDef.AllChildRelationDefs)
            {
                bool? addCaption = null;
                if (!string.IsNullOrEmpty(relDef.ChildrenName))
                {
                    List<System.Reflection.PropertyInfo> propInfoList = new List<System.Reflection.PropertyInfo>();
                    bool addBaseChild = true;
                    if (relDef.RelationDefID.ToString().ToUpper() != ("e0982699-06df-40ee-9060-1dc023e2ba1a").ToUpper())// ehrParentEpisodeAction _ ehrSubactProcedureFlowables relationı OldActionReportHtml'da zaten ekleniyor
                    {
                        foreach (TTObjectRelationSubtypeDef stDef in relDef.SubtypeDefs)
                        {
                            if (stDef.ParentObjectDefID == ObjectDef.ID)
                            {
                                if (!(notShowEhrChildColOnOldActionsString.Contains("," + stDef.ChildrenName.ToUpperInvariant() + ",")))
                                {
                                    addBaseChild = false;
                                    propInfoList.Add(GetType().GetProperty(stDef.ChildrenName.ToString()));
                                }
                            }
                        }
                        if (addBaseChild)
                        {
                            if (!(notShowEhrChildColOnOldActionsString.Contains("," + relDef.ChildrenName.ToUpperInvariant() + ",")))
                            {
                                propInfoList.Add(GetType().GetProperty(relDef.ChildrenName.ToString()));
                            }
                        }
                    }
                    foreach (System.Reflection.PropertyInfo propInfo in propInfoList)
                    {
                        addCaption = null;
                        if (propInfo != null)
                        {
                            object childCollection = propInfo.GetValue(this, null);
                            ITTChildObjectCollection cc = childCollection as ITTChildObjectCollection;
                            List<List<EpisodeAction.OldActionPropertyObject>> gridFolderContentsRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();
                            foreach (TTObject childobject in cc)
                            {
                                bool add = true;
                                if (childobject == null || childobject is IEpisodeAction)
                                    add = false;
                                if (add)
                                {
                                    bool checkShowProperties = Common.IsAttributeExists(typeof(NotShowEhrPropertiesOnOldActions), childobject);
                                    string notShowEhrPropertiesOnOldActionsString = "";
                                    if (checkShowProperties)
                                        notShowEhrPropertiesOnOldActionsString = childobject.ObjectDef.AllAttributes[typeof(NotShowEhrPropertiesOnOldActions).Name.ToUpperInvariant()].Parameters["Properties"].Value.ToString().ToUpperInvariant();

                                    List<EpisodeAction.OldActionPropertyObject> gridFolderContentsRowColumnList = new List<EpisodeAction.OldActionPropertyObject>();
                                    foreach (TTObjectPropertyDef colPropDef in childobject.ObjectDef.AllPropertyDefs)
                                    {
                                        if (!(notShowEhrPropertiesOnOldActionsString.Contains("," + colPropDef.CodeName.ToUpperInvariant() + ",")))
                                        {
                                            System.Reflection.PropertyInfo colPropInfo = childobject.GetType().GetProperty(colPropDef.CodeName.ToString());
                                            if (propInfo != null)
                                            {
                                                string caption = colPropDef.Caption == null ? colPropDef.Description : colPropDef.Caption;
                                                if (String.IsNullOrEmpty(caption))
                                                    caption = colPropDef.CodeName;
                                                gridFolderContentsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(caption, Common.ReturnObjectAsString(colPropInfo.GetValue(childobject, null))));
                                                if (addCaption == null)
                                                    addCaption = true;
                                            }
                                        }
                                    }

                                    foreach (TTObjectRelationDef colRelDef in childobject.ObjectDef.AllParentRelationDefs)
                                    {
                                        if (!(notShowEhrPropertiesOnOldActionsString.Contains("," + colRelDef.CodeName.ToUpperInvariant() + ",")))
                                        {
                                            System.Reflection.PropertyInfo colRelInfo = childobject.GetType().GetProperty(colRelDef.CodeName.ToString());
                                            if (colRelInfo != null)
                                            {
                                                object colRelValue = colRelInfo.GetValue(childobject, null);

                                                if (colRelValue != null && !(colRelValue is ehrEpisode || colRelValue is ehrEpisodeAction))
                                                {
                                                    string caption = colRelDef.ParentCaption == null ? colRelDef.ParentName : colRelDef.ParentCaption;
                                                    gridFolderContentsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(caption, Common.ReturnObjectAsString(colRelValue)));
                                                    if (addCaption == null)
                                                        addCaption = true;
                                                }
                                            }
                                        }
                                    }
                                    gridFolderContentsRowList.Add(gridFolderContentsRowColumnList);
                                }
                                //Grid Başlığı için
                                if (addCaption == true)
                                {
                                    string baslık = relDef.ChildrenCaption;
                                    if (String.IsNullOrEmpty(baslık) || addBaseChild == false)
                                        baslık = childobject.ObjectDef.DisplayText.ToString();
                                    List<List<EpisodeAction.OldActionPropertyObject>> captionRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();
                                    List<EpisodeAction.OldActionPropertyObject> captionRowColumnList = new List<EpisodeAction.OldActionPropertyObject>();
                                    captionRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(baslık, null));
                                    captionRowList.Add(captionRowColumnList);
                                    gridList.Add(captionRowList);
                                    addCaption = false;
                                }
                            }

                            gridList.Add(gridFolderContentsRowList);
                        }
                    }
                }
            }
            return gridList;
        }

        public virtual string OldActionSubactionProcedureFlowablesHtml()
        {
            // ehrSubactProcedureFlowables dolsurulur
            string report = "";
            Dictionary<string, List<ehrEpisodeAction>> ehrChildEpisodeActionDictionary = new Dictionary<string, List<ehrEpisodeAction>>();
            foreach (ehrEpisodeAction childEpisodeAction in ehrSubactProcedureFlowables)
            {
                List<ehrEpisodeAction> dictionaryItem;
                if (ehrChildEpisodeActionDictionary.TryGetValue(childEpisodeAction.ObjectDef.Name, out dictionaryItem) == true)
                {
                    dictionaryItem.Add(childEpisodeAction);
                }
                else
                {
                    List<ehrEpisodeAction> childList = new List<ehrEpisodeAction>();
                    childList.Add(childEpisodeAction);
                    ehrChildEpisodeActionDictionary.Add(childEpisodeAction.ObjectDef.Name, childList);
                }
            }
            foreach (KeyValuePair<string, List<ehrEpisodeAction>> dictionaryItem in ehrChildEpisodeActionDictionary)
            {
                bool addCaption = true;
                foreach (ehrEpisodeAction childEpisodeAction in dictionaryItem.Value)
                {
                    if (addCaption)
                    {
                        report = report + "<br>";
                        report = report + "<table border=1 width='100%'>";
                        report = report + "<tr>" + childEpisodeAction.ObjectDef.DisplayText;
                        report = report + "</table>";
                        addCaption = false;
                    }
                    report = report + childEpisodeAction.OldActionReportHtml();
                    report = report + "<br>";
                }
            }
            return report;
        }
        public virtual string OldActionReportHtml()
        {
            string report = "<html>";
            if (OldActionPropertyList() != null)
            {
                if (OldActionPropertyList().Count > 0)
                {
                    report = report + "<table border=1 width='100%'>";
                    foreach (EpisodeAction.OldActionPropertyObject property in OldActionPropertyList())
                    {
                        report = report + "<tr>" + Common.FormatAsOldActionTitle(property.PropertyCaption, null) + Common.FormatAsOldActionValue(property.PropertyValue, null);
                    }
                    report = report + "</table>";
                }
            }
            if (OldActionChildRelationList() != null)
            {
                foreach (List<List<EpisodeAction.OldActionPropertyObject>> grid in OldActionChildRelationList())// her bir grid için dönüyor
                {
                    if (grid != null)
                    {
                        if (grid.Count > 0)
                        {
                            report = report + "<table border width='100%'>";
                            report = report + "<tr>";
                            foreach (EpisodeAction.OldActionPropertyObject property in grid[0])// griddeki her bir bir obje propertysi için başlık satırı tek olacağı için gelen ilk objeninki alındı
                            {
                                report = report + Common.FormatAsOldActionTitleV2(property.PropertyCaption, null, true);
                            }
                            report = report + "</tr>";
                            foreach (List<EpisodeAction.OldActionPropertyObject> childRelationRow in grid)
                            {
                                if (childRelationRow.Count > 0)
                                {
                                    report = report + "<tr>";
                                    foreach (EpisodeAction.OldActionPropertyObject property in childRelationRow)// her bir obje propertysi değerleri yazılır
                                    {
                                        report = report + Common.FormatAsOldActionValue(property.PropertyValue, null);
                                    }
                                    report = report + "</tr>";
                                }
                            }
                            report = report + "</table>";
                        }
                    }
                }
            }
            report = report + "</html>";
            report = report + OldActionSubactionProcedureFlowablesHtml();
            return report;

        }
        protected virtual List<List<EpisodeAction.OldActionPropertyObject>> OldActionEhrDiagnosisList()
        {
            // Ehr Tanı Gridi
            List<List<EpisodeAction.OldActionPropertyObject>> gridEhrDiagnosisRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();
            foreach (ehrDiagnosis diagnose in ehrDiagnosis)
            {
                // Öntanının her bir satırı için kolonları taşıyan Liste
                List<EpisodeAction.OldActionPropertyObject> gridEhrDiagnosisRowColumnList = new List<EpisodeAction.OldActionPropertyObject>();
                gridEhrDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject("Giriş Tarihi", Common.ReturnObjectAsString(diagnose.DiagnoseDate)));
                gridEhrDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject("Tanı", Common.ReturnObjectAsString(diagnose.Diagnose.Name)));
                gridEhrDiagnosisRowColumnList.Add(new EpisodeAction.OldActionPropertyObject("Ana Tanı", Common.ReturnObjectAsString(diagnose.IsMainDiagnose)));
                gridEhrDiagnosisRowList.Add(gridEhrDiagnosisRowColumnList);
            }
            return gridEhrDiagnosisRowList;
        }

        public override List<TTObject> getFullPackage()
        {
            List<TTObject> package = base.getFullPackage();
            if (ehrEpisode != null && (!package.Contains(ehrEpisode)))//ImpotantmedicalInfonun ehrEpisodeu null olabilir
                package.Add(ehrEpisode);//ehrEpisode Ekliyor
            return package;
        }

        public override string ToString()
        {
            return (ActionDate != null ? ((DateTime)ActionDate).Date.ToString() : "") + "-" + (ObjectDef.DisplayText == null ? ObjectDef.Description : ObjectDef.DisplayText);
        }

        #endregion Methods

    }
}