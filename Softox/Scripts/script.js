$(document).ready(function () {
    init_page_navigation();
    init_tab_navigation();
    init_auto_navigation();
    init_fancybox();
    init_editor_coloration();
});

// Pages navigation
function init_page_navigation() {
    $('a[id$=button]').click(function () {
        $('#menu li').removeClass('active');
        $('.container_sub').hide();
        show_page('#' + $(this).attr("id").replace('_brand', '').replace('_button', ''));
    });
}

function show_page(page_id) {
    $(page_id + '_container').show();
    $(page_id + '_button').parent().addClass('active');
}

// Tabs navigation
function init_tab_navigation() {
    $('a[data-toggle=tab]').click(function () {
        var url = this.href.substring(this.href.indexOf('#') + 1, this.href.length);
        document.location.hash = document.location.hash.split('/')[0] + '/' + url;
    });
}

function show_tab(tab_id) {
    $('a[href="#' + tab_id + '"]').tab('show');
}

// Auto navigation
function init_auto_navigation() {
    var hash = document.location.hash.split('/');
    show_page(hash[0] == '' ? '#accueil' : hash[0]);
    show_tab(hash.length == 2 ? hash[1] : '');
}

// Fancybox activation
function init_fancybox() {
    $(".fancybox").fancybox({
        openEffect: 'elastic',
        closeEffect: 'elastic',
        helpers: { title: { type: 'inside' } }
    });
}
// Editor coloration
function init_editor_coloration() {
    $("pre").each(function () {
        var content = $(this).html();

        var keywords = ['public ', 'void ', 'static ', 'return', 'delegate ', 'event', 'Func', 'Action',
                        'Object', 'string ', 'int ', 'int[] ', 'out ', 'ref ', 'var'];
        for (var i = 0; i < keywords.length; i++) {
            content = content.replace(new RegExp(keywords[i], 'g'), '<span style="color: blue;">' + keywords[i] + '</span>');
        }

        content = content.replace(/\/\/.*\n/g, '<span style="color: red;\">$&<\/span>');

        $(this).html(content);
    });
}

// Function called after mail sending
function OnMailSend(e) {
    $('#mail').hide();
    $('#mail_send').show();
}