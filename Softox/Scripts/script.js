$(document).ready(function () {
    init_navigation();
    init_fancybox();
    init_editorColoration();
});

// Navigation initialization
function init_navigation() {
    var lockSammy = false;

    var routes = $.sammy(function () {
        this.get(/\#\/(.*)\/(.*)/, function (context) {
            if (lockSammy)
                return;

            var result = this.params['splat'],
                page = result[0],
                tab = result[1];

            if ($('a[href="#/' + page + '/"]').length == 0) {
                document.location.hash = '#/accueil/';
            }
            else {
                $('#navbar li').removeClass('active');
                $('a[href="#/' + page + '/"]').parent().addClass('active');

                $('.container-sub').hide();
                $('#' + page).show();

                $('a[href="#' + tab + '"]').tab('show');
            }

            console.log('lola');
        });
    });

    routes.run('#/accueil/');

    $('a[data-toggle=tab]').click(function () {
        lockSammy = true;
        var url = this.href.substring(this.href.indexOf('#') + 1, this.href.length);
        document.location.hash = '#/' + document.location.hash.split('/')[1] + '/' + url;
        lockSammy = false;
    });
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
function init_editorColoration() {
    $("pre").each(function () {
        var content = $(this).html();

        var keywords = ['public ', 'void ', 'static ', 'return', 'delegate ', 'event', 'Func', 'Action',
                        'Object', 'string', 'int', 'int[] ', 'out ', 'ref ', 'var', 'params'];

        for (var i = 0; i < keywords.length; i++) {
            content = content.replace(new RegExp(keywords[i], 'g'), '<span style="color: blue;">' + keywords[i] + '</span>');
        }

        content = content.replace(/\/\/.*\n/g, '<span style="color: red;\">$&<\/span>');

        $(this).html(content);
    });
}

// Functions to manage mail sending
function OnBegin(e) {
    $('#contact_button').button('loading');
}

function OnMailSend(e) {
    $('#contact_form').hide();
    $('#contact_success').show();
}

function OnFailure(e) {
    $('#contact_form').hide();
    $('#contact_failure').show();
}