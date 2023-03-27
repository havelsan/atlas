
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
    /// <summary>
    /// Laboratuvar Tetkik Tanımları
    /// </summary>
    public  partial class LaboratoryTestDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public partial class GetLaboratoryTestDefinitions_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetLabTestDef_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetLabTestDef_WithDate_Class : TTReportNqlObject 
        {
        }

        public partial class VEM_TETKIK_Class : TTReportNqlObject 
        {
        }

        #region Methods

        #region IProcedureRequestDefinition Members
        public String GetMyCategoryName()
        {
            return MyCategoryName;
        }

        public String GetMyFiredActionDefName()
        {
            return MyFiredActionDefName;
        }

        public bool GetIsProcedureFlowStarts()
        {
            return IsProcedureFlowStarts;
        }

        public Guid GetMyStartedStateDefID()
        {
            return MyStartedStateDefID;
        }
        #endregion
        public void LocationArrange()
        {
            //eğer tab seçilmemişse LaboratoryLocation a ekleme.. (formpostta çağırılıyor)
            
            if ((bool) IsActive)
            {
                if (RequestFormTab != null)
                {
                    IList LaboratoryLocations = LaboratoryLocation.GetByTest(ObjectContext,ObjectID.ToString()  );
                    //ObjectContext.QueryObjects("LaboratoryLocation","TEST = " + ConnectionManager.GuidToString(this.ObjectID));
                    
                    if (LaboratoryLocations.Count > 0)
                    {
                        LaboratoryLocation loc = (LaboratoryLocation)  LaboratoryLocations[0];
                        loc.Tab = RequestFormTab;
                        loc.OrderNo = TabOrder;
                    }
                    else
                    {
                        LaboratoryLocation loc = new LaboratoryLocation(ObjectContext);
                        loc.Test = this;
                        loc.Tab = RequestFormTab;
                        loc.OrderNo = TabOrder;
                    }
                }
                else
                {
                    IList LaboratoryLocations = LaboratoryLocation.GetByTest(ObjectContext,ObjectID.ToString()  );
                    //ObjectContext.QueryObjects("LaboratoryLocation","TEST = " + ConnectionManager.GuidToString(this.ObjectID));

                    if (LaboratoryLocations.Count > 0)
                    {
                        LaboratoryLocation loc = (LaboratoryLocation)  LaboratoryLocations[0];
                        loc.Tab = RequestFormTab;
                        loc.OrderNo = 0;
                    }
                }
            }
            else
            {
                IList LaboratoryLocations = LaboratoryLocation.GetByTest(ObjectContext,ObjectID.ToString()  );
                //ObjectContext.QueryObjects("LaboratoryLocation","TEST = " + ConnectionManager.GuidToString(this.ObjectID));
                
                if (LaboratoryLocations.Count > 0)
                {
                    LaboratoryLocation loc = (LaboratoryLocation)  LaboratoryLocations[0];
                    loc.Tab = null;
                    loc.OrderNo = 0;
                }
            }
        }

        public override void SetProcedureType()
        {
            ProcedureType = ProcedureDefGroupEnum.tahlilBilgileri;
        }

        public void DeparmentControl()
        {
            if (Departments.Count < 1) {throw new TTException(SystemMessage.GetMessage(554));}
        }
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.LaboratoryTestDefinitionNewInfo;
        }

        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("Environment");
            localPropertyNamesList.Add("RequestFormTab");
            localPropertyNamesList.Add("TestSubType");
            localPropertyNamesList.Add("TestTube");
            localPropertyNamesList.Add("TestType");
            localPropertyNamesList.Add("TestUnit");
            localPropertyNamesList.Add("DurationValue");
            localPropertyNamesList.Add("Is24HourTest");
            localPropertyNamesList.Add("IsBoundedTest");
            localPropertyNamesList.Add("IsDurationControl");
            localPropertyNamesList.Add("IsHeader");
            localPropertyNamesList.Add("IsLoad");
            localPropertyNamesList.Add("IsMicrobiologyTest");
            localPropertyNamesList.Add("IsMoleculerTest");
            localPropertyNamesList.Add("IsMultiReference");
            localPropertyNamesList.Add("IsPanel");
            localPropertyNamesList.Add("IsPassiveNow");
            localPropertyNamesList.Add("IsPrintEveryPage");
            localPropertyNamesList.Add("IsRestrictedTest");
            localPropertyNamesList.Add("IsSat");
            localPropertyNamesList.Add("IsSexControl");
            localPropertyNamesList.Add("ReasonForPassive");
            localPropertyNamesList.Add("ResultType");
            localPropertyNamesList.Add("ResultUnit");
            localPropertyNamesList.Add("RoundValue");
            localPropertyNamesList.Add("SexControl");
            localPropertyNamesList.Add("TabDescription");
            localPropertyNamesList.Add("TabOrder");
            localPropertyNamesList.Add("PriceCoefficient");
            localPropertyNamesList.Add("NotLISTest");
            //
            localPropertyNamesList.Add("RequiresBinaryScanForm");
            localPropertyNamesList.Add("RequiresTripleTestForm");
            localPropertyNamesList.Add("RequiresUreaBreathTestReport");
            
            return localPropertyNamesList;
        }
        
        
        
        public Guid MyStartedStateDefID
        {
            get{
                return (Guid)LaboratoryRequest.States.RequestAcception;
            }
        }
        
           
            public string MyCategoryName
        {
            get{
                return (string)ProcedureTree.Description.ToString();
            }
        }
            
                    
            public string MyFiredActionDefName
        {
            get{
                return "LaboratoryRequest";
            }
        }
            
            public bool IsProcedureFlowStarts
            {
                get{
                    return true;
                }
            }
                
        public EpisodeAction CreateMyEpisodeAction(EpisodeAction starterEA, ResSection masterRes, ResSection fromRes, bool setMasterAction, bool emergency, DateTime requestDate, Guid procedureUser, bool fromPatientAdmission)
        {
            //Episode da RequestAcception asamasinda LaboratoryRequest actioni varsa o doner, yoksa yeni episodeaction yaratip o doner.
            
               LaboratoryRequest labAction = (LaboratoryRequest)ObjectContext.CreateObject("LaboratoryRequest");
               labAction.ActionDate = requestDate;
               labAction.RequestDate = requestDate;
               if (procedureUser != null && procedureUser != Guid.Empty)
                  labAction.ProcedureDoctor = (ResUser)ObjectContext.GetObject(procedureUser, "ResUser");
               labAction.WorkListDate = requestDate;
               labAction.CurrentStateDefID = LaboratoryRequest.States.New;
               labAction.MasterAction = (BaseAction)starterEA;
               if (emergency == true)
                    labAction.Emergency = emergency;

               labAction.SetMandatoryEpisodeActionProperties(starterEA, masterRes, fromRes, setMasterAction);
               labAction.SetMyActionMandatoryProperties();
            if (!fromPatientAdmission)
                labAction.Update();
               
               return (EpisodeAction) labAction;
            
        }
        
        public SubActionProcedure  CreateMySubactionProcedure(EpisodeAction ea, ResSection masterRes, ResSection fromRes)
        {
            LaboratoryRequest labRequest = (LaboratoryRequest)ea;
            LaboratoryProcedure labProc = (LaboratoryProcedure)ObjectContext.CreateObject("LaboratoryProcedure");
            LaboratoryTestDefinition labTestDef = (LaboratoryTestDefinition)this;

            SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(labRequest, masterRes, fromRes, labProc);
            labProc.RequestDate = labRequest.RequestDate;
            labProc.CreationDate = labRequest.RequestDate;
            labProc.ActionDate = labRequest.RequestDate;
            labProc.ProcedureObject = labTestDef;
            labProc.EpisodeAction = labRequest;
            labProc.Amount = labTestDef.PriceCoefficient == null ? 1 : labTestDef.PriceCoefficient;
            if (ea.Emergency == true)
                labProc.Emergency = true;

            
            foreach (LaboratoryGridMaterialDefinition defMaterialGrid in labTestDef.Materials)
            {
                LaboratoryMaterial labMaterial = new LaboratoryMaterial(ea.ObjectContext);
                labMaterial.Amount = 1;
                labMaterial.Material = defMaterialGrid.Material;
                labMaterial.EpisodeAction = labRequest;
                labProc.Materials.Add(labMaterial);
            }

    
            //test panellerin alt testleri sonuc gelince olusturulacak, istem aninda olusmamasi icin asagidaki blok commentlendi
            //if (labTestDef.IsPanel == true)
            //{
            //    foreach (LaboratoryGridPanelTestDefinition panelTestDef in labTestDef.PanelTests)
            //    {
            //        LaboratorySubProcedure subProcedure = new LaboratorySubProcedure(labRequest.ObjectContext);
            //        LaboratoryTestDefinition labSubReqTestDef = (LaboratoryTestDefinition)panelTestDef.LaboratoryTest;
            //        subProcedure.ProcedureObject = labSubReqTestDef;
            //        subProcedure.MasterResource = masterRes; //labReqTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
            //        subProcedure.FromResource = fromRes;
            //        subProcedure.EpisodeAction = labRequest;
            //        subProcedure.Eligible = false; // Fatura'ya düşmez.
            //        labProc.LaboratorySubProcedures.Add(subProcedure);
            //    }
            //}

           

            labRequest.SubactionProcedures.Add((SubActionProcedure)labProc);
            return (SubActionProcedure)labProc;

        }

        public ActionTypeEnum? GetActionTypeEnum()
        {
            return ActionTypeEnum.LaboratoryRequest;
        }

        public static Boolean GetLaboratoryTestDefinitionFromLIS()
        {
            try
            { 

                Dictionary<string, List<string>> panelTestProceduresList = new Dictionary<string, List<string>>();
                TTObjectContext objectContext = new TTObjectContext(false);
                //ProcedureTree Zorunlu
                ProcedureTreeDefinition procedureTreeDef = (ProcedureTreeDefinition)objectContext.GetObject(new Guid("7265fc04-6503-4349-b759-f195e2eb5969"), "PROCEDURETREEDEFINITION");

                XXXXXXIHEWS.TetkikBilgiListe tetkikListe = new XXXXXXIHEWS.TetkikBilgiListe();
                tetkikListe = XXXXXXIHEWS.WebMethods.TetkikBilgiGetirSync(Sites.SiteLocalHost);
                foreach (XXXXXXIHEWS.TetkikBilgi tetkikBilgi in tetkikListe.TetkikBilgiArr)
                {
                    IBindingList labTestDefList = ProcedureDefinition.GetByLOINCCode(objectContext, tetkikBilgi.LoincKodu);
                    //LabTestDef Update
                    if (labTestDefList.Count > 0)
                    {

                        LaboratoryTestDefinition labTestDef = (LaboratoryTestDefinition)labTestDefList[0];
                        labTestDef.Name = tetkikBilgi.Adi;
                        if (tetkikBilgi.SutKodu == "" || tetkikBilgi.SutKodu == null)
                            labTestDef.Code = ".";
                        else
                            labTestDef.Code = tetkikBilgi.SutKodu;

                        if (tetkikBilgi.Aktif == "E")
                            labTestDef.IsActive = true;
                        else
                            labTestDef.IsActive = false;

                        string boundedTests = tetkikBilgi.BirlikteIstenenTestler;
                        //TODO: bırlıkte ıstenen testler BoundedTest olarak eklenecek

                        List<LaboratoryTestTypeDefinition> labTestTypeList = LaboratoryTestTypeDefinition.GetByCode(objectContext, tetkikBilgi.UniteKodu).ToList();
                        if (labTestTypeList != null)
                        {
                            if (labTestTypeList.Count > 0)
                            {
                                labTestDef.TestType = labTestTypeList[0];
                            }
                            else
                            {
                                LaboratoryTestTypeDefinition labTestTypeDef = new LaboratoryTestTypeDefinition(objectContext);
                                labTestTypeDef.Code = tetkikBilgi.UniteKodu;
                                labTestTypeDef.Name = tetkikBilgi.UniteAdi;
                                objectContext.Save();
                                labTestDef.TestType = labTestTypeDef;
                            }
                        }


                        if (tetkikBilgi.PanelLoincKodu != null && tetkikBilgi.PanelLoincKodu != "")  //Panel testi ise
                        {
                            List<string> subTestList = new List<string>();
                            if (panelTestProceduresList.TryGetValue(tetkikBilgi.PanelLoincKodu, out subTestList) == false)
                            {
                                if (subTestList == null)
                                    subTestList = new List<string>();
                                subTestList.Add(tetkikBilgi.LoincKodu);
                                panelTestProceduresList.Add(tetkikBilgi.PanelLoincKodu, subTestList);
                            }
                            else
                            {
                                subTestList.Add(tetkikBilgi.LoincKodu);
                            }
                        }
                    }

                    //LabTestDef create
                    else
                    {
                        /*
                        LaboratoryTestDefinition labTestDef = new LaboratoryTestDefinition(objectContext);
                        labTestDef.Name = tetkikBilgi.Adi;
                        if (tetkikBilgi.SutKodu == "" || tetkikBilgi.SutKodu == null)
                            labTestDef.Code = ".";
                        else
                            labTestDef.Code = tetkikBilgi.SutKodu;

                        List<SKRSLOINC> skrsLOINCList = SKRSLOINC.GetByLoincNum(objectContext, tetkikBilgi.LoincKodu).ToList();
                        if (skrsLOINCList != null)
                        {
                            if (skrsLOINCList.Count > 0)
                            {
                                labTestDef.SKRSLoincKodu = skrsLOINCList[0];
                            }
                        }

                        if (tetkikBilgi.Aktif == "E")
                            labTestDef.IsActive = true;
                        else
                            labTestDef.IsActive = false;
                        

                        string boundedTests = tetkikBilgi.BirlikteIstenenTestler;
                        //TODO: bırlıkte ıstenen testler BoundedTest olarak eklenecek
                        labTestDef.Description = tetkikBilgi.Not;

                        if (tetkikBilgi.PanelLoincKodu != null && tetkikBilgi.PanelLoincKodu != "")  //Panel testi ise
                        {
                            List<string> subTestList = new List<string>();
                            if (panelTestProceduresList.TryGetValue(tetkikBilgi.PanelLoincKodu, out subTestList) == false)
                            {
                                if (subTestList == null)
                                    subTestList = new List<string>();
                                subTestList.Add(tetkikBilgi.LoincKodu);
                                panelTestProceduresList.Add(tetkikBilgi.PanelLoincKodu, subTestList);
                            }
                            else
                            {
                                subTestList.Add(tetkikBilgi.LoincKodu);
                            }
                        }
                        else
                            labTestDef.Chargable = true;

                        labTestDef.ProcedureTree = procedureTreeDef;
                        List<LaboratoryTestTypeDefinition> labTestTypeList = LaboratoryTestTypeDefinition.GetByCode(objectContext, tetkikBilgi.UniteKodu).ToList();
                        if (labTestTypeList != null)
                        {
                            if (labTestTypeList.Count > 0)
                            {
                                labTestDef.TestType = labTestTypeList[0];
                            }
                            else
                            {
                                LaboratoryTestTypeDefinition labTestTypeDef = new LaboratoryTestTypeDefinition(objectContext);
                                labTestTypeDef.Code = tetkikBilgi.UniteKodu;
                                labTestTypeDef.Name = tetkikBilgi.UniteAdi;
                                objectContext.Save();
                                labTestDef.TestType = labTestTypeDef;
                            }
                        }
                        */
                    }
                }
                objectContext.Save();


                if (panelTestProceduresList.Count > 0)
                {
                    foreach (KeyValuePair<string, List<string>> panelTest in panelTestProceduresList)
                    {
                        LaboratoryTestDefinition panelLabTest;
                        IBindingList panelTestDefList = ProcedureDefinition.GetByLOINCCode(objectContext, panelTest.Key);
                        if (panelTestDefList.Count > 0)
                        {
                            if (panelTestDefList[0] != null)
                            {
                                panelLabTest = (LaboratoryTestDefinition)panelTestDefList[0];
                                foreach (string subTestLoincCode in panelTest.Value)
                                {
                                    IBindingList subTestDefList = ProcedureDefinition.GetByLOINCCode(objectContext, subTestLoincCode);
                                    if (subTestDefList.Count > 0)
                                    {
                                        LaboratoryGridPanelTestDefinition subTestDef = new LaboratoryGridPanelTestDefinition(objectContext);
                                        subTestDef.LaboratoryTest = (LaboratoryTestDefinition)subTestDefList[0];
                                        panelLabTest.PanelTests.Add(subTestDef);
                                    }
                                }
                            }
                        }
                    }
                }

               objectContext.Save();
               return true;
            }

            catch (Exception ex)
            {
                    return false;
            }
        }


        public string GetMyAlertMessage(Guid eaObjectId)
        {
            return null;
        }
        #endregion Methods

    }

}