//ELEMENTS ==================================================================
var logoutElement = $("#logout");

$(document).ready(function () {
    autoHideNavBar();
    dropdownHover();
    clickToCardTabs();
    addToolTips();
    convertLogoutInPopup();
    onlyOnePopOver();
});

//CARD TABS ==================================================================
function clickToCardTabs() {
    $(".btn-pref .btn").click(function () {
        $(".tab").addClass("active"); // instead of this do the below 
        $(".btn-pref .btn").removeClass("btn-primary").addClass("btn-default");
        $(this).removeClass("btn-default").addClass("btn-primary");
    });
}

//LOGOUT ==================================================================
function convertLogoutInPopup() {
    logoutElement.popup({
        transition: 'ease-in-out 0.3s',
        vertical: 'top'
    });
    $.fn.popup.defaults.pagecontainer = '#wrapper';

    $("[href='#logout'], #calcelLogout").click(function (e) {
        e.preventDefault();
        logoutElement.popup('toggle');
    });
}

//TOOLTIP ==================================================================
function addToolTips() {
    $("[data-toggle='tooltip']").tooltip({
        container: "body"
    });
}

//POPOVER ==================================================================
function onlyOnePopOver() {
    $('body').on('click', function (e) {
        $('[data-toggle="popover"]').each(function () {
            if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
                $(this).popover('hide');
            }
        });
    });
}

//PANEL ==================================================================
function showAndHidePanel() {
    $(".portlet-widgets .fa-chevron-down, .portlet-widgets .fa-chevron-up").click(function () {
        $(this).toggleClass("fa-chevron-down fa-chevron-up");
    });
}

//DROPDOWN HOVER==================================================================
function dropdownHover() {
    $('.dropdown').hover(function() {
        $(this).addClass("open");
    }, function() {
        $(this).removeClass("open");
    });
}

//AUTO HIDE NAVBAR==================================================================
function autoHideNavBar() {
    $(".navbar-fixed-top").autoHidingNavbar({showOnBottom: false});
}
