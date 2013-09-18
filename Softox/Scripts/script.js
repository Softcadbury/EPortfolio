$(document).ready(function () {
    // Pages navigation
    function show_page(page_id) {
        $(page_id + '_container').show("drop", {}, "slow");
        $(page_id + '_button').parent().addClass('active');
    }

    $('a[id$=button]').click(function () {
        $('#menu li').removeClass('active');
        $('.container_sub').hide();
        show_page('#' + $(this).attr("id").replace('_brand', '').replace('_button', ''));
    });

    // Tabs navigation
    function show_tab(tab_id) {
        $('a[href="#' + tab_id + '"]').tab('show');
    }

    $('a[data-toggle=tab]').click(function () {
        var url = this.href.substring(this.href.indexOf('#') + 1, this.href.length);
        document.location.hash = document.location.hash.split('_')[0] + '_' + url;
    });

    // Auto navigation
    var hash = document.location.hash.split('_');
    show_page(hash[0] == '' ? '#accueil' : hash[0]);
    show_tab(hash.length == 2 ? hash[1] : '');

    // Fancybox activation
    $(".fancybox").fancybox({
        openEffect: 'elastic',
        closeEffect: 'elastic',
        helpers: { title: { type: 'inside' } }
    });

    // Editor coloration
    $("pre").each(function () {
        var content = $(this).html();

        var keywords = ['public ', 'delegate ', 'void ', 'Object', 'string ', 'int ', 'int[] ', 'out ', 'ref ', 'var'];
        for (var i = 0; i < keywords.length; i++) {
            content = content.replace(new RegExp(keywords[i], 'g'), '<span style="color: blue;">' + keywords[i] + '</span>');
        }

        content = content.replace(/\/\/.*\n/g, '<span style="color: red;\">$&<\/span>');

        $(this).html(content);
    });
});

// Contact form
function OnMailSend(e) {
    $('#mail').hide();
    $('#mail_send').show();
}