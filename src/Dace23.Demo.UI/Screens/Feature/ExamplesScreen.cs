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
            return new Screen(Constants.ExamplesScreenName)
            {
                Pages = new PageCollection()
                {
                    CreateFormPage(),
                    CreateTextBoxPage(),
                    CreateMessagePage(),
                    CreateScrollBoxPage(),
                    CreateInteractivePage(),
                    CreateBorderPage()
                }
            };
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

        private Page CreateBorderPage()
        {
            return new Page("BORDER PAGE")
            {
                Fields = new FieldCollection()
                {
                    new Label(7, 5, "THIS IS A SINGLE-LINED BORDER"),
                    new Border(6, 4, 9, 35, BorderType.Single),

                    new Label(10, 5, "THIS IS A DOUBLE-LINED BORDER"),
                    new Border(9, 4, 12, 35, BorderType.Double),

                    new Label(13, 7, "THIS IS A HASHED BORDER"),
                    new Border(12, 4, 15, 35, BorderType.Hashed),

                    new GroupBox(6, 40, 9, 80, "GROUP-BOX: DOUBLE/LEFT", BorderType.Double, Alignment.Left),
                    new GroupBox(9, 40, 12, 80, "GROUP-BOX: SINGLE/CENTRE", BorderType.Single, Alignment.Centre),
                    new GroupBox(12, 40, 15, 80, "GROUP-BOX: HASHED/RIGHT", BorderType.Hashed, Alignment.Right),
                }
            };
        }

        private Page CreateInteractivePage()
        {
            var interactivePage = new Page("INTERACTIVE PAGE");

            interactivePage.AddFields(
                new Label(4, 4, "CHECKBOX (PRESS SPACE TO CHECK):"),
                new CheckBox(4, 40, isChecked: false),

                new Label(7, 4, "DROPDOWN (PRESS SPACE TO EXPAND):"),
                new DropDownBox(7, 40, new string[] {
                    "OPT-ONE", "OPT-TWO", "OPT-THREE", "OPT-FOUR", "OPT-FIVE", "OPT-SIX", "OPT-SEVEN" }, 10),

                new Label(10, 4, "NUMBERBOX (UP-DOWN ARROWS):"),
                new NumberBox(10, 40, minimum: 0, maximum: 10, startValue: 1),

                new Label(13, 4, "BUTTON (F1):"),
                new Button(13, 40, "->", width: 10),

                new Label(16, 4, "TEXTBOX (F2):"),
                new TextBox(16, 40, "Editable Text"),

                new Label(19, 4, "SCROLLBOX (UP-DOWN ARROWS):"),
                new ScrollBox(19, 40, new string[] { "LINE-ONE", "LINE-TWO", "LINE-THREE" }, width: 14, height: 2));

            return interactivePage;
        }
    }
}
