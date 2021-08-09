﻿! function (e, t) {
    "object" == typeof exports && "undefined" != typeof module ? t(exports, require("jquery"), require("perfect-scrollbar")) : "function" == typeof define && define.amd ? define(["exports", "jquery", "perfect-scrollbar"], t) : t(e.coreui = {}, e.jQuery, e.PerfectScrollbar)
}(this, function (e, t, r) {
    "use strict";

    function o(e, t) {
        for (var n = 0; n < t.length; n++) {
            var r = t[n];
            r.enumerable = r.enumerable || !1, r.configurable = !0, "value" in r && (r.writable = !0), Object.defineProperty(e, r.key, r)
        }
    }

    function a(e, t, n) {
        return t && o(e.prototype, t), n && o(e, n), e
    }
    t = t && t.hasOwnProperty("default") ? t.default : t, r = r && r.hasOwnProperty("default") ? r.default : r;
    var i, n, s, u, c, d, l, f, p, g, h, m, v, b, y, w, I, _, C, S, T, L, E, j, x, A, O, P, D, k, Q, q, U, N, G, R, K, H, M, V, z, B, X, J, Y = (n = "ajaxLoad", s = "coreui.ajaxLoad", u = (i = t).fn[n], c = "active", d = "open", l = "view-script", f = "click", p = ".sidebar-nav .nav-dropdown", g = ".sidebar-nav .nav-link", h = ".sidebar-nav .nav-item", m = ".view-script", v = {
        defaultPage: "main.html",
        errorPage: "404.html",
        subpagesDirectory: "views/"
    }, b = function () {
        function n(e, t) {
            this._config = this._getConfig(t), this._element = e;
            var n = location.hash.replace(/^#/, "");
            "" !== n ? this.setUpUrl(n) : this.setUpUrl(this._config.defaultPage), this._addEventListeners()
        }
        var e = n.prototype;
        return e.loadPage = function (r) {
            var o = this._element,
                e = this._config;
            i.ajax({
                type: "GET",
                url: e.subpagesDirectory + r,
                dataType: "html",
                beforeSend: function () {
                    i(m).remove()
                },
                success: function (e) {
                    var t = document.createElement("div");
                    t.innerHTML = e;
                    var n = Array.from(t.querySelectorAll("script")).map(function (e) {
                        return e.attributes.getNamedItem("src").nodeValue
                    });
                    t.querySelectorAll("script").forEach(function (e) {
                        return e.parentNode.removeChild(e)
                    }), i("body").animate({
                        scrollTop: 0
                    }, 0), i(o).html(t), n.length && function e(t, n) {
                        void 0 === n && (n = 0);
                        var r = document.createElement("script");
                        r.type = "text/javascript", r.src = t[n], r.className = l, r.onload = r.onreadystatechange = function () {
                            this.readyState && "complete" !== this.readyState || t.length > n + 1 && e(t, n + 1)
                        }, document.getElementsByTagName("body")[0].appendChild(r)
                    }(n), window.location.hash = r
                },
                error: function () {
                    window.location.href = e.errorPage
                }
            })
        }, e.setUpUrl = function (e) {
            i(g).removeClass(c), i(p).removeClass(d), i(p + ':has(a[href="' + e.replace(/^\//, "").split("?")[0] + '"])').addClass(d), i(h + ' a[href="' + e.replace(/^\//, "").split("?")[0] + '"]').addClass(c), this.loadPage(e)
        }, e.loadBlank = function (e) {
            window.open(e)
        }, e.loadTop = function (e) {
            window.location = e
        }, e._getConfig = function (e) {
            return e = Object.assign({}, v, e)
        }, e._addEventListeners = function () {
            var t = this;
            i(document).on(f, g + '[href!="#"]', function (e) {
                e.preventDefault(), e.stopPropagation(), "_top" === e.currentTarget.target ? t.loadTop(e.currentTarget.href) : "_blank" === e.currentTarget.target ? t.loadBlank(e.currentTarget.href) : t.setUpUrl(e.currentTarget.getAttribute("href"))
            })
        }, n._jQueryInterface = function (t) {
            return this.each(function () {
                var e = i(this).data(s);
                e || (e = new n(this, "object" == typeof t && t), i(this).data(s, e))
            })
        }, a(n, null, [{
            key: "VERSION",
            get: function () {
                return "2.0.6"
            }
        }, {
            key: "Default",
            get: function () {
                return v
            }
        }]), n
    }(), i.fn[n] = b._jQueryInterface, i.fn[n].Constructor = b, i.fn[n].noConflict = function () {
        return i.fn[n] = u, b._jQueryInterface
    }, b),
        $ = function (e, t) {
            var n = t.indexOf(e),
                r = t.slice(0, n + 1); - 1 !== r.map(function (e) {
                    return document.body.classList.contains(e)
                }).indexOf(!0) ? r.map(function (e) {
                    return document.body.classList.remove(e)
                }) : document.body.classList.add(e)
        },
        F = (w = "aside-menu", I = "coreui.aside-menu", _ = (y = t).fn[w], C = {
            CLICK: "click",
            LOAD_DATA_API: "load.coreui.aside-menu.data-api",
            TOGGLE: "toggle"
        }, S = ".aside-menu", T = ".aside-menu-toggler", L = ["aside-menu-show", "aside-menu-sm-show", "aside-menu-md-show", "aside-menu-lg-show", "aside-menu-xl-show"], E = function () {
            function n(e) {
                this._element = e, this._addEventListeners()
            }
            return n.prototype._addEventListeners = function () {
                y(T).on(C.CLICK, function (e) {
                    e.preventDefault(), e.stopPropagation();
                    var t = e.currentTarget.dataset.toggle;
                    $(t, L)
                })
            }, n._jQueryInterface = function () {
                return this.each(function () {
                    var e = y(this),
                        t = e.data(I);
                    t || (t = new n(this), e.data(I, t))
                })
            }, a(n, null, [{
                key: "VERSION",
                get: function () {
                    return "2.0.6"
                }
            }]), n
        }(), y(window).on(C.LOAD_DATA_API, function () {
            var e = y(S);
            E._jQueryInterface.call(e)
        }), y.fn[w] = E._jQueryInterface, y.fn[w].Constructor = E, y.fn[w].noConflict = function () {
            return y.fn[w] = _, E._jQueryInterface
        }, E),
        W = (x = "sidebar", A = "coreui.sidebar", O = (j = t).fn[x], P = "active", D = "brand-minimized", k = "open", Q = "sidebar-minimized", q = {
            CLICK: "click",
            DESTROY: "destroy",
            INIT: "init",
            LOAD_DATA_API: "load.coreui.sidebar.data-api",
            TOGGLE: "toggle"
        }, U = "body", N = ".brand-minimizer", G = ".nav-dropdown-toggle", R = ".nav-dropdown-items", K = ".nav-link", H = ".sidebar-nav", M = ".sidebar-nav > .nav", V = ".sidebar", z = ".sidebar-minimizer", B = ".sidebar-toggler", X = ["sidebar-show", "sidebar-sm-show", "sidebar-md-show", "sidebar-lg-show", "sidebar-xl-show"], J = function () {
            function n(e) {
                this._element = e, this.perfectScrollbar(q.INIT), this.setActiveLink(), this._addEventListeners()
            }
            var e = n.prototype;
            return e.perfectScrollbar = function (e) {
                "undefined" != typeof r && (e !== q.INIT || document.body.classList.contains(Q) || new r(document.querySelector(H), {
                    suppressScrollX: !0
                }), e === q.DESTROY && new r(document.querySelector(H), {
                    suppressScrollX: !0
                }).destroy(), e === q.TOGGLE && (document.body.classList.contains(Q) ? new r(document.querySelector(H), {
                    suppressScrollX: !0
                }).destroy() : new r(document.querySelector(H), {
                    suppressScrollX: !0
                })))
            }, e.setActiveLink = function () {
                j(M).find(K).each(function (e, t) {
                    var n = t,
                        r = String(window.location).split("?")[0];
                    "#" === r.substr(r.length - 1) && (r = r.slice(0, -1)), j(j(n))[0].href === r && j(n).addClass(P).parents(R).add(n).each(function (e, t) {
                        j(n = t).parent().addClass(k)
                    })
                })
            }, e._addEventListeners = function () {
                var t = this;
                j(N).on(q.CLICK, function (e) {
                    e.preventDefault(), e.stopPropagation(), j(U).toggleClass(D)
                }), j(G).on(q.CLICK, function (e) {
                    e.preventDefault(), e.stopPropagation();
                    var t = e.target;
                    j(t).parent().toggleClass(k)
                }), j(z).on(q.CLICK, function (e) {
                    e.preventDefault(), e.stopPropagation(), j(U).toggleClass(Q), t.perfectScrollbar(q.TOGGLE)
                }), j(B).on(q.CLICK, function (e) {
                    e.preventDefault(), e.stopPropagation();
                    var t = e.currentTarget.dataset.toggle;
                    $(t, X)
                })
            }, n._jQueryInterface = function () {
                return this.each(function () {
                    var e = j(this),
                        t = e.data(A);
                    t || (t = new n(this), e.data(A, t))
                })
            }, a(n, null, [{
                key: "VERSION",
                get: function () {
                    return "2.0.6"
                }
            }]), n
        }(), j(window).on(q.LOAD_DATA_API, function () {
            var e = j(V);
            J._jQueryInterface.call(e)
        }), j.fn[x] = J._jQueryInterface, j.fn[x].Constructor = J, j.fn[x].noConflict = function () {
            return j.fn[x] = O, J._jQueryInterface
        }, J);
    ! function (e) {
        if ("undefined" == typeof e) throw new TypeError("CoreUI's JavaScript requires jQuery. jQuery must be included before CoreUI's JavaScript.");
        var t = e.fn.jquery.split(" ")[0].split(".");
        if (t[0] < 2 && t[1] < 9 || 1 === t[0] && 9 === t[1] && t[2] < 1 || 4 <= t[0]) throw new Error("CoreUI's JavaScript requires at least jQuery v1.9.1 but less than v4.0.0")
    }(t), window.getStyle = function (e, t) {
        var n;
        void 0 === t && (t = document.body), n = e.match(/^--.*/i) && Boolean(document.documentMode) && 10 <= document.documentMode ? function () {
            for (var r = {}, e = document.styleSheets, t = "", n = e.length - 1; - 1 < n; n--) {
                for (var o = e[n].cssRules, a = o.length - 1; - 1 < a; a--)
                    if (".ie-custom-properties" === o[a].selectorText) {
                        t = o[a].cssText;
                        break
                    } if (t) break
            }
            return (t = t.substring(t.lastIndexOf("{") + 1, t.lastIndexOf("}"))).split(";").forEach(function (e) {
                if (e) {
                    var t = e.split(": ")[0],
                        n = e.split(": ")[1];
                    t && n && (r["--" + t.trim()] = n.trim())
                }
            }), r
        }()[e] : window.getComputedStyle(t, null).getPropertyValue(e).replace(/^\s/, "");
        return n
    }, window.hexToRgb = function (e) {
        if ("undefined" == typeof e) throw new Error("Hex color is not defined");
        var t, n, r;
        if (!e.match(/^#(?:[0-9a-f]{3}){1,2}$/i)) throw new Error(e + " is not a valid hex color");
        return 7 === e.length ? (t = parseInt(e.substring(1, 3), 16), n = parseInt(e.substring(3, 5), 16), r = parseInt(e.substring(5, 7), 16)) : (t = parseInt(e.substring(1, 2), 16), n = parseInt(e.substring(2, 3), 16), r = parseInt(e.substring(3, 5), 16)), "rgba(" + t + ", " + n + ", " + r + ")"
    }, window.hexToRgba = function (e, t) {
        if (void 0 === t && (t = 100), "undefined" == typeof e) throw new Error("Hex color is not defined");
        var n, r, o;
        if (!e.match(/^#(?:[0-9a-f]{3}){1,2}$/i)) throw new Error(e + " is not a valid hex color");
        return 7 === e.length ? (n = parseInt(e.substring(1, 3), 16), r = parseInt(e.substring(3, 5), 16), o = parseInt(e.substring(5, 7), 16)) : (n = parseInt(e.substring(1, 2), 16), r = parseInt(e.substring(2, 3), 16), o = parseInt(e.substring(3, 5), 16)), "rgba(" + n + ", " + r + ", " + o + ", " + t / 100 + ")"
    }, window.rgbToHex = function (e) {
        if ("undefined" == typeof e) throw new Error("Hex color is not defined");
        var t = e.match(/^rgba?[\s+]?\([\s+]?(\d+)[\s+]?,[\s+]?(\d+)[\s+]?,[\s+]?(\d+)[\s+]?/i);
        if (!t) throw new Error(e + " is not a valid rgb color");
        var n = "0" + parseInt(t[1], 10).toString(16),
            r = "0" + parseInt(t[2], 10).toString(16),
            o = "0" + parseInt(t[3], 10).toString(16);
        return "#" + n.slice(-2) + r.slice(-2) + o.slice(-2)
    }, e.AjaxLoad = Y, e.AsideMenu = F, e.Sidebar = W, Object.defineProperty(e, "__esModule", {
        value: !0
    })
});