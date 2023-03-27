using RuleChecker.Interface;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RuleChecker.Engine
{
    public class RuleSetLoader : IRuleSetLoader
    {

        private readonly IRuleRepository _ruleRepository;

        public RuleSetLoader(IRuleRepository ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }

        private RuleSet _ruleSet;
        public IRuleSet RuleSet
        {
            get
            {
                _ruleSet = LoadRuleSet();

                return _ruleSet;
            }
        }

        private RuleSet LoadRuleSet()
        {
            var ruleList = _ruleRepository.RuleList();

            var query1 = from r in ruleList
                         select XElement.Parse(r.Content);

            var elmRuleSet = new XElement(RuleXmlTag.RuleSet);

            var elmRules = new XElement(RuleXmlTag.Rules);

            elmRuleSet.Add(elmRules);

            elmRules.Add(query1.ToArray());

            var serializer = new XmlSerializer(typeof(RuleSet));

            using (var reader = elmRuleSet.CreateReader())
            {
                var ruleSet = serializer.Deserialize(reader) as RuleSet;

                return ruleSet;
            }
        }


    }
}
