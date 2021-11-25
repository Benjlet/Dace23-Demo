using Dace23.Screens;
using Dace23.Pages;
using System.Collections.Generic;
using Dace23.Fields;

namespace Dace23.Demo.UI
{
    class ExamplesScreen : IScreen
    {
        private readonly Screen _demoScreen;

        public ExamplesScreen()
        {
            _demoScreen = CreateDemoScreen();
        }

        public void Start()
        {
            _demoScreen.Start();
        }

        private Screen CreateDemoScreen()
        {
            var demoScreen = new Screen(Constants.ExamplesScreenName);

            demoScreen.AddPages(
                CreateFormPage(),
                CreateTextBoxPage(),
                CreateMessagePage(),
                CreateScrollBoxPage());

            return demoScreen;
        }

        private FormPage CreateFormPage()
        {
            return new FormPage("AUTO-FORM-PAGE", new List<FormPageField>()
            {
                new FormPageField("ACCOUNT-NO", "12345678"),
                new FormPageField("SORT-CODE", "01-02-03"),
                new FormPageField("PAN", "0123456789012345"),
                new FormPageField("CUST-NO", "0123456789"),
                new FormPageField("EXP-DAT", "10/99"),
                new FormPageField("EXPIRED", "N"),
                new FormPageField("REASON", "This is an example field that starts to scroll as there is a lot of superfuous text that would cause scrolling behaviour."),
                new FormPageField("EXAMPLE", "0123456"),
                new FormPageField("MCHT-CODE", "12345")
            });
        }

        private TextBoxPage CreateTextBoxPage()
        {
            return new TextBoxPage("TEXT-BOX-PAGE (JSON)",
                @"{ ""glossary"": { ""title"": ""example glossary"", ""GlossDiv"": { ""title"": ""S"", ""GlossList"": { ""GlossEntry"": { ""ID"": ""SGML"", ""SortAs"": ""SGML"", ""GlossTerm"": ""Standard Generalized Markup Language"", ""Acronym"": " +
                @"""SGML"", ""Abbrev"": ""ISO 8879:1986"", ""GlossDef"": { ""para"": ""A meta-markup language, used to create markup languages such as DocBook."", ""GlossSeeAlso"": [""GML"", ""XML""] }, ""GlossSee"": ""markup"" } } } } }"
                , TextFormat.Json);
        }

        private MessagePage CreateMessagePage()
        {
            return new MessagePage("MESSAGE-PAGE", "This is an example MessagePage with a single message.");
        }

        private ScrollBoxPage CreateScrollBoxPage()
        {
            return new ScrollBoxPage("SCROLL-TEXT-PAGE (XML)",
                "<breakfast_menu><food><name>Belgian Waffles</name><price>$5.95</price><description>Two of our famous Belgian Waffles with plenty of real maple syrup</description><calories>650</calories></food><food><name>Strawberry Belgian Waffles</name>" +
                "<price>$7.95</price><description>Light Belgian waffles covered with strawberries and whipped cream</description><calories>900</calories></food><food><name>Berry-Berry Belgian Waffles</name><price>$8.95</price>" +
                "<description>Light Belgian waffles covered with an assortment of fresh berries and whipped cream</description><calories>900</calories></food><food><name>French Toast</name><price>$4.50</price>" +
                "<description>Thick slices made from our homemade sourdough bread</description><calories>600</calories></food><food><name>Homestyle Breakfast</name><price>$6.95</price>" +
                "<description>Two eggs, bacon or sausage, toast, and our ever-popular hash browns</description><calories>950</calories></food></breakfast_menu>"
                , TextFormat.Xml);
        }
    }
}
