/*! modernizr 3.3.1 (Custom Build) | MIT *
 * https://modernizr.com/download/?-canvas-cssanimations-cssgradients-csstransforms-csstransforms3d-csstransitions-cssvhunit-cssvmaxunit-cssvminunit-cssvwunit-fontface-svg-touchevents-domprefixes-mq-prefixed-prefixedcssvalue-prefixes-setclasses-testallprops-testprop-teststyles !*/
!function (e, t, n) {
    function r(e, t) {
        return typeof e === t
    }
    function i() {
        var e,
            t,
            n,
            i,
            o,
            s,
            a;
        for (var d in x)
            if (x.hasOwnProperty(d)) {
                if (e = [], t = x[d], t.name && (e.push(t.name.toLowerCase()), t.options && t.options.aliases && t.options.aliases.length))
                    for (n = 0; n < t.options.aliases.length; n++)
                        e.push(t.options.aliases[n].toLowerCase());
                for (i = r(t.fn, "function") ? t.fn() : t.fn, o = 0; o < e.length; o++)
                    s = e[o], a = s.split("."), 1 === a.length ? Modernizr[a[0]] = i : (!Modernizr[a[0]] || Modernizr[a[0]] instanceof Boolean || (Modernizr[a[0]] = new Boolean(Modernizr[a[0]])), Modernizr[a[0]][a[1]] = i), w.push((i ? "" : "no-") + a.join("-"))
            }
    }
    function o(e) {
        var t = b.className,
            n = Modernizr._config.classPrefix || "";
        if (T && (t = t.baseVal), Modernizr._config.enableJSClass) {
            var r = new RegExp("(^|\\s)" + n + "no-js(\\s|$)");
            t = t.replace(r, "$1" + n + "js$2")
        }
        Modernizr._config.enableClasses && (t += " " + n + e.join(" " + n), T ? b.className.baseVal = t : b.className = t)
    }
    function s(e) {
        return e.replace(/([a-z])-([a-z])/g, function (e, t, n) {
            return t + n.toUpperCase()
        }).replace(/^-/, "")
    }
    function a() {
        return "function" != typeof t.createElement ? t.createElement(arguments[0]) : T ? t.createElementNS.call(t, "http://www.w3.org/2000/svg", arguments[0]) : t.createElement.apply(t, arguments)
    }
    function d(e, t) {
        return e - 1 === t || e === t || e + 1 === t
    }
    function l() {
        var e = t.body;
        return e || (e = a(T ? "svg" : "body"), e.fake = !0),
            e
    }
    function u(e, n, r, i) {
        var o,
            s,
            d,
            u,
            f = "modernizr",
            c = a("div"),
            p = l();
        if (parseInt(r, 10))
            for (; r--;)
                d = a("div"), d.id = i ? i[r] : f + (r + 1), c.appendChild(d);
        return o = a("style"),
            o.type = "text/css",
            o.id = "s" + f,
            (p.fake ? p : c).appendChild(o),
            p.appendChild(c),
            o.styleSheet ? o.styleSheet.cssText = e : o.appendChild(t.createTextNode(e)),
            c.id = f,
            p.fake && (p.style.background = "", p.style.overflow = "hidden", u = b.style.overflow, b.style.overflow = "hidden", b.appendChild(p)),
            s = n(c, e),
            p.fake ? (p.parentNode.removeChild(p), b.style.overflow = u, b.offsetHeight) : c.parentNode.removeChild(c),
            !!s
    }
    function f(e, t) {
        return !!~("" + e).indexOf(t)
    }
    function c(e, t) {
        return function () {
            return e.apply(t, arguments)
        }
    }
    function p(e, t, n) {
        var i;
        for (var o in e)
            if (e[o] in t)
                return n === !1 ? e[o] : (i = t[e[o]], r(i, "function") ? c(i, n || t) : i);
        return !1
    }
    function m(e) {
        return e.replace(/([A-Z])/g, function (e, t) {
            return "-" + t.toLowerCase()
        }).replace(/^ms-/, "-ms-")
    }
    function h(t, r) {
        var i = t.length;
        if ("CSS" in e && "supports" in e.CSS) {
            for (; i--;)
                if (e.CSS.supports(m(t[i]), r))
                    return !0;
            return !1
        }
        if ("CSSSupportsRule" in e) {
            for (var o = []; i--;)
                o.push("(" + m(t[i]) + ":" + r + ")");
            return o = o.join(" or "),
                u("@supports (" + o + ") { #modernizr { position: absolute; } }", function (e) {
                    return "absolute" == getComputedStyle(e, null).position
                })
        }
        return n
    }
    function g(e, t, i, o) {
        function d() {
            u && (delete W.style, delete W.modElem)
        }
        if (o = r(o, "undefined") ? !1 : o, !r(i, "undefined")) {
            var l = h(e, i);
            if (!r(l, "undefined"))
                return l
        }
        for (var u, c, p, m, g, v = ["modernizr", "tspan", "samp"]; !W.style && v.length;)
            u = !0, W.modElem = a(v.shift()), W.style = W.modElem.style;
        for (p = e.length, c = 0; p > c; c++)
            if (m = e[c], g = W.style[m], f(m, "-") && (m = s(m)), W.style[m] !== n) {
                if (o || r(i, "undefined"))
                    return d(), "pfx" == t ? m : !0;
                try {
                    W.style[m] = i
                } catch (y) { }
                if (W.style[m] != g)
                    return d(), "pfx" == t ? m : !0
            }
        return d(),
            !1
    }
    function v(e, t, n, i, o) {
        var s = e.charAt(0).toUpperCase() + e.slice(1),
            a = (e + " " + j.join(s + " ") + s).split(" ");
        return r(t, "string") || r(t, "undefined") ? g(a, t, i, o) : (a = (e + " " + z.join(s + " ") + s).split(" "), p(a, t, n))
    }
    function y(e, t, r) {
        return v(e, n, n, t, r)
    }
    var w = [],
        x = [],
        S = {
            _version: "3.3.1",
            _config: {
                classPrefix: "",
                enableClasses: !0,
                enableJSClass: !0,
                usePrefixes: !0
            },
            _q: [],
            on: function (e, t) {
                var n = this;
                setTimeout(function () {
                    t(n[e])
                }, 0)
            },
            addTest: function (e, t, n) {
                x.push({
                    name: e,
                    fn: t,
                    options: n
                })
            },
            addAsyncTest: function (e) {
                x.push({
                    name: null,
                    fn: e
                })
            }
        },
        Modernizr = function () { };
    Modernizr.prototype = S,
        Modernizr = new Modernizr,
        Modernizr.addTest("svg", !!t.createElementNS && !!t.createElementNS("http://www.w3.org/2000/svg", "svg").createSVGRect);
    var C = S._config.usePrefixes ? " -webkit- -moz- -o- -ms- ".split(" ") : ["", ""];
    S._prefixes = C;
    var b = t.documentElement,
        T = "svg" === b.nodeName.toLowerCase(),
        _ = "Moz O ms Webkit",
        z = S._config.usePrefixes ? _.toLowerCase().split(" ") : [];
    S._domPrefixes = z;
    var N = function (e, t) {
        var n = !1,
            r = a("div"),
            i = r.style;
        if (e in i) {
            var o = z.length;
            for (i[e] = t, n = i[e]; o-- && !n;)
                i[e] = "-" + z[o] + "-" + t, n = i[e]
        }
        return "" === n && (n = !1),
            n
    };
    S.prefixedCSSValue = N,
        Modernizr.addTest("canvas", function () {
            var e = a("canvas");
            return !(!e.getContext || !e.getContext("2d"))
        }),
        Modernizr.addTest("cssgradients", function () {
            for (var e, t = "background-image:", n = "gradient(linear,left top,right bottom,from(#9f9),to(white));", r = "", i = 0, o = C.length - 1; o > i; i++)
                e = 0 === i ? "to " : "", r += t + C[i] + "linear-gradient(" + e + "left top, #9f9, white);";
            Modernizr._config.usePrefixes && (r += t + "-webkit-" + n);
            var s = a("a"),
                d = s.style;
            return d.cssText = r,
                ("" + d.backgroundImage).indexOf("gradient") > -1
        });
    var E = "CSS" in e && "supports" in e.CSS,
        P = "supportsCSS" in e;
    Modernizr.addTest("supports", E || P);
    var I = function () {
        var t = e.matchMedia || e.msMatchMedia;
        return t ? function (e) {
            var n = t(e);
            return n && n.matches || !1
        }
            : function (t) {
                var n = !1;
                return u("@media " + t + " { #modernizr { position: absolute; } }", function (t) {
                    n = "absolute" == (e.getComputedStyle ? e.getComputedStyle(t, null) : t.currentStyle).position
                }),
                    n
            }
    }
        ();
    S.mq = I;
    var k = S.testStyles = u;
    Modernizr.addTest("touchevents", function () {
        var n;
        if ("ontouchstart" in e || e.DocumentTouch && t instanceof DocumentTouch)
            n = !0;
        else {
            var r = ["@media (", C.join("touch-enabled),("), "heartz", ")", "{#modernizr{top:9px;position:absolute}}"].join("");
            k(r, function (e) {
                n = 9 === e.offsetTop
            })
        }
        return n
    });
    var R = function () {
        var e = navigator.userAgent,
            t = e.match(/applewebkit\/([0-9]+)/gi) && parseFloat(RegExp.$1),
            n = e.match(/w(eb)?osbrowser/gi),
            r = e.match(/windows phone/gi) && e.match(/iemobile\/([0-9])+/gi) && parseFloat(RegExp.$1) >= 9,
            i = 533 > t && e.match(/android/gi);
        return n || i || r
    }
        ();
    R ? Modernizr.addTest("fontface", !1) : k('@font-face {font-family:"font";src:url("https://")}', function (e, n) {
        var r = t.getElementById("smodernizr"),
            i = r.sheet || r.styleSheet,
            o = i ? i.cssRules && i.cssRules[0] ? i.cssRules[0].cssText : i.cssText || "" : "",
            s = /src/i.test(o) && 0 === o.indexOf(n.split(" ")[0]);
        Modernizr.addTest("fontface", s)
    }),
        k("#modernizr { height: 50vh; }", function (t) {
            var n = parseInt(e.innerHeight / 2, 10),
                r = parseInt((e.getComputedStyle ? getComputedStyle(t, null) : t.currentStyle).height, 10);
            Modernizr.addTest("cssvhunit", r == n)
        }),
        k("#modernizr1{width: 50vmax}#modernizr2{width:50px;height:50px;overflow:scroll}#modernizr3{position:fixed;top:0;left:0;bottom:0;right:0}", function (t) {
            var n = t.childNodes[2],
                r = t.childNodes[1],
                i = t.childNodes[0],
                o = parseInt((r.offsetWidth - r.clientWidth) / 2, 10),
                s = i.clientWidth / 100,
                a = i.clientHeight / 100,
                l = parseInt(50 * Math.max(s, a), 10),
                u = parseInt((e.getComputedStyle ? getComputedStyle(n, null) : n.currentStyle).width, 10);
            Modernizr.addTest("cssvmaxunit", d(l, u) || d(l, u - o))
        }, 3),
        k("#modernizr1{width: 50vm;width:50vmin}#modernizr2{width:50px;height:50px;overflow:scroll}#modernizr3{position:fixed;top:0;left:0;bottom:0;right:0}", function (t) {
            var n = t.childNodes[2],
                r = t.childNodes[1],
                i = t.childNodes[0],
                o = parseInt((r.offsetWidth - r.clientWidth) / 2, 10),
                s = i.clientWidth / 100,
                a = i.clientHeight / 100,
                l = parseInt(50 * Math.min(s, a), 10),
                u = parseInt((e.getComputedStyle ? getComputedStyle(n, null) : n.currentStyle).width, 10);
            Modernizr.addTest("cssvminunit", d(l, u) || d(l, u - o))
        }, 3),
        k("#modernizr { width: 50vw; }", function (t) {
            var n = parseInt(e.innerWidth / 2, 10),
                r = parseInt((e.getComputedStyle ? getComputedStyle(t, null) : t.currentStyle).width, 10);
            Modernizr.addTest("cssvwunit", r == n)
        });
    var j = S._config.usePrefixes ? _.split(" ") : [];
    S._cssomPrefixes = j;
    var A = function (t) {
        var r,
            i = C.length,
            o = e.CSSRule;
        if ("undefined" == typeof o)
            return n;
        if (!t)
            return !1;
        if (t = t.replace(/^@/, ""), r = t.replace(/-/g, "_").toUpperCase() + "_RULE", r in o)
            return "@" + t;
        for (var s = 0; i > s; s++) {
            var a = C[s],
                d = a.toUpperCase() + "_" + r;
            if (d in o)
                return "@-" + a.toLowerCase() + "-" + t
        }
        return !1
    };
    S.atRule = A;
    var O = {
        elem: a("modernizr")
    };
    Modernizr._q.push(function () {
        delete O.elem
    });
    var W = {
        style: O.elem.style
    };
    Modernizr._q.unshift(function () {
        delete W.style
    });
    S.testProp = function (e, t, r) {
        return g([e], n, t, r)
    };
    S.testAllProps = v;
    S.prefixed = function (e, t, n) {
        return 0 === e.indexOf("@") ? A(e) : (-1 != e.indexOf("-") && (e = s(e)), t ? v(e, t, n) : v(e, "pfx"))
    };
    S.testAllProps = y,
        Modernizr.addTest("cssanimations", y("animationName", "a", !0)),
        Modernizr.addTest("csstransforms", function () {
            return -1 === navigator.userAgent.indexOf("Android 2.") && y("transform", "scale(1)", !0)
        }),
        Modernizr.addTest("csstransforms3d", function () {
            var e = !!y("perspective", "1px", !0),
                t = Modernizr._config.usePrefixes;
            if (e && (!t || "webkitPerspective" in b.style)) {
                var n,
                    r = "#modernizr{width:0;height:0}";
                Modernizr.supports ? n = "@supports (perspective: 1px)" : (n = "@media (transform-3d)", t && (n += ",(-webkit-transform-3d)")),
                    n += "{#modernizr{width:7px;height:18px;margin:0;padding:0;border:0}}",
                    k(r + n, function (t) {
                        e = 7 === t.offsetWidth && 18 === t.offsetHeight
                    })
            }
            return e
        }),
        Modernizr.addTest("csstransitions", y("transition", "all", !0)),
        i(),
        o(w),
        delete S.addTest,
        delete S.addAsyncTest;
    for (var L = 0; L < Modernizr._q.length; L++)
        Modernizr._q[L]();
    e.Modernizr = Modernizr
}
    (window, document);
