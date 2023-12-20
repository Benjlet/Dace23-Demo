# Overview

Dace23 is a transactional, text-based UI component library for Console Applications, designed to behave like classic payments interfaces:

![image](https://user-images.githubusercontent.com/70886027/144134718-822d9ab9-63da-4a1c-a257-3ff3a1dc0a7e.png)

This repo is a demonstration of its general functionality and visuals.

The latest version of Dace23 is available via [NuGet](https://www.nuget.org/packages/Dace23/).

For an interactive console terminal with cursor support, you could try 'Gui.cs':
https://github.com/gui-cs/Terminal.Gui

# How to use

Dace23 must first be initialised so it can manage the console buffer:

```
ConsoleUI.Init();
```

Screens can be declared, containing Pages:

```
Screen screen = new();

Page page = new("Example-Page");
Page page2 = new("Example-Page2");

screen.AddPages(page, page2);
screen.Start();
```

Fields can then be placed on the Page, such as TextBoxes and Labels:

```
page.AddFields(
    new TextBox(Pos.On(12, 25), "Example editable TextBox"),
    new Label(Pos.On(12, 45), "Example label text"));
```

After configuring the Screen and its Pages, calling ```.Start()``` will prompt and handle user input, returning when the screen is exited.

# Fields

'Fields' represent UI elements, such as an editable TextBox, a static Label, or a triggered DropDownBox, positioned on a Page.

Examples include:

  - **Border** (read-only text border)
  - **Button** (acts like a selectable label - you can optionally assign an Action event, such as navigating to another page)
  - **CheckBox** (pressing Space toggles 'X' on or off - you can optionally assign a Check/Uncheck event)
  - **DateBox** (pressing Space triggers the date-picker UI; move the cursor with the arrow keys and press Enter to interact)
  - **DropDownBox** (pressing Space triggers an options dialog; Enter commits selected)
  - **GroupBox** (read-only text border with a title)
  - **Label** (read-only text)
  - **NumberBox** (pressing Space triggers the ability to increment/decrement the value with the arrow keys)
  - **ScrollBox** (read-only TextBox)
  - **TextBox** (editable - single or multi-line)
  - **TimeBox** (pressing Space triggers the time-selector UI; use the arrow keys to toggle between fields and increment then, Enter to commit)

# Key Controls

As alluded to at the bottom of the UI, these are the base controls:

```
F1-SUBMIT  F2-EDIT  (S)F3-COPY  F5-REFRESH  (S)F6-PAGE  TAB-FIELD  F12-CNTLS
```

Cursor input is not supported - that would be far too user friendly.

The full list includes:

  - F1 will submit the page, triggering a Submit event if a Button was selected
  - F2 will edit the fields's selected text, provided that it is editable
  - F3 will copy the selected Field's contents to the Clipboard as shown (truncated). The shift modifier will copy without formatting applied.
  - F5 forces a re-draw (refresh) of the UI
  - F6 advances to the next page of the screen or, with the Shift modifier, back a page
  - TAB will tab to the next selectable field or, with the Shift modifier, the previous selectable field
  - ARROW KEYS are used to scroll through text or as the cursor when interacting with controls, such as the TimeBox, DateBox, or NumberBox
  - SPACE toggles the behaviour of certain fields, such as displaying Dropdown options or checking a CheckBox
  - ENTER commits the changes of an edit or prompt selection, such as editing text, or selecting a dropdown option
  - DELETE during an edit action will delete a character - with the Shift modifier, the whole line will be cleared.
  - INSERT during an edit action will add an empty character - with the Shift modifier, a line will be added on a multi-line field.

# Template Screens

There are some template screens used to generate default pages and fieldsyou. For example, using a 'MessageScreen' to display a simple message condenses this:

```
Screen screen = new();
Page page = new("Example-Message");
Label message = new(Pos.On(10, 10), "This is a message");

screen.AddPages(page);
page.AddFields(message);

screen.Start();
```

To this:

```
new MessageScreen("Example-Message", "This is a message").Start();
```

Examples include:

  - **SelectionScreen**: generates SelectionPages, based on input options and display mode
  - **MessageScreen**: generates a single MessagePage
  - **ScrollBoxScreen**: generates a single ScrollBoxPage
  - **TextBoxScreen**: generates a single TextBoxPage
  - **Screen**: the default, empty screen

Calling ```.Start(1)``` on the screen will start the screen on a specific page.

# Screenshots

Presenting User Data (courtesy of [this](https://randomuser.me/) API):

![image](https://user-images.githubusercontent.com/70886027/143666679-6cf1f456-a20d-440d-94d8-50900ebb0f68.png)

Presenting Cocktail Data (courtesy of [this](https://www.thecocktaildb.com/api.php) API):

![image](https://user-images.githubusercontent.com/70886027/143666722-a9c84777-402a-48be-8d74-fb150d80f0c5.png)

Editing structured XML / JSON:

![image](https://user-images.githubusercontent.com/70886027/143666769-ec9a89cc-817f-4d5a-add7-dd10c4e97c1a.png)
