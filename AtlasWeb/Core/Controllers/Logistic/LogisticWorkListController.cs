using Core.Models;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using TTUtils;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class LogisticWorkListController : Controller
    {

        public class NewStockMenuDTO
        {
            public Guid id { get; set; }

            public string text { get; set; }

            public string isVisibleKey { get; set; }

            public bool expanded { get; set; }

            public bool clickable { get; set; }

            public bool pinned { get; set; }

            public string roleID { get; set; }

            public List<NewStockMenuDTO> items { get; set; }

            public NewStockMenuDTO()
            {
                items = new List<NewStockMenuDTO>();
            }
        }

        public class QueryInputDVO
        {
            public DateTime? StartDate
            {
                get;
                set;
            }

            public Guid StoreID
            {
                get;
                set;
            }

            public DateTime? EndDate
            {
                get;
                set;
            }

            public string MKYSState
            {
                get;
                set;
            }

            public string StateType
            {
                get;
                set;
            }

            public string StockActionId
            {
                get;
                set;
            }

            public string TIFId
            {
                get;
                set;
            }

            public int? WorkListCount
            {
                get;
                set;
            }

            public List<WorkListItem> SelectedWorkListItems
            {
                get;
                set;
            }

            public bool PartialCancel
            {
                get;
                set;
            }
            public bool EHUWait
            {
                get;
                set;
            }
            public bool IsEmergencyMaterial
            {
                get;
                set;
            }
        }

        public class MenuOutputDVO
        {
            public List<MenuDefinition> StockActionMenuItems
            {
                get;
                set;
            }

            public List<WorkListItem> WorkListSearchItem
            {
                get;
                set;
            }

            public List<TTListDef> StockDefinitionMenuItems
            {
                get;
                set;
            }
        }

        public class DynamicComponentInfoDVO
        {
            public string ComponentName
            {
                get;
                set;
            }

            public string ModuleName
            {
                get;
                set;
            }

            public string ModulePath
            {
                get;
                set;
            }

            public string objectID
            {
                get;
                set;
            }
        }

        public static readonly List<Guid> EpisodeActionListForPharmacyStore = new List<Guid>()
        {
            new Guid("e8038335-a8b1-4149-bfac-7c12007eca1a"), //DrugReturnAction
            new Guid("eb8545ad-b542-4489-8e4c-b903b5f0fe28"), //DirectMaterialSupplyAction
            new Guid("39dc2f2a-2723-4522-9e3f-92c010b1e72b"), //OutPatientPrescription
            new Guid("fda28150-7a87-49c7-9acb-b68fe9bd5d20"), //InpatientPrescription
            new Guid("0fe703f4-0496-4e27-abfb-80992bfc6628"), //PatientOwnDrugEntry
            new Guid("d4338e34-3e24-42a0-892a-4ce9ec2eb144"), //HalfDoseDestruction
        };

        public static readonly List<Guid> EpisodeActionListByMainStore = new List<Guid>()
        {
          new Guid("eb8545ad-b542-4489-8e4c-b903b5f0fe28") //DirectMaterialSupplyAction
        };

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Stok_Is_Listesi)]
        public LogisticWorkListViewModel Query(QueryInputDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                LogisticWorkListViewModel model = new LogisticWorkListViewModel();
                if (inputdvo.StartDate.HasValue == false)
                    inputdvo.StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                if (inputdvo.EndDate.HasValue == false)
                    inputdvo.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");

                Store selected = (Store)objectContext.GetObject(inputdvo.StoreID, "STORE");
                List<StockActionWorkListItemModel> stockactionlist = new List<StockActionWorkListItemModel>();
                List<StockAction> lookupList = new List<StockAction>();
                string filiterExpresion = string.Empty;
                if (string.IsNullOrEmpty(inputdvo.StateType) == false)
                    filiterExpresion = " AND CURRENTSTATE IS " + inputdvo.StateType;
                if (inputdvo.SelectedWorkListItems != null && inputdvo.SelectedWorkListItems.Count > 0)
                {
                    filiterExpresion = filiterExpresion + " AND OBJECTDEFID IN (";
                    foreach (WorkListItem wli in inputdvo.SelectedWorkListItems)
                    {
                        filiterExpresion = filiterExpresion + "'" + wli.ObjectDefId + "',";
                    }

                    filiterExpresion = filiterExpresion.Remove(filiterExpresion.Length - 1);
                    filiterExpresion = filiterExpresion + ")";
                }

                if (string.IsNullOrEmpty(inputdvo.StockActionId) == false)
                {
                    lookupList = StockAction.StockActionWorkListNQLNoDate(objectContext, "AND STOCKACTIONID in (" + inputdvo.StockActionId.ToString() + ")").ToList();
                }
                else if (string.IsNullOrEmpty(inputdvo.TIFId) == false)
                {
                    IBindingList documentRecordLogs = objectContext.QueryObjects("DOCUMENTRECORDLOG", "DOCUMENTRECORDLOGNUMBER ='" + inputdvo.TIFId.ToString() + "' AND STOCKACTION.STORE = " + TTConnectionManager.ConnectionManager.GuidToString(inputdvo.StoreID));
                    foreach (DocumentRecordLog d in documentRecordLogs)
                    {
                        int documentyear = ((DateTime)d.DocumentDateTime).Year;
                        int currentYear = Common.RecTime().Year;
                        if(documentyear == currentYear)
                        {
                            lookupList.Add(d.StockAction);
                        }
                    }
                }
                else
                    lookupList = StockAction.StockActionWorkListNQL(objectContext, (DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, inputdvo.StoreID, filiterExpresion).ToList();

                if (inputdvo.PartialCancel)
                {
                    List<StockAction> partialCancelList = new List<StockAction>();
                    foreach (StockAction sa in lookupList)
                    {
                        if (sa.StockActionDetails.Select("STATUS=1").Count > 0)
                            partialCancelList.Add(sa);
                    }
                    lookupList = partialCancelList;
                }
                if (inputdvo.EHUWait)
                {
                    List<StockAction> ehuWaitList = new List<StockAction>();
                    foreach (StockAction sa in lookupList)
                    {
                        if (sa is KSchedule)
                        {
                            KSchedule kSchedule = (KSchedule)sa;
                            if (kSchedule.KScheduleInfectionDrugs.Select("ISAPPROVED <> 1").Count > 0)
                                ehuWaitList.Add(sa);
                        }
                    }
                    lookupList = ehuWaitList;
                }

                foreach (StockAction a in lookupList)
                {

                    if (a is StockAction)
                    {
                        if (a.CurrentStateDef != null)
                        {
                            if (TTUser.CurrentUser.HasRight(a.CurrentStateDef.FormDef, a, 1003))
                            {
                                StockAction sa = (StockAction)a;
                                StockActionWorkListItemModel sai = new StockActionWorkListItemModel();
                                sai.ObjectID = sa.ObjectID.ToString();
                                sai.StockActionID = (int)sa.StockActionID.Value;
                                if (sa.Store != null)
                                    sai.Store = sa.Store.Name;
                                if (sa.DestinationStore != null)
                                    sai.DestinationStore = sa.DestinationStore.Name;
                                bool color = true;
                                if (a is KSchedule)
                                {
                                    if (((KSchedule)a).Episode != null)//Episode null gelince iş listesi patlıyordu.
                                    {
                                        sai.PatientName = ((KSchedule)a).Episode.Patient.Name + " " + ((KSchedule)a).Episode.Patient.Surname;
                                    }
                                    else
                                    {
                                        sai.PatientName = string.Empty;
                                    }

                                    foreach (KScheduleMaterial mat in ((KSchedule)a).KScheduleMaterials)
                                    {
                                        if (mat.KScheduleCollectedOrder != null)
                                        {
                                            List<DrugOrderDetail> drugOrderDet = mat.KScheduleCollectedOrder.DrugOrderDetails.Where(d => d.DrugOrder.IsImmediate == true).ToList();
                                            if (drugOrderDet.Count > 0)
                                            {
                                                sai.colorEnum = WorkListResultColorEnum.red;
                                                color = false;
                                                break;
                                            }
                                            if (color)
                                            {
                                                sai.colorEnum = WorkListResultColorEnum.white;
                                            }
                                        }
                                    }
                                }
                                if (a is StockOut)
                                {
                                    StockOut stockOut = (StockOut)a;
                                    foreach (StockActionDetail stockActionDetail in stockOut.StockActionDetails.Select(string.Empty))
                                    {
                                        if (stockActionDetail.SubActionMaterial != null && stockActionDetail.SubActionMaterial.Count > 0)
                                        {
                                            BaseTreatmentMaterial material = (BaseTreatmentMaterial)stockActionDetail.SubActionMaterial[0];
                                            sai.PatientName = material.Episode.Patient.Name + " " + material.Episode.Patient.Surname;
                                        }
                                    }
                                }
                                sai.StockactionName = sa.ObjectDef.DisplayText;
                                sai.TransactionDate = ((DateTime)sa.WorkListDate.Value).ToString("dd.MM.yyyy HH:mm:ss");
                                sai.StateName = sa.CurrentStateDef.DisplayText;
                                sai.StateFormName = sa.CurrentStateDef.FormDef.CodeName;

                                if (sa.IsEmergencyMaterial != null)
                                    sai.IsEmergencyMaterial = sa.IsEmergencyMaterial.Value;
                                else
                                    sai.IsEmergencyMaterial = false;

                                if (sa.IsEmergencyMaterial == true)
                                {
                                    sai.colorEnum = WorkListResultColorEnum.red;
                                    color = false;
                                }

                                foreach (DocumentRecordLog log in a.DocumentRecordLogs)
                                {
                                    if ((log.MKYSStatus == null && log.ReceiptNumber == null) || (log.MKYSStatus == MKYSControlEnum.Completed && log.ReceiptNumber == null) || (log.MKYSStatus == MKYSControlEnum.Cancelled && log.ReceiptNumber != null))
                                    {
                                        sai.colorEnum = WorkListResultColorEnum.red;
                                        color = false;
                                        break;
                                    }
                                    else
                                    {
                                        color = true;
                                    }
                                }
                                if (color)
                                {
                                    sai.colorEnum = WorkListResultColorEnum.white;
                                }

                                if (inputdvo.MKYSState == null || inputdvo.MKYSState == "" || inputdvo.MKYSState == "ALL")
                                {
                                    stockactionlist.Add(sai);
                                }
                                else if (inputdvo.MKYSState == "SUCCESSFUL")
                                {
                                    if (sai.colorEnum == WorkListResultColorEnum.white)
                                        stockactionlist.Add(sai);
                                }
                                else if (inputdvo.MKYSState == "UNSUCCESSFUL")
                                {
                                    if (sai.colorEnum == WorkListResultColorEnum.red)
                                        stockactionlist.Add(sai);
                                }
                            }
                        }
                    }
                }


                BindingList<EpisodeAction.GetStockEpisodeActionWorkListNQL_Class> ealist = null;
                BindingList<EpisodeAction.GetStockEpisodeActionWorkListNQLByID_Class> ealistFilter = null;


                if (string.IsNullOrEmpty(inputdvo.StockActionId) == false)
                {
                    ealistFilter = EpisodeAction.GetStockEpisodeActionWorkListNQLByID(EpisodeActionListForPharmacyStore, "AND ID in (" + inputdvo.StockActionId.ToString() + ")");
                }
                else
                {
                    if (selected is PharmacyStoreDefinition || selected is PharmacySubStoreDefinition)
                    {
                        ealist = EpisodeAction.GetStockEpisodeActionWorkListNQL((DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, EpisodeActionListForPharmacyStore, filiterExpresion);
                    }
                    else
                    {
                        ealist = EpisodeAction.GetStockEpisodeActionWorkListNQL((DateTime)inputdvo.StartDate, (DateTime)inputdvo.EndDate, EpisodeActionListByMainStore, filiterExpresion);
                    }
                }


                if (string.IsNullOrEmpty(inputdvo.TIFId))
                {
                    List<String> episodeActionIdList = new List<string>();
                    if (!String.IsNullOrEmpty(inputdvo.StockActionId))
                    {
                        if (inputdvo.StockActionId.Contains(","))
                        {
                            episodeActionIdList = inputdvo.StockActionId.Split(',').ToList();
                        }
                        else
                            episodeActionIdList.Add(inputdvo.StockActionId);
                    }
                    if (ealist != null)
                    {
                        foreach (EpisodeAction.GetStockEpisodeActionWorkListNQL_Class action in ealist)
                        {

                            EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject((Guid)action.ObjectID, typeof(EpisodeAction));
                            if (episodeAction is OutPatientPrescription == false)//TFS 49117 nolu iş sebebiyle eklendi.
                            {
                                StockActionWorkListItemModel sai = new StockActionWorkListItemModel();
                                if (TTStorageManager.Security.TTUser.CurrentUser.HasRight(episodeAction.CurrentStateDef.FormDef, null, (int)TTStorageManager.Security.TTSecurityAuthority.RightsEnum.UpdateForm))
                                {
                                    sai.ObjectID = action.ObjectID.ToString();
                                    sai.StockActionID = (int)action.ID;
                                    if (episodeAction is PatientOwnDrugEntry)
                                    {
                                        if (action.Masterresource != null)
                                            sai.DestinationStore = action.Masterresource;
                                    }
                                    if (action.Masterresource != null)
                                        sai.DestinationStore = action.Masterresource;
                                    if (action.Name != null && action.Surname != null)
                                        sai.PatientName = action.Name + " " + action.Surname;
                                    sai.colorEnum = WorkListResultColorEnum.white;
                                    sai.StockactionName = episodeAction.ObjectDef.DisplayText;
                                    sai.TransactionDate = ((DateTime)episodeAction.WorkListDate.Value).ToString("dd.MM.yyyy HH:mm:ss");
                                    sai.StateName = episodeAction.CurrentStateDef.DisplayText;
                                    sai.StateFormName = episodeAction.CurrentStateDef.FormDef.CodeName;

                                    if (!String.IsNullOrEmpty(inputdvo.StockActionId))
                                    {
                                        if (episodeActionIdList.Count > 0)
                                        {
                                            foreach (String str in episodeActionIdList)
                                            {
                                                if (str == action.ID.ToString())
                                                    stockactionlist.Add(sai);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        stockactionlist.Add(sai);
                                    }
                                }
                            }
                        }
                    }
                    if (ealistFilter != null)
                    {
                        foreach (EpisodeAction.GetStockEpisodeActionWorkListNQLByID_Class action in ealistFilter)
                        {
                            EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject((Guid)action.ObjectID, typeof(EpisodeAction));
                            if (episodeAction is OutPatientPrescription == false)//TFS 49117 nolu iş sebebiyle eklendi.
                            {
                                StockActionWorkListItemModel sai = new StockActionWorkListItemModel();
                                if (TTStorageManager.Security.TTUser.CurrentUser.HasRight(episodeAction.CurrentStateDef.FormDef, null, (int)TTStorageManager.Security.TTSecurityAuthority.RightsEnum.UpdateForm))
                                {
                                    sai.ObjectID = action.ObjectID.ToString();
                                    sai.StockActionID = (int)action.ID;
                                    if (episodeAction is PatientOwnDrugEntry)
                                    {
                                        if (action.Masterresource != null)
                                            sai.DestinationStore = action.Masterresource;
                                    }
                                    if (action.Masterresource != null)
                                        sai.Store = action.Masterresource;
                                    if (action.Name != null && action.Surname != null)
                                        sai.PatientName = action.Name + " " + action.Surname;
                                    sai.colorEnum = WorkListResultColorEnum.white;
                                    sai.StockactionName = episodeAction.ObjectDef.DisplayText;
                                    sai.TransactionDate = ((DateTime)episodeAction.WorkListDate.Value).ToString("dd.MM.yyyy HH:mm:ss");
                                    sai.StateName = episodeAction.CurrentStateDef.DisplayText;
                                    sai.StateFormName = episodeAction.CurrentStateDef.FormDef.CodeName;

                                    if (!String.IsNullOrEmpty(inputdvo.StockActionId))
                                    {
                                        if (episodeActionIdList.Count > 0)
                                        {
                                            foreach (String str in episodeActionIdList)
                                            {
                                                if (str == action.ID.ToString())
                                                    stockactionlist.Add(sai);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        stockactionlist.Add(sai);
                                    }
                                }
                            }
                        }
                    }
                }

                if (inputdvo.IsEmergencyMaterial == true)
                {
                    stockactionlist = stockactionlist.Where(x => x.IsEmergencyMaterial == true).ToList();
                }

                model.stockactionlist = stockactionlist;
                model.StartDate = (DateTime)inputdvo.StartDate;
                model.EndDate = (DateTime)inputdvo.EndDate;
                if (string.IsNullOrEmpty(inputdvo.StockActionId) == false)
                    model.StockActionId = inputdvo.StockActionId;
                if (string.IsNullOrEmpty(inputdvo.TIFId) == false)
                    model.TIFId = inputdvo.TIFId;
                if (inputdvo.WorkListCount > 0)
                    model.WorkListCount = (int)inputdvo.WorkListCount;
                //TODO: Kullanıcı özelliklerinden gelmeli.
                model.StateType = inputdvo.StateType;
                //model.workListItems = FilterStatesWithObjectDef();
                model.PartialCancel = inputdvo.PartialCancel;
                model.EHUWait = inputdvo.EHUWait;
                model.IsEmergencyMaterial = inputdvo.IsEmergencyMaterial;
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public MenuOutputDVO GetStockMenuDefinition()
        {
            MenuOutputDVO menu = new MenuOutputDVO();
            List<MenuDefinition> menuList = new List<MenuDefinition>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                IList<int> menuGroup = new List<int>();
                menuGroup.Add((int)MenuTypeEnum.StockMenu);
                IBindingList menuDefinitionList = MenuDefinition.GetMainMenu(objectContext, menuGroup);
                foreach (MenuDefinition md in menuDefinitionList)
                {
                    foreach (MenuDefinition childMenu in md.ChildMenus)
                    {
                        if (String.IsNullOrEmpty(childMenu.Caption) == false && HasRightMenuDefinition(childMenu) && childMenu.IsDisabled == false)
                        {
                            if (String.IsNullOrEmpty(childMenu.IconPath))
                                childMenu.IconPath = "../../Content/Logistic/worklistIcon.png";

                            menuList.Add(childMenu);
                        }
                    }
                }

                menu.StockActionMenuItems = menuList;
                menu.WorkListSearchItem = FilterStatesWithObjectDef();
                //menu.StockDefinitionMenuItems = GetStockDefinitionAction();
                objectContext.FullPartialllyLoadedObjects();
                return menu;
            }
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<NewStockMenuDTO> GetNewStockMenuDefinition()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                IList<int> menuGroup = new List<int>
                {
                    (int)MenuTypeEnum.NewStockMenu
                };
                List<MenuDefinition> menuDefinitionList = MenuDefinition.GetMainMenu(objectContext, menuGroup).ToList();
                var stockMenu = menuDefinitionList.Where(p => p.ParentMenu == null).Select(item => new NewStockMenuDTO()
                {
                    id = item.ObjectID,
                    pinned = false,
                    text = item.Caption,
                    clickable = !item.ChildMenus.Any(),
                    expanded = false,
                    isVisibleKey = item.ObjectDefinitionName,
                    items = item.ChildMenus?.Select(child => new NewStockMenuDTO()
                    {
                        id = child.ObjectID,
                        pinned = false,
                        text = child.Caption,
                        clickable = !child.ChildMenus.Any(),
                        expanded = false,
                        isVisibleKey = child.ObjectDefinitionName,
                        items = child.ChildMenus?.Select(twochild => new NewStockMenuDTO()
                        {
                            id = twochild.ObjectID,
                            pinned = false,
                            text = twochild.Caption,
                            clickable = true,
                            expanded = false,
                            isVisibleKey = twochild.ObjectDefinitionName,
                        }).ToList()
                    }).ToList()
                }).ToList();
                return stockMenu;
            }
        }


        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<NewStockMenuDTO> GetStockReportMenuDefinition()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                IList<int> menuGroup = new List<int>
                {
                    (int)MenuTypeEnum.NewStockMenu
                };
                List<MenuDefinition> menuDefinitionList = MenuDefinition.GetMainMenu(objectContext, menuGroup).ToList();
                MenuDefinition report = menuDefinitionList.FirstOrDefault(x => x.ObjectID == new Guid("97747284-6363-49a7-9063-5678be203920"));
                List<NewStockMenuDTO> menuList = new List<NewStockMenuDTO>();
                menuList.Add(reportMenuPrepare(report));

                return menuList;
            }
        }


        public NewStockMenuDTO reportMenuPrepare(MenuDefinition menuDefinition)
        {
            NewStockMenuDTO menu = new NewStockMenuDTO();
            menu.id = menuDefinition.ObjectID;
            menu.pinned = false;
            menu.text = menuDefinition.Caption;
            menu.clickable = !menuDefinition.ChildMenus.Any();
            menu.expanded = true;
            menu.roleID = menuDefinition.EntryState;
            menu.isVisibleKey = menuDefinition.ObjectDefinitionName;
            foreach(MenuDefinition child in menuDefinition.ChildMenus)
            {
                menu.items.Add(reportMenuPrepare(child));
            }
            return menu;
        }




        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DynamicComponentInfoDVO GetDynamicComponentInfo([FromQuery] string ObjectId)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                var objectDefList = TTObjectDefManager.Instance.ObjectDefs;
                var objectDef = objectDefList.Values.Where(d => d.Name.ToUpperInvariant() == "EPISODEACTION").FirstOrDefault();
                TTObject obj = objectContext.GetObject(new Guid(ObjectId), objectDef, false);
                if (obj == null)
                    obj = objectContext.GetObject(new Guid(ObjectId), typeof(StockAction));
                var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
                var folderPath = string.Join("/", subFolders.Reverse());
                var moduleName = obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
                var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
                dynamicComponentInfo.ComponentName = obj.CurrentStateDef.FormDef.CodeName;
                dynamicComponentInfo.ModuleName = moduleName;
                dynamicComponentInfo.ModulePath = modulePath;
                dynamicComponentInfo.objectID = ObjectId;
                objectContext.FullPartialllyLoadedObjects();
                return dynamicComponentInfo;
            }
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DynamicComponentInfoDVO GetNewObjectDynamicComponentInfo([FromQuery] string ObjectDefName)
        {
            DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
            var objectDefList = TTObjectDefManager.Instance.ObjectDefs;
            var objectDef = objectDefList.Values.Where(d => d.Name.ToUpperInvariant() == ObjectDefName).FirstOrDefault();
            if (objectDef == null)
                return dynamicComponentInfo;
            var subFolders = GetParentFolders(objectDef.ModuleDef);
            var folderPath = string.Join("/", subFolders.Reverse());
            var moduleName = objectDef.ModuleDef.Name.GetTsModuleName();
            var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
            string componentName = string.Empty;
            foreach (TTObjectStateDef state in objectDef.StateDefs)
            {
                if (state.IsEntry)
                {
                    componentName = state.FormDef.CodeName;
                    break;
                }
            }

            dynamicComponentInfo.ComponentName = componentName;
            dynamicComponentInfo.ModuleName = moduleName;
            dynamicComponentInfo.ModulePath = modulePath;
            dynamicComponentInfo.objectID = string.Empty;
            return dynamicComponentInfo;
        }

        internal static IEnumerable<string> GetParentFolders(TTModuleDef moduleDef)
        {
            yield return TTUtils.Globals.GetModuleName(moduleDef.Name);
            Guid? folderDefId = moduleDef.FolderDefID;
            while (folderDefId != null)
            {
                TTFolderDef folderDef = null;
                if (TTObjectDefManager.Instance.FolderDefs.ContainsKey(folderDefId))
                {
                    folderDef = TTObjectDefManager.Instance.FolderDefs[folderDefId];
                    yield return TTUtils.Globals.GetModuleName(folderDef.CodeName);
                    folderDefId = folderDef.ParentFolderDefID;
                }

                if (!folderDefId.HasValue)
                    yield break;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<TTListDef> GetStockDefinitionAction()
        {
            List<TTListDef> def = new List<TTListDef>();
            foreach (TTListDef listDef in TTObjectDefManager.Instance.ListDefs.Values)
            {
                if (listDef.FormDef != null && listDef.FormDef.FormType == FormTypeEnum.DefinitionForm)
                {
                    if (TTUser.CurrentUser.HasRight(listDef.ObjectDef, null, (int)TTSecurityAuthority.RightsEnum.Read) == true)
                    {
                        if (TTUser.CurrentUser.HasRight(listDef.ObjectDef, null, (int)TTSecurityAuthority.RightsEnum.Update) == true)
                        {
                            def.Add(listDef);
                        }
                    }
                }
            }

            return def;
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public static bool HasRightMenuDefinition(MenuDefinition menuDefinition)
        {
            // TTObjectContext objectContext = new TTObjectContext(true);
            if (menuDefinition.ObjectDefinitionName != null)
            {
                TTObjectStateDef entryState = EntryStateForMenuDefinition(menuDefinition);
                if (entryState == null)
                    return false;
                if (entryState.FormDef == null)
                    return false;
                return TTStorageManager.Security.TTUser.CurrentUser.HasRight(entryState.FormDef, null, (int)TTStorageManager.Security.TTSecurityAuthority.RightsEnum.UpdateForm);
            }
            else if (menuDefinition.UnboundFormName != null)
            {
                string unboundFormDefName = menuDefinition.UnboundFormName.ToUpperInvariant();
                if (TTObjectDefManager.Instance.UnboundFormDefs.ContainsKey(unboundFormDefName))
                {
                    return TTStorageManager.Security.TTUser.CurrentUser.HasRight(TTObjectDefManager.Instance.UnboundFormDefs[unboundFormDefName], null, (int)TTStorageManager.Security.TTSecurityAuthority.RightsEnum.UpdateForm);
                }
            }
            else
            {
                foreach (MenuDefinition md in menuDefinition.ChildMenus)
                {
                    if (HasRightMenuDefinition(md)) //Bir tanesi bile true olsa true döner
                        return true;
                }
            }

            return false;
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public static TTObjectStateDef EntryStateForMenuDefinition(MenuDefinition menuDefinition)
        {
            if (menuDefinition.ObjectDefinitionName != null)
            {
                string objectDefName = menuDefinition.ObjectDefinitionName.ToUpperInvariant();
                if (TTObjectDefManager.Instance.ObjectDefs.ContainsKey(objectDefName) == true)
                {
                    TTObjectDef objDef = TTObjectDefManager.Instance.ObjectDefs[objectDefName];
                    if (menuDefinition.EntryState != null)
                    {
                        if (Globals.IsGuid(menuDefinition.EntryState))
                        {
                            Guid mdGuid = new Guid(menuDefinition.EntryState.ToString());
                            if (objDef.StateDefs.ContainsKey(mdGuid))
                                return objDef.StateDefs[mdGuid];
                        }
                    }

                    foreach (TTObjectStateDef StateDef in objDef.StateDefs)
                    {
                        if (StateDef.IsEntry == true)
                            return StateDef;
                    }
                }
            }

            return null;
        }

        public static readonly List<string> excludedActionList = new List<string>()
            {"MainStoreProductionConsumptionDocument",
            "ShellingProcedure",
        "DistributionDepStore",
        "ReturnDepStore",
        "PresDistributionDocument",
        "FreePrescriptionEntry",
        "CensusOrderByStore",
        "ResSubStoreConsumption",
        "HandoverDocument",
        "E2",
        "VoucherDistributingDocument",
        "PresVoucherDistributingDoc",
        "VoucherReturnDocument",
        "PresVoucherReturnDocument",
        "ProductionConsumptionInfirmaryDocument",
        "PresInfirmaryDocument",
        "PurchaseExamination",
        "GeneralProductionAction",
        "KScheduleDaily",
        "DailyDrugSchedule",
        "PresReturningDocument",
        "DrugProductionTest",
        "SectionRequirement",
        "MilitaryDrugProductionProcedure",
        "ConsignedCensusFixed",
        "PresCensusFixed",
        "CensusOrder",
        "StockMerge",
        "PresChaDocOutputWithAccountancy",
        "PresChaDocInputWithAccountancy",
        "PresChaDocWithPurchase",
        "ProductionConsumptionDocument",
        "PrescriptionConsumptionDocument"};

        private List<WorkListItem> FilterStatesWithObjectDef()
        {
            var currentUser = TTUser.CurrentUser;
            SortedList<string, TTObjectDef> filteredObjectDefList = new SortedList<string, TTObjectDef>();
            foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values)
            {
                if (EpisodeActionListForPharmacyStore.Contains(objDef.ID) == true)
                {
                    filteredObjectDefList.Add(objDef.ApplicationName, objDef);
                }

                foreach (TTObjectStateDef stateDef in objDef.StateDefs)
                {
                    ITTSecurableObject securableFormDef = stateDef.FormDef;
                    if (securableFormDef != null)
                    {
                        TTPermissionCollection subSecurityPermissionsCollection;
                        if (securableFormDef.SubSecurityPermissions != null)
                        {
                            if (securableFormDef.SubSecurityPermissions.TryGetValue(stateDef.StateDefID, out subSecurityPermissionsCollection))
                            {
                                foreach (TTPermission permission in subSecurityPermissionsCollection.Values)
                                {
                                    if (permission.RightDef.RightDefID == 1003)
                                    {
                                        if (currentUser.HasRole(permission.Role.ID))
                                        {
                                            if (filteredObjectDefList.ContainsKey(objDef.ApplicationName) == false)
                                                filteredObjectDefList.Add(objDef.ApplicationName, objDef);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            List<WorkListItem> workListItems = new List<WorkListItem>();
            foreach (var l in filteredObjectDefList)
            {
                if (excludedActionList.Contains(l.Value.CodeName) == false)
                {
                    WorkListItem w = new Models.WorkListItem();
                    w.ObjectDefName = l.Value.ApplicationName;
                    w.ObjectDefId = l.Value.ID.ToString();
                    workListItems.Add(w);
                }
            }

            return workListItems;
        }
    }
}