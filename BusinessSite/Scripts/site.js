$(document).ready(function () {

    $(document).scroll(function () {

        if ($(window).scrollTop() > 90) {
            $(".fixed-top").css('top', '0px');
            $(".fixed-top").css('position', 'fixed');
        }
        if ($(window).scrollTop() <= 90) {
            $(".fixed-top").css('top', '90px');
            $(".fixed-top").css('position', 'absolute');
        }
    });

    if (window.innerWidth < 768) {
        $('#navbar-brand-image').attr('src', '/Assets/img/FN_LOGO_mini.png');
        $('.navbar-brand').css('padding-left', '25px');
        $('#logo-image').hide();
        $('.logo .logo-social-media').css('right', '15px');
        $('.login-input').css("width", '80px');
        $('.login-input').css("margin-left", "15px");
        $('.login-btn').css("width", '50px');
        $('.login-btn').css("margin-left", "15px");
        $('#login-form').css("line-height", "");
        $('footer .about-author').css("height", "");
    } else {
        $('#navbar-brand-image').attr('src', '/Assets/img/FN_LOGO_short.png');
        $('.navbar-brand').css('padding-left', '');
        $('#logo-image').show();
        $('.logo .logo-social-media').css('right', '220px');
        $('.login-input').css("width", '9vw');
        $('.login-input').css("margin-left", "0");
        $('.login-btn').css("width", '6vw');
        $('.login-btn').css("margin-left", "0");
        $('#login-form').css("line-height", "45px");
        $('footer .about-author').css("height", "110px");
    }

    if (window.innerWidth < 380) {
        $('#about-author-tags').hide();
    } else {
        $('#about-author-tags').show();
    }

    $(window).resize(function () {
        if (window.innerWidth < 768) {
            $('#navbar-brand-image').attr('src', '/Assets/img/FN_LOGO_mini.png');
            $('.navbar-brand').css('padding-left', '25px');
            $('#logo-image').hide();
            $('.logo .logo-social-media').css('right', '15px');
            $('.login-input').css("width", '80px');
            $('.login-input').css("margin-left", "15px");
            $('.login-btn').css("width", '50px');
            $('.login-btn').css("margin-left", "15px");
            $('#login-form').css("line-height", "");
            $('footer .about-author').css("height", "");
        } else {
            $('#navbar-brand-image').attr('src', '/Assets/img/FN_LOGO_short.png');
            $('.navbar-brand').css('padding-left', '');
            $('#logo-image').show();
            $('.logo .logo-social-media').css('right', '220px');
            $('.login-input').css("width", '9vw');
            $('.login-input').css("margin-left", "0");
            $('.login-btn').css("width", '6vw');
            $('.login-btn').css("margin-left", "0");
            $('#login-form').css("line-height", "45px");
            $('footer .about-author').css("height", "110px");
        }

        if (window.innerWidth < 380) {
            $('#about-author-tags').hide();
        } else {
            $('#about-author-tags').show();
        }
    });
});