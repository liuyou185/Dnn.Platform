!function(e,o){"object"==typeof exports&&"object"==typeof module?module.exports=o(require("dnn-dropdown"),require("dnn-label"),require("dnn-tooltip"),require("react")):"function"==typeof define&&define.amd?define(["dnn-dropdown","dnn-label","dnn-tooltip","react"],o):"object"==typeof exports?exports.DropdownWithError=o(require("dnn-dropdown"),require("dnn-label"),require("dnn-tooltip"),require("react")):e.DropdownWithError=o(e["dnn-dropdown"],e["dnn-label"],e["dnn-tooltip"],e.react)}(this,function(e,o,t,r){return function(e){function o(r){if(t[r])return t[r].exports;var n=t[r]={exports:{},id:r,loaded:!1};return e[r].call(n.exports,n,n.exports,o),n.loaded=!0,n.exports}var t={};return o.m=e,o.c=t,o.p="",o(0)}([function(e,o,t){"use strict";function r(e){return e&&e.__esModule?e:{"default":e}}function n(e,o){if(!(e instanceof o))throw new TypeError("Cannot call a class as a function")}function i(e,o){if(!e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return!o||"object"!=typeof o&&"function"!=typeof o?e:o}function p(e,o){if("function"!=typeof o&&null!==o)throw new TypeError("Super expression must either be null or a function, not "+typeof o);e.prototype=Object.create(o&&o.prototype,{constructor:{value:e,enumerable:!1,writable:!0,configurable:!0}}),o&&(Object.setPrototypeOf?Object.setPrototypeOf(e,o):e.__proto__=o)}Object.defineProperty(o,"__esModule",{value:!0});var l=function(){function e(e,o){for(var t=0;t<o.length;t++){var r=o[t];r.enumerable=r.enumerable||!1,r.configurable=!0,"value"in r&&(r.writable=!0),Object.defineProperty(e,r.key,r)}}return function(o,t,r){return t&&e(o.prototype,t),r&&e(o,r),o}}(),s=t(8),a=r(s),d=t(7),c=r(d),u=t(5),f=r(u),h=t(6),b=r(h);t(4);var y=function(e){function o(){return n(this,o),i(this,(o.__proto__||Object.getPrototypeOf(o)).call(this))}return p(o,e),l(o,[{key:"render",value:function(){var e=this.props,o="dnn-dropdown-with-error"+(e.error?" error":"")+(" "+e.className)+(e.enabled?"":" disabled"),t=e.errorMessage instanceof Array?e.errorMessage:[e.errorMessage];return a["default"].createElement("div",{className:o,style:e.style},e.label&&a["default"].createElement(b["default"],{labelFor:e.inputId,label:e.label,tooltipMessage:e.tooltipMessage,tooltipPlace:e.infoTooltipPlace,tooltipActive:e.tooltipMessage,labelType:e.labelType,className:e.infoTooltipClassName,style:Object.assign(e.tooltipMessage?{}:{marginBottom:5},e.labelStyle)}),e.extraToolTips,a["default"].createElement("div",{className:"dropdown-tooltip-container "+e.labelType},a["default"].createElement(f["default"],{label:e.defaultDropdownValue,fixedHeight:e.fixedHeight,collapsibleWidth:e.collapsibleWidth,collapsibleHeight:e.collapsibleHeight,keepCollapsedContent:e.keepCollapsedContent,scrollAreaStyle:e.scrollAreaStyle,options:e.options,onSelect:e.onSelect,size:e.dropdownSize,withBorder:e.withBorder,withIcon:e.withIcon,enabled:e.enabled,value:e.value,closeOnClick:e.closeOnClick,prependWith:e.prependWith}),a["default"].createElement(c["default"],{messages:t,type:"error",className:e.placement,tooltipPlace:e.tooltipPlace,rendered:e.error})))}}]),o}(s.Component);y.propTypes={inputId:s.PropTypes.string,label:s.PropTypes.string,infoTooltipClassName:s.PropTypes.string,tooltipMessage:s.PropTypes.oneOfType([s.PropTypes.string,s.PropTypes.array]),infoTooltipPlace:s.PropTypes.string,labelType:s.PropTypes.string,className:s.PropTypes.string,dropdownSize:s.PropTypes.oneOf(["large","small"]),error:s.PropTypes.bool,errorMessage:s.PropTypes.oneOfType([s.PropTypes.string,s.PropTypes.array]),tooltipPlace:s.PropTypes.string,placement:s.PropTypes.oneOf(["outside","inside"]),defaultDropdownValue:s.PropTypes.string,fixedHeight:s.PropTypes.number,collapsibleWidth:s.PropTypes.number,collapsibleHeight:s.PropTypes.number,keepCollapsedContent:s.PropTypes.bool,scrollAreaStyle:s.PropTypes.object,options:s.PropTypes.array,onSelect:s.PropTypes.func,size:s.PropTypes.string,withBorder:s.PropTypes.bool,withIcon:s.PropTypes.bool,enabled:s.PropTypes.bool,value:s.PropTypes.oneOfType([s.PropTypes.number,s.PropTypes.string]),closeOnClick:s.PropTypes.bool,style:s.PropTypes.object,labelStyle:s.PropTypes.object,extraToolTips:s.PropTypes.node,prependWith:s.PropTypes.string},y.defaultProps={error:!1,enabled:!0,className:"",placement:"outside",inputSize:"small",labelType:"block",errorMessage:["This field has an error."],prependWith:""},o["default"]=y},function(e,o,t){o=e.exports=t(2)(),o.push([e.id,".dnn-dropdown-with-error{display:inline-block;position:relative}.dnn-dropdown-with-error.disabled .dnn-label label,.dnn-dropdown-with-error.disabled .dropdown-tooltip-container .dnn-dropdown-input{color:#959695;cursor:not-allowed}.dnn-dropdown-with-error .dnn-label label{font-weight:700;cursor:pointer;float:left}.dnn-dropdown-with-error input{color:#46292b}.dnn-dropdown-with-error.error input{border-bottom:2px solid #ea2134}.dnn-dropdown-with-error .dnn-ui-common-tooltip .tooltip-text{max-width:255px;text-align:center;padding:7px 15px}.dnn-dropdown-with-error .dropdown-tooltip-container{float:left;position:relative;width:100%}.dnn-dropdown-with-error .dropdown-tooltip-container .dnn-dropdown{width:100%;box-sizing:border-box;border-radius:0}.dnn-dropdown-with-error .dropdown-tooltip-container.inline{width:auto}.dnn-dropdown-with-error .dropdown-tooltip-container .dnn-ui-common-tooltip{position:absolute;top:7px;right:30px}.dnn-dropdown-with-error .dropdown-tooltip-container .dnn-ui-common-tooltip.outside{right:-25px}.dnn-dropdown-with-error .dropdown-tooltip-container .dnn-ui-common-tooltip svg{width:20px;height:20px}",""])},function(e,o){e.exports=function(){var e=[];return e.toString=function(){for(var e=[],o=0;o<this.length;o++){var t=this[o];t[2]?e.push("@media "+t[2]+"{"+t[1]+"}"):e.push(t[1])}return e.join("")},e.i=function(o,t){"string"==typeof o&&(o=[[null,o,""]]);for(var r={},n=0;n<this.length;n++){var i=this[n][0];"number"==typeof i&&(r[i]=!0)}for(n=0;n<o.length;n++){var p=o[n];"number"==typeof p[0]&&r[p[0]]||(t&&!p[2]?p[2]=t:t&&(p[2]="("+p[2]+") and ("+t+")"),e.push(p))}},e}},function(e,o,t){function r(e,o){for(var t=0;t<e.length;t++){var r=e[t],n=f[r.id];if(n){n.refs++;for(var i=0;i<n.parts.length;i++)n.parts[i](r.parts[i]);for(;i<r.parts.length;i++)n.parts.push(a(r.parts[i],o))}else{for(var p=[],i=0;i<r.parts.length;i++)p.push(a(r.parts[i],o));f[r.id]={id:r.id,refs:1,parts:p}}}}function n(e){for(var o=[],t={},r=0;r<e.length;r++){var n=e[r],i=n[0],p=n[1],l=n[2],s=n[3],a={css:p,media:l,sourceMap:s};t[i]?t[i].parts.push(a):o.push(t[i]={id:i,parts:[a]})}return o}function i(e,o){var t=y(),r=g[g.length-1];if("top"===e.insertAt)r?r.nextSibling?t.insertBefore(o,r.nextSibling):t.appendChild(o):t.insertBefore(o,t.firstChild),g.push(o);else{if("bottom"!==e.insertAt)throw new Error("Invalid value for parameter 'insertAt'. Must be 'top' or 'bottom'.");t.appendChild(o)}}function p(e){e.parentNode.removeChild(e);var o=g.indexOf(e);o>=0&&g.splice(o,1)}function l(e){var o=document.createElement("style");return o.type="text/css",i(e,o),o}function s(e){var o=document.createElement("link");return o.rel="stylesheet",i(e,o),o}function a(e,o){var t,r,n;if(o.singleton){var i=m++;t=w||(w=l(o)),r=d.bind(null,t,i,!1),n=d.bind(null,t,i,!0)}else e.sourceMap&&"function"==typeof URL&&"function"==typeof URL.createObjectURL&&"function"==typeof URL.revokeObjectURL&&"function"==typeof Blob&&"function"==typeof btoa?(t=s(o),r=u.bind(null,t),n=function(){p(t),t.href&&URL.revokeObjectURL(t.href)}):(t=l(o),r=c.bind(null,t),n=function(){p(t)});return r(e),function(o){if(o){if(o.css===e.css&&o.media===e.media&&o.sourceMap===e.sourceMap)return;r(e=o)}else n()}}function d(e,o,t,r){var n=t?"":r.css;if(e.styleSheet)e.styleSheet.cssText=v(o,n);else{var i=document.createTextNode(n),p=e.childNodes;p[o]&&e.removeChild(p[o]),p.length?e.insertBefore(i,p[o]):e.appendChild(i)}}function c(e,o){var t=o.css,r=o.media;o.sourceMap;if(r&&e.setAttribute("media",r),e.styleSheet)e.styleSheet.cssText=t;else{for(;e.firstChild;)e.removeChild(e.firstChild);e.appendChild(document.createTextNode(t))}}function u(e,o){var t=o.css,r=(o.media,o.sourceMap);r&&(t+="\n/*# sourceMappingURL=data:application/json;base64,"+btoa(unescape(encodeURIComponent(JSON.stringify(r))))+" */");var n=new Blob([t],{type:"text/css"}),i=e.href;e.href=URL.createObjectURL(n),i&&URL.revokeObjectURL(i)}var f={},h=function(e){var o;return function(){return"undefined"==typeof o&&(o=e.apply(this,arguments)),o}},b=h(function(){return/msie [6-9]\b/.test(window.navigator.userAgent.toLowerCase())}),y=h(function(){return document.head||document.getElementsByTagName("head")[0]}),w=null,m=0,g=[];e.exports=function(e,o){o=o||{},"undefined"==typeof o.singleton&&(o.singleton=b()),"undefined"==typeof o.insertAt&&(o.insertAt="bottom");var t=n(e);return r(t,o),function(e){for(var i=[],p=0;p<t.length;p++){var l=t[p],s=f[l.id];s.refs--,i.push(s)}if(e){var a=n(e);r(a,o)}for(var p=0;p<i.length;p++){var s=i[p];if(0===s.refs){for(var d=0;d<s.parts.length;d++)s.parts[d]();delete f[s.id]}}}};var v=function(){var e=[];return function(o,t){return e[o]=t,e.filter(Boolean).join("\n")}}()},function(e,o,t){var r=t(1);"string"==typeof r&&(r=[[e.id,r,""]]);t(3)(r,{});r.locals&&(e.exports=r.locals)},function(o,t){o.exports=e},function(e,t){e.exports=o},function(e,o){e.exports=t},function(e,o){e.exports=r}])});