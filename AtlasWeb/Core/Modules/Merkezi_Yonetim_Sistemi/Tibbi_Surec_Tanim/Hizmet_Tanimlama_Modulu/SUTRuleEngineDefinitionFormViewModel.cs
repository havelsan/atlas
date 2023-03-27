using AutoMapper;
using RuleChecker.Engine.RuleCheckers;
using RuleChecker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace Core.Models
{
    public class SutRuleEngineDefinitionFormViewModel
    {
        public string SUTCode { get; set; }
        public RuleSetDTO RuleSetDTO = new RuleSetDTO();
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Creates a new SohaRule and a Rule for xml content of SohaRule's content.
        /// </summary>
        /// <typeparam name="T">Rule class that is serialized to xml for content of new SohaRule.</typeparam>
        /// <param name="objectContext">TTObjectContext</param>
        /// <param name="ruleDTO">RuleDTO class</param>
        /// <param name="SUTCode">SUTCode of procedure</param>
        /// <param name="ruleGroup">SohaRuleGroup of new SohaRule and Xml content</param>
        /// <returns>CreateNewSohaRuleDTO</returns>
        public CreateNewSohaRule CreateNewSohaRuleAndXmlContent<T>(TTObjectContext objectContext, IRuleDTO ruleDTO, string SUTCode, SohaRuleGroup ruleGroup) where T : IRule
        {
            CreateNewSohaRule model = new CreateNewSohaRule();
            SohaRule newSohaRule = new SohaRule(objectContext);
            newSohaRule.IsDeleted = false;
            newSohaRule.Active = ruleDTO.Active.HasValue ? ruleDTO.Active.Value : true;
            newSohaRule.BlockRequest = ruleDTO.BlockRequest.HasValue ? ruleDTO.BlockRequest.Value : false;
            newSohaRule.Performance = false;
            newSohaRule.ProcedureCode = SUTCode;
            newSohaRule.RuleGroup = ruleGroup;

            IRule xmlRule = (IRule)Activator.CreateInstance(typeof(T));
            xmlRule.GroupId = ruleGroup.ObjectID;
            xmlRule.ObjectId = newSohaRule.ObjectID;
            xmlRule.ProcedureCode = SUTCode;
            model.SohaRule = newSohaRule;
            model.XmlRule = xmlRule;
            return model;
        }

        /// <summary>
        /// Kural listesinin Xml (content) kolonunu serialize eder.
        /// </summary>
        /// <param name="ruleList">SohaRule listesi</param>
        /// <returns>RuleChecker.Engine.RuleSet</returns>
        public RuleChecker.Engine.RuleSet GetRuleSet(List<SohaRule> ruleList)
        {
            var contentList = ruleList.Select(x => x.Content);
            var query1 = from r in ruleList
                         select new { Content = XElement.Parse(r.Content), r.BlockRequest, r.Active, r.ObjectID };
            var elmRuleSet = new XElement(RuleXmlTag.RuleSet);

            var elmRules = new XElement(RuleXmlTag.Rules);

            elmRuleSet.Add(elmRules);

            elmRules.Add(query1.Select(x => x.Content).ToArray());

            XmlSerializer serializer = new XmlSerializer(typeof(RuleChecker.Engine.RuleSet));

            using (var reader = elmRuleSet.CreateReader())
            {
                var ruleSet = serializer.Deserialize(reader) as RuleChecker.Engine.RuleSet;
                return ruleSet;
            }
        }

        public static SutRuleEngineDefinitionFormViewModel GetSUTRules(string sutCode)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                SutRuleEngineDefinitionFormViewModel viewModel = new SutRuleEngineDefinitionFormViewModel();
                viewModel.SUTCode = sutCode;

                /*Kurallar xml'den serialize edilerek çekiliyor fakat Active ve BlockRequest kolonları xml
                içerisinde tutulmadığı için bu propertyler SohaRule tablosundan alınıp client'a döndürülecek 
                ilgili kural'ın DTO suna set ediliyor.
                 */
                void SetRuleActiveAndBlockRequest(IRule rule, List<SohaRule> ruleList)
                {
                    var queryRule = ruleList.FirstOrDefault(x => x.ObjectID == (rule as IRule).ObjectId);
                    (rule as IRule).Active = queryRule.Active.Value;
                    (rule as IRule).BlockRequest = queryRule.BlockRequest.Value;
                }

                if (!string.IsNullOrEmpty(sutCode))
                {
                    //Seçilen hizmete ait tüm kuralların listesi.
                    List<SohaRule> sohaRuleList = objectContext.QueryObjects<SohaRule>("PROCEDURECODE = '" + sutCode + "' AND ISDELETED = 0").ToList();

                    var ruleSet = viewModel.GetRuleSet(sohaRuleList);

                    IEnumerable<Rule1> rule1List = ruleSet.Rules.OfType<Rule1>();
                    IEnumerable<Rule2> rule2List = ruleSet.Rules.OfType<Rule2>();
                    IEnumerable<Rule3> rule3List = ruleSet.Rules.OfType<Rule3>();
                    IEnumerable<Rule4> rule4List = ruleSet.Rules.OfType<Rule4>();
                    IEnumerable<Rule5> rule5List = ruleSet.Rules.OfType<Rule5>();
                    IEnumerable<Rule6> rule6List = ruleSet.Rules.OfType<Rule6>();
                    IEnumerable<Rule7> rule7List = ruleSet.Rules.OfType<Rule7>();
                    IEnumerable<Rule8> rule8List = ruleSet.Rules.OfType<Rule8>();
                    IEnumerable<Rule9> rule9List = ruleSet.Rules.OfType<Rule9>();
                    IEnumerable<Rule10> rule10List = ruleSet.Rules.OfType<Rule10>();
                    IEnumerable<Rule11> rule11List = ruleSet.Rules.OfType<Rule11>();
                    IEnumerable<Rule15> rule15List = ruleSet.Rules.OfType<Rule15>();
                    IEnumerable<Rule16> rule16List = ruleSet.Rules.OfType<Rule16>();
                    IEnumerable<Rule17> rule17List = ruleSet.Rules.OfType<Rule17>();
                    IEnumerable<Rule18> rule18List = ruleSet.Rules.OfType<Rule18>();
                    IEnumerable<Rule19> rule19List = ruleSet.Rules.OfType<Rule19>();
                    IEnumerable<Rule20> rule20List = ruleSet.Rules.OfType<Rule20>();

                    //Rule1 içerisindeki procedurecode listesi
                    List<string> procedureCodeListOfRule1 = null;
                    //Rule1 içerisindeki procedurecode listesinin SUT karşılılıklarını tutan liste
                    List<SUT> procedureListForRule1 = null;

                    //Rule2 içerisindeki branchcodes listesi
                    List<string> branchCodeListOfRule2 = null;
                    List<SpecialityDefinition> specialityDefinitionListForRule2 = null;

                    //Rule2 içerisindeki branchcodes listesi
                    List<string> icd10CodeListOfRule7 = null;
                    List<DiagnosisDefinition> icd10DefinitionListForRule7 = null;

                    //Rule16 içerisindeki procedurecode listesi
                    List<string> procedureCodeListOfRule16 = null;
                    //Rule16 içerisindeki procedurecode listesinin SUT karşılılıklarını tutan liste
                    List<SUT> procedureListForRule16 = null;

                    Mapper.Reset();
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<Rule1, Rule1DataSourceObject>();
                        cfg.CreateMap<Rule2, Rule2DTO>();
                        cfg.CreateMap<Rule3, Rule3DTO>();
                        cfg.CreateMap<Rule5, Rule5DTO>();
                        cfg.CreateMap<Rule7, Rule7DTO>();
                        cfg.CreateMap<Rule16, Rule16DTO>();
                        cfg.CreateMap<Rule17, Rule17DTO>();
                        cfg.CreateMap<Rule18, Rule18DTO>();
                        cfg.CreateMap<Rule20, Rule20DTO>();
                    });

                    if (rule1List.Count() > 0)
                    {
                        procedureCodeListOfRule1 = rule1List.Select(x => x.ProcedureCode2).ToList();
                        procedureListForRule1 = objectContext.QueryObjects<SUT>(Common.CreateFilterExpressionOfStringList("KOD", procedureCodeListOfRule1)).ToList();
                        objectContext.QueryObjects<SohaRule>("RULEGROUP = '" + rule1List.FirstOrDefault().GroupId + "' AND " + Common.CreateFilterExpressionOfStringList("PROCEDURECODE", procedureCodeListOfRule1));


                        Rule1DTO rule1DTO = new Rule1DTO();
                        SetRuleActiveAndBlockRequest(rule1List.FirstOrDefault(), sohaRuleList);
                        rule1DTO.Active = rule1List.FirstOrDefault().Active;
                        rule1DTO.BlockRequest = rule1List.FirstOrDefault().BlockRequest;
                        foreach (var rule in rule1List)
                        {
                            Rule1 rule1 = rule;
                            Rule1DataSourceObject data = new Rule1DataSourceObject();
                            data = Mapper.Map<Rule1, Rule1DataSourceObject>(rule1);
                            data.ProcedureName2 = procedureListForRule1.FirstOrDefault(x => x.Kod == rule1.ProcedureCode2).Ad;

                            rule1DTO.Rule1DataSource.Add(data);
                        }

                        viewModel.RuleSetDTO.Rule1DTO = rule1DTO;
                    }

                    if (rule2List.Count() > 0)
                    {
                        branchCodeListOfRule2 = rule2List.FirstOrDefault().BranchCodes;
                        specialityDefinitionListForRule2 = objectContext.QueryObjects<SpecialityDefinition>(Common.CreateFilterExpressionOfStringList("CODE", branchCodeListOfRule2)).ToList();

                        Rule2 rule2 = rule2List.FirstOrDefault();
                        SetRuleActiveAndBlockRequest(rule2, sohaRuleList);
                        Rule2DTO rule2DTO = new Rule2DTO();

                        rule2DTO = Mapper.Map<Rule2, Rule2DTO>(rule2List.FirstOrDefault());
                        rule2DTO.BranchCodesAndNames = specialityDefinitionListForRule2.Select(x => new listboxObject { Code = x.Code, Name = x.Name, ObjectID = x.ObjectID }).ToList();
                        viewModel.RuleSetDTO.Rule2DTO = rule2DTO;
                    }


                    if (rule3List.Count() > 0)
                    {
                        Rule3 rule3 = rule3List.FirstOrDefault();
                        SetRuleActiveAndBlockRequest(rule3, sohaRuleList);
                        Rule3DTO rule3DTO = new Rule3DTO();

                        rule3DTO = Mapper.Map<Rule3, Rule3DTO>(rule3List.FirstOrDefault());
                        viewModel.RuleSetDTO.Rule3DTO = rule3DTO;
                    }

                    if (rule5List.Count() > 0)
                    {
                        Rule5 rule5 = rule5List.FirstOrDefault() as Rule5;
                        SetRuleActiveAndBlockRequest(rule5, sohaRuleList);
                        Rule5DTO rule5DTO = new Rule5DTO();
                        rule5DTO = Mapper.Map<Rule5, Rule5DTO>(rule5);
                        viewModel.RuleSetDTO.Rule5DTO = rule5DTO;
                    }


                    if (rule7List.Count() > 0)
                    {
                        icd10CodeListOfRule7 = ruleSet.Rules.OfType<Rule7>().FirstOrDefault().Icd10List;
                        icd10DefinitionListForRule7 = objectContext.QueryObjects<DiagnosisDefinition>(Common.CreateFilterExpressionOfStringList("CODE", icd10CodeListOfRule7)).ToList();

                        Rule7 rule7 = rule7List.FirstOrDefault() as Rule7;
                        SetRuleActiveAndBlockRequest(rule7, sohaRuleList);
                        Rule7DTO rule7DTO = new Rule7DTO();
                        rule7DTO = Mapper.Map<Rule7, Rule7DTO>(rule7);
                        rule7DTO.Icd10ListAndNames = icd10DefinitionListForRule7.Select(x => new listboxObject { Code = x.Code, Name = x.Name, ObjectID = x.ObjectID }).ToList();
                        viewModel.RuleSetDTO.Rule7DTO = rule7DTO;
                    }

                    if (rule16List.Count() > 0)
                    {
                        procedureCodeListOfRule16 = ruleSet.Rules.OfType<Rule16>().FirstOrDefault().ProcedureList;
                        procedureListForRule16 = objectContext.QueryObjects<SUT>(Common.CreateFilterExpressionOfStringList("KOD", procedureCodeListOfRule16)).ToList();

                        Rule16 rule16 = rule16List.FirstOrDefault() as Rule16;
                        SetRuleActiveAndBlockRequest(rule16, sohaRuleList);

                        Rule16DTO rule16DTO = new Rule16DTO();
                        rule16DTO = Mapper.Map<Rule16, Rule16DTO>(rule16);
                        rule16DTO.ProcedureNameAndCodes = procedureListForRule16.Select(x => new listboxObject { Code = x.Kod, Name = x.Ad, ObjectID = x.ObjectID }).ToList();
                        viewModel.RuleSetDTO.Rule16DTO = rule16DTO;
                    }

                    if (rule16List.Count() > 0)
                    {
                        procedureCodeListOfRule16 = ruleSet.Rules.OfType<Rule16>().FirstOrDefault().ProcedureList;
                        procedureListForRule16 = objectContext.QueryObjects<SUT>(Common.CreateFilterExpressionOfStringList("KOD", procedureCodeListOfRule16)).ToList();

                        Rule16 rule16 = rule16List.FirstOrDefault() as Rule16;
                        SetRuleActiveAndBlockRequest(rule16, sohaRuleList);

                        Rule16DTO rule16DTO = new Rule16DTO();
                        rule16DTO = Mapper.Map<Rule16, Rule16DTO>(rule16);
                        rule16DTO.ProcedureNameAndCodes = procedureListForRule16.Select(x => new listboxObject { Code = x.Kod, Name = x.Ad, ObjectID = x.ObjectID }).ToList();
                        viewModel.RuleSetDTO.Rule16DTO = rule16DTO;
                    }

                    if (rule17List.Count() > 0)
                    {
                        Rule17 rule17 = rule17List.FirstOrDefault() as Rule17;
                        SetRuleActiveAndBlockRequest(rule17, sohaRuleList);
                        Rule17DTO rule17DTO = new Rule17DTO();
                        rule17DTO = Mapper.Map<Rule17, Rule17DTO>(rule17);
                        viewModel.RuleSetDTO.Rule17DTO = rule17DTO;
                    }

                    if (rule18List.Count() > 0)
                    {
                        Rule18 rule18 = rule18List.FirstOrDefault() as Rule18;
                        SetRuleActiveAndBlockRequest(rule18, sohaRuleList);
                        Rule18DTO rule18DTO = new Rule18DTO();
                        rule18DTO = Mapper.Map<Rule18, Rule18DTO>(rule18);
                        viewModel.RuleSetDTO.Rule18DTO = rule18DTO;
                    }

                    if (rule20List.Count() > 0)
                    {
                        Rule20 rule20 = rule20List.FirstOrDefault();
                        SetRuleActiveAndBlockRequest(rule20, sohaRuleList);
                        Rule20DTO rule20DTO = new Rule20DTO();

                        rule20DTO = Mapper.Map<Rule20, Rule20DTO>(rule20List.FirstOrDefault());
                        viewModel.RuleSetDTO.Rule20DTO = rule20DTO;
                    }
                }
                else
                    throw new TTException("Hizmet seçimi yapmadınız ya da SUT Kodu girilmemiş bir hizmet seçtiniz.");

                return viewModel;
            }
        }

        public static SutRuleEngineDefinitionFormViewModel SaveSUTRules(SutRuleEngineDefinitionFormViewModel viewModel)
        {
            List<IRuleDTO> addedRules = new List<IRuleDTO>();
            List<IRuleDTO> modifiedRules = new List<IRuleDTO>();
            List<IRuleDTO> deletedRules = new List<IRuleDTO>();

            foreach (var item in viewModel.RuleSetDTO.GetType().GetProperties())
            {
                var rule = item.GetValue(viewModel.RuleSetDTO) as IRuleDTO;
                switch (rule.EntityState)
                {
                    case EntityStateEnum.Added:
                        addedRules.Add(item.GetValue(viewModel.RuleSetDTO) as IRuleDTO);
                        break;
                    case EntityStateEnum.Deleted:
                        deletedRules.Add(item.GetValue(viewModel.RuleSetDTO) as IRuleDTO);
                        break;
                    case EntityStateEnum.Modified:
                        modifiedRules.Add(item.GetValue(viewModel.RuleSetDTO) as IRuleDTO);
                        break;
                    case EntityStateEnum.Unchanged:

                        break;
                    case EntityStateEnum.Cancelled:

                        break;
                    default:
                        break;
                }
            }

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                IEnumerable<SohaRuleGroup> sohaRuleGroupList = objectContext.QueryObjects<SohaRuleGroup>("");
                if (sohaRuleGroupList == null || sohaRuleGroupList.Count() == 0)
                    return new SutRuleEngineDefinitionFormViewModel()
                    {
                        SUTCode = viewModel.SUTCode,
                        ErrorMessage = "SUT Kural Grupları mevcut değil. Kural tanımı yapabilmek için kural gruplarının aktarılması gerekmektedir."
                    };

                foreach (var rule in addedRules)
                {
                    #region AddRule1
                    //Rule1'in kayıt edilme şekli sebebi ile tüm işlemleri sadece Added durumunda yapılacak 
                    if (rule is Rule1DTO)
                    {
                        SohaRuleGroup rule1Group = SohaRuleGroup.GetSohaRuleGroupByType(sohaRuleGroupList, SohaRuleGroupEnum.Rule1);
                        var rule1DTO = (rule as Rule1DTO);

                        if (rule1DTO.Rule1DataSource.Count > 0)
                        {
                            List<Guid> straightRuleGuidList = rule1DTO.Rule1DataSource.Select(x => x.ObjectId).ToList();
                            List<SohaRule> straightRuleList = objectContext.QueryObjects<SohaRule>(Common.CreateFilterExpressionOfGuidList("", "", straightRuleGuidList)).ToList();

                            List<string> reverseRuleCodeList = rule1DTO.Rule1DataSource.Select(x => x.ProcedureCode2).ToList();
                            List<SohaRule> reverseSohaRuleList = objectContext.QueryObjects<SohaRule>("RULEGROUP = '" + rule1Group.ObjectID + "' AND " + Common.CreateFilterExpressionOfStringList("PROCEDURECODE", reverseRuleCodeList)).ToList();
                            var reverseRuleSetList = viewModel.GetRuleSet(reverseSohaRuleList);
                            List<Rule1> reverseRuleListOfCurrentRule = reverseRuleSetList.Rules.OfType<Rule1>().Where(x => x.ProcedureCode2 == rule1DTO.Rule1DataSource[0].ProcedureCode).ToList();

                            //Modify BlockRequest and Active of all rules
                            foreach (var straightRule in straightRuleList)
                            {
                                var data = rule1DTO.Rule1DataSource.FirstOrDefault(x => x.ObjectId == straightRule.ObjectID);
                                if (data.EntityState == EntityStateEnum.Deleted)
                                    straightRule.IsDeleted = true;
                                else
                                {
                                    straightRule.BlockRequest = rule1DTO.BlockRequest;
                                    straightRule.Active = rule1DTO.Active;
                                }

                            }

                            foreach (var reverseRuleContent in reverseRuleListOfCurrentRule)
                            {
                                var reverseRule = reverseSohaRuleList.FirstOrDefault(x => x.ObjectID == reverseRuleContent.ObjectId);
                                var data = rule1DTO.Rule1DataSource.FirstOrDefault(x => x.ProcedureCode2 == reverseRuleContent.ProcedureCode);
                                if (data.EntityState == EntityStateEnum.Deleted)
                                    reverseRule.IsDeleted = true;
                                else
                                {
                                    reverseRule.BlockRequest = rule1DTO.BlockRequest;
                                    reverseRule.Active = rule1DTO.Active;
                                }
                            }

                            //Add new rules
                            List<string> addNewRuleCodeList = rule1DTO.Rule1DataSource.Where(x => x.EntityState == EntityStateEnum.Added).Select(x => x.ProcedureCode2).ToList();
                            foreach (string code in addNewRuleCodeList)
                            {

                                var newStraightRule = viewModel.CreateNewSohaRuleAndXmlContent<Rule1>(objectContext, rule1DTO, viewModel.SUTCode, rule1Group);
                                SohaRule newStraightSohaRule = newStraightRule.SohaRule;
                                Rule1 straightRule1Xml = newStraightRule.XmlRule as Rule1;
                                straightRule1Xml.ProcedureCode2 = code;
                                newStraightSohaRule.Content = Common.SerializeToString(straightRule1Xml);

                                var newReverseRule = viewModel.CreateNewSohaRuleAndXmlContent<Rule1>(objectContext, rule1DTO, code, rule1Group);
                                SohaRule newReverseSohaRule = newReverseRule.SohaRule;
                                Rule1 reverseRule1Xml = newReverseRule.XmlRule as Rule1;
                                reverseRule1Xml.ProcedureCode2 = viewModel.SUTCode;
                                newReverseSohaRule.Content = Common.SerializeToString(reverseRule1Xml);
                            }
                        }
                    }
                    #endregion AddRule1

                    #region AddRule2
                    else if (rule is Rule2DTO)
                    {
                        var rule2DTO = (rule as Rule2DTO);
                        SohaRuleGroup rule2Group = SohaRuleGroup.GetSohaRuleGroupByType(sohaRuleGroupList, SohaRuleGroupEnum.Rule2);
                        if (rule2DTO.ObjectId != null && rule2DTO.ObjectId != Guid.Empty)
                        {
                            var deletedRule2 = objectContext.GetObject<SohaRule>(rule2DTO.ObjectId);
                            deletedRule2.IsDeleted = true;
                        }

                        var newRule = viewModel.CreateNewSohaRuleAndXmlContent<Rule2>(objectContext, rule2DTO, viewModel.SUTCode, rule2Group);

                        SohaRule newRule2 = newRule.SohaRule;
                        Rule2 rule2Xml = newRule.XmlRule as Rule2;
                        rule2Xml.BranchCodes = rule2DTO.BranchCodesAndNames.Select(x => x.Code).ToList();

                        newRule2.Content = Common.SerializeToString(rule2Xml);
                    }
                    #endregion AddRule2

                    #region AddRule3
                    else if (rule is Rule3DTO)
                    {
                        var rule3DTO = (rule as Rule3DTO);

                        rule3DTO.CheckErrors();

                        SohaRuleGroup rule3Group = SohaRuleGroup.GetSohaRuleGroupByType(sohaRuleGroupList, SohaRuleGroupEnum.Rule3);

                        if (rule3DTO.ObjectId != null && rule3DTO.ObjectId != Guid.Empty)
                        {
                            var deletedRule3 = objectContext.GetObject<SohaRule>(rule3DTO.ObjectId);
                            deletedRule3.IsDeleted = true;
                        }

                        var newRule = viewModel.CreateNewSohaRuleAndXmlContent<Rule3>(objectContext, rule3DTO, viewModel.SUTCode, rule3Group);

                        SohaRule newRule3 = newRule.SohaRule;
                        Rule3 rule3Xml = newRule.XmlRule as Rule3;
                        rule3Xml.MaxQuantity = rule3DTO.MaxQuantity.HasValue ? rule3DTO.MaxQuantity.Value : 0;
                        rule3Xml.NumOfDays = rule3DTO.NumOfDays.HasValue ? rule3DTO.NumOfDays.Value : 0;

                        newRule3.Content = Common.SerializeToString(rule3Xml);
                    }
                    #endregion AddRule3

                    #region AddRule5
                    else if (rule is Rule5DTO)
                    {
                        var rule5DTO = (rule as Rule5DTO);

                        rule5DTO.CheckErrors();

                        SohaRuleGroup rule5Group = SohaRuleGroup.GetSohaRuleGroupByType(sohaRuleGroupList, SohaRuleGroupEnum.Rule5);

                        if (rule5DTO.ObjectId != null && rule5DTO.ObjectId != Guid.Empty)
                        {
                            var deletedRule5 = objectContext.GetObject<SohaRule>(rule5DTO.ObjectId);
                            deletedRule5.IsDeleted = true;
                        }

                        var newRule = viewModel.CreateNewSohaRuleAndXmlContent<Rule5>(objectContext, rule5DTO, viewModel.SUTCode, rule5Group);

                        SohaRule newRule5 = newRule.SohaRule;
                        Rule5 rule5Xml = newRule.XmlRule as Rule5;
                        rule5Xml.MinAge = rule5DTO.MinAge.HasValue ? rule5DTO.MinAge.Value : 1;
                        rule5Xml.MaxAge = rule5DTO.MaxAge.HasValue ? rule5DTO.MaxAge.Value : 2;

                        newRule5.Content = Common.SerializeToString(rule5Xml);
                    }
                    #endregion AddRule5

                    #region AddRule7
                    else if (rule is Rule7DTO)
                    {
                        var rule7DTO = (rule as Rule7DTO);

                        SohaRuleGroup rule7Group = SohaRuleGroup.GetSohaRuleGroupByType(sohaRuleGroupList, SohaRuleGroupEnum.Rule7);
                        if (rule7DTO.ObjectId != null && rule7DTO.ObjectId != Guid.Empty)
                        {
                            var deletedRule7 = objectContext.GetObject<SohaRule>(rule7DTO.ObjectId);
                            deletedRule7.IsDeleted = true;
                        }

                        var newRule = viewModel.CreateNewSohaRuleAndXmlContent<Rule7>(objectContext, rule7DTO, viewModel.SUTCode, rule7Group);

                        SohaRule newRule7 = newRule.SohaRule;
                        Rule7 rule7Xml = newRule.XmlRule as Rule7;
                        rule7Xml.Icd10List = rule7DTO.Icd10ListAndNames.Select(x => x.Code).ToList();

                        newRule7.Content = Common.SerializeToString(rule7Xml);
                    }
                    #endregion AddRule7

                    #region AddRule16
                    else if (rule is Rule16DTO)
                    {
                        var rule16DTO = (rule as Rule16DTO);

                        SohaRuleGroup rule16Group = SohaRuleGroup.GetSohaRuleGroupByType(sohaRuleGroupList, SohaRuleGroupEnum.Rule16);
                        if (rule16DTO.ObjectId != null && rule16DTO.ObjectId != Guid.Empty)
                        {
                            var deletedRule16 = objectContext.GetObject<SohaRule>(rule16DTO.ObjectId);
                            deletedRule16.IsDeleted = true;
                        }

                        var newRule = viewModel.CreateNewSohaRuleAndXmlContent<Rule16>(objectContext, rule16DTO, viewModel.SUTCode, rule16Group);

                        SohaRule newRule16 = newRule.SohaRule;
                        Rule16 rule16Xml = newRule.XmlRule as Rule16;
                        rule16Xml.ProcedureList = rule16DTO.ProcedureNameAndCodes.Select(x => x.Code).ToList();

                        newRule16.Content = Common.SerializeToString(rule16Xml);
                    }
                    #endregion AddRule16

                    #region AddRule17
                    else if (rule is Rule17DTO)
                    {
                        var rule17DTO = (rule as Rule17DTO);

                        if (rule17DTO.LifeTimeMaxQuantity.HasValue && rule17DTO.LifeTimeMaxQuantity == 0)
                        {
                            throw new TTException("Ömür boyu adet kontrolü için sıfırdan büyük bir değer girilmelidir.");
                        }

                        SohaRuleGroup rule17Group = SohaRuleGroup.GetSohaRuleGroupByType(sohaRuleGroupList, SohaRuleGroupEnum.Rule17);

                        if (rule17DTO.ObjectId != null && rule17DTO.ObjectId != Guid.Empty)
                        {
                            var deletedRule17 = objectContext.GetObject<SohaRule>(rule17DTO.ObjectId);
                            deletedRule17.IsDeleted = true;
                        }

                        var newRule = viewModel.CreateNewSohaRuleAndXmlContent<Rule17>(objectContext, rule17DTO, viewModel.SUTCode, rule17Group);

                        SohaRule newRule17 = newRule.SohaRule;
                        Rule17 rule17Xml = newRule.XmlRule as Rule17;
                        rule17Xml.LifeTimeMaxQuantity = rule17DTO.LifeTimeMaxQuantity.HasValue ? rule17DTO.LifeTimeMaxQuantity.Value : 1;

                        newRule17.Content = Common.SerializeToString(rule17Xml);
                    }
                    #endregion AddRule17

                    #region AddRule18
                    else if (rule is Rule18DTO)
                    {
                        var rule18DTO = (rule as Rule18DTO);

                        SohaRuleGroup rule18Group = SohaRuleGroup.GetSohaRuleGroupByType(sohaRuleGroupList, SohaRuleGroupEnum.Rule18);

                        if (rule18DTO.ObjectId != null && rule18DTO.ObjectId != Guid.Empty)
                        {
                            var deletedRule18 = objectContext.GetObject<SohaRule>(rule18DTO.ObjectId);
                            deletedRule18.IsDeleted = true;
                        }

                        var newRule = viewModel.CreateNewSohaRuleAndXmlContent<Rule18>(objectContext, rule18DTO, viewModel.SUTCode, rule18Group);

                        SohaRule newRule18 = newRule.SohaRule;
                        Rule18 rule18Xml = newRule.XmlRule as Rule18;
                        rule18Xml.Gender = rule18DTO.Gender;

                        newRule18.Content = Common.SerializeToString(rule18Xml);
                    }
                    #endregion AddRule18

                    #region AddRule20
                    else if (rule is Rule20DTO)
                    {
                        var rule20DTO = (rule as Rule20DTO);

                        rule20DTO.CheckErrors();

                        SohaRuleGroup rule20Group = SohaRuleGroup.GetSohaRuleGroupByType(sohaRuleGroupList, SohaRuleGroupEnum.Rule20);

                        if (rule20DTO.ObjectId != null && rule20DTO.ObjectId != Guid.Empty)
                        {
                            var deletedRule20 = objectContext.GetObject<SohaRule>(rule20DTO.ObjectId);
                            deletedRule20.IsDeleted = true;
                        }

                        var newRule = viewModel.CreateNewSohaRuleAndXmlContent<Rule20>(objectContext, rule20DTO, viewModel.SUTCode, rule20Group);

                        SohaRule newRule20 = newRule.SohaRule;
                        Rule20 rule20Xml = newRule.XmlRule as Rule20;
                        rule20Xml.TreatmentMaxQuantity = rule20DTO.TreatmentMaxQuantity.HasValue ? rule20DTO.TreatmentMaxQuantity.Value : 1;

                        newRule20.Content = Common.SerializeToString(rule20Xml);
                    }
                    #endregion AddRule20
                }

                if (deletedRules.Count > 0)
                {
                    List<SohaRule> deleteSohaRuleList = objectContext.QueryObjects<SohaRule>(Common.CreateFilterExpressionOfGuidList("", "", deletedRules.Select(x => x.ObjectId).ToList())).ToList();
                    deleteSohaRuleList.ForEach(x => x.IsDeleted = true);
                }

                if (modifiedRules.Count > 0)
                {
                    IEnumerable<SohaRule> modifySohaRuleList = objectContext.QueryObjects<SohaRule>(Common.CreateFilterExpressionOfGuidList("", "", modifiedRules.Select(x => x.ObjectId).ToList())).ToList();

                    modifySohaRuleList.All(x =>
                    {
                        x.Active = modifiedRules.FirstOrDefault(y => y.ObjectId == x.ObjectID).Active;
                        x.BlockRequest = modifiedRules.FirstOrDefault(y => y.ObjectId == x.ObjectID).BlockRequest;
                        return true;
                    });
                }
                objectContext.Save();

                return GetSUTRules(viewModel.SUTCode);
            }
        }

    }

    public class CreateNewSohaRule
    {
        public SohaRule SohaRule { get; set; }
        public IRule XmlRule { get; set; }
    }

    public class RuleSetDTO
    {
        public Rule1DTO Rule1DTO { get; set; } = new Rule1DTO();
        public Rule2DTO Rule2DTO { get; set; } = new Rule2DTO();
        public Rule3DTO Rule3DTO { get; set; } = new Rule3DTO();
        public Rule5DTO Rule5DTO { get; set; } = new Rule5DTO();
        public Rule7DTO Rule7DTO { get; set; } = new Rule7DTO();
        public Rule16DTO Rule16DTO { get; set; } = new Rule16DTO();
        public Rule17DTO Rule17DTO { get; set; } = new Rule17DTO();
        public Rule18DTO Rule18DTO { get; set; } = new Rule18DTO();
        public Rule20DTO Rule20DTO { get; set; } = new Rule20DTO();
    }

    public class Rule1DTO : IRuleDTO
    {
        public List<Rule1DataSourceObject> Rule1DataSource { get; set; } = new List<Rule1DataSourceObject>();

        public Guid ObjectId { get; set; }
        public Guid GroupId { get; set; }
        public string ProcedureCode { get; set; }
        public EntityStateEnum EntityState { get; set; } = EntityStateEnum.Unchanged;

        public bool? _blockRequest;

        public bool? BlockRequest
        {
            get { return _blockRequest; }
            set { _blockRequest = value; }
        }

        public bool? _active;

        public bool? Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public void CheckErrors()
        {

        }
    }

    public class Rule1DataSourceObject : Rule1
    {
        //Yasaklı işlemin adı
        public string ProcedureName2 { get; set; }
        public EntityStateEnum EntityState { get; set; } = EntityStateEnum.Unchanged;

    }

    public class Rule2DTO : IRuleDTO
    {
        public Guid ObjectId { get; set; }
        public Guid GroupId { get; set; }
        public string ProcedureCode { get; set; }
        public EntityStateEnum EntityState { get; set; } = EntityStateEnum.Unchanged;

        public bool? _blockRequest;

        public bool? BlockRequest
        {
            get { return _blockRequest; }
            set { _blockRequest = value; }
        }

        public bool? _active;

        public bool? Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public List<string> BranchCodes { get; set; }
        public List<listboxObject> BranchCodesAndNames { get; set; } = new List<listboxObject>();

        public void CheckErrors()
        {

        }
    }

    public class Rule3DTO : IRuleDTO
    {
        public Guid ObjectId { get; set; }
        public Guid GroupId { get; set; }
        public string ProcedureCode { get; set; }
        public EntityStateEnum EntityState { get; set; } = EntityStateEnum.Unchanged;

        public bool? _blockRequest;

        public bool? BlockRequest
        {
            get { return _blockRequest; }
            set { _blockRequest = value; }
        }

        public bool? _active;

        public bool? Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public int? _numofdays;

        public int? NumOfDays
        {
            get { return _numofdays; }
            set { _numofdays = value; }
        }


        public int? _maxquantity;

        public int? MaxQuantity
        {
            get { return _maxquantity; }
            set { _maxquantity = value; }
        }
        public void CheckErrors()
        {
            NumOfDays = NumOfDays.HasValue ? NumOfDays.Value : 0;
            MaxQuantity = MaxQuantity.HasValue ? MaxQuantity.Value : 0;

            if (NumOfDays.Value <= 0)
                throw new TTException("Periyodik Gün Sınırı sıfırdan büyük olmalıdır.");
            if (MaxQuantity.Value <= 0)
                throw new TTException("İşlem Adedi sıfırdan büyük olmalıdır.");
        }
    }

    public class Rule5DTO : IRuleDTO
    {
        public Guid ObjectId { get; set; }
        public Guid GroupId { get; set; }
        public string ProcedureCode { get; set; }

        public int? _minAge;

        public int? MinAge
        {
            get { return _minAge; }
            set { _minAge = value; }
        }


        public int? _maxAge;

        public int? MaxAge
        {
            get { return _maxAge; }
            set { _maxAge = value; }
        }

        public bool? _blockRequest;

        public bool? BlockRequest
        {
            get { return _blockRequest; }
            set { _blockRequest = value; }
        }

        public bool? _active;

        public bool? Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public EntityStateEnum EntityState { get; set; } = EntityStateEnum.Unchanged;

        public void CheckErrors()
        {
            MinAge = MinAge.HasValue ? MinAge.Value : 0;
            MaxAge = MaxAge.HasValue ? MaxAge.Value : 0;

            if (MaxAge.Value <= MinAge.Value)
                throw new TTException("Mininum yaş kriteri maksimum yaş kriterinden küçük olamalı.");
            if (MaxAge < 0)
                throw new TTException("Mininum yaş kriteri sıfır veya sıfırdan büyük olmalıdır.");
            if (MaxAge <= 0)
                throw new TTException("Maksimum yaş kriteri sıfırdan büyük olmalıdır.");
        }
    }

    public class Rule7DTO : IRuleDTO
    {
        public List<listboxObject> Icd10ListAndNames { get; set; }
        public List<string> Icd10List { get; set; }

        public Guid ObjectId { get; set; }
        public Guid GroupId { get; set; }
        public string ProcedureCode { get; set; }
        public EntityStateEnum EntityState { get; set; } = EntityStateEnum.Unchanged;

        public bool? _blockRequest;

        public bool? BlockRequest
        {
            get { return _blockRequest; }
            set { _blockRequest = value; }
        }

        public bool? _active;

        public bool? Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public void CheckErrors()
        {

        }
    }

    public class Rule16DTO : IRuleDTO
    {
        public List<string> ProcedureList { get; set; }
        public List<listboxObject> ProcedureNameAndCodes { get; set; } = new List<listboxObject>();

        public Guid ObjectId { get; set; }
        public Guid GroupId { get; set; }
        public string ProcedureCode { get; set; }
        public EntityStateEnum EntityState { get; set; } = EntityStateEnum.Unchanged;

        public bool? _blockRequest;

        public bool? BlockRequest
        {
            get { return _blockRequest; }
            set { _blockRequest = value; }
        }

        public bool? _active;

        public bool? Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public void CheckErrors()
        {

        }
    }

    public class Rule17DTO : IRuleDTO
    {
        public int? _lifeTimeMaxQuantity;

        public int? LifeTimeMaxQuantity
        {
            get { return _lifeTimeMaxQuantity; }
            set { _lifeTimeMaxQuantity = value; }
        }

        public Guid ObjectId { get; set; }
        public Guid GroupId { get; set; }
        public string ProcedureCode { get; set; }
        public EntityStateEnum EntityState { get; set; } = EntityStateEnum.Unchanged;

        public bool? _blockRequest;

        public bool? BlockRequest
        {
            get { return _blockRequest; }
            set { _blockRequest = value; }
        }

        public bool? _active;

        public bool? Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public void CheckErrors()
        {

        }
    }

    public class Rule18DTO : IRuleDTO
    {

        public string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public Guid ObjectId { get; set; }
        public Guid GroupId { get; set; }
        public string ProcedureCode { get; set; }
        public EntityStateEnum EntityState { get; set; } = EntityStateEnum.Unchanged;

        public bool? _blockRequest;

        public bool? BlockRequest
        {
            get { return _blockRequest; }
            set { _blockRequest = value; }
        }

        public bool? _active;

        public bool? Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public void CheckErrors()
        {

        }
    }

    public class Rule20DTO : IRuleDTO
    {
        public int? _treatmentMaxQuantity;

        public int? TreatmentMaxQuantity
        {
            get { return _treatmentMaxQuantity; }
            set { _treatmentMaxQuantity = value; }
        }
        public Guid ObjectId { get; set; }
        public Guid GroupId { get; set; }
        public string ProcedureCode { get; set; }
        public EntityStateEnum EntityState { get; set; } = EntityStateEnum.Unchanged;

        public bool? _blockRequest;

        public bool? BlockRequest
        {
            get { return _blockRequest; }
            set { _blockRequest = value; }
        }

        public bool? _active;

        public bool? Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public void CheckErrors()
        {
            TreatmentMaxQuantity = TreatmentMaxQuantity.HasValue ? TreatmentMaxQuantity.Value : 0;
            if (TreatmentMaxQuantity.Value <= 0)
            {
                throw new TTException("Kabul Bazında İşlem Adedi sıfırdan büyük olmalıdır.");
            }
        }
    }

    public interface IRuleDTO
    {
        Guid ObjectId { get; set; }
        Guid GroupId { get; set; }
        string ProcedureCode { get; set; }
        bool? BlockRequest { get; set; }
        bool? Active { get; set; }
        EntityStateEnum EntityState { get; set; }
        void CheckErrors();
    }
}
