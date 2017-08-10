# FluentFrontend

This project is the spiritual successor to [FluentBootstrap](https://github.com/daveaglick/FluentBootstrap). It was built from scratch and has many differences from that previous project, including an expanded scope.

The intent is to provide a fully general code-based HTML generation capability along with optional support for:
* [Bootstrap](http://getbootstrap.com)
* [Bulma](http://bulma.io)
* [Vue.js](https://vuejs.org)
* [Element](http://element.eleme.io/#/en-US)

It also comes with a more flexible adapter architecture that makes it easier to support different frameworks and platforms:
* ASP.NET MVC
* ASP.NET WebPages
* ASP.NET Core MVC
* ASP.NET Core Razor Pages
* Directly to any `TextWriter`

Some other differences include:
* All the underlying libraries target netstandard
* Less crazy generics so it's easier to maintain and enhance (though there's still some)
* All elements are created from the helper so they no longer have to track which elements make sense as children (that's up to you now)
* An internal element stack is no longer maintained
* All elements are now immutable
* Broader support for general HTML

This project is under very active development and is not ready for public use yet. An official release will be announced later. That said, feel free to look and play around.