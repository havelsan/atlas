using RuleChecker.Engine.RuleCheckers;
using RuleChecker.Interface;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RuleChecker.Engine
{
    [XmlRoot(RuleXmlTag.RuleSet)]
    public class RuleSet : IRuleSet
    {
        [XmlArray(RuleXmlTag.Rules)]
        [XmlArrayItem(RuleXmlTag.Rule1, typeof(Rule1))]
        [XmlArrayItem(RuleXmlTag.Rule2, typeof(Rule2))]
        [XmlArrayItem(RuleXmlTag.Rule3, typeof(Rule3))]
        [XmlArrayItem(RuleXmlTag.Rule4, typeof(Rule4))]
        [XmlArrayItem(RuleXmlTag.Rule5, typeof(Rule5))]
        [XmlArrayItem(RuleXmlTag.Rule6, typeof(Rule6))]
        [XmlArrayItem(RuleXmlTag.Rule7, typeof(Rule7))]
        [XmlArrayItem(RuleXmlTag.Rule8, typeof(Rule8))]
        [XmlArrayItem(RuleXmlTag.Rule9, typeof(Rule9))]
        [XmlArrayItem(RuleXmlTag.Rule10, typeof(Rule10))]
        [XmlArrayItem(RuleXmlTag.Rule11, typeof(Rule11))]
        [XmlArrayItem(RuleXmlTag.Rule15, typeof(Rule15))]
        [XmlArrayItem(RuleXmlTag.Rule16, typeof(Rule16))]
        [XmlArrayItem(RuleXmlTag.Rule17, typeof(Rule17))]
        [XmlArrayItem(RuleXmlTag.Rule18, typeof(Rule18))]
        [XmlArrayItem(RuleXmlTag.Rule19, typeof(Rule19))]
        [XmlArrayItem(RuleXmlTag.Rule20, typeof(Rule20))]
        public List<object> Rules { get; set; }
    }
}
