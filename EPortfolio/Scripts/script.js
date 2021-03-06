$(document).ready(function () {
    init_navigation();
    init_fancybox();
    init_editorColoration();
});

// Navigation initialization
function init_navigation() {
    var lockNavigation = false;

    var routes = $.sammy(function () {
        this.get(/\#\/(.*)\/(.*)/, function () {
            if (lockNavigation)
                return;

            var result = this.params['splat'],
                page = result[0],
                tab = result[1];

            if ($('#' + page).length == 0 || (tab != '' && $('#' + tab).length == 0)) {
                document.location.hash = '#/accueil/';
            }
            else {
                $('#navbar li').removeClass('active');
                $('a[href="#/' + page + '/"]').parent().addClass('active');

                $('.container-sub').hide();
                $('#' + page).show();

                $('a[href="#' + tab + '"]').tab('show');
            }
        });
    });

    routes.run('#/accueil/');

    $('a[data-toggle=tab]').click(function () {
        var page = document.location.hash.split('/')[1];
        var tab = $(this).attr('href').substring(1);

        lockNavigation = true;
        document.location.hash = '#/' + page + '/' + tab;
        lockNavigation = false;
    });
}

// Fancybox activation
function init_fancybox() {
    $('.fancybox').fancybox({
        openEffect: 'elastic',
        closeEffect: 'elastic',
        helpers: { title: { type: 'inside' } }
    });
}

// Editor coloration
function init_editorColoration() {
    $('pre').each(function () {
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
function OnBegin() {
    $('#contact_button').button('loading');
}

function OnMailSend() {
    $('#contact_form').hide();
    $('#contact_success').show();
}

function OnFailure() {
    $('#contact_form').hide();
    $('#contact_failure').show();
}