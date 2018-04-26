define("app",["exports","aurelia-fetch-client","aurelia-framework"],function(e,n,t){"use strict";function o(e,n){if(!(e instanceof n))throw new TypeError("Cannot call a class as a function")}Object.defineProperty(e,"__esModule",{value:!0}),e.App=void 0;var i,a;e.App=(i=(0,t.inject)(n.HttpClient),i(a=function(){function e(n){var t=this;o(this,e),this.shipNames=[],this.patterns=["v A N","T v A N","A N","T N","V T A N","A V","V A","T N [of] N"],this.limit=4,this.count=1,this.length=22,this.alliterate=!1,this.showOptions=!1,this.handleKeyInput=function(e){"KeyB"==e.code&&e.ctrlKey&&(t.showOptions=!t.showOptions,ga("send",{hitType:"event",eventCategory:"Options",eventAction:"toggle",eventLabel:"Toggle options"}))},n.configure(function(e){e.withBaseUrl("/api/")}),this.http=n}return e.prototype.activate=function(){window.addEventListener("keypress",this.handleKeyInput,!1)},e.prototype.deactivate=function(){window.removeEventListener("keypress",this.handleKeyInput)},e.prototype.getSingleName=function(){var e=this;this.http.fetch("names/"+this.count+"/"+this.length+"/"+this.limit+"/"+this.alliterate+"/"+this.patterns+"/?_t="+(new Date).getTime()).then(function(e){return e.json()}).then(function(n){Array.isArray(n)?n.forEach(function(e){this.shipNames.unshift(e)},e):e.shipNames.unshift(n)}),ga("send",{hitType:"event",eventCategory:"Names",eventAction:"request",eventLabel:"Name request"})},e}())||a)}),define("environment",["exports"],function(e){"use strict";Object.defineProperty(e,"__esModule",{value:!0}),e.default={debug:!1,testing:!1}}),define("main",["exports","./environment"],function(e,n){"use strict";function t(e){return e&&e.__esModule?e:{default:e}}function o(e){e.use.standardConfiguration().feature("resources"),i.default.debug&&e.use.developmentLogging(),i.default.testing&&e.use.plugin("aurelia-testing"),e.start().then(function(){return e.setRoot()})}Object.defineProperty(e,"__esModule",{value:!0}),e.configure=o;var i=t(n);Promise.config({warnings:{wForgottenReturn:!1}})}),define("resources/index",["exports"],function(e){"use strict";function n(e){}Object.defineProperty(e,"__esModule",{value:!0}),e.configure=n}),define("text!app.html",["module"],function(e){e.exports='<template><require from="app.css"></require><div class="container text-center"><div if.bind="showOptions"><h2>Settings</h2><input type="text" value.bind="patterns"> <input type="checkbox" checked.bind="alliterate"><select value.two-way="limit"><option value="0">0 - Flibble!</option><option value="1">1 - Bat Crazy Roy</option><option value="2">2 - Psykokow Sings!</option><option value="5">5 - Freakin\' Insane (default)</option><option value="10">10 - Unhinged</option><option value="20">20 - Feeling Better</option><option value="50">50 - What is Normal anyway?</option><option value="100">100 - Boring</option><option value="200">200 - OMG are you going on about Yaw again!</option></select></div><button click.delegate="getSingleName()">Generate Shipname</button><div id="namelist"><div repeat.for="name of shipNames"><h3>${name}</h3></div></div><div class="footer">Made with &hearts; of the game by <a href="http://iainmnorman.com">Iain M Norman</a></div></div></template>'}),define("text!app.css",["module"],function(e){e.exports='/* http://meyerweb.com/eric/tools/css/reset/ \r\n   v2.0 | 20110126\r\n   License: none (public domain)\r\n*/\nhtml, body, div, span, applet, object, iframe,\nh1, h2, h3, h4, h5, h6, p, blockquote, pre,\na, abbr, acronym, address, big, cite, code,\ndel, dfn, em, img, ins, kbd, q, s, samp,\nsmall, strike, strong, sub, sup, tt, var,\nb, u, i, center,\ndl, dt, dd, ol, ul, li,\nfieldset, form, label, legend,\ntable, caption, tbody, tfoot, thead, tr, th, td,\narticle, aside, canvas, details, embed,\nfigure, figcaption, footer, header, hgroup,\nmenu, nav, output, ruby, section, summary,\ntime, mark, audio, video {\n  margin: 0;\n  padding: 0;\n  border: 0;\n  font-size: 100%;\n  font: inherit;\n  vertical-align: baseline; }\n\n/* HTML5 display-role reset for older browsers */\narticle, aside, details, figcaption, figure,\nfooter, header, hgroup, menu, nav, section {\n  display: block; }\n\nbody {\n  line-height: 1; }\n\nol, ul {\n  list-style: none; }\n\nblockquote, q {\n  quotes: none; }\n\nblockquote:before, blockquote:after,\nq:before, q:after {\n  content: \'\';\n  content: none; }\n\ntable {\n  border-collapse: collapse;\n  border-spacing: 0; }\n\n@font-face {\n  font-family: \'eurostile\';\n  src: url("/fonts/eurostile-webfont.woff2") format("woff2"), url("/fonts/eurostile-webfont.woff") format("woff");\n  font-weight: normal;\n  font-style: normal; }\n\nbody {\n  font-family: "eurostile", sans-serif;\n  padding: 50px;\n  background: black;\n  color: white;\n  line-height: 400%; }\n\n#namelist div:first-child h3 {\n  color: #f07b05;\n  font-size: 42px;\n  text-transform: uppercase;\n  letter-spacing: 4px;\n  margin-bottom: 20px; }\n\n#namelist div:not(:first-child) h3 {\n  color: silver;\n  font-size: 28px; }\n\n#namelist h3 {\n  font-weight: normal; }\n\nbutton {\n  background: none;\n  color: #f07b05;\n  border: 2px solid #f07b05;\n  outline: none;\n  font-size: 24px;\n  padding: 10px;\n  cursor: pointer;\n  margin-bottom: 30px;\n  font-family: "eurostile", sans-serif; }\n\n#loading {\n  position: absolute;\n  top: 10px;\n  right: 10px;\n  text-align: right; }\n\n.footer {\n  position: fixed;\n  bottom: 10px;\n  right: 30px;\n  color: silver; }\n  .footer a {\n    color: silver; }\n'});