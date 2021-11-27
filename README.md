# Overview

Dace23 is a UI component library for Console Applications, designed to format the console like a classic mainframe eyesore, but also allow quickly-configurable form controls.

This repo is a demonstration of its general functionality and what Fields, Pages, and Screens are available.

# How to use

Dace23 must first be initialised so it can manage the console buffer:

```
Dace23.Init();
```

Screens can be declared, containing Pages:

```
var screen = new Screen("Example-Screen");

var page = new Page("Example-Page");
var page2 = new Page("Example-Page2");

screen.AddPages(page, page2);
```

Fields can then be placed on the Page, such as TextBoxes and Labels:

```
page.AddFields(
    new TextBox(12, 25, "Example editable TextBox"),
    new Label(12, 45, "Example label text"));
```

After configuring the Screen and its Pages, calling '.Start()' will prompt and handle user input, returning when either the screen's active Page is Exited or Submitted. The result is a ScreenResult object with a reference to the current Page's data (ActivePage) and the selected Field (ActiveField).

Some variants of Screen (see _Screens_ below) generate default Pages for you. For example, using a MessageScreen to display a simple message condenses this:

```
var screen = new Screen("Example-Message");
var page = new Page("Example-Message");
var message = new Label(10, 10, $"You picked {result.ActiveField.Text}");

screen.AddPages(page);
page.AddFields(message);

screen.Start();
```

To this:

```
new MessageScreen("Example-Message", $"You picked {result.ActiveField.Text}").Start();
```

# Components

## Screens

Screens are considered the 'upper-level' of the UI, presenting and managing a collection of Pages.

Examples include:

  - **FormScreen**: generates FormPages, based on input fields,
  - **SelectionScreen**: generates SelectionPages, based on input options and display mode
  - **MessageScreen**: generates a single MessagePage
  - **ScrollBoxScreen**: generates a single ScrollBoxPage
  - **TextBoxScreen**: generates a single TextBoxPage
  - **Screen**: the default, empty screen

## Pages

Pages contain a collection of Fields to present to the user.

Examples include:

  - **FormPage**: auto-generates a form, based on input fields
  - **MessagePage**: displays a message
  - **SelectionPage**: auto-generates buttons, based on input options and display mode
  - **ScrollBoxPage**: displays text in a scrollable format
  - **TextBoxPage**: displays text in a scrollable and editable format
  - **Page**: the default, empty page

## Fields

Fields represent UI elements, such as an editable TextBox, a static Label, or a triggered DropDownBox, positioned on a Page.

Examples include:

  - **Label** (read-only text)
  - **TextBox** (editable - single or multi-line)
  - **ScrollBox** (read-only TextBox)
  - **CheckBox** (pressing Space toggles 'X' on or off)
  - **Button** (acts like a selectable label)
  - **DropDownBox** (pressing Space triggers an options dialog, Enter commits selected)

# Controls

As alluded to at the bottom of the UI, these are the base controls:

```
 F1-SUBMIT  F2-EDIT  F3-COPY  F5-REFRESH  (S)F6-PAGE  TAB-FIELD  ARRWS-SCROLL
```

The full list includes:

  - F1 and ESC will return the ScreenResult to the caller of the screen's '.Start()' method.
  - F2 will edit the fields's selected text, provided it is editable. Ctrl+V (paste) is also supported in Edit mode.
  - F3 will copy the selected Field's contents to the Clipboard
  - F5 manually refreshes the UI
  - F6 advances to the next page of the screen. With the Shift modifier, this will go back a page.
  - TAB will tab to the next selectable field
  - UP/DOWN ARROWS allow scrolling through text, where there are multiple lines
  - SPACE toggles the behaviour of fields in Yellow, such as displaying Dropdown options or crossing a CheckBox
  - ENTER commits the changes of an Edit or Dropdown selection

# Screenshots

Presenting User Data (courtesy of this API: https://randomuser.me/):
![image](https://user-images.githubusercontent.com/70886027/143666679-6cf1f456-a20d-440d-94d8-50900ebb0f68.png)

Presenting Cocktail Data (courtesy of this API: https://www.thecocktaildb.com/api.php)

![image](https://user-images.githubusercontent.com/70886027/143666722-a9c84777-402a-48be-8d74-fb150d80f0c5.png)

Editing structured XML / JSON:

![image](https://user-images.githubusercontent.com/70886027/143666769-ec9a89cc-817f-4d5a-add7-dd10c4e97c1a.png)




